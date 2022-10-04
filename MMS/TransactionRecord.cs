using MMS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS
{
    public class TransactionRecord
    {
        private MaterialModel _Material;
        private TransactionModel _Transaction;

        public string Id { get { return _Transaction.Id; } }
        public string MPN { get { return _Transaction.MPN; } }
        public string PN { get { return _Material.PN; } }
        public string DESC { get { return _Material.DESC; } }
        public string Manufacturer { get { return _Material.Manufacturer; } }
        public string Warehouse { get { return _Material.Warehouse; } }
        public uint MoveType { get { return _Transaction.MoveType; } }
        public string Date { get { return _Transaction.Date; } }
        public int Stock { get { return _Transaction.GetStock(); } }

        public TransactionRecord(MaterialModel material, TransactionModel transaction)
        {
            _Material = material;
            _Transaction = transaction;
        }

        public void ChangeModel(TransactionModel model)
        {
            _Transaction = model;
        }
    }
}
