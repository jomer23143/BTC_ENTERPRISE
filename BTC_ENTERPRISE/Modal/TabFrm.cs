using BTC_ENTERPRISE.Class;
using BTC_ENTERPRISE.YaoUI;

namespace BTC_ENTERPRISE.Modal
{
    public partial class TabFrm : Form
    {
        private FormManager formManager;
        private int processid;
        private string processName;
        private string moid;
        private string generatedSerial;
        private ProcessFrm _processFrm;
        public TabFrm(ProcessFrm processFrm, int processid, string processName, string moid, string generatedSerial)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            formManager = new FormManager(panel_top, panel_main);
            YUI yUI = new YUI();
            yUI.RoundedButton(btn_cancel, 12, Color.Tomato);
            yUI.RoundedButton(btn_break, 12, Color.FromArgb(37, 45, 55));
            yUI.RoundedButton(btn_abi, 12, Color.FromArgb(37, 45, 55));
            yUI.RoundedFormsDocker(this, 8);

            this.processid = processid; // Store the process ID for later use
            this.processName = processName;
            this.moid = moid;
            this.generatedSerial = generatedSerial;
            this._processFrm = processFrm;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (btn_cancel.Text == "Submit")
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();

            }
            else if (btn_cancel.Text == "Cancel")
            {
                DialogResult = DialogResult.Yes;
                this.Close();
            }

        }

        private void btn_break_Click(object sender, EventArgs e)
        {
            formManager.OpenChildForm(new Settingsfrm.Breakfrm(this, _processFrm, processid), sender);
        }

        private void btn_abi_Click(object sender, EventArgs e)
        {
           //formManager.OpenChildForm(new ABIFrm(processid, moid, generatedSerial, processName), sender);
        }

        private void TabFrm_Load(object sender, EventArgs e)
        {
            formManager.ActivateButton(btn_break);
            formManager.OpenChildForm(new Settingsfrm.Breakfrm(this, _processFrm, processid), btn_break);
        }
    }
}
