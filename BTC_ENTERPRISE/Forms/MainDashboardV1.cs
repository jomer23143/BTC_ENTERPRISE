using System.Data;
using BTC_ENTERPRISE.Forms;
using BTC_ENTERPRISE.Modal;
using BTC_ENTERPRISE.SideBar;
using BTC_ENTERPRISE.Class;
using BTC_ENTERPRISE.YaoUI;
using Frameworks.Utilities.Registry;
using Utility.ModifyRegistry;
using BTC_ENTERPRISE.Model;
using Frameworks.Utilities.ApiUtilities;
namespace BTC_ENTERPRISE.Forms
{
    public partial class MainDashboardV1 : Form
    {
        private int borderSize = 2;
        private Size formSize;
        private ContextMenuStrip imageMenu = new ContextMenuStrip();
        private FormManager formManager;
        private UIManager UIManager;
        private Manage_SubAssy Manage_SubAssy;
        private FormManager fulldisplaycontroll;
        public static string processType = string.Empty;
        public MainDashboardV1()
        {
            InitializeComponent();
            UIControls.SetupUI(null, Setting_Click, Logout_Click,login_Click);
            Manage_SubAssy = new Manage_SubAssy(panel_menubar, panel_Subassy_Display);
            fulldisplaycontroll = new FormManager(panel_menubar, panel_Subassy_Display);

        }
        private void MainDashboard_SizeChanged(object sender, EventArgs e)
        {
            UIControls.SetupUI(null, Setting_Click, Logout_Click, login_Click);
        }
        private void Setting_Click(object? sender, EventArgs e)
        {
            PasswordForm passwordForm = new PasswordForm();
            passwordForm.StartPosition = FormStartPosition.CenterScreen;

            var passwordResult = passwordForm.ShowDialog();

            if (passwordResult == DialogResult.OK)
            {
                setupfrm setupForm = new setupfrm(null);
                setupForm.StartPosition = FormStartPosition.CenterScreen;
                setupForm.ShowDialog(this);
                Refresh_Main_Menu(sender);
            }
        }


        private void Logout_Click(object? sender, EventArgs e)
        {

            DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                Global.UserToken = string.Empty;
                UIControls.SetupUI(null, Setting_Click, Logout_Click, login_Click);
                fulldisplaycontroll.closeAForm();
            }
          
        }
        private void login_Click(object? sender, EventArgs e)
        {
            var login = new EndProcessScanner();
            login.rfidScaned += (rfid) =>
            {
                // Handle the scanned RFID here
                get_user_info("06211332");
                
            };
            login.ShowDialog();
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
            Utils.SetConnectionDetails();
            Refresh_Main_Menu(sender);
            var login = new EndProcessScanner();
            login.rfidScaned += async (rfid) =>
            {
                if (rfid == "")
                {
                    MessageBox.Show("Invalid RFID. Please try again.");
                    return;
                }
                get_user_info(rfid);
            };
            login.ShowDialog(this);

        }
        private  void Refresh_Main_Menu(object sender)
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
                        var departmentName = records[5].Trim();
                        switch (processType = records[6].Trim())
                        {
                            case "101":
                                btn_subasemble.Visible = false;
                                lbl_departmemnt.Text = departmentName;
                                fulldisplaycontroll.OpenChildForm(new PerantFrm(null), sender);
                                break;
                            case "102":
                                btn_subasemble.Visible = false;
                                lbl_departmemnt.Text = departmentName;
                                fulldisplaycontroll.OpenChildForm(new PerantFrm(null), sender);
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
                        UIControls.SetupUI(null, Setting_Click, Logout_Click, login_Click);
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
        private async void get_user_info(string? rfid)
        {
            var apiUrl = GlobalApi.GetLogin();
            var data = new Dictionary<string, object>
                {
                    { "rfid_no", rfid }
                };
            var json_token = await ApiHelper.PostJsonAsync(apiUrl, data);
            var json_object = json_token?.ToObject<LoginToken.Root>();

            // Ensure json_object is not null before accessing its properties
            if (json_object != null)
            {
                Global.UserToken = json_object.token?.ToString();

                var user_license = json_object?.user?.employee?.licenses?.Where(x => x.is_active == 1).ToList();
                var dt_license = new List<Global.license>();
                foreach (var item in user_license)
                {
                    var license_name = new Global.license
                    {
                        id = item.id,
                        employee_id = item.employee_id,
                        license_id = item.license_id,
                        license_name = item.license?.name,
                        license_no = item.license?.license_no,
                        license_type_id = item.license?.license_type_id ?? 0,
                        license_type_name = item.license?.license_type?.name
                    };
                    dt_license.Add(license_name);
                }
                Global.dt_license = dt_license;
                UIControls.SetupUI(null, Setting_Click, Logout_Click, login_Click);
            }
            else
            {
                // Handle the case where json_object is null (optional)
                Global.UserToken = "null";
            }
        }
        private void panel_main_display_SizeChanged(object sender, EventArgs e)
        {
            UIControls.SetupUI(null, Setting_Click, Logout_Click, login_Click);
        }


        private DataTable response_list;
        private void button2_Click(object sender, EventArgs e)
        {
            if (Global.UserToken != string.Empty)
            {
                using var scannerForm = new SubAssy_Serial_Scanner();

                string scannedSerial = string.Empty;
                string processType = string.Empty;


                scannerForm.SerialScanned += async (serial, processtype, segmentname, itemsTable) =>
                {
                    scannedSerial = serial ?? string.Empty;
                    segmentname = segmentname ?? string.Empty;
                    processType = processtype ?? string.Empty;
                    int _segmentID = Convert.ToInt32(processType);
                    response_list = itemsTable ?? new DataTable("thedata");
                    // fulldisplaycontroll.OpenChildForm(new Sub_AssyFrm(scannedSerial, response_list, _segmentID, segmentname), sender);
                    //  fulldisplaycontroll.OpenChildForm(new TestForm(scannedSerial, response_list, _segmentID, segmentname), sender); // Open TestForm as an example

                    //fulldisplaycontroll.OpenChildForm(new ProcessFrm(scannedSerial, _segmentID, segmentname), sender);
                };

                scannerForm.ShowDialog(this);
            }else
            {
                var login = new EndProcessScanner();
                login.rfidScaned += async (rfid) =>
                {
                    if (rfid == "")
                    {
                        MessageBox.Show("Invalid RFID. Please try again.");
                        return;
                    }
                    get_user_info("06211332");
                };
                if (login.ShowDialog(this) == DialogResult.Cancel)
                {
                    return;
                }
                using var scannerForm = new SubAssy_Serial_Scanner();

                string scannedSerial = string.Empty;
                string processType = string.Empty;


                scannerForm.SerialScanned += async (serial, processtype, segmentname, itemsTable) =>
                {
                    scannedSerial = serial ?? string.Empty;
                    segmentname = segmentname ?? string.Empty;
                    processType = processtype ?? string.Empty;
                    int _segmentID = Convert.ToInt32(processType);
                    response_list = itemsTable ?? new DataTable("thedata");
                    // fulldisplaycontroll.OpenChildForm(new Sub_AssyFrm(scannedSerial, response_list, _segmentID, segmentname), sender);
                    //  fulldisplaycontroll.OpenChildForm(new TestForm(scannedSerial, response_list, _segmentID, segmentname), sender); // Open TestForm as an example

                   // fulldisplaycontroll.OpenChildForm(new ProcessFrm(scannedSerial, _segmentID, segmentname), sender);
                };

                scannerForm.ShowDialog(this);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btn_home_Click(object sender, EventArgs e)
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
                        var departmentName = records[0].Trim();
                        var processType = records[1].Trim();
                        if (processType != "101" && processType != "102")
                        {
                            fulldisplaycontroll.closeAForm();
                        }
                        else
                        {
                            Manage_SubAssy.closeAForm();
                            fulldisplaycontroll.OpenChildForm(new PerantFrm(null), sender);
                        }
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

            //fulldisplaycontroll.OpenChildForm(new PerantFrm(), sender);

        }

        private void warehouseRecievingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_SubAssy.OpenChildForm(new Warehouse_Kitting(), sender);
        }

        private void kitlistRecievingToolStripMenuItem_Click(object sender, EventArgs e)
        {

          //  Manage_SubAssy.OpenChildForm(new KitlistRecieving(), sender);
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
