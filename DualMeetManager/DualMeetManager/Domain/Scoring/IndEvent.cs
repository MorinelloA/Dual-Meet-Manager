using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain.Scoring
{
    class IndEvent
    {
        Tuple<string, string> team1 { get; set; }
        Tuple<string, string> team2 { get; set; }
        Tuple<decimal, decimal> firstPlacePts { get; set; }
        Tuple<decimal, decimal> secondPlacePts { get; set; }
        Tuple<decimal, decimal> thirdPlacePts { get; set; }
        Tuple<decimal, decimal> totalPts { get; set; }

        //Default Constructor
        public IndEvent() { }

        //Constructor without points
        public IndEvent(Tuple<string, string> team1, Tuple<string, string> team2)
        {
            this.team1 = team1;
            this.team2 = team2;
        }

        //Constructor without points without using tuples in parameters
        public IndEvent(string team1Abbr, string team1Name, string team2Abbr, string team2Name)
        {
            team1 = Tuple.Create(team1Abbr, team1Name);
            team2 = Tuple.Create(team2Abbr, team2Name);
        }

        //Constructor with points
        public IndEvent(Tuple<string, string> team1, Tuple<string, string> team2, Tuple<decimal, decimal> firstPlacePts, Tuple<decimal, decimal> secondPlacePts, Tuple<decimal, decimal> thirdPlacePts, Tuple<decimal, decimal> totalPts)
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
