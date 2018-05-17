using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
