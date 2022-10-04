using System;
using System.IO;

namespace MMS
{
    internal class Logger
    {
        private static object _LockObject = new object();
        internal static Logger _Instance = new Logger();
        internal static Logger Instance
        {
            get { return _Instance; }
        }
        
        private string _LogFileName;

        private Logger()
        {            
        }

        internal void Init(string filePath)
        {            
            CreatePath(filePath);

            _LogFileName = Path.Combine(filePath, $"{ DateTime.Now.ToString("yyyymmdd")}.log" );
            if (!File.Exists(filePath))
            {
                File.Create(_LogFileName).Close();
            }
        }

        private void CreatePath(string path)
        {
            DirectoryInfo info = Directory.CreateDirectory(path);

            if (info.Exists == false)
            {
                throw new DirectoryNotFoundException(string.Format("Failed to create folder: {0} (1215)", path));
            }
        }

        internal void Message(string message)
        {
            WriteLine(FormatMessage("Normal", message));
            Console.WriteLine(FormatMessage("Normal", message));
        }

        internal void Warning(string message)
        {
            WriteLine(FormatMessage("Warning", message));
            Console.WriteLine(FormatMessage("Warning", message));
        }

        internal void Error(string message)
        {
            WriteLine(FormatMessage("Error", message));
            Console.WriteLine(FormatMessage("Error", message));
        }

        private void WriteLine(string message)
        {
            lock (_LockObject)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(_LogFileName, true))
                    {
                        sw.WriteLine(message);
                        sw.Close();
                    }

                }
                catch (Exception) { }
            }
        }

        private string FormatMessage(string type, string message)
        {
            return string.Format(string.Format("{0}\t[{1}]:{2}", DateTime.Now.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss"), type, message));
        }
    }
}
