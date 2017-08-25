using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgeDetectSystem.service
{
   public class SetTextValueManager
    {
        public static void SetValueToText(double[] array, ref MetroTextBox txt1, ref MetroTextBox txt2, 
            ref MetroTextBox txt3, ref MetroTextBox txt4, ref MetroTextBox txtmax, ref MetroTextBox txtmaxdiff)
        {
            double Max = array.Max();
            double Min = array.Min();
            double MaxDiff = Max - Min;
            txt1.Text = array[0].ToString();
            txt2.Text = array[1].ToString();
            txt3.Text = array[2].ToString();
            txt4.Text = array[3].ToString();
            txtmax.Text = Max.ToString();
            txtmaxdiff.Text = MaxDiff.ToString();
        }
    }
}
