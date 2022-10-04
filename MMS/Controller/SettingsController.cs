using MMS.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;

namespace MMS.Controller
{
    public class SettingsController
    {
        private string _SettingFilePath;
        private SettingReader _Reader;

        public MoveTypeParam[] MoveTypeParameter
        {
            get { return _Reader.MoveTypeParameter.ToArray(); }
        }
        public string[] GroupParameter
        {
            get { return _Reader.GroupParameter.ToArray(); }
        }
        
        public SettingsController(string fullFileName)        
        {            
            _SettingFilePath = fullFileName;

            if (File.Exists(_SettingFilePath) == false)
            {
                SettingWriter writer = new SettingWriter();
                writer.Save(_Reader, _SettingFilePath);
            }

            _Reader = new SettingReader();
            _Reader.Read(fullFileName);
        }

        public DataTable CreateMoveTypeTable(MoveTypeParam[] parameters)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MoveType", typeof(int));            
            dt.Columns.Add("DESC", typeof(string));
            dt.Columns.Add("Operator", typeof(string));
            foreach (var p in parameters)
            {
                dt.Rows.Add(new object[]
                {
                    p.Id,
                    p.Desc,
                    p.Operator
                });
            }

            return dt;
        }

        public DataTable CreateGroupTable(string[] parameters)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Name", typeof(string));
            foreach (var p in parameters)
            {
                dt.Rows.Add(new object[] { p });
            }

            return dt;
        }

        public DataTable Add(MoveTypeParam p)
        {
            if (MoveTypeExisted(p.Id) == true)
            {
                throw new ArgumentException($"Move type existed already:{p.Id}");
            }

            _Reader.MoveTypeParameter.Add(p);
            DataTable dt = CreateMoveTypeTable(_Reader.MoveTypeParameter.ToArray());
            WriteMoveType(dt);
            
            return dt;
        }

        public DataTable Add(string group)
        {
            if (string.IsNullOrEmpty(group.Trim()) == true)
            {
                throw new ArgumentException("Group cannot be blank.");
            }
            if (GroupExisted(group) == true)
            {
                throw new ArgumentException("Group existed already.");
            }

            _Reader.GroupParameter.Add(group);
            DataTable dt = CreateGroupTable(_Reader.GroupParameter.ToArray());
            WriteGroup(dt);

            return dt;
        }

        private bool GroupExisted(string group)
        {
            return _Reader.GroupParameter.Where(v => v == group).Count() > 0;
        }

        public DataTable Delete(SettingType type, int rowIndex)
        {
            if (type == SettingType.MoveType)
            {
                if (rowIndex >= _Reader.MoveTypeParameter.Count)
                {
                    throw new IndexOutOfRangeException($"index out of range:{rowIndex}");
                }
                _Reader.MoveTypeParameter.RemoveAt(rowIndex);
                DataTable dt = CreateMoveTypeTable(_Reader.MoveTypeParameter.ToArray());
                WriteMoveType(dt);
                return dt;
            }
            else if (type == SettingType.Group)
            {
                if (rowIndex >= _Reader.GroupParameter.Count)
                {
                    throw new IndexOutOfRangeException($"index out of range:{rowIndex}");
                }
                _Reader.GroupParameter.RemoveAt(rowIndex);
                DataTable dt = CreateGroupTable(_Reader.GroupParameter.ToArray());
                WriteGroup(dt);
                return dt;
            }
            else
                throw new ArgumentException();
        }

        private bool MoveTypeExisted(uint id)
        {
            return _Reader.MoveTypeParameter.Where(v => v.Id == id).Count() > 0;
        }

        private void WriteMoveType(DataTable table)
        {
            SettingWriter writer = new SettingWriter();
            writer.WriteMoveType(table, _SettingFilePath);
            ReLoad();
        }

        private void WriteGroup(DataTable table)
        {
            SettingWriter writer = new SettingWriter();
            writer.WriteGroup(table, _SettingFilePath);
            ReLoad();
        }

        private void ReLoad()
        {
            _Reader.Read(_SettingFilePath);
        }
    }
}
