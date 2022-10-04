using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using System.Linq;

namespace MMS.Setting
{
    public class SettingWriter
    {
        public SettingWriter()
        {

        }

        public void WriteMoveType(DataTable dt, string fullFileName)
        {
            SettingReader reader = new SettingReader();
            reader.Read(fullFileName);

            reader.SetMoveTypeParameter(dt);

            Save(reader, fullFileName);
        }
        public void WriteGroup(DataTable dt, string fullFileName)
        {
            SettingReader reader = new SettingReader();
            reader.Read(fullFileName);

            reader.SetGroupParameter(dt);

            Save(reader, fullFileName);
        }

        public void Save(SettingReader reader, string fullFileName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = new UTF8Encoding(false);
            settings.NewLineChars = Environment.NewLine;

            using (XmlWriter xmlWriter = XmlWriter.Create(fullFileName, settings))
            {
                xmlWriter.WriteStartDocument(false);
                xmlWriter.WriteStartElement("MMS");
                xmlWriter.WriteStartElement("Settings");

                //Group +
                xmlWriter.WriteStartElement(SettingType.Group.ToString());
                foreach (string p in reader.GroupParameter)
                {                    
                    xmlWriter.WriteElementString("Item", p);
                }
                xmlWriter.WriteEndElement();
                //Group -

                //MoveType +
                xmlWriter.WriteStartElement(SettingType.MoveType.ToString());
                foreach (var p in reader.MoveTypeParameter)
                {
                    xmlWriter.WriteStartElement("Item");
                    xmlWriter.WriteAttributeString(SettingReader.AttributeId, p.Id.ToString());
                    xmlWriter.WriteAttributeString(SettingReader.AttributeDesc, p.Desc);
                    xmlWriter.WriteAttributeString(SettingReader.AttributeOperator, p.Operator);

                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
                //MoveType -

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();//End of MMS
                xmlWriter.WriteEndDocument();

            }
        }  
    }
}
