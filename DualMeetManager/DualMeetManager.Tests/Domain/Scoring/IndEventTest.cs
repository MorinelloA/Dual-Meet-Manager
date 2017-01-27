using DualMeetManager.Domain.Scoring;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Tests.Domain.Scoring
{
    [TestFixture]
    class IndEventTest
    {
        [TestCase]
        public void TestDefaultConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            IndEvent blankEvent = new IndEvent();
            Assert.AreEqual(blankEvent != null, true, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestParameterizedConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            bool test = true;

            IndEvent myIndEvent = new IndEvent("PLM", "GWY", Tuple.Create(5.0m, 0.0m, "P1", "PLM", "11.3"), Tuple.Create(3.0m, 0.0m, "P2", "PLM", "11.4"), Tuple.Create(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));

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
            if (!myIndEvent.firstPlacePts.Equals(Tuple.Create(5.0m, 0.0m, "P1", "PLM", "11.3")))
            {
                test = false;
                Console.WriteLine("firstPlacePts does not have the correct value");
            }
            if (!myIndEvent.secondPlacePts.Equals(Tuple.Create(3.0m, 0.0m, "P2", "PLM", "11.4")))
            {
                test = false;
                Console.WriteLine("secondPlacePts does not have the correct value");
            }
            if (!myIndEvent.thirdPlacePts.Equals(Tuple.Create(0.0m, 1.0m, "G1", "GWY", "11.5")))
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

        [TestCase]
        public void TestEqualsMethod()
        {
            bool test = true;

            IndEvent controlIndEvent = new IndEvent("PLM", "GWY", Tuple.Create(5.0m, 0.0m, "P1", "PLM", "11.3"), Tuple.Create(3.0m, 0.0m, "P2", "PLM", "11.4"), Tuple.Create(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));

            IndEvent equalIndEvent = new IndEvent("PLM", "GWY", Tuple.Create(5.0m, 0.0m, "P1", "PLM", "11.3"), Tuple.Create(3.0m, 0.0m, "P2", "PLM", "11.4"), Tuple.Create(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent diffTeam1 = new IndEvent("WH", "GWY", Tuple.Create(5.0m, 0.0m, "P1", "PLM", "11.3"), Tuple.Create(3.0m, 0.0m, "P2", "PLM", "11.4"), Tuple.Create(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent diffTeam2 = new IndEvent("PLM", "WH", Tuple.Create(5.0m, 0.0m, "P1", "PLM", "11.3"), Tuple.Create(3.0m, 0.0m, "P2", "PLM", "11.4"), Tuple.Create(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent diffFirstPlacePts = new IndEvent("PLM", "GWY", Tuple.Create(5.0m, 0.0m, "P4", "PLM", "11.3"), Tuple.Create(3.0m, 0.0m, "P2", "PLM", "11.4"), Tuple.Create(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent diffSecondPlacePts = new IndEvent("PLM", "GWY", Tuple.Create(5.0m, 0.0m, "P1", "PLM", "11.3"), Tuple.Create(3.0m, 0.0m, "P2", "PLM", "11.45"), Tuple.Create(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent diffThirdPlacePts = new IndEvent("PLM", "GWY", Tuple.Create(5.0m, 0.0m, "P1", "PLM", "11.3"), Tuple.Create(3.0m, 0.0m, "P2", "PLM", "11.4"), Tuple.Create(0.0m, 1.1m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent diffTotalPts = new IndEvent("PLM", "GWY", Tuple.Create(5.0m, 0.0m, "P1", "PLM", "11.3"), Tuple.Create(3.0m, 0.0m, "P2", "PLM", "11.4"), Tuple.Create(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(9.0m, 0.0m));
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

        [TestCase]
        public void TestToStringMethod()
        {

        }

        [TestCase]
        public void TestValidateMethod()
        {

        }
    }
}
