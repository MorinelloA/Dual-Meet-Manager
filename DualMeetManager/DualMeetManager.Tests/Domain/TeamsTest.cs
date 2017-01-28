using DualMeetManager.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DualMeetManager.Tests.Domain
{
    /// <summary>
    /// Tests for the Teams class
    /// </summary>
    [TestFixture]
    class TeamsTest
    {
        /// <summary>
        /// Tests the Default Constructor
        /// </summary>
        [TestCase]
        public void TestDefaultConstructor()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            Teams blankTeams = new Teams();
            Assert.AreEqual(blankTeams != null, true, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
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

            Dictionary<string, string> boys = new Dictionary<string, string>();
            boys.Add("PLM", "Plum");
            boys.Add("GWY", "GateWay");
            boys.Add("WH", "Woodland Hills");

            Dictionary<string, string> girls = new Dictionary<string, string>();
            girls.Add("FR", "Franklin Regional");
            girls.Add("HL", "Highlands");
            girls.Add("SPR", "Springdale");

            Teams myTeams = new Teams(boys, girls);

            if (myTeams == null)
            {
                test = false;
                Console.WriteLine("myTeams is null");
            }
            if (myTeams.boySchoolNames == null)
            {
                test = false;
                Console.WriteLine("boySchoolNames is null");
            }
            if (myTeams.girlSchoolNames == null)
            {
                test = false;
                Console.WriteLine("girlSchoolNames is null");
            }
            if (!myTeams.boySchoolNames.OrderBy(r => r.Key).SequenceEqual(boys.OrderBy(r => r.Key)))
            {
                test = false;
                Console.WriteLine("boySchoolNames does not have the correct value");
            }
            if (!myTeams.girlSchoolNames.OrderBy(r => r.Key).SequenceEqual(girls.OrderBy(r => r.Key)))
            {
                test = false;
                Console.WriteLine("girlSchoolNames does not have the correct value");
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

            //Dictionary to compare
            Dictionary<string, string> boys1 = new Dictionary<string, string>();
            boys1.Add("PLM", "Plum");
            boys1.Add("GWY", "GateWay");
            boys1.Add("WH", "Woodland Hills");

            //Equal to boys1
            Dictionary<string, string> boys2 = new Dictionary<string, string>();
            boys2.Add("PLM", "Plum");
            boys2.Add("GWY", "GateWay");
            boys2.Add("WH", "Woodland Hills");

            //Equal to but out of order to boys1
            Dictionary<string, string> boys3 = new Dictionary<string, string>();
            boys3.Add("PLM", "Plum");
            boys3.Add("WH", "Woodland Hills");
            boys3.Add("GWY", "GateWay");

            //One different key
            Dictionary<string, string> boys4 = new Dictionary<string, string>();
            boys4.Add("PLM", "Plum");
            boys4.Add("GWY", "GateWay");
            boys4.Add("WHS", "Woodland Hills");

            //One different value
            Dictionary<string, string> boys5 = new Dictionary<string, string>();
            boys5.Add("PLM", "Plum HS");
            boys5.Add("GWY", "GateWay");
            boys5.Add("WH", "Woodland Hills");

            //Girl's dictionary to compare
            Dictionary<string, string> girls1 = new Dictionary<string, string>();
            girls1.Add("FR", "Franklin Regional");
            girls1.Add("HL", "Highlands");
            girls1.Add("SPR", "Springdale");

            //Equal dictionary
            Dictionary<string, string> girls2 = new Dictionary<string, string>();
            girls2.Add("FR", "Franklin Regional");
            girls2.Add("HL", "Highlands");
            girls2.Add("SPR", "Springdale");

            //Equal but out of order
            Dictionary<string, string> girls3 = new Dictionary<string, string>();
            girls3.Add("FR", "Franklin Regional");
            girls3.Add("SPR", "Springdale");
            girls3.Add("HL", "Highlands");

            //One different key
            Dictionary<string, string> girls4 = new Dictionary<string, string>();
            girls4.Add("FR", "Franklin Regional");
            girls4.Add("HLS", "Highlands");
            girls4.Add("SPR", "Springdale");

            //One different value
            Dictionary<string, string> girls5 = new Dictionary<string, string>();
            girls5.Add("FR", "Franklin Regional");
            girls5.Add("HL", "Highlands Area");
            girls5.Add("SPR", "Springdale");

            Teams controlTeams = new Teams(boys1, girls1);
            Teams equalBoys = new Teams(boys2, girls1);
            Teams equalGirls = new Teams(boys1, girls2);
            Teams unorderedBoys = new Teams(boys3, girls1);
            Teams unorderedGirls = new Teams(boys1, girls3);
            Teams incorrectBoysKey = new Teams(boys4, girls1);
            Teams incorrectGirlsKey = new Teams(boys1, girls4);
            Teams incorrectBoysValue = new Teams(boys5, girls1);
            Teams incorrectGirlsValue = new Teams(boys1, girls5);

            if(!equalBoys.Equals(controlTeams))
            {
                test = false;
                Console.WriteLine("equalBoys was not equal to the control");
            }
            if (!equalGirls.Equals(controlTeams))
            {
                test = false;
                Console.WriteLine("equalGirls was not equal to the control");
            }
            if (!unorderedBoys.Equals(controlTeams))
            {
                test = false;
                Console.WriteLine("unorderedBoys was not equal to the control");
            }
            if (!unorderedGirls.Equals(controlTeams))
            {
                test = false;
                Console.WriteLine("unorederedGirls was not equal to the control");
            }
            if (incorrectBoysKey.Equals(controlTeams))
            {
                test = false;
                Console.WriteLine("incorrectBoysKey was equal to the control");
            }
            if (incorrectGirlsKey.Equals(controlTeams))
            {
                test = false;
                Console.WriteLine("incorrectGirlsKey was equal to the control");
            }
            if (incorrectBoysValue.Equals(controlTeams))
            {
                test = false;
                Console.WriteLine("incorrectBoysValue was equal to the control");
            }
            if (incorrectGirlsValue.Equals(controlTeams))
            {
                test = false;
                Console.WriteLine("incorrectGirlsValue was equal to the control");
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

            Dictionary<string, string> boys = new Dictionary<string, string>();
            boys.Add("BLN", "Baldwin");
            boys.Add("TJ", "Thomas Jefferson");
            boys.Add("WHS", "Washington HS");

            Dictionary<string, string> girls = new Dictionary<string, string>();
            girls.Add("PLM", "Plum");
            girls.Add("GWY", "Gateway");
            girls.Add("KCH", "Knoch");

            Teams myTeams = new Teams(boys, girls);

            string strTeams = myTeams.ToString();

            Console.WriteLine("My string:" + Environment.NewLine + Environment.NewLine);
            Console.WriteLine(strTeams + Environment.NewLine);

            Console.WriteLine("Expecting:" + Environment.NewLine + Environment.NewLine);
            Console.WriteLine("Teams:" + Environment.NewLine +
                "Boys:" + Environment.NewLine +
                "Baldwin - BLN" + Environment.NewLine +
                "Thomas Jefferson - TJ" + Environment.NewLine +
                "Washington HS - WHS" + Environment.NewLine +
                "Girls:" + Environment.NewLine +
                "Plum - PLM" + Environment.NewLine +
                "Gateway - GWY" + Environment.NewLine +
                "Knoch - KCH");

            Assert.AreEqual(strTeams, "Teams:" + Environment.NewLine +
                "Boys:" + Environment.NewLine +
                "Baldwin - BLN" + Environment.NewLine +
                "Thomas Jefferson - TJ" + Environment.NewLine +
                "Washington HS - WHS" + Environment.NewLine +
                "Girls:" + Environment.NewLine +
                "Plum - PLM" + Environment.NewLine +
                "Gateway - GWY" + Environment.NewLine +
                "Knoch - KCH",
                GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");

            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        /// <summary>
        /// Tests accuracy of the validate method
        /// </summary>
        /// <remarks>Each possibility of an invalid Teams object is tested</remarks>
        [TestCase]
        public void TestValidateMethod()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            bool test = true;

            //Valid boys
            Dictionary<string, string> boys1 = new Dictionary<string, string>();
            boys1.Add("PLM", "Plum");
            boys1.Add("GWY", "GateWay");
            boys1.Add("WH", "Woodland Hills");

            //Blank boys Key
            Dictionary<string, string> boys2 = new Dictionary<string, string>();
            boys2.Add("PLM", "Plum");
            boys2.Add("", "GateWay");
            boys2.Add("WH", "Woodland Hills");

            //Blank boys Value
            Dictionary<string, string> boys3 = new Dictionary<string, string>();
            boys3.Add("PLM", "");
            boys3.Add("GWY", "GateWay");
            boys3.Add("WH", "Woodland Hills");

            //Two values the same
            Dictionary<string, string> boys4 = new Dictionary<string, string>();
            boys4.Add("PLM", "Plum");
            boys4.Add("GWY", "Plum");
            boys4.Add("WH", "Woodland Hills");

            //Key has more than 3 letters
            Dictionary<string, string> boys5 = new Dictionary<string, string>();
            boys5.Add("PLM", "Plum");
            boys5.Add("GATE", "GateWay");
            boys5.Add("WH", "Woodland Hills");

            //Valid girls
            Dictionary<string, string> girls1 = new Dictionary<string, string>();
            girls1.Add("FR", "Franklin Regional");
            girls1.Add("HL", "Highlands");
            girls1.Add("SPR", "Springdale");

            //Blank girls key
            Dictionary<string, string> girls2 = new Dictionary<string, string>();
            girls2.Add("FR", "Franklin Regional");
            girls2.Add("HL", "Highlands");
            girls2.Add("", "Springdale");

            //Blank girls Value
            Dictionary<string, string> girls3 = new Dictionary<string, string>();
            girls3.Add("FR", "");
            girls3.Add("HL", "Highlands");
            girls3.Add("SPR", "Springdale");

            //Two values the same           
            Dictionary<string, string> girls4 = new Dictionary<string, string>();
            girls4.Add("FR", "Franklin Regional");
            girls4.Add("HL", "Highlands");
            girls4.Add("SPR", "Highlands");
            
            //Key has more than 3 letters
            Dictionary<string, string> girls5 = new Dictionary<string, string>();
            girls5.Add("FR", "Franklin Regional");
            girls5.Add("HL", "Highlands");
            girls5.Add("SPRING", "Springdale");

            Teams validTeams = new Teams(boys1, girls1);
            Teams blankBoysKey = new Teams(boys2, girls1);
            Teams blankBoysValue = new Teams(boys3, girls1);
            Teams dupBoysValue = new Teams(boys4, girls1);
            Teams longBoysKey = new Teams(boys5, girls1);
            Teams blankGirlsKey = new Teams(boys1, girls2);
            Teams blankGirlsValue = new Teams(boys1, girls3);
            Teams dupGirlsValue = new Teams(boys1, girls4);
            Teams longGirlsKey = new Teams(boys1, girls5);

            if (!validTeams.validate())
            {
                test = false;
                Console.WriteLine("validTeams did not validate");
            }
            if (blankBoysKey.validate())
            {
                test = false;
                Console.WriteLine("blankBoysKey validated");
            }
            if (blankBoysValue.validate())
            {
                test = false;
                Console.WriteLine("blankBoysValue validated");
            }
            if (dupBoysValue.validate())
            {
                test = false;
                Console.WriteLine("dupBoysValue validated");
            }
            if (longBoysKey.validate())
            {
                test = false;
                Console.WriteLine("longBoyKey validated");
            }
            if (blankGirlsKey.validate())
            {
                test = false;
                Console.WriteLine("blankGirlsKey validated");
            }
            if (blankGirlsValue.validate())
            {
                test = false;
                Console.WriteLine("blankGirlsValue validated");
            }
            if (dupGirlsValue.validate())
            {
                test = false;
                Console.WriteLine("dupGirlsValue validated");
            }
            if (longGirlsKey.validate())
            {
                test = false;
                Console.WriteLine("longGirlKey validated");
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
        
    }
}