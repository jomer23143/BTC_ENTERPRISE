﻿namespace BTC_EnterpriseV2.Modal
{
    partial class ScanChemical
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanChemical));
            lbl_processname = new Label();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            lbl_scancount = new Label();
            lbl_msg = new Label();
            txt_chemical = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lbl_processname
            // 
            lbl_processname.Dock = DockStyle.Top;
            lbl_processname.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_processname.Location = new Point(0, 0);
            lbl_processname.Name = "lbl_processname";
            lbl_processname.Size = new Size(671, 42);
            lbl_processname.TabIndex = 1;
            lbl_processname.Text = "Material Name";
            lbl_processname.TextAlign = ContentAlignment.MiddleCenter;
            lbl_processname.Click += lbl_processname_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.FromArgb(37, 45, 55);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(4);
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(23, 194);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Padding = new Padding(4);
            dataGridViewCellStyle2.SelectionBackColor = Color.White;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Size = new Size(626, 104);
            dataGridView1.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Brown;
            label2.Location = new Point(36, 177);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 14;
            label2.Text = "Scaned Chemicals";
            // 
            // lbl_scancount
            // 
            lbl_scancount.AutoSize = true;
            lbl_scancount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_scancount.ForeColor = Color.Brown;
            lbl_scancount.Location = new Point(227, 177);
            lbl_scancount.Name = "lbl_scancount";
            lbl_scancount.Size = new Size(61, 15);
            lbl_scancount.TabIndex = 15;
            lbl_scancount.Text = "0 out of 1";
            // 
            // lbl_msg
            // 
            lbl_msg.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_msg.ForeColor = Color.Navy;
            lbl_msg.Location = new Point(23, 153);
            lbl_msg.Name = "lbl_msg";
            lbl_msg.Size = new Size(626, 24);
            lbl_msg.TabIndex = 11;
            lbl_msg.Text = "Scan Chemical Serial Here.!";
            lbl_msg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_chemical
            // 
            txt_chemical.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_chemical.Location = new Point(135, 122);
            txt_chemical.Margin = new Padding(3, 2, 3, 2);
            txt_chemical.Name = "txt_chemical";
            txt_chemical.Size = new Size(411, 29);
            txt_chemical.TabIndex = 10;
            txt_chemical.TextAlign = HorizontalAlignment.Center;
            txt_chemical.KeyDown += txt_chemical_KeyDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(277, 44);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 74);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // ScanChemical
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(671, 305);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(lbl_scancount);
            Controls.Add(pictureBox1);
            Controls.Add(lbl_msg);
            Controls.Add(txt_chemical);
            Controls.Add(lbl_processname);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ScanChemical";
            Text = "ScanChemical";
            Load += ScanChemical_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_processname;
        private DataGridView dataGridView1;
        private Label label2;
        private Label lbl_scancount;
        private Label lbl_msg;
        public TextBox txt_chemical;
        private PictureBox pictureBox1;
    }
}