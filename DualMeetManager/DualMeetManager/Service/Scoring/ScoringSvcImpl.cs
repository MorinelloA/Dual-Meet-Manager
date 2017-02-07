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
        /// <param name="perf">Complete list of performances for a particular field event</param>
        /// <returns>IndEvent, which holds all information ragarding this event's points</returns>
        public IndEvent CalculateFieldEvent(List<Performance> perf)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implementation for calculating points (1st, and 2nd) for a relay event
        /// </summary>
        /// <param name="perf"></param>
        /// <returns>RelayEvent, which holds all information ragarding this event's points</returns>
        public RelayEvent CalculateRelayEvent(List<Performance> perf)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Interface for calculating points (1st, 2nd, and 3rd) for an individual running event
        /// </summary>
        /// <param name="perf">Complete list of performances for a particular running event</param>
        /// <returns>IndEvent, which holds all information ragarding this event's points</returns>
        public IndEvent CalculateRunningEvent(List<Performance> perf)
        {
            throw new NotImplementedException();
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
