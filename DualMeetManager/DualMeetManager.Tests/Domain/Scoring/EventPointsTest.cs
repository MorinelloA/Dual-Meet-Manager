using DualMeetManager.Domain.Scoring;
using NUnit.Framework;
using System;

namespace DualMeetManager.Tests.Domain.Scoring
{
    /// <summary>
    /// Tests for the EventPoints class
    /// </summary>
    [TestFixture]
    class EventPointsTest
    {
        /// <summary>
        /// Test Default Constructor
        /// </summary>
        [TestCase]
        public void TestDefaultConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            EventPoints blankEventPoints = new EventPoints();
            Assert.AreEqual(blankEventPoints != null, true, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        /// <summary>
        /// Test Parameterized Constructor
        /// </summary>
        /// <remarks>Each attribute is tested individually for accuracy</remarks>
        [TestCase]
        public void TestParameterizedConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            bool test = true;

            EventPoints ep = new EventPoints(5.0m, 0.0m, "AthleteName", "ABR", "4:25");

            if (ep == null)
            {
                test = false;
                Console.WriteLine("ep is null");
            }
            if (ep.team1Pts != 5.0m)
            {
                test = false;
                Console.WriteLine("team1Pts does not have the correct value");
            }
            if (ep.team2Pts != 0.0m)
            {
                test = false;
                Console.WriteLine("team2Pts does not have the correct value");
            }
            if (ep.athleteName != "AthleteName")
            {
                test = false;
                Console.WriteLine("athleteName does not have the correct value");
            }
            if (ep.schoolName != "ABR")
            {
                test = false;
                Console.WriteLine("schoolName does not have the correct value");
            }
            if (ep.performance != "4:25")
            {
                test = false;
                Console.WriteLine("performance does not have the correct value");
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

            EventPoints control = new EventPoints(5.0m, 0.0m, "AthleteName", "ABR", "4:25");

            EventPoints equal = new EventPoints(5.0m, 0.0m, "AthleteName", "ABR", "4:25");
            EventPoints diffTeam1Pts = new EventPoints(4.0m, 0.0m, "AthleteName", "ABR", "4:25");
            EventPoints diffTeam2Pts = new EventPoints(5.0m, 1.0m, "AthleteName", "ABR", "4:25");
            EventPoints diffAthleteName = new EventPoints(5.0m, 0.0m, "Donald Trump", "ABR", "4:25");
            EventPoints diffSchoolName = new EventPoints(5.0m, 0.0m, "AthleteName", "WHS", "4:25");
            EventPoints diffPerformance = new EventPoints(5.0m, 0.0m, "AthleteName", "ABR", "4:23");
            
            if(!control.Equals(equal))
            {
                test = false;
                Console.WriteLine("equal object was not equal to the control");
            }
            if(control.Equals(diffTeam1Pts))
            {
                test = false;
                Console.WriteLine("diffTeam1Pts was equal to the control");
            }
            if (control.Equals(diffTeam2Pts))
            {
                test = false;
                Console.WriteLine("diffTeam2Pts was equal to the control");
            }
            if (control.Equals(diffAthleteName))
            {
                test = false;
                Console.WriteLine("diffAthleteName was equal to the control");
            }
            if (control.Equals(diffSchoolName))
            {
                test = false;
                Console.WriteLine("diffSchoolName was equal to the control");
            }
            if (control.Equals(diffPerformance))
            {
                test = false;
                Console.WriteLine("diffPerformance was equal to the control");
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

            EventPoints myEventPoints = new EventPoints(5.0m, 0.0m, "AthleteName", "ABR", "4:25");

            string strEventPoints = myEventPoints.ToString();

            Console.WriteLine("My string:" + Environment.NewLine + Environment.NewLine);
            Console.WriteLine(strEventPoints + Environment.NewLine);

            Console.WriteLine("Expecting:" + Environment.NewLine + Environment.NewLine);
            Console.WriteLine("Athlete: AthleteName" + Environment.NewLine +
                "School: ABR" + Environment.NewLine +
                "Performance: 4:25" + Environment.NewLine +
                "Team 1 Points: 5" + Environment.NewLine +
                "Team 2 Points: 0");

            Assert.AreEqual(strEventPoints, "Athlete: AthleteName" + Environment.NewLine +
                "School: ABR" + Environment.NewLine +
                "Performance: 4:25" + Environment.NewLine +
                "Team 1 Points: 5" + Environment.NewLine +
                "Team 2 Points: 0",
                GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");

            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
    }
}
