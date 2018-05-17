namespace wintac_utils
{
    partial class SearchBox
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSearchString = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxInputCN = new System.Windows.Forms.TextBox();
            this.buttonSearchCN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search String: ";
            // 
            // textBoxSearchString
            // 
            this.textBoxSearchString.Location = new System.Drawing.Point(227, 132);
            this.textBoxSearchString.Name = "textBoxSearchString";
            this.textBoxSearchString.Size = new System.Drawing.Size(250, 31);
            this.textBoxSearchString.TabIndex = 4;
            this.textBoxSearchString.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBoxSearchString.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchStringCheckKeyUp);
            // 
            // buttonSearch
            // 
            this.buttonSearch.FlatAppearance.BorderSize = 3;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSearch.Location = new System.Drawing.Point(501, 120);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(119, 54);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(575, 50);
            this.label1.TabIndex = 6;
            this.label1.Text = "Please enter a search string.  \r\nThis can be customer name, address, or customer " +
    "number.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Customer Num:";
            // 
            // textBoxInputCN
            // 
            this.textBoxInputCN.Location = new System.Drawing.Point(227, 272);
            this.textBoxInputCN.Name = "textBoxInputCN";
            this.textBoxInputCN.Size = new System.Drawing.Size(250, 31);
            this.textBoxInputCN.TabIndex = 8;
            this.textBoxInputCN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchCustomerNumberKeyUp);
            // 
            // buttonSearchCN
            // 
            this.buttonSearchCN.FlatAppearance.BorderSize = 3;
            this.buttonSearchCN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSearchCN.Location = new System.Drawing.Point(501, 262);
            this.buttonSearchCN.Name = "buttonSearchCN";
            this.buttonSearchCN.Size = new System.Drawing.Size(119, 54);
            this.buttonSearchCN.TabIndex = 9;
            this.buttonSearchCN.Text = "Search";
            this.buttonSearchCN.UseVisualStyleBackColor = true;
            this.buttonSearchCN.Click += new System.EventHandler(this.buttonSearchCN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(222, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "- or -";
            // 
            // SearchBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 378);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonSearchCN);
            this.Controls.Add(this.textBoxInputCN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearchString);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SearchBox";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Search String";
            this.Load += new System.EventHandler(this.SearchBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSearchString;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxInputCN;
        private System.Windows.Forms.Button buttonSearchCN;
        private System.Windows.Forms.Label label4;
    }
}