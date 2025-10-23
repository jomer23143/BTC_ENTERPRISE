using BTC_ENTERPRISE.Class;
using BTC_ENTERPRISE.Forms;

namespace BTC_ENTERPRISE.YaoUI
{
    public static class UIControls
    {

        public static void SetupUI(MainDashboard form, EventHandler settingHandler, EventHandler logoutHandler, EventHandler loginHandler)
        {
            //   form.FormBorderStyle = FormBorderStyle.None;  // temporary disabled for testing porpuse
            form.StartPosition = FormStartPosition.CenterScreen;
            form.WindowState = FormWindowState.Maximized;

            form.lbl_time.TextAlign = ContentAlignment.MiddleCenter;
            form.lbl_currentdate.TextAlign = ContentAlignment.MiddleCenter;


            form.timer1.Tick += (sender, args) =>

            {
                form.lbl_time.Text = DateTime.Now.ToString("hh:mm:ss tt");
                form.lbl_currentdate.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy");
            };
            form.timer1.Start();

            var contextMenu = new ContextMenuStrip();

            // Create "Settings" menu item
            var settingsItem = new ToolStripMenuItem("Settings", null, settingHandler)
            {
                BackColor = Color.LightBlue,
                ForeColor = Color.Black
            };

            // Create "Logout" menu item
            var logoutItem = new ToolStripMenuItem("Logout", null, logoutHandler)
            {
                BackColor = Color.Red,
                ForeColor = Color.White
            };
            var loginItem = new ToolStripMenuItem("Login", null, loginHandler)
            {
                BackColor = Color.Green,
                ForeColor = Color.White
            };
            // Add items to context menu
            contextMenu.Items.Add(settingsItem);
            contextMenu.Items.Add(logoutItem);
            contextMenu.Items.Add(loginItem);
            if (Global.UserToken != "")
            {
                if (MainDashboardV1.processType == "101" || MainDashboardV1.processType == "102")
                {
                    loginItem.Visible = false;
                    logoutItem.Visible = false;
                }
                else
                {
                    loginItem.Visible = false;
                    logoutItem.Visible = true;
                }
            }
            else
            {
                if (MainDashboardV1.processType == "101" || MainDashboardV1.processType == "102")
                {
                    loginItem.Visible = false;
                    logoutItem.Visible = false;
                }
                else
                {
                    loginItem.Visible = true;
                    logoutItem.Visible = false;
                }
            }

            // Show the context menu when the settings image is clicked.
            form.settingimage.Click += (sender, args) =>
            {
                contextMenu.Show(form.settingimage, new Point(0, form.settingimage.Height));
            };

            var yui = new YUI();

        }



    }
}
