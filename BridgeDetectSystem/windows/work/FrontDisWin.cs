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
    public partial class FrontDisWin : MetroFramework.Forms.MetroForm
    {
        public FrontDisWin()
        {
            InitializeComponent();
        }
        AdamHelper adamhelper;

        Series f1;
        Series f2;
        Series f3;
        Series f4;

        private Thread addDataRunner;
        private delegate void AddDataDelegate();
        private AddDataDelegate addDataDel;

        private double firstStandard;
        private double secondStanard;
        private double threeStandard;
        private double fourStandard;
        double s1=0;
        double s2 = 0;
        double s3 = 0;
        double s4 = 0;

        private void FrontDisWin_Load(object sender, EventArgs e)
        {
            adamhelper = AdamHelper.GetInstance();
        }
        /// <summary>
        /// 定时器，刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayData();
        }

        /// <summary>
        /// 力数据显示=方法
        /// </summary>
        private void DisplayData()
        {
            try
            {
                firstStandard = adamhelper.first_frontPivotDisStandard;
                secondStanard = adamhelper.second_frontPivotDisStandard;
                threeStandard = adamhelper.three_standard;
                fourStandard = adamhelper.four_standard;//四个基准
                Dictionary<int, FrontPivot> dicFrontPivot = adamhelper.frontPivotDic;
                double[] frontPivotDis = new double[4];//沉降位移数组           
                frontPivotDis[0] = Math.Round(firstStandard - dicFrontPivot[0].GetDisplace(), 1);
                frontPivotDis[1] = Math.Round(secondStanard - dicFrontPivot[1].GetDisplace(), 1);
                frontPivotDis[2] = Math.Round(threeStandard - dicFrontPivot[2].GetDisplace(), 1);
                frontPivotDis[3] = Math.Round(fourStandard - dicFrontPivot[3].GetDisplace(), 1);
                for (int k = 0; k < 4; k++)
                {
                    frontPivotDis[k] = Math.Abs(frontPivotDis[k]);
                }
                s1 = frontPivotDis[0];//绘制曲线纵坐标的值
                s2 = frontPivotDis[1];
                s3 = frontPivotDis[2];
                s4 = frontPivotDis[3];
                lblS1.Text = frontPivotDis[0].ToString();
                lblS2.Text = frontPivotDis[1].ToString();
                lblS3.Text = frontPivotDis[2].ToString();
                lblS4.Text = frontPivotDis[3].ToString();
            }

            catch (Exception ex)
            {
                timer1.Enabled = false;
                MessageBox.Show("采集前支点位移数据失败，请检查硬件后重启软件。" + ex.Message);
            }

        }

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
            chart1.ChartAreas[0].AxisY.Title = "前支架沉降位移（mm）";
            chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();
            chart1.Series.Clear();
            //曲线f1,f2,f3,f4
            f1 = new Series();
            f1.ChartType = SeriesChartType.Spline;
            f1.BorderWidth = 1;
            f1.BorderColor = Color.Red;
            //f1.IsValueShownAsLabel = true;
            f1.LegendText = "一号前支点";
            f1.XValueType = ChartValueType.DateTime;
            //f2
            f2 = new Series();
            f2.ChartType = SeriesChartType.Spline;
            f2.BorderWidth = 1;
            f2.BorderColor = Color.Orange;
            f2.LegendText = "二号前支点";
            f2.XValueType = ChartValueType.DateTime;

            f3 = new Series();
            f3.ChartType = SeriesChartType.Spline;
            f3.BorderWidth = 1;
            f3.BorderColor = Color.Green;
            f3.LegendText = "三号前支点";
            f3.XValueType = ChartValueType.DateTime;

            f4 = new Series();
            f4.ChartType = SeriesChartType.Spline;
            f4.BorderWidth = 1;
            f4.BorderColor = Color.Blue;
            f4.LegendText = "四号前支点";
            f4.XValueType = ChartValueType.DateTime;
            chart1.Series.Add(f1);
            chart1.Series.Add(f2);
            chart1.Series.Add(f3);
            chart1.Series.Add(f4);

            addDataRunner.Start();
        }

        private void AddData()
        {
            DateTime timetemp = DateTime.Now;
            //f1曲线
            f1.Points.AddXY(timetemp.ToLocalTime(), s1);
            f2.Points.AddXY(timetemp.ToLocalTime(), s2);
            f3.Points.AddXY(timetemp.ToLocalTime(), s3);
            f4.Points.AddXY(timetemp.ToLocalTime(), s4);
            double removeBefore = timetemp.AddSeconds((double)(500) * (-1)).ToOADate();


            while (f1.Points[0].XValue < removeBefore)
            {
                f1.Points.RemoveAt(0);
                f2.Points.RemoveAt(0);
                f3.Points.RemoveAt(0);
                f4.Points.RemoveAt(0);

            }
            chart1.ChartAreas[0].AxisX.Minimum = f1.Points[0].XValue;
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
            }
            catch (Exception e) { }
        }
    }
}
