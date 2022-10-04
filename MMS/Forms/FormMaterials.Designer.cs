
namespace MMS.Forms
{
    partial class FormMaterial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMaterial));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBoard = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.rtxSearch = new MMS.RoundedTextBox();
            this.dgvMaterialInfo = new System.Windows.Forms.DataGridView();
            this.btnCreate = new System.Windows.Forms.Button();
            this.pcbSearch = new System.Windows.Forms.PictureBox();
            this.lblMPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDESC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbxGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lblWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitle.SuspendLayout();
            this.panelBoard.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.label1);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1199, 120);
            this.panelTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(68)))), ((int)(((byte)(126)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(66, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(1199, 120);
            this.label1.TabIndex = 2;
            this.label1.Text = "Material";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelBoard
            // 
            this.panelBoard.Controls.Add(this.panel1);
            this.panelBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBoard.Location = new System.Drawing.Point(0, 120);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(1199, 730);
            this.panelBoard.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.rtxSearch);
            this.panel1.Controls.Add(this.dgvMaterialInfo);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.pcbSearch);
            this.panel1.Location = new System.Drawing.Point(37, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1123, 696);
            this.panel1.TabIndex = 2;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(68)))), ((int)(((byte)(126)))));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(210, 15);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(150, 63);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
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
            this.rtxSearch.Location = new System.Drawing.Point(649, 32);
            this.rtxSearch.Multiline = false;
            this.rtxSearch.Name = "rtxSearch";
            this.rtxSearch.Padding = new System.Windows.Forms.Padding(7);
            this.rtxSearch.PasswordChar = false;
            this.rtxSearch.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rtxSearch.PlaceholderText = "MPN, \'*\' for any string of zero or more characters.";
            this.rtxSearch.Size = new System.Drawing.Size(380, 35);
            this.rtxSearch.TabIndex = 5;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaterialInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMaterialInfo.ColumnHeadersHeight = 40;
            this.dgvMaterialInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMaterialInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lblMPN,
            this.lblPN,
            this.lblDESC,
            this.lblManufacturer,
            this.cbxGroup,
            this.lblWarehouse});
            this.dgvMaterialInfo.GridColor = System.Drawing.Color.White;
            this.dgvMaterialInfo.Location = new System.Drawing.Point(40, 99);
            this.dgvMaterialInfo.MultiSelect = false;
            this.dgvMaterialInfo.Name = "dgvMaterialInfo";
            this.dgvMaterialInfo.ReadOnly = true;
            this.dgvMaterialInfo.RowHeadersWidth = 62;
            this.dgvMaterialInfo.RowTemplate.Height = 32;
            this.dgvMaterialInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterialInfo.Size = new System.Drawing.Size(1045, 572);
            this.dgvMaterialInfo.TabIndex = 0;
            this.dgvMaterialInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterialInfo_CellClick);
            this.dgvMaterialInfo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMaterialInfo_RowPostPaint);
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
            // pcbSearch
            // 
            this.pcbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbSearch.BackColor = System.Drawing.SystemColors.Control;
            this.pcbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbSearch.Image = ((System.Drawing.Image)(resources.GetObject("pcbSearch.Image")));
            this.pcbSearch.Location = new System.Drawing.Point(1028, 32);
            this.pcbSearch.Name = "pcbSearch";
            this.pcbSearch.Size = new System.Drawing.Size(57, 35);
            this.pcbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbSearch.TabIndex = 4;
            this.pcbSearch.TabStop = false;
            this.pcbSearch.Click += new System.EventHandler(this.pcbSearch_Click);
            // 
            // lblMPN
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.lblMPN.DefaultCellStyle = dataGridViewCellStyle3;
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
            // cbxGroup
            // 
            this.cbxGroup.HeaderText = "Group";
            this.cbxGroup.Items.AddRange(new object[] {
            "0-RES電阻類",
            "10-摄像头",
            "11-线材"});
            this.cbxGroup.MinimumWidth = 8;
            this.cbxGroup.Name = "cbxGroup";
            this.cbxGroup.ReadOnly = true;
            this.cbxGroup.Width = 150;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.HeaderText = "Location";
            this.lblWarehouse.MinimumWidth = 8;
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.ReadOnly = true;
            this.lblWarehouse.Width = 150;
            // 
            // FormMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1199, 850);
            this.Controls.Add(this.panelBoard);
            this.Controls.Add(this.panelTitle);
            this.Name = "FormMaterial";
            this.Text = "Materials";
            this.panelTitle.ResumeLayout(false);
            this.panelBoard.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.PictureBox pcbSearch;
        private System.Windows.Forms.DataGridView dgvMaterialInfo;
        private RoundedTextBox rtxSearch;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn lblMPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn lblPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn lblDESC;
        private System.Windows.Forms.DataGridViewTextBoxColumn lblManufacturer;
        private System.Windows.Forms.DataGridViewComboBoxColumn cbxGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn lblWarehouse;
    }
}