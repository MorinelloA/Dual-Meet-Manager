using DualMeetManager.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Test.Domain
{
    [TestFixture]
    class MeetTest
    {
        [TestCase]
        public void TestDefaultConstructor()
        {
            Meet blankMeet = new Meet();
            Assert.AreEqual(blankMeet != null, true);
        }

        [TestCase]
        public void TestParameterizedConstructor()
        {
            bool test = true;

            Performance myPerformance1 = new Performance("A", "AA", 1.1m);
            Performance myPerformance2 = new Performance("B", "BB", 2.2m);
            Performance myPerformance3 = new Performance("C", "CC", 3.3m);
            Performance myPerformance4 = new Performance("D", "AA", 4.1m);
            Performance myPerformance5 = new Performance("E", "BB", 5.2m);
            Performance myPerformance6 = new Performance("F", "CC", 6.3m);

            List<Performance> myPerformancesA = new List<Performance>();
            myPerformancesA.Add(myPerformance1);
            myPerformancesA.Add(myPerformance2);
            myPerformancesA.Add(myPerformance3);

            List<Performance> myPerformancesB = new List<Performance>();
            myPerformancesB.Add(myPerformance4);
            myPerformancesB.Add(myPerformance5);
            myPerformancesB.Add(myPerformance6);

            Event myEvent1 = new Event("Boy's 100", myPerformancesA);
            Event myEvent2 = new Event("Boy's 200", myPerformancesB);
            List<Event> myEvents = new List<Event>();
            myEvents.Add(myEvent1);
            myEvents.Add(myEvent2);

            List<string> boysNames = new List<string>();
            List<string> boysAbbr = new List<string>();
            boysNames.Add("Baldwin");
            boysAbbr.Add("BLN");
            boysNames.Add("Thomas Jefferson");
            boysAbbr.Add("TJ");
            boysNames.Add("Washington HS");
            boysAbbr.Add("WHS");

            List<string> girlsNames = new List<string>();
            List<string> girlsAbbr = new List<string>();
            girlsNames.Add("Plum");
            girlsAbbr.Add("PLM");
            girlsNames.Add("Gateway");
            girlsAbbr.Add("GWY");
            girlsNames.Add("Knoch");
            girlsAbbr.Add("KCH");
            
            Meet myMeetNoEvents = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNames, girlsNames, boysAbbr, girlsAbbr);

            if (myMeetNoEvents.dateOfMeet != new DateTime(2017, 04, 13)) test = false;
            else if (myMeetNoEvents.location != "Baldwin HS") test = false;
            else if (myMeetNoEvents.weatherConditions != "Windy") test = false;
            else if (!myMeetNoEvents.boySchoolNames.SequenceEqual(boysNames)) test = false;
            else if (!myMeetNoEvents.girlSchoolNames.SequenceEqual(girlsNames)) test = false;
            else if (!myMeetNoEvents.boySchoolAbbr.SequenceEqual(boysAbbr)) test = false;
            else if (!myMeetNoEvents.girlSchoolAbbr.SequenceEqual(girlsAbbr)) test = false;

            Meet myMeetWithEvents = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNames, girlsNames, boysAbbr, girlsAbbr, myEvents);

            if (myMeetWithEvents.dateOfMeet != new DateTime(2017, 04, 13)) test = false;
            else if (myMeetWithEvents.location != "Baldwin HS") test = false;
            else if (myMeetWithEvents.weatherConditions != "Windy") test = false;
            else if (!myMeetWithEvents.boySchoolNames.SequenceEqual(boysNames)) test = false;
            else if (!myMeetWithEvents.girlSchoolNames.SequenceEqual(girlsNames)) test = false;
            else if (!myMeetWithEvents.boySchoolAbbr.SequenceEqual(boysAbbr)) test = false;
            else if (!myMeetWithEvents.girlSchoolAbbr.SequenceEqual(girlsAbbr)) test = false;
            else if (!myMeetWithEvents.events.SequenceEqual(myEvents)) test = false;

            Assert.True(test);
        }

        [TestCase]
        public void TestEqualsMethod()
        {
            bool test = true;

            Performance myPerformance1 = new Performance("A", "AA", 1.1m);
            Performance myPerformance2 = new Performance("B", "BB", 2.2m);
            Performance myPerformance3 = new Performance("C", "CC", 3.3m);
            Performance myPerformance4 = new Performance("D", "AA", 4.1m);
            Performance myPerformance5 = new Performance("E", "BB", 5.2m);
            Performance myPerformance6 = new Performance("F", "CC", 6.3m);

            List<Performance> myPerformancesA = new List<Performance>();
            myPerformancesA.Add(myPerformance1);
            myPerformancesA.Add(myPerformance2);

            List<Performance> myPerformancesB = new List<Performance>();
            myPerformancesB.Add(myPerformance3);
            myPerformancesB.Add(myPerformance4);

            List<Performance> myPerformancesC = new List<Performance>();
            myPerformancesC.Add(myPerformance5);
            myPerformancesC.Add(myPerformance6);

            Event myEvent1 = new Event("Boy's 100", myPerformancesA);
            Event myEvent2 = new Event("Boy's 200", myPerformancesB);
            Event myEvent3 = new Event("Boy's 400", myPerformancesC);

            List<Event> myEventsA = new List<Event>();
            myEventsA.Add(myEvent1);
            myEventsA.Add(myEvent2);

            List<Event> myEventsB = new List<Event>();
            myEventsB.Add(myEvent1);
            myEventsB.Add(myEvent2);

            List<Event> myEventsC = new List<Event>();
            myEventsC.Add(myEvent2);
            myEventsC.Add(myEvent3);

            List<string> boysNamesA = new List<string>();
            List<string> boysAbbrA = new List<string>();
            boysNamesA.Add("Baldwin");
            boysAbbrA.Add("BLN");
            boysNamesA.Add("Thomas Jefferson");
            boysAbbrA.Add("TJ");
            boysNamesA.Add("Washington HS");
            boysAbbrA.Add("WHS");

            List<string> boysNamesB = new List<string>();
            List<string> boysAbbrB = new List<string>();
            boysNamesB.Add("Baldwin");
            boysAbbrB.Add("BLN");
            boysNamesB.Add("Thomas Jefferson");
            boysAbbrB.Add("TJ");
            boysNamesB.Add("Washington HS");
            boysAbbrB.Add("WHS");

            List<string> boysNamesC = new List<string>();
            List<string> boysAbbrC = new List<string>();
            boysNamesC.Add("Baldwin");
            boysAbbrC.Add("BLN");
            boysNamesC.Add("Thomas Jefferson");
            boysAbbrC.Add("TJ");
            boysNamesC.Add("Beaver HS");
            boysAbbrC.Add("BHS");

            List<string> girlsNamesA = new List<string>();
            List<string> girlsAbbrA = new List<string>();
            girlsNamesA.Add("Plum");
            girlsAbbrA.Add("PLM");
            girlsNamesA.Add("Gateway");
            girlsAbbrA.Add("GWY");
            girlsNamesA.Add("Knoch");
            girlsAbbrA.Add("KCH");

            List<string> girlsNamesB = new List<string>();
            List<string> girlsAbbrB = new List<string>();
            girlsNamesB.Add("Plum");
            girlsAbbrB.Add("PLM");
            girlsNamesB.Add("Gateway");
            girlsAbbrB.Add("GWY");
            girlsNamesB.Add("Knoch");
            girlsAbbrB.Add("KCH");

            List<string> girlsNamesC = new List<string>();
            List<string> girlsAbbrC = new List<string>();
            girlsNamesC.Add("Plum");
            girlsAbbrC.Add("PLM");
            girlsNamesC.Add("Gateway");
            girlsAbbrC.Add("GWY");
            girlsNamesC.Add("Ohio HS");
            girlsAbbrC.Add("OHH");

            //Meet to test
            Meet meet1 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsA);

            //Equal Meet
            Meet meet2 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesB, girlsNamesB, boysAbbrB, girlsAbbrB, myEventsB);

            //Differnet Date
            Meet meet3 = new Meet(new DateTime(2017, 04, 12), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsA);

            //Different Location 
            Meet meet4 = new Meet(new DateTime(2017, 04, 13), "Trinity HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsA);

            //Different Weather Conditions
            Meet meet5 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Cloudy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsA);

            //Different Boy's Teams
            Meet meet6 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesC, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsA);

            //Differnet Girls's Teams
            Meet meet7 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesC, boysAbbrA, girlsAbbrA, myEventsA);

            //Different Boy's Abbr
            Meet meet8 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrC, girlsAbbrA, myEventsA);

            //Different Girl's Abbr
            Meet meet9 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrC, myEventsA);

            //Different Results
            Meet meet10 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsC);

            //No Results
            Meet meet11 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA);

            if (!meet1.Equals(meet2)) test = false;
            else if (meet1.Equals(meet3)) test = false;
            else if (meet1.Equals(meet4)) test = false;
            else if (meet1.Equals(meet5)) test = false;
            else if (meet1.Equals(meet6)) test = false;
            else if (meet1.Equals(meet7)) test = false;
            else if (meet1.Equals(meet8)) test = false;
            else if (meet1.Equals(meet9)) test = false;
            else if (meet1.Equals(meet10)) test = false;
            else if (meet1.Equals(meet11)) test = false;

            Assert.True(test);
        }

        [TestCase]
        public void TestToStringMethod()
        {
            Performance myPerformance1 = new Performance("A", "AA", 1.1m);
            Performance myPerformance2 = new Performance("B", "BB", 2.2m);
            Performance myPerformance3 = new Performance("C", "CC", 3.3m);
            Performance myPerformance4 = new Performance("D", "DD", 4.1m);

            List<Performance> myPerformancesA = new List<Performance>();
            myPerformancesA.Add(myPerformance1);
            myPerformancesA.Add(myPerformance2);

            List<Performance> myPerformancesB = new List<Performance>();
            myPerformancesB.Add(myPerformance3);
            myPerformancesB.Add(myPerformance4);

            Event myEvent1 = new Event("Boy's 100", myPerformancesA);
            Event myEvent2 = new Event("Boy's 200", myPerformancesB);

            List<Event> myEventsA = new List<Event>();
            myEventsA.Add(myEvent1);
            myEventsA.Add(myEvent2);

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

            Meet myMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsA);

            string strMeet = myMeet.ToString();
            Assert.AreEqual(strMeet, "Date: 04/13/2017" + Environment.NewLine +
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
