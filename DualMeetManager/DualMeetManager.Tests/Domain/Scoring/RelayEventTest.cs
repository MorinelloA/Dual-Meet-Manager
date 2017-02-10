using DualMeetManager.Domain.Scoring;
using NUnit.Framework;
using System;

namespace DualMeetManager.Tests.Domain.Scoring
{
    /// <summary>
    /// Tests for the RelayEvent class
    /// </summary>
    [TestFixture]
    class RelayEventTest
    {
        /// <summary>
        /// Tests the Default Constructor
        /// </summary>
        [TestCase]
        public void TestDefaultConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            RelayEvent blankPerformance = new RelayEvent();
            Assert.AreEqual(blankPerformance != null, true, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        /// <summary>
        /// Tests the parameterized Constructor
        /// </summary>
        /// <remarks>Each attribute is tested individually for accuracy</remarks>
        [TestCase]
        public void TestParameterizedConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            bool test = true;

            RelayEvent myRelayEvent = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "A", "PLM", "11.3"), new EventPoints(0.0m, 0.0m, "A", "GWY", "11.4"), 5.0m, 0.0m);

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
            if(myRelayEvent.team1Total != 5.0m)
            {
                test = false;
                Console.WriteLine("team1Total does not have the correct value");
            }
            if (myRelayEvent.team2Total != 0.0m)
            {
                test = false;
                Console.WriteLine("team2Total does not have the correct value");
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

            RelayEvent controlRelayEvent = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), 8.0m, 1.0m);

            RelayEvent equalRelayEvent = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), 8.0m, 1.0m);
            RelayEvent diffTeam1 = new RelayEvent("WH", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), 8.0m, 1.0m);
            RelayEvent diffTeam2 = new RelayEvent("PLM", "WH", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), 8.0m, 1.0m);
            RelayEvent diffFirstPlacePts = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P4", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), 8.0m, 1.0m);
            RelayEvent diffSecondPlacePts = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.45"), 8.0m, 1.0m);
            RelayEvent diffTotalPts = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), 9.0m, 0.0m);
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

        /// <summary>
        /// Tests accuracy of the ToString method
        /// </summary>
        [TestCase]
        public void TestToStringMethod()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            RelayEvent myRelayEvent = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "A", "PLM", "11.3"), new EventPoints(0.0m, 0.0m, "A", "GWY", "11.4"), 5.0m, 0.0m);

            string strRelayEvent = myRelayEvent.ToString();

            Console.WriteLine("My string:" + Environment.NewLine + Environment.NewLine);
            Console.WriteLine(strRelayEvent + Environment.NewLine);

            Console.WriteLine("Expecting:" + Environment.NewLine + Environment.NewLine);
            Console.WriteLine("First Place: A - PLM: 11.3" + Environment.NewLine +
                "First Place Pts: PLM: 5 GWY: 0" + Environment.NewLine +
                "Second Place: A - GWY: 11.4" + Environment.NewLine +
                "Second Place Pts: PLM: 0 GWY: 0" + Environment.NewLine +
                "Total: PLM: 5 GWY: 0");

            Assert.AreEqual(strRelayEvent, "First Place: A - PLM: 11.3" + Environment.NewLine +
                "First Place Pts: PLM: 5 GWY: 0" + Environment.NewLine +
                "Second Place: A - GWY: 11.4" + Environment.NewLine +
                "Second Place Pts: PLM: 0 GWY: 0" + Environment.NewLine +
                "Total: PLM: 5 GWY: 0",
                GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");

            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        /// <summary>
        /// Tests accuracy of the validate method
        /// </summary>
        /// <remarks>Each possibility of an invalid RelayEvent is tested</remarks>
        [TestCase]
        public void TestValidateMethod()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            bool test = true;
            RelayEvent control = new RelayEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(0.0m, 0.0m, "Athlete2", "TM1", "11.4"), 5.0m, 0.0m);

            RelayEvent team1PtsDontMatch = new RelayEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(0.0m, 0.0m, "Athlete2", "TM1", "11.4"), 4.0m, 0.0m);
            RelayEvent team2PtsDontMatch = new RelayEvent("TM1", "TM2", new EventPoints(4.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(0.0m, 0.0m, "Athlete2", "TM1", "11.4"), 4.0m, 1.0m);
            RelayEvent totalAbove5 = new RelayEvent("TM1", "TM2", new EventPoints(5.0m, 1.0m, "Athlete1", "TM1", "11.3"), new EventPoints(0.0m, 0.0m, "Athlete2", "TM1", "11.4"), 5.0m, 1.0m);
            RelayEvent noNameTeam1 = new RelayEvent("", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(0.0m, 0.0m, "Athlete2", "TM1", "11.4"), 5.0m, 0.0m);
            RelayEvent noNameTeam2 = new RelayEvent("TM1", "", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(0.0m, 0.0m, "Athlete2", "TM1", "11.4"), 5.0m, 0.0m);
            RelayEvent nullNameTeam1 = new RelayEvent("TM1", "TM2", new EventPoints(0.0m, 0.0m, "", "TM1", "11.3"), new EventPoints(0.0m, 0.0m, "Athlete2", "TM1", "11.4"), 0.0m, 0.0m);
            RelayEvent nullNameTeam2 = new RelayEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(0.0m, 0.0m, "", "TM1", "11.4"), 5.0m, 0.0m);
            RelayEvent noNameWithPtsTeam1 = new RelayEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "", "", "11.3"), new EventPoints(0.0m, 0.0m, "Athlete2", "TM1", "11.4"), 5.0m, 0.0m);
            RelayEvent nameWithNoPtsTeam1 = new RelayEvent("TM1", "TM2", new EventPoints(0.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(0.0m, 0.0m, "Athlete2", "TM1", "11.4"), 0.0m, 0.0m);
            RelayEvent secondPlaceHasPts = new RelayEvent("TM1", "TM2", new EventPoints(4.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(0.0m, 1.0m, "Athlete2", "TM1", "11.4"), 4.0m, 1.0m);

            if (!control.validate())
            {
                test = false;
                Console.WriteLine("control was invalid");
            }
            if (team1PtsDontMatch.validate())
            {
                test = false;
                Console.WriteLine("team1PtsDontMatch was valid");
            }
            if (team2PtsDontMatch.validate())
            {
                test = false;
                Console.WriteLine("team2PtsDontMatch was valid");
            }
            if (totalAbove5.validate())
            {
                test = false;
                Console.WriteLine("totalAbove5 was valid");
            }
            if (noNameTeam1.validate())
            {
                test = false;
                Console.WriteLine("noNameTeam1 was valid");
            }
            if (noNameTeam2.validate())
            {
                test = false;
                Console.WriteLine("noNameTeam2 was valid");
            }
            if (nullNameTeam1.validate())
            {
                test = false;
                Console.WriteLine("nullNameTeam1 was valid");
            }
            if (nullNameTeam2.validate())
            {
                test = false;
                Console.WriteLine("nullNameTeam2 was valid");
            }
            if (noNameWithPtsTeam1.validate())
            {
                test = false;
                Console.WriteLine("noNameWithPtsTeam1 was valid");
            }
            if (nameWithNoPtsTeam1.validate())
            {
                test = false;
                Console.WriteLine("nameWithNoPtsTeam1 was valid");
            }
            if (secondPlaceHasPts.validate())
            {
                test = false;
                Console.WriteLine("secondPlaceHasPts was valid");
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
    }
}