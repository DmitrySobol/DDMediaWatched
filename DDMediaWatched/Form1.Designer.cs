
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
            this.buttonSaveExit = new System.Windows.Forms.Button();
            this.buttonFindAllSize = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewTitles
            // 
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
            this.textBoxTitleInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTitleInfo.Size = new System.Drawing.Size(410, 336);
            this.textBoxTitleInfo.TabIndex = 2;
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxInfo.Location = new System.Drawing.Point(858, 25);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
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
            this.buttonNewFranchiseSave.Location = new System.Drawing.Point(1138, 338);
            this.buttonNewFranchiseSave.Name = "buttonNewFranchiseSave";
            this.buttonNewFranchiseSave.Size = new System.Drawing.Size(130, 23);
            this.buttonNewFranchiseSave.TabIndex = 7;
            this.buttonNewFranchiseSave.Text = "Save";
            this.buttonNewFranchiseSave.UseVisualStyleBackColor = true;
            this.buttonNewFranchiseSave.Visible = false;
            this.buttonNewFranchiseSave.Click += new System.EventHandler(this.buttonNewFranchiseSave_Click);
            // 
            // labelNewFranchise1
            // 
            this.labelNewFranchise1.AutoSize = true;
            this.labelNewFranchise1.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewFranchise1.Location = new System.Drawing.Point(857, 9);
            this.labelNewFranchise1.Name = "labelNewFranchise1";
            this.labelNewFranchise1.Size = new System.Drawing.Size(151, 13);
            this.labelNewFranchise1.TabIndex = 8;
            this.labelNewFranchise1.Text = "Names (separate with ;):";
            this.labelNewFranchise1.Visible = false;
            // 
            // textBoxNewFranchiseNames
            // 
            this.textBoxNewFranchiseNames.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewFranchiseNames.Location = new System.Drawing.Point(858, 25);
            this.textBoxNewFranchiseNames.Name = "textBoxNewFranchiseNames";
            this.textBoxNewFranchiseNames.Size = new System.Drawing.Size(410, 20);
            this.textBoxNewFranchiseNames.TabIndex = 9;
            this.textBoxNewFranchiseNames.Visible = false;
            // 
            // labelNewFranchise2
            // 
            this.labelNewFranchise2.AutoSize = true;
            this.labelNewFranchise2.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewFranchise2.Location = new System.Drawing.Point(857, 48);
            this.labelNewFranchise2.Name = "labelNewFranchise2";
            this.labelNewFranchise2.Size = new System.Drawing.Size(37, 13);
            this.labelNewFranchise2.TabIndex = 10;
            this.labelNewFranchise2.Text = "Type:";
            this.labelNewFranchise2.Visible = false;
            // 
            // comboBoxNewFranchiseType
            // 
            this.comboBoxNewFranchiseType.Font = new System.Drawing.Font("Consolas", 8F);
            this.comboBoxNewFranchiseType.FormattingEnabled = true;
            this.comboBoxNewFranchiseType.Items.AddRange(new object[] {
            "Anime",
            "Cartoon",
            "Fillm"});
            this.comboBoxNewFranchiseType.Location = new System.Drawing.Point(858, 64);
            this.comboBoxNewFranchiseType.Name = "comboBoxNewFranchiseType";
            this.comboBoxNewFranchiseType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNewFranchiseType.TabIndex = 11;
            this.comboBoxNewFranchiseType.Visible = false;
            // 
            // textBoxNewFranchisePath
            // 
            this.textBoxNewFranchisePath.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewFranchisePath.Location = new System.Drawing.Point(858, 104);
            this.textBoxNewFranchisePath.Name = "textBoxNewFranchisePath";
            this.textBoxNewFranchisePath.Size = new System.Drawing.Size(410, 20);
            this.textBoxNewFranchisePath.TabIndex = 13;
            this.textBoxNewFranchisePath.Visible = false;
            // 
            // labelNewFranchise3
            // 
            this.labelNewFranchise3.AutoSize = true;
            this.labelNewFranchise3.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewFranchise3.Location = new System.Drawing.Point(857, 88);
            this.labelNewFranchise3.Name = "labelNewFranchise3";
            this.labelNewFranchise3.Size = new System.Drawing.Size(37, 13);
            this.labelNewFranchise3.TabIndex = 12;
            this.labelNewFranchise3.Text = "Path:";
            this.labelNewFranchise3.Visible = false;
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
            this.buttonNewPartSave.Location = new System.Drawing.Point(1138, 338);
            this.buttonNewPartSave.Name = "buttonNewPartSave";
            this.buttonNewPartSave.Size = new System.Drawing.Size(130, 23);
            this.buttonNewPartSave.TabIndex = 15;
            this.buttonNewPartSave.Text = "Save";
            this.buttonNewPartSave.UseVisualStyleBackColor = true;
            this.buttonNewPartSave.Visible = false;
            this.buttonNewPartSave.Click += new System.EventHandler(this.buttonNewPartSave_Click);
            // 
            // textBoxNewPartName
            // 
            this.textBoxNewPartName.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewPartName.Location = new System.Drawing.Point(858, 25);
            this.textBoxNewPartName.Name = "textBoxNewPartName";
            this.textBoxNewPartName.Size = new System.Drawing.Size(410, 20);
            this.textBoxNewPartName.TabIndex = 17;
            this.textBoxNewPartName.Visible = false;
            // 
            // labelNewPart1
            // 
            this.labelNewPart1.AutoSize = true;
            this.labelNewPart1.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPart1.Location = new System.Drawing.Point(857, 9);
            this.labelNewPart1.Name = "labelNewPart1";
            this.labelNewPart1.Size = new System.Drawing.Size(37, 13);
            this.labelNewPart1.TabIndex = 16;
            this.labelNewPart1.Text = "Name:";
            this.labelNewPart1.Visible = false;
            // 
            // textBoxNewPartWidth
            // 
            this.textBoxNewPartWidth.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewPartWidth.Location = new System.Drawing.Point(858, 64);
            this.textBoxNewPartWidth.Name = "textBoxNewPartWidth";
            this.textBoxNewPartWidth.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewPartWidth.TabIndex = 19;
            this.textBoxNewPartWidth.Visible = false;
            // 
            // labelNewPart2
            // 
            this.labelNewPart2.AutoSize = true;
            this.labelNewPart2.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPart2.Location = new System.Drawing.Point(857, 48);
            this.labelNewPart2.Name = "labelNewPart2";
            this.labelNewPart2.Size = new System.Drawing.Size(73, 13);
            this.labelNewPart2.TabIndex = 18;
            this.labelNewPart2.Text = "Resolution:";
            this.labelNewPart2.Visible = false;
            // 
            // labelNewPart3
            // 
            this.labelNewPart3.AutoSize = true;
            this.labelNewPart3.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPart3.Location = new System.Drawing.Point(964, 67);
            this.labelNewPart3.Name = "labelNewPart3";
            this.labelNewPart3.Size = new System.Drawing.Size(13, 13);
            this.labelNewPart3.TabIndex = 20;
            this.labelNewPart3.Text = "X";
            this.labelNewPart3.Visible = false;
            // 
            // textBoxNewPartHeight
            // 
            this.textBoxNewPartHeight.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewPartHeight.Location = new System.Drawing.Point(985, 65);
            this.textBoxNewPartHeight.Name = "textBoxNewPartHeight";
            this.textBoxNewPartHeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxNewPartHeight.TabIndex = 21;
            this.textBoxNewPartHeight.Visible = false;
            // 
            // textBoxNewPartPath
            // 
            this.textBoxNewPartPath.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewPartPath.Location = new System.Drawing.Point(858, 104);
            this.textBoxNewPartPath.Name = "textBoxNewPartPath";
            this.textBoxNewPartPath.Size = new System.Drawing.Size(410, 20);
            this.textBoxNewPartPath.TabIndex = 23;
            this.textBoxNewPartPath.Visible = false;
            // 
            // labelNewPart4
            // 
            this.labelNewPart4.AutoSize = true;
            this.labelNewPart4.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPart4.Location = new System.Drawing.Point(857, 88);
            this.labelNewPart4.Name = "labelNewPart4";
            this.labelNewPart4.Size = new System.Drawing.Size(37, 13);
            this.labelNewPart4.TabIndex = 22;
            this.labelNewPart4.Text = "Path:";
            this.labelNewPart4.Visible = false;
            // 
            // checkBoxNewPartIsPathFile
            // 
            this.checkBoxNewPartIsPathFile.AutoSize = true;
            this.checkBoxNewPartIsPathFile.Font = new System.Drawing.Font("Consolas", 8F);
            this.checkBoxNewPartIsPathFile.Location = new System.Drawing.Point(860, 130);
            this.checkBoxNewPartIsPathFile.Name = "checkBoxNewPartIsPathFile";
            this.checkBoxNewPartIsPathFile.Size = new System.Drawing.Size(98, 17);
            this.checkBoxNewPartIsPathFile.TabIndex = 25;
            this.checkBoxNewPartIsPathFile.Text = "Is path file";
            this.checkBoxNewPartIsPathFile.UseVisualStyleBackColor = true;
            this.checkBoxNewPartIsPathFile.Visible = false;
            // 
            // textBoxNewPartLength
            // 
            this.textBoxNewPartLength.Font = new System.Drawing.Font("Consolas", 8F);
            this.textBoxNewPartLength.Location = new System.Drawing.Point(858, 166);
            this.textBoxNewPartLength.Name = "textBoxNewPartLength";
            this.textBoxNewPartLength.Size = new System.Drawing.Size(410, 20);
            this.textBoxNewPartLength.TabIndex = 27;
            this.textBoxNewPartLength.Visible = false;
            // 
            // labelNewPart5
            // 
            this.labelNewPart5.AutoSize = true;
            this.labelNewPart5.Font = new System.Drawing.Font("Consolas", 8F);
            this.labelNewPart5.Location = new System.Drawing.Point(857, 150);
            this.labelNewPart5.Name = "labelNewPart5";
            this.labelNewPart5.Size = new System.Drawing.Size(211, 13);
            this.labelNewPart5.TabIndex = 26;
            this.labelNewPart5.Text = "Average legth of series (seconds):";
            this.labelNewPart5.Visible = false;
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
            this.textBoxPartInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPartInfo.Size = new System.Drawing.Size(410, 336);
            this.textBoxPartInfo.TabIndex = 32;
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
            // buttonSaveExit
            // 
            this.buttonSaveExit.Font = new System.Drawing.Font("Consolas", 8F);
            this.buttonSaveExit.Location = new System.Drawing.Point(862, 675);
            this.buttonSaveExit.Name = "buttonSaveExit";
            this.buttonSaveExit.Size = new System.Drawing.Size(130, 23);
            this.buttonSaveExit.TabIndex = 39;
            this.buttonSaveExit.Text = "Save + Exit";
            this.buttonSaveExit.UseVisualStyleBackColor = true;
            this.buttonSaveExit.Click += new System.EventHandler(this.buttonSaveExit_Click);
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
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(410, 189);
            this.textBoxLog.TabIndex = 41;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 710);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonFindAllSize);
            this.Controls.Add(this.buttonSaveExit);
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
            this.Controls.Add(this.textBoxNewPartLength);
            this.Controls.Add(this.labelNewPart5);
            this.Controls.Add(this.checkBoxNewPartIsPathFile);
            this.Controls.Add(this.textBoxNewPartPath);
            this.Controls.Add(this.labelNewPart4);
            this.Controls.Add(this.textBoxNewPartHeight);
            this.Controls.Add(this.labelNewPart3);
            this.Controls.Add(this.textBoxNewPartWidth);
            this.Controls.Add(this.labelNewPart2);
            this.Controls.Add(this.textBoxNewPartName);
            this.Controls.Add(this.labelNewPart1);
            this.Controls.Add(this.buttonNewPartSave);
            this.Controls.Add(this.buttonNewPart);
            this.Controls.Add(this.textBoxNewFranchisePath);
            this.Controls.Add(this.labelNewFranchise3);
            this.Controls.Add(this.comboBoxNewFranchiseType);
            this.Controls.Add(this.labelNewFranchise2);
            this.Controls.Add(this.textBoxNewFranchiseNames);
            this.Controls.Add(this.labelNewFranchise1);
            this.Controls.Add(this.buttonNewFranchiseSave);
            this.Controls.Add(this.buttonNewFranchise);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelTitleInfo);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.textBoxTitleInfo);
            this.Controls.Add(this.labelTitles);
            this.Controls.Add(this.listViewTitles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Dax_Donamo Media Watched";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
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
        private System.Windows.Forms.Button buttonSaveExit;
        private System.Windows.Forms.Button buttonFindAllSize;
        private System.Windows.Forms.TextBox textBoxLog;
    }
}

