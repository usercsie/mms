using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MMS.Forms
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void pbLogin_Click(object sender, EventArgs e)
        {
            FormLogin form = new FormLogin();
            if (form.ShowDialog() == DialogResult.OK)
            {
                lbUser.Text = form.CurrentUser.ToString();
                Settings.Instance.CurrentUser = form.CurrentUser;
            }
        }
    }
}
