using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMSTest.Model
{
    [TestClass]
    public class TransactionModelImportTest
    {
        string _TestPath = @"..\..\..\TestData\Sample.xlsx";
        string _BadExcelPath = @"..\..\..\TestData\InvalidFormat.xlsx";

        [TestMethod]
        public void Load()
        {
            TransactionModelImport importer = new TransactionModelImport();

            var actual = importer.Load(_TestPath);

            Assert.AreEqual(412, actual.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Load_BadFormat_Throw_ArgumentException()
        {
            TransactionModelImport importer = new TransactionModelImport();

            var actual = importer.Load(_BadExcelPath);
        }

        //[TestMethod]
        //public void Parse()
        //{
        //    string line = "0201N270J250CT,13100-S030088H-00,\"C / C,0201,27PF,5 %,25V,C0G,HF,WALSIN\",WALSIN,A15,101,11/30,\"1,000 \",,";
        //    TransactionModel actual = TransactionModelImport.Parse(line);

        //    Assert.AreEqual("0201N270J250CT", actual.MPN);
        //    Assert.AreEqual(101, (int)actual.MoveType);
        //    Assert.AreEqual(1000, (int)actual.Quantity);
        //    Assert.AreEqual("2021-11-30", actual.Date);

        //    line = "0201N270J250CT,13100-S030088H-00,\"C / C,0201,27PF,5 %,25V,C0G,HF,WALSIN\",WALSIN,A15,101,11/30,123,,";
        //    actual = TransactionModelImport.Parse(line);

        //    Assert.AreEqual("0201N270J250CT", actual.MPN);
        //    Assert.AreEqual(101, (int)actual.MoveType);
        //    Assert.AreEqual(123, (int)actual.Quantity);
        //    Assert.AreEqual("2021-11-30", actual.Date);

        //    line = "0201N270J250CT,13100-S030088H-00,\"C / C,0201,27PF,5 %,25V,C0G,HF,WALSIN\",WALSIN,A15,101,11/30,-123,,";
        //    actual = TransactionModelImport.Parse(line);

        //    Assert.AreEqual("0201N270J250CT", actual.MPN);
        //    Assert.AreEqual(101, (int)actual.MoveType);
        //    Assert.AreEqual(123, (int)actual.Quantity);
        //    Assert.AreEqual("2021-11-30", actual.Date);            
        //}
    }
}
