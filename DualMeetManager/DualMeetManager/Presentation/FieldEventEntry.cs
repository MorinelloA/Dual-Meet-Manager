using DualMeetManager.Business.Managers;
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
    public partial class FieldEventEntry : Form
    {
        MeetHub mh;
        Dictionary<string, string> teamNames = new Dictionary<string, string>();
        int currentHeatNum = 0;
        string eventName;

        List<Performance> allPerfs = new List<Performance>();
        //OrderedDictionary perfs = new OrderedDictionary
        //Dictionary<int, List<Performance>> perfs = new Dictionary<int, List<Performance>>();
        EventMgr em = new EventMgr();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FieldEventEntry()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="eventName">Name of the event being entered</param>
        /// <param name="allPerfs">Performances for the event</param>
        public FieldEventEntry(MeetHub mh, string eventName, List<Performance> allPerfs, Dictionary<string, string> teamNames) : this()
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

        private void FieldEventEntry_Load(object sender, EventArgs e)
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

        private void mnuPrintout_Click(object sender, EventArgs e)
        {
            if (AddFlightToList())
            {
                PrintoutMgr pm = new PrintoutMgr();
                SortListOfPerfs();
                pm.CreateIndEventDoc(eventName, allPerfs);
            }
        }

        /// <summary>
        /// /// Clears all data from all objects on the form
        /// </summary>
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

            txtName7.Text = "";
            cboSchool7.Text = "";
            txtPerf7.Text = "";

            txtName8.Text = "";
            cboSchool8.Text = "";
            txtPerf8.Text = "";

            txtName9.Text = "";
            cboSchool9.Text = "";
            txtPerf9.Text = "";

            txtName10.Text = "";
            cboSchool10.Text = "";
            txtPerf10.Text = "";

            txtName11.Text = "";
            cboSchool11.Text = "";
            txtPerf11.Text = "";

            txtName12.Text = "";
            cboSchool12.Text = "";
            txtPerf12.Text = "";

            txtName13.Text = "";
            cboSchool13.Text = "";
            txtPerf13.Text = "";

            txtName14.Text = "";
            cboSchool14.Text = "";
            txtPerf14.Text = "";

            txtName15.Text = "";
            cboSchool15.Text = "";
            txtPerf15.Text = "";

            txtName16.Text = "";
            cboSchool16.Text = "";
            txtPerf16.Text = "";

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

        /// <summary>
        /// Enters data from specific heat (int currentHeatNum) for all objects on the form
        /// </summary>
        /// <remarks>Untested and does not look at other flights</remarks>
        private void EnterDataIntoForm()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            ClearAll();
            if (allPerfs != null)
            {
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 0) != null)
                {
                    txtName1.Text = allPerfs[(currentHeatNum * 32) + 0].athleteName;
                    cboSchool1.Text = allPerfs[(currentHeatNum * 32) + 0].schoolName;
                    txtPerf1.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 0].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 1) != null)
                {
                    txtName2.Text = allPerfs[(currentHeatNum * 32) + 1].athleteName;
                    cboSchool2.Text = allPerfs[(currentHeatNum * 32) + 1].schoolName;
                    txtPerf2.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 1].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 2) != null)
                {
                    txtName3.Text = allPerfs[(currentHeatNum * 32) + 2].athleteName;
                    cboSchool3.Text = allPerfs[(currentHeatNum * 32) + 2].schoolName;
                    txtPerf3.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 2].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 3) != null)
                {
                    txtName4.Text = allPerfs[(currentHeatNum * 32) + 3].athleteName;
                    cboSchool4.Text = allPerfs[(currentHeatNum * 32) + 3].schoolName;
                    txtPerf4.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 3].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 4) != null)
                {
                    txtName5.Text = allPerfs[(currentHeatNum * 32) + 4].athleteName;
                    cboSchool5.Text = allPerfs[(currentHeatNum * 32) + 4].schoolName;
                    txtPerf5.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 4].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 5) != null)
                {
                    txtName6.Text = allPerfs[(currentHeatNum * 32) + 5].athleteName;
                    cboSchool6.Text = allPerfs[(currentHeatNum * 32) + 5].schoolName;
                    txtPerf6.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 5].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 6) != null)
                {
                    txtName7.Text = allPerfs[(currentHeatNum * 32) + 6].athleteName;
                    cboSchool7.Text = allPerfs[(currentHeatNum * 32) + 6].schoolName;
                    txtPerf7.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 6].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 7) != null)
                {
                    txtName8.Text = allPerfs[(currentHeatNum * 32) + 7].athleteName;
                    cboSchool8.Text = allPerfs[(currentHeatNum * 32) + 7].schoolName;
                    txtPerf8.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 7].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 8) != null)
                {
                    txtName9.Text = allPerfs[(currentHeatNum * 32) + 8].athleteName;
                    cboSchool9.Text = allPerfs[(currentHeatNum * 32) + 8].schoolName;
                    txtPerf9.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 8].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 9) != null)
                {
                    txtName10.Text = allPerfs[(currentHeatNum * 32) + 9].athleteName;
                    cboSchool10.Text = allPerfs[(currentHeatNum * 32) + 9].schoolName;
                    txtPerf10.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 9].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 10) != null)
                {
                    txtName11.Text = allPerfs[(currentHeatNum * 32) + 10].athleteName;
                    cboSchool11.Text = allPerfs[(currentHeatNum * 32) + 10].schoolName;
                    txtPerf11.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 10].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 11) != null)
                {
                    txtName12.Text = allPerfs[(currentHeatNum * 32) + 11].athleteName;
                    cboSchool12.Text = allPerfs[(currentHeatNum * 32) + 11].schoolName;
                    txtPerf12.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 11].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 12) != null)
                {
                    txtName13.Text = allPerfs[(currentHeatNum * 32) + 12].athleteName;
                    cboSchool13.Text = allPerfs[(currentHeatNum * 32) + 12].schoolName;
                    txtPerf13.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 12].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 13) != null)
                {
                    txtName14.Text = allPerfs[(currentHeatNum * 32) + 13].athleteName;
                    cboSchool14.Text = allPerfs[(currentHeatNum * 32) + 13].schoolName;
                    txtPerf14.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 13].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 14) != null)
                {
                    txtName15.Text = allPerfs[(currentHeatNum * 32) + 14].athleteName;
                    cboSchool15.Text = allPerfs[(currentHeatNum * 32) + 14].schoolName;
                    txtPerf15.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 14].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 15) != null)
                {
                    txtName16.Text = allPerfs[(currentHeatNum * 32) + 15].athleteName;
                    cboSchool16.Text = allPerfs[(currentHeatNum * 32) + 15].schoolName;
                    txtPerf16.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 15].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 16) != null)
                {
                    txtName17.Text = allPerfs[(currentHeatNum * 32) + 16].athleteName;
                    cboSchool17.Text = allPerfs[(currentHeatNum * 32) + 16].schoolName;
                    txtPerf17.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 16].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 17) != null)
                {
                    txtName18.Text = allPerfs[(currentHeatNum * 32) + 17].athleteName;
                    cboSchool18.Text = allPerfs[(currentHeatNum * 32) + 17].schoolName;
                    txtPerf18.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 17].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 18) != null)
                {
                    txtName19.Text = allPerfs[(currentHeatNum * 32) + 18].athleteName;
                    cboSchool19.Text = allPerfs[(currentHeatNum * 32) + 18].schoolName;
                    txtPerf19.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 18].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 19) != null)
                {
                    txtName20.Text = allPerfs[(currentHeatNum * 32) + 19].athleteName;
                    cboSchool20.Text = allPerfs[(currentHeatNum * 32) + 19].schoolName;
                    txtPerf20.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 19].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 20) != null)
                {
                    txtName21.Text = allPerfs[(currentHeatNum * 32) + 20].athleteName;
                    cboSchool21.Text = allPerfs[(currentHeatNum * 32) + 20].schoolName;
                    txtPerf21.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 20].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 21) != null)
                {
                    txtName22.Text = allPerfs[(currentHeatNum * 32) + 21].athleteName;
                    cboSchool22.Text = allPerfs[(currentHeatNum * 32) + 21].schoolName;
                    txtPerf22.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 21].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 22) != null)
                {
                    txtName23.Text = allPerfs[(currentHeatNum * 32) + 22].athleteName;
                    cboSchool23.Text = allPerfs[(currentHeatNum * 32) + 22].schoolName;
                    txtPerf23.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 22].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 23) != null)
                {
                    txtName24.Text = allPerfs[(currentHeatNum * 32) + 23].athleteName;
                    cboSchool24.Text = allPerfs[(currentHeatNum * 32) + 23].schoolName;
                    txtPerf24.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 23].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 24) != null)
                {
                    txtName25.Text = allPerfs[(currentHeatNum * 32) + 24].athleteName;
                    cboSchool25.Text = allPerfs[(currentHeatNum * 32) + 24].schoolName;
                    txtPerf25.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 24].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 25) != null)
                {
                    txtName26.Text = allPerfs[(currentHeatNum * 32) + 25].athleteName;
                    cboSchool26.Text = allPerfs[(currentHeatNum * 32) + 25].schoolName;
                    txtPerf26.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 25].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 26) != null)
                {
                    txtName27.Text = allPerfs[(currentHeatNum * 32) + 26].athleteName;
                    cboSchool27.Text = allPerfs[(currentHeatNum * 32) + 26].schoolName;
                    txtPerf27.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 26].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 27) != null)
                {
                    txtName28.Text = allPerfs[(currentHeatNum * 32) + 27].athleteName;
                    cboSchool28.Text = allPerfs[(currentHeatNum * 32) + 27].schoolName;
                    txtPerf28.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 27].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 28) != null)
                {
                    txtName29.Text = allPerfs[(currentHeatNum * 32) + 28].athleteName;
                    cboSchool29.Text = allPerfs[(currentHeatNum * 32) + 28].schoolName;
                    txtPerf29.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 28].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 29) != null)
                {
                    txtName30.Text = allPerfs[(currentHeatNum * 32) + 29].athleteName;
                    cboSchool30.Text = allPerfs[(currentHeatNum * 32) + 29].schoolName;
                    txtPerf30.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 29].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 30) != null)
                {
                    txtName31.Text = allPerfs[(currentHeatNum * 32) + 30].athleteName;
                    cboSchool31.Text = allPerfs[(currentHeatNum * 32) + 30].schoolName;
                    txtPerf31.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 30].performance);
                }
                if (allPerfs.ElementAtOrDefault((currentHeatNum * 32) + 31) != null)
                {
                    txtName32.Text = allPerfs[(currentHeatNum * 32) + 31].athleteName;
                    cboSchool32.Text = allPerfs[(currentHeatNum * 32) + 31].schoolName;
                    txtPerf32.Text = em.ConvertToLengthData(allPerfs[(currentHeatNum * 32) + 31].performance);
                }
            }
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// Populate all combo boxes with the team names
        /// </summary>
        private void PopulateTeams()
        {
            cboSchool1.Items.Add("");
            cboSchool2.Items.Add("");
            cboSchool3.Items.Add("");
            cboSchool4.Items.Add("");
            cboSchool5.Items.Add("");
            cboSchool6.Items.Add("");
            cboSchool7.Items.Add("");
            cboSchool8.Items.Add("");
            cboSchool9.Items.Add("");
            cboSchool10.Items.Add("");
            cboSchool11.Items.Add("");
            cboSchool12.Items.Add("");
            cboSchool13.Items.Add("");
            cboSchool14.Items.Add("");
            cboSchool15.Items.Add("");
            cboSchool16.Items.Add("");
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
                cboSchool7.Items.Add(s);
                cboSchool8.Items.Add(s);
                cboSchool9.Items.Add(s);
                cboSchool10.Items.Add(s);
                cboSchool11.Items.Add(s);
                cboSchool12.Items.Add(s);
                cboSchool13.Items.Add(s);
                cboSchool14.Items.Add(s);
                cboSchool15.Items.Add(s);
                cboSchool16.Items.Add(s);
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

        /// <summary>
        /// Check to make sure that the data entered into the form by the user is valid
        /// </summary>
        /// <returns>true if valid, false if invalid</returns>
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
            if ((!string.IsNullOrWhiteSpace(txtName7.Text) && string.IsNullOrWhiteSpace(cboSchool7.Text) && string.IsNullOrWhiteSpace(txtPerf7.Text)) ||
                (string.IsNullOrWhiteSpace(txtName7.Text) && !string.IsNullOrWhiteSpace(cboSchool7.Text) && string.IsNullOrWhiteSpace(txtPerf7.Text)) ||
                (string.IsNullOrWhiteSpace(txtName7.Text) && string.IsNullOrWhiteSpace(cboSchool7.Text) && !string.IsNullOrWhiteSpace(txtPerf7.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #7", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName8.Text) && string.IsNullOrWhiteSpace(cboSchool8.Text) && string.IsNullOrWhiteSpace(txtPerf8.Text)) ||
                (string.IsNullOrWhiteSpace(txtName8.Text) && !string.IsNullOrWhiteSpace(cboSchool8.Text) && string.IsNullOrWhiteSpace(txtPerf8.Text)) ||
                (string.IsNullOrWhiteSpace(txtName8.Text) && string.IsNullOrWhiteSpace(cboSchool8.Text) && !string.IsNullOrWhiteSpace(txtPerf8.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #8", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName9.Text) && string.IsNullOrWhiteSpace(cboSchool9.Text) && string.IsNullOrWhiteSpace(txtPerf9.Text)) ||
                (string.IsNullOrWhiteSpace(txtName9.Text) && !string.IsNullOrWhiteSpace(cboSchool9.Text) && string.IsNullOrWhiteSpace(txtPerf9.Text)) ||
                (string.IsNullOrWhiteSpace(txtName9.Text) && string.IsNullOrWhiteSpace(cboSchool9.Text) && !string.IsNullOrWhiteSpace(txtPerf9.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #9", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName10.Text) && string.IsNullOrWhiteSpace(cboSchool10.Text) && string.IsNullOrWhiteSpace(txtPerf10.Text)) ||
                (string.IsNullOrWhiteSpace(txtName10.Text) && !string.IsNullOrWhiteSpace(cboSchool10.Text) && string.IsNullOrWhiteSpace(txtPerf10.Text)) ||
                (string.IsNullOrWhiteSpace(txtName10.Text) && string.IsNullOrWhiteSpace(cboSchool10.Text) && !string.IsNullOrWhiteSpace(txtPerf10.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #10", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName11.Text) && string.IsNullOrWhiteSpace(cboSchool11.Text) && string.IsNullOrWhiteSpace(txtPerf11.Text)) ||
                (string.IsNullOrWhiteSpace(txtName11.Text) && !string.IsNullOrWhiteSpace(cboSchool11.Text) && string.IsNullOrWhiteSpace(txtPerf11.Text)) ||
                (string.IsNullOrWhiteSpace(txtName11.Text) && string.IsNullOrWhiteSpace(cboSchool11.Text) && !string.IsNullOrWhiteSpace(txtPerf11.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #11", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName12.Text) && string.IsNullOrWhiteSpace(cboSchool12.Text) && string.IsNullOrWhiteSpace(txtPerf12.Text)) ||
                (string.IsNullOrWhiteSpace(txtName12.Text) && !string.IsNullOrWhiteSpace(cboSchool12.Text) && string.IsNullOrWhiteSpace(txtPerf12.Text)) ||
                (string.IsNullOrWhiteSpace(txtName12.Text) && string.IsNullOrWhiteSpace(cboSchool12.Text) && !string.IsNullOrWhiteSpace(txtPerf12.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #12", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName13.Text) && string.IsNullOrWhiteSpace(cboSchool13.Text) && string.IsNullOrWhiteSpace(txtPerf13.Text)) ||
                (string.IsNullOrWhiteSpace(txtName13.Text) && !string.IsNullOrWhiteSpace(cboSchool13.Text) && string.IsNullOrWhiteSpace(txtPerf13.Text)) ||
                (string.IsNullOrWhiteSpace(txtName13.Text) && string.IsNullOrWhiteSpace(cboSchool13.Text) && !string.IsNullOrWhiteSpace(txtPerf13.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #13", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName14.Text) && string.IsNullOrWhiteSpace(cboSchool14.Text) && string.IsNullOrWhiteSpace(txtPerf14.Text)) ||
                (string.IsNullOrWhiteSpace(txtName14.Text) && !string.IsNullOrWhiteSpace(cboSchool14.Text) && string.IsNullOrWhiteSpace(txtPerf14.Text)) ||
                (string.IsNullOrWhiteSpace(txtName14.Text) && string.IsNullOrWhiteSpace(cboSchool14.Text) && !string.IsNullOrWhiteSpace(txtPerf14.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #14", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName15.Text) && string.IsNullOrWhiteSpace(cboSchool15.Text) && string.IsNullOrWhiteSpace(txtPerf15.Text)) ||
                (string.IsNullOrWhiteSpace(txtName15.Text) && !string.IsNullOrWhiteSpace(cboSchool15.Text) && string.IsNullOrWhiteSpace(txtPerf15.Text)) ||
                (string.IsNullOrWhiteSpace(txtName15.Text) && string.IsNullOrWhiteSpace(cboSchool15.Text) && !string.IsNullOrWhiteSpace(txtPerf15.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #15", "Invalid Data");
                return false;
            }
            if ((!string.IsNullOrWhiteSpace(txtName16.Text) && string.IsNullOrWhiteSpace(cboSchool16.Text) && string.IsNullOrWhiteSpace(txtPerf16.Text)) ||
                (string.IsNullOrWhiteSpace(txtName16.Text) && !string.IsNullOrWhiteSpace(cboSchool16.Text) && string.IsNullOrWhiteSpace(txtPerf16.Text)) ||
                (string.IsNullOrWhiteSpace(txtName16.Text) && string.IsNullOrWhiteSpace(cboSchool16.Text) && !string.IsNullOrWhiteSpace(txtPerf16.Text)))
            {
                MessageBox.Show("Incomplete data for Athlete #16", "Invalid Data");
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
            if (!txtPerf1.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf1.Text.IndexOf('-') != txtPerf1.Text.LastIndexOf('-') || txtPerf1.Text.IndexOf('.') != txtPerf1.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #1 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf2.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf2.Text.IndexOf('-') != txtPerf2.Text.LastIndexOf('-') || txtPerf2.Text.IndexOf('.') != txtPerf2.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #2 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf3.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf3.Text.IndexOf('-') != txtPerf3.Text.LastIndexOf('-') || txtPerf3.Text.IndexOf('.') != txtPerf3.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #3 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf4.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf4.Text.IndexOf('-') != txtPerf4.Text.LastIndexOf('-') || txtPerf4.Text.IndexOf('.') != txtPerf4.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #4 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf5.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf5.Text.IndexOf('-') != txtPerf5.Text.LastIndexOf('-') || txtPerf5.Text.IndexOf('.') != txtPerf5.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #5 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf6.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf6.Text.IndexOf('-') != txtPerf6.Text.LastIndexOf('-') || txtPerf6.Text.IndexOf('.') != txtPerf6.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #6 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf7.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf7.Text.IndexOf('-') != txtPerf7.Text.LastIndexOf('-') || txtPerf7.Text.IndexOf('.') != txtPerf7.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #7 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf8.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf8.Text.IndexOf('-') != txtPerf8.Text.LastIndexOf('-') || txtPerf8.Text.IndexOf('.') != txtPerf8.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #8 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf9.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf9.Text.IndexOf('-') != txtPerf9.Text.LastIndexOf('-') || txtPerf9.Text.IndexOf('.') != txtPerf9.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #9 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf10.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf10.Text.IndexOf('-') != txtPerf10.Text.LastIndexOf('-') || txtPerf10.Text.IndexOf('.') != txtPerf10.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #10 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf11.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf11.Text.IndexOf('-') != txtPerf11.Text.LastIndexOf('-') || txtPerf11.Text.IndexOf('.') != txtPerf11.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #11 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf12.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf12.Text.IndexOf('-') != txtPerf12.Text.LastIndexOf('-') || txtPerf12.Text.IndexOf('.') != txtPerf12.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #12 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf13.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf13.Text.IndexOf('-') != txtPerf13.Text.LastIndexOf('-') || txtPerf13.Text.IndexOf('.') != txtPerf13.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #13 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf14.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf14.Text.IndexOf('-') != txtPerf14.Text.LastIndexOf('-') || txtPerf14.Text.IndexOf('.') != txtPerf14.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #14 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf15.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf15.Text.IndexOf('-') != txtPerf15.Text.LastIndexOf('-') || txtPerf15.Text.IndexOf('.') != txtPerf15.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #15 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf16.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf16.Text.IndexOf('-') != txtPerf16.Text.LastIndexOf('-') || txtPerf16.Text.IndexOf('.') != txtPerf16.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #16 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf17.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf17.Text.IndexOf('-') != txtPerf17.Text.LastIndexOf('-') || txtPerf17.Text.IndexOf('.') != txtPerf17.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #17 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf18.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf18.Text.IndexOf('-') != txtPerf18.Text.LastIndexOf('-') || txtPerf18.Text.IndexOf('.') != txtPerf18.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #18 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf19.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf19.Text.IndexOf('-') != txtPerf19.Text.LastIndexOf('-') || txtPerf19.Text.IndexOf('.') != txtPerf19.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #19 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf20.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf20.Text.IndexOf('-') != txtPerf20.Text.LastIndexOf('-') || txtPerf20.Text.IndexOf('.') != txtPerf20.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #20 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf21.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf21.Text.IndexOf('-') != txtPerf21.Text.LastIndexOf('-') || txtPerf21.Text.IndexOf('.') != txtPerf21.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #21 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf22.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf22.Text.IndexOf('-') != txtPerf22.Text.LastIndexOf('-') || txtPerf22.Text.IndexOf('.') != txtPerf22.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #22 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf23.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf23.Text.IndexOf('-') != txtPerf23.Text.LastIndexOf('-') || txtPerf23.Text.IndexOf('.') != txtPerf23.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #23 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf24.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf24.Text.IndexOf('-') != txtPerf24.Text.LastIndexOf('-') || txtPerf24.Text.IndexOf('.') != txtPerf24.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #24 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf25.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf25.Text.IndexOf('-') != txtPerf25.Text.LastIndexOf('-') || txtPerf25.Text.IndexOf('.') != txtPerf25.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #25 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf26.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf26.Text.IndexOf('-') != txtPerf26.Text.LastIndexOf('-') || txtPerf26.Text.IndexOf('.') != txtPerf26.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #26 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf27.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf27.Text.IndexOf('-') != txtPerf27.Text.LastIndexOf('-') || txtPerf27.Text.IndexOf('.') != txtPerf27.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #27 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf28.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf28.Text.IndexOf('-') != txtPerf28.Text.LastIndexOf('-') || txtPerf28.Text.IndexOf('.') != txtPerf28.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #28 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf29.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf29.Text.IndexOf('-') != txtPerf29.Text.LastIndexOf('-') || txtPerf29.Text.IndexOf('.') != txtPerf29.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #29 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf30.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf30.Text.IndexOf('-') != txtPerf30.Text.LastIndexOf('-') || txtPerf30.Text.IndexOf('.') != txtPerf30.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #30 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf31.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf31.Text.IndexOf('-') != txtPerf31.Text.LastIndexOf('-') || txtPerf31.Text.IndexOf('.') != txtPerf31.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #31 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf32.Text.All(c => char.IsDigit(c) || c == '-' || c == '.') || txtPerf32.Text.IndexOf('-') != txtPerf32.Text.LastIndexOf('-') || txtPerf32.Text.IndexOf('.') != txtPerf32.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #32 is invalid", "Invalid Data");
                return false;
            }

            //If all the above errors were ot found, return true
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return true;
        }

        /// <summary>
        /// Sorts the List of Performances in Descending Order (Best to Worst)
        /// </summary>
        private void SortListOfPerfs()
        {
            if (allPerfs != null && allPerfs.Count > 0)
            {
                allPerfs = allPerfs.OrderByDescending(o => o.performance).ToList();
            }
        }

        private void cmdPrevious_Click(object sender, EventArgs e)
        {
            if (currentHeatNum <= 0)
            {
                MessageBox.Show("Cannot go to a flight below 1", "Invalid flight #");
                currentHeatNum = 0; // This should never be needed, but here just incase of an unknown error
            }
            else if (AddFlightToList())
            {
                currentHeatNum--;
                grpHeats1.Text = "Flight #" + (currentHeatNum + 1);
                grpHeats2.Text = "Flight #" + (currentHeatNum + 1);
                EnterDataIntoForm();
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            if (currentHeatNum >= 10000)
            {
                MessageBox.Show("Cannot go to a flight above 10,000", "Invalid flight #");
                currentHeatNum = 10000; // This should never be needed, but here just incase of an unknown error
            }
            else if (AddFlightToList())
            {
                currentHeatNum++;
                grpHeats1.Text = "Flight #" + (currentHeatNum + 1);
                grpHeats2.Text = "Flight #" + (currentHeatNum + 1);
                EnterDataIntoForm();
            }
        }

        private void cmdEnterData_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            if (AddFlightToList())
            {
                MessageBox.Show("Data for " + eventName + " entered", "Success");
                mh.AddEvent(eventName, allPerfs);
                string gender = "Boy";
                if (eventName.StartsWith("Girl"))
                {
                    gender = "Girl";
                }
                mh.AddFieldEventToScores(gender, eventName, allPerfs);
                mh.Show();
                this.Close();
            }
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void mnuClearThis_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to clear data from this flight?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                ClearAll();
        }

        private void mnuClearAll_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to clear data from this entire event?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ClearAll();
                allPerfs.Clear();
            }
        }

        public void clearFlight(int flightNum)
        {
            for(int i = (flightNum * 32) + 32; i >= flightNum * 32; i--)
            {
                if(allPerfs != null && allPerfs.ElementAtOrDefault(i) != null)
                {
                    allPerfs.RemoveAt(i);
                }
            }
        }

        public bool AddFlightToList()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            if (CheckData())
            {
                //Need to clear entire flight data
                clearFlight(currentHeatNum);

                if(allPerfs==null)
                    allPerfs = new List<Performance>();
                //Need to delete performances from current "Flight"
                clearFlight(currentHeatNum);

                if (!string.IsNullOrWhiteSpace(txtName1.Text))
                    allPerfs.Add(new Performance(txtName1.Text, cboSchool1.Text, 0, em.ConvertFromLengthData(txtPerf1.Text)));
                if (!string.IsNullOrWhiteSpace(txtName2.Text))
                    allPerfs.Add(new Performance(txtName2.Text, cboSchool2.Text, 0, em.ConvertFromLengthData(txtPerf2.Text)));
                if (!string.IsNullOrWhiteSpace(txtName3.Text))
                    allPerfs.Add(new Performance(txtName3.Text, cboSchool3.Text, 0, em.ConvertFromLengthData(txtPerf3.Text)));
                if (!string.IsNullOrWhiteSpace(txtName4.Text))
                    allPerfs.Add(new Performance(txtName4.Text, cboSchool4.Text, 0, em.ConvertFromLengthData(txtPerf4.Text)));
                if (!string.IsNullOrWhiteSpace(txtName5.Text))
                    allPerfs.Add(new Performance(txtName5.Text, cboSchool5.Text, 0, em.ConvertFromLengthData(txtPerf5.Text)));
                if (!string.IsNullOrWhiteSpace(txtName6.Text))
                    allPerfs.Add(new Performance(txtName6.Text, cboSchool6.Text, 0, em.ConvertFromLengthData(txtPerf6.Text)));
                if (!string.IsNullOrWhiteSpace(txtName7.Text))
                    allPerfs.Add(new Performance(txtName7.Text, cboSchool7.Text, 0, em.ConvertFromLengthData(txtPerf7.Text)));
                if (!string.IsNullOrWhiteSpace(txtName8.Text))
                    allPerfs.Add(new Performance(txtName8.Text, cboSchool8.Text, 0, em.ConvertFromLengthData(txtPerf8.Text)));
                if (!string.IsNullOrWhiteSpace(txtName9.Text))
                    allPerfs.Add(new Performance(txtName9.Text, cboSchool9.Text, 0, em.ConvertFromLengthData(txtPerf9.Text)));
                if (!string.IsNullOrWhiteSpace(txtName10.Text))
                    allPerfs.Add(new Performance(txtName10.Text, cboSchool10.Text, 0, em.ConvertFromLengthData(txtPerf10.Text)));
                if (!string.IsNullOrWhiteSpace(txtName11.Text))
                    allPerfs.Add(new Performance(txtName11.Text, cboSchool11.Text, 0, em.ConvertFromLengthData(txtPerf11.Text)));
                if (!string.IsNullOrWhiteSpace(txtName12.Text))
                    allPerfs.Add(new Performance(txtName12.Text, cboSchool12.Text, 0, em.ConvertFromLengthData(txtPerf12.Text)));
                if (!string.IsNullOrWhiteSpace(txtName13.Text))
                    allPerfs.Add(new Performance(txtName13.Text, cboSchool13.Text, 0, em.ConvertFromLengthData(txtPerf13.Text)));
                if (!string.IsNullOrWhiteSpace(txtName14.Text))
                    allPerfs.Add(new Performance(txtName14.Text, cboSchool14.Text, 0, em.ConvertFromLengthData(txtPerf14.Text)));
                if (!string.IsNullOrWhiteSpace(txtName15.Text))
                    allPerfs.Add(new Performance(txtName15.Text, cboSchool15.Text, 0, em.ConvertFromLengthData(txtPerf15.Text)));
                if (!string.IsNullOrWhiteSpace(txtName16.Text))
                    allPerfs.Add(new Performance(txtName16.Text, cboSchool16.Text, 0, em.ConvertFromLengthData(txtPerf16.Text)));
                if (!string.IsNullOrWhiteSpace(txtName17.Text))
                    allPerfs.Add(new Performance(txtName17.Text, cboSchool17.Text, 0, em.ConvertFromLengthData(txtPerf17.Text)));
                if (!string.IsNullOrWhiteSpace(txtName18.Text))
                    allPerfs.Add(new Performance(txtName18.Text, cboSchool18.Text, 0, em.ConvertFromLengthData(txtPerf18.Text)));
                if (!string.IsNullOrWhiteSpace(txtName19.Text))
                    allPerfs.Add(new Performance(txtName19.Text, cboSchool19.Text, 0, em.ConvertFromLengthData(txtPerf19.Text)));
                if (!string.IsNullOrWhiteSpace(txtName20.Text))
                    allPerfs.Add(new Performance(txtName20.Text, cboSchool20.Text, 0, em.ConvertFromLengthData(txtPerf20.Text)));
                if (!string.IsNullOrWhiteSpace(txtName21.Text))
                    allPerfs.Add(new Performance(txtName21.Text, cboSchool21.Text, 0, em.ConvertFromLengthData(txtPerf21.Text)));
                if (!string.IsNullOrWhiteSpace(txtName22.Text))
                    allPerfs.Add(new Performance(txtName22.Text, cboSchool22.Text, 0, em.ConvertFromLengthData(txtPerf22.Text)));
                if (!string.IsNullOrWhiteSpace(txtName23.Text))
                    allPerfs.Add(new Performance(txtName23.Text, cboSchool23.Text, 0, em.ConvertFromLengthData(txtPerf23.Text)));
                if (!string.IsNullOrWhiteSpace(txtName24.Text))
                    allPerfs.Add(new Performance(txtName24.Text, cboSchool24.Text, 0, em.ConvertFromLengthData(txtPerf24.Text)));
                if (!string.IsNullOrWhiteSpace(txtName25.Text))
                    allPerfs.Add(new Performance(txtName25.Text, cboSchool25.Text, 0, em.ConvertFromLengthData(txtPerf25.Text)));
                if (!string.IsNullOrWhiteSpace(txtName26.Text))
                    allPerfs.Add(new Performance(txtName26.Text, cboSchool26.Text, 0, em.ConvertFromLengthData(txtPerf26.Text)));
                if (!string.IsNullOrWhiteSpace(txtName27.Text))
                    allPerfs.Add(new Performance(txtName27.Text, cboSchool27.Text, 0, em.ConvertFromLengthData(txtPerf27.Text)));
                if (!string.IsNullOrWhiteSpace(txtName28.Text))
                    allPerfs.Add(new Performance(txtName28.Text, cboSchool28.Text, 0, em.ConvertFromLengthData(txtPerf28.Text)));
                if (!string.IsNullOrWhiteSpace(txtName29.Text))
                    allPerfs.Add(new Performance(txtName29.Text, cboSchool29.Text, 0, em.ConvertFromLengthData(txtPerf29.Text)));
                if (!string.IsNullOrWhiteSpace(txtName30.Text))
                    allPerfs.Add(new Performance(txtName30.Text, cboSchool30.Text, 0, em.ConvertFromLengthData(txtPerf30.Text)));
                if (!string.IsNullOrWhiteSpace(txtName31.Text))
                    allPerfs.Add(new Performance(txtName31.Text, cboSchool31.Text, 0, em.ConvertFromLengthData(txtPerf31.Text)));
                if (!string.IsNullOrWhiteSpace(txtName32.Text))
                    allPerfs.Add(new Performance(txtName32.Text, cboSchool32.Text, 0, em.ConvertFromLengthData(txtPerf32.Text)));

                SortListOfPerfs();

                Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return true;
            }
            else
            {
                Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        private void mnuClear_Click(object sender, EventArgs e)
        {

        }

        private void cboSchool3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
