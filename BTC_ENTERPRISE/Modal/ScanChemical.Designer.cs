namespace BTC_EnterpriseV2.Modal
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
            lbl_processname = new Label();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            lbl_scancount = new Label();
            lbl_msg = new Label();
            txt_chemical = new TextBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_processname
            // 
            lbl_processname.Dock = DockStyle.Fill;
            lbl_processname.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_processname.Location = new Point(0, 0);
            lbl_processname.Name = "lbl_processname";
            lbl_processname.Size = new Size(499, 24);
            lbl_processname.TabIndex = 1;
            lbl_processname.Text = "Material Name";
            lbl_processname.TextAlign = ContentAlignment.MiddleCenter;
            lbl_processname.Click += lbl_processname_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            dataGridView1.Location = new Point(6, 100);
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
            dataGridView1.Size = new Size(499, 116);
            dataGridView1.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Brown;
            label2.Location = new Point(27, 82);
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
            lbl_scancount.Location = new Point(138, 82);
            lbl_scancount.Name = "lbl_scancount";
            lbl_scancount.Size = new Size(61, 15);
            lbl_scancount.TabIndex = 15;
            lbl_scancount.Text = "0 out of 1";
            // 
            // lbl_msg
            // 
            lbl_msg.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_msg.ForeColor = Color.Navy;
            lbl_msg.Location = new Point(6, 63);
            lbl_msg.Name = "lbl_msg";
            lbl_msg.Size = new Size(499, 15);
            lbl_msg.TabIndex = 11;
            lbl_msg.Text = "Scan Chemical Serial Here.!";
            lbl_msg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_chemical
            // 
            txt_chemical.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txt_chemical.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_chemical.Location = new Point(126, 31);
            txt_chemical.Margin = new Padding(3, 2, 3, 2);
            txt_chemical.Name = "txt_chemical";
            txt_chemical.Size = new Size(249, 29);
            txt_chemical.TabIndex = 10;
            txt_chemical.TextAlign = HorizontalAlignment.Center;
            txt_chemical.KeyDown += txt_chemical_KeyDown;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lbl_processname);
            panel1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(6, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(499, 24);
            panel1.TabIndex = 16;
            // 
            // ScanChemical
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(509, 220);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(lbl_scancount);
            Controls.Add(lbl_msg);
            Controls.Add(txt_chemical);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ScanChemical";
            Text = "ScanChemical";
            Load += ScanChemical_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
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
        private Panel panel1;
    }
}