using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wintac_utils.main;
using wintac_utils.workorders;
using wintac_utils.influxdb;

namespace wintac_utils
{
    public partial class MainForm : Form
    {

        List<DataGridViewCell> currentResults;
        int currentCellIdx;

        public MainForm()
        {
            InitializeComponent();
            this.Size = new Size(1200, 700);

            inputServer.Text = MainApp.getProperties().getServer();
            inputDB.Text = MainApp.getProperties().getDatabase();
            inputUser.Text = MainApp.getProperties().getUser();
            inputPassword.Text = MainApp.getProperties().getPassword();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            connectToolStripMenuItem_Click(null, null);
        }

        private void FileMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String connected = MainApp.GetDBConnection().connectToDB(inputServer.Text, inputDB.Text,
                inputUser.Text, inputPassword.Text);

            if (connected == null)
            {
                labelItemsFound.Text = "FAILED TO CONNECT TO DB!";
                return;
            }

            loadCustomersToolStripMenuItem.Enabled = true;
            searchCustomerToolStripMenuItem.Enabled = true;
            connectToolStripMenuItem.Enabled = false;
            disconnectToolStripMenuItem.Enabled = true;
            outstandingWOToolStripMenuItem.Enabled = true;
            labelItemsFound.Text = "CONNECTED TO DB SUCCESSFUL!";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainApp.GetDBConnection().closeDBConnection();
            System.Environment.Exit(0);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainApp.GetDBConnection().getCustomerList(dataGridView1);
            dataGridView1.Columns["TS"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainApp.GetSearchBox().Text = "";
            MainApp.GetSearchBox().Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void inputServer_TextChanged(object sender, EventArgs e)
        {

        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainApp.GetDBConnection().closeDBConnection();
            disconnectToolStripMenuItem.Enabled = false;
            connectToolStripMenuItem.Enabled = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void formSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView1 != null && dataGridView1.RowCount > 20 && e.KeyCode != Keys.Enter)
            {
                // Require at least 2 chars for results greater than 20
                if (String.IsNullOrEmpty(textBoxInputFind.Text) || textBoxInputFind.Text.Length < 2)
                    return;
            }
            searchDataGrid(textBoxInputFind.Text);
        }

        protected void searchDataGrid(String find)
        {
            currentResults = getCellsForSearch(find, MainApp.getMainForm().GetDataGridView());
            currentCellIdx = 0;
            if (currentResults != null && currentResults.Count > 0)
                dataGridView1.CurrentCell = currentResults[currentCellIdx];
            labelItemsFound.Text = "Items Found: " + currentResults.Count;
        }

        protected List<DataGridViewCell> getCellsForSearch(String find, DataGridView dataGridView1)
        {
            List<DataGridViewCell> cells = new List<DataGridViewCell>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                    if (cell.Value == null || String.IsNullOrEmpty(find))
                        continue;
                    int index = cell.Value.ToString().ToUpper().IndexOf(find.ToUpper());
                    if (index < 0)
                        continue;
                    else
                    {
                        cells.Add(cell);
                        cell.Style.BackColor = Color.Red;
                    }
                }
            }
            return cells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentResults.Count == 1 || currentResults.Count == 0)
                return;
            else if (currentCellIdx == 0)
                currentCellIdx = currentResults.Count - 1;
            else if (currentCellIdx > 0)
                currentCellIdx--;
            dataGridView1.CurrentCell = currentResults[currentCellIdx];
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBoxInputFind_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (currentResults.Count == 1 || currentResults.Count == 0)
                return;
            else if (currentCellIdx < currentResults.Count - 1)
                currentCellIdx++;
            else if (currentCellIdx == currentResults.Count - 1)
                currentCellIdx = 0;
            dataGridView1.CurrentCell = currentResults[currentCellIdx];
        }

        private void outstandingWOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkOrderUtils.getOutStandingWorkOrders();
        }

        private void pongTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfluxdbClient.testInfluxDBClient();
        }

        private void inputPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void calculateWOPerTechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkOrderUtils.calculateOutstandingPerTech();
        }
    }
}
