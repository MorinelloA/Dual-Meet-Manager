using DualMeetManager.src.com.dualmeetmanager.model.domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.test.com.dualmeetmanager.model.domain
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

            Meet myMeetWithEvents = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNames, girlsNames, boysAbbr, girlsAbbr, myPerformances);

            if (myMeetWithEvents.dateOfMeet != new DateTime(2017, 04, 13))
            {
                test = false;
                Console.WriteLine("Invalid date");
            }
            else if (myMeetWithEvents.location != "Baldwin HS")
            {
                test = false;
                Console.WriteLine("Invalid location");
            }
            else if (myMeetWithEvents.weatherConditions != "Windy")
            {
                test = false;
                Console.WriteLine("Invalid weather conditions");
            }
            else if (!myMeetWithEvents.boySchoolNames.SequenceEqual(boysNames))
            {
                test = false;
                Console.WriteLine("Invalid boy school names");
            }
            else if (!myMeetWithEvents.girlSchoolNames.SequenceEqual(girlsNames))
            {
                test = false;
                Console.WriteLine("Invalid girl school names");
            }
            else if (!myMeetWithEvents.boySchoolAbbr.SequenceEqual(boysAbbr))
            {
                test = false;
                Console.WriteLine("Invalid boy school abbr");
            }
            else if (!myMeetWithEvents.girlSchoolAbbr.SequenceEqual(girlsAbbr))
            {
                test = false;
                Console.WriteLine("Invalid girl school abbr");
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
        
        //[TestCase]
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

            List<string> boysNamesA = new List<string>();
            List<string> boysAbbrA = new List<string>();
            boysNamesA.Add("Baldwin");
            boysAbbrA.Add("BLN");
            boysNamesA.Add("Thomas Jefferson");
            boysAbbrA.Add("TJ");
            boysNamesA.Add("Washington HS");
            boysAbbrA.Add("WHS");

            List<string> dupBoysNames = new List<string>();
            List<string> dupBoysAbbr = new List<string>();
            dupBoysNames.Add("Baldwin");
            dupBoysAbbr.Add("BLN");
            dupBoysNames.Add("Thomas Jefferson");
            dupBoysAbbr.Add("TJ");
            dupBoysNames.Add("Baldwin");
            dupBoysAbbr.Add("BLN");

            List<string> boysNamesC = new List<string>();
            List<string> boysAbbrC = new List<string>();
            boysNamesC.Add("Baldwin");
            boysAbbrC.Add("BLN");
            boysNamesC.Add("Thomas Jefferson");
            boysAbbrC.Add("TJ");
            boysAbbrC.Add("WHS");

            List<string> girlsNamesA = new List<string>();
            List<string> girlsAbbrA = new List<string>();
            girlsNamesA.Add("Plum");
            girlsAbbrA.Add("PLM");
            girlsNamesA.Add("Gateway");
            girlsAbbrA.Add("GWY");
            girlsNamesA.Add("Knoch");
            girlsAbbrA.Add("KCH");

            List<string> dupGirlsNames = new List<string>();
            List<string> dupGirlsAbbr = new List<string>();
            dupGirlsNames.Add("Plum");
            dupGirlsAbbr.Add("PLM");
            dupGirlsNames.Add("Gateway");
            dupGirlsAbbr.Add("GWY");
            dupGirlsNames.Add("Plum");
            dupGirlsAbbr.Add("PLM");

            List<string> girlsNamesC = new List<string>();
            List<string> girlsAbbrC = new List<string>();
            girlsNamesC.Add("Plum");
            girlsAbbrC.Add("PLM");
            girlsNamesC.Add("Gateway");
            girlsAbbrC.Add("GWY");
            girlsNamesC.Add("Knoch");

            List<string> girlsNamesD = new List<string>();
            List<string> girlsAbbrD = new List<string>();
            girlsNamesD.Add("Plum");
            girlsAbbrD.Add("PLM");
            girlsNamesD.Add("");
            girlsAbbrD.Add("GWY");
            girlsNamesD.Add("Knoch");
            girlsAbbrD.Add("");

            List<string> boysNamesD = new List<string>();
            List<string> boysAbbrD = new List<string>();
            boysNamesD.Add("Plum");
            boysAbbrD.Add("PLM");
            boysNamesD.Add("");
            boysAbbrD.Add("GWY");
            boysNamesD.Add("Knoch");
            boysAbbrD.Add("");

            List<string> overBoysAbbr = new List<string>();
            overBoysAbbr.Add("PLM");
            overBoysAbbr.Add("GATE");
            overBoysAbbr.Add("GWY");

            List<string> overGirlsAbbr = new List<string>();
            overGirlsAbbr.Add("PLM");
            overGirlsAbbr.Add("GATE");
            overGirlsAbbr.Add("GWY");
            
            Meet validMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsA);
            Meet validNoEventsMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA);
            Meet invalidDateTime = new Meet(DateTime.MinValue, "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsA);
            Meet invalidLocation1 = new Meet(new DateTime(2017, 04, 13), null, "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsA);
            Meet invalidWeather1 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", null, boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsA);
            Meet invalidLocation2 = new Meet(new DateTime(2017, 04, 13), "", "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsA);
            Meet invalidWeather2 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsA);
            Meet dupBoysNameMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", dupBoysNames, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsA);
            Meet dupGirlsNameMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, dupGirlsNames, boysAbbrA, girlsAbbrA, myEventsA);
            Meet dupBoysAbbrMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, dupBoysAbbr, girlsAbbrA, myEventsA);
            Meet dupGirlsAbbrMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, dupGirlsAbbr, myEventsA);
            Meet mismatchBoysNames = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesC, girlsNamesA, boysAbbrC, girlsAbbrA, myEventsA);
            Meet mismatchGirlsNames = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesC, boysAbbrA, girlsAbbrC, myEventsA);
            Meet overBoysAbbrMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, overBoysAbbr, girlsAbbrA, myEventsA);
            Meet overGirlsAbbrMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, overGirlsAbbr, myEventsA);
            Meet invalidBoysName = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesD, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsA);
            Meet invalidGirlsName = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesD, boysAbbrA, girlsAbbrA, myEventsA);
            Meet invalidBoysAbbr = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrD, girlsAbbrA, myEventsA);
            Meet invalidGirlsAbbr = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrD, myEventsA);
            Meet invalidPerformance = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsB);
            Meet invalidEventName = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", boysNamesA, girlsNamesA, boysAbbrA, girlsAbbrA, myEventsC);
            
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
            else if (dupBoysAbbrMeet.validate())
            {
                test = false;
                Console.WriteLine("dupBoysAbbrMeet was valid");
            }
            else if (dupGirlsAbbrMeet.validate())
            {
                test = false;
                Console.WriteLine("dupGirlsAbbrMeet was valid");
            }
            else if (mismatchBoysNames.validate())
            {
                test = false;
                Console.WriteLine("mismatchBoysNames was valid");
            }
            else if (mismatchGirlsNames.validate())
            {
                test = false;
                Console.WriteLine("mismatchGirlsNames was valid");
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
            else if (invalidBoysAbbr.validate())
            {
                test = false;
                Console.WriteLine("invalidBoysAbbr was valid");
            }
            else if (invalidGirlsAbbr.validate())
            {
                test = false;
                Console.WriteLine("invalidGirlsAbbr was valid");
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