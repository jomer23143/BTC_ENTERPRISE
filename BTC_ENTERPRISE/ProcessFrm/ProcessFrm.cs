using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using BTC_ENTERPRISE.Class;
using BTC_ENTERPRISE.Modal;
using BTC_ENTERPRISE.Model;
using BTC_ENTERPRISE.YaoUI;
using BTC_EnterpriseV2.Modal;
using Frameworks;
using Frameworks.Utilities.ApiUtilities;
using Newtonsoft.Json.Linq;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Styles;
using Timer = System.Windows.Forms.Timer;

namespace BTC_ENTERPRISE
{
    public partial class ProcessFrm : Form
    {
        private Timer timer;
        private int timer_durration;

        public static ProcessFrm instance;
        private DateTime _startTime;

        private string Postprocess = GlobalApi.GetPostProcessUrl();
        private TimeFormat timeFormat = new TimeFormat();
        public DataTable tbl_process = new DataTable("tblp");
        public DataTable tbl_subprocess = new DataTable("tblsp");
        public bool _IsTScanSuccess = false;
        public bool _IsMScanSuccess = false;
        public string _returnTorqueName = "";
        public string _returnTorqueValue = "";
        public string? _MoID;
        public string _serial;
        private int _segmentID;
        private string processname;
        private string segmentname;
        private string processstatus;
        private string durationDisplay;
        private int _selectedProcessID;
        private bool _started = false;
        private int _processStrtID;
        private bool IsScanItem = true;
        private bool _IsScanChemical = true;
        private bool _IscanOK = false;
        private FormManager formManager;
        private System.Windows.Forms.Timer fadeTimer;
        private string Token;
        private ProcessScanner1 _processScanner;
        private scantorque _scanTorque;
        private ShowCustomizeAlert ShowCustomizeAlert;
        //Final Test
        private Timer processTimer;
        private DateTime startTime;
        private bool isRunning = false;
        private Dictionary<int, DateTime> activeProcesses = new Dictionary<int, DateTime>();
        private string _storedDuration;
        private string _storedChildDuration;
        private bool durationUpdated;


        private DataTable parentDurationDatatable = new DataTable("p");
        private DataTable ChildrowDataTable = new DataTable("Cr");
        public SfDataGrid _sfDataGrid2;
        public ProcessFrm(string scangeneratedSerial, int segmentid, string moid, string segmentname, string processname, string operatorfullname, string thetoken, DataTable plist, DataTable subplist)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            durationUpdated = false;
            QrController();
            instance = this;
            _sfDataGrid2 = sfDataGrid2;
            this._serial = scangeneratedSerial;
            pb_child.Visible = false;
            this._MoID = moid;
            this._segmentID = segmentid;
            this.processname = processname;
            this.segmentname = segmentname;
            this.tbl_process = plist;
            this.tbl_subprocess = subplist;
            this.lbl_operatorname.Text = operatorfullname;
            this.Token = thetoken;
            formManager = new FormManager(panel_top, panel_parent_tab_subprocess);
            YUI yaoui = new YUI();
            //yaoui.RoundedButton(btn_material, 8, Color.FromArgb(27, 86, 253));
            //yaoui.RoundedButton(btn_torque, 8, Color.FromArgb(7, 222, 151));
            //yaoui.RoundedButton(btn_chemical, 8, Color.FromArgb(255, 128, 0));
            yaoui.RoundedPanelDocker(panel_material, 8);
            yaoui.RoundedPanelDocker(panel_torque, 8);
            yaoui.RoundedPanelDocker(panel_chemical, 8);
            yaoui.RoundedButton(btn_qcChecklist, 8, Color.Tomato);
            // checkBoxAdv2.Checked = true;

            // Timers
            processTimer = new Timer();
            processTimer.Interval = 1000;
            processTimer.Tick += timer_duration_Tick;

        }
        private void QrController()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            this.FormBorderStyle = FormBorderStyle.None;


        }
        private async void ProcessFrm_Load(object sender, EventArgs e)
        {
            lbl_mo.Text = _MoID;
            lbl_segment.Text = segmentname;
            lbl_parentname.Text = processname;
            lbl_generatedSerial.Text = _serial;
            pb_parent.Visible = true;

            await LoadProcessDataMerged_Sf(tbl_process);


        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan duration = DateTime.Now - _startTime;
            durationDisplay = timeFormat.FormatDuration(duration);
        }


        private async Task LoadProcessDataMerged_Sf(DataTable processlist)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });

            sfDataGrid1.AutoGenerateColumns = false;
            sfDataGrid1.Columns.Clear();
            sfDataGrid1.RowHeight = 90;
            sfDataGrid1.AutoSizeColumnsMode = AutoSizeColumnsMode.Fill;
            sfDataGrid1.AllowEditing = false;
            sfDataGrid1.RowHeaderWidth = 70;

            CellStyleInfo cellstyle = new CellStyleInfo
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = Color.Black,
                Font = new GridFontInfo(new Font("Segoe UI", 18, FontStyle.Bold))
            };

            CellStyleInfo cellstyle1 = new CellStyleInfo
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = Color.Black,
                Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Regular))
            };

            sfDataGrid1.HeaderRowHeight = 45;
            sfDataGrid1.Style.HeaderStyle.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Bold));
            sfDataGrid1.Style.HeaderStyle.BackColor = Color.Gray;
            sfDataGrid1.Style.HeaderStyle.TextColor = Color.Black;
            sfDataGrid1.Style.SelectionStyle.BackColor = Color.PaleGreen;
            sfDataGrid1.Style.SelectionStyle.TextColor = Color.Black;
            sfDataGrid1.AllowEditing = true;
            sfDataGrid1.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Single;
            sfDataGrid1.NavigationMode = Syncfusion.WinForms.DataGrid.Enums.NavigationMode.Row;

            // --- Columns ---
            sfDataGrid1.Columns.Add(new GridButtonColumn()
            {
                MappingName = "ExpandCollapse",
                HeaderText = "",
                CellStyle = cellstyle,
                Width = 50,
                Visible = false,
                AllowDefaultButtonText = true
            });

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Index", HeaderText = "#", Width = 50, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Process", Width = 450, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "StartTime", HeaderText = "Time Start", Visible = true, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "EndTime", HeaderText = "Time End", Visible = true, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Duration", HeaderText = "Duration", CellStyle = cellstyle1, AllowTextWrapping = true });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Status", HeaderText = "Status", Visible = true, CellStyle = cellstyle1, AllowTextWrapping = true });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Color", HeaderText = "Color", Visible = false });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Id", HeaderText = "ID", Visible = false });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CycleTime", HeaderText = "CycleTime", Visible = false });

            sfDataGrid1.Columns.Add(new GridButtonColumn() { MappingName = "StartButton", HeaderText = "Start", CellStyle = cellstyle });
            sfDataGrid1.Columns.Add(new GridButtonColumn() { MappingName = "EndButton", HeaderText = "End", CellStyle = cellstyle });
            sfDataGrid1.Columns.Add(new GridButtonColumn() { MappingName = "HoldButton", HeaderText = "Hold", CellStyle = cellstyle });


            var groupedProcesses = processlist.AsEnumerable()
                .GroupBy(row => row.Field<int>("id"))
                .Select(group => new
                {
                    ProcessId = group.Key,
                    AllDurationRows = group.OrderBy(r => r.Field<string>("end_time") == null).ThenBy(r => DateTime.TryParse(r.Field<string>("end_time"), out var dt) ? dt : DateTime.MinValue).ToList()

                })
                .ToList();


            var viewModels = new List<ViewModel.ProcessViewModel>();
            int index = 1;
            var childrowStartime = "";

            foreach (var group in groupedProcesses)
            {
                TimeSpan totalDuration = TimeSpan.Zero;

                System.Data.DataRow lastDurationRow = group.AllDurationRows.Last();

                string processId = Convert.ToString(lastDurationRow["id"]);
                string processName = lastDurationRow["name"]?.ToString() ?? "Unknown";
                string statusName = lastDurationRow["status"]?.ToString() ?? "Unknown";
                string statusColor = lastDurationRow["color"]?.ToString() ?? "White";
                string cycleTime = lastDurationRow["cycle_time"]?.ToString() ?? "N/A";

                string startTimeDisplay = "-";
                string endTimeDisplay = "-";

                DateTime parsedStart;
                DateTime parsedEnd;
                if (lastDurationRow["start_time"] != DBNull.Value && DateTime.TryParse(lastDurationRow["start_time"].ToString(), out parsedStart))
                {
                    startTimeDisplay = $"Time: {parsedStart:HH:mm:ss} Date: {parsedStart:MM-dd-yyyy}";

                    if (lastDurationRow["end_time"] != DBNull.Value && DateTime.TryParse(lastDurationRow["end_time"].ToString(), out parsedEnd))
                    {
                        endTimeDisplay = $"Time: {parsedEnd:HH:mm:ss} Date: {parsedEnd:MM-dd-yyyy}";

                    }
                    else
                    {
                        endTimeDisplay = "-:-:-";

                        timer1.Start();
                    }
                }

                var childProcesses = new BindingList<ViewModel.ChildProcessViewModel>();

                var startedRows = group.AllDurationRows
                    .Where(r => !string.IsNullOrEmpty(r["start_time"]?.ToString()))
                    .ToList();


                DateTime? activeChildStartTime = null;
                int? activeChildId = null;

                foreach (System.Data.DataRow durationRow in startedRows)
                {
                    string childStartTime = durationRow["start_time"]?.ToString() ?? "-";
                    string childEndTime = durationRow["end_time"]?.ToString() ?? "-";
                    string status = durationRow["status"]?.ToString() ?? "";


                    string childDurationDisplay = "0 Days : 00 : 00 : 00";
                    DateTime childParsedStart, childParsedEnd;
                    TimeSpan currentDuration = TimeSpan.Zero;

                    if (DateTime.TryParse(childStartTime, out childParsedStart))
                    {
                        if (DateTime.TryParse(childEndTime, out childParsedEnd))
                        {
                            currentDuration = childParsedEnd - childParsedStart;
                        }
                        else
                        {
                            // Active (no end time)
                            currentDuration = DateTime.Now - childParsedStart;
                            activeChildStartTime = childParsedStart;
                            activeChildId = Convert.ToInt32(durationRow["id"]);
                        }

                        childDurationDisplay = timeFormat.FormatDuration(currentDuration);
                        totalDuration = totalDuration.Add(currentDuration);
                    }
                    if (string.IsNullOrWhiteSpace(durationRow["status"].ToString()))
                    {
                        var timeSpan = DateTime.Now - Convert.ToDateTime(childStartTime);
                        _storedChildDuration = timeSpan.ToString();
                    }
                    childProcesses.Add(new ViewModel.ChildProcessViewModel
                    {
                        Id = Convert.ToInt32(durationRow["id"]),
                        ProcessId = processId,
                        TimeStart = childStartTime,
                        TimeEnd = childEndTime,
                        Duration = childDurationDisplay,
                        Remarks = durationRow["remark"]?.ToString() ?? "",
                        StatusName = status
                    });
                }


                string finalTotalDurationDisplay = timeFormat.FormatDuration(totalDuration);

                viewModels.Add(new ViewModel.ProcessViewModel
                {
                    Index = index++,
                    expandIcon = "+",
                    ProcessId = processId,
                    Name = processName,

                    StartTime = startTimeDisplay,
                    EndTime = endTimeDisplay,

                    Duration = finalTotalDurationDisplay,

                    Status = statusName,
                    Color = statusColor,
                    CycleTime = cycleTime,

                    StartButton = "▶",
                    EndButton = "⏹",
                    HoldButton = "⏸",

                    SubProcesses = childProcesses
                });
                var record = new ViewModel.ProcessViewModel
                {
                    Index = index,
                    expandIcon = "+",
                    ProcessId = processId,
                    Name = processName,

                    StartTime = startTimeDisplay,
                    EndTime = endTimeDisplay,

                    Duration = finalTotalDurationDisplay,

                    Status = statusName,
                    Color = statusColor,
                    CycleTime = cycleTime,

                    StartButton = "▶",
                    EndButton = "⏹",
                    HoldButton = "⏸",

                    SubProcesses = childProcesses
                };
                if (statusName == "Processing")
                {
                    record.AccumulatedDuration += totalDuration;
                    DateTime startTime = DateTime.Now;
                    activeProcesses[Convert.ToInt32(processId)] = startTime;
                    _storedDuration = record.Duration;
                    StartProcessTimers(record);
                    // StartProcessTimers(record, activeChildStartTime, activeChildId);
                }

            }

            sfDataGrid1.DataSource = viewModels;
            sfDataGrid1.DetailsViewDefinitions.Clear();
            sfDataGrid1.DetailsViewDefinitions.Add(GetChildViewDefinition());

            pb_parent.Visible = false;
        }




        private GridViewDefinition GetChildViewDefinition()
        {
            var childGrid = new SfDataGrid
            {
                AutoGenerateColumns = false
            };
            CellStyleInfo cellstyle1 = new CellStyleInfo
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = Color.Black,
                BackColor = Color.LightSkyBlue
            };
            childGrid.AutoSizeColumnsMode = AutoSizeColumnsMode.Fill;
            childGrid.HeaderRowHeight = 45;
            childGrid.RowHeight = 80;
            childGrid.Style.HeaderStyle.BackColor = Color.Gray;
            cellstyle1.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Regular));
            childGrid.Columns.Add(new GridTextColumn { MappingName = "Id", HeaderText = "#", Visible = false, CellStyle = cellstyle1 });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "ProcessId", HeaderText = "Process ID", CellStyle = cellstyle1 });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "TimeStart", HeaderText = "Start Time", Format = "g", CellStyle = cellstyle1, AllowTextWrapping = true });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "TimeEnd", HeaderText = "End Time", Format = "g", CellStyle = cellstyle1, AllowTextWrapping = true });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "Duration", HeaderText = "Duration", CellStyle = cellstyle1, AllowTextWrapping = true });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "Remarks", HeaderText = "Remarks", CellStyle = cellstyle1, AllowTextWrapping = true });

            return new GridViewDefinition
            {
                RelationalColumn = "SubProcesses",
                DataGrid = childGrid
            };
        }

        private async Task LoadSubProcessData(int processID, DataTable subprocess)
        {

            // --- Setup Grid ---
            sfDataGrid2.AutoGenerateColumns = false;
            sfDataGrid2.Columns.Clear();
            sfDataGrid2.RowHeight = 90;
            sfDataGrid2.AutoSizeColumnsMode = AutoSizeColumnsMode.Fill;
            sfDataGrid2.AllowEditing = true;
            sfDataGrid2.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Single;
            sfDataGrid2.NavigationMode = Syncfusion.WinForms.DataGrid.Enums.NavigationMode.Row;
            CellStyleInfo cellstyle1 = new CellStyleInfo
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = Color.FromArgb(0, 0, 0),
            };
            cellstyle1.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Regular));
            sfDataGrid2.HeaderRowHeight = 45;
            sfDataGrid2.Style.HeaderStyle.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Bold));
            sfDataGrid2.Style.HeaderStyle.BackColor = Color.Gray;
            sfDataGrid2.Style.HeaderStyle.TextColor = Color.Black;
            sfDataGrid2.Style.SelectionStyle.BackColor = Color.LimeGreen;
            sfDataGrid2.Style.SelectionStyle.TextColor = Color.White;

            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Index", HeaderText = "#", Width = 50, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "MaterialID", HeaderText = "ID", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Material", Width = 300, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Ipn", HeaderText = "ipn", AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Torque", HeaderText = "Torque", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Serial_qty", HeaderText = "Qty", Visible = true, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Serial_count", HeaderText = "s", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "IsSerialized", HeaderText = "IsSerialized", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "IsTorque", HeaderText = "IsTorque", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Torque_count", HeaderText = "tc", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "IsChemical", HeaderText = "ischemical", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "manufacturing_order_id", HeaderText = "id", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Torque_value", HeaderText = "Tvalue", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });
            sfDataGrid2.Columns.Add(new GridTextColumn() { MappingName = "Chemical_name", HeaderText = "Cname", Visible = false, AllowTextWrapping = true, CellStyle = cellstyle1 });

            // --- Filter rows by processID ---
            var filteredRows = subprocess.AsEnumerable()
                .Where(r => r.Field<int>("manufacturing_order_process_id") == processID);

            // --- Map Processes to ViewModel ---
            var viewModels = new List<ViewModel.SubProcessView>();
            int index = 1;

            foreach (var row in filteredRows)
            {
                var kitlist = row.Field<int>("is_kit_list");

                if (kitlist == 0)
                {
                    // do not include in the row.
                }
                else
                {
                    viewModels.Add(new ViewModel.SubProcessView
                    {
                        //  Torque_count = !string.IsNullOrEmpty(row.Field<string>("value")) ? "1" : "0",
                        Torque_count = row.Field<string>("torque_count"),
                        Serial_count = row.Field<int>("is_serial") == 1 ? row["serial_count"]?.ToString() ?? "0" : "0",

                        Chemical_count = row["chemical_count"].ToString(),

                        Index = index++,
                        MaterialID = row.Field<int>("id"),
                        Name = row["description"]?.ToString() ?? "N/A",
                        Ipn = row["ipn_number"]?.ToString() ?? "N/A",

                        Torque = string.Format("({0}) {1}",
                          string.IsNullOrEmpty(row["torque_name"]?.ToString()) ? "N/A" : row["torque_name"].ToString(),
                          string.IsNullOrEmpty(row["value"]?.ToString()) ? "N/A" : row["value"].ToString()),

                        Serial_qty = row["serial_quantity"]?.ToString() ?? "0",
                        IsSerialized = row.Field<int>("is_serial"),
                        IsTorque = row.Field<int>("is_torque"),
                        IsChemical = row.Field<string>("is_chemical"),
                        manufacturing_order_id = row.Field<int>("manufacturing_order_process_id"),
                        Torque_value = row.Field<string>("value").ToString(),
                        Chemical_name = row.Field<string>("chemical_name").ToString(),

                    });
                }


            }


            sfDataGrid2.DataSource = viewModels;

            if (viewModels.Count > 0)
            {
                sfDataGrid2.SelectedIndex = 0;

                var firstRecord = viewModels[0];


                ProcessSubProcessSelection(firstRecord, sfDataGrid2);
            }
            sfDataGrid2.DetailsViewDefinitions.Clear();

            pb_child.Visible = false;
        }



        //child of subprocess
        private GridViewDefinition GetChildSubPviewDefinition()
        {
            var childGrid = new SfDataGrid
            {
                AutoGenerateColumns = false
            };
            CellStyleInfo cellstyle1 = new CellStyleInfo
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextColor = Color.Black,
                BackColor = Color.LightSkyBlue
            };
            childGrid.AutoSizeColumnsMode = AutoSizeColumnsMode.Fill;
            childGrid.HeaderRowHeight = 45;
            childGrid.RowHeight = 80;
            childGrid.Style.HeaderStyle.BackColor = Color.Gray;
            cellstyle1.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Regular));
            childGrid.Columns.Add(new GridTextColumn { MappingName = "Id", HeaderText = "#", Visible = false, CellStyle = cellstyle1 });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "SerialNumber", HeaderText = "Serial Number", CellStyle = cellstyle1 });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "ChemicalName", HeaderText = "Chemical Name", Format = "g", CellStyle = cellstyle1, AllowTextWrapping = true });
            childGrid.Columns.Add(new GridTextColumn { MappingName = "ChemicalExpiry", HeaderText = "Chemical Expiry", Format = "g", CellStyle = cellstyle1, AllowTextWrapping = true });

            return new GridViewDefinition
            {
                RelationalColumn = "ChildSubProcessView",
                DataGrid = childGrid
            };
        }


        private void sfDataGrid1_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {

            if (e.Column == null) return;

            int recordIndex = sfDataGrid1.TableControl.ResolveToRecordIndex(e.RowIndex);
            if (recordIndex < 0) return;

            var record = sfDataGrid1.View.Records.GetItemAt(recordIndex) as ViewModel.ProcessViewModel;
            if (record == null) return;


            if (e.Column.MappingName == "ExpandCollapse")
            {
                e.Style.Font = new GridFontInfo(new Font("Segoe UI", 12, FontStyle.Bold));
                e.Style.TextColor = Color.Red;

            }


            if (e.Column.MappingName == "Status")
            {
                Color textColor = Color.LightGray;

                if (!string.IsNullOrWhiteSpace(record.Color))
                {
                    try
                    {
                        string hex = record.Color.Replace("#", "");

                        if (hex.Length == 6)
                        {
                            textColor = ColorTranslator.FromHtml("#" + hex);
                        }
                        else if (hex.Length == 8) // ARGB
                        {
                            byte a = Convert.ToByte(hex.Substring(0, 2), 16);
                            byte r = Convert.ToByte(hex.Substring(2, 2), 16);
                            byte g = Convert.ToByte(hex.Substring(4, 2), 16);
                            byte b = Convert.ToByte(hex.Substring(6, 2), 16);
                            textColor = Color.FromArgb(a, r, g, b);
                        }
                    }
                    catch
                    {
                        textColor = Color.LightGray;
                    }
                }


                e.Style.TextColor = textColor;
                e.Style.Font = new GridFontInfo(new Font("Segoe UI", 10, FontStyle.Bold));
            }


            var firstPendingRow = sfDataGrid1.View.Records
                .Select(r => r.Data as ViewModel.ProcessViewModel)
                .FirstOrDefault(r => r.Status != "Completed");

            if (record != firstPendingRow)
            {
                e.Style.BackColor = Color.LightGray;
                e.Style.TextColor = Color.DarkGray;
            }



        }

        private void sfDataGrid1_QueryButtonCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryButtonCellStyleEventArgs e)
        {
            if (e.RowIndex < 0 || e.Column == null) return;

            int recordIndex = sfDataGrid1.TableControl.ResolveToRecordIndex(e.RowIndex);
            if (recordIndex < 0) return;

            var record = sfDataGrid1.View.Records.GetItemAt(recordIndex) as ViewModel.ProcessViewModel;
            if (record == null) return;

            if (_IscanOK == true)
            {
                e.Style.TextColor = Color.Green;
            }

            bool isRowEnabled = false;

            if (recordIndex == 0)
            {

                isRowEnabled = record.Status != "Completed";
            }
            else
            {

                var prevRecord = sfDataGrid1.View.Records.GetItemAt(recordIndex - 1) as ViewModel.ProcessViewModel;
                if (prevRecord != null && prevRecord.Status == "Completed" && record.Status != "Completed")
                {
                    isRowEnabled = true;
                }
            }

            switch (e.Column.MappingName)
            {
                case "StartButton":
                    if (!isRowEnabled || record.Status == "Completed" || record.IsCancelled || record.Status == "Processing")
                    {
                        e.Style.BackColor = Color.LightGray;
                        e.Style.TextColor = Color.DarkGray;
                        e.Style.Enabled = false;
                    }
                    else
                    {
                        e.Style.BackColor = Color.ForestGreen;
                        e.Style.TextColor = Color.White;
                        e.Style.Enabled = true;
                    }
                    break;

                case "HoldButton":
                    if (!isRowEnabled || record.Status == "Open" || record.Status == "Completed" || record.IsCancelled)
                    {
                        e.Style.BackColor = Color.LightGray;
                        e.Style.TextColor = Color.DarkGray;
                        e.Style.Enabled = false;
                    }
                    else
                    {
                        e.Style.BackColor = Color.Goldenrod;
                        e.Style.TextColor = Color.White;
                        e.Style.Enabled = true;
                    }
                    break;

                case "EndButton":
                    if (!isRowEnabled || record.Status == "Open" || record.Status == "Completed" || record.IsCancelled)
                    {
                        e.Style.BackColor = Color.LightGray;
                        e.Style.TextColor = Color.DarkGray;
                        e.Style.Enabled = false;
                    }
                    else
                    {
                        e.Style.BackColor = Color.Salmon;
                        e.Style.TextColor = Color.White;
                        e.Style.Enabled = true;
                    }
                    break;

                case "ExpandCollapse":
                    if (record.IsExpanded)
                    {
                        e.Style.TextColor = Color.Red;
                        e.Style.Enabled = true;
                        e.Style.BackColor = Color.SeaGreen;
                        record.expandIcon = "➖";

                    }
                    else
                    {
                        e.Style.TextColor = Color.Green;
                        e.Style.Enabled = true;
                        e.Style.BackColor = Color.LimeGreen;
                        record.expandIcon = "➕";

                    }
                    break;
            }
        }




        private async void sfDataGrid1_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            if (sfDataGrid1.SelectedItem is ViewModel.ProcessViewModel record)
            {
                int selectedId = Convert.ToInt32(record.ProcessId);
                _selectedProcessID = selectedId;
                string selectedName = record.Name;

                processstatus = record.Status;
                if (record.Status != "Processing")
                {
                    formManager.closeAForm();
                }
                lbl_processname.Text = $"Process Name : {selectedName}";
                sfDataGrid2.Columns.Clear();
                pb_child.Visible = true;
                lbl_subprocessInfo.Text = "";
                await LoadSubProcessData(selectedId, tbl_subprocess);


                //   sfDataGrid2.SelectedIndex = 0;

            }
        }


        private async void sfDataGrid1_CellButtonClick_1(object sender, Syncfusion.WinForms.DataGrid.Events.CellButtonClickEventArgs e)
        {
            // --- Initial Checks ---
            int recordIndex = sfDataGrid1.TableControl.ResolveToRecordIndex(e.RowIndex);
            if (recordIndex < 0) return;

            var record = sfDataGrid1.View.Records.GetItemAt(recordIndex) as ViewModel.ProcessViewModel;
            if (record == null) return;

            int processid = Convert.ToInt32(record.ProcessId);
            string timeEndString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime segmentEndTime = DateTime.Now;
            string status = "";
            TimeSpan segmentDuration = TimeSpan.Zero;


            switch (e.Column.MappingName)
            {
                // ─────────────── START ───────────────
                case "StartButton":
                    status = "START_TIME";

                    bool canStart = await PostProcessWithDictionary(processid, "Start remarks", status, "");
                    if (!canStart) return;

                    record.IsStarted = true;
                    if (record.Status == "Pause" || record.Status == "Cancelled")
                    {
                        record.IsOnHold = true;
                    }
                    record.Status = "Processing";
                    processstatus = "Processing";

                    DateTime startTime = DateTime.Now;
                    activeProcesses[processid] = startTime;

                    record.StartTime = $"Time: {startTime:HH:mm:ss} Date: {startTime:MM-dd-yyyy}";

                    _storedDuration = record.Duration;
                    //record.Duration = timeFormat.FormatDuration(record.AccumulatedDuration);

                    StartProcessTimers(record);

                    if (record.IsOnHold || record.SubProcesses.Count == 0)
                    {

                        LogSubProcess(
                            record,
                            lastSubProcess: null,
                            "Processing",
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            null,
                            TimeSpan.Zero
                        );
                    }

                    var childlastSubProcess = record.SubProcesses.LastOrDefault();
                    UpdateChildStatus(childlastSubProcess, "Processing");
                    record.IsOnHold = false;
                    record.IsEnded = false;

                    break;



                // ─────────────── HOLD ───────────────
                case "HoldButton":
                    string processName = record.Name;
                    if (record.Status == "Pause")
                    {
                        ShowCustomizeAlert.ShowMsg("Pause Process Validation.", "You already Pause the current Process. Please Start the process.", CustomeAlert.Alertype.Warning);
                        return;
                    }
                    TabFrm tabFrm = new TabFrm(this, processid, processName, lbl_mo.Text, lbl_generatedSerial.Text);
                    var _lastSubProcess = record.SubProcesses.LastOrDefault();
                    if (tabFrm.ShowDialog() == DialogResult.Yes)
                    {
                        UpdateStatus(record, true, false, false, "Cancelled");
                        UpdateChildStatus(_lastSubProcess, "Cancel");
                        activeProcesses.Remove(processid);
                    }

                    else
                    {
                        if (activeProcesses.TryGetValue(processid, out DateTime segmentStartTime))
                        {
                            segmentDuration = segmentEndTime - segmentStartTime;
                            activeProcesses.Remove(processid);
                            //record.AccumulatedDuration =  TimeSpan.FromTicks(Convert.ToDateTime(record.Duration).Ticks);
                            record.AccumulatedDuration += segmentDuration;
                        }
                        StopProcessTimersIfInactive();

                        var lastSubProcess = record.SubProcesses.LastOrDefault();
                        UpdateChildStatus(lastSubProcess, "Pause");
                        LogSubProcess(
                            record,
                            lastSubProcess,
                            "Paused: " + lbl_public_event.Text,
                            record.StartTime,
                            timeEndString,
                            segmentDuration
                        );
                        UpdateChildStatus(lastSubProcess, "Paused");
                        //record.Duration = timeFormat.FormatDuration(record.AccumulatedDuration);

                        record.StartTime = timeEndString;
                        UpdateStatus(record, true, true, true, "Pause");

                    }
                    break;



                // ─────────────── END ───────────────
                case "EndButton":
                    if (record.Status == "Pause")
                    {
                        ShowCustomizeAlert.ShowMsg("Validation Error.", "You cannot end this process because the process is on Pause. Please Start the process again.", CustomeAlert.Alertype.Warning);
                        return;
                    }
                    if (sfDataGrid2.RowCount == 0)
                    {
                        ShowCustomizeAlert.ShowMsg("Validation Error.", "Select the process first.", CustomeAlert.Alertype.Warning);
                        return;
                    }

                    if (HasUnscannedMaterial() || HasUnscannedTorque() || HasUnscannedChemical())
                    {
                        ShowCustomizeAlert.ShowMsg("Validation Error.", "You cannot end this process because one or more required items have not been scanned or torqued yet.", CustomeAlert.Alertype.Warning);
                        return;
                    }

                    if (!string.IsNullOrEmpty(Token))
                    {
                        status = "END_TIME";


                        if (activeProcesses.TryGetValue(processid, out DateTime segmentStartTime))
                        {
                            segmentDuration = segmentEndTime - segmentStartTime;
                            record.AccumulatedDuration += segmentDuration;
                            activeProcesses.Remove(processid);
                        }

                        var ChildlastSubProcess = record.SubProcesses.LastOrDefault();
                        LogSubProcess(record, ChildlastSubProcess, "Process Completed", record.StartTime, timeEndString, segmentDuration);

                        TimeSpan totalAccumulatedDuration = TimeFormat.ParseCustomDuration(record.Duration);
                        record.Duration = timeFormat.FormatDuration(totalAccumulatedDuration);
                        record.EndTime = $"Time: {segmentEndTime:HH:mm:ss} Date: {segmentEndTime:MM-dd-yyyy}";
                        UpdateStatus(record, true, false, true, "Completed");

                        UpdateChildStatus(ChildlastSubProcess, "Completed");

                        await PostProcessWithDictionary(processid, "Process Completed", status, Token);
                        StopProcessTimersIfInactive();
                    }
                    else
                    {

                        UpdateStatus(record, true, false, false, "Processing");
                        MessageBox.Show("Process End Cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;

                // ─────────────── EXPAND / COLLAPSE ───────────────
                case "ExpandCollapse":
                    record.IsExpanded = !record.IsExpanded;

                    if (record.IsExpanded)
                    {
                        sfDataGrid1.ExpandDetailsViewAt(e.RowIndex);
                        record.expandIcon = "➖";
                    }
                    else
                    {
                        sfDataGrid1.CollapseDetailsViewAt(e.RowIndex);
                        record.expandIcon = "➕";
                    }
                    break;
            }

            sfDataGrid1.Refresh();
        }



        private void UpdateStatus(ViewModel.ProcessViewModel record, bool isStarted, bool isOnHold, bool isEnded, string statusText)
        {
            record.IsStarted = isStarted;
            record.IsOnHold = isOnHold;
            record.IsEnded = isEnded;
            record.Status = statusText;
            processstatus = statusText;
        }
        private void UpdateChildStatus(ViewModel.ChildProcessViewModel record, string statusText)
        {
            record.StatusName = statusText;

        }



        private void StartProcessTimers(ViewModel.ProcessViewModel record)
        {
            if (!processTimer.Enabled)
            {
                processTimer.Start();
                isRunning = true;
            }

            if (record.CycleTime != "N/A" && int.TryParse(record.CycleTime, out int timer_duration))
            {
                process_duration_timer.Interval = timer_duration;
                process_duration_timer.Start();
            }
        }

        private void StopProcessTimersIfInactive()
        {
            if (activeProcesses.Count == 0 && processTimer.Enabled)
            {
                processTimer.Stop();
                isRunning = false;
            }
        }

        private void LogSubProcess(
    ViewModel.ProcessViewModel record,
    ViewModel.ChildProcessViewModel lastSubProcess,
    string remarks,
    string timeStart,
    string timeEnd,
    TimeSpan duration)
        {

            if (lastSubProcess != null && string.IsNullOrEmpty(lastSubProcess.TimeEnd))
            {
                var res = Convert.ToDateTime(timeEnd) - Convert.ToDateTime(lastSubProcess.TimeStart);
                lastSubProcess.TimeEnd = timeEnd;
                lastSubProcess.Remarks = remarks;
                lastSubProcess.Duration = timeFormat.FormatDuration(res);

            }
            else
            {
                record.SubProcesses.Add(new ViewModel.ChildProcessViewModel
                {
                    Id = record.SubProcesses.Count + 1,
                    ProcessId = record.ProcessId,
                    TimeStart = timeStart,
                    TimeEnd = string.IsNullOrEmpty(timeEnd) ? null : timeEnd,
                    Duration = timeFormat.FormatDuration(duration),
                    Remarks = remarks
                });
            }
        }


        private bool HasUnscannedMaterial()
        {
            return sfDataGrid2.View.Records
                .Select(r => r.Data as ViewModel.SubProcessView)
                .Any(m => m?.Serial_count == "1");
        }

        private bool HasUnscannedTorque()
        {
            return sfDataGrid2.View.Records
                .Select(r => r.Data as ViewModel.SubProcessView)
                .Any(t => t?.IsTorque == 1 && t.Torque_value == "0.00");
        }

        private bool HasUnscannedChemical()
        {
            return sfDataGrid2.View.Records
                .Select(r => r.Data as ViewModel.SubProcessView)
                .Any(c => c?.IsChemical == "1" && c.Chemical_name == string.Empty);
        }

        public async Task<bool> PostProcessWithDictionary(int processid, string remark, string status, string rfid)
        {
            try
            {
                var postData = new Dictionary<string, object>
                {
                    { "process_id", processid.ToString() },
                    { "remark", remark },
                    { "status", status },
                    { "rfid", rfid }
                };

                var (isSuccess, token) = await ApiHelper.PostTokenJsonAsync_response(Postprocess, postData, Token);

                if (!isSuccess)
                    return false;

                if (token?.Type == JTokenType.Array)
                {
                    var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    if (result?.FirstOrDefault() == null)
                    {
                        MessageBox.Show("No valid process data returned.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API Error: {ex.Message}");
                return false;
            }
        }

        private void sfDataGrid2_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {
            // --- Pre-checks (Keep these as-is) ---
            if (e.Column == null) return;

            int recordIndex = sfDataGrid2.TableControl.ResolveToRecordIndex(e.RowIndex);
            if (recordIndex < 0) return;

            var record = sfDataGrid2.View.Records.GetItemAt(recordIndex) as ViewModel.SubProcessView;
            if (record == null) return;

            // --- Default Style ---

            Color newTextColor = Color.Black;
            FontStyle newFontStyle = FontStyle.Regular;

            if (record.IsSerialized == 1 && record.Serial_count == "0" &&
                record.IsTorque == 0 && record.IsChemical == "0")
            {
                // BLUE (27, 86, 253)
                newTextColor = Color.FromArgb(27, 86, 253);
            }

            else if (record.IsTorque == 1 && record.Torque_count == "0" &&
                     record.IsSerialized == 0 && record.IsChemical == "0")
            {
                // CYAN (7, 222, 151)
                newTextColor = Color.FromArgb(7, 222, 151);
            }

            else if (record.IsChemical == "1" && record.Chemical_count == "0" &&
                     record.IsTorque == 0 && record.IsSerialized == 0)
            {

                newTextColor = Color.FromArgb(255, 128, 0);
            }

            else if (record.IsSerialized == 1 && record.Serial_count == "1" &&  // Serialized Complete
                     record.IsTorque == 1 && record.Torque_count == "1" &&    // Torque Complete
                     record.IsChemical == "1" && record.Chemical_count == "0") // Chemical Incomplete
            {
                newTextColor = Color.Teal;
            }

            else if (record.IsSerialized == 1 && record.Serial_count == "1" &&
                     record.IsTorque == 1 && record.Torque_count == "1" &&
                     record.IsChemical == "1" && record.Chemical_count != "0")
            {
                newTextColor = Color.Green;
            }

            e.Style.TextColor = newTextColor;
            e.Style.Font = new GridFontInfo(new Font("Segoe UI", 10, newFontStyle));
        }
        //i make this outside to access entire class
        //  string record; 
        string selectedName;
        int rowindex = 0;
        string processid;
        string manufacturingOrderID;
        string qty = "0";
        string tqty = "0";
        int count = 0;
        int tcount = 0;
        int iskitlist;
        string buffcount = "0";
        string bufftcount = "0";
        string _name;
        string _Sercount;
        string _chemicalname;
        Global global_DTtable = new Global();
        Color CheckColor = Color.Green;
        Color UncheckColor = Color.Gray;
        string CheckMark = "✔";
        string EmptyMark = "";
        private bool _scanS = false;
        private bool _scanT = false;
        private bool _scanChem = false;
        private async void sfDataGrid2_CellClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            if (e.DataRow == null || e.DataRow.RowType != RowType.DefaultRow)
                return;
            sfDataGrid1.SelectedIndex = 1;
            var rec = sfDataGrid2.View.Records;
            var record = e.DataRow.RowData as ViewModel.SubProcessView;
            if (record == null) return;
            selectedName = record.Name;
            rowindex = 0;
            processid = Convert.ToString(record.MaterialID);
            manufacturingOrderID = Convert.ToString(record.manufacturing_order_id);
            qty = record.Serial_qty;
            tqty = record.Torque_count;
            count = Convert.ToInt32(record.Serial_count) > 0 ? 0 : 1;
            tcount = Convert.ToInt32(record.Torque_count) > 0 ? 0 : 1;
            iskitlist = 0;
            buffcount = Convert.ToString(count);
            bufftcount = Convert.ToString(tcount);
            _Sercount = record.Serial_count;
            _chemicalname = record.Chemical_name;


            if (record.IsSerialized == 1)
            {
                _scanS = true;
            }
            else
            {
                _scanS = false;
            }
            if (record.IsTorque == 1)
            {
                _scanT = true;
            }
            else
            {
                _scanT = false;
            }
            if (record.IsChemical == "1")
            {
                _scanChem = true;
            }
            else
            {
                _scanChem = false;
            }



            if (record.IsSerialized == 1 && record.Serial_count == "1")
            {
                IsScanItem = true;

                chkIndicator1.Text = CheckMark;
                chkIndicator1.ForeColor = CheckColor;

                chkIndicator2.Text = EmptyMark;
                chkIndicator3.Text = EmptyMark;

                btn_scanserialized.ForeColor = Color.FromArgb(27, 86, 253);
                panel_material.BackColor = Color.White;

                btn_scan_torque.ForeColor = Color.White;
                panel_torque.BackColor = Color.Transparent;

                btn_scan_chemical.ForeColor = Color.White;
                panel_chemical.BackColor = Color.Transparent;
            }
            else if (record.IsTorque == 1 && record.Torque_value == "0.00")
            {
                IsScanItem = false;

                chkIndicator1.Text = EmptyMark;

                chkIndicator2.Text = CheckMark;
                chkIndicator2.ForeColor = CheckColor;

                chkIndicator3.Text = EmptyMark;

                btn_scanserialized.ForeColor = Color.White;
                panel_material.BackColor = Color.Transparent;

                btn_scan_torque.ForeColor = Color.FromArgb(7, 222, 151);
                panel_torque.BackColor = Color.White;

                btn_scan_chemical.ForeColor = Color.White;
                panel_chemical.BackColor = Color.Transparent;
            }
            else if ((record.IsChemical == "1" && record.Chemical_name == string.Empty))
            {
                _IsScanChemical = true;

                chkIndicator2.Text = EmptyMark;

                chkIndicator3.Text = CheckMark;
                chkIndicator3.ForeColor = CheckColor;


                chkIndicator1.Text = EmptyMark;

                btn_scanserialized.ForeColor = Color.White;
                panel_material.BackColor = Color.Transparent;

                btn_scan_torque.ForeColor = Color.White;
                panel_torque.BackColor = Color.Transparent;

                btn_scan_chemical.ForeColor = Color.FromArgb(255, 128, 0);
                panel_chemical.BackColor = Color.White;
            }
            else
            {
                formManager.closeAForm();
                lbl_subprocessInfo.Text = "This material is neither serialized nor requires torque.";
                return;
            }



            if (processstatus == "Pause")
            {
                string messageType = IsScanItem ? "item" : "torque/chemical";
                lbl_subprocessInfo.Text = $"Process is on Hold, cannot scan {messageType}. Please start the process and scan it again.";
                formManager.closeAForm();
                return;
            }

            if (processstatus == "Completed")
            {
                string messageType = IsScanItem ? "item" : "torque/chemical";
                lbl_subprocessInfo.Text = $"Process is Completed, cannot scan {messageType}.";
                formManager.closeAForm();
                return;
            }

            if (processstatus == "Open")
            {
                string messageType = IsScanItem ? "Item" : "torque/chemical";
                lbl_subprocessInfo.Text = $"Process is not started, cannot scan {messageType}.";
                formManager.closeAForm();
                return;
            }


            //Serialize Material
            if (IsScanItem)
            {
                if (record.IsSerialized == 0)
                {
                    lbl_subprocessInfo.Text = "This material is not serialized, cannot scan item.";
                    formManager.closeAForm();
                    return;
                }

                if (record.Serial_count != "0")
                {
                    _name = record.Name;
                    var scanner = new ProcessScanner(this, rowindex, processid, manufacturingOrderID, selectedName, lbl_generatedSerial.Text, qty, buffcount, iskitlist, tbl_subprocess);
                    formManager.OpenChildForm(scanner, sender);
                    scanner.Shown += (s, args) => scanner.txt_serialnumber.Focus();

                    scanner.ItemScanSuccess += async (serial, processid, scanned_Serial, serial_count) =>
                    {
                        global_DTtable.UpdateSerialQuantity(tbl_subprocess, Convert.ToInt32(processid), record.Name, scanned_Serial);
                        
                        var matchingRecords = sfDataGrid2.View.Records
                        .Where(r => (r.Data as ViewModel.SubProcessView)?.MaterialID == record.MaterialID).ToList();
                        foreach (var item in matchingRecords)
                        {
                            if (item.Data is ViewModel.SubProcessView s && s.MaterialID == record.MaterialID)
                            {
                                s.Serial_count = serial_count.ToString();
                            }
                        }
                        sfDataGrid2.View.GetPropertyAccessProvider().SetValue(matchingRecords, "Serial_count", serial_count);
                        sfDataGrid2.Refresh();
                       // await LoadSubProcessData(_selectedProcessID, tbl_subprocess);
                    };
                    return; // Exit after opening scanner
                }

                lbl_subprocessInfo.Text = "The item was already fully scanned.";
                formManager.closeAForm();

            }

            //Torque
            if (record.IsTorque == 1)
            {
                if (record.Torque_value == "0.00")
                {
                    var Tscanner = new scantorque(this, processid, selectedName, tqty, bufftcount, tbl_subprocess);
                    formManager.OpenChildForm(Tscanner, sender);
                    Tscanner.Shown += (s, args) => Tscanner.txt_torque.Focus();

                    Tscanner.TorqueScanSuccess += async (torqueName, torqueValue, torquemin, torquemax) =>
                    {
                        _IscanOK = true;
                        global_DTtable.UpdateTorqueQuantity(tbl_subprocess, Convert.ToInt32(processid), 1, torqueName, torqueValue);
                        //sfDataGrid2.View.GetPropertyAccessProvider().SetValue(record, "Torque_value", torqueValue);
                        //sfDataGrid2.View.GetPropertyAccessProvider().SetValue(record, "Torque", string.Format("({0}) {1}", torqueName, torqueValue));
                        //sfDataGrid2.View.Records[roid].Data.GetType().GetProperty("Torque_value").SetValue(sfDataGrid2.View.Records[roid].Data, torqueValue);
                        //sfDataGrid2.View.Records[roid].Data.GetType().GetProperty("Torque").SetValue(sfDataGrid2.View.Records[roid].Data, string.Format("({0}) {1}", torqueName, torqueValue));
                        //sfDataGrid2.Refresh();
                        await LoadSubProcessData(_selectedProcessID, tbl_subprocess);
                    };
                    return; // Exit after opening scanner
                }

                lbl_subprocessInfo.Text = "You have already scanned Torque for this Material.";
                formManager.closeAForm();

            }
            //Chemical
            if (record.IsChemical == "1" && string.IsNullOrEmpty(record.Chemical_name))
            {
                var Chemicalscanner = new ScanChemical(this, rowindex, processid, selectedName, tbl_subprocess);
                formManager.OpenChildForm(Chemicalscanner, sender);
                Chemicalscanner.Shown += (s, args) => Chemicalscanner.txt_chemical.Focus();

                Chemicalscanner.ChemicalScanSuccess += async (materialID, Cname, expiryx) =>
                {
                    _IscanOK = true;
                    global_DTtable.UpdateChemical(tbl_subprocess, Convert.ToInt32(processid), 1, Cname, expiryx);
                    await LoadSubProcessData(_selectedProcessID, tbl_subprocess);
                };
                return; // Exit after opening scanner
            }

            lbl_subprocessInfo.Text = "All required scans for this material are complete or the material requires no scanning.";
            formManager.closeAForm();


        }


        private void btn_scanserialized_Click(object sender, EventArgs e)
        {
            if (!_scanS)
            {
                lbl_subprocessInfo.Text = "This material is not serialized, cannot scan item.";
                return;
            }
            var scanner = new ProcessScanner(this, rowindex, processid, manufacturingOrderID, selectedName, lbl_generatedSerial.Text, qty, buffcount, iskitlist, tbl_subprocess);
            formManager.OpenChildForm(scanner, sender);
            if (_Sercount == "0")
            {
                scanner.Shown += (s, args) => scanner.txt_serialnumber.Enabled = false;
            }
            else
            {
                scanner.Shown += (s, args) => scanner.txt_serialnumber.Enabled = true;
            }



            scanner.ItemScanSuccess += async (serial, processid, scanned_Serial, serial_count) =>
            {
                global_DTtable.UpdateSerialQuantity(tbl_subprocess, Convert.ToInt32(processid), _name, scanned_Serial);
                await LoadSubProcessData(_selectedProcessID, tbl_subprocess);
            };
            btn_scanserialized.ForeColor = Color.FromArgb(27, 86, 253);
            panel_material.BackColor = Color.White;
            chkIndicator1.Text = CheckMark;
            chkIndicator1.ForeColor = CheckColor;

            chkIndicator2.Text = EmptyMark;
            chkIndicator3.Text = EmptyMark;


            btn_scan_torque.ForeColor = Color.White;
            panel_torque.BackColor = Color.Transparent;

            btn_scan_chemical.ForeColor = Color.White;
            panel_chemical.BackColor = Color.Transparent;
        }

        private void btn_scan_torque_Click(object sender, EventArgs e)
        {
            if (!_scanT)
            {
                lbl_subprocessInfo.Text = "This process is not require Torque.";
                return;
            }

            var Tscanner = new scantorque(this, processid, selectedName, tqty, bufftcount, tbl_subprocess);
            if (tcount == 0)
            {
                Tscanner.Shown += (s, args) => Tscanner.txt_torque.Enabled = false;
            }
            else
            {
                Tscanner.Shown += (s, args) => Tscanner.txt_torque.Enabled = true;
            }
            formManager.OpenChildForm(Tscanner, sender);
            Tscanner.Shown += (s, args) => Tscanner.txt_torque.Focus();

            Tscanner.TorqueScanSuccess += async (torqueName, torqueValue, torquemin, torquemax) =>
            {
                _IscanOK = true;
                global_DTtable.UpdateTorqueQuantity(tbl_subprocess, Convert.ToInt32(processid), 1, torqueName, torqueValue);
                await LoadSubProcessData(_selectedProcessID, tbl_subprocess);
            };
            chkIndicator1.Text = EmptyMark;

            chkIndicator2.Text = CheckMark;
            chkIndicator2.ForeColor = CheckColor;

            chkIndicator3.Text = EmptyMark;

            btn_scanserialized.ForeColor = Color.White;
            panel_material.BackColor = Color.Transparent;

            btn_scan_torque.ForeColor = Color.FromArgb(7, 222, 151);
            panel_torque.BackColor = Color.White;

            btn_scan_chemical.ForeColor = Color.White;
            panel_chemical.BackColor = Color.Transparent;
        }

        private void btn_scan_chemical_Click(object sender, EventArgs e)
        {
            if (!_scanChem)
            {
                lbl_subprocessInfo.Text = "This process is not require Chemical.";
                return;
            }
            var Chemicalscanner = new ScanChemical(this, rowindex, processid, selectedName, tbl_subprocess);
            if (_chemicalname == string.Empty)
            {
                Chemicalscanner.Shown += (s, args) => Chemicalscanner.txt_chemical.Enabled = false;
            }
            else
            {
                Chemicalscanner.Shown += (s, args) => Chemicalscanner.txt_chemical.Enabled = true;
            }
            formManager.OpenChildForm(Chemicalscanner, sender);
            Chemicalscanner.Shown += (s, args) => Chemicalscanner.txt_chemical.Focus();

            Chemicalscanner.ChemicalScanSuccess += async (materialID, Cname, expiryx) =>
            {
                _IscanOK = true;
                global_DTtable.UpdateChemical(tbl_subprocess, Convert.ToInt32(processid), 1, Cname, expiryx);
                await LoadSubProcessData(_selectedProcessID, tbl_subprocess);
            };
            chkIndicator2.Text = EmptyMark;

            chkIndicator3.Text = CheckMark;
            chkIndicator3.ForeColor = CheckColor;


            chkIndicator1.Text = EmptyMark;

            btn_scanserialized.ForeColor = Color.White;
            panel_material.BackColor = Color.Transparent;

            btn_scan_torque.ForeColor = Color.White;
            panel_torque.BackColor = Color.Transparent;

            btn_scan_chemical.ForeColor = Color.FromArgb(255, 128, 0);
            panel_chemical.BackColor = Color.White;
        }




        private void sfDataGrid2_CurrentCellActivating(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellActivatingEventArgs e)
        {

        }
        private void sfDataGrid2_CurrentCellActivated(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellActivatedEventArgs e)
        {
            if (sfDataGrid2.SelectedItem is ViewModel.SubProcessView record)
            {
                ProcessSubProcessSelection(record, sender);
            }
        }

        private void ProcessSubProcessSelection(ViewModel.SubProcessView record, object sender)
        {
            selectedName = record.Name;
            rowindex = 0;
            processid = Convert.ToString(record.MaterialID);
            manufacturingOrderID = Convert.ToString(record.manufacturing_order_id);
            qty = record.Serial_qty;
            tqty = record.Torque_count;
            count = Convert.ToInt32(record.Serial_count) > 0 ? 0 : 1;
            tcount = Convert.ToInt32(record.Torque_count) > 0 ? 0 : 1;
            iskitlist = 0;
            buffcount = Convert.ToString(count);
            bufftcount = Convert.ToString(tcount);
            _Sercount = record.Serial_count;

            if (record.IsSerialized == 1)
            {
                _scanS = true;
            }
            else
            {
                _scanS = false;
            }
            if (record.IsTorque == 1)
            {
                _scanT = true;
            }
            else
            {
                _scanT = false;
            }
            if (record.IsChemical == "1")
            {
                _scanChem = true;
            }
            else
            {
                _scanChem = false;
            }


            if (record.IsSerialized == 1 && record.Serial_count == "1")
            {
                IsScanItem = true;

                chkIndicator1.Text = CheckMark;
                chkIndicator1.ForeColor = CheckColor;

                chkIndicator2.Text = EmptyMark;
                chkIndicator3.Text = EmptyMark;

                btn_scanserialized.ForeColor = Color.FromArgb(27, 86, 253);
                panel_material.BackColor = Color.White;

                btn_scan_torque.ForeColor = Color.White;
                panel_torque.BackColor = Color.Transparent;

                btn_scan_chemical.ForeColor = Color.White;
                panel_chemical.BackColor = Color.Transparent;
            }
            else if (record.IsTorque == 1 && record.Torque_value == "0.00")
            {
                IsScanItem = false;

                chkIndicator1.Text = EmptyMark;

                chkIndicator2.Text = CheckMark;
                chkIndicator2.ForeColor = CheckColor;

                chkIndicator3.Text = EmptyMark;

                btn_scanserialized.ForeColor = Color.White;
                panel_material.BackColor = Color.Transparent;

                btn_scan_torque.ForeColor = Color.FromArgb(7, 222, 151);
                panel_torque.BackColor = Color.White;

                btn_scan_chemical.ForeColor = Color.White;
                panel_chemical.BackColor = Color.Transparent;
            }
            else if ((record.IsChemical == "1" && record.Chemical_name == string.Empty))
            {
                _IsScanChemical = true;

                chkIndicator2.Text = EmptyMark;

                chkIndicator3.Text = CheckMark;
                chkIndicator3.ForeColor = CheckColor;


                chkIndicator1.Text = EmptyMark;

                btn_scanserialized.ForeColor = Color.White;
                panel_material.BackColor = Color.Transparent;

                btn_scan_torque.ForeColor = Color.White;
                panel_torque.BackColor = Color.Transparent;

                btn_scan_chemical.ForeColor = Color.FromArgb(255, 128, 0);
                panel_chemical.BackColor = Color.White;
            }
            else
            {
                formManager.closeAForm();
                lbl_subprocessInfo.Text = "This material is neither serialized nor requires torque.";
                return;
            }



            if (processstatus == "Pause")
            {
                string messageType = IsScanItem ? "item" : "torque/chemical";
                lbl_subprocessInfo.Text = $"Process is on Hold, cannot scan {messageType}. Please start the process and scan it again.";
                formManager.closeAForm();
                return;
            }

            if (processstatus == "Completed")
            {
                string messageType = IsScanItem ? "item" : "torque/chemical";
                lbl_subprocessInfo.Text = $"Process is Completed, cannot scan {messageType}.";
                formManager.closeAForm();
                return;
            }

            if (processstatus == "Open")
            {
                string messageType = IsScanItem ? "Item" : "torque/chemical";
                lbl_subprocessInfo.Text = $"Process is not started, cannot scan {messageType}.";
                formManager.closeAForm();
                return;
            }


            //Serialize Material
            if (IsScanItem)
            {
                if (record.IsSerialized == 0)
                {
                    lbl_subprocessInfo.Text = "This material is not serialized, cannot scan item.";
                    formManager.closeAForm();
                    return;
                }

                if (record.Serial_count != "0")
                {
                    _name = record.Name;
                    var scanner = new ProcessScanner(this, rowindex, processid, manufacturingOrderID, selectedName, lbl_generatedSerial.Text, qty, buffcount, iskitlist, tbl_subprocess);
                    formManager.OpenChildForm(scanner, sender);
                    scanner.Shown += (s, args) => scanner.txt_serialnumber.Focus();

                    scanner.ItemScanSuccess += async (serial, processid, scanned_Serial, serial_count) =>
                    {
                        global_DTtable.UpdateSerialQuantity(tbl_subprocess, Convert.ToInt32(processid), record.Name, scanned_Serial);
                        await LoadSubProcessData(_selectedProcessID, tbl_subprocess);
                    };
                    return; // Exit after opening scanner
                }

                lbl_subprocessInfo.Text = "The item was already fully scanned.";
                formManager.closeAForm();

            }

            //Torque
            if (record.IsTorque == 1)
            {
                if (record.Torque_value == "0.00")
                {
                    var Tscanner = new scantorque(this, processid, selectedName, tqty, bufftcount, tbl_subprocess);
                    formManager.OpenChildForm(Tscanner, sender);
                    Tscanner.Shown += (s, args) => Tscanner.txt_torque.Focus();

                    Tscanner.TorqueScanSuccess += async (torqueName, torqueValue, torquemin, torquemax) =>
                    {
                        _IscanOK = true;
                        global_DTtable.UpdateTorqueQuantity(tbl_subprocess, Convert.ToInt32(processid), 1, torqueName, torqueValue);
                        await LoadSubProcessData(_selectedProcessID, tbl_subprocess);
                    };
                    return; // Exit after opening scanner
                }

                lbl_subprocessInfo.Text = "You have already scanned Torque for this Material.";
                formManager.closeAForm();

            }
            //Chemical
            if (record.IsChemical == "1" && string.IsNullOrEmpty(record.Chemical_name))
            {
                var Chemicalscanner = new ScanChemical(this, rowindex, processid, selectedName, tbl_subprocess);
                formManager.OpenChildForm(Chemicalscanner, sender);
                Chemicalscanner.Shown += (s, args) => Chemicalscanner.txt_chemical.Focus();

                Chemicalscanner.ChemicalScanSuccess += async (materialID, Cname, expiryx) =>
                {
                    _IscanOK = true;
                    global_DTtable.UpdateChemical(tbl_subprocess, Convert.ToInt32(processid), 1, Cname, expiryx);
                    await LoadSubProcessData(_selectedProcessID, tbl_subprocess);
                };
                return; // Exit after opening scanner
            }

            lbl_subprocessInfo.Text = "All required scans for this material are complete or the material requires no scanning.";
            formManager.closeAForm();

        }



        private void sfDataGrid2_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            //    if (sfDataGrid2.SelectedItem is ViewModel.SubProcessView record)
            //    {

            //        selectedName = record.Name;
            //        rowindex = 0;
            //        processid = Convert.ToString(record.MaterialID);
            //        manufacturingOrderID = Convert.ToString(record.manufacturing_order_id);
            //        qty = record.Serial_qty;
            //        tqty = record.Torque_count;
            //        count = Convert.ToInt32(record.Serial_count) > 0 ? 0 : 1;
            //        tcount = Convert.ToInt32(record.Torque_count) > 0 ? 0 : 1;
            //        iskitlist = 0;
            //        buffcount = Convert.ToString(count);
            //        bufftcount = Convert.ToString(tcount);
            //        _Sercount = record.Serial_count;



            //        if (record.IsSerialized == 1 && record.Serial_count == "1")
            //        {
            //            IsScanItem = true;

            //            chkIndicator1.Text = CheckMark;
            //            chkIndicator1.ForeColor = CheckColor;

            //            chkIndicator2.Text = EmptyMark;
            //            chkIndicator3.Text = EmptyMark;

            //            btn_scanserialized.ForeColor = Color.FromArgb(27, 86, 253);
            //            panel_material.BackColor = Color.White;

            //            btn_scan_torque.ForeColor = Color.White;
            //            panel_torque.BackColor = Color.Transparent;

            //            btn_scan_chemical.ForeColor = Color.White;
            //            panel_chemical.BackColor = Color.Transparent;
            //        }
            //        else if (record.IsTorque == 1 && record.Torque_value == "0.00")
            //        {
            //            IsScanItem = false;

            //            chkIndicator1.Text = EmptyMark;

            //            chkIndicator2.Text = CheckMark;
            //            chkIndicator2.ForeColor = CheckColor;

            //            chkIndicator3.Text = EmptyMark;

            //            btn_scanserialized.ForeColor = Color.White;
            //            panel_material.BackColor = Color.Transparent;

            //            btn_scan_torque.ForeColor = Color.FromArgb(7, 222, 151);
            //            panel_torque.BackColor = Color.White;

            //            btn_scan_chemical.ForeColor = Color.White;
            //            panel_chemical.BackColor = Color.Transparent;
            //        }
            //        else if ((record.IsChemical == "1" && record.Chemical_name == string.Empty))
            //        {
            //            _IsScanChemical = true;

            //            chkIndicator2.Text = EmptyMark;

            //            chkIndicator3.Text = CheckMark;
            //            chkIndicator3.ForeColor = CheckColor;


            //            chkIndicator1.Text = EmptyMark;

            //            btn_scanserialized.ForeColor = Color.White;
            //            panel_material.BackColor = Color.Transparent;

            //            btn_scan_torque.ForeColor = Color.White;
            //            panel_torque.BackColor = Color.Transparent;

            //            btn_scan_chemical.ForeColor = Color.FromArgb(255, 128, 0);
            //            panel_chemical.BackColor = Color.White;
            //        }
            //        else
            //        {
            //            formManager.closeAForm();
            //            lbl_subprocessInfo.Text = "This material is neither serialized nor requires torque.";
            //            return;
            //        }



            //        if (processstatus == "Pause")
            //        {
            //            string messageType = IsScanItem ? "item" : "torque/chemical";
            //            lbl_subprocessInfo.Text = $"Process is on Hold, cannot scan {messageType}. Please start the process and scan it again.";
            //            formManager.closeAForm();
            //            return;
            //        }

            //        if (processstatus == "Completed")
            //        {
            //            string messageType = IsScanItem ? "item" : "torque/chemical";
            //            lbl_subprocessInfo.Text = $"Process is Completed, cannot scan {messageType}.";
            //            formManager.closeAForm();
            //            return;
            //        }

            //        if (processstatus == "Open")
            //        {
            //            string messageType = IsScanItem ? "Item" : "torque/chemical";
            //            lbl_subprocessInfo.Text = $"Process is not started, cannot scan {messageType}.";
            //            formManager.closeAForm();
            //            return;
            //        }


            //        //Serialize Material
            //        if (IsScanItem)
            //        {
            //            if (record.IsSerialized == 0)
            //            {
            //                lbl_subprocessInfo.Text = "This material is not serialized, cannot scan item.";
            //                formManager.closeAForm();
            //                return;
            //            }

            //            if (record.Serial_count != "0")
            //            {
            //                _name = record.Name;
            //                var scanner = new ProcessScanner(this, rowindex, processid, manufacturingOrderID, selectedName, lbl_generatedSerial.Text, qty, buffcount, iskitlist, tbl_subprocess);
            //                formManager.OpenChildForm(scanner, sender);
            //                scanner.Shown += (s, args) => scanner.txt_serialnumber.Focus();

            //                scanner.ItemScanSuccess += async (serial, processid, scanned_Serial) =>
            //                {
            //                    global_DTtable.UpdateSerialQuantity(tbl_subprocess, Convert.ToInt32(processid), record.Name, scanned_Serial);
            //                    await LoadSubProcessData(_selectedProcessID, tbl_subprocess);
            //                };
            //                return; // Exit after opening scanner
            //            }

            //            lbl_subprocessInfo.Text = "The item was already fully scanned.";
            //            formManager.closeAForm();

            //        }

            //        //Torque
            //        if (record.IsTorque == 1)
            //        {
            //            if (record.Torque_value == "0.00")
            //            {
            //                var Tscanner = new scantorque(this, processid, selectedName, tqty, bufftcount);
            //                formManager.OpenChildForm(Tscanner, sender);
            //                Tscanner.Shown += (s, args) => Tscanner.txt_torque.Focus();

            //                Tscanner.TorqueScanSuccess += async (torqueName, torqueValue, torquemin, torquemax) =>
            //                {
            //                    _IscanOK = true;
            //                    global_DTtable.UpdateTorqueQuantity(tbl_subprocess, Convert.ToInt32(processid), 1, torqueName, torqueValue);
            //                    await LoadSubProcessData(_selectedProcessID, tbl_subprocess);
            //                };
            //                return; // Exit after opening scanner
            //            }

            //            lbl_subprocessInfo.Text = "You have already scanned Torque for this Material.";
            //            formManager.closeAForm();

            //        }
            //        //Chemical
            //        if (record.IsChemical == "1" && string.IsNullOrEmpty(record.Chemical_name))
            //        {
            //            var Chemicalscanner = new ScanChemical(this, rowindex, processid, selectedName, tbl_subprocess);
            //            formManager.OpenChildForm(Chemicalscanner, sender);
            //            Chemicalscanner.Shown += (s, args) => Chemicalscanner.txt_chemical.Focus();

            //            Chemicalscanner.ChemicalScanSuccess += async (materialID, Cname, expiryx) =>
            //            {
            //                _IscanOK = true;
            //                global_DTtable.UpdateChemical(tbl_subprocess, Convert.ToInt32(processid), 1, Cname, expiryx);
            //                await LoadSubProcessData(_selectedProcessID, tbl_subprocess);
            //            };
            //            return; // Exit after opening scanner
            //        }

            //        lbl_subprocessInfo.Text = "All required scans for this material are complete or the material requires no scanning.";
            //        formManager.closeAForm();

            //    }

        }


        private void btn_chemical_Click(object sender, EventArgs e)
        {
            _IsScanChemical = true;
        }
        private async void ProcessFrm_Shown(object sender, EventArgs e)
        {
            this.Opacity = 0;
            fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = 30;
            fadeTimer.Tick += FadeIn;
            fadeTimer.Start();
        }
        private void FadeIn(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.05;
            }
            else
            {
                fadeTimer.Stop();
            }
        }



        private void process_duration_timer_Tick(object sender, EventArgs e)
        {
            new ToastForm("Attention! You have exceeded the process time duration.").Show();
        }

        private void btn_qcChecklist_Click(object sender, EventArgs e)
        {
            var qcform = new QC_Checklist_QR(lbl_generatedSerial.Text, _segmentID);
            qcform.ShowDialog();
        }

        private void timer_duration_Tick(object sender, EventArgs e)
        {
            if (sfDataGrid1.InvokeRequired)
            {
                sfDataGrid1.Invoke(new Action(() => timer_duration_Tick(sender, e)));
                return;
            }
            if (sfDataGrid1.View == null || sfDataGrid1.View.Records == null)
            {
                return;
            }


            TimeSpan accumulatedTimeBase = TimeFormat.ParseCustomDuration(_storedDuration);
            // TimeSpan accumulatedChildTimeBase = TimeFormat.ParseCustomDuration(_storedChildDuration);

            foreach (var record in sfDataGrid1.View.Records.Select(r => r.Data as ViewModel.ProcessViewModel))
            {
                if (record == null) continue;

                if (activeProcesses.TryGetValue(Convert.ToInt32(record.ProcessId), out DateTime currentStartTime))
                {
                    TimeSpan currentSegmentDuration = DateTime.Now - currentStartTime;

                    TimeSpan totalRunningDuration = accumulatedTimeBase + currentSegmentDuration;



                    string durationDisplay = timeFormat.FormatDuration(totalRunningDuration);
                    record.Duration = durationDisplay;

                    foreach (var child in record.SubProcesses)
                    {
                        if (child.StatusName == "Processing")
                        {
                            TimeSpan childtDuration = DateTime.Now - Convert.ToDateTime(child.TimeStart);
                            child.Duration = timeFormat.FormatDuration(childtDuration);
                        }
                    }
                    durationUpdated = true;
                }
            }


            if (durationUpdated)
            {
                sfDataGrid1.Refresh();
            }
        }
    }
}
