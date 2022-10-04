using MMS.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MMS.Reporting
{
    public class CsvReportTransaction : CsvReportBase
    {
        public CsvReportTransaction()
            :base()
        {
        }

        protected override string[] GetColumns()
        {
            string quantity = GetTotalQuantity().ToString();
            List<string> columns = new List<string>();

            foreach (DataColumn col in _DataTable.Columns)
            {
                if (IsHiddenColumn(col) == true)
                    continue;
                columns.Add(col.Caption);
            }
            columns.Add(quantity);
            return columns.ToArray();
        }

        protected override IEnumerable<string> GetData()
        {
            foreach (DataRow row in _DataTable.Rows)
            {
                string data = "";
                foreach (DataColumn col in _DataTable.Columns)
                {
                    if (IsHiddenColumn(col) == true)
                        continue;

                    string s = row[col].ToString();
                    //if (NeedQuote(col) == true)
                    {
                        s = AutoQuote(s);
                    }
                    data += $"{s},";
                }
                yield return data;
            }
        }

        private bool IsHiddenColumn(DataColumn column)
        {
            return column.Caption == "Id";
        }

        private int GetTotalQuantity()
        {
            int sum = 0;
            foreach(DataRow row in _DataTable.Rows)
            {
                sum += Convert.ToInt32(row["Issue Qty"].ToString());
            }
            return sum;
        }
    }
}
