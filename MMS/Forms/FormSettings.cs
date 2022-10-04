using MMS.Controller;
using MMS.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MMS.Forms
{
    public partial class FormSettings : Form
    {
        private SettingsController _Controller;

        private int MoveTypeDeleteColumnIndex
        {
            get { return dgvMoveTypeParameter.Columns["btnDelete"].Index; }
        }
        private int GroupDeleteColumnIndex
        {
            get { return dgvGroupParameter.Columns["btnDelete"].Index; }
        }


        public FormSettings()
        {
            InitializeComponent();
            InitializeCombobox();
            _Controller = new SettingsController(AppInitializer.Instance.UserSettingPath);
        }

        private void InitializeCombobox()
        {
            cbxOperator.Items.Clear();
            cbxOperator.Items.Add("+");
            cbxOperator.Items.Add("-");
            cbxOperator.SelectedIndex = 0;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            LoadDataFromSettings();
        }

        private void LoadDataFromSettings()
        {          
            //Move type
            dgvMoveTypeParameter.Columns.Clear();
            dgvMoveTypeParameter.DataSource = _Controller.CreateMoveTypeTable(Settings.Instance.GetMoveTypeParameters());            
            dgvMoveTypeParameter.Columns.Add(CreateColumnButton("btnDelete", "Delete"));

            for (int n = 0; n < dgvMoveTypeParameter.Columns.Count; n++)
            {
                dgvMoveTypeParameter.Columns[n].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvMoveTypeParameter.Columns["DESC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Group
            dgvGroupParameter.Columns.Clear();
            dgvGroupParameter.DataSource = _Controller.CreateGroupTable(Settings.Instance.GetMaterialGroups());
            dgvGroupParameter.Columns.Add(CreateColumnButton("btnDelete", "Delete"));
            dgvGroupParameter.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGroupParameter.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private DataGridViewButtonColumn CreateColumnButton(string name, string text)
        {
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            button.HeaderText = "";
            button.Text = text;
            button.Name = name;
            button.UseColumnTextForButtonValue = true;
            return button;
        }

        private void dgvMoveTypeParameter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex == MoveTypeDeleteColumnIndex)
            {
                if (Settings.Instance.DataAccesible == false)
                {
                    MessageBoxEx.ShowWarning("Only manager can perform the operation.");
                    return;
                }
                if (MessageBox.Show($"Do you want to DELETE the parameter?", "Question",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DataTable dt = _Controller.Delete(Setting.SettingType.MoveType, e.RowIndex);
                        dgvMoveTypeParameter.DataSource = dt;
                    }
                    catch(Exception ex)
                    {
                        MessageBoxEx.ShowOperationError(ex);
                    }
                }
            }
        }

        private void btnAddMoveType_Click(object sender, EventArgs e)
        {
            if (Settings.Instance.DataAccesible == false)
            {
                MessageBoxEx.ShowWarning("Only manager can perform the operation.");
                return;
            }

            string desc = txtDesc.Text;
            string op = cbxOperator.Text;
            try
            {
                uint moveType = Convert.ToUInt32(txtMoveType.Text);
                var dt = _Controller.Add(new Setting.MoveTypeParam() { Id = moveType, Desc = desc, Operator = op });
                dgvMoveTypeParameter.DataSource = dt;
            }
            catch(FormatException)
            {
                MessageBoxEx.ShowError("Move Type must be numeric format.");
            }
            catch(Exception ex)
            {
                MessageBoxEx.ShowOperationError(ex);
            }
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Instance.SetMaterialGroupParameter(_Controller.GroupParameter);
            Settings.Instance.SetMoveTypeParameter(_Controller.MoveTypeParameter);
        }

        private void dgvGroupParameter_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex == GroupDeleteColumnIndex)
            {
                if (Settings.Instance.DataAccesible == false)
                {
                    MessageBoxEx.ShowWarning("Only manager can perform the operation.");
                    return;
                }
                if (MessageBox.Show($"Do you want to DELETE the parameter?", "Question",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DataTable dt = _Controller.Delete(Setting.SettingType.Group, e.RowIndex);
                        dgvGroupParameter.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBoxEx.ShowOperationError(ex);
                    }
                }
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            if (Settings.Instance.DataAccesible == false)
            {
                MessageBoxEx.ShowWarning("Only manager can perform the operation.");
                return;
            }
            try
            {
                string name = txtGroup.Text;
                var dt = _Controller.Add(name);
                dgvGroupParameter.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBoxEx.ShowOperationError(ex);
            }
        }
    }
}
