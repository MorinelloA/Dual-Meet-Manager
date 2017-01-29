using DualMeetManager.Domain.Scoring;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Tests.Domain.Scoring
{
    /// <summary>
    /// Tests for the RelayEvent class
    /// </summary>
    [TestFixture]
    class RelayEventTest
    {
        [TestCase]
        public void TestDefaultConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            RelayEvent blankPerformance = new RelayEvent();
            Assert.AreEqual(blankPerformance != null, true, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestParameterizedConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            bool test = true;

            //public RelayEvent(string team1, string team2, EventPoints firstPlacePts, EventPoints secondPlacePts, Tuple<decimal, decimal> totalPts)
            RelayEvent myRelayEvent = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "A", "PLM", "11.3"), new EventPoints(0.0m, 0.0m, "A", "GWY", "11.4"), Tuple.Create(5.0m, 0.0m));

            if (myRelayEvent == null)
            {
                test = false;
                Console.WriteLine("myRelayEvent is null");
            }
            if (myRelayEvent.team1 != "PLM")
            {
                test = false;
                Console.WriteLine("team1 does not have the correct value");
            }
            if (myRelayEvent.team2 != "GWY")
            {
                test = false;
                Console.WriteLine("team2 does not have the correct value");
            }
            if (!myRelayEvent.points[0].Equals(new EventPoints(5.0m, 0.0m, "A", "PLM", "11.3")))
            {
                test = false;
                Console.WriteLine("firstPlacePts does not have the correct value");
            }
            if (!myRelayEvent.points[1].Equals(new EventPoints(0.0m, 0.0m, "A", "GWY", "11.4")))
            {
                test = false;
                Console.WriteLine("secondPlacePts does not have the correct value");
            }
            if (!myRelayEvent.totalPts.Equals(Tuple.Create(5.0m, 0.0m)))
            {
                test = false;
                Console.WriteLine("totalPts does not have the correct value");
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed"); 
        }

        [TestCase]
        public void TestEqualsMethod()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            bool test = true;

            RelayEvent controlRelayEvent = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), Tuple.Create(8.0m, 1.0m));

            RelayEvent equalRelayEvent = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), Tuple.Create(8.0m, 1.0m));
            RelayEvent diffTeam1 = new RelayEvent("WH", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), Tuple.Create(8.0m, 1.0m));
            RelayEvent diffTeam2 = new RelayEvent("PLM", "WH", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), Tuple.Create(8.0m, 1.0m));
            RelayEvent diffFirstPlacePts = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P4", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), Tuple.Create(8.0m, 1.0m));
            RelayEvent diffSecondPlacePts = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.45"), Tuple.Create(8.0m, 1.0m));
            RelayEvent diffTotalPts = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), Tuple.Create(9.0m, 0.0m));
            RelayEvent nullRelayEvent = new RelayEvent();

            if (!controlRelayEvent.Equals(equalRelayEvent))
            {
                test = false;
                Console.WriteLine("equalRelayEvent was not equal to controlRelayEvent");
            }
            if (controlRelayEvent.Equals(diffTeam1))
            {
                test = false;
                Console.WriteLine("diffTeam1 was equal to controlRelayEvent");
            }
            if (controlRelayEvent.Equals(diffTeam2))
            {
                test = false;
                Console.WriteLine("diffTeam2 was equal to controlRelayEvent");
            }
            if (controlRelayEvent.Equals(diffFirstPlacePts))
            {
                test = false;
                Console.WriteLine("diffFirstPlacePts was equal to controlRelayEvent");
            }
            if (controlRelayEvent.Equals(diffSecondPlacePts))
            {
                test = false;
                Console.WriteLine("diffSecondPlacePts was equal to controlRelayEvent");
            }
            if (controlRelayEvent.Equals(diffTotalPts))
            {
                test = false;
                Console.WriteLine("diffTotalPts was equal to controlRelayEvent");
            }
            if (controlRelayEvent.Equals(nullRelayEvent))
            {
                test = false;
                Console.WriteLine("nullRelayEvent was equal to controlRelayEvent");
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestToStringMethod()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        [TestCase]
        public void TestValidateMethod()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
    }
}
