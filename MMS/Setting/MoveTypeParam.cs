using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Setting
{
    public enum SettingType
    {
        Nan,
        Group,
        MoveType
    }
    public enum MoveTypeEffect
    {
        Plus,
        Minus
    }
    public class MoveTypeParam
    {
        public uint Id { get; set; }
        public string Desc { get; set; }
        public string Operator { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is MoveTypeParam))
                return false;

            var other = obj as MoveTypeParam;

            return Id == other.Id || Desc == other.Desc || Operator == other.Operator;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
