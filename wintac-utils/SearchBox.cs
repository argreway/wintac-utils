using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wintac_utils.main;
using System.Windows.Forms;

namespace wintac_utils
{
    public partial class SearchBox : Form
    {
        protected MainForm mainForm = MainApp.getMainForm();

        public SearchBox()
        {
            InitializeComponent();
        }

        private void SearchBox_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            searchCustomerText();
        }

        private void buttonSearchCN_Click(object sender, EventArgs e)
        {
            searchCustomerNumber();
        }

        private void searchStringCheckKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchCustomerText();
            }
        }

        private void searchCustomerNumberKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchCustomerNumber();
            }
        }

        /// ////////////////////////////////////////////////////// 
        /// ////////////////////////// HELPERS  /// ////////////////////////// 
        /// ////////////////////////////////////////////////////// 

        private void searchCustomerText()
        {
            this.Visible = false;
            MainApp.GetDBConnection().searchCustomer(mainForm.GetDataGridView(), textBoxSearchString.Text);
            mainForm.GetDataGridView().Columns["TS"].Visible = false;
        }

        private void searchCustomerNumber()
        {
            this.Visible = false;
            MainApp.GetDBConnection().searchCustomerCN(mainForm.GetDataGridView(), textBoxInputCN.Text);
        }

    }
}
