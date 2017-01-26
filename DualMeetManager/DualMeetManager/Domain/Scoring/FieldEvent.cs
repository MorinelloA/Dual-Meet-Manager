using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain.Scoring
{
    class FieldEvent
    {
        //Teams
        //Abbr, Full Name
        Tuple<string, string> team1 { get; set; }
        Tuple<string, string> team2 { get; set; }

        //Pts
        //Team1 pts, Team2 pts, athlete name, school name, performance
        //Note: performance is a string because it could be in minutes and second (ex: 4:25)
        Tuple<decimal, decimal, string, string, string> firstPlacePts { get; set; }
        Tuple<decimal, decimal, string, string, string> secondPlacePts { get; set; }
        Tuple<decimal, decimal, string, string, string> thirdPlacePts { get; set; }

        //Total
        //Team1 total, Team2 total
        Tuple<decimal, decimal> totalPts { get; set; }

        //Default Constructor
        public FieldEvent() { }

        //Constructor without points
        public FieldEvent(Tuple<string, string> team1, Tuple<string, string> team2)
        {
            this.team1 = team1;
            this.team2 = team2;
        }

        //Constructor without points without using tuples in parameters
        public FieldEvent(string team1Abbr, string team1Name, string team2Abbr, string team2Name)
        {
            team1 = Tuple.Create(team1Abbr, team1Name);
            team2 = Tuple.Create(team2Abbr, team2Name);
        }

        //Constructor with points
        public FieldEvent(Tuple<string, string> team1, Tuple<string, string> team2, Tuple<decimal, decimal, string, string, string> firstPlacePts, Tuple<decimal, decimal, string, string, string> secondPlacePts, Tuple<decimal, decimal, string, string, string> thirdPlacePts, Tuple<decimal, decimal> totalPts)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.firstPlacePts = firstPlacePts;
            this.secondPlacePts = secondPlacePts;
            this.thirdPlacePts = thirdPlacePts;
            this.totalPts = totalPts;
        }
    }
}
