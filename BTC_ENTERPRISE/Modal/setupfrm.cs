using BTC_ENTERPRISE;
using BTC_ENTERPRISE.Forms;
using BTC_ENTERPRISE.YaoUI;

namespace BTC_ENTERPRISE.Modal
{
    public partial class setupfrm : Form
    {
        private readonly MainDashboard _mainDashboard;
        public setupfrm(MainDashboard mainDashboard)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            YUI yUI = new YUI();
            yUI.RoundedFormsDocker(this, 10);
            yUI.RoundedButton(btn_save, 6, Color.FromArgb(17, 40, 86));
            _mainDashboard = mainDashboard;
        }


        private void LoadData()
        {
            try
            {
                Utility.ModifyRegistry.RegistrySupport registry = new Utility.ModifyRegistry.RegistrySupport();
                String data = registry.Read(Frameworks.Utilities.Registry.Def.REGKEY_SUB);
                if (data == null)
                {
                    data += String.Format($"BTC_ENTERPRISE<limiter>192.168.20.15<limiter>sa<limiter>MISys_SBM1<limiter>BROADBAND<limiter>Warehouse Kitting<limiter>101<limiter1>");
                    registry.Write(Frameworks.Utilities.Registry.Def.REGKEY_SUB, data);
                }
                String[] programs = data.Split(new String[] { "<limiter1>" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String program in programs)
                {
                    String[] records = program.Split(new String[] { "<limiter>" }, StringSplitOptions.RemoveEmptyEntries);
                    //setup_grid.Rows.Add(records);
                    if (records.Length >= 3)
                    {
                        cmb_name.Text = records[5].Trim();
                        lbl_code.Text = records[6].Trim();

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

        private void setupfrm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            String data = "";

            String sectname = cmb_name.Text.Trim();
            String sectCode = lbl_code.Text.Trim();
            //String projectName = "BTC_ENTERPRISE";
            if (sectname.Length == 0 || sectCode.Length == 0)
            {
                MessageBox.Show("Please enter a valid section name and code.");
                return;
            }
            data += String.Format($"BTC_ENTERPRISE<limiter>192.168.20.15<limiter>sa<limiter>MISys_SBM1<limiter>BROADBAND<limiter>{sectname}<limiter>{sectCode}<limiter1>");

            Utility.ModifyRegistry.RegistrySupport registry = new Utility.ModifyRegistry.RegistrySupport();
            if (registry.Write(Frameworks.Utilities.Registry.Def.REGKEY_SUB, data))
            {
                Close();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_name.SelectedItem is CodeItem selectedItem)
            {
                string selectedCode = selectedItem.Code;
                string sectionName = selectedItem.Name;

                lbl_code.Text = selectedCode;
                _mainDashboard.lbl_departmemnt.Text = sectionName;
            }
        }
        public class CodeItem
        {
            public string Code { get; set; }
            public string Name { get; set; }
        }
        public readonly Dictionary<string, string> CodeNameMap = new Dictionary<string, string>
        {
            { "101", "Warehouse Kitting" },
            { "102", "Kitlist Receiving" },
            { "1", "Sub-Assembly" },
            { "2", "Pre-Assembly" },
            { "3", "Rain Test" },
            { "4", "Main Assembly" },
            { "5", "In-Station QC" },
            { "6", "EQL Test" },
            { "7", "Final Assembly" },
            { "8", "Final QC" },
            { "9", "Packing" }
        };
        private void cmb_code_Click(object sender, EventArgs e)
        {

            var items = CodeNameMap.Select(pair => new CodeItem
            {
                Code = pair.Key,
                Name = pair.Value
            }).ToList();

            cmb_name.DataSource = items;
            cmb_name.DisplayMember = "name";
            cmb_name.ValueMember = "code";
        }
    }
}