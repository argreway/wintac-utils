namespace wintac_utils
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCustomersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outstandingWOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getPayrollTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateWOPerTechToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateInvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePurchaseOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateProposalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePayrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertALLStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.inputServer = new System.Windows.Forms.TextBox();
            this.inputDB = new System.Windows.Forms.TextBox();
            this.inputUser = new System.Windows.Forms.TextBox();
            this.inputPassword = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelItemsFound = new System.Windows.Forms.Label();
            this.buttonFindForward = new System.Windows.Forms.Button();
            this.buttonFindReverse = new System.Windows.Forms.Button();
            this.textBoxInputFind = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.influxDBAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.workOrdersToolStripMenuItem,
            this.payrollToolStripMenuItem,
            this.statsToolStripMenuItem,
            this.influxDBAdminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1614, 42);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(58, 38);
            this.fileToolStripMenuItem.Text = "DB";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(232, 38);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Enabled = false;
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(232, 38);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(232, 38);
            this.closeToolStripMenuItem.Text = "Exit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadCustomersToolStripMenuItem,
            this.searchCustomerToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(140, 38);
            this.editToolStripMenuItem.Text = "Customers";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // loadCustomersToolStripMenuItem
            // 
            this.loadCustomersToolStripMenuItem.Enabled = false;
            this.loadCustomersToolStripMenuItem.Name = "loadCustomersToolStripMenuItem";
            this.loadCustomersToolStripMenuItem.Size = new System.Drawing.Size(295, 38);
            this.loadCustomersToolStripMenuItem.Text = "Load Customers";
            this.loadCustomersToolStripMenuItem.Click += new System.EventHandler(this.loadCustomersToolStripMenuItem_Click);
            // 
            // searchCustomerToolStripMenuItem
            // 
            this.searchCustomerToolStripMenuItem.Enabled = false;
            this.searchCustomerToolStripMenuItem.Name = "searchCustomerToolStripMenuItem";
            this.searchCustomerToolStripMenuItem.Size = new System.Drawing.Size(295, 38);
            this.searchCustomerToolStripMenuItem.Text = "Search Customer";
            this.searchCustomerToolStripMenuItem.Click += new System.EventHandler(this.searchCustomerToolStripMenuItem_Click);
            // 
            // workOrdersToolStripMenuItem
            // 
            this.workOrdersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outstandingWOToolStripMenuItem});
            this.workOrdersToolStripMenuItem.Name = "workOrdersToolStripMenuItem";
            this.workOrdersToolStripMenuItem.Size = new System.Drawing.Size(161, 38);
            this.workOrdersToolStripMenuItem.Text = "Work Orders";
            // 
            // outstandingWOToolStripMenuItem
            // 
            this.outstandingWOToolStripMenuItem.Enabled = false;
            this.outstandingWOToolStripMenuItem.Name = "outstandingWOToolStripMenuItem";
            this.outstandingWOToolStripMenuItem.Size = new System.Drawing.Size(293, 38);
            this.outstandingWOToolStripMenuItem.Text = "Outstanding WO";
            this.outstandingWOToolStripMenuItem.Click += new System.EventHandler(this.outstandingWOToolStripMenuItem_Click);
            // 
            // payrollToolStripMenuItem
            // 
            this.payrollToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getPayrollTableToolStripMenuItem});
            this.payrollToolStripMenuItem.Name = "payrollToolStripMenuItem";
            this.payrollToolStripMenuItem.Size = new System.Drawing.Size(98, 38);
            this.payrollToolStripMenuItem.Text = "Payroll";
            // 
            // getPayrollTableToolStripMenuItem
            // 
            this.getPayrollTableToolStripMenuItem.Name = "getPayrollTableToolStripMenuItem";
            this.getPayrollTableToolStripMenuItem.Size = new System.Drawing.Size(294, 38);
            this.getPayrollTableToolStripMenuItem.Text = "Get Payroll Table";
            // 
            // statsToolStripMenuItem
            // 
            this.statsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculateWOPerTechToolStripMenuItem,
            this.updateInvoicesToolStripMenuItem,
            this.updatePurchaseOrdersToolStripMenuItem,
            this.updateProposalsToolStripMenuItem,
            this.updatePayrollToolStripMenuItem,
            this.insertALLStatsToolStripMenuItem});
            this.statsToolStripMenuItem.Name = "statsToolStripMenuItem";
            this.statsToolStripMenuItem.Size = new System.Drawing.Size(78, 38);
            this.statsToolStripMenuItem.Text = "Stats";
            // 
            // calculateWOPerTechToolStripMenuItem
            // 
            this.calculateWOPerTechToolStripMenuItem.Name = "calculateWOPerTechToolStripMenuItem";
            this.calculateWOPerTechToolStripMenuItem.Size = new System.Drawing.Size(371, 38);
            this.calculateWOPerTechToolStripMenuItem.Text = "Update Work Orders";
            this.calculateWOPerTechToolStripMenuItem.Click += new System.EventHandler(this.calculateWOPerTechToolStripMenuItem_Click);
            // 
            // updateInvoicesToolStripMenuItem
            // 
            this.updateInvoicesToolStripMenuItem.Name = "updateInvoicesToolStripMenuItem";
            this.updateInvoicesToolStripMenuItem.Size = new System.Drawing.Size(371, 38);
            this.updateInvoicesToolStripMenuItem.Text = "Update Invoices";
            this.updateInvoicesToolStripMenuItem.Click += new System.EventHandler(this.updateInvoices);
            // 
            // updatePurchaseOrdersToolStripMenuItem
            // 
            this.updatePurchaseOrdersToolStripMenuItem.Name = "updatePurchaseOrdersToolStripMenuItem";
            this.updatePurchaseOrdersToolStripMenuItem.Size = new System.Drawing.Size(371, 38);
            this.updatePurchaseOrdersToolStripMenuItem.Text = "Update Purchase Orders";
            this.updatePurchaseOrdersToolStripMenuItem.Click += new System.EventHandler(this.updatePurchaseOrders);
            // 
            // updateProposalsToolStripMenuItem
            // 
            this.updateProposalsToolStripMenuItem.Name = "updateProposalsToolStripMenuItem";
            this.updateProposalsToolStripMenuItem.Size = new System.Drawing.Size(371, 38);
            this.updateProposalsToolStripMenuItem.Text = "Update Proposals";
            this.updateProposalsToolStripMenuItem.Click += new System.EventHandler(this.updateProposals);
            // 
            // updatePayrollToolStripMenuItem
            // 
            this.updatePayrollToolStripMenuItem.Name = "updatePayrollToolStripMenuItem";
            this.updatePayrollToolStripMenuItem.Size = new System.Drawing.Size(371, 38);
            this.updatePayrollToolStripMenuItem.Text = "Update Payroll";
            this.updatePayrollToolStripMenuItem.Click += new System.EventHandler(this.updatePayrollToolStripMenuItem_Click);
            // 
            // insertALLStatsToolStripMenuItem
            // 
            this.insertALLStatsToolStripMenuItem.Name = "insertALLStatsToolStripMenuItem";
            this.insertALLStatsToolStripMenuItem.Size = new System.Drawing.Size(371, 38);
            this.insertALLStatsToolStripMenuItem.Text = "Insert ALL Stats";
            this.insertALLStatsToolStripMenuItem.Click += new System.EventHandler(this.insertALLStatsToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 192);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1614, 737);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // inputServer
            // 
            this.inputServer.Location = new System.Drawing.Point(115, 60);
            this.inputServer.Name = "inputServer";
            this.inputServer.Size = new System.Drawing.Size(282, 31);
            this.inputServer.TabIndex = 3;
            this.inputServer.TextChanged += new System.EventHandler(this.inputServer_TextChanged);
            // 
            // inputDB
            // 
            this.inputDB.Location = new System.Drawing.Point(463, 60);
            this.inputDB.Name = "inputDB";
            this.inputDB.Size = new System.Drawing.Size(198, 31);
            this.inputDB.TabIndex = 4;
            this.inputDB.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // inputUser
            // 
            this.inputUser.Location = new System.Drawing.Point(765, 60);
            this.inputUser.Name = "inputUser";
            this.inputUser.Size = new System.Drawing.Size(198, 31);
            this.inputUser.TabIndex = 5;
            this.inputUser.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // inputPassword
            // 
            this.inputPassword.Location = new System.Drawing.Point(1085, 60);
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.PasswordChar = '*';
            this.inputPassword.Size = new System.Drawing.Size(198, 31);
            this.inputPassword.TabIndex = 6;
            this.inputPassword.TextChanged += new System.EventHandler(this.inputPassword_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Server:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(403, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 31);
            this.label2.TabIndex = 8;
            this.label2.Text = "DB:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(679, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 31);
            this.label3.TabIndex = 9;
            this.label3.Text = "User:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(999, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 31);
            this.label4.TabIndex = 10;
            this.label4.Text = "PW:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.labelItemsFound);
            this.panel1.Controls.Add(this.buttonFindForward);
            this.panel1.Controls.Add(this.buttonFindReverse);
            this.panel1.Controls.Add(this.textBoxInputFind);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1614, 77);
            this.panel1.TabIndex = 11;
            // 
            // labelItemsFound
            // 
            this.labelItemsFound.AutoSize = true;
            this.labelItemsFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItemsFound.ForeColor = System.Drawing.Color.Red;
            this.labelItemsFound.Location = new System.Drawing.Point(458, 30);
            this.labelItemsFound.Name = "labelItemsFound";
            this.labelItemsFound.Size = new System.Drawing.Size(0, 26);
            this.labelItemsFound.TabIndex = 16;
            // 
            // buttonFindForward
            // 
            this.buttonFindForward.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonFindForward.FlatAppearance.BorderSize = 4;
            this.buttonFindForward.Location = new System.Drawing.Point(398, 27);
            this.buttonFindForward.Name = "buttonFindForward";
            this.buttonFindForward.Size = new System.Drawing.Size(45, 41);
            this.buttonFindForward.TabIndex = 15;
            this.buttonFindForward.Text = ">";
            this.buttonFindForward.UseVisualStyleBackColor = true;
            this.buttonFindForward.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonFindReverse
            // 
            this.buttonFindReverse.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonFindReverse.FlatAppearance.BorderSize = 4;
            this.buttonFindReverse.Location = new System.Drawing.Point(337, 27);
            this.buttonFindReverse.Name = "buttonFindReverse";
            this.buttonFindReverse.Size = new System.Drawing.Size(44, 41);
            this.buttonFindReverse.TabIndex = 14;
            this.buttonFindReverse.Text = "<";
            this.buttonFindReverse.UseVisualStyleBackColor = true;
            this.buttonFindReverse.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxInputFind
            // 
            this.textBoxInputFind.Location = new System.Drawing.Point(115, 27);
            this.textBoxInputFind.Name = "textBoxInputFind";
            this.textBoxInputFind.Size = new System.Drawing.Size(198, 31);
            this.textBoxInputFind.TabIndex = 12;
            this.textBoxInputFind.TextChanged += new System.EventHandler(this.textBoxInputFind_TextChanged);
            this.textBoxInputFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.formSearchKeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 31);
            this.label5.TabIndex = 12;
            this.label5.Text = "Find: ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // influxDBAdminToolStripMenuItem
            // 
            this.influxDBAdminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDBToolStripMenuItem,
            this.dropDBToolStripMenuItem});
            this.influxDBAdminToolStripMenuItem.Name = "influxDBAdminToolStripMenuItem";
            this.influxDBAdminToolStripMenuItem.Size = new System.Drawing.Size(117, 38);
            this.influxDBAdminToolStripMenuItem.Text = "InfluxDB";
            // 
            // createDBToolStripMenuItem
            // 
            this.createDBToolStripMenuItem.Name = "createDBToolStripMenuItem";
            this.createDBToolStripMenuItem.Size = new System.Drawing.Size(324, 38);
            this.createDBToolStripMenuItem.Text = "Create DB";
            this.createDBToolStripMenuItem.Click += new System.EventHandler(this.createDBToolStripMenuItem_Click);
            // 
            // dropDBToolStripMenuItem
            // 
            this.dropDBToolStripMenuItem.Name = "dropDBToolStripMenuItem";
            this.dropDBToolStripMenuItem.Size = new System.Drawing.Size(324, 38);
            this.dropDBToolStripMenuItem.Text = "Drop DB";
            this.dropDBToolStripMenuItem.Click += new System.EventHandler(this.dropDBToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1614, 929);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputPassword);
            this.Controls.Add(this.inputUser);
            this.Controls.Add(this.inputDB);
            this.Controls.Add(this.inputServer);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wintac Utils";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public System.Windows.Forms.DataGridView GetDataGridView()
        {
            return dataGridView1;
        }


        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCustomersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchCustomerToolStripMenuItem;
        private System.Windows.Forms.TextBox inputServer;
        private System.Windows.Forms.TextBox inputDB;
        private System.Windows.Forms.TextBox inputUser;
        private System.Windows.Forms.TextBox inputPassword;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxInputFind;
        private System.Windows.Forms.Button buttonFindReverse;
        private System.Windows.Forms.Button buttonFindForward;
        private System.Windows.Forms.Label labelItemsFound;
        private System.Windows.Forms.ToolStripMenuItem workOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outstandingWOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateWOPerTechToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateInvoicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatePurchaseOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateProposalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payrollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getPayrollTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatePayrollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertALLStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem influxDBAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dropDBToolStripMenuItem;
    }
}

