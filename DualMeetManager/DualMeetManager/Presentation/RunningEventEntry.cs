using DualMeetManager.Business.Managers;
using DualMeetManager.Domain;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DualMeetManager.Presentation
{
    public partial class RunningEventEntry : Form
    {
        MeetHub mh;
        int currentHeatNum = 0;
        int numRunners = 8;
        string eventName;

        List<Performance> allPerfs = new List<Performance>();
        OrderedDictionary perfs = new OrderedDictionary();
        EventMgr em = new EventMgr();

        public void setCorrectNumRunners()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            //Check how many runners are in current heat
            if (perfs == null || !perfs.Contains(currentHeatNum))
            {
                //Change this code to display the correct number of runners based on what event it is
                numRunners = 8;
            }
            else
            {
                Console.WriteLine("Debug, Inside else");
                List<Performance> temp = perfs[currentHeatNum] as List<Performance>;
                //List<Performance> temp = new List<Performance>();
                Console.WriteLine("a");
                if (temp.Count <= 8)
                {
                    numRunners = 8;
                }
                else if (temp.Count <= 16)
                {
                    numRunners = 16;
                }
                else
                {
                    numRunners = 32;
                }
                Console.WriteLine("b");
            }
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// Changes the visibility of the runner form objects based on how many there are/needed
        /// </summary>
        public void displayCorrectNumOfRunners()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            //Make visible / non visible depending on number of runners
            if (numRunners <= 8)
            {
                clear9to16();
                clear17to32();

                txtName9.Visible = false;
                cboSchool9.Visible = false;
                txtPerf9.Visible = false;

                txtName10.Visible = false;
                cboSchool10.Visible = false;
                txtPerf10.Visible = false;

                txtName11.Visible = false;
                cboSchool11.Visible = false;
                txtPerf11.Visible = false;

                txtName12.Visible = false;
                cboSchool12.Visible = false;
                txtPerf12.Visible = false;

                txtName13.Visible = false;
                cboSchool13.Visible = false;
                txtPerf13.Visible = false;

                txtName14.Visible = false;
                cboSchool14.Visible = false;
                txtPerf14.Visible = false;

                txtName15.Visible = false;
                cboSchool15.Visible = false;
                txtPerf15.Visible = false;

                txtName16.Visible = false;
                cboSchool16.Visible = false;
                txtPerf16.Visible = false;

                grpHeats2.Visible = false;
            }
            else if (numRunners <= 16)
            {
                clear17to32();

                txtName9.Visible = true;
                cboSchool9.Visible = true;
                txtPerf9.Visible = true;

                txtName10.Visible = true;
                cboSchool10.Visible = true;
                txtPerf10.Visible = true;

                txtName11.Visible = true;
                cboSchool11.Visible = true;
                txtPerf11.Visible = true;

                txtName12.Visible = true;
                cboSchool12.Visible = true;
                txtPerf12.Visible = true;

                txtName13.Visible = true;
                cboSchool13.Visible = true;
                txtPerf13.Visible = true;

                txtName14.Visible = true;
                cboSchool14.Visible = true;
                txtPerf14.Visible = true;

                txtName15.Visible = true;
                cboSchool15.Visible = true;
                txtPerf15.Visible = true;

                txtName16.Visible = true;
                cboSchool16.Visible = true;
                txtPerf16.Visible = true;

                grpHeats2.Visible = false;
            }
            else
            {
                txtName9.Visible = true;
                cboSchool9.Visible = true;
                txtPerf9.Visible = true;

                txtName10.Visible = true;
                cboSchool10.Visible = true;
                txtPerf10.Visible = true;

                txtName11.Visible = true;
                cboSchool11.Visible = true;
                txtPerf11.Visible = true;

                txtName12.Visible = true;
                cboSchool12.Visible = true;
                txtPerf12.Visible = true;

                txtName13.Visible = true;
                cboSchool13.Visible = true;
                txtPerf13.Visible = true;

                txtName14.Visible = true;
                cboSchool14.Visible = true;
                txtPerf14.Visible = true;

                txtName15.Visible = true;
                cboSchool15.Visible = true;
                txtPerf15.Visible = true;

                txtName16.Visible = true;
                cboSchool16.Visible = true;
                txtPerf16.Visible = true;

                grpHeats2.Visible = true;
            }
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RunningEventEntry()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + "Default Constructor");
            InitializeComponent();
            Console.WriteLine("Leaving " + GetType().Name + " - " + "Default Constructor");
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="eventName">Name of the event being entered</param>
        /// <param name="allPerfs">Performances for the event</param>
        public RunningEventEntry(MeetHub mh, string eventName, List<Performance> allPerfs) : this()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + "Parameterized Constructor");
            this.mh = mh;
            this.eventName = eventName;
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

        public void clear1to8()
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
        }

        public void clear9to16()
        {
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
        }

        public void clear17to32()
        {
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
        /// Clears all data from all objects on the form
        /// </summary>
        public void clearForm()
        {
            clear1to8();
            clear9to16();
            clear17to32();
        }

        /// <summary>
        /// Enters data from specific heat (int currentHeatNum) for all objects on the form
        /// </summary>
        public void enterDataIntoForm()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.WriteLine("currentHeatNum = " + currentHeatNum);
            //Needs to check that this entry exists. Otherwise it will produce an error
            List<Performance> tempPerfs = new List<Performance>();
            if (perfs.Contains(currentHeatNum))
                tempPerfs = perfs[currentHeatNum] as List<Performance>;
            else
                clearForm();

            if (tempPerfs.ElementAtOrDefault(0) != null)
            {
                txtName1.Text = tempPerfs[0].athleteName;
                cboSchool1.Text = tempPerfs[0].schoolName;
                txtPerf1.Text = em.ConvertToTimedData(tempPerfs[0].performance);
            }
            if (tempPerfs.ElementAtOrDefault(1) != null)
            {
                txtName2.Text = tempPerfs[1].athleteName;
                cboSchool2.Text = tempPerfs[1].schoolName;
                txtPerf2.Text = em.ConvertToTimedData(tempPerfs[1].performance);
            }
            if (tempPerfs.ElementAtOrDefault(2) != null)
            {
                txtName3.Text = tempPerfs[2].athleteName;
                cboSchool3.Text = tempPerfs[2].schoolName;
                txtPerf3.Text = em.ConvertToTimedData(tempPerfs[2].performance);
            }
            if (tempPerfs.ElementAtOrDefault(3) != null)
            {
                txtName4.Text = tempPerfs[3].athleteName;
                cboSchool4.Text = tempPerfs[3].schoolName;
                txtPerf4.Text = em.ConvertToTimedData(tempPerfs[3].performance);
            }
            if (tempPerfs.ElementAtOrDefault(4) != null)
            {
                txtName5.Text = tempPerfs[4].athleteName;
                cboSchool5.Text = tempPerfs[4].schoolName;
                txtPerf5.Text = em.ConvertToTimedData(tempPerfs[4].performance);
            }
            if (tempPerfs.ElementAtOrDefault(5) != null)
            {
                txtName6.Text = tempPerfs[5].athleteName;
                cboSchool6.Text = tempPerfs[5].schoolName;
                txtPerf6.Text = em.ConvertToTimedData(tempPerfs[5].performance);
            }
            if (tempPerfs.ElementAtOrDefault(6) != null)
            {
                txtName7.Text = tempPerfs[6].athleteName;
                cboSchool7.Text = tempPerfs[6].schoolName;
                txtPerf7.Text = em.ConvertToTimedData(tempPerfs[6].performance);
            }
            if (tempPerfs.ElementAtOrDefault(7) != null)
            {
                txtName8.Text = tempPerfs[7].athleteName;
                cboSchool8.Text = tempPerfs[7].schoolName;
                txtPerf8.Text = em.ConvertToTimedData(tempPerfs[7].performance);
            }
            if (tempPerfs.ElementAtOrDefault(8) != null)
            {
                txtName9.Text = tempPerfs[8].athleteName;
                cboSchool9.Text = tempPerfs[8].schoolName;
                txtPerf9.Text = em.ConvertToTimedData(tempPerfs[8].performance);
            }
            if (tempPerfs.ElementAtOrDefault(9) != null)
            {
                txtName10.Text = tempPerfs[9].athleteName;
                cboSchool10.Text = tempPerfs[9].schoolName;
                txtPerf10.Text = em.ConvertToTimedData(tempPerfs[9].performance);
            }
            if (tempPerfs.ElementAtOrDefault(10) != null)
            {
                txtName11.Text = tempPerfs[10].athleteName;
                cboSchool11.Text = tempPerfs[10].schoolName;
                txtPerf11.Text = em.ConvertToTimedData(tempPerfs[10].performance);
            }
            if (tempPerfs.ElementAtOrDefault(11) != null)
            {
                txtName12.Text = tempPerfs[11].athleteName;
                cboSchool12.Text = tempPerfs[11].schoolName;
                txtPerf12.Text = em.ConvertToTimedData(tempPerfs[11].performance);
            }
            if (tempPerfs.ElementAtOrDefault(12) != null)
            {
                txtName13.Text = tempPerfs[12].athleteName;
                cboSchool13.Text = tempPerfs[12].schoolName;
                txtPerf13.Text = em.ConvertToTimedData(tempPerfs[12].performance);
            }
            if (tempPerfs.ElementAtOrDefault(13) != null)
            {
                txtName14.Text = tempPerfs[13].athleteName;
                cboSchool14.Text = tempPerfs[13].schoolName;
                txtPerf14.Text = em.ConvertToTimedData(tempPerfs[13].performance);
            }
            if (tempPerfs.ElementAtOrDefault(14) != null)
            {
                txtName15.Text = tempPerfs[14].athleteName;
                cboSchool15.Text = tempPerfs[14].schoolName;
                txtPerf15.Text = em.ConvertToTimedData(tempPerfs[14].performance);
            }
            if (tempPerfs.ElementAtOrDefault(15) != null)
            {
                txtName16.Text = tempPerfs[15].athleteName;
                cboSchool16.Text = tempPerfs[15].schoolName;
                txtPerf16.Text = em.ConvertToTimedData(tempPerfs[15].performance);
            }
            if (tempPerfs.ElementAtOrDefault(16) != null)
            {
                txtName17.Text = tempPerfs[16].athleteName;
                cboSchool17.Text = tempPerfs[16].schoolName;
                txtPerf17.Text = em.ConvertToTimedData(tempPerfs[16].performance);
            }
            if (tempPerfs.ElementAtOrDefault(17) != null)
            {
                txtName18.Text = tempPerfs[17].athleteName;
                cboSchool18.Text = tempPerfs[17].schoolName;
                txtPerf18.Text = em.ConvertToTimedData(tempPerfs[17].performance);
            }
            if (tempPerfs.ElementAtOrDefault(18) != null)
            {
                txtName19.Text = tempPerfs[18].athleteName;
                cboSchool19.Text = tempPerfs[18].schoolName;
                txtPerf19.Text = em.ConvertToTimedData(tempPerfs[18].performance);
            }
            if (tempPerfs.ElementAtOrDefault(19) != null)
            {
                txtName20.Text = tempPerfs[19].athleteName;
                cboSchool20.Text = tempPerfs[19].schoolName;
                txtPerf20.Text = em.ConvertToTimedData(tempPerfs[19].performance);
            }
            if (tempPerfs.ElementAtOrDefault(20) != null)
            {
                txtName21.Text = tempPerfs[20].athleteName;
                cboSchool21.Text = tempPerfs[20].schoolName;
                txtPerf21.Text = em.ConvertToTimedData(tempPerfs[20].performance);
            }
            if (tempPerfs.ElementAtOrDefault(21) != null)
            {
                txtName22.Text = tempPerfs[21].athleteName;
                cboSchool22.Text = tempPerfs[21].schoolName;
                txtPerf22.Text = em.ConvertToTimedData(tempPerfs[21].performance);
            }
            if (tempPerfs.ElementAtOrDefault(22) != null)
            {
                txtName23.Text = tempPerfs[22].athleteName;
                cboSchool23.Text = tempPerfs[22].schoolName;
                txtPerf23.Text = em.ConvertToTimedData(tempPerfs[22].performance);
            }
            if (tempPerfs.ElementAtOrDefault(23) != null)
            {
                txtName24.Text = tempPerfs[23].athleteName;
                cboSchool24.Text = tempPerfs[23].schoolName;
                txtPerf24.Text = em.ConvertToTimedData(tempPerfs[23].performance);
            }
            if (tempPerfs.ElementAtOrDefault(24) != null)
            {
                txtName25.Text = tempPerfs[24].athleteName;
                cboSchool25.Text = tempPerfs[24].schoolName;
                txtPerf25.Text = em.ConvertToTimedData(tempPerfs[24].performance);
            }
            if (tempPerfs.ElementAtOrDefault(25) != null)
            {
                txtName26.Text = tempPerfs[25].athleteName;
                cboSchool26.Text = tempPerfs[25].schoolName;
                txtPerf26.Text = em.ConvertToTimedData(tempPerfs[25].performance);
            }
            if (tempPerfs.ElementAtOrDefault(26) != null)
            {
                txtName27.Text = tempPerfs[26].athleteName;
                cboSchool27.Text = tempPerfs[26].schoolName;
                txtPerf27.Text = em.ConvertToTimedData(tempPerfs[26].performance);
            }
            if (tempPerfs.ElementAtOrDefault(27) != null)
            {
                txtName28.Text = tempPerfs[27].athleteName;
                cboSchool28.Text = tempPerfs[27].schoolName;
                txtPerf28.Text = em.ConvertToTimedData(tempPerfs[27].performance);
            }
            if (tempPerfs.ElementAtOrDefault(28) != null)
            {
                txtName29.Text = tempPerfs[28].athleteName;
                cboSchool29.Text = tempPerfs[28].schoolName;
                txtPerf29.Text = em.ConvertToTimedData(tempPerfs[28].performance);
            }
            if (tempPerfs.ElementAtOrDefault(29) != null)
            {
                txtName30.Text = tempPerfs[29].athleteName;
                cboSchool30.Text = tempPerfs[29].schoolName;
                txtPerf30.Text = em.ConvertToTimedData(tempPerfs[29].performance);
            }
            if (tempPerfs.ElementAtOrDefault(30) != null)
            {
                txtName31.Text = tempPerfs[30].athleteName;
                cboSchool31.Text = tempPerfs[30].schoolName;
                txtPerf31.Text = em.ConvertToTimedData(tempPerfs[30].performance);
            }
            if (tempPerfs.ElementAtOrDefault(31) != null)
            {
                txtName32.Text = tempPerfs[31].athleteName;
                cboSchool32.Text = tempPerfs[31].schoolName;
                txtPerf32.Text = em.ConvertToTimedData(tempPerfs[31].performance);
            }
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// Puts all the Performances (allPerfs) into an Ordered Dictionary (perfs)
        /// The key of this Dictionary is the heat Number. Value is a List of Performances for that heat
        /// This allows us to enter and gather performances from this form alot easier, quicker, and cleaner.
        /// </summary>
        public void putPerfsIntoOrderedDictionary()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            //Clear perfs
            perfs.Clear();

            //Check that allPerfs is not null
            if (allPerfs != null)
            {
                //Get the highest heat number
                int highestHeat = 1;
                foreach (Performance p in allPerfs)
                {
                    if (p.heatNum > highestHeat)
                        highestHeat = p.heatNum;
                }

                //i is equal to the heat number
                for (int i = 1; i <= highestHeat; i++)
                {
                    List<Performance> tempPerfs = new List<Performance>();
                    foreach (Performance p in allPerfs)
                    {
                        if (p.heatNum == i)
                            tempPerfs.Add(p);
                    }
                    if (tempPerfs.Count > 0)
                        perfs.Add(i-1, tempPerfs);
                }

            }
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void takePerfsFromOrderedDictionary()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            if (allPerfs != null) allPerfs.Clear();
            else allPerfs = new List<Performance>();
            foreach(int key in perfs.Keys)
            {
                //List<Performance> tempPerfs = new List<Performance>();
                //if (perfs.Contains(currentHeatNum))
                //    tempPerfs = perfs[currentHeatNum] as List<Performance>;
                List<Performance> tempPerfs = new List<Performance>();
                tempPerfs = perfs[key] as List<Performance>;
                foreach(Performance p in tempPerfs)
                {
                    allPerfs.Add(p);
                }
            }
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void RunningEventEntry_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            putPerfsIntoOrderedDictionary();
            currentHeatNum = 0;
            setCorrectNumRunners();
            displayCorrectNumOfRunners();
            enterDataIntoForm();
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// Check to make sure that the data entered into the form by the user is valid
        /// </summary>
        /// <returns>true if valid, false if invalid</returns>
        public bool checkData()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            //Check that athlete #1 has a value
            if (string.IsNullOrWhiteSpace(txtName1.Text))
            {
                MessageBox.Show("Please enter a name for Athlete #1", "Invalid Data");
                return false;
            }
            if (string.IsNullOrWhiteSpace(cboSchool1.Text))
            {
                MessageBox.Show("Please enter a school for Athlete #1", "Invalid Data");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPerf1.Text))
            {
                MessageBox.Show("Please enter a name for Athlete #1", "Invalid Data");
                return false;
            }

            //Check that every athlete 2-32 has either no values or all values
            if((!string.IsNullOrWhiteSpace(txtName2.Text) && string.IsNullOrWhiteSpace(cboSchool2.Text) && string.IsNullOrWhiteSpace(txtPerf2.Text)) || 
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
            if (!txtPerf7.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf7.Text.IndexOf(':') != txtPerf7.Text.LastIndexOf(':') || txtPerf7.Text.IndexOf('.') != txtPerf7.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #7 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf8.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf8.Text.IndexOf(':') != txtPerf8.Text.LastIndexOf(':') || txtPerf8.Text.IndexOf('.') != txtPerf8.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #8 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf9.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf9.Text.IndexOf(':') != txtPerf9.Text.LastIndexOf(':') || txtPerf9.Text.IndexOf('.') != txtPerf9.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #9 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf10.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf10.Text.IndexOf(':') != txtPerf10.Text.LastIndexOf(':') || txtPerf10.Text.IndexOf('.') != txtPerf10.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #10 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf11.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf11.Text.IndexOf(':') != txtPerf11.Text.LastIndexOf(':') || txtPerf11.Text.IndexOf('.') != txtPerf11.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #11 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf12.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf12.Text.IndexOf(':') != txtPerf12.Text.LastIndexOf(':') || txtPerf12.Text.IndexOf('.') != txtPerf12.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #12 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf13.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf13.Text.IndexOf(':') != txtPerf13.Text.LastIndexOf(':') || txtPerf13.Text.IndexOf('.') != txtPerf13.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #13 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf14.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf14.Text.IndexOf(':') != txtPerf14.Text.LastIndexOf(':') || txtPerf14.Text.IndexOf('.') != txtPerf14.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #14 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf15.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf15.Text.IndexOf(':') != txtPerf15.Text.LastIndexOf(':') || txtPerf15.Text.IndexOf('.') != txtPerf15.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #15 is invalid", "Invalid Data");
                return false;
            }
            if (!txtPerf16.Text.All(c => char.IsDigit(c) || c == ':' || c == '.') || txtPerf16.Text.IndexOf(':') != txtPerf16.Text.LastIndexOf(':') || txtPerf16.Text.IndexOf('.') != txtPerf16.Text.LastIndexOf('.'))
            {
                MessageBox.Show("Performance entered for Athlete #16 is invalid", "Invalid Data");
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

            //If all the above errors were ot found, return true
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return true;
        }

        //Might not be nessecary
        public void formatPerformances()
        {

        }

        private void mnuNum8_Click(object sender, EventArgs e)
        {
            numRunners = 8;
            displayCorrectNumOfRunners();
        }

        private void mnuNum16_Click(object sender, EventArgs e)
        {
            numRunners = 16;
            displayCorrectNumOfRunners();
        }

        private void mnuNum32_Click(object sender, EventArgs e)
        {
            numRunners = 32;
            displayCorrectNumOfRunners();
        }

        private void cmdPrevious_Click(object sender, EventArgs e)
        {
            if(currentHeatNum <= 0)
            {
                MessageBox.Show("Cannot go to heat below 1", "Invalid heat #");
                currentHeatNum = 0; // This should never be needed, but here just incase of an unknown error
            }
            else if (addHeatToDictionary())
            {
                currentHeatNum--;
                grpHeats1.Text = "Heat #" + (currentHeatNum + 1);
                grpHeats2.Text = "Heat #" + (currentHeatNum + 1);
                setCorrectNumRunners();
                displayCorrectNumOfRunners();
                enterDataIntoForm();
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            if (currentHeatNum >= 10000)
            {
                MessageBox.Show("Cannot go to heat above 10,000", "Invalid heat #");
                currentHeatNum = 10000; // This should never be needed, but here just incase of an unknown error
            }
            else if (addHeatToDictionary())
            {
                currentHeatNum++;
                grpHeats1.Text = "Heat #" + (currentHeatNum + 1);
                grpHeats2.Text = "Heat #" + (currentHeatNum + 1);
                setCorrectNumRunners();
                displayCorrectNumOfRunners();
                enterDataIntoForm();
            }
        }

        public bool addHeatToDictionary()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            if (checkData())
            {
                List<Performance> listToAdd = new List<Performance>();

                if(!string.IsNullOrWhiteSpace(txtName1.Text))
                    listToAdd.Add(new Performance(txtName1.Text, cboSchool1.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf1.Text)));
                if (!string.IsNullOrWhiteSpace(txtName2.Text))
                    listToAdd.Add(new Performance(txtName2.Text, cboSchool2.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf2.Text)));
                if (!string.IsNullOrWhiteSpace(txtName3.Text))
                    listToAdd.Add(new Performance(txtName3.Text, cboSchool3.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf3.Text)));
                if (!string.IsNullOrWhiteSpace(txtName4.Text))
                    listToAdd.Add(new Performance(txtName4.Text, cboSchool4.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf4.Text)));
                if (!string.IsNullOrWhiteSpace(txtName5.Text))
                    listToAdd.Add(new Performance(txtName5.Text, cboSchool5.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf5.Text)));
                if (!string.IsNullOrWhiteSpace(txtName6.Text))
                    listToAdd.Add(new Performance(txtName6.Text, cboSchool6.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf6.Text)));
                if (!string.IsNullOrWhiteSpace(txtName7.Text))
                    listToAdd.Add(new Performance(txtName7.Text, cboSchool7.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf7.Text)));
                if (!string.IsNullOrWhiteSpace(txtName8.Text))
                    listToAdd.Add(new Performance(txtName8.Text, cboSchool8.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf8.Text)));
                if (!string.IsNullOrWhiteSpace(txtName9.Text))
                    listToAdd.Add(new Performance(txtName9.Text, cboSchool9.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf9.Text)));
                if (!string.IsNullOrWhiteSpace(txtName10.Text))
                    listToAdd.Add(new Performance(txtName10.Text, cboSchool10.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf10.Text)));
                if (!string.IsNullOrWhiteSpace(txtName11.Text))
                    listToAdd.Add(new Performance(txtName11.Text, cboSchool11.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf11.Text)));
                if (!string.IsNullOrWhiteSpace(txtName12.Text))
                    listToAdd.Add(new Performance(txtName12.Text, cboSchool12.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf12.Text)));
                if (!string.IsNullOrWhiteSpace(txtName13.Text))
                    listToAdd.Add(new Performance(txtName13.Text, cboSchool13.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf13.Text)));
                if (!string.IsNullOrWhiteSpace(txtName14.Text))
                    listToAdd.Add(new Performance(txtName14.Text, cboSchool14.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf14.Text)));
                if (!string.IsNullOrWhiteSpace(txtName15.Text))
                    listToAdd.Add(new Performance(txtName15.Text, cboSchool15.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf15.Text)));
                if (!string.IsNullOrWhiteSpace(txtName16.Text))
                    listToAdd.Add(new Performance(txtName16.Text, cboSchool16.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf16.Text)));
                if (!string.IsNullOrWhiteSpace(txtName17.Text))
                    listToAdd.Add(new Performance(txtName17.Text, cboSchool17.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf17.Text)));
                if (!string.IsNullOrWhiteSpace(txtName18.Text))
                    listToAdd.Add(new Performance(txtName18.Text, cboSchool18.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf18.Text)));
                if (!string.IsNullOrWhiteSpace(txtName19.Text))
                    listToAdd.Add(new Performance(txtName19.Text, cboSchool19.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf19.Text)));
                if (!string.IsNullOrWhiteSpace(txtName20.Text))
                    listToAdd.Add(new Performance(txtName20.Text, cboSchool20.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf20.Text)));
                if (!string.IsNullOrWhiteSpace(txtName21.Text))
                    listToAdd.Add(new Performance(txtName21.Text, cboSchool21.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf21.Text)));
                if (!string.IsNullOrWhiteSpace(txtName22.Text))
                    listToAdd.Add(new Performance(txtName22.Text, cboSchool22.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf22.Text)));
                if (!string.IsNullOrWhiteSpace(txtName23.Text))
                    listToAdd.Add(new Performance(txtName23.Text, cboSchool23.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf23.Text)));
                if (!string.IsNullOrWhiteSpace(txtName24.Text))
                    listToAdd.Add(new Performance(txtName24.Text, cboSchool24.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf24.Text)));
                if (!string.IsNullOrWhiteSpace(txtName25.Text))
                    listToAdd.Add(new Performance(txtName25.Text, cboSchool25.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf25.Text)));
                if (!string.IsNullOrWhiteSpace(txtName26.Text))
                    listToAdd.Add(new Performance(txtName26.Text, cboSchool26.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf26.Text)));
                if (!string.IsNullOrWhiteSpace(txtName27.Text))
                    listToAdd.Add(new Performance(txtName27.Text, cboSchool27.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf27.Text)));
                if (!string.IsNullOrWhiteSpace(txtName28.Text))
                    listToAdd.Add(new Performance(txtName28.Text, cboSchool28.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf28.Text)));
                if (!string.IsNullOrWhiteSpace(txtName29.Text))
                    listToAdd.Add(new Performance(txtName29.Text, cboSchool29.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf29.Text)));
                if (!string.IsNullOrWhiteSpace(txtName30.Text))
                    listToAdd.Add(new Performance(txtName30.Text, cboSchool30.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf30.Text)));
                if (!string.IsNullOrWhiteSpace(txtName31.Text))
                    listToAdd.Add(new Performance(txtName31.Text, cboSchool31.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf31.Text)));
                if (!string.IsNullOrWhiteSpace(txtName32.Text))
                    listToAdd.Add(new Performance(txtName32.Text, cboSchool32.Text, currentHeatNum + 1, em.ConvertFromTimedData(txtPerf32.Text)));

                if (perfs.Contains(currentHeatNum))
                    perfs[currentHeatNum] = listToAdd;
                else
                    perfs.Add(currentHeatNum, listToAdd);

                Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return true;
            }
            else
            {
                Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }



        private void cmdEnterData_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            if (addHeatToDictionary())
            {
                takePerfsFromOrderedDictionary();
                MessageBox.Show("Data for " + eventName + " entered", "Success");

                //MessageBox.Show(allPerfs.ToString());
                mh.AddEvent(eventName, allPerfs);
                mh.Show();
                this.Close();
                
            }
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
