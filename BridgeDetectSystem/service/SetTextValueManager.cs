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
            txt1.Text = array[0].ToString();
            txt2.Text = array[1].ToString();
            txt3.Text = array[2].ToString();
            txt4.Text = array[3].ToString();
            double[] arrayAbs = new double[array.Length];
            for (int i = 0; i <4; i++)
            {
                arrayAbs[i] = array[i];
            }
            double max = arrayAbs.Max();
       
            double maxdiff = array.Max() - array.Min();
         
            txtmax.Text = max.ToString();
            txtmaxdiff.Text = maxdiff.ToString();

        }
        public static void set4(double[] a, ref MetroTextBox txt1, ref MetroTextBox txt2, ref MetroTextBox txt3, ref MetroTextBox txt4)
       {
            txt1.Text = a[0].ToString();
            txt2.Text = a[1].ToString();
            txt3.Text = a[2].ToString();
            txt4.Text = a[3].ToString();
        }

    }
}
