namespace BridgeDetectSystem
{
    partial class AmplifiedVideo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.btnAllVideo});
            this.menuStrip1.Location = new System.Drawing.Point(22, 72);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1108, 48);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnVideo1
            // 
            this.btnVideo1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVideo1.ForeColor = System.Drawing.Color.White;
            this.btnVideo1.Name = "btnVideo1";
            this.btnVideo1.Size = new System.Drawing.Size(71, 44);
            this.btnVideo1.Text = "1放大";
            // 
            // btnVideo2
            // 
            this.btnVideo2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVideo2.ForeColor = System.Drawing.Color.White;
            this.btnVideo2.Name = "btnVideo2";
            this.btnVideo2.Size = new System.Drawing.Size(71, 44);
            this.btnVideo2.Text = "2放大";
            // 
            // btnVideo3
            // 
            this.btnVideo3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVideo3.ForeColor = System.Drawing.Color.White;
            this.btnVideo3.Name = "btnVideo3";
            this.btnVideo3.Size = new System.Drawing.Size(71, 44);
            this.btnVideo3.Text = "3放大";
            // 
            // btnVideo4
            // 
            this.btnVideo4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVideo4.ForeColor = System.Drawing.Color.White;
            this.btnVideo4.Name = "btnVideo4";
            this.btnVideo4.Size = new System.Drawing.Size(71, 44);
            this.btnVideo4.Text = "4放大";
            // 
            // btnAllVideo
            // 
            this.btnAllVideo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllVideo.ForeColor = System.Drawing.Color.White;
            this.btnAllVideo.Name = "btnAllVideo";
            this.btnAllVideo.Size = new System.Drawing.Size(101, 44);
            this.btnAllVideo.Text = "全部显示";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(22, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 778);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1108, 778);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AmplifiedVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 922);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "AmplifiedVideo";
            this.Padding = new System.Windows.Forms.Padding(22, 72, 22, 24);
            this.Resizable = false;
            this.Text = "视频放大";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AmplifiedVideo_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}