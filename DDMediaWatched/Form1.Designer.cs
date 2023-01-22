
namespace DDMediaWatched
{
    partial class Form1
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
            if (disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            this.listViewTitles = new System.Windows.Forms.ListView();
            this.contextMenuStripTitle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addFullWatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findSizeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTitles = new System.Windows.Forms.Label();
            this.textBoxTitleInfo = new System.Windows.Forms.TextBox();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.labelTitleInfo = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.buttonNewFranchise = new System.Windows.Forms.Button();
            this.buttonNewFranchiseSave = new System.Windows.Forms.Button();
            this.labelNewFranchise1 = new System.Windows.Forms.Label();
            this.textBoxNewFranchiseNames = new System.Windows.Forms.TextBox();
            this.labelNewFranchise2 = new System.Windows.Forms.Label();
            this.comboBoxNewFranchiseType = new System.Windows.Forms.ComboBox();
            this.textBoxNewFranchisePath = new System.Windows.Forms.TextBox();
            this.labelNewFranchise3 = new System.Windows.Forms.Label();
            this.buttonNewPart = new System.Windows.Forms.Button();
            this.buttonNewPartSave = new System.Windows.Forms.Button();
            this.textBoxNewPartName = new System.Windows.Forms.TextBox();
            this.labelNewPart1 = new System.Windows.Forms.Label();
            this.textBoxNewPartPath = new System.Windows.Forms.TextBox();
            this.labelNewPart4 = new System.Windows.Forms.Label();
            this.checkBoxNewPartIsPathFile = new System.Windows.Forms.CheckBox();
            this.textBoxNewPartLength = new System.Windows.Forms.TextBox();
            this.labelNewPart5 = new System.Windows.Forms.Label();
            this.labelParts = new System.Windows.Forms.Label();
            this.listViewParts = new System.Windows.Forms.ListView();
            this.contextMenuStripPart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFullViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelPartInfo = new System.Windows.Forms.Label();
            this.textBoxPartInfo = new System.Windows.Forms.TextBox();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.labelFontSize = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.textBoxNewPartLengths = new System.Windows.Forms.TextBox();
            this.labelNewPartLengths = new System.Windows.Forms.Label();
            this.numericUpDownNewPartSeries = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxNewPart = new System.Windows.Forms.GroupBox();
            this.buttonNewPartCommonLengthToAll = new System.Windows.Forms.Button();
            this.labelNewPartCOW = new System.Windows.Forms.Label();
            this.textBoxNewPartCOW = new System.Windows.Forms.TextBox();
            this.groupBoxNewFranchise = new System.Windows.Forms.GroupBox();
            this.buttonNewFranchiseToday = new System.Windows.Forms.Button();
            this.labelNewFranchiseDate = new System.Windows.Forms.Label();
            this.textBoxNewFranchiseDate = new System.Windows.Forms.TextBox();
            this.buttonSort = new System.Windows.Forms.Button();
            this.groupBoxSort = new System.Windows.Forms.GroupBox();
            this.comboBoxSortColorBy = new System.Windows.Forms.ComboBox();
            this.labelSortColorBy = new System.Windows.Forms.Label();
            this.checkedListBoxSortTypesPersentage = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxSortTypesDown = new System.Windows.Forms.CheckedListBox();
            this.checkBoxSortReverse = new System.Windows.Forms.CheckBox();
            this.comboBoxSortSortBy = new System.Windows.Forms.ComboBox();
            this.labelSortSortBy = new System.Windows.Forms.Label();
            this.checkedListBoxSortTypesGenre = new System.Windows.Forms.CheckedListBox();
            this.labelSortTypes = new System.Windows.Forms.Label();
            this.buttonSortSave = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findAllSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelNewPartSeries = new System.Windows.Forms.Label();
            this.contextMenuStripTitle.SuspendLayout();
            this.contextMenuStripPart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewPartSeries)).BeginInit();
            this.groupBoxNewPart.SuspendLayout();
            this.groupBoxNewFranchise.SuspendLayout();
            this.groupBoxSort.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewTitles
            // 
            this.listViewTitles.ContextMenuStrip = this.contextMenuStripTitle;
            this.listViewTitles.Font = new System.Drawing.Font("Consolas", 8F);
            this.listViewTitles.FullRowSelect = true;
            this.listViewTitles.GridLines = true;
            this.listViewTitles.HideSelection = false;
            this.listViewTitles.Location = new System.Drawing.Point(12, 25);
            this.listViewTitles.MultiSelect = false;
            this.listViewTitles.Name = "listViewTitles";
            this.listViewTitles.Size = new System.Drawing.Size(460, 404);
            this.listViewTitles.TabIndex = 0;
            this.listViewTitles.UseCompatibleStateImageBehavior = false;
            this.listViewTitles.View = System.Windows.Forms.View.Details;
            this.listViewTitles.SelectedIndexChanged += new System.EventHandler(this.listViewTitles_SelectedIndexChanged);
            // 
            // contextMenuStripTitle
            // 
            this.contextMenuStripTitle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem1,
            this.addFullWatchToolStripMenuItem,
            this.findSizeToolStripMenuItem1,
            this.editToolStripMenuItem});
            this.contextMenuStripTitle.Name = "contextMenuStripTitle";
            this.contextMenuStripTitle.Size = new System.Drawing.Size(144, 92);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // addFullWatchToolStripMenuItem
            // 
            this.addFullWatchToolStripMenuItem.Name = "addFullWatchToolStripMenuItem";
            this.addFullWatchToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addFullWatchToolStripMenuItem.Text = "Add full view";
            this.addFullWatchToolStripMenuItem.Click += new System.EventHandler(this.addFullWatchToolStripMenuItem_Click);
            // 
            // findSizeToolStripMenuItem1
            // 
            this.findSizeToolStripMenuItem1.Name = "findSizeToolStripMenuItem1";
            this.findSizeToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.findSizeToolStripMenuItem1.Text = "Find size";
            this.findSizeToolStripMenuItem1.Click += new System.EventHandler(this.findSizeToolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // labelTitles
            // 
            this.labelTitles.AutoSize = true;
            this.labelTitles.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelTitles.Location = new System.Drawing.Point(12, 9);
            this.labelTitles.Name = "labelTitles";
            this.labelTitles.Size = new System.Drawing.Size(73, 13);
            this.labelTitles.TabIndex = 1;
            this.labelTitles.Text = "Franchises:";
            // 
            // textBoxTitleInfo
            // 
            this.textBoxTitleInfo.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxTitleInfo.Location = new System.Drawing.Point(12, 448);
            this.textBoxTitleInfo.Multiline = true;
            this.textBoxTitleInfo.Name = "textBoxTitleInfo";
            this.textBoxTitleInfo.ReadOnly = true;
            this.textBoxTitleInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTitleInfo.Size = new System.Drawing.Size(460, 250);
            this.textBoxTitleInfo.TabIndex = 2;
            this.textBoxTitleInfo.WordWrap = false;
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxInfo.Location = new System.Drawing.Point(958, 25);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ReadOnly = true;
            this.textBoxInfo.Size = new System.Drawing.Size(310, 365);
            this.textBoxInfo.TabIndex = 3;
            // 
            // labelTitleInfo
            // 
            this.labelTitleInfo.AutoSize = true;
            this.labelTitleInfo.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelTitleInfo.Location = new System.Drawing.Point(9, 432);
            this.labelTitleInfo.Name = "labelTitleInfo";
            this.labelTitleInfo.Size = new System.Drawing.Size(73, 13);
            this.labelTitleInfo.TabIndex = 4;
            this.labelTitleInfo.Text = "Title info:";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelInfo.Location = new System.Drawing.Point(855, 9);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(37, 13);
            this.labelInfo.TabIndex = 5;
            this.labelInfo.Text = "Info:";
            // 
            // buttonNewFranchise
            // 
            this.buttonNewFranchise.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonNewFranchise.Location = new System.Drawing.Point(952, 396);
            this.buttonNewFranchise.Name = "buttonNewFranchise";
            this.buttonNewFranchise.Size = new System.Drawing.Size(100, 23);
            this.buttonNewFranchise.TabIndex = 6;
            this.buttonNewFranchise.Text = "New franchise";
            this.buttonNewFranchise.UseVisualStyleBackColor = true;
            this.buttonNewFranchise.Click += new System.EventHandler(this.buttonNewFranchise_Click);
            // 
            // buttonNewFranchiseSave
            // 
            this.buttonNewFranchiseSave.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonNewFranchiseSave.Location = new System.Drawing.Point(184, 349);
            this.buttonNewFranchiseSave.Name = "buttonNewFranchiseSave";
            this.buttonNewFranchiseSave.Size = new System.Drawing.Size(130, 23);
            this.buttonNewFranchiseSave.TabIndex = 7;
            this.buttonNewFranchiseSave.Text = "Save";
            this.buttonNewFranchiseSave.UseVisualStyleBackColor = true;
            this.buttonNewFranchiseSave.Click += new System.EventHandler(this.buttonNewFranchiseSave_Click);
            // 
            // labelNewFranchise1
            // 
            this.labelNewFranchise1.AutoSize = true;
            this.labelNewFranchise1.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewFranchise1.Location = new System.Drawing.Point(6, 16);
            this.labelNewFranchise1.Name = "labelNewFranchise1";
            this.labelNewFranchise1.Size = new System.Drawing.Size(151, 13);
            this.labelNewFranchise1.TabIndex = 8;
            this.labelNewFranchise1.Text = "Names (separate with ;):";
            // 
            // textBoxNewFranchiseNames
            // 
            this.textBoxNewFranchiseNames.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewFranchiseNames.Location = new System.Drawing.Point(7, 32);
            this.textBoxNewFranchiseNames.Name = "textBoxNewFranchiseNames";
            this.textBoxNewFranchiseNames.Size = new System.Drawing.Size(305, 20);
            this.textBoxNewFranchiseNames.TabIndex = 9;
            // 
            // labelNewFranchise2
            // 
            this.labelNewFranchise2.AutoSize = true;
            this.labelNewFranchise2.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewFranchise2.Location = new System.Drawing.Point(6, 55);
            this.labelNewFranchise2.Name = "labelNewFranchise2";
            this.labelNewFranchise2.Size = new System.Drawing.Size(37, 13);
            this.labelNewFranchise2.TabIndex = 10;
            this.labelNewFranchise2.Text = "Type:";
            // 
            // comboBoxNewFranchiseType
            // 
            this.comboBoxNewFranchiseType.Font = new System.Drawing.Font("Consolas", 8F);
            this.comboBoxNewFranchiseType.FormattingEnabled = true;
            this.comboBoxNewFranchiseType.Items.AddRange(new object[] {
            "Anime",
            "Cartoon",
            "Film",
            "Dorama"});
            this.comboBoxNewFranchiseType.Location = new System.Drawing.Point(7, 71);
            this.comboBoxNewFranchiseType.Name = "comboBoxNewFranchiseType";
            this.comboBoxNewFranchiseType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNewFranchiseType.TabIndex = 11;
            // 
            // textBoxNewFranchisePath
            // 
            this.textBoxNewFranchisePath.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewFranchisePath.Location = new System.Drawing.Point(7, 111);
            this.textBoxNewFranchisePath.Name = "textBoxNewFranchisePath";
            this.textBoxNewFranchisePath.Size = new System.Drawing.Size(305, 20);
            this.textBoxNewFranchisePath.TabIndex = 13;
            // 
            // labelNewFranchise3
            // 
            this.labelNewFranchise3.AutoSize = true;
            this.labelNewFranchise3.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewFranchise3.Location = new System.Drawing.Point(6, 95);
            this.labelNewFranchise3.Name = "labelNewFranchise3";
            this.labelNewFranchise3.Size = new System.Drawing.Size(37, 13);
            this.labelNewFranchise3.TabIndex = 12;
            this.labelNewFranchise3.Text = "Path:";
            // 
            // buttonNewPart
            // 
            this.buttonNewPart.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonNewPart.Location = new System.Drawing.Point(1062, 396);
            this.buttonNewPart.Name = "buttonNewPart";
            this.buttonNewPart.Size = new System.Drawing.Size(100, 23);
            this.buttonNewPart.TabIndex = 14;
            this.buttonNewPart.Text = "New part";
            this.buttonNewPart.UseVisualStyleBackColor = true;
            this.buttonNewPart.Click += new System.EventHandler(this.buttonNewPart_Click);
            // 
            // buttonNewPartSave
            // 
            this.buttonNewPartSave.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonNewPartSave.Location = new System.Drawing.Point(184, 351);
            this.buttonNewPartSave.Name = "buttonNewPartSave";
            this.buttonNewPartSave.Size = new System.Drawing.Size(130, 23);
            this.buttonNewPartSave.TabIndex = 15;
            this.buttonNewPartSave.Text = "Save";
            this.buttonNewPartSave.UseVisualStyleBackColor = true;
            this.buttonNewPartSave.Click += new System.EventHandler(this.buttonNewPartSave_Click);
            // 
            // textBoxNewPartName
            // 
            this.textBoxNewPartName.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewPartName.Location = new System.Drawing.Point(50, 19);
            this.textBoxNewPartName.Name = "textBoxNewPartName";
            this.textBoxNewPartName.Size = new System.Drawing.Size(264, 20);
            this.textBoxNewPartName.TabIndex = 17;
            // 
            // labelNewPart1
            // 
            this.labelNewPart1.AutoSize = true;
            this.labelNewPart1.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPart1.Location = new System.Drawing.Point(6, 22);
            this.labelNewPart1.Name = "labelNewPart1";
            this.labelNewPart1.Size = new System.Drawing.Size(37, 13);
            this.labelNewPart1.TabIndex = 16;
            this.labelNewPart1.Text = "Name:";
            // 
            // textBoxNewPartPath
            // 
            this.textBoxNewPartPath.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewPartPath.Location = new System.Drawing.Point(50, 45);
            this.textBoxNewPartPath.Name = "textBoxNewPartPath";
            this.textBoxNewPartPath.Size = new System.Drawing.Size(264, 20);
            this.textBoxNewPartPath.TabIndex = 23;
            this.textBoxNewPartPath.TextChanged += new System.EventHandler(this.textBoxNewPartPath_TextChanged);
            // 
            // labelNewPart4
            // 
            this.labelNewPart4.AutoSize = true;
            this.labelNewPart4.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPart4.Location = new System.Drawing.Point(6, 49);
            this.labelNewPart4.Name = "labelNewPart4";
            this.labelNewPart4.Size = new System.Drawing.Size(37, 13);
            this.labelNewPart4.TabIndex = 22;
            this.labelNewPart4.Text = "Path:";
            // 
            // checkBoxNewPartIsPathFile
            // 
            this.checkBoxNewPartIsPathFile.AutoSize = true;
            this.checkBoxNewPartIsPathFile.Font = new System.Drawing.Font("Consolas", 8F);
            this.checkBoxNewPartIsPathFile.Location = new System.Drawing.Point(216, 71);
            this.checkBoxNewPartIsPathFile.Name = "checkBoxNewPartIsPathFile";
            this.checkBoxNewPartIsPathFile.Size = new System.Drawing.Size(98, 17);
            this.checkBoxNewPartIsPathFile.TabIndex = 25;
            this.checkBoxNewPartIsPathFile.Text = "Is path file";
            this.checkBoxNewPartIsPathFile.UseVisualStyleBackColor = true;
            this.checkBoxNewPartIsPathFile.CheckedChanged += new System.EventHandler(this.checkBoxNewPartIsPathFile_CheckedChanged);
            // 
            // textBoxNewPartLength
            // 
            this.textBoxNewPartLength.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewPartLength.Location = new System.Drawing.Point(109, 94);
            this.textBoxNewPartLength.Name = "textBoxNewPartLength";
            this.textBoxNewPartLength.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewPartLength.TabIndex = 27;
            this.textBoxNewPartLength.TextChanged += new System.EventHandler(this.textBoxNewPartLength_TextChanged);
            // 
            // labelNewPart5
            // 
            this.labelNewPart5.AutoSize = true;
            this.labelNewPart5.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPart5.Location = new System.Drawing.Point(6, 98);
            this.labelNewPart5.Name = "labelNewPart5";
            this.labelNewPart5.Size = new System.Drawing.Size(97, 13);
            this.labelNewPart5.TabIndex = 26;
            this.labelNewPart5.Text = "Average length:";
            // 
            // labelParts
            // 
            this.labelParts.AutoSize = true;
            this.labelParts.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelParts.Location = new System.Drawing.Point(486, 9);
            this.labelParts.Name = "labelParts";
            this.labelParts.Size = new System.Drawing.Size(43, 13);
            this.labelParts.TabIndex = 30;
            this.labelParts.Text = "Parts:";
            // 
            // listViewParts
            // 
            this.listViewParts.ContextMenuStrip = this.contextMenuStripPart;
            this.listViewParts.Font = new System.Drawing.Font("Consolas", 8F);
            this.listViewParts.FullRowSelect = true;
            this.listViewParts.GridLines = true;
            this.listViewParts.HideSelection = false;
            this.listViewParts.Location = new System.Drawing.Point(486, 25);
            this.listViewParts.MultiSelect = false;
            this.listViewParts.Name = "listViewParts";
            this.listViewParts.Size = new System.Drawing.Size(460, 404);
            this.listViewParts.TabIndex = 29;
            this.listViewParts.UseCompatibleStateImageBehavior = false;
            this.listViewParts.View = System.Windows.Forms.View.Details;
            this.listViewParts.SelectedIndexChanged += new System.EventHandler(this.listViewParts_SelectedIndexChanged);
            // 
            // contextMenuStripPart
            // 
            this.contextMenuStripPart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.addFullViewToolStripMenuItem,
            this.findSizeToolStripMenuItem,
            this.editToolStripMenuItem1,
            this.upToolStripMenuItem,
            this.downToolStripMenuItem});
            this.contextMenuStripPart.Name = "contextMenuStripPart";
            this.contextMenuStripPart.Size = new System.Drawing.Size(144, 136);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // addFullViewToolStripMenuItem
            // 
            this.addFullViewToolStripMenuItem.Name = "addFullViewToolStripMenuItem";
            this.addFullViewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addFullViewToolStripMenuItem.Text = "Add full view";
            this.addFullViewToolStripMenuItem.Click += new System.EventHandler(this.addFullViewToolStripMenuItem_Click);
            // 
            // findSizeToolStripMenuItem
            // 
            this.findSizeToolStripMenuItem.Name = "findSizeToolStripMenuItem";
            this.findSizeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.findSizeToolStripMenuItem.Text = "Find size";
            this.findSizeToolStripMenuItem.Click += new System.EventHandler(this.findSizeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.editToolStripMenuItem1.Text = "Edit";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.upToolStripMenuItem.Text = "Up";
            this.upToolStripMenuItem.Click += new System.EventHandler(this.upToolStripMenuItem_Click);
            // 
            // downToolStripMenuItem
            // 
            this.downToolStripMenuItem.Name = "downToolStripMenuItem";
            this.downToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.downToolStripMenuItem.Text = "Down";
            this.downToolStripMenuItem.Click += new System.EventHandler(this.downToolStripMenuItem_Click);
            // 
            // labelPartInfo
            // 
            this.labelPartInfo.AutoSize = true;
            this.labelPartInfo.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelPartInfo.Location = new System.Drawing.Point(483, 432);
            this.labelPartInfo.Name = "labelPartInfo";
            this.labelPartInfo.Size = new System.Drawing.Size(67, 13);
            this.labelPartInfo.TabIndex = 33;
            this.labelPartInfo.Text = "Part info:";
            // 
            // textBoxPartInfo
            // 
            this.textBoxPartInfo.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxPartInfo.Location = new System.Drawing.Point(486, 448);
            this.textBoxPartInfo.Multiline = true;
            this.textBoxPartInfo.Name = "textBoxPartInfo";
            this.textBoxPartInfo.ReadOnly = true;
            this.textBoxPartInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxPartInfo.Size = new System.Drawing.Size(460, 250);
            this.textBoxPartInfo.TabIndex = 32;
            this.textBoxPartInfo.WordWrap = false;
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Font = new System.Drawing.Font("Consolas", 8F);
            this.numericUpDownFontSize.Location = new System.Drawing.Point(1142, 425);
            this.numericUpDownFontSize.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownFontSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(130, 20);
            this.numericUpDownFontSize.TabIndex = 36;
            this.numericUpDownFontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownFontSize.ValueChanged += new System.EventHandler(this.numericUpDownFontSize_ValueChanged);
            // 
            // labelFontSize
            // 
            this.labelFontSize.AutoSize = true;
            this.labelFontSize.Location = new System.Drawing.Point(1084, 429);
            this.labelFontSize.Name = "labelFontSize";
            this.labelFontSize.Size = new System.Drawing.Size(52, 13);
            this.labelFontSize.TabIndex = 37;
            this.labelFontSize.Text = "Font size:";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxLog.Location = new System.Drawing.Point(962, 454);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(310, 244);
            this.textBoxLog.TabIndex = 41;
            this.textBoxLog.WordWrap = false;
            // 
            // textBoxNewPartLengths
            // 
            this.textBoxNewPartLengths.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewPartLengths.Location = new System.Drawing.Point(6, 135);
            this.textBoxNewPartLengths.Multiline = true;
            this.textBoxNewPartLengths.Name = "textBoxNewPartLengths";
            this.textBoxNewPartLengths.Size = new System.Drawing.Size(306, 60);
            this.textBoxNewPartLengths.TabIndex = 42;
            // 
            // labelNewPartLengths
            // 
            this.labelNewPartLengths.AutoSize = true;
            this.labelNewPartLengths.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPartLengths.Location = new System.Drawing.Point(5, 119);
            this.labelNewPartLengths.Name = "labelNewPartLengths";
            this.labelNewPartLengths.Size = new System.Drawing.Size(163, 13);
            this.labelNewPartLengths.TabIndex = 43;
            this.labelNewPartLengths.Text = "Lengths (separate with ;):";
            // 
            // numericUpDownNewPartSeries
            // 
            this.numericUpDownNewPartSeries.Font = new System.Drawing.Font("Consolas", 8F);
            this.numericUpDownNewPartSeries.Location = new System.Drawing.Point(111, 70);
            this.numericUpDownNewPartSeries.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownNewPartSeries.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNewPartSeries.Name = "numericUpDownNewPartSeries";
            this.numericUpDownNewPartSeries.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownNewPartSeries.TabIndex = 45;
            this.numericUpDownNewPartSeries.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownNewPartSeries.ValueChanged += new System.EventHandler(this.numericUpDownNewPartSeries_ValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Films";
            this.openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            // 
            // groupBoxNewPart
            // 
            this.groupBoxNewPart.Controls.Add(this.buttonNewPartCommonLengthToAll);
            this.groupBoxNewPart.Controls.Add(this.labelNewPartCOW);
            this.groupBoxNewPart.Controls.Add(this.textBoxNewPartCOW);
            this.groupBoxNewPart.Controls.Add(this.labelNewPart1);
            this.groupBoxNewPart.Controls.Add(this.buttonNewPartSave);
            this.groupBoxNewPart.Controls.Add(this.textBoxNewPartName);
            this.groupBoxNewPart.Controls.Add(this.numericUpDownNewPartSeries);
            this.groupBoxNewPart.Controls.Add(this.labelNewPartSeries);
            this.groupBoxNewPart.Controls.Add(this.labelNewPartLengths);
            this.groupBoxNewPart.Controls.Add(this.textBoxNewPartLengths);
            this.groupBoxNewPart.Controls.Add(this.labelNewPart4);
            this.groupBoxNewPart.Controls.Add(this.textBoxNewPartPath);
            this.groupBoxNewPart.Controls.Add(this.checkBoxNewPartIsPathFile);
            this.groupBoxNewPart.Controls.Add(this.labelNewPart5);
            this.groupBoxNewPart.Controls.Add(this.textBoxNewPartLength);
            this.groupBoxNewPart.Font = new System.Drawing.Font("Consolas", 8F);
            this.groupBoxNewPart.Location = new System.Drawing.Point(952, 10);
            this.groupBoxNewPart.Name = "groupBoxNewPart";
            this.groupBoxNewPart.Size = new System.Drawing.Size(320, 380);
            this.groupBoxNewPart.TabIndex = 48;
            this.groupBoxNewPart.TabStop = false;
            this.groupBoxNewPart.Text = "Edit part";
            this.groupBoxNewPart.Visible = false;
            // 
            // buttonNewPartCommonLengthToAll
            // 
            this.buttonNewPartCommonLengthToAll.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonNewPartCommonLengthToAll.Location = new System.Drawing.Point(214, 93);
            this.buttonNewPartCommonLengthToAll.Name = "buttonNewPartCommonLengthToAll";
            this.buttonNewPartCommonLengthToAll.Size = new System.Drawing.Size(100, 23);
            this.buttonNewPartCommonLengthToAll.TabIndex = 49;
            this.buttonNewPartCommonLengthToAll.Text = "Common to all";
            this.buttonNewPartCommonLengthToAll.UseVisualStyleBackColor = true;
            this.buttonNewPartCommonLengthToAll.Click += new System.EventHandler(this.buttonNewPartCommonLengthToAll_Click);
            // 
            // labelNewPartCOW
            // 
            this.labelNewPartCOW.AutoSize = true;
            this.labelNewPartCOW.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPartCOW.Location = new System.Drawing.Point(8, 198);
            this.labelNewPartCOW.Name = "labelNewPartCOW";
            this.labelNewPartCOW.Size = new System.Drawing.Size(205, 13);
            this.labelNewPartCOW.TabIndex = 48;
            this.labelNewPartCOW.Text = "Count of watch (separate with ;):";
            // 
            // textBoxNewPartCOW
            // 
            this.textBoxNewPartCOW.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewPartCOW.Location = new System.Drawing.Point(6, 214);
            this.textBoxNewPartCOW.Multiline = true;
            this.textBoxNewPartCOW.Name = "textBoxNewPartCOW";
            this.textBoxNewPartCOW.Size = new System.Drawing.Size(306, 80);
            this.textBoxNewPartCOW.TabIndex = 47;
            // 
            // groupBoxNewFranchise
            // 
            this.groupBoxNewFranchise.Controls.Add(this.buttonNewFranchiseToday);
            this.groupBoxNewFranchise.Controls.Add(this.labelNewFranchiseDate);
            this.groupBoxNewFranchise.Controls.Add(this.textBoxNewFranchiseDate);
            this.groupBoxNewFranchise.Controls.Add(this.labelNewFranchise1);
            this.groupBoxNewFranchise.Controls.Add(this.buttonNewFranchiseSave);
            this.groupBoxNewFranchise.Controls.Add(this.textBoxNewFranchiseNames);
            this.groupBoxNewFranchise.Controls.Add(this.labelNewFranchise2);
            this.groupBoxNewFranchise.Controls.Add(this.comboBoxNewFranchiseType);
            this.groupBoxNewFranchise.Controls.Add(this.labelNewFranchise3);
            this.groupBoxNewFranchise.Controls.Add(this.textBoxNewFranchisePath);
            this.groupBoxNewFranchise.Font = new System.Drawing.Font("Consolas", 8F);
            this.groupBoxNewFranchise.Location = new System.Drawing.Point(952, 12);
            this.groupBoxNewFranchise.Name = "groupBoxNewFranchise";
            this.groupBoxNewFranchise.Size = new System.Drawing.Size(320, 380);
            this.groupBoxNewFranchise.TabIndex = 49;
            this.groupBoxNewFranchise.TabStop = false;
            this.groupBoxNewFranchise.Text = "Edit franchise";
            this.groupBoxNewFranchise.Visible = false;
            // 
            // buttonNewFranchiseToday
            // 
            this.buttonNewFranchiseToday.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonNewFranchiseToday.Location = new System.Drawing.Point(182, 149);
            this.buttonNewFranchiseToday.Name = "buttonNewFranchiseToday";
            this.buttonNewFranchiseToday.Size = new System.Drawing.Size(130, 23);
            this.buttonNewFranchiseToday.TabIndex = 16;
            this.buttonNewFranchiseToday.Text = "Today";
            this.buttonNewFranchiseToday.UseVisualStyleBackColor = true;
            this.buttonNewFranchiseToday.Click += new System.EventHandler(this.buttonNewFranchiseToday_Click);
            // 
            // labelNewFranchiseDate
            // 
            this.labelNewFranchiseDate.AutoSize = true;
            this.labelNewFranchiseDate.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewFranchiseDate.Location = new System.Drawing.Point(5, 133);
            this.labelNewFranchiseDate.Name = "labelNewFranchiseDate";
            this.labelNewFranchiseDate.Size = new System.Drawing.Size(37, 13);
            this.labelNewFranchiseDate.TabIndex = 14;
            this.labelNewFranchiseDate.Text = "Date:";
            // 
            // textBoxNewFranchiseDate
            // 
            this.textBoxNewFranchiseDate.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewFranchiseDate.Location = new System.Drawing.Point(6, 149);
            this.textBoxNewFranchiseDate.Name = "textBoxNewFranchiseDate";
            this.textBoxNewFranchiseDate.Size = new System.Drawing.Size(171, 20);
            this.textBoxNewFranchiseDate.TabIndex = 15;
            // 
            // buttonSort
            // 
            this.buttonSort.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonSort.Location = new System.Drawing.Point(1172, 396);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(100, 23);
            this.buttonSort.TabIndex = 50;
            this.buttonSort.Text = "Sort";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // groupBoxSort
            // 
            this.groupBoxSort.Controls.Add(this.comboBoxSortColorBy);
            this.groupBoxSort.Controls.Add(this.labelSortColorBy);
            this.groupBoxSort.Controls.Add(this.checkedListBoxSortTypesPersentage);
            this.groupBoxSort.Controls.Add(this.checkedListBoxSortTypesDown);
            this.groupBoxSort.Controls.Add(this.checkBoxSortReverse);
            this.groupBoxSort.Controls.Add(this.comboBoxSortSortBy);
            this.groupBoxSort.Controls.Add(this.labelSortSortBy);
            this.groupBoxSort.Controls.Add(this.checkedListBoxSortTypesGenre);
            this.groupBoxSort.Controls.Add(this.labelSortTypes);
            this.groupBoxSort.Controls.Add(this.buttonSortSave);
            this.groupBoxSort.Font = new System.Drawing.Font("Consolas", 8F);
            this.groupBoxSort.Location = new System.Drawing.Point(952, 11);
            this.groupBoxSort.Name = "groupBoxSort";
            this.groupBoxSort.Size = new System.Drawing.Size(320, 380);
            this.groupBoxSort.TabIndex = 51;
            this.groupBoxSort.TabStop = false;
            this.groupBoxSort.Text = "Sort";
            this.groupBoxSort.Visible = false;
            // 
            // comboBoxSortColorBy
            // 
            this.comboBoxSortColorBy.FormattingEnabled = true;
            this.comboBoxSortColorBy.Items.AddRange(new object[] {
            "None",
            "Persentage (3)",
            "Persentage (Gradient)"});
            this.comboBoxSortColorBy.Location = new System.Drawing.Point(142, 102);
            this.comboBoxSortColorBy.Name = "comboBoxSortColorBy";
            this.comboBoxSortColorBy.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSortColorBy.TabIndex = 24;
            this.comboBoxSortColorBy.Text = "Persentage (Gradient)";
            this.comboBoxSortColorBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxSortColorBy_SelectedIndexChanged);
            // 
            // labelSortColorBy
            // 
            this.labelSortColorBy.AutoSize = true;
            this.labelSortColorBy.Location = new System.Drawing.Point(139, 83);
            this.labelSortColorBy.Name = "labelSortColorBy";
            this.labelSortColorBy.Size = new System.Drawing.Size(61, 13);
            this.labelSortColorBy.TabIndex = 23;
            this.labelSortColorBy.Text = "Color by:";
            // 
            // checkedListBoxSortTypesPersentage
            // 
            this.checkedListBoxSortTypesPersentage.CheckOnClick = true;
            this.checkedListBoxSortTypesPersentage.FormattingEnabled = true;
            this.checkedListBoxSortTypesPersentage.Items.AddRange(new object[] {
            "0%",
            "1%-99%",
            "100%"});
            this.checkedListBoxSortTypesPersentage.Location = new System.Drawing.Point(6, 170);
            this.checkedListBoxSortTypesPersentage.Name = "checkedListBoxSortTypesPersentage";
            this.checkedListBoxSortTypesPersentage.Size = new System.Drawing.Size(120, 64);
            this.checkedListBoxSortTypesPersentage.TabIndex = 22;
            // 
            // checkedListBoxSortTypesDown
            // 
            this.checkedListBoxSortTypesDown.CheckOnClick = true;
            this.checkedListBoxSortTypesDown.FormattingEnabled = true;
            this.checkedListBoxSortTypesDown.Items.AddRange(new object[] {
            "Downloaded",
            "Not downloaded"});
            this.checkedListBoxSortTypesDown.Location = new System.Drawing.Point(6, 115);
            this.checkedListBoxSortTypesDown.Name = "checkedListBoxSortTypesDown";
            this.checkedListBoxSortTypesDown.Size = new System.Drawing.Size(120, 49);
            this.checkedListBoxSortTypesDown.TabIndex = 21;
            // 
            // checkBoxSortReverse
            // 
            this.checkBoxSortReverse.AutoSize = true;
            this.checkBoxSortReverse.Location = new System.Drawing.Point(142, 63);
            this.checkBoxSortReverse.Name = "checkBoxSortReverse";
            this.checkBoxSortReverse.Size = new System.Drawing.Size(68, 17);
            this.checkBoxSortReverse.TabIndex = 19;
            this.checkBoxSortReverse.Text = "Reverse";
            this.checkBoxSortReverse.UseVisualStyleBackColor = true;
            this.checkBoxSortReverse.CheckedChanged += new System.EventHandler(this.checkBoxSortReverse_CheckedChanged);
            // 
            // comboBoxSortSortBy
            // 
            this.comboBoxSortSortBy.FormattingEnabled = true;
            this.comboBoxSortSortBy.Items.AddRange(new object[] {
            "None",
            "Name",
            "Size",
            "Length",
            "Persentage (0-100)",
            "Persentage (99-0, 100)",
            "BPS",
            "Date",
            "Mark"});
            this.comboBoxSortSortBy.Location = new System.Drawing.Point(142, 33);
            this.comboBoxSortSortBy.Name = "comboBoxSortSortBy";
            this.comboBoxSortSortBy.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSortSortBy.TabIndex = 18;
            this.comboBoxSortSortBy.Text = "Persentage (99-0, 100)";
            this.comboBoxSortSortBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxSortSortBy_SelectedIndexChanged);
            // 
            // labelSortSortBy
            // 
            this.labelSortSortBy.AutoSize = true;
            this.labelSortSortBy.Location = new System.Drawing.Point(139, 14);
            this.labelSortSortBy.Name = "labelSortSortBy";
            this.labelSortSortBy.Size = new System.Drawing.Size(55, 13);
            this.labelSortSortBy.TabIndex = 17;
            this.labelSortSortBy.Text = "Sort by:";
            // 
            // checkedListBoxSortTypesGenre
            // 
            this.checkedListBoxSortTypesGenre.CheckOnClick = true;
            this.checkedListBoxSortTypesGenre.FormattingEnabled = true;
            this.checkedListBoxSortTypesGenre.Items.AddRange(new object[] {
            "Anime",
            "Cartoon",
            "Film",
            "Dorama"});
            this.checkedListBoxSortTypesGenre.Location = new System.Drawing.Point(6, 30);
            this.checkedListBoxSortTypesGenre.Name = "checkedListBoxSortTypesGenre";
            this.checkedListBoxSortTypesGenre.Size = new System.Drawing.Size(120, 79);
            this.checkedListBoxSortTypesGenre.TabIndex = 16;
            // 
            // labelSortTypes
            // 
            this.labelSortTypes.AutoSize = true;
            this.labelSortTypes.Location = new System.Drawing.Point(7, 14);
            this.labelSortTypes.Name = "labelSortTypes";
            this.labelSortTypes.Size = new System.Drawing.Size(43, 13);
            this.labelSortTypes.TabIndex = 15;
            this.labelSortTypes.Text = "Types:";
            // 
            // buttonSortSave
            // 
            this.buttonSortSave.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonSortSave.Location = new System.Drawing.Point(184, 350);
            this.buttonSortSave.Name = "buttonSortSave";
            this.buttonSortSave.Size = new System.Drawing.Size(130, 23);
            this.buttonSortSave.TabIndex = 14;
            this.buttonSortSave.Text = "Save";
            this.buttonSortSave.UseVisualStyleBackColor = true;
            this.buttonSortSave.Click += new System.EventHandler(this.buttonSortSave_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1280, 24);
            this.menuStrip1.TabIndex = 53;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.findAllSizeToolStripMenuItem,
            this.backUpToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // findAllSizeToolStripMenuItem
            // 
            this.findAllSizeToolStripMenuItem.Name = "findAllSizeToolStripMenuItem";
            this.findAllSizeToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.findAllSizeToolStripMenuItem.Text = "Find all size";
            this.findAllSizeToolStripMenuItem.Click += new System.EventHandler(this.findAllSizeToolStripMenuItem_Click);
            // 
            // backUpToolStripMenuItem
            // 
            this.backUpToolStripMenuItem.Name = "backUpToolStripMenuItem";
            this.backUpToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.backUpToolStripMenuItem.Text = "BackUp";
            this.backUpToolStripMenuItem.Click += new System.EventHandler(this.backUpToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // labelNewPartSeries
            // 
            this.labelNewPartSeries.AutoSize = true;
            this.labelNewPartSeries.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPartSeries.Location = new System.Drawing.Point(7, 72);
            this.labelNewPartSeries.Name = "labelNewPartSeries";
            this.labelNewPartSeries.Size = new System.Drawing.Size(49, 13);
            this.labelNewPartSeries.TabIndex = 44;
            this.labelNewPartSeries.Text = "Series:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 710);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBoxSort);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.groupBoxNewFranchise);
            this.Controls.Add(this.groupBoxNewPart);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.labelFontSize);
            this.Controls.Add(this.numericUpDownFontSize);
            this.Controls.Add(this.labelPartInfo);
            this.Controls.Add(this.textBoxPartInfo);
            this.Controls.Add(this.labelParts);
            this.Controls.Add(this.listViewParts);
            this.Controls.Add(this.buttonNewPart);
            this.Controls.Add(this.buttonNewFranchise);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelTitleInfo);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.textBoxTitleInfo);
            this.Controls.Add(this.labelTitles);
            this.Controls.Add(this.listViewTitles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Dax_Donamo Media Watched";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStripTitle.ResumeLayout(false);
            this.contextMenuStripPart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewPartSeries)).EndInit();
            this.groupBoxNewPart.ResumeLayout(false);
            this.groupBoxNewPart.PerformLayout();
            this.groupBoxNewFranchise.ResumeLayout(false);
            this.groupBoxNewFranchise.PerformLayout();
            this.groupBoxSort.ResumeLayout(false);
            this.groupBoxSort.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewTitles;
        private System.Windows.Forms.Label labelTitles;
        private System.Windows.Forms.TextBox textBoxTitleInfo;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Label labelTitleInfo;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button buttonNewFranchise;
        private System.Windows.Forms.Button buttonNewFranchiseSave;
        private System.Windows.Forms.Label labelNewFranchise1;
        private System.Windows.Forms.TextBox textBoxNewFranchiseNames;
        private System.Windows.Forms.Label labelNewFranchise2;
        private System.Windows.Forms.ComboBox comboBoxNewFranchiseType;
        private System.Windows.Forms.TextBox textBoxNewFranchisePath;
        private System.Windows.Forms.Label labelNewFranchise3;
        private System.Windows.Forms.Button buttonNewPart;
        private System.Windows.Forms.Button buttonNewPartSave;
        private System.Windows.Forms.TextBox textBoxNewPartName;
        private System.Windows.Forms.Label labelNewPart1;
        private System.Windows.Forms.TextBox textBoxNewPartPath;
        private System.Windows.Forms.Label labelNewPart4;
        private System.Windows.Forms.CheckBox checkBoxNewPartIsPathFile;
        private System.Windows.Forms.TextBox textBoxNewPartLength;
        private System.Windows.Forms.Label labelNewPart5;
        private System.Windows.Forms.Label labelParts;
        private System.Windows.Forms.ListView listViewParts;
        private System.Windows.Forms.Label labelPartInfo;
        private System.Windows.Forms.TextBox textBoxPartInfo;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.Label labelFontSize;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TextBox textBoxNewPartLengths;
        private System.Windows.Forms.Label labelNewPartLengths;
        private System.Windows.Forms.NumericUpDown numericUpDownNewPartSeries;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBoxNewPart;
        private System.Windows.Forms.GroupBox groupBoxNewFranchise;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.GroupBox groupBoxSort;
        private System.Windows.Forms.Button buttonSortSave;
        private System.Windows.Forms.CheckedListBox checkedListBoxSortTypesGenre;
        private System.Windows.Forms.Label labelSortTypes;
        private System.Windows.Forms.Label labelNewPartCOW;
        private System.Windows.Forms.TextBox textBoxNewPartCOW;
        private System.Windows.Forms.Label labelNewFranchiseDate;
        private System.Windows.Forms.TextBox textBoxNewFranchiseDate;
        private System.Windows.Forms.CheckBox checkBoxSortReverse;
        private System.Windows.Forms.ComboBox comboBoxSortSortBy;
        private System.Windows.Forms.Label labelSortSortBy;
        private System.Windows.Forms.Button buttonNewFranchiseToday;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPart;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFullViewToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTitle;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addFullWatchToolStripMenuItem;
        private System.Windows.Forms.Button buttonNewPartCommonLengthToAll;
        private System.Windows.Forms.CheckedListBox checkedListBoxSortTypesPersentage;
        private System.Windows.Forms.CheckedListBox checkedListBoxSortTypesDown;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findAllSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findSizeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ComboBox comboBoxSortColorBy;
        private System.Windows.Forms.Label labelSortColorBy;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downToolStripMenuItem;
        private System.Windows.Forms.Label labelNewPartSeries;
    }
}

