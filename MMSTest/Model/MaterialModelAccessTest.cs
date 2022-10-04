using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMS.Model;
using System.IO;
using System.Linq;

namespace MMSTest.Model
{
    [TestClass]
    public class MaterialModelAccessTest
    {
        string _TestPath = @"..\..\..\TestData\";        

        [TestMethod]
        public void GetRowCount()
        {
            MaterialModelAccess access = CreateInstance(Path.Combine(_TestPath, "Select.db"));

            int actual = access.GetRowCount();

            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void Select()
        {
            MaterialModelAccess access = CreateInstance(Path.Combine(_TestPath, "Select.db"));

            var output = access.Select();

            Assert.AreEqual(1, output.Count);
            Assert.AreEqual("CR10-6041-FK", output[0].MPN);
        }

        [TestMethod]
        public void SelectPage()
        {
            MaterialModelAccess access = CreateInstance(Path.Combine(_TestPath, "InsertMany.db"));
            access.DeleteAll();
            MaterialModel[] materials = new MaterialModel[]
            {
                CreateDefaultMaterial(),
                CreateDefaultMaterial_2()
            };

            access.Insert(materials);

            uint pageIndex = 0;
            int pageSize = 1;
            var actual = access.Select(pageIndex, pageSize);

            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("MS05W2F100MT5E", actual.First().MPN);

            pageIndex = 1;
            actual = access.Select(pageIndex, pageSize);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("NCP15WF104F03RC", actual.First().MPN);
        }

        [TestMethod]
        public void SelectBy_Mpn()
        {
            MaterialModelAccess access = CreateInstance(Path.Combine(_TestPath, "SelectBy.db"));

            var output = access.SelectBy("NCP15WF104F03RC");

            Assert.AreEqual(1, output.Count);
            Assert.AreEqual("13001-S070003H-00", output[0].PN);
        }

        [TestMethod]
        public void SelectLikeBy()
        {
            MaterialModelAccess access = CreateInstance(Path.Combine(_TestPath, "SelectBy.db"));

            var output = access.SelectLikeBy("NCP15*");

            Assert.AreEqual(2, output.Count);
            Assert.AreEqual("NCP15WF104F03RC", output[0].MPN);
            Assert.AreEqual("NCP15XW682E03RC", output[1].MPN);

            output = access.SelectLikeBy("*P15WF104F03RC");

            Assert.AreEqual(1, output.Count);
            Assert.AreEqual("NCP15WF104F03RC", output[0].MPN);

            output = access.SelectLikeBy("*15W*");

            Assert.AreEqual(1, output.Count);
            Assert.AreEqual("NCP15WF104F03RC", output[0].MPN);
            //Assert.AreEqual("NCP15XW682E03RC", output[1].MPN);
        }

        [TestMethod]
        public void Insert_One()
        {
            MaterialModelAccess access = CreateInstance(Path.Combine(_TestPath, "Insert.db"));

            access.DeleteAll();

            MaterialModel m = CreateDefaultMaterial();

            access.Insert(m);
            var output = access.Select();

            Assert.AreEqual(1, output.Count);
        }

        [TestMethod]
        public void Insert_Many()
        {            
            MaterialModelAccess access = CreateInstance(Path.Combine(_TestPath, "InsertMany.db"));
            access.DeleteAll();
            MaterialModel[] materials = new MaterialModel[]
            {
                CreateDefaultMaterial(),
                CreateDefaultMaterial_2()
            };

            access.Insert(materials);

            var output = access.Select();
            Assert.AreEqual(2, output.Count);
            Assert.AreEqual(materials[0], output[0]);
            Assert.AreEqual(materials[1], output[1]);
        }

        [TestMethod]
        public void DeleteBy()
        {            
            MaterialModelAccess access = CreateInstance(Path.Combine(_TestPath, "Delete.db"));
            access.DeleteAll();

            MaterialModel m = CreateDefaultMaterial();
            access.Insert(m);

            var output = access.Select();
            Assert.AreEqual(1, output.Count);

            access.DeleteBy("MS05W2F100MT5E");
            output = access.Select();
            Assert.AreEqual(0, output.Count);
        }

        [TestMethod]
        public void Update()
        {
            MaterialModelAccess access = CreateInstance(Path.Combine(_TestPath, "Update.db"));

            access.DeleteAll();
            access.Insert(CreateDefaultMaterial());
            var currMaterial = access.Select();

            var newMaterial = CreateDefaultMaterial_2();
            newMaterial.MPN = currMaterial.First().MPN;
            access.Update(newMaterial);

            var output = access.Select();

            Assert.AreEqual(1, output.Count);
            Assert.AreEqual(newMaterial, output.First());
        }

        private MaterialModelAccess CreateInstance(string dbPath)
        {
            return new MaterialModelAccess(dbPath);
        }

        private MaterialModel CreateDefaultMaterial()
        {
            return new MaterialModel()
            {
                MPN = "MS05W2F100MT5E",
                DESC = "RES,10mΩ,±1%,0805,1/2W,HF,Uniohm",
                PN = "13000-S040120H-00",
                Manufacturer = "UNIOHM",
                Flock = "0-RES電阻類",
                Warehouse = "A01"
            };
        }

        private MaterialModel CreateDefaultMaterial_2()
        {
            return new MaterialModel()
            {
                MPN = "NCP15WF104F03RC",
                DESC = "NTC,S,0402,100Kohm,1%,HF,MURATA",
                PN = "13001-S070003H-00",
                Manufacturer = "MURATA",
                Flock = "0-RES電阻類",
                Warehouse = "A01"
            };
        }
    }
}
