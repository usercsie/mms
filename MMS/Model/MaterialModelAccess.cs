using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace MMS.Model
{
    public class MaterialModelAccess
    {
        private string _DBPath;

        private string TableName
        {
            get { return "MaterialDefaultTable"; }
        }

        public MaterialModelAccess(string dbPath)
        {
            _DBPath = dbPath;
        }
        
        public int GetRowCount()
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                return cnn.ExecuteScalar<int>($"select count(1) from {TableName}");
            }
        }
        public List<MaterialModel> Select()
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                var output = cnn.Query<MaterialModel>($"select * from {TableName}", new DynamicParameters());
                return output.ToList();
            }
        }

        public List<MaterialModel> Select(uint pageIndex, int pageSize)
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                if (pageIndex == 0)
                {
                    return cnn.Query<MaterialModel>($"select * from {TableName} limit {pageSize}", new DynamicParameters()).ToList();
                }
                else
                {
                    int offset = (int)pageIndex * pageSize;
                    return cnn.Query<MaterialModel>($"select * from {TableName} limit {pageSize} offset {offset}", new DynamicParameters()).ToList();
                }
            }
        }

        public List<MaterialModel> SelectBy(string mpn)
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {                
                var output = cnn.Query<MaterialModel>($"select * from {TableName} where MPN = @p", new { p = mpn });
                return output.ToList();
            }
        }

        public List<MaterialModel> SelectLikeBy(string mpn)
        {
            mpn = mpn.Replace('*', '%');

            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                var output = cnn.Query<MaterialModel>($"select * from {TableName} where MPN like @p", new { p = mpn });
                return output.ToList();
            }
        }

        public int Insert(MaterialModel material)
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                return cnn.Execute($"insert into {TableName} values (@MPN, @PN, @DESC, @Manufacturer, @Flock, @Warehouse)", material);
            }
        }

        public int Insert(MaterialModel[] materials)
        {
            using (var cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                //using SQLiteTransaction to accelerate data to db. 
                cnn.Open();
                using (SQLiteTransaction tran = cnn.BeginTransaction())
                {
                    int rowAffected = 0;
                    foreach (var m in materials)
                    {
                        rowAffected += cnn.Execute($"insert into {TableName} values (@MPN, @PN, @DESC, @Manufacturer, @Flock, @Warehouse)", m);
                    }

                    tran.Commit();
                    return rowAffected;
                }
            }
        }

        public int DeleteAll()
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                return cnn.Execute("delete from " + TableName);
            }
        }

        public int DeleteBy(string mpn)
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                return cnn.Execute($"delete from {TableName} where MPN = @p", new { p = mpn });
            }
        }

        public int Update(MaterialModel m)
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=" + _DBPath))
            {
                string statement = @$"
                                  UPDATE {TableName}
                                  SET PN = @pPN,
                                      DESC = @pDESC,
                                      Manufacturer = @pManufacturer,
                                      Flock = @pFlock,
                                      Warehouse = @pWarehouse
                                  WHERE MPN= @pMPN
                                 ";
                return cnn.Execute(statement, new
                {
                    pMPN = m.MPN,
                    pPN = m.PN,
                    pDESC = m.DESC,
                    pManufacturer = m.Manufacturer,
                    pFlock = m.Flock,
                    pWarehouse = m.Warehouse
                });
            }
        }
    }
}
