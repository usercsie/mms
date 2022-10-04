using MMS.Model;
using MMS.Setting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMS.Controller
{
    public class TransactionController
    {
        private TransactionModelAccess _TransactionAccess;
        private MaterialModelAccess _MaterialAccess;

        public TransactionController(TransactionModelAccess transactionAccess, MaterialModelAccess materialAccess)
        {
            _TransactionAccess = transactionAccess;
            _MaterialAccess = materialAccess;
        }


        public void Import(string xlsxFileName, bool append = false)
        {
            TransactionModelImport importer = new TransactionModelImport();
            TransactionModel[] models = importer.Load(xlsxFileName);

            if (append == false)
            {
                _TransactionAccess.DeleteAll();
            }

            AddData(models);
        }

        public void AddData(TransactionModel m)
        {
            _TransactionAccess.Insert(m);
        }

        public void AddData(TransactionModel[] models)
        {
            _TransactionAccess.Insert(models);
        }

        public int GetStock(string mpn)
        {
            var models = _TransactionAccess.SelectByMpn(mpn);

            int stock = 0;
            foreach (var m in models)
            {
                stock += m.GetStock();
            }

            return stock;
        }
        
        public List<TransactionRecord> GetTransactionRecords()
        {
            var transactions = _TransactionAccess.Select();
            var materials = _MaterialAccess.Select();

            return ToTransactionRecordList(transactions, materials);
            //List<TransactionRecord> records = new List<TransactionRecord>();
            //foreach (var t in transactions)
            //{
            //    var material = _MaterialAccess.SelectBy(t.MPN).FirstOrDefault();
            //    if (material == null)
            //    {
            //        material = new MaterialModel();
            //    }
            //    records.Add(new TransactionRecord(material, t));
            //}

            //return records;
        }
        public List<TransactionRecord> GetTransactionRecords(DateTime start, DateTime end)
        {
            var transactions = _TransactionAccess.Select(start, end);
            var materials = _MaterialAccess.Select();

            return ToTransactionRecordList(transactions, materials);

            //List<TransactionRecord> records = new List<TransactionRecord>();
            //foreach (var t in transactions)
            //{
            //    var material = _MaterialAccess.SelectBy(t.MPN).FirstOrDefault();
            //    if (material == null)
            //    {
            //        material = new MaterialModel();
            //    }
            //    records.Add(new TransactionRecord(material, t));
            //}

            //return records;
        }

        public List<TransactionRecord> GetTransactionRecords(string mpn)
        {
            List<TransactionModel> transactions;
            List<MaterialModel> materials;

            if (mpn.Contains('*') == true)
            {
                transactions = _TransactionAccess.SelectLikeByMpn(mpn);
                materials = _MaterialAccess.SelectLikeBy(mpn);
            }
            else
            {
                transactions = _TransactionAccess.SelectByMpn(mpn);
                materials = _MaterialAccess.SelectBy(mpn);
            }
            return ToTransactionRecordList(transactions, materials);
        }

        public List<TransactionRecord> GetTransactionRecords(string mpn, DateTime start, DateTime end)
        {
            List<TransactionModel> transactions;
            List<MaterialModel> materials;

            if (mpn.Contains('*') == true)
            {
                transactions = _TransactionAccess.SelectLikeByMpn(mpn, start, end);
                materials = _MaterialAccess.SelectLikeBy(mpn);
            }
            else
            {
                transactions = _TransactionAccess.SelectByMpn(mpn);
                materials = _MaterialAccess.SelectBy(mpn);
            }
            return ToTransactionRecordList(transactions, materials);
        }

        private static List<TransactionRecord> ToTransactionRecordList(List<TransactionModel> transactions, List<MaterialModel> materials)
        {
            List<TransactionRecord> records = new List<TransactionRecord>();
            foreach (var t in transactions)
            {
                MaterialModel model = materials.Where(v => v.MPN == t.MPN).FirstOrDefault();
                if (model == null)
                {
                    model = new MaterialModel();
                }                
                records.Add(new TransactionRecord(model, t));
            }

            return records;
        }

        public TransactionRecord GetTransactionRecord(string id)
        {
            var transaction = _TransactionAccess.SelectById(id);
            var material = _MaterialAccess.SelectBy(transaction.MPN).FirstOrDefault();
            if  (material == null)
            {
                material = new MaterialModel();
            }    
            return new TransactionRecord(material, transaction);
        }

        public int DeleteData(string id)
        {
            return _TransactionAccess.DeleteBy(id);
        }

        public void SetData(TransactionModel model)
        {
            _TransactionAccess.Update(model);
        }

        public static string ToFullMoveType(MoveTypeParam p)
        {
            return $"{p.Id} ({p.Operator})";
        }

        public static uint ParseMoveTypeId(string fullMoveType)
        {
            return Convert.ToUInt32(fullMoveType.Split(' ').First());
        }
    }
}
