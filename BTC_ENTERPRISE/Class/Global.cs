using System.Data;

namespace BTC_ENTERPRISE.Class
{
    public class Global
    {

        public static string UserToken = "";
        public static List<license>? dt_license { get; set; }
        public class license
        {
            public int id { get; set; }
            public int employee_id { get; set; }
            public int license_id { get; set; }
            public string? license_name { get; set; }
            public string? license_no { get; set; }
            public int license_type_id { get; set; }
            public string? license_type_name { get; set; }

        }
        public static string process_name { get; set; }
        public static int process_id { get; set; }


        public void UpdateSerialQuantity(DataTable subprocess, int materialID, string description, string newserialnumber)
        {
            foreach (System.Data.DataRow row in subprocess.Rows)
            {
                int currentId = Convert.ToInt32(row["id"]);
                string currentDescription = row["description"]?.ToString() ?? string.Empty;

                if (currentId == materialID)
                {
                    if (currentDescription.Equals(description, StringComparison.OrdinalIgnoreCase))
                    {
                        int currentSerialCount = row["serial_count"] == DBNull.Value ?
                                                 Convert.ToInt32(row["serial_quantity"]) :
                                                 Convert.ToInt32(row["serial_count"]);

                        int newCount = currentSerialCount - 1;

                        if (newCount < 0)
                        {
                            newCount = 0;
                        }

                        row["serial_number"] = newserialnumber;
                        row["serial_count"] = newCount;

                    }
                }
            }
        }
        public void UpdateTorqueQuantity(DataTable subprocess, int materialID, int newQuantity, string Tname, string Tvalue)
        {
            foreach (System.Data.DataRow row in subprocess.Rows)
            {
                if (Convert.ToInt32(row["id"]) == materialID && row["torque_name"].ToString() == Tname)
                {
                    row["torque_count"] = newQuantity;
                    row["value"] = Tvalue;
                    break;
                }
            }
        }

        public void UpdateChemical(DataTable subprocess, int materialID, int newQuantity, string Cname, string Cexp)
        {
            foreach (System.Data.DataRow row in subprocess.Rows)
            {
                int currentId = Convert.ToInt32(row["id"]);
                string currentChemical = row["chemical_name"]?.ToString() ?? string.Empty;

                if (currentId == materialID)
                {
                    if (currentChemical.Equals(Cname, StringComparison.OrdinalIgnoreCase))
                    {
                        row["chemical_count"] = newQuantity;
                        row["chemical_name"] = Cname;
                        row["chemical_expiration"] = Cexp;
                        break;

                    }
                }


            }
        }


    }
}
