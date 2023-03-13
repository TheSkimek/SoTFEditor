using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace SoTFEditor
{
    public partial class ArmorTool : Form
    {
        string savePath;

        string playerArmorFile = "PlayerArmourSystemSaveData.json";
        JObject saveFileArmorObject;

        int[] armorSlots = new int[] { 0, 1, 4, 5, 6, 7, 8, 9, 10, 11 };

        public ArmorTool()
        {
            InitializeComponent();
            armorTypeBox.DataSource = Enum.GetValues(typeof(armorTypes));
        }

        public void receiveData(string input)
        {
            savePath = input;
        }

        private void writeArmorButton_Click(object sender, EventArgs e)
        {
            string armorPoints = "9999.0";

            saveFileArmorObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(savePath + playerArmorFile));

            JObject armorSystemObject = JsonConvert.DeserializeObject<JObject>(saveFileArmorObject["Data"]["PlayerArmourSystem"].ToString());

            JArray armorPieces = JArray.Parse(armorSystemObject["ArmourPieces"].ToString());

            armorPieces.Clear();

            foreach(int slotNumber in armorSlots)
            {
                JObject pieceToAdd = new JObject(new JProperty("ItemId", ((int)armorTypeBox.SelectedValue).ToString()),
                                              new JProperty("Slot", slotNumber.ToString()),
                                              new JProperty("RemainingArmourpoints", armorPoints));
                armorPieces.Add(pieceToAdd);
            }

            armorSystemObject["ArmourPieces"] = armorPieces;
            saveFileArmorObject["Data"]["PlayerArmourSystem"] = JsonConvert.SerializeObject(armorSystemObject);

            File.WriteAllText(savePath + playerArmorFile, JsonConvert.SerializeObject(saveFileArmorObject));
            MessageBox.Show(string.Format("Changed all armor to {0}", armorTypeBox.SelectedValue.ToString()));
        }

        private void armorTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            writeArmorButton.Text = string.Format("Set all armor to {0}", armorTypeBox.SelectedValue);
        }
    }

    enum armorTypes
    {
        LeafArmor = 473,
        BoneArmor = 494,
        DeerHideArmor = 519,
        TechArmor = 554,
        CreepyArmor = 593
    };
}
