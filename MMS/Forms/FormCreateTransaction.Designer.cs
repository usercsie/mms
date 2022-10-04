
namespace MMS.Forms
{
    partial class FormCreateTransaction
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
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIctPn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMpn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMoveType = new System.Windows.Forms.Label();
            this.cbxMoveType = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblStock = new System.Windows.Forms.Label();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(444, 577);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(163, 48);
            this.btnExecute.TabIndex = 31;
            this.btnExecute.Text = "Create";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Enabled = false;
            this.txtLocation.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLocation.Location = new System.Drawing.Point(35, 361);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(572, 30);
            this.txtLocation.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(35, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 28;
            this.label2.Text = "Location";
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Enabled = false;
            this.txtManufacturer.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtManufacturer.Location = new System.Drawing.Point(35, 281);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(572, 30);
            this.txtManufacturer.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(30, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 23);
            this.label9.TabIndex = 25;
            this.label9.Text = "Manufacturer";
            // 
            // txtDesc
            // 
            this.txtDesc.Enabled = false;
            this.txtDesc.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDesc.Location = new System.Drawing.Point(35, 205);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(572, 30);
            this.txtDesc.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(30, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 23);
            this.label8.TabIndex = 23;
            this.label8.Text = "DESC";
            // 
            // txtIctPn
            // 
            this.txtIctPn.Enabled = false;
            this.txtIctPn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIctPn.Location = new System.Drawing.Point(35, 131);
            this.txtIctPn.Name = "txtIctPn";
            this.txtIctPn.Size = new System.Drawing.Size(572, 30);
            this.txtIctPn.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(30, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 23);
            this.label7.TabIndex = 21;
            this.label7.Text = "ICT P/N";
            // 
            // txtMpn
            // 
            this.txtMpn.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMpn.Location = new System.Drawing.Point(35, 53);
            this.txtMpn.Name = "txtMpn";
            this.txtMpn.Size = new System.Drawing.Size(572, 30);
            this.txtMpn.TabIndex = 20;
            this.txtMpn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMpn_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(35, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 19;
            this.label1.Text = "*MPN";
            // 
            // lblMoveType
            // 
            this.lblMoveType.AutoSize = true;
            this.lblMoveType.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMoveType.Location = new System.Drawing.Point(35, 414);
            this.lblMoveType.Name = "lblMoveType";
            this.lblMoveType.Size = new System.Drawing.Size(97, 23);
            this.lblMoveType.TabIndex = 32;
            this.lblMoveType.Text = "MoveType";
            // 
            // cbxMoveType
            // 
            this.cbxMoveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMoveType.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxMoveType.FormattingEnabled = true;
            this.cbxMoveType.Location = new System.Drawing.Point(35, 440);
            this.cbxMoveType.Name = "cbxMoveType";
            this.cbxMoveType.Size = new System.Drawing.Size(269, 31);
            this.cbxMoveType.TabIndex = 33;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDate.Location = new System.Drawing.Point(322, 414);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(51, 23);
            this.lblDate.TabIndex = 34;
            this.lblDate.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(322, 440);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(285, 30);
            this.dtpDate.TabIndex = 35;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStock.Location = new System.Drawing.Point(322, 492);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(88, 23);
            this.lblStock.TabIndex = 36;
            this.lblStock.Text = "Issue Qty";
            // 
            // nudStock
            // 
            this.nudStock.Location = new System.Drawing.Point(322, 518);
            this.nudStock.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudStock.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(285, 30);
            this.nudStock.TabIndex = 38;
            this.nudStock.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormCreateTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 644);
            this.Controls.Add(this.nudStock);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cbxMoveType);
            this.Controls.Add(this.lblMoveType);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtManufacturer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIctPn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMpn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCreateTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Transaction";
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIctPn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMpn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMoveType;
        private System.Windows.Forms.ComboBox cbxMoveType;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown nudStock;
    }
}