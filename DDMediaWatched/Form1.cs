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

        public static string
            sortBy = "",
            colorBy = "";

        public static bool
            reverseSort = false,
            isEdited = false;

        public Form1()
        {
            InitializeComponent();
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
        //Edit Franchise
        private void buttonNewFranchise_Click(object sender, EventArgs e)
        {
            ControlsDisable(controlsRightButtons);
            ControlsDisable(controlsListViews);
            currentFranchise = new Franchise();
            Franchise.franchises.Add(currentFranchise);
            EditFranchise();
        }

        private void buttonEditFranchiseSave_Click(object sender, EventArgs e)
        {
            isEdited = true;
            ControlsOffVisible(controlsNewFranchise);
            currentFranchise.setNames(textBoxEditFranchiseNames.Text.Split(';'));
            currentFranchise.setPath(textBoxEditFranchisePath.Text);
            currentFranchise.setURL(textBoxEditFranchiseURL.Text);
            currentFranchise.setType(comboBoxEditFranchiseType.SelectedIndex);
            currentFranchise.setStartingDate(textBoxEditFranchiseDate.Text);
            foreach (Part part in currentFranchise.getParts())
                part.findSize();
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
            textBoxEditFranchiseNames.Text = currentFranchise.getAllNames();
            textBoxEditFranchisePath.Text = currentFranchise.getPath();
            textBoxEditFranchiseURL.Text = currentFranchise.getURL();
            comboBoxEditFranchiseType.SelectedIndex = currentFranchise.getTypeInt();
            textBoxEditFranchiseDate.Text = currentFranchise.getStartingDate().ToString("yyyy.MM.dd");
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
                    for (int i = 0; i < Franchise.franchises.Count; i++)
                        if (Franchise.franchises[i].getName() == currentFranchise.getName())
                        {
                            Franchise.franchises.RemoveAt(i);
                            break;
                        }
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
            foreach (Part p in currentFranchise.getParts())
                p.addWatch();
        }

        private void findSizeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (currentFranchise == null)
                return;
            isEdited = true;
            currentFranchise.findSize();
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
                string selected = listViewTitles.SelectedItems[0].Text;
                foreach (Franchise franchise in Franchise.franchises)
                    if (franchise.getName() == selected)
                    {
                        currentFranchise = franchise;
                        break;
                    }
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
            currentFranchise.getParts().Add(currentPart);
            EditPart();
        }

        private void buttonEditPartSave_Click(object sender, EventArgs e)
        {
            isEdited = true;
            int b = 0;
            foreach (Part part in currentFranchise.getParts())
                if (part.getName() == textBoxEditPartName.Text)
                    b++;
            if (currentPart.getName() == textBoxEditPartName.Text)
                b--;
            if (b > 0)
            {
                MessageBox.Show("There is alredy exist part with this name!", "Error");
                return;
            }
            int len = StaticUtils.HMStoSecs(textBoxEditPartLength.Text);
            if (!currentPart.isFull())
            {
                if (!MakeLengthsEditPart())
                    return;
            }
            if (!MakeCOWEditPart())
                return;
            if (currentPart.isFull())
            {
                if (len == -1)
                    return;
                currentPart.setCommonLength(len);
                currentPart.setSeriesLengthToCommon();
            }
            ControlsOffVisible(controlsNewPart);
            currentPart.setName(textBoxEditPartName.Text);
            currentPart.setPath(textBoxEditPartPath.Text);
            if (len != -1)
            {
                currentPart.setCommonLength(len);
            }
            currentPart.setIsPathFile(checkBoxEditPartIsPathFile.Checked);
            currentPart.findSize();
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
            textBoxEditPartName.Text = currentPart.getName();
            textBoxEditPartPath.Text = currentPart.getPath();
            int p = currentPart.getCommonLength();
            textBoxEditPartLength.Text = String.Format("{0}:{1}:{2}", p / 3600, p / 60 % 60, p % 60);
            numericUpDownEditPartSeries.Value = currentPart.getSeries().Count();
            checkBoxEditPartIsPathFile.Checked = currentPart.isFull();
            MakeEditPartLengths();
            MakeEditPartCOW();
        }

        private void textBoxEditPartLength_TextChanged(object sender, EventArgs e)
        {
            int p = StaticUtils.HMStoSecs(textBoxEditPartLength.Text);
            if (p == -1)
                return;
            currentPart.setCommonLength(p);
            if (!currentPart.isFull())
                MakeEditPartLengths();
            else
                currentPart.setSeriesLengthToCommon();
        }

        private void numericUpDownEditPartSeries_ValueChanged(object sender, EventArgs e)
        {
            int p = (int)numericUpDownEditPartSeries.Value;
            if (currentPart.getSeries().Count != p)
                if (currentPart.getSeries().Count < p)
                {
                    p = p - currentPart.getSeries().Count;
                    for (int i = 0; i < p; i++)
                        currentPart.getSeries().Add(new Series(currentPart.getCommonLength(), 0));
                }
                else
                {
                    p = currentPart.getSeries().Count - p;
                    for (int i = 0; i < p; i++)
                        currentPart.getSeries().RemoveAt(currentPart.getSeries().Count - 1);
                }
            if (!currentPart.isFull())
            {
                MakeEditPartLengths();
                MakeEditPartCOW();
            }
            else
                currentPart.setSeriesLengthToCommon();
        }

        private void MakeEditPartLengths()
        {
            string str = "";
            foreach (Series s in currentPart.getSeries())
            {
                str += String.Format("{0};", s.getLength());
            }
            if (!String.IsNullOrEmpty(str))
                str = str.Remove(str.Length - 1);
            textBoxEditPartLengths.Text = str;
        }

        private void MakeEditPartCOW()
        {
            string str = "";
            foreach (Series s in currentPart.getSeries())
            {
                str += String.Format("{0};", s.getCountWatch());
            }
            if (!String.IsNullOrEmpty(str))
                str = str.Remove(str.Length - 1);
            textBoxEditPartCOW.Text = str;
        }

        private bool MakeLengthsEditPart()
        {
            string[] s = textBoxEditPartLengths.Text.Split(';');
            if (s.Length != currentPart.getSeries().Count)
                return false;
            int[] l = new int[s.Length];
            bool b = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (!int.TryParse(s[i], out l[i]))
                    b = false;
            }
            if (!b)
                return false;
            for (int i = 0; i < l.Length; i++)
                currentPart.getSeries()[i].setLength(l[i]);
            return true;
        }

        private bool MakeCOWEditPart()
        {
            string[] s = textBoxEditPartCOW.Text.Split(';');
            if (s.Length != currentPart.getSeries().Count)
                return false;
            int[] l = new int[s.Length];
            bool b = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (!int.TryParse(s[i], out l[i]))
                    b = false;
            }
            if (!b)
                return false;
            for (int i = 0; i < l.Length; i++)
                currentPart.getSeries()[i].setCountWatch(l[i]);
            return true;
        }

        private void checkBoxEditPartIsPathFile_CheckedChanged(object sender, EventArgs e)
        {
            currentPart.setIsPathFile(checkBoxEditPartIsPathFile.Checked);
            if (checkBoxEditPartIsPathFile.Checked)
            {
                numericUpDownEditPartSeries.Value = 1;
                numericUpDownEditPartSeries.Enabled = false;
                textBoxEditPartLengths.Enabled = false;
                currentPart.setPath(textBoxEditPartPath.Text);
                textBoxEditPartLength.Text = StaticUtils.GetVideoLength(currentPart.getAbsolutePath());
            }
            else
            {
                numericUpDownEditPartSeries.Enabled = true;
                textBoxEditPartLengths.Enabled = true;
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
            currentPart.setSeriesLengthToCommon();
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
                    for (int i = 0; i < currentFranchise.getParts().Count; i++)
                        if (currentFranchise.getParts()[i].getName() == currentPart.getName())
                        {
                            currentFranchise.getParts().RemoveAt(i);
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
            currentPart.addWatch();
        }

        private void findSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentPart == null)
                return;
            isEdited = true;
            currentPart.findSize();
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
                foreach (Part p in currentFranchise.getParts())
                    if (p.getName() == selected)
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
            for (int i = 1; i < currentFranchise.getParts().Count; i++)
                if (currentFranchise.getParts()[i].getName() == currentPart.getName())
                {
                    Part p = currentFranchise.getParts()[i];
                    currentFranchise.getParts()[i] = currentFranchise.getParts()[i - 1];
                    currentFranchise.getParts()[i - 1] = p;
                    break;
                }
            currentPart = null;
            textBoxPartInfo.Text = "Selected None!\r\n";
            PartsToListView();
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isEdited = true;
            for (int i = 0; i < currentFranchise.getParts().Count - 1; i++)
                if (currentFranchise.getParts()[i].getName() == currentPart.getName())
                {
                    Part p = currentFranchise.getParts()[i];
                    currentFranchise.getParts()[i] = currentFranchise.getParts()[i + 1];
                    currentFranchise.getParts()[i + 1] = p;
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
                    Franchise.franchises.Add(new Franchise(p.Split('|')));
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
                foreach (Franchise franchise in Franchise.franchises)
                {
                    foreach (Part part in franchise.getParts())
                        part.findSize();
                }
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
                string selected = listViewTitles.SelectedItems[0].Text;
                foreach (Franchise franchise in Franchise.franchises)
                    if (franchise.getName() == selected)
                    {
                        currentFranchise = franchise;
                        textBoxTitleInfo.Text = currentFranchise.ToString();
                        break;
                    }
            }
            PartsToListView();
        }

        private void listViewTitles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (currentFranchise == null)
                return;
            if (currentFranchise.getURL() != "")
                System.Diagnostics.Process.Start(currentFranchise.getURL());
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
                foreach (Part part in currentFranchise.getParts())
                    if (part.getName() == selected)
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
