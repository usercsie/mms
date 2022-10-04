using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMSTest.Model
{
    [TestClass]
    public class MaterialModelImportTest
    {        
        string _TestPath = @"..\..\..\TestData\Sample.xlsx";
        string _BadExcelPath = @"..\..\..\TestData\InvalidFormat.xlsx";

        [TestMethod]
        public void Load()
        {
            MaterialModelImport importer = new MaterialModelImport();

            var actual = importer.Load(_TestPath);

            Assert.AreEqual(517, actual.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Load_BadFormat_Throw_ArgumentException()
        {
            MaterialModelImport importer = new MaterialModelImport();

            var actual = importer.Load(_BadExcelPath);
        }

        //[TestMethod]
        //public void Parse_line_Without_Quote()
        //{
        //    string line = "RC0201FR-07499RL,13000-S000525H-00,RES,YAGEO,0-RES電阻類,A04";
        //    MaterialModel actual = MaterialModelImport.Parse(line);

        //    Assert.AreEqual("RC0201FR-07499RL", actual.MPN);
        //    Assert.AreEqual("13000-S000525H-00", actual.PN);
        //    Assert.AreEqual("RES", actual.DESC);
        //    Assert.AreEqual("YAGEO", actual.Manufacturer);
        //    Assert.AreEqual("0-RES電阻類", actual.Flock);
        //    Assert.AreEqual("A04", actual.Warehouse);
        //}

        //[TestMethod]
        //public void Parse_line_DESC_With_Quote()
        //{
        //    string line = "RC0201FR-07499RL,13000-S000525H-00,\"RES,0201,499 ohm,1%,1/20W,HF,YAGEO\",YAGEO,0-RES電阻類,A04";
        //    MaterialModel actual = MaterialModelImport.Parse(line);

        //    Assert.AreEqual("RC0201FR-07499RL", actual.MPN);
        //    Assert.AreEqual("13000-S000525H-00", actual.PN);
        //    Assert.AreEqual("RES,0201,499 ohm,1%,1/20W,HF,YAGEO", actual.DESC);
        //    Assert.AreEqual("YAGEO", actual.Manufacturer);
        //    Assert.AreEqual("0-RES電阻類", actual.Flock);
        //    Assert.AreEqual("A04", actual.Warehouse);
        //}

        //[TestMethod]
        //public void Parse_line_MPN_With_Quote()
        //{
        //    string line = "\"RC0201FR-07499RL\",13000-S000525H-00,RES,YAGEO,0-RES電阻類,A04";
        //    MaterialModel actual = MaterialModelImport.Parse(line);

        //    Assert.AreEqual("RC0201FR-07499RL", actual.MPN);
        //    Assert.AreEqual("13000-S000525H-00", actual.PN);
        //    Assert.AreEqual("RES", actual.DESC);
        //    Assert.AreEqual("YAGEO", actual.Manufacturer);
        //    Assert.AreEqual("0-RES電阻類", actual.Flock);
        //    Assert.AreEqual("A04", actual.Warehouse);
        //}
    }
}
