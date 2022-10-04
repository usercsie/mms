using MMS.Setting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Model
{
    public class TransactionModel
    {
        public string Id { get; private set; }
        public string MPN { get; set; }
        public uint MoveType { get; set; }        
        public string Date { get; set; }//format: YYYY-MM-DD
        public uint Quantity { get; set; }

        public TransactionModel()
        {
            Id = Guid.NewGuid().ToString();
        }
        public TransactionModel(string mpn, uint moveType, uint quantity, string date)
            :this()
        {
            MPN = mpn;
            MoveType = moveType;
            Quantity = quantity;
            Date = date;
        }
        public TransactionModel(string id, string mpn, uint moveType, uint quantity, string date)    
        {
            Id = id;
            MPN = mpn;
            MoveType = moveType;
            Quantity = quantity;
            Date = date;
        }

        public int GetStock()
        {
            MoveTypeEffect effect =  Settings.Instance.GetMoveTypeEffect(MoveType);

            if (effect == MoveTypeEffect.Plus)
            {
                return (int)Quantity;
            }
            else if (effect == MoveTypeEffect.Minus)
            {
                return (int)(Quantity) * -1;
            }
            else
            {
                throw new ArgumentException("Undefine MoveType:" + MoveType);
            }
        }

        public override bool Equals(object obj) => this.Equals(obj as TransactionModel);

        public bool Equals(TransactionModel p)
        {
            if (p is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, p))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != p.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (MPN == p.MPN) &&
                   (MoveType == p.MoveType) &&
                   (Quantity == p.Quantity);
        }

        public override int GetHashCode()
        {
            return (MPN, MoveType, Quantity).GetHashCode();
        }

        public static bool operator ==(TransactionModel lhs, TransactionModel rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(TransactionModel lhs, TransactionModel rhs) => !(lhs == rhs);

        public static string ToDate(DateTime date)
        {
            return date.ToString("yyyy'-'MM'-'dd");            
        }
    }
}
