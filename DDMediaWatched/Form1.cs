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
            controlsSort = new List<Control>();

        public List<Franchise.FranchiseType>
            TypeOn = new List<Franchise.FranchiseType>();

        public static string
            sortBy = "";

        public static bool
            reverseSort = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            checkedListBoxSortTypes.SetItemChecked(0, true);
            checkedListBoxSortTypes.SetItemChecked(1, true);
            checkedListBoxSortTypes.SetItemChecked(2, true);
            checkedListBoxSortTypes.SetItemChecked(3, true);
            foreach (int p in checkedListBoxSortTypes.CheckedIndices)
                TypeOn.Add((Franchise.FranchiseType)p);
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
                DisplayIndex = 1,
                Text = "Name",
                Width = 150
            };
            columns.Add(ch);
            ch = new ColumnHeader
            {
                DisplayIndex = 0,
                Text = "Num",
                Width = 30
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
            listViewTitles.Columns.AddRange(columns.ToArray());
        }

        private void LoadColumnsParts()
        {
            List<ColumnHeader> columns = new List<ColumnHeader>();
            ColumnHeader ch;
            ch = new ColumnHeader
            {
                DisplayIndex = 1,
                Text = "Name",
                Width = 100
            };
            columns.Add(ch);
            ch = new ColumnHeader
            {
                DisplayIndex = 0,
                Text = "Num",
                Width = 30
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
            controlsRightButtons.Add(buttonEditFranchise);
            controlsRightButtons.Add(buttonDeleteFranchise);
            controlsRightButtons.Add(buttonNewPart);
            controlsRightButtons.Add(buttonEditPart);
            controlsRightButtons.Add(buttonDeletePart);
            controlsRightButtons.Add(buttonFindPartSize);
            controlsRightButtons.Add(buttonFindAllSize);
            controlsRightButtons.Add(buttonImport);
            controlsRightButtons.Add(buttonSort);
            controlsSort.Add(groupBoxSort);
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
                        FranchisesToListView();
                        DrawStatistic();
                    }
                    break;
                case Keys.Escape:
                    {
                        Environment.Exit(0);
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
            int p = Program.FileReadInt32(f);
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
            currentFranchise = new Franchise();
            franchises.Add(currentFranchise);
            EditFranchise();
        }

        private void buttonNewFranchiseSave_Click(object sender, EventArgs e)
        {
            ControlsOff(controlsNewFranchise);
            currentFranchise.setNames(textBoxNewFranchiseNames.Text.Split(';'));
            currentFranchise.setPath(textBoxNewFranchisePath.Text);
            currentFranchise.setType(comboBoxNewFranchiseType.SelectedIndex);
            currentFranchise.setStartingDate(textBoxNewFranchiseDate.Text);
            foreach (Part part in currentFranchise.getParts())
                part.findSize();
            ControlsOn(controlsInfo);
            FranchisesToListView();
            ControlsEnable(controlsRightButtons);
        }

        private void buttonEditFranchise_Click(object sender, EventArgs e)
        {
            if (listViewTitles.SelectedItems.Count > 0)
            {
                ControlsDisable(controlsRightButtons);
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

        private void EditFranchise()
        {
            ControlsOff(controlsInfo);
            ControlsOn(controlsNewFranchise);
            textBoxNewFranchiseNames.Text = currentFranchise.getAllNames();
            textBoxNewFranchisePath.Text = currentFranchise.getPath();
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
            MessageBox.Show("I'm so sorry, but this function don't work :(", "Error");
        }

        private void addFullWatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFranchise == null)
                return;
            foreach (Part p in currentFranchise.getParts())
                p.addWatch();
        }
        //Edit Part
        private void buttonNewPart_Click(object sender, EventArgs e)
        {
            if (currentFranchise == null)
                return;
            ControlsDisable(controlsRightButtons);
            currentPart = new Part(currentFranchise);
            currentFranchise.getParts().Add(currentPart);
            int p = 0;
            foreach (Part part in currentFranchise.getParts())
                if (part.getNumber() > p)
                    p = part.getNumber();
            currentPart.setNumber(p + 1);
            EditPart();
        }

        private void buttonNewPartSave_Click(object sender, EventArgs e)
        {
            int len = Program.HMStoSecs(textBoxNewPartLength.Text);
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
            int p = 0;
            int.TryParse(textBoxNewPartWidth.Text, out p);
            currentPart.setWidth(p);
            p = 0;
            int.TryParse(textBoxNewPartHeight.Text, out p);
            currentPart.setHeight(p);
            if (len != -1)
            {
                currentPart.setCommonLength(len);
            }
            currentPart.setIsPathFile(checkBoxNewPartIsPathFile.Checked);
            currentPart.findSize();
            ControlsOn(controlsInfo);
            currentPart = null;
            PartsToListView();
            ControlsEnable(controlsRightButtons);
        }

        private void buttonEditPart_Click(object sender, EventArgs e)
        {
            if (listViewParts.SelectedItems.Count > 0)
            {
                ControlsDisable(controlsRightButtons);
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

        private void EditPart()
        {
            ControlsOff(controlsInfo);
            ControlsOn(controlsNewPart);
            comboBoxNewPartResolutions.SelectedIndex = -1;
            textBoxNewPartName.Text = currentPart.getName();
            textBoxNewPartPath.Text = currentPart.getPath();
            int p = currentPart.getCommonLength();
            textBoxNewPartLength.Text = String.Format("{0}:{1}:{2}", p / 3600, p / 60 % 60, p % 60);
            textBoxNewPartWidth.Text = currentPart.getWidth().ToString();
            textBoxNewPartHeight.Text = currentPart.getHeight().ToString();
            numericUpDownNewPartSeries.Value = currentPart.getSeries().Count();
            checkBoxNewPartIsPathFile.Checked = currentPart.isFull();
            MakeNewPartLengths();
            MakeNewPartCOW();
        }

        private void textBoxNewPartLength_TextChanged(object sender, EventArgs e)
        {
            int p = Program.HMStoSecs(textBoxNewPartLength.Text);
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
                textBoxNewPartLength.Text = Program.GetVideoLength(currentPart.getAbsolutePath());
            }
            else
            {
                numericUpDownNewPartSeries.Enabled = true;
                textBoxNewPartLengths.Enabled = true;
            }
        }

        private void comboBoxNewPartResolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxNewPartResolutions.Text)
            {
                case "NULL":
                    {
                        currentPart.setWidth(0);
                        currentPart.setHeight(0);
                    }
                    break;
                case "960x720":
                    {
                        currentPart.setWidth(960);
                        currentPart.setHeight(720);
                    }
                    break;
                case "1280x720":
                    {
                        currentPart.setWidth(1280);
                        currentPart.setHeight(720);
                    }
                    break;
                case "1920x1080":
                    {
                        currentPart.setWidth(1920);
                        currentPart.setHeight(1080);
                    }
                    break;
                case "3840x2160":
                    {
                        currentPart.setWidth(3840);
                        currentPart.setHeight(2160);
                    }
                    break;
            }
            textBoxNewPartWidth.Text = currentPart.getWidth().ToString();
            textBoxNewPartHeight.Text = currentPart.getHeight().ToString();
        }

        private void textBoxNewPartPath_TextChanged(object sender, EventArgs e)
        {
            string path = textBoxNewPartPath.Text;
            if (path.Length > 0)
                if (path[0] == '"')
                    path = path.Substring(1, path.Length - 2);
            int p = Program.IsFileOrDirr(path);
            if (p == 0)
            {
                checkBoxNewPartIsPathFile.Checked = false;
            }
            if (p == 1)
            {
                checkBoxNewPartIsPathFile.Checked = true;
            }
        }
        //ContexParts
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I'm so sorry, but this function don't work :(", "Error");
        }

        private void addFullViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentPart == null)
                return;
            currentPart.addWatch();
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

        private void buttonFindPartSize_Click(object sender, EventArgs e)
        {
            if (currentPart == null)
                return;
            currentPart.findSize();
        }

        private void buttonFindAllSize_Click(object sender, EventArgs e)
        {
            if (Program.pathLetter == "null")
            {
                MessageBox.Show("There isn't media volume!", "Error");
            }
            else
            {
                foreach (Franchise franchise in franchises)
                {
                    foreach (Part part in franchise.getParts())
                        part.findSize();
                }
                Log("All size has been updated!");
            }
        }

        private void buttonDeletePart_Click(object sender, EventArgs e)
        {
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

        private void buttonDeleteFranchise_Click(object sender, EventArgs e)
        {
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveMedia();
        }

        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            listViewParts.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
            listViewTitles.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
            textBoxTitleInfo.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
            textBoxPartInfo.Font = new Font("Consolas", (float)numericUpDownFontSize.Value);
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] s = File.ReadAllLines(openFileDialog1.FileName);
                foreach (string p in s)
                    franchises.Add(new Franchise(p.Split('|')));
                SelectNone();
                FranchisesToListView();
            }
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
            TypeOn.Clear();
            foreach (int p in checkedListBoxSortTypes.CheckedIndices)
                TypeOn.Add((Franchise.FranchiseType)p);
            FranchisesToListView();
            ControlsEnable(controlsRightButtons);
        }

        private void comboBoxSortSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            sortBy = comboBoxSortSortBy.Text;
        }

        private void checkBoxSortReverse_CheckedChanged(object sender, EventArgs e)
        {
            reverseSort = checkBoxSortReverse.Checked;
        }

        private void buttonBackUP_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            File.Copy(path + "Media.bin", path + String.Format("Media - {0}.bin", dt.ToString("yyyy.MM.dd HH.mm.ss")));
            MessageBox.Show("BackUP has been created!", "Success");
        }

        public void FranchisesToListView()
        {
            listViewTitles.Items.Clear();
            List<Franchise> franchisesType = new List<Franchise>();
            foreach (Franchise el in franchises)
                if (IsTypeOn(el))
                    franchisesType.Add(el);
            switch (sortBy)
            {
                case "Name":
                    {
                        franchisesType = franchisesType.OrderBy(x => x.getName()).ToList();
                    }
                    break;
                case "Size":
                    {
                        franchisesType = franchisesType.OrderBy(x => x.getSize()).ToList();
                    }
                    break;
                case "Length":
                    {
                        franchisesType = franchisesType.OrderBy(x => x.getLength()).ToList();
                    }
                    break;
                case "BPS":
                    {
                        franchisesType = franchisesType.OrderBy(x => x.getBPS()).ToList();
                    }
                    break;
                case "Date":
                    {
                        franchisesType = franchisesType.OrderBy(x => x.getStartingDate()).ToList();
                    }
                    break;
                case "Mark":
                    {
                        franchisesType = franchisesType.OrderBy(x => x.getMark()).ToList();
                    }
                    break;
                default:
                    {

                    }
                    break;
            }
            if (reverseSort)
                franchisesType.Reverse();
            foreach (Franchise el in franchisesType)
            {
                ListViewItem item = new ListViewItem()
                {
                    Text = el.getName()
                };
                ListViewItem.ListViewSubItem si;
                int p = 0;
                //Number
                si = new ListViewItem.ListViewSubItem
                {
                    Tag = "Number"
                };
                p = el.getNumber();
                if (p > 0)
                    si.Text = p.ToString();
                else
                    si.Text = "";
                item.SubItems.Add(si);
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
                int p = 0;
                //Number
                si = new ListViewItem.ListViewSubItem
                {
                    Tag = "Number"
                };
                p = el.getNumber();
                if (p > 0)
                    si.Text = p.ToString();
                else
                    si.Text = "";
                item.SubItems.Add(si);
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
            s += String.Format("{0,-20}: {1,8:f2} GB  \r\n", "Size Total", size / 1024d / 1024 / 1024);
            s += String.Format("{0,-20}: {1,8:f2} Hour| {2,8:f2} days\r\n", "Watched", watchedLength / 60d / 60, watchedLength / 60d / 60 / 24);
            s += String.Format("{0,-20}: {1,8:f2} Hour| {2,8:f2} days\r\n", "Watched Unique", watchedUniqueLength / 60d / 60, watchedUniqueLength / 60d / 60 / 24);
            textBoxInfo.Text = s;
        }

        public bool IsTypeOn(Franchise el)
        {
            bool b = false;
            if (TypeOn.Contains(el.getType()))
                b = true;
            return b;
        }

        public void Log(string s)
        {
            textBoxLog.Text += s + "\r\n";
        }
    }
}
