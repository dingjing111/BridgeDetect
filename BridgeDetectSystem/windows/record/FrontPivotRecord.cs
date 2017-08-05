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
    public partial class FrontPivotRecord : MetroFramework.Forms.MetroForm
    {
        public FrontPivotRecord()
        {
            InitializeComponent();
        }
        private void initial()
        {
            this.panel2.Height = this.panel1.Height * 1/ 15;
        }
        private void FrontPivotRecord_Load(object sender, EventArgs e)
        {
            this.initial();
        }
    }
}
