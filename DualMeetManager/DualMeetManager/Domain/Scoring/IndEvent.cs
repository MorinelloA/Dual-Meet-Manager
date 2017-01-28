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
        //These need deleted, replaced with an array of EventPoints
        //public Tuple<decimal, decimal, string, string, string> firstPlacePts { get; set; }
        //public Tuple<decimal, decimal, string, string, string> secondPlacePts { get; set; }
        //public Tuple<decimal, decimal, string, string, string> thirdPlacePts { get; set; }

        //index 0 for 1st place, 1 for 2nd place, 2 for 3rd place
        public EventPoints[] points = new EventPoints[3];

        //Total
        //Team1 total, Team2 total
        public Tuple<decimal, decimal> totalPts { get; set; }

        //Default Constructor
        public IndEvent()
        {
            this.team1 = "";
            this.team2 = "";
            this.points[0] = new EventPoints(0.0m, 0.0m, "", "", "");
            this.points[1] = new EventPoints(0.0m, 0.0m, "", "", "");
            this.points[2] = new EventPoints(0.0m, 0.0m, "", "", "");
            this.totalPts = Tuple.Create(0.0m, 0.0m);
        }

        //Constructor without points
        public IndEvent(string team1, string team2)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.points[0] = new EventPoints(0.0m, 0.0m, "", "", "");
            this.points[1] = new EventPoints(0.0m, 0.0m, "", "", "");
            this.points[2] = new EventPoints(0.0m, 0.0m, "", "", "");
            this.totalPts = Tuple.Create(0.0m, 0.0m);
        }

        //Constructor with points
        public IndEvent(string team1, string team2, EventPoints firstPlacePts, EventPoints secondPlacePts, EventPoints thirdPlacePts, Tuple<decimal, decimal> totalPts)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.points[0] = firstPlacePts;
            this.points[1] = secondPlacePts;
            this.points[2] = thirdPlacePts;
            this.totalPts = totalPts;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("First Place: " + points[0].athleteName + " - " + points[0].schoolName + ": " + points[0].performance);
            sb.Append("First Place Pts: " + team1 + ": " + points[0].team1Pts + " " + team2 + ": " + points[0].team2Pts);
            sb.Append("Second Place: " + points[1].athleteName + " - " + points[1].schoolName + ": " + points[1].performance);
            sb.Append("Second Place Pts: " + team1 + ": " + points[1].team1Pts + " " + team2 + ": " + points[1].team2Pts);
            sb.Append("Third Place: " + points[2].athleteName + " - " + points[2].schoolName + ": " + points[2].performance);
            sb.Append("Third Place Pts: " + team1 + ": " + points[2].team1Pts + " " + team2 + ": " + points[2].team2Pts);
            sb.Append("Total: " + team1 + ": " + totalPts.Item1 + " " + team2 + ": " + totalPts.Item2);
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            IndEvent myIndEvent = obj as IndEvent;
            if (myIndEvent == null && this == null) return true;
            else if (myIndEvent != null && this == null) return false;
            else if (myIndEvent == null && this != null) return false;
            else if (!myIndEvent.team1.Equals(team1)) return false;
            else if (!myIndEvent.team2.Equals(team2)) return false;
            else if (!myIndEvent.points[0].Equals(points[0])) return false;
            else if (!myIndEvent.points[1].Equals(points[1])) return false;
            else if (!myIndEvent.points[2].Equals(points[2])) return false;
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
                hash = hash * 23 + points[0].GetHashCode();
                hash = hash * 23 + points[1].GetHashCode();
                hash = hash * 23 + points[2].GetHashCode();
                hash = hash * 23 + totalPts.GetHashCode();
                return hash;
            }
        }

        public bool validate()
        {
            if (points[0].team1Pts + points[1].team1Pts + points[2].team1Pts + points[0].team2Pts + points[1].team2Pts + points[2].team2Pts != totalPts.Item1 + totalPts.Item2) return false; //Points distributed should match up
            else if (points[0].team1Pts + points[1].team1Pts + points[2].team1Pts + points[0].team2Pts + points[1].team2Pts + points[2].team2Pts > 9) return false; //Check if an event is awarding more than 9 points
            else if (totalPts.Item1 + totalPts.Item2 > 9) return false; //Redundant if statement
            else if (string.IsNullOrWhiteSpace(team1)) return false; //team1 must have a name
            else if (string.IsNullOrWhiteSpace(team2)) return false; //team2 must have a name
            else if ((string.IsNullOrWhiteSpace(points[0].athleteName) && !string.IsNullOrWhiteSpace(points[0].athleteName)) || (!string.IsNullOrWhiteSpace(points[0].athleteName) && string.IsNullOrWhiteSpace(points[0].athleteName))) return false; //If name or school are null, the other must be null as well
            else if ((string.IsNullOrWhiteSpace(points[1].athleteName) && !string.IsNullOrWhiteSpace(points[1].athleteName)) || (!string.IsNullOrWhiteSpace(points[1].athleteName) && string.IsNullOrWhiteSpace(points[1].athleteName))) return false; //If name or school are null, the other must be null as well
            else if ((string.IsNullOrWhiteSpace(points[2].athleteName) && !string.IsNullOrWhiteSpace(points[2].athleteName)) || (!string.IsNullOrWhiteSpace(points[2].athleteName) && string.IsNullOrWhiteSpace(points[2].athleteName))) return false; //If name or school are null, the other must be null as well
            else if ((string.IsNullOrWhiteSpace(points[0].athleteName) || string.IsNullOrWhiteSpace(points[0].schoolName)) && (points[0].team1Pts + points[0].team2Pts != 0)) return false; //No name with points being distributed 
            else if ((string.IsNullOrWhiteSpace(points[1].athleteName) || string.IsNullOrWhiteSpace(points[1].schoolName)) && (points[1].team1Pts + points[1].team2Pts != 0)) return false; //No name with points being distributed
            else if ((string.IsNullOrWhiteSpace(points[2].athleteName) || string.IsNullOrWhiteSpace(points[2].schoolName)) && (points[2].team1Pts + points[2].team2Pts != 0)) return false; //No name with points being distributed
            else if (!string.IsNullOrWhiteSpace(points[0].athleteName) && (points[0].team1Pts + points[0].team2Pts == 0)) return false; //Name without distributing any points
            else if (!string.IsNullOrWhiteSpace(points[1].athleteName) && (points[1].team1Pts + points[1].team2Pts == 0)) return false; //Name without distributing any points
            else if (!string.IsNullOrWhiteSpace(points[2].athleteName) && (points[2].team1Pts + points[2].team2Pts == 0)) return false; //Name without distributing any points
            return true;
        }
    }
}