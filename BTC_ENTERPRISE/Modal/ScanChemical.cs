using System.Data;
using BTC_ENTERPRISE;
using BTC_ENTERPRISE.Class;
using BTC_ENTERPRISE.Model;
using Frameworks.Utilities.ApiUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BTC_EnterpriseV2.Modal
{
    public partial class ScanChemical : Form
    {
        private string PostChemical = GlobalApi.GetPostChemicalAssignUrl();
        private DataTable dataserials;
        private string _MaterialID;
        public int rowindex;
        private ProcessFrm _processfrm;

        //access to return value
        private string cname;
        private string cexp;

        public event Action<string, string, string> ChemicalScanSuccess;
        public ScanChemical(ProcessFrm processFrm, int rowindex, string materialid, DataTable dtserials)
        {
            InitializeComponent();
            this.dataserials = dtserials;
            this.rowindex = rowindex;
            this._MaterialID = materialid;
            lbl_msg.Text = "Please scan the QR of the Chemical to processed.";
        }
        private void ScanChemical_Load(object sender, EventArgs e)
        {
            LoadProcessData(dataserials);

        }
        private async void txt_chemical_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txt_chemical.Text))
                {
                    MessageBox.Show("Please enter a serial number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string inputString = txt_chemical.Text; //split by |

                char delimiter = '|';

                string[] parts = inputString.Split(delimiter);

                string chemicalName = parts[0].Trim();
                string expiryDate = parts[1].Trim();
                cname = chemicalName;
                cexp = expiryDate;

                await PostItemSerial(chemicalName, expiryDate, _MaterialID);

            }

        }

        public async Task PostItemSerial(string chemicalname, string expirydate, string materialId)
        {
            try
            {
                // Sanitize inputs
                var postData = new
                {
                    chemical_name = chemicalname.Trim(),
                    chemical_expiration = expirydate.Trim(),
                    material_id = materialId.Trim(),
                };
                string json = JsonConvert.SerializeObject(postData);

                string jsonResponse = await WebRequestApi.PostRequest(PostChemical, json);

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

                    bool exists = dataGridView1.Rows
                        .Cast<DataGridViewRow>()
                        .Any(r => r.Cells["chemical_name"].Value?.ToString() == data.serial_number);

                    if (!exists)
                    {

                    }
                    else
                    {
                        ShowMessage("This serial number has already been scanned.", Color.Orange);
                    }


                }
                else
                {
                    ChemicalScanSuccess?.Invoke(materialId, cname, cexp);

                    bool exists = dataGridView1.Rows
                      .Cast<DataGridViewRow>()
                      .Any(r => r.Cells["chemical_name"].Value?.ToString() == cname);

                    if (!exists)
                    {
                        int rowNumber = dataGridView1.Rows.Count + 1;
                        dataGridView1.Rows.Add(rowNumber, cname);

                    }


                    ShowMessage($"Scanned Successfully!.", Color.Green);

                    txt_chemical.Clear();
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

        private void lbl_processname_Click(object sender, EventArgs e)
        {

        }


        private void LoadProcessData(DataTable serials)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("NoProcess", "No.");
            dataGridView1.Columns.Add("serial_number", "Item Serial Number");
            dataGridView1.Columns["NoProcess"].Width = 50;

            int index = 1;
            foreach (DataRow serial in serials.Rows)
            {
                if (_MaterialID == serial[1].ToString())
                {
                    dataGridView1.Rows.Add(index++, serial[16]);
                }
            }
        }
    }
}
