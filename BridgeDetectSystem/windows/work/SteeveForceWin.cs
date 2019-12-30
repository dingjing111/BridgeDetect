using BridgeDetectSystem.adam;
using BridgeDetectSystem.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BridgeDetectSystem.windows.work
{
    public partial class SteeveForceWin : MetroFramework.Forms.MetroForm
    {
        public SteeveForceWin()
        {
            InitializeComponent();
        }
        AdamHelper adamhelper;
        double F1=0;
        double F2=0;
        double F3=0;
        double F4=0;
        Series f1;
        Series f2;
        Series f3;
        Series f4;
        private Thread addDataRunner;
        private delegate void AddDataDelegate();
        private AddDataDelegate addDataDel;

        private void SteeveForceWin_Load(object sender, EventArgs e)
        {
            adamhelper = AdamHelper.GetInstance();
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayData();
            
            
        }
        private void DisplayData()
        {
            try
            {
                Dictionary<int, Steeve> dicSteeve = adamhelper.steeveDic;//得到吊杆的字典集合，用方法得到力和位移
                double[] steeveForce = new double[4];//吊杆力数组，元素为double

                for (int i = 0; i < 4; i++)
                {
                    steeveForce[i] = dicSteeve[i].GetForce();//为吊杆力数组赋值值
                }
                F1 = steeveForce[0];
                F2 = steeveForce[1];
                F3 = steeveForce[2];
                F4 = steeveForce[3];
                lblF1.Text = steeveForce[0].ToString();
                lblF2.Text = steeveForce[1].ToString();
                lblF3.Text = steeveForce[2].ToString();
                lblF4.Text = steeveForce[3].ToString();
             }
            catch (Exception ex)
            {
                timer1.Enabled = false;
                MessageBox.Show("采集吊杆力，位移数据失败，请检查硬件后重启软件。" + ex.Message);
            }
        }

        /// <summary>
        /// 开始绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrawStart_Click(object sender, EventArgs e)
        {
            btnDrawStart.Enabled = false;
            btnEndDraw.Enabled = true;
            addDataRunner = new Thread(new ThreadStart(AddDataThreadLoop));
            addDataRunner.IsBackground = true;
            addDataDel = new AddDataDelegate(AddData);
            DateTime timeValue = DateTime.Now;
            DateTime minValue = timeValue.ToLocalTime();
            DateTime maxValue = timeValue.AddSeconds(600).ToLocalTime();

            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
            chart1.ChartAreas[0].AxisX.Title = "时间";
            chart1.ChartAreas[0].AxisY.Title ="吊杆力（kN）";
            chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
            chart1.Series.Clear();
            //曲线f1
            f1 = new Series();
            f1.ChartType = SeriesChartType.Spline;
            f1.BorderWidth = 1;
            f1.BorderColor = Color.Red;
            f1.LegendText = "一号吊杆";
            //f1.IsValueShownAsLabel = true;
            f1.XValueType = ChartValueType.DateTime;
            //f2
            f2 = new Series();
            f2.ChartType = SeriesChartType.Spline;
            f2.BorderWidth = 1;
            f2.BorderColor = Color.Orange;
            f2.XValueType = ChartValueType.DateTime;
            f2.LegendText = "二号吊杆";
            f3 = new Series();
            f3.ChartType = SeriesChartType.Spline;
            f3.BorderWidth = 1;
            f3.BorderColor = Color.Green;
            f3.XValueType = ChartValueType.DateTime;
            f3.LegendText = "三号吊杆";


            f4 = new Series();
            f4.ChartType = SeriesChartType.Spline;
            f4.BorderWidth = 1;
            f4.BorderColor = Color.Blue;
            f4.XValueType = ChartValueType.DateTime;
            f4.LegendText = "四号吊杆";
            chart1.Series.Add(f1);
            chart1.Series.Add(f2);
            chart1.Series.Add(f3);
            chart1.Series.Add(f4);

            addDataRunner.Start();
        }
        /// <summary>
        /// 委托的方法，实际绘制
        /// </summary>
        private void AddData()
        {
            DateTime timetemp = DateTime.Now;
            //f1曲线
            f1.Points.AddXY(timetemp.ToLocalTime(), F1);
            f2.Points.AddXY(timetemp.ToLocalTime(), F2);
            f3.Points.AddXY(timetemp.ToLocalTime(), F3);
            f4.Points.AddXY(timetemp.ToLocalTime(), F4);
            double removeBefore = timetemp.AddSeconds((double)(540) * (-1)).ToOADate();


            while (f1.Points[0].XValue < removeBefore)
            {
                f1.Points.RemoveAt(0);
                f2.Points.RemoveAt(0);
                f3.Points.RemoveAt(0);
                f4.Points.RemoveAt(0);

            }
            chart1.ChartAreas[0].AxisX.Minimum =f1.Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(f1.Points[0].XValue).AddSeconds(600).ToOADate();

            chart1.Invalidate();
        }

        private void AddDataThreadLoop()
        {
            try
            {
                while (true)
                {
                    chart1.Invoke(addDataDel);
                    Thread.Sleep(10000);
                }
            }catch(Exception e) { }
        }

        /// <summary>
        /// 结束绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndDraw_Click(object sender, EventArgs e)
        {
            if (addDataRunner != null)
            {
                addDataRunner.Abort();
                addDataRunner.Join();
                addDataRunner = null;
            }
            btnDrawStart.Enabled = true;
            btnEndDraw.Enabled = false;
        }

       
    }
}
