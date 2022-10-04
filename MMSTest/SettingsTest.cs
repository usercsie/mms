using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMS;
using MMS.Setting;

namespace MMSTest
{
    [TestClass]
    public class SettingsTest
    {
        //string _TestPath = @"..\..\..\TestData\";

        //[TestMethod]
        //public void GetMaterialGroups()
        //{
        //    Settings.Instance.Load(Path.Combine(_TestPath, "Setting.xml"));

        //    string[] actual = Settings.Instance.GetMaterialGroups();
        //    string[] expect = CreateExpectedGroups();

        //    Assert.AreEqual(true, actual.SequenceEqual(expect));
        //}

        //[TestMethod]
        //public void GetMoveTypeParameters()
        //{
        //    Settings.Instance.Load(Path.Combine(_TestPath, "Setting.xml"));

        //    MoveTypeParam[] actual = Settings.Instance.GetMoveTypeParameters();
        //    MoveTypeParam[] expect = CreateExpectedMoveTypeParameter();

        //    Assert.AreEqual(true, actual.SequenceEqual(expect));
        //}

        //[TestMethod]
        //public void GetMoveTypeEffect()
        //{
        //    Settings.Instance.Load(Path.Combine(_TestPath, "Setting.xml"));

        //    MoveTypeEffect actual = Settings.Instance.GetMoveTypeEffect(101);
        //    Assert.AreEqual(MoveTypeEffect.Plus, actual);

        //    actual = Settings.Instance.GetMoveTypeEffect(102);
        //    Assert.AreEqual(MoveTypeEffect.Minus, actual);

        //    actual = Settings.Instance.GetMoveTypeEffect(601);
        //    Assert.AreEqual(MoveTypeEffect.Minus, actual);

        //    actual = Settings.Instance.GetMoveTypeEffect(602);
        //    Assert.AreEqual(MoveTypeEffect.Plus, actual);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void GetMoveTypeEffect_Id_NotFound_Throw_ArgumentException()
        //{
        //    Settings.Instance.Load(Path.Combine(_TestPath, "Setting.xml"));

        //    MoveTypeEffect actual = Settings.Instance.GetMoveTypeEffect(103);            
        //}
      
    }
}
