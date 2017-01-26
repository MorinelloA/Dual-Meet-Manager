using DualMeetManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Performance myPerformance1 = new Performance("A", "AA", 1.1m);
            Performance myPerformance2 = new Performance("B", "BB", 2.2m);
            Performance myPerformance3 = new Performance("C", "CC", 3.3m);
            Performance myPerformance4 = new Performance("D", "DD", 4.1m);
            Performance myPerformance5 = new Performance("E", "EE", 3.3m);
            Performance myPerformance6 = new Performance("F", "FF", 4.1m);

            List<Performance> myPerformancesA = new List<Performance>();
            myPerformancesA.Add(myPerformance1);
            myPerformancesA.Add(myPerformance2);

            List<Performance> myPerformancesB = new List<Performance>();
            myPerformancesB.Add(myPerformance3);
            myPerformancesB.Add(myPerformance4);

            List<Performance> myPerformancesC = new List<Performance>();
            myPerformancesC.Add(myPerformance5);
            myPerformancesC.Add(myPerformance6);

            Dictionary<Tuple<string, int>, List<Performance>> myEventsA = new Dictionary<Tuple<string, int>, List<Performance>>();
            myEventsA.Add(Tuple.Create("Boy's 100", 1), myPerformancesA);
            myEventsA.Add(Tuple.Create("Boy's 200", 1), myPerformancesB);

            Dictionary<string, string> boysNamesA = new Dictionary<string, string>();
            boysNamesA.Add("BLN", "Baldwin");
            boysNamesA.Add("TJ", "Thomas Jefferson");
            boysNamesA.Add("WHS", "Washington HS");

            Dictionary<string, string> girlsNamesA = new Dictionary<string, string>();
            girlsNamesA.Add("PLM", "Plum");
            girlsNamesA.Add("GWY", "Gateway");
            girlsNamesA.Add("KCH", "Knoch");

            Teams teams = new Teams(boysNamesA, girlsNamesA);

            Meet myMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams, myEventsA);

            Console.WriteLine(myMeet.ToString());
            Console.WriteLine();
            Console.WriteLine();
            myMeet.AddPerformance("Boy's 100", 2, myPerformancesC);
            Console.WriteLine(myMeet.ToString());
        }
    }
}
