using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SoTFEditor.Tools;

namespace SoTFEditor
{
    public class CustomTextBox : System.Windows.Forms.TextBox
    {
        public string parentItemId { get; set; }
        public string oldValue { get; set; }
        public bool changedValue { get; set; }

        public void validateCustomTextBoxNumber(object? sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if((e.KeyChar == '-'))
            {
                (sender as TextBox).Text = "-1";
                e.Handled = true;
            }
        }
    }

    public class CustomComboBox: System.Windows.Forms.ComboBox
    {
        public string parentSlotId { get; set; }
        public int oldIndex { get; set; }
        public bool changedValue { get; set; }

        public CustomTextBox? linkedTextBoxCurrent;
        public CustomTextBox? linkedTextBoxMax;
    }

    public class itemChange
    {
        public string itemID;
        public string oldValue;
        public string newValue;

        public itemChange(string _itemID, string _oldValue, string _newValue)
        {
            this.itemID = _itemID;
            this.oldValue = _oldValue;
            this.newValue = _newValue; 
        }
    }

    public class armorPieceChange
    {
        public string slotID;
        public int oldArmorID;
        public int newArmorID;

        public armorPieceChange(string _slotID, int _oldArmorID, int _newArmorID)
        {
            this.slotID = _slotID;
            this.oldArmorID = _oldArmorID;
            this.newArmorID = _newArmorID;
        }
    }

    public class armorPointsChange
    {
        public string slotID;
        public string oldArmorPoints;
        public string newArmorPoints;

        public armorPointsChange(string _slotID, string _oldArmorPoints, string _newArmorID)
        {
            this.slotID = _slotID;
            this.oldArmorPoints = _oldArmorPoints;
            this.newArmorPoints = _newArmorID;
        }
    }

    public class BlueprintChange
    {
        public string posID;
        public string structureID;
        public string addedAmount;
        public bool addedByStruct;

        public BlueprintChange(string _posID, string _structureID, string _addedAmount, bool _addedByStruct)
        {
            posID = _posID;
            structureID = _structureID;
            addedAmount = _addedAmount;
            addedByStruct = _addedByStruct;
        }
    }

    public class SaveSelector : System.Windows.Forms.ComboBox
    {
        /// <summary>
        /// Credit to JToland
        /// https://stackoverflow.com/questions/4080719/placing-images-and-strings-with-a-c-sharp-combobox
        /// </summary>
        readonly float smaller = 1.5f; 

        public SaveSelector()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
        }
        
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();


            if(e.Index >= 0 && e.Index < Items.Count)
            {
                Font test = new Font(e.Font, FontStyle.Bold);
                DropDownItem item = (DropDownItem)Items[e.Index];
                e.Graphics.DrawImage(item.Image, e.Bounds.Left, e.Bounds.Top+8, item.Image.Width/ smaller, item.Image.Height/ smaller);
                e.Graphics.DrawString(item.Value, test, new SolidBrush(e.ForeColor), e.Bounds.Left + 5 + item.Image.Width / smaller, e.Bounds.Top + 50);
            }

            base.OnDrawItem(e);
        }
    }

    public class DropDownItem
    {
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
        private string value;

        public Image Image
        {
            get { return img; }
            set { img = value; }
        }
        private Image img;

        public DropDownItem(string val, string imagePath)
        {
            Value = val;
            //Image = Image.FromFile(imagePath + @"\"+SaveManager.saveThumbnail);

            using(FileStream fs = new FileStream(imagePath + @"\" + SaveManager.saveThumbnail, FileMode.Open))
            {
                Image = Image.FromStream(fs);
            }
        }

        public override string ToString()
        {
            return value;
        }
    }
}
