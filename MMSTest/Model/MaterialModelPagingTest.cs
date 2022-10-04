using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMS.Model;
using System;

namespace MMSTest.Model
{
    [TestClass]
    public class MaterialModelPagingTest
    {
        string _DBPath = @"..\..\..\TestData\MMS.db";
        MaterialModelAccess _Access;
        MaterialModelPaging _Paging;

        [TestInitialize]
        public void TestInitialize()
        {
            _Access = new MaterialModelAccess(_DBPath);
        }

        [TestMethod]
        public void MoveTo()
        {
            uint pageSize = 10;
            uint pageCount = (uint)Math.Ceiling((double)_Access.GetRowCount() / pageSize);
            _Paging = new MaterialModelPaging(_Access, pageSize, pageCount);

            var actual = _Paging.MoveTo(0);
            Assert.AreEqual(10, actual.Count);

            actual = _Paging.MoveTo(pageCount - 1);
            Assert.AreEqual(7, actual.Count);
        }
        [TestMethod]
        public void FirstPage()
        {
            uint pageSize = 10;
            uint pageCount = (uint)Math.Ceiling((double)_Access.GetRowCount() / pageSize);
            _Paging = new MaterialModelPaging(_Access, pageSize, pageCount);

            var actual = _Paging.FirstPage();
            Assert.AreEqual(10, actual.Count);
            Assert.AreEqual("CR10-6041-FK", actual[0].MPN);
            Assert.AreEqual("MS05W2F100MT5E", actual[1].MPN);
            Assert.AreEqual("NCP15WF104F03RC", actual[2].MPN);
            Assert.AreEqual("RC0201FR-0710KL", actual[9].MPN);
        }
        [TestMethod]
        public void LastPage()
        {
            uint pageSize = 10;
            uint pageCount = (uint)Math.Ceiling((double)_Access.GetRowCount() / pageSize);
            _Paging = new MaterialModelPaging(_Access, pageSize, pageCount);

            var actual = _Paging.LastPage();
            Assert.AreEqual(7, actual.Count);
            Assert.AreEqual("LR1206-21R020F4", actual[0].MPN);
            Assert.AreEqual("NV140DRM-N61", actual[1].MPN);
            Assert.AreEqual("PE0402FRF7T0R01L", actual[2].MPN);
            Assert.AreEqual("PESD5V0H1BSF", actual[3].MPN);
            Assert.AreEqual("PH291-002T410P", actual[4].MPN);
            Assert.AreEqual("RTH06R010FTP", actual[5].MPN);
            Assert.AreEqual("SB472A22H2", actual[6].MPN);
        }

    }
}
