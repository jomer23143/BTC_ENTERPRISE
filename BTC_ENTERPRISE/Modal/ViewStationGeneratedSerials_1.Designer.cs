namespace BTC_ENTERPRISE.Modal
{
    partial class ViewStationGeneratedSerials_1
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btn_close = new Button();
            panel2 = new Panel();
            btn_print_all = new Button();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(37, 45, 55);
            panel1.Controls.Add(btn_close);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(735, 38);
            panel1.TabIndex = 0;
            // 
            // btn_close
            // 
            btn_close.BackgroundImageLayout = ImageLayout.Stretch;
            btn_close.FlatAppearance.BorderSize = 0;
            btn_close.FlatStyle = FlatStyle.Flat;
            btn_close.Image = Properties.Resources.close__2_;
            btn_close.Location = new Point(697, 4);
            btn_close.Margin = new Padding(3, 2, 3, 2);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(33, 28);
            btn_close.TabIndex = 0;
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(37, 45, 55);
            panel2.Controls.Add(btn_print_all);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 489);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(735, 51);
            panel2.TabIndex = 1;
            // 
            // btn_print_all
            // 
            btn_print_all.BackColor = Color.FromArgb(22, 27, 45);
            btn_print_all.FlatAppearance.BorderColor = Color.DarkSlateBlue;
            btn_print_all.FlatStyle = FlatStyle.Flat;
            btn_print_all.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btn_print_all.ForeColor = Color.White;
            btn_print_all.ImageAlign = ContentAlignment.MiddleLeft;
            btn_print_all.Location = new Point(495, 5);
            btn_print_all.Margin = new Padding(3, 2, 3, 2);
            btn_print_all.Name = "btn_print_all";
            btn_print_all.RightToLeft = RightToLeft.No;
            btn_print_all.Size = new Size(223, 37);
            btn_print_all.TabIndex = 4;
            btn_print_all.Text = "Print Preview";
            btn_print_all.UseVisualStyleBackColor = false;
            btn_print_all.Click += btn_print_all_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.FromArgb(22, 27, 45);
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new Padding(4);
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 38);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Padding = new Padding(4);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.Size = new Size(735, 451);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ViewStationGeneratedSerials_1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(735, 540);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ViewStationGeneratedSerials_1";
            Text = "ViewStationGeneratedSerials_1";
            Load += ViewStationGeneratedSerials_1_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        //private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Button btn_print_all;
        private DataGridView dataGridView1;
        private Button btn_close;
    }
}