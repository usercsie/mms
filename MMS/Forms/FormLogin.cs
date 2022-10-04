using MMS.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MMS.Forms
{
    public partial class FormLogin : Form
    {
        LoginController _Controller = new LoginController();

        LoginUser _CurrentUser = LoginUser.Viewer;
        public LoginUser CurrentUser
        {
            get { return _CurrentUser; }
        }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            cbxAccount.Items.Clear();
            foreach(var user in _Controller.AvailableUsers)
            {
                cbxAccount.Items.Add(user);
            }
            cbxAccount.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Login();
        }
        private void rtbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Login();
            }
        }
        private void Login()
        {
            LoginUser user = (LoginUser)cbxAccount.SelectedIndex;

            if (_Controller.Login(user, rtbPassword.Texts) == true)
            {
                _CurrentUser = user;
                MessageBox.Show("Login success.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();                
            }
            else
            {
                MessageBox.Show("Wrong password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbxAccount_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //rtbPassword.Enabled = cbxAccount.SelectedIndex > 0;
        }


    }
}
