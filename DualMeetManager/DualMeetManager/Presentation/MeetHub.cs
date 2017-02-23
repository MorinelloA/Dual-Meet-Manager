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
    public partial class MeetHub : Form
    {
        public void TestTest()
        {
            Console.WriteLine("Test is a success");
        }

        public void AddEvent(string eventName, List<Performance> perfsToAdd)
        {
            EventMgr em = new EventMgr();
            activeMeet.performances = em.AddPerformanceToEvent(activeMeet.performances, eventName, perfsToAdd);
        }

        public MeetHub()
        {
            InitializeComponent();
        }

        Meet activeMeet = new Meet();

        //Generate List of Boy's team Abbrs from Dictionary
        List<string> boysAbbrs = new List<string>();

        //Generate List of Girl's team Abbrs from Dictionary
        List<string> girlsAbbrs = new List<string>();

        public MeetHub(Meet activeMeet) : this()
        {
            this.activeMeet = activeMeet;
        }

        private void MeetHub_Load(object sender, EventArgs e)
        {
            //Populate Boys List
            foreach (KeyValuePair<string, string> entry in activeMeet.schoolNames.boySchoolNames)
            {
                boysAbbrs.Add(entry.Key);
            }

            mnuPrintoutsBoysTeamPerfsTeam1.Text = boysAbbrs[0];

            if (activeMeet.schoolNames.boySchoolNames.Count >= 2)
            {
                //Scores
                mnuPrintoutsBoysScores.Visible = true;
                mnuPrintoutsBoysScores1vs2.Text = boysAbbrs[0] + " vs " + boysAbbrs[1];

                //Team Perf
                mnuPrintoutsBoysTeamPerfsAll.Visible = true;
                mnuPrintoutsBoysTeamPerfsTeam2.Visible = true;
                mnuPrintoutsBoysTeamPerfsTeam2.Text = boysAbbrs[1];

                if (activeMeet.schoolNames.boySchoolNames.Count >= 3)
                {
                    //Scores
                    mnuPrintoutsBoysScoresAll.Visible = true;
                    mnuPrintoutsBoysScores1vs3.Visible = true;
                    mnuPrintoutsBoysScores1vs3.Text = boysAbbrs[0] + " vs " + boysAbbrs[2];
                    mnuPrintoutsBoysScores2vs3.Visible = true;
                    mnuPrintoutsBoysScores2vs3.Text = boysAbbrs[1] + " vs " + boysAbbrs[2];

                    //Team Perf
                    mnuPrintoutsBoysTeamPerfsTeam3.Visible = true;
                    mnuPrintoutsBoysTeamPerfsTeam3.Text = boysAbbrs[2];

                    if (activeMeet.schoolNames.boySchoolNames.Count >= 4)
                    {
                        //Scores
                        mnuPrintoutsBoysScores1vs4.Visible = true;
                        mnuPrintoutsBoysScores1vs4.Text = boysAbbrs[0] + " vs " + boysAbbrs[3];
                        mnuPrintoutsBoysScores2vs4.Visible = true;
                        mnuPrintoutsBoysScores2vs4.Text = boysAbbrs[1] + " vs " + boysAbbrs[3];
                        mnuPrintoutsBoysScores3vs4.Visible = true;
                        mnuPrintoutsBoysScores3vs4.Text = boysAbbrs[2] + " vs " + boysAbbrs[3];

                        //Team Perf
                        mnuPrintoutsBoysTeamPerfsTeam4.Visible = true;
                        mnuPrintoutsBoysTeamPerfsTeam4.Text = boysAbbrs[3];

                        if (activeMeet.schoolNames.boySchoolNames.Count >= 5)
                        {
                            //Scores
                            mnuPrintoutsBoysScores1vs5.Visible = true;
                            mnuPrintoutsBoysScores1vs5.Text = boysAbbrs[0] + " vs " + boysAbbrs[4];
                            mnuPrintoutsBoysScores2vs5.Visible = true;
                            mnuPrintoutsBoysScores2vs5.Text = boysAbbrs[1] + " vs " + boysAbbrs[4];
                            mnuPrintoutsBoysScores3vs5.Visible = true;
                            mnuPrintoutsBoysScores3vs5.Text = boysAbbrs[2] + " vs " + boysAbbrs[4];
                            mnuPrintoutsBoysScores4vs5.Visible = true;
                            mnuPrintoutsBoysScores4vs5.Text = boysAbbrs[3] + " vs " + boysAbbrs[4];

                            //Team Perf
                            mnuPrintoutsBoysTeamPerfsTeam5.Visible = true;
                            mnuPrintoutsBoysTeamPerfsTeam5.Text = boysAbbrs[4];

                            if (activeMeet.schoolNames.boySchoolNames.Count >= 6)
                            {
                                //Scores
                                mnuPrintoutsBoysScores1vs6.Visible = true;
                                mnuPrintoutsBoysScores1vs6.Text = boysAbbrs[0] + " vs " + boysAbbrs[5];
                                mnuPrintoutsBoysScores2vs6.Visible = true;
                                mnuPrintoutsBoysScores2vs6.Text = boysAbbrs[1] + " vs " + boysAbbrs[5];
                                mnuPrintoutsBoysScores3vs6.Visible = true;
                                mnuPrintoutsBoysScores3vs6.Text = boysAbbrs[2] + " vs " + boysAbbrs[5];
                                mnuPrintoutsBoysScores4vs6.Visible = true;
                                mnuPrintoutsBoysScores4vs6.Text = boysAbbrs[3] + " vs " + boysAbbrs[5];
                                mnuPrintoutsBoysScores5vs6.Visible = true;
                                mnuPrintoutsBoysScores5vs6.Text = boysAbbrs[4] + " vs " + boysAbbrs[5];

                                //Team Perf
                                mnuPrintoutsBoysTeamPerfsTeam6.Visible = true;
                                mnuPrintoutsBoysTeamPerfsTeam6.Text = boysAbbrs[5];
                            }
                        }
                    }
                }
            } // End Boy's data

            //Populate Girls List
            foreach (KeyValuePair<string, string> entry in activeMeet.schoolNames.girlSchoolNames)
            {
                girlsAbbrs.Add(entry.Key);
            }

            mnuPrintoutsGirlsTeamPerfsTeam1.Text = girlsAbbrs[0];

            if (activeMeet.schoolNames.girlSchoolNames.Count >= 2)
            {
                //Scores
                mnuPrintoutsGirlsScores.Visible = true;
                mnuPrintoutsGirlsScores1vs2.Text = girlsAbbrs[0] + " vs " + girlsAbbrs[1];

                //Team Perf
                mnuPrintoutsGirlsTeamPerfsAll.Visible = true;
                mnuPrintoutsGirlsTeamPerfsTeam2.Visible = true;
                mnuPrintoutsGirlsTeamPerfsTeam2.Text = girlsAbbrs[1];

                if (activeMeet.schoolNames.girlSchoolNames.Count >= 3)
                {
                    //Scores
                    mnuPrintoutsGirlsScoresAll.Visible = true;
                    mnuPrintoutsGirlsScores1vs3.Visible = true;
                    mnuPrintoutsGirlsScores1vs3.Text = girlsAbbrs[0] + " vs " + girlsAbbrs[2];
                    mnuPrintoutsGirlsScores2vs3.Visible = true;
                    mnuPrintoutsGirlsScores2vs3.Text = girlsAbbrs[1] + " vs " + girlsAbbrs[2];

                    //Team Perf
                    mnuPrintoutsGirlsTeamPerfsTeam3.Visible = true;
                    mnuPrintoutsGirlsTeamPerfsTeam3.Text = girlsAbbrs[2];

                    if (activeMeet.schoolNames.girlSchoolNames.Count >= 4)
                    {
                        //Scores
                        mnuPrintoutsGirlsScores1vs4.Visible = true;
                        mnuPrintoutsGirlsScores1vs4.Text = girlsAbbrs[0] + " vs " + girlsAbbrs[3];
                        mnuPrintoutsGirlsScores2vs4.Visible = true;
                        mnuPrintoutsGirlsScores2vs4.Text = girlsAbbrs[1] + " vs " + girlsAbbrs[3];
                        mnuPrintoutsGirlsScores3vs4.Visible = true;
                        mnuPrintoutsGirlsScores3vs4.Text = girlsAbbrs[2] + " vs " + girlsAbbrs[3];

                        //Team Perf
                        mnuPrintoutsGirlsTeamPerfsTeam4.Visible = true;
                        mnuPrintoutsGirlsTeamPerfsTeam4.Text = girlsAbbrs[3];

                        if (activeMeet.schoolNames.girlSchoolNames.Count >= 5)
                        {
                            //Scores
                            mnuPrintoutsGirlsScores1vs5.Visible = true;
                            mnuPrintoutsGirlsScores1vs5.Text = girlsAbbrs[0] + " vs " + girlsAbbrs[4];
                            mnuPrintoutsGirlsScores2vs5.Visible = true;
                            mnuPrintoutsGirlsScores2vs5.Text = girlsAbbrs[1] + " vs " + girlsAbbrs[4];
                            mnuPrintoutsGirlsScores3vs5.Visible = true;
                            mnuPrintoutsGirlsScores3vs5.Text = girlsAbbrs[2] + " vs " + girlsAbbrs[4];
                            mnuPrintoutsGirlsScores4vs5.Visible = true;
                            mnuPrintoutsGirlsScores4vs5.Text = girlsAbbrs[3] + " vs " + girlsAbbrs[4];

                            //Team Perf
                            mnuPrintoutsGirlsTeamPerfsTeam5.Visible = true;
                            mnuPrintoutsGirlsTeamPerfsTeam5.Text = girlsAbbrs[4];

                            if (activeMeet.schoolNames.girlSchoolNames.Count >= 6)
                            {
                                //Scores
                                mnuPrintoutsGirlsScores1vs6.Visible = true;
                                mnuPrintoutsGirlsScores1vs6.Text = girlsAbbrs[0] + " vs " + girlsAbbrs[5];
                                mnuPrintoutsGirlsScores2vs6.Visible = true;
                                mnuPrintoutsGirlsScores2vs6.Text = girlsAbbrs[1] + " vs " + girlsAbbrs[5];
                                mnuPrintoutsGirlsScores3vs6.Visible = true;
                                mnuPrintoutsGirlsScores3vs6.Text = girlsAbbrs[2] + " vs " + girlsAbbrs[5];
                                mnuPrintoutsGirlsScores4vs6.Visible = true;
                                mnuPrintoutsGirlsScores4vs6.Text = girlsAbbrs[3] + " vs " + girlsAbbrs[5];
                                mnuPrintoutsGirlsScores5vs6.Visible = true;
                                mnuPrintoutsGirlsScores5vs6.Text = girlsAbbrs[4] + " vs " + girlsAbbrs[5];

                                //Team Perf
                                mnuPrintoutsGirlsTeamPerfsTeam6.Visible = true;
                                mnuPrintoutsGirlsTeamPerfsTeam6.Text = girlsAbbrs[5];
                            }
                        }
                    }
                }
            } // End Girl's data
        }

        private void mnuEnterBoysSprints100_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's 100"))
            {
                newForm = new RunningEventEntry(this, "Boy's 100", activeMeet.performances["Boy's 100"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Boy's 100", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine(activeMeet.ToString());
        }

        private void mnuEnterBoysSprints200_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's 200"))
            {
                newForm = new RunningEventEntry(this, "Boy's 200", activeMeet.performances["Boy's 200"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Boy's 200", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterBoysSprints400_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's 400"))
            {
                newForm = new RunningEventEntry(this, "Boy's 400", activeMeet.performances["Boy's 400"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Boy's 400", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterBoysDistance800_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's 800"))
            {
                newForm = new RunningEventEntry(this, "Boy's 800", activeMeet.performances["Boy's 800"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Boy's 800", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterBoysDistance1600_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's 1600"))
            {
                newForm = new RunningEventEntry(this, "Boy's 1600", activeMeet.performances["Boy's 1600"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Boy's 1600", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterBoysDistance3200_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's 3200"))
            {
                newForm = new RunningEventEntry(this, "Boy's 3200", activeMeet.performances["Boy's 3200"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Boy's 3200", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void highHurdlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's HH"))
            {
                newForm = new RunningEventEntry(this, "Boy's HH", activeMeet.performances["Boy's HH"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Boy's HH", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterBoysHurdles300_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's 300H"))
            {
                newForm = new RunningEventEntry(this, "Boy's 300H", activeMeet.performances["Boy's 300H"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Boy's 300H", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterBoysRelays4x100_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet Implemented", "Coming Soon", MessageBoxButtons.OK ,MessageBoxIcon.Asterisk);
        }

        private void mnuEnterGirlsSprints100_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's 100"))
            {
                newForm = new RunningEventEntry(this, "Girl's 100", activeMeet.performances["Girl's 100"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Girl's 100", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsSprints200_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's 200"))
            {
                newForm = new RunningEventEntry(this, "Girl's 200", activeMeet.performances["Girl's 200"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Girl's 200", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsSprints400_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's 400"))
            {
                newForm = new RunningEventEntry(this, "Girl's 400", activeMeet.performances["Girl's 400"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Girl's 400", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsDistance800_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's 800"))
            {
                newForm = new RunningEventEntry(this, "Girl's 800", activeMeet.performances["Girl's 800"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Girl's 800", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsDistance1600_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's 1600"))
            {
                newForm = new RunningEventEntry(this, "Girl's 1600", activeMeet.performances["Girl's 1600"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Girl's 1600", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsDistance3200_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's 3200"))
            {
                newForm = new RunningEventEntry(this, "Girl's 3200", activeMeet.performances["Girl's 3200"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Girl's 3200", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsHurdlesHigh_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's HH"))
            {
                newForm = new RunningEventEntry(this, "Girl's HH", activeMeet.performances["Girl's HH"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Girl's HH", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsHurdles300_Click(object sender, EventArgs e)
        {
            RunningEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's 300H"))
            {
                newForm = new RunningEventEntry(this, "Girl's 300H", activeMeet.performances["Girl's 300H"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new RunningEventEntry(this, "Girl's 300H", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }
    }
}
