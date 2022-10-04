using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMS.Setting;
using System.Linq;

namespace MMSTest.Setting
{
    [TestClass]
    public class SettingReaderTest
    {
        string _TestPath = @"..\..\..\TestData\";

        SettingReader _Reader;

        [TestInitialize]
        public void Intialize()
        {
            _Reader = new SettingReader();
            _Reader.Read(Path.Combine(_TestPath, "Setting.xml"));
        }

        [TestMethod]
        public void GetMaterialGroups()
        {
            SettingReader defaultReader = new SettingReader();

            string[] actual = _Reader.GroupParameter.ToArray();
            string[] expect = defaultReader.GroupParameter.ToArray();

            Assert.AreEqual(true, actual.SequenceEqual(expect));
        }

        [TestMethod]
        public void GetMoveTypeParameters()
        {
            SettingReader defaultReader = new SettingReader();

            MoveTypeParam[] actual = _Reader.MoveTypeParameter.ToArray();
            MoveTypeParam[] expect = defaultReader.MoveTypeParameter.ToArray();

            Assert.AreEqual(true, actual.SequenceEqual(expect));
        }        
    }
}
