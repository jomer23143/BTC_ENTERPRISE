﻿using BTC_ENTERPRISE.Class;
using BTC_ENTERPRISE.Model;
using Frameworks.Utilities;
using BTC_ENTERPRISE.YaoUI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Frameworks.Utilities.ApiUtilities;

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
        private string PostTorque = GlobalApi.GetPostMaterialAssignTorqueUrl();

        public event Action<string, string> TorqueScanSuccess;

        private ProcessFrm _processfrm;
        public scantorque(ProcessFrm processFrm, string processid, string processname, string qty, string count)
        {
            InitializeComponent();
            YUI yUI = new YUI();
            // yUI.RoundedFormsDocker(this, 8);
            yUI.RoundedTextBox(txt_torque, 6, Color.White);
            yUI.RoundedPanelDocker(panel_processname, 6);
            this.processid = processid;
            lbl_processname.Text = processname;
            this.qty = qty;
            this.count = count;
            this._processfrm = processFrm;
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

                if (tempcount >= tempqty)
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

                // Check if the response is empty or invalid HTML
                if (string.IsNullOrWhiteSpace(jsonResponse) || jsonResponse.StartsWith("<"))
                {
                    ShowMessage("Invalid response from server.", Color.Red);
                    return;
                }
                var token = JToken.Parse(jsonResponse);

                // Handle object-based response (likely error/info)
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
                // Handle array-based response (expected successful data)
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
                        //  Debug.WriteLine("Parse Error: " + parseEx);
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

                    if (token.Type == JTokenType.Object && token["machine_tool_torque_value"] != null)
                    {
                        string torqueValue = token["machine_tool_torque_value"]?.ToString();
                        string torqueName = token["machine_tool_torque_name"]?.ToString();
                        string torqueRange = token["machine_tool_torque_range"]?.ToString();

                        TorqueScanSuccess?.Invoke(torqueName, torqueValue);

                        // Check if serial already exists
                        var existingRow = dataGridView1.Rows
                            .Cast<DataGridViewRow>()
                            .FirstOrDefault(r => r.Cells["torque_name"].Value?.ToString() == torqueName);

                        if (existingRow == null)
                        {
                            // 🔹 Add new row
                            tempcount++;
                            int rowIndex = dataGridView1.Rows.Add();

                            var row = dataGridView1.Rows[rowIndex];
                            row.Cells["row_number"].Value = rowIndex + 1;
                            row.Cells["torque_name"].Value = torqueName;
                            row.Cells["torque_value"].Value = torqueValue;
                            row.Cells["torque_range"].Value = torqueRange;
                        }
                        else
                        {
                            // 🔹 Update existing row’s torque info
                            existingRow.Cells["torque_name"].Value = torqueName;
                            existingRow.Cells["torque_value"].Value = torqueValue;
                            existingRow.Cells["torque_range"].Value = torqueRange;
                        }

                        ShowMessage($"Torque Machine Tools Scanned Successfully.", Color.Green);
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
            tempqty = int.Parse(qty);
            tempcount = int.Parse(count);
            lbl_scancount.Text = count + " out of " + qty;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("row_number", "#");
            dataGridView1.Columns.Add("torque_name", "Torque Name");
            dataGridView1.Columns.Add("torque_value", "Torque Value");
            dataGridView1.Columns.Add("torque_range", "Torque Range");
            dataGridView1.Columns["row_number"].Width = 50;

        }
    }
}
