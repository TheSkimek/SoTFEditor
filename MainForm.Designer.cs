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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            changesButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            userIDComboBox = new ComboBox();
            radioButtonMultClient = new RadioButton();
            saveIDComboBox = new ComboBox();
            radioButtonMultHost = new RadioButton();
            radioButtonSingle = new RadioButton();
            versionLabel = new Label();
            menuStrip1 = new MenuStrip();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            createBackupToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            regrowAllTreesToolStripMenuItem = new ToolStripMenuItem();
            openTestToolStripMenuItem = new ToolStripMenuItem();
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
            panel2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // changesButton
            // 
            changesButton.Enabled = false;
            changesButton.Location = new Point(12, 306);
            changesButton.Name = "changesButton";
            changesButton.Size = new Size(269, 68);
            changesButton.TabIndex = 0;
            changesButton.Text = "Write changes to file";
            changesButton.UseVisualStyleBackColor = true;
            changesButton.Click += writeFileButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.LightGray;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 39);
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
            label2.Location = new Point(162, 39);
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
            label3.Location = new Point(312, 39);
            label3.Name = "label3";
            label3.Size = new Size(113, 25);
            label3.TabIndex = 4;
            label3.Text = "New Amount";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel1.AutoScroll = true;
            panel1.Location = new Point(12, 67);
            panel1.Name = "panel1";
            panel1.Size = new Size(512, 554);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.AutoScroll = true;
            panel2.Controls.Add(userIDComboBox);
            panel2.Controls.Add(radioButtonMultClient);
            panel2.Controls.Add(saveIDComboBox);
            panel2.Controls.Add(radioButtonMultHost);
            panel2.Controls.Add(radioButtonSingle);
            panel2.Controls.Add(changesButton);
            panel2.Location = new Point(527, 67);
            panel2.Name = "panel2";
            panel2.Size = new Size(291, 554);
            panel2.TabIndex = 6;
            // 
            // userIDComboBox
            // 
            userIDComboBox.FormattingEnabled = true;
            userIDComboBox.Location = new Point(15, 89);
            userIDComboBox.Name = "userIDComboBox";
            userIDComboBox.Size = new Size(228, 28);
            userIDComboBox.TabIndex = 4;
            userIDComboBox.SelectedIndexChanged += userIDComboBox_SelectedIndexChanged;
            // 
            // radioButtonMultClient
            // 
            radioButtonMultClient.AutoSize = true;
            radioButtonMultClient.Location = new Point(3, 44);
            radioButtonMultClient.Name = "radioButtonMultClient";
            radioButtonMultClient.Size = new Size(157, 24);
            radioButtonMultClient.TabIndex = 3;
            radioButtonMultClient.Tag = "Multiplayer (Client)";
            radioButtonMultClient.Text = "Multiplayer (Client)";
            radioButtonMultClient.UseVisualStyleBackColor = true;
            radioButtonMultClient.CheckedChanged += folderRadioButton_CheckedChanged;
            // 
            // saveIDComboBox
            // 
            saveIDComboBox.FormattingEnabled = true;
            saveIDComboBox.Location = new Point(15, 132);
            saveIDComboBox.Name = "saveIDComboBox";
            saveIDComboBox.Size = new Size(228, 28);
            saveIDComboBox.TabIndex = 2;
            saveIDComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // radioButtonMultHost
            // 
            radioButtonMultHost.AutoSize = true;
            radioButtonMultHost.Location = new Point(3, 14);
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
            radioButtonSingle.Location = new Point(153, 14);
            radioButtonSingle.Name = "radioButtonSingle";
            radioButtonSingle.Size = new Size(112, 24);
            radioButtonSingle.TabIndex = 0;
            radioButtonSingle.Tag = "Singleplayer";
            radioButtonSingle.Text = "Singleplayer";
            radioButtonSingle.UseVisualStyleBackColor = true;
            radioButtonSingle.CheckedChanged += folderRadioButton_CheckedChanged;
            // 
            // versionLabel
            // 
            versionLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            versionLabel.AutoSize = true;
            versionLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            versionLabel.Location = new Point(621, 640);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(197, 25);
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
            menuStrip1.Size = new Size(830, 28);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createBackupToolStripMenuItem, toolStripSeparator8, regrowAllTreesToolStripMenuItem, openTestToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(58, 24);
            toolsToolStripMenuItem.Tag = "";
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // createBackupToolStripMenuItem
            // 
            createBackupToolStripMenuItem.Name = "createBackupToolStripMenuItem";
            createBackupToolStripMenuItem.Size = new Size(207, 26);
            createBackupToolStripMenuItem.Text = "Create Backup";
            createBackupToolStripMenuItem.Click += createBackupToolStripMenuItem_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(204, 6);
            // 
            // regrowAllTreesToolStripMenuItem
            // 
            regrowAllTreesToolStripMenuItem.Name = "regrowAllTreesToolStripMenuItem";
            regrowAllTreesToolStripMenuItem.Size = new Size(207, 26);
            regrowAllTreesToolStripMenuItem.Text = "Regrow all trees";
            regrowAllTreesToolStripMenuItem.Click += regrowAllTreesToolStripMenuItem_Click;
            // 
            // openTestToolStripMenuItem
            // 
            openTestToolStripMenuItem.Enabled = false;
            openTestToolStripMenuItem.Name = "openTestToolStripMenuItem";
            openTestToolStripMenuItem.Size = new Size(207, 26);
            openTestToolStripMenuItem.Text = "Open Armor Tool";
            openTestToolStripMenuItem.ToolTipText = "Select a folder first";
            openTestToolStripMenuItem.Click += openArmorToolStripMenuItem_Click;
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
            maxButton.Location = new Point(442, 37);
            maxButton.Name = "maxButton";
            maxButton.Size = new Size(156, 29);
            maxButton.TabIndex = 8;
            maxButton.Tag = "True";
            maxButton.Text = "Set all to 100";
            maxButton.UseVisualStyleBackColor = true;
            maxButton.Click += bulkChangeAmount_Click;
            // 
            // emptyButton
            // 
            emptyButton.Enabled = false;
            emptyButton.Location = new Point(604, 37);
            emptyButton.Name = "emptyButton";
            emptyButton.Size = new Size(94, 29);
            emptyButton.TabIndex = 9;
            emptyButton.Tag = "False";
            emptyButton.Text = "Remove all";
            emptyButton.UseVisualStyleBackColor = true;
            emptyButton.Click += bulkChangeAmount_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 674);
            Controls.Add(emptyButton);
            Controls.Add(maxButton);
            Controls.Add(versionLabel);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SoTFEditor";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button changesButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private Panel panel2;
        private RadioButton radioButtonMultHost;
        private RadioButton radioButtonSingle;
        private ComboBox saveIDComboBox;
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
        private ToolStripMenuItem openTestToolStripMenuItem;
        private ToolStripMenuItem openSaveGameFolderToolStripMenuItem;
    }
}