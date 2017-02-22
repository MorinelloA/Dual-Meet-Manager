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
        public MeetHub()
        {
            InitializeComponent();
        }

        Meet activeMeet;

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
            //Needs refactored to include data, if it exists
            RunningEventEntry newForm = new RunningEventEntry("Boy's 100", null);
            this.Hide();
            newForm.ShowDialog();
            //this.Close();
        }
    }
}
