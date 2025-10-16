using BTC_ENTERPRISE;
using Utility.ModifyRegistry;
using Frameworks.Utilities.Registry;

namespace BTC_ENTERPRISE.Settings
{
    public partial class createConnection : Form
    {
        public createConnection()
        {
            InitializeComponent();
        }

        private void createConnection_Load(object sender, EventArgs e)
        {
            LoadData();
            Utils.SetConnectionDetails();
        }

        private void SaveData()
        {
            String data = "";
            foreach (DataGridViewRow row in programsGrid.Rows)
            {
                // Ignore last row
                if (row.Index == programsGrid.Rows.Count - 1)
                    break;

                // Ensure cells are not null before accessing their values
                String name = row.Cells["gridcolname"]?.Value?.ToString() ?? string.Empty;
                String server = row.Cells["gridcolserver"]?.Value?.ToString() ?? string.Empty;
                String user = row.Cells["gridcoluser"]?.Value?.ToString() ?? string.Empty;
                String password = row.Cells["gridcolpassword"]?.Value?.ToString() ?? string.Empty;
                String dbname = row.Cells["gridcoldbname"]?.Value?.ToString() ?? string.Empty;
                String segment_name = row.Cells[colsegment.Name]?.Value?.ToString() ?? string.Empty;
                String segment_code = row.Cells[colsegmentcode.Name]?.Value?.ToString() ?? string.Empty;

                data += String.Format("{0}<limiter>{1}<limiter>{2}<limiter>{3}<limiter>{4}<limiter>{5}<limiter>{6}<limiter1>", name, server, user, password, dbname,segment_name,segment_code);
            }
            RegistrySupport registry = new RegistrySupport();
            if (registry.Write(Def.REGKEY_SUB, data))
            {
                MessageBox.Show("Settings Saved");
                Close();
            }
        }
        private void LoadData()
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
                    programsGrid.Rows.Add(records);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            // Class.SqlCon.connections(EngineLevelTesting.Connection.GetConnectionStringReg);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (programsGrid.Rows.Count != 1)
            {
                SaveData();
                Utils.SetConnectionDetails();
            }
        }

        private void programsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            programsGrid.Rows[e.RowIndex].Tag = e.Value;
            if (programsGrid.Columns[e.ColumnIndex].Name == "gridcolpassword" && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }

        }
    }
}
