using DualMeetManager.Business.Exceptions;
using DualMeetManager.Business.Managers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Tests.Business
{
    [TestFixture]
    public class EventMgrTest
    {
        [Test]
        public void TestConvertToTimedDataEventMgr()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            EventMgr eMgr = new EventMgr();
            string timedData = eMgr.ConvertToTimedData(61.01m);
            bool test = (timedData == "1:01.01");
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestConvertFromTimedDataEventMgr()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            EventMgr eMgr = new EventMgr();
            decimal rawData = eMgr.ConvertFromTimedData("1:01.01");
            bool test = (rawData == 61.01m);
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestConvertToLengthDataEventMgr()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            EventMgr eMgr = new EventMgr();
            string lengthData = eMgr.ConvertToLengthData(37.1m);
            bool test = (lengthData == "3-01.1");
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestConvertFromLengthDataEventMgr()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            EventMgr eMgr = new EventMgr();
            decimal rawData = eMgr.ConvertFromLengthData("3-01.1");
            bool test = (rawData == 37.1m);
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
    }
}
