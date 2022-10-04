using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMS;
using MMS.Controller;
using MMS.Model;
using MMS.Reporting;
using MMS.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace MMSTest.Reporting
{
    [TestClass]
    public class CsvReportTransactionTest
    {
        string _TestPath = @"..\..\..\TestData\";

        private CsvReportTransaction _Reporter;
        private TransactionController _TransactionController;
        private MaterialController _MaterialController;
        private MaterialModelAccess _MaterialAccess;
        private TransactionModelAccess _TransactionModelAccess;

        [TestInitialize]
        public void Initialize()
        {
            string dbPath = Path.Combine(_TestPath, "Default.db");
            _MaterialAccess = new MaterialModelAccess(dbPath);
            _TransactionModelAccess = new TransactionModelAccess(dbPath);

            _TransactionController = new TransactionController(_TransactionModelAccess, _MaterialAccess);
            _MaterialController = new MaterialController(_MaterialAccess);
            _Reporter = new CsvReportTransaction();

            SettingReader reader = new SettingReader();
            reader.Read(Path.Combine(_TestPath, "Setting.xml"));
            Settings.Instance.SetMoveTypeParameter(reader.MoveTypeParameter.ToArray());
            Settings.Instance.SetMaterialGroupParameter(reader.GroupParameter.ToArray());

            _MaterialAccess.DeleteAll();
            _TransactionModelAccess.DeleteAll();
        }
        [TestCleanup]
        public void CleanUp()
        {
            _MaterialAccess.DeleteAll();
            _TransactionModelAccess.DeleteAll();
        }

        [TestMethod]
        public void Save()
        {
            _TransactionController.AddData(CreateTransactionModels());
            _MaterialController.AddData(CreateMaterialModels());
            DataTable table = CreateDataTable(_TransactionController.GetTransactionRecords().ToArray());

            string fullFileName = Path.Combine(_TestPath, "transaction.csv");
            if (File.Exists(fullFileName) == true)
            {
                File.Delete(fullFileName);
            }

            _Reporter.Save(table, fullFileName);

            Assert.AreEqual(true, File.Exists(fullFileName));

            File.Delete(fullFileName);
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
                    record.Stock
                });
            }
            return dt;
        }

        private TransactionModel[] CreateTransactionModels()
        {
            return new TransactionModel[]
            {
                new TransactionModel("0201N270J250CT", 101, 1000, "2021-11-30"),
                new TransactionModel("158-1000902603", 101, 25, "2021-11-30"),
                new TransactionModel("158-1000902614", 101, 92, "2021-11-30"),
                new TransactionModel("2SJ3080-064111F", 101, 100, "2021-11-30"),
                new TransactionModel("2UB1646-003111F", 101, 100, "2021-11-30"),

                new TransactionModel("158-1000902603", 601, 25, "2021-12-6"),
                new TransactionModel("158-1000902603", 602, 5, "2021-12-7"),
                new TransactionModel("158-1000902614", 102, 50, "2021-12-1"),
            };
        }

        private MaterialModel[] CreateMaterialModels()
        {
            return new MaterialModel[]
            {
                new MaterialModel("0201N270J250CT", "13100-S030088H-00", "C/C,0201,27PF,5%,25V,C0G,HF,WALSIN", "WALSIN", "1-CAP電容類", "A15"),
                new MaterialModel("158-1000902603", "050-Z242Z0-003H", "MICRO SD 158-1000902603", "TAISOL", "7-CONN", "A41"),
                new MaterialModel("158-1000902614", "050-Z24270-001H", "Micro SD,STD,H1.27,23P,Push Push", "TAISOL", "7-CONN", "A41"),
                new MaterialModel("2SJ3080-064111F", "050-32205L-002H", "Audio, 4pole, CH-0.7, 6P, 內徑3.6，外徑6，無鐵環", "SINGATRON", "7-CONN", "A41"),
                new MaterialModel("2UB1646-003111F", "050-4J2090-001H", "USB 3.1A, REV, CH-0.7, 沉板, 9P , Black", "SINGATRON", "7-CONN", "A41"),
                new MaterialModel("50273-0080N-001", "050-1Z2088-002H", "ACES 50273-0080N-001", "ACES", "7-CONN", "A42")
            };
        }
    }
}
