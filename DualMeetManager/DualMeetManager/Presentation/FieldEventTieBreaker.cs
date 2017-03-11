using DualMeetManager.Business.Managers;
using DualMeetManager.Domain;
using DualMeetManager.Domain.Scoring;
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
    public partial class FieldEventTieBreaker : Form
    {
        //public IndEvent(string team1, string team2, EventPoints[] points, decimal team1Total, decimal team2Total)
        MeetHub mh;
        string team1, team2;
        List<Performance> perf = new List<Performance>();

        public FieldEventTieBreaker()
        {
            InitializeComponent();
        }

        public FieldEventTieBreaker(string t1, string t2, List<Performance> perf) : this()
        {
            //this.mh = mh;
            team1 = t1;
            team2 = t2;
            //this.perf = perf;
            foreach (Performance i in perf) //Iterate through entire list of performances
            {
                if (i.schoolName == t1 || i.schoolName == t2) //check if the performance is for Team 1 or 2
                {
                    this.perf.Add(i); //Add performance to working List
                }
            }
            //
            //sort performances from best to worst
            //
            this.perf = this.perf.OrderByDescending(o => o.performance).ToList();
        }

        private void FieldEventTieBreaker_Load(object sender, EventArgs e)
        {
            LoadPerformances();
            grpPerformances.Text = team1 + " vs. " + team2;
        }

        private void cmdEnter_Click(object sender, EventArgs e)
        {
            EventMgr em = new EventMgr();

            IndEvent newEvent = new IndEvent(team1, team2);
            int num1sts = 0;
            int num2nds = 0;
            int num3rds = 0;

            if (cboPlace1.Text == "1st")
            {
                num1sts++;
                newEvent.points[0].athleteName = lblName1.Text;
                newEvent.points[0].schoolName = lblSchool1.Text;
                newEvent.points[0].performance = lblPerformance1.Text;
            }
            else if (cboPlace1.Text == "2nd")
            {
                num2nds++;
                newEvent.points[1].athleteName = lblName1.Text;
                newEvent.points[1].schoolName = lblSchool1.Text;
                newEvent.points[1].performance = lblPerformance1.Text;
            }
            else if (cboPlace1.Text == "3rd")
            {
                num3rds++;
                newEvent.points[2].athleteName = lblName1.Text;
                newEvent.points[2].schoolName = lblSchool1.Text;
                newEvent.points[2].performance = lblPerformance1.Text;
            }

            if (cboPlace2.Text == "1st")
            {
                num1sts++;
                newEvent.points[0].athleteName = lblName2.Text;
                newEvent.points[0].schoolName = lblSchool2.Text;
                newEvent.points[0].performance = lblPerformance2.Text;
            }
            else if (cboPlace2.Text == "2nd")
            {
                num2nds++;
                newEvent.points[1].athleteName = lblName2.Text;
                newEvent.points[1].schoolName = lblSchool2.Text;
                newEvent.points[1].performance = lblPerformance2.Text;
            }
            else if (cboPlace2.Text == "3rd")
            {
                num3rds++;
                newEvent.points[2].athleteName = lblName2.Text;
                newEvent.points[2].schoolName = lblSchool2.Text;
                newEvent.points[2].performance = lblPerformance2.Text;
            }

            if (cboPlace3.Text == "1st")
            {
                num1sts++;
                newEvent.points[0].athleteName = lblName3.Text;
                newEvent.points[0].schoolName = lblSchool3.Text;
                newEvent.points[0].performance = lblPerformance3.Text;
            }
            else if (cboPlace3.Text == "2nd")
            {
                num2nds++;
                newEvent.points[1].athleteName = lblName3.Text;
                newEvent.points[1].schoolName = lblSchool3.Text;
                newEvent.points[1].performance = lblPerformance3.Text;
            }
            else if (cboPlace3.Text == "3rd")
            {
                num3rds++;
                newEvent.points[2].athleteName = lblName3.Text;
                newEvent.points[2].schoolName = lblSchool3.Text;
                newEvent.points[2].performance = lblPerformance3.Text;
            }

            if (cboPlace4.Text == "1st")
            {
                num1sts++;
                newEvent.points[0].athleteName = lblName4.Text;
                newEvent.points[0].schoolName = lblSchool4.Text;
                newEvent.points[0].performance = lblPerformance4.Text;
            }
            else if (cboPlace4.Text == "2nd")
            {
                num2nds++;
                newEvent.points[1].athleteName = lblName4.Text;
                newEvent.points[1].schoolName = lblSchool4.Text;
                newEvent.points[1].performance = lblPerformance4.Text;
            }
            else if (cboPlace4.Text == "3rd")
            {
                num3rds++;
                newEvent.points[2].athleteName = lblName4.Text;
                newEvent.points[2].schoolName = lblSchool4.Text;
                newEvent.points[2].performance = lblPerformance4.Text;
            }

            if (cboPlace5.Text == "1st")
            {
                num1sts++;
                newEvent.points[0].athleteName = lblName5.Text;
                newEvent.points[0].schoolName = lblSchool5.Text;
                newEvent.points[0].performance = lblPerformance5.Text;
            }
            else if (cboPlace5.Text == "2nd")
            {
                num2nds++;
                newEvent.points[1].athleteName = lblName5.Text;
                newEvent.points[1].schoolName = lblSchool5.Text;
                newEvent.points[1].performance = lblPerformance5.Text;
            }
            else if (cboPlace5.Text == "3rd")
            {
                num3rds++;
                newEvent.points[2].athleteName = lblName5.Text;
                newEvent.points[2].schoolName = lblSchool5.Text;
                newEvent.points[2].performance = lblPerformance5.Text;
            }

            if (cboPlace6.Text == "1st")
            {
                num1sts++;
                newEvent.points[0].athleteName = lblName6.Text;
                newEvent.points[0].schoolName = lblSchool6.Text;
                newEvent.points[0].performance = lblPerformance6.Text;
            }
            else if (cboPlace6.Text == "2nd")
            {
                num2nds++;
                newEvent.points[1].athleteName = lblName6.Text;
                newEvent.points[1].schoolName = lblSchool6.Text;
                newEvent.points[1].performance = lblPerformance6.Text;
            }
            else if (cboPlace6.Text == "3rd")
            {
                num3rds++;
                newEvent.points[2].athleteName = lblName6.Text;
                newEvent.points[2].schoolName = lblSchool6.Text;
                newEvent.points[2].performance = lblPerformance6.Text;
            }

            if (cboPlace7.Text == "1st")
            {
                num1sts++;
                newEvent.points[0].athleteName = lblName7.Text;
                newEvent.points[0].schoolName = lblSchool7.Text;
                newEvent.points[0].performance = lblPerformance7.Text;
            }
            else if (cboPlace7.Text == "2nd")
            {
                num2nds++;
                newEvent.points[1].athleteName = lblName7.Text;
                newEvent.points[1].schoolName = lblSchool7.Text;
                newEvent.points[1].performance = lblPerformance7.Text;
            }
            else if (cboPlace7.Text == "3rd")
            {
                num3rds++;
                newEvent.points[2].athleteName = lblName7.Text;
                newEvent.points[2].schoolName = lblSchool7.Text;
                newEvent.points[2].performance = lblPerformance7.Text;
            }

            if (cboPlace8.Text == "1st")
            {
                num1sts++;
                newEvent.points[0].athleteName = lblName8.Text;
                newEvent.points[0].schoolName = lblSchool8.Text;
                newEvent.points[0].performance = lblPerformance8.Text;
            }
            else if (cboPlace8.Text == "2nd")
            {
                num2nds++;
                newEvent.points[1].athleteName = lblName8.Text;
                newEvent.points[1].schoolName = lblSchool8.Text;
                newEvent.points[1].performance = lblPerformance8.Text;
            }
            else if (cboPlace8.Text == "3rd")
            {
                num3rds++;
                newEvent.points[2].athleteName = lblName8.Text;
                newEvent.points[2].schoolName = lblSchool8.Text;
                newEvent.points[2].performance = lblPerformance8.Text;
            }

            if (cboPlace9.Text == "1st")
            {
                num1sts++;
                newEvent.points[0].athleteName = lblName9.Text;
                newEvent.points[0].schoolName = lblSchool9.Text;
                newEvent.points[0].performance = lblPerformance9.Text;
            }
            else if (cboPlace9.Text == "2nd")
            {
                num2nds++;
                newEvent.points[1].athleteName = lblName9.Text;
                newEvent.points[1].schoolName = lblSchool9.Text;
                newEvent.points[1].performance = lblPerformance9.Text;
            }
            else if (cboPlace9.Text == "3rd")
            {
                num3rds++;
                newEvent.points[2].athleteName = lblName9.Text;
                newEvent.points[2].schoolName = lblSchool9.Text;
                newEvent.points[2].performance = lblPerformance9.Text;
            }

            if (cboPlace10.Text == "1st")
            {
                num1sts++;
                newEvent.points[0].athleteName = lblName10.Text;
                newEvent.points[0].schoolName = lblSchool10.Text;
                newEvent.points[0].performance = lblPerformance10.Text;
            }
            else if (cboPlace10.Text == "2nd")
            {
                num2nds++;
                newEvent.points[1].athleteName = lblName10.Text;
                newEvent.points[1].schoolName = lblSchool10.Text;
                newEvent.points[1].performance = lblPerformance10.Text;
            }
            else if (cboPlace10.Text == "3rd")
            {
                num3rds++;
                newEvent.points[2].athleteName = lblName10.Text;
                newEvent.points[2].schoolName = lblSchool10.Text;
                newEvent.points[2].performance = lblPerformance10.Text;
            }

            if (cboPlace11.Text == "1st")
            {
                num1sts++;
                newEvent.points[0].athleteName = lblName11.Text;
                newEvent.points[0].schoolName = lblSchool11.Text;
                newEvent.points[0].performance = lblPerformance11.Text;
            }
            else if (cboPlace11.Text == "2nd")
            {
                num2nds++;
                newEvent.points[1].athleteName = lblName11.Text;
                newEvent.points[1].schoolName = lblSchool11.Text;
                newEvent.points[1].performance = lblPerformance11.Text;
            }
            else if (cboPlace11.Text == "3rd")
            {
                num3rds++;
                newEvent.points[2].athleteName = lblName11.Text;
                newEvent.points[2].schoolName = lblSchool11.Text;
                newEvent.points[2].performance = lblPerformance11.Text;
            }

            if (cboPlace12.Text == "1st")
            {
                num1sts++;
                newEvent.points[0].athleteName = lblName12.Text;
                newEvent.points[0].schoolName = lblSchool12.Text;
                newEvent.points[0].performance = lblPerformance12.Text;
            }
            else if (cboPlace12.Text == "2nd")
            {
                num2nds++;
                newEvent.points[1].athleteName = lblName12.Text;
                newEvent.points[1].schoolName = lblSchool12.Text;
                newEvent.points[1].performance = lblPerformance12.Text;
            }
            else if (cboPlace12.Text == "3rd")
            {
                num3rds++;
                newEvent.points[2].athleteName = lblName12.Text;
                newEvent.points[2].schoolName = lblSchool12.Text;
                newEvent.points[2].performance = lblPerformance12.Text;
            }

            if (num1sts < 1)
                MessageBox.Show("Must have a 1st place", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (num1sts + num2nds < 2 && perf.Count >= 2)
                MessageBox.Show("Check Places", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (num1sts + num2nds + num3rds < 3 && perf.Count >= 3)
                MessageBox.Show("Check Places", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (num1sts >= 3 && num2nds + num3rds > 0)
                MessageBox.Show("Check Places", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (num1sts > 1 && num2nds > 0)
                MessageBox.Show("Check Places", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (num1sts + num2nds > 2 && num3rds > 0)
                MessageBox.Show("Check Places", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (em.ConvertFromLengthData(newEvent.points[0].performance) < em.ConvertFromLengthData(newEvent.points[1].performance))
                MessageBox.Show("2nd place cannot have a better performance than 1st place", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!string.IsNullOrWhiteSpace(newEvent.points[1].performance) && em.ConvertFromLengthData(newEvent.points[1].performance) < em.ConvertFromLengthData(newEvent.points[2].performance))
                MessageBox.Show("3rd place cannot have a better performance than 2nd place", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //Cycle through here and check that all ties have the same performance

                if (num1sts > 1)
                {
                    newEvent.points[0].athleteName = "TIE";
                    newEvent.points[0].schoolName = "TIE";
                }
                if (num2nds > 1)
                {
                    newEvent.points[1].athleteName = "TIE";
                    newEvent.points[1].schoolName = "TIE";
                }
                if (num3rds > 1)
                {
                    newEvent.points[2].athleteName = "TIE";
                    newEvent.points[2].schoolName = "TIE";
                }
            }
        }

        private void LoadPerformances()
        {
            EventMgr em = new EventMgr();
            if (perf.Count >= 1)
            {
                lblName1.Text = perf[0].athleteName;
                lblSchool1.Text = perf[0].schoolName;
                lblPerformance1.Text = em.ConvertToLengthData(perf[0].performance);

                lblName1.Visible = true;
                lblSchool1.Visible = true;
                lblPerformance1.Visible = true;
                cboPlace1.Visible = true;
            }
            if (perf.Count >= 2)
            {
                lblName2.Text = perf[1].athleteName;
                lblSchool2.Text = perf[1].schoolName;
                lblPerformance2.Text = em.ConvertToLengthData(perf[1].performance);

                lblName2.Visible = true;
                lblSchool2.Visible = true;
                lblPerformance2.Visible = true;
                cboPlace2.Visible = true;
            }
            if (perf.Count >= 3)
            {
                lblName3.Text = perf[2].athleteName;
                lblSchool3.Text = perf[2].schoolName;
                lblPerformance3.Text = em.ConvertToLengthData(perf[2].performance);

                lblName3.Visible = true;
                lblSchool3.Visible = true;
                lblPerformance3.Visible = true;
                cboPlace3.Visible = true;
            }
            if (perf.Count >= 4)
            {
                lblName4.Text = perf[3].athleteName;
                lblSchool4.Text = perf[3].schoolName;
                lblPerformance4.Text = em.ConvertToLengthData(perf[3].performance);

                lblName4.Visible = true;
                lblSchool4.Visible = true;
                lblPerformance4.Visible = true;
                cboPlace4.Visible = true;
            }
            if (perf.Count >= 5)
            {
                lblName5.Text = perf[4].athleteName;
                lblSchool5.Text = perf[4].schoolName;
                lblPerformance5.Text = em.ConvertToLengthData(perf[4].performance);

                lblName5.Visible = true;
                lblSchool5.Visible = true;
                lblPerformance5.Visible = true;
                cboPlace5.Visible = true;
            }
            if (perf.Count >= 6)
            {
                lblName6.Text = perf[5].athleteName;
                lblSchool6.Text = perf[5].schoolName;
                lblPerformance6.Text = em.ConvertToLengthData(perf[5].performance);

                lblName6.Visible = true;
                lblSchool6.Visible = true;
                lblPerformance6.Visible = true;
                cboPlace6.Visible = true;
            }
            if (perf.Count >= 7)
            {
                lblName7.Text = perf[6].athleteName;
                lblSchool7.Text = perf[6].schoolName;
                lblPerformance7.Text = em.ConvertToLengthData(perf[6].performance);

                lblName7.Visible = true;
                lblSchool7.Visible = true;
                lblPerformance7.Visible = true;
                cboPlace7.Visible = true;
            }
            if (perf.Count >= 8)
            {
                lblName8.Text = perf[7].athleteName;
                lblSchool8.Text = perf[7].schoolName;
                lblPerformance8.Text = em.ConvertToLengthData(perf[7].performance);

                lblName8.Visible = true;
                lblSchool8.Visible = true;
                lblPerformance8.Visible = true;
                cboPlace8.Visible = true;
            }
            if (perf.Count >= 9)
            {
                lblName9.Text = perf[8].athleteName;
                lblSchool9.Text = perf[8].schoolName;
                lblPerformance9.Text = em.ConvertToLengthData(perf[8].performance);

                lblName9.Visible = true;
                lblSchool9.Visible = true;
                lblPerformance9.Visible = true;
                cboPlace9.Visible = true;
            }
            if (perf.Count >= 10)
            {
                lblName10.Text = perf[9].athleteName;
                lblSchool10.Text = perf[9].schoolName;
                lblPerformance10.Text = em.ConvertToLengthData(perf[9].performance);

                lblName10.Visible = true;
                lblSchool10.Visible = true;
                lblPerformance10.Visible = true;
                cboPlace10.Visible = true;
            }
            if (perf.Count >= 11)
            {
                lblName11.Text = perf[10].athleteName;
                lblSchool11.Text = perf[10].schoolName;
                lblPerformance11.Text = em.ConvertToLengthData(perf[10].performance);

                lblName11.Visible = true;
                lblSchool11.Visible = true;
                lblPerformance11.Visible = true;
                cboPlace11.Visible = true;
            }
            if (perf.Count >= 12)
            {
                lblName12.Text = perf[11].athleteName;
                lblSchool12.Text = perf[11].schoolName;
                lblPerformance12.Text = em.ConvertToLengthData(perf[11].performance);

                lblName12.Visible = true;
                lblSchool12.Visible = true;
                lblPerformance12.Visible = true;
                cboPlace12.Visible = true;
            }
            if (perf.Count >= 13)
            {
                lblName13.Text = perf[12].athleteName;
                lblSchool13.Text = perf[12].schoolName;
                lblPerformance13.Text = em.ConvertToLengthData(perf[12].performance);

                lblName13.Visible = true;
                lblSchool13.Visible = true;
                lblPerformance13.Visible = true;
                cboPlace13.Visible = true;
            }
            if (perf.Count >= 14)
            {
                lblName14.Text = perf[13].athleteName;
                lblSchool14.Text = perf[13].schoolName;
                lblPerformance14.Text = em.ConvertToLengthData(perf[13].performance);

                lblName14.Visible = true;
                lblSchool14.Visible = true;
                lblPerformance14.Visible = true;
                cboPlace14.Visible = true;
            }
            if (perf.Count >= 15)
            {
                lblName15.Text = perf[14].athleteName;
                lblSchool15.Text = perf[14].schoolName;
                lblPerformance15.Text = em.ConvertToLengthData(perf[14].performance);

                lblName15.Visible = true;
                lblSchool15.Visible = true;
                lblPerformance15.Visible = true;
                cboPlace15.Visible = true;
            }
            if (perf.Count >= 16)
            {
                lblName16.Text = perf[15].athleteName;
                lblSchool16.Text = perf[15].schoolName;
                lblPerformance16.Text = em.ConvertToLengthData(perf[15].performance);

                lblName16.Visible = true;
                lblSchool16.Visible = true;
                lblPerformance16.Visible = true;
                cboPlace16.Visible = true;
            }
        }
    }
}
