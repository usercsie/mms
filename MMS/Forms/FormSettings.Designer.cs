
namespace MMS.Forms
{
    partial class FormSettings
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
            this.dgvMoveTypeParameter = new System.Windows.Forms.DataGridView();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMoveType = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxOperator = new System.Windows.Forms.ComboBox();
            this.btnAddMoveType = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvGroupParameter = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoveTypeParameter)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupParameter)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMoveTypeParameter
            // 
            this.dgvMoveTypeParameter.AllowUserToAddRows = false;
            this.dgvMoveTypeParameter.AllowUserToDeleteRows = false;
            this.dgvMoveTypeParameter.AllowUserToResizeColumns = false;
            this.dgvMoveTypeParameter.AllowUserToResizeRows = false;
            this.dgvMoveTypeParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMoveTypeParameter.BackgroundColor = System.Drawing.Color.White;
            this.dgvMoveTypeParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMoveTypeParameter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colType,
            this.colDesc,
            this.colOperator});
            this.dgvMoveTypeParameter.Location = new System.Drawing.Point(22, 18);
            this.dgvMoveTypeParameter.MultiSelect = false;
            this.dgvMoveTypeParameter.Name = "dgvMoveTypeParameter";
            this.dgvMoveTypeParameter.ReadOnly = true;
            this.dgvMoveTypeParameter.RowHeadersVisible = false;
            this.dgvMoveTypeParameter.RowHeadersWidth = 62;
            this.dgvMoveTypeParameter.RowTemplate.Height = 32;
            this.dgvMoveTypeParameter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMoveTypeParameter.Size = new System.Drawing.Size(568, 405);
            this.dgvMoveTypeParameter.TabIndex = 0;
            this.dgvMoveTypeParameter.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMoveTypeParameter_CellClick);
            // 
            // colType
            // 
            this.colType.HeaderText = "Move Type";
            this.colType.MinimumWidth = 8;
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 150;
            // 
            // colDesc
            // 
            this.colDesc.HeaderText = "DESC";
            this.colDesc.MinimumWidth = 8;
            this.colDesc.Name = "colDesc";
            this.colDesc.ReadOnly = true;
            this.colDesc.Width = 150;
            // 
            // colOperator
            // 
            this.colOperator.HeaderText = "Operator";
            this.colOperator.MinimumWidth = 8;
            this.colOperator.Name = "colOperator";
            this.colOperator.ReadOnly = true;
            this.colOperator.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 442);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Move Type";
            // 
            // txtMoveType
            // 
            this.txtMoveType.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMoveType.Location = new System.Drawing.Point(328, 439);
            this.txtMoveType.Name = "txtMoveType";
            this.txtMoveType.Size = new System.Drawing.Size(262, 33);
            this.txtMoveType.TabIndex = 4;
            this.txtMoveType.Text = "101";
            // 
            // txtDesc
            // 
            this.txtDesc.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDesc.Location = new System.Drawing.Point(328, 478);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(262, 33);
            this.txtDesc.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(22, 481);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "DESC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(22, 517);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Operator";
            // 
            // cbxOperator
            // 
            this.cbxOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOperator.FormattingEnabled = true;
            this.cbxOperator.Items.AddRange(new object[] {
            "+",
            "-"});
            this.cbxOperator.Location = new System.Drawing.Point(328, 517);
            this.cbxOperator.Name = "cbxOperator";
            this.cbxOperator.Size = new System.Drawing.Size(262, 31);
            this.cbxOperator.TabIndex = 8;
            // 
            // btnAddMoveType
            // 
            this.btnAddMoveType.Location = new System.Drawing.Point(465, 563);
            this.btnAddMoveType.Name = "btnAddMoveType";
            this.btnAddMoveType.Size = new System.Drawing.Size(125, 47);
            this.btnAddMoveType.TabIndex = 9;
            this.btnAddMoveType.Text = "Add";
            this.btnAddMoveType.UseVisualStyleBackColor = true;
            this.btnAddMoveType.Click += new System.EventHandler(this.btnAddMoveType_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(621, 666);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvMoveTypeParameter);
            this.tabPage1.Controls.Add(this.btnAddMoveType);
            this.tabPage1.Controls.Add(this.txtMoveType);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtDesc);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cbxOperator);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(613, 630);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Move Type";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddGroup);
            this.tabPage2.Controls.Add(this.txtGroup);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.dgvGroupParameter);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(613, 630);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Group";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(465, 488);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(125, 47);
            this.btnAddGroup.TabIndex = 12;
            this.btnAddGroup.Text = "Add";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // txtGroup
            // 
            this.txtGroup.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtGroup.Location = new System.Drawing.Point(328, 439);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(262, 33);
            this.txtGroup.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(22, 442);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Group";
            // 
            // dgvGroupParameter
            // 
            this.dgvGroupParameter.AllowUserToAddRows = false;
            this.dgvGroupParameter.AllowUserToDeleteRows = false;
            this.dgvGroupParameter.AllowUserToResizeColumns = false;
            this.dgvGroupParameter.AllowUserToResizeRows = false;
            this.dgvGroupParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGroupParameter.BackgroundColor = System.Drawing.Color.White;
            this.dgvGroupParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupParameter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgvGroupParameter.Location = new System.Drawing.Point(22, 18);
            this.dgvGroupParameter.MultiSelect = false;
            this.dgvGroupParameter.Name = "dgvGroupParameter";
            this.dgvGroupParameter.ReadOnly = true;
            this.dgvGroupParameter.RowHeadersVisible = false;
            this.dgvGroupParameter.RowHeadersWidth = 62;
            this.dgvGroupParameter.RowTemplate.Height = 32;
            this.dgvGroupParameter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroupParameter.Size = new System.Drawing.Size(568, 405);
            this.dgvGroupParameter.TabIndex = 1;
            this.dgvGroupParameter.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroupParameter_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(621, 666);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoveTypeParameter)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupParameter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMoveTypeParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMoveType;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxOperator;
        private System.Windows.Forms.Button btnAddMoveType;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvGroupParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}