using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SoTFEditor
{
    public static class ArmorTool
    {
        static JObject saveFileArmorObject;
        static JObject armorSystemObject;
        static JArray _armorPieces;
        public static List<armorPieceChange> changedArmorPieces = new List<armorPieceChange>();
        public static List<armorPointsChange> changedArmorPoints = new List<armorPointsChange>();

        public static JArray armorPieces
        {
            get
            {
                saveFileArmorObject = JsonConvert.DeserializeObject<JObject>(SaveManager.armorSaveString);

                JObject armorSystemObject = JsonConvert.DeserializeObject<JObject>(saveFileArmorObject["Data"]["PlayerArmourSystem"].ToString());

                _armorPieces = JArray.Parse(armorSystemObject["ArmourPieces"].ToString());
                return _armorPieces;
            }
        }
        
        public static void setAllArmor(armorTypes selectedArmor)
        {
            string armorPoints = "9999.0";

            armorSystemObject = JsonConvert.DeserializeObject<JObject>(saveFileArmorObject["Data"]["PlayerArmourSystem"].ToString());

            _armorPieces.Clear();

            foreach(int slotNumber in Enum.GetValues(typeof(armorSlots)))
            {
                JObject pieceToAdd = new JObject(new JProperty("ItemId", ((int)selectedArmor).ToString()),
                                              new JProperty("Slot", slotNumber.ToString()),
                                              new JProperty("RemainingArmourpoints", armorPoints));
                _armorPieces.Add(pieceToAdd);
            }

            armorSystemObject["ArmourPieces"] = _armorPieces;
            saveFileArmorObject["Data"]["PlayerArmourSystem"] = JsonConvert.SerializeObject(armorSystemObject);

            _armorPieces = JArray.Parse(armorSystemObject["ArmourPieces"].ToString());
            SaveManager.writeToFile(saveFile.playerArmor, JsonConvert.SerializeObject(saveFileArmorObject));
            MessageBox.Show(string.Format("Changed all armor to {0}", selectedArmor.ToString()));
        }

        public static void setChangedArmor()
        {
            armorSystemObject = JsonConvert.DeserializeObject<JObject>(saveFileArmorObject["Data"]["PlayerArmourSystem"].ToString());

            JArray newArmorPieces = new JArray();
            JObject pieceToAdd;

            int newArmorID;
            string armorPoints;
            string armorSlot;
            armorPieceChange nextPieceChange;
            armorPointsChange nextPointsChange;

            foreach(var armor in armorPieces)
            {
                newArmorID = int.Parse(armor["ItemId"].ToString());
                armorPoints = armor["RemainingArmourpoints"].ToString();
                armorSlot = armor["Slot"].ToString();

                nextPieceChange = changedArmorPieces.Where(x => x.slotID == armor["Slot"].ToString()).FirstOrDefault();
                if(nextPieceChange != null)
                {
                    newArmorID = nextPieceChange.newArmorID;
                }

                nextPointsChange = changedArmorPoints.Where(x => x.slotID == armor["Slot"].ToString()).FirstOrDefault();

                if(nextPointsChange != null)
                {
                    armorPoints = nextPointsChange.newArmorPoints;
                }

                pieceToAdd = new JObject(new JProperty("ItemId", newArmorID),
                                              new JProperty("Slot", armorSlot),
                                              new JProperty("RemainingArmourpoints", armorPoints));

                newArmorPieces.Add(pieceToAdd);
            }

            armorSystemObject["ArmourPieces"] = newArmorPieces;
            saveFileArmorObject["Data"]["PlayerArmourSystem"] = JsonConvert.SerializeObject(armorSystemObject);

            SaveManager.writeToFile(saveFile.playerArmor, JsonConvert.SerializeObject(saveFileArmorObject));
            _armorPieces = JArray.Parse(armorSystemObject["ArmourPieces"].ToString());
            changedArmorPieces.Clear();
            changedArmorPoints.Clear();
        }

        public static string getEnumNameString(string input, enumNames inputEnum)
        {
            string enumNameString = "";

            switch(inputEnum)
            {
                case enumNames.armorType:
                    armorTypes tempType = (armorTypes)Enum.Parse(typeof(armorTypes), input);
                    enumNameString = tempType.ToString();
                    break;
                case enumNames.armorSlot:
                    armorSlots tempSlot = (armorSlots)Enum.Parse(typeof(armorSlots), input);
                    enumNameString = tempSlot.ToString();
                    break;
            }

            return System.Text.RegularExpressions.Regex.Replace(enumNameString, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
        }
    }

    public enum enumNames
    {
        armorType,
        armorSlot
    }

    public enum armorTypes
    {
        None = 0,
        LeafArmor = 473,
        BoneArmor = 494,
        DeerHideArmor = 519,
        TechArmor = 554,
        CreepyArmor = 593
    };

    public enum armorSlots
    {
        Head = 0,
        Chest = 1,
        Shoulder1 = 4,
        Shoulder2 = 5,
        LeftArm = 6, 
        RightArm = 7,
        UpperLeftLeg = 8,
        UpperRightLeg = 9,
        LeftLeg = 10,
        RightLeg = 11
    }
}
