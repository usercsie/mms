using MMS.Controller;
using MMS.Extensions;
using MMS.Model;
using MMS.Reporting;
using MMS.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MMS.Forms
{
    public partial class FormStock : Form
    {
        private MaterialController _MaterialController;
        private TransactionController _TransactionController;

        private int MPNColumnIndex
        {
            get { return dgvMaterialInfo.Columns["MPN"].Index; }
        }

        public FormStock(TransactionController transactionController, MaterialController materialController)
        {
            _MaterialController = materialController;
            _TransactionController = transactionController;

            InitializeComponent();

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

            for (int n = 0; n < dgvMaterialInfo.Columns.Count; n++)
            {
                dgvMaterialInfo.Columns[n].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMaterialInfo.Columns[n].DefaultCellStyle.Font = ThemeFont.GetCellFont();
            }

            dgvMaterialInfo.Columns["DESC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Cursor.Current = Cursors.Default;
        }

        private DataTable CreateDataTable(MaterialModel[] models)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MPN", typeof(string));
            dt.Columns.Add("ICTP/N", typeof(string));
            dt.Columns.Add("DESC", typeof(string));
            dt.Columns.Add("Manufacture", typeof(string));            
            dt.Columns.Add("Location", typeof(string));
            dt.Columns.Add("Stock", typeof(int));

            foreach (var model in models)
            {
                dt.Rows.Add(new object[]
                {
                    model.MPN,
                    model.PN,
                    model.DESC,
                    model.Manufacturer,
                    model.Warehouse,
                    _TransactionController.GetStock(model.MPN)
                }); ;
            }
            return dt;
        }

        private void pcbSearch_Click(object sender, EventArgs e)
        {
            LoadDataFromDB(rtxSearch.Texts.Trim());
        }

        private void rtxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                LoadDataFromDB(rtxSearch.Texts.Trim());
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Export";
                dialog.Filter = "csv file(*.*)|*.csv";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var reporter = CsvReportFactory.Create(CsvReportFactory.CsvReportType.Stock);
                        reporter.Save((DataTable)dgvMaterialInfo.DataSource, dialog.FileName);
                        MessageBox.Show("Save material stock sucessfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBoxEx.ShowOperationError(ex);
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
