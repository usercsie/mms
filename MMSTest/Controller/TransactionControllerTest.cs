using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMS;
using MMS.Controller;
using MMS.Model;
using MMS.Setting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MMSTest.Controller
{
    [TestClass]
    public class TransactionControllerTest
    {
        string _DBPath = @"..\..\..\TestData\Default.db";
        string _SettingPath = @"..\..\..\TestData\Setting.xml";
        TransactionController _Controller;
        TransactionModelAccess _Access;
        MaterialModelAccess _MaterialAccess;

        [TestInitialize]
        public void Initialize()
        {
            _MaterialAccess = new MaterialModelAccess(_DBPath);
            _Access = new TransactionModelAccess(_DBPath);
            _Controller = new TransactionController(_Access, _MaterialAccess);
            SettingReader reader = new SettingReader();
            reader.Read(_SettingPath);
            Settings.Instance.SetMoveTypeParameter(reader.MoveTypeParameter.ToArray());
            Settings.Instance.SetMaterialGroupParameter(reader.GroupParameter.ToArray());

            _Access.DeleteAll();
            _MaterialAccess.DeleteAll();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _Access.DeleteAll();
            _MaterialAccess.DeleteAll();
        }

        [TestMethod]
        public void AddData()
        {
            TransactionModel m = CreateTransactionModel();
            _Controller.AddData(m);

            var output = _Access.Select();
            Assert.AreEqual(1, output.Count);
            Assert.AreEqual(m, output.Last());
        }
        
        [TestMethod]
        public void GetStock()
        {
            TransactionModel[] models = CreateTransactionModels();
            _Access.Insert(models);

            string mpn = "158-1000902603";
            int stock = _Controller.GetStock(mpn);
            Assert.AreEqual(5, stock);

            mpn = "158-1000902614";
            stock = _Controller.GetStock(mpn);
            Assert.AreEqual(42, stock);
        }

        [TestMethod]
        public void GetStock_Without_TransactionRecrod_Return_0()
        {
            TransactionModel[] models = CreateTransactionModels();
            _Access.Insert(models);

            string mpn = "158-9999999";
            int stock = _Controller.GetStock(mpn);
            Assert.AreEqual(0, stock);
        }

        [TestMethod]
        public void GetTransactionRecords()
        {
            TransactionModel[] models = CreateTransactionModels();
            _Access.Insert(models);

            _MaterialAccess.Insert(new MaterialModel()
            {
                 MPN = "158-1000902603",
                 PN = "050-Z242Z0-003H",
                 DESC = "MICRO SD 158-1000902603",
                 Manufacturer = "TAISOL",
                 Flock = "7-CONN",
                 Warehouse = "A41"
            });

            string mpn = "158-1000902603";
            List<TransactionRecord> records = _Controller.GetTransactionRecords(mpn);

            Assert.AreEqual(3, records.Count);
        }

        [TestMethod]
        public void ToFullMoveType()
        {
            MoveTypeParam p = new MoveTypeParam() { Id = 101, Operator = "+" };
            string actual = TransactionController.ToFullMoveType(p);

            Assert.AreEqual("101 (+)", actual);
        }

        [TestMethod]
        public void ParseMoveTypeId()
        {
            string moveType = "101 (+)";
            
            uint id = TransactionController.ParseMoveTypeId(moveType);
            
            Assert.AreEqual((uint)(101), id);
        }

        private TransactionModel CreateTransactionModel()
        {
            return new TransactionModel()
            {                
                MPN = "158-1000902603",
                MoveType = 101,
                Quantity = 25,
                Date = "2021-11-30"
            };
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
       
    }
    
}
