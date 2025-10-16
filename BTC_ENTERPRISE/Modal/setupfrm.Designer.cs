namespace BTC_ENTERPRISE.Modal
{
    partial class setupfrm
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
            label1 = new Label();
            label2 = new Label();
            btn_save = new Button();
            panel1 = new Panel();
            label3 = new Label();
            btn_close = new Button();
            panel2 = new Panel();
            cmb_name = new ComboBox();
            lbl_code = new Label();
            panel3 = new Panel();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(44, 15);
            label1.Name = "label1";
            label1.Size = new Size(116, 21);
            label1.TabIndex = 1;
            label1.Text = "Section Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(45, 50);
            label2.Name = "label2";
            label2.Size = new Size(116, 21);
            label2.TabIndex = 1;
            label2.Text = "Section Code :";
            // 
            // btn_save
            // 
            btn_save.BackColor = Color.FromArgb(17, 40, 86);
            btn_save.FlatAppearance.BorderSize = 0;
            btn_save.FlatStyle = FlatStyle.Flat;
            btn_save.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_save.ForeColor = Color.White;
            btn_save.Location = new Point(376, 6);
            btn_save.Margin = new Padding(3, 2, 3, 2);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(200, 40);
            btn_save.TabIndex = 3;
            btn_save.Text = "save";
            btn_save.UseVisualStyleBackColor = false;
            btn_save.Click += btn_save_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btn_close);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(586, 37);
            panel1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(10, 4);
            label3.Name = "label3";
            label3.Size = new Size(98, 32);
            label3.TabIndex = 1;
            label3.Text = "Registry";
            // 
            // btn_close
            // 
            btn_close.BackgroundImageLayout = ImageLayout.Stretch;
            btn_close.FlatAppearance.BorderSize = 0;
            btn_close.FlatStyle = FlatStyle.Flat;
            btn_close.Image = Properties.Resources.close__2_;
            btn_close.Location = new Point(548, 2);
            btn_close.Margin = new Padding(3, 2, 3, 2);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(38, 31);
            btn_close.TabIndex = 0;
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(37, 45, 55);
            panel2.Controls.Add(cmb_name);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(lbl_code);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 37);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(586, 97);
            panel2.TabIndex = 5;
            // 
            // cmb_name
            // 
            cmb_name.BackColor = Color.FromArgb(22, 27, 45);
            cmb_name.FlatStyle = FlatStyle.Flat;
            cmb_name.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmb_name.ForeColor = Color.White;
            cmb_name.FormattingEnabled = true;
            cmb_name.Location = new Point(175, 13);
            cmb_name.Margin = new Padding(3, 2, 3, 2);
            cmb_name.Name = "cmb_name";
            cmb_name.Size = new Size(236, 29);
            cmb_name.TabIndex = 3;
            cmb_name.SelectedIndexChanged += cmb_code_SelectedIndexChanged;
            cmb_name.Click += cmb_code_Click;
            // 
            // lbl_code
            // 
            lbl_code.AutoSize = true;
            lbl_code.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lbl_code.ForeColor = Color.White;
            lbl_code.Location = new Point(220, 50);
            lbl_code.Name = "lbl_code";
            lbl_code.Size = new Size(116, 21);
            lbl_code.TabIndex = 1;
            lbl_code.Text = "Section Code :";
            // 
            // panel3
            // 
            panel3.Controls.Add(btn_save);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 133);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(586, 54);
            panel3.TabIndex = 6;
            // 
            // setupfrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(586, 187);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "setupfrm";
            Text = "setupfrm";
            Load += setupfrm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Label label2;
        private Button btn_save;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button btn_close;
        private Label label3;
        private ComboBox cmb_name;
        private Label lbl_code;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
    }
}