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
    public partial class MeetHub : Form
    {
        public IndEvent tieBreakerEvent = new IndEvent();

        //Overall Scores for every dual meet taking place
        Dictionary<string, OverallScore> boysActiveScores = new Dictionary<string, OverallScore>();
        Dictionary<string, OverallScore> girlsActiveScores = new Dictionary<string, OverallScore>();

        //Entire Meet
        Meet activeMeet = new Meet();

        //File Path/Name for saving the Meet
        string file = "";

        //Generate List of Boy's team Abbrs from Dictionary
        List<string> boysAbbrs = new List<string>();

        //Generate List of Girl's team Abbrs from Dictionary
        List<string> girlsAbbrs = new List<string>();

        public void AddEvent(string eventName, List<Performance> perfsToAdd)
        {
            EventMgr em = new EventMgr();
            activeMeet.performances = em.AddPerformanceToEvent(activeMeet.performances, eventName, perfsToAdd);
        }

        public void CalculateScoreTotals()
        {
            lstBoysScores.Items.Clear();
            lstGirlsScores.Items.Clear();

            ScoringMgr sm = new ScoringMgr();

            Dictionary<string, OverallScore> tempDictionary = new Dictionary<string, OverallScore>();

            foreach (string s in boysActiveScores.Keys)
            {
                tempDictionary.Add(s, sm.CalculateTotal(boysActiveScores[s], "Boy"));
                lstBoysScores.Items.Add(boysActiveScores[s].team1.Item2 + ": " + boysActiveScores[s].team1Points.ToString("0.###") + " - " + boysActiveScores[s].team2.Item2 + ": " + boysActiveScores[s].team2Points.ToString("0.###"));
            }
            boysActiveScores = tempDictionary;

            Dictionary<string, OverallScore> tempDictionaryg = new Dictionary<string, OverallScore>();
            foreach (string s in girlsActiveScores.Keys)
            {
                //girlsActiveScores[s] = sm.CalculateTotal(girlsActiveScores[s], "Girl");
                tempDictionaryg.Add(s, sm.CalculateTotal(girlsActiveScores[s], "Girl"));
                lstGirlsScores.Items.Add(girlsActiveScores[s].team1.Item2 + ": " + girlsActiveScores[s].team1Points.ToString("0.###") + " - " + girlsActiveScores[s].team2.Item2 + ": " + girlsActiveScores[s].team2Points.ToString("0.###"));
            }
            girlsActiveScores = tempDictionaryg;
        }

        public void AddRelayEventToScores(string gender, string eventName, List<Performance> perf)
        {
            ScoringMgr sm = new ScoringMgr();

            if (gender.StartsWith("Boy", StringComparison.OrdinalIgnoreCase))
            {
                foreach (string t1 in activeMeet.schoolNames.boySchoolNames.Keys)
                {
                    foreach (string t2 in activeMeet.schoolNames.boySchoolNames.Keys)
                    {
                        if (boysActiveScores.ContainsKey(t1 + "vs." + t2))
                        {
                            RelayEvent newEventToAdd = sm.CalculateRelayEvent(t1, t2, perf);
                            boysActiveScores[t1 + "vs." + t2] = sm.AddEvent(boysActiveScores[t1 + "vs." + t2], eventName, newEventToAdd);
                        }
                    }
                }
            }
            else if (gender.StartsWith("Girl", StringComparison.OrdinalIgnoreCase))
            {
                foreach (string t1 in activeMeet.schoolNames.girlSchoolNames.Keys)
                {
                    foreach (string t2 in activeMeet.schoolNames.girlSchoolNames.Keys)
                    {
                        if (girlsActiveScores.ContainsKey(t1 + "vs." + t2))
                        {
                            RelayEvent newEventToAdd = sm.CalculateRelayEvent(t1, t2, perf);
                            girlsActiveScores[t1 + "vs." + t2] = sm.AddEvent(girlsActiveScores[t1 + "vs." + t2], eventName, newEventToAdd);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("ERROR in AddRelayEventToScores - gender not Boy or Girl");
                Console.WriteLine("gender = " + gender);
                MessageBox.Show("Error Adding running event to scores");
            }

            CalculateScoreTotals();
        }

        public void AddFieldEventToScores(string gender, string eventName, List<Performance> perf)
        {
            ScoringMgr sm = new ScoringMgr();

            if (gender.StartsWith("Boy", StringComparison.OrdinalIgnoreCase))
            {
                foreach (string t1 in activeMeet.schoolNames.boySchoolNames.Keys)
                {
                    foreach (string t2 in activeMeet.schoolNames.boySchoolNames.Keys)
                    {
                        if (boysActiveScores.ContainsKey(t1 + "vs." + t2))
                        {
                            IndEvent newEventToAdd = sm.CalculateFieldEvent(t1, t2, perf);

                            if (newEventToAdd == null)
                            {
                                FieldEventTieBreaker fetb = new FieldEventTieBreaker(this, t1, t2, perf);
                                fetb.ShowDialog();
                                newEventToAdd = tieBreakerEvent;
                                tieBreakerEvent = null;
                            }

                            boysActiveScores[t1 + "vs." + t2] = sm.AddEvent(boysActiveScores[t1 + "vs." + t2], eventName, newEventToAdd);
                        }
                    }
                }
            }
            else if (gender.StartsWith("Girl", StringComparison.OrdinalIgnoreCase))
            {
                foreach (string t1 in activeMeet.schoolNames.girlSchoolNames.Keys)
                {
                    foreach (string t2 in activeMeet.schoolNames.girlSchoolNames.Keys)
                    {
                        if (girlsActiveScores.ContainsKey(t1 + "vs." + t2))
                        {
                            IndEvent newEventToAdd = sm.CalculateFieldEvent(t1, t2, perf);

                            if (newEventToAdd == null)
                            {
                                FieldEventTieBreaker fetb = new FieldEventTieBreaker(this, t1, t2, perf);
                                fetb.ShowDialog();
                                newEventToAdd = tieBreakerEvent;
                                tieBreakerEvent = null;
                            }

                            girlsActiveScores[t1 + "vs." + t2] = sm.AddEvent(girlsActiveScores[t1 + "vs." + t2], eventName, newEventToAdd);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("ERROR in AddFieldEventToScores - gender not Boy or Girl");
                Console.WriteLine("gender = " + gender);
                MessageBox.Show("Error Adding running event to scores");
            }

            CalculateScoreTotals();
        }

        public void AddRunningEventToScores(string gender, string eventName, List<Performance> perf)
        {
            ScoringMgr sm = new ScoringMgr();

            if (gender.StartsWith("Boy", StringComparison.OrdinalIgnoreCase))
            {
                foreach (string t1 in activeMeet.schoolNames.boySchoolNames.Keys)
                {
                    foreach (string t2 in activeMeet.schoolNames.boySchoolNames.Keys)
                    {
                        if(boysActiveScores.ContainsKey(t1 + "vs." + t2))
                        {
                            IndEvent newEventToAdd = sm.CalculateRunningEvent(t1, t2, perf);
                            boysActiveScores[t1 + "vs." + t2] = sm.AddEvent(boysActiveScores[t1 + "vs." + t2], eventName, newEventToAdd);
                        }
                    }
                }
            }
            else if (gender.StartsWith("Girl", StringComparison.OrdinalIgnoreCase))
            {
                foreach (string t1 in activeMeet.schoolNames.girlSchoolNames.Keys)
                {
                    foreach (string t2 in activeMeet.schoolNames.girlSchoolNames.Keys)
                    {
                        if (girlsActiveScores.ContainsKey(t1 + "vs." + t2))
                        {
                            IndEvent newEventToAdd = sm.CalculateRunningEvent(t1, t2, perf);
                            girlsActiveScores[t1 + "vs." + t2] = sm.AddEvent(girlsActiveScores[t1 + "vs." + t2], eventName, newEventToAdd);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("ERROR in AddRunningEventToScores - gender not Boy or Girl");
                Console.WriteLine("gender = " + gender);
                MessageBox.Show("Error Adding running event to scores");
            }

            CalculateScoreTotals();
        }

        public MeetHub()
        {
            InitializeComponent();
        }

        public MeetHub(Meet activeMeet) : this()
        {
            this.activeMeet = activeMeet;
            FormLoadHelper();

            if (activeMeet != null && activeMeet.performances != null)
            {
                if (activeMeet.performances.ContainsKey("Boy's 100"))
                    AddRunningEventToScores("Boy", "Boy's 100", activeMeet.performances["Boy's 100"]);
                if (activeMeet.performances.ContainsKey("Boy's 200"))
                    AddRunningEventToScores("Boy", "Boy's 200", activeMeet.performances["Boy's 200"]);
                if (activeMeet.performances.ContainsKey("Boy's 400"))
                    AddRunningEventToScores("Boy", "Boy's 400", activeMeet.performances["Boy's 400"]);
                if (activeMeet.performances.ContainsKey("Boy's 800"))
                    AddRunningEventToScores("Boy", "Boy's 800", activeMeet.performances["Boy's 800"]);
                if (activeMeet.performances.ContainsKey("Boy's 1600"))
                    AddRunningEventToScores("Boy", "Boy's 1600", activeMeet.performances["Boy's 1600"]);
                if (activeMeet.performances.ContainsKey("Boy's 3200"))
                    AddRunningEventToScores("Boy", "Boy's 3200", activeMeet.performances["Boy's 3200"]);
                if (activeMeet.performances.ContainsKey("Boy's HH"))
                    AddRunningEventToScores("Boy", "Boy's HH", activeMeet.performances["Boy's HH"]);
                if (activeMeet.performances.ContainsKey("Boy's 300H"))
                    AddRunningEventToScores("Boy", "Boy's 300H", activeMeet.performances["Boy's 300H"]);
                if (activeMeet.performances.ContainsKey("Boy's 4x100"))
                    AddRelayEventToScores("Boy", "Boy's 4x100", activeMeet.performances["Boy's 4x100"]);
                if (activeMeet.performances.ContainsKey("Boy's 4x400"))
                    AddRelayEventToScores("Boy", "Boy's 4x400", activeMeet.performances["Boy's 4x400"]);
                if (activeMeet.performances.ContainsKey("Boy's 4x800"))
                    AddRelayEventToScores("Boy", "Boy's 4x800", activeMeet.performances["Boy's 4x800"]);
                if (activeMeet.performances.ContainsKey("Boy's LJ"))
                    AddFieldEventToScores("Boy", "Boy's LJ", activeMeet.performances["Boy's LJ"]);
                if (activeMeet.performances.ContainsKey("Boy's TJ"))
                    AddFieldEventToScores("Boy", "Boy's TJ", activeMeet.performances["Boy's TJ"]);
                if (activeMeet.performances.ContainsKey("Boy's HJ"))
                    AddFieldEventToScores("Boy", "Boy's HJ", activeMeet.performances["Boy's HJ"]);
                if (activeMeet.performances.ContainsKey("Boy's PV"))
                    AddFieldEventToScores("Boy", "Boy's PV", activeMeet.performances["Boy's PV"]);
                if (activeMeet.performances.ContainsKey("Boy's Shotput"))
                    AddFieldEventToScores("Boy", "Boy's Shotput", activeMeet.performances["Boy's Shotput"]);
                if (activeMeet.performances.ContainsKey("Boy's Discus"))
                    AddFieldEventToScores("Boy", "Boy's Discus", activeMeet.performances["Boy's Discus"]);
                if (activeMeet.performances.ContainsKey("Boy's Javelin"))
                    AddFieldEventToScores("Boy", "Boy's Javelin", activeMeet.performances["Boy's Javelin"]);

                if (activeMeet.performances.ContainsKey("Girl's 100"))
                    AddRunningEventToScores("Girl", "Girl's 100", activeMeet.performances["Girl's 100"]);
                if (activeMeet.performances.ContainsKey("Girl's 200"))
                    AddRunningEventToScores("Girl", "Girl's 200", activeMeet.performances["Girl's 200"]);
                if (activeMeet.performances.ContainsKey("Girl's 400"))
                    AddRunningEventToScores("Girl", "Girl's 400", activeMeet.performances["Girl's 400"]);
                if (activeMeet.performances.ContainsKey("Girl's 800"))
                    AddRunningEventToScores("Girl", "Girl's 800", activeMeet.performances["Girl's 800"]);
                if (activeMeet.performances.ContainsKey("Girl's 1600"))
                    AddRunningEventToScores("Girl", "Girl's 1600", activeMeet.performances["Girl's 1600"]);
                if (activeMeet.performances.ContainsKey("Girl's 3200"))
                    AddRunningEventToScores("Girl", "Girl's 3200", activeMeet.performances["Girl's 3200"]);
                if (activeMeet.performances.ContainsKey("Girl's HH"))
                    AddRunningEventToScores("Girl", "Girl's HH", activeMeet.performances["Girl's HH"]);
                if (activeMeet.performances.ContainsKey("Girl's 300H"))
                    AddRunningEventToScores("Girl", "Girl's 300H", activeMeet.performances["Girl's 300H"]);
                if (activeMeet.performances.ContainsKey("Girl's 4x100"))
                    AddRelayEventToScores("Girl", "Girl's 4x100", activeMeet.performances["Girl's 4x100"]);
                if (activeMeet.performances.ContainsKey("Girl's 4x400"))
                    AddRelayEventToScores("Girl", "Girl's 4x400", activeMeet.performances["Girl's 4x400"]);
                if (activeMeet.performances.ContainsKey("Girl's 4x800"))
                    AddRelayEventToScores("Girl", "Girl's 4x800", activeMeet.performances["Girl's 4x800"]);
                if (activeMeet.performances.ContainsKey("Girl's LJ"))
                    AddFieldEventToScores("Girl", "Girl's LJ", activeMeet.performances["Girl's LJ"]);
                if (activeMeet.performances.ContainsKey("Girl's TJ"))
                    AddFieldEventToScores("Girl", "Girl's TJ", activeMeet.performances["Girl's TJ"]);
                if (activeMeet.performances.ContainsKey("Girl's HJ"))
                    AddFieldEventToScores("Girl", "Girl's HJ", activeMeet.performances["Girl's HJ"]);
                if (activeMeet.performances.ContainsKey("Girl's PV"))
                    AddFieldEventToScores("Girl", "Girl's PV", activeMeet.performances["Girl's PV"]);
                if (activeMeet.performances.ContainsKey("Girl's Shotput"))
                    AddFieldEventToScores("Girl", "Girl's Shotput", activeMeet.performances["Girl's Shotput"]);
                if (activeMeet.performances.ContainsKey("Girl's Discus"))
                    AddFieldEventToScores("Girl", "Girl's Discus", activeMeet.performances["Girl's Discus"]);
                if (activeMeet.performances.ContainsKey("Girl's Javelin"))
                    AddFieldEventToScores("Girl", "Girl's Javelin", activeMeet.performances["Girl's Javelin"]);
            }
        }

        private void MeetHub_Load(object sender, EventArgs e)
        {
            FormLoadHelper();
        }

        private void FormLoadHelper()
        {
            //Create OverallScores
            foreach (string t1 in activeMeet.schoolNames.boySchoolNames.Keys)
            {
                foreach (string t2 in activeMeet.schoolNames.boySchoolNames.Keys)
                {
                    if (t1 != t2 && !boysActiveScores.ContainsKey(t2 + "vs." + t1) && !boysActiveScores.ContainsKey(t1 + "vs." + t2))
                    {
                        boysActiveScores.Add(t1 + "vs." + t2, new OverallScore(Tuple.Create(t1, activeMeet.schoolNames.boySchoolNames[t1]), Tuple.Create(t2, activeMeet.schoolNames.boySchoolNames[t2])));
                    }
                }
            }
            foreach (string t1 in activeMeet.schoolNames.girlSchoolNames.Keys)
            {
                foreach (string t2 in activeMeet.schoolNames.girlSchoolNames.Keys)
                {
                    if (t1 != t2 && !girlsActiveScores.ContainsKey(t2 + "vs." + t1) && !girlsActiveScores.ContainsKey(t1 + "vs." + t2))
                        girlsActiveScores.Add(t1 + "vs." + t2, new OverallScore(Tuple.Create(t1, activeMeet.schoolNames.girlSchoolNames[t1]), Tuple.Create(t2, activeMeet.schoolNames.girlSchoolNames[t2])));
                }
            }

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

        private void mnuEnterBoysHurdlesHigh_Click(object sender, EventArgs e)
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
            RelayEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's 4x100"))
            {
                newForm = new RelayEventEntry(this, "Boy's 4x100", activeMeet.performances["Boy's 4x100"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new RelayEventEntry(this, "Boy's 4x100", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
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

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(file))
            {
                //Get file name and path
                if(sfdMeet.ShowDialog() == DialogResult.OK)
                {
                    MeetMgr mm = new MeetMgr();
                    mm.saveMeet(file, activeMeet);
                }
            }
            else
            {
                MeetMgr mm = new MeetMgr();
                mm.saveMeet(file, activeMeet);
            }
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdMeet.ShowDialog() == DialogResult.OK)
            {
                MeetMgr mm = new MeetMgr();
                Meet newMeet = mm.openMeet(ofdMeet.FileName);
                MeetHub newForm = new MeetHub(newMeet);
                this.Hide();
                newForm.ShowDialog();
                this.Close();
            }
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            //Get file name and path
            if (sfdMeet.ShowDialog() == DialogResult.OK)
            {
                MeetMgr mm = new MeetMgr();
                mm.saveMeet(file, activeMeet);
            }
        }

        private void sfdMeet_FileOk(object sender, CancelEventArgs e)
        {
            file = sfdMeet.FileName;
        }

        public void SortPerfs(string eventName)
        {
            if (activeMeet == null || activeMeet.performances == null || !activeMeet.performances.ContainsKey(eventName))
            {
                Console.WriteLine("Meet information for " + eventName + " not available");
            }
            else
            {
                activeMeet.performances[eventName] = activeMeet.performances[eventName].OrderBy(o => o.performance).ToList();
            }
        }

        private void printEvent(string eventName)
        {
            PrintoutMgr pm = new PrintoutMgr();
            SortPerfs(eventName);
            if (activeMeet == null || activeMeet.performances == null || !activeMeet.performances.ContainsKey(eventName))
            {
                MessageBox.Show("Meet information for " + eventName + " not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pm.CreateIndEventDoc(eventName, activeMeet.performances[eventName]);
            }
        }

        private void mnuPrintoutsBoysEventPerfsSprints100_Click(object sender, EventArgs e)
        {
            printEvent("Boy's 100");
        }

        private void mnuPrintoutsBoysEventPerfsSprints200_Click(object sender, EventArgs e)
        {
            printEvent("Boy's 200");
        }

        private void mnuPrintoutsBoysEventPerfsSprints400_Click(object sender, EventArgs e)
        {
            printEvent("Boy's 400");
        }

        private void mnuPrintoutsBoysEventPerfsDistance800_Click(object sender, EventArgs e)
        {
            printEvent("Boy's 800");
        }

        private void mnuPrintoutsBoysEventPerfsDistance1600_Click(object sender, EventArgs e)
        {
            printEvent("Boy's 1600");
        }

        private void mnuPrintoutsBoysEventPerfsDistance3200_Click(object sender, EventArgs e)
        {
            printEvent("Boy's 3200");
        }

        private void mnuPrintoutsBoysEventPerfsHurdlesHigh_Click(object sender, EventArgs e)
        {
            printEvent("Boy's HH");
        }

        private void mnuPrintoutsBoysEventPerfsHurdles300_Click(object sender, EventArgs e)
        {
            printEvent("Boy's 300H");
        }

        private void mnuPrintoutsBoysEventPerfsRelays4x100_Click(object sender, EventArgs e)
        {
            printEvent("Boy's 4x100");
        }

        private void mnuPrintoutsBoysEventPerfsRelays4x400_Click(object sender, EventArgs e)
        {
            printEvent("Boy's 4x400");
        }

        private void mnuPrintoutsBoysEventPerfsRelays4x800_Click(object sender, EventArgs e)
        {
            printEvent("Boy's 4x800");
        }

        private void mnuPrintoutsBoysEventPerfsJumpsLJ_Click(object sender, EventArgs e)
        {
            printEvent("Boy's LJ");
        }

        private void mnuPrintoutsBoysEventPerfsJumpsTJ_Click(object sender, EventArgs e)
        {
            printEvent("Boy's TJ");
        }

        private void mnuPrintoutsBoysEventPerfsJumpsHJ_Click(object sender, EventArgs e)
        {
            printEvent("Boy'S HJ");
        }

        private void mnuPrintoutsBoysEventPerfsJumpsPV_Click(object sender, EventArgs e)
        {
            printEvent("Boy's PV");
        }

        private void mnuPrintoutsGirlsEventPerfsSprints100_Click(object sender, EventArgs e)
        {
            printEvent("Girl's 100");
        }

        private void mnuPrintoutsGirlsEventPerfsSprints200_Click(object sender, EventArgs e)
        {
            printEvent("Girl's 200");
        }

        private void mnuPrintoutsGirlsEventPerfsSprints400_Click(object sender, EventArgs e)
        {
            printEvent("Girl's 400");
        }

        private void mnuPrintoutsGirlsEventPerfsDistance800_Click(object sender, EventArgs e)
        {
            printEvent("Girl's 800");
        }

        private void mnuPrintoutsGirlsEventPerfsDistance1600_Click(object sender, EventArgs e)
        {
            printEvent("Girl's 1600");
        }

        private void mnuPrintoutsGirlsEventPerfsDistance3200_Click(object sender, EventArgs e)
        {
            printEvent("Girl's 3200");
        }

        private void mnuPrintoutsGirlsEventPerfsHurdlesHigh_Click(object sender, EventArgs e)
        {
            printEvent("Girl's HH");
        }

        private void mnuPrintoutsGirlsEventPerfsHurdles300_Click(object sender, EventArgs e)
        {
            printEvent("Girl's 300H");
        }

        private void mnuPrintoutsGirlsEventPerfsRelays4x100_Click(object sender, EventArgs e)
        {
            printEvent("Girl's 4x100");
        }

        private void mnuPrintoutsGirlsEventPerfsRelays4x400_Click(object sender, EventArgs e)
        {
            printEvent("Girl's 4x400");
        }

        private void mnuPrintoutsGirlsEventPerfsRelays4x800_Click(object sender, EventArgs e)
        {
            printEvent("Girl's 4x800");
        }

        private void mnuPrintoutsGirlsEventPerfsJumpsLJ_Click(object sender, EventArgs e)
        {
            printEvent("Girl's LJ");
        }

        private void mnuPrintoutsGirlsEventPerfsJumpsTJ_Click(object sender, EventArgs e)
        {
            printEvent("Girl's TJ");
        }

        private void mnuPrintoutsGirlsEventPerfsJumpsHJ_Click(object sender, EventArgs e)
        {
            printEvent("Girl's HJ");
        }

        private void mnuPrintoutsGirlsEventPerfsJumpsPV_Click(object sender, EventArgs e)
        {
            printEvent("Girl's PV");
        }

        private void mnuPrintoutsBoysEventPerfsThrowsShotput_Click(object sender, EventArgs e)
        {
            printEvent("Boy's Shotput");
        }

        private void mnuPrintoutsBoysEventPerfsThrowsDiscus_Click(object sender, EventArgs e)
        {
            printEvent("Boy's Discus");
        }

        private void mnuPrintoutsBoysEventPerfsThrowsJavelin_Click(object sender, EventArgs e)
        {
            printEvent("Boy's Javelin");
        }

        private void mnuPrintoutsGirlsEventPerfsThrowsShotput_Click(object sender, EventArgs e)
        {
            printEvent("Girl's Shotput");
        }

        private void mnuPrintoutsGirlsEventPerfsThrowsDiscus_Click(object sender, EventArgs e)
        {
            printEvent("Girl's Discus");
        }

        private void mnuPrintoutsGirlsEventPerfsThrowsJavelin_Click(object sender, EventArgs e)
        {
            printEvent("Girl's Javelin");
        }

        private void mnuPrintoutsBoysTeamPerfsTeam1_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateTeamPerfDoc(mnuPrintoutsBoysTeamPerfsTeam1.Text, "Boy's", activeMeet);
        }

        private void mnuPrintoutsBoysTeamPerfsTeam2_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateTeamPerfDoc(mnuPrintoutsBoysTeamPerfsTeam2.Text, "Boy's", activeMeet);
        }

        private void mnuPrintoutsBoysTeamPerfsTeam3_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateTeamPerfDoc(mnuPrintoutsBoysTeamPerfsTeam3.Text, "Boy's", activeMeet);
        }

        private void mnuPrintoutsBoysTeamPerfsTeam4_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateTeamPerfDoc(mnuPrintoutsBoysTeamPerfsTeam4.Text, "Boy's", activeMeet);
        }

        private void mnuPrintoutsBoysTeamPerfsTeam5_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateTeamPerfDoc(mnuPrintoutsBoysTeamPerfsTeam5.Text, "Boy's", activeMeet);
        }

        private void mnuPrintoutsBoysTeamPerfsTeam6_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateTeamPerfDoc(mnuPrintoutsBoysTeamPerfsTeam6.Text, "Boy's", activeMeet);
        }

        private void mnuPrintoutsGirlsTeamPerfsTeam1_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateTeamPerfDoc(mnuPrintoutsGirlsTeamPerfsTeam1.Text, "Girl's", activeMeet);
        }

        private void mnuPrintoutsGirlsTeamPerfsTeam2_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateTeamPerfDoc(mnuPrintoutsGirlsTeamPerfsTeam2.Text, "Girl's", activeMeet);
        }

        private void mnuPrintoutsGirlsTeamPerfsTeam3_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateTeamPerfDoc(mnuPrintoutsGirlsTeamPerfsTeam3.Text, "Girl's", activeMeet);
        }

        private void mnuPrintoutsGirlsTeamPerfsTeam4_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateTeamPerfDoc(mnuPrintoutsGirlsTeamPerfsTeam4.Text, "Girl's", activeMeet);
        }

        private void mnuPrintoutsGirlsTeamPerfsTeam5_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateTeamPerfDoc(mnuPrintoutsGirlsTeamPerfsTeam5.Text, "Girl's", activeMeet);
        }

        private void mnuPrintoutsGirlsTeamPerfsTeam6_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateTeamPerfDoc(mnuPrintoutsGirlsTeamPerfsTeam6.Text, "Girl's", activeMeet);
        }

        private void mnuPrintoutsBoysTeamPerfsAll_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            foreach(string teamName in activeMeet.schoolNames.boySchoolNames.Keys)
            {
                pm.CreateTeamPerfDoc(teamName, "Boy's", activeMeet);
            }
        }

        private void mnuPrintoutsGirlsTeamPerfsAll_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            foreach (string teamName in activeMeet.schoolNames.girlSchoolNames.Keys)
            {
                pm.CreateTeamPerfDoc(teamName, "Girl's", activeMeet);
            }
        }

        private void mnuEnterBoysJumpsLJ_Click(object sender, EventArgs e)
        {
            FieldEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's LJ"))
            {
                newForm = new FieldEventEntry(this, "Boy's LJ", activeMeet.performances["Boy's LJ"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new FieldEventEntry(this, "Boy's LJ", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterBoysJumpsTJ_Click(object sender, EventArgs e)
        {
            FieldEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's TJ"))
            {
                newForm = new FieldEventEntry(this, "Boy's TJ", activeMeet.performances["Boy's TJ"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new FieldEventEntry(this, "Boy's TJ", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterBoysJumpsHJ_Click(object sender, EventArgs e)
        {
            FieldEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's HJ"))
            {
                newForm = new FieldEventEntry(this, "Boy's HJ", activeMeet.performances["Boy's HJ"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new FieldEventEntry(this, "Boy's HJ", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterBoysJumpsPV_Click(object sender, EventArgs e)
        {
            FieldEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's PV"))
            {
                newForm = new FieldEventEntry(this, "Boy's PV", activeMeet.performances["Boy's PV"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new FieldEventEntry(this, "Boy's PV", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterBoysThrowsShotput_Click(object sender, EventArgs e)
        {
            FieldEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's Shotput"))
            {
                newForm = new FieldEventEntry(this, "Boy's Shotput", activeMeet.performances["Boy's Shotput"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new FieldEventEntry(this, "Boy's Shotput", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterBoysThrowsDiscus_Click(object sender, EventArgs e)
        {
            FieldEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's Discus"))
            {
                newForm = new FieldEventEntry(this, "Boy's Discus", activeMeet.performances["Boy's Discus"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new FieldEventEntry(this, "Boy's Discus", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterBoysThrowsJavelin_Click(object sender, EventArgs e)
        {
            FieldEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's Javelin"))
            {
                newForm = new FieldEventEntry(this, "Boy's Javelin", activeMeet.performances["Boy's Javelin"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new FieldEventEntry(this, "Boy's Javelin", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsJumpsLJ_Click(object sender, EventArgs e)
        {
            FieldEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's LJ"))
            {
                newForm = new FieldEventEntry(this, "Girl's LJ", activeMeet.performances["Girl's LJ"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new FieldEventEntry(this, "Girl's LJ", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsJumpsTJ_Click(object sender, EventArgs e)
        {
            FieldEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's TJ"))
            {
                newForm = new FieldEventEntry(this, "Girl's TJ", activeMeet.performances["Girl's TJ"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new FieldEventEntry(this, "Girl's TJ", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsJumpsHJ_Click(object sender, EventArgs e)
        {
            FieldEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's HJ"))
            {
                newForm = new FieldEventEntry(this, "Girl's HJ", activeMeet.performances["Girl's HJ"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new FieldEventEntry(this, "Girl's HJ", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsJumpsPV_Click(object sender, EventArgs e)
        {
            FieldEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's PV"))
            {
                newForm = new FieldEventEntry(this, "Girl's PV", activeMeet.performances["Girl's PV"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new FieldEventEntry(this, "Girl's PV", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsThrowsShotput_Click(object sender, EventArgs e)
        {
            FieldEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's Shotput"))
            {
                newForm = new FieldEventEntry(this, "Girl's Shotput", activeMeet.performances["Girl's Shotput"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new FieldEventEntry(this, "Girl's Shotput", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsThrowsDiscus_Click(object sender, EventArgs e)
        {
            FieldEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's Discus"))
            {
                newForm = new FieldEventEntry(this, "Girl's Discus", activeMeet.performances["Girl's Discus"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new FieldEventEntry(this, "Girl's Discus", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsThrowsJavelin_Click(object sender, EventArgs e)
        {
            FieldEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's Javelin"))
            {
                newForm = new FieldEventEntry(this, "Girl's Javelin", activeMeet.performances["Girl's Javelin"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new FieldEventEntry(this, "Girl's Javelin", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterBoysRelays4x400_Click(object sender, EventArgs e)
        {
            RelayEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's 4x400"))
            {
                newForm = new RelayEventEntry(this, "Boy's 4x400", activeMeet.performances["Boy's 4x400"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new RelayEventEntry(this, "Boy's 4x400", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterBoysRelays4x800_Click(object sender, EventArgs e)
        {
            RelayEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Boy's 4x800"))
            {
                newForm = new RelayEventEntry(this, "Boy's 4x800", activeMeet.performances["Boy's 4x800"], activeMeet.schoolNames.boySchoolNames);
            }
            else
            {
                newForm = new RelayEventEntry(this, "Boy's 4x800", null, activeMeet.schoolNames.boySchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirls_Click(object sender, EventArgs e)
        {

        }

        private void mnuEnterGirlsRelays4x100_Click(object sender, EventArgs e)
        {
            RelayEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's 4x100"))
            {
                newForm = new RelayEventEntry(this, "Girl's 4x100", activeMeet.performances["Girl's 4x100"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new RelayEventEntry(this, "Girl's 4x100", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsRelays4x400_Click(object sender, EventArgs e)
        {
            RelayEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's 4x400"))
            {
                newForm = new RelayEventEntry(this, "Girl's 4x400", activeMeet.performances["Girl's 4x400"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new RelayEventEntry(this, "Girl's 4x400", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void mnuEnterGirlsRelays4x800_Click(object sender, EventArgs e)
        {
            RelayEventEntry newForm;
            if (activeMeet.performances != null && activeMeet.performances.ContainsKey("Girl's 4x800"))
            {
                newForm = new RelayEventEntry(this, "Girl's 4x800", activeMeet.performances["Girl's 4x800"], activeMeet.schoolNames.girlSchoolNames);
            }
            else
            {
                newForm = new RelayEventEntry(this, "Girl's 4x800", null, activeMeet.schoolNames.girlSchoolNames);
            }
            this.Hide();
            newForm.ShowDialog();
        }

        private void ptsDebugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (string s in boysActiveScores.Keys)
            {
                Console.WriteLine(boysActiveScores[s]);
            }
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuPrintoutsBoysScores1vs2_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[0] + "vs." + boysAbbrs[1]]);
        }

        private void mnuPrintoutsBoysScores1vs3_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[0] + "vs." + boysAbbrs[2]]);
        }

        private void mnuPrintoutsBoysScores2vs3_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[1] + "vs." + boysAbbrs[2]]);
        }

        private void mnuPrintoutsBoysScores1vs4_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[0] + "vs." + boysAbbrs[3]]);
        }

        private void mnuPrintoutsBoysScores2vs4_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[1] + "vs." + boysAbbrs[3]]);
        }

        private void mnuPrintoutsBoysScores3vs4_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[2] + "vs." + boysAbbrs[3]]);
        }

        private void mnuPrintoutsBoysScores1vs5_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[0] + "vs." + boysAbbrs[4]]);
        }

        private void mnuPrintoutsBoysScores2vs5_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[1] + "vs." + boysAbbrs[4]]);
        }

        private void mnuPrintoutsBoysScores3vs5_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[2] + "vs." + boysAbbrs[4]]);
        }

        private void mnuPrintoutsBoysScores4vs5_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[3] + "vs." + boysAbbrs[4]]);
        }

        private void mnuPrintoutsBoysScores1vs6_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[0] + "vs." + boysAbbrs[5]]);
        }

        private void mnuPrintoutsBoysScores2vs6_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[1] + "vs." + boysAbbrs[5]]);
        }

        private void mnuPrintoutsBoysScores3vs6_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[2] + "vs." + boysAbbrs[5]]);
        }

        private void mnuPrintoutsBoysScores4vs6_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[3] + "vs." + boysAbbrs[5]]);
        }

        private void mnuPrintoutsBoysScores5vs6_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Boy's", activeMeet.dateOfMeet, activeMeet.location, boysActiveScores[boysAbbrs[4] + "vs." + boysAbbrs[5]]);
        }

        private void mnuPrintoutsBoysScoresAll_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented, pick individually");
        }

        private void mnuPrintoutsGirlsScores1vs2_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[0] + "vs." + girlsAbbrs[1]]);
        }

        private void mnuPrintoutsGirlsScores1vs3_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[0] + "vs." + girlsAbbrs[2]]);
        }

        private void mnuPrintoutsGirlsScores2vs3_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[1] + "vs." + girlsAbbrs[2]]);
        }

        private void mnuPrintoutsGirlsScores1vs4_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[0] + "vs." + girlsAbbrs[3]]);
        }

        private void mnuPrintoutsGirlsScores2vs4_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[1] + "vs." + girlsAbbrs[3]]);
        }

        private void mnuPrintoutsGirlsScores3vs4_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[2] + "vs." + girlsAbbrs[3]]);
        }

        private void mnuPrintoutsGirlsScores1vs5_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[0] + "vs." + girlsAbbrs[4]]);
        }

        private void mnuPrintoutsGirlsScores2vs5_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[1] + "vs." + girlsAbbrs[4]]);
        }

        private void mnuPrintoutsGirlsScores3vs5_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[2] + "vs." + girlsAbbrs[4]]);
        }

        private void mnuPrintoutsGirlsScores4vs5_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[3] + "vs." + girlsAbbrs[4]]);
        }

        private void mnuPrintoutsGirlsScores1vs6_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[0] + "vs." + girlsAbbrs[5]]);
        }

        private void mnuPrintoutsGirlsScores2vs6_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[1] + "vs." + girlsAbbrs[5]]);
        }

        private void mnuPrintoutsGirlsScores3vs6_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[2] + "vs." + girlsAbbrs[5]]);
        }

        private void mnuPrintoutsGirlsScores4vs6_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[3] + "vs." + girlsAbbrs[5]]);
        }

        private void mnuPrintoutsGirlsScores5vs6_Click(object sender, EventArgs e)
        {
            PrintoutMgr pm = new PrintoutMgr();
            pm.CreateMeetResultsDoc("Girl's", activeMeet.dateOfMeet, activeMeet.location, girlsActiveScores[girlsAbbrs[4] + "vs." + girlsAbbrs[5]]);
        }

        private void mnuPrintoutsGirlsScoresAll_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented, pick individually");
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to start a new Meet? Your progress will be lost", "New Meet?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form1 createMeet = new Form1();
                this.Hide();
                createMeet.ShowDialog();
                this.Close();
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Exit?", "Exit?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void mnuPrintouts_Click(object sender, EventArgs e)
        {

        }
    }
}
