using DualMeetManager.Domain.Scoring;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DualMeetManager.Tests.Domain.Scoring
{
    /// <summary>
    /// Tests for the OverallScore class
    /// </summary>
    [TestFixture]
    class OverallScoreTest
    {
        /// <summary>
        /// Tests the default Constructor
        /// </summary>
        [TestCase]
        public void TestDefaultConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            IndEvent blankEvent = new IndEvent();
            Assert.AreEqual(blankEvent != null, true, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        /// <summary>
        /// Tests parameterized constructor
        /// </summary>
        /// <remarks>Each attribute is tested individually for accuracy</remarks>
        public void TestParameterizedConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            bool test = true;

            IndEvent indEvent1 = new IndEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), 8.0m, 1.0m);
            IndEvent indEvent2 = new IndEvent("PLM", "GWY", new EventPoints(0.0m, 5.0m, "P5", "PLM", "11.2"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), 3.0m, 6.0m);
            Dictionary<string, IndEvent> indEvents = new Dictionary<string, IndEvent>();
            indEvents.Add("Boy's 100", indEvent1);
            indEvents.Add("Boy's 200", indEvent2);

            RelayEvent relayEvent1 = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "A", "PLM", "11.3"), new EventPoints(0.0m, 0.0m, "A", "GWY", "11.4"), 5.0m, 0.0m);
            RelayEvent relayEvent2 = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "A", "PLM", "400"), new EventPoints(0.0m, 0.0m, "A", "GWY", "500"), 5.0m, 0.0m);
            Dictionary<string, RelayEvent> relayEvents = new Dictionary<string, RelayEvent>();
            relayEvents.Add("Boy's 4x100", relayEvent1);
            relayEvents.Add("Boy's 4x400", relayEvent2);

            OverallScore myOverallScore = new OverallScore(Tuple.Create("PLM", "Plum"), Tuple.Create("GWY", "Gateway"), indEvents, relayEvents);

            if (myOverallScore == null)
            {
                test = false;
                Console.WriteLine("myOverallScore is null");
            }
            if (!myOverallScore.team1.Equals(Tuple.Create("PLM", "Plum", 10.0m)))
            {
                test = false;
                Console.WriteLine("team1 does not have the correct value");
            }
            if (!myOverallScore.team2.Equals(Tuple.Create("GWY", "Gateway", 6.0m)))
            {
                test = false;
                Console.WriteLine("team2 does not have the correct value");
            }
            if (!myOverallScore.indEvents.OrderBy(r => r.Key).SequenceEqual(indEvents.OrderBy(r => r.Key)))
            {
                test = false;
                Console.WriteLine("indEvents does not have the correct value");
            }
            if (!myOverallScore.relayEvents.OrderBy(r => r.Key).SequenceEqual(relayEvents.OrderBy(r => r.Key)))
            {
                test = false;
                Console.WriteLine("relayEvents does not have the correct value");
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        /// <summary>
        /// Tests the Equals method
        /// </summary>
        /// <remarks>Each attribute is tested individually for accuracy</remarks>
        [TestCase]
        public void TestEqualsMethod()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            bool test = true;

            IndEvent indEvent1 = new IndEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), 8.0m, 1.0m);
            IndEvent indEvent2 = new IndEvent("PLM", "GWY", new EventPoints(0.0m, 5.0m, "P5", "PLM", "11.2"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), 3.0m, 6.0m);
            IndEvent indEvent3 = new IndEvent("PLM", "GWY", new EventPoints(0.0m, 5.0m, "P7", "PLM", "11.2"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), 3.0m, 6.0m);

            Dictionary<string, IndEvent> indEventsA = new Dictionary<string, IndEvent>();
            indEventsA.Add("Boy's 100", indEvent1);
            indEventsA.Add("Boy's 200", indEvent2);

            Dictionary<string, IndEvent> indEventsB = new Dictionary<string, IndEvent>();
            indEventsB.Add("Boy's 100", indEvent1);
            indEventsB.Add("Boy's 200", indEvent3);

            RelayEvent relayEvent1 = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "A", "PLM", "11.3"), new EventPoints(0.0m, 0.0m, "A", "GWY", "11.4"), 5.0m, 0.0m);
            RelayEvent relayEvent2 = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "A", "PLM", "400"), new EventPoints(0.0m, 0.0m, "A", "GWY", "500"), 5.0m, 0.0m);
            RelayEvent relayEvent3 = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "A", "PLM", "450"), new EventPoints(0.0m, 0.0m, "A", "GWY", "500"), 5.0m, 0.0m);

            Dictionary<string, RelayEvent> relayEventsA = new Dictionary<string, RelayEvent>();
            relayEventsA.Add("Boy's 4x100", relayEvent1);
            relayEventsA.Add("Boy's 4x400", relayEvent2);

            Dictionary<string, RelayEvent> relayEventsB = new Dictionary<string, RelayEvent>();
            relayEventsB.Add("Boy's 4x100", relayEvent1);
            relayEventsB.Add("Boy's 4x400", relayEvent3);

            OverallScore control = new OverallScore(Tuple.Create("PLM", "Plum"), Tuple.Create("GWY", "Gateway"), indEventsA, relayEventsA);

            OverallScore equal = new OverallScore(Tuple.Create("PLM", "Plum"), Tuple.Create("GWY", "Gateway"), indEventsA, relayEventsA);
            OverallScore diffTeam1 = new OverallScore(Tuple.Create("PLU", "Plum"), Tuple.Create("GWY", "Gateway"), indEventsA, relayEventsA);
            OverallScore diffTeam2 = new OverallScore(Tuple.Create("PLM", "Plum"), Tuple.Create("GWY", "Gate HS"), indEventsA, relayEventsA);
            OverallScore diffIndEvents = new OverallScore(Tuple.Create("PLM", "Plum"), Tuple.Create("GWY", "Gateway"), indEventsB, relayEventsA);
            OverallScore diffRelayEvents = new OverallScore(Tuple.Create("PLM", "Plum"), Tuple.Create("GWY", "Gateway"), indEventsA, relayEventsB);

            if (!control.Equals(equal))
            {
                test = false;
                Console.WriteLine("equal was not equal to control");
            }
            if (control.Equals(diffTeam1))
            {
                test = false;
                Console.WriteLine("diffTeam1 was equal to control");
            }
            if (control.Equals(diffTeam2))
            {
                test = false;
                Console.WriteLine("diffTeam2 was equal to control");
            }
            if (control.Equals(diffIndEvents))
            {
                test = false;
                Console.WriteLine("diffIndEvents was equal to control");
            }
            if (control.Equals(diffRelayEvents))
            {
                test = false;
                Console.WriteLine("diffRelayEvents was equal to control");
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        /// <summary>
        /// Tests accuracy of the ToString method
        /// </summary>
        [TestCase]
        public void TestToStringMethod()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            IndEvent indEvent1 = new IndEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), 8.0m, 1.0m);
            IndEvent indEvent2 = new IndEvent("PLM", "GWY", new EventPoints(0.0m, 5.0m, "P5", "PLM", "11.2"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), 3.0m, 6.0m);

            Dictionary<string, IndEvent> indEventsA = new Dictionary<string, IndEvent>();
            indEventsA.Add("Boy's 100", indEvent1);
            indEventsA.Add("Boy's 200", indEvent2);

            RelayEvent relayEvent1 = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "A", "PLM", "11.3"), new EventPoints(0.0m, 0.0m, "A", "GWY", "11.4"), 5.0m, 0.0m);
            RelayEvent relayEvent2 = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "A", "PLM", "400"), new EventPoints(0.0m, 0.0m, "A", "GWY", "500"), 5.0m, 0.0m);
            
            Dictionary<string, RelayEvent> relayEventsA = new Dictionary<string, RelayEvent>();
            relayEventsA.Add("Boy's 4x100", relayEvent1);
            relayEventsA.Add("Boy's 4x400", relayEvent2);

            OverallScore myOverallScore = new OverallScore(Tuple.Create("PLM", "Plum"), Tuple.Create("GWY", "Gateway"), indEventsA, relayEventsA, 10.0m, 6.0m);

            string strOverallScore = myOverallScore.ToString();

            Console.WriteLine("My string:" + Environment.NewLine + Environment.NewLine);
            Console.WriteLine(strOverallScore + Environment.NewLine);

            Console.WriteLine("Expecting:" + Environment.NewLine + Environment.NewLine);
            Console.WriteLine("Plum - PLM: 10.0" + Environment.NewLine +
                "Gateway - GWY: 6.0" + Environment.NewLine + Environment.NewLine +
                "Boy's 100" + Environment.NewLine +
                "First Place: P1 - PLM: 11.3" + Environment.NewLine +
                "First Place Pts: PLM: 5 GWY: 0" + Environment.NewLine +
                "Second Place: P2 - PLM: 11.4" + Environment.NewLine +
                "Second Place Pts: PLM: 3 GWY: 0" + Environment.NewLine +
                "Third Place: G1 - GWY: 11.5" + Environment.NewLine +
                "Third Place Pts: PLM: 0 GWY: 1" + Environment.NewLine +
                "Total: PLM: 8 GWY: 1" + Environment.NewLine +
                "Boy's 200" + Environment.NewLine +
                "First Place: P5 - PLM: 11.2" + Environment.NewLine +
                "First Place Pts: PLM: 0 GWY: 5" + Environment.NewLine +
                "Second Place: P2 - PLM: 11.4" + Environment.NewLine +
                "Second Place Pts: PLM: 3 GWY: 0" + Environment.NewLine +
                "Third Place: G1 - GWY: 11.5" + Environment.NewLine +
                "Third Place Pts: PLM: 0 GWY: 1" + Environment.NewLine +
                "Total: PLM: 3 GWY: 6" + Environment.NewLine +
                "Boy's 4x100" + Environment.NewLine +
                "First Place: A - PLM: 11.3" + Environment.NewLine +
                "First Place Pts: PLM: 5 GWY: 0" + Environment.NewLine +
                "Second Place: A - GWY: 11.4" + Environment.NewLine +
                "Second Place Pts: PLM: 0 GWY: 0" + Environment.NewLine +
                "Total: PLM: 5 GWY: 0" + Environment.NewLine +
                "Boy's 4x400" + Environment.NewLine +
                "First Place: A - PLM: 400" + Environment.NewLine +
                "First Place Pts: PLM: 5 GWY: 0" + Environment.NewLine +
                "Second Place: A - GWY: 500" + Environment.NewLine +
                "Second Place Pts: PLM: 0 GWY: 0" + Environment.NewLine +
                "Total: PLM: 5 GWY: 0" + Environment.NewLine);

            Assert.AreEqual(strOverallScore, "Plum - PLM: 10.0" + Environment.NewLine +
                "Gateway - GWY: 6.0" + Environment.NewLine + Environment.NewLine +
                "Boy's 100" + Environment.NewLine +
                "First Place: P1 - PLM: 11.3" + Environment.NewLine +
                "First Place Pts: PLM: 5 GWY: 0" + Environment.NewLine +
                "Second Place: P2 - PLM: 11.4" + Environment.NewLine +
                "Second Place Pts: PLM: 3 GWY: 0" + Environment.NewLine +
                "Third Place: G1 - GWY: 11.5" + Environment.NewLine +
                "Third Place Pts: PLM: 0 GWY: 1" + Environment.NewLine +
                "Total: PLM: 8 GWY: 1" + Environment.NewLine +
                "Boy's 200" + Environment.NewLine +
                "First Place: P5 - PLM: 11.2" + Environment.NewLine +
                "First Place Pts: PLM: 0 GWY: 5" + Environment.NewLine +
                "Second Place: P2 - PLM: 11.4" + Environment.NewLine +
                "Second Place Pts: PLM: 3 GWY: 0" + Environment.NewLine +
                "Third Place: G1 - GWY: 11.5" + Environment.NewLine +
                "Third Place Pts: PLM: 0 GWY: 1" + Environment.NewLine +
                "Total: PLM: 3 GWY: 6" + Environment.NewLine +
                "Boy's 4x100" + Environment.NewLine +
                "First Place: A - PLM: 11.3" + Environment.NewLine +
                "First Place Pts: PLM: 5 GWY: 0" + Environment.NewLine +
                "Second Place: A - GWY: 11.4" + Environment.NewLine +
                "Second Place Pts: PLM: 0 GWY: 0" + Environment.NewLine +
                "Total: PLM: 5 GWY: 0" + Environment.NewLine +
                "Boy's 4x400" + Environment.NewLine +
                "First Place: A - PLM: 400" + Environment.NewLine +
                "First Place Pts: PLM: 5 GWY: 0" + Environment.NewLine +
                "Second Place: A - GWY: 500" + Environment.NewLine +
                "Second Place Pts: PLM: 0 GWY: 0" + Environment.NewLine +
                "Total: PLM: 5 GWY: 0" + Environment.NewLine,
                GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");

            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
    }
}
