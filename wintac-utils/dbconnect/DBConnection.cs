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
        protected SqlConnection cnn;

        public String connectToDB(String server, String db, String user, String password)
        {
            string connetionString = null;
            //connetionString = "Server=192.168.1.34\\WINTACSQL;Database=SENTRY4-4-2018;User ID=argreway;Password=Sniper13!";
            //String escServer = server.Split('\\').Join(' ');
            connetionString = "Server=" + server + ";Database=" + db + ";User ID=" + user + ";Password=" + password;
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                return "Connection was successful! ";
            }
            catch (Exception ex)
            {
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

        public DataTable getOutStandingWorkOrders(DateTime start, DateTime end)
        {
            String selectString = "SELECT CST.CN, CST.NAME, RCV.ADR1, RCV.NAME, RCV.IN2, RCV.JDATE, RCV.COUNTER, RCVN.RCVNKey, RCVT.TECH " +
                "FROM RCV, RCVT, RCVN, CST " +
                "WHERE (" +
                "(((((RCV.FRM = 1 ) AND (NOT((RCV.JSTAT = '*' )) OR (RCV.JSTAT IS NULL ))) " +
                "AND (RCV.COUNTER = RCVT.RCVPK )) " +
                "AND (RCVT.DATE BETWEEN {d '" + start.ToString("yyyy'-'MM'-'dd") + "'} AND {d '" + end.ToString("yyyy'-'MM'-'dd") + "'} ) ) " +
                "AND ((RCV.\"IN\" = RCVN.\"IN\" ) AND (RCV.CN = RCVN.CN ))) " + "AND (CST.CN = RCV.CN ))";

            SqlCommand command = new SqlCommand(selectString, cnn);

            SqlDataAdapter sda = new SqlDataAdapter();

            sda.SelectCommand = command;
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            BindingSource bsource = new BindingSource();
            bsource.DataSource = dataTable;

            MainApp.getMainForm().GetDataGridView().DataSource = bsource;
            sda.Update(dataTable);

            return dataTable;
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
