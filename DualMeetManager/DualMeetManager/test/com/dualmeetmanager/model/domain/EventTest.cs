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

        [TestCase]
        public void TestValidateMethod()
        {
            bool test = true;

            Performance validPerf1 = new Performance("George Washington", "Washington High", 17.76m);
            Performance validPerf2 = new Performance("Charlie Brown", "Peanuts U", 19.8m);
            Performance validPerf3 = new Performance("Sally Brown", "Peanuts U", 18.5m);
            Performance validPerf4 = new Performance("Superman", "Krypton", .01m);
            Performance invalidPerf = new Performance(null, "Washington High", 17.76m);

            List<Performance> valid = new List<Performance>();
            valid.Add(validPerf1);
            valid.Add(validPerf2);
            valid.Add(validPerf3);
            valid.Add(validPerf4);

            List<Performance> invalid = new List<Performance>();
            invalid.Add(validPerf1);
            invalid.Add(validPerf2);
            invalid.Add(validPerf3);
            invalid.Add(validPerf4);
            invalid.Add(invalidPerf);

            Event validBlankEvent = new Event("Boy's 100");
            Event validLoadedEvent = new Event("Boy's 100", valid);
            Event validNullEvents = new Event("Boy's 100", null);
            Event invalidName1 = new Event(null, valid);
            Event invalidName2 = new Event(null);
            Event invalidName3 = new Event("", valid);
            Event invalidName4 = new Event("");
            Event invalidPerfEvent = new Event("Boy's 100", invalid);

            if (!validBlankEvent.validate()) test = false;
            else if (!validLoadedEvent.validate()) test = false;
            else if (!validNullEvents.validate()) test = false;
            else if (invalidName1.validate()) test = false;
            else if (invalidName2.validate()) test = false;
            else if (invalidName3.validate()) test = false;
            else if (invalidName4.validate()) test = false;
            else if (invalidPerfEvent.validate()) test = false;

            Assert.True(test);
        }
    }
}
