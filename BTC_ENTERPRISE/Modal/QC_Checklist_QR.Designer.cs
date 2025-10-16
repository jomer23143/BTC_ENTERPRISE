namespace BTC_ENTERPRISE.Modal
{
    partial class QC_Checklist_QR
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
            panel1 = new Panel();
            btn_close = new Button();
            Pb_qr = new PictureBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Pb_qr).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 192, 0);
            panel1.Controls.Add(btn_close);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 364);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(538, 59);
            panel1.TabIndex = 0;
            // 
            // btn_close
            // 
            btn_close.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_close.ForeColor = Color.FromArgb(22, 27, 45);
            btn_close.Image = Properties.Resources.cross__2_;
            btn_close.ImageAlign = ContentAlignment.MiddleLeft;
            btn_close.Location = new Point(325, 2);
            btn_close.Margin = new Padding(3, 2, 3, 2);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(211, 55);
            btn_close.TabIndex = 0;
            btn_close.Text = "Close";
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // Pb_qr
            // 
            Pb_qr.Location = new Point(94, 49);
            Pb_qr.Margin = new Padding(3, 2, 3, 2);
            Pb_qr.Name = "Pb_qr";
            Pb_qr.Size = new Size(350, 278);
            Pb_qr.SizeMode = PictureBoxSizeMode.StretchImage;
            Pb_qr.TabIndex = 1;
            Pb_qr.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(118, 15);
            label1.Name = "label1";
            label1.Size = new Size(284, 25);
            label1.TabIndex = 2;
            label1.Text = "Scan QR Code for QC Check List";
            // 
            // QC_Checklist_QR
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(538, 423);
            Controls.Add(label1);
            Controls.Add(Pb_qr);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "QC_Checklist_QR";
            Text = "QC_Checklist_QR";
            Load += QC_Checklist_QR_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Pb_qr).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox Pb_qr;
        private Button btn_close;
        private Label label1;
    }
}