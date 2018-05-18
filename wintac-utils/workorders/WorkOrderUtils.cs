using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wintac_utils.dbconnect;
using wintac_utils.influxdb;
using wintac_utils.main;

namespace wintac_utils.workorders
{
    class WorkOrderUtils
    {

        public static void getOutStandingWorkOrders()
        {
            DateTime start = new DateTime(2018, 3, 1);
            DateTime end = new DateTime(2018, 3, 31);

            MainApp.GetDBConnection().getOutStandingWorkOrders(start, end);
        }

        public static void calculateOutstandingPerTech()
        {
            //DateTime start = new DateTime(2018, 4, 1);
            DateTime start = new DateTime(2016, 1, 1);
            DateTime end = new DateTime(2018, 5, 31);

            if (start.Month != end.Month)
            {
                int currentMonth = start.Month;
                int currentYear = start.Year;
                int endMonth = end.Month;

                while (currentYear <= end.Year)
                {
                    if (currentYear != end.Year)
                        endMonth = 12;
                    else
                        endMonth = end.Month;

                    while (currentMonth <= endMonth)
                    {
                        DateTime itrEnd = new DateTime(currentYear, currentMonth, DateTime.DaysInMonth(currentYear, currentMonth));
                        DateTime itrStart = new DateTime(currentYear, currentMonth, 1);

                        DataTable dt = MainApp.GetDBConnection().getOutStandingWorkOrders(itrStart, itrEnd);
                        updateStats(itrEnd, dt);

                        currentMonth++;
                    }
                    currentYear++;
                    currentMonth = 1;
                }
            }
            else
            {
                DataTable dt = MainApp.GetDBConnection().getOutStandingWorkOrders(start, end);
                updateStats(end, dt);
            }
        }

        protected static void updateStats(DateTime date, DataTable dataTable)
        {
            DateTime now = DateTime.Now;
            HashSet<String> techs = new HashSet<string>();
            Dictionary<string, int> outstandingMap = new Dictionary<string, int>();

            foreach (DataRow row in dataTable.Rows)
            {
                String tech = row["TECH"].ToString();
                techs.Add(tech);
                if (outstandingMap.ContainsKey(tech))
                    outstandingMap[tech]++;
                else
                    outstandingMap.Add(tech, 1);

                //if (now.Month == date.Month && now.Year == date.Year)
                if (now.Year == date.Year)
                {
                    // Submit the work orders per tech
                    Dictionary<string, int> fields = new Dictionary<string, int>();
                    Dictionary<string, string> tags = new Dictionary<string, string>();
                    fields.Add("value", date.Month);
                    foreach (DataColumn dc in dataTable.Columns)
                    {
                        tags.Add(dc.ColumnName.ToString(), row[dc.ColumnName].ToString());
                    }

                    InfluxdbClient.WriteStat(InfluxdbClient.MEASUREMENT.DETAILS.ToString() + "." + date.Year + "." + date.Month, fields, tags);
                }
            }
            string[] array2 = techs.ToArray();

            string print = "Total Found: " + dataTable.Rows.Count + "\n";
            print += "Month End: " + date.ToString("yyyy MM dd") + "\n\n";
            print += "Per Tech: \n";
            foreach (KeyValuePair<string, int> item in outstandingMap)
            {
                print += " -> " + item.Key + " : " + item.Value + "\n";
                Dictionary<string, int> fields = new Dictionary<string, int>();
                Dictionary<string, string> tags = new Dictionary<string, string>();

                tags.Add(InfluxdbClient.WO.TECH.ToString(), item.Key);
                fields.Add(InfluxdbClient.WO.OUTSTANDING.ToString(), item.Value);

                InfluxdbClient.WriteStat(InfluxdbClient.MEASUREMENT.WO.ToString() + "." + date.Year + "." + date.Month, fields, tags);
            }
            //MessageBox.Show(print);
        }
    }
}
