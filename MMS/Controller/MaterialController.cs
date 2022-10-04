using MMS.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MMS.Controller
{
    public class MaterialController
    {
        private MaterialModelAccess _Access;

        public MaterialController(MaterialModelAccess access)
        {
            _Access = access;
        }

        public MaterialModel GetData(string mpn)
        {
            return SelectData(mpn).FirstOrDefault();
        }

        public List<MaterialModel> SelectData(string mpn = "")
        {
            if (mpn == "")
            {
                return _Access.Select();
            }
            else
            {
                if (mpn.Contains('*') == true)
                {
                    return _Access.SelectLikeBy(mpn);
                }
                else
                    return _Access.SelectBy(mpn);
            }
        }

        public void SetData(MaterialModel model)
        {
            _Access.Update(model);
        }        

        public void AddData(MaterialModel[] models)
        {
            _Access.Insert(models);
        }

        public void AddData(MaterialModel model)
        {
            _Access.Insert(model);
        }
        
        public void DeleteData(string mpn)
        {
            _Access.DeleteBy(mpn);
        }

        public string[] GetMpn()
        {
            return _Access.Select().Select(v => v.MPN).ToArray();
        }

        public void Import(string csvFileName)
        {
            MaterialModelImport importer = new MaterialModelImport();
            MaterialModel[] models = importer.Load(csvFileName);
            
            foreach (var m in models)
            {
                if (_Access.SelectBy(m.MPN).Count == 0)
                {
                    _Access.Insert(m);
                }
                else
                    _Access.Update(m);
            }
        }

        public bool IsIncompleted(MaterialModel model)
        {
            return string.IsNullOrEmpty(model.DESC) ||
                   string.IsNullOrEmpty(model.PN) ||
                   string.IsNullOrEmpty(model.Manufacturer) ||
                   string.IsNullOrEmpty(model.Flock) ||
                   string.IsNullOrEmpty(model.Warehouse);
        }
    }
}
