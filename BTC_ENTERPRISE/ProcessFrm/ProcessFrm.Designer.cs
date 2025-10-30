﻿namespace BTC_ENTERPRISE
{
    partial class ProcessFrm
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            lbl_parentname = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            lbl_public_event = new Label();
            panel6 = new Panel();
            panel10 = new Panel();
            btn_qcChecklist = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            lbl_operatorname = new Label();
            label1 = new Label();
            lbl_QCinspector = new Label();
            label6 = new Label();
            label3 = new Label();
            lbl_inspectionDate = new Label();
            label5 = new Label();
            lbl_generatedSerial = new Label();
            lbl_segment = new Label();
            lbl_mo = new Label();
            label4 = new Label();
            label2 = new Label();
            panel7 = new Panel();
            pb_parent = new PictureBox();
            sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            panel8 = new Panel();
            pb_child = new PictureBox();
            sfDataGrid2 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            lbl_processname = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel9 = new Panel();
            panel_top = new Panel();
            panel_chemical = new Panel();
            btn_scan_chemical = new Button();
            chkIndicator3 = new Label();
            panel_torque = new Panel();
            btn_scan_torque = new Button();
            chkIndicator2 = new Label();
            panel_material = new Panel();
            btn_scanserialized = new Button();
            chkIndicator1 = new Label();
            panel_parent_tab_subprocess = new Panel();
            lbl_subprocessInfo = new Label();
            timer2 = new System.Windows.Forms.Timer(components);
            process_duration_timer = new System.Windows.Forms.Timer(components);
            timer_duration = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel10.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_parent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).BeginInit();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_child).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid2).BeginInit();
            panel9.SuspendLayout();
            panel_top.SuspendLayout();
            panel_chemical.SuspendLayout();
            panel_torque.SuspendLayout();
            panel_material.SuspendLayout();
            panel_parent_tab_subprocess.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.YellowGreen;
            panel1.Controls.Add(lbl_parentname);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1320, 41);
            panel1.TabIndex = 0;
            // 
            // lbl_parentname
            // 
            lbl_parentname.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbl_parentname.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_parentname.Location = new Point(272, 7);
            lbl_parentname.Name = "lbl_parentname";
            lbl_parentname.Size = new Size(1039, 28);
            lbl_parentname.TabIndex = 5;
            lbl_parentname.Text = "Process Name Here";
            lbl_parentname.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(267, 41);
            panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.uv;
            pictureBox1.Location = new Point(9, 2);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(256, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 41);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(9, 578);
            panel3.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(1311, 41);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(9, 578);
            panel4.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(lbl_public_event);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(9, 585);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(1302, 34);
            panel5.TabIndex = 1;
            // 
            // lbl_public_event
            // 
            lbl_public_event.AutoSize = true;
            lbl_public_event.Location = new Point(50, 13);
            lbl_public_event.Name = "lbl_public_event";
            lbl_public_event.Size = new Size(38, 15);
            lbl_public_event.TabIndex = 0;
            lbl_public_event.Text = "label1";
            lbl_public_event.Visible = false;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(panel10);
            panel6.Controls.Add(tableLayoutPanel1);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(9, 41);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(1302, 90);
            panel6.TabIndex = 2;
            // 
            // panel10
            // 
            panel10.Controls.Add(btn_qcChecklist);
            panel10.Dock = DockStyle.Right;
            panel10.Location = new Point(1093, 0);
            panel10.Margin = new Padding(3, 2, 3, 2);
            panel10.Name = "panel10";
            panel10.Size = new Size(209, 90);
            panel10.TabIndex = 1;
            // 
            // btn_qcChecklist
            // 
            btn_qcChecklist.Anchor = AnchorStyles.Right;
            btn_qcChecklist.FlatAppearance.BorderColor = Color.White;
            btn_qcChecklist.FlatStyle = FlatStyle.Flat;
            btn_qcChecklist.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_qcChecklist.ForeColor = Color.White;
            btn_qcChecklist.Location = new Point(11, 8);
            btn_qcChecklist.Margin = new Padding(3, 2, 3, 2);
            btn_qcChecklist.Name = "btn_qcChecklist";
            btn_qcChecklist.Size = new Size(187, 77);
            btn_qcChecklist.TabIndex = 0;
            btn_qcChecklist.Text = "Scan QC Checklist";
            btn_qcChecklist.UseVisualStyleBackColor = true;
            btn_qcChecklist.Click += btn_qcChecklist_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.6484938F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.2969875F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.6484947F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.4060173F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            tableLayoutPanel1.Controls.Add(lbl_operatorname, 3, 2);
            tableLayoutPanel1.Controls.Add(label1, 2, 2);
            tableLayoutPanel1.Controls.Add(lbl_QCinspector, 3, 1);
            tableLayoutPanel1.Controls.Add(label6, 2, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(lbl_inspectionDate, 3, 0);
            tableLayoutPanel1.Controls.Add(label5, 2, 0);
            tableLayoutPanel1.Controls.Add(lbl_generatedSerial, 1, 2);
            tableLayoutPanel1.Controls.Add(lbl_segment, 1, 1);
            tableLayoutPanel1.Controls.Add(lbl_mo, 1, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(5, 4);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(1082, 83);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl_operatorname
            // 
            lbl_operatorname.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_operatorname.Location = new Point(639, 55);
            lbl_operatorname.Name = "lbl_operatorname";
            lbl_operatorname.Size = new Size(422, 22);
            lbl_operatorname.TabIndex = 2;
            lbl_operatorname.Text = "Test Operator";
            lbl_operatorname.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.Location = new Point(480, 55);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 1;
            label1.Text = "Operator :";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_QCinspector
            // 
            lbl_QCinspector.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_QCinspector.Location = new Point(639, 29);
            lbl_QCinspector.Name = "lbl_QCinspector";
            lbl_QCinspector.Size = new Size(422, 23);
            lbl_QCinspector.TabIndex = 0;
            lbl_QCinspector.Text = "Inspector Mills";
            lbl_QCinspector.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label6.Location = new Point(480, 29);
            label6.Name = "label6";
            label6.Size = new Size(150, 23);
            label6.TabIndex = 0;
            label6.Text = "QC Inspector :";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label3.Location = new Point(6, 29);
            label3.Name = "label3";
            label3.Size = new Size(150, 23);
            label3.TabIndex = 0;
            label3.Text = "Process Segment :";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_inspectionDate
            // 
            lbl_inspectionDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_inspectionDate.Location = new Point(639, 3);
            lbl_inspectionDate.Name = "lbl_inspectionDate";
            lbl_inspectionDate.Size = new Size(422, 23);
            lbl_inspectionDate.TabIndex = 0;
            lbl_inspectionDate.Text = "000-0000-000";
            lbl_inspectionDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label5.Location = new Point(480, 3);
            label5.Name = "label5";
            label5.Size = new Size(150, 23);
            label5.TabIndex = 0;
            label5.Text = "Inspection Date :";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_generatedSerial
            // 
            lbl_generatedSerial.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_generatedSerial.Location = new Point(165, 55);
            lbl_generatedSerial.Name = "lbl_generatedSerial";
            lbl_generatedSerial.Size = new Size(304, 17);
            lbl_generatedSerial.TabIndex = 0;
            lbl_generatedSerial.Text = "Generated Serial Number";
            lbl_generatedSerial.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_segment
            // 
            lbl_segment.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_segment.Location = new Point(165, 29);
            lbl_segment.Name = "lbl_segment";
            lbl_segment.Size = new Size(304, 23);
            lbl_segment.TabIndex = 0;
            lbl_segment.Text = "Process Segement";
            lbl_segment.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_mo
            // 
            lbl_mo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_mo.Location = new Point(165, 3);
            lbl_mo.Name = "lbl_mo";
            lbl_mo.Size = new Size(304, 23);
            lbl_mo.TabIndex = 0;
            lbl_mo.Text = "Product MO :";
            lbl_mo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label4.Location = new Point(6, 55);
            label4.Name = "label4";
            label4.Size = new Size(150, 25);
            label4.TabIndex = 0;
            label4.Text = "Sub-Assembly Serial Number :";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.Location = new Point(6, 3);
            label2.Name = "label2";
            label2.Size = new Size(150, 23);
            label2.TabIndex = 0;
            label2.Text = "Product MO :";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel7.BackColor = Color.White;
            panel7.Controls.Add(pb_parent);
            panel7.Controls.Add(sfDataGrid1);
            panel7.Location = new Point(9, 134);
            panel7.Margin = new Padding(3, 2, 3, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(616, 446);
            panel7.TabIndex = 3;
            // 
            // pb_parent
            // 
            pb_parent.Anchor = AnchorStyles.Top;
            pb_parent.Image = Properties.Resources.loadingscreen;
            pb_parent.Location = new Point(174, 130);
            pb_parent.Margin = new Padding(3, 2, 3, 2);
            pb_parent.Name = "pb_parent";
            pb_parent.Size = new Size(223, 172);
            pb_parent.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_parent.TabIndex = 0;
            pb_parent.TabStop = false;
            // 
            // sfDataGrid1
            // 
            sfDataGrid1.AccessibleName = "Table";
            sfDataGrid1.AllowEditing = false;
            sfDataGrid1.CanOverrideStyle = true;
            sfDataGrid1.Dock = DockStyle.Fill;
            sfDataGrid1.Location = new Point(0, 0);
            sfDataGrid1.Margin = new Padding(3, 2, 3, 2);
            sfDataGrid1.Name = "sfDataGrid1";
            sfDataGrid1.PreviewRowHeight = 35;
            sfDataGrid1.RowHeaderWidth = 40D;
            sfDataGrid1.Size = new Size(616, 446);
            sfDataGrid1.Style.Border3DStyle = Border3DStyle.Flat;
            sfDataGrid1.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGrid1.Style.BorderStyle = BorderStyle.None;
            sfDataGrid1.TabIndex = 0;
            sfDataGrid1.Text = "sfDataGrid1";
            sfDataGrid1.QueryCellStyle += sfDataGrid1_QueryCellStyle;
            sfDataGrid1.SelectionChanged += sfDataGrid1_SelectionChanged;
            sfDataGrid1.QueryButtonCellStyle += sfDataGrid1_QueryButtonCellStyle;
            sfDataGrid1.CellButtonClick += sfDataGrid1_CellButtonClick_1;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel8.Controls.Add(pb_child);
            panel8.Controls.Add(sfDataGrid2);
            panel8.Location = new Point(630, 164);
            panel8.Margin = new Padding(3, 2, 3, 2);
            panel8.Name = "panel8";
            panel8.Size = new Size(678, 346);
            panel8.TabIndex = 4;
            // 
            // pb_child
            // 
            pb_child.Anchor = AnchorStyles.Top;
            pb_child.Image = Properties.Resources.loadingscreen;
            pb_child.Location = new Point(248, 17);
            pb_child.Margin = new Padding(3, 2, 3, 2);
            pb_child.Name = "pb_child";
            pb_child.Size = new Size(208, 147);
            pb_child.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_child.TabIndex = 0;
            pb_child.TabStop = false;
            // 
            // sfDataGrid2
            // 
            sfDataGrid2.AccessibleName = "Table";
            sfDataGrid2.BackColor = Color.White;
            sfDataGrid2.Dock = DockStyle.Fill;
            sfDataGrid2.Location = new Point(0, 0);
            sfDataGrid2.Margin = new Padding(3, 2, 3, 2);
            sfDataGrid2.Name = "sfDataGrid2";
            sfDataGrid2.PreviewRowHeight = 35;
            sfDataGrid2.Size = new Size(678, 346);
            sfDataGrid2.Style.Border3DStyle = Border3DStyle.Flat;
            sfDataGrid2.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGrid2.Style.BorderStyle = BorderStyle.None;
            sfDataGrid2.TabIndex = 0;
            sfDataGrid2.Text = "sfDataGrid2";
            sfDataGrid2.QueryCellStyle += sfDataGrid2_QueryCellStyle;
            sfDataGrid2.SelectionChanged += sfDataGrid2_SelectionChanged;
            sfDataGrid2.CellClick += sfDataGrid2_CellClick;
            sfDataGrid2.CurrentCellActivating += sfDataGrid2_CurrentCellActivating;
            sfDataGrid2.CurrentCellActivated += sfDataGrid2_CurrentCellActivated;
            // 
            // lbl_processname
            // 
            lbl_processname.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_processname.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_processname.ForeColor = Color.FromArgb(64, 64, 64);
            lbl_processname.Location = new Point(630, 134);
            lbl_processname.Name = "lbl_processname";
            lbl_processname.Size = new Size(676, 28);
            lbl_processname.TabIndex = 5;
            lbl_processname.Text = "Process Name Here";
            lbl_processname.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // panel9
            // 
            panel9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel9.BackColor = Color.White;
            panel9.Controls.Add(panel_top);
            panel9.Controls.Add(panel_parent_tab_subprocess);
            panel9.Location = new Point(630, 512);
            panel9.Margin = new Padding(3, 2, 3, 2);
            panel9.Name = "panel9";
            panel9.Size = new Size(678, 68);
            panel9.TabIndex = 6;
            // 
            // panel_top
            // 
            panel_top.BackColor = Color.Gray;
            panel_top.Controls.Add(panel_chemical);
            panel_top.Controls.Add(panel_torque);
            panel_top.Controls.Add(panel_material);
            panel_top.Dock = DockStyle.Top;
            panel_top.Location = new Point(0, 0);
            panel_top.Margin = new Padding(3, 2, 3, 2);
            panel_top.Name = "panel_top";
            panel_top.Size = new Size(678, 53);
            panel_top.TabIndex = 2;
            // 
            // panel_chemical
            // 
            panel_chemical.Controls.Add(btn_scan_chemical);
            panel_chemical.Controls.Add(chkIndicator3);
            panel_chemical.Location = new Point(449, 6);
            panel_chemical.Name = "panel_chemical";
            panel_chemical.Size = new Size(224, 43);
            panel_chemical.TabIndex = 2;
            // 
            // btn_scan_chemical
            // 
            btn_scan_chemical.FlatAppearance.BorderColor = Color.White;
            btn_scan_chemical.FlatAppearance.BorderSize = 0;
            btn_scan_chemical.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_scan_chemical.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_scan_chemical.FlatStyle = FlatStyle.Flat;
            btn_scan_chemical.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_scan_chemical.ForeColor = Color.White;
            btn_scan_chemical.Location = new Point(42, 1);
            btn_scan_chemical.Name = "btn_scan_chemical";
            btn_scan_chemical.Size = new Size(179, 39);
            btn_scan_chemical.TabIndex = 4;
            btn_scan_chemical.Text = "Scan Chemical";
            btn_scan_chemical.TextAlign = ContentAlignment.MiddleLeft;
            btn_scan_chemical.UseVisualStyleBackColor = true;
            btn_scan_chemical.Click += btn_scan_chemical_Click;
            // 
            // chkIndicator3
            // 
            chkIndicator3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkIndicator3.ForeColor = Color.Gray;
            chkIndicator3.Location = new Point(5, 7);
            chkIndicator3.Name = "chkIndicator3";
            chkIndicator3.Size = new Size(31, 31);
            chkIndicator3.TabIndex = 3;
            chkIndicator3.Text = "✔";
            chkIndicator3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_torque
            // 
            panel_torque.Controls.Add(btn_scan_torque);
            panel_torque.Controls.Add(chkIndicator2);
            panel_torque.Location = new Point(232, 6);
            panel_torque.Name = "panel_torque";
            panel_torque.Size = new Size(216, 43);
            panel_torque.TabIndex = 2;
            // 
            // btn_scan_torque
            // 
            btn_scan_torque.FlatAppearance.BorderColor = Color.White;
            btn_scan_torque.FlatAppearance.BorderSize = 0;
            btn_scan_torque.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_scan_torque.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_scan_torque.FlatStyle = FlatStyle.Flat;
            btn_scan_torque.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_scan_torque.ForeColor = Color.White;
            btn_scan_torque.Location = new Point(53, 3);
            btn_scan_torque.Name = "btn_scan_torque";
            btn_scan_torque.Size = new Size(160, 39);
            btn_scan_torque.TabIndex = 4;
            btn_scan_torque.Text = "Scan Torque";
            btn_scan_torque.TextAlign = ContentAlignment.MiddleLeft;
            btn_scan_torque.UseVisualStyleBackColor = true;
            btn_scan_torque.Click += btn_scan_torque_Click;
            // 
            // chkIndicator2
            // 
            chkIndicator2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkIndicator2.ForeColor = Color.Gray;
            chkIndicator2.Location = new Point(16, 7);
            chkIndicator2.Name = "chkIndicator2";
            chkIndicator2.Size = new Size(31, 31);
            chkIndicator2.TabIndex = 3;
            chkIndicator2.Text = "✔";
            chkIndicator2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_material
            // 
            panel_material.Controls.Add(btn_scanserialized);
            panel_material.Controls.Add(chkIndicator1);
            panel_material.Location = new Point(7, 6);
            panel_material.Name = "panel_material";
            panel_material.Size = new Size(224, 43);
            panel_material.TabIndex = 2;
            // 
            // btn_scanserialized
            // 
            btn_scanserialized.FlatAppearance.BorderColor = Color.White;
            btn_scanserialized.FlatAppearance.BorderSize = 0;
            btn_scanserialized.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_scanserialized.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_scanserialized.FlatStyle = FlatStyle.Flat;
            btn_scanserialized.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_scanserialized.ForeColor = Color.White;
            btn_scanserialized.Location = new Point(57, 3);
            btn_scanserialized.Name = "btn_scanserialized";
            btn_scanserialized.Size = new Size(162, 39);
            btn_scanserialized.TabIndex = 4;
            btn_scanserialized.Text = "Scan Serialized";
            btn_scanserialized.TextAlign = ContentAlignment.MiddleLeft;
            btn_scanserialized.UseVisualStyleBackColor = true;
            btn_scanserialized.Click += btn_scanserialized_Click;
            // 
            // chkIndicator1
            // 
            chkIndicator1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkIndicator1.ForeColor = Color.Gray;
            chkIndicator1.Location = new Point(16, 6);
            chkIndicator1.Name = "chkIndicator1";
            chkIndicator1.Size = new Size(35, 31);
            chkIndicator1.TabIndex = 3;
            chkIndicator1.Text = "✔";
            chkIndicator1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_parent_tab_subprocess
            // 
            panel_parent_tab_subprocess.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel_parent_tab_subprocess.BackColor = Color.White;
            panel_parent_tab_subprocess.Controls.Add(lbl_subprocessInfo);
            panel_parent_tab_subprocess.Location = new Point(9, 58);
            panel_parent_tab_subprocess.Margin = new Padding(3, 2, 3, 2);
            panel_parent_tab_subprocess.Name = "panel_parent_tab_subprocess";
            panel_parent_tab_subprocess.Size = new Size(662, 8);
            panel_parent_tab_subprocess.TabIndex = 1;
            // 
            // lbl_subprocessInfo
            // 
            lbl_subprocessInfo.BackColor = Color.LightGray;
            lbl_subprocessInfo.Dock = DockStyle.Fill;
            lbl_subprocessInfo.Font = new Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_subprocessInfo.ForeColor = Color.OrangeRed;
            lbl_subprocessInfo.Location = new Point(0, 0);
            lbl_subprocessInfo.Name = "lbl_subprocessInfo";
            lbl_subprocessInfo.Size = new Size(662, 8);
            lbl_subprocessInfo.TabIndex = 0;
            lbl_subprocessInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // process_duration_timer
            // 
            process_duration_timer.Tick += process_duration_timer_Tick;
            // 
            // timer_duration
            // 
            timer_duration.Tick += timer_duration_Tick;
            // 
            // ProcessFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1320, 619);
            Controls.Add(panel9);
            Controls.Add(lbl_processname);
            Controls.Add(panel8);
            Controls.Add(panel6);
            Controls.Add(panel7);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProcessFrm";
            Text = "ProcessFrm";
            Load += ProcessFrm_Load;
            Shown += ProcessFrm_Shown;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel10.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_parent).EndInit();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).EndInit();
            panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_child).EndInit();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid2).EndInit();
            panel9.ResumeLayout(false);
            panel_top.ResumeLayout(false);
            panel_chemical.ResumeLayout(false);
            panel_torque.ResumeLayout(false);
            panel_material.ResumeLayout(false);
            panel_parent_tab_subprocess.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid2;
        private Label lbl_processname;
        private Label lbl_parentname;
        private Label label4;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label lbl_generatedSerial;
        private Label lbl_segment;
        private Label lbl_QCinspector;
        private Label lbl_inspectionDate;
        private PictureBox pb_parent;
        private PictureBox pb_child;
        private System.Windows.Forms.Timer timer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lbl_mo;
        private Label label2;
        private PictureBox pictureBox1;
        public Label lbl_public_event;
        private Panel panel9;
        private Panel panel_top;
        private Panel panel_parent_tab_subprocess;
        private System.Windows.Forms.Timer timer2;
        private Label lbl_subprocessInfo;
        private Label label1;
        private Label lbl_operatorname;
        private System.Windows.Forms.Timer process_duration_timer;
        private Panel panel10;
        private Button btn_qcChecklist;
        private System.Windows.Forms.Timer timer_duration;
        private Panel panel_chemical;
        private Panel panel_torque;
        private Panel panel_material;
        private Label chkIndicator3;
        private Label chkIndicator2;
        private Label chkIndicator1;
        private Button btn_scanserialized;
        private Button btn_scan_chemical;
        private Button btn_scan_torque;
    }
}