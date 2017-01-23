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
            Performance myPerformance4 = new Performance("D", "AA", 4.1m);

            List<Performance> myPerformancesA = new List<Performance>();
            myPerformancesA.Add(myPerformance1);
            myPerformancesA.Add(myPerformance2);

            List<Performance> myPerformancesB = new List<Performance>();
            myPerformancesB.Add(myPerformance3);
            myPerformancesB.Add(myPerformance4);

            Dictionary<string, List<Performance>> performances = new Dictionary<string, List<Performance>>();

            performances.Add("Boy's 100", myPerformancesA);
            performances.Add("Boy's 200", myPerformancesB);

            List<string> boysNamesA = new List<string>();
            List<string> boysAbbrA = new List<string>();
            boysNamesA.Add("Baldwin");
            boysAbbrA.Add("BLN");
            boysNamesA.Add("Thomas Jefferson");
            boysAbbrA.Add("TJ");
            boysNamesA.Add("Washington HS");
            boysAbbrA.Add("WHS");

            List<string> girlsNamesA = new List<string>();
            List<string> girlsAbbrA = new List<string>();
            girlsNamesA.Add("Plum");
            girlsAbbrA.Add("PLM");
            girlsNamesA.Add("Gateway");
            girlsAbbrA.Add("GWY");
            girlsNamesA.Add("Knoch");
            girlsAbbrA.Add("KCH");

            Meet myMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA, performances);

            string strMeet = myMeet.ToString();
            Console.WriteLine(strMeet);
            Console.WriteLine();

            Console.WriteLine("Date: 04/13/2017" + Environment.NewLine +
                "Location: " + "Baldwin HS" + Environment.NewLine +
                "Weather Conditions: " + "Windy" + Environment.NewLine +
                "Teams:" + Environment.NewLine +
                "Boys:" + Environment.NewLine +
                "Baldwin - BLN" + Environment.NewLine +
                "Thomas Jefferson - TJ" + Environment.NewLine +
                "Washington HS - WHS" + Environment.NewLine +
                "Girls:" + Environment.NewLine +
                "Plum - PLM" + Environment.NewLine +
                "Gateway - GWY" + Environment.NewLine +
                "Knoch - KCH" + Environment.NewLine +
                "Event: " + "Boy's 100" + Environment.NewLine +
                "Name: " + "A" + ", " + "AA" + " - " + 1.1 + Environment.NewLine +
                "Name: " + "B" + ", " + "BB" + " - " + 2.2 + Environment.NewLine +
                "Event: " + "Boy's 200" + Environment.NewLine +
                "Name: " + "C" + ", " + "CC" + " - " + 3.3 + Environment.NewLine +
                "Name: " + "D" + ", " + "DD" + " - " + 4.1);
        }
    }
}
