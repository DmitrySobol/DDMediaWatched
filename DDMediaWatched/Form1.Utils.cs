using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DDMediaWatched
{
    partial class Form1
    {
        private void LoadConfigs()
        {
            FileStream fs = new FileStream("config.cfg", FileMode.Open, FileAccess.Read);
            StreamReader t = new StreamReader(fs, Encoding.UTF8);
            Franchise.SetMediaPath(t.ReadLine());
            t.Dispose();
            t.Close();
            fs.Dispose();
            fs.Close();
        }

        private void LoadControls()
        {
            controlsNewFranchise.Add(groupBoxEditFranchise);
            controlsInfo.Add(labelInfo);
            controlsInfo.Add(textBoxInfo);
            controlsNewPart.Add(groupBoxEditPart);
            controlsRightButtons.Add(buttonNewFranchise);
            controlsRightButtons.Add(buttonNewPart);
            controlsRightButtons.Add(buttonSort);
            controlsSort.Add(groupBoxSort);
            controlsListViews.Add(listViewTitles);
            controlsListViews.Add(listViewParts);
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

        public void SelectNone()
        {
            currentFranchise = null;
            textBoxTitleInfo.Text = "Selected None!\r\n";
            currentPart = null;
            textBoxPartInfo.Text = "Selected None!\r\n";
            FranchisesToListView();
            PartsToListView();
        }

        private void ControlsOnVisible(List<Control> controls)
        {
            foreach (Control s in controls)
                s.Visible = true;
        }

        private void ControlsOffVisible(List<Control> controls)
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

        public void FranchisesToListView()
        {
            listViewTitles.Items.Clear();
            List<Franchise> franchisesType = new List<Franchise>();
            foreach (Franchise el in Franchise.franchises)
                if (IsTypeOn(el))
                    franchisesType.Add(el);
            SortFranchises(ref franchisesType);
            foreach (Franchise el in franchisesType)
            {
                ListViewItem item = new ListViewItem()
                {
                    Text = el.getName(),
                    BackColor = StaticUtils.GetColor(colorBy, el)
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
            foreach (Franchise f in Franchise.franchises)
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
