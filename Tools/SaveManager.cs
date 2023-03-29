using Newtonsoft.Json;
using System.IO.Compression;

namespace SoTFEditor.Tools
{
    public static class SaveManager
    {
        const string inventoryFile = "PlayerInventorySaveData.json";
        const string playerArmorFile = "PlayerArmourSystemSaveData.json";
        public const string blueprintFile = "ScrewStructureNodeInstancesSaveData.json";
        const string emptyInventorySave = @"\data\samples\emptyInventorySave.txt";

        static string _savesPath;
        static string _folder;
        static string _completePath;
        static string _inventorySaveString;
        static string _armorSaveString;
        static string _blueprintSaveString;

        public const string saveThumbnail = "SaveDataThumbnail.png";
        public static bool pathSet = false;

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

        public static string inventorySaveString
        {
            get
            {
                if (_inventorySaveString == null)
                {
                    _inventorySaveString = File.ReadAllText(completePath + inventoryFile);
                }
                return _inventorySaveString;
            }
        }

        public static string armorSaveString
        {
            get
            {
                if (_armorSaveString == null)
                {
                    _armorSaveString = File.ReadAllText(completePath + playerArmorFile);
                }
                return _armorSaveString;
            }
        }

        public static string blueprintSaveString
        {
            get
            {
                _blueprintSaveString = File.ReadAllText(completePath + blueprintFile); 

                return _blueprintSaveString;
            }
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

        public static bool getSavesDirectories(string userID, out string[] dirList)
        {
            if (Directory.Exists(_savesPath + userID + @"\" + _folder))
            {
                dirList = Directory.GetDirectories(_savesPath + userID + @"\" + _folder, "*", SearchOption.TopDirectoryOnly);
                return true;
            }
            else
            {
                MessageBox.Show(string.Format("SaveFiles for \n\n{0} \n\ncould not be found", _savesPath + userID + @"\" + _folder), "Error in loading files");
                dirList = new string[] { };
                return false;
            }
        }

        public static void changeCompletePath(string userID, string savesID, string folder = "")
        {
            _completePath = _savesPath + userID + @"\" + _folder + @"\" + savesID + @"\";
            pathSet = true;
            _inventorySaveString = File.ReadAllText(completePath + inventoryFile);
            _armorSaveString = File.ReadAllText(completePath + playerArmorFile);
        }

        public static void changeFolder(string newFolder)
        {
            _folder = newFolder;
        }

        public static void writeToFile(saveFile selectedFile, string inputString, bool replace = false)
        {
            switch (selectedFile)
            {
                case saveFile.inventory:
                    if (replace)
                    {
                        File.Copy(Application.StartupPath + emptyInventorySave, completePath + inventoryFile, true);
                    }
                    else
                    {
                        File.WriteAllText(completePath + inventoryFile, inputString);
                    }
                    _inventorySaveString = File.ReadAllText(completePath + inventoryFile);
                    break;
                case saveFile.playerArmor:
                    File.WriteAllText(completePath + playerArmorFile, inputString);
                    _armorSaveString = File.ReadAllText(completePath + playerArmorFile);
                    break;
                case saveFile.structureBlueprints:
                    File.WriteAllText(completePath + blueprintFile, inputString);
                    _blueprintSaveString = File.ReadAllText(completePath + blueprintFile);
                    break;
            }
        }

        public static void createBackupFile()
        {
            if (folder == null)
            {
                MessageBox.Show("Please select SaveGame first", "Create Backup tool");
            }
            else
            {
                string backupName = getBackupName();
                string targetFolder = completePath.Remove(completePath.Length - 1);
                ZipFile.CreateFromDirectory(targetFolder, backupName, 0, true);
                MessageBox.Show($"Backup created at \n{backupName}");
            }
        }

        private static string getBackupName()
        {
            string backupPath = completePath.Split(folder + @"\")[0];
            string backupName = completePath.Split(@"\").Reverse().Skip(1).First();
            string completeBackupName = backupPath + folder + @"\" + backupName;

            if (!File.Exists(completeBackupName + ".rar"))
            {
                return completeBackupName + ".rar";
            }

            var i = 1;

            do
            {
                completeBackupName = backupPath + folder + @"\" + backupName + $"_{i++}";
            } while (File.Exists(completeBackupName + ".rar"));

            return completeBackupName + ".rar";
        }
    }

    public enum saveFile
    {
        inventory,
        playerArmor,
        structureBlueprints
    }
}
