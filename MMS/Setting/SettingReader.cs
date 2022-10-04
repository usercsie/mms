using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

namespace MMS.Setting
{
    public class SettingReader
    {
        public static readonly string AttributeId = "Id";
        public static readonly string AttributeDesc = "DESC";
        public static readonly string AttributeOperator = "Operator";

        private List<string> _Groups;
        private List<MoveTypeParam> _MoveTypes;

        public List<string> GroupParameter { get { return _Groups; } }
        public List<MoveTypeParam> MoveTypeParameter { get { return _MoveTypes; } }

        public SettingReader()
        {
            Default();
        }

        public void Read(string fullFileName)
        {
            _Groups = new List<string>();
            _MoveTypes = new List<MoveTypeParam>();

            SettingType currentType = SettingType.Nan;
            using (XmlReader reader = XmlReader.Create(fullFileName))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        currentType = UpdateCurrentType(currentType, reader.Name);
                    }
                    if (reader.NodeType == XmlNodeType.Text || reader.HasAttributes == true)
                    {
                        AddParameter(currentType, reader);
                    }
                }
            }
        }

        public void SetGroupParameter(DataTable dt)
        {
            _Groups.Clear();

            foreach(DataRow row in dt.Rows)
            {
                DataColumn col = dt.Columns[0];                
                _Groups.Add(row[col].ToString());
            }
        }

        public void SetMoveTypeParameter(DataTable dt)
        {
            _MoveTypes.Clear();

            foreach (DataRow row in dt.Rows)
            {
                DataColumn col = dt.Columns[0];

                uint id = Convert.ToUInt32(row[0].ToString());
                string desc = row[1].ToString();
                string op = row[2].ToString();
                _MoveTypes.Add(new MoveTypeParam() { Id = id, Desc = desc, Operator = op });
            }
        }

        private void AddParameter(SettingType currentType, XmlReader reader)
        {
            if (currentType == SettingType.Group && reader.NodeType == XmlNodeType.Text)
            {
                _Groups.Add(reader.Value);
            }
            else if (currentType == SettingType.MoveType)
            {
                if (reader.HasAttributes == true)
                {
                    MoveTypeParam param = new MoveTypeParam()
                    {
                        Id = Convert.ToUInt32(reader.GetAttribute(AttributeId)),
                        Desc = reader.GetAttribute(AttributeDesc),
                        Operator = reader.GetAttribute(AttributeOperator)
                    };
                    _MoveTypes.Add(param);
                }
            }
        }

        private SettingType UpdateCurrentType(SettingType currentType, string name)
        {
            if (name == SettingType.Group.ToString())
            {
                return SettingType.Group;
            }
            else if (name == SettingType.MoveType.ToString())
            {
                return SettingType.MoveType;
            }
            else
                return currentType;
        }

        private void Default()
        {
            _Groups = new List<string>()
            {
                "0-RES電阻類",
                "1-CAP電容類",
                "2-IND電感類",
                "3-二三極管",
            };

            _MoveTypes = new List<MoveTypeParam>()
            {
                new MoveTypeParam() { Id = 101, Desc = "材料收料", Operator = "+" },
                new MoveTypeParam() { Id = 102, Desc = "材料收料-錯誤反冲", Operator = "-" },
                new MoveTypeParam() { Id = 601, Desc = "材料出貨", Operator = "-" },
                new MoveTypeParam() { Id = 602, Desc = "材料出貨-錯誤反冲", Operator = "+" },
            };
        }
    }
}
