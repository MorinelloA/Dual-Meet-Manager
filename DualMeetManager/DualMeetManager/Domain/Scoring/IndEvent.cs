using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain.Scoring
{
    public class IndEvent
    {
        //Team Abbr
        public string team1 { get; set; }
        public string team2 { get; set; }

        //Pts
        //Team1 pts, Team2 pts, athlete name, school name, performance
        //Note: performance is a string because it could be in minutes and seconds (ex: 4:25)
        public Tuple<decimal, decimal, string, string, string> firstPlacePts { get; set; }
        public Tuple<decimal, decimal, string, string, string> secondPlacePts { get; set; }
        public Tuple<decimal, decimal, string, string, string> thirdPlacePts { get; set; }

        //Total
        //Team1 total, Team2 total
        public Tuple<decimal, decimal> totalPts { get; set; }

        //Default Constructor
        public IndEvent()
        {
            this.team1 = "";
            this.team2 = "";
            this.firstPlacePts = Tuple.Create(0.0m, 0.0m, "", "", "");
            this.secondPlacePts = Tuple.Create(0.0m, 0.0m, "", "", "");
            this.thirdPlacePts = Tuple.Create(0.0m, 0.0m, "", "", "");
            this.totalPts = Tuple.Create(0.0m, 0.0m);
        }

        //Constructor without points
        public IndEvent(string team1, string team2)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.firstPlacePts = Tuple.Create(0.0m, 0.0m, "", "", "");
            this.secondPlacePts = Tuple.Create(0.0m, 0.0m, "", "", "");
            this.thirdPlacePts = Tuple.Create(0.0m, 0.0m, "", "", "");
            this.totalPts = Tuple.Create(0.0m, 0.0m);
        }

        //Constructor with points
        public IndEvent(string team1, string team2, Tuple<decimal, decimal, string, string, string> firstPlacePts, Tuple<decimal, decimal, string, string, string> secondPlacePts, Tuple<decimal, decimal, string, string, string> thirdPlacePts, Tuple<decimal, decimal> totalPts)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.firstPlacePts = firstPlacePts;
            this.secondPlacePts = secondPlacePts;
            this.thirdPlacePts = thirdPlacePts;
            this.totalPts = totalPts;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("First Place: " + firstPlacePts.Item3 + " - " + firstPlacePts.Item4 + ": " + firstPlacePts.Item5);
            sb.Append("First Place Pts: " + team1 + ": " + firstPlacePts.Item1 + " " + team2 + ": " + firstPlacePts.Item2);
            sb.Append("Second Place: " + secondPlacePts.Item3 + " - " + secondPlacePts.Item4 + ": " + secondPlacePts.Item5);
            sb.Append("Second Place Pts: " + team1 + ": " + secondPlacePts.Item1 + " " + team2 + ": " + secondPlacePts.Item2);
            sb.Append("Third Place: " + thirdPlacePts.Item3 + " - " + thirdPlacePts.Item4 + ": " + thirdPlacePts.Item5);
            sb.Append("Third Place Pts: " + team1 + ": " + thirdPlacePts.Item1 + " " + team2 + ": " + thirdPlacePts.Item2);
            sb.Append("Total: " + team1 + ": " + totalPts.Item1 + " " + team2 + ": " + totalPts.Item2);
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            IndEvent myIndEvent = obj as IndEvent;
            if (myIndEvent == null && this == null) return true;
            else if (myIndEvent != null && this == null) return false;
            else if (myIndEvent == null && this != null) return false;
            else if (!myIndEvent.team1.Equals(team1)) return false;
            else if (!myIndEvent.team2.Equals(team2)) return false;
            else if (!myIndEvent.firstPlacePts.Equals(firstPlacePts)) return false;
            else if (!myIndEvent.secondPlacePts.Equals(secondPlacePts)) return false;
            else if (!myIndEvent.thirdPlacePts.Equals(thirdPlacePts)) return false;
            else if (!myIndEvent.totalPts.Equals(totalPts)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + team1.GetHashCode();
                hash = hash * 23 + team2.GetHashCode();
                hash = hash * 23 + firstPlacePts.GetHashCode();
                hash = hash * 23 + secondPlacePts.GetHashCode();
                hash = hash * 23 + thirdPlacePts.GetHashCode();
                hash = hash * 23 + totalPts.GetHashCode();
                return hash;
            }
        }
    }
}