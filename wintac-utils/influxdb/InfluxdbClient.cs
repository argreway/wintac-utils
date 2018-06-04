using InfluxClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wintac_utils.influxdb
{
    class InfluxdbClient
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public enum MEASUREMENT
        {
            WO,
            INV,
            PO,
            PROP,
            PAY,
            AR
        }

        public enum COL
        {
            TECH,
            JDATE,
            INVDATE,
            CHKDATE
        }

        public static List<String> WIP_FIELDS = new List<String> { "SUBTOTAL", "TOTTAX", "TOTTAX2", "MAT", "LAB", "MATC", "LABC" };
        public static List<String> AR_FIELDS = new List<String> { "SUBTOTAL", "TOTTAX", "TOTTAX2", "MAT", "LAB", "MATC", "LABC",
            "BALANCE","RECEIPTS_PAID_AMOUNT" };
        public static List<String> PAY_FIELDS = new List<String> { "NHOURS ", "OHOURS ", "SHOURS ", "VHOURS ", "HOURS5 ", "HOURS6 ",
            "HOURS7 ", "HOURS8 ", "HOURS9 ", "HOURS10 ", "GROSS" , "TIPS ", "FED_WH ", "ST_WH ", "LOC_WH ", "SOC ", "MED ", "BEN ",
            "ATSAV ", "BTSAV ", "REIMB ", "MISC1 ", "DED5 ", "DED6 ", "DED7 ", "DED8 ", "DED9 ", "DED10 ", "SDI ", "FLI ", "SUI" };

        protected static String INFLUX_DB_URL = "http://192.168.1.30:8086";
        protected static String INFLUX_DB = "sentry_stats_time";
        protected static InfluxManager manager = new InfluxManager(INFLUX_DB_URL, INFLUX_DB);

        private static readonly HttpClient client = new HttpClient();

        private static Dictionary<string, string> values = new Dictionary<string, string>
        {
             { "t", "v" },
             { "t2", "v2" }
        };

        private static int dropRetries = 0;
        public static void dropDB()
        {
            Task<HttpResponseMessage> response;
            Task<String> responseString;

            if (dropRetries % 5 == 0)
            {
                log.Info("Dropping influxdb " + INFLUX_DB);
                manager.Query("drop database " + INFLUX_DB);
            }
            else
            {
                log.Info("Waiting for drop...");
                System.Threading.Thread.Sleep(2000);
            }

            response = client.GetAsync(INFLUX_DB_URL + "/query?q=SHOW DATABASES");
            responseString = response.Result.Content.ReadAsStringAsync();
            log.Info("Got reponse: " + responseString.Result);
            if (responseString.Result.Contains(INFLUX_DB))
            {
                log.Error("DB: not dropped reattempting...");
                dropRetries++;
                dropDB();
            }
            else
            {
                System.Threading.Thread.Sleep(2000);
                dropRetries = 0;
                log.Info("Dropped influxdb " + INFLUX_DB);
            }
        }

        protected static int createRetries = 0;
        public static void createDB()
        {
            log.Info("Creating influxdb " + INFLUX_DB);

            try
            {
                Task<HttpResponseMessage> response;
                Task<String> responseString;

                if (createRetries % 5 == 0)
                {
                    var content = new FormUrlEncodedContent(values);
                    response = client.PostAsync(INFLUX_DB_URL + "/query?q=CREATE DATABASE " +
                        INFLUX_DB, content);
                    responseString = response.Result.Content.ReadAsStringAsync();
                    log.Info("Got reponse: " + responseString.Result);
                }
                else
                {
                    log.Info("Waiting for create...");
                    System.Threading.Thread.Sleep(2000);
                }

                response = client.GetAsync(INFLUX_DB_URL + "/query?q=SHOW DATABASES");
                responseString = response.Result.Content.ReadAsStringAsync();
                log.Info("Got reponse: " + responseString.Result);

                if (!responseString.Result.Contains(INFLUX_DB))
                {
                    log.Error("DB: not created reattempting...");
                    createRetries++;
                    createDB();
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);
                    createRetries = 0;
                    log.Info("Created influxdb db. ");
                }
            }
            catch (Exception e)
            {
                log.Error("Failed to create db ", e);

            }
        }


        public async static void testInfluxDBClient()
        {
            Random rnd = new Random();
            int month = rnd.Next(1, 100);
            Measurement m = new Measurement("unittest").AddField("value1", month).AddField("value2", month - 1).AddTag("name", "Tony");
            var retval = await manager.Write(m);

            Console.Write("connected");
        }

        public static Measurement buildMeasurement(String measurement, Dictionary<String, object> fields, Dictionary<String, String> tags, DateTime timestamp)
        {
            Measurement m = new Measurement(measurement);
            if (timestamp != null)
            {
                DateTime iTimeStamp = new DateTime(timestamp.Year, timestamp.Month, timestamp.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
                m.Timestamp = iTimeStamp;
            }
            if (fields != null)
            {
                foreach (KeyValuePair<String, object> item in fields)
                {
                    if (item.Value is int)
                        m.AddField(item.Key, (int)item.Value);
                    else if (item.Value is float)
                        m.AddField(item.Key, (float)item.Value);
                }
            }
            if (tags != null)
            {
                foreach (KeyValuePair<String, String> item in tags)
                {
                    String itemValue = item.Value;
                    if (String.IsNullOrEmpty(itemValue) || String.IsNullOrWhiteSpace(itemValue))
                    {
                        itemValue = "<empty>";
                    }
                    else if (itemValue.Contains(System.Environment.NewLine))
                    {
                        itemValue = itemValue.Replace(System.Environment.NewLine, "");
                    }

                    m.AddTag(item.Key, itemValue);
                }
            }
            return m;
        }

        public async static void WriteStat(String measurement, Dictionary<String, object> fields, Dictionary<String, String> tags, DateTime timestamp)
        {
            Measurement m = buildMeasurement(measurement, fields, tags, timestamp);
            await manager.Write(m);
        }

        public static void WriteBulkMeasurements(List<Measurement> measurements)
        {
            log.Info("BEGIN: Writting bulk measurements [" + measurements.Count + "]");
            manager.Write(measurements);
            log.Info("END: writting bulk measurements [" + measurements.Count + "]");
        }
    }
}