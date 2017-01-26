using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain.Scoring
{
    class OverallScore
    {
        //Teams
        //Abbr, Full Name, OverallPts
        Tuple<string, string, decimal> team1 { get; set; }
        Tuple<string, string, decimal> team2 { get; set; }

        //Event name, List of points
        Dictionary<string, List<RunningEvent>> runningEvents;
        Dictionary<string, List<FieldEvent>> fieldEvents;
        Dictionary<string, List<RelayEvent>> relayEvents;

        //Defult Constructor
        public OverallScore(){}

        //Parameterized Constructor
        public OverallScore(Tuple<string, string, decimal> team1, Tuple<string, string, decimal> team2, Dictionary<string, List<RunningEvent>> runningEvents, Dictionary<string, List<FieldEvent>> fieldEvents, Dictionary<string, List<RelayEvent>> relayEvents)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.runningEvents = runningEvents;
            this.fieldEvents = fieldEvents;
            this.relayEvents = relayEvents;
        }

        public override bool Equals(object obj)
        {
            //If there is a problem because of sorting Tuples, look here:
            //http://stackoverflow.com/questions/4668525/sort-listtupleint-int-in-place

            OverallScore myOverallScore = obj as OverallScore;
            if (myOverallScore.team1.Equals(team1)) return false;
            else if (myOverallScore.team2.Equals(team2)) return false;
            else if (!myOverallScore.runningEvents.OrderBy(r => r.Key).SequenceEqual(runningEvents.OrderBy(r => r.Key))) return false;
            else if (!myOverallScore.fieldEvents.OrderBy(r => r.Key).SequenceEqual(fieldEvents.OrderBy(r => r.Key))) return false;
            else if (!myOverallScore.relayEvents.OrderBy(r => r.Key).SequenceEqual(relayEvents.OrderBy(r => r.Key))) return false;
            return true;
        }

        public override string ToString()
        { 
            StringBuilder sb = new StringBuilder();
            sb.Append(team1.Item2 + " - " + team1.Item1 + ": " + team1.Item3 + Environment.NewLine);
            sb.Append(team2.Item2 + " - " + team2.Item1 + ": " + team2.Item3 + Environment.NewLine + Environment.NewLine);

            foreach (KeyValuePair<string, List<RunningEvent>> i in runningEvents)
            {
                sb.Append(i.ToString());
            }
            foreach (KeyValuePair<string, List<FieldEvent>> i in fieldEvents)
            {
                sb.Append(i.ToString());
            }
            foreach (KeyValuePair<string, List<RelayEvent>> i in relayEvents)
            {
                sb.Append(i.ToString());
            }
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + team1.GetHashCode();
                hash = hash * 23 + team2.GetHashCode();
                hash = hash * 23 + runningEvents.GetHashCode();
                hash = hash * 23 + fieldEvents.GetHashCode();
                hash = hash * 23 + relayEvents.GetHashCode();
                return hash;
            }
        }

        
    }
}
