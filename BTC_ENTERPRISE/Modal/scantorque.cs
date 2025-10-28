using System.Data;
using BTC_ENTERPRISE.Class;
using BTC_ENTERPRISE.Model;
using BTC_ENTERPRISE.YaoUI;
using Frameworks.Utilities.ApiUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BTC_ENTERPRISE.Modal
{
    public partial class scantorque : Form
    {
        private string processid;
        private string processname;
        public string qty;
        public string count;
        public int tempqty = 0;
        public int tempcount = 0;
        private string _Tname;
        private string PostTorque = GlobalApi.GetPostMaterialAssignTorqueUrl();
        private DataTable dataserials;
        public event Action<string, string, string, string> TorqueScanSuccess;

        private ProcessFrm _processfrm;
        public scantorque(ProcessFrm processFrm, string processid, string processname, string qty, string count, DataTable table_serials)
        {
            InitializeComponent();
            YUI yUI = new YUI();
            yUI.RoundedTextBox(txt_torque, 6, Color.White);
            yUI.RoundedPanelDocker(panel_processname, 6);
            this.processid = processid;
            lbl_processname.Text = processname;
            this.qty = qty;
            this.count = count;
            this._processfrm = processFrm;
            this.dataserials = table_serials;
        }
        private async void txt_torque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txt_torque.Text))
                {
                    MessageBox.Show("Please enter a serial number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _Tname = txt_torque.Text;
                if (tempqty <= tempcount)
                {
                    await PostItemSerial(
                        txt_torque.Text,
                        processid
                    );

                    txt_torque.Clear();

                    lbl_scancount.Text = $"{tempcount} out of {tempqty}";



                }
                else
                {
                    MessageBox.Show("You have already met the required number of Torque.", "Scanning Validator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }

            }
        }

        public async Task PostItemSerial(string serial, string processid)
        {
            try
            {
                // Sanitize inputs
                var postData = new
                {
                    name = serial.Trim(),
                    material_id = processid,

                };
                string json = JsonConvert.SerializeObject(postData);

                string jsonResponse = await WebRequestApi.PostRequest(PostTorque, json);

                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                {
                    ShowMessage("Invalid response from server.", Color.Red);
                    return;
                }
                var token = JToken.Parse(jsonResponse);

                if (token.Type == JTokenType.Object && token["message"] != null)
                {
                    string message = token["message"]?.ToString();
                    string kitSerialError = token["errors"]?["kit_serial"]?.FirstOrDefault()?.ToString();

                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        ShowMessage(message, Color.Orange);
                    }
                    else if (!string.IsNullOrWhiteSpace(kitSerialError))
                    {
                        ShowMessage(kitSerialError, Color.Red);
                    }
                    else
                    {
                        ShowMessage("An unknown error occurred.", Color.Red);
                    }

                    return;
                }

                if (token.Type == JTokenType.Array)
                {
                    List<Sub_Asy_Process_Model.Root> result;
                    try
                    {
                        result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    }
                    catch (Exception parseEx)
                    {
                        ShowMessage("Failed to parse process data.", Color.Red);

                        return;
                    }

                    var data = result?.FirstOrDefault();

                    if (data == null)
                    {
                        ShowMessage("No valid process data returned.", Color.Red);
                        return;

                    }
                }
                else
                {

                    var torqueArrayToken = token["torque"];

                    if (torqueArrayToken != null && torqueArrayToken.Type == JTokenType.Array)
                    {
                        bool targetTorqueFound = false;

                        foreach (JObject torqueRecord in torqueArrayToken)
                        {
                            string torqueValue = torqueRecord["value"]?.ToString();
                            string torqueName = torqueRecord["torque_name"]?.ToString();
                            string torquemin = torqueRecord["min"]?.ToString();
                            string torquemax = torqueRecord["max"]?.ToString();

                            var existingRow = dataGridView1.Rows
                                .Cast<DataGridViewRow>()
                                .FirstOrDefault(r => r.Cells["torque_name"].Value?.ToString() == torqueName);

                            if (existingRow == null)
                            {
                                tempcount++;
                                int rowIndex = dataGridView1.Rows.Add();
                                var row = dataGridView1.Rows[rowIndex];
                                row.Cells["row_number"].Value = rowIndex + 1;
                                row.Cells["torque_name"].Value = torqueName;
                                row.Cells["torque_value"].Value = torqueValue;
                                row.Cells["torque_min"].Value = torquemin;
                                row.Cells["torque_max"].Value = torquemax;
                            }
                            else
                            {
                                // Update existing row
                                existingRow.Cells["torque_name"].Value = torqueName;
                                existingRow.Cells["torque_value"].Value = torqueValue;
                                existingRow.Cells["torque_min"].Value = torquemin;
                                existingRow.Cells["torque_max"].Value = torquemax;
                            }

                            if (string.Equals(_Tname, torqueName, StringComparison.OrdinalIgnoreCase))
                            {
                                TorqueScanSuccess?.Invoke(torqueName, torqueValue, torquemin, torquemax);
                                targetTorqueFound = true;

                            }
                        }


                        if (targetTorqueFound)
                        {
                            ShowMessage($"Torque '{_Tname}' Scanned Successfully. All Torque Data Updated.", Color.Green);
                        }
                    }



                }
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"JSON Error: {ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, Color.Orange);
            }

        }
        private void ShowMessage(string message, Color color)
        {
            lbl_msg.ForeColor = color;
            lbl_msg.Text = message;
        }

        private void scantorque_Load(object sender, EventArgs e)
        {
            LoadTorqueData(dataserials);

        }

        private void LoadTorqueData(DataTable subp_serials)
        {
            tempqty = int.Parse(qty);
            tempcount = int.Parse(count);
            lbl_scancount.Text = count + " out of " + qty;

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("row_number", "#");
            dataGridView1.Columns.Add("torque_name", "Torque Name");
            dataGridView1.Columns.Add("torque_value", "Torque Value");
            dataGridView1.Columns.Add("torque_min", "Min");
            dataGridView1.Columns.Add("torque_max", "Max");

            dataGridView1.Columns["row_number"].Width = 50;


            int index = 1;
            string currentProcessId = processid;

            foreach (DataRow torqueRow in subp_serials.Rows)
            {
                bool matchesProcess = currentProcessId == torqueRow["id"]?.ToString();
                bool hasTorqueName = !string.IsNullOrEmpty(torqueRow["torque_name"]?.ToString());

                if (matchesProcess && hasTorqueName)
                {
                    dataGridView1.Rows.Add(
                        index++,
                        torqueRow["torque_name"]?.ToString() ?? "",
                        torqueRow["value"]?.ToString() ?? "",
                        torqueRow["min"]?.ToString() ?? "",
                        torqueRow["max"]?.ToString() ?? ""
                    );
                }
            }
        }

    }
}
