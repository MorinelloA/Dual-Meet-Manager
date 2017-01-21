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
    class EventTest
    {
        [TestCase]
        public void TestDefaultConstructor()
        {
            Event blankEvent = new Event();
            Assert.AreEqual(blankEvent != null, true);
        }

        [TestCase]
        public void TestParameterizedConstructor()
        {
            bool test = true;

            Performance myPerformance1 = new Performance("A", "AA", 1.1m);
            Performance myPerformance2 = new Performance("B", "BB", 2.2m);
            Performance myPerformance3 = new Performance("C", "CC", 3.3m);

            List<Performance> myPerformances = new List<Performance>();
            myPerformances.Add(myPerformance1);
            myPerformances.Add(myPerformance2);
            myPerformances.Add(myPerformance3);

            Event myEvent = new Event("EVENT NAME", myPerformances);

            if (myEvent.name != "EVENT NAME") test = false;
            else if (!myEvent.performances.SequenceEqual(myPerformances)) test = false;

            Assert.True(test);
        }

        [TestCase]
        public void TestEqualsMethod()
        {
            bool test = true;

            Performance myPerformance1 = new Performance("A", "AA", 1.1m);
            Performance myPerformance2 = new Performance("B", "BB", 2.2m);
            Performance myPerformance3 = new Performance("C", "CC", 3.3m);

            List<Performance> myPerformances = new List<Performance>();
            myPerformances.Add(myPerformance1);
            myPerformances.Add(myPerformance2);
            myPerformances.Add(myPerformance3);

            List<Performance> myPerformances2 = new List<Performance>();
            myPerformances2.Add(myPerformance2);
            myPerformances2.Add(myPerformance1);
            myPerformances2.Add(myPerformance3);

            Event myEvent1 = new Event("Boy's 100", myPerformances);
            Event myEvent2 = new Event("Boy's 100", myPerformances);
            Event myEvent3 = new Event("Girl's 100", myPerformances);
            Event myEvent4 = new Event("Boy's 100", myPerformances2);

            if (!myEvent1.Equals(myEvent2)) test = false;
            else if (myEvent1.Equals(myEvent3)) test = false;
            else if (myEvent1.Equals(myEvent4)) test = false;

            Assert.True(test);
        }

        [TestCase]
        public void TestToStringMethod()
        {
            Performance myPerformance1 = new Performance("A", "AA", 1.1m);
            Performance myPerformance2 = new Performance("B", "BB", 2.2m);
            Performance myPerformance3 = new Performance("C", "CC", 3.3m);

            List<Performance> myPerformances = new List<Performance>();
            myPerformances.Add(myPerformance1);
            myPerformances.Add(myPerformance2);
            myPerformances.Add(myPerformance3);

            Event myEvent = new Event("Boy's 100", myPerformances);

            string strEvent = myEvent.ToString();

            Assert.AreEqual(strEvent, "Event: Boy's 100" + Environment.NewLine + "Name: A, AA - 1.1" + Environment.NewLine + "Name: B, BB - 2.2" + Environment.NewLine + "Name: C, CC - 3.3");
        }
    }
}
