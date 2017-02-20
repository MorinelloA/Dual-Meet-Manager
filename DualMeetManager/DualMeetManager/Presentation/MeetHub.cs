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
            }
        }
    }
}
