namespace BridgeDetectSystem
{
    partial class SetParameter
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
            this.btnFirstPage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grpSetAnchorPara = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAnchorForceLimit = new MetroFramework.Controls.MetroLabel();
            this.txtAnchorForceLimit = new MetroFramework.Controls.MetroTextBox();
            this.lblAnchorForceDiffLimit = new MetroFramework.Controls.MetroLabel();
            this.lblFrontPivotDisLimit = new MetroFramework.Controls.MetroLabel();
            this.txtAnchorForceDiffLimit = new MetroFramework.Controls.MetroTextBox();
            this.txtFrontPivotDisLimit = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpSetSteevePara = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUpDisLimit = new MetroFramework.Controls.MetroLabel();
            this.txtSteeveGoDisLimit = new MetroFramework.Controls.MetroTextBox();
            this.lblDownDisLimit = new MetroFramework.Controls.MetroLabel();
            this.lblTotalDisDiffLimit = new MetroFramework.Controls.MetroLabel();
            this.lblSteeveForceLimit = new MetroFramework.Controls.MetroLabel();
            this.txtDownDisLimit = new MetroFramework.Controls.MetroTextBox();
            this.txtTotalDisDiffLimit = new MetroFramework.Controls.MetroTextBox();
            this.txtSteeveForceLimit = new MetroFramework.Controls.MetroTextBox();
            this.lblSteeveForceDiffLimit = new MetroFramework.Controls.MetroLabel();
            this.txtSteeveForceDiffLimit = new MetroFramework.Controls.MetroTextBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grpSetAnchorPara.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpSetSteevePara.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(93)))), ((int)(((byte)(152)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFirstPage,
            this.btnExit});
            this.menuStrip1.Location = new System.Drawing.Point(22, 72);
            this.menuStrip1.Name = "menuStrip1";
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
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
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
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(22, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 778);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grpSetAnchorPara);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(550, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(558, 778);
            this.panel3.TabIndex = 1;
            // 
            // grpSetAnchorPara
            // 
            this.grpSetAnchorPara.Controls.Add(this.tableLayoutPanel2);
            this.grpSetAnchorPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSetAnchorPara.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpSetAnchorPara.Location = new System.Drawing.Point(0, 0);
            this.grpSetAnchorPara.Name = "grpSetAnchorPara";
            this.grpSetAnchorPara.Size = new System.Drawing.Size(558, 778);
            this.grpSetAnchorPara.TabIndex = 0;
            this.grpSetAnchorPara.TabStop = false;
            this.grpSetAnchorPara.Text = "锚杆与前支点报警参数设置";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Controls.Add(this.lblAnchorForceLimit, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtAnchorForceLimit, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblAnchorForceDiffLimit, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblFrontPivotDisLimit, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtAnchorForceDiffLimit, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtFrontPivotDisLimit, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.btnBack, 4, 8);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 26);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 12;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(552, 749);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // lblAnchorForceLimit
            // 
            this.lblAnchorForceLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblAnchorForceLimit, 2);
            this.lblAnchorForceLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAnchorForceLimit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblAnchorForceLimit.Location = new System.Drawing.Point(3, 65);
            this.lblAnchorForceLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblAnchorForceLimit.Name = "lblAnchorForceLimit";
            this.lblAnchorForceLimit.Size = new System.Drawing.Size(214, 56);
            this.lblAnchorForceLimit.TabIndex = 0;
            this.lblAnchorForceLimit.Text = "锚杆受力上限(kN)";
            this.lblAnchorForceLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAnchorForceLimit
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtAnchorForceLimit, 2);
            this.txtAnchorForceLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnchorForceLimit.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtAnchorForceLimit.Location = new System.Drawing.Point(278, 65);
            this.txtAnchorForceLimit.Name = "txtAnchorForceLimit";
            this.txtAnchorForceLimit.Size = new System.Drawing.Size(214, 56);
            this.txtAnchorForceLimit.TabIndex = 1;
            // 
            // lblAnchorForceDiffLimit
            // 
            this.lblAnchorForceDiffLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblAnchorForceDiffLimit, 2);
            this.lblAnchorForceDiffLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAnchorForceDiffLimit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblAnchorForceDiffLimit.Location = new System.Drawing.Point(3, 189);
            this.lblAnchorForceDiffLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblAnchorForceDiffLimit.Name = "lblAnchorForceDiffLimit";
            this.lblAnchorForceDiffLimit.Size = new System.Drawing.Size(214, 56);
            this.lblAnchorForceDiffLimit.TabIndex = 2;
            this.lblAnchorForceDiffLimit.Text = "锚杆力差值上限(kN)";
            this.lblAnchorForceDiffLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFrontPivotDisLimit
            // 
            this.lblFrontPivotDisLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblFrontPivotDisLimit, 2);
            this.lblFrontPivotDisLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFrontPivotDisLimit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblFrontPivotDisLimit.Location = new System.Drawing.Point(3, 313);
            this.lblFrontPivotDisLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblFrontPivotDisLimit.Name = "lblFrontPivotDisLimit";
            this.lblFrontPivotDisLimit.Size = new System.Drawing.Size(214, 56);
            this.lblFrontPivotDisLimit.TabIndex = 3;
            this.lblFrontPivotDisLimit.Text = "前支点位移上限(cm)";
            this.lblFrontPivotDisLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAnchorForceDiffLimit
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtAnchorForceDiffLimit, 2);
            this.txtAnchorForceDiffLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnchorForceDiffLimit.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtAnchorForceDiffLimit.Location = new System.Drawing.Point(278, 189);
            this.txtAnchorForceDiffLimit.Name = "txtAnchorForceDiffLimit";
            this.txtAnchorForceDiffLimit.Size = new System.Drawing.Size(214, 56);
            this.txtAnchorForceDiffLimit.TabIndex = 5;
            // 
            // txtFrontPivotDisLimit
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtFrontPivotDisLimit, 2);
            this.txtFrontPivotDisLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFrontPivotDisLimit.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtFrontPivotDisLimit.Location = new System.Drawing.Point(278, 313);
            this.txtFrontPivotDisLimit.Name = "txtFrontPivotDisLimit";
            this.txtFrontPivotDisLimit.Size = new System.Drawing.Size(214, 56);
            this.txtFrontPivotDisLimit.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(113, 499);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 56);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(388, 499);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(104, 56);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grpSetSteevePara);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 778);
            this.panel2.TabIndex = 0;
            // 
            // grpSetSteevePara
            // 
            this.grpSetSteevePara.Controls.Add(this.tableLayoutPanel1);
            this.grpSetSteevePara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSetSteevePara.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpSetSteevePara.Location = new System.Drawing.Point(0, 0);
            this.grpSetSteevePara.Name = "grpSetSteevePara";
            this.grpSetSteevePara.Size = new System.Drawing.Size(550, 778);
            this.grpSetSteevePara.TabIndex = 0;
            this.grpSetSteevePara.TabStop = false;
            this.grpSetSteevePara.Text = "吊杆报警参数设置";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.lblUpDisLimit, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSteeveGoDisLimit, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDownDisLimit, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalDisDiffLimit, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblSteeveForceLimit, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtDownDisLimit, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTotalDisDiffLimit, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtSteeveForceLimit, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblSteeveForceDiffLimit, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtSteeveForceDiffLimit, 2, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 749);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lblUpDisLimit
            // 
            this.lblUpDisLimit.AutoSize = true;
            this.lblUpDisLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpDisLimit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblUpDisLimit.Location = new System.Drawing.Point(3, 65);
            this.lblUpDisLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblUpDisLimit.Name = "lblUpDisLimit";
            this.lblUpDisLimit.Size = new System.Drawing.Size(211, 56);
            this.lblUpDisLimit.TabIndex = 0;
            this.lblUpDisLimit.Text = "吊杆上升位移上限(cm)";
            this.lblUpDisLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSteeveGoDisLimit
            // 
            this.txtSteeveGoDisLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSteeveGoDisLimit.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtSteeveGoDisLimit.Location = new System.Drawing.Point(274, 65);
            this.txtSteeveGoDisLimit.Name = "txtSteeveGoDisLimit";
            this.txtSteeveGoDisLimit.Size = new System.Drawing.Size(211, 56);
            this.txtSteeveGoDisLimit.TabIndex = 1;
            // 
            // lblDownDisLimit
            // 
            this.lblDownDisLimit.AutoSize = true;
            this.lblDownDisLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDownDisLimit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblDownDisLimit.Location = new System.Drawing.Point(3, 189);
            this.lblDownDisLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblDownDisLimit.Name = "lblDownDisLimit";
            this.lblDownDisLimit.Size = new System.Drawing.Size(211, 56);
            this.lblDownDisLimit.TabIndex = 2;
            this.lblDownDisLimit.Text = "吊杆下降位移上限(cm)";
            this.lblDownDisLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalDisDiffLimit
            // 
            this.lblTotalDisDiffLimit.AutoSize = true;
            this.lblTotalDisDiffLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalDisDiffLimit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTotalDisDiffLimit.Location = new System.Drawing.Point(3, 313);
            this.lblTotalDisDiffLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblTotalDisDiffLimit.Name = "lblTotalDisDiffLimit";
            this.lblTotalDisDiffLimit.Size = new System.Drawing.Size(211, 56);
            this.lblTotalDisDiffLimit.TabIndex = 3;
            this.lblTotalDisDiffLimit.Text = "吊杆总位移差上限(cm)";
            this.lblTotalDisDiffLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSteeveForceLimit
            // 
            this.lblSteeveForceLimit.AutoSize = true;
            this.lblSteeveForceLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSteeveForceLimit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblSteeveForceLimit.Location = new System.Drawing.Point(3, 437);
            this.lblSteeveForceLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblSteeveForceLimit.Name = "lblSteeveForceLimit";
            this.lblSteeveForceLimit.Size = new System.Drawing.Size(211, 56);
            this.lblSteeveForceLimit.TabIndex = 4;
            this.lblSteeveForceLimit.Text = "吊杆受力上限(kN)";
            this.lblSteeveForceLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDownDisLimit
            // 
            this.txtDownDisLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDownDisLimit.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtDownDisLimit.Location = new System.Drawing.Point(274, 189);
            this.txtDownDisLimit.Name = "txtDownDisLimit";
            this.txtDownDisLimit.Size = new System.Drawing.Size(211, 56);
            this.txtDownDisLimit.TabIndex = 5;
            // 
            // txtTotalDisDiffLimit
            // 
            this.txtTotalDisDiffLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalDisDiffLimit.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtTotalDisDiffLimit.Location = new System.Drawing.Point(274, 313);
            this.txtTotalDisDiffLimit.Name = "txtTotalDisDiffLimit";
            this.txtTotalDisDiffLimit.Size = new System.Drawing.Size(211, 56);
            this.txtTotalDisDiffLimit.TabIndex = 6;
            // 
            // txtSteeveForceLimit
            // 
            this.txtSteeveForceLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSteeveForceLimit.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtSteeveForceLimit.Location = new System.Drawing.Point(274, 437);
            this.txtSteeveForceLimit.Name = "txtSteeveForceLimit";
            this.txtSteeveForceLimit.Size = new System.Drawing.Size(211, 56);
            this.txtSteeveForceLimit.TabIndex = 7;
            // 
            // lblSteeveForceDiffLimit
            // 
            this.lblSteeveForceDiffLimit.AutoSize = true;
            this.lblSteeveForceDiffLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSteeveForceDiffLimit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblSteeveForceDiffLimit.Location = new System.Drawing.Point(3, 561);
            this.lblSteeveForceDiffLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblSteeveForceDiffLimit.Name = "lblSteeveForceDiffLimit";
            this.lblSteeveForceDiffLimit.Size = new System.Drawing.Size(211, 56);
            this.lblSteeveForceDiffLimit.TabIndex = 8;
            this.lblSteeveForceDiffLimit.Text = "吊杆力差值上限(kN)";
            this.lblSteeveForceDiffLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSteeveForceDiffLimit
            // 
            this.txtSteeveForceDiffLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSteeveForceDiffLimit.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtSteeveForceDiffLimit.Location = new System.Drawing.Point(274, 561);
            this.txtSteeveForceDiffLimit.Name = "txtSteeveForceDiffLimit";
            this.txtSteeveForceDiffLimit.Size = new System.Drawing.Size(211, 56);
            this.txtSteeveForceDiffLimit.TabIndex = 9;
            // 
            // SetParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 922);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "SetParameter";
            this.Padding = new System.Windows.Forms.Padding(22, 72, 22, 24);
            this.Resizable = false;
            this.Text = "参数设置";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SteeveParaSet_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.grpSetAnchorPara.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.grpSetSteevePara.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnFirstPage;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grpSetAnchorPara;
        private System.Windows.Forms.GroupBox grpSetSteevePara;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroLabel lblUpDisLimit;
        private MetroFramework.Controls.MetroTextBox txtSteeveGoDisLimit;
        private MetroFramework.Controls.MetroLabel lblDownDisLimit;
        private MetroFramework.Controls.MetroLabel lblTotalDisDiffLimit;
        private MetroFramework.Controls.MetroLabel lblSteeveForceLimit;
        private MetroFramework.Controls.MetroTextBox txtDownDisLimit;
        private MetroFramework.Controls.MetroTextBox txtTotalDisDiffLimit;
        private MetroFramework.Controls.MetroTextBox txtSteeveForceLimit;
        private MetroFramework.Controls.MetroLabel lblSteeveForceDiffLimit;
        private MetroFramework.Controls.MetroTextBox txtSteeveForceDiffLimit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroLabel lblAnchorForceLimit;
        private MetroFramework.Controls.MetroTextBox txtAnchorForceLimit;
        private MetroFramework.Controls.MetroLabel lblAnchorForceDiffLimit;
        private MetroFramework.Controls.MetroLabel lblFrontPivotDisLimit;
        private MetroFramework.Controls.MetroTextBox txtAnchorForceDiffLimit;
        private MetroFramework.Controls.MetroTextBox txtFrontPivotDisLimit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
    }
}