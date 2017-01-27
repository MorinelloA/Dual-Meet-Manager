﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain.Scoring
{
    public class RelayEvent
    {
        string team1 { get; set; }
        string team2 { get; set; }

        //Having points assigned for relays seems redundant since the winning relay gets 5pts, and the loser gets 0.
        //However, if rules were ever to change, the code would be much easier to update this way.

        //Pts
        //Team1 pts, Team2 pts, school abbr, performance
        //Note: performance is a string because it could be in minutes and seconds (ex: 4:25)
        Tuple<decimal, decimal, string, string> firstPlacePts { get; set; }
        Tuple<decimal, decimal, string, string> secondPlacePts { get; set; }
        Tuple<int, int> totalPts { get; set; }

        //Default Constructor
        public RelayEvent() { }

        //Parameterized Constructor
        public RelayEvent(string team1, string team2, Tuple<decimal, decimal, string, string> firstPlacePts, Tuple<decimal, decimal, string, string> secondPlacePts, Tuple<int, int> totalPts)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.firstPlacePts = firstPlacePts;
            this.secondPlacePts = secondPlacePts;
            this.totalPts = totalPts;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("First Place: " + firstPlacePts.Item3 + ": " + firstPlacePts.Item4);
            sb.Append("First Place Pts: " + team1 + ": " + firstPlacePts.Item1 + " " + team2 + ": " + firstPlacePts.Item2);
            sb.Append("Second Place: " + secondPlacePts.Item3 + ": " + secondPlacePts.Item4);
            sb.Append("Second Place Pts: " + team1 + ": " + secondPlacePts.Item1 + " " + team2 + ": " + secondPlacePts.Item2);
            sb.Append("Total: " + team1 + ": " + totalPts.Item1 + " " + team2 + ": " + totalPts.Item2);
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            RelayEvent myIndEvent = obj as RelayEvent;
            if (!myIndEvent.team1.Equals(team1)) return false;
            else if (!myIndEvent.team2.Equals(team2)) return false;
            else if (!myIndEvent.firstPlacePts.Equals(firstPlacePts)) return false;
            else if (!myIndEvent.secondPlacePts.Equals(secondPlacePts)) return false;
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
                hash = hash * 23 + totalPts.GetHashCode();
                return hash;
            }
        }
    }
}
