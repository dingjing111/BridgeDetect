using BridgeDetectSystem.adam;
using BridgeDetectSystem.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BridgeDetectSystem
{
    public partial class testform222 : Form
    {
        AdamHelper adamHelper;
        double[] f=new double[8];
        public testform222()
        {
            InitializeComponent();
            adamHelper = AdamHelper.GetInstance();
            
        }

        private void testform222_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Dictionary<int, Steeve> dicSteeve = adamHelper.steeveDic;
            double[] steeveForce = new double[dicSteeve.Count];//吊杆力数组，元素为double
            double[] steeveDis = new double[dicSteeve.Count];//吊杆位移数组，元素为double
            double[] realSteeveDis = new double[4];
            for (int i = 0; i < 4; i++)
            {
                steeveForce[i] = dicSteeve[i].GetForce();//为吊杆力数组赋值值
                realSteeveDis[i] = Math.Round(dicSteeve[i].GetDisplace(), 1);//真实距离
                steeveDis[i] = dicSteeve[i].GetDisplace() - adamHelper.standardlist[i];//升降位移
                steeveDis[i] = Math.Round(steeveDis[i], 1);  //保留一位小数

            }
            label1.Text = steeveForce[0].ToString();
            label2.Text = steeveForce[1].ToString();
            label3.Text = steeveForce[2].ToString();
            label4.Text = steeveForce[3].ToString();
        }
    }
}
