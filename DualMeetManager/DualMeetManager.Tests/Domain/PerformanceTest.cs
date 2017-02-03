using DualMeetManager.Domain;
using NUnit.Framework;
using System;

namespace DualMeetManager.Tests.Domain
{
    /// <summary>
    /// Tests for the Performance class
    /// </summary>
    [TestFixture]
    class PerformanceTest
    {

        /// <summary>
        /// Tests the Default Constructor
        /// </summary>
        [TestCase]
        public void TestDefaultConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            Performance blankPerformance = new Performance();
            Assert.AreEqual(blankPerformance != null, true, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        /// <summary>
        /// Tests a parameterized constructor
        /// </summary>
        /// <remarks>Each attribute is tested individually for accuracy</remarks>
        [TestCase]
        public void TestParameterizedConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            bool test = true;

            Performance myPerformance = new Performance("NAME", "SCHOOL", 10.1m);
            if (myPerformance == null)
            {
                test = false;
                Console.WriteLine("myPerformance is null");
            }
            if (myPerformance.athleteName != "NAME")
            {
                test = false;
                Console.WriteLine("athleteName does not have the correct value");
            }
            if (myPerformance.schoolName != "SCHOOL")
            {
                test = false;
                Console.WriteLine("schoolName does not have the correct value");
            }
            if (myPerformance.performance != 10.1m)
            {
                test = false;
                Console.WriteLine("performance does not have the correct value");
            }

            Performance myPerformance2 = new Performance("John Smith", "Lincoln High", 11.569m);
            if (myPerformance2 == null)
            {
                test = false;
                Console.WriteLine("myPerformance2 is null");
            }
            if (myPerformance2.athleteName != "John Smith")
            {
                test = false;
                Console.WriteLine("athleteName does not have the correct value");
            }
            if (myPerformance2.schoolName != "Lincoln High")
            {
                test = false;
                Console.WriteLine("schoolName does not have the correct value");
            }
            if (myPerformance2.performance != 11.569m)
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

            Performance perf1 = new Performance("George Washington", "Washington High", 17.76m);
            Performance perf2 = new Performance("George Washington", "Washington High", 17.76m);
            Performance perf3 = new Performance("John Adams", "Washington High", 17.76m);
            Performance perf4 = new Performance("George Washington", "Jefferson High", 17.76m);
            Performance perf5 = new Performance("George Washington", "Washington High", 18.01m);

            if (!perf1.Equals(perf2))
            {
                test = false;
                Console.WriteLine("perf1 and perf2 are not equal");
            }
            if (perf1.Equals(perf3))
            {
                test = false;
                Console.WriteLine("perf1 equals perf3");
            }
            if (perf1.Equals(perf4))
            {
                test = false;
                Console.WriteLine("perf1 equals perf4");
            }
            if (perf1.Equals(perf5))
            {
                test = false;
                Console.WriteLine("perf1 equals perf5");
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
            Performance perf = new Performance("George Washington", "Washington High", 17.76m);
            string strPerf = perf.ToString();

            Assert.AreEqual(strPerf, "Name: George Washington, Washington High - 17.76", GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        /// <summary>
        /// Tests accuracy of the validate method
        /// </summary>
        /// <remarks>Each possibility of an invalid performance is tested</remarks>
        [TestCase]
        public void TestValidateMethod()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            bool test = true;

            Performance validPerf = new Performance("George Washington", "Washington High", 17.76m);
            Performance invalidName1 = new Performance(null, "Washington High", 17.76m);
            Performance invalidName2 = new Performance("", "Washington High", 17.76m);
            Performance invalidSchool1 = new Performance("George Washington", null, 17.76m);
            Performance invalidSchool2 = new Performance("George Washington", "", 17.76m);
            Performance invalidPerf1 = new Performance("George Washington", "Washington High", 0m);
            Performance invalidPerf2 = new Performance("George Washington", "Washington High", -17.76m);

            if (!validPerf.validate())
            {
                test = false;
                Console.WriteLine("validPerf did not validate");
            }
            if (invalidName1.validate())
            {
                test = false;
                Console.WriteLine("invalidName1 validated");
            }
            if (invalidName2.validate())
            {
                test = false;
                Console.WriteLine("invalidName2 validated");
            }
            if (invalidSchool1.validate())
            {
                test = false;
                Console.WriteLine("invalidSchool1 validated");
            }
            if (invalidSchool2.validate())
            {
                test = false;
                Console.WriteLine("invalidSchool2 validated");
            }
            if (invalidPerf1.validate())
            {
                test = false;
                Console.WriteLine("invalidPerf1 validated");
            }
            if (invalidPerf2.validate())
            {
                test = false;
                Console.WriteLine("invalidPerf2 validated");
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
    }
}
