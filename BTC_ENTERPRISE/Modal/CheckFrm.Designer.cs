namespace BTC_ENTERPRISE.Modal
{
    partial class CheckFrm
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
            panel2 = new Panel();
            panel_scangeneratedserial = new Panel();
            panel_generatedcodeform = new Panel();
            txt_scangeneratedserial = new TextBox();
            pictureBox2 = new PictureBox();
            label_scaninfo = new Label();
            panel_rfid = new Panel();
            pictureBox1 = new PictureBox();
            panel_rfidtextholder = new Panel();
            txt_scan = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            btn_viewlicense = new Button();
            panel_positionHolder = new Panel();
            lbl_position = new Label();
            panel_nameHolder = new Panel();
            lbl_userinfo = new Label();
            panel_idholder = new Panel();
            txt_id = new Label();
            pb_rfid = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel_scangeneratedserial.SuspendLayout();
            panel_generatedcodeform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel_rfid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel_rfidtextholder.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            panel_positionHolder.SuspendLayout();
            panel_nameHolder.SuspendLayout();
            panel_idholder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_rfid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_close);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(757, 28);
            panel1.TabIndex = 0;
            // 
            // btn_close
            // 
            btn_close.BackgroundImage = Properties.Resources.cross__2_1;
            btn_close.BackgroundImageLayout = ImageLayout.Stretch;
            btn_close.FlatAppearance.BorderSize = 0;
            btn_close.FlatStyle = FlatStyle.Flat;
            btn_close.Location = new Point(715, 2);
            btn_close.Margin = new Padding(3, 2, 3, 2);
            btn_close.Name = "btn_close";
            btn_close.Size = new Size(32, 24);
            btn_close.TabIndex = 0;
            btn_close.UseVisualStyleBackColor = true;
            btn_close.Click += btn_close_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(37, 45, 55);
            panel2.Controls.Add(panel_scangeneratedserial);
            panel2.Controls.Add(panel_rfid);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(10, 33);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(737, 407);
            panel2.TabIndex = 1;
            // 
            // panel_scangeneratedserial
            // 
            panel_scangeneratedserial.Controls.Add(panel_generatedcodeform);
            panel_scangeneratedserial.Controls.Add(pictureBox2);
            panel_scangeneratedserial.Controls.Add(label_scaninfo);
            panel_scangeneratedserial.Location = new Point(426, 14);
            panel_scangeneratedserial.Margin = new Padding(3, 2, 3, 2);
            panel_scangeneratedserial.Name = "panel_scangeneratedserial";
            panel_scangeneratedserial.Size = new Size(300, 376);
            panel_scangeneratedserial.TabIndex = 4;
            // 
            // panel_generatedcodeform
            // 
            panel_generatedcodeform.BackColor = Color.FromArgb(37, 45, 55);
            panel_generatedcodeform.Controls.Add(txt_scangeneratedserial);
            panel_generatedcodeform.Location = new Point(21, 187);
            panel_generatedcodeform.Margin = new Padding(3, 2, 3, 2);
            panel_generatedcodeform.Name = "panel_generatedcodeform";
            panel_generatedcodeform.Size = new Size(262, 40);
            panel_generatedcodeform.TabIndex = 1;
            // 
            // txt_scangeneratedserial
            // 
            txt_scangeneratedserial.BorderStyle = BorderStyle.None;
            txt_scangeneratedserial.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_scangeneratedserial.Location = new Point(10, 8);
            txt_scangeneratedserial.Margin = new Padding(3, 2, 3, 2);
            txt_scangeneratedserial.Name = "txt_scangeneratedserial";
            txt_scangeneratedserial.Size = new Size(242, 25);
            txt_scangeneratedserial.TabIndex = 0;
            txt_scangeneratedserial.TextAlign = HorizontalAlignment.Center;
            txt_scangeneratedserial.KeyDown += txt_scangeneratedserial_KeyDown;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.qrcode;
            pictureBox2.Location = new Point(32, 4);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(239, 179);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // label_scaninfo
            // 
            label_scaninfo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_scaninfo.ForeColor = Color.White;
            label_scaninfo.Location = new Point(33, 244);
            label_scaninfo.Name = "label_scaninfo";
            label_scaninfo.Size = new Size(238, 47);
            label_scaninfo.TabIndex = 1;
            label_scaninfo.Text = "Please Scan Generated Serial Here.";
            label_scaninfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_rfid
            // 
            panel_rfid.BackColor = Color.FromArgb(22, 27, 45);
            panel_rfid.BackgroundImage = Properties.Resources.modern_minimal_id_card_template_design_green____Made_with_PosterMyWall__1_;
            panel_rfid.BackgroundImageLayout = ImageLayout.Stretch;
            panel_rfid.Controls.Add(pictureBox1);
            panel_rfid.Controls.Add(panel_rfidtextholder);
            panel_rfid.Controls.Add(label2);
            panel_rfid.Controls.Add(label1);
            panel_rfid.Location = new Point(426, 18);
            panel_rfid.Margin = new Padding(3, 2, 3, 2);
            panel_rfid.Name = "panel_rfid";
            panel_rfid.Size = new Size(300, 372);
            panel_rfid.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.Unknown2;
            pictureBox1.Location = new Point(29, 51);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 148);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // panel_rfidtextholder
            // 
            panel_rfidtextholder.BackColor = Color.FromArgb(7, 222, 151);
            panel_rfidtextholder.Controls.Add(txt_scan);
            panel_rfidtextholder.Location = new Point(29, 204);
            panel_rfidtextholder.Margin = new Padding(3, 2, 3, 2);
            panel_rfidtextholder.Name = "panel_rfidtextholder";
            panel_rfidtextholder.Size = new Size(240, 34);
            panel_rfidtextholder.TabIndex = 1;
            // 
            // txt_scan
            // 
            txt_scan.BorderStyle = BorderStyle.None;
            txt_scan.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_scan.Location = new Point(4, 4);
            txt_scan.Margin = new Padding(3, 2, 3, 2);
            txt_scan.Name = "txt_scan";
            txt_scan.PasswordChar = 'X';
            txt_scan.Size = new Size(232, 25);
            txt_scan.TabIndex = 0;
            txt_scan.KeyDown += txt_scan_KeyDown;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 4);
            label2.Name = "label2";
            label2.Size = new Size(241, 25);
            label2.TabIndex = 1;
            label2.Text = "BTC POWER CEBU INC.";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(29, 244);
            label1.Name = "label1";
            label1.Size = new Size(240, 50);
            label1.TabIndex = 2;
            label1.Text = "Please tap your ID to RFID Scanner";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(22, 27, 45);
            panel3.Controls.Add(groupBox1);
            panel3.Location = new Point(11, 14);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(410, 376);
            panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_viewlicense);
            groupBox1.Controls.Add(panel_positionHolder);
            groupBox1.Controls.Add(panel_nameHolder);
            groupBox1.Controls.Add(panel_idholder);
            groupBox1.Controls.Add(pb_rfid);
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.Lime;
            groupBox1.Location = new Point(9, 8);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(382, 357);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Operator Information";
            // 
            // btn_viewlicense
            // 
            btn_viewlicense.FlatAppearance.BorderColor = Color.FromArgb(22, 27, 45);
            btn_viewlicense.FlatStyle = FlatStyle.Flat;
            btn_viewlicense.Location = new Point(35, 304);
            btn_viewlicense.Margin = new Padding(3, 2, 3, 2);
            btn_viewlicense.Name = "btn_viewlicense";
            btn_viewlicense.Size = new Size(313, 44);
            btn_viewlicense.TabIndex = 3;
            btn_viewlicense.Text = "View License";
            btn_viewlicense.UseVisualStyleBackColor = true;
            btn_viewlicense.Click += button1_Click;
            // 
            // panel_positionHolder
            // 
            panel_positionHolder.BackColor = Color.FromArgb(37, 45, 55);
            panel_positionHolder.Controls.Add(lbl_position);
            panel_positionHolder.Location = new Point(35, 250);
            panel_positionHolder.Margin = new Padding(3, 2, 3, 2);
            panel_positionHolder.Name = "panel_positionHolder";
            panel_positionHolder.Size = new Size(316, 39);
            panel_positionHolder.TabIndex = 2;
            // 
            // lbl_position
            // 
            lbl_position.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_position.ForeColor = Color.White;
            lbl_position.Location = new Point(3, 4);
            lbl_position.Name = "lbl_position";
            lbl_position.Size = new Size(311, 30);
            lbl_position.TabIndex = 1;
            lbl_position.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel_nameHolder
            // 
            panel_nameHolder.BackColor = Color.FromArgb(37, 45, 55);
            panel_nameHolder.Controls.Add(lbl_userinfo);
            panel_nameHolder.Location = new Point(35, 200);
            panel_nameHolder.Margin = new Padding(3, 2, 3, 2);
            panel_nameHolder.Name = "panel_nameHolder";
            panel_nameHolder.Size = new Size(316, 39);
            panel_nameHolder.TabIndex = 2;
            // 
            // lbl_userinfo
            // 
            lbl_userinfo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_userinfo.ForeColor = Color.White;
            lbl_userinfo.Location = new Point(3, 5);
            lbl_userinfo.Name = "lbl_userinfo";
            lbl_userinfo.Size = new Size(301, 29);
            lbl_userinfo.TabIndex = 1;
            lbl_userinfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel_idholder
            // 
            panel_idholder.BackColor = Color.FromArgb(37, 45, 55);
            panel_idholder.Controls.Add(txt_id);
            panel_idholder.Location = new Point(115, 148);
            panel_idholder.Margin = new Padding(3, 2, 3, 2);
            panel_idholder.Name = "panel_idholder";
            panel_idholder.Size = new Size(174, 39);
            panel_idholder.TabIndex = 2;
            // 
            // txt_id
            // 
            txt_id.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_id.ForeColor = Color.White;
            txt_id.Location = new Point(4, 0);
            txt_id.Name = "txt_id";
            txt_id.Size = new Size(167, 39);
            txt_id.TabIndex = 1;
            txt_id.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pb_rfid
            // 
            pb_rfid.Image = Properties.Resources._operator;
            pb_rfid.Location = new Point(119, 27);
            pb_rfid.Margin = new Padding(3, 2, 3, 2);
            pb_rfid.Name = "pb_rfid";
            pb_rfid.Size = new Size(167, 117);
            pb_rfid.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_rfid.TabIndex = 0;
            pb_rfid.TabStop = false;
            // 
            // CheckFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 27, 45);
            ClientSize = new Size(757, 449);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "CheckFrm";
            Text = "CheckFrm";
            Load += CheckFrm_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel_scangeneratedserial.ResumeLayout(false);
            panel_generatedcodeform.ResumeLayout(false);
            panel_generatedcodeform.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel_rfid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel_rfidtextholder.ResumeLayout(false);
            panel_rfidtextholder.PerformLayout();
            panel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panel_positionHolder.ResumeLayout(false);
            panel_nameHolder.ResumeLayout(false);
            panel_idholder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_rfid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btn_close;
        private Panel panel2;
        private Label label1;
        private Panel panel_rfidtextholder;
        private Panel panel3;
        private GroupBox groupBox1;
        private PictureBox pb_rfid;
        private Label lbl_position;
        private Label lbl_userinfo;
        private Label txt_id;
        private TextBox txt_scan;
        private Panel panel_rfid;
        private PictureBox pictureBox1;
        private Label label2;
        private Panel panel_generatedcodeform;
        private TextBox txt_scangeneratedserial;
        private PictureBox pictureBox2;
        private Label label_scaninfo;
        private Panel panel_positionHolder;
        private Panel panel_nameHolder;
        private Panel panel_idholder;
        private Button btn_viewlicense;
        public Panel panel_scangeneratedserial;
    }
}