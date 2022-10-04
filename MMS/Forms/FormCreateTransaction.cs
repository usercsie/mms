using MMS.Controller;
using MMS.Model;
using MMS.Setting;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MMS.Forms
{
    public partial class FormCreateTransaction : Form
    {
        private MaterialController _MaterialController;
        private string _CurrentId;

        private TransactionModel _ReturnValue;

        private string MPN
        {
            get { return txtMpn.Text.Trim(); }
        }

        public TransactionModel Result
        {
            get { return _ReturnValue; }
        }

        public FormCreateTransaction(MaterialController controller)
        {
            _MaterialController = controller;
            _CurrentId = null;

            InitializeComponent();
            InitMoveTypeCombobox();

            ResetUI();
        }
        public FormCreateTransaction(MaterialController controller, TransactionRecord record)
            : this(controller)
        {
            UpdateUIForEditing();
            UpdateUI(record);
            _CurrentId = record.Id;
        }

        private void UpdateUIForEditing()
        {
            txtMpn.Enabled = false;
            btnExecute.Text = "Update";
            Text = "Edit Transaction";
        }

        private void ResetUI()
        {
            txtIctPn.Text = "";
            txtDesc.Text = "";
            txtManufacturer.Text = "";
            txtLocation.Text = "";
            btnExecute.Enabled = false;
        }
        private void UpdateUI(TransactionRecord model)
        {
            txtMpn.Text = model.MPN;
            txtIctPn.Text = model.PN;
            txtDesc.Text = model.DESC;
            txtManufacturer.Text = model.Manufacturer;
            txtLocation.Text = model.Warehouse;
            cbxMoveType.SelectedIndex = Settings.Instance.GetMoveTypeIds().ToList().FindIndex(v => v == model.MoveType);
            dtpDate.Value = DateTime.Parse(model.Date);
            nudStock.Value = Math.Abs(model.Stock);
            
            btnExecute.Enabled = true;
        }

        private void InitMoveTypeCombobox()
        {
            cbxMoveType.Items.Clear();

            foreach (var g in Settings.Instance.GetMoveTypeParameters())
            {
                cbxMoveType.Items.Add(TransactionController.ToFullMoveType(g));
            }

            cbxMoveType.SelectedIndex = 0;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MPN) == true)
            {
                MessageBox.Show("MPN field must not be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetUI();
                return;
            }
            if (_MaterialController.SelectData(MPN).Count == 0)
            {
                MessageBox.Show($"Material [{MPN}] not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetUI();
                return;
            }

            if (string.IsNullOrEmpty(_CurrentId))
            {
                _ReturnValue = new TransactionModel(this.MPN, TransactionController.ParseMoveTypeId(cbxMoveType.Text),
                    (uint)nudStock.Value, TransactionModel.ToDate(dtpDate.Value));
            }
            else
                _ReturnValue = new TransactionModel(_CurrentId, this.MPN, TransactionController.ParseMoveTypeId(cbxMoveType.Text),
                    (uint)nudStock.Value, TransactionModel.ToDate(dtpDate.Value));

            DialogResult = DialogResult.OK;
        }

        private void txtMpn_KeyPress(object sender, KeyPressEventArgs e)
        {
            string mpn = MPN;

            if (string.IsNullOrEmpty(mpn) == true)
            {
                return;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                var material = _MaterialController.GetData(mpn);
                if (material == null)
                {
                    MessageBox.Show($"Material [{mpn}] is not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetUI();
                }
                else
                {
                    UpdateMaterialInfo(material);
                }
            }
        }

        private void UpdateMaterialInfo(MaterialModel model)
        {
            txtMpn.Text = model.MPN;
            txtIctPn.Text = model.PN;
            txtDesc.Text = model.DESC;
            txtManufacturer.Text = model.Manufacturer;
            txtLocation.Text = model.Warehouse;

            btnExecute.Enabled = true;
        }
    }
}
