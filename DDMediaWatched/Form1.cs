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
            controlsNewPart = new List<Control>();

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            foreach (Control el in this.Controls)
                el.KeyDown += new KeyEventHandler(Form1_KeyDown);
            LoadColumnsFranchises();
            LoadColumnsParts();
            FindDiskLetter();
            LoadControls();
            textBoxTitleInfo.Text += Program.pathLetter + "\r\n";
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
                Width = 200
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
                Width = 200
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
                Text = "Path",
                Width = 200
            };
            columns.Add(ch);
            listViewParts.Columns.AddRange(columns.ToArray());
        }

        private void LoadControls()
        {
            controlsNewFranchise.Add(labelNewFranchise1);
            controlsNewFranchise.Add(labelNewFranchise2);
            controlsNewFranchise.Add(labelNewFranchise3);
            controlsNewFranchise.Add(textBoxNewFranchiseNames);
            controlsNewFranchise.Add(textBoxNewFranchisePath);
            controlsNewFranchise.Add(comboBoxNewFranchiseType);
            controlsNewFranchise.Add(buttonNewFranchiseSave);
            controlsInfo.Add(labelInfo);
            controlsInfo.Add(textBoxInfo);
            controlsNewPart.Add(labelNewPart1);
            controlsNewPart.Add(labelNewPart2);
            controlsNewPart.Add(labelNewPart3);
            controlsNewPart.Add(labelNewPart4);
            controlsNewPart.Add(labelNewPart5);
            controlsNewPart.Add(textBoxNewPartName);
            controlsNewPart.Add(textBoxNewPartPath);
            controlsNewPart.Add(textBoxNewPartWidth);
            controlsNewPart.Add(textBoxNewPartHeight);
            controlsNewPart.Add(textBoxNewPartLength);
            controlsNewPart.Add(checkBoxNewPartIsPathFile);
            controlsNewPart.Add(buttonNewPartSave);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadConfigs();
            LoadMedia();
            FranchisesToListView();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F5:
                    {
                        FranchisesToListView();
                    }
                    break;
                case Keys.Escape:
                    {
                        SaveMedia();
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

        private void buttonNewFranchise_Click(object sender, EventArgs e)
        {
            currentFranchise = new Franchise();
            franchises.Add(currentFranchise);
            int p = 0;
            foreach (Franchise franchise in franchises)
                if (franchise.getNumber() > p)
                    p = franchise.getNumber();
            currentFranchise.setNumber(p + 1);
            EditFranchise();
        }

        private void buttonNewFranchiseSave_Click(object sender, EventArgs e)
        {
            ControlsOff(controlsNewFranchise);
            currentFranchise.setNames(textBoxNewFranchiseNames.Text.Split(';'));
            currentFranchise.setPath(textBoxNewFranchisePath.Text);
            currentFranchise.setType(comboBoxNewFranchiseType.SelectedIndex);
            ControlsOn(controlsInfo);
            FranchisesToListView();
        }

        private void buttonNewPart_Click(object sender, EventArgs e)
        {
            if (currentFranchise == null)
                return;
            currentPart = new Part(currentFranchise);
            currentFranchise.getParts().Add(currentPart);
            int p = 0;
            foreach (Part part in currentFranchise.getParts())
                if (part.getNumber() > p)
                    p = part.getNumber();
            currentPart.setNumber(p + 1);
            ControlsOff(controlsInfo);
            ControlsOn(controlsNewPart);
        }

        private void buttonNewPartSave_Click(object sender, EventArgs e)
        {
            ControlsOff(controlsNewPart);
            currentPart.setName(textBoxNewPartName.Text);
            currentPart.setPath(textBoxNewPartPath.Text);
            int p = 0;
            int.TryParse(textBoxNewPartWidth.Text, out p);
            currentPart.setWidth(p);
            p = 0;
            int.TryParse(textBoxNewPartHeight.Text, out p);
            currentPart.setHeight(p);
            if (!String.IsNullOrEmpty(textBoxNewPartLength.Text))
            {
                p = 0;
                int.TryParse(textBoxNewPartLength.Text, out p);
                currentPart.setCommonLength(p);
            }
            currentPart.setIsPathFile(checkBoxNewPartIsPathFile.Checked);
            currentPart.findSize();
            ControlsOn(controlsInfo);
            currentPart = null;
            PartsToListView();
        }

        private void listViewTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTitles.SelectedItems.Count < 1)
            {
                SelectNone();
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

        private void buttonEditFranchise_Click(object sender, EventArgs e)
        {
            if (listViewTitles.SelectedItems.Count > 0)
            {
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

        private void buttonEditPart_Click(object sender, EventArgs e)
        {
            if (listViewParts.SelectedItems.Count > 0)
            {
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

        private void EditFranchise()
        {
            ControlsOff(controlsInfo);
            ControlsOn(controlsNewFranchise);
            textBoxNewFranchiseNames.Text = currentFranchise.getAllNames();
            textBoxNewFranchisePath.Text = currentFranchise.getPath();
            comboBoxNewFranchiseType.SelectedIndex = currentFranchise.getTypeInt();
        }

        private void EditPart()
        {
            ControlsOff(controlsInfo);
            ControlsOn(controlsNewPart);
            textBoxNewPartName.Text = currentPart.getName();
            textBoxNewPartPath.Text = currentPart.getPath();
            textBoxNewPartLength.Text = currentPart.getCommonLength().ToString();
            textBoxNewPartWidth.Text = currentPart.getWidth().ToString();
            textBoxNewPartHeight.Text = currentPart.getHeight().ToString();
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

        private void buttonFindPartSize_Click(object sender, EventArgs e)
        {
            if (currentPart == null)
                return;
            currentPart.findSize();
        }

        private void buttonDeletePart_Click(object sender, EventArgs e)
        {
            if (currentPart == null)
                return;
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
        }

        public void FranchisesToListView()
        {
            listViewTitles.Items.Clear();
            foreach (Franchise el in franchises)
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
    }
}
