
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
            this.textBoxNewPartWidth = new System.Windows.Forms.TextBox();
            this.labelNewPart2 = new System.Windows.Forms.Label();
            this.labelNewPart3 = new System.Windows.Forms.Label();
            this.textBoxNewPartHeight = new System.Windows.Forms.TextBox();
            this.textBoxNewPartPath = new System.Windows.Forms.TextBox();
            this.labelNewPart4 = new System.Windows.Forms.Label();
            this.checkBoxNewPartIsPathFile = new System.Windows.Forms.CheckBox();
            this.textBoxNewPartLength = new System.Windows.Forms.TextBox();
            this.labelNewPart5 = new System.Windows.Forms.Label();
            this.buttonEditFranchise = new System.Windows.Forms.Button();
            this.labelParts = new System.Windows.Forms.Label();
            this.listViewParts = new System.Windows.Forms.ListView();
            this.buttonEditPart = new System.Windows.Forms.Button();
            this.labelPartInfo = new System.Windows.Forms.Label();
            this.textBoxPartInfo = new System.Windows.Forms.TextBox();
            this.buttonFindPartSize = new System.Windows.Forms.Button();
            this.buttonDeletePart = new System.Windows.Forms.Button();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.labelFontSize = new System.Windows.Forms.Label();
            this.buttonDeleteFranchise = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonFindAllSize = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.textBoxNewPartLengths = new System.Windows.Forms.TextBox();
            this.labelNewPartLengths = new System.Windows.Forms.Label();
            this.labelNewPartSeries = new System.Windows.Forms.Label();
            this.numericUpDownNewPartSeries = new System.Windows.Forms.NumericUpDown();
            this.comboBoxNewPartResolutions = new System.Windows.Forms.ComboBox();
            this.buttonImport = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxNewPart = new System.Windows.Forms.GroupBox();
            this.labelNewPartCOW = new System.Windows.Forms.Label();
            this.textBoxNewPartCOW = new System.Windows.Forms.TextBox();
            this.groupBoxNewFranchise = new System.Windows.Forms.GroupBox();
            this.buttonNewFranchiseToday = new System.Windows.Forms.Button();
            this.labelNewFranchiseDate = new System.Windows.Forms.Label();
            this.textBoxNewFranchiseDate = new System.Windows.Forms.TextBox();
            this.buttonSort = new System.Windows.Forms.Button();
            this.groupBoxSort = new System.Windows.Forms.GroupBox();
            this.checkBoxSortReverse = new System.Windows.Forms.CheckBox();
            this.comboBoxSortSortBy = new System.Windows.Forms.ComboBox();
            this.labelSortSortBy = new System.Windows.Forms.Label();
            this.checkedListBoxSortTypes = new System.Windows.Forms.CheckedListBox();
            this.labelSortTypes = new System.Windows.Forms.Label();
            this.buttonSortSave = new System.Windows.Forms.Button();
            this.buttonBackUP = new System.Windows.Forms.Button();
            this.contextMenuStripPart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFullViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripTitle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addFullWatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewPartSeries)).BeginInit();
            this.groupBoxNewPart.SuspendLayout();
            this.groupBoxNewFranchise.SuspendLayout();
            this.groupBoxSort.SuspendLayout();
            this.contextMenuStripPart.SuspendLayout();
            this.contextMenuStripTitle.SuspendLayout();
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
            this.listViewTitles.Size = new System.Drawing.Size(410, 315);
            this.listViewTitles.TabIndex = 0;
            this.listViewTitles.UseCompatibleStateImageBehavior = false;
            this.listViewTitles.View = System.Windows.Forms.View.Details;
            this.listViewTitles.SelectedIndexChanged += new System.EventHandler(this.listViewTitles_SelectedIndexChanged);
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
            this.textBoxTitleInfo.Location = new System.Drawing.Point(12, 362);
            this.textBoxTitleInfo.Multiline = true;
            this.textBoxTitleInfo.Name = "textBoxTitleInfo";
            this.textBoxTitleInfo.ReadOnly = true;
            this.textBoxTitleInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTitleInfo.Size = new System.Drawing.Size(410, 336);
            this.textBoxTitleInfo.TabIndex = 2;
            this.textBoxTitleInfo.WordWrap = false;
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxInfo.Location = new System.Drawing.Point(858, 25);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ReadOnly = true;
            this.textBoxInfo.Size = new System.Drawing.Size(410, 336);
            this.textBoxInfo.TabIndex = 3;
            // 
            // labelTitleInfo
            // 
            this.labelTitleInfo.AutoSize = true;
            this.labelTitleInfo.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelTitleInfo.Location = new System.Drawing.Point(9, 346);
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
            this.buttonNewFranchise.Location = new System.Drawing.Point(858, 367);
            this.buttonNewFranchise.Name = "buttonNewFranchise";
            this.buttonNewFranchise.Size = new System.Drawing.Size(130, 23);
            this.buttonNewFranchise.TabIndex = 6;
            this.buttonNewFranchise.Text = "New franchise";
            this.buttonNewFranchise.UseVisualStyleBackColor = true;
            this.buttonNewFranchise.Click += new System.EventHandler(this.buttonNewFranchise_Click);
            // 
            // buttonNewFranchiseSave
            // 
            this.buttonNewFranchiseSave.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonNewFranchiseSave.Location = new System.Drawing.Point(290, 327);
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
            this.textBoxNewFranchiseNames.Size = new System.Drawing.Size(410, 20);
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
            this.textBoxNewFranchisePath.Size = new System.Drawing.Size(410, 20);
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
            this.buttonNewPart.Location = new System.Drawing.Point(858, 396);
            this.buttonNewPart.Name = "buttonNewPart";
            this.buttonNewPart.Size = new System.Drawing.Size(130, 23);
            this.buttonNewPart.TabIndex = 14;
            this.buttonNewPart.Text = "New part";
            this.buttonNewPart.UseVisualStyleBackColor = true;
            this.buttonNewPart.Click += new System.EventHandler(this.buttonNewPart_Click);
            // 
            // buttonNewPartSave
            // 
            this.buttonNewPartSave.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonNewPartSave.Location = new System.Drawing.Point(287, 327);
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
            this.textBoxNewPartName.Size = new System.Drawing.Size(367, 20);
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
            // textBoxNewPartWidth
            // 
            this.textBoxNewPartWidth.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewPartWidth.Location = new System.Drawing.Point(103, 45);
            this.textBoxNewPartWidth.Name = "textBoxNewPartWidth";
            this.textBoxNewPartWidth.Size = new System.Drawing.Size(80, 20);
            this.textBoxNewPartWidth.TabIndex = 19;
            // 
            // labelNewPart2
            // 
            this.labelNewPart2.AutoSize = true;
            this.labelNewPart2.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPart2.Location = new System.Drawing.Point(7, 49);
            this.labelNewPart2.Name = "labelNewPart2";
            this.labelNewPart2.Size = new System.Drawing.Size(73, 13);
            this.labelNewPart2.TabIndex = 18;
            this.labelNewPart2.Text = "Resolution:";
            // 
            // labelNewPart3
            // 
            this.labelNewPart3.AutoSize = true;
            this.labelNewPart3.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPart3.Location = new System.Drawing.Point(191, 48);
            this.labelNewPart3.Name = "labelNewPart3";
            this.labelNewPart3.Size = new System.Drawing.Size(13, 13);
            this.labelNewPart3.TabIndex = 20;
            this.labelNewPart3.Text = "X";
            // 
            // textBoxNewPartHeight
            // 
            this.textBoxNewPartHeight.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewPartHeight.Location = new System.Drawing.Point(210, 46);
            this.textBoxNewPartHeight.Name = "textBoxNewPartHeight";
            this.textBoxNewPartHeight.Size = new System.Drawing.Size(80, 20);
            this.textBoxNewPartHeight.TabIndex = 21;
            // 
            // textBoxNewPartPath
            // 
            this.textBoxNewPartPath.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewPartPath.Location = new System.Drawing.Point(50, 74);
            this.textBoxNewPartPath.Name = "textBoxNewPartPath";
            this.textBoxNewPartPath.Size = new System.Drawing.Size(367, 20);
            this.textBoxNewPartPath.TabIndex = 23;
            this.textBoxNewPartPath.TextChanged += new System.EventHandler(this.textBoxNewPartPath_TextChanged);
            // 
            // labelNewPart4
            // 
            this.labelNewPart4.AutoSize = true;
            this.labelNewPart4.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPart4.Location = new System.Drawing.Point(6, 78);
            this.labelNewPart4.Name = "labelNewPart4";
            this.labelNewPart4.Size = new System.Drawing.Size(37, 13);
            this.labelNewPart4.TabIndex = 22;
            this.labelNewPart4.Text = "Path:";
            // 
            // checkBoxNewPartIsPathFile
            // 
            this.checkBoxNewPartIsPathFile.AutoSize = true;
            this.checkBoxNewPartIsPathFile.Font = new System.Drawing.Font("Consolas", 8F);
            this.checkBoxNewPartIsPathFile.Location = new System.Drawing.Point(320, 100);
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
            this.textBoxNewPartLength.Location = new System.Drawing.Point(109, 100);
            this.textBoxNewPartLength.Name = "textBoxNewPartLength";
            this.textBoxNewPartLength.Size = new System.Drawing.Size(205, 20);
            this.textBoxNewPartLength.TabIndex = 27;
            this.textBoxNewPartLength.TextChanged += new System.EventHandler(this.textBoxNewPartLength_TextChanged);
            // 
            // labelNewPart5
            // 
            this.labelNewPart5.AutoSize = true;
            this.labelNewPart5.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPart5.Location = new System.Drawing.Point(6, 104);
            this.labelNewPart5.Name = "labelNewPart5";
            this.labelNewPart5.Size = new System.Drawing.Size(97, 13);
            this.labelNewPart5.TabIndex = 26;
            this.labelNewPart5.Text = "Average length:";
            // 
            // buttonEditFranchise
            // 
            this.buttonEditFranchise.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonEditFranchise.Location = new System.Drawing.Point(994, 367);
            this.buttonEditFranchise.Name = "buttonEditFranchise";
            this.buttonEditFranchise.Size = new System.Drawing.Size(130, 23);
            this.buttonEditFranchise.TabIndex = 28;
            this.buttonEditFranchise.Text = "Edit franchise";
            this.buttonEditFranchise.UseVisualStyleBackColor = true;
            this.buttonEditFranchise.Click += new System.EventHandler(this.buttonEditFranchise_Click);
            // 
            // labelParts
            // 
            this.labelParts.AutoSize = true;
            this.labelParts.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelParts.Location = new System.Drawing.Point(436, 9);
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
            this.listViewParts.Location = new System.Drawing.Point(436, 25);
            this.listViewParts.MultiSelect = false;
            this.listViewParts.Name = "listViewParts";
            this.listViewParts.Size = new System.Drawing.Size(410, 315);
            this.listViewParts.TabIndex = 29;
            this.listViewParts.UseCompatibleStateImageBehavior = false;
            this.listViewParts.View = System.Windows.Forms.View.Details;
            this.listViewParts.SelectedIndexChanged += new System.EventHandler(this.listViewParts_SelectedIndexChanged);
            // 
            // buttonEditPart
            // 
            this.buttonEditPart.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonEditPart.Location = new System.Drawing.Point(994, 396);
            this.buttonEditPart.Name = "buttonEditPart";
            this.buttonEditPart.Size = new System.Drawing.Size(130, 23);
            this.buttonEditPart.TabIndex = 31;
            this.buttonEditPart.Text = "Edit part";
            this.buttonEditPart.UseVisualStyleBackColor = true;
            this.buttonEditPart.Click += new System.EventHandler(this.buttonEditPart_Click);
            // 
            // labelPartInfo
            // 
            this.labelPartInfo.AutoSize = true;
            this.labelPartInfo.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelPartInfo.Location = new System.Drawing.Point(433, 346);
            this.labelPartInfo.Name = "labelPartInfo";
            this.labelPartInfo.Size = new System.Drawing.Size(67, 13);
            this.labelPartInfo.TabIndex = 33;
            this.labelPartInfo.Text = "Part info:";
            // 
            // textBoxPartInfo
            // 
            this.textBoxPartInfo.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxPartInfo.Location = new System.Drawing.Point(436, 362);
            this.textBoxPartInfo.Multiline = true;
            this.textBoxPartInfo.Name = "textBoxPartInfo";
            this.textBoxPartInfo.ReadOnly = true;
            this.textBoxPartInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxPartInfo.Size = new System.Drawing.Size(410, 336);
            this.textBoxPartInfo.TabIndex = 32;
            this.textBoxPartInfo.WordWrap = false;
            // 
            // buttonFindPartSize
            // 
            this.buttonFindPartSize.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonFindPartSize.Location = new System.Drawing.Point(858, 425);
            this.buttonFindPartSize.Name = "buttonFindPartSize";
            this.buttonFindPartSize.Size = new System.Drawing.Size(130, 23);
            this.buttonFindPartSize.TabIndex = 34;
            this.buttonFindPartSize.Text = "Find part size";
            this.buttonFindPartSize.UseVisualStyleBackColor = true;
            this.buttonFindPartSize.Click += new System.EventHandler(this.buttonFindPartSize_Click);
            // 
            // buttonDeletePart
            // 
            this.buttonDeletePart.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonDeletePart.Location = new System.Drawing.Point(1130, 396);
            this.buttonDeletePart.Name = "buttonDeletePart";
            this.buttonDeletePart.Size = new System.Drawing.Size(130, 23);
            this.buttonDeletePart.TabIndex = 35;
            this.buttonDeletePart.Text = "Delete part";
            this.buttonDeletePart.UseVisualStyleBackColor = true;
            this.buttonDeletePart.Click += new System.EventHandler(this.buttonDeletePart_Click);
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Font = new System.Drawing.Font("Consolas", 8F);
            this.numericUpDownFontSize.Location = new System.Drawing.Point(917, 454);
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
            this.numericUpDownFontSize.Size = new System.Drawing.Size(120, 20);
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
            this.labelFontSize.Location = new System.Drawing.Point(859, 458);
            this.labelFontSize.Name = "labelFontSize";
            this.labelFontSize.Size = new System.Drawing.Size(52, 13);
            this.labelFontSize.TabIndex = 37;
            this.labelFontSize.Text = "Font size:";
            // 
            // buttonDeleteFranchise
            // 
            this.buttonDeleteFranchise.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonDeleteFranchise.Location = new System.Drawing.Point(1130, 367);
            this.buttonDeleteFranchise.Name = "buttonDeleteFranchise";
            this.buttonDeleteFranchise.Size = new System.Drawing.Size(130, 23);
            this.buttonDeleteFranchise.TabIndex = 38;
            this.buttonDeleteFranchise.Text = "Delete franchise";
            this.buttonDeleteFranchise.UseVisualStyleBackColor = true;
            this.buttonDeleteFranchise.Click += new System.EventHandler(this.buttonDeleteFranchise_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonSave.Location = new System.Drawing.Point(862, 675);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(130, 23);
            this.buttonSave.TabIndex = 39;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonFindAllSize
            // 
            this.buttonFindAllSize.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonFindAllSize.Location = new System.Drawing.Point(994, 425);
            this.buttonFindAllSize.Name = "buttonFindAllSize";
            this.buttonFindAllSize.Size = new System.Drawing.Size(130, 23);
            this.buttonFindAllSize.TabIndex = 40;
            this.buttonFindAllSize.Text = "Find all size";
            this.buttonFindAllSize.UseVisualStyleBackColor = true;
            this.buttonFindAllSize.Click += new System.EventHandler(this.buttonFindAllSize_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxLog.Location = new System.Drawing.Point(862, 480);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLog.Size = new System.Drawing.Size(410, 189);
            this.textBoxLog.TabIndex = 41;
            this.textBoxLog.WordWrap = false;
            // 
            // textBoxNewPartLengths
            // 
            this.textBoxNewPartLengths.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewPartLengths.Location = new System.Drawing.Point(8, 164);
            this.textBoxNewPartLengths.Multiline = true;
            this.textBoxNewPartLengths.Name = "textBoxNewPartLengths";
            this.textBoxNewPartLengths.Size = new System.Drawing.Size(410, 60);
            this.textBoxNewPartLengths.TabIndex = 42;
            // 
            // labelNewPartLengths
            // 
            this.labelNewPartLengths.AutoSize = true;
            this.labelNewPartLengths.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPartLengths.Location = new System.Drawing.Point(7, 148);
            this.labelNewPartLengths.Name = "labelNewPartLengths";
            this.labelNewPartLengths.Size = new System.Drawing.Size(163, 13);
            this.labelNewPartLengths.TabIndex = 43;
            this.labelNewPartLengths.Text = "Lengths (separate with ;):";
            // 
            // labelNewPartSeries
            // 
            this.labelNewPartSeries.AutoSize = true;
            this.labelNewPartSeries.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPartSeries.Location = new System.Drawing.Point(5, 127);
            this.labelNewPartSeries.Name = "labelNewPartSeries";
            this.labelNewPartSeries.Size = new System.Drawing.Size(49, 13);
            this.labelNewPartSeries.TabIndex = 44;
            this.labelNewPartSeries.Text = "Series:";
            // 
            // numericUpDownNewPartSeries
            // 
            this.numericUpDownNewPartSeries.Font = new System.Drawing.Font("Consolas", 8F);
            this.numericUpDownNewPartSeries.Location = new System.Drawing.Point(109, 125);
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
            this.numericUpDownNewPartSeries.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownNewPartSeries.TabIndex = 45;
            this.numericUpDownNewPartSeries.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownNewPartSeries.ValueChanged += new System.EventHandler(this.numericUpDownNewPartSeries_ValueChanged);
            // 
            // comboBoxNewPartResolutions
            // 
            this.comboBoxNewPartResolutions.FormattingEnabled = true;
            this.comboBoxNewPartResolutions.Items.AddRange(new object[] {
            "NULL",
            "960x720",
            "1280x720",
            "1920x1080",
            "3840x2160"});
            this.comboBoxNewPartResolutions.Location = new System.Drawing.Point(296, 45);
            this.comboBoxNewPartResolutions.Name = "comboBoxNewPartResolutions";
            this.comboBoxNewPartResolutions.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNewPartResolutions.TabIndex = 46;
            this.comboBoxNewPartResolutions.SelectedIndexChanged += new System.EventHandler(this.comboBoxNewPartResolutions_SelectedIndexChanged);
            // 
            // buttonImport
            // 
            this.buttonImport.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonImport.Location = new System.Drawing.Point(1130, 425);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(130, 23);
            this.buttonImport.TabIndex = 47;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Films";
            this.openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            // 
            // groupBoxNewPart
            // 
            this.groupBoxNewPart.Controls.Add(this.labelNewPartCOW);
            this.groupBoxNewPart.Controls.Add(this.textBoxNewPartCOW);
            this.groupBoxNewPart.Controls.Add(this.labelNewPart1);
            this.groupBoxNewPart.Controls.Add(this.buttonNewPartSave);
            this.groupBoxNewPart.Controls.Add(this.comboBoxNewPartResolutions);
            this.groupBoxNewPart.Controls.Add(this.textBoxNewPartName);
            this.groupBoxNewPart.Controls.Add(this.numericUpDownNewPartSeries);
            this.groupBoxNewPart.Controls.Add(this.labelNewPart2);
            this.groupBoxNewPart.Controls.Add(this.labelNewPartSeries);
            this.groupBoxNewPart.Controls.Add(this.textBoxNewPartWidth);
            this.groupBoxNewPart.Controls.Add(this.labelNewPartLengths);
            this.groupBoxNewPart.Controls.Add(this.labelNewPart3);
            this.groupBoxNewPart.Controls.Add(this.textBoxNewPartLengths);
            this.groupBoxNewPart.Controls.Add(this.textBoxNewPartHeight);
            this.groupBoxNewPart.Controls.Add(this.labelNewPart4);
            this.groupBoxNewPart.Controls.Add(this.textBoxNewPartPath);
            this.groupBoxNewPart.Controls.Add(this.checkBoxNewPartIsPathFile);
            this.groupBoxNewPart.Controls.Add(this.labelNewPart5);
            this.groupBoxNewPart.Controls.Add(this.textBoxNewPartLength);
            this.groupBoxNewPart.Font = new System.Drawing.Font("Consolas", 8F);
            this.groupBoxNewPart.Location = new System.Drawing.Point(852, 10);
            this.groupBoxNewPart.Name = "groupBoxNewPart";
            this.groupBoxNewPart.Size = new System.Drawing.Size(420, 352);
            this.groupBoxNewPart.TabIndex = 48;
            this.groupBoxNewPart.TabStop = false;
            this.groupBoxNewPart.Text = "Edit part";
            this.groupBoxNewPart.Visible = false;
            // 
            // labelNewPartCOW
            // 
            this.labelNewPartCOW.AutoSize = true;
            this.labelNewPartCOW.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPartCOW.Location = new System.Drawing.Point(10, 227);
            this.labelNewPartCOW.Name = "labelNewPartCOW";
            this.labelNewPartCOW.Size = new System.Drawing.Size(205, 13);
            this.labelNewPartCOW.TabIndex = 48;
            this.labelNewPartCOW.Text = "Count of watch (separate with ;):";
            // 
            // textBoxNewPartCOW
            // 
            this.textBoxNewPartCOW.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewPartCOW.Location = new System.Drawing.Point(8, 243);
            this.textBoxNewPartCOW.Multiline = true;
            this.textBoxNewPartCOW.Name = "textBoxNewPartCOW";
            this.textBoxNewPartCOW.Size = new System.Drawing.Size(410, 80);
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
            this.groupBoxNewFranchise.Location = new System.Drawing.Point(852, 12);
            this.groupBoxNewFranchise.Name = "groupBoxNewFranchise";
            this.groupBoxNewFranchise.Size = new System.Drawing.Size(420, 352);
            this.groupBoxNewFranchise.TabIndex = 49;
            this.groupBoxNewFranchise.TabStop = false;
            this.groupBoxNewFranchise.Text = "Edit franchise";
            this.groupBoxNewFranchise.Visible = false;
            // 
            // buttonNewFranchiseToday
            // 
            this.buttonNewFranchiseToday.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonNewFranchiseToday.Location = new System.Drawing.Point(290, 147);
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
            this.textBoxNewFranchiseDate.Size = new System.Drawing.Size(278, 20);
            this.textBoxNewFranchiseDate.TabIndex = 15;
            // 
            // buttonSort
            // 
            this.buttonSort.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonSort.Location = new System.Drawing.Point(1130, 454);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(130, 23);
            this.buttonSort.TabIndex = 50;
            this.buttonSort.Text = "Sort";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // groupBoxSort
            // 
            this.groupBoxSort.Controls.Add(this.checkBoxSortReverse);
            this.groupBoxSort.Controls.Add(this.comboBoxSortSortBy);
            this.groupBoxSort.Controls.Add(this.labelSortSortBy);
            this.groupBoxSort.Controls.Add(this.checkedListBoxSortTypes);
            this.groupBoxSort.Controls.Add(this.labelSortTypes);
            this.groupBoxSort.Controls.Add(this.buttonSortSave);
            this.groupBoxSort.Font = new System.Drawing.Font("Consolas", 8F);
            this.groupBoxSort.Location = new System.Drawing.Point(852, 11);
            this.groupBoxSort.Name = "groupBoxSort";
            this.groupBoxSort.Size = new System.Drawing.Size(420, 352);
            this.groupBoxSort.TabIndex = 51;
            this.groupBoxSort.TabStop = false;
            this.groupBoxSort.Text = "Sort";
            this.groupBoxSort.Visible = false;
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
            "Number",
            "Name",
            "Size",
            "Length",
            "BPS",
            "Date",
            "Mark"});
            this.comboBoxSortSortBy.Location = new System.Drawing.Point(142, 33);
            this.comboBoxSortSortBy.Name = "comboBoxSortSortBy";
            this.comboBoxSortSortBy.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSortSortBy.TabIndex = 18;
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
            // checkedListBoxSortTypes
            // 
            this.checkedListBoxSortTypes.CheckOnClick = true;
            this.checkedListBoxSortTypes.FormattingEnabled = true;
            this.checkedListBoxSortTypes.Items.AddRange(new object[] {
            "Anime",
            "Cartoon",
            "Film",
            "Dorama"});
            this.checkedListBoxSortTypes.Location = new System.Drawing.Point(6, 30);
            this.checkedListBoxSortTypes.Name = "checkedListBoxSortTypes";
            this.checkedListBoxSortTypes.Size = new System.Drawing.Size(120, 94);
            this.checkedListBoxSortTypes.TabIndex = 16;
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
            this.buttonSortSave.Location = new System.Drawing.Point(284, 318);
            this.buttonSortSave.Name = "buttonSortSave";
            this.buttonSortSave.Size = new System.Drawing.Size(130, 23);
            this.buttonSortSave.TabIndex = 14;
            this.buttonSortSave.Text = "Save";
            this.buttonSortSave.UseVisualStyleBackColor = true;
            this.buttonSortSave.Click += new System.EventHandler(this.buttonSortSave_Click);
            // 
            // buttonBackUP
            // 
            this.buttonBackUP.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonBackUP.Location = new System.Drawing.Point(1138, 675);
            this.buttonBackUP.Name = "buttonBackUP";
            this.buttonBackUP.Size = new System.Drawing.Size(130, 23);
            this.buttonBackUP.TabIndex = 52;
            this.buttonBackUP.Text = "BackUP";
            this.buttonBackUP.UseVisualStyleBackColor = true;
            this.buttonBackUP.Click += new System.EventHandler(this.buttonBackUP_Click);
            // 
            // contextMenuStripPart
            // 
            this.contextMenuStripPart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.addFullViewToolStripMenuItem});
            this.contextMenuStripPart.Name = "contextMenuStripPart";
            this.contextMenuStripPart.Size = new System.Drawing.Size(144, 48);
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
            // contextMenuStripTitle
            // 
            this.contextMenuStripTitle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem1,
            this.addFullWatchToolStripMenuItem});
            this.contextMenuStripTitle.Name = "contextMenuStripTitle";
            this.contextMenuStripTitle.Size = new System.Drawing.Size(144, 48);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 710);
            this.Controls.Add(this.buttonBackUP);
            this.Controls.Add(this.groupBoxSort);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.groupBoxNewFranchise);
            this.Controls.Add(this.groupBoxNewPart);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonFindAllSize);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDeleteFranchise);
            this.Controls.Add(this.labelFontSize);
            this.Controls.Add(this.numericUpDownFontSize);
            this.Controls.Add(this.buttonDeletePart);
            this.Controls.Add(this.buttonFindPartSize);
            this.Controls.Add(this.labelPartInfo);
            this.Controls.Add(this.textBoxPartInfo);
            this.Controls.Add(this.buttonEditPart);
            this.Controls.Add(this.labelParts);
            this.Controls.Add(this.listViewParts);
            this.Controls.Add(this.buttonEditFranchise);
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
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Dax_Donamo Media Watched";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNewPartSeries)).EndInit();
            this.groupBoxNewPart.ResumeLayout(false);
            this.groupBoxNewPart.PerformLayout();
            this.groupBoxNewFranchise.ResumeLayout(false);
            this.groupBoxNewFranchise.PerformLayout();
            this.groupBoxSort.ResumeLayout(false);
            this.groupBoxSort.PerformLayout();
            this.contextMenuStripPart.ResumeLayout(false);
            this.contextMenuStripTitle.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox textBoxNewPartWidth;
        private System.Windows.Forms.Label labelNewPart2;
        private System.Windows.Forms.Label labelNewPart3;
        private System.Windows.Forms.TextBox textBoxNewPartHeight;
        private System.Windows.Forms.TextBox textBoxNewPartPath;
        private System.Windows.Forms.Label labelNewPart4;
        private System.Windows.Forms.CheckBox checkBoxNewPartIsPathFile;
        private System.Windows.Forms.TextBox textBoxNewPartLength;
        private System.Windows.Forms.Label labelNewPart5;
        private System.Windows.Forms.Button buttonEditFranchise;
        private System.Windows.Forms.Label labelParts;
        private System.Windows.Forms.ListView listViewParts;
        private System.Windows.Forms.Button buttonEditPart;
        private System.Windows.Forms.Label labelPartInfo;
        private System.Windows.Forms.TextBox textBoxPartInfo;
        private System.Windows.Forms.Button buttonFindPartSize;
        private System.Windows.Forms.Button buttonDeletePart;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.Label labelFontSize;
        private System.Windows.Forms.Button buttonDeleteFranchise;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonFindAllSize;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TextBox textBoxNewPartLengths;
        private System.Windows.Forms.Label labelNewPartLengths;
        private System.Windows.Forms.Label labelNewPartSeries;
        private System.Windows.Forms.NumericUpDown numericUpDownNewPartSeries;
        private System.Windows.Forms.ComboBox comboBoxNewPartResolutions;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBoxNewPart;
        private System.Windows.Forms.GroupBox groupBoxNewFranchise;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.GroupBox groupBoxSort;
        private System.Windows.Forms.Button buttonSortSave;
        private System.Windows.Forms.CheckedListBox checkedListBoxSortTypes;
        private System.Windows.Forms.Label labelSortTypes;
        private System.Windows.Forms.Label labelNewPartCOW;
        private System.Windows.Forms.TextBox textBoxNewPartCOW;
        private System.Windows.Forms.Label labelNewFranchiseDate;
        private System.Windows.Forms.TextBox textBoxNewFranchiseDate;
        private System.Windows.Forms.CheckBox checkBoxSortReverse;
        private System.Windows.Forms.ComboBox comboBoxSortSortBy;
        private System.Windows.Forms.Label labelSortSortBy;
        private System.Windows.Forms.Button buttonNewFranchiseToday;
        private System.Windows.Forms.Button buttonBackUP;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPart;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFullViewToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTitle;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addFullWatchToolStripMenuItem;
    }
}

