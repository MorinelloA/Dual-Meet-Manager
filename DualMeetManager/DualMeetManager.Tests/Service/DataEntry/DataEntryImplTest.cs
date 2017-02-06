using DualMeetManager.Service.DataEntry;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Tests.Service.DataEntry
{
    [TestFixture]
    public class DataEntryImplTest
    {
        [Test]
        public void TestConvertToTimedData()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            DataEntryImpl DEI = new DataEntryImpl();
            bool test = true;

            if(DEI.ConvertToTimedData(59.1m) != "59.1")
            {
                Console.WriteLine("59.1m was not correct");
                test = false;
            }
            if (DEI.ConvertToTimedData(59.1111m) != "59.111")
            {
                Console.WriteLine("59.1111m was not correct");
                test = false;
            }
            if (DEI.ConvertToTimedData(59.99m) != "59.99")
            {
                Console.WriteLine("59.99m was not correct");
                test = false;
            }
            if (DEI.ConvertToTimedData(60.0m) != "1:00")
            {
                Console.WriteLine("60.0m was not correct, returned " + DEI.ConvertToTimedData(60.0m));
                test = false;
            }
            if (DEI.ConvertToTimedData(61.0m) != "1:01")
            {
                Console.WriteLine("61.0m was not correct, returned " + DEI.ConvertToTimedData(61.0m));
                test = false;
            }
            if (DEI.ConvertToTimedData(120.1m) != "2:00.1")
            {
                Console.WriteLine("120.1m was not correct");
                test = false;
            }
            if (DEI.ConvertToTimedData(70.01m) != "1:10.01")
            {
                Console.WriteLine("70.01mm was not correct");
                test = false;
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestConvertFromTimedData()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            DataEntryImpl DEI = new DataEntryImpl();
            bool test = true;

            if(DEI.ConvertFromTimedData("1:01") != 61m)
            {
                Console.WriteLine("1:01 was not correct, returned " + DEI.ConvertFromTimedData("1:01"));
                test = false;
            }
            if (DEI.ConvertFromTimedData("1:10") != 70m)
            {
                Console.WriteLine("1:10 was not correct, returned " + DEI.ConvertFromTimedData("1:10"));
                test = false;
            }
            if (DEI.ConvertFromTimedData("59") != 59m)
            {
                Console.WriteLine("59 was not correct, returned " + DEI.ConvertFromTimedData("59"));
                test = false;
            }
            if (DEI.ConvertFromTimedData("59.99") != 59.99m)
            {
                Console.WriteLine("59.99 was not correct, returned " + DEI.ConvertFromTimedData("59.99"));
                test = false;
            }
            if (DEI.ConvertFromTimedData("2:22.222") != 142.222m)
            {
                Console.WriteLine("2:22.222 was not correct, returned " + DEI.ConvertFromTimedData("2:22.222"));
                test = false;
            }
            if (DEI.ConvertFromTimedData("1:01.01") != 61.01m)
            {
                Console.WriteLine("1:01.01 was not correct, returned " + DEI.ConvertFromTimedData("1:01.01"));
                test = false;
            }
            if (DEI.ConvertFromTimedData("1:01.001") != 61.001m)
            {
                Console.WriteLine("1:01.001 was not correct, returned " + DEI.ConvertFromTimedData("1:01.001"));
                test = false;
            }
            if (DEI.ConvertFromTimedData("1:00") != 60m)
            {
                Console.WriteLine("1:00 was not correct, returned " + DEI.ConvertFromTimedData("1:00"));
                test = false;
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
    }
}
