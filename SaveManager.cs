using System;
using System.Collections.Generic;
using System.IO.Compression;

namespace SoTFEditor
{
    public static class SaveManager
    {
        const string inventoryFile = "PlayerInventorySaveData.json";
        const string playerArmorFile = "PlayerArmourSystemSaveData.json";
        const string emptyInventorySave = @"\Files\emptyInventorySave.txt";

        public const string saveThumbnail = "SaveDataThumbnail.png";

        static string _savesPath;
        static string _folder;
        static string _completePath;
        static string _inventorySaveString;
        static string _armorSaveString;

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
                if(_inventorySaveString == null)
                {
                    _inventorySaveString = File.ReadAllText(SaveManager.completePath + SaveManager.inventoryFile);
                }
                return _inventorySaveString;
            }
        }

        public static string armorSaveString
        {
            get
            {
                if(_armorSaveString == null)
                {
                    _armorSaveString = File.ReadAllText(SaveManager.completePath + SaveManager.playerArmorFile);
                }
                return _armorSaveString;
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
            if(Directory.Exists(_savesPath + userID + @"\" + _folder))
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
            _inventorySaveString = File.ReadAllText(SaveManager.completePath + SaveManager.inventoryFile);
            _armorSaveString = File.ReadAllText(SaveManager.completePath + SaveManager.playerArmorFile);
        }

        public static void changeFolder(string newFolder)
        {
            _folder = newFolder;
        }

        public static void writeToFile(saveFile selectedFile, string inputString, bool replace = false)
        {
            switch(selectedFile)
            {
                case saveFile.inventory:
                    if(replace)
                    {
                        File.Copy(System.Windows.Forms.Application.StartupPath + emptyInventorySave, completePath + inventoryFile, true);
                    }
                    else
                    {
                        File.WriteAllText(completePath + inventoryFile, inputString);
                    }
                    _inventorySaveString = File.ReadAllText(SaveManager.completePath + SaveManager.inventoryFile);
                    break;
                case saveFile.playerArmor:
                    File.WriteAllText(completePath + playerArmorFile, inputString);
                    _armorSaveString = File.ReadAllText(SaveManager.completePath + SaveManager.playerArmorFile);
                    break;
            }
        }

        public static void createBackupFile()
        {
            if(folder == null)
            {
                MessageBox.Show("Please select SaveGame first", "Create Backup tool");
            }
            else
            {
                //string zipName = completePath.Split(@"\").Reverse().Skip(1).First() + ".rar";
                //string zipPath = completePath.Split(folder + @"\")[0];
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

            if(!File.Exists(completeBackupName+".rar"))
            {
                return completeBackupName + ".rar";
            }

            var i = 1;

            do
            {
                completeBackupName = backupPath + folder + @"\" + backupName + $"_{i++}";
            } while(File.Exists(completeBackupName + ".rar"));

            return completeBackupName + ".rar";
        }
    }

    public enum saveFile
    {
        inventory,
        playerArmor
    }
}
