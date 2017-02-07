using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DualMeetManager.Domain;
using DualMeetManager.Domain.Scoring;

namespace DualMeetManager.Service.Scoring
{
    class ScoringSvcImpl : IScoringSvc
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

            List<int> firstPlaceHeats = new List<int>();
            List<int> secondPlaceHeats = new List<int>();
            List<int> thirdPlaceHeats = new List<int>();

            decimal firstPlacePerf, secondPlacePerf, thirdPlacePerf;

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

                //Check if second place was not already found and at least 2 performances
                if(secondPlaceHeats.Count > 0 && teams1and2.Count > 1)
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

                //Check if third place was not already found and at least 3 performances
                if (thirdPlaceHeats.Count > 0 && teams1and2.Count > 2)
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
            }

            

            //
            //Populate IndEvent object
            //

            //
            //return IndEvent Object
            //

            return null;
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
