﻿using System;
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
                Width = 200
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
                Width = 20
            };
            columns.Add(ch);
            ch = new ColumnHeader
            {
                Text = "ForWhom",
                Width = 50
            };
            columns.Add(ch);
            ch = new ColumnHeader
            {
                Text = "Mark",
                Width = 50
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
                Width = 150
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

        private void FranchisesToListView()
        {
            menu = MenuState.Start;
            //Clear parts list
            currentPart = null;
            textBoxPartInfo.Text = "Selected None!\r\n";
            listViewParts.Items.Clear();
            //Update franchises list
            currentFranchise = null;
            textBoxTitleInfo.Text = "Selected None!\r\n";
            listViewTitles.Items.Clear();
            List<Franchise> filteredFranchises = Franchise.GetFilteredFranchises(true);
            SortFranchises(ref filteredFranchises);
            ListViewItem[] items = new ListViewItem[filteredFranchises.Count];
            int i = 0;
            foreach (Franchise el in filteredFranchises)
                items[i++] = el.ToListViewItem();
            listViewTitles.Items.AddRange(items);
            DrawStatistic();
        }

        private void PartsToListView()
        {
            menu = MenuState.Parts;
            currentPart = null;
            textBoxPartInfo.Text = "Selected None!\r\n";
            listViewParts.Items.Clear();
            if (currentFranchise == null)
                return;
            listViewParts.Items.AddRange(currentFranchise.GetListViewPartsArray());
        }

        private void DrawStatistic()
        {
            string s = "";
            s += String.Format("FPS: {0}|{1}|{2}\r\n", Franchise.GetCountFranchise(), Franchise.GetCountParts(), Franchise.GetCountSeries());
            s += String.Format("User: {0}\r\n", Profile.User);
            s += String.Format("Current media volume: {0}\r\n", StaticUtils.GetMediaDrivePath());
            int count = Franchise.GetAllCount(false);
            long size = Franchise.GetAllSize(false);
            int watchedLength = Franchise.GetAllWatchedLength(false);
            int watchedUniqueLength = Franchise.GetAllUniqueWatchedLength(false);
            int noTouchedLength = Franchise.GetAllNoTouchedLength(false);
            s += "All:\r\n";
            s += String.Format("{0,-15}:{1,6}\r\n", "Franchises", count);
            s += String.Format("{0,-15}:{1,9:f2} GB  \r\n", "Size Total", size / 1024d / 1024 / 1024);
            s += String.Format("{0,-15}:{1,9:f2} Hour|{2,8:f2} days\r\n", "Watched", watchedLength / 60d / 60, watchedLength / 60d / 60 / 24);
            s += String.Format("{0,-15}:{1,9:f2} Hour|{2,8:f2} days\r\n", "Watched Unique", watchedUniqueLength / 60d / 60, watchedUniqueLength / 60d / 60 / 24);
            s += String.Format("{0,-15}:{1,9:f2} Hour|{2,8:f2} days\r\n", "No touched", noTouchedLength / 60d / 60, noTouchedLength / 60d / 60 / 24);
            count = Franchise.GetAllCount(true);
            size = Franchise.GetAllSize(true);
            watchedLength = Franchise.GetAllWatchedLength(true);
            watchedUniqueLength = Franchise.GetAllUniqueWatchedLength(true);
            noTouchedLength = Franchise.GetAllNoTouchedLength(true);
            s += "Filtered:\r\n";
            s += String.Format("{0,-15}:{1,6}\r\n", "Franchises", count);
            s += String.Format("{0,-15}:{1,9:f2} GB  \r\n", "Size Total", size / 1024d / 1024 / 1024);
            s += String.Format("{0,-15}:{1,9:f2} Hour|{2,8:f2} days\r\n", "Watched", watchedLength / 60d / 60, watchedLength / 60d / 60 / 24);
            s += String.Format("{0,-15}:{1,9:f2} Hour|{2,8:f2} days\r\n", "Watched Unique", watchedUniqueLength / 60d / 60, watchedUniqueLength / 60d / 60 / 24);
            s += String.Format("{0,-15}:{1,9:f2} Hour|{2,8:f2} days\r\n", "No touched", noTouchedLength / 60d / 60, noTouchedLength / 60d / 60 / 24);
            textBoxInfo.Text = s;
        }

        private void SortFranchises(ref List<Franchise> list)
        {
            switch (Franchise.GetSortBy())
            {
                case "Name":
                    {
                        list = list.OrderBy(x => x.GetName()).ToList();
                    }
                    break;
                case "Size":
                    {
                        list = list.OrderBy(x => x.GetSize()).ToList();
                    }
                    break;
                case "Length":
                    {
                        list = list.OrderBy(x => x.GetLength()).ToList();
                    }
                    break;
                case "Watched length":
                    {
                        list = list.OrderBy(x => x.GetWatchedLength()).ToList();
                    }
                    break;
                case "Unique watched length":
                    {
                        list = list.OrderBy(x => x.GetUniqueWatchedLength()).ToList();
                    }
                    break;
                case "Persentage (0-100)":
                    {
                        list = list.OrderBy(x => x.GetPersentage()).ToList();
                    }
                    break;
                case "Persentage (99-0, 100)":
                    {
                        list = list.OrderBy(x => 0 - x.GetPersentage99_0_100()).ToList();
                    }
                    break;
                case "Persentage All":
                    {
                        list = list.OrderBy(x => 0 - x.GetPersentageAll()).ToList();
                    }
                    break;
                case "BPS":
                    {
                        list = list.OrderBy(x => x.GetBPS()).ToList();
                    }
                    break;
                case "Date":
                    {
                        list = list.OrderBy(x => x.GetStartingDate()).ToList();
                    }
                    break;
                case "Mark":
                    {
                        list = list.OrderBy(x => x.Mark).ToList();
                    }
                    break;
                default:
                    {

                    }
                    break;
            }
            if (Franchise.IsReverseSort())
                list.Reverse();
        }
    }
}
