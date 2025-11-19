namespace BTC_ENTERPRISE.Modal
{
    partial class ProcessScanner
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lbl_msg = new Label();
            txt_serialnumber = new TextBox();
            panel_processname = new Panel();
            lbl_processname = new Label();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            lbl_scancount = new Label();
            lbl_generatedserial = new Label();
            panel_processname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lbl_msg
            // 
            lbl_msg.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbl_msg.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_msg.ForeColor = Color.White;
            lbl_msg.Location = new Point(57, 57);
            lbl_msg.Name = "lbl_msg";
            lbl_msg.Size = new Size(415, 15);
            lbl_msg.TabIndex = 6;
            lbl_msg.Text = "Please Scan Item Serial Number here.";
            lbl_msg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_serialnumber
            // 
            txt_serialnumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txt_serialnumber.BorderStyle = BorderStyle.None;
            txt_serialnumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_serialnumber.Location = new Point(142, 29);
            txt_serialnumber.Margin = new Padding(3, 2, 3, 2);
            txt_serialnumber.Name = "txt_serialnumber";
            txt_serialnumber.Size = new Size(263, 25);
            txt_serialnumber.TabIndex = 5;
            txt_serialnumber.TextAlign = HorizontalAlignment.Center;
            txt_serialnumber.TextChanged += txt_serialnumber_TextChanged;
            txt_serialnumber.KeyDown += txt_serialnumber_KeyDown;
            // 
            // panel_processname
            // 
            panel_processname.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel_processname.BackColor = Color.White;
            panel_processname.Controls.Add(lbl_processname);
            panel_processname.Location = new Point(10, 1);
            panel_processname.Margin = new Padding(3, 2, 3, 2);
            panel_processname.Name = "panel_processname";
            panel_processname.Size = new Size(522, 23);
            panel_processname.TabIndex = 8;
            // 
            // lbl_processname
            // 
            lbl_processname.Dock = DockStyle.Fill;
            lbl_processname.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_processname.Location = new Point(0, 0);
            lbl_processname.Name = "lbl_processname";
            lbl_processname.Size = new Size(522, 23);
            lbl_processname.TabIndex = 0;
            lbl_processname.Text = "test";
            lbl_processname.TextAlign = ContentAlignment.MiddleCenter;
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new Padding(4);
            dataGridViewCellStyle3.SelectionBackColor = Color.White;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(10, 93);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Padding = new Padding(4);
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.Size = new Size(522, 118);
            dataGridView1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(19, 76);
            label2.Name = "label2";
            label2.Size = new Size(158, 15);
            label2.TabIndex = 6;
            label2.Text = "Scaned Items Serial Number";
            // 
            // lbl_scancount
            // 
            lbl_scancount.AutoSize = true;
            lbl_scancount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_scancount.ForeColor = Color.White;
            lbl_scancount.Location = new Point(196, 75);
            lbl_scancount.Name = "lbl_scancount";
            lbl_scancount.Size = new Size(61, 15);
            lbl_scancount.TabIndex = 6;
            lbl_scancount.Text = "0 out of 5";
            // 
            // lbl_generatedserial
            // 
            lbl_generatedserial.AutoSize = true;
            lbl_generatedserial.ForeColor = Color.White;
            lbl_generatedserial.Location = new Point(77, 44);
            lbl_generatedserial.Name = "lbl_generatedserial";
            lbl_generatedserial.Size = new Size(38, 15);
            lbl_generatedserial.TabIndex = 10;
            lbl_generatedserial.Text = "label3";
            lbl_generatedserial.Visible = false;
            // 
            // ProcessScanner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 45, 55);
            ClientSize = new Size(540, 224);
            Controls.Add(dataGridView1);
            Controls.Add(lbl_generatedserial);
            Controls.Add(panel_processname);
            Controls.Add(label2);
            Controls.Add(lbl_scancount);
            Controls.Add(lbl_msg);
            Controls.Add(txt_serialnumber);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProcessScanner";
            Text = "ProcessScanner";
            Load += ProcessScanner_Load;
            panel_processname.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbl_msg;
        private Panel panel_processname;
        private Label label2;
        private Label lbl_scancount;
        private Label lbl_processname;
        private DataGridView dataGridView1;
        private Label lbl_generatedserial;
        public TextBox txt_serialnumber;
    }
}