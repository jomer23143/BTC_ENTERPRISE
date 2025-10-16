using System.Data;
using BTC_ENTERPRISE.Forms;
using BTC_ENTERPRISE.Modal;
using BTC_ENTERPRISE.Settings;
using BTC_ENTERPRISE.SideBar;
using Frameworks.Utilities;
using BTC_ENTERPRISE.Class;
using BTC_ENTERPRISE.YaoUI;
using Frameworks.Utilities.Registry;
using Utility.ModifyRegistry;
using BTC_ENTERPRISE.Model;

namespace BTC_ENTERPRISE.Forms
{
    public partial class MainDashboard : Form
    {
        private int borderSize = 2;
        private Size formSize;
        //private ContextMenuStrip imageMenu = new ContextMenuStrip();
        //private FormManager formManager;
        //private UIManager UIManager;
        private Manage_SubAssy Manage_SubAssy;
        private FormManager fulldisplaycontroll;
        private string processType = string.Empty;
        
        private PerantFrm _perantFrm;
        public MainDashboard()
        {
            InitializeComponent();
            UIControls.SetupUI(this, Setting_Click, Logout_Click, login_Click);
            Manage_SubAssy = new Manage_SubAssy(panel_menubar, panel_Subassy_Display);
            fulldisplaycontroll = new FormManager(panel_menubar, panel_Subassy_Display);
            this._perantFrm = new PerantFrm(this);
        }
        private void MainDashboard_SizeChanged(object sender, EventArgs e)
        {
            UIControls.SetupUI(this, Setting_Click, Logout_Click,login_Click);
        }
        public void Setting_Click(object? sender, EventArgs e)
        {
            PasswordForm passwordForm = new PasswordForm();
            passwordForm.StartPosition = FormStartPosition.CenterScreen;

            var passwordResult = passwordForm.ShowDialog();

            if (passwordResult == DialogResult.OK)
            {
                setupfrm setupForm = new setupfrm(this);
                setupForm.StartPosition = FormStartPosition.CenterScreen;
                setupForm.ShowDialog(this);
                Refresh_Main_Menu(sender);
            }
        }
        public void login_Click(object? sender, EventArgs e)
        {
            //var login = new EndProcessScanner();
            //login.rfidScaned += (rfid) =>
            //{
            //    // Handle the scanned RFID here
            //    //get_user_info("06211332");

            //};
            //login.ShowDialog();
            using var CheckProcessForm = new CheckFrm(this, lbl_operatorlogin.Text,true);

            CheckProcessForm.AfterScanned += (moid, segmentid, segmentname, processname, serialnumber, operatorName, token, processlist, subprocesslist,islogin) =>
            {
                string scannedSerial = serialnumber ?? string.Empty;
                string processType = segmentname ?? string.Empty;
                string Pname = processname ?? string.Empty;
                string MoId = moid ?? string.Empty;
                int _segmentID = segmentid;
                if (Global.process_name.ToUpper() == "WAREHOUSE KITTING")
                {
                    
                }
                else if (Global.process_name.ToUpper() == "KITLIST RECIEVING")
                {
                    
                }
                else
                {
                    if (!islogin)
                    {
                        fulldisplaycontroll.OpenChildForm(new ProcessFrm(scannedSerial, _segmentID, MoId, processType, Pname, operatorName, token, processlist, subprocesslist), sender);
                    }
                    
                }
            };

            CheckProcessForm.ShowDialog(this);
            UIControls.SetupUI(this, Setting_Click, Logout_Click, login_Click);
            _perantFrm.toogle(false);
            _perantFrm.is_login();
            //Refresh_Main_Menu(sender);
        }

        public void Logout_Click(object? sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                Global.UserToken = string.Empty;
                UIControls.SetupUI(this, Setting_Click, Logout_Click, login_Click);
                lbl_operatorlogin.Text = string.Empty;
                _perantFrm.toogle(false);
                _perantFrm.is_login();
                if (Global.process_name == "WAREHOUSE KITTING")
                {
                    _perantFrm.formManager.closeAForm();
                }
                else if (Global.process_name == "KITLIST RECEIVING")
                {
                    _perantFrm.formManager.closeAForm();
                }
                else
                {
                    fulldisplaycontroll.closeAForm();
                }
               
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = DateTime.Now.ToString("hh:mm tt").ToUpper();
            lbl_currentdate.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy");
        }

        public void Load_MainPanel(Form mainPanel)
        {
            if (this.panel_Subassy_Display.Controls.Count > 0)
                this.panel_Subassy_Display.Controls.Clear(); // Remove existing controls
            mainPanel.TopLevel = false;
            mainPanel.FormBorderStyle = FormBorderStyle.None;
            mainPanel.Dock = DockStyle.Fill;
            this.panel_Subassy_Display.Controls.Add(mainPanel);
            this.panel_Subassy_Display.Tag = mainPanel;
            mainPanel.BringToFront();
            mainPanel.Show();
        }

        private void panel_menubar_MouseDown(object sender, MouseEventArgs e)
        {
            // DragForm.ReleaseCapture();
            // DragForm.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            Refresh_Main_Menu(sender);
        }
        public void Refresh_Main_Menu(object sender)
        {
            try
            {
                RegistrySupport registry = new RegistrySupport();
                String data = registry.Read(Def.REGKEY_SUB);
                if (data == null)
                {
                    data += String.Format($"BTC_ENTERPRISE<limiter>192.168.20.15<limiter>sa<limiter>MISys_SBM1<limiter>BROADBAND<limiter>Warehouse Kitting<limiter>101<limiter1>");
                    registry.Write(Def.REGKEY_SUB, data);
                }
                String[] programs = data.Split(new String[] { "<limiter1>" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String program in programs)
                {
                    String[] records = program.Split(new String[] { "<limiter>" }, StringSplitOptions.RemoveEmptyEntries);
                    if (records.Length >= 3)
                    {
                        Global.process_name = records[5].ToUpper().Trim();
                        Global.process_id = Convert.ToInt32(records[6].Trim());

                        var departmentName = records[5].Trim();
                        switch (processType = records[6].Trim())
                        {
                            case "101":
                                btn_subasemble.Visible = false;
                                lbl_departmemnt.Text = departmentName;
                                _perantFrm = new PerantFrm(this);
                                fulldisplaycontroll.OpenChildForm(_perantFrm, sender);
                                break;
                            case "102":
                                btn_subasemble.Visible = false;
                                lbl_departmemnt.Text = departmentName;
                                _perantFrm = new PerantFrm(this);
                                fulldisplaycontroll.OpenChildForm(_perantFrm, sender);
                                break;
                            case "1":
                                fulldisplaycontroll.closeAForm();
                                Manage_SubAssy.Reset();
                                btn_subasemble.Visible = true;
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "2":
                                fulldisplaycontroll.closeAForm();
                                Manage_SubAssy.Reset();
                                btn_subasemble.Visible = true;
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "3":
                                fulldisplaycontroll.closeAForm();
                                Manage_SubAssy.Reset();
                                btn_subasemble.Visible = true;
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "4":
                                btn_subasemble.Visible = true;
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "5":
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "6":
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "7":
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "8":
                                lbl_departmemnt.Text = departmentName;
                                break;
                            case "9":
                                lbl_departmemnt.Text = departmentName;
                                break;
                            default:
                                lbl_departmemnt.Text = departmentName;
                                break;

                        }
                        UIControls.SetupUI(this, Setting_Click, Logout_Click, login_Click);
                    }
                    else
                    {
                        MessageBox.Show("Invalid data format in registry.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void panel_main_display_SizeChanged(object sender, EventArgs e)
        {
            UIControls.SetupUI(this, Setting_Click, Logout_Click,login_Click);
        }


        private DataTable response_list;
        private void button2_Click(object sender, EventArgs e)
        {

            using var CheckProcessForm = new CheckFrm(this, lbl_operatorlogin.Text,false);

            CheckProcessForm.AfterScanned += (moid, segmentid, segmentname, processname, serialnumber, operatorName, token, processlist, subprocesslist,islogin) =>
        {
            string scannedSerial = serialnumber ?? string.Empty;
            string processType = segmentname ?? string.Empty;
            string Pname = processname ?? string.Empty;
            string MoId = moid ?? string.Empty;
            int _segmentID = segmentid;
            if (Global.process_name.ToUpper() != "WAREHOUSE KITTING" || Global.process_name.ToUpper() != "KITLIST RECIEVING") 
            {
                fulldisplaycontroll.OpenChildForm(new ProcessFrm(scannedSerial, _segmentID, MoId, processType, Pname, operatorName, token, processlist, subprocesslist), sender);
            }
        };

            CheckProcessForm.ShowDialog(this);
            UIControls.SetupUI(this, Setting_Click, Logout_Click, login_Click);
        }


        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            Refresh_Main_Menu(sender);
           
        }
        private void warehouseRecievingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_SubAssy.OpenChildForm(new Warehouse_Kitting(), sender);
        }

        private void kitlistRecievingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Manage_SubAssy.OpenChildForm(new Kitlist_Recieving(), sender);
        }
        private bool isSidebarExpanded = false;

        private void Btn_maximixe_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void settingimage_Click(object sender, EventArgs e)
        {

        }
    }
}
