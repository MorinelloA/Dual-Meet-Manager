using static DualMeetManager.Service.DataEntry.DataEntrySvcStaticImpl;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DualMeetManager.Domain;
using DualMeetManager.Service.DataEntry;

namespace DualMeetManager.Tests.Service.DataEntry
{
    [TestFixture]
    public class DataEntrySvcStaticImplTest
    {
        [Test]
        public void TestStaticConvertToTimedData()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            bool test = true;

            if (ConvertToTimedData(59.1m) != "59.1")
            {
                Console.WriteLine("59.1m was not correct");
                test = false;
            }
            if (ConvertToTimedData(59.1111m) != "59.111")
            {
                Console.WriteLine("59.1111m was not correct");
                test = false;
            }
            if (ConvertToTimedData(59.99m) != "59.99")
            {
                Console.WriteLine("59.99m was not correct");
                test = false;
            }
            if (ConvertToTimedData(60.0m) != "1:00")
            {
                Console.WriteLine("60.0m was not correct, returned " + ConvertToTimedData(60.0m));
                test = false;
            }
            if (ConvertToTimedData(61.0m) != "1:01")
            {
                Console.WriteLine("61.0m was not correct, returned " + ConvertToTimedData(61.0m));
                test = false;
            }
            if (ConvertToTimedData(120.1m) != "2:00.1")
            {
                Console.WriteLine("120.1m was not correct");
                test = false;
            }
            if (ConvertToTimedData(70.01m) != "1:10.01")
            {
                Console.WriteLine("70.01mm was not correct");
                test = false;
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestStaticConvertFromTimedData()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            bool test = true;

            if (ConvertFromTimedData("1:01") != 61m)
            {
                Console.WriteLine("1:01 was not correct, returned " + ConvertFromTimedData("1:01"));
                test = false;
            }
            if (ConvertFromTimedData("1:10") != 70m)
            {
                Console.WriteLine("1:10 was not correct, returned " + ConvertFromTimedData("1:10"));
                test = false;
            }
            if (ConvertFromTimedData("59") != 59m)
            {
                Console.WriteLine("59 was not correct, returned " + ConvertFromTimedData("59"));
                test = false;
            }
            if (ConvertFromTimedData("59.99") != 59.99m)
            {
                Console.WriteLine("59.99 was not correct, returned " + ConvertFromTimedData("59.99"));
                test = false;
            }
            if (ConvertFromTimedData("2:22.222") != 142.222m)
            {
                Console.WriteLine("2:22.222 was not correct, returned " + ConvertFromTimedData("2:22.222"));
                test = false;
            }
            if (ConvertFromTimedData("1:01.01") != 61.01m)
            {
                Console.WriteLine("1:01.01 was not correct, returned " + ConvertFromTimedData("1:01.01"));
                test = false;
            }
            if (ConvertFromTimedData("1:01.001") != 61.001m)
            {
                Console.WriteLine("1:01.001 was not correct, returned " + ConvertFromTimedData("1:01.001"));
                test = false;
            }
            if (ConvertFromTimedData("1:00") != 60m)
            {
                Console.WriteLine("1:00 was not correct, returned " + ConvertFromTimedData("1:00"));
                test = false;
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestStaticConvertToLengthData()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            bool test = true;

            if (ConvertToLengthData(13m) != "1-01")
            {
                Console.WriteLine("13m was not correct, returned " + ConvertToLengthData(13m));
                test = false;
            }
            if (ConvertToLengthData(11m) != "11")
            {
                Console.WriteLine("11m was not correct, returned " + ConvertToLengthData(11m));
                test = false;
            }
            if (ConvertToLengthData(35m) != "2-11")
            {
                Console.WriteLine("35m was not correct, returned " + ConvertToLengthData(35m));
                test = false;
            }
            if (ConvertToLengthData(36.1m) != "3-00.1")
            {
                Console.WriteLine("36.1m was not correct, returned " + ConvertToLengthData(36.1m));
                test = false;
            }
            if (ConvertToLengthData(46m) != "3-10")
            {
                Console.WriteLine("46m was not correct, returned " + ConvertToLengthData(46m));
                test = false;
            }
            if (ConvertToLengthData(36.001m) != "3-00.001")
            {
                Console.WriteLine("36.001m was not correct, returned " + ConvertToLengthData(36.001m));
                test = false;
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestStaticConvertFromLengthData()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            bool test = true;

            if (ConvertFromLengthData("1-01") != 13m)
            {
                Console.WriteLine("1-01 was not correct, returned " + ConvertFromLengthData("1-10"));
                test = false;
            }
            if (ConvertFromLengthData("11") != 11m)
            {
                Console.WriteLine("11 was not correct, returned " + ConvertFromLengthData("11"));
                test = false;
            }
            if (ConvertFromLengthData("2-11") != 35m)
            {
                Console.WriteLine("2-11 was not correct, returned " + ConvertFromLengthData("2-11"));
                test = false;
            }
            if (ConvertFromLengthData("3-00.1") != 36.1m)
            {
                Console.WriteLine("3-00.1 was not correct, returned " + ConvertFromLengthData("3-00.1"));
                test = false;
            }
            if (ConvertFromLengthData("3-10") != 46m)
            {
                Console.WriteLine("3-10 was not correct, returned " + ConvertFromLengthData("3-10"));
                test = false;
            }
            if (ConvertFromLengthData("3-00.001") != 36.001m)
            {
                Console.WriteLine("3-00.001 was not correct, returned " + ConvertFromLengthData("3-00.001"));
                test = false;
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestStaticAddIndividualPerformance()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            Dictionary<string, string> boysNames = new Dictionary<string, string>();
            boysNames.Add("BLN", "Baldwin");
            boysNames.Add("TJ", "Thomas Jefferson");
            boysNames.Add("WHS", "Washington HS");

            Dictionary<string, string> girlsNames = new Dictionary<string, string>();
            girlsNames.Add("PLM", "Plum");
            girlsNames.Add("GWY", "Gateway");
            girlsNames.Add("KCH", "Knoch");

            Teams teams = new Teams(boysNames, girlsNames);

            Performance myPerformance1 = new Performance("A", "AA", 1.1m);
            Performance myPerformance2 = new Performance("B", "BB", 2.2m);
            Performance myPerformance3 = new Performance("C", "CC", 3.3m);
            Performance myPerformance4 = new Performance("D", "AA", 4.1m);
            Performance myPerformance5 = new Performance("E", "BB", 5.2m);
            Performance myPerformance6 = new Performance("F", "CC", 6.3m);
            Performance myPerformance7 = new Performance("G", "DD", 4.4m);

            List<Performance> myPerformancesA = new List<Performance>();
            myPerformancesA.Add(myPerformance1);
            myPerformancesA.Add(myPerformance2);
            myPerformancesA.Add(myPerformance3);

            List<Performance> myPerformancesB = new List<Performance>();
            myPerformancesB.Add(myPerformance4);
            myPerformancesB.Add(myPerformance5);
            myPerformancesB.Add(myPerformance6);

            List<Performance> myPerformancesC = new List<Performance>();
            myPerformancesC.Add(myPerformance4);
            myPerformancesC.Add(myPerformance5);
            myPerformancesC.Add(myPerformance6);
            myPerformancesC.Add(myPerformance7);

            Dictionary<string, List<Performance>> originalList = new Dictionary<string, List<Performance>>();
            originalList.Add("Boy's 100", myPerformancesA);
            originalList.Add("Boy's 200", myPerformancesB);

            Dictionary<string, List<Performance>> newComparableList = new Dictionary<string, List<Performance>>();
            newComparableList.Add("Boy's 100", myPerformancesA);
            newComparableList.Add("Boy's 200", myPerformancesC);

            Meet meet1 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams, originalList);
            Meet meet2 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams, newComparableList);

            meet1.performances = meet1.performances.AddPerformanceToEvent("Boy's 200", myPerformance7);

            //if (!myTeams.boySchoolNames.OrderBy(r => r.Key).SequenceEqual(boys.OrderBy(r => r.Key)))
            Console.WriteLine("originalList:");
            foreach (KeyValuePair<string, List<Performance>> kvp in originalList)
            {
                foreach (Performance i in kvp.Value)
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, i.ToString());
            }
            Console.WriteLine("\nnewComparableList:");
            foreach (KeyValuePair<string, List<Performance>> kvp in newComparableList)
            {
                foreach (Performance i in kvp.Value)
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, i.ToString());
            }


            bool test = meet1.Equals(meet2);

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestStaticAddNewIndividualPerformance()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            Dictionary<string, string> boysNames = new Dictionary<string, string>();
            boysNames.Add("BLN", "Baldwin");
            boysNames.Add("TJ", "Thomas Jefferson");
            boysNames.Add("WHS", "Washington HS");

            Dictionary<string, string> girlsNames = new Dictionary<string, string>();
            girlsNames.Add("PLM", "Plum");
            girlsNames.Add("GWY", "Gateway");
            girlsNames.Add("KCH", "Knoch");

            Teams teams = new Teams(boysNames, girlsNames);

            Performance myPerformance1 = new Performance("A", "AA", 1.1m);
            Performance myPerformance2 = new Performance("B", "BB", 2.2m);
            Performance myPerformance3 = new Performance("C", "CC", 3.3m);
            Performance myPerformance4 = new Performance("D", "AA", 4.1m);
            Performance myPerformance5 = new Performance("E", "BB", 5.2m);
            Performance myPerformance6 = new Performance("F", "CC", 6.3m);
            Performance myPerformance7 = new Performance("G", "DD", 4.4m);

            List<Performance> myPerformancesA = new List<Performance>();
            myPerformancesA.Add(myPerformance1);
            myPerformancesA.Add(myPerformance2);
            myPerformancesA.Add(myPerformance3);

            List<Performance> myPerformancesB = new List<Performance>();
            myPerformancesB.Add(myPerformance4);
            myPerformancesB.Add(myPerformance5);
            myPerformancesB.Add(myPerformance6);

            List<Performance> myPerformancesC = new List<Performance>();
            myPerformancesC.Add(myPerformance7);

            Dictionary<string, List<Performance>> originalList = new Dictionary<string, List<Performance>>();
            originalList.Add("Boy's 100", myPerformancesA);
            originalList.Add("Boy's 200", myPerformancesB);

            Dictionary<string, List<Performance>> newComparableList = new Dictionary<string, List<Performance>>();
            newComparableList.Add("Boy's 100", myPerformancesA);
            newComparableList.Add("Boy's 200", myPerformancesB);
            newComparableList.Add("Boy's 400", myPerformancesC);

            Meet meet1 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams, originalList);
            Meet meet2 = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams, newComparableList);

            DataEntrySvcImpl DESI = new DataEntrySvcImpl();

            meet1.performances = meet1.performances.AddPerformanceToEvent("Boy's 400", myPerformance7);

            Console.WriteLine("originalList:");
            foreach (KeyValuePair<string, List<Performance>> kvp in originalList)
            {
                foreach (Performance i in kvp.Value)
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, i.ToString());
            }
            Console.WriteLine("\nnewComparableList:");
            foreach (KeyValuePair<string, List<Performance>> kvp in newComparableList)
            {
                foreach (Performance i in kvp.Value)
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, i.ToString());
            }


            bool test = meet1.Equals(meet2);

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
    }
}
