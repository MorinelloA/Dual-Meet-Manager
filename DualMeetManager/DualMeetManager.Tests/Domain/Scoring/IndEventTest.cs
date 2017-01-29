using DualMeetManager.Domain.Scoring;
using NUnit.Framework;
using System;

namespace DualMeetManager.Tests.Domain.Scoring
{
    /// <summary>
    /// Tests for the IndEvent class
    /// </summary>
    [TestFixture]
    class IndEventTest
    {
        /// <summary>
        /// Tests the default constructor
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
        [TestCase]
        public void TestParameterizedConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            bool test = true;

            IndEvent myIndEvent = new IndEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));

            if (myIndEvent == null)
            {
                test = false;
                Console.WriteLine("myIndEvent is null");
            }
            if (myIndEvent.team1 != "PLM")
            {
                test = false;
                Console.WriteLine("team1 does not have the correct value");
            }
            if (myIndEvent.team2 != "GWY")
            {
                test = false;
                Console.WriteLine("team2 does not have the correct value");
            }
            if (!myIndEvent.points[0].Equals(new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3")))
            {
                test = false;
                Console.WriteLine("firstPlacePts does not have the correct value");
            }
            if (!myIndEvent.points[1].Equals(new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4")))
            {
                test = false;
                Console.WriteLine("secondPlacePts does not have the correct value");
            }
            if (!myIndEvent.points[2].Equals(new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5")))
            {
                test = false;
                Console.WriteLine("thirdPlacePts does not have the correct value");
            }
            if(!myIndEvent.totalPts.Equals(Tuple.Create(8.0m, 1.0m)))
            {
                test = false;
                Console.WriteLine("totalPts does not have the correct value");
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

            IndEvent controlIndEvent = new IndEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));

            IndEvent equalIndEvent = new IndEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent diffTeam1 = new IndEvent("WH", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent diffTeam2 = new IndEvent("PLM", "WH", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent diffFirstPlacePts = new IndEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P4", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent diffSecondPlacePts = new IndEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.45"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent diffThirdPlacePts = new IndEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.1m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent diffTotalPts = new IndEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(9.0m, 0.0m));
            IndEvent nullIndEvent = new IndEvent();

            if(!controlIndEvent.Equals(equalIndEvent))
            {
                test = false;
                Console.WriteLine("equalIndEvent was not equal to controlIndEvent");
            }
            if (controlIndEvent.Equals(diffTeam1))
            {
                test = false;
                Console.WriteLine("diffTeam1 was equal to controlIndEvent");
            }
            if (controlIndEvent.Equals(diffTeam2))
            {
                test = false;
                Console.WriteLine("diffTeam2 was equal to controlIndEvent");
            }
            if (controlIndEvent.Equals(diffFirstPlacePts))
            {
                test = false;
                Console.WriteLine("diffFirstPlacePts was equal to controlIndEvent");
            }
            if (controlIndEvent.Equals(diffSecondPlacePts))
            {
                test = false;
                Console.WriteLine("diffSecondPlacePts was equal to controlIndEvent");
            }
            if (controlIndEvent.Equals(diffThirdPlacePts))
            {
                test = false;
                Console.WriteLine("diffThirdPlacePts was equal to controlIndEvent");
            }
            if (controlIndEvent.Equals(diffTotalPts))
            {
                test = false;
                Console.WriteLine("diffTotalPts was equal to controlIndEvent");
            }
            if (controlIndEvent.Equals(nullIndEvent))
            {
                test = false;
                Console.WriteLine("nullIndEvent was equal to controlIndEvent");
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

            IndEvent myIndEvent = new IndEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));

            string strIndEvent = myIndEvent.ToString();

            Console.WriteLine("My string:" + Environment.NewLine + Environment.NewLine);
            Console.WriteLine(strIndEvent + Environment.NewLine);

            Console.WriteLine("Expecting:" + Environment.NewLine + Environment.NewLine);
            Console.WriteLine("First Place: P1 - PLM: 11.3" + Environment.NewLine +
                "First Place Pts: PLM: 5 GWY: 0" + Environment.NewLine +
                "Second Place: P2 - PLM: 11.4" + Environment.NewLine +
                "Second Place Pts: PLM: 3 GWY: 0" + Environment.NewLine +
                "Third Place: G1 - GWY: 11.5" + Environment.NewLine +
                "Third Place Pts: PLM: 0 GWY: 1" + Environment.NewLine +
                "Total: PLM: 8 GWY: 1");

            Assert.AreEqual(strIndEvent, "First Place: P1 - PLM: 11.3" + Environment.NewLine +
                "First Place Pts: PLM: 5 GWY: 0" + Environment.NewLine +
                "Second Place: P2 - PLM: 11.4" + Environment.NewLine +
                "Second Place Pts: PLM: 3 GWY: 0" + Environment.NewLine +
                "Third Place: G1 - GWY: 11.5" + Environment.NewLine +
                "Third Place Pts: PLM: 0 GWY: 1" + Environment.NewLine +
                "Total: PLM: 8 GWY: 1",
                GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");

            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        /// <summary>
        /// Tests accuracy of the validate method
        /// </summary>
        /// <remarks>Each possibility of an invalid IndEvent is tested</remarks>
        [TestCase]
        public void TestValidateMethod()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            bool test = true;
            IndEvent control = new IndEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(3.0m, 0.0m, "Athlete2", "TM1", "11.4"), new EventPoints(0.0m, 1.0m, "Athlete3", "TM2", "11.5"), Tuple.Create(8.0m, 1.0m));

            IndEvent team1PtsDontMatch = new IndEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(3.0m, 0.0m, "Athlete2", "TM1", "11.4"), new EventPoints(0.0m, 1.0m, "Athlete3", "TM2", "11.5"), Tuple.Create(7.0m, 1.0m));
            IndEvent team2PtsDontMatch = new IndEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(3.0m, 0.0m, "Athlete2", "TM1", "11.4"), new EventPoints(0.0m, 1.0m, "Athlete3", "TM2", "11.5"), Tuple.Create(8.0m, 0.0m));
            IndEvent totalAbove9 = new IndEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(3.0m, 0.0m, "Athlete2", "TM1", "11.4"), new EventPoints(0.0m, 3.0m, "Athlete3", "TM2", "11.5"), Tuple.Create(8.0m, 3.0m));
            IndEvent noNameTeam1 = new IndEvent("", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(3.0m, 0.0m, "Athlete2", "TM1", "11.4"), new EventPoints(0.0m, 1.0m, "Athlete3", "TM2", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent noNameTeam2 = new IndEvent("TM1", "", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(3.0m, 0.0m, "Athlete2", "TM1", "11.4"), new EventPoints(0.0m, 1.0m, "Athlete3", "TM2", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent nullNameTeam1 = new IndEvent("TM1", "TM2", new EventPoints(0.0m, 0.0m, "", "TM1", "11.3"), new EventPoints(3.0m, 0.0m, "Athlete2", "TM1", "11.4"), new EventPoints(0.0m, 1.0m, "Athlete3", "TM2", "11.5"), Tuple.Create(3.0m, 1.0m));
            IndEvent nullNameTeam2 = new IndEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(0.0m, 0.0m, "", "TM1", "11.4"), new EventPoints(0.0m, 1.0m, "Athlete3", "TM2", "11.5"), Tuple.Create(5.0m, 1.0m));
            IndEvent nullNameTeam3 = new IndEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(3.0m, 0.0m, "Athlete2", "TM1", "11.4"), new EventPoints(0.0m, 0.0m, "", "TM2", "11.5"), Tuple.Create(8.0m, 0.0m));
            IndEvent noNameWithPtsTeam1 = new IndEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "", "", "11.3"), new EventPoints(3.0m, 0.0m, "Athlete2", "TM1", "11.4"), new EventPoints(0.0m, 1.0m, "Athlete3", "TM2", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent noNameWithPtsTeam2 = new IndEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(3.0m, 0.0m, "", "", "11.4"), new EventPoints(0.0m, 1.0m, "Athlete3", "TM2", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent noNameWithPtsTeam3 = new IndEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(3.0m, 0.0m, "Athlete2", "TM1", "11.4"), new EventPoints(0.0m, 1.0m, "", "", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent nameWithNoPtsTeam1 = new IndEvent("TM1", "TM2", new EventPoints(0.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(3.0m, 0.0m, "Athlete2", "TM1", "11.4"), new EventPoints(0.0m, 1.0m, "Athlete3", "TM2", "11.5"), Tuple.Create(3.0m, 1.0m));
            IndEvent nameWithNoPtsTeam2 = new IndEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(0.0m, 0.0m, "Athlete2", "TM1", "11.4"), new EventPoints(0.0m, 1.0m, "Athlete3", "TM2", "11.5"), Tuple.Create(5.0m, 1.0m));
            IndEvent nameWithNoPtsTeam3 = new IndEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(3.0m, 0.0m, "Athlete2", "TM1", "11.4"), new EventPoints(0.0m, 0.0m, "Athlete3", "TM2", "11.5"), Tuple.Create(8.0m, 0.0m));

            if(!control.validate())
            {
                test = false;
                Console.WriteLine("control was invalid");
            }
            if(team1PtsDontMatch.validate())
            {
                test = false;
                Console.WriteLine("team1PtsDontMatch was valid");
            }
            if (team2PtsDontMatch.validate())
            {
                test = false;
                Console.WriteLine("team2PtsDontMatch was valid");
            }
            if (totalAbove9.validate())
            {
                test = false;
                Console.WriteLine("totalAbove9 was valid");
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
            if (nullNameTeam3.validate())
            {
                test = false;
                Console.WriteLine("nullNameTeam3 was valid");
            }
            if (noNameWithPtsTeam1.validate())
            {
                test = false;
                Console.WriteLine("noNameWithPtsTeam1 was valid");
            }
            if (noNameWithPtsTeam2.validate())
            {
                test = false;
                Console.WriteLine("noNameWithPtsTeam2 was valid");
            }
            if (noNameWithPtsTeam3.validate())
            {
                test = false;
                Console.WriteLine("noNameWithPtsTeam3 was valid");
            }
            if (nameWithNoPtsTeam1.validate())
            {
                test = false;
                Console.WriteLine("nameWithNoPtsTeam1 was valid");
            }
            if (nameWithNoPtsTeam2.validate())
            {
                test = false;
                Console.WriteLine("nameWithNoPtsTeam2 was valid");
            }
            if (nameWithNoPtsTeam3.validate())
            {
                test = false;
                Console.WriteLine("nameWithNoPtsTeam3 was valid");
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        /// <summary>
        /// Tests that both parameterized constructors will equal each other
        /// </summary>
        [TestCase]
        public void TestParameterizedConstructorsAreEqual()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            IndEvent indEvent1 = new IndEvent("TM1", "TM2", new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(3.0m, 0.0m, "Athlete2", "TM1", "11.4"), new EventPoints(0.0m, 1.0m, "Athlete3", "TM2", "11.5"), Tuple.Create(8.0m, 1.0m));
            Console.WriteLine(1);
            EventPoints[] eventPoints = { new EventPoints(5.0m, 0.0m, "Athlete1", "TM1", "11.3"), new EventPoints(3.0m, 0.0m, "Athlete2", "TM1", "11.4"), new EventPoints(0.0m, 1.0m, "Athlete3", "TM2", "11.5") };
            Console.WriteLine(2);
            IndEvent indEvent2 = new IndEvent("TM1", "TM2", eventPoints, Tuple.Create(8.0m, 1.0m));
            Console.WriteLine(3);
            Assert.AreEqual(indEvent1, indEvent2, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
    }
}