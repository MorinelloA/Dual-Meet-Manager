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
        int currentHeatNum = 1;
        string eventName;
        List<Performance> currentPerfs;
        List<Performance> allPerfs;
        OrderedDictionary perfs = new OrderedDictionary();
        EventMgr em = new EventMgr();

        public void enterDataIntoForm()
        {
            //Need to check that this entry exists. Otherwise it will produce an error
            List<Performance> tempPerfs = perfs[currentHeatNum] as List<Performance>;
        }

        public void putPerfsIntoOrderedDictionary()
        {
            //Clear perfs
            perfs.Clear();

            //Check that allPerfs is not null
            if(allPerfs != null)
            {
                //Get the highest heat number
                int highestHeat = 1;
                foreach(Performance p in allPerfs)
                {
                    if (p.heatNum > highestHeat)
                        highestHeat = p.heatNum;
                }

                for(int i = 1; i <= highestHeat; i++)
                {
                    List<Performance> tempPerfs = new List<Performance>();
                    foreach (Performance p in allPerfs)
                    {
                        if (p.heatNum == i)
                            tempPerfs.Add(p);
                    }
                    if (tempPerfs.Count > 0)
                        perfs.Add(i, tempPerfs);
                }

            }
        }

        public RunningEventEntry()
        {
            InitializeComponent();
        }

        public RunningEventEntry(string eventName, List<Performance> allPerfs) : this()
        {
            this.eventName = eventName;
            this.allPerfs = allPerfs;
        }

        private void RunningEventEntry_Load(object sender, EventArgs e)
        {

        }

        public bool checkData()
        {
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

            return true;
        }

        public void formatPerformances()
        {

        }

        private void comboBox30_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
