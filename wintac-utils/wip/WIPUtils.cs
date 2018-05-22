using InfluxClient;
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

namespace wintac_utils.wip
{
    class WIPUtils
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //protected static DateTime start = new DateTime(2018, 4, 1);
        //protected static DateTime end = new DateTime(2018, 5, 31);
        protected static DateTime start = new DateTime(2010, 1, 1);
        protected static DateTime end = DateTime.Now;

        public static void insertAllStats()
        {
            String message = "Inserting all stats from " + start + " to " + end;
            log.Info(message);
            MessageBox.Show(message);

            InfluxdbClient.dropDB();
            InfluxdbClient.createDB();

            insertInvoiceStats();
            log.Info("Finished invoices.");
            insertWorkOrderStats();
            log.Info("Finished wo.");
            insertProposalStats();
            log.Info("Finished props.");
            insertPurchaseOrders();
            log.Info("Finished po.");
            insertPayrollStats();
            log.Info("Finished pay.");
        }

        public static void getOutStandingWorkOrders()
        {
            MainApp.GetDBConnection().getOutStandingWorkOrders(start, end);
        }

        public static void insertPayrollStats()
        {
            DataTable dt = MainApp.GetDBConnection().getPayrollDataTable(start, end);
            updateWIPStats(dt, InfluxdbClient.COL.CHKDATE.ToString(), InfluxdbClient.PAY_FIELDS, InfluxdbClient.MEASUREMENT.PAY.ToString());
        }

        public static void insertProposalStats()
        {
            DataTable dt = MainApp.GetDBConnection().getProposals(start, end);
            updateWIPStats(dt, InfluxdbClient.COL.JDATE.ToString(), InfluxdbClient.WIP_FIELDS, InfluxdbClient.MEASUREMENT.PROP.ToString());
        }

        public static void insertPurchaseOrders()
        {
            DataTable dt = MainApp.GetDBConnection().getPurchaseOrders(start, end);
            updateWIPStats(dt, InfluxdbClient.COL.JDATE.ToString(), InfluxdbClient.WIP_FIELDS, InfluxdbClient.MEASUREMENT.PO.ToString());
        }

        public static void insertInvoiceStats()
        {
            DataTable dt = MainApp.GetDBConnection().getInvoices(start, end);
            updateWIPStats(dt, InfluxdbClient.COL.JDATE.ToString(), InfluxdbClient.WIP_FIELDS, InfluxdbClient.MEASUREMENT.INV.ToString());
        }

        public static void insertWorkOrderStats()
        {
            DataTable dt = MainApp.GetDBConnection().getOutStandingWorkOrders(start, end);
            updateWIPStats(dt, InfluxdbClient.COL.JDATE.ToString(), InfluxdbClient.WIP_FIELDS, InfluxdbClient.MEASUREMENT.WO.ToString());
        }

        protected static void updateWIPStats(DataTable dataTable, String dateColumn, List<String> fieldColumns, String measurement)
        {
            List<Measurement> measurements = new List<Measurement>();
            DateTime timestamp = DateTime.Now;

            // Create Measurement per row
            foreach (DataRow row in dataTable.Rows)
            {
                Dictionary<string, object> fields = new Dictionary<string, object>();
                Dictionary<string, string> tags = new Dictionary<string, string>();
                foreach (DataColumn dc in dataTable.Columns)
                {
                    if (isField(fieldColumns, dc.ColumnName))
                        fields.Add(dc.ColumnName.ToString(), Convert.ToSingle(row[dc.ColumnName.ToString()]));
                    else
                        tags.Add(dc.ColumnName.ToString(), row[dc.ColumnName].ToString());
                }

                String convDate = row[dateColumn].ToString();
                if (!String.IsNullOrEmpty(convDate) && !String.IsNullOrWhiteSpace(convDate))
                    timestamp = Convert.ToDateTime(convDate);

                measurements.Add(InfluxdbClient.buildMeasurement(measurement, fields, tags, timestamp));
            }

            // Bulk write out the stats
            InfluxdbClient.WriteBulkMeasurements(measurements);
        }

        protected static bool isField(List<String> fieldList, String columnName)
        {
            foreach (String fieldName in fieldList)
            {
                if (columnName == fieldName)
                    return true;
            }
            return false;
        }
    }
}
