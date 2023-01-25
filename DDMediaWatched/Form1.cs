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
        public static Franchise
            currentFranchise;

        public static Part
            currentPart;

        public List<Control>
            controlsNewFranchise = new List<Control>(),
            controlsInfo = new List<Control>(),
            controlsNewPart = new List<Control>(),
            controlsRightButtons = new List<Control>(),
            controlsSort = new List<Control>(),
            controlsListViews = new List<Control>();

        public List<Franchise.FranchiseType>
            TypeOnType = new List<Franchise.FranchiseType>();

        public List<Franchise.FranchiseDown>
            TypeOnDown = new List<Franchise.FranchiseDown>();

        public List<Franchise.FranchisePersentage>
            TypeOnPersentage = new List<Franchise.FranchisePersentage>();

        public List<bool>
            TypeOnURL = new List<bool>();

        public static string
            sortBy = "",
            colorBy = "";

        public static bool
            reverseSort = false,
            isEdited = false;

        private readonly List<NumericUpDown>
            PanelEditPartCOW = new List<NumericUpDown>();

        private readonly List<TextBox>
            PanelEditPartLengths = new List<TextBox>();

        public Form1()
        {
            InitializeComponent();
            InitializePanelsEditPart();
            LoadConfigs();
            CheckCheckedListBoxes();
            SaveSortConfigs();
            LoadColumnsFranchises();
            LoadColumnsParts();
            Program.pathLetter = StaticUtils.FindDiskLetter();
            LoadControls();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Franchise.LoadMedia();
            FranchisesToListView();
            DrawStatistic();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F5:
                    {
                        SelectNone();
                        DrawStatistic();
                    }
                    break;
                case Keys.Escape:
                    {
                        AppClose();
                    }
                    break;
            }
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
        private void buttonNewFranchise_Click(object sender, EventArgs e)
        {
            ControlsDisable(controlsRightButtons);
            ControlsDisable(controlsListViews);
            currentFranchise = new Franchise();
            Franchise.AddFranchise(currentFranchise);
            EditFranchise();
        }

        private void buttonEditFranchiseSave_Click(object sender, EventArgs e)
        {
            isEdited = true;
            ControlsOffVisible(controlsNewFranchise);
            currentFranchise.SetNames(textBoxEditFranchiseNames.Text.Split(';'));
            currentFranchise.SetPath(textBoxEditFranchisePath.Text);
            currentFranchise.SetURL(textBoxEditFranchiseURL.Text);
            currentFranchise.SetType(comboBoxEditFranchiseType.SelectedIndex);
            currentFranchise.SetStartingDate(textBoxEditFranchiseDate.Text);
            foreach (Part part in currentFranchise.GetParts())
                part.FindSize();
            ControlsOnVisible(controlsInfo);
            FranchisesToListView();
            listViewParts.Enabled = true;
            listViewTitles.Enabled = true;
            ControlsEnable(controlsRightButtons);
            ControlsEnable(controlsListViews);
        }

        private void EditFranchise()
        {
            ControlsOffVisible(controlsInfo);
            ControlsOnVisible(controlsNewFranchise);
            textBoxEditFranchiseNames.Text = currentFranchise.GetAllNames();
            textBoxEditFranchisePath.Text = currentFranchise.GetPath();
            textBoxEditFranchiseURL.Text = currentFranchise.GetURL();
            comboBoxEditFranchiseType.SelectedIndex = currentFranchise.GetFranchiseTypeInt();
            textBoxEditFranchiseDate.Text = currentFranchise.GetStartingDate().ToString("yyyy.MM.dd");
        }

        private void buttonEditFranchiseToday_Click(object sender, EventArgs e)
        {
            textBoxEditFranchiseDate.Text = DateTime.Now.ToString("yyyy.MM.dd");
        }
        //ContexFranchise
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            isEdited = true;
            ControlsDisable(controlsRightButtons);
            if (currentFranchise != null)
                if (MessageBox.Show("Are you sure???", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Franchise.RemoveFranchise(currentFranchise.GetName());
                    SelectNone();
                    FranchisesToListView();
                }
            ControlsEnable(controlsRightButtons);
        }

        private void addFullWatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFranchise == null)
                return;
            isEdited = true;
            foreach (Part p in currentFranchise.GetParts())
                p.AddWatch();
        }

        private void findSizeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (currentFranchise == null)
                return;
            isEdited = true;
            currentFranchise.FindSize();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void buttonNewPart_Click(object sender, EventArgs e)
        {
            if (currentFranchise == null)
                return;
            ControlsDisable(controlsRightButtons);
            ControlsDisable(controlsListViews);
            currentPart = new Part(currentFranchise);
            currentFranchise.GetParts().Add(currentPart);
            EditPart();
        }

        private void buttonEditPartSave_Click(object sender, EventArgs e)
        {
            isEdited = true;
            int b = 0;
            foreach (Part part in currentFranchise.GetParts())
                if (part.GetName() == textBoxEditPartName.Text)
                    b++;
            if (currentPart.GetName() == textBoxEditPartName.Text)
                b--;
            if (b > 0)
            {
                MessageBox.Show("There is alredy exist part with this name!", "Error");
                return;
            }
            int len = StaticUtils.HMStoSecs(textBoxEditPartLength.Text);
            if (!currentPart.IsFull())
            {
                if (!MakeLengthsEditPart())
                    return;
            }
            MakeCOWEditPart();
            if (currentPart.IsFull())
            {
                if (len == -1)
                    return;
                currentPart.SetCommonLength(len);
                currentPart.SetSeriesLengthToCommon();
            }
            ControlsOffVisible(controlsNewPart);
            currentPart.SetName(textBoxEditPartName.Text);
            currentPart.SetPath(textBoxEditPartPath.Text);
            if (len != -1)
            {
                currentPart.SetCommonLength(len);
            }
            currentPart.SetIsPathFile(checkBoxEditPartIsPathFile.Checked);
            currentPart.FindSize();
            ControlsOnVisible(controlsInfo);
            currentPart = null;
            PartsToListView();
            listViewParts.Enabled = true;
            listViewTitles.Enabled = true;
            ControlsEnable(controlsRightButtons);
            ControlsEnable(controlsListViews);
        }

        private void EditPart()
        {
            ControlsOffVisible(controlsInfo);
            ControlsOnVisible(controlsNewPart);
            textBoxEditPartName.Text = currentPart.GetName();
            textBoxEditPartPath.Text = currentPart.GetPath();
            textBoxEditPartLength.Text = StaticUtils.SecsToHMS(currentPart.GetCommonLength());
            numericUpDownEditPartSeries.Value = currentPart.GetSeries().Count();
            checkBoxEditPartIsPathFile.Checked = currentPart.IsFull();
            MakeEditPartLengths();
            MakeEditPartCOW();
        }

        private void textBoxEditPartLength_TextChanged(object sender, EventArgs e)
        {
            int p = StaticUtils.HMStoSecs(textBoxEditPartLength.Text);
            if (p == -1)
                return;
            currentPart.SetCommonLength(p);
            if (!currentPart.IsFull())
                MakeEditPartLengths();
            else
                currentPart.SetSeriesLengthToCommon();
        }

        private void numericUpDownEditPartSeries_ValueChanged(object sender, EventArgs e)
        {
            int p = (int)numericUpDownEditPartSeries.Value;
            if (currentPart.GetSeries().Count != p)
                if (currentPart.GetSeries().Count < p)
                {
                    p = p - currentPart.GetSeries().Count;
                    for (int i = 0; i < p; i++)
                        currentPart.GetSeries().Add(new Series(currentPart.GetCommonLength(), 0));
                }
                else
                {
                    p = currentPart.GetSeries().Count - p;
                    for (int i = 0; i < p; i++)
                        currentPart.GetSeries().RemoveAt(currentPart.GetSeries().Count - 1);
                }
            if (!currentPart.IsFull())
            {
                MakeEditPartLengths();
                MakeEditPartCOW();
            }
            else
                currentPart.SetSeriesLengthToCommon();
        }

        private void MakeEditPartLengths()
        {
            panelEditPartLengths.Controls.Clear();
            PanelEditPartLengths.Clear();
            int i = 0;
            foreach (Series s in currentPart.GetSeries())
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
                    Text = StaticUtils.SecsToHMS(s.GetLength())
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
            foreach (Series s in currentPart.GetSeries())
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
                    Maximum = 9999,
                    Increment = 1,
                    Value = s.GetCountWatch()
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
            int[] lengths = new int[currentPart.GetSeries().Count];
            for (int i = 0; i < currentPart.GetSeries().Count; i++)
            {
                lengths[i] = StaticUtils.HMStoSecs(PanelEditPartLengths[i].Text);
                if (lengths[i] == -1)
                    isConvertionCorrect = false;
            }
            if (isConvertionCorrect)
                for (int i = 0; i < currentPart.GetSeries().Count; i++)
                    currentPart.GetSeries()[i].SetLength(lengths[i]);
            else
                return false;
            return true;
        }

        private void MakeCOWEditPart()
        {
            for (int i = 0; i < currentPart.GetSeries().Count; i++)
            {
                int cow = (int)PanelEditPartCOW[i].Value;
                currentPart.GetSeries()[i].SetCountWatch(cow);
            }
        }

        private void checkBoxEditPartIsPathFile_CheckedChanged(object sender, EventArgs e)
        {
            currentPart.SetIsPathFile(checkBoxEditPartIsPathFile.Checked);
            if (checkBoxEditPartIsPathFile.Checked)
            {
                numericUpDownEditPartSeries.Value = 1;
                numericUpDownEditPartSeries.Enabled = false;
                panelEditPartLengths.Enabled = false;
                currentPart.SetPath(textBoxEditPartPath.Text);
                if (File.Exists(currentPart.GetAbsolutePath()))
                    textBoxEditPartLength.Text = StaticUtils.GetVideoLength(currentPart.GetAbsolutePath());
            }
            else
            {
                numericUpDownEditPartSeries.Enabled = true;
                panelEditPartLengths.Enabled = true;
            }
        }

        private void textBoxEditPartPath_TextChanged(object sender, EventArgs e)
        {
            string path = textBoxEditPartPath.Text;
            if (path.Length > 0)
                if (path[0] == '"')
                    path = path.Substring(1, path.Length - 2);
            int p = StaticUtils.IsFileOrDirr(path);
            if (p == 0)
            {
                checkBoxEditPartIsPathFile.Checked = false;
            }
            if (p == 1)
            {
                checkBoxEditPartIsPathFile.Checked = true;
            }
        }

        private void buttonEditPartCommonLengthToAll_Click(object sender, EventArgs e)
        {
            currentPart.SetSeriesLengthToCommon();
            MakeEditPartLengths();
        }
        //ContexParts
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isEdited = true;
            ControlsDisable(controlsRightButtons);
            if (currentPart != null)
                if (MessageBox.Show("Are you sure???", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < currentFranchise.GetParts().Count; i++)
                        if (currentFranchise.GetParts()[i].GetName() == currentPart.GetName())
                        {
                            currentFranchise.GetParts().RemoveAt(i);
                            break;
                        }
                    SelectNone();
                }
            ControlsEnable(controlsRightButtons);
        }

        private void addFullViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentPart == null)
                return;
            isEdited = true;
            currentPart.AddWatch();
        }

        private void findSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentPart == null)
                return;
            isEdited = true;
            currentPart.FindSize();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listViewParts.SelectedItems.Count > 0)
            {
                isEdited = true;
                ControlsDisable(controlsRightButtons);
                ControlsDisable(controlsListViews);
                listViewParts.Enabled = false;
                listViewTitles.Enabled = false;
                string selected = listViewParts.SelectedItems[0].Text;
                foreach (Part p in currentFranchise.GetParts())
                    if (p.GetName() == selected)
                    {
                        currentPart = p;
                        break;
                    }
                EditPart();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Franchise.SaveMedia();
            MessageBox.Show("Media has been saved succesful!!!", "Saved!");
            isEdited = false;
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isEdited = true;
            for (int i = 1; i < currentFranchise.GetParts().Count; i++)
                if (currentFranchise.GetParts()[i].GetName() == currentPart.GetName())
                {
                    Part p = currentFranchise.GetParts()[i];
                    currentFranchise.GetParts()[i] = currentFranchise.GetParts()[i - 1];
                    currentFranchise.GetParts()[i - 1] = p;
                    break;
                }
            currentPart = null;
            textBoxPartInfo.Text = "Selected None!\r\n";
            PartsToListView();
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isEdited = true;
            for (int i = 0; i < currentFranchise.GetParts().Count - 1; i++)
                if (currentFranchise.GetParts()[i].GetName() == currentPart.GetName())
                {
                    Part p = currentFranchise.GetParts()[i];
                    currentFranchise.GetParts()[i] = currentFranchise.GetParts()[i + 1];
                    currentFranchise.GetParts()[i + 1] = p;
                    break;
                }
            currentPart = null;
            textBoxPartInfo.Text = "Selected None!\r\n";
            PartsToListView();
        }
        //ToolStripMenu
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                isEdited = true;
                string[] s = File.ReadAllLines(openFileDialog1.FileName);
                foreach (string p in s)
                    Franchise.AddFranchise(new Franchise(p.Split('|')));
                SelectNone();
                FranchisesToListView();
            }
        }

        private void findAllSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.pathLetter == "null")
            {
                MessageBox.Show("There isn't media volume!", "Error");
            }
            else
            {
                isEdited = true;
                Franchise.FindAllSize();
                Log("All size has been updated!");
            }
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            File.Copy(Franchise.GetMediaPath() + "Media.bin", Franchise.GetMediaPath() + String.Format("Media - {0}.bin", dt.ToString("yyyy.MM.dd HH.mm.ss")));
            MessageBox.Show("BackUP has been created!", "Success");
        }
        //ListViews
        private void listViewTitles_SelectedIndexChanged(object sender, EventArgs e)
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

        private void listViewTitles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (currentFranchise == null)
                return;
            if (currentFranchise.GetURL() != "")
                System.Diagnostics.Process.Start(currentFranchise.GetURL());
        }

        private void listViewParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewParts.SelectedItems.Count < 1)
            {
                currentPart = null;
                textBoxPartInfo.Text = "Selected None!\r\n";
            }
            else
            {
                string selected = listViewParts.SelectedItems[0].Text;
                foreach (Part part in currentFranchise.GetParts())
                    if (part.GetName() == selected)
                    {
                        currentPart = part;
                        textBoxPartInfo.Text = currentPart.ToString();
                        break;
                    }
            }
        }
        //Font size
        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            listViewParts.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
            listViewTitles.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
            textBoxTitleInfo.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
            textBoxPartInfo.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
        }
        //Sort
        private void buttonSort_Click(object sender, EventArgs e)
        {
            ControlsDisable(controlsRightButtons);

            ControlsOffVisible(controlsInfo);
            ControlsOnVisible(controlsSort);
        }

        private void buttonSortSave_Click(object sender, EventArgs e)
        {
            ControlsOffVisible(controlsSort);
            ControlsOnVisible(controlsInfo);
            SaveSortConfigs();
            FranchisesToListView();
            ControlsEnable(controlsRightButtons);
        }

        private void CheckCheckedListBoxes()
        {
            checkedListBoxSortTypesGenre.SetItemChecked(0, true);
            checkedListBoxSortTypesGenre.SetItemChecked(1, true);
            checkedListBoxSortTypesGenre.SetItemChecked(2, true);
            checkedListBoxSortTypesGenre.SetItemChecked(3, true);
            checkedListBoxSortTypesDown.SetItemChecked(0, true);
            checkedListBoxSortTypesDown.SetItemChecked(1, true);
            checkedListBoxSortTypesPersentage.SetItemChecked(0, true);
            checkedListBoxSortTypesPersentage.SetItemChecked(1, true);
            checkedListBoxSortTypesPersentage.SetItemChecked(2, true);
            checkedListBoxSortTypesURL.SetItemChecked(0, true);
            checkedListBoxSortTypesURL.SetItemChecked(1, true);
        }

        private void SaveSortConfigs()
        {
            TypeOnType.Clear();
            foreach (int p in checkedListBoxSortTypesGenre.CheckedIndices)
                TypeOnType.Add((Franchise.FranchiseType)p);
            TypeOnDown.Clear();
            foreach (int p in checkedListBoxSortTypesDown.CheckedIndices)
                TypeOnDown.Add((Franchise.FranchiseDown)p);
            TypeOnPersentage.Clear();
            foreach (int p in checkedListBoxSortTypesPersentage.CheckedIndices)
                TypeOnPersentage.Add((Franchise.FranchisePersentage)p);
            TypeOnURL.Clear();
            if (checkedListBoxSortTypesURL.CheckedItems.Contains("URL"))
                TypeOnURL.Add(true);
            if (checkedListBoxSortTypesURL.CheckedItems.Contains("-URL"))
                TypeOnURL.Add(false);
            sortBy = comboBoxSortSortBy.Text;
            colorBy = comboBoxSortColorBy.Text;
            reverseSort = checkBoxSortReverse.Checked;
        }
        //Form Closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            AppClose();
        }
        //Other
        public void AppClose()
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

        public void Log(string s)
        {
            textBoxLog.Text += s + "\r\n";
        }
    }
}
