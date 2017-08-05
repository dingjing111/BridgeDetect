namespace BridgeDetectSystem
{
    partial class MainWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnFirstPage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUserSet = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAlarmRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.HistoryDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSteeveForce = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSteeveDis = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAnchorForce = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFrontPivot = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnWalking = new System.Windows.Forms.Button();
            this.btnPouring = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(93)))), ((int)(((byte)(152)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFirstPage,
            this.btnUserSet,
            this.btnSetParameter,
            this.btnAlarmRecord,
            this.HistoryDataToolStripMenuItem,
            this.btnExit});
            this.menuStrip1.Location = new System.Drawing.Point(22, 72);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1108, 48);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFirstPage.ForeColor = System.Drawing.Color.White;
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(61, 44);
            this.btnFirstPage.Text = "首页";
            // 
            // btnUserSet
            // 
            this.btnUserSet.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUserSet.ForeColor = System.Drawing.Color.White;
            this.btnUserSet.Name = "btnUserSet";
            this.btnUserSet.Size = new System.Drawing.Size(101, 44);
            this.btnUserSet.Text = "系统设置";
            this.btnUserSet.Click += new System.EventHandler(this.btnUserSet_Click);
            // 
            // btnSetParameter
            // 
            this.btnSetParameter.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetParameter.ForeColor = System.Drawing.Color.White;
            this.btnSetParameter.Name = "btnSetParameter";
            this.btnSetParameter.Size = new System.Drawing.Size(101, 44);
            this.btnSetParameter.Text = "参数设置";
            this.btnSetParameter.Click += new System.EventHandler(this.btnSetParameter_Click);
            // 
            // btnAlarmRecord
            // 
            this.btnAlarmRecord.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAlarmRecord.ForeColor = System.Drawing.Color.White;
            this.btnAlarmRecord.Name = "btnAlarmRecord";
            this.btnAlarmRecord.Size = new System.Drawing.Size(101, 44);
            this.btnAlarmRecord.Text = "历史报警";
            this.btnAlarmRecord.Click += new System.EventHandler(this.btnAlarmRecord_Click);
            // 
            // HistoryDataToolStripMenuItem
            // 
            this.HistoryDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSteeveForce,
            this.btnSteeveDis,
            this.btnAnchorForce,
            this.btnFrontPivot});
            this.HistoryDataToolStripMenuItem.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HistoryDataToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.HistoryDataToolStripMenuItem.Name = "HistoryDataToolStripMenuItem";
            this.HistoryDataToolStripMenuItem.Size = new System.Drawing.Size(101, 44);
            this.HistoryDataToolStripMenuItem.Text = "历史数据";
            // 
            // btnSteeveForce
            // 
            this.btnSteeveForce.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSteeveForce.ForeColor = System.Drawing.Color.White;
            this.btnSteeveForce.Name = "btnSteeveForce";
            this.btnSteeveForce.Size = new System.Drawing.Size(264, 26);
            this.btnSteeveForce.Text = "吊杆力检测记录";
            this.btnSteeveForce.Click += new System.EventHandler(this.btnSteeveForce_Click);
            // 
            // btnSteeveDis
            // 
            this.btnSteeveDis.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSteeveDis.ForeColor = System.Drawing.Color.White;
            this.btnSteeveDis.Name = "btnSteeveDis";
            this.btnSteeveDis.Size = new System.Drawing.Size(264, 26);
            this.btnSteeveDis.Text = "吊杆位移检测记录";
            this.btnSteeveDis.Click += new System.EventHandler(this.btnSteeveDis_Click);
            // 
            // btnAnchorForce
            // 
            this.btnAnchorForce.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAnchorForce.ForeColor = System.Drawing.Color.White;
            this.btnAnchorForce.Name = "btnAnchorForce";
            this.btnAnchorForce.Size = new System.Drawing.Size(264, 26);
            this.btnAnchorForce.Text = "锚杆力检测记录";
            this.btnAnchorForce.Click += new System.EventHandler(this.btnAnchorForce_Click);
            // 
            // btnFrontPivot
            // 
            this.btnFrontPivot.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFrontPivot.ForeColor = System.Drawing.Color.White;
            this.btnFrontPivot.Name = "btnFrontPivot";
            this.btnFrontPivot.Size = new System.Drawing.Size(264, 26);
            this.btnFrontPivot.Text = "前支点位移检测记录";
            this.btnFrontPivot.Click += new System.EventHandler(this.btnFrontPivot_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(61, 44);
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(22, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 778);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel1.Controls.Add(this.btnWalking, 7, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnPouring, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox3, 6, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.006113F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.06113F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.43247F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.978894F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.51528F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.006113F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1108, 778);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnWalking
            // 
            this.btnWalking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(93)))), ((int)(((byte)(152)))));
            this.btnWalking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnWalking.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWalking.ForeColor = System.Drawing.Color.White;
            this.btnWalking.Location = new System.Drawing.Point(776, 643);
            this.btnWalking.Name = "btnWalking";
            this.btnWalking.Size = new System.Drawing.Size(104, 91);
            this.btnWalking.TabIndex = 2;
            this.btnWalking.Text = "行走状态";
            this.btnWalking.UseVisualStyleBackColor = false;
            this.btnWalking.Click += new System.EventHandler(this.btnWalking_Click);
            // 
            // btnPouring
            // 
            this.btnPouring.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(93)))), ((int)(((byte)(152)))));
            this.btnPouring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPouring.ForeColor = System.Drawing.Color.White;
            this.btnPouring.Location = new System.Drawing.Point(224, 643);
            this.btnPouring.Name = "btnPouring";
            this.btnPouring.Size = new System.Drawing.Size(104, 91);
            this.btnPouring.TabIndex = 5;
            this.btnPouring.Text = "浇筑状态";
            this.btnPouring.UseVisualStyleBackColor = false;
            this.btnPouring.Click += new System.EventHandler(this.btnPouring_Click);
            // 
            // pictureBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox2, 3);
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(36, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBox2, 2);
            this.pictureBox2.Size = new System.Drawing.Size(502, 534);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox3, 3);
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(566, 41);
            this.pictureBox3.Name = "pictureBox3";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBox3, 2);
            this.pictureBox3.Size = new System.Drawing.Size(502, 534);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 922);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "MainWin";
            this.Padding = new System.Windows.Forms.Padding(22, 72, 22, 24);
            this.Resizable = false;
            this.Text = "欢迎使用桥梁挂篮自动检测安全系统";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnFirstPage;
        private System.Windows.Forms.ToolStripMenuItem btnUserSet;
        private System.Windows.Forms.ToolStripMenuItem btnSetParameter;
        private System.Windows.Forms.ToolStripMenuItem btnAlarmRecord;
        private System.Windows.Forms.ToolStripMenuItem HistoryDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem btnSteeveForce;
        private System.Windows.Forms.ToolStripMenuItem btnSteeveDis;
        private System.Windows.Forms.ToolStripMenuItem btnAnchorForce;
        private System.Windows.Forms.ToolStripMenuItem btnFrontPivot;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnWalking;
        private System.Windows.Forms.Button btnPouring;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}