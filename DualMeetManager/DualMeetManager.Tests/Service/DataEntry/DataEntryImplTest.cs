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
            DataEntrySvcImpl DEI = new DataEntrySvcImpl();
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
            DataEntrySvcImpl DEI = new DataEntrySvcImpl();
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

        [Test]
        public void TestConvertToLengthData()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            DataEntrySvcImpl DEI = new DataEntrySvcImpl();
            bool test = true;

            if (DEI.ConvertToLengthData(13m) != "1-01")
            {
                Console.WriteLine("13m was not correct, returned " + DEI.ConvertToLengthData(13m));
                test = false;
            }
            if (DEI.ConvertToLengthData(11m) != "11")
            {
                Console.WriteLine("11m was not correct, returned " + DEI.ConvertToLengthData(11m));
                test = false;
            }
            if (DEI.ConvertToLengthData(35m) != "2-11")
            {
                Console.WriteLine("35m was not correct, returned " + DEI.ConvertToLengthData(35m));
                test = false;
            }
            if (DEI.ConvertToLengthData(36.1m) != "3-00.1")
            {
                Console.WriteLine("36.1m was not correct, returned " + DEI.ConvertToLengthData(36.1m));
                test = false;
            }
            if (DEI.ConvertToLengthData(46m) != "3-10")
            {
                Console.WriteLine("46m was not correct, returned " + DEI.ConvertToLengthData(46m));
                test = false;
            }
            if (DEI.ConvertToLengthData(36.001m) != "3-00.001")
            {
                Console.WriteLine("36.001m was not correct, returned " + DEI.ConvertToLengthData(36.001m));
                test = false;
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestConvertFromLengthData()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            DataEntrySvcImpl DEI = new DataEntrySvcImpl();
            bool test = true;

            if (DEI.ConvertFromLengthData("1-01") != 13m)
            {
                Console.WriteLine("1-01 was not correct, returned " + DEI.ConvertFromLengthData("1-10"));
                test = false;
            }
            if (DEI.ConvertFromLengthData("11") != 11m)
            {
                Console.WriteLine("11 was not correct, returned " + DEI.ConvertFromLengthData("11"));
                test = false;
            }
            if (DEI.ConvertFromLengthData("2-11") != 35m)
            {
                Console.WriteLine("2-11 was not correct, returned " + DEI.ConvertFromLengthData("2-11"));
                test = false;
            }
            if (DEI.ConvertFromLengthData("3-00.1") != 36.1m)
            {
                Console.WriteLine("3-00.1 was not correct, returned " + DEI.ConvertFromLengthData("3-00.1"));
                test = false;
            }
            if (DEI.ConvertFromLengthData("3-10") != 46m)
            {
                Console.WriteLine("3-10 was not correct, returned " + DEI.ConvertFromLengthData("3-10"));
                test = false;
            }
            if (DEI.ConvertFromLengthData("3-00.001") != 36.001m)
            {
                Console.WriteLine("3-00.001 was not correct, returned " + DEI.ConvertFromLengthData("3-00.001"));
                test = false;
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
    }
}
