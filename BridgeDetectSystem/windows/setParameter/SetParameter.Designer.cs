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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetParameter));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grpSetAnchorPara = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAnchorForceLimit = new MetroFramework.Controls.MetroLabel();
            this.lblAnchorForceDiffLimit = new MetroFramework.Controls.MetroLabel();
            this.lblFrontPivotDisLimit = new MetroFramework.Controls.MetroLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtAnchorForceLimit = new System.Windows.Forms.NumericUpDown();
            this.txtAnchorForceDiffLimit = new System.Windows.Forms.NumericUpDown();
            this.txtFrontPivotDisLimit = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpSetSteevePara = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUpDis = new MetroFramework.Controls.MetroLabel();
            this.lblDownDis = new MetroFramework.Controls.MetroLabel();
            this.lblAllowDisDiffLimit = new MetroFramework.Controls.MetroLabel();
            this.lblSteeveDisDiffLimit = new MetroFramework.Controls.MetroLabel();
            this.lblSteeveForceLimit = new MetroFramework.Controls.MetroLabel();
            this.lblSteeveForceDiffLimit = new MetroFramework.Controls.MetroLabel();
            this.txtBasketAllowDisDiffLimit = new System.Windows.Forms.NumericUpDown();
            this.txtBasketUpDisLimit = new System.Windows.Forms.NumericUpDown();
            this.txtBasketDownDisLimit = new System.Windows.Forms.NumericUpDown();
            this.txtSteeveDisDiffLimit = new System.Windows.Forms.NumericUpDown();
            this.txtSteeveForceUpLimit = new System.Windows.Forms.NumericUpDown();
            this.txtSteeveForceDiffLimit = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grpSetAnchorPara.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnchorForceLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnchorForceDiffLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrontPivotDisLimit)).BeginInit();
            this.panel2.SuspendLayout();
            this.grpSetSteevePara.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasketAllowDisDiffLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasketUpDisLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasketDownDisLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSteeveDisDiffLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSteeveForceUpLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSteeveForceDiffLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(22, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 826);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grpSetAnchorPara);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(550, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(558, 826);
            this.panel3.TabIndex = 1;
            // 
            // grpSetAnchorPara
            // 
            this.grpSetAnchorPara.Controls.Add(this.tableLayoutPanel2);
            this.grpSetAnchorPara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSetAnchorPara.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpSetAnchorPara.Location = new System.Drawing.Point(0, 0);
            this.grpSetAnchorPara.Name = "grpSetAnchorPara";
            this.grpSetAnchorPara.Size = new System.Drawing.Size(558, 826);
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
            this.tableLayoutPanel2.Controls.Add(this.lblAnchorForceDiffLimit, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblFrontPivotDisLimit, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.btnBack, 4, 8);
            this.tableLayoutPanel2.Controls.Add(this.txtAnchorForceLimit, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtAnchorForceDiffLimit, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtFrontPivotDisLimit, 3, 5);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(552, 797);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // lblAnchorForceLimit
            // 
            this.lblAnchorForceLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblAnchorForceLimit, 2);
            this.lblAnchorForceLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAnchorForceLimit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblAnchorForceLimit.Location = new System.Drawing.Point(3, 69);
            this.lblAnchorForceLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblAnchorForceLimit.Name = "lblAnchorForceLimit";
            this.lblAnchorForceLimit.Size = new System.Drawing.Size(214, 60);
            this.lblAnchorForceLimit.TabIndex = 0;
            this.lblAnchorForceLimit.Text = "锚杆受力上限(kN)";
            this.lblAnchorForceLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAnchorForceDiffLimit
            // 
            this.lblAnchorForceDiffLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblAnchorForceDiffLimit, 2);
            this.lblAnchorForceDiffLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAnchorForceDiffLimit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblAnchorForceDiffLimit.Location = new System.Drawing.Point(3, 201);
            this.lblAnchorForceDiffLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblAnchorForceDiffLimit.Name = "lblAnchorForceDiffLimit";
            this.lblAnchorForceDiffLimit.Size = new System.Drawing.Size(214, 60);
            this.lblAnchorForceDiffLimit.TabIndex = 2;
            this.lblAnchorForceDiffLimit.Text = "锚杆力差值上限(kN)";
            this.lblAnchorForceDiffLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFrontPivotDisLimit
            // 
            this.lblFrontPivotDisLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblFrontPivotDisLimit, 2);
            this.lblFrontPivotDisLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFrontPivotDisLimit.Location = new System.Drawing.Point(3, 333);
            this.lblFrontPivotDisLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblFrontPivotDisLimit.Name = "lblFrontPivotDisLimit";
            this.lblFrontPivotDisLimit.Size = new System.Drawing.Size(214, 60);
            this.lblFrontPivotDisLimit.TabIndex = 3;
            this.lblFrontPivotDisLimit.Text = "前支点沉降位移上限(mm)";
            this.lblFrontPivotDisLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(113, 531);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 60);
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
            this.btnBack.Location = new System.Drawing.Point(388, 531);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(104, 60);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtAnchorForceLimit
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtAnchorForceLimit, 2);
            this.txtAnchorForceLimit.DecimalPlaces = 1;
            this.txtAnchorForceLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnchorForceLimit.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAnchorForceLimit.Location = new System.Drawing.Point(276, 67);
            this.txtAnchorForceLimit.Margin = new System.Windows.Forms.Padding(1);
            this.txtAnchorForceLimit.Name = "txtAnchorForceLimit";
            this.txtAnchorForceLimit.Size = new System.Drawing.Size(218, 53);
            this.txtAnchorForceLimit.TabIndex = 9;
            this.txtAnchorForceLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAnchorForceDiffLimit
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtAnchorForceDiffLimit, 2);
            this.txtAnchorForceDiffLimit.DecimalPlaces = 1;
            this.txtAnchorForceDiffLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnchorForceDiffLimit.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAnchorForceDiffLimit.Location = new System.Drawing.Point(278, 201);
            this.txtAnchorForceDiffLimit.Name = "txtAnchorForceDiffLimit";
            this.txtAnchorForceDiffLimit.Size = new System.Drawing.Size(214, 53);
            this.txtAnchorForceDiffLimit.TabIndex = 10;
            this.txtAnchorForceDiffLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFrontPivotDisLimit
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtFrontPivotDisLimit, 2);
            this.txtFrontPivotDisLimit.DecimalPlaces = 1;
            this.txtFrontPivotDisLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFrontPivotDisLimit.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFrontPivotDisLimit.Location = new System.Drawing.Point(278, 333);
            this.txtFrontPivotDisLimit.Name = "txtFrontPivotDisLimit";
            this.txtFrontPivotDisLimit.Size = new System.Drawing.Size(214, 53);
            this.txtFrontPivotDisLimit.TabIndex = 11;
            this.txtFrontPivotDisLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grpSetSteevePara);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 826);
            this.panel2.TabIndex = 0;
            // 
            // grpSetSteevePara
            // 
            this.grpSetSteevePara.Controls.Add(this.tableLayoutPanel1);
            this.grpSetSteevePara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSetSteevePara.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpSetSteevePara.Location = new System.Drawing.Point(0, 0);
            this.grpSetSteevePara.Name = "grpSetSteevePara";
            this.grpSetSteevePara.Size = new System.Drawing.Size(550, 826);
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
            this.tableLayoutPanel1.Controls.Add(this.lblUpDis, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDownDis, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblAllowDisDiffLimit, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblSteeveDisDiffLimit, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblSteeveForceLimit, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblSteeveForceDiffLimit, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.txtBasketAllowDisDiffLimit, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtBasketUpDisLimit, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtBasketDownDisLimit, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtSteeveDisDiffLimit, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtSteeveForceUpLimit, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtSteeveForceDiffLimit, 2, 11);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692545F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.689467F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 797);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lblUpDis
            // 
            this.lblUpDis.AutoSize = true;
            this.lblUpDis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpDis.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblUpDis.Location = new System.Drawing.Point(3, 64);
            this.lblUpDis.Margin = new System.Windows.Forms.Padding(3);
            this.lblUpDis.Name = "lblUpDis";
            this.lblUpDis.Size = new System.Drawing.Size(211, 55);
            this.lblUpDis.TabIndex = 0;
            this.lblUpDis.Text = "前下横梁上升位移(cm)";
            this.lblUpDis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDownDis
            // 
            this.lblDownDis.AutoSize = true;
            this.lblDownDis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDownDis.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblDownDis.Location = new System.Drawing.Point(3, 186);
            this.lblDownDis.Margin = new System.Windows.Forms.Padding(3);
            this.lblDownDis.Name = "lblDownDis";
            this.lblDownDis.Size = new System.Drawing.Size(211, 55);
            this.lblDownDis.TabIndex = 2;
            this.lblDownDis.Text = "前下横梁下降位移(cm)";
            this.lblDownDis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAllowDisDiffLimit
            // 
            this.lblAllowDisDiffLimit.AutoSize = true;
            this.lblAllowDisDiffLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAllowDisDiffLimit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblAllowDisDiffLimit.Location = new System.Drawing.Point(3, 308);
            this.lblAllowDisDiffLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblAllowDisDiffLimit.Name = "lblAllowDisDiffLimit";
            this.lblAllowDisDiffLimit.Size = new System.Drawing.Size(211, 55);
            this.lblAllowDisDiffLimit.TabIndex = 3;
            this.lblAllowDisDiffLimit.Text = "吊杆位移上限(cm)";
            this.lblAllowDisDiffLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSteeveDisDiffLimit
            // 
            this.lblSteeveDisDiffLimit.AutoSize = true;
            this.lblSteeveDisDiffLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSteeveDisDiffLimit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblSteeveDisDiffLimit.Location = new System.Drawing.Point(3, 430);
            this.lblSteeveDisDiffLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblSteeveDisDiffLimit.Name = "lblSteeveDisDiffLimit";
            this.lblSteeveDisDiffLimit.Size = new System.Drawing.Size(211, 55);
            this.lblSteeveDisDiffLimit.TabIndex = 4;
            this.lblSteeveDisDiffLimit.Text = "吊杆位移差上限(cm)";
            this.lblSteeveDisDiffLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSteeveForceLimit
            // 
            this.lblSteeveForceLimit.AutoSize = true;
            this.lblSteeveForceLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSteeveForceLimit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblSteeveForceLimit.Location = new System.Drawing.Point(3, 552);
            this.lblSteeveForceLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblSteeveForceLimit.Name = "lblSteeveForceLimit";
            this.lblSteeveForceLimit.Size = new System.Drawing.Size(211, 55);
            this.lblSteeveForceLimit.TabIndex = 8;
            this.lblSteeveForceLimit.Text = "吊杆受力上限(kN)";
            this.lblSteeveForceLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSteeveForceDiffLimit
            // 
            this.lblSteeveForceDiffLimit.AutoSize = true;
            this.lblSteeveForceDiffLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSteeveForceDiffLimit.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblSteeveForceDiffLimit.Location = new System.Drawing.Point(3, 674);
            this.lblSteeveForceDiffLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblSteeveForceDiffLimit.Name = "lblSteeveForceDiffLimit";
            this.lblSteeveForceDiffLimit.Size = new System.Drawing.Size(211, 55);
            this.lblSteeveForceDiffLimit.TabIndex = 10;
            this.lblSteeveForceDiffLimit.Text = "吊杆力差值上限(kN)";
            this.lblSteeveForceDiffLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBasketAllowDisDiffLimit
            // 
            this.txtBasketAllowDisDiffLimit.AutoSize = true;
            this.txtBasketAllowDisDiffLimit.DecimalPlaces = 1;
            this.txtBasketAllowDisDiffLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBasketAllowDisDiffLimit.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBasketAllowDisDiffLimit.Location = new System.Drawing.Point(272, 306);
            this.txtBasketAllowDisDiffLimit.Margin = new System.Windows.Forms.Padding(1);
            this.txtBasketAllowDisDiffLimit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtBasketAllowDisDiffLimit.Name = "txtBasketAllowDisDiffLimit";
            this.txtBasketAllowDisDiffLimit.Size = new System.Drawing.Size(215, 53);
            this.txtBasketAllowDisDiffLimit.TabIndex = 12;
            this.txtBasketAllowDisDiffLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBasketUpDisLimit
            // 
            this.txtBasketUpDisLimit.DecimalPlaces = 1;
            this.txtBasketUpDisLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBasketUpDisLimit.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBasketUpDisLimit.Location = new System.Drawing.Point(272, 62);
            this.txtBasketUpDisLimit.Margin = new System.Windows.Forms.Padding(1);
            this.txtBasketUpDisLimit.Name = "txtBasketUpDisLimit";
            this.txtBasketUpDisLimit.Size = new System.Drawing.Size(215, 53);
            this.txtBasketUpDisLimit.TabIndex = 13;
            this.txtBasketUpDisLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBasketDownDisLimit
            // 
            this.txtBasketDownDisLimit.DecimalPlaces = 1;
            this.txtBasketDownDisLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBasketDownDisLimit.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBasketDownDisLimit.Location = new System.Drawing.Point(272, 184);
            this.txtBasketDownDisLimit.Margin = new System.Windows.Forms.Padding(1);
            this.txtBasketDownDisLimit.Name = "txtBasketDownDisLimit";
            this.txtBasketDownDisLimit.Size = new System.Drawing.Size(215, 53);
            this.txtBasketDownDisLimit.TabIndex = 14;
            this.txtBasketDownDisLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSteeveDisDiffLimit
            // 
            this.txtSteeveDisDiffLimit.DecimalPlaces = 1;
            this.txtSteeveDisDiffLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSteeveDisDiffLimit.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSteeveDisDiffLimit.Location = new System.Drawing.Point(274, 430);
            this.txtSteeveDisDiffLimit.Name = "txtSteeveDisDiffLimit";
            this.txtSteeveDisDiffLimit.Size = new System.Drawing.Size(211, 53);
            this.txtSteeveDisDiffLimit.TabIndex = 15;
            this.txtSteeveDisDiffLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSteeveForceUpLimit
            // 
            this.txtSteeveForceUpLimit.DecimalPlaces = 1;
            this.txtSteeveForceUpLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSteeveForceUpLimit.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSteeveForceUpLimit.Location = new System.Drawing.Point(272, 550);
            this.txtSteeveForceUpLimit.Margin = new System.Windows.Forms.Padding(1);
            this.txtSteeveForceUpLimit.Name = "txtSteeveForceUpLimit";
            this.txtSteeveForceUpLimit.Size = new System.Drawing.Size(215, 53);
            this.txtSteeveForceUpLimit.TabIndex = 16;
            this.txtSteeveForceUpLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSteeveForceDiffLimit
            // 
            this.txtSteeveForceDiffLimit.DecimalPlaces = 1;
            this.txtSteeveForceDiffLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSteeveForceDiffLimit.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSteeveForceDiffLimit.Location = new System.Drawing.Point(272, 672);
            this.txtSteeveForceDiffLimit.Margin = new System.Windows.Forms.Padding(1);
            this.txtSteeveForceDiffLimit.Name = "txtSteeveForceDiffLimit";
            this.txtSteeveForceDiffLimit.Size = new System.Drawing.Size(215, 53);
            this.txtSteeveForceDiffLimit.TabIndex = 17;
            this.txtSteeveForceDiffLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SetParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 922);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "SetParameter";
            this.Padding = new System.Windows.Forms.Padding(22, 72, 22, 24);
            this.Resizable = false;
            this.Text = "参数设置";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SteeveParaSet_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.grpSetAnchorPara.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnchorForceLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnchorForceDiffLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrontPivotDisLimit)).EndInit();
            this.panel2.ResumeLayout(false);
            this.grpSetSteevePara.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasketAllowDisDiffLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasketUpDisLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasketDownDisLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSteeveDisDiffLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSteeveForceUpLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSteeveForceDiffLimit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grpSetAnchorPara;
        private System.Windows.Forms.GroupBox grpSetSteevePara;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroLabel lblUpDis;
        private MetroFramework.Controls.MetroLabel lblDownDis;
        private MetroFramework.Controls.MetroLabel lblAllowDisDiffLimit;
        private MetroFramework.Controls.MetroLabel lblSteeveDisDiffLimit;
        private MetroFramework.Controls.MetroLabel lblSteeveForceLimit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroLabel lblAnchorForceLimit;
        private MetroFramework.Controls.MetroLabel lblAnchorForceDiffLimit;
        private MetroFramework.Controls.MetroLabel lblFrontPivotDisLimit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
        private MetroFramework.Controls.MetroLabel lblSteeveForceDiffLimit;
        private System.Windows.Forms.NumericUpDown txtBasketAllowDisDiffLimit;
        private System.Windows.Forms.NumericUpDown txtAnchorForceLimit;
        private System.Windows.Forms.NumericUpDown txtAnchorForceDiffLimit;
        private System.Windows.Forms.NumericUpDown txtFrontPivotDisLimit;
        private System.Windows.Forms.NumericUpDown txtBasketUpDisLimit;
        private System.Windows.Forms.NumericUpDown txtBasketDownDisLimit;
        private System.Windows.Forms.NumericUpDown txtSteeveDisDiffLimit;
        private System.Windows.Forms.NumericUpDown txtSteeveForceUpLimit;
        private System.Windows.Forms.NumericUpDown txtSteeveForceDiffLimit;
    }
}