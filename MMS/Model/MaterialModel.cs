using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Model
{
    public class MaterialModel
    {
        public string MPN { get; set; }
        public string PN { get; set; }
        public string DESC { get; set; }
        public string Manufacturer { get; set; }
        public string Flock { get; set; }
        public string Warehouse { get; set; }

        public MaterialModel()
        {

        }

        public MaterialModel(string mpn, string pn, string desc, 
            string manufacturer, string flock, string warehouse)
        {
            MPN = mpn;
            PN = pn;
            DESC = desc;
            Manufacturer = manufacturer;
            Flock = flock;
            Warehouse = warehouse;
        }

        public override bool Equals(object obj) => this.Equals(obj as MaterialModel);

        public bool Equals(MaterialModel p)
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
                   (PN == p.PN) &&
                   (DESC == p.DESC) &&
                   (Manufacturer == p.Manufacturer) &&
                   (Flock == p.Flock) &&
                   (Warehouse == p.Warehouse);
        }

        public override int GetHashCode()
        {
            return (MPN, PN, DESC, Manufacturer, Flock, Warehouse).GetHashCode();
        }

        public static bool operator ==(MaterialModel lhs, MaterialModel rhs)
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

        public static bool operator !=(MaterialModel lhs, MaterialModel rhs) => !(lhs == rhs);
    }
}
