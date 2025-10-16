namespace BTC_ENTERPRISE.Forms
{
    partial class MainDashboardV1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashboardV1));
            timer1 = new System.Windows.Forms.Timer(components);
            panel_menubar = new Panel();
            settingimage = new PictureBox();
            button1 = new Button();
            lbl_departmemnt = new Label();
            Btn_maximixe = new Button();
            btn_subasemble = new Button();
            panel3 = new Panel();
            lbl_currentdate = new Label();
            lbl_time = new Label();
            panel_last = new Panel();
            panel_Subassy_Display = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            panel5 = new Panel();
            panel2 = new Panel();
            panel6 = new Panel();
            panel_menubar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)settingimage).BeginInit();
            panel_Subassy_Display.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // panel_menubar
            // 
            panel_menubar.BackColor = Color.FromArgb(22, 27, 45);
            panel_menubar.Controls.Add(settingimage);
            panel_menubar.Controls.Add(button1);
            panel_menubar.Controls.Add(lbl_departmemnt);
            panel_menubar.Controls.Add(Btn_maximixe);
            panel_menubar.Controls.Add(btn_subasemble);
            panel_menubar.Controls.Add(panel3);
            panel_menubar.Controls.Add(lbl_currentdate);
            panel_menubar.Controls.Add(lbl_time);
            panel_menubar.Dock = DockStyle.Top;
            panel_menubar.Location = new Point(0, 0);
            panel_menubar.Margin = new Padding(3, 2, 3, 2);
            panel_menubar.Name = "panel_menubar";
            panel_menubar.Size = new Size(1412, 59);
            panel_menubar.TabIndex = 0;
            panel_menubar.MouseDown += panel_menubar_MouseDown;
            // 
            // settingimage
            // 
            settingimage.BackgroundImage = Properties.Resources.icons8_settings_32;
            settingimage.BackgroundImageLayout = ImageLayout.Center;
            settingimage.Location = new Point(281, 3);
            settingimage.Margin = new Padding(3, 2, 3, 2);
            settingimage.Name = "settingimage";
            settingimage.Size = new Size(48, 38);
            settingimage.SizeMode = PictureBoxSizeMode.StretchImage;
            settingimage.TabIndex = 12;
            settingimage.TabStop = false;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(12, 6);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(263, 30);
            button1.TabIndex = 12;
            button1.UseVisualStyleBackColor = true;
            // 
            // lbl_departmemnt
            // 
            lbl_departmemnt.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_departmemnt.ForeColor = Color.White;
            lbl_departmemnt.Location = new Point(14, 39);
            lbl_departmemnt.Name = "lbl_departmemnt";
            lbl_departmemnt.Size = new Size(260, 20);
            lbl_departmemnt.TabIndex = 8;
            lbl_departmemnt.Text = "label1";
            lbl_departmemnt.TextAlign = ContentAlignment.TopCenter;
            // 
            // Btn_maximixe
            // 
            Btn_maximixe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_maximixe.Location = new Point(1099, 12);
            Btn_maximixe.Margin = new Padding(3, 2, 3, 2);
            Btn_maximixe.Name = "Btn_maximixe";
            Btn_maximixe.Size = new Size(82, 29);
            Btn_maximixe.TabIndex = 7;
            Btn_maximixe.Text = "button2";
            Btn_maximixe.UseVisualStyleBackColor = true;
            Btn_maximixe.Visible = false;
            Btn_maximixe.Click += Btn_maximixe_Click;
            // 
            // btn_subasemble
            // 
            btn_subasemble.Cursor = Cursors.Hand;
            btn_subasemble.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            btn_subasemble.FlatAppearance.BorderSize = 0;
            btn_subasemble.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_subasemble.FlatStyle = FlatStyle.Flat;
            btn_subasemble.Font = new Font("Calibri", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_subasemble.ForeColor = SystemColors.ControlLightLight;
            btn_subasemble.Location = new Point(391, 12);
            btn_subasemble.Margin = new Padding(3, 2, 3, 2);
            btn_subasemble.Name = "btn_subasemble";
            btn_subasemble.Size = new Size(280, 38);
            btn_subasemble.TabIndex = 5;
            btn_subasemble.Text = "Production Process";
            btn_subasemble.UseVisualStyleBackColor = true;
            btn_subasemble.Click += button2_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Location = new Point(332, 10);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(4, 39);
            panel3.TabIndex = 4;
            // 
            // lbl_currentdate
            // 
            lbl_currentdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_currentdate.ForeColor = Color.White;
            lbl_currentdate.Location = new Point(1213, 32);
            lbl_currentdate.Name = "lbl_currentdate";
            lbl_currentdate.Size = new Size(189, 15);
            lbl_currentdate.TabIndex = 3;
            lbl_currentdate.Text = "Monday, October 07 2025";
            lbl_currentdate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_time
            // 
            lbl_time.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbl_time.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_time.ForeColor = Color.FromArgb(100, 180, 45);
            lbl_time.Location = new Point(1212, 8);
            lbl_time.Name = "lbl_time";
            lbl_time.Size = new Size(189, 21);
            lbl_time.TabIndex = 2;
            lbl_time.Text = "10:10 AM";
            lbl_time.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_last
            // 
            panel_last.BackColor = Color.Transparent;
            panel_last.Dock = DockStyle.Left;
            panel_last.Location = new Point(0, 0);
            panel_last.Margin = new Padding(3, 2, 3, 2);
            panel_last.Name = "panel_last";
            panel_last.Size = new Size(9, 647);
            panel_last.TabIndex = 1;
            // 
            // panel_Subassy_Display
            // 
            panel_Subassy_Display.BackColor = Color.FromArgb(37, 45, 55);
            panel_Subassy_Display.Controls.Add(pictureBox1);
            panel_Subassy_Display.Controls.Add(label1);
            panel_Subassy_Display.Controls.Add(pictureBox2);
            panel_Subassy_Display.Controls.Add(panel5);
            panel_Subassy_Display.Controls.Add(panel2);
            panel_Subassy_Display.Controls.Add(panel_last);
            panel_Subassy_Display.Controls.Add(panel6);
            panel_Subassy_Display.Dock = DockStyle.Fill;
            panel_Subassy_Display.Location = new Point(0, 59);
            panel_Subassy_Display.Margin = new Padding(3, 2, 3, 2);
            panel_Subassy_Display.Name = "panel_Subassy_Display";
            panel_Subassy_Display.Size = new Size(1412, 647);
            panel_Subassy_Display.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(249, 110);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(914, 426);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 192, 0);
            label1.Location = new Point(418, 35);
            label1.Name = "label1";
            label1.Size = new Size(517, 78);
            label1.TabIndex = 11;
            label1.Text = "Production System";
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Location = new Point(252, 541);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(914, 62);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(9, 639);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(1394, 8);
            panel5.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(9, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1394, 4);
            panel2.TabIndex = 4;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(37, 45, 55);
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(1403, 0);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(9, 647);
            panel6.TabIndex = 8;
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 45, 55);
            ClientSize = new Size(1412, 706);
            Controls.Add(panel_Subassy_Display);
            Controls.Add(panel_menubar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainDashboard";
            Text = "MainDashboard";
            Load += MainDashboard_Load;
            SizeChanged += MainDashboard_SizeChanged;
            panel_menubar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)settingimage).EndInit();
            panel_Subassy_Display.ResumeLayout(false);
            panel_Subassy_Display.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel_menubar;
        private Panel panel3;
        private Button btn_subasemble;
        public Label lbl_currentdate;
        public Label lbl_time;
        public System.Windows.Forms.Timer timer1;
        public Panel panel_last;
        private Panel panel_Subassy_Display;
        private Panel panel2;
        private Panel panel5;
        private Panel panel6;
        private Button Btn_maximixe;
        public Label lbl_departmemnt;
        private PictureBox pictureBox2;
        private Label label1;
        public PictureBox settingimage;
        private Button button1;
        private PictureBox pictureBox1;
    }
}