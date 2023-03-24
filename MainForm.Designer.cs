namespace SoTFEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            changesButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            inventoryPanel = new Panel();
            panel2 = new Panel();
            saveSelector = new SaveSelector();
            saveImageBox = new PictureBox();
            userIDComboBox = new ComboBox();
            radioButtonMultClient = new RadioButton();
            radioButtonMultHost = new RadioButton();
            radioButtonSingle = new RadioButton();
            versionLabel = new Label();
            menuStrip1 = new MenuStrip();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            createBackupToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            regrowAllTreesToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            openReadMeToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            openSaveGameFolderToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            clickMeToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            printToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            customizeToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            contentsToolStripMenuItem = new ToolStripMenuItem();
            indexToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            maxButton = new Button();
            emptyButton = new Button();
            tabControl1 = new TabControl();
            inventoryTab = new TabPage();
            searchButton = new Button();
            searchBox = new TextBox();
            armorTab = new TabPage();
            armorTypeBox = new ComboBox();
            armorPanel = new Panel();
            label5 = new Label();
            writeArmorButton = new Button();
            toolTip1 = new ToolTip(components);
            removeAllBlueprintsToolStripMenuItem = new ToolStripMenuItem();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)saveImageBox).BeginInit();
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            inventoryTab.SuspendLayout();
            armorTab.SuspendLayout();
            armorPanel.SuspendLayout();
            SuspendLayout();
            // 
            // changesButton
            // 
            changesButton.Enabled = false;
            changesButton.Location = new Point(27, 462);
            changesButton.Name = "changesButton";
            changesButton.Size = new Size(256, 68);
            changesButton.TabIndex = 0;
            changesButton.Text = "Write changes to {0} file";
            changesButton.UseVisualStyleBackColor = true;
            changesButton.Click += writeFileButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightGray;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(8, 64);
            label1.Name = "label1";
            label1.Size = new Size(47, 25);
            label1.TabIndex = 0;
            label1.Text = "Item";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightGray;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(158, 64);
            label2.Name = "label2";
            label2.Size = new Size(106, 25);
            label2.TabIndex = 3;
            label2.Text = "Old Amount";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightGray;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(308, 64);
            label3.Name = "label3";
            label3.Size = new Size(113, 25);
            label3.TabIndex = 4;
            label3.Text = "New Amount";
            // 
            // inventoryPanel
            // 
            inventoryPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            inventoryPanel.AutoScroll = true;
            inventoryPanel.Location = new Point(8, 95);
            inventoryPanel.Name = "inventoryPanel";
            inventoryPanel.Size = new Size(512, 522);
            inventoryPanel.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.AutoScroll = true;
            panel2.Controls.Add(saveSelector);
            panel2.Controls.Add(saveImageBox);
            panel2.Controls.Add(userIDComboBox);
            panel2.Controls.Add(radioButtonMultClient);
            panel2.Controls.Add(radioButtonMultHost);
            panel2.Controls.Add(radioButtonSingle);
            panel2.Controls.Add(changesButton);
            panel2.Location = new Point(530, 73);
            panel2.Name = "panel2";
            panel2.Size = new Size(330, 604);
            panel2.TabIndex = 6;
            // 
            // saveSelector
            // 
            saveSelector.DrawMode = DrawMode.OwnerDrawFixed;
            saveSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            saveSelector.FormattingEnabled = true;
            saveSelector.IntegralHeight = false;
            saveSelector.ItemHeight = 120;
            saveSelector.Location = new Point(12, 129);
            saveSelector.Name = "saveSelector";
            saveSelector.Size = new Size(300, 126);
            saveSelector.TabIndex = 6;
            saveSelector.SelectedIndexChanged += saveIDComboBox_SelectedIndexChanged;
            // 
            // saveImageBox
            // 
            saveImageBox.BorderStyle = BorderStyle.FixedSingle;
            saveImageBox.ImageLocation = "";
            saveImageBox.Location = new Point(27, 282);
            saveImageBox.Name = "saveImageBox";
            saveImageBox.Size = new Size(256, 160);
            saveImageBox.TabIndex = 5;
            saveImageBox.TabStop = false;
            // 
            // userIDComboBox
            // 
            userIDComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            userIDComboBox.FormattingEnabled = true;
            userIDComboBox.Location = new Point(12, 95);
            userIDComboBox.Name = "userIDComboBox";
            userIDComboBox.Size = new Size(300, 28);
            userIDComboBox.TabIndex = 4;
            userIDComboBox.SelectedIndexChanged += userIDComboBox_SelectedIndexChanged;
            // 
            // radioButtonMultClient
            // 
            radioButtonMultClient.AutoSize = true;
            radioButtonMultClient.Location = new Point(12, 44);
            radioButtonMultClient.Name = "radioButtonMultClient";
            radioButtonMultClient.Size = new Size(157, 24);
            radioButtonMultClient.TabIndex = 3;
            radioButtonMultClient.Tag = "Multiplayer (Client)";
            radioButtonMultClient.Text = "Multiplayer (Client)";
            radioButtonMultClient.UseVisualStyleBackColor = true;
            radioButtonMultClient.CheckedChanged += folderRadioButton_CheckedChanged;
            // 
            // radioButtonMultHost
            // 
            radioButtonMultHost.AutoSize = true;
            radioButtonMultHost.Location = new Point(12, 14);
            radioButtonMultHost.Name = "radioButtonMultHost";
            radioButtonMultHost.Size = new Size(150, 24);
            radioButtonMultHost.TabIndex = 1;
            radioButtonMultHost.Tag = "Multiplayer";
            radioButtonMultHost.Text = "Multiplayer (Host)";
            radioButtonMultHost.UseVisualStyleBackColor = true;
            radioButtonMultHost.CheckedChanged += folderRadioButton_CheckedChanged;
            // 
            // radioButtonSingle
            // 
            radioButtonSingle.AutoSize = true;
            radioButtonSingle.Location = new Point(162, 14);
            radioButtonSingle.Name = "radioButtonSingle";
            radioButtonSingle.Size = new Size(112, 24);
            radioButtonSingle.TabIndex = 0;
            radioButtonSingle.Tag = "SinglePlayer";
            radioButtonSingle.Text = "Singleplayer";
            radioButtonSingle.UseVisualStyleBackColor = true;
            radioButtonSingle.CheckedChanged += folderRadioButton_CheckedChanged;
            // 
            // versionLabel
            // 
            versionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            versionLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            versionLabel.ImageAlign = ContentAlignment.MiddleRight;
            versionLabel.Location = new Point(383, 683);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(485, 26);
            versionLabel.TabIndex = 5;
            versionLabel.Text = "Checking for Update...";
            versionLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(872, 28);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createBackupToolStripMenuItem, toolStripSeparator8, regrowAllTreesToolStripMenuItem, removeAllBlueprintsToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(58, 24);
            toolsToolStripMenuItem.Tag = "";
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // createBackupToolStripMenuItem
            // 
            createBackupToolStripMenuItem.Name = "createBackupToolStripMenuItem";
            createBackupToolStripMenuItem.Size = new Size(236, 26);
            createBackupToolStripMenuItem.Text = "Create Backup";
            createBackupToolStripMenuItem.Click += createBackupToolStripMenuItem_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(233, 6);
            // 
            // regrowAllTreesToolStripMenuItem
            // 
            regrowAllTreesToolStripMenuItem.Name = "regrowAllTreesToolStripMenuItem";
            regrowAllTreesToolStripMenuItem.Size = new Size(236, 26);
            regrowAllTreesToolStripMenuItem.Text = "Regrow all trees";
            regrowAllTreesToolStripMenuItem.Click += regrowAllTreesToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openReadMeToolStripMenuItem, toolStripMenuItem1, openSaveGameFolderToolStripMenuItem, toolStripSeparator7, clickMeToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // openReadMeToolStripMenuItem
            // 
            openReadMeToolStripMenuItem.Name = "openReadMeToolStripMenuItem";
            openReadMeToolStripMenuItem.Size = new Size(248, 26);
            openReadMeToolStripMenuItem.Tag = ".\\Files\\Readme.txt";
            openReadMeToolStripMenuItem.Text = "Open ReadMe";
            openReadMeToolStripMenuItem.Click += openFileToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(248, 26);
            toolStripMenuItem1.Tag = ".\\Files\\ItemIDList.csv";
            toolStripMenuItem1.Text = "Open ItemIDList";
            toolStripMenuItem1.Click += openFileToolStripMenuItem_Click;
            // 
            // openSaveGameFolderToolStripMenuItem
            // 
            openSaveGameFolderToolStripMenuItem.Enabled = false;
            openSaveGameFolderToolStripMenuItem.Name = "openSaveGameFolderToolStripMenuItem";
            openSaveGameFolderToolStripMenuItem.Size = new Size(248, 26);
            openSaveGameFolderToolStripMenuItem.Text = "Open SaveGame Folder";
            openSaveGameFolderToolStripMenuItem.ToolTipText = "Select a folder first";
            openSaveGameFolderToolStripMenuItem.Click += openSaveGameFolderToolStripMenuItem_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(245, 6);
            // 
            // clickMeToolStripMenuItem
            // 
            clickMeToolStripMenuItem.Name = "clickMeToolStripMenuItem";
            clickMeToolStripMenuItem.Size = new Size(248, 26);
            clickMeToolStripMenuItem.Text = "Check for Update";
            clickMeToolStripMenuItem.Click += checkForUpdateToolStripMenuItem_Click;
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(224, 26);
            newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Enabled = false;
            openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(224, 26);
            openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(221, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(224, 26);
            saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(224, 26);
            saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(221, 6);
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Image = (Image)resources.GetObject("printToolStripMenuItem.Image");
            printToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            printToolStripMenuItem.Size = new Size(224, 26);
            printToolStripMenuItem.Text = "&Print";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(221, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(224, 26);
            exitToolStripMenuItem.Text = "E&xit";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(221, 6);
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(224, 26);
            undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoToolStripMenuItem.Size = new Size(224, 26);
            redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(221, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = (Image)resources.GetObject("cutToolStripMenuItem.Image");
            cutToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(224, 26);
            cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = (Image)resources.GetObject("copyToolStripMenuItem.Image");
            copyToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(224, 26);
            copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Image = (Image)resources.GetObject("pasteToolStripMenuItem.Image");
            pasteToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(224, 26);
            pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(221, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new Size(224, 26);
            selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            customizeToolStripMenuItem.Size = new Size(224, 26);
            customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(224, 26);
            optionsToolStripMenuItem.Text = "&Options";
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.Size = new Size(224, 26);
            contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            indexToolStripMenuItem.Size = new Size(224, 26);
            indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(224, 26);
            searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(221, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(224, 26);
            aboutToolStripMenuItem.Text = "&About...";
            // 
            // maxButton
            // 
            maxButton.Enabled = false;
            maxButton.Location = new Point(308, 13);
            maxButton.Name = "maxButton";
            maxButton.Size = new Size(109, 29);
            maxButton.TabIndex = 8;
            maxButton.Tag = "True";
            maxButton.Text = "Set all to 100";
            maxButton.UseVisualStyleBackColor = true;
            maxButton.Click += bulkChangeAmount_Click;
            // 
            // emptyButton
            // 
            emptyButton.Enabled = false;
            emptyButton.Location = new Point(423, 13);
            emptyButton.Name = "emptyButton";
            emptyButton.Size = new Size(94, 29);
            emptyButton.TabIndex = 9;
            emptyButton.Tag = "False";
            emptyButton.Text = "Remove all";
            emptyButton.UseVisualStyleBackColor = true;
            emptyButton.Click += bulkChangeAmount_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(inventoryTab);
            tabControl1.Controls.Add(armorTab);
            tabControl1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl1.Location = new Point(0, 31);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(872, 650);
            tabControl1.TabIndex = 10;
            tabControl1.Tag = "";
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // inventoryTab
            // 
            inventoryTab.Controls.Add(emptyButton);
            inventoryTab.Controls.Add(searchButton);
            inventoryTab.Controls.Add(maxButton);
            inventoryTab.Controls.Add(inventoryPanel);
            inventoryTab.Controls.Add(searchBox);
            inventoryTab.Controls.Add(label2);
            inventoryTab.Controls.Add(label1);
            inventoryTab.Controls.Add(label3);
            inventoryTab.Location = new Point(4, 29);
            inventoryTab.Name = "inventoryTab";
            inventoryTab.Padding = new Padding(3);
            inventoryTab.Size = new Size(864, 617);
            inventoryTab.TabIndex = 0;
            inventoryTab.Tag = "";
            inventoryTab.Text = "Inventory";
            inventoryTab.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            searchButton.Enabled = false;
            searchButton.Location = new Point(200, 13);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(64, 29);
            searchButton.TabIndex = 11;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(6, 15);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(188, 27);
            searchBox.TabIndex = 10;
            searchBox.Text = "Search Text...";
            searchBox.Enter += searchBox_Enter;
            // 
            // armorTab
            // 
            armorTab.Controls.Add(armorTypeBox);
            armorTab.Controls.Add(armorPanel);
            armorTab.Controls.Add(writeArmorButton);
            armorTab.ForeColor = SystemColors.ControlText;
            armorTab.ImageKey = "(none)";
            armorTab.Location = new Point(4, 29);
            armorTab.Name = "armorTab";
            armorTab.Padding = new Padding(3);
            armorTab.Size = new Size(864, 617);
            armorTab.TabIndex = 1;
            armorTab.Text = "Armor Tool";
            armorTab.UseVisualStyleBackColor = true;
            // 
            // armorTypeBox
            // 
            armorTypeBox.FormattingEnabled = true;
            armorTypeBox.Location = new Point(17, 539);
            armorTypeBox.Name = "armorTypeBox";
            armorTypeBox.Size = new Size(151, 28);
            armorTypeBox.TabIndex = 3;
            armorTypeBox.SelectedIndexChanged += armorTypeBox_SelectedIndexChanged;
            // 
            // armorPanel
            // 
            armorPanel.Controls.Add(label5);
            armorPanel.Location = new Point(8, 83);
            armorPanel.Name = "armorPanel";
            armorPanel.Size = new Size(512, 423);
            armorPanel.TabIndex = 5;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(131, 211);
            label5.Name = "label5";
            label5.Size = new Size(251, 32);
            label5.TabIndex = 1;
            label5.Text = "Select SaveGame first!";
            // 
            // writeArmorButton
            // 
            writeArmorButton.Enabled = false;
            writeArmorButton.Location = new Point(231, 512);
            writeArmorButton.Name = "writeArmorButton";
            writeArmorButton.Size = new Size(262, 81);
            writeArmorButton.TabIndex = 4;
            writeArmorButton.Text = "Set all armor to {0}";
            toolTip1.SetToolTip(writeArmorButton, "It´s over 9000!");
            writeArmorButton.UseVisualStyleBackColor = true;
            writeArmorButton.Click += setArmorButton_Click;
            // 
            // removeAllBlueprintsToolStripMenuItem
            // 
            removeAllBlueprintsToolStripMenuItem.Name = "removeAllBlueprintsToolStripMenuItem";
            removeAllBlueprintsToolStripMenuItem.Size = new Size(236, 26);
            removeAllBlueprintsToolStripMenuItem.Text = "Remove all Blueprints";
            removeAllBlueprintsToolStripMenuItem.Click += removeAllBlueprintsToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AcceptButton = searchButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 718);
            Controls.Add(panel2);
            Controls.Add(tabControl1);
            Controls.Add(versionLabel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SoTFEditor";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)saveImageBox).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            inventoryTab.ResumeLayout(false);
            inventoryTab.PerformLayout();
            armorTab.ResumeLayout(false);
            armorPanel.ResumeLayout(false);
            armorPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button changesButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel inventoryPanel;
        private Panel panel2;
        private RadioButton radioButtonMultHost;
        private RadioButton radioButtonSingle;
        private RadioButton radioButtonMultClient;
        private ComboBox userIDComboBox;
        private Label versionLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem clickMeToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem contentsToolStripMenuItem;
        private ToolStripMenuItem indexToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem openReadMeToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem regrowAllTreesToolStripMenuItem;
        private ToolStripMenuItem createBackupToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private Button maxButton;
        private Button emptyButton;
        private ToolStripMenuItem openSaveGameFolderToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage armorTab;
        private TabPage inventoryTab;
        private ComboBox armorTypeBox;
        private Button writeArmorButton;
        private Panel armorPanel;
        private ToolTip toolTip1;
        private Label label5;
        private PictureBox saveImageBox;
        private SaveSelector saveSelector;
        private TextBox searchBox;
        private Button searchButton;
        private ToolStripMenuItem removeAllBlueprintsToolStripMenuItem;
    }
}