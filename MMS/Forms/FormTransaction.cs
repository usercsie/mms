using MMS.Controller;
using MMS.Extensions;
using MMS.Reporting;
using MMS.Themes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace MMS.Forms
{
    public partial class FormTransaction : Form
    {
        private MaterialController _MaterialController;
        private TransactionController _TransactionController;

        private int EditColumnIndex
        {
            get { return dgvTransactionInfo.Columns["btnEdit"].Index; }
        }
        private int DeleteColumnIndex
        {
            get { return dgvTransactionInfo.Columns["btnDelete"].Index; }
        }
        private int MPNColumnIndex
        {
            get { return dgvTransactionInfo.Columns["MPN"].Index; }
        }
        private int StockColumnIndex
        {
            get { return dgvTransactionInfo.Columns["Issue Qty"].Index; }
        }

        private int IdColumnIndex
        {
            get { return dgvTransactionInfo.Columns["Id"].Index; }
        }
        public FormTransaction(TransactionController transactionController, MaterialController materialController)
        {
            _TransactionController = transactionController;
            _MaterialController = materialController;
            InitializeComponent();

            LoadDataFromDB();
        }

        private void LoadDataFromDB(string mpn = "")
        {
            Cursor.Current = Cursors.WaitCursor;

            List<TransactionRecord> models = GetTransactionRecords(mpn);

            dgvTransactionInfo.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(ThemeColor.ColumnBackColor);
            dgvTransactionInfo.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(ThemeColor.ColumnForeColor);
            dgvTransactionInfo.ColumnHeadersDefaultCellStyle.Font = ThemeFont.GetColumnHeaderFont();
            dgvTransactionInfo.ColumnHeadersHeight = 40;
            dgvTransactionInfo.EnableHeadersVisualStyles = false;
            dgvTransactionInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            dgvTransactionInfo.Columns.Clear();
            dgvTransactionInfo.DataSource = CreateDataTable(models.ToArray());

            dgvTransactionInfo.Columns.Add(CreateColumnButton("btnEdit", "Edit"));
            dgvTransactionInfo.Columns.Add(CreateColumnButton("btnDelete", "Delete"));

            for (int n = 0; n < dgvTransactionInfo.Columns.Count - 2; n++)
            {
                dgvTransactionInfo.Columns[n].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvTransactionInfo.Columns[n].DefaultCellStyle.Font = ThemeFont.GetCellFont();
            }
            dgvTransactionInfo.Columns[dgvTransactionInfo.Columns.Count - 1].Width = 100;
            dgvTransactionInfo.Columns[dgvTransactionInfo.Columns.Count - 2].Width = 100;

            dgvTransactionInfo.Columns["DESC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //hide column "Id"
            dgvTransactionInfo.Columns["Id"].Visible = false;

            Cursor.Current = Cursors.Default;
        }

        private List<TransactionRecord> GetTransactionRecords(string mpn)
        {
            bool dateRange = ckbDateRange.Checked;

            List<TransactionRecord> models;
            if (mpn == "")
            {
                if (dateRange == true)
                {
                    models = _TransactionController.GetTransactionRecords(dtpStartDate.Value, dtpEndDate.Value);
                }
                else
                    models = _TransactionController.GetTransactionRecords();
            }
            else
            {
                if (dateRange == true)
                {
                    models = _TransactionController.GetTransactionRecords(mpn, dtpStartDate.Value, dtpEndDate.Value);
                }
                else
                    models = _TransactionController.GetTransactionRecords(mpn);
            }

            return models;
        }

        private DataTable CreateDataTable(TransactionRecord[] models)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("MPN", typeof(string));
            dt.Columns.Add("ICTP/N", typeof(string));
            dt.Columns.Add("DESC", typeof(string));
            dt.Columns.Add("Manufacture", typeof(string));            
            dt.Columns.Add("Location", typeof(string));
            dt.Columns.Add("MoveType", typeof(int));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Issue Qty", typeof(int));

            foreach (var record in models)
            {
                int stock = 0;
                
                try
                {
                    stock = record.Stock;
                }
                catch (Exception ex)
                {
                    MessageBoxEx.ShowError(ex.Message);
                }

                dt.Rows.Add(new object[]
                {
                    record.Id,
                    record.MPN,
                    record.PN,
                    record.DESC,
                    record.Manufacturer,
                    record.Warehouse,
                    record.MoveType,
                    record.Date,
                    stock
                });
            }
            return dt;
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Settings.Instance.DataAccesible == false)
            {
                MessageBoxEx.ShowWarning("Only manager can perform the operation.");
                return;
            }
            using (FormCreateTransaction form = new FormCreateTransaction(_MaterialController))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _TransactionController.AddData(form.Result);
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

        private void dgvTransactionInfo_CellClick(object sender, DataGridViewCellEventArgs e)
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
                if (IsInvalidTransaction(e.RowIndex) == true)
                {
                    MessageBoxEx.ShowWarning("The record is damaged so it cannot be edited.");
                    return;
                }

                string mpn = GetMpn(e.RowIndex);
                var record = _TransactionController.GetTransactionRecord(GetId(e.RowIndex));
                using (FormCreateTransaction form = new FormCreateTransaction(_MaterialController, record))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            record.ChangeModel(form.Result);
                            _TransactionController.SetData(form.Result);                            
                            UpdateDataTableByEditing(e.RowIndex, record);                            
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
                if (MessageBox.Show("Do you want to DELETE the record?", "Question",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {                    
                    try
                    {
                        string id = GetId(e.RowIndex);
                        _TransactionController.DeleteData(id);
                        UpdateDataTableByDeleting(e.RowIndex);                        
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBoxEx.ShowOperationError(ex);
                    }
                    catch(Exception ex)
                    {
                        MessageBoxEx.ShowOperationError(ex);
                    }
                }
            }
        }

        private bool IsInvalidTransaction(int rowIndex)
        {
            return Convert.ToInt32(dgvTransactionInfo.Rows[rowIndex].Cells[StockColumnIndex].Value) == 0;
        }

        private void UpdateDataTableByEditing(int rowIndex, TransactionRecord record)
        {
            DataTable dt = (DataTable)dgvTransactionInfo.DataSource;
            dt.Rows[rowIndex].ItemArray = new object[]
            {
                record.Id,
                record.MPN,
                record.PN,
                record.DESC,
                record.Manufacturer,
                record.Warehouse,
                record.MoveType,
                record.Date,
                record.Stock
            };
        }

        private void UpdateDataTableByDeleting(int rowIndex)
        {
            DataTable dt = (DataTable)dgvTransactionInfo.DataSource;
            dt.Rows[rowIndex].Delete();
        }

        private string GetMpn(int rowIndex)
        {
            return dgvTransactionInfo.Rows[rowIndex].Cells[MPNColumnIndex].Value.ToString();
        }

        private string GetId(int rowIndex)
        {
            return dgvTransactionInfo.Rows[rowIndex].Cells[IdColumnIndex].Value.ToString();
        }

        private void pcbSearch_Click(object sender, EventArgs e)
        {
            LoadDataFromDB(rtxSearch.Text.Trim());
        }

        private void dgvTransactionInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.ColumnIndex != StockColumnIndex)
                return;

            Color clr;
            DataGridViewCell cell = dgvTransactionInfo.Rows[e.RowIndex].Cells[StockColumnIndex];
            try
            {                
                if (Convert.ToInt32(cell.Value) < 0)
                {
                    clr = Color.Red;
                }
                else
                    clr = Color.Black;
            }
            catch
            {
                clr = Color.Red;
            }

            cell.Style.ForeColor = clr;
        }

        private void ckbDateRange_CheckedChanged(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = dtpEndDate.Enabled = ckbDateRange.Checked;
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
                        var reporter = CsvReportFactory.Create(CsvReportFactory.CsvReportType.Transaction);
                        reporter.Save((DataTable)dgvTransactionInfo.DataSource, dialog.FileName);
                        MessageBox.Show("Save transaction records sucessfully.");
                    }
                    catch(Exception ex)
                    {
                        MessageBoxEx.ShowOperationError(ex);
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (Settings.Instance.DataAccesible == false)
            {
                MessageBoxEx.ShowWarning("Only manager can perform the operation.");
                return;
            }
            if (MessageBox.Show("The operation will APPEND all new transaction data to the DB, do you want to continue?",
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
                        _TransactionController.Import(dialog.FileName, true);
                        LoadDataFromDB();
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Transactions import completed.");
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBoxEx.ShowError($"Failed to import transaction file:{ex.Message}");
                    }
                }
            }
        }

        private void dgvTransactionInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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
