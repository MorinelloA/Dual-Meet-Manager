using DualMeetManager.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Tests.Domain
{
    [TestFixture]
    class MeetTest
    {
        
        [TestCase]
        public void TestDefaultConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            Meet blankMeet = new Meet();
            Assert.AreEqual(blankMeet != null, true, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestParameterizedConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
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

            Dictionary<string, List<Performance>> myPerformances = new Dictionary<string, List<Performance>>();
            myPerformances.Add("Boy's 100", myPerformancesA);
            myPerformances.Add("Boy's 200", myPerformancesB);

            Dictionary<string, string> boysNames = new Dictionary<string, string>();
            boysNames.Add("BLN", "Baldwin");
            boysNames.Add("TJ", "Thomas Jefferson");
            boysNames.Add("WHS", "Washington HS");

            Dictionary<string, string> girlsNames = new Dictionary<string, string>();
            girlsNames.Add("PLM", "Plum");
            girlsNames.Add("GWY", "Gateway");
            girlsNames.Add("KCH", "Knoch");

            Teams teams = new Teams(boysNames, girlsNames);
            
            Meet myMeetNoEvents = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams);

            if (myMeetNoEvents.dateOfMeet != new DateTime(2017, 04, 13))
            {
                test = false;
                Console.WriteLine("myMeetNoEvents - Invalid date");
            }
            else if (myMeetNoEvents.location != "Baldwin HS")
            {
                test = false;
                Console.WriteLine("myMeetNoEvents - Invalid location");
            }
            else if (myMeetNoEvents.weatherConditions != "Windy")
            {
                test = false;
                Console.WriteLine("myMeetNoEvents - Invalid weather conditions");
            }
            else if (!myMeetNoEvents.schoolNames.Equals(teams))
            {
                test = false;
                Console.WriteLine("myMeetNoEvents - Invalid Teams object");
            }

            Meet myMeetWithEvents = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams, myPerformances);

            if (myMeetWithEvents.dateOfMeet != new DateTime(2017, 04, 13))
            {
                test = false;
                Console.WriteLine("myMeetWithEvents - Invalid date");
            }
            else if (myMeetWithEvents.location != "Baldwin HS")
            {
                test = false;
                Console.WriteLine("myMeetWithEvents - Invalid location");
            }
            else if (myMeetWithEvents.weatherConditions != "Windy")
            {
                test = false;
                Console.WriteLine("myMeetWithEvents - Invalid weather conditions");
            }
            else if (!myMeetWithEvents.schoolNames.Equals(teams))
            {
                test = false;
                Console.WriteLine("myMeetWithEvents - Invalid Teams object");
            }
            else if (!myMeetWithEvents.performances.SequenceEqual(myPerformances))
            {
                test = false;
                Console.WriteLine("Invalid performances");
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestEqualsMethod()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
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

            Dictionary<string, List<Performance>> myEventsA = new Dictionary<string, List<Performance>>();
            myEventsA.Add("Boy's 100", myPerformancesA);
            myEventsA.Add("Boy's 200", myPerformancesB);

            Dictionary<string, List<Performance>> myEventsB = new Dictionary<string, List<Performance>>();
            myEventsB.Add("Boy's 100", myPerformancesA);
            myEventsB.Add("Boy's 200", myPerformancesB);

            Dictionary<string, List<Performance>> myEventsC = new Dictionary<string, List<Performance>>();
            myEventsC.Add("Boy's 100", myPerformancesB);
            myEventsC.Add("Boy's 200", myPerformancesC);

            //Teams
            Dictionary<string, string> boysNamesA = new Dictionary<string, string>();
            boysNamesA.Add("BLN", "Baldwin");
            boysNamesA.Add("TJ", "Thomas Jefferson");
            boysNamesA.Add("WHS", "Washington HS");

            Dictionary<string, string> boysNamesB = new Dictionary<string, string>();
            boysNamesB.Add("BLN", "Baldwin");
            boysNamesB.Add("TJ", "Thomas Jefferson");
            boysNamesB.Add("WHS", "Washington HS");

            Dictionary<string, string> boysNamesC = new Dictionary<string, string>();
            boysNamesC.Add("BLN", "Baldwin");
            boysNamesC.Add("TJ", "Thomas Jefferson");
            boysNamesC.Add("WHS", "Washington");

            Dictionary<string, string> boysNamesD = new Dictionary<string, string>();
            boysNamesD.Add("BLN", "Baldwin");
            boysNamesD.Add("TJ", "Thomas Jefferson");
            boysNamesD.Add("BHS", "Washington HS");

            Dictionary<string, string> girlsNamesA = new Dictionary<string, string>();
            girlsNamesA.Add("PLM", "Plum");
            girlsNamesA.Add("GWY", "Gateway");
            girlsNamesA.Add("KCH", "Knoch");

            Dictionary<string, string> girlsNamesB = new Dictionary<string, string>();
            girlsNamesB.Add("PLM", "Plum");
            girlsNamesB.Add("GWY", "Gateway");
            girlsNamesB.Add("KCH", "Knoch");

            Dictionary<string, string> girlsNamesC = new Dictionary<string, string>();
            girlsNamesC.Add("PLM", "Plum");
            girlsNamesC.Add("GWY", "Gateway");
            girlsNamesC.Add("KCH", "Ohio HS");

            Dictionary<string, string> girlsNamesD = new Dictionary<string, string>();
            girlsNamesD.Add("PLM", "Plum");
            girlsNamesD.Add("GWY", "Gateway");
            girlsNamesD.Add("KOH", "Knoch");

            Teams teams1 = new Teams(boysNamesA, girlsNamesA);
            Teams teams2 = new Teams(boysNamesB, girlsNamesB);
            Teams teams3 = new Teams(boysNamesC, girlsNamesA);
            Teams teams4 = new Teams(boysNamesA, girlsNamesC);
            Teams teams5 = new Teams(boysNamesD, girlsNamesA);
            Teams teams6 = new Teams(boysNamesA, girlsNamesD);

            //Meet to test
            Meet meet1 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams1, myEventsA);

            //Equal Meet
            Meet meet2 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams2, myEventsB);

            //Differnet Date
            Meet meet3 = new Meet(new DateTime(2017, 04, 12), "Baldwin HS", "Windy", teams1, myEventsA);

            //Different Location 
            Meet meet4 = new Meet(new DateTime(2017, 04, 13), "Trinity HS", "Windy", teams1, myEventsA);

            //Different Weather Conditions
            Meet meet5 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Cloudy", teams1, myEventsA);

            //Different Boy's Teams
            Meet meet6 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams3, myEventsA);

            //Differnet Girls's Teams
            Meet meet7 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams4, myEventsA);

            //Different Boy's Abbr
            Meet meet8 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams5, myEventsA);

            //Different Girl's Abbr
            Meet meet9 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams6, myEventsA);

            //Different Results
            Meet meet10 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams1, myEventsC);

            //No Results
            Meet meet11 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams1);

            if (!meet1.Equals(meet2))
            {
                test = false;
                Console.WriteLine("meet1 does not equal meet2");
            }
            else if (meet1.Equals(meet3))
            {
                test = false;
                Console.WriteLine("meet1 equals meet3");
            }
            else if (meet1.Equals(meet4))
            {
                test = false;
                Console.WriteLine("meet1 equals meet4");
            }
            else if (meet1.Equals(meet5))
            {
                test = false;
                Console.WriteLine("meet1 equals meet5");
            }
            else if (meet1.Equals(meet6))
            {
                test = false;
                Console.WriteLine("meet1 equals meet6");
            }
            else if (meet1.Equals(meet7))
            {
                test = false;
                Console.WriteLine("meet1 equals meet7");
            }
            else if (meet1.Equals(meet8))
            {
                test = false;
                Console.WriteLine("meet1 equals meet8");
            }
            else if (meet1.Equals(meet9))
            {
                test = false;
                Console.WriteLine("meet1 equals meet9");
            }
            else if (meet1.Equals(meet10))
            {
                test = false;
                Console.WriteLine("meet1 equals meet10");
            }
            else if (meet1.Equals(meet11))
            {
                test = false;
                Console.WriteLine("meet1 equals meet11");
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
        
        [TestCase]
        public void TestToStringMethod()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
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

            Dictionary<string, List<Performance>> myEventsA = new Dictionary<string, List<Performance>>();
            myEventsA.Add("Boy's 100", myPerformancesA);
            myEventsA.Add("Boy's 200", myPerformancesB);

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

            string strMeet = myMeet.ToString();

            Console.WriteLine("My string:" + Environment.NewLine + Environment.NewLine);
            Console.WriteLine(strMeet + Environment.NewLine);

            Console.WriteLine("Expecting:" + Environment.NewLine + Environment.NewLine);
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
                "Name: " + "D" + ", " + "DD" + " - " + 4.1, 
                GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");

            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestValidateMethod()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            bool test = true;

            Performance myPerformance1 = new Performance("A", "AA", 1.1m);
            Performance myPerformance2 = new Performance("B", "BB", 2.2m);
            Performance myPerformance3 = new Performance("C", "CC", 3.3m);
            Performance myPerformance4 = new Performance("D", "DD", 4.1m);
            Performance myPerformance5 = new Performance("", "DD", 4.1m);

            List<Performance> myPerformancesA = new List<Performance>();
            myPerformancesA.Add(myPerformance1);
            myPerformancesA.Add(myPerformance2);

            List<Performance> myPerformancesB = new List<Performance>();
            myPerformancesB.Add(myPerformance3);
            myPerformancesB.Add(myPerformance4);

            List<Performance> myPerformancesC = new List<Performance>();
            myPerformancesC.Add(myPerformance5);

            //Events
            Dictionary<string, List<Performance>> myEventsA = new Dictionary<string, List<Performance>>();
            myEventsA.Add("Boy's 100", myPerformancesA);
            myEventsA.Add("Boy's 200", myPerformancesB);

            Dictionary<string, List<Performance>> myEventsB = new Dictionary<string, List<Performance>>();
            myEventsB.Add("Boy's 100", myPerformancesA);
            myEventsB.Add("Boy's 200", myPerformancesB);
            myEventsB.Add("Boy's 400", myPerformancesC);

            Dictionary<string, List<Performance>> myEventsC = new Dictionary<string, List<Performance>>();
            myEventsC.Add("Boy's 100", myPerformancesA);
            myEventsC.Add("200", myPerformancesB);

            //Team Names
            Dictionary<string, string> boysNamesA = new Dictionary<string, string>();
            boysNamesA.Add("BLN", "Baldwin");
            boysNamesA.Add("TJ", "Thomas Jefferson");
            boysNamesA.Add("WHS", "Washington HS");

            Dictionary<string, string> dupBoysNames = new Dictionary<string, string>();
            dupBoysNames.Add("BLN", "Baldwin");
            dupBoysNames.Add("TJ", "Thomas Jefferson");
            dupBoysNames.Add("BLD", "Baldwin");

            Dictionary<string, string> boysNamesC = new Dictionary<string, string>();
            boysNamesC.Add("BLN", "Baldwin");
            boysNamesC.Add("TJ", "Thomas Jefferson");
            boysNamesC.Add("", "Washinton HS");

            Dictionary<string, string> girlsNamesA = new Dictionary<string, string>();
            girlsNamesA.Add("PLM", "Plum");
            girlsNamesA.Add("GWY", "Gateway");
            girlsNamesA.Add("KCH", "Knoch");

            Dictionary<string, string> dupGirlsNames = new Dictionary<string, string>();
            dupGirlsNames.Add("PLM", "Plum");
            dupGirlsNames.Add("GWY", "Gateway");
            dupGirlsNames.Add("PM", "Plum");

            Dictionary<string, string> girlsNamesC = new Dictionary<string, string>();
            girlsNamesC.Add("PLM", "Plum");
            girlsNamesC.Add("GWY", "Gateway");
            girlsNamesC.Add("KCH", "");

            Dictionary<string, string> overAbbr = new Dictionary<string, string>();
            overAbbr.Add("PLM", "Plum");
            overAbbr.Add("GATE", "Gateway");
            overAbbr.Add("KCH", "Kiski");

            Teams teams1 = new Teams(boysNamesA, girlsNamesA);
            Teams teams2 = new Teams(dupBoysNames, girlsNamesA);
            Teams teams3 = new Teams(boysNamesC, girlsNamesA);
            Teams teams4 = new Teams(boysNamesA, girlsNamesC);
            Teams teams5 = new Teams(boysNamesA, dupGirlsNames);
            Teams teams6 = new Teams(overAbbr, girlsNamesA);
            Teams teams7 = new Teams(boysNamesA, overAbbr);

            Meet validMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams1, myEventsA);
            Meet validNoEventsMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams1);
            Meet invalidDateTime = new Meet(DateTime.MinValue, "Baldwin HS", "Windy", teams1, myEventsA);
            Meet invalidLocation1 = new Meet(new DateTime(2017, 04, 13), null, "Windy", teams1, myEventsA);
            Meet invalidWeather1 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", null, teams1, myEventsA);
            Meet invalidLocation2 = new Meet(new DateTime(2017, 04, 13), "", "Windy", teams1, myEventsA);
            Meet invalidWeather2 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "", teams1, myEventsA);
            Meet dupBoysNameMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams2, myEventsA);
            Meet dupGirlsNameMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams5, myEventsA);
            Meet overBoysAbbrMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams6, myEventsA);
            Meet overGirlsAbbrMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams7, myEventsA);
            Meet invalidBoysName = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams3, myEventsA);
            Meet invalidGirlsName = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams4, myEventsA);
            Meet invalidPerformance = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams1, myEventsB);
            Meet invalidEventName = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams1, myEventsC);
            
            if (!validMeet.validate())
            {
                test = false;
                Console.WriteLine("validMeet failed");
            }
            else if (!validNoEventsMeet.validate())
            {
                test = false;
                Console.WriteLine("validNoEventsMeet failed");
            }
            else if (invalidDateTime.validate())
            {
                test = false;
                Console.WriteLine("invalidDateTime was valid");
            }
            else if (invalidLocation1.validate())
            {
                test = false;
                Console.WriteLine("invalidLocation1 was valid");
            }
            else if (invalidLocation2.validate())
            {
                test = false;
                Console.WriteLine("invalidLocation2 was valid");
            }
            else if (invalidWeather1.validate())
            {
                test = false;
                Console.WriteLine("invalidWeather1 was valid");
            }
            else if (invalidWeather2.validate())
            {
                test = false;
                Console.WriteLine("invalidWeather2 was valid");
            }
            else if (dupBoysNameMeet.validate())
            {
                test = false;
                Console.WriteLine("dupBoysNameMeet was valid");
            }
            else if (dupGirlsNameMeet.validate())
            {
                test = false;
                Console.WriteLine("dupGirlsNameMeet was valid");
            }
            else if (overBoysAbbrMeet.validate())
            {
                test = false;
                Console.WriteLine("overBoysAbbrMeet was valid");
            }
            else if (overGirlsAbbrMeet.validate())
            {
                test = false;
                Console.WriteLine("overGirlsAbbrMeet was valid");
            }
            else if (invalidBoysName.validate())
            {
                test = false;
                Console.WriteLine("invalidBoysName was valid");
            }
            else if (invalidGirlsName.validate())
            {
                test = false;
                Console.WriteLine("invalidGirlsName was valid");
            }
            else if (invalidPerformance.validate())
            {
                test = false;
                Console.WriteLine("invalidPerformance was valid");
            }
            else if (invalidEventName.validate())
            {
                test = false;
                Console.WriteLine("invalidEventName was valid");
            }
            else
            {
                Console.WriteLine("TestValidateMethod Passed!");
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
    }
}