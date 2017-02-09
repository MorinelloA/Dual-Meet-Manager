using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DualMeetManager.Domain;
using DualMeetManager.Domain.Scoring;
using DualMeetManager.Service.DataEntry;

namespace DualMeetManager.Service.Scoring
{
    public class ScoringSvcImpl : IScoringSvc
    {
        /// <summary>
        /// Implementation for adding an indEvent to an OverallScore object
        /// </summary>
        /// <param name="scores">Overall scores</param>
        /// <param name="eventName">Name of the event being added</param>
        /// <param name="eventToAdd">Data for the event being added</param>
        /// <returns>OverallScore with the event added</returns>
        public OverallScore AddIndEvent(OverallScore scores, string eventName, IndEvent eventToAdd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implementation for adding a relayEvent to an OverallScore object
        /// </summary>
        /// <param name="scores">Overall scores</param>
        /// <param name="eventName">Name of the event being added</param>
        /// <param name="eventToAdd">Data for the event being added</param>
        /// <returns>OverallScore with the event added</returns>
        public OverallScore AddRelayEvent(OverallScore scores, string eventName, RelayEvent eventToAdd)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implementation for calculating points (1st, 2nd, and 3rd) for an individual field event
        /// </summary>
        /// <param name="team1Abbr">Abbr for team 1</param>
        /// <param name="team2Abbr">Abbr for team 2</param>
        /// <param name="perf">Complete list of performances for a particular field event</param>
        /// <returns>IndEvent, which holds all information ragarding this event's points</returns>
        public IndEvent CalculateFieldEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implementation for calculating points (1st, and 2nd) for a relay event
        /// </summary>
        /// <param name="team1Abbr">Abbr for team 1</param>
        /// <param name="team2Abbr">Abbr for team 2</param>
        /// <param name="perf"></param>
        /// <returns>RelayEvent, which holds all information ragarding this event's points</returns>
        public RelayEvent CalculateRelayEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Interface for calculating points (1st, 2nd, and 3rd) for an individual running event
        /// </summary>
        /// <param name="team1Abbr">Abbr for team 1</param>
        /// <param name="team2Abbr">Abbr for team 2</param>
        /// <param name="perf">Complete list of performances for a particular running event</param>
        /// <returns>IndEvent, which holds all information ragarding this event's points</returns>
        public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
        {
            //
            //gather performances from only teams 1 and 2
            //
            List<Performance> teams1and2 = new List<Performance>();
            foreach(Performance i in perf) //Iterate through entire list of performances
            {
                if (i.schoolName == team1Abbr || i.schoolName == team2Abbr) //check if the performance is for Team 1 or 2
                {
                    teams1and2.Add(i); //Add performance to working List
                }
            }
            //
            //sort performances from best to worst
            //
            teams1and2 = teams1and2.OrderBy(o => o.performance).ToList();

            //
            //gather info for 1st 2nd and 3rd
            //
            IndEvent eventToReturn = new IndEvent();
            eventToReturn.team1 = team1Abbr;
            eventToReturn.team2 = team2Abbr;

            List<int> firstPlaceHeats = new List<int>();
            List<int> secondPlaceHeats = new List<int>();
            List<int> thirdPlaceHeats = new List<int>();

            decimal firstPlacePerf = 0;
            decimal secondPlacePerf = 0;
            decimal thirdPlacePerf = 0;

            //First place performance
            if (teams1and2.Count > 0)
            {
                firstPlacePerf = teams1and2[0].performance;
                firstPlaceHeats.Add(teams1and2[0].heatNum);

                for (int i = 1; i < teams1and2.Count; i++)
                {
                    if (teams1and2[i].performance == firstPlacePerf)
                    {
                        //check heatnum
                        if (firstPlaceHeats.Contains(teams1and2[i].heatNum)) //check if it is already a 2nd item
                        {
                            if (secondPlaceHeats.Contains(teams1and2[i].heatNum)) //check if it is already a 3rd item
                            {
                                if (!thirdPlaceHeats.Contains(teams1and2[i].heatNum))
                                {
                                    thirdPlaceHeats.Add(teams1and2[i].heatNum);
                                    thirdPlacePerf = teams1and2[0].performance;
                                }
                            }
                            else
                            {
                                secondPlaceHeats.Add(teams1and2[i].heatNum);
                                secondPlacePerf = teams1and2[0].performance;
                            }
                        }
                        else
                        {
                            firstPlaceHeats.Add(teams1and2[i].heatNum);
                        }
                    }
                }

                //Check if 3 or more firsts
                //Should have no 2nds or 3rds
                if(firstPlaceHeats.Count >= 3)
                {
                    secondPlaceHeats.Clear();
                    thirdPlaceHeats.Clear();
                    secondPlacePerf = 0;
                    thirdPlacePerf = 0;
                }

                //Check if 2 firsts
                //Should have no 2nd, its should become third
                if(firstPlaceHeats.Count == 2)
                {
                    thirdPlaceHeats.Clear();
                    thirdPlaceHeats.AddRange(secondPlaceHeats);
                    secondPlaceHeats.Clear();
                    thirdPlacePerf = secondPlacePerf;
                    secondPlacePerf = 0;
                }

                //Check if 2 or more seconds
                //Should have no 3rds
                if(secondPlaceHeats.Count >= 2)
                {
                    thirdPlaceHeats.Clear();
                    thirdPlacePerf = 0;
                }

                //Check if second place was not already found, at least 2 performances, and not more than one firstPlace
                //May be wrong
                if (!(secondPlaceHeats.Count > 0 && teams1and2.Count > 1))
                {
                    secondPlacePerf = teams1and2[1].performance;
                    secondPlaceHeats.Add(teams1and2[1].heatNum);

                    for (int i = 2; i < teams1and2.Count; i++)
                    {
                        if (teams1and2[i].performance == secondPlacePerf)
                        {
                            //check heatnum
                            if (secondPlaceHeats.Contains(teams1and2[i].heatNum)) //check if it is already a 3rd item
                            {
                                if (!thirdPlaceHeats.Contains(teams1and2[i].heatNum))
                                {
                                    thirdPlaceHeats.Add(teams1and2[i].heatNum);
                                    thirdPlacePerf = teams1and2[0].performance;
                                }
                            }
                            else
                            {
                                secondPlaceHeats.Add(teams1and2[i].heatNum);
                                secondPlacePerf = teams1and2[0].performance;
                            }                        
                        }
                    }
                }
                else
                {
                    //This means that there were either 2 or more firsts, or second place was already found (same time + same heat)
                }

                //Check if third place was not already found and at least 3 performances
                //May be wrong
                if (!(thirdPlaceHeats.Count > 0 && teams1and2.Count > 2))
                {
                    thirdPlacePerf = teams1and2[2].performance;
                    thirdPlaceHeats.Add(teams1and2[2].heatNum);

                    for (int i = 3; i < teams1and2.Count; i++)
                    {
                        if (teams1and2[i].performance == thirdPlacePerf)
                        {
                            //check heatnum
                            if (!thirdPlaceHeats.Contains(teams1and2[i].heatNum))
                            {
                                thirdPlaceHeats.Add(teams1and2[i].heatNum);
                                thirdPlacePerf = teams1and2[0].performance;
                            }
                        }
                    }
                }
                else
                {
                    //Third place should not be calculated because of ties with 1st and/or 2nd
                }

                
            }
            else //No performances for either team. Uncontested Event
            {
                //null object needs created here
            }



            //
            //Populate IndEvent object
            //

            //Use this to convert into strings for EventPoints objects 
            DataEntrySvcImpl DESI = new DataEntrySvcImpl();

            EventPoints firstEventPoints = new EventPoints();
            EventPoints secondEventPoints = new EventPoints();
            EventPoints thirdEventPoints = new EventPoints();

            //first place EventPoints
            if (firstPlacePerf != 0)
            {
                firstEventPoints.performance = DESI.ConvertToTimedData(firstPlacePerf);
                if (firstPlaceHeats.Count > 1)
                {
                    firstEventPoints.athleteName = "TIE";
                    firstEventPoints.schoolName = "TIE";
                    //Calculate Tie info
                }
                else
                {
                    //Populate regular non-tie info
                    firstEventPoints.athleteName = teams1and2[0].athleteName;
                    firstEventPoints.schoolName = teams1and2[0].schoolName;
                    if (firstEventPoints.schoolName == team1Abbr)
                    {
                        firstEventPoints.team1Pts = 5;
                        firstEventPoints.team2Pts = 0;
                    }
                    else if(firstEventPoints.schoolName == team2Abbr)
                    {
                        firstEventPoints.team1Pts = 0;
                        firstEventPoints.team2Pts = 5;
                    }
                    else
                    {
                        Console.WriteLine("ERROR! First Place Points being assigned to an incorrect team name");
                    }
                } 
            }
            else
            {
                firstEventPoints.performance = "";
                firstEventPoints.athleteName = "";
                firstEventPoints.schoolName = "";
                firstEventPoints.team1Pts = 0;
                firstEventPoints.team2Pts = 0;
            }

            //secondplace EventPoints
            if (secondPlacePerf != 0)
            {
                secondEventPoints.performance = DESI.ConvertToTimedData(secondPlacePerf);
                if (secondPlaceHeats.Count > 1)
                {
                    secondEventPoints.athleteName = "TIE";
                    secondEventPoints.schoolName = "TIE";
                    //Calculate Tie info
                }
                else
                {
                    //Populate regular non-tie info
                    for(int i = 1; i < teams1and2.Count; i++)
                    {
                        if(teams1and2[i].performance == secondPlacePerf)
                        {
                            secondEventPoints.athleteName = teams1and2[i].athleteName;
                            secondEventPoints.schoolName = teams1and2[i].schoolName;
                        }
                    }
                    
                    if (secondEventPoints.schoolName == team1Abbr)
                    {
                        secondEventPoints.team1Pts = 3;
                        secondEventPoints.team2Pts = 0;
                    }
                    else if (secondEventPoints.schoolName == team2Abbr)
                    {
                        secondEventPoints.team1Pts = 0;
                        secondEventPoints.team2Pts = 3;
                    }
                    else
                    {
                        Console.WriteLine("ERROR! Second Place Points being assigned to an incorrect team name");
                    }
                }
            }
            else
            {
                secondEventPoints.performance = "";
                secondEventPoints.athleteName = "";
                secondEventPoints.schoolName = "";
                secondEventPoints.team1Pts = 0;
                secondEventPoints.team2Pts = 0;
            }

            //thirdplace EventPoints
            if (thirdPlacePerf != 0)
            {
                thirdEventPoints.performance = DESI.ConvertToTimedData(thirdPlacePerf);
                if (thirdPlaceHeats.Count > 1)
                {
                    thirdEventPoints.athleteName = "TIE";
                    thirdEventPoints.schoolName = "TIE";
                    //Calculate Tie info
                }
                else
                {
                    //Populate regular non-tie info
                    for (int i = 1; i < teams1and2.Count; i++)
                    {
                        if (teams1and2[i].performance == thirdPlacePerf)
                        {
                            thirdEventPoints.athleteName = teams1and2[i].athleteName;
                            thirdEventPoints.schoolName = teams1and2[i].schoolName;
                        }
                    }

                    if (thirdEventPoints.schoolName == team1Abbr)
                    {
                        thirdEventPoints.team1Pts = 1;
                        thirdEventPoints.team2Pts = 0;
                    }
                    else if (thirdEventPoints.schoolName == team2Abbr)
                    {
                        thirdEventPoints.team1Pts = 0;
                        thirdEventPoints.team2Pts = 1;
                    }
                    else
                    {
                        Console.WriteLine("ERROR! Third Place Points being assigned to an incorrect team name");
                    }
                }
            }
            else
            {
                thirdEventPoints.performance = "";
                thirdEventPoints.athleteName = "";
                thirdEventPoints.schoolName = "";
                thirdEventPoints.team1Pts = 0;
                thirdEventPoints.team2Pts = 0;
            }

            //Populate points totals
            eventToReturn.points[0] = firstEventPoints;
            eventToReturn.points[1] = secondEventPoints;
            eventToReturn.points[2] = thirdEventPoints;
            eventToReturn.team1Total = firstEventPoints.team1Pts + secondEventPoints.team1Pts + thirdEventPoints.team1Pts;
            eventToReturn.team2Total = firstEventPoints.team2Pts + secondEventPoints.team2Pts + thirdEventPoints.team2Pts;

            //
            //return IndEvent Object
            //

            return eventToReturn;
        }

        /// <summary>
        /// Interface for calculating The overall score of a meet
        /// </summary>
        /// <param name="scores">Overall scores</param>
        /// <param name="gender">string to hold what gender the meet is, boy's or girl's</param>
        /// <returns>OverallScore object that holds accurate overall score points</returns>
        public OverallScore CalculateTotal(OverallScore scores, string gender)
        {
            decimal totalPointsTeam1 = 0;
            decimal totalPointsTeam2 = 0;
            IndEvent tempIndEvent = new IndEvent();
            RelayEvent tempRelayEvent = new RelayEvent();

            string[] validIndEvents = {"100", "200", "400","800", "1600", "3200",
                "LJ", "TJ", "HJ", "PV", "ShotPut", "Discus", "Javelin"};

            for (int i = 0; i < validIndEvents.Length; i++)
            {
                scores.indEvents.TryGetValue(gender + "'s " + validIndEvents[i], out tempIndEvent);
                if (!tempIndEvent.Equals(null))
                {
                    totalPointsTeam1 += tempIndEvent.team1Total;
                    totalPointsTeam2 += tempIndEvent.team2Total;
                }
            }

            //DO THE SAME FOR RELAY EVENTS

            scores.team1Points = totalPointsTeam1;
            scores.team2Points = totalPointsTeam2;

            return scores;
        }
    }
}
