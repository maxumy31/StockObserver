using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StockObserver.Configs
{
    public class ConfigHandler
    {
        string _configName = "Settings";
        IniFile _iniFile;
        public ConfigHandler()
        {
            _iniFile = new IniFile(_configName);

            if (!File.Exists(_iniFile.Path)) CreateEmptyConfigFile();
        }

        public ConfigData GetConfigData()
        {
            ConfigData data = new ConfigData();
            data.x = ReadInt("x");
            data.y = ReadInt("y");
            data.width = ReadInt("width");
            data.height = ReadInt("height");


            return data;
        }

        public void CreateEmptyConfigFile()
        {
            Console.WriteLine("Created empty config");

            var dpi = System.Windows.Media.VisualTreeHelper.GetDpi(new System.Windows.Controls.Control());
            var screenRealWidth = SystemParameters.PrimaryScreenWidth * dpi.DpiScaleX;
            var screenRealHeight = SystemParameters.PrimaryScreenHeight * dpi.DpiScaleY;

            int expectedWidth = 400;
            int expectedHeight = 240;

            _iniFile.Write("width", expectedWidth.ToString());
            _iniFile.Write("height", expectedHeight.ToString());


            _iniFile.Write("x", (screenRealWidth - expectedWidth).ToString());
            _iniFile.Write("y", (screenRealHeight - expectedHeight).ToString());
            
        }

        private int ReadInt(string key)
        {
            int value;
            string result = _iniFile.Read(key);

            bool success = int.TryParse(result,out value);
            if (!success) { Console.WriteLine("Reading config error! Error key is " + key); return 0; }
            return value;
        }

        public struct ConfigData
        {
            public int x;
            public int y;
            public int width;
            public int height;
        }
    }
}
