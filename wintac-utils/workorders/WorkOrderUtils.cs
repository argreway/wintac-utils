using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wintac_utils.dbconnect;
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
            DateTime start = new DateTime(2017, 12, 1);
            DateTime end = new DateTime(2018, 3, 31);

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
                        MessageBox.Show("End: " + itrEnd.ToString("yyyy MM dd"));

                        DataTable dt = MainApp.GetDBConnection().getOutStandingWorkOrders(itrStart, itrEnd);
                        updateStats(dt);

                        currentMonth++;
                    }
                    currentYear++;
                    currentMonth = 1;
                }
            }
            else
            {
                DataTable dt = MainApp.GetDBConnection().getOutStandingWorkOrders(start, end);
                updateStats(dt);
            }
        }

        protected static void updateStats(DataTable dataTable)
        {
            HashSet<String> techs = new HashSet<string>();

            foreach (DataColumn dc in dataTable.Columns)
            {
                String name = dc.ColumnName;
            }
            foreach (DataRow row in dataTable.Rows)
            {
                String val = row["TECH"].ToString();
                techs.Add(val);

            }
            string[] array2 = techs.ToArray();

            MessageBox.Show("techs: " + string.Join(", ", array2));
            MessageBox.Show("Found: " + dataTable.Rows.Count);
        }
    }
}
