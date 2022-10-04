
namespace MMS.Forms
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.rtbPassword = new MMS.RoundedTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.cbxAccount = new MMS.Extensions.Controls.CustomCombobox();
            this.btnOK = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbPassword
            // 
            this.rtbPassword.BackColor = System.Drawing.SystemColors.Window;
            this.rtbPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.rtbPassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.rtbPassword.BorderRadius = 0;
            this.rtbPassword.BorderSize = 2;
            this.rtbPassword.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbPassword.ForeColor = System.Drawing.Color.DimGray;
            this.rtbPassword.Location = new System.Drawing.Point(115, 106);
            this.rtbPassword.Multiline = false;
            this.rtbPassword.Name = "rtbPassword";
            this.rtbPassword.Padding = new System.Windows.Forms.Padding(7);
            this.rtbPassword.PasswordChar = true;
            this.rtbPassword.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rtbPassword.PlaceholderText = "Password";
            this.rtbPassword.Size = new System.Drawing.Size(377, 43);
            this.rtbPassword.TabIndex = 1;
            this.rtbPassword.Texts = "";
            this.rtbPassword.UnderlineStyle = false;
            this.rtbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbPassword_KeyPress);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(50, 106);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(50, 39);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 43);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // cbxAccount
            // 
            this.cbxAccount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbxAccount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.cbxAccount.BorderSize = 2;
            this.cbxAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAccount.ForeColor = System.Drawing.Color.DimGray;
            this.cbxAccount.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.cbxAccount.Items.AddRange(new object[] {
            "Viewer",
            "Manager"});
            this.cbxAccount.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbxAccount.ListTextColor = System.Drawing.Color.DimGray;
            this.cbxAccount.Location = new System.Drawing.Point(115, 39);
            this.cbxAccount.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbxAccount.Name = "cbxAccount";
            this.cbxAccount.Padding = new System.Windows.Forms.Padding(2);
            this.cbxAccount.Size = new System.Drawing.Size(377, 45);
            this.cbxAccount.TabIndex = 5;
            this.cbxAccount.Texts = "";
            this.cbxAccount.OnSelectedIndexChanged += new System.EventHandler(this.cbxAccount_OnSelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(319, 178);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(173, 58);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Login";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 262);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbxAccount);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.rtbPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private RoundedTextBox rtbPassword;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Extensions.Controls.CustomCombobox cbxAccount;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}