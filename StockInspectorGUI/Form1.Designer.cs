namespace StockInspectorGUI
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_Stocks = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_InportToDatabase = new System.Windows.Forms.Button();
            this.btn_DownladStock = new System.Windows.Forms.Button();
            this.tb_StockIndex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_ImportFromDatabase = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_Stocks = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Add = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_Stocks = new System.Windows.Forms.ListBox();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_All = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_Type = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_Stock = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.display_cb_Type = new System.Windows.Forms.ComboBox();
            this.pb_Download = new System.Windows.Forms.ProgressBar();
            this.lb_Download = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tp_Stocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stocks)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_Stocks);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(779, 642);
            this.tabControl1.TabIndex = 0;
            // 
            // tp_Stocks
            // 
            this.tp_Stocks.Controls.Add(this.dataGridView1);
            this.tp_Stocks.Controls.Add(this.btn_InportToDatabase);
            this.tp_Stocks.Controls.Add(this.btn_DownladStock);
            this.tp_Stocks.Controls.Add(this.tb_StockIndex);
            this.tp_Stocks.Controls.Add(this.label1);
            this.tp_Stocks.Location = new System.Drawing.Point(4, 22);
            this.tp_Stocks.Name = "tp_Stocks";
            this.tp_Stocks.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Stocks.Size = new System.Drawing.Size(771, 616);
            this.tp_Stocks.TabIndex = 0;
            this.tp_Stocks.Text = "Stocks";
            this.tp_Stocks.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(29, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(391, 199);
            this.dataGridView1.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "StockID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "StockName";
            this.Column2.Name = "Column2";
            // 
            // btn_InportToDatabase
            // 
            this.btn_InportToDatabase.Location = new System.Drawing.Point(491, 80);
            this.btn_InportToDatabase.Name = "btn_InportToDatabase";
            this.btn_InportToDatabase.Size = new System.Drawing.Size(75, 23);
            this.btn_InportToDatabase.TabIndex = 4;
            this.btn_InportToDatabase.Text = "导入到数据库";
            this.btn_InportToDatabase.UseVisualStyleBackColor = true;
            this.btn_InportToDatabase.Click += new System.EventHandler(this.btn_InportToDatabase_Click);
            // 
            // btn_DownladStock
            // 
            this.btn_DownladStock.Location = new System.Drawing.Point(491, 18);
            this.btn_DownladStock.Name = "btn_DownladStock";
            this.btn_DownladStock.Size = new System.Drawing.Size(75, 23);
            this.btn_DownladStock.TabIndex = 3;
            this.btn_DownladStock.Text = "下载";
            this.btn_DownladStock.UseVisualStyleBackColor = true;
            this.btn_DownladStock.Click += new System.EventHandler(this.btn_DownladStock_Click);
            // 
            // tb_StockIndex
            // 
            this.tb_StockIndex.Location = new System.Drawing.Point(77, 18);
            this.tb_StockIndex.Name = "tb_StockIndex";
            this.tb_StockIndex.Size = new System.Drawing.Size(343, 21);
            this.tb_StockIndex.TabIndex = 1;
            this.tb_StockIndex.Text = "http://quote.stockstar.com/stock/stock_index.htm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Url";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lb_Download);
            this.tabPage2.Controls.Add(this.pb_Download);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.cb_Type);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.lb_Stocks);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btn_All);
            this.tabPage2.Controls.Add(this.btn_Clear);
            this.tabPage2.Controls.Add(this.btn_Remove);
            this.tabPage2.Controls.Add(this.btn_Add);
            this.tabPage2.Controls.Add(this.btn_ImportFromDatabase);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(771, 616);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Download";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_ImportFromDatabase
            // 
            this.btn_ImportFromDatabase.Location = new System.Drawing.Point(622, 6);
            this.btn_ImportFromDatabase.Name = "btn_ImportFromDatabase";
            this.btn_ImportFromDatabase.Size = new System.Drawing.Size(106, 23);
            this.btn_ImportFromDatabase.TabIndex = 7;
            this.btn_ImportFromDatabase.Text = "从数据库中读出";
            this.btn_ImportFromDatabase.UseVisualStyleBackColor = true;
            this.btn_ImportFromDatabase.Click += new System.EventHandler(this.btn_ImportFromDatabase_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_Stocks);
            this.groupBox1.Location = new System.Drawing.Point(22, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stocks";
            // 
            // dgv_Stocks
            // 
            this.dgv_Stocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Stocks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column5});
            this.dgv_Stocks.Location = new System.Drawing.Point(7, 21);
            this.dgv_Stocks.Name = "dgv_Stocks";
            this.dgv_Stocks.RowTemplate.Height = 23;
            this.dgv_Stocks.Size = new System.Drawing.Size(699, 150);
            this.dgv_Stocks.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "checked";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "StockID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "StockName";
            this.Column5.Name = "Column5";
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(500, 248);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 8;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Stocks";
            // 
            // lb_Stocks
            // 
            this.lb_Stocks.FormattingEnabled = true;
            this.lb_Stocks.ItemHeight = 12;
            this.lb_Stocks.Location = new System.Drawing.Point(104, 248);
            this.lb_Stocks.Name = "lb_Stocks";
            this.lb_Stocks.Size = new System.Drawing.Size(313, 172);
            this.lb_Stocks.TabIndex = 10;
            // 
            // btn_Remove
            // 
            this.btn_Remove.Location = new System.Drawing.Point(500, 289);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(75, 23);
            this.btn_Remove.TabIndex = 8;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(500, 331);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 8;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_All
            // 
            this.btn_All.Location = new System.Drawing.Point(500, 375);
            this.btn_All.Name = "btn_All";
            this.btn_All.Size = new System.Drawing.Size(75, 23);
            this.btn_All.TabIndex = 8;
            this.btn_All.Text = "All";
            this.btn_All.UseVisualStyleBackColor = true;
            this.btn_All.Click += new System.EventHandler(this.btn_All_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 456);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Type";
            // 
            // cb_Type
            // 
            this.cb_Type.FormattingEnabled = true;
            this.cb_Type.Items.AddRange(new object[] {
            "Minute",
            "Day",
            "Week",
            "Month",
            "All"});
            this.cb_Type.Location = new System.Drawing.Point(104, 447);
            this.cb_Type.Name = "cb_Type";
            this.cb_Type.Size = new System.Drawing.Size(121, 20);
            this.cb_Type.TabIndex = 12;
            this.cb_Type.Text = "All";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(500, 447);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "下载并导入数据库";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.display_cb_Type);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cb_Stock);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(771, 616);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Display";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Stock";
            // 
            // cb_Stock
            // 
            this.cb_Stock.FormattingEnabled = true;
            this.cb_Stock.Location = new System.Drawing.Point(117, 24);
            this.cb_Stock.Name = "cb_Stock";
            this.cb_Stock.Size = new System.Drawing.Size(121, 20);
            this.cb_Stock.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Type";
            // 
            // display_cb_Type
            // 
            this.display_cb_Type.FormattingEnabled = true;
            this.display_cb_Type.Items.AddRange(new object[] {
            "Minute",
            "Day",
            "Week",
            "Month",
            "All"});
            this.display_cb_Type.Location = new System.Drawing.Point(117, 92);
            this.display_cb_Type.Name = "display_cb_Type";
            this.display_cb_Type.Size = new System.Drawing.Size(121, 20);
            this.display_cb_Type.TabIndex = 3;
            // 
            // pb_Download
            // 
            this.pb_Download.Location = new System.Drawing.Point(104, 512);
            this.pb_Download.Name = "pb_Download";
            this.pb_Download.Size = new System.Drawing.Size(313, 23);
            this.pb_Download.TabIndex = 14;
            // 
            // lb_Download
            // 
            this.lb_Download.AutoSize = true;
            this.lb_Download.Location = new System.Drawing.Point(442, 512);
            this.lb_Download.Name = "lb_Download";
            this.lb_Download.Size = new System.Drawing.Size(0, 12);
            this.lb_Download.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 642);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tp_Stocks.ResumeLayout(false);
            this.tp_Stocks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stocks)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_Stocks;
        private System.Windows.Forms.TextBox tb_StockIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_InportToDatabase;
        private System.Windows.Forms.Button btn_DownladStock;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_Stocks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btn_ImportFromDatabase;
        private System.Windows.Forms.ListBox lb_Stocks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_All;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cb_Type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox display_cb_Type;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_Stock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar pb_Download;
        private System.Windows.Forms.Label lb_Download;
    }
}

