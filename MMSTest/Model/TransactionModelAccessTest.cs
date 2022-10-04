using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMS.Model;
using System.IO;
using System.Linq;

namespace MMSTest.Model
{
    [TestClass]
    public class TransactionModelAccessTest
    {
        string _TestPath = @"..\..\..\TestData\";

        TransactionModelAccess _Access;


        [TestInitialize]
        public void Initialize()
        {
            _Access = new TransactionModelAccess(Path.Combine(_TestPath, "Default.db"));
            _Access.DeleteAll();
        }
        [TestCleanup]
        public void CleanUp()
        {
            _Access.DeleteAll();
        }

        [TestMethod]
        public void Insert_One()
        {
            TransactionModel m = CreateTransactionModel();
            _Access.Insert(m);

            var output = _Access.Select();
            Assert.AreEqual(1, output.Count());
            Assert.AreEqual(m, output.First());
        }

        [TestMethod]
        public void Insert_Many()
        {
            TransactionModel[] m = new TransactionModel[]
            {
                CreateTransactionModel(),
                CreateTransactionModel_2(),
            };

            _Access.Insert(m);

            var output = _Access.Select();
            Assert.AreEqual(2, output.Count());
        }

        [TestMethod]
        public void SelectWithDateRange()
        {
            TransactionModel[] m = new TransactionModel[]
            {
                CreateTransactionModel(),
                CreateTransactionModel_2(),
            };

            _Access.Insert(m);

            System.DateTime start = System.DateTime.Parse("2021-11-30");
            System.DateTime end = System.DateTime.Parse("2021-11-30");
            var output = _Access.Select(start, end);
            Assert.AreEqual(1, output.Count);            
        }

        [TestMethod]
        public void SelectWithDateOutOfRange()
        {
            TransactionModel[] m = new TransactionModel[]
            {
                CreateTransactionModel(),
                CreateTransactionModel_2(),
            };

            _Access.Insert(m);

            System.DateTime start = System.DateTime.Parse("2021-11-04");
            System.DateTime end = System.DateTime.Parse("2021-11-29");
            var output = _Access.Select(start, end);
            Assert.AreEqual(0, output.Count);
        }
        
        [TestMethod]
        public void SelectByMpn()
        {
            TransactionModel[] m = new TransactionModel[]
            {
                CreateTransactionModel(),
                CreateTransactionModel_2(),
            };

            _Access.Insert(m);

            var output = _Access.SelectByMpn("158-1000902614");
            Assert.AreEqual(1, output.Count);            
            Assert.AreEqual((uint)92, output.First().Quantity);
        }
        [TestMethod]
        public void SelectByMpnWithDateRange()
        {
            TransactionModel[] m = new TransactionModel[]
            {
                CreateTransactionModel(),
                CreateTransactionModel_2(),
            };

            _Access.Insert(m);

            System.DateTime start = System.DateTime.Parse("2021-11-30");
            System.DateTime end = System.DateTime.Parse("2021-11-30");
            var output = _Access.SelectByMpn("158-1000902614", start, end);
            Assert.AreEqual(1, output.Count);
            Assert.AreEqual((uint)92, output.First().Quantity);
        }

        [TestMethod]
        public void SelectByMpnWithDateOutOfRange()
        {
            TransactionModel[] m = new TransactionModel[]
            {
                CreateTransactionModel(),
                CreateTransactionModel_2(),
            };

            _Access.Insert(m);

            System.DateTime start = System.DateTime.Parse("2021-11-29");
            System.DateTime end = System.DateTime.Parse("2021-11-29");
            var output = _Access.SelectByMpn("158-1000902614", start, end);
            Assert.AreEqual(0, output.Count);            
        }

        [TestMethod]
        public void SelectLikeByMpn()
        {
            TransactionModel[] m = new TransactionModel[]
           {
                CreateTransactionModel(),
                CreateTransactionModel_2(),
           };

            _Access.Insert(m);

            var output = _Access.SelectLikeByMpn("158*");
            Assert.AreEqual(2, output.Count);
            Assert.AreEqual("158-1000902603", output[0].MPN);
            Assert.AreEqual("158-1000902614", output[1].MPN);

            output = _Access.SelectLikeByMpn("*2603");
            Assert.AreEqual(1, output.Count);
            Assert.AreEqual("158-1000902603", output[0].MPN);

            output = _Access.SelectLikeByMpn("*-100090260*");
            Assert.AreEqual(1, output.Count);
            Assert.AreEqual("158-1000902603", output[0].MPN);
        }

        [TestMethod]
        public void SelectLikeByMpnWithDate()
        {
            TransactionModel[] m = new TransactionModel[]
            {
                CreateTransactionModel(),
                CreateTransactionModel_2(),
            };

            _Access.Insert(m);

            System.DateTime start = System.DateTime.Parse("2021-11-30");
            System.DateTime end = System.DateTime.Parse("2021-11-30");
            var output = _Access.SelectLikeByMpn("158-*", start, end);
            Assert.AreEqual(1, output.Count);
            Assert.AreEqual("158-1000902614", output.First().MPN);
        }

        [TestMethod]
        public void SelectById()
        {
            TransactionModel[] m = new TransactionModel[]
            {
                CreateTransactionModel(),
                CreateTransactionModel_2(),
            };

            _Access.Insert(m);

            var output = _Access.SelectById(m.First().Id);
            Assert.AreEqual(m.First(), output);            
        }

        [TestMethod]
        public void SelectById_NotFound_Return_NULL()
        {
            TransactionModel[] m = new TransactionModel[]
            {
                CreateTransactionModel(),
                CreateTransactionModel_2(),
            };

            _Access.Insert(m);

            var output = _Access.SelectById("xxxx");
            Assert.AreEqual(null, output);
        }

        [TestMethod]
        public void DeleteBy()
        {
            TransactionModel[] m = new TransactionModel[]
            {
                CreateTransactionModel(),
                CreateTransactionModel_2(),
            };
            _Access.Insert(m);

            var output = _Access.Select();
            Assert.AreEqual(2, output.Count);

            _Access.DeleteBy(output.First().Id);
            output = _Access.Select();
            Assert.AreEqual(1, output.Count);
        }

        [TestMethod]
        public void Update()
        {
            TransactionModel[] m = new TransactionModel[]
           {
                CreateTransactionModel(),
                CreateTransactionModel_2(),
           };
            _Access.Insert(m);

            var models = _Access.Select();
            Assert.AreEqual(2, models.Count);

            TransactionModel model = m.First();
            model.MoveType = 102;
            model.Quantity = 111;

            _Access.Update(model);
            TransactionModel actual = _Access.Select().First();
            Assert.AreEqual(model, actual);
        }

        private TransactionModel CreateTransactionModel()
        {
            return new TransactionModel()
            {                
                MPN = "158-1000902603",
                MoveType = 101,
                Quantity = 25,
                Date = "2021-11-03"
            };
        }

        private TransactionModel CreateTransactionModel_2()
        {
            return new TransactionModel()
            {                
                MPN = "158-1000902614",
                MoveType = 101,
                Quantity = 92,
                Date = "2021-11-30"
            };
        }
    }
}
