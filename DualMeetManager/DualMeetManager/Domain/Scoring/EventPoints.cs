using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain.Scoring
{
    public class EventPoints
    {
        //Team1 pts, Team2 pts, athlete name, school name, performance
        public decimal team1Pts { get; set; }
        public decimal team2Pts { get; set; }
        public string athleteName { get; set; }
        public string schoolName { get; set; }
        //Note: performance is a string because it could be in minutes and seconds (ex: 4:25)
        public string performance { get; set; }
        
        //Default Constructor
        public EventPoints() { }

        //Parameterized Constructor
        public EventPoints(decimal team1Pts, decimal team2Pts, string athleteName, string schoolName, string performance)
        {
            this.team1Pts = team1Pts;
            this.team2Pts = team2Pts;
            this.athleteName = athleteName;
            this.schoolName = schoolName;
            this.performance = performance;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Athlete: " + athleteName + Environment.NewLine);
            sb.Append("School: " + schoolName + Environment.NewLine);
            sb.Append("Performance: " + performance + Environment.NewLine);
            sb.Append("Team 1 Points: " + team1Pts + Environment.NewLine);
            sb.Append("Team 2 Points: " + team2Pts);
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            EventPoints myEventPoints = obj as EventPoints;
            if (myEventPoints == null && this == null) return true;
            else if (myEventPoints != null && this == null) return false;
            else if (myEventPoints == null && this != null) return false;
            else if (myEventPoints.team1Pts != team1Pts) return false;
            else if (myEventPoints.team2Pts != team2Pts) return false;
            else if (myEventPoints.athleteName != athleteName) return false;
            else if (myEventPoints.schoolName != schoolName) return false;
            else if (myEventPoints.performance != performance) return false;
            return true;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + team1Pts.GetHashCode();
                hash = hash * 23 + team2Pts.GetHashCode();
                hash = hash * 23 + athleteName.GetHashCode();
                hash = hash * 23 + schoolName.GetHashCode();
                hash = hash * 23 + performance.GetHashCode();
                return hash;
            }
        }

        //A validate method is not useful for this class
        //An object may very well be null
        //Also, because of ties, point values may be something other than the typical 5, 3, or 1
        /*public bool validate()
        {
            return true;
        }*/
    }
}
