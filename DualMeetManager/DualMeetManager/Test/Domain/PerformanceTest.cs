﻿using DualMeetManager.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Test.Domain
{
    [TestFixture]
    class PerformanceTest
    {
        [TestCase]
        public void TestDefaultConstructor()
        {
            Performance blankPerformance = new Performance();
            Assert.AreEqual(blankPerformance != null, true);
        }

        [TestCase]
        public void TestParameterizedConstructor()
        {
            bool test = true;

            Performance myPerformance = new Performance("NAME", "SCHOOL", 10.1m);
            if (myPerformance == null) test = false;
            else if (myPerformance.athleteName != "NAME") test = false;
            else if (myPerformance.schoolName != "SCHOOL") test = false;
            else if (myPerformance.performance != 10.1m) test = false;

            Performance myPerformance2 = new Performance("John Smith", "Lincoln High", 11.569m);
            if (myPerformance2.athleteName != "John Smith") test = false;
            else if (myPerformance2.schoolName != "Lincoln High") test = false;
            else if (myPerformance2.performance != 11.569m) test = false;

            Assert.True(test);
        }

        [TestCase]
        public void TestEqualsMethod()
        {
            bool test = true;

            Performance perf1 = new Performance("George Washington", "Washington High", 17.76m);
            Performance perf2 = new Performance("George Washington", "Washington High", 17.76m);
            Performance perf3 = new Performance("John Adams", "Washington High", 17.76m);
            Performance perf4 = new Performance("George Washington", "Jefferson High", 17.76m);
            Performance perf5 = new Performance("George Washington", "Washington High", 18.01m);

            if (!perf1.Equals(perf2)) test = false;
            else if (perf1.Equals(perf3)) test = false;
            else if (perf1.Equals(perf4)) test = false;
            else if (perf1.Equals(perf5)) test = false;

            Assert.True(test);
        }

        [TestCase]
        public void TestToStringMethod()
        {
            Performance perf = new Performance("George Washington", "Washington High", 17.76m);
            string strPerf = perf.ToString();

            Assert.AreEqual(strPerf, "Name: George Washington, Washington High - 17.76");
        }
    }
}
