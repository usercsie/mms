
namespace MMS.Forms
{
    partial class FormTransaction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTransaction));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBoard = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.rtxSearch = new MMS.RoundedTextBox();
            this.ckbDateRange = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dgvTransactionInfo = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoveType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcbSearch = new System.Windows.Forms.PictureBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelBoard.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1693, 120);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(68)))), ((int)(((byte)(126)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(66, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(1693, 120);
            this.label1.TabIndex = 3;
            this.label1.Text = "Trasaction";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelBoard
            // 
            this.panelBoard.Controls.Add(this.panel2);
            this.panelBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBoard.Location = new System.Drawing.Point(0, 120);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(1693, 677);
            this.panelBoard.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.rtxSearch);
            this.panel2.Controls.Add(this.ckbDateRange);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtpStartDate);
            this.panel2.Controls.Add(this.dtpEndDate);
            this.panel2.Controls.Add(this.dgvTransactionInfo);
            this.panel2.Controls.Add(this.pcbSearch);
            this.panel2.Controls.Add(this.btnCreate);
            this.panel2.Location = new System.Drawing.Point(37, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1617, 641);
            this.panel2.TabIndex = 3;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(68)))), ((int)(((byte)(126)))));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(384, 15);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(150, 63);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(68)))), ((int)(((byte)(126)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(210, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 63);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // rtxSearch
            // 
            this.rtxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxSearch.BackColor = System.Drawing.SystemColors.Window;
            this.rtxSearch.BorderColor = System.Drawing.Color.DimGray;
            this.rtxSearch.BorderFocusColor = System.Drawing.Color.DimGray;
            this.rtxSearch.BorderRadius = 0;
            this.rtxSearch.BorderSize = 1;
            this.rtxSearch.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtxSearch.ForeColor = System.Drawing.Color.Black;
            this.rtxSearch.Location = new System.Drawing.Point(1143, 32);
            this.rtxSearch.Multiline = false;
            this.rtxSearch.Name = "rtxSearch";
            this.rtxSearch.Padding = new System.Windows.Forms.Padding(7);
            this.rtxSearch.PasswordChar = false;
            this.rtxSearch.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rtxSearch.PlaceholderText = "MPN, \'*\' for any string of zero or more characters.";
            this.rtxSearch.Size = new System.Drawing.Size(380, 35);
            this.rtxSearch.TabIndex = 9;
            this.rtxSearch.Texts = "";
            this.rtxSearch.UnderlineStyle = false;
            this.rtxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxSearch_KeyPress);
            // 
            // ckbDateRange
            // 
            this.ckbDateRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbDateRange.AutoSize = true;
            this.ckbDateRange.Location = new System.Drawing.Point(659, 39);
            this.ckbDateRange.Name = "ckbDateRange";
            this.ckbDateRange.Size = new System.Drawing.Size(22, 21);
            this.ckbDateRange.TabIndex = 8;
            this.ckbDateRange.UseVisualStyleBackColor = true;
            this.ckbDateRange.CheckedChanged += new System.EventHandler(this.ckbDateRange_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(900, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "to";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Location = new System.Drawing.Point(687, 35);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(207, 30);
            this.dtpStartDate.TabIndex = 6;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Location = new System.Drawing.Point(930, 35);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(207, 30);
            this.dtpEndDate.TabIndex = 5;
            // 
            // dgvTransactionInfo
            // 
            this.dgvTransactionInfo.AllowUserToAddRows = false;
            this.dgvTransactionInfo.AllowUserToDeleteRows = false;
            this.dgvTransactionInfo.AllowUserToResizeColumns = false;
            this.dgvTransactionInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Bisque;
            this.dgvTransactionInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransactionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransactionInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactionInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransactionInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactionInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.lblMPN,
            this.lblPN,
            this.lblDESC,
            this.lblManufacturer,
            this.lblWarehouse,
            this.MoveType,
            this.Date,
            this.Stock});
            this.dgvTransactionInfo.GridColor = System.Drawing.Color.White;
            this.dgvTransactionInfo.Location = new System.Drawing.Point(40, 99);
            this.dgvTransactionInfo.MultiSelect = false;
            this.dgvTransactionInfo.Name = "dgvTransactionInfo";
            this.dgvTransactionInfo.ReadOnly = true;
            this.dgvTransactionInfo.RowHeadersWidth = 62;
            this.dgvTransactionInfo.RowTemplate.Height = 32;
            this.dgvTransactionInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactionInfo.Size = new System.Drawing.Size(1541, 517);
            this.dgvTransactionInfo.TabIndex = 0;
            this.dgvTransactionInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactionInfo_CellClick);
            this.dgvTransactionInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTransactionInfo_CellFormatting);
            this.dgvTransactionInfo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTransactionInfo_RowPostPaint);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 30;
            // 
            // lblMPN
            // 
            this.lblMPN.HeaderText = "MPN";
            this.lblMPN.MinimumWidth = 8;
            this.lblMPN.Name = "lblMPN";
            this.lblMPN.ReadOnly = true;
            this.lblMPN.Width = 150;
            // 
            // lblPN
            // 
            this.lblPN.HeaderText = "ICT P/N";
            this.lblPN.MinimumWidth = 8;
            this.lblPN.Name = "lblPN";
            this.lblPN.ReadOnly = true;
            this.lblPN.Width = 150;
            // 
            // lblDESC
            // 
            this.lblDESC.HeaderText = "DESC";
            this.lblDESC.MinimumWidth = 8;
            this.lblDESC.Name = "lblDESC";
            this.lblDESC.ReadOnly = true;
            this.lblDESC.Width = 150;
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.HeaderText = "Manufacturer";
            this.lblManufacturer.MinimumWidth = 8;
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.ReadOnly = true;
            this.lblManufacturer.Width = 150;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.HeaderText = "Location";
            this.lblWarehouse.MinimumWidth = 8;
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.ReadOnly = true;
            this.lblWarehouse.Width = 150;
            // 
            // MoveType
            // 
            this.MoveType.HeaderText = "MoveType";
            this.MoveType.MinimumWidth = 8;
            this.MoveType.Name = "MoveType";
            this.MoveType.ReadOnly = true;
            this.MoveType.Width = 150;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 8;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 150;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Issue Qty";
            this.Stock.MinimumWidth = 8;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 150;
            // 
            // pcbSearch
            // 
            this.pcbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbSearch.BackColor = System.Drawing.SystemColors.Control;
            this.pcbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbSearch.Image = ((System.Drawing.Image)(resources.GetObject("pcbSearch.Image")));
            this.pcbSearch.Location = new System.Drawing.Point(1522, 32);
            this.pcbSearch.Name = "pcbSearch";
            this.pcbSearch.Size = new System.Drawing.Size(57, 35);
            this.pcbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbSearch.TabIndex = 4;
            this.pcbSearch.TabStop = false;
            this.pcbSearch.Click += new System.EventHandler(this.pcbSearch_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(68)))), ((int)(((byte)(126)))));
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(40, 15);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(150, 63);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // FormTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1693, 797);
            this.Controls.Add(this.panelBoard);
            this.Controls.Add(this.panel1);
            this.Name = "FormTransaction";
            this.Text = "Transaction";
            this.panel1.ResumeLayout(false);
            this.panelBoard.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvTransactionInfo;
        private System.Windows.Forms.PictureBox pcbSearch;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn lblMPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn lblPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn lblDESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn lblManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn lblWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoveType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.CheckBox ckbDateRange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private RoundedTextBox rtxSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
    }
}