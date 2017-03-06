﻿using DualMeetManager.Business.Managers;
using DualMeetManager.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DualMeetManager.Presentation
{
    public partial class RelayEventEntry : Form
    {
        MeetHub mh;
        Dictionary<string, string> teamNames = new Dictionary<string, string>();
        int currentHeatNum = 0;
        string eventName;

        List<Performance> allPerfs = new List<Performance>();
        //OrderedDictionary perfs = new OrderedDictionary
        //Dictionary<int, List<Performance>> perfs = new Dictionary<int, List<Performance>>();
        EventMgr em = new EventMgr();

        public RelayEventEntry()
        {
            InitializeComponent();
        }

        public RelayEventEntry(MeetHub mh, string eventName, List<Performance> allPerfs, Dictionary<string, string> teamNames) : this()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + "Parameterized Constructor");
            this.mh = mh;
            this.eventName = eventName;
            this.teamNames = teamNames;
            this.allPerfs = allPerfs;
            if (allPerfs == null)
            {
                Console.WriteLine("allPerfs is equal to null");
            }
            else
            {
                foreach (Performance p in allPerfs)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            Console.WriteLine("Leaving " + GetType().Name + " - " + "Parameterized Constructor");
        }

        private void mnuPrintout_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                PrintoutMgr pm = new PrintoutMgr();
                GatherPerfs();
                SortListOfPerfs();
                pm.CreateIndEventDoc(eventName, allPerfs);
            }
        }

        private void GatherPerfs()
        {
            if (allPerfs != null)
                allPerfs.Clear();
            else
                allPerfs = new List<Performance>();

            if (!string.IsNullOrWhiteSpace(txtName1.Text))
                allPerfs.Add(new Performance(txtName1.Text, cboSchool1.Text, em.ConvertFromTimedData(txtPerf1.Text)));
            if (!string.IsNullOrWhiteSpace(txtName2.Text))
                allPerfs.Add(new Performance(txtName2.Text, cboSchool2.Text, em.ConvertFromTimedData(txtPerf2.Text)));
            if (!string.IsNullOrWhiteSpace(txtName3.Text))
                allPerfs.Add(new Performance(txtName3.Text, cboSchool3.Text, em.ConvertFromTimedData(txtPerf3.Text)));
            if (!string.IsNullOrWhiteSpace(txtName4.Text))
                allPerfs.Add(new Performance(txtName4.Text, cboSchool4.Text, em.ConvertFromTimedData(txtPerf4.Text)));
            if (!string.IsNullOrWhiteSpace(txtName5.Text))
                allPerfs.Add(new Performance(txtName5.Text, cboSchool5.Text, em.ConvertFromTimedData(txtPerf5.Text)));
            if (!string.IsNullOrWhiteSpace(txtName6.Text))
                allPerfs.Add(new Performance(txtName6.Text, cboSchool6.Text, em.ConvertFromTimedData(txtPerf6.Text)));

            if (!string.IsNullOrWhiteSpace(txtName17.Text))
                allPerfs.Add(new Performance(txtName17.Text, cboSchool17.Text, em.ConvertFromTimedData(txtPerf17.Text)));
            if (!string.IsNullOrWhiteSpace(txtName18.Text))
                allPerfs.Add(new Performance(txtName18.Text, cboSchool18.Text, em.ConvertFromTimedData(txtPerf18.Text)));
            if (!string.IsNullOrWhiteSpace(txtName19.Text))
                allPerfs.Add(new Performance(txtName19.Text, cboSchool19.Text, em.ConvertFromTimedData(txtPerf19.Text)));
            if (!string.IsNullOrWhiteSpace(txtName20.Text))
                allPerfs.Add(new Performance(txtName20.Text, cboSchool20.Text, em.ConvertFromTimedData(txtPerf20.Text)));
            if (!string.IsNullOrWhiteSpace(txtName21.Text))
                allPerfs.Add(new Performance(txtName21.Text, cboSchool21.Text, em.ConvertFromTimedData(txtPerf21.Text)));
            if (!string.IsNullOrWhiteSpace(txtName22.Text))
                allPerfs.Add(new Performance(txtName22.Text, cboSchool22.Text, em.ConvertFromTimedData(txtPerf22.Text)));
            if (!string.IsNullOrWhiteSpace(txtName23.Text))
                allPerfs.Add(new Performance(txtName23.Text, cboSchool23.Text, em.ConvertFromTimedData(txtPerf23.Text)));
            if (!string.IsNullOrWhiteSpace(txtName24.Text))
                allPerfs.Add(new Performance(txtName24.Text, cboSchool24.Text, em.ConvertFromTimedData(txtPerf24.Text)));
            if (!string.IsNullOrWhiteSpace(txtName25.Text))
                allPerfs.Add(new Performance(txtName25.Text, cboSchool25.Text, em.ConvertFromTimedData(txtPerf25.Text)));
            if (!string.IsNullOrWhiteSpace(txtName26.Text))
                allPerfs.Add(new Performance(txtName26.Text, cboSchool26.Text, em.ConvertFromTimedData(txtPerf26.Text)));
            if (!string.IsNullOrWhiteSpace(txtName27.Text))
                allPerfs.Add(new Performance(txtName27.Text, cboSchool27.Text, em.ConvertFromTimedData(txtPerf27.Text)));
            if (!string.IsNullOrWhiteSpace(txtName28.Text))
                allPerfs.Add(new Performance(txtName28.Text, cboSchool28.Text, em.ConvertFromTimedData(txtPerf28.Text)));
            if (!string.IsNullOrWhiteSpace(txtName29.Text))
                allPerfs.Add(new Performance(txtName29.Text, cboSchool29.Text, em.ConvertFromTimedData(txtPerf29.Text)));
            if (!string.IsNullOrWhiteSpace(txtName30.Text))
                allPerfs.Add(new Performance(txtName30.Text, cboSchool30.Text, em.ConvertFromTimedData(txtPerf30.Text)));
            if (!string.IsNullOrWhiteSpace(txtName31.Text))
                allPerfs.Add(new Performance(txtName31.Text, cboSchool31.Text, em.ConvertFromTimedData(txtPerf31.Text)));
            if (!string.IsNullOrWhiteSpace(txtName32.Text))
                allPerfs.Add(new Performance(txtName32.Text, cboSchool32.Text, em.ConvertFromTimedData(txtPerf32.Text)));

            SortListOfPerfs();
        }

        private void mnuClearThis_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to clear all data from this event?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                ClearAll();
        }

        private void grpHeats1_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Sorts the List of Performances in Ascending Order
        /// </summary>
        private void SortListOfPerfs()
        {
            if (allPerfs != null && allPerfs.Count > 0)
            {
                allPerfs = allPerfs.OrderBy(o => o.performance).ToList();
            }
        }

        private void PopulateTeams()
        {
            cboSchool1.Items.Add("");
            cboSchool2.Items.Add("");
            cboSchool3.Items.Add("");
            cboSchool4.Items.Add("");
            cboSchool5.Items.Add("");
            cboSchool6.Items.Add("");
            cboSchool17.Items.Add("");
            cboSchool18.Items.Add("");
            cboSchool19.Items.Add("");
            cboSchool20.Items.Add("");
            cboSchool21.Items.Add("");
            cboSchool22.Items.Add("");
            cboSchool23.Items.Add("");
            cboSchool24.Items.Add("");
            cboSchool25.Items.Add("");
            cboSchool26.Items.Add("");
            cboSchool27.Items.Add("");
            cboSchool28.Items.Add("");
            cboSchool29.Items.Add("");
            cboSchool30.Items.Add("");
            cboSchool31.Items.Add("");
            cboSchool32.Items.Add("");
            foreach (string s in teamNames.Keys)
            {
                cboSchool1.Items.Add(s);
                cboSchool2.Items.Add(s);
                cboSchool3.Items.Add(s);
                cboSchool4.Items.Add(s);
                cboSchool5.Items.Add(s);
                cboSchool6.Items.Add(s);
                cboSchool17.Items.Add(s);
                cboSchool18.Items.Add(s);
                cboSchool19.Items.Add(s);
                cboSchool20.Items.Add(s);
                cboSchool21.Items.Add(s);
                cboSchool22.Items.Add(s);
                cboSchool23.Items.Add(s);
                cboSchool24.Items.Add(s);
                cboSchool25.Items.Add(s);
                cboSchool26.Items.Add(s);
                cboSchool27.Items.Add(s);
                cboSchool28.Items.Add(s);
                cboSchool29.Items.Add(s);
                cboSchool30.Items.Add(s);
                cboSchool31.Items.Add(s);
                cboSchool32.Items.Add(s);
            }
        }

        private bool CheckData()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Check that every athlete 1-32 has either no values or all values
            if ((string.IsNullOrWhiteSpace(txtName1.Text) && (!string.IsNullOrWhiteSpace(cboSchool1.Text) || !string.IsNullOrWhiteSpace(txtPerf1.Text))) ||
                (string.IsNullOrWhiteSpace(cboSchool1.Text) && (!string.IsNullOrWhiteSpace(txtName1.Text) || !string.IsNullOrWhiteSpace(txtPerf1.Text))) ||
                (string.IsNullOrWhiteSpace(txtPerf1.Text) && (!string.IsNullOrWhiteSpace(cboSchool1.Text) || !string.IsNullOrWhiteSpace(txtName1.Text))))
            {
                MessageBox.Show("Incomplete data for Athlete #1", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName2.Text) && string.IsNullOrWhiteSpace(cboSchool2.Text) && string.IsNullOrWhiteSpace(txtPerf2.Text)) ||
                (string.IsNullOrWhiteSpace(txtName2.Text) && !string.IsNullOrWhiteSpace(cboSchool2.Text) && string.IsNullOrWhiteSpace(txtPerf2.Text)) ||
                (string.IsNullOrWhiteSpace(txtName2.Text) && string.IsNullOrWhiteSpace(cboSchool2.Text) && !string.IsNullOrWhiteSpace(txtPerf2.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #2", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName3.Text) && string.IsNullOrWhiteSpace(cboSchool3.Text) && string.IsNullOrWhiteSpace(txtPerf3.Text)) ||
                (string.IsNullOrWhiteSpace(txtName3.Text) && !string.IsNullOrWhiteSpace(cboSchool3.Text) && string.IsNullOrWhiteSpace(txtPerf3.Text)) ||
                (string.IsNullOrWhiteSpace(txtName3.Text) && string.IsNullOrWhiteSpace(cboSchool3.Text) && !string.IsNullOrWhiteSpace(txtPerf3.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #3", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName4.Text) && string.IsNullOrWhiteSpace(cboSchool4.Text) && string.IsNullOrWhiteSpace(txtPerf4.Text)) ||
                (string.IsNullOrWhiteSpace(txtName4.Text) && !string.IsNullOrWhiteSpace(cboSchool4.Text) && string.IsNullOrWhiteSpace(txtPerf4.Text)) ||
                (string.IsNullOrWhiteSpace(txtName4.Text) && string.IsNullOrWhiteSpace(cboSchool4.Text) && !string.IsNullOrWhiteSpace(txtPerf4.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #4", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName5.Text) && string.IsNullOrWhiteSpace(cboSchool5.Text) && string.IsNullOrWhiteSpace(txtPerf5.Text)) ||
                (string.IsNullOrWhiteSpace(txtName5.Text) && !string.IsNullOrWhiteSpace(cboSchool5.Text) && string.IsNullOrWhiteSpace(txtPerf5.Text)) ||
                (string.IsNullOrWhiteSpace(txtName5.Text) && string.IsNullOrWhiteSpace(cboSchool5.Text) && !string.IsNullOrWhiteSpace(txtPerf5.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #5", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName6.Text) && string.IsNullOrWhiteSpace(cboSchool6.Text) && string.IsNullOrWhiteSpace(txtPerf6.Text)) ||
                (string.IsNullOrWhiteSpace(txtName6.Text) && !string.IsNullOrWhiteSpace(cboSchool6.Text) && string.IsNullOrWhiteSpace(txtPerf6.Text)) ||
                (string.IsNullOrWhiteSpace(txtName6.Text) && string.IsNullOrWhiteSpace(cboSchool6.Text) && !string.IsNullOrWhiteSpace(txtPerf6.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #6", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName17.Text) && string.IsNullOrWhiteSpace(cboSchool17.Text) && string.IsNullOrWhiteSpace(txtPerf17.Text)) ||
                (string.IsNullOrWhiteSpace(txtName17.Text) && !string.IsNullOrWhiteSpace(cboSchool17.Text) && string.IsNullOrWhiteSpace(txtPerf17.Text)) ||
                (string.IsNullOrWhiteSpace(txtName17.Text) && string.IsNullOrWhiteSpace(cboSchool17.Text) && !string.IsNullOrWhiteSpace(txtPerf17.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #17", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName18.Text) && string.IsNullOrWhiteSpace(cboSchool18.Text) && string.IsNullOrWhiteSpace(txtPerf18.Text)) ||
                (string.IsNullOrWhiteSpace(txtName18.Text) && !string.IsNullOrWhiteSpace(cboSchool18.Text) && string.IsNullOrWhiteSpace(txtPerf18.Text)) ||
                (string.IsNullOrWhiteSpace(txtName18.Text) && string.IsNullOrWhiteSpace(cboSchool18.Text) && !string.IsNullOrWhiteSpace(txtPerf18.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #18", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName19.Text) && string.IsNullOrWhiteSpace(cboSchool19.Text) && string.IsNullOrWhiteSpace(txtPerf19.Text)) ||
                (string.IsNullOrWhiteSpace(txtName19.Text) && !string.IsNullOrWhiteSpace(cboSchool19.Text) && string.IsNullOrWhiteSpace(txtPerf19.Text)) ||
                (string.IsNullOrWhiteSpace(txtName19.Text) && string.IsNullOrWhiteSpace(cboSchool19.Text) && !string.IsNullOrWhiteSpace(txtPerf19.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #19", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName20.Text) && string.IsNullOrWhiteSpace(cboSchool20.Text) && string.IsNullOrWhiteSpace(txtPerf20.Text)) ||
                (string.IsNullOrWhiteSpace(txtName20.Text) && !string.IsNullOrWhiteSpace(cboSchool20.Text) && string.IsNullOrWhiteSpace(txtPerf20.Text)) ||
                (string.IsNullOrWhiteSpace(txtName20.Text) && string.IsNullOrWhiteSpace(cboSchool20.Text) && !string.IsNullOrWhiteSpace(txtPerf20.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #20", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName21.Text) && string.IsNullOrWhiteSpace(cboSchool21.Text) && string.IsNullOrWhiteSpace(txtPerf21.Text)) ||
                (string.IsNullOrWhiteSpace(txtName21.Text) && !string.IsNullOrWhiteSpace(cboSchool21.Text) && string.IsNullOrWhiteSpace(txtPerf21.Text)) ||
                (string.IsNullOrWhiteSpace(txtName21.Text) && string.IsNullOrWhiteSpace(cboSchool21.Text) && !string.IsNullOrWhiteSpace(txtPerf21.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #21", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName22.Text) && string.IsNullOrWhiteSpace(cboSchool22.Text) && string.IsNullOrWhiteSpace(txtPerf22.Text)) ||
                (string.IsNullOrWhiteSpace(txtName22.Text) && !string.IsNullOrWhiteSpace(cboSchool22.Text) && string.IsNullOrWhiteSpace(txtPerf22.Text)) ||
                (string.IsNullOrWhiteSpace(txtName22.Text) && string.IsNullOrWhiteSpace(cboSchool22.Text) && !string.IsNullOrWhiteSpace(txtPerf22.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #22", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName23.Text) && string.IsNullOrWhiteSpace(cboSchool23.Text) && string.IsNullOrWhiteSpace(txtPerf23.Text)) ||
                (string.IsNullOrWhiteSpace(txtName23.Text) && !string.IsNullOrWhiteSpace(cboSchool23.Text) && string.IsNullOrWhiteSpace(txtPerf23.Text)) ||
                (string.IsNullOrWhiteSpace(txtName23.Text) && string.IsNullOrWhiteSpace(cboSchool23.Text) && !string.IsNullOrWhiteSpace(txtPerf23.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #23", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName24.Text) && string.IsNullOrWhiteSpace(cboSchool24.Text) && string.IsNullOrWhiteSpace(txtPerf24.Text)) ||
                (string.IsNullOrWhiteSpace(txtName24.Text) && !string.IsNullOrWhiteSpace(cboSchool24.Text) && string.IsNullOrWhiteSpace(txtPerf24.Text)) ||
                (string.IsNullOrWhiteSpace(txtName24.Text) && string.IsNullOrWhiteSpace(cboSchool24.Text) && !string.IsNullOrWhiteSpace(txtPerf24.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #24", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName25.Text) && string.IsNullOrWhiteSpace(cboSchool25.Text) && string.IsNullOrWhiteSpace(txtPerf25.Text)) ||
                (string.IsNullOrWhiteSpace(txtName25.Text) && !string.IsNullOrWhiteSpace(cboSchool25.Text) && string.IsNullOrWhiteSpace(txtPerf25.Text)) ||
                (string.IsNullOrWhiteSpace(txtName25.Text) && string.IsNullOrWhiteSpace(cboSchool25.Text) && !string.IsNullOrWhiteSpace(txtPerf25.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #25", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName26.Text) && string.IsNullOrWhiteSpace(cboSchool26.Text) && string.IsNullOrWhiteSpace(txtPerf26.Text)) ||
                (string.IsNullOrWhiteSpace(txtName26.Text) && !string.IsNullOrWhiteSpace(cboSchool26.Text) && string.IsNullOrWhiteSpace(txtPerf26.Text)) ||
                (string.IsNullOrWhiteSpace(txtName26.Text) && string.IsNullOrWhiteSpace(cboSchool26.Text) && !string.IsNullOrWhiteSpace(txtPerf26.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #26", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName27.Text) && string.IsNullOrWhiteSpace(cboSchool27.Text) && string.IsNullOrWhiteSpace(txtPerf27.Text)) ||
                (string.IsNullOrWhiteSpace(txtName27.Text) && !string.IsNullOrWhiteSpace(cboSchool27.Text) && string.IsNullOrWhiteSpace(txtPerf27.Text)) ||
                (string.IsNullOrWhiteSpace(txtName27.Text) && string.IsNullOrWhiteSpace(cboSchool27.Text) && !string.IsNullOrWhiteSpace(txtPerf27.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #27", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName28.Text) && string.IsNullOrWhiteSpace(cboSchool28.Text) && string.IsNullOrWhiteSpace(txtPerf28.Text)) ||
                (string.IsNullOrWhiteSpace(txtName28.Text) && !string.IsNullOrWhiteSpace(cboSchool28.Text) && string.IsNullOrWhiteSpace(txtPerf28.Text)) ||
                (string.IsNullOrWhiteSpace(txtName28.Text) && string.IsNullOrWhiteSpace(cboSchool28.Text) && !string.IsNullOrWhiteSpace(txtPerf28.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #28", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName29.Text) && string.IsNullOrWhiteSpace(cboSchool29.Text) && string.IsNullOrWhiteSpace(txtPerf29.Text)) ||
                (string.IsNullOrWhiteSpace(txtName29.Text) && !string.IsNullOrWhiteSpace(cboSchool29.Text) && string.IsNullOrWhiteSpace(txtPerf29.Text)) ||
                (string.IsNullOrWhiteSpace(txtName29.Text) && string.IsNullOrWhiteSpace(cboSchool29.Text) && !string.IsNullOrWhiteSpace(txtPerf29.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #29", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName30.Text) && string.IsNullOrWhiteSpace(cboSchool30.Text) && string.IsNullOrWhiteSpace(txtPerf30.Text)) ||
                (string.IsNullOrWhiteSpace(txtName30.Text) && !string.IsNullOrWhiteSpace(cboSchool30.Text) && string.IsNullOrWhiteSpace(txtPerf30.Text)) ||
                (string.IsNullOrWhiteSpace(txtName30.Text) && string.IsNullOrWhiteSpace(cboSchool30.Text) && !string.IsNullOrWhiteSpace(txtPerf30.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #30", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName31.Text) && string.IsNullOrWhiteSpace(cboSchool31.Text) && string.IsNullOrWhiteSpace(txtPerf31.Text)) ||
                (string.IsNullOrWhiteSpace(txtName31.Text) && !string.IsNullOrWhiteSpace(cboSchool31.Text) && string.IsNullOrWhiteSpace(txtPerf31.Text)) ||
                (string.IsNullOrWhiteSpace(txtName31.Text) && string.IsNullOrWhiteSpace(cboSchool31.Text) && !string.IsNullOrWhiteSpace(txtPerf31.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #31", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName32.Text) && string.IsNullOrWhiteSpace(cboSchool32.Text) && string.IsNullOrWhiteSpace(txtPerf32.Text)) ||
                (string.IsNullOrWhiteSpace(txtName32.Text) && !string.IsNullOrWhiteSpace(cboSchool32.Text) && string.IsNullOrWhiteSpace(txtPerf32.Text)) ||
                (string.IsNullOrWhiteSpace(txtName32.Text) && string.IsNullOrWhiteSpace(cboSchool32.Text) && !string.IsNullOrWhiteSpace(txtPerf32.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #32", "Invalid Data");
                return false;
            }

            //Check for invalid performances
            if (!txtPerf1.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf1.Text.IndexOf(':') != txtPerf1.Text.LastIndexOf(':') || txtPerf1.Text.IndexOf('.') != txtPerf1.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #1 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf2.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf2.Text.IndexOf(':') != txtPerf2.Text.LastIndexOf(':') || txtPerf2.Text.IndexOf('.') != txtPerf2.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #2 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf3.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf3.Text.IndexOf(':') != txtPerf3.Text.LastIndexOf(':') || txtPerf3.Text.IndexOf('.') != txtPerf3.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #3 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf4.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf4.Text.IndexOf(':') != txtPerf4.Text.LastIndexOf(':') || txtPerf4.Text.IndexOf('.') != txtPerf4.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #4 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf5.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf5.Text.IndexOf(':') != txtPerf5.Text.LastIndexOf(':') || txtPerf5.Text.IndexOf('.') != txtPerf5.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #5 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf6.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf6.Text.IndexOf(':') != txtPerf6.Text.LastIndexOf(':') || txtPerf6.Text.IndexOf('.') != txtPerf6.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #6 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf17.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf17.Text.IndexOf(':') != txtPerf17.Text.LastIndexOf(':') || txtPerf17.Text.IndexOf('.') != txtPerf17.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #17 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf18.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf18.Text.IndexOf(':') != txtPerf18.Text.LastIndexOf(':') || txtPerf18.Text.IndexOf('.') != txtPerf18.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #18 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf19.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf19.Text.IndexOf(':') != txtPerf19.Text.LastIndexOf(':') || txtPerf19.Text.IndexOf('.') != txtPerf19.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #19 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf20.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf20.Text.IndexOf(':') != txtPerf20.Text.LastIndexOf(':') || txtPerf20.Text.IndexOf('.') != txtPerf20.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #20 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf21.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf21.Text.IndexOf(':') != txtPerf21.Text.LastIndexOf(':') || txtPerf21.Text.IndexOf('.') != txtPerf21.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #21 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf22.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf22.Text.IndexOf(':') != txtPerf22.Text.LastIndexOf(':') || txtPerf22.Text.IndexOf('.') != txtPerf22.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #22 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf23.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf23.Text.IndexOf(':') != txtPerf23.Text.LastIndexOf(':') || txtPerf23.Text.IndexOf('.') != txtPerf23.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #23 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf24.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf24.Text.IndexOf(':') != txtPerf24.Text.LastIndexOf(':') || txtPerf24.Text.IndexOf('.') != txtPerf24.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #24 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf25.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf25.Text.IndexOf(':') != txtPerf25.Text.LastIndexOf(':') || txtPerf25.Text.IndexOf('.') != txtPerf25.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #25 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf26.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf26.Text.IndexOf(':') != txtPerf26.Text.LastIndexOf(':') || txtPerf26.Text.IndexOf('.') != txtPerf26.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #26 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf27.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf27.Text.IndexOf(':') != txtPerf27.Text.LastIndexOf(':') || txtPerf27.Text.IndexOf('.') != txtPerf27.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #27 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf28.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf28.Text.IndexOf(':') != txtPerf28.Text.LastIndexOf(':') || txtPerf28.Text.IndexOf('.') != txtPerf28.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #28 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf29.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf29.Text.IndexOf(':') != txtPerf29.Text.LastIndexOf(':') || txtPerf29.Text.IndexOf('.') != txtPerf29.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #29 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf30.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf30.Text.IndexOf(':') != txtPerf30.Text.LastIndexOf(':') || txtPerf30.Text.IndexOf('.') != txtPerf30.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #30 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf31.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf31.Text.IndexOf(':') != txtPerf31.Text.LastIndexOf(':') || txtPerf31.Text.IndexOf('.') != txtPerf31.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #31 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf32.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf32.Text.IndexOf(':') != txtPerf32.Text.LastIndexOf(':') || txtPerf32.Text.IndexOf('.') != txtPerf32.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #32 is invalid", "Invalid Data");
                return false;
            }
            if(txtName17.Text == "A Relay" || txtName18.Text == "A Relay" || txtName19.Text == "A Relay" || txtName20.Text == "A Relay" || txtName21.Text == "A Relay" || txtName22.Text == "A Relay" || txtName23.Text == "A Relay" || txtName24.Text == "A Relay" ||
               txtName25.Text == "A Relay" || txtName26.Text == "A Relay" || txtName27.Text == "A Relay" || txtName28.Text == "A Relay" || txtName29.Text == "A Relay" || txtName30.Text == "A Relay" || txtName31.Text == "A Relay" || txtName32.Text == "A Relay")
            {
                MessageBox.Show("Invalid name for a non scoring team", "Invalid Data");
                return false;
            }
            //If all the above errors were ot found, return true
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return true;
        }

        private void ClearAll()
        {
            txtName1.Text = "";
            cboSchool1.Text = "";
            txtPerf1.Text = "";

            txtName2.Text = "";
            cboSchool2.Text = "";
            txtPerf2.Text = "";

            txtName3.Text = "";
            cboSchool3.Text = "";
            txtPerf3.Text = "";

            txtName4.Text = "";
            cboSchool4.Text = "";
            txtPerf4.Text = "";

            txtName5.Text = "";
            cboSchool5.Text = "";
            txtPerf5.Text = "";

            txtName6.Text = "";
            cboSchool6.Text = "";
            txtPerf6.Text = "";

            txtName17.Text = "";
            cboSchool17.Text = "";
            txtPerf17.Text = "";

            txtName18.Text = "";
            cboSchool18.Text = "";
            txtPerf18.Text = "";

            txtName19.Text = "";
            cboSchool19.Text = "";
            txtPerf19.Text = "";

            txtName20.Text = "";
            cboSchool20.Text = "";
            txtPerf20.Text = "";

            txtName21.Text = "";
            cboSchool21.Text = "";
            txtPerf21.Text = "";

            txtName22.Text = "";
            cboSchool22.Text = "";
            txtPerf22.Text = "";

            txtName23.Text = "";
            cboSchool23.Text = "";
            txtPerf23.Text = "";

            txtName24.Text = "";
            cboSchool24.Text = "";
            txtPerf24.Text = "";

            txtName25.Text = "";
            cboSchool25.Text = "";
            txtPerf25.Text = "";

            txtName26.Text = "";
            cboSchool26.Text = "";
            txtPerf26.Text = "";

            txtName27.Text = "";
            cboSchool27.Text = "";
            txtPerf27.Text = "";

            txtName28.Text = "";
            cboSchool28.Text = "";
            txtPerf28.Text = "";

            txtName29.Text = "";
            cboSchool29.Text = "";
            txtPerf29.Text = "";

            txtName30.Text = "";
            cboSchool30.Text = "";
            txtPerf30.Text = "";

            txtName31.Text = "";
            cboSchool31.Text = "";
            txtPerf31.Text = "";

            txtName32.Text = "";
            cboSchool32.Text = "";
            txtPerf32.Text = "";
        }

        private void EnterDataIntoForm()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            ClearAll();

            //Need to seperate scoring and non-scoring performances
            List<Performance> scoringPerfs = new List<Performance>();
            List<Performance> nonScoringPerfs = new List<Performance>();

            foreach(Performance p in allPerfs)
            {
                if(p.athleteName == "A Relay")
                {
                    scoringPerfs.Add(p);
                }
                else
                {
                    nonScoringPerfs.Add(p);
                }
            }

            if (scoringPerfs.ElementAtOrDefault(0) != null)
            {
                txtName1.Text = scoringPerfs[0].athleteName;
                cboSchool1.Text = scoringPerfs[0].schoolName;
                txtPerf1.Text = em.ConvertToTimedData(scoringPerfs[0].performance);
            }
            if (scoringPerfs.ElementAtOrDefault(1) != null)
            {
                txtName2.Text = scoringPerfs[1].athleteName;
                cboSchool2.Text = scoringPerfs[1].schoolName;
                txtPerf2.Text = em.ConvertToTimedData(scoringPerfs[1].performance);
            }
            if (scoringPerfs.ElementAtOrDefault(2) != null)
            {
                txtName3.Text = scoringPerfs[2].athleteName;
                cboSchool3.Text = scoringPerfs[2].schoolName;
                txtPerf3.Text = em.ConvertToTimedData(scoringPerfs[2].performance);
            }
            if (scoringPerfs.ElementAtOrDefault(3) != null)
            {
                txtName4.Text = scoringPerfs[3].athleteName;
                cboSchool4.Text = scoringPerfs[3].schoolName;
                txtPerf4.Text = em.ConvertToTimedData(scoringPerfs[3].performance);
            }
            if (scoringPerfs.ElementAtOrDefault(4) != null)
            {
                txtName5.Text = scoringPerfs[4].athleteName;
                cboSchool5.Text = scoringPerfs[4].schoolName;
                txtPerf5.Text = em.ConvertToTimedData(scoringPerfs[4].performance);
            }
            if (scoringPerfs.ElementAtOrDefault(5) != null)
            {
                txtName6.Text = scoringPerfs[5].athleteName;
                cboSchool6.Text = scoringPerfs[5].schoolName;
                txtPerf6.Text = em.ConvertToTimedData(scoringPerfs[5].performance);
            }

            //ADD NON SCORING PERFS HERE
            if (nonScoringPerfs.ElementAtOrDefault(0) != null)
            {
                txtName17.Text = nonScoringPerfs[0].athleteName;
                cboSchool17.Text = nonScoringPerfs[0].schoolName;
                txtPerf17.Text = em.ConvertToTimedData(nonScoringPerfs[0].performance);
            }
            if (nonScoringPerfs.ElementAtOrDefault(1) != null)
            {
                txtName18.Text = nonScoringPerfs[1].athleteName;
                cboSchool18.Text = nonScoringPerfs[1].schoolName;
                txtPerf18.Text = em.ConvertToTimedData(nonScoringPerfs[1].performance);
            }
            if (nonScoringPerfs.ElementAtOrDefault(2) != null)
            {
                txtName19.Text = nonScoringPerfs[2].athleteName;
                cboSchool19.Text = nonScoringPerfs[2].schoolName;
                txtPerf19.Text = em.ConvertToTimedData(nonScoringPerfs[2].performance);
            }
            if (nonScoringPerfs.ElementAtOrDefault(3) != null)
            {
                txtName20.Text = nonScoringPerfs[3].athleteName;
                cboSchool20.Text = nonScoringPerfs[3].schoolName;
                txtPerf20.Text = em.ConvertToTimedData(nonScoringPerfs[3].performance);
            }
            if (nonScoringPerfs.ElementAtOrDefault(4) != null)
            {
                txtName21.Text = nonScoringPerfs[4].athleteName;
                cboSchool21.Text = nonScoringPerfs[4].schoolName;
                txtPerf21.Text = em.ConvertToTimedData(nonScoringPerfs[4].performance);
            }
            if (nonScoringPerfs.ElementAtOrDefault(5) != null)
            {
                txtName22.Text = nonScoringPerfs[5].athleteName;
                cboSchool22.Text = nonScoringPerfs[5].schoolName;
                txtPerf22.Text = em.ConvertToTimedData(nonScoringPerfs[5].performance);
            }
            if (nonScoringPerfs.ElementAtOrDefault(6) != null)
            {
                txtName23.Text = nonScoringPerfs[6].athleteName;
                cboSchool23.Text = nonScoringPerfs[6].schoolName;
                txtPerf23.Text = em.ConvertToTimedData(nonScoringPerfs[6].performance);
            }
            if (nonScoringPerfs.ElementAtOrDefault(7) != null)
            {
                txtName24.Text = nonScoringPerfs[7].athleteName;
                cboSchool24.Text = nonScoringPerfs[7].schoolName;
                txtPerf24.Text = em.ConvertToTimedData(nonScoringPerfs[7].performance);
            }
            if (nonScoringPerfs.ElementAtOrDefault(8) != null)
            {
                txtName25.Text = nonScoringPerfs[8].athleteName;
                cboSchool25.Text = nonScoringPerfs[8].schoolName;
                txtPerf25.Text = em.ConvertToTimedData(nonScoringPerfs[8].performance);
            }
            if (nonScoringPerfs.ElementAtOrDefault(9) != null)
            {
                txtName26.Text = nonScoringPerfs[9].athleteName;
                cboSchool26.Text = nonScoringPerfs[9].schoolName;
                txtPerf26.Text = em.ConvertToTimedData(nonScoringPerfs[9].performance);
            }
            if (nonScoringPerfs.ElementAtOrDefault(10) != null)
            {
                txtName27.Text = nonScoringPerfs[10].athleteName;
                cboSchool27.Text = nonScoringPerfs[10].schoolName;
                txtPerf27.Text = em.ConvertToTimedData(nonScoringPerfs[10].performance);
            }
            if (nonScoringPerfs.ElementAtOrDefault(11) != null)
            {
                txtName28.Text = nonScoringPerfs[11].athleteName;
                cboSchool28.Text = nonScoringPerfs[11].schoolName;
                txtPerf28.Text = em.ConvertToTimedData(nonScoringPerfs[11].performance);
            }
            if (nonScoringPerfs.ElementAtOrDefault(12) != null)
            {
                txtName29.Text = nonScoringPerfs[12].athleteName;
                cboSchool29.Text = nonScoringPerfs[12].schoolName;
                txtPerf29.Text = em.ConvertToTimedData(nonScoringPerfs[12].performance);
            }
            if (nonScoringPerfs.ElementAtOrDefault(13) != null)
            {
                txtName30.Text = nonScoringPerfs[13].athleteName;
                cboSchool30.Text = nonScoringPerfs[13].schoolName;
                txtPerf30.Text = em.ConvertToTimedData(nonScoringPerfs[13].performance);
            }
            if (nonScoringPerfs.ElementAtOrDefault(14) != null)
            {
                txtName31.Text = nonScoringPerfs[14].athleteName;
                cboSchool31.Text = nonScoringPerfs[14].schoolName;
                txtPerf31.Text = em.ConvertToTimedData(nonScoringPerfs[14].performance);
            }
            if (nonScoringPerfs.ElementAtOrDefault(15) != null)
            {
                txtName32.Text = nonScoringPerfs[15].athleteName;
                cboSchool32.Text = nonScoringPerfs[15].schoolName;
                txtPerf32.Text = em.ConvertToTimedData(nonScoringPerfs[15].performance);
            }

            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void cboSchool1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboSchool1.Text))
                txtName1.Text = "";
            else
                txtName1.Text = "A Relay";
        }

        private void cboSchool2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboSchool2.Text))
                txtName2.Text = "";
            else
                txtName2.Text = "A Relay";
        }

        private void cboSchool3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboSchool3.Text))
                txtName3.Text = "";
            else
                txtName3.Text = "A Relay";
        }

        private void cboSchool4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboSchool4.Text))
                txtName4.Text = "";
            else
                txtName4.Text = "A Relay";
        }

        private void cboSchool5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboSchool5.Text))
                txtName5.Text = "";
            else
                txtName5.Text = "A Relay";
        }

        private void cboSchool6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboSchool6.Text))
                txtName6.Text = "";
            else
                txtName6.Text = "A Relay";
        }

        private void cmdEnterData_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            if (CheckData())
            {
                GatherPerfs();
                MessageBox.Show("Data for " + eventName + " entered", "Success");
                mh.AddEvent(eventName, allPerfs);
                mh.Show();
                this.Close();
            }
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void mnuClear_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to clear data for this event?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                ClearAll();
        }

        private void RelayEventEntry_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            this.Text = eventName + " Entry";
            if (eventName.StartsWith("Boy"))
            {
                BackColor = Color.LightBlue;
            }
            else if (eventName.StartsWith("Girl"))
            {
                BackColor = Color.LightPink;
            }
            PopulateTeams();
            SortListOfPerfs();
            currentHeatNum = 0;
            EnterDataIntoForm();
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
    }
}
