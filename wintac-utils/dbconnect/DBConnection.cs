using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using wintac_utils.main;

namespace wintac_utils.dbconnect
{
    class DBConnection
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected SqlConnection cnn;

        public String connectToDB(String server, String db, String user, String password)
        {
            string connectionString = null;
            //connetionString = "Server=192.168.1.34\\WINTACSQL;Database=SENTRY4-4-2018;User ID=argreway;Password=Sniper13!";
            //String escServer = server.Split('\\').Join(' ');
            connectionString = "Server=" + server + ";Database=" + db + ";User ID=" + user + ";Password=" + password;
            log.Info("Connecting to the DB: " + connectionString);
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                log.Info("Connection was successful!");
                return "Connection was successful! ";
            }
            catch (Exception ex)
            {
                log.Error("Can not open connection !", ex);
                if (MainApp.GetConsole())
                    MessageBox.Show("Can not open connection ! " + ex);
            }
            return null;
        }

        public void getCustomerList(DataGridView dataGridView)
        {
            SqlCommand command = new SqlCommand("select * from cst;", cnn);
            SqlDataAdapter sda = new SqlDataAdapter();

            sda.SelectCommand = command;
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            BindingSource bsource = new BindingSource();
            bsource.DataSource = dataTable;

            dataGridView.DataSource = bsource;
            sda.Update(dataTable);
        }


        public void searchCustomerCN(DataGridView dataGridView, String searchString)
        {
            long cn = -1L;
            bool isCn = long.TryParse(searchString, out cn);

            String selectString = "SELECT * FROM cst WHERE cn = " + cn;
            if (!isCn)
            {
                MessageBox.Show("Error: Must be a numeric value!");
                return;
            }

            SqlCommand command = new SqlCommand(selectString, cnn);

            SqlDataAdapter sda = new SqlDataAdapter();

            sda.SelectCommand = command;
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            BindingSource bsource = new BindingSource();
            bsource.DataSource = dataTable;

            dataGridView.DataSource = bsource;
            sda.Update(dataTable);
        }

        public void searchCustomer(DataGridView dataGridView, String searchString)
        {
            String selectString =
            "SELECT * FROM cst WHERE " +
                "REPLACE(REPLACE(REPLACE(REPLACE(name,  '#',''), '*', ''), '\"', ''), char(39), '') like '" + searchString + "%'" +
                " or REPLACE(REPLACE(REPLACE(REPLACE(adr1,  '#',''), '*', ''), '\"', ''), char(39), '') like '" + searchString + "%'" +
                " or REPLACE(REPLACE(REPLACE(REPLACE(adr2,  '#',''), '*', ''), '\"', ''), char(39), '') like '" + searchString + "%'";

            SqlCommand command = new SqlCommand(selectString, cnn);

            SqlDataAdapter sda = new SqlDataAdapter();

            sda.SelectCommand = command;
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            BindingSource bsource = new BindingSource();
            bsource.DataSource = dataTable;

            dataGridView.DataSource = bsource;
            sda.Update(dataTable);
        }

        public DataTable getInvoiceItemTable()
        {
            //String selectString = "SELECT RPG.COUNTER,RPG.RPG.CN,RPG.[IN],RPG.PAGENUM,RPG.POCOST,RPG.IC," +
            //   "RPG.NAME,RPG.HQ,RPG.HQ2,RPG.RP,RPG.COST,RPG.IDATE,RPG.CSDATE," +
            //  "RPG.DEPT,RPG.ACC1,RPG.ACC2,RPG.INOTE,RPG.MISC1,RPG.POCOST * RPG.HQ2 as TOTCOST" +
            // " FROM RPG,RCV,CST,RCVT WHERE IDATE IS NOT NULL AND IDATE like '%2017%' AND RPG.COST > 0 AND RPG.HQ2 > 0 " +
            // "AND (RPG.TYPE IN (1 ,2 ,3 ,4 ) AND NOT(RPG.IC LIKE 'H_FLATRATE%' )";

            String selectString = "SELECT " +
                "CASE RPG.COST " +
                "  WHEN 0 THEN RPG.POCOST " +
                "  ELSE RPG.POCOST* RPG.HQ2 " +
                "END AS TOTCOST, " +
                "RPG.[COUNTER],RPG.CN,RPG.[IN],RPG.PAGENUM,RPG.POCOST,RPG.IC, " +
                "RPG.NAME,RPG.HQ,RPG.HQ2,RPG.RP,RPG.COST,RPG.IDATE,RPG.CSDATE, " +
                "RPG.DEPT,RPG.ACC1,RPG.ACC2,RPG.INOTE,RPG.MISC1,RCV.DEPT as DIVISION " +
                //",RPG.POCOST * RPG.HQ2 as TOTCOST " +
                "FROM RPG,RCV,CST,RCVT WHERE(((((((((({ fn length(RPG.IC )}> 0 ) " +
                "AND NOT((RPG.IC LIKE 'H_FLATRATE%' ))) " +

                "AND(RPG.IDATE like '%201%' ))))" +

                //"AND (RPG.IDATE >= { d '2017-10-15'} ) AND (RPG.IDATE <= { d '2017-10-16'}) AND(RPG.MISC1 LIKE 'ID%')))) " +

                "AND(RPG.TYPE IN(1, 2, 3, 4)) ) AND " +
                "((RCV.CN = RPG.CN) AND(RCV.[IN] = RPG.[IN]))) AND " +
                "((RCV.FRM = 2) AND (RCV.AUTOWIP = 0))) " +
                "AND(CST.CN = RCV.CN) ) AND(RCV.COUNTER = RCVT.RCVPK))";
            //" FROM dbo.RPG WHERE((CN = 6699) AND([IN] = 123)) " +
            //" ORDER BY dbo.RPG.CN ,dbo.RPG.[IN], dbo.RPG.PAGENUM";
            return getDataTable(selectString);
        }

        public DataTable getPayrollDataTable(DateTime start, DateTime end)
        {
            String selectString = "SELECT PAY.EN , PAY.NAME , PAY.CHKNUM , PAY.CHKDATE , PAY.NHOURS , PAY.OHOURS , PAY.SHOURS , PAY.VHOURS , PAY.HOURS5 , PAY.HOURS6 , PAY.HOURS7 , PAY.HOURS8 , PAY.HOURS9 , PAY.HOURS10 , " +
                "PAY.GROSS , PAY.TIPS , PAY.FED_WH , PAY.ST_WH , PAY.LOC_WH , PAY.SOC , PAY.MED , PAY.BEN , PAY.ATSAV , PAY.BTSAV , PAY.REIMB , PAY.MISC1 , PAY.DED5 , PAY.DED6 , PAY.DED7 , PAY.DED8 , PAY.DED9 , PAY.DED10 , PAY.SDI , PAY.FLI , PAY.SUI " +
                "FROM PAY, EMP " +
                "WHERE((PAY.CHKDATE BETWEEN { d '" + start.ToString("yyyy'-'MM'-'dd") + "'} AND { d '" + end.ToString("yyyy'-'MM'-'dd") + "'} ) " +
                "AND (PAY.EN = EMP.EN) )";
            return getDataTable(selectString);
        }

        /// <summary>
        /// 
        /// <param name="rcvForm"></param>  = 
        /// 1 = WO
        /// 2 = Invoice
        /// 3 = PO?
        /// <returns></returns>
        public DataTable getRCVDataTable(DateTime start, DateTime end, int rcvForm)
        {
            String selectString = "SELECT CST.CN, CST.NAME, RCV.ADR1, RCV.INVRMK, RCV.DEPT, RCV.NAME, RCV.IN2, RCV.JDATE, RCV.COUNTER, RCVN.RCVNKey, RCVT.TECH, RCV.SUBTOTAL, RCV.TOTTAX, RCV.TOTTAX2, RCV.MAT, RCV.LAB, RCV.MATC, RCV.LABC " +
                "FROM RCV, RCVT, RCVN, CST " +
                "WHERE (" +
                "(((((RCV.FRM = " + rcvForm + " ) AND (NOT((RCV.JSTAT = '*' )) OR (RCV.JSTAT IS NULL ))) " +
                "AND (RCV.COUNTER = RCVT.RCVPK )) " +
                "AND (RCVT.DATE BETWEEN {d '" + start.ToString("yyyy'-'MM'-'dd") + "'} AND {d '" + end.ToString("yyyy'-'MM'-'dd") + "'} ) ) " +
                "AND ((RCV.\"IN\" = RCVN.\"IN\" ) AND (RCV.CN = RCVN.CN ))) " + "AND (CST.CN = RCV.CN ))";

            return getDataTable(selectString);
        }

        public DataTable getARDataTable(DateTime end)
        {
            String selectString =
            "Select RCV.CN, RCV.[IN], RCV.IN2, RCV.[NAME],RCV.DEPT, RCV.MISC1, RCV.INVRMK, RCV.FRM, RCV.INVDATE, RCV.SUBTOTAL," +
            "RCV.TOTTAX, RCV.TOTTAX2, RCV.TOTTAX3, RCV.TOTTAX4, RCV.TOTTAX5, RCV.MISC1, RCV.PDUE, RCV.INVRMK, " +
            "RCV.DUEDATE, RCV.BALANCE, CST.[EMAIL], CST.[EMAIL2], CST.[NAME] AS CSTNAME, CST.[FNAME] AS CSTFNAME, CST.[TEL] AS CSTTEL," +
            " ISNULL(" +
            " (select SUM(ISNULL(RCT.AMOUNT, 0))" +
            "       + SUM(ISNULL(RCT.TAXPD, 0))" +
            "       + SUM(ISNULL(RCT.DISC, 0))" +
            "   from RCT" +
            "   where ((RCT.CN = RCV.CN and RCT.[IN] = RCV.[IN])) " +
            "   And(DateDiff(\"D\", RCT.[DATE], '" + end.ToString("yyyy'-'MM'-'dd") + "') >= 0)" +
            "    ), 0) AS RECEIPTS_PAID_AMOUNT FROM RCV" +
            "    INNER JOIN CST ON RCV.CN = CST.CN" +
            "      Where((RCV.FRM = 2)  " +
            //"      AND(RCV.[DEPT] LIKE 'CO SPRINGS%') " +
            "      AND(RCV.[INVDATE] <= '" + end.ToString("yyyy'-'MM'-'dd") + "')" +
            "      And((RCV.SUBTOTAL + RCV.TOTTAX + RCV.TOTTAX2 + RCV.TOTTAX3 + RCV.TOTTAX4 + RCV.TOTTAX5) - (ISNULL((select SUM(ISNULL(RCT.AMOUNT, 0))+ SUM(ISNULL(RCT.TAXPD, 0))+SUM(ISNULL(RCT.DISC, 0)) from RCT where((RCT.CN= RCV.CN and RCT.[IN]= RCV.[IN])) " +
            "      And(DateDiff(\"D\", RCT.[DATE], '" + end.ToString("yyyy'-'MM'-'dd") + "') >= 0)), 0)) <> 0) ) Order by RCV.INVDATE, RCV.[NAME]";

            return getDataTable(selectString);
        }

        public DataTable getDataTable(String selectString)
        {
            log.Info("GetDataTable selectString: " + selectString);

            SqlCommand command = new SqlCommand(selectString, cnn);

            SqlDataAdapter sda = new SqlDataAdapter();

            sda.SelectCommand = command;
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            if (MainApp.GetConsole())
            {
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dataTable;

                MainApp.getMainForm().GetDataGridView().DataSource = bsource;
                sda.Update(dataTable);
            }

            log.Info("Found: " + dataTable.Rows.Count);

            return dataTable;
        }

        public DataTable getOutStandingWorkOrders(DateTime start, DateTime end)
        {
            return getRCVDataTable(start, end, 1);
        }

        public DataTable getInvoices(DateTime start, DateTime end)
        {
            return getRCVDataTable(start, end, 2);
        }

        public DataTable getPurchaseOrders(DateTime start, DateTime end)
        {
            return getRCVDataTable(start, end, 5);
        }

        public DataTable getProposals(DateTime start, DateTime end)
        {
            return getRCVDataTable(start, end, 3);
        }


        public void closeDBConnection()
        {
            try
            {
                if (cnn != null)
                    cnn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to close connection! " + e);
                return;
            }
            MessageBox.Show("Closed connection to DB! ");
        }

    }
}
