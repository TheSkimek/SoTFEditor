namespace SoTFEditor
{
    partial class ArmorTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            writeArmorButton = new Button();
            armorTypeBox = new ComboBox();
            myToolTip = new ToolTip(components);
            SuspendLayout();
            // 
            // writeArmorButton
            // 
            writeArmorButton.Location = new Point(424, 132);
            writeArmorButton.Name = "writeArmorButton";
            writeArmorButton.Size = new Size(262, 81);
            writeArmorButton.TabIndex = 1;
            writeArmorButton.Text = "Set all armor to {0}";
            myToolTip.SetToolTip(writeArmorButton, "It´s over 9000!");
            writeArmorButton.UseVisualStyleBackColor = true;
            writeArmorButton.Click += writeArmorButton_Click;
            // 
            // armorTypeBox
            // 
            armorTypeBox.FormattingEnabled = true;
            armorTypeBox.Location = new Point(118, 159);
            armorTypeBox.Name = "armorTypeBox";
            armorTypeBox.Size = new Size(151, 28);
            armorTypeBox.TabIndex = 2;
            armorTypeBox.SelectedIndexChanged += armorTypeBox_SelectedIndexChanged;
            // 
            // ArmorTool
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(armorTypeBox);
            Controls.Add(writeArmorButton);
            HelpButton = true;
            Name = "ArmorTool";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Armor Tool";
            ResumeLayout(false);
        }

        #endregion
        private Button writeArmorButton;
        private ComboBox armorTypeBox;
        private ToolTip myToolTip;
    }
}