using MMS.Model;
using System;
using System.Windows.Forms;
using System.Linq;

namespace MMS.Forms
{
    public partial class FormCreateMaterial : Form
    {
        private MaterialModel _ReturnValue;

        public MaterialModel Result
        {
            get { return _ReturnValue; }
        }

        //create material
        public FormCreateMaterial()
        {
            InitializeComponent();
            InitGroup();
            txtMpn.Enabled = true;
        }

        //update material
        public FormCreateMaterial(MaterialModel model)
            :this()
        {
            UpdateUIForEditing();
            UpdateUI(model);
        }

        private void UpdateUIForEditing()
        {
            txtMpn.Enabled = false;            
            btnSave.Text = "Update";
            Text = "Edit Material";
        }

        private void UpdateUI(MaterialModel model)
        {
            txtMpn.Text = model.MPN;
            txtIctPn.Text = model.PN;
            txtDesc.Text = model.DESC;
            txtManufacturer.Text = model.Manufacturer;
            txtLocation.Text = model.Warehouse;
            cbxGroup.SelectedIndex = Settings.Instance.GetMaterialGroups().ToList().FindIndex(v => v == model.Flock);            
        }       

        private void InitGroup()
        {
            cbxGroup.Items.Clear();

            foreach(var g in Settings.Instance.GetMaterialGroups())
            {
                cbxGroup.Items.Add(g);
            }

            cbxGroup.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMpn.Text.Trim()) == true)
            {
                MessageBox.Show("MPN field must not be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMpn.Focus();
                return;
            }
            if(txtMpn.Text.Contains('*') == true)
            {
                MessageBox.Show("MPN field cannot input * character!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMpn.SelectAll();
                txtMpn.Focus();
                return;
            }

            _ReturnValue = new MaterialModel()
            {
                MPN = txtMpn.Text.Trim(),
                PN = txtIctPn.Text.Trim(),
                DESC = txtDesc.Text,
                Manufacturer = txtManufacturer.Text,
                Warehouse = txtLocation.Text,
                Flock = cbxGroup.Text
            };
            DialogResult = DialogResult.OK;
        }
    }
}
