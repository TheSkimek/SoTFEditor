using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using CG.Web.MegaApiClient;
using System.IO;
using System.IO.Compression;
using System.Text.Unicode;
using System.Text;
using SoTFEditor.Properties;

namespace SoTFEditor
{
    public partial class MainForm : Form
    {
        JObject saveFileObject;
        JObject inventoryObject;

        MegaApiClient client;
        string currentVersion, newVersion;
        bool needsUpdate;
        List<itemChange> itemChangesList = new List<itemChange>();

        public Dictionary<string, string> ItemIds = new Dictionary<string, string>();

        string itemIDListFile = System.Windows.Forms.Application.StartupPath + @"Files\ItemIDList.csv";

        public MainForm()
        {
            InitializeComponent();

            Task.Factory.StartNew(() => buildVersionText());
            SaveManager.setGameSavePath();
            changeWriteButtonText(tabControl1.TabPages[tabControl1.SelectedIndex].Text);
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

        private void userIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSaveIDComboBox();
        }

        private void saveIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveManager.changeCompletePath(userIDComboBox.Text, saveSelector.Text);
           
            saveImageBox.Image = ((DropDownItem)saveSelector.SelectedItem).Image;
            openSaveGameFolderToolStripMenuItem.Enabled = true;
            openSaveGameFolderToolStripMenuItem.ToolTipText = string.Empty;
            fillSelectedPanel();
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkForUpdate();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = ((ToolStripMenuItem)sender);
            Process.Start("explorer", "\"" + menuItem.Tag + "\"");
        }

        private void regrowAllTreesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            regrowAllTrees();
        }

        private void createBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveManager.createBackupFile();
        }

        private void bulkChangeAmount_Click(object sender, EventArgs e)
        {
            if((sender as Button).Tag == "True")
            {
                inventoryPanel.Controls.OfType<CustomTextBox>().ToList().ForEach((tb) => tb.Text = "100");
            }
            else
            {
                ///Some items have unique behaviour that wont let us delete them like this, e.g. Stun Baton with its battery charge or fish with its decay counter.
                //inventoryPanel.Controls.OfType<CustomTextBox>().ToList().ForEach((tb) => tb.Text = "-1"); 

                DialogResult dialogResult = MessageBox.Show("Warning: \n" +
                                                            "Your inventory will be emptied and you will only have the starter items.\n\n" +
                                                            "Are you sure you want to remove all items from inventory?",
                                                            "Remove ALL items warning",
                                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if(dialogResult == DialogResult.Yes)
                {
                    SaveManager.writeToFile(saveFile.inventory, "", true);
                    itemChangesList.Clear();
                    fillList();
                }
            }
        }

        private void openSaveGameFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", SaveManager.completePath);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeWriteButtonText(tabControl1.TabPages[tabControl1.SelectedIndex].Text);
            if(SaveManager.pathSet)
            {
                fillSelectedPanel();
            }
            MainForm.ActiveForm.Text = $"SoTFEditor - {tabControl1.TabPages[tabControl1.SelectedIndex].Text}";
        }

        private void armorTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            writeArmorButton.Text = string.Format("Set all armor to {0}", armorTypeBox.SelectedValue);
        }

        private void setArmorButton_Click(object sender, EventArgs e)
        {
            ArmorTool.setAllArmor((armorTypes)armorTypeBox.SelectedValue);
            fillArmorList();
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
            int boxWidth = 130;
            inventoryPanel.Controls.Clear();
            changesButton.Enabled = false;

            foreach(var item in ItemIds)
            {
                TextBox itemBox = new TextBox();

                itemBox.Text = item.Value;
                itemBox.Location = new Point(0, pointY);
                itemBox.Width = boxWidth;
                itemBox.ReadOnly = true;
                itemBox.BackColor = Color.Silver;

                inventoryPanel.Controls.Add(itemBox);

                TextBox amountBox = new TextBox();
                amountBox.Text = getAmountByItemId(item.Key);
                amountBox.Location = new Point(distance, pointY);
                amountBox.Width = boxWidth;
                amountBox.ReadOnly = true;
                amountBox.BackColor = Color.Silver;
                inventoryPanel.Controls.Add(amountBox);

                CustomTextBox newAmountBox = new CustomTextBox();
                newAmountBox.oldValue = newAmountBox.Text;
                newAmountBox.parentItemId = item.Key.ToString();
                newAmountBox.CausesValidation = true;
                newAmountBox.TextChanged += (sender2, e2) => registerChangedTextBox(sender2, e2, amountBox.Text);
                if(itemChangesList.Any(x => x.itemID == newAmountBox.parentItemId))
                {
                    itemChange changedItem = itemChangesList.First(x => x.itemID == newAmountBox.parentItemId);
                    newAmountBox.Text = changedItem.newValue;
                    newAmountBox.BackColor = Color.LightCoral;
                    changesButton.Enabled = true;
                }
                else
                {
                    newAmountBox.Text = getAmountByItemId(item.Key);
                }

                newAmountBox.Location = new Point(distance * 2, pointY);
                newAmountBox.Width = boxWidth;
                newAmountBox.KeyPress += newAmountBox.validateCustomTextBoxNumber;

                inventoryPanel.Controls.Add(newAmountBox);

                pointY += 40;
            }
            inventoryPanel.Show();
            maxButton.Enabled = true;
            emptyButton.Enabled = true;
            writeArmorButton.Enabled = true;
        }

        private void fillArmorList()
        {
            int pointY = 10;
            int distance = 150;
            int boxWidth = 130;

            int selectedIndex = -1;

            armorPanel.Controls.Clear();
            foreach(var armorSlot in Enum.GetNames(typeof(armorSlots)))
            {
                TextBox slotBox = new TextBox();
                slotBox.Text = armorSlot;
                slotBox.Location = new Point(0, pointY);
                slotBox.Width = boxWidth;
                slotBox.ReadOnly = true;
                slotBox.BackColor = Color.Silver;
                armorPanel.Controls.Add(slotBox);

                CustomComboBox selectedArmor = new CustomComboBox();
                selectedArmor.DataSource = Enum.GetValues(typeof(armorTypes));
                selectedArmor.Location = new Point(distance, pointY);
                selectedArmor.parentSlotId = armorSlot;
                armorPanel.Controls.Add(selectedArmor);
                string checkSlot = ((int)Enum.Parse(typeof(armorSlots), selectedArmor.parentSlotId)).ToString();

                armorPieceChange changedArmor = ArmorTool.changedArmorPieces.FirstOrDefault(x => x.slotID == checkSlot,null);

                if(changedArmor != null)
                {
                    selectedArmor.SelectedIndex = selectedArmor.FindStringExact(Enum.GetName(typeof(armorTypes),changedArmor.newArmorID));
                    selectedArmor.BackColor = Color.LightCoral;
                    changesButton.Enabled = true;
                }
                else
                {
                    var equippedArmor = ArmorTool.armorPieces.FirstOrDefault(x => x["Slot"].ToString() == ((int)Enum.Parse(typeof(armorSlots), armorSlot)).ToString(), null);
                    string searchString = equippedArmor == null ? "None" : equippedArmor["ItemId"].ToString();

                    selectedIndex = selectedArmor.FindStringExact(Enum.Parse(typeof(armorTypes), searchString).ToString());

                    selectedArmor.SelectedIndex = selectedIndex;
                }

                selectedArmor.oldIndex = selectedArmor.SelectedIndex;
                selectedArmor.SelectedIndexChanged += (sender2, e2) => registerChangedComboBox(sender2, e2, selectedArmor.oldIndex);

                CustomTextBox armorValueBox = new CustomTextBox();
                
                armorValueBox.oldValue = armorValueBox.Text;
                armorValueBox.parentItemId = armorSlot;
                armorValueBox.Location = new Point(distance * 2, pointY);
                armorValueBox.Width = boxWidth;
                armorValueBox.CausesValidation = true;

                armorPointsChange changedPoints = ArmorTool.changedArmorPoints.FirstOrDefault(x => x.slotID == checkSlot, null);

                if(changedPoints != null)
                {
                    armorValueBox.Text = changedPoints.newArmorPoints;
                    armorValueBox.BackColor = Color.LightCoral;
                    changesButton.Enabled = true;
                }
                else
                {
                    JToken tempToken = ArmorTool.armorPieces.Where(x => x["Slot"].ToString() == ((int)Enum.Parse(typeof(armorSlots), armorSlot)).ToString()).FirstOrDefault();
                    armorValueBox.Text = tempToken != null ? tempToken["RemainingArmourpoints"].ToString() : "0";
                }
                armorValueBox.TextChanged += (sender2, e2) => registerChangedTextBox(sender2, e2, armorValueBox.oldValue, true);

                armorValueBox.KeyPress += armorValueBox.validateCustomTextBoxNumber;
                armorPanel.Controls.Add(armorValueBox);

                pointY += 40;
            }

            armorPanel.Show();
        }

        private void registerChangedTextBox(object? sender, EventArgs e, string oldAmount, bool isArmorPoints = false)
        {
            CustomTextBox thisTextBox = sender as CustomTextBox;

            if(!isArmorPoints)
            {
                itemChangesList.RemoveAll(x => x.itemID == thisTextBox.parentItemId);

                if(thisTextBox.Text != oldAmount)
                {
                    itemChangesList.Add(new itemChange(thisTextBox.parentItemId, oldAmount, thisTextBox.Text));
                    thisTextBox.changedValue = true;
                    thisTextBox.BackColor = Color.LightCoral;
                }
                else
                {
                    thisTextBox.changedValue = false;
                    thisTextBox.BackColor = SystemColors.Window;
                }

                changesButton.Enabled = itemChangesList.Count > 0 ? true : false;
            }
            else
            {
                ArmorTool.changedArmorPoints.RemoveAll(x => x.slotID == thisTextBox.parentItemId);
                string selectedArmorSlot = ((int)Enum.Parse(typeof(armorSlots), thisTextBox.parentItemId)).ToString();
                if(thisTextBox.Text != oldAmount)
                {
                    ArmorTool.changedArmorPoints.Add(new armorPointsChange(selectedArmorSlot, oldAmount, thisTextBox.Text));
                    thisTextBox.changedValue = true;
                    thisTextBox.BackColor = Color.LightCoral;
                }
                else
                {
                    thisTextBox.changedValue = false;
                    thisTextBox.BackColor = SystemColors.Window;
                }

                changesButton.Enabled = ArmorTool.changedArmorPoints.Count > 0 ? true : false;
            }
        }

        private void registerChangedComboBox(object? sender, EventArgs e, int oldIndex)
        {
            CustomComboBox thisComboBox = sender as CustomComboBox;
            string selectedArmorID = ((int)Enum.Parse(typeof(armorSlots), thisComboBox.parentSlotId)).ToString();
            ArmorTool.changedArmorPieces.RemoveAll(x => x.slotID == selectedArmorID);

            if(thisComboBox.SelectedIndex != oldIndex)
            {
                int oldArmorItemID = (int)Enum.Parse(typeof(armorTypes), thisComboBox.Items[oldIndex].ToString());
                int newArmorItemID = (int)Enum.Parse(typeof(armorTypes), thisComboBox.SelectedValue.ToString());

                ArmorTool.changedArmorPieces.Add(new armorPieceChange(selectedArmorID, oldArmorItemID, newArmorItemID));

                thisComboBox.changedValue = true;
                thisComboBox.BackColor = Color.LightCoral;
            }
            else
            {
                thisComboBox.changedValue = false;
                thisComboBox.BackColor = SystemColors.Window;
            }
            changesButton.Enabled = ArmorTool.changedArmorPieces.Count > 0 ? true : false;
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
            switch(tabControl1.SelectedIndex)
            {
                case 0:
                    SaveManager.writeToFile(saveFile.inventory, newInventoryString());
                    fillList();
                    break;
                case 1:
                    ArmorTool.setChangedArmor();
                    fillArmorList();
                    break;
            }
        }

        private void readFile()
        {
            //SaveFileObject
            saveFileObject = JsonConvert.DeserializeObject<JObject>(SaveManager.inventorySaveString);

            //Get Inventory token from saveFileObject
            JToken inventoryToken = saveFileObject.SelectToken("Data.PlayerInventory");

            //As the inventory content is saved as a string it need to be deserzialized again
            inventoryObject = JsonConvert.DeserializeObject<JObject>(inventoryToken.ToString());
        }

        private string newInventoryString()
        {
            JToken newToken;

            JToken inventoryToken = saveFileObject.SelectToken("Data.PlayerInventory");

            foreach(var change in itemChangesList)
            {
                //change is (itemID, newValue, oldValue)
                if(change.oldValue == "-1")
                {
                    addItem(change.itemID, change.newValue);
                }
                else
                {
                    newToken = inventoryObject.SelectToken("ItemInstanceManagerData.ItemBlocks[?(@.ItemId == " + change.itemID + ")]");
                    JToken amount = newToken.SelectToken("TotalCount");
                    amount.Replace(change.newValue);
                }
            }

            inventoryToken.Replace(inventoryObject.ToString());

            string updatedBaseString = saveFileObject.ToString();
            string unescapedString = updatedBaseString.Replace(@"\r\n", "").Replace(@" ", "");
            string cleaned = unescapedString.Replace(Environment.NewLine, "");
            itemChangesList.Clear();

            return cleaned;
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

        private void fillSelectedPanel()
        {
            switch(tabControl1.SelectedIndex)
            {
                case 0:
                    armorPanel.Controls.Clear();
                    changesButton.Enabled = itemChangesList.Count > 0 ? true : false;
                    fillList();
                    break;
                case 1:
                    inventoryPanel.Controls.Clear();
                    changesButton.Enabled = ArmorTool.changedArmorPieces.Count > 0 ? true : false;
                    writeArmorButton.Enabled = true;
                    fillArmorList();
                    break;
            }
        }

        private void fillSaveIDComboBox()
        {
            saveSelector.Items.Clear();
            DropDownItem tempItem;
            string saveName;
            string[] dirList;
            if(SaveManager.getSavesDirectories(userIDComboBox.Text, out dirList))
            {
                foreach(string dir in dirList)
                {
                    saveName = dir.Substring(dir.LastIndexOf("\\") + 1);
                    tempItem = new DropDownItem(saveName, dir);
                    saveSelector.Items.Add(tempItem);
                }
                saveSelector.SelectedIndex = 0;
            }
        }

        private void changeWriteButtonText(string input)
        {
            changesButton.Text = $"Write changes to {input.Replace(" Tool", "")} file";
        }

        void regrowAllTrees()
        {
            if(SaveManager.folder == null)
            {
                MessageBox.Show("Please select SaveGame first", "Tree regrow tool");
            }
            else
            {
                string saveGame = SaveManager.completePath.Split(@"SonsOfTheForest\")[1];
                DialogResult dialogResult = MessageBox.Show(string.Format("Warning: \n" +
                                                            "This will regrow ALL trees, even the ones you removed the stump.\n\n" +
                                                            "Trees might grow through your base or buildings you built! \n" +
                                                            "There is no check if its possible! \n\n" +
                                                            "Are you sure you want to regrow all trees for the following SaveGame?\n\n" +
                                                            "{0}", saveGame),
                                                            "Tree regrow warning!",
                                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if(dialogResult == DialogResult.Yes)
                {
                    File.Delete(SaveManager.completePath + "WorldObjectLocatorManagerSaveData.json");
                }
            }
        }
    }
}