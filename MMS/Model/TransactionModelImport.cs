using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using ClosedXML.Excel;

namespace MMS.Model
{
    public class TransactionModelImport
    {
        private readonly int _ColumnIndexMPN = 1;
        private readonly int _ColumnIndexMoveType = 6;
        private readonly int _ColumnIndexDate = 7;
        private readonly int _ColumnIndexQuantity = 8;
        private readonly string _SheetName = "交易记录";

        public TransactionModelImport()
        {

        }

        public TransactionModel[] Load(string fullFileName)
        {
            List<TransactionModel> models = new List<TransactionModel>();

            using (XLWorkbook book = new XLWorkbook(fullFileName))
            {
                var sheet = GetSheet(book, _SheetName);
                if (sheet == null)
                {
                    throw new ArgumentException("Invalid excel file format.");
                }
                foreach (var row in sheet.RowsUsed().Skip(1))//skip column header
                {
                    TransactionModel model = new TransactionModel();
                    model.MPN = row.Cell(_ColumnIndexMPN).Value.ToString();
                    model.MoveType = Convert.ToUInt32((row.Cell(_ColumnIndexMoveType).Value.ToString()));
                    model.Date = TransactionModel.ToDate(ToDate(row.Cell(_ColumnIndexDate).Value.ToString()));
                    string quantity = row.Cell(_ColumnIndexQuantity).Value.ToString();
                    model.Quantity = (uint)Math.Abs(Convert.ToInt32(quantity));
                    models.Add(model);
                }                
            }

            return models.ToArray();
        }

        private IXLWorksheet GetSheet(XLWorkbook book, string sheetName)
        {
            foreach (var s in book.Worksheets)
            {
                if (s.Name == _SheetName)
                    return s;

            }
            return null;
        }
        private static DateTime ToDate(string date)
        {
            string[] tokens = date.Split('/');
            if (tokens.Length == 2)//only month and day
            {
                return new DateTime(2021, Convert.ToInt32(tokens[0]), Convert.ToInt32(tokens[1]));
            }
            else if (tokens.Length == 3)//year, month, day
            {
                return new DateTime(Convert.ToInt32(tokens[0]), Convert.ToInt32(tokens[1]), Convert.ToInt32(tokens[2]));
            }
            else
                throw new FormatException($"Invalid date format:{date}");
        }
    }
}
