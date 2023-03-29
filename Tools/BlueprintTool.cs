using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using System.Data;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace SoTFEditor.Tools
{
    public static class BlueprintTool
    {
        static string jsonPath = System.Windows.Forms.Application.StartupPath + @"data\structureInfo.json";
        static JObject blueprintsSaveObject, structureBlueprintsObject;

        public static List<BlueprintChange> changedBlueprintList = new List<BlueprintChange>();

        static JObject dataJson = JObject.Parse(File.ReadAllText(jsonPath));
        static List<JToken> dataList = dataJson.SelectTokens("*[*]").ToList();
        static JArray currentBlueprintArray;
        static Panel blueprintPanel;
        static Button changeButton, setMaxButton, removeAllButton;

        static int pointY = 10;
        static int distance = 135;

        public static void outputBlueprints(Panel blueprintPanelInput = null, Button changeButtonInput = null, Button setMaxButtonInput = null, Button removeAllButtonInput = null)
        {
            blueprintPanel ??= blueprintPanelInput;
            changeButton ??= changeButtonInput;
            setMaxButton ??= setMaxButtonInput;
            removeAllButton ??= removeAllButtonInput;

            blueprintsSaveObject = JsonConvert.DeserializeObject<JObject>(SaveManager.blueprintSaveString);
            JToken blueprintsToken = blueprintsSaveObject.SelectToken("Data.ScrewStructureNodeInstances");
            structureBlueprintsObject = JsonConvert.DeserializeObject<JObject>(blueprintsToken.ToString());
            currentBlueprintArray = JArray.Parse(structureBlueprintsObject["_structures"].ToString());
            List<string> listOfStructureNames = dataJson.SelectTokens("*[*]").Select(x => x["name"].ToString()).ToList();

            blueprintPanel.Controls.Clear();

            if(currentBlueprintArray.Count != 0)
            {
                foreach(var blueprintData in currentBlueprintArray)
                {
                    CustomComboBox newCombo = new CustomComboBox();
                    newCombo.BindingContext = new BindingContext();
                    newCombo.DataSource = listOfStructureNames;
                    newCombo.Location = new Point(0, pointY);
                    newCombo.parentSlotId = blueprintData["Pos"].ToString();
                    newCombo.Tag = blueprintData["Id"].ToString();
                    blueprintPanel.Controls.Add(newCombo);
                    JToken selectedToken = dataList.Where(x => x["id"].ToString() == blueprintData["Id"].ToString()).FirstOrDefault();
                    string blueprintIdName = selectedToken == null ? "unknown" : selectedToken["name"].ToString();

                    newCombo.SelectedIndex = newCombo.FindStringExact(blueprintIdName);
                    if(newCombo.SelectedIndex == -1)
                    {
                        newCombo.SelectedText = "UNKNOWN";
                    }
                    newCombo.SelectedIndexChanged += registerChangedBlueprint;

                    CustomTextBox currentAmount = new CustomTextBox();
                    currentAmount.Text = blueprintData["Added"].ToString();
                    currentAmount.Tag = blueprintData["Id"].ToString();
                    currentAmount.oldValue = currentAmount.Text;
                    currentAmount.Size = new Size(40, 30);
                    currentAmount.TextAlign = HorizontalAlignment.Center;
                    currentAmount.Location = new Point(distance, pointY);
                    newCombo.linkedTextBoxCurrent = currentAmount;
                    currentAmount.TextChanged += (sender2, e2) => validateCurrentAmount(sender2, e2, newCombo);
                    blueprintPanel.Controls.Add(currentAmount);

                    Label divider = new Label();
                    divider.Text = "/";
                    divider.Location = new Point(currentAmount.Location.X+45, currentAmount.Location.Y);
                    divider.Size = new Size(15,30);
                    blueprintPanel.Controls.Add(divider);

                    CustomTextBox requiredAmount = new CustomTextBox();
                    requiredAmount.Text = getRequiredAmountByID(blueprintData["Id"].ToString());
                    requiredAmount.Size = new Size(40, 30);
                    requiredAmount.TextAlign = HorizontalAlignment.Center;
                    requiredAmount.Location = new Point(currentAmount.Location.X + 65, currentAmount.Location.Y);
                    requiredAmount.ReadOnly = true;
                    requiredAmount.BackColor = Color.Silver;
                    newCombo.linkedTextBoxMax = requiredAmount;
                    blueprintPanel.Controls.Add(requiredAmount);

                    Button maxButton = new Button();
                    maxButton.Text = "Set Max";
                    maxButton.Tag = newCombo;//blueprintData["Pos"].ToString();
                    maxButton.Location = new Point(currentAmount.Location.X + 115, currentAmount.Location.Y);
                    maxButton.Size = new Size(72, 30);
                    maxButton.Click += maxButton_Click;
                    blueprintPanel.Controls.Add(maxButton);

                    Button removeButton = new Button();
                    removeButton.Text = "Remove this Blueprint";
                    removeButton.Tag = blueprintData["Pos"].ToString();
                    removeButton.Location = new Point(currentAmount.Location.X + distance+70, currentAmount.Location.Y);
                    removeButton.Size = new Size(165, 30);
                    removeButton.Click += removeButton_Click;
                    blueprintPanel.Controls.Add(removeButton);

                    //Button teleportButton = new Button();
                    //teleportButton.Text = "Teleport Player to this";
                    //teleportButton.Tag = blueprintData["Pos"].ToString();
                    //teleportButton.Location = new Point(distance * 2 + 40, pointY);
                    //teleportButton.Size = new Size(167, 30);
                    //teleportButton.Click += teleportButton_Click;
                    //blueprintPanel.Controls.Add(teleportButton);

                    pointY += 40;
                }
                setMaxButton.Enabled = true;
                removeAllButton.Enabled = true;
            }
            else
            {
                Label emptyLabel = new Label();
                emptyLabel.Text = "No blueprints found in this save";
                emptyLabel.Font = new Font("Segoe UI", 14);
                emptyLabel.Location = new Point(71, 235);
                emptyLabel.Size = new Size(357, 32);
                blueprintPanel.Controls.Add(emptyLabel);

                setMaxButton.Enabled = false;
                removeAllButton.Enabled = false;
            }

            pointY = 0;  
        }

        public static void writeNewBlueprints()
        {
            foreach(var change in changedBlueprintList)
            {
                JToken changeToken = currentBlueprintArray.Where(x => cleanUpString(x["Pos"].ToString()) == change.posID).First();
                if(changeToken != null)
                {
                    changeToken["Id"] = change.structureID;
                    changeToken["Added"] = change.addedAmount;
                }
            }

            structureBlueprintsObject["_structures"] = currentBlueprintArray;
            blueprintsSaveObject["Data"]["ScrewStructureNodeInstances"] = JsonConvert.SerializeObject(structureBlueprintsObject);

            SaveManager.writeToFile(saveFile.structureBlueprints, JsonConvert.SerializeObject(blueprintsSaveObject));
            changedBlueprintList.Clear();
            if(blueprintPanel != null)
            {
                outputBlueprints();
            }
        }

        private static string getRequiredAmountByID(string searchedID)
        {
            JToken selectedToken = dataList.Where(x => x["id"].ToString() == searchedID).FirstOrDefault();
            return selectedToken == null ? "-1" : selectedToken["blueprintRequiredAmount"].ToString();
        }

        public static void setAllToMax()
        {
            writeNewBlueprints();
            foreach(var item in currentBlueprintArray)
            {
                item["Added"] = Int32.Parse(getRequiredAmountByID(item["Id"].ToString()))-1;
            }

            writeNewBlueprints();
        }

        private static void validateCurrentAmount(object sender, EventArgs e, CustomComboBox parentComboBox)
        {
            CustomTextBox currentAmount = sender as CustomTextBox;
            int temp;

            if(Int32.TryParse(currentAmount.Text, out temp))
            {
                string requiredAmountString = getRequiredAmountByID(parentComboBox.Tag.ToString());
                if(requiredAmountString == "-1") 
                {
                    currentAmount.Text = "-1";
                }
                else
                {
                    currentAmount.Text = Int32.Parse(currentAmount.Text) >= Int32.Parse(requiredAmountString) ? (Int32.Parse(requiredAmountString) - 1).ToString() : currentAmount.Text;
                    registerChangeAmount(currentAmount, parentComboBox);
                }
            }
            else
            {
                currentAmount.Text = currentAmount.oldValue;
            }
        }

        private static void registerChangeAmount(CustomTextBox changedTextBox, CustomComboBox parentComboBox)
        {
            if(changedTextBox.Text != changedTextBox.oldValue)
            {
                changedTextBox.BackColor = Color.LightCoral;
                BlueprintChange foundChange = changedBlueprintList.Where(x => x.posID == cleanUpString(parentComboBox.parentSlotId)).FirstOrDefault();

                if(foundChange == null)
                {
                    changedBlueprintList.Add(new BlueprintChange(cleanUpString(parentComboBox.parentSlotId), parentComboBox.Tag.ToString(), changedTextBox.Text, false));
                }
                else
                {
                    foundChange.addedAmount = changedTextBox.Text;
                    foundChange.addedByStruct = false;
                }
            }
            else
            {
                changedTextBox.BackColor = SystemColors.Window;
                BlueprintChange clearChange = changedBlueprintList.Where(x => x.posID == cleanUpString(parentComboBox.parentSlotId)).FirstOrDefault();
                if(clearChange != null)
                {
                    if(clearChange.addedByStruct)
                    {
                        clearChange.addedAmount = changedTextBox.Text;
                    }
                    else
                    {
                        changedBlueprintList.Remove(clearChange);
                    }
                }
            }

            changeButton.Enabled = changedBlueprintList.Count > 0;
        }


        private static void removeButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            removeBlueprints(currentBlueprintArray.Remove(currentBlueprintArray.Where(x => x["Pos"].ToString() == button.Tag.ToString()).First()));
        }

        public static void removeBlueprints(JToken removeToken = null)
        {
            string targetBlueprint = removeToken != null ? "this blueprint" : "ALL blueprints";

            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove {targetBlueprint}? \n" +
                                                            "This can NOT be reverted.\n\n" +
                                                            "Please create backup of your files if you are unsure!",
                                                            "Remove Blueprint Warning!",
                                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if(dialogResult == DialogResult.Yes)
            {
                if(removeToken != null)
                {
                    currentBlueprintArray.Remove(removeToken);
                }
                else
                {
                    currentBlueprintArray.Clear();
                    changedBlueprintList.Clear();
                    changeButton.Enabled=false;
                }

                writeNewBlueprints();
            }
            setMaxButton.Enabled = currentBlueprintArray.Count > 0;
            removeAllButton.Enabled = setMaxButton.Enabled;
        }

        private static void maxButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            CustomComboBox comboBox = button.Tag as CustomComboBox;
            comboBox.linkedTextBoxCurrent.Text = (Int32.Parse(comboBox.linkedTextBoxMax.Text)-1).ToString();
        }

        private static void teleportButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            Console.WriteLine($"Teleporting player to {button.Tag}");
        }

        private static void registerChangedBlueprint(object sender, EventArgs e)
        {
            CustomComboBox blueprintComboBox = sender as CustomComboBox;

            string newStructureID = dataList.Where(x => x["name"].ToString() == blueprintComboBox.SelectedValue).First()["id"].ToString();
            string currentStructureID = currentBlueprintArray.Where(x => x["Pos"].ToString() == blueprintComboBox.parentSlotId).First()["Id"].ToString();

            if(newStructureID != currentStructureID)
            {
                blueprintComboBox.BackColor = Color.LightCoral;
                blueprintComboBox.Tag = newStructureID;
                BlueprintChange foundChange = changedBlueprintList.Where(x => x.posID == cleanUpString(blueprintComboBox.parentSlotId)).FirstOrDefault();

                if(foundChange == null)
                {
                    changedBlueprintList.Add(new BlueprintChange(cleanUpString(blueprintComboBox.parentSlotId), newStructureID, blueprintComboBox.linkedTextBoxCurrent.Text, true));
                }
                else
                {
                    foundChange.structureID = newStructureID;
                    foundChange.addedByStruct = true;
                }
            }
            else
            {
                blueprintComboBox.BackColor = SystemColors.Window;
                BlueprintChange clearChange = changedBlueprintList.Where(x => x.posID == cleanUpString(blueprintComboBox.parentSlotId)).FirstOrDefault();
                if(clearChange != null)
                {
                    if(clearChange.addedByStruct)
                    {
                        changedBlueprintList.Remove(clearChange);
                    }
                    else
                    {
                        clearChange.structureID = newStructureID;
                    }
                }
            }

            blueprintComboBox.linkedTextBoxMax.Text = getRequiredAmountByID(newStructureID);
            blueprintComboBox.linkedTextBoxCurrent.Text = Int32.Parse(blueprintComboBox.linkedTextBoxCurrent.Text) >= Int32.Parse(blueprintComboBox.linkedTextBoxMax.Text) ? (Int32.Parse(blueprintComboBox.linkedTextBoxMax.Text) - 1).ToString() : blueprintComboBox.linkedTextBoxCurrent.Text;

            changeButton.Enabled = changedBlueprintList.Count > 0;
        }

        private static string cleanUpString(string inputString)
        {
            return inputString.Replace("{", "")
                              .Replace("}", "")
                              .Replace(" ", "")
                              .Replace("\r\n", "");
        }
    }
}
