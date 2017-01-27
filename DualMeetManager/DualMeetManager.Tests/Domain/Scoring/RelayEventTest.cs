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

        }

        [TestCase]
        public void TestEqualsMethod()
        {

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
