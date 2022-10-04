using MMS.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MMS
{
    public class AppInitializer
    {
        private static readonly AppInitializer _Instance = new AppInitializer();

        private readonly string _DBFileName = "MMS.db";
        private readonly string _SettingFileName = "MMS.xml";
        private string _UserDBPath;
        private string _UserSettingPath;

        public static AppInitializer Instance
        {
            get { return _Instance; }
        }

        private AppInitializer()
        {

        }

        public string AppDataPath
        {
            get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LUX_MMS"); }
        }

        public string UserDBPath 
        {
            get { return _UserDBPath; } 
        }
        public string UserSettingPath
        { 
            get { return _UserSettingPath; } 
        }

        private string DefaultDBPath
        {
            get { return Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DB"), "Default.db"); }
        }

        private string DefaultSettingPath
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Setting.xml"); }
        }                

        public void Initialize()
        {
            InitializeUserFolder();

            InitializeDatabase();

            InitializeSetting();
        }

        private void InitializeUserFolder()
        {
            if (Directory.Exists(AppDataPath) == false)
            {
                DirectoryInfo info = Directory.CreateDirectory(AppDataPath);
                if (info.Exists == false)
                {
                    throw new DirectoryNotFoundException("Initialize application folder failed.");
                }
            }
        }

        private void InitializeDatabase()
        {
            _UserDBPath = Path.Combine(AppDataPath, _DBFileName);

            if (File.Exists(_UserDBPath) == false)
            {
                try
                {
                    File.Copy(DefaultDBPath, _UserDBPath);
                }
                catch (Exception e)
                {
                    throw new AppInitializeException($"Initialize application database failed:{e.Message}");
                }
            }
        }

        private void InitializeSetting()
        {
            _UserSettingPath = Path.Combine(AppDataPath, _SettingFileName);

            if (File.Exists(_UserSettingPath) == false)
            {
                try
                {
                    File.Copy(DefaultSettingPath, _UserSettingPath);
                }
                catch(Exception e)
                {
                    throw new AppInitializeException($"Initialize application setting failed:{e.Message}");
                }
            }
        }
    }
}
