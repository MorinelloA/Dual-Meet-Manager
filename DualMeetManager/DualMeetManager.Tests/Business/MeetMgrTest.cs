using DualMeetManager.Business.Managers;
using DualMeetManager.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace DualMeetManager.Tests.Business
{
    [TestFixture]
    public class MeetMgrTest
    {
        const string testFileName = "MeetMgrTestFile.txt";
        Meet testMeet;

        [SetUp]
        public void setupMeetObject()
        {
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

            testMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams, myPerformances);
        }

        [OneTimeSetUp]
        public void deleteTestFileStart()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            if (File.Exists(testFileName))
            {
                Console.WriteLine(testFileName + " found, deleting now");
                File.Delete(testFileName);
            }
            else
            {
                Console.WriteLine(testFileName + " not found");
            }
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        [OneTimeTearDown]
        public void deleteTestFileEnd()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            if (File.Exists(testFileName))
            {
                Console.WriteLine(testFileName + " found, deleting now");
                File.Delete(testFileName);
            }
            else
            {
                Console.WriteLine(testFileName + " not found");
            }
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        [Test, Order(2)]
        public void TestOpenMeetMeetMgr()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            MeetMgr mMgr = new MeetMgr();
            Meet openedMeet = mMgr.openMeet(testFileName);
            Console.WriteLine("Opened Meet:");
            Console.WriteLine(openedMeet.ToString());
            Console.WriteLine("\nControl Meet:");
            Console.WriteLine(testMeet.ToString());
            bool test = openedMeet.Equals(testMeet);
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test, Order(1)]
        public void TestSaveMeetMeetMgr()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            MeetMgr mMgr = new MeetMgr();
            bool test = mMgr.saveMeet(testFileName, testMeet);

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestOpenInvalidFileMeetMgr()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            MeetMgr mMgr = new MeetMgr();
            Meet openedMeet = mMgr.openMeet("zyxw.1234");
            bool test = openedMeet == null;
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
    }
}
