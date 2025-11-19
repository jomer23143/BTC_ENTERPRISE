using BTC_ENTERPRISE.Model;
using Frameworks.Utilities.ApiUtilities;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using static BTC_ENTERPRISE.Model.WarehouseKitting;
using static BTC_ENTERPRISE.Modal.CheckFrm;

namespace BTC_ENTERPRISE.Class
{
    public class Global
    {
        private object jsonResponse;
        public string? modulename;
        public string? type;
        private string loginApiUrl = GlobalApi.GetOperatorLoginUrl();
        private string ScanUrl = GlobalApi.GetScanUrl();
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


        public static string UserToken = "";
        public static List<license>? dt_license { get; set; }
        public class license
        {
            public int id { get; set; }
            public int employee_id { get; set; }
            public int license_id { get; set; }
            public string? license_name { get; set; }
            public string? license_no { get; set; }
            public int license_type_id { get; set; }
            public string? license_type_name { get; set; }

        }
        public static string process_name { get; set; }
        public static int process_id { get; set; }


        public void UpdateSerialQuantity(DataTable subprocess, int materialID, string description, string newserialnumber,string ipn)
        {
            foreach (System.Data.DataRow row in subprocess.Rows)
            {
                int currentId = Convert.ToInt32(row["id"]);
                string currentDescription = row["description"]?.ToString() ?? string.Empty;

                if (currentId == materialID)
                {
                    if (currentDescription.Equals(description, StringComparison.OrdinalIgnoreCase))
                    {
                        int currentSerialCount = row["serial_count"] == DBNull.Value ?
                                                 Convert.ToInt32(row["serial_quantity"]) :
                                                 Convert.ToInt32(row["serial_count"]);

                        int newCount = currentSerialCount - 1;

                        if (newCount < 0)
                        {
                            newCount = 0;
                        }

                        
                        row["serial_count"] = newCount;
                        if (row["ipn_number"].ToString() == ipn)
                        {
                            row["serial_number"] = newserialnumber;
                        }
                    }
                    
                }
            }
        }
        public void UpdateTorqueQuantity(DataTable subprocess, int materialID, int newQuantity, string Tname, string Tvalue)
        {
            foreach (System.Data.DataRow row in subprocess.Rows)
            {
                if (Convert.ToInt32(row["id"]) == materialID && row["torque_name"].ToString() == Tname)
                {
                    row["torque_count"] = newQuantity;
                    row["value"] = Tvalue;
                    break;
                }
            }
        }

        public void UpdateChemical(DataTable subprocess, int materialID, int newQuantity, string Cname, string Cexp)
        {
            foreach (System.Data.DataRow row in subprocess.Rows)
            {
                int currentId = Convert.ToInt32(row["id"]);
                string currentChemical = row["chemical_name"]?.ToString() ?? string.Empty;

                if (currentId == materialID)
                {
                    //if (currentChemical.Equals(Cname, StringComparison.OrdinalIgnoreCase))
                    //{
                        row["chemical_count"] = newQuantity;
                        row["chemical_name"] = Cname;
                        row["chemical_expiration"] = Cexp;
                        //break;

                   //}
                }


            }
        }
        public async Task<string[]> Refresh_SubAsy_Process(int mo_process_id,string generatedserial)
        {
            await LoadSegmentProcessAsync(generatedserial, mo_process_id);

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
                return null;
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
                    return null;
                }
            }
            string[] result = { moid,processname,serialnumber };
            return result;
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
                    //InitTables();
                    SessionData.tbl_process_Session.Rows.Clear();
                    SessionData.tbl_subprocess_Session.Rows.Clear();

                    foreach (var mainprocess in data.process)
                    {
                        // Check if there are any duration records
                        if (mainprocess.duration != null && mainprocess.duration.Any())
                        {
                            // Iterate over every duration record
                            foreach (var durationItems in mainprocess.duration)
                            {
                                string statusName = "";
                                if (mainprocess.is_hold == 1 && mainprocess.is_quality == "0")
                                    statusName = "ON HOLD";
                                else if (mainprocess.is_quality == "1" && mainprocess.quality_validated == "0")
                                    statusName = "QC Required";
                                else if (mainprocess.quality_validated == "1")
                                    statusName = "Quality Approved";
                                else
                                    statusName = durationItems.status?.Name ?? "Open";
                        
                                if (durationItems.manufacturing_order_process_type_id?.ToString()?.Trim() == "1" || durationItems.manufacturing_order_process_type_id?.ToString()?.Trim() == "2")
                                {
                                    SessionData.tbl_process_Session.Rows.Add(
                                        mainprocess.id,
                                        mainprocess.name ?? "N/A",
                                        mainprocess.cycle_time ?? "N/A",
                                        durationItems.manufacturing_order_process_type_id ?? "N/A",
                                        durationItems.start_time,
                                        durationItems.end_time,
                                        statusName,
                                        mainprocess.is_quality,
                                        mainprocess.quality_validated,
                                        // mainprocess.is_hold == 1 ? "ON HOLD" : durationItems.status.Name ?? "Open",
                                        mainprocess.is_hold,
                                        mainprocess.is_hold == 1 ? "#EF4444" : mainprocess.status?.Color ?? "White",
                                        durationItems.remarks ?? ""
                                    );
                                }
                            }
                        }
                        else
                        {
                            string statusName = "";
                            if (mainprocess.is_hold == 1 && mainprocess.is_quality == "0")
                                statusName = "ON HOLD";
                            else if (mainprocess.is_quality == "1" && mainprocess.quality_validated == "0")
                                statusName = "QC Required";
                            else if (mainprocess.quality_validated == "1")
                                statusName = "Quality Approved";
                            else
                                statusName = mainprocess.status?.Name ?? "Open";
                            // Add one row for the process even if it has NO duration records
                            SessionData.tbl_process_Session.Rows.Add(
                                mainprocess.id,
                                mainprocess.name ?? "N/A",
                                mainprocess.cycle_time ?? "N/A",
                                "N/A",
                                null,
                                null,
                                statusName,
                                mainprocess.is_quality,
                                mainprocess.quality_validated,
                                mainprocess.is_hold,
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

                                if (maxRows == 0)
                                {
                                    SessionData.tbl_subprocess_Session.Rows.Add(
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

                                        SessionData.tbl_subprocess_Session.Rows.Add(
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

                    bool anyIsKitList = data.process.Any(p => p.is_kit_list == 1);

                    moid = data.mo_id;
                    processname = data.name;
                    serialnumber = data.serial_number;

                    var durationItem = data.duration?.FirstOrDefault();
                    var rawStartTime = data.duration?.FirstOrDefault()?.start_time;
                    var rawEndTime = data.duration?.FirstOrDefault()?.end_time;

                    //if (durationItem == null)
                    //{
                    //    MessageBox.Show("No duration data found.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}

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
    }
}
