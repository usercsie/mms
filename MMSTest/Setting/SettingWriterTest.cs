using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMS.Setting;
using System.Linq;
using System.Data;

namespace MMSTest.Setting
{
    [TestClass]
    public class SettingWriterTest
    {
        private string _TestPath = @"..\..\..\TestData\";
        private SettingWriter _Writer;

        [TestMethod]
        public void WriteMoveType()
        {
            _Writer = new SettingWriter();

            DataTable dt = CreateMoveTypeTable();

            _Writer.WriteMoveType(dt, Path.Combine(_TestPath, "SettingWriter.xml"));

            SettingReader reader = new SettingReader();
            reader.Read(Path.Combine(_TestPath, "SettingWriter.xml"));
            Assert.AreEqual(5, reader.MoveTypeParameter.Count);
            Assert.AreEqual(701, (int)reader.MoveTypeParameter[4].Id);
            Assert.AreEqual("-", reader.MoveTypeParameter[4].Operator);
        }

        [TestMethod]
        public void WriteGroup()
        {
            _Writer = new SettingWriter();

            DataTable dt = CreateGroup();

            _Writer.WriteGroup(dt, Path.Combine(_TestPath, "SettingWriter.xml"));

            SettingReader reader = new SettingReader();
            reader.Read(Path.Combine(_TestPath, "SettingWriter.xml"));
            Assert.AreEqual(4, reader.GroupParameter.Count);
            Assert.AreEqual("3-二三極管", reader.GroupParameter[3]);
        }

        private DataTable CreateMoveTypeTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MoveType", typeof(int));
            dt.Columns.Add("DESC", typeof(string));
            dt.Columns.Add("Operator", typeof(string));
            dt.Rows.Add(new object[] { 101, "材料收料", "+" });
            dt.Rows.Add(new object[] { 102, "材料收料-錯誤反冲", "-" });
            dt.Rows.Add(new object[] { 601, "材料出貨", "-" });
            dt.Rows.Add(new object[] { 602, "材料出貨-錯誤反冲", "+" });
            dt.Rows.Add(new object[] { 701, "材料出貨-Test", "-" });

            return dt;
        }

        private DataTable CreateGroup()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Group", typeof(string));

            dt.Rows.Add(new object[] { "0-RES電阻類" });
            dt.Rows.Add(new object[] { "1-CAP電容類" });
            dt.Rows.Add(new object[] { "2-IND電感類" });
            dt.Rows.Add(new object[] { "3-二三極管" });

            return dt;
        }
    }
}
