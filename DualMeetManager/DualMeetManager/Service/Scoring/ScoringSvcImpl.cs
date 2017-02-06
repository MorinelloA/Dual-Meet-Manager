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
        public OverallScore AddIndEvent(IndEvent eventToAdd)
        {
            throw new NotImplementedException();
        }

        public OverallScore AddRelayEvent(RelayEvent eventToAdd)
        {
            throw new NotImplementedException();
        }

        public IndEvent CalculateFieldEvent(List<Performance> perf)
        {
            throw new NotImplementedException();
        }

        public RelayEvent CalculateRelayEvent(List<Performance> perf)
        {
            throw new NotImplementedException();
        }

        public IndEvent CalculateRunningEvent(List<Performance> perf)
        {
            throw new NotImplementedException();
        }

        public OverallScore CalculateTotal(OverallScore scores, string gender)
        {
            //throw new NotImplementedException();

            //string test;
            //test1.TryGetValue("t1", out test);

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
