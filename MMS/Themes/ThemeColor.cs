using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MMS.Themes
{
    public static class ThemeColor
    {
        public static string ActivateButtonColor = "#DCDCDC";
        public static string NormalButtonColor = "#0C447E";
        public static string DisabledButtonColor = "#85A1BE";
        public static string ButtonForeColor = "#FFFFFF";
        public static string ColumnBackColor = "#252526";
        public static string ColumnForeColor = "#FFFFFF";
        //public static string 
    }

    public static class ThemeFont
    {
        public static Font GetColumnHeaderFont()
        {
            return new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        }
        public static Font GetCellFont()
        {
            return new Font("Microsoft JhengHei UI", 10F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        }

        public static Font GetMainButtonFont()
        {
            return new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        }
    }    
}
