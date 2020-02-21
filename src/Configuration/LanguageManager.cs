using System;
using System.IO;
using ClassicUO.IO.Resources;
using ClassicUO.Utility;
using ClassicUO.Utility.Logging;

using Newtonsoft.Json;

namespace ClassicUO.Configuration
{
    internal static class LanguageManager
    {
        public enum Languages
        {
            English,
            SimChinese,
            TraChinese
        };
        public static Language Current { get; private set; }

        public static void Load(string language)
        {
            string path = FileSystemHelper.CreateFolderIfNotExists(CUOEnviroment.ExecutablePath, "Language");


            string fileToLoad = Path.Combine(path, language);

            if (!File.Exists(fileToLoad))
                Current = new Language();
            else
            { 
                Current = ConfigurationResolver.Load <Language>(fileToLoad,
                                                              new JsonSerializerSettings
                                                              {
                                                                  TypeNameHandling = TypeNameHandling.All,
                                                                  MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
                                                              });
                if (Current == null)
                {
                    Current = new Language();
                }
            }
        }
        public static void SwitchLanguage()
        {
            string filename;
            switch (ProfileManager.Current.Language)
            {
                default:
                case Languages.English:
                    filename = "English.json";
                    Settings.GlobalSettings.ClilocFile = "Cliloc.enu";
                    break;
                case Languages.SimChinese:
                    filename = "SimChinese.json";
                    Settings.GlobalSettings.ClilocFile = "Cliloc.chs";
                    break;
                case Languages.TraChinese:
                    filename = "TraChinese.json";
                    Settings.GlobalSettings.ClilocFile = "Cliloc.cht";
                    break;
                
            }
            Load(filename);
            ClilocLoader.Instance.Load(Settings.GlobalSettings.ClilocFile);

        }
 

    }
}
