﻿using InfluxClient;
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
            INV,
            PO,
            PROP,
            PAY
        }

        public enum COL
        {
            TECH,
            JDATE,
            CHKDATE
        }

        public static List<String> WIP_FIELDS = new List<String> { "SUBTOTAL", "TOTTAX", "TOTTAX2", "MAT", "LAB", "MATC", "LABC" };
        public static List<String> PAY_FIELDS = new List<String> { "NHOURS ", "OHOURS ", "SHOURS ", "VHOURS ", "HOURS5 ", "HOURS6 ",
            "HOURS7 ", "HOURS8 ", "HOURS9 ", "HOURS10 ", "GROSS" , "TIPS ", "FED_WH ", "ST_WH ", "LOC_WH ", "SOC ", "MED ", "BEN ",
            "ATSAV ", "BTSAV ", "REIMB ", "MISC1 ", "DED5 ", "DED6 ", "DED7 ", "DED8 ", "DED9 ", "DED10 ", "SDI ", "FLI ", "SUI" };

        protected static String INFLUX_DB_URL = "http://192.168.1.30:8086";
        protected static String INFLUX_DB = "sentry_stats_time";
        protected static InfluxManager manager = new InfluxManager(INFLUX_DB_URL, INFLUX_DB);

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

        public async static void WriteBulkMeasurements(List<Measurement> measurements)
        {
            await manager.Write(measurements);
        }

    }
}