using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DDMediaWatched
{
    public partial class Form1 : Form
    {
        private static Franchise
            currentFranchise;

        private static Part
            currentPart;

        private readonly List<Control>
            controlsNewFranchise = new List<Control>(),
            controlsInfo = new List<Control>(),
            controlsNewPart = new List<Control>(),
            controlsRightButtons = new List<Control>(),
            controlsSort = new List<Control>(),
            controlsListViews = new List<Control>();

        private static bool
            isEdited = false;

        private readonly List<NumericUpDown>
            PanelEditPartCOW = new List<NumericUpDown>();

        private readonly List<TextBox>
            PanelEditPartLengths = new List<TextBox>();

        private readonly string[]
            DefaultPath = new string[5] { @"Anime\", @"Video\Cartoons\", @"Video\Films\", @"Video\Doramas\", @"" };

        private enum MenuState {Start, Parts, EditFranchise, EditPart, SortMenu };

        private MenuState
            menu = MenuState.Start;

        public Form1()
        {
            InitializeComponent();
            ResizeControls(1280, 710);
            Program.Log = this.Log;
            InitializePanelsEditPart();
            StaticUtils.LoadConfigs();
            checkedListBoxSortTypesForWhom.Items.AddRange(StaticUtils.GetForWhomNames());
            comboBoxEditFranchiseForWhom.Items.AddRange(StaticUtils.GetForWhomNames());
            CheckCheckedListBoxes();
            SaveSortConfigs();
            LoadColumnsFranchises();
            LoadColumnsParts();
            StaticUtils.FindMediaDrivePath();
            LoadControls();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Franchise.LoadMedia();
            this.Location = new Point(225, 150);
            FranchisesToListView();
            DrawStatistic();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F5:
                    {
                        FranchisesToListView();
                        StaticUtils.FindMediaDrivePath();
                        DrawStatistic();
                    }
                    break;
                case Keys.Escape:
                    {
                        switch (menu)
                        {
                            case MenuState.Start:
                                {
                                    AppClose();
                                }
                                break;
                            case MenuState.Parts:
                                {
                                    FranchisesToListView();
                                }
                                break;
                            case MenuState.EditFranchise:
                                {
                                    CloseEditFranchise();
                                }
                                break;
                            case MenuState.EditPart:
                                {
                                    CloseEditPart();
                                }
                                break;
                            case MenuState.SortMenu:
                                {
                                    CloseSortMenu();
                                }
                                break;
                        }
                    }
                    break;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeControls(this.ClientSize.Width, this.ClientSize.Height);
        }

        private void ResizeControls(int width, int height)
        {
            panelFranchises.Location = new Point(0, 25);
            panelFranchises.Size = new Size(375 * width / 1000, height - 25);
            panelParts.Location = new Point(375 * width / 1000 + 1, 25);
            panelParts.Size = new Size(375 * width / 1000, height - 25);
            panelRigth.Location = new Point(750 * width / 1000 + 2, 25);
            panelRigth.Size = new Size(250 * width / 1000, height - 25);
        }

        private void InitializePanelsEditPart()
        {
            this.panelEditPartCOW.AutoScroll = false;
            this.panelEditPartCOW.HorizontalScroll.Enabled = false;
            this.panelEditPartCOW.HorizontalScroll.Visible = false;
            this.panelEditPartCOW.HorizontalScroll.Maximum = 0;
            this.panelEditPartCOW.AutoScroll = true;
            this.panelEditPartLengths.AutoScroll = false;
            this.panelEditPartLengths.HorizontalScroll.Enabled = false;
            this.panelEditPartLengths.HorizontalScroll.Visible = false;
            this.panelEditPartLengths.HorizontalScroll.Maximum = 0;
            this.panelEditPartLengths.AutoScroll = true;
        }
        //Edit Franchise
        private void ButtonNewFranchise_Click(object sender, EventArgs e)
        {
            ControlsDisable(controlsRightButtons);
            ControlsDisable(controlsListViews);
            currentFranchise = new Franchise();
            Franchise.AddFranchise(currentFranchise);
            EditFranchise();
        }

        private void ButtonEditFranchiseSave_Click(object sender, EventArgs e)
        {
            isEdited = true;
            //Check name
            if (!EditFranchiseCheckSameNames())
            {
                MessageBox.Show("There is alredy exist franchise with this name!", "Error");
                return;
            }
            //UpdateFields
            string names = textBoxEditFranchiseNames.Text.Replace(" / ", ";");
            currentFranchise.SetNames(names.Split(';'));
            currentFranchise.SetType(comboBoxEditFranchiseType.SelectedIndex);
            currentFranchise.Mark = (int)numericUpDownEditFranchiseMark.Value;
            currentFranchise.Path = textBoxEditFranchisePath.Text;
            currentFranchise.SetStartingDate(textBoxEditFranchiseDate.Text);
            currentFranchise.URL = textBoxEditFranchiseURL.Text;
            currentFranchise.ForWhom = comboBoxEditFranchiseForWhom.SelectedIndex;
            //Conclusion
            currentFranchise.FindSize();
            CloseEditFranchise();
        }

        private void CloseEditFranchise()
        {
            ControlsOffVisible(controlsNewFranchise);
            ControlsOnVisible(controlsInfo);
            FranchisesToListView();
            ControlsEnable(controlsRightButtons);
            ControlsEnable(controlsListViews);
        }

        private bool EditFranchiseCheckSameNames()
        {
            string name = textBoxEditFranchiseNames.Text.Split(';')[0];
            int countOfFranchiseWithSameName = Franchise.GetFranchiseCountWithName(name);
            if (currentFranchise.GetName() == name)
                countOfFranchiseWithSameName--;
            if (countOfFranchiseWithSameName > 0)
                return false;
            return true;
        }

        private void EditFranchise()
        {
            menu = MenuState.EditFranchise;
            ControlsOffVisible(controlsInfo);
            ControlsOnVisible(controlsNewFranchise);
            textBoxEditFranchiseNames.Text = currentFranchise.GetAllNames();
            comboBoxEditFranchiseType.SelectedIndex = currentFranchise.GetFranchiseTypeInt();
            numericUpDownEditFranchiseMark.Value = currentFranchise.Mark;
            textBoxEditFranchisePath.Text = currentFranchise.Path;
            textBoxEditFranchiseDate.Text = currentFranchise.GetStartingDate().ToString("yyyy.MM.dd");
            textBoxEditFranchiseURL.Text = currentFranchise.URL;
            comboBoxEditFranchiseForWhom.SelectedIndex = currentFranchise.ForWhom;
        }

        private void ButtonEditFranchiseToday_Click(object sender, EventArgs e)
        {
            textBoxEditFranchiseDate.Text = DateTime.Now.ToString("yyyy.MM.dd");
        }

        private void ComboBoxEditFranchiseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EditFranchseIsPathDefault())
                switch (comboBoxEditFranchiseType.Text)
                {
                    case "Anime":
                        {
                            textBoxEditFranchisePath.Text = DefaultPath[0];
                        }
                        break;
                    case "Cartoon":
                        {
                            textBoxEditFranchisePath.Text = DefaultPath[1];
                        }
                        break;
                    case "Film":
                        {
                            textBoxEditFranchisePath.Text = DefaultPath[2];
                        }
                        break;
                    case "Dorama":
                        {
                            textBoxEditFranchisePath.Text = DefaultPath[3];
                        }
                        break;
                }
        }

        private bool EditFranchseIsPathDefault()
        {
            bool b = false;
            foreach (string s in DefaultPath)
                if (textBoxEditFranchisePath.Text == s)
                {
                    b = true;
                }
            return b;
        }
        //ContexFranchise
        private void DeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            isEdited = true;
            ControlsDisable(controlsRightButtons);
            if (currentFranchise != null)
                if (MessageBox.Show("Are you sure???", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Franchise.RemoveFranchise(currentFranchise.GetName());
                    FranchisesToListView();
                }
            ControlsEnable(controlsRightButtons);
        }

        private void AddFullWatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFranchise == null)
                return;
            isEdited = true;
            currentFranchise.AddWatch();
        }

        private void FindSizeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (currentFranchise == null)
                return;
            isEdited = true;
            currentFranchise.FindSize();
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewTitles.SelectedItems.Count > 0)
            {
                isEdited = true;
                ControlsDisable(controlsRightButtons);
                ControlsDisable(controlsListViews);
                listViewParts.Enabled = false;
                listViewTitles.Enabled = false;
                currentFranchise = Franchise.GetFranchise(listViewTitles.SelectedItems[0].Text);
                EditFranchise();
            }
        }
        //Edit Part
        private void ButtonNewPart_Click(object sender, EventArgs e)
        {
            if (currentFranchise == null)
                return;
            ControlsDisable(controlsRightButtons);
            ControlsDisable(controlsListViews);
            currentPart = new Part(currentFranchise);
            currentFranchise.AddPart(currentPart);
            EditPart();
        }

        private void ButtonEditPartSave_Click(object sender, EventArgs e)
        {
            isEdited = true;
            //Name
            if (!EditPartCheckSameNames())
            {
                MessageBox.Show("There is alredy exist part with this name!", "Error");
                return;
            }
            currentPart.Name = textBoxEditPartName.Text;
            //Path
            currentPart.Path = textBoxEditPartPath.Text;
            currentPart.SetIsPathFile(checkBoxEditPartIsPathFile.Checked);
            //Size
            currentPart.FindSize();
            //Lengths
            if (!MakeLengthsEditPart())
            {
                MessageBox.Show("Please, check lengths of series!", "Error");
                return;
            }
            //COW
            MakeCOWEditPart();
            //Length
            short length = StaticUtils.HMStoSecs(textBoxEditPartLength.Text);
            if (length != -1)
                currentPart.CommonLength = length;
            if (currentPart.IsFile())
            {
                if (length == -1)
                    return;
                currentPart.SetSeriesLengthToCommon();
            }
            //
            CloseEditPart();
        }

        private void CloseEditPart()
        {
            ControlsOffVisible(controlsNewPart);
            ControlsOnVisible(controlsInfo);
            PartsToListView();
            ControlsEnable(controlsRightButtons);
            ControlsEnable(controlsListViews);
        }

        private bool EditPartCheckSameNames()
        {
            string name = textBoxEditPartName.Text;
            int countOfPartWithSameName = currentFranchise.GetPartsCountWithName(name);
            if (currentPart.Name == textBoxEditPartName.Text)
                countOfPartWithSameName--;
            if (countOfPartWithSameName > 0)
                return false;
            return true;
        }

        private void EditPart()
        {
            menu = MenuState.EditPart;
            ControlsOffVisible(controlsInfo);
            ControlsOnVisible(controlsNewPart);
            textBoxEditPartName.Text = currentPart.Name;
            textBoxEditPartPath.Text = currentPart.Path;
            textBoxEditPartLength.Text = StaticUtils.SecsToHMS(currentPart.CommonLength);
            numericUpDownEditPartSeries.Value = currentPart.Series.Count();
            checkBoxEditPartIsPathFile.Checked = currentPart.IsFile();
            MakeEditPartLengths();
            MakeEditPartCOW();
        }

        private void NumericUpDownEditPartSeries_ValueChanged(object sender, EventArgs e)
        {
            int seriesCount = (int)numericUpDownEditPartSeries.Value;
            currentPart.SetSeriesCount(seriesCount);
            MakeEditPartCOW();
            if (!currentPart.IsFile())
                MakeEditPartLengths();
        }

        private void MakeEditPartLengths()
        {
            panelEditPartLengths.Controls.Clear();
            PanelEditPartLengths.Clear();
            int i = 0;
            foreach (Series s in currentPart.Series)
            {
                Label label = new Label()
                {
                    Location = new Point(0, i * 20),
                    Size = new Size(30, 20),
                    Text = String.Format("{0,3}", i + 1),
                    Font = new Font("Consolas", 8)
                };
                TextBox textBox = new TextBox()
                {
                    Location = new Point(30, i * 20),
                    Size = new Size(105, 20),
                    Font = new Font("Consolas", 8),
                    Text = StaticUtils.SecsToHMS(s.Length)
                };
                panelEditPartLengths.Controls.Add(label);
                panelEditPartLengths.Controls.Add(textBox);
                PanelEditPartLengths.Add(textBox);
                i++;
            }
        }

        private void MakeEditPartCOW()
        {
            panelEditPartCOW.Controls.Clear();
            PanelEditPartCOW.Clear();
            int i = 0;
            foreach (Series s in currentPart.Series)
            {
                Label label = new Label()
                {
                    Location = new Point(0, i * 20),
                    Size = new Size(30, 20),
                    Text = String.Format("{0,3}", i + 1),
                    Font = new Font("Consolas", 8)
                };
                NumericUpDown numericUpDown = new NumericUpDown()
                {
                    Location = new Point(30, i * 20),
                    Size = new Size(45, 20),
                    Font = new Font("Consolas", 8),
                    Minimum = 0,
                    Maximum = 32767,
                    Increment = 1,
                    Value = s.CountWatch
                };
                panelEditPartCOW.Controls.Add(label);
                panelEditPartCOW.Controls.Add(numericUpDown);
                PanelEditPartCOW.Add(numericUpDown);
                i++;
            }
        }

        private bool MakeLengthsEditPart()
        {
            bool isConvertionCorrect = true;
            short[] lengths = new short[currentPart.Series.Count];
            for (int i = 0; i < currentPart.Series.Count; i++)
            {
                lengths[i] = StaticUtils.HMStoSecs(PanelEditPartLengths[i].Text);
                if (lengths[i] == -1)
                    isConvertionCorrect = false;
            }
            if (isConvertionCorrect)
                for (int i = 0; i < currentPart.Series.Count; i++)
                    currentPart.Series[i].Length = lengths[i];
            else
                return false;
            return true;
        }

        private void MakeCOWEditPart()
        {
            for (int i = 0; i < currentPart.Series.Count; i++)
            {
                short cow = (short)PanelEditPartCOW[i].Value;
                currentPart.Series[i].CountWatch = cow;
            }
        }

        private void CheckBoxEditPartIsPathFile_CheckedChanged(object sender, EventArgs e)
        {
            currentPart.SetIsPathFile(checkBoxEditPartIsPathFile.Checked);
            if (checkBoxEditPartIsPathFile.Checked)
            {
                numericUpDownEditPartSeries.Value = 1;
                numericUpDownEditPartSeries.Enabled = false;
                panelEditPartLengths.Visible = false;
                currentPart.Path = textBoxEditPartPath.Text;
                if (File.Exists(currentPart.GetAbsolutePath()))
                    textBoxEditPartLength.Text = StaticUtils.GetVideoLength(currentPart.GetAbsolutePath());
            }
            else
            {
                numericUpDownEditPartSeries.Enabled = true;
                panelEditPartLengths.Visible = true;
            }
        }
        
        private void TextBoxEditPartPath_TextChanged(object sender, EventArgs e)
        {
            string path = textBoxEditPartPath.Text;
            if (path.Length > 2)
                if (path[0] == '"' && path[path.Length - 1] == '"')
                    path = path.Substring(1, path.Length - 2);
            int p = StaticUtils.IsFileOrDirr(path);
            if (p == 0)
                checkBoxEditPartIsPathFile.Checked = false;
            if (p == 1)
                checkBoxEditPartIsPathFile.Checked = true;
        }

        private void ButtonEditPartCommonLengthToAll_Click(object sender, EventArgs e)
        {
            short length = StaticUtils.HMStoSecs(textBoxEditPartLength.Text);
            if (length == -1)
            {
                MessageBox.Show("Please, check common length!", "Error");
                return;
            }
            currentPart.CommonLength = length;
            currentPart.SetSeriesLengthToCommon();
            MakeEditPartLengths();
        }
        //ContexParts
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isEdited = true;
            ControlsDisable(controlsRightButtons);
            if (currentPart != null)
                if (MessageBox.Show("Are you sure???", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    currentFranchise.RemovePart(currentPart);
                    PartsToListView();
                }
            ControlsEnable(controlsRightButtons);
        }

        private void AddFullViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentPart == null)
                return;
            isEdited = true;
            currentPart.AddWatch();
        }

        private void FindSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentPart == null)
                return;
            isEdited = true;
            currentPart.FindSize();
        }

        private void EditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listViewParts.SelectedItems.Count > 0)
            {
                isEdited = true;
                ControlsDisable(controlsRightButtons);
                ControlsDisable(controlsListViews);
                listViewParts.Enabled = false;
                listViewTitles.Enabled = false;
                EditPart();
            }
        }

        private void UpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isEdited = true;
            currentFranchise.PartUp(currentPart.Name);
            PartsToListView();
        }

        private void DownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isEdited = true;
            currentFranchise.PartDown(currentPart.Name);
            PartsToListView();
        }
        //ToolStripMenu
        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                isEdited = true;
                string[] s = File.ReadAllLines(openFileDialog1.FileName);
                foreach (string p in s)
                    Franchise.AddFranchise(new Franchise(p.Split('|')));
                FranchisesToListView();
            }
        }

        private void FindAllSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StaticUtils.IsMediaDriveExists())
            {
                isEdited = true;
                Franchise.FindAllSize();
                Log("All size has been updated!");
            }
            else
                MessageBox.Show("There isn't media volume!", "Error");
        }

        private void BackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string path = String.Format("{0}BackUP - {1}\\", Franchise.GetMediaPath(), dt.ToString("yyyy.MM.dd HH.mm.ss"));
            Directory.CreateDirectory(path);
            string[] files = Directory.GetFiles(Franchise.GetMediaPath());
            foreach (string file in files)
            {
                File.Copy(file, path + Path.GetFileName(file));
            }
            MessageBox.Show("BackUP has been created!", "Success");
        }

        private void ChoseMediaDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                StaticUtils.SetMediaDriveLetter(folderBrowserDialog1.SelectedPath.Substring(0, 2));
                DrawStatistic();
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Franchise.SaveMedia();
            MessageBox.Show("Media has been saved succesful!!!", "Saved!");
            isEdited = false;
        }

        private void OpenProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isEdited)
                if (MessageBox.Show("Do you wanna save changes?", "Save", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    Franchise.SaveMedia();
                    isEdited = false;
                }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Profile.SetPath(openFileDialog1.FileName);
                Profile.LoadFile();
                StaticUtils.SaveConfigs();
                DrawStatistic();
                FranchisesToListView();
            }
        }
        //ListViews
        private void ListViewTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTitles.SelectedItems.Count < 1)
            {
                currentFranchise = null;
                textBoxTitleInfo.Text = "Selected None!\r\n";
                currentPart = null;
                textBoxPartInfo.Text = "Selected None!\r\n";
            }
            else
            {
                currentFranchise = Franchise.GetFranchise(listViewTitles.SelectedItems[0].Text);
                textBoxTitleInfo.Text = currentFranchise.ToString();
            }
            PartsToListView();
        }

        private void ListViewTitles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (currentFranchise == null)
                return;
            if (currentFranchise.URL != "")
                System.Diagnostics.Process.Start(currentFranchise.URL);
        }

        private void ListViewParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewParts.SelectedItems.Count < 1)
            {
                currentPart = null;
                textBoxPartInfo.Text = "Selected None!\r\n";
            }
            else
            {
                currentPart = currentFranchise.GetPart(listViewParts.SelectedItems[0].Text);
                textBoxPartInfo.Text = currentPart.ToString();
            }
        }
        //Font size
        private void NumericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            listViewParts.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
            listViewTitles.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
            textBoxTitleInfo.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
            textBoxPartInfo.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
        }
        //Sort
        private void ButtonSort_Click(object sender, EventArgs e)
        {
            menu = MenuState.SortMenu;
            ControlsDisable(controlsRightButtons);

            ControlsOffVisible(controlsInfo);
            ControlsOnVisible(controlsSort);
        }

        private void ButtonSortSave_Click(object sender, EventArgs e)
        {
            SaveSortConfigs();
            CloseSortMenu();
        }

        private void CloseSortMenu()
        {
            ControlsOffVisible(controlsSort);
            ControlsOnVisible(controlsInfo);
            FranchisesToListView();
            DrawStatistic();
            ControlsEnable(controlsRightButtons);
        }

        private void CheckCheckedListBoxes()
        {
            for (int i = 0; i < checkedListBoxSortTypesGenre.Items.Count; i++)
                checkedListBoxSortTypesGenre.SetItemChecked(i, true);
            for (int i = 0; i < checkedListBoxSortTypesDown.Items.Count; i++)
                checkedListBoxSortTypesDown.SetItemChecked(i, true);
            for (int i = 0; i < checkedListBoxSortTypesPersentage.Items.Count; i++)
                checkedListBoxSortTypesPersentage.SetItemChecked(i, true);
            for (int i = 0; i < checkedListBoxSortTypesURL.Items.Count; i++)
                checkedListBoxSortTypesURL.SetItemChecked(i, true);
            for (int i = 0; i < checkedListBoxSortTypesNames.Items.Count; i++)
                checkedListBoxSortTypesNames.SetItemChecked(i, true);
            for (int i = 0; i < checkedListBoxSortTypesForWhom.Items.Count; i++)
                checkedListBoxSortTypesForWhom.SetItemChecked(i, true);
        }

        private void SaveSortConfigs()
        {
            Franchise.ClearFilters();
            //Genres
            foreach (int p in checkedListBoxSortTypesGenre.CheckedIndices)
                Franchise.AddFiltersType((Franchise.FranchiseType)p);
            //Downloaded
            foreach (int p in checkedListBoxSortTypesDown.CheckedIndices)
                Franchise.AddFiltersDown((Franchise.FranchiseDown)p);
            //Persentage
            foreach (int p in checkedListBoxSortTypesPersentage.CheckedIndices)
                Franchise.AddFiltersPersentage((Franchise.FranchisePersentage)p);
            //URL
            if (checkedListBoxSortTypesURL.CheckedItems.Contains("URL"))
                Franchise.AddFiltersURL(true);
            if (checkedListBoxSortTypesURL.CheckedItems.Contains("-URL"))
                Franchise.AddFiltersURL(false);
            //Names
            if (checkedListBoxSortTypesNames.CheckedItems.Contains("1 name"))
                Franchise.AddFiltersNames(false);
            if (checkedListBoxSortTypesNames.CheckedItems.Contains("2+ names"))
                Franchise.AddFiltersNames(true);
            //ForWhom
            foreach (int p in checkedListBoxSortTypesForWhom.CheckedIndices)
                Franchise.AddFiltersForWhom(p);
            Franchise.SetSortBy(comboBoxSortSortBy.Text, checkBoxSortReverse.Checked);
            Franchise.SetColorBy(comboBoxSortColorBy.Text);
        }

        //Form Closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            AppClose();
        }
        //Franchises search
        private void TextBoxFranchisesSearch_TextChanged(object sender, EventArgs e)
        {
            Franchise.SetSearchMask(textBoxFranchisesSearch.Text);
            FranchisesToListView();
        }
        //Other
        private void AppClose()
        {
            if (!isEdited)
                Environment.Exit(0);
            DialogResult dr = MessageBox.Show("Do you wanna save changes?", "Exit", MessageBoxButtons.YesNoCancel);
            switch (dr)
            {
                case DialogResult.Yes:
                    {
                        Franchise.SaveMedia();
                        Environment.Exit(0);
                    }
                    break;
                case DialogResult.No:
                    {
                        Environment.Exit(0);
                    }
                    break;
                case DialogResult.Cancel:
                    {

                    }
                    break;
            }
        }

        private void Log(string s)
        {
            textBoxLog.Text += s + "\r\n";
        }
    }
}
