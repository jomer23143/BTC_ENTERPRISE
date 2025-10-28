using System.Data;
using System.Diagnostics;
using BTC_ENTERPRISE.Class;
using BTC_ENTERPRISE.Forms;
using BTC_ENTERPRISE.Model;
using BTC_ENTERPRISE.YaoUI;
using Frameworks.Utilities.ApiUtilities;
using Frameworks.Utilities.Registry;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Utility.ModifyRegistry;
using static BTC_ENTERPRISE.Model.OperatorModel;

namespace BTC_ENTERPRISE.Modal
{
    public partial class CheckFrm : Form
    {
        private object jsonResponse;
        private YUI yui = new YUI();
        public string? modulename;
        public string? type;
        private string loginApiUrl = GlobalApi.GetOperatorLoginUrl();
        private string ScanUrl = GlobalApi.GetScanSerialUrl();
        public DataTable tbl_process = new DataTable("tblprocess");
        public DataTable tbl_subprocess = new DataTable("tblsubp");
        private string segmentname;
        private int _segmentid;
        private string OperatorToken;
        private string operatorName;
        private int _Prcess_license_Id;
        private string moid;
        private string processname;
        private string serialnumber;
        private string _islogin;
        private bool islogin;

        private MainDashboard maindash = new MainDashboard();

        public delegate void checkHandler(string moid, int segmentid, string segment, string processname, string serialnumber, string operatorname, string operatortoken, DataTable process_list, DataTable subprocess_list, bool islogin);
        public event checkHandler AfterScanned;

        public CheckFrm(MainDashboard main, string _isloginOperator, bool _islogin)
        {
            InitializeComponent();
            this.islogin = _islogin;
            this.maindash = main;
            this._islogin = _isloginOperator;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.StartPosition = FormStartPosition.CenterParent;
            yui.RoundedPicturebox(pictureBox1, Color.FromArgb(123, 123, 123));
            yui.RoundedFormsDocker(this, 8);
            yui.RoundedPanelModuleName(panel_idholder);
            yui.RoundedPanelModuleName(panel_nameHolder);
            yui.RoundedPanelModuleName(panel_positionHolder);
            yui.RoundedPanelModuleName(panel_generatedcodeform);
            yui.RoundedTextBox(txt_scan, 10, Color.FromArgb(32, 59, 73));
            yui.RoundedTextBox(txt_scangeneratedserial, 10, Color.White);
            yui.RoundedPanelDocker(panel_rfid, 8);
            yui.RoundedButton(btn_viewlicense, 18, Color.SlateBlue);
            txt_scan.TextAlign = HorizontalAlignment.Center;
            txt_scan.Select();

        }

        private void CheckFrm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_islogin))
            {
                panel_rfid.Visible = true;
                panel_scangeneratedserial.Visible = false;
            }
            else
            {
                var userId = SessionData.TempData.Rows[0]["id"].ToString();
                var fullName = SessionData.TempData.Rows[0]["FullName"].ToString();
                var position = SessionData.TempData.Rows[0]["Position"].ToString();
                var token = SessionData.TempData.Rows[0]["Token"].ToString();

                txt_id.Text = $"ID :{userId}";
                lbl_userinfo.Text = $"FullName : {fullName}";
                operatorName = fullName;
                lbl_position.Text = $"Position : {position}";
                OperatorToken = token;

                panel_scangeneratedserial.Visible = true;
                txt_scangeneratedserial.Select();
            }
            LoadRegistryAsync();

        }

        private void LoadRegistryAsync()
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
                    segmentname = records[5].Trim();
                    _segmentid = Convert.ToInt32(records[6].Trim());
                }
                else
                {
                    MessageBox.Show("Invalid data format in registry.");
                }
            }

        }


        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_scan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txt_scan.Text))
            {
                string rifd = txt_scan.Text.Trim();
                Myrequest(loginApiUrl, rifd);
                txt_scangeneratedserial.Focus();

            }

        }

        private async void txt_scangeneratedserial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txt_scangeneratedserial.Text))
            {
                label_scaninfo.Text = "Processing.....";
                await LoadSegmentProcessAsync(txt_scangeneratedserial.Text, _segmentid);
                txt_scangeneratedserial.Clear();
                txt_scangeneratedserial.Focus();

                var licenses = SessionData.TempDataLicense.AsEnumerable();


                var licenseRow = licenses
                    .Where(row => row.Field<int>("id") == _Prcess_license_Id)
                    .Where(row =>
                    {
                        var expiryStr = row.Field<string>("expiry_date");

                        if (DateTime.TryParse(expiryStr, out DateTime expiryDate))
                        {
                            return expiryDate >= DateTime.Now.Date;
                        }
                        return false;
                    })
                    .FirstOrDefault();

                if (licenseRow == null)
                {
                    MessageBox.Show("You are not registered or your license has expired.",
                                    "Access Denied",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }




                // Check if the license is expired
                if (DateTime.TryParse(licenseRow.Field<string>("expiry_date"), out DateTime expiryDate))
                {
                    if (expiryDate < DateTime.Now)
                    {
                        MessageBox.Show("Your license for this process has expired. Please contact your Production Head for renewal.",
                                        "License Expired",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }
                }

                // All checks passed
                AfterScanned?.Invoke(moid, _segmentid, segmentname, processname, serialnumber,
                                     operatorName, OperatorToken, tbl_process, tbl_subprocess, false);

                e.Handled = true;
                this.Close();
            }
        }

        private async void Myrequest(string apiUrl, string rfid)
        {
            try
            {
                var postData = new { rfid_no = rfid };
                string json = JsonConvert.SerializeObject(postData);

                string jsonResponse = await WebRequestApi.PostRequest(apiUrl, json);

                Console.WriteLine($"Raw API Response: {jsonResponse}");

                if (string.IsNullOrEmpty(jsonResponse) || jsonResponse.Trim().StartsWith("<"))
                {
                    MessageBox.Show("Invalid response from server.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var response = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);


                if (response?.user?.employee == null)
                {
                    MessageBox.Show("Failed to parse API response.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SessionData.TempData.Rows.Clear();
                SessionData.TempData.Rows.Add(
                response.user.employee.employee_id_no,
               $"{response.user.profile?.first_name} {response.user.profile?.last_name}".Trim(),
                response.user.job_title ?? "Unknown",
                response.token
                 );
                Global.UserToken = response.token;

                txt_id.Text = $"ID : {response.user.employee.employee_id_no ?? "N/A"}";
                lbl_userinfo.Text = $"FullName : {response.user.profile?.first_name} {response.user.profile?.last_name}".Trim();
                operatorName = $"{response.user.profile?.first_name} {response.user.profile?.last_name}".Trim();
                maindash.lbl_operatorlogin.Text = operatorName;
                lbl_position.Text = $"Position : {response.user.job_title ?? "Unknown"}";
                OperatorToken = response.token;

                SessionData.TempDataLicense.Rows.Clear();

                foreach (var lic in response.user.employee.licenses)
                {
                    SessionData.TempDataLicense.Rows.Add(
                        lic.license?.id ?? 0,
                        lic.license?.name ?? "N/A",
                        lic.license_no ?? "N/A",
                        lic.product_id ?? 0,
                        lic.product_name ?? "N/A",
                        lic.expiry_date?.ToString("yyyy-MM-dd") ?? "N/A"

                    );
                }


                string defaultImagePath = Path.Combine(Application.StartupPath, "Assets", "Unknown.png");
                string imagePath = defaultImagePath;

                pb_rfid.Image = File.Exists(imagePath) ? Image.FromFile(imagePath) : null;

                await Task.Delay(100);

                panel_scangeneratedserial.Visible = true;
                txt_scangeneratedserial.Select();
                if (Global.process_name.ToUpper() == "WAREHOUSE KITTING")
                {
                    AfterScanned?.Invoke(moid, _segmentid, segmentname, processname, serialnumber,
                                   operatorName, OperatorToken, tbl_process, tbl_subprocess, false);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (Global.process_name.ToUpper() == "KITLIST RECEIVING")
                {
                    AfterScanned?.Invoke(moid, _segmentid, segmentname, processname, serialnumber,
                                   operatorName, OperatorToken, tbl_process, tbl_subprocess, false);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                if (islogin)
                {
                    AfterScanned?.Invoke(moid, _segmentid, segmentname, processname, serialnumber,
                                   operatorName, OperatorToken, tbl_process, tbl_subprocess, true);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}\n\nResponse: {jsonResponse}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbl_userinfo.Text = "The Server has incounter a problem please contact IT.";
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"Error: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("The operator ID is not registered in the system. You must register it before you can use the production system.", "Invalid User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_scan.Text = "";
            }
        }

        public async Task LoadSegmentProcessAsync(string serial, int segmentId)
        {
            try
            {
                var postData = new Dictionary<string, object>
                {
                    { "serial_number", serial },
                    { "manufacturing_order_segment_id", segmentId }
                };
                string json = JsonConvert.SerializeObject(postData);
                Debug.WriteLine("Request JSON: " + json);

                var token = await ApiHelper.PostJsonAsync(ScanUrl, postData, OperatorToken);
                if (token == null) return;

                if (token.Type == JTokenType.Array)
                {
                    var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    var data = result?.FirstOrDefault();

                    if (data == null)
                    {
                        return;
                    }

                    _Prcess_license_Id = data.license_id != null ? int.Parse(data.license_id) : 0;
                    InitTables();
                    tbl_process.Rows.Clear();
                    tbl_subprocess.Rows.Clear();

                    foreach (var mainprocess in data.process)
                    {
                        // Check if there are any duration records
                        if (mainprocess.duration != null && mainprocess.duration.Any())
                        {
                            // Iterate over every duration record
                            foreach (var durationItems in mainprocess.duration)
                            {

                                if (durationItems.manufacturing_order_process_type_id?.ToString()?.Trim() == "1")
                                {
                                    tbl_process.Rows.Add(
                                        mainprocess.id,
                                        mainprocess.name ?? "N/A",
                                        mainprocess.cycle_time ?? "N/A",
                                        durationItems.manufacturing_order_process_type_id ?? "N/A",
                                        durationItems.start_time,
                                        durationItems.end_time,
                                        durationItems.status?.Name ?? "Open",
                                        mainprocess.status?.Color ?? "White",
                                        durationItems.remarks ?? ""
                                    );
                                }
                            }
                        }
                        else
                        {
                            // Add one row for the process even if it has NO duration records
                            tbl_process.Rows.Add(
                                mainprocess.id,
                                mainprocess.name ?? "N/A",
                                mainprocess.cycle_time ?? "N/A",
                                "N/A",
                                null,
                                null,
                                mainprocess.status?.Name ?? "Open",
                                mainprocess.status?.Color ?? "White",
                                ""
                            );
                        }
                    }



                    foreach (var process in data.process ?? new List<Sub_Asy_Process_Model.Process>())
                    {
                        if (process.sub_process != null)
                        {
                            foreach (var sub in process.sub_process)
                            {
                                var ipns = sub.internal_part_number ?? new List<Sub_Asy_Process_Model.InternalPartNumber>();
                                var torques = sub.torque ?? new List<Sub_Asy_Process_Model.Torque>();
                                var serials = sub.serial ?? new List<Sub_Asy_Process_Model.Serial>();
                                var iskitlist = sub.is_kit_list;

                                int maxRows = Math.Max(ipns.Count, torques.Count);

<<<<<<< HEAD
                                if (sub.internal_part_number.Count == 0)
                                {
                                    continue;
                                }
                                // kung diin ang duha ka list kay walay sulod (one default row for the sub-process)
=======
>>>>>>> c52c37d1377db1f53ecc27e2681bde1f79cfc106
                                if (maxRows == 0)
                                {
                                    tbl_subprocess.Rows.Add(
                                        sub.id,
                                        sub.manufacturing_order_process_id,
                                        "N/A",
                                        "",
                                        "",
                                        sub.serial_quantity,
                                        sub.serial_count,
                                        sub.is_kit_list,
                                        sub.is_serial,
                                        sub.is_torque,
                                        0,
                                        "",
                                        "",
                                        "",
                                        "",
                                        sub.is_chemical,
                                        sub.chemical_name?.ToString() ?? "",
                                        0,
                                        sub.chemical_expiration?.ToString() ?? ""
                                    );
                                }
                                else
                                {
                                    for (int i = 0; i < maxRows; i++)
                                    {
                                        var ser = i < serials.Count ? serials[i] : null;
                                        var ipn = i < ipns.Count ? ipns[i] : null;
                                        var torque = i < torques.Count ? torques[i] : null;

                                        tbl_subprocess.Rows.Add(
                                            sub.id,
                                            sub.manufacturing_order_process_id,

                                            ipn?.description ?? "N/A",
                                            ipn?.ipn_number ?? "",
                                            ser?.serial_number ?? "",
                                            // SubProcess Details 
                                            sub.serial_quantity,
                                            sub.serial_count,
                                            sub.is_kit_list,
                                            sub.is_serial,
                                            sub.is_torque,
                                            0,

                                            //Torque Details
                                            torque?.min ?? "",
                                            torque?.max ?? "",
                                            torque?.value ?? "",
                                            torque?.torque_name ?? "",


                                            // Chemical Details
                                            sub.is_chemical,
                                            sub.chemical_name?.ToString() ?? "",
                                            0,
                                            sub.chemical_expiration?.ToString() ?? ""
                                        );
                                    }
                                }
                            }
                        }
                    }

                    //foreach (var process in data.process ?? new List<Sub_Asy_Process_Model.Process>())
                    //{
                    //    if (process.sub_process != null)
                    //    {
                    //        foreach (var sub in process.sub_process)
                    //        {
                    //            var ipns = sub.internal_part_number ?? new List<Sub_Asy_Process_Model.InternalPartNumber>();
                    //            var torques = sub.torque ?? new List<Sub_Asy_Process_Model.Torque>();
                    //            var serials = sub.serial ?? new List<Sub_Asy_Process_Model.Serial>();

                    //            // --- CRITICAL CHECK: Ensure the first IPN record (index 0) exists ---
                    //            if (ipns.Count > 0)
                    //            {
                    //                var firstIpn = ipns[0];
                    //                var ser = serials.Count > 0 ? serials[0] : null; // Use first Serial record if available

                    //                // --- Scenario A: At least one IPN exists, and Torques exist ---
                    //                if (torques.Count > 0)
                    //                {
                    //                    // Inner Loop: Iterate through *all* Torque records.
                    //                    foreach (var torque in torques)
                    //                    {
                    //                        // Add a row using the details of the first IPN but the current Torque.
                    //                        tbl_subprocess.Rows.Add(
                    //                            sub.id,
                    //                            sub.manufacturing_order_process_id,

                    //                            // IPN Details (always from the FIRST IPN)
                    //                            firstIpn.description ?? "N/A",
                    //                            firstIpn.ipn_number ?? "",
                    //                            ser?.serial_number ?? "",

                    //                            // SubProcess/Control Details
                    //                            sub.serial_quantity, sub.serial_count, sub.is_kit_list,
                    //                            sub.is_serial, sub.is_torque, 0,

                    //                            // Torque Details (from the current Torque record in the loop)
                    //                            torque.min ?? "",
                    //                            torque.max ?? "",
                    //                            torque.value ?? "",
                    //                            torque.torque_name ?? "",

                    //                            // Chemical Details (Constant)
                    //                            sub.is_chemical, sub.chemical_name?.ToString() ?? "", 0, sub.chemical_expiration?.ToString() ?? ""
                    //                        );
                    //                    }
                    //                }
                    //                // --- Scenario B: First IPN exists, but NO Torques exist ---
                    //                else
                    //                {
                    //                    // Add a single row using the first IPN with empty torque fields
                    //                    tbl_subprocess.Rows.Add(
                    //                        sub.id, sub.manufacturing_order_process_id,
                    //                        firstIpn.description ?? "N/A",
                    //                        firstIpn.ipn_number ?? "",
                    //                        ser?.serial_number ?? "",
                    //                        sub.serial_quantity, sub.serial_count, sub.is_kit_list,
                    //                        sub.is_serial, sub.is_torque, 0,
                    //                        "", "", "", "", // Empty Torque fields
                    //                        sub.is_chemical, sub.chemical_name?.ToString() ?? "", 0, sub.chemical_expiration?.ToString() ?? ""
                    //                    );
                    //                }
                    //            }
                    //            // --- Scenario C: NO IPNs exist at all (Fallback) ---
                    //            else if (ipns.Count == 0 && torques.Count == 0) // Only add if everything is missing
                    //            {
                    //                // Re-use your original 'maxRows == 0' logic here
                    //                tbl_subprocess.Rows.Add(
                    //                    sub.id, sub.manufacturing_order_process_id, "N/A", "", "", sub.serial_quantity, sub.serial_count, sub.is_kit_list,
                    //                    sub.is_serial, sub.is_torque, 0, "", "", "", "",
                    //                    sub.is_chemical, sub.chemical_name?.ToString() ?? "", 0, sub.chemical_expiration?.ToString() ?? ""
                    //                );
                    //            }
                    //            // NOTE: If multiple IPN records exist (ipns.Count > 1), they will be ignored by this specific logic.
                    //        }
                    //    }
                    //}


                    bool anyIsKitList = data.process.Any(p => p.is_kit_list == 1);

                    moid = data.mo_id;
                    processname = data.name;
                    serialnumber = data.serial_number;

                    var durationItem = data.duration?.FirstOrDefault();
                    var rawStartTime = data.duration?.FirstOrDefault()?.start_time;
                    var rawEndTime = data.duration?.FirstOrDefault()?.end_time;

                    if (durationItem == null)
                    {
                        MessageBox.Show("No duration data found.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool isSubAssembly = segmentId == 1;

                }
                else
                {
                    MessageBox.Show("Unexpected response format.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Error: {ex.Message}");
            }
        }



        private void InitTables()
        {
            if (tbl_process.Columns.Count == 0)
            {
                tbl_process.Columns.Add("id", typeof(int));
                tbl_process.Columns.Add("name", typeof(string));
                tbl_process.Columns.Add("cycle_time", typeof(string));
                tbl_process.Columns.Add("manufacturing_order_process_type_id", typeof(string));
                tbl_process.Columns.Add("start_time", typeof(string));
                tbl_process.Columns.Add("end_time", typeof(string));
                tbl_process.Columns.Add("status", typeof(string));
                tbl_process.Columns.Add("color", typeof(string));
                tbl_process.Columns.Add("remark", typeof(string));

                tbl_process.Columns.Add("DurationRecords", typeof(List<Sub_Asy_Process_Model.Duration>));
            }

            if (tbl_subprocess.Columns.Count == 0)
            {
                tbl_subprocess.Columns.Add("id", typeof(int));
                tbl_subprocess.Columns.Add("manufacturing_order_process_id", typeof(int));
                tbl_subprocess.Columns.Add("description", typeof(string));
                tbl_subprocess.Columns.Add("ipn_number", typeof(string));
                tbl_subprocess.Columns.Add("serial_number", typeof(string));
                tbl_subprocess.Columns.Add("serial_quantity", typeof(int));
                tbl_subprocess.Columns.Add("serial_count", typeof(int));
                tbl_subprocess.Columns.Add("is_kit_list", typeof(int));
                tbl_subprocess.Columns.Add("is_serial", typeof(int));
                tbl_subprocess.Columns.Add("is_torque", typeof(int));
                tbl_subprocess.Columns.Add("torque_count", typeof(string));
                tbl_subprocess.Columns.Add("min", typeof(string));
                tbl_subprocess.Columns.Add("max", typeof(string));
                tbl_subprocess.Columns.Add("value", typeof(string));
                tbl_subprocess.Columns.Add("torque_name", typeof(string));
                tbl_subprocess.Columns.Add("is_chemical", typeof(string));
                tbl_subprocess.Columns.Add("chemical_name", typeof(string));
                tbl_subprocess.Columns.Add("chemical_count", typeof(string));
                tbl_subprocess.Columns.Add("chemical_expiration", typeof(string));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ToastForm("This is a success message!").Show();
        }
    }
}
