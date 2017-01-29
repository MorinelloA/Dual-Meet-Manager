using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain.Scoring
{
    public class RelayEvent
    {
        public string team1 { get; private set; }
        public string team2 { get; private set; }

        //Having points assigned for relays seems redundant since the winning relay gets 5pts, and the loser gets 0.
        //However, if rules were ever to change, the code would be much easier to update this way.

        //Pts
        //Team1 pts, Team2 pts, school abbr, performance
        //Note: performance is a string because it could be in minutes and seconds (ex: 4:25)
        //public Tuple<decimal, decimal, string, string> firstPlacePts { get; private set; }
        //public Tuple<decimal, decimal, string, string> secondPlacePts { get; private set; }
        public Tuple<decimal, decimal> totalPts { get; private set; }

        //index 0 for 1st place, 1 for 2nd place
        public EventPoints[] points { get; private set; }

        //Default Constructor
        public RelayEvent()
        {
            points = new EventPoints[2];
            this.team1 = "";
            this.team2 = "";
            this.points[0] = new EventPoints(0.0m, 0.0m, "", "", "");
            this.points[1] = new EventPoints(0.0m, 0.0m, "", "", "");
            this.totalPts = Tuple.Create(0.0m, 0.0m);
        }

        //Parameterized Constructor
        public RelayEvent(string team1, string team2, EventPoints firstPlacePts, EventPoints secondPlacePts, Tuple<decimal, decimal> totalPts)
        {
            points = new EventPoints[2];
            this.team1 = team1;
            this.team2 = team2;
            points[0] = firstPlacePts;
            points[1] = secondPlacePts;
            this.totalPts = totalPts;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("First Place: " + points[0].athleteName + " - " + points[0].schoolName + ": " + points[0].performance);
            sb.Append("First Place Pts: " + team1 + ": " + points[0].team1Pts + " " + team2 + ": " + points[0].team2Pts);
            sb.Append("Second Place: " + points[1].athleteName + " - " + points[1].schoolName + ": " + points[1].performance);
            sb.Append("Second Place Pts: " + team1 + ": " + points[1].team1Pts + " " + team2 + ": " + points[1].team2Pts);
            sb.Append("Total: " + team1 + ": " + totalPts.Item1 + " " + team2 + ": " + totalPts.Item2);
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            RelayEvent myRelayEvent = obj as RelayEvent;
            if (!myRelayEvent.team1.Equals(team1)) return false;
            else if (!myRelayEvent.team2.Equals(team2)) return false;
            else if (!myRelayEvent.points[0].Equals(points[0])) return false;
            else if (!myRelayEvent.points[1].Equals(points[1])) return false;
            else if (!myRelayEvent.totalPts.Equals(totalPts)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + team1.GetHashCode();
                hash = hash * 23 + team2.GetHashCode();
                hash = hash * 23 + points[0].GetHashCode();
                hash = hash * 23 + points[1].GetHashCode();
                hash = hash * 23 + totalPts.GetHashCode();
                return hash;
            }
        }
    }
}