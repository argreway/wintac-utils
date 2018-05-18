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

        public enum MEASUREMENT
        {
            WO,
            DETAILS
        }

        public enum WO
        {
            TECH,
            COMPLETED,
            OUTSTANDING
        }

        protected static String INFLUX_DB_URL = "http://192.168.1.30:8086";
        protected static String INFLUX_DB = "sentry_stats";

        //protected static InfluxManager manager = new InfluxManager(INFLUX_DB_URL, INFLUX_DB);

        public async static void testInfluxDBClient()
        {
            InfluxManager manager = new InfluxManager(INFLUX_DB_URL, INFLUX_DB);
            Random rnd = new Random();
            int month = rnd.Next(1, 100);
            Measurement m = new Measurement("unittest").AddField("value1", month).AddField("value2", month - 1).AddTag("name", "Tony");
            var retval = await manager.Write(m);

            Console.Write("connected");
            //Pong pong = await influxClient.PingAsync();
            //MessageBox.Show("Found: " + pong);
        }

        //public async static Task<HttpResponseMessage> WriteStat(String measurement, Dictionary<String, int> fields, Dictionary<String, String> tags)
        public async static void WriteStat(String measurement, Dictionary<String, int> fields, Dictionary<String, String> tags)
        {
            InfluxManager manager = new InfluxManager(INFLUX_DB_URL, INFLUX_DB);

            Measurement m = new Measurement(measurement);
            if (fields != null)
            {
                foreach (KeyValuePair<String, int> item in fields)
                    m.AddField(item.Key, item.Value);
            }
            if (tags != null)
            {
                foreach (KeyValuePair<String, String> item in tags)
                    m.AddTag(item.Key, item.Value);
            }
            await manager.Write(m);
        }

    }
}