
namespace MMS.Forms
{
    partial class FormStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStock));
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panelBoard = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.rtxSearch = new MMS.RoundedTextBox();
            this.dgvMaterialInfo = new System.Windows.Forms.DataGridView();
            this.lblMPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcbSearch = new System.Windows.Forms.PictureBox();
            this.panelTitle.SuspendLayout();
            this.panelBoard.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(68)))), ((int)(((byte)(126)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(66, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(1181, 120);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Stock";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1181, 120);
            this.panelTitle.TabIndex = 4;
            // 
            // panelBoard
            // 
            this.panelBoard.Controls.Add(this.panel1);
            this.panelBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBoard.Location = new System.Drawing.Point(0, 120);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(1181, 375);
            this.panelBoard.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.rtxSearch);
            this.panel1.Controls.Add(this.dgvMaterialInfo);
            this.panel1.Controls.Add(this.pcbSearch);
            this.panel1.Location = new System.Drawing.Point(38, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1105, 339);
            this.panel1.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(68)))), ((int)(((byte)(126)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(40, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 63);
            this.btnExport.TabIndex = 7;
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
            this.rtxSearch.Location = new System.Drawing.Point(631, 32);
            this.rtxSearch.Multiline = false;
            this.rtxSearch.Name = "rtxSearch";
            this.rtxSearch.Padding = new System.Windows.Forms.Padding(7);
            this.rtxSearch.PasswordChar = false;
            this.rtxSearch.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rtxSearch.PlaceholderText = "MPN";
            this.rtxSearch.Size = new System.Drawing.Size(380, 35);
            this.rtxSearch.TabIndex = 6;
            this.rtxSearch.Texts = "";
            this.rtxSearch.UnderlineStyle = false;
            this.rtxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxSearch_KeyPress);
            // 
            // dgvMaterialInfo
            // 
            this.dgvMaterialInfo.AllowUserToAddRows = false;
            this.dgvMaterialInfo.AllowUserToDeleteRows = false;
            this.dgvMaterialInfo.AllowUserToResizeColumns = false;
            this.dgvMaterialInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Bisque;
            this.dgvMaterialInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMaterialInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMaterialInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvMaterialInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMaterialInfo.ColumnHeadersHeight = 40;
            this.dgvMaterialInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMaterialInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lblMPN,
            this.lblPN,
            this.lblDESC,
            this.lblManufacturer,
            this.lblWarehouse,
            this.Stock});
            this.dgvMaterialInfo.GridColor = System.Drawing.Color.White;
            this.dgvMaterialInfo.Location = new System.Drawing.Point(40, 99);
            this.dgvMaterialInfo.MultiSelect = false;
            this.dgvMaterialInfo.Name = "dgvMaterialInfo";
            this.dgvMaterialInfo.ReadOnly = true;
            this.dgvMaterialInfo.RowHeadersWidth = 62;
            this.dgvMaterialInfo.RowTemplate.Height = 32;
            this.dgvMaterialInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterialInfo.Size = new System.Drawing.Size(1027, 213);
            this.dgvMaterialInfo.TabIndex = 0;
            this.dgvMaterialInfo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMaterialInfo_RowPostPaint);
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
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
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
            this.pcbSearch.Location = new System.Drawing.Point(1010, 32);
            this.pcbSearch.Name = "pcbSearch";
            this.pcbSearch.Size = new System.Drawing.Size(57, 35);
            this.pcbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbSearch.TabIndex = 4;
            this.pcbSearch.TabStop = false;
            this.pcbSearch.Click += new System.EventHandler(this.pcbSearch_Click);
            // 
            // FormStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1181, 495);
            this.Controls.Add(this.panelBoard);
            this.Controls.Add(this.panelTitle);
            this.Name = "FormStock";
            this.Text = "Stock";
            this.panelTitle.ResumeLayout(false);
            this.panelBoard.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvMaterialInfo;
        private System.Windows.Forms.PictureBox pcbSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn lblMPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn lblPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn lblDESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn lblManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn lblWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private RoundedTextBox rtxSearch;
        private System.Windows.Forms.Button btnExport;
    }
}