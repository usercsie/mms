using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMS.Controller;
using MMS.Model;

namespace MMSTest.Controller
{
    [TestClass]
    public class MaterialControllerTest
    {
        string _DBPath = @"..\..\..\TestData\Default.db";

        MaterialController _Controller;
        MaterialModelAccess _Access;

        [TestInitialize]
        public void Initialize()
        {
            _Access = new MaterialModelAccess(_DBPath);            
            _Controller = new MaterialController(_Access);

            _Access.DeleteAll();            
        }

        [TestCleanup]
        public void CleanUp()
        {
            _Access.DeleteAll();            
        }

        [TestMethod]
        public void GetData()
        {
            MaterialModel model = CreateMaterialModel();

            _Access.Insert(model);

            MaterialModel output = _Controller.GetData(model.MPN);

            Assert.AreEqual(model, output);
        }

        [TestMethod]
        public void GetData_NotFound()
        {
            string mpn = "AAAAA";
            MaterialModel model = _Controller.GetData(mpn);

            Assert.AreEqual(null, model);
        }

        [TestMethod]
        public void SelectData_Empty()
        {
            string mpn = "AAAAA";
            var models = _Controller.SelectData(mpn);

            Assert.AreEqual(0, models.Count);
        }

        [TestMethod]
        public void IsInCompleted()
        {
            MaterialModel model = CreateInCompletedMaterialModel();
            _Access.Insert(model);

            MaterialModel output = _Controller.GetData(model.MPN);

            bool actual = _Controller.IsIncompleted(output);
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void GetMpn()
        {
            MaterialModel[] models = new MaterialModel[]
            {
                CreateMaterialModel(),
                CreateInCompletedMaterialModel()
            };
            _Access.Insert(models);

            string[] mpn = _Controller.GetMpn();
            Assert.AreEqual(2, mpn.Length);
            Assert.AreEqual(models[0].MPN, mpn[0]);
            Assert.AreEqual(models[1].MPN, mpn[1]);
        }

        //[TestMethod]
        //public void Import()
        //{
        //    _Controller.Import(_CsvPath);
        //}

        private MaterialModel CreateMaterialModel()
        {
            return new MaterialModel()
            {
                MPN = "158-1000902603",
                PN = "050-Z242Z0-003H",
                DESC = "MICRO SD 158-1000902603",
                Manufacturer = "TAISOL",
                Flock = "7-CONN",
                Warehouse = "A41"
            };
        }

        private MaterialModel CreateInCompletedMaterialModel()
        {
            return new MaterialModel()
            {
                MPN = "158-1000902614",
            };
        }
    }

    
}
