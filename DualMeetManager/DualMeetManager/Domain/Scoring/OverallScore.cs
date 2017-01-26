using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain.Scoring
{
    class OverallScore
    {
        //Team1 vs Team2, <Team1 pts, Team2 pts>
        Dictionary<string, Tuple<decimal, decimal>> overallPts;
        //Event name, List of points
        Dictionary<string, List<RunningEvent>> runningEvents;
        Dictionary<string, List<FieldEvent>> throwingEvents;
        Dictionary<string, List<RelayEvent>> relayEvents;

        //Defult Constructor
        public OverallScore(){}

        //Parameterized Constructor
        public OverallScore(Dictionary<string, Tuple<decimal, decimal>> overallPts, Dictionary<string, List<RunningEvent>> runningEvents, Dictionary<string, List<FieldEvent>> throwingEvents, Dictionary<string, List<RelayEvent>> relayEvents)
        {
            this.overallPts = overallPts;
            this.runningEvents = runningEvents;
            this.throwingEvents = throwingEvents;
            this.relayEvents = relayEvents;
        }
    }
}
