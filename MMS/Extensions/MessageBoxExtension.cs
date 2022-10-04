using System;
using System.Data.SQLite;
using System.Windows.Forms;


namespace MMS.Extensions
{
    public static class MessageBoxEx
    {
        public static void ShowSQLWarning(SQLiteException ex)
        {            
            MessageBox.Show($"Operation failed:{ex.Message}. ({ex.ErrorCode})", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowOperationError(Exception ex)
        {
            MessageBox.Show($"Operation failed:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
