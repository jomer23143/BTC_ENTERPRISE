namespace BTC_ENTERPRISE.Settings
{
    partial class createConnection
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
            programsGrid = new DataGridView();
            gridcolName = new DataGridViewTextBoxColumn();
            gridcolserver = new DataGridViewTextBoxColumn();
            gridcoluser = new DataGridViewTextBoxColumn();
            gridcolpassword = new DataGridViewTextBoxColumn();
            gridcoldbname = new DataGridViewTextBoxColumn();
            colsegment = new DataGridViewTextBoxColumn();
            colsegmentcode = new DataGridViewTextBoxColumn();
            btn_test = new Button();
            btn_save = new Button();
            ((System.ComponentModel.ISupportInitialize)programsGrid).BeginInit();
            SuspendLayout();
            // 
            // programsGrid
            // 
            programsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            programsGrid.Columns.AddRange(new DataGridViewColumn[] { gridcolName, gridcolserver, gridcoluser, gridcolpassword, gridcoldbname, colsegment, colsegmentcode });
            programsGrid.Location = new Point(12, 18);
            programsGrid.Margin = new Padding(3, 2, 3, 2);
            programsGrid.Name = "programsGrid";
            programsGrid.RowHeadersWidth = 51;
            programsGrid.Size = new Size(697, 141);
            programsGrid.TabIndex = 0;
            programsGrid.CellFormatting += programsGrid_CellFormatting;
            // 
            // gridcolName
            // 
            gridcolName.HeaderText = "Name";
            gridcolName.MinimumWidth = 6;
            gridcolName.Name = "gridcolName";
            gridcolName.Width = 125;
            // 
            // gridcolserver
            // 
            gridcolserver.HeaderText = "Server";
            gridcolserver.MinimumWidth = 6;
            gridcolserver.Name = "gridcolserver";
            gridcolserver.Width = 125;
            // 
            // gridcoluser
            // 
            gridcoluser.HeaderText = "UserName";
            gridcoluser.MinimumWidth = 6;
            gridcoluser.Name = "gridcoluser";
            gridcoluser.Width = 125;
            // 
            // gridcolpassword
            // 
            gridcolpassword.HeaderText = "Password";
            gridcolpassword.MinimumWidth = 6;
            gridcolpassword.Name = "gridcolpassword";
            gridcolpassword.Width = 125;
            // 
            // gridcoldbname
            // 
            gridcoldbname.HeaderText = "DBName";
            gridcoldbname.MinimumWidth = 6;
            gridcoldbname.Name = "gridcoldbname";
            gridcoldbname.Width = 125;
            // 
            // colsegment
            // 
            colsegment.HeaderText = "Segment";
            colsegment.Name = "colsegment";
            // 
            // colsegmentcode
            // 
            colsegmentcode.HeaderText = "Segment Code";
            colsegmentcode.Name = "colsegmentcode";
            // 
            // btn_test
            // 
            btn_test.Location = new Point(462, 172);
            btn_test.Margin = new Padding(3, 2, 3, 2);
            btn_test.Name = "btn_test";
            btn_test.Size = new Size(113, 29);
            btn_test.TabIndex = 1;
            btn_test.Text = "Test Connection";
            btn_test.UseVisualStyleBackColor = true;
            btn_test.Click += btn_test_Click;
            // 
            // btn_save
            // 
            btn_save.Location = new Point(580, 172);
            btn_save.Margin = new Padding(3, 2, 3, 2);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(113, 29);
            btn_save.TabIndex = 1;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // createConnection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(721, 212);
            Controls.Add(btn_save);
            Controls.Add(btn_test);
            Controls.Add(programsGrid);
            Margin = new Padding(3, 2, 3, 2);
            Name = "createConnection";
            Text = "createConnection";
            Load += createConnection_Load;
            ((System.ComponentModel.ISupportInitialize)programsGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView programsGrid;
        private Button btn_test;
        private Button btn_save;
        private DataGridViewTextBoxColumn gridcolName;
        private DataGridViewTextBoxColumn gridcolserver;
        private DataGridViewTextBoxColumn gridcoluser;
        private DataGridViewTextBoxColumn gridcolpassword;
        private DataGridViewTextBoxColumn gridcoldbname;
        private DataGridViewTextBoxColumn colsegment;
        private DataGridViewTextBoxColumn colsegmentcode;
    }
}