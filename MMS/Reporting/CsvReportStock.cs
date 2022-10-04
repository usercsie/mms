using MMS.Controller;
using MMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MMS.Reporting
{
    public class CsvReportStock : CsvReportBase
    {
        public CsvReportStock()
            :base()
        {
        }   

        protected override IEnumerable<string> GetData()
        {
            foreach(DataRow row in _DataTable.Rows)
            {
                string data = "";
                foreach(DataColumn col in _DataTable.Columns)
                {
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
    }
}
