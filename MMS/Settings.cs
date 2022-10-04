using MMS.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MMS
{    
    public class Settings
    {
        private static Settings _Settings = new Settings();

        public static Settings Instance
        {
            get 
            { 
                return _Settings;
            }
        }

        private string[] _Groups;
        private MoveTypeParam[] _MoveTypes;

        public LoginUser CurrentUser { get; set; }

        private Settings()
        {
            _Groups = new string[0];
            _MoveTypes = new MoveTypeParam[0];

            CurrentUser = LoginUser.Viewer;
        }     

        public bool DataAccesible
        {
            get { return CurrentUser == LoginUser.Manager; }
        }

        public void SetMaterialGroupParameter(string[] parameter)
        {
            _Groups = parameter;
        }

        public void SetMoveTypeParameter(MoveTypeParam[] parameter)
        {
            _MoveTypes = parameter;
        }

        public MoveTypeEffect GetMoveTypeEffect(uint id)
        {
            var p = _MoveTypes.Where(v => v.Id == id).FirstOrDefault();

            if (p == null)
                throw new ArgumentException($"Move type {id} is undefined.");
            
            string str = p.Operator.Trim();
            if (str == "+")
            {
                return MoveTypeEffect.Plus;
            }
            else if (str == "-")
            {
                return MoveTypeEffect.Minus;
            }
            else
                throw new ArgumentException($"{str} is a undefined move type effect.");
        }

        public string[] GetMaterialGroups()
        {
            return _Groups.ToArray();
        }

        public MoveTypeParam[] GetMoveTypeParameters()
        {
            return _MoveTypes.ToArray();
        }

        public uint[] GetMoveTypeIds()
        {
            return _MoveTypes.Select(v => v.Id).ToArray();
        }
    }
}
