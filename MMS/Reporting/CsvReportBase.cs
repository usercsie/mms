using MMS.Controller;
using MMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace MMS.Reporting
{
    public abstract class CsvReportBase
    {
        protected DataTable _DataTable;

        public CsvReportBase()
        {     
        }

        public void Save(DataTable table, string fullFileName)
        {
            _DataTable = table;
            using (StreamWriter sw = new StreamWriter(fullFileName, false, Encoding.UTF8))
            {
                WriteColumns(sw);
                WriteBody(sw);                
            }
        }
        private void WriteColumns(StreamWriter sw)
        {
            string s = "";
            foreach (var column in GetColumns())
            {
                s += (column + ",");
            }
            s.TrimEnd(',');
            sw.WriteLine(s);
        }

        private void WriteBody(StreamWriter sw)
        {
            foreach (var d in GetData())
            {
                sw.WriteLine(d);
            }
        }

        protected virtual string[] GetColumns()
        {
            List<string> columns = new List<string>();

            foreach (DataColumn col in _DataTable.Columns)
            {                
                columns.Add(col.Caption);
            }

            return columns.ToArray();
        }

        protected abstract IEnumerable<string> GetData();

        protected string AutoQuote(string txt)
        {
            if (txt.Contains(',') == true)
            {
                return $"\"{txt}\"";
            }
            else
                return txt;
        }

        protected bool NeedQuote(DataColumn column)
        {
            return column.ColumnName == "DESC" || 
                   column.ColumnName == "Manufacture" || 
                   column.ColumnName == "Location";
        }
    }
}
