namespace BridgeDetectSystem
{
    partial class VideoMonitorWin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnVideo1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVideo2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVideo3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVideo4 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAllVideo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.picBox4 = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.picBox3 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.picBox2 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.picBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox4)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox3)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(93)))), ((int)(((byte)(152)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVideo1,
            this.btnVideo2,
            this.btnVideo3,
            this.btnVideo4,
            this.btnAllVideo,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(22, 72);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1108, 48);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnVideo1
            // 
            this.btnVideo1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVideo1.ForeColor = System.Drawing.Color.White;
            this.btnVideo1.Name = "btnVideo1";
            this.btnVideo1.Size = new System.Drawing.Size(60, 44);
            this.btnVideo1.Text = "1放大";
            this.btnVideo1.Click += new System.EventHandler(this.btnVideo1_Click);
            // 
            // btnVideo2
            // 
            this.btnVideo2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVideo2.ForeColor = System.Drawing.Color.White;
            this.btnVideo2.Name = "btnVideo2";
            this.btnVideo2.Size = new System.Drawing.Size(60, 44);
            this.btnVideo2.Text = "2放大";
            this.btnVideo2.Click += new System.EventHandler(this.btnVideo2_Click);
            // 
            // btnVideo3
            // 
            this.btnVideo3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVideo3.ForeColor = System.Drawing.Color.White;
            this.btnVideo3.Name = "btnVideo3";
            this.btnVideo3.Size = new System.Drawing.Size(60, 44);
            this.btnVideo3.Text = "3放大";
            this.btnVideo3.Click += new System.EventHandler(this.btnVideo3_Click);
            // 
            // btnVideo4
            // 
            this.btnVideo4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVideo4.ForeColor = System.Drawing.Color.White;
            this.btnVideo4.Name = "btnVideo4";
            this.btnVideo4.Size = new System.Drawing.Size(60, 44);
            this.btnVideo4.Text = "4放大";
            this.btnVideo4.Click += new System.EventHandler(this.btnVideo4_Click);
            // 
            // btnAllVideo
            // 
            this.btnAllVideo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllVideo.ForeColor = System.Drawing.Color.White;
            this.btnAllVideo.Name = "btnAllVideo";
            this.btnAllVideo.Size = new System.Drawing.Size(84, 44);
            this.btnAllVideo.Text = "全部显示";
            this.btnAllVideo.Click += new System.EventHandler(this.btnAllVideo_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 44);
            this.toolStripMenuItem1.Text = " ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(22, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 778);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 389);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1108, 389);
            this.panel3.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.picBox4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(554, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(554, 389);
            this.panel7.TabIndex = 1;
            // 
            // picBox4
            // 
            this.picBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox4.Location = new System.Drawing.Point(0, 0);
            this.picBox4.Name = "picBox4";
            this.picBox4.Size = new System.Drawing.Size(554, 389);
            this.picBox4.TabIndex = 0;
            this.picBox4.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.picBox3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(554, 389);
            this.panel6.TabIndex = 0;
            // 
            // picBox3
            // 
            this.picBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox3.Location = new System.Drawing.Point(0, 0);
            this.picBox3.Name = "picBox3";
            this.picBox3.Size = new System.Drawing.Size(554, 389);
            this.picBox3.TabIndex = 0;
            this.picBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1108, 389);
            this.panel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.picBox2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(554, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(554, 389);
            this.panel5.TabIndex = 1;
            // 
            // picBox2
            // 
            this.picBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox2.Location = new System.Drawing.Point(0, 0);
            this.picBox2.Name = "picBox2";
            this.picBox2.Size = new System.Drawing.Size(554, 389);
            this.picBox2.TabIndex = 0;
            this.picBox2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.picBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(554, 389);
            this.panel4.TabIndex = 0;
            // 
            // picBox1
            // 
            this.picBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox1.Location = new System.Drawing.Point(0, 0);
            this.picBox1.Name = "picBox1";
            this.picBox1.Size = new System.Drawing.Size(554, 389);
            this.picBox1.TabIndex = 0;
            this.picBox1.TabStop = false;
            // 
            // VideoMonitorWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 922);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "VideoMonitorWin";
            this.Padding = new System.Windows.Forms.Padding(22, 72, 22, 24);
            this.Resizable = false;
            this.Text = "视频监控";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoMonitorWin_FormClosing_1);
            this.Load += new System.EventHandler(this.VideoMonitor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox4)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox2)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnVideo1;
        private System.Windows.Forms.ToolStripMenuItem btnVideo2;
        private System.Windows.Forms.ToolStripMenuItem btnVideo3;
        private System.Windows.Forms.ToolStripMenuItem btnVideo4;
        private System.Windows.Forms.ToolStripMenuItem btnAllVideo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox picBox4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox picBox3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox picBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox picBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}