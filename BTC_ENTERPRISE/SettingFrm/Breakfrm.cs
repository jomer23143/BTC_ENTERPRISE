﻿using System.Diagnostics;
using BTC_ENTERPRISE.Class;
using BTC_ENTERPRISE.Modal;
using BTC_ENTERPRISE.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Frameworks.Utilities.ApiUtilities;

namespace BTC_ENTERPRISE.Settingsfrm
{
    public partial class Breakfrm : Form
    {
        private TabFrm _tabForm;
        private ProcessFrm _processFrm;
        private int processid = 0; // Assuming you will set this value appropriately before calling PostProcessWithDictionary
        private string Postprocess = GlobalApi.GetPostProcessUrl();
        public Breakfrm(TabFrm tabForm, ProcessFrm processFrm, int Pid)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            _tabForm = tabForm; //store Reference
            _processFrm = processFrm;
            this.processid = Pid;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            _tabForm.btn_cancel.Text = "Submit";
            _tabForm.btn_cancel.BackColor = Color.DodgerBlue;
            var status = "PAUSE_TIME";
            var remark = button1.Text;
            _processFrm.lbl_public_event.Text = button1.Text;
            await PostProcessWithDictionary(processid, remark, status);

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            _tabForm.btn_cancel.Text = "Submit";
            _tabForm.btn_cancel.BackColor = Color.DodgerBlue;
            _processFrm.lbl_public_event.Text = button2.Text;
            var status = "PAUSE_TIME";
            var remark = button2.Text;
            await PostProcessWithDictionary(processid, remark, status);

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            _tabForm.btn_cancel.Text = "Submit";
            _tabForm.btn_cancel.BackColor = Color.DodgerBlue;
            var status = "PAUSE_TIME";
            var remark = button3.Text;
            _processFrm.lbl_public_event.Text = button3.Text;
            await PostProcessWithDictionary(processid, remark, status);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            _tabForm.btn_cancel.Text = "Cancel";
            _tabForm.btn_cancel.BackColor = Color.Tomato;
        }

        public async Task PostProcessWithDictionary(int processid, string remark, string status)
        {
            try
            {
                var temprfid = "";
                Dictionary<string,object> postData = new Dictionary<string, object>
                {
                     { "process_id", processid},
                    { "remarks", remark },
                    { "status", status.Trim() },
                    { "employee_rfid", temprfid.Trim() }
                };

                var token = await ApiHelper.PostJsonAsync(Postprocess, postData, Global.UserToken);
                if (token == null) return;

                if (token.Type == JTokenType.Array)
                {
                    var result = token.ToObject<List<Sub_Asy_Process_Model.Root>>();
                    var data = result?.FirstOrDefault();
                    if (data == null)
                    {
                        MessageBox.Show("No valid process data returned.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                }
                else
                {
                    //   MessageBox.Show("Unexpected response format.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
