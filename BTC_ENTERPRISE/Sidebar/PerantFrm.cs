using System.Text.Json;
using BTC_ENTERPRISE.Forms;
using BTC_ENTERPRISE.Modal;
using BTC_ENTERPRISE.Class;
using BTC_ENTERPRISE.YaoUI;
using BTC_ENTERPRISE.Model;
using Frameworks.Utilities.ApiUtilities;
using System.Net.NetworkInformation;


namespace BTC_ENTERPRISE.SideBar
{
    public partial class PerantFrm : Form
    {
        private bool isSidebarExpanded = true;
        YUI yUI = new YUI();
        public FormManager formManager;
        private MainDashboard _mainDashboard ;
        public PerantFrm(MainDashboard mainDashboard)
        {
            InitializeComponent();
            formManager = new FormManager(panel_sidebarHolder, panel_display_holder);
            yUI.RoundedPanelDocker(panel_display_holder, 10);
            yUI.RoundedPanelDocker(panel_sidebarHolder, 10);
            yUI.RoundedPanelDocker(panel_chart, 10);
            this._mainDashboard = mainDashboard;
        }
        private void PerantFrm_SizeChanged(object sender, EventArgs e)
        {
            yUI.RoundedPanelDocker(panel_display_holder, 10);
            yUI.RoundedPanelDocker(panel_sidebarHolder, 10);
            yUI.RoundedPanelDocker(panel_chart, 10);
        }

        private async void PerantFrm_Load(object sender, EventArgs e)
        {
            formManager.ActivateButton(button1);
            toogle(true);
            is_login();
            //if (isSidebarExpanded)
            //{
            //    string arrowRight = Path.Combine(Application.StartupPath, "Assets", "next-24.png");
            //    btn_toggle_right.Image = Image.FromFile(arrowRight);
            //}
            //else
            //{
            //    string arrowLeft = Path.Combine(Application.StartupPath, "Assets", "previous.png");
            //    btn_toggle_right.Image = Image.FromFile(arrowLeft);

            //}
            //  await ViewChar();//commented out for now waiting for the correct api.


        }
        Image ResizeImage(Image img, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height);
            }
            return bmp;
        }

        private void btn_toggle_right_Click(object sender, EventArgs e)
        {
           toogle(true);
        }
        public void toogle(bool is_click)
        {
            string arrowLeft = Path.Combine(Application.StartupPath, "Assets", "icons8-double-left-32.png");
            string arrowRight = Path.Combine(Application.StartupPath, "Assets", "menu-4-24.png");
            if (is_click)
            {
                if (isSidebarExpanded)
                 {
                    button1.Text = "Home";
                    button1.ImageAlign = ContentAlignment.MiddleLeft;
                    btn_printqr.Text = "Print Qr Code";
                    btn_printqr.ImageAlign = ContentAlignment.MiddleLeft;
                    button3.Text = "Warehouse Kitting";
                    button3.ImageAlign = ContentAlignment.MiddleLeft;
                    button4.Text = "Kitlist Recieving";
                    button4.ImageAlign = ContentAlignment.MiddleLeft;
                    button5.Text = "Chart";
                    button5.ImageAlign = ContentAlignment.MiddleLeft;
                    button6.Text = "Process";
                    btn_logout.Text = Global.UserToken ==""?"Login":"Logout";
                    btn_logout.ImageAlign = ContentAlignment.MiddleLeft;
                    panel_sidebarHolder.Width = 295;
                    isSidebarExpanded = true;
                }
                else
                {
                    button1.Text = string.Empty;
                    button1.ImageAlign = ContentAlignment.MiddleCenter;
                    btn_printqr.Text = string.Empty;
                    btn_printqr.ImageAlign = ContentAlignment.MiddleCenter;
                    button3.Text = string.Empty;
                    button3.ImageAlign = ContentAlignment.MiddleCenter;
                    button4.Text = string.Empty;
                    button4.ImageAlign = ContentAlignment.MiddleCenter;
                    button5.Text = string.Empty;
                    button5.ImageAlign = ContentAlignment.MiddleCenter;
                    button6.Text = string.Empty;
                    btn_logout.Text = string.Empty;
                    btn_logout.ImageAlign = ContentAlignment.MiddleCenter;
                    panel_sidebarHolder.Width = 60;
                    isSidebarExpanded = false;

                }
          
                isSidebarExpanded = !isSidebarExpanded;
            }
            // Set button image based on new state
            btn_toggle_right.Image = Image.FromFile(isSidebarExpanded ? arrowRight : arrowLeft);
            this.PerformLayout();
            yUI.RoundedPanelDocker(panel_display_holder, 10);
            yUI.RoundedPanelDocker(panel_sidebarHolder, 10);
            yUI.RoundedPanelDocker(panel_chart, 10);
        }
        private async void get_user_info(string rfid)
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
                is_login();
                toogle(false);
            }
            else
            {
                // Handle the case where json_object is null (optional)
                Global.UserToken = "null";
            }
        }
        public void is_login()
        {
            string login = Path.Combine(Application.StartupPath, "Assets", "icons8-customer-32.png");
            string logout = Path.Combine(Application.StartupPath, "Assets", "switch.png");
            btn_logout.Image = Image.FromFile(Global.UserToken != "" ? logout : login);
            if (isSidebarExpanded)
            {
                return;
            }
            if (Global.UserToken != "")
            {
                btn_logout.Text = "Logout";
            }
            else
            {
                btn_logout.Text = "Login";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //EndProcessScanner sec = new EndProcessScanner();

            //if (sec.ShowDialog() == DialogResult.Yes)
            //{
            //    MessageBox.Show("Please scan id to Print Qr Code", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //}
            //else
            if (Global.UserToken != "")
            {
                formManager.OpenChildForm(new PrintQRFrm(), sender);
            }
            else
            {
                //var login = new EndProcessScanner();
                //login.rfidScaned += (rfid) =>
                //{
                //    // Handle the scanned RFID here
                //    get_user_info(rfid);
                //};
                //login.ShowDialog();
                using var CheckProcessForm = new CheckFrm(_mainDashboard, _mainDashboard.lbl_operatorlogin.Text, false);
                var _oparatorName = "";
                CheckProcessForm.AfterScanned += (moid, segmentid, segmentname, processname, serialnumber, operatorName, token, processlist, subprocesslist, islogin) =>
                {
                    string scannedSerial = serialnumber ?? string.Empty;
                    string processType = segmentname ?? string.Empty;
                    string Pname = processname ?? string.Empty;
                    string MoId = moid ?? string.Empty;
                    int _segmentID = segmentid;
                    _oparatorName = operatorName ?? string.Empty;
                };
                if (CheckProcessForm.ShowDialog(this) == DialogResult.OK)
                {
                    is_login();
                    toogle(false);
                    _mainDashboard.lbl_operatorlogin.Text = _oparatorName;
                    // _mainDashboard.Refresh_Main_Menu(sender);
                    UIControls.SetupUI(_mainDashboard, _mainDashboard.Setting_Click, _mainDashboard.Logout_Click, _mainDashboard.login_Click);
                    formManager.OpenChildForm(new PrintQRFrm(), sender);
                }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formManager.ActivateButton(sender);
            formManager.closeAForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Global.UserToken != "")
            {
                formManager.OpenChildForm(new Warehouse_Kitting(), sender);
            }
            else
            {
                //var login = new EndProcessScanner();
                //login.rfidScaned += (rfid) =>
                //{
                //    // Handle the scanned RFID here
                //    get_user_info(rfid);
                //};
                //login.ShowDialog();
                using var CheckProcessForm = new CheckFrm(_mainDashboard, _mainDashboard.lbl_operatorlogin.Text, false);
                var _oparatorName = "";
                CheckProcessForm.AfterScanned += (moid, segmentid, segmentname, processname, serialnumber, operatorName, token, processlist, subprocesslist, islogin) =>
                {
                    string scannedSerial = serialnumber ?? string.Empty;
                    string processType = segmentname ?? string.Empty;
                    string Pname = processname ?? string.Empty;
                    string MoId = moid ?? string.Empty;
                    int _segmentID = segmentid;
                    _oparatorName = operatorName ?? string.Empty;
                };
                if (CheckProcessForm.ShowDialog(this) == DialogResult.OK)
                {
                    is_login();
                    toogle(false);
                    _mainDashboard.lbl_operatorlogin.Text = _oparatorName;
                    // _mainDashboard.Refresh_Main_Menu(sender);
                    UIControls.SetupUI(_mainDashboard, _mainDashboard.Setting_Click, _mainDashboard.Logout_Click, _mainDashboard.login_Click);
                    formManager.OpenChildForm(new Warehouse_Kitting(), sender);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Global.UserToken != "")
            {
                formManager.OpenChildForm(new Kitlist_Recieving(), sender);
            }
            else
            {
                //var login = new EndProcessScanner();
                //login.rfidScaned += (rfid) =>
                //{
                //    // Handle the scanned RFID here
                //    get_user_info(rfid);
                //};
                //login.ShowDialog();
                using var CheckProcessForm = new CheckFrm(_mainDashboard, _mainDashboard.lbl_operatorlogin.Text, false);
                var _oparatorName = "";
                CheckProcessForm.AfterScanned += (moid, segmentid, segmentname, processname, serialnumber, operatorName, token, processlist, subprocesslist, islogin) =>
                {
                    string scannedSerial = serialnumber ?? string.Empty;
                    string processType = segmentname ?? string.Empty;
                    string Pname = processname ?? string.Empty;
                    string MoId = moid ?? string.Empty;
                    int _segmentID = segmentid;
                    _oparatorName = operatorName ?? string.Empty;
                };
                if (CheckProcessForm.ShowDialog(this) == DialogResult.OK)
                {
                    is_login();
                    toogle(false);
                    _mainDashboard.lbl_operatorlogin.Text = _oparatorName;
                    // _mainDashboard.Refresh_Main_Menu(sender);
                    UIControls.SetupUI(_mainDashboard, _mainDashboard.Setting_Click, _mainDashboard.Logout_Click, _mainDashboard.login_Click);
                    formManager.OpenChildForm(new Kitlist_Recieving(), sender);
                }
            }
           
        }

        //for chart
        private async Task ViewChar()
        {
            var url = "https://app.btcp-enterprise.com/api/product?with_segment";
            using var client = new HttpClient();

            try
            {
                var json = await client.GetStringAsync(url);
                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var descriptionsGrouped = apiResponse.data
                    .GroupBy(p => p.description)
                    .Select(g => new
                    {
                        Description = g.Key,
                        Count = g.Count()
                    })
                    .ToList();

                var descriptions = descriptionsGrouped.Select(x => x.Description).ToArray();
                var counts = descriptionsGrouped.Select(x => x.Count).ToArray();

                panel_chart.Controls.Clear();

            //    var columnSeries = new ColumnSeries<int>
            //    {
            //        Values = counts,
            //        Name = "Product Count",
            //        Fill = new SolidColorPaint(SKColors.CornflowerBlue),
            //        YToolTipLabelFormatter = point => $"{descriptions[point.Index]}"
            //    };

            //    var chart = new CartesianChart
            //    {
            //        Series = new ISeries[] { columnSeries },
            //        ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X,
            //        XAxes = new[] {
            //    new Axis {
            //        Labels = descriptions,
            //        LabelsRotation = 15,
            //        Name = "Description",
            //        TextSize = 12
            //    }
            //},
            //        YAxes = new[] {
            //    new Axis {
            //        Labeler = value =>  ((int)value).ToString(),
            //        Name = "Count",
            //        TextSize = 12
            //    }
            //},
            //        LegendPosition = LiveChartsCore.Measure.LegendPosition.Top
            //    };

                //chart.Dock = DockStyle.Fill;
                //panel_chart.Controls.Add(chart);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error", ex.Message);
                MessageBox.Show($"Failed to load chart data: {ex.Message}");
            }
        }

        public class Product
        {
            public int id { get; set; }
            public string? bom_item { get; set; }
            public string? description { get; set; }
            public string? bom_revision_number { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }

        public class ApiResponse
        {
            public List<Product>? data { get; set; }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            if (Global.UserToken != "")
            {
                DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    Global.UserToken = string.Empty;
                    is_login();
                    formManager.closeAForm();
                    UIControls.SetupUI(_mainDashboard, _mainDashboard.Setting_Click, _mainDashboard.Logout_Click, _mainDashboard.login_Click);
                    //_mainDashboard.Refresh_Main_Menu(sender);
                    _mainDashboard.lbl_operatorlogin.Text = string.Empty;
                }
            }
            else
            {
                //var login = new EndProcessScanner();
                //login.rfidScaned += (rfid) =>
                //{
                //    // Handle the scanned RFID here
                //    get_user_info("06211332");
                    
                //};
                //login.ShowDialog();
                
                using var CheckProcessForm = new CheckFrm(_mainDashboard, _mainDashboard.lbl_operatorlogin.Text,false);
                var _oparatorName = "";
                CheckProcessForm.AfterScanned += (moid, segmentid, segmentname, processname, serialnumber, operatorName, token, processlist, subprocesslist, islogin) =>
                {
                    string scannedSerial = serialnumber ?? string.Empty;
                    string processType = segmentname ?? string.Empty;
                    string Pname = processname ?? string.Empty;
                    string MoId = moid ?? string.Empty;
                    int _segmentID = segmentid;
                   _oparatorName = operatorName ?? string.Empty;
                };
                if (CheckProcessForm.ShowDialog(this) == DialogResult.OK)
                {
                    is_login();
                    toogle(false);
                    _mainDashboard.lbl_operatorlogin.Text = _oparatorName;
                    // _mainDashboard.Refresh_Main_Menu(sender);
                    UIControls.SetupUI(_mainDashboard, _mainDashboard.Setting_Click, _mainDashboard.Logout_Click, _mainDashboard.login_Click);

                } 
            }
           
        }
        //private void Setting_Click(object? sender, EventArgs e)
        //{
        //    PasswordForm passwordForm = new PasswordForm();
        //    passwordForm.StartPosition = FormStartPosition.CenterScreen;

        //    var passwordResult = passwordForm.ShowDialog();
        //    if (passwordResult == DialogResult.OK)
        //    {
        //        setupfrm setupForm = new setupfrm(_mainDashboard);
        //        setupForm.StartPosition = FormStartPosition.CenterScreen;
        //        setupForm.ShowDialog(this);
        //        UIControls.SetupUI(_mainDashboard, Setting_Click, Logout_Click, login_Click);
        //    }
        //}
        //private void login_Click(object? sender, EventArgs e)
        //{
        //    //var login = new EndProcessScanner();
        //    //login.rfidScaned += (rfid) =>
        //    //{
        //    //    // Handle the scanned RFID here
        //    //    //get_user_info("06211332");

        //    //};
        //    //login.ShowDialog();
        //    using var CheckProcessForm = new CheckFrm(_mainDashboard, _mainDashboard.lbl_operatorlogin.Text);

        //    CheckProcessForm.AfterScanned += (moid, segmentid, segmentname, processname, serialnumber, operatorName, token, processlist, subprocesslist) =>
        //    {
        //        string scannedSerial = serialnumber ?? string.Empty;
        //        string processType = segmentname ?? string.Empty;
        //        string Pname = processname ?? string.Empty;
        //        string MoId = moid ?? string.Empty;
        //        int _segmentID = segmentid;
              
        //    };

        //    CheckProcessForm.ShowDialog(this);
        //    UIControls.SetupUI(_mainDashboard, _mainDashboard.Setting_Click, _mainDashboard.Logout_Click, _mainDashboard.login_Click);
        //}

        //private void Logout_Click(object? sender, EventArgs e)
        //{
        //    DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (DialogResult == DialogResult.Yes)
        //    {
        //        Global.UserToken = string.Empty;
                
        //        _mainDashboard.lbl_operatorlogin.Text = string.Empty;
        //    }
        //}
    }
}
