using System.Data;
using System.Diagnostics;
using BTC_ENTERPRISE.Class;
using BTC_ENTERPRISE.Modal;
using BTC_ENTERPRISE.Model;
using BTC_ENTERPRISE.YaoUI;
using Frameworks.Utilities.ApiUtilities;
using Newtonsoft.Json.Linq;

namespace BTC_ENTERPRISE.Forms
{
    public partial class PrintQRFrm : Form
    {

        private DataTable dt_list_Station_Serial = new DataTable();
        private string storedmoid = string.Empty;
        private string? T;
        private readonly string email = "super_admin@btcpower.com";
        private readonly string password = "password";
        public PrintQRFrm()
        {
            InitializeComponent();
            pb_loader.Visible = false;
            YUI yUI = new YUI();
            yUI.RoundedTextBox(txt_moid, 5, Color.White);
            txt_moid.Select();
            btn_printallin1.Visible = false;
        }
        private  void PrintQRFrm_Load(object sender, EventArgs e)
        {
            //Dictionary<string, object> dict = new Dictionary<string, object>()
            //{
            //    { "email", email.Trim() },
            //    { "password", password.Trim() }
            //};
            //var res = await ApiHelper.PostJsonAsync(GlobalApi.GetAdminLoginUrl(), dict);
            //var token = res?.ToObject<LoginToken.Root>();
            //T = token?.token;
        }
        private async void txt_moid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var moid = txt_moid.Text.Trim();
                storedmoid = moid;
                pb_loader.Visible = true;

                var api = $"{GlobalApi.GetManufacturingOrdersUrl()}?with_segment=1&with_station=1&with_process=0&mo_id={moid}&per_row=9999";
                var jsonResponse = await WebRequestApi.GetData_httpclient_Token(api,Global.UserToken);
                var jtoken = JToken.Parse(jsonResponse);
                var toObj = jtoken.ToObject<PrintQR_Model.RootWrapper>();
                var datalist = toObj?.data ?? new List<PrintQR_Model.Main>();

                pb_loader.Visible = false;

                if (datalist == null || datalist.Count == 0)
                {
                    MessageBox.Show("No valid process data returned or invalid MO ID.",
                        "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadProcessData(datalist);

                Debug.WriteLine($"Retrieved {datalist.Count} items");
            }
        }
        private void LoadProcessData(List<PrintQR_Model.Main> processes)
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("No", "#");
            dataGridView1.Columns.Add("Segment", "Segment Name");
            dataGridView1.Columns.Add("Station", "Station Name");
            dataGridView1.Rows.Add();

            DataTable dt = new DataTable("Segmet_Station");
            dt.Columns.Add("No");
            dt.Columns.Add("Segment");
            dt.Columns.Add("Station");

            DataTable dtstation_serial_number = new DataTable("Station_Serial_Number");
            dtstation_serial_number.Columns.Add("manufacturing_order_id");
            dtstation_serial_number.Columns.Add("Station");
            dtstation_serial_number.Columns.Add("serial_number");

            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
            {
                Name = "Printing",
                HeaderText = "View",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            dataGridView1.Columns.Add(imgColumn);


            string defaultImagePath = Path.Combine(Application.StartupPath, "Assets", "file.png");
            Image originalImage = Image.FromFile(defaultImagePath);
            Image resizedImage = ResizeImage(originalImage, 60, 60);

            int index = 1;
            foreach (var process_list in processes)
            {
                var segment = process_list.segment;
                foreach (var segment_list in segment)
                {
                    var station = segment_list.station;
                    if (segment_list.name == "Rain Test") continue;
                    if (segment_list.name == "Main Assembly") continue;
                    if (segment_list.name == "In-station QC") continue;
                    if (segment_list.name == "EOL Test") continue;
                    if (segment_list.name == "Final Assembly") continue;
                    if (segment_list.name == "Final QC") continue;
                    if (segment_list.name == "Packing") continue;
                    foreach (var station_list in station)
                    {
                        bool exists = dt.AsEnumerable().Where(c => c.Field<string>("Station").Equals(station_list.name)).Count() > 0;
                        if (!exists)
                        {
                            dt.Rows.Add(index++, segment_list.name, station_list.name);
                        }
                        dtstation_serial_number.Rows.Add(segment_list.manufacturing_order_id, station_list.name, station_list.serial_number);
                    }
                }
            }
            dt_list_Station_Serial = dtstation_serial_number;
            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(row["no"].ToString(), row["Segment"].ToString(), row["Station"].ToString(), resizedImage);
            }
            btn_printallin1.Visible = true;
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

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
               e.ColumnIndex == dataGridView1.Columns["Printing"]?.Index)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                var station_name = row.Cells["Station"].Value?.ToString();
                ViewStationGeneratedSerials_1 qrprint1 = new ViewStationGeneratedSerials_1(storedmoid, station_name, dt_list_Station_Serial);
                qrprint1.ShowDialog();
            }
        }
        private void btn_printallin1_Click(object sender, EventArgs e)
        {
            DataTable newdataforPrint = new DataTable("newdataforPrint");

            // Define columns
            newdataforPrint.Columns.Add("manufacturing_order_id", typeof(string));
            newdataforPrint.Columns.Add("Station", typeof(string));
            newdataforPrint.Columns.Add("serial_number", typeof(string));

            // Get the first manufacturing_order_id (as string)
            var firstBatchId = dt_list_Station_Serial.AsEnumerable()
                .Select(row => row.Field<string>("manufacturing_order_id"))
                .Distinct()
                .OrderBy(id => id)
                .FirstOrDefault();

            // Filter rows that belong to the first batch
            var firstBatchRows = dt_list_Station_Serial.AsEnumerable()
                .Where(row => row.Field<string>("manufacturing_order_id") == firstBatchId)
                .ToList();

            // Fill the new DataTable
            foreach (var row in firstBatchRows)
            {
                string moId = row.Field<string>("manufacturing_order_id");
                string station = row.Field<string>("Station");
                string serial = row.Field<string>("serial_number");

                newdataforPrint.Rows.Add(moId, station, serial);
            }

            printingqrviewForm printingqrviewForm = new printingqrviewForm(newdataforPrint);
            printingqrviewForm.ShowDialog();
        }

    }
}
