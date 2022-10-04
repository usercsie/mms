using MMS.Controller;
using MMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using MMS.Extensions;
using System.Drawing;
using MMS.Themes;

namespace MMS.Forms
{

    public partial class FormMaterial : Form
    {
        private MaterialController _MaterialController;       

        private int EditColumnIndex
        {
            get { return dgvMaterialInfo.Columns["btnEdit"].Index; }
        }
        private int DeleteColumnIndex
        {
            get { return dgvMaterialInfo.Columns["btnDelete"].Index; }
        }
        private int MPNColumnIndex
        {
            get { return dgvMaterialInfo.Columns["MPN"].Index; }
        }

        public FormMaterial(MaterialController materialController)
        {
            InitializeComponent();

            _MaterialController = materialController;            

            LoadDataFromDB();            
        }

        private void LoadDataFromDB(string mpn = "")
        {
            Cursor.Current = Cursors.WaitCursor;

            List<MaterialModel> models = _MaterialController.SelectData(mpn);

            dgvMaterialInfo.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(ThemeColor.ColumnBackColor);
            dgvMaterialInfo.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(ThemeColor.ColumnForeColor);
            dgvMaterialInfo.ColumnHeadersDefaultCellStyle.Font = ThemeFont.GetColumnHeaderFont();
            dgvMaterialInfo.ColumnHeadersHeight = 40;
            dgvMaterialInfo.EnableHeadersVisualStyles = false;
            dgvMaterialInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvMaterialInfo.Columns.Clear();
            dgvMaterialInfo.DataSource = CreateDataTable(models.ToArray());
            
            dgvMaterialInfo.Columns.Add(CreateColumnButton("btnEdit", "Edit"));
            dgvMaterialInfo.Columns.Add(CreateColumnButton("btnDelete", "Delete"));

            for (int n = 0; n < dgvMaterialInfo.Columns.Count - 2; n++)
            {
                dgvMaterialInfo.Columns[n].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMaterialInfo.Columns[n].DefaultCellStyle.Font = ThemeFont.GetCellFont();
            }
            dgvMaterialInfo.Columns[dgvMaterialInfo.Columns.Count - 1].Width = 100;
            dgvMaterialInfo.Columns[dgvMaterialInfo.Columns.Count - 2].Width = 100;

            dgvMaterialInfo.Columns["DESC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Cursor.Current = Cursors.Default;
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

        private DataTable CreateDataTable(MaterialModel[] models)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MPN", typeof(string));
            dt.Columns.Add("ICTP/N", typeof(string));
            dt.Columns.Add("DESC", typeof(string));
            dt.Columns.Add("Manufacture", typeof(string));
            dt.Columns.Add("Group", typeof(string));
            dt.Columns.Add("Location", typeof(string));               

            foreach (var model in models)
            {
                dt.Rows.Add(new object[]
                {
                    model.MPN,
                    model.PN,
                    model.DESC,
                    model.Manufacturer,
                    model.Flock,
                    model.Warehouse,                                        
                });
            }
            return dt;
        }

        private void dgvMaterialInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.ColumnIndex == EditColumnIndex)
            {
                if (Settings.Instance.DataAccesible == false)
                {
                    MessageBoxEx.ShowWarning("Only manager can perform the operation.");
                    return;
                }
                string mpn = GetMpn(e.RowIndex);
                MaterialModel model = _MaterialController.GetData(mpn);
                using (FormCreateMaterial form = new FormCreateMaterial(model))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            _MaterialController.SetData(form.Result);
                            UpdateDataTableByEditing(e.RowIndex, form.Result);                           
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBoxEx.ShowSQLWarning(ex);
                        }
                        catch (Exception ex)
                        {
                            MessageBoxEx.ShowOperationError(ex);
                        }
                    }
                }
            }
            else if (e.ColumnIndex == DeleteColumnIndex)
            {
                if (Settings.Instance.DataAccesible == false)
                {
                    MessageBoxEx.ShowWarning("Only manager can perform the operation.");
                    return;
                }
                string mpn = GetMpn(e.RowIndex);
                if (MessageBox.Show($"Do you want to DELETE [{mpn}] material?", "Question",                    
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    { 
                        _MaterialController.DeleteData(mpn);
                        UpdateDataTableByDeleting(e.RowIndex);
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBoxEx.ShowOperationError(ex);
                    }
                    catch (Exception ex)
                    {
                        MessageBoxEx.ShowOperationError(ex);
                    }
                }
            }            
        }

        private void UpdateDataTableByDeleting(int rowIndex)
        {
            DataTable dt = (DataTable)dgvMaterialInfo.DataSource;
            dt.Rows[rowIndex].Delete();
        }

        private void UpdateDataTableByEditing(int rowIndex, MaterialModel model)
        {
            DataTable dt = (DataTable)dgvMaterialInfo.DataSource;
            dt.Rows[rowIndex].ItemArray = new object[]
            {
                model.MPN,
                model.PN,
                model.DESC,
                model.Manufacturer,
                model.Flock,
                model.Warehouse,
            };
        }

        private string GetMpn(int rowIndex)
        {                        
            return dgvMaterialInfo.Rows[rowIndex].Cells[MPNColumnIndex].Value.ToString();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Settings.Instance.DataAccesible == false)
            {
                MessageBoxEx.ShowWarning("Only manager can perform the operation.");
                return;
            }
            using (FormCreateMaterial form = new FormCreateMaterial())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _MaterialController.AddData(form.Result);
                        LoadDataFromDB();
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBoxEx.ShowSQLWarning(ex);                        
                    }
                    catch (Exception ex)
                    {
                        MessageBoxEx.ShowOperationError(ex);                        
                    }                                        
                }
            }
        }

        private void pcbSearch_Click(object sender, EventArgs e)
        {
            LoadDataFromDB(rtxSearch.Text.Trim());
        }

        private void rtxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                LoadDataFromDB(rtxSearch.Texts.Trim());
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (Settings.Instance.DataAccesible == false)
            {
                MessageBoxEx.ShowWarning("Only manager can perform the operation.");
                return;
            }
            if (MessageBox.Show("The operation will overwrite the material data if MPN existed already, do you want to continue?",
                "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Import";
                dialog.Filter = "Excel file(*.*)|*.xlsx";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        _MaterialController.Import(dialog.FileName);
                        LoadDataFromDB();
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Materials import completed.");
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBoxEx.ShowError($"Failed to import material file:{ex.Message}");
                    }
                }
            }
            
        }

        private void dgvMaterialInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}
