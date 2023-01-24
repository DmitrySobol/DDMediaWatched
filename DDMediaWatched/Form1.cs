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
        public static string
            path;

        public static List<Franchise>
            franchises = new List<Franchise>();

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

        private static Color
            colorPers100 = Color.FromArgb(191, 255, 191),
            colorPers50 = Color.FromArgb(255, 255, 191),
            colorPers0 = Color.FromArgb(255, 191, 191);

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            checkedListBoxSortTypesGenre.SetItemChecked(0, true);
            checkedListBoxSortTypesGenre.SetItemChecked(1, true);
            checkedListBoxSortTypesGenre.SetItemChecked(2, true);
            checkedListBoxSortTypesGenre.SetItemChecked(3, true);
            foreach (int p in checkedListBoxSortTypesGenre.CheckedIndices)
                TypeOnType.Add((Franchise.FranchiseType)p);
            checkedListBoxSortTypesDown.SetItemChecked(0, true);
            checkedListBoxSortTypesDown.SetItemChecked(1, true);
            foreach (int p in checkedListBoxSortTypesDown.CheckedIndices)
                TypeOnDown.Add((Franchise.FranchiseDown)p);
            checkedListBoxSortTypesPersentage.SetItemChecked(0, true);
            checkedListBoxSortTypesPersentage.SetItemChecked(1, true);
            checkedListBoxSortTypesPersentage.SetItemChecked(2, true);
            foreach (int p in checkedListBoxSortTypesPersentage.CheckedIndices)
                TypeOnPersentage.Add((Franchise.FranchisePersentage)p);
            checkedListBoxSortTypesURL.SetItemChecked(0, true);
            checkedListBoxSortTypesURL.SetItemChecked(1, true);
            sortBy = comboBoxSortSortBy.Text;
            colorBy = comboBoxSortColorBy.Text;
            LoadColumnsFranchises();
            LoadColumnsParts();
            FindDiskLetter();
            LoadControls();
        }

        private static void FindDiskLetter()
        {
            string[] drivers = Environment.GetLogicalDrives();
            for (int i = 0; i < drivers.Length;  i++)
            {
                if (File.Exists(drivers[i] + "config.dat"))
                    if (File.ReadAllText(drivers[i] + "config.dat", Encoding.UTF8) == "LOLI_HDD")
                        Program.pathLetter = drivers[i];
            }
        }

        private void LoadColumnsFranchises()
        {
            List<ColumnHeader> columns = new List<ColumnHeader>();
            ColumnHeader ch;
            ch = new ColumnHeader
            {
                Text = "Name",
                Width = 180
            };
            columns.Add(ch);
            ch = new ColumnHeader
            {
                Text = "Length",
                Width = 70
            };
            columns.Add(ch);
            ch = new ColumnHeader
            {
                Text = "Size",
                Width = 70
            };
            columns.Add(ch);
            ch = new ColumnHeader
            {
                Text = "BPS",
                Width = 60
            };
            columns.Add(ch);
            ch = new ColumnHeader
            {
                Text = "%",
                Width = 40
            };
            columns.Add(ch);
            ch = new ColumnHeader
            {
                Text = "Type",
                Width = 40
            };
            columns.Add(ch);
            ch = new ColumnHeader
            {
                Text = "Path",
                Width = 200
            };
            columns.Add(ch);
            listViewTitles.Columns.AddRange(columns.ToArray());
        }

        private void LoadColumnsParts()
        {
            List<ColumnHeader> columns = new List<ColumnHeader>();
            ColumnHeader ch;
            ch = new ColumnHeader
            {
                Text = "Name",
                Width = 220
            };
            columns.Add(ch);
            ch = new ColumnHeader
            {
                Text = "Length",
                Width = 70
            };
            columns.Add(ch);
            ch = new ColumnHeader
            {
                Text = "Size",
                Width = 70
            };
            columns.Add(ch);
            ch = new ColumnHeader
            {
                Text = "BPS",
                Width = 60
            };
            columns.Add(ch);
            ch = new ColumnHeader
            {
                Text = "%",
                Width = 40
            };
            columns.Add(ch);
            ch = new ColumnHeader
            {
                Text = "Path",
                Width = 200
            };
            columns.Add(ch);
            listViewParts.Columns.AddRange(columns.ToArray());
        }

        private void LoadControls()
        {
            controlsNewFranchise.Add(groupBoxNewFranchise);
            controlsInfo.Add(labelInfo);
            controlsInfo.Add(textBoxInfo);
            controlsNewPart.Add(groupBoxNewPart);
            controlsRightButtons.Add(buttonNewFranchise);
            controlsRightButtons.Add(buttonNewPart);
            controlsRightButtons.Add(buttonSort);
            controlsSort.Add(groupBoxSort);
            controlsListViews.Add(listViewTitles);
            controlsListViews.Add(listViewParts);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadConfigs();
            LoadMedia();
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

        private void LoadConfigs()
        {
            FileStream fs = new FileStream("config.cfg", FileMode.Open, FileAccess.Read);
            StreamReader t = new StreamReader(fs, Encoding.UTF8);
            path = t.ReadLine();
            t.Dispose();
            t.Close();
            fs.Dispose();
            fs.Close();
        }

        private void LoadMedia()
        {
            FileStream f = new FileStream(path + "Media.bin", FileMode.Open, FileAccess.Read);
            int p = BinaryFile.FileReadInt32(f);
            for (int j = 0; j < p; j++)
            {
                franchises.Add(new Franchise(f));
            }
            f.Dispose();
            f.Close();
        }

        private void SaveMedia()
        {
            FileStream f = new FileStream(path + "Media.bin", FileMode.Create, FileAccess.Write);
            f.Write(BitConverter.GetBytes(franchises.Count), 0, 4);
            foreach (Franchise el in franchises)
            {
                el.SaveToBin(f);
            }
            f.Dispose();
            f.Close();
            MessageBox.Show("Media has been saved succesful!!!", "Saved!");
            isEdited = false;
        }

        public void SelectNone()
        {
            currentFranchise = null;
            textBoxTitleInfo.Text = "Selected None!\r\n";
            currentPart = null;
            textBoxPartInfo.Text = "Selected None!\r\n";
            FranchisesToListView();
            PartsToListView();
        }
        //Edit Franchise
        private void buttonNewFranchise_Click(object sender, EventArgs e)
        {
            ControlsDisable(controlsRightButtons);
            ControlsDisable(controlsListViews);
            currentFranchise = new Franchise();
            franchises.Add(currentFranchise);
            EditFranchise();
        }

        private void buttonNewFranchiseSave_Click(object sender, EventArgs e)
        {
            isEdited = true;
            ControlsOff(controlsNewFranchise);
            currentFranchise.setNames(textBoxNewFranchiseNames.Text.Split(';'));
            currentFranchise.setPath(textBoxNewFranchisePath.Text);
            currentFranchise.setURL(textBoxNewFranchiseURL.Text);
            currentFranchise.setType(comboBoxNewFranchiseType.SelectedIndex);
            currentFranchise.setStartingDate(textBoxNewFranchiseDate.Text);
            foreach (Part part in currentFranchise.getParts())
                part.findSize();
            ControlsOn(controlsInfo);
            FranchisesToListView();
            listViewParts.Enabled = true;
            listViewTitles.Enabled = true;
            ControlsEnable(controlsRightButtons);
            ControlsEnable(controlsListViews);
        }

        private void EditFranchise()
        {
            ControlsOff(controlsInfo);
            ControlsOn(controlsNewFranchise);
            textBoxNewFranchiseNames.Text = currentFranchise.getAllNames();
            textBoxNewFranchisePath.Text = currentFranchise.getPath();
            textBoxNewFranchiseURL.Text = currentFranchise.getURL();
            comboBoxNewFranchiseType.SelectedIndex = currentFranchise.getTypeInt();
            textBoxNewFranchiseDate.Text = currentFranchise.getStartingDate().ToString("yyyy.MM.dd");
        }

        private void buttonNewFranchiseToday_Click(object sender, EventArgs e)
        {
            textBoxNewFranchiseDate.Text = DateTime.Now.ToString("yyyy.MM.dd");
        }
        //ContexFranchise
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            isEdited = true;
            ControlsDisable(controlsRightButtons);
            if (currentFranchise != null)
                if (MessageBox.Show("Are you sure???", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < franchises.Count; i++)
                        if (franchises[i].getName() == currentFranchise.getName())
                        {
                            franchises.RemoveAt(i);
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
                foreach (Franchise franchise in franchises)
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

        private void buttonNewPartSave_Click(object sender, EventArgs e)
        {
            isEdited = true;
            int b = 0;
            foreach (Part part in currentFranchise.getParts())
                if (part.getName() == textBoxNewPartName.Text)
                    b++;
            if (currentPart.getName() == textBoxNewPartName.Text)
                b--;
            if (b > 0)
            {
                MessageBox.Show("There is alredy exist part with this name!", "Error");
                return;
            }
            int len = StaticUtils.HMStoSecs(textBoxNewPartLength.Text);
            if (!currentPart.isFull())
            {
                if (!MakeLengthsNewPart())
                    return;
            }
            if (!MakeCOWNewPart())
                return;
            if (currentPart.isFull())
            {
                if (len == -1)
                    return;
                currentPart.setCommonLength(len);
                currentPart.setSeriesLengthToCommon();
            }
            ControlsOff(controlsNewPart);
            currentPart.setName(textBoxNewPartName.Text);
            currentPart.setPath(textBoxNewPartPath.Text);
            if (len != -1)
            {
                currentPart.setCommonLength(len);
            }
            currentPart.setIsPathFile(checkBoxNewPartIsPathFile.Checked);
            currentPart.findSize();
            ControlsOn(controlsInfo);
            currentPart = null;
            PartsToListView();
            listViewParts.Enabled = true;
            listViewTitles.Enabled = true;
            ControlsEnable(controlsRightButtons);
            ControlsEnable(controlsListViews);
        }

        private void EditPart()
        {
            ControlsOff(controlsInfo);
            ControlsOn(controlsNewPart);
            textBoxNewPartName.Text = currentPart.getName();
            textBoxNewPartPath.Text = currentPart.getPath();
            int p = currentPart.getCommonLength();
            textBoxNewPartLength.Text = String.Format("{0}:{1}:{2}", p / 3600, p / 60 % 60, p % 60);
            numericUpDownNewPartSeries.Value = currentPart.getSeries().Count();
            checkBoxNewPartIsPathFile.Checked = currentPart.isFull();
            MakeNewPartLengths();
            MakeNewPartCOW();
        }

        private void textBoxNewPartLength_TextChanged(object sender, EventArgs e)
        {
            int p = StaticUtils.HMStoSecs(textBoxNewPartLength.Text);
            if (p == -1)
                return;
            currentPart.setCommonLength(p);
            if (!currentPart.isFull())
                MakeNewPartLengths();
            else
                currentPart.setSeriesLengthToCommon();
        }

        private void numericUpDownNewPartSeries_ValueChanged(object sender, EventArgs e)
        {
            int p = (int)numericUpDownNewPartSeries.Value;
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
                MakeNewPartLengths();
                MakeNewPartCOW();
            }
            else
                currentPart.setSeriesLengthToCommon();
        }

        private void MakeNewPartLengths()
        {
            string str = "";
            foreach (Series s in currentPart.getSeries())
            {
                str += String.Format("{0};", s.getLength());
            }
            if (!String.IsNullOrEmpty(str))
                str = str.Remove(str.Length - 1);
            textBoxNewPartLengths.Text = str;
        }

        private void MakeNewPartCOW()
        {
            string str = "";
            foreach (Series s in currentPart.getSeries())
            {
                str += String.Format("{0};", s.getCountWatch());
            }
            if (!String.IsNullOrEmpty(str))
                str = str.Remove(str.Length - 1);
            textBoxNewPartCOW.Text = str;
        }

        private bool MakeLengthsNewPart()
        {
            string[] s = textBoxNewPartLengths.Text.Split(';');
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

        private bool MakeCOWNewPart()
        {
            string[] s = textBoxNewPartCOW.Text.Split(';');
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

        private void checkBoxNewPartIsPathFile_CheckedChanged(object sender, EventArgs e)
        {
            currentPart.setIsPathFile(checkBoxNewPartIsPathFile.Checked);
            if (checkBoxNewPartIsPathFile.Checked)
            {
                numericUpDownNewPartSeries.Value = 1;
                numericUpDownNewPartSeries.Enabled = false;
                textBoxNewPartLengths.Enabled = false;
                currentPart.setPath(textBoxNewPartPath.Text);
                textBoxNewPartLength.Text = StaticUtils.GetVideoLength(currentPart.getAbsolutePath());
            }
            else
            {
                numericUpDownNewPartSeries.Enabled = true;
                textBoxNewPartLengths.Enabled = true;
            }
        }

        private void textBoxNewPartPath_TextChanged(object sender, EventArgs e)
        {
            string path = textBoxNewPartPath.Text;
            if (path.Length > 0)
                if (path[0] == '"')
                    path = path.Substring(1, path.Length - 2);
            int p = StaticUtils.IsFileOrDirr(path);
            if (p == 0)
            {
                checkBoxNewPartIsPathFile.Checked = false;
            }
            if (p == 1)
            {
                checkBoxNewPartIsPathFile.Checked = true;
            }
        }

        private void buttonNewPartCommonLengthToAll_Click(object sender, EventArgs e)
        {
            currentPart.setSeriesLengthToCommon();
            MakeNewPartLengths();
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
            SaveMedia();
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
                    franchises.Add(new Franchise(p.Split('|')));
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
                foreach (Franchise franchise in franchises)
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
            File.Copy(path + "Media.bin", path + String.Format("Media - {0}.bin", dt.ToString("yyyy.MM.dd HH.mm.ss")));
            MessageBox.Show("BackUP has been created!", "Success");
        }
        //Other
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
                foreach (Franchise franchise in franchises)
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

        private void ControlsOn(List<Control> controls)
        {
            foreach (Control s in controls)
                s.Visible = true;
        }

        private void ControlsOff(List<Control> controls)
        {
            foreach (Control s in controls)
                s.Visible = false;
        }

        private void ControlsEnable(List<Control> controls)
        {
            foreach (Control s in controls)
                s.Enabled = true;
        }

        private void ControlsDisable(List<Control> controls)
        {
            foreach (Control s in controls)
                s.Enabled = false;
        }

        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            listViewParts.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
            listViewTitles.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
            textBoxTitleInfo.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
            textBoxPartInfo.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            ControlsDisable(controlsRightButtons);

            ControlsOff(controlsInfo);
            ControlsOn(controlsSort);
        }

        private void buttonSortSave_Click(object sender, EventArgs e)
        {
            ControlsOff(controlsSort);
            ControlsOn(controlsInfo);
            TypeOnType.Clear();
            foreach (int p in checkedListBoxSortTypesGenre.CheckedIndices)
                TypeOnType.Add((Franchise.FranchiseType)p);
            TypeOnDown.Clear();
            foreach (int p in checkedListBoxSortTypesDown.CheckedIndices)
                TypeOnDown.Add((Franchise.FranchiseDown)p);
            TypeOnPersentage.Clear();
            foreach (int p in checkedListBoxSortTypesPersentage.CheckedIndices)
                TypeOnPersentage.Add((Franchise.FranchisePersentage)p);
            FranchisesToListView();
            ControlsEnable(controlsRightButtons);
        }

        private void comboBoxSortSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            sortBy = comboBoxSortSortBy.Text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            AppClose();
        }

        private void comboBoxSortColorBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorBy = comboBoxSortColorBy.Text;
        }

        private void checkBoxSortReverse_CheckedChanged(object sender, EventArgs e)
        {
            reverseSort = checkBoxSortReverse.Checked;
        }

        public void FranchisesToListView()
        {
            listViewTitles.Items.Clear();
            List<Franchise> franchisesType = new List<Franchise>();
            foreach (Franchise el in franchises)
                if (IsTypeOn(el))
                    franchisesType.Add(el);
            SortFranchises(ref franchisesType);
            foreach (Franchise el in franchisesType)
            {
                ListViewItem item = new ListViewItem()
                {
                    Text = el.getName(),
                    BackColor = GetColor(el)
                };
                ListViewItem.ListViewSubItem si;
                //Length
                si = new ListViewItem.ListViewSubItem
                {
                    Tag = "Length",
                    Text = String.Format("{0:f2} Hr", el.getLength() / 3600d)
                };
                item.SubItems.Add(si);
                //Size
                si = new ListViewItem.ListViewSubItem
                {
                    Tag = "Size",
                    Text = el.getSize() == 0 ? "" : String.Format("{0:f2} Gb", el.getSize() / 1024d / 1024 / 1024)
                };
                item.SubItems.Add(si);
                //BPS
                si = new ListViewItem.ListViewSubItem
                {
                    Tag = "BPS",
                    Text = el.getSize() == 0 ? "" : String.Format("{0:f0} Mb", (el.getBPS() / 1024 / 1024))
                };
                item.SubItems.Add(si);
                //%
                si = new ListViewItem.ListViewSubItem
                {
                    Tag = "%",
                    Text = String.Format("{0:f0}%", el.getPersentage())
                };
                item.SubItems.Add(si);
                //Type
                si = new ListViewItem.ListViewSubItem
                {
                    Tag = "Type",
                    Text = String.Format("{0}", el.getTypeLetter())
                };
                item.SubItems.Add(si);
                //Path
                si = new ListViewItem.ListViewSubItem
                {
                    Tag = "Path",
                    Text = el.getPath()
                };
                item.SubItems.Add(si);
                listViewTitles.Items.Add(item);
            }
        }

        public void PartsToListView()
        {
            listViewParts.Items.Clear();
            if (currentFranchise == null)
                return;
            foreach (Part el in currentFranchise.getParts())
            {
                ListViewItem item = new ListViewItem()
                {
                    Text = el.getName()
                };
                ListViewItem.ListViewSubItem si;
                //Length
                si = new ListViewItem.ListViewSubItem
                {
                    Tag = "Length",
                    Text = String.Format("{0:f2} Hr", el.getLength() / 3600d)
                };
                item.SubItems.Add(si);
                //Size
                si = new ListViewItem.ListViewSubItem
                {
                    Tag = "Size",
                    Text = el.getSize() == 0 ? "" : String.Format("{0:f2} Gb", el.getSize() / 1024d / 1024 / 1024)
                };
                item.SubItems.Add(si);
                //BPS
                si = new ListViewItem.ListViewSubItem
                {
                    Tag = "BPS",
                    Text = el.getSize() == 0 ? "" : String.Format("{0:f0} Mb", (el.getSize() / 1024d / 1024) / (el.getLength() / 60d / 24))
                };
                item.SubItems.Add(si);
                //%
                si = new ListViewItem.ListViewSubItem
                {
                    Tag = "%",
                    Text = String.Format("{0:f0}%", el.getPersentage())
                };
                item.SubItems.Add(si);
                //Path
                si = new ListViewItem.ListViewSubItem
                {
                    Tag = "Path",
                    Text = el.getPath()
                };
                item.SubItems.Add(si);
                listViewParts.Items.Add(item);
            }
        }

        public void DrawStatistic()
        {
            string s = "";
            s += String.Format("Current media volume: {0}\r\n", Program.pathLetter);
            long size = 0;
            int watchedLength = 0;
            int watchedUniqueLength = 0;
            foreach (Franchise f in franchises)
            {
                size += f.getSize();
                watchedLength += f.getWatchedLength();
                watchedUniqueLength += f.getUniqueWatchedLength();
            }
            s += String.Format("{0,-15}:{1,9:f2} GB  \r\n", "Size Total", size / 1024d / 1024 / 1024);
            s += String.Format("{0,-15}:{1,9:f2} Hour|{2,8:f2} days\r\n", "Watched", watchedLength / 60d / 60, watchedLength / 60d / 60 / 24);
            s += String.Format("{0,-15}:{1,9:f2} Hour|{2,8:f2} days\r\n", "Watched Unique", watchedUniqueLength / 60d / 60, watchedUniqueLength / 60d / 60 / 24);
            textBoxInfo.Text = s;
        }

        public bool IsTypeOn(Franchise el)
        {
            bool b = true;
            if (!TypeOnType.Contains(el.getType()))
                b = false;
            if (!TypeOnDown.Contains(el.isDownloaded()))
                b = false;
            if (!TypeOnPersentage.Contains(el.isPersentage()))
                b = false;
            if (!checkedListBoxSortTypesURL.CheckedItems.Contains(el.isURL() ? "URL" : "-URL"))
                b = false;
            return b;
        }

        public void AppClose()
        {
            if (!isEdited)
                Environment.Exit(0);
            DialogResult dr = MessageBox.Show("Do you wanna save changes?", "Exit", MessageBoxButtons.YesNoCancel);
            switch (dr)
            {
                case DialogResult.Yes:
                    {
                        SaveMedia();
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

        public Color GetColor(Franchise franchise)
        {
            Color ret = Color.FromArgb(255, 255, 255);
            switch (colorBy)
            {
                case "Persentage (3)":
                    {
                        switch (franchise.isPersentage())
                        {
                            case Franchise.FranchisePersentage.Zero:
                                ret = colorPers0;
                                break;
                            case Franchise.FranchisePersentage.Started:
                                ret = colorPers50;
                                break;
                            case Franchise.FranchisePersentage.Full:
                                ret = colorPers100;
                                break;
                        }
                    }
                    break;
                case "Persentage (Gradient)":
                    {
                        if (franchise.getPersentage() > 50)
                        {
                            double pColor = 191 + (100 - franchise.getPersentage()) / 50 * 64;
                            ret = Color.FromArgb((int)Math.Round(pColor), 255, 191);
                        }
                        else
                        {
                            double pColor = 191 + franchise.getPersentage() / 50 * 64;
                            ret = Color.FromArgb(255, (int)Math.Round(pColor), 191);
                        }
                    }
                    break;
            }
            return ret;
        }

        public void SortFranchises(ref List<Franchise> list)
        {
            switch (sortBy)
            {
                case "Name":
                    {
                        list = list.OrderBy(x => x.getName()).ToList();
                    }
                    break;
                case "Size":
                    {
                        list = list.OrderBy(x => x.getSize()).ToList();
                    }
                    break;
                case "Length":
                    {
                        list = list.OrderBy(x => x.getLength()).ToList();
                    }
                    break;
                case "Persentage (0-100)":
                    {
                        list = list.OrderBy(x => x.getPersentage()).ToList();
                    }
                    break;
                case "Persentage (99-0, 100)":
                    {
                        for (int j = 0; j < list.Count; j++)
                            for (int i = 0; i < list.Count - 1; i++)
                            {
                                if (list[i].getPersentage() < list[i + 1].getPersentage() && list[i + 1].isPersentage() != Franchise.FranchisePersentage.Full)
                                {
                                    Franchise fr = list[i];
                                    list[i] = list[i + 1];
                                    list[i + 1] = fr;
                                }
                                if (list[i].isPersentage() == Franchise.FranchisePersentage.Full)
                                {
                                    Franchise fr = list[i];
                                    list[i] = list[i + 1];
                                    list[i + 1] = fr;
                                }
                            }
                    }
                    break;
                case "BPS":
                    {
                        list = list.OrderBy(x => x.getBPS()).ToList();
                    }
                    break;
                case "Date":
                    {
                        list = list.OrderBy(x => x.getStartingDate()).ToList();
                    }
                    break;
                case "Mark":
                    {
                        list = list.OrderBy(x => x.getMark()).ToList();
                    }
                    break;
                default:
                    {

                    }
                    break;
            }
            if (reverseSort)
                list.Reverse();
        }
    }
}
