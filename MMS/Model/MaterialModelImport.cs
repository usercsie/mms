using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using ClosedXML.Excel;

namespace MMS.Model
{
    public class MaterialModelImport
    {
        private readonly int _ColumnIndexMPN = 1;
        private readonly int _ColumnIndexICTPN = 2;
        private readonly int _ColumnIndexDESC = 3;
        private readonly int _ColumnIndexManufacture = 4;
        private readonly int _ColumnIndexGroup = 5;
        private readonly int _ColumnIndexLocation = 6;
        private readonly string _SheetName = "基本信息";

        public MaterialModelImport()
        {

        }

        public MaterialModel[] Load(string fullFileName)
        {
            List<MaterialModel> models = new List<MaterialModel>();

            using (XLWorkbook book = new XLWorkbook(fullFileName))
            {
                var sheet = GetSheet(book, _SheetName);
                if (sheet == null)
                {
                    throw new ArgumentException("Invalid excel file format.");
                }
                foreach (var row in sheet.RowsUsed().Skip(1))//skip column header
                {
                    MaterialModel model = new MaterialModel();
                    model.MPN = row.Cell(_ColumnIndexMPN).Value.ToString();
                    model.PN = row.Cell(_ColumnIndexICTPN).Value.ToString();
                    model.DESC = row.Cell(_ColumnIndexDESC).Value.ToString();
                    model.Manufacturer = row.Cell(_ColumnIndexManufacture).Value.ToString();
                    model.Flock = row.Cell(_ColumnIndexGroup).Value.ToString();
                    model.Warehouse = row.Cell(_ColumnIndexLocation).Value.ToString();
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

        //public static MaterialModel Parse(string line)
        //{
        //    line = line.TrimEnd();
        //    if (line.Last() != ',')
        //    {
        //        line += ",";
        //    }            

        //    MaterialModel model = new MaterialModel();
        //    List<string> tokens = new List<string>();
        //    bool isQuote = false;            
        //    string token = string.Empty;
        //    foreach(var c in line)
        //    {
        //        if (c == ',')
        //        {
        //            if (isQuote == false || (isQuote == true && token.Last() == '"'))
        //            {
        //                token = token.Trim('"');
        //                tokens.Add(token);
        //                token = string.Empty;
        //                isQuote = false;
        //            }
        //            else
        //                token += c;
        //        }
        //        else if (c == '"')
        //        {
        //            if (isQuote == false)
        //            {
        //                isQuote = true;
        //            }
        //            token += c;
        //        }
        //        else
        //        {
        //            token += c;
        //        }                
        //    }

        //    if (tokens.Count == 6)
        //    {
        //        model.MPN = tokens[0];
        //        model.PN = tokens[1];
        //        model.DESC = tokens[2];
        //        model.Manufacturer = tokens[3];
        //        model.Flock = tokens[4];
        //        model.Warehouse = tokens[5];
        //    }
        //    return model;
        //}

        //private bool ValidFormat(string line)
        //{
        //    if (string.IsNullOrEmpty(line) == true)
        //        return false;

        //    var tokens = line.Split(',').Select(v => v.Trim());
        //    return tokens.SequenceEqual<string>(AvailableColumns());
        //}

        //private string[] AvailableColumns()
        //{
        //    return new string[]
        //    {
        //        "MPN",
        //        "ICT P/N",
        //        "DESC",
        //        "Manufacturer",
        //        "Group",
        //        "WH PIC"
        //    };
        //}
    }
}
