using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace MMS.Model
{
    public class TransactionModelAccess
    {
        private string _DBPath;

        private string TableName
        {
            get { return "TransactionTable"; }
        }

        public TransactionModelAccess(string dbPath)
        {
            _DBPath = dbPath;
        }

        public List<TransactionModel> Select()
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                var output = cnn.Query<TransactionModel>("select * from " + TableName, new DynamicParameters());
                return output.ToList();
            }
        }
        public List<TransactionModel> Select(DateTime start, DateTime end)
        {
            string startDate = TransactionModel.ToDate(start);
            string endDate = TransactionModel.ToDate(end);
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {                
                var output = cnn.Query<TransactionModel>(@$"select * from {TableName} 
                                                            where Date between @pStart and @pEnd",
                                                             new { pStart = startDate, pEnd = endDate });
                return output.ToList();
            }
        }

        public TransactionModel SelectById(string id)
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                var output = cnn.Query<TransactionModel>($"select * from {TableName} where Id = @p", new { p = id });
                return output.FirstOrDefault();
            }
        }

        public List<TransactionModel> SelectByMpn(string mpn)
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                var output = cnn.Query<TransactionModel>($"select * from {TableName} where MPN = @p", new { p = mpn });
                return output.ToList();
            }
        }

        public List<TransactionModel> SelectByMpn(string mpn, DateTime start, DateTime end)
        {
            string startDate = TransactionModel.ToDate(start);
            string endDate = TransactionModel.ToDate(end);
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                var output = cnn.Query<TransactionModel>(@$"select * from {TableName} 
                                                            where MPN = @pMpn and Date between @pStart and @pEnd", 
                                                            new { pMpn = mpn, pStart = startDate, pEnd = endDate });
                return output.ToList();
            }
        }

        public List<TransactionModel> SelectLikeByMpn(string mpn)
        {
            mpn = mpn.Replace('*', '%');

            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                var output = cnn.Query<TransactionModel>($"select * from {TableName} where MPN like @p", new { p = mpn });
                return output.ToList();
            }
        }

        public List<TransactionModel> SelectLikeByMpn(string mpn, DateTime start, DateTime end)
        {
            mpn = mpn.Replace('*', '%');

            string startDate = TransactionModel.ToDate(start);
            string endDate = TransactionModel.ToDate(end);
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                var output = cnn.Query<TransactionModel>(@$"select * from {TableName} 
                                                            where MPN like @pMpn and Date between @pStart and @pEnd",
                                                           new { pMpn = mpn, pStart = startDate, pEnd = endDate });
                return output.ToList();
            }
        }

        public void Insert(TransactionModel m)
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                cnn.Execute($"insert into {TableName} (Id, MPN, MoveType, Date, Quantity) values (@pId, @pMPN, @pMoveType, @pDate, @pQuantity)",
                            new
                            {
                                pId = m.Id,
                                pMPN = m.MPN,
                                pMoveType = m.MoveType,
                                pDate = m.Date,
                                pQuantity = m.Quantity
                            });            
            }
        }

        public void Insert(TransactionModel[] ms)
        {
            using (var cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                cnn.Open();
                using (SQLiteTransaction tran = cnn.BeginTransaction())
                {
                    foreach (var m in ms)
                    {
                        cnn.Execute($"insert into {TableName} (Id, MPN, MoveType, Date, Quantity) values (@pId, @pMPN, @pMoveType, @pDate, @pQuantity)",
                                    new
                                    {
                                        pId = m.Id,
                                        pMPN = m.MPN,
                                        pMoveType = m.MoveType,
                                        pDate = m.Date,
                                        pQuantity = m.Quantity
                                    });
                    }

                    tran.Commit();
                }
            }
        }

        public int DeleteAll()
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                return cnn .Execute("delete from " + TableName);
            }
        }

        public int DeleteBy(string id)
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                return cnn.Execute($"delete from {TableName} where Id = @p", new { p = id });
            }
        }

        public int Update(TransactionModel m)
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                string statement = @$"
                                  UPDATE {TableName}
                                  SET Id = @pId,
                                      MPN = @pMpn,
                                      MoveType = @pMoveType,
                                      Date = @pDate,
                                      Quantity = @pQuantity
                                  WHERE Id= @pId
                                 ";                
                return cnn.Execute(statement, new
                {
                    pId = m.Id,
                    pMPN = m.MPN,                    
                    pMoveType = m.MoveType,
                    pDate = m.Date,
                    pQuantity = m.Quantity
                });
            }
        }

    }
}
