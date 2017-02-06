using DualMeetManager.Domain;
using DualMeetManager.Service.Saving;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Tests.Service.Saving
{
    [TestFixture]
    public class SavingImplTest
    {
        const string testFileName = "TESTFILETEST.txt";
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

        [OneTimeTearDown]
        public void deleteTestFile()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            /*if (File.Exists(testFileName))
            {
                Console.WriteLine(testFileName + " found, deleting now");
                File.Delete(testFileName);
            }
            else
            {
                Console.WriteLine(testFileName + " not found");
            }*/
            Console.WriteLine("Leaving " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        [Test]
        public void TestMeetSaves()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            SavingSvcImpl savingImplObject = new SavingSvcImpl();
            bool test = savingImplObject.saveMeet(testFileName, testMeet);

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestMeetOpens()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            SavingSvcImpl savingImplObject = new SavingSvcImpl();
            Meet openedMeet = savingImplObject.openMeet(testFileName);
            Console.WriteLine("Opened Meet:");
            Console.WriteLine(openedMeet.ToString());
            Console.WriteLine("\nControl Meet:");
            Console.WriteLine(testMeet.ToString());
            bool test = openedMeet.Equals(testMeet);
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
    }
}
