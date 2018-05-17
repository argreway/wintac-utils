using InfluxClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wintac_utils.influxdb
{
    class InfluxdbClient
    {

        public async static void testInfluxDBClient()
        {
            //InfluxDb influxClient = new InfluxDb("http://192.168.1.30:8086", "sentry", "sentry", InfluxDB.Net.Enums.InfluxVersion.Auto, new TimeSpan(10000));
            InfluxManager mgr = new InfluxManager("http://192.168.1.30:8086/", "sentry_stats");
            Measurement m = new Measurement("unittest").AddField("count", 42);
            var retval = await mgr.Write(m);

            Console.Write("connected");
            //Pong pong = await influxClient.PingAsync();
            //MessageBox.Show("Found: " + pong);
        }


    }
}