using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoTFEditor
{
    public static class SaveManager
    {
        public static readonly string inventoryFile = "PlayerInventorySaveData.json";
        public static readonly string playerArmorFile = "PlayerArmourSystemSaveData.json";

        static string _savesPath;
        static string _folder;
        static string _completePath;

        public static string completePath
        {
            get { return _completePath; }
        }

        public static string savesPath
        {
            get { return _savesPath; }
        }

        public static string folder
        {
            get { return _folder; }
        }

        public static void setGameSavePath()
        {
            string localLow = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");

            _savesPath = localLow + @"\Endnight\SonsOfTheForest\Saves\";
        }

        public static string[] getUserDirectories()
        {
            return Directory.GetDirectories(_savesPath, "*", SearchOption.TopDirectoryOnly);
        }

        public static string[] getSavesDirectories(string userID)
        {
            return Directory.GetDirectories(_savesPath + userID + @"\" + _folder, "*", SearchOption.TopDirectoryOnly);
        }

        public static void changeCompletePath(string userID, string savesID)
        {
            _completePath = _savesPath + userID + @"\" + _folder + @"\" + savesID + @"\";
        }

        public static void changeFolder(string newFolder)
        {
            _folder = newFolder;
        }
    }
}
