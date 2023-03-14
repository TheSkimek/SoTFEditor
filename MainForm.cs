using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using CG.Web.MegaApiClient;
using System.IO.Compression;
using Microsoft.VisualBasic.ApplicationServices;

namespace SoTFEditor
{
    public partial class MainForm : Form
    {
        JObject saveFileObject;
        JObject inventoryObject;

        MegaApiClient client;
        string currentVersion, newVersion;
        bool needsUpdate;

        public Dictionary<string, string> ItemIds = new Dictionary<string, string>();

        string itemIDListFile = System.Windows.Forms.Application.StartupPath + @"Files\ItemIDList.csv";

        public MainForm()
        {
            InitializeComponent();
            Task.Factory.StartNew(() => buildVersionText());
            changeWriteButtonText(tabControl1.TabPages[tabControl1.SelectedIndex].Text);
            SaveManager.setGameSavePath();
            readItemList();
            armorTypeBox.DataSource = Enum.GetValues(typeof(armorTypes));
        }

        #region Form Events
        private void writeFileButton_Click(object sender, EventArgs e)
        {
            writeFile();
        }

        private void folderRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton senderRadio = ((RadioButton)sender);

            if(senderRadio.Checked)
            {
                SaveManager.changeFolder(senderRadio.Tag.ToString());

                userIDComboBox.Items.Clear();

                foreach(string userDir in SaveManager.getUserDirectories())
                {
                    userIDComboBox.Items.Add(userDir.Substring(userDir.LastIndexOf("\\") + 1));
                }

                userIDComboBox.SelectedIndex = 0; //Triggers userIDComboBox_SelectedIndexChanged
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveManager.changeCompletePath(userIDComboBox.Text, saveIDComboBox.Text);
            fillList();
        }

        private void userIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSaveIDComboBox();
        }
        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkForUpdate();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = ((ToolStripMenuItem)sender);

            using Process fileopener = new Process();

            fileopener.StartInfo.FileName = "explorer";
            fileopener.StartInfo.Arguments = "\"" + menuItem.Tag + "\"";
            fileopener.Start();
        }

        private void regrowAllTreesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(SaveManager.folder == null)
            {
                MessageBox.Show("Please select SaveGame first", "Tree regrow tool");
            }
            else
            {
                string saveFile = SaveManager.completePath.Split(@"SonsOfTheForest\")[1];
                DialogResult dialogResult = MessageBox.Show(string.Format("Warning: \n" +
                                                            "This will regrow ALL trees, even the ones you removed the stump.\n\n" +
                                                            "Trees might grow through your base or buildings you build! \n" +
                                                            "There is no check if its possible! \n\n" +
                                                            "Are you sure you want to regrow all trees for the following SaveFile?\n\n" +
                                                            "{0}", saveFile),
                                                            "Tree regrow warning!",
                                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if(dialogResult == DialogResult.Yes)
                {
                    Console.WriteLine("{0}", SaveManager.completePath + "WorldObjectLocatorManagerSaveData.json");
                    File.Delete(SaveManager.completePath + "WorldObjectLocatorManagerSaveData.json");
                }
            }
        }

        private void createBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(SaveManager.folder == null)
            {
                MessageBox.Show("Please select SaveGame first", "Create Backup tool");
            }
            else
            {
                string zipName = SaveManager.completePath.Split(@"\").Reverse().Skip(1).First() + ".rar";
                string zipPath = SaveManager.completePath.Split(SaveManager.folder + @"\")[0];
                string targetFolder = SaveManager.completePath.Remove(SaveManager.completePath.Length - 1);
                ZipFile.CreateFromDirectory(targetFolder, zipPath + SaveManager.folder + @"\" + zipName, 0, true);
            }
        }

        private void bulkChangeAmount_Click(object sender, EventArgs e)
        {
            if((sender as Button).Tag == "True")
            {
                inventoryPanel.Controls.OfType<CustomTextBox>().ToList().ForEach((tb) => tb.Text = "100");
            }
            else
            {
                inventoryPanel.Controls.OfType<CustomTextBox>().ToList().ForEach((tb) => tb.Text = "-1");
            }
        }

        private void openSaveGameFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", SaveManager.completePath);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeWriteButtonText(tabControl1.TabPages[tabControl1.SelectedIndex].Text);
            changesButton.Visible = tabControl1.SelectedIndex == 1 ? false : true;
            MainForm.ActiveForm.Text = $"SoTFEditor - {tabControl1.TabPages[tabControl1.SelectedIndex].Text}";
        }

        private void armorTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            writeArmorButton.Text = string.Format("Set all armor to {0}", armorTypeBox.SelectedValue);
        }

        private void writeArmorButton_Click(object sender, EventArgs e)
        {
            string armorPoints = "9999.0";

            ArmorTool.saveFileArmorObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(SaveManager.completePath + SaveManager.playerArmorFile));

            JObject armorSystemObject = JsonConvert.DeserializeObject<JObject>(ArmorTool.saveFileArmorObject["Data"]["PlayerArmourSystem"].ToString());

            JArray armorPieces = JArray.Parse(armorSystemObject["ArmourPieces"].ToString());

            armorPieces.Clear();

            foreach(int slotNumber in ArmorTool.armorSlots)
            {
                JObject pieceToAdd = new JObject(new JProperty("ItemId", ((int)armorTypeBox.SelectedValue).ToString()),
                                              new JProperty("Slot", slotNumber.ToString()),
                                              new JProperty("RemainingArmourpoints", armorPoints));
                armorPieces.Add(pieceToAdd);
            }

            armorSystemObject["ArmourPieces"] = armorPieces;
            ArmorTool.saveFileArmorObject["Data"]["PlayerArmourSystem"] = JsonConvert.SerializeObject(armorSystemObject);

            File.WriteAllText(SaveManager.savesPath + SaveManager.playerArmorFile, JsonConvert.SerializeObject(ArmorTool.saveFileArmorObject));
            MessageBox.Show(string.Format("Changed all armor to {0}", armorTypeBox.SelectedValue.ToString()));
        }
        #endregion

        private void checkForUpdate()
        {
#if DEBUG
            MessageBox.Show("Is in DEBUG Mode!");
            return;
#else
            if(needsUpdate)
            {
                if(MessageBox.Show(string.Format("There is a new Version available: \n\nCurrent Version: {0}\nNew Version: {1}\n\nDo you want to download the newer Version?", currentVersion, newVersion), "Check for Update", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    client.LoginAnonymous();
                    Uri updateZipLink = new Uri("https://mega.nz/folder/96wgVRDA#GgMSlj5JmwPV9WGc-UU9Ng");
                    INode zipNode = client.GetNodesFromLink(updateZipLink).Where(x => (x.Type == NodeType.File) && (x.Name == "SoTFEditor.zip")).First();

                    using(var stream = client.Download(zipNode))
                    {
                        using(var fileStream = new FileStream("SoTFEditor.zip", FileMode.OpenOrCreate))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                    client.Logout();
                    System.IO.Compression.ZipFile.ExtractToDirectory("SoTFEditor.zip", @".\Update", true);
                    Process proc = null;
                    try
                    {
                        proc = new Process();

                        proc.StartInfo.FileName = "updater.bat";
                        proc.StartInfo.CreateNoWindow = true;
                        proc.Start();
                        Environment.Exit(0);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("App is up-to-date!", "Check for Update");
            }
#endif
        }

        void buildVersionText()
        {
#if DEBUG
            currentVersion = File.ReadAllText("Version.txt");
            string versionText = $"DEBUG {currentVersion}";
            versionLabel.Text = versionText;
#else
            string versionText = !checkVersions() ? currentVersion : string.Format("{0}   [New Version available: {1}]", currentVersion, newVersion);
#endif
            MethodInvoker inv = delegate
            {
                this.versionLabel.Text = versionText;
            };

            this.Invoke(inv);
        }

        public bool checkVersions()
        {
            client = new MegaApiClient();
            client.LoginAnonymous();

            Uri fileLink = new Uri("https://mega.nz/folder/k3BHhBZB#FSJ85HfCpjh31DPWEJxD-Q");
            INode node = client.GetNodesFromLink(fileLink).Where(x => (x.Type == NodeType.File) && (x.Name == "Version.txt")).First();

            using(var stream = client.Download(node))
            {
                using(var fileStream = new FileStream("Temp" + node.Name, FileMode.OpenOrCreate))
                {
                    stream.CopyTo(fileStream);
                }
            }

            currentVersion = File.ReadAllText(node.Name);
            newVersion = File.ReadAllText("Temp" + node.Name);
            File.Delete("Temp" + node.Name);
            client.Logout();
            needsUpdate = currentVersion != newVersion;
            return needsUpdate;
        }

        private void readItemList()
        {
            ItemIds.Clear();
            ItemIds = File.ReadLines(itemIDListFile).Select(line => line.Split(',')).GroupBy(line => line[1], StringComparer.OrdinalIgnoreCase).ToDictionary(line => line.First()[1], line => line.First()[0], StringComparer.OrdinalIgnoreCase);
        }

        private void fillList()
        {
            readFile();

            int pointY = 10;
            int distance = 150;
            inventoryPanel.Controls.Clear();
            changesButton.Enabled = false;

            foreach(var item in ItemIds)
            {
                int boxWidth = 130;
                TextBox itemBox = new TextBox();

                itemBox.Text = item.Value;
                itemBox.Location = new Point(0, pointY);
                itemBox.Width = boxWidth;
                itemBox.ReadOnly = true;
                itemBox.BackColor = Color.Silver;

                inventoryPanel.Controls.Add(itemBox);

                TextBox amountBox = new TextBox();
                amountBox.Text = getAmountByItemId(item.Key);
                amountBox.Location = new Point(0 + distance, pointY);
                amountBox.Width = boxWidth;
                amountBox.ReadOnly = true;
                amountBox.BackColor = Color.Silver;
                inventoryPanel.Controls.Add(amountBox);

                CustomTextBox newAmountBox = new CustomTextBox();
                newAmountBox.Text = getAmountByItemId(item.Key);
                newAmountBox.oldValue = newAmountBox.Text;
                newAmountBox.parentItemId = item.Key.ToString();
                newAmountBox.Location = new Point(distance * 2, pointY);
                newAmountBox.Width = boxWidth;
                newAmountBox.CausesValidation = true;
                newAmountBox.TextChanged += (sender2, e2) => changeMyColor(sender2, e2, amountBox.Text);
                newAmountBox.KeyPress += newAmountBox.validateCustomTextBoxNumber;

                inventoryPanel.Controls.Add(newAmountBox);

                inventoryPanel.Show();
                pointY += 40;
            }

            maxButton.Enabled = true;
            emptyButton.Enabled = true;
            writeArmorButton.Enabled = true;
            openSaveGameFolderToolStripMenuItem.Enabled = true;
            openSaveGameFolderToolStripMenuItem.ToolTipText = string.Empty;
        }

        private void changeMyColor(object? sender, EventArgs e, string oldAmount)
        {
            CustomTextBox thisTextBox = sender as CustomTextBox;
            thisTextBox.BackColor = thisTextBox.Text != oldAmount ? Color.LightCoral : SystemColors.Window;
            thisTextBox.changedValue = thisTextBox.Text != oldAmount;
            if(thisTextBox.changedValue)
            {
                changesButton.Enabled = true;
            }
        }

        private string getAmountByItemId(string itemId)
        {
            string itemAmount = "-1";

            JToken itemToken = inventoryObject.SelectToken("ItemInstanceManagerData.ItemBlocks[?(@.ItemId == " + itemId + ")]");
            if(itemToken != null)
            {
                JToken amountToken = itemToken.SelectToken("TotalCount");
                itemAmount = amountToken.ToString();
            }
            return itemAmount;
        }

        private void writeFile()
        {
            JToken newToken;

            JToken inventoryToken = saveFileObject.SelectToken("Data.PlayerInventory");

            foreach(var change in findChangedAmount())
            {
                //Tuple is (itemID, newValue, oldValue)
                if(change.Item3 == "-1")
                {
                    addItem(change.Item1, change.Item2);
                }
                else
                {
                    newToken = inventoryObject.SelectToken("ItemInstanceManagerData.ItemBlocks[?(@.ItemId == " + change.Item1 + ")]");
                    JToken amount = newToken.SelectToken("TotalCount");
                    amount.Replace(change.Item2);
                }
            }

            inventoryToken.Replace(inventoryObject.ToString());

            string updatedBaseString = saveFileObject.ToString();
            string unescapedString = updatedBaseString.Replace(@"\r\n", "").Replace(@" ", "");
            //string cleaned = unescapedString.Replace("\n", "").Replace("\r", "");
            string cleaned = unescapedString.Replace(Environment.NewLine, "");

            File.WriteAllText(SaveManager.completePath + SaveManager.inventoryFile, cleaned);
            fillList();
        }

        private void readFile()
        {
            //SaveFileObject
            saveFileObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(SaveManager.completePath + SaveManager.inventoryFile));

            //Get Inventory token from saveFileObject
            JToken inventoryToken = saveFileObject.SelectToken("Data.PlayerInventory");

            //As the inventory content is saved as a string it need to be deserzialized again
            inventoryObject = JsonConvert.DeserializeObject<JObject>(inventoryToken.ToString());
        }

        public void addItem(string itemId, string newValue)
        {
            JToken newToken = inventoryObject.SelectToken("ItemInstanceManagerData.ItemBlocks");
            string itemString = "{\"ItemId\":" + itemId + ",\"TotalCount\":\"" + newValue + "\",\"UniqueItems\":[]}";
            newToken.Last.AddAfterSelf(JObject.Parse(itemString));
        }

        public List<ValueTuple<string, string, string>> findChangedAmount()
        {
            List<ValueTuple<string, string, string>> changedAmounts = new List<ValueTuple<string, string, string>>();

            //this.Controls.OfType<TextBox>().ToList().ForEach((tb) => Console.WriteLine("TextBox entry: {0}", tb.Text));

            Control ctrl = this.GetNextControl(this, true);
            while(ctrl != null)
            {
                if(ctrl is CustomTextBox)
                {
                    CustomTextBox customTextBox = (CustomTextBox)ctrl;

                    if(!customTextBox.ReadOnly && customTextBox.changedValue)
                    {
                        //Tuple is (itemID, newValue, oldValue)
                        var tempTuple = (customTextBox.parentItemId.ToString(), customTextBox.Text, customTextBox.oldValue);
                        changedAmounts.Add(tempTuple);
                    }
                }
                ctrl = this.GetNextControl(ctrl, true);
            }

            return changedAmounts;
        }

        private void fillSaveIDComboBox()
        {
            try
            {
                saveIDComboBox.Items.Clear();

                foreach(string dir in SaveManager.getSavesDirectories(userIDComboBox.Text))
                {
                    saveIDComboBox.Items.Add(dir.Substring(dir.LastIndexOf("\\") + 1));
                }

                saveIDComboBox.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("SaveFile for \n\n{0} \n\ncould not be found", SaveManager.savesPath + userIDComboBox.Text + @"\" + SaveManager.folder), "Error in loading file");
            }
        }

        private void changeWriteButtonText(string input)
        {
            changesButton.Text = $"Write changes to {input} file";
        }
    }
}