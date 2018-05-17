using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wintac_utils.WintacReference;


namespace wintac_utils.webservice
{
    class WebserviceConnect
    {
        public static void Test()
        {
            WebserviceConnect connect = new WebserviceConnect();
            //connect.Connect();
        }

        public void Connect()
        {
            WebService1SoapClient soapClient = new WebService1SoapClient();

            String client = soapClient.get_customer(14716L);

            String sites = soapClient.list_job_sites(14716L);

            //String job = soapClient.get_job_details();
            //String site = soapClient.get_site_info();
            String history = soapClient.service_history("abc", 14716L, "a", "b");

            Console.WriteLine("Found client: " + client);
            Console.WriteLine("Found history: " + history);

        }

    }
}
