using MMS.Controller;
using System;

namespace MMS.Reporting
{
    internal static class CsvReportFactory
    {
        internal enum CsvReportType
        {
            Stock,
            Transaction
        }

        public static CsvReportBase Create(CsvReportType type)
        {
            if (type == CsvReportType.Stock)
            {
                return new CsvReportStock();
            }
            else if (type == CsvReportType.Transaction)
            {
                return new CsvReportTransaction();
            }
            else
                throw new NotImplementedException("CsvReportType:" + type.ToString());

        }
    }
}
