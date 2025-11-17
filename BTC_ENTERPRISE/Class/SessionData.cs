using BTC_ENTERPRISE.Model;
using System.Data;

namespace BTC_ENTERPRISE.Class
{
    public static class SessionData
    {
        public static DataTable TempData { get; private set; }
        public static DataTable TempDataLicense { get; private set; }
        public static DataTable tbl_process_Session { get; set; }
        public static DataTable tbl_subprocess_Session { get; set; }

        static SessionData()
        {
            TempData = new DataTable();
            TempData.Columns.Add("id", typeof(string));
            TempData.Columns.Add("FullName", typeof(string));
            TempData.Columns.Add("Position", typeof(string));
            TempData.Columns.Add("Token", typeof(string));


            TempDataLicense = new DataTable();
            TempDataLicense.Columns.Add("id", typeof(int));
            TempDataLicense.Columns.Add("name", typeof(string));
            TempDataLicense.Columns.Add("license_no", typeof(string));
            TempDataLicense.Columns.Add("product_id", typeof(int));
            TempDataLicense.Columns.Add("product_name", typeof(string));
            TempDataLicense.Columns.Add("expiry_date", typeof(string));


         
                tbl_process_Session = new DataTable();
                tbl_process_Session.Columns.Add("id", typeof(int));
                tbl_process_Session.Columns.Add("name", typeof(string));
                tbl_process_Session.Columns.Add("cycle_time", typeof(string));
                tbl_process_Session.Columns.Add("manufacturing_order_process_type_id", typeof(string));
                tbl_process_Session.Columns.Add("start_time", typeof(string));
                tbl_process_Session.Columns.Add("end_time", typeof(string));
                tbl_process_Session.Columns.Add("status", typeof(string));
                tbl_process_Session.Columns.Add("is_hold", typeof(int));
                tbl_process_Session.Columns.Add("color", typeof(string));
                tbl_process_Session.Columns.Add("remark", typeof(string));

                tbl_process_Session.Columns.Add("DurationRecords", typeof(List<Sub_Asy_Process_Model.Duration>));



                tbl_subprocess_Session = new DataTable();
                tbl_subprocess_Session.Columns.Add("id", typeof(int));
                tbl_subprocess_Session.Columns.Add("manufacturing_order_process_id", typeof(int));
                tbl_subprocess_Session.Columns.Add("description", typeof(string));
                tbl_subprocess_Session.Columns.Add("ipn_number", typeof(string));
                tbl_subprocess_Session.Columns.Add("serial_number", typeof(string));
                tbl_subprocess_Session.Columns.Add("serial_quantity", typeof(int));
                tbl_subprocess_Session.Columns.Add("serial_count", typeof(int));
                tbl_subprocess_Session.Columns.Add("is_kit_list", typeof(int));
                tbl_subprocess_Session.Columns.Add("is_serial", typeof(int));
                tbl_subprocess_Session.Columns.Add("is_torque", typeof(int));
                tbl_subprocess_Session.Columns.Add("torque_count", typeof(string));
                tbl_subprocess_Session.Columns.Add("min", typeof(string));
                tbl_subprocess_Session.Columns.Add("max", typeof(string));
                tbl_subprocess_Session.Columns.Add("value", typeof(string));
                tbl_subprocess_Session.Columns.Add("torque_name", typeof(string));
                tbl_subprocess_Session.Columns.Add("is_chemical", typeof(string));
                tbl_subprocess_Session.Columns.Add("chemical_name", typeof(string));
                tbl_subprocess_Session.Columns.Add("chemical_count", typeof(string));
                tbl_subprocess_Session.Columns.Add("chemical_expiration", typeof(string));

        }
    }
}
