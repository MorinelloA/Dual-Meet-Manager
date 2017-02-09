using DualMeetManager.Domain;
using DualMeetManager.Domain.Scoring;
using DualMeetManager.Service.Scoring;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Tests.Service.Scoring
{
    /// <summary>
    /// Tests for scoring Running Events
    /// </summary>
    [TestFixture]
    public class ScoringServiceImplRunningEventTest
    {
        /// <summary>
        /// Tests if scoring for Team 1 sweeping 1 2 and 3 is accurate
        /// </summary>
        [TestCase]
        public void Team1Sweep()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.8m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 1, 10.6m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 1, 10.9m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 1, 10.7m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 1, 10.95m));

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if(eventToTest.team1Total != 9)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 9 - It equals " + eventToTest.team1Total);
            }
            if (eventToTest.team2Total != 0)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 0 - It equals " + eventToTest.team2Total);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        /// <summary>
        /// Tests if scoring for Team 2 sweeping 1 2 and 3 is accurate
        /// </summary>
        [TestCase]
        public void Team2Sweep()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.55m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.52m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 1, 10.54m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 1, 10.51m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 1, 10.53m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 1, 10.50m));

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 0)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 0 - It equals " + eventToTest.team1Total);
            }
            if (eventToTest.team2Total != 9)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 9 - It equals " + eventToTest.team2Total);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }


        [TestCase]
        public void FirstPlaceOnly()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.5m));

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 5)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 5 - It equals " + eventToTest.team1Total);
            }
            if (eventToTest.team2Total != 0)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 0 - It equals " + eventToTest.team2Total);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void FirstAndSecondOnly()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.7m));

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 5)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 5 - It equals " + eventToTest.team1Total);
            }
            if (eventToTest.team2Total != 3)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 3 - It equals " + eventToTest.team2Total);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void FiveToFour()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.7m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 1, 11.5m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 1, 10.8m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 1, 12.5m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 1, 13.7m));

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 5)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 5 - It equals " + eventToTest.team1Total);
            }
            if (eventToTest.team2Total != 4)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 4 - It equals " + eventToTest.team2Total);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void EightToOne()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 17.9m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.7m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 1, 11.5m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 1, 10.8m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 1, 10.9m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 1, 17.9m));

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 1)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 1 - It equals " + eventToTest.team1Total);
            }
            if (eventToTest.team2Total != 8)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 8 - It equals " + eventToTest.team2Total);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TwoWayTieForFirst()
        {

        }

        [TestCase]
        public void ThreeWayTieForFirst()
        {

        }

        [TestCase]
        public void FourWayTieForFirst()
        {

        }

        [TestCase]
        public void TwoWayTieForSecond()
        {

        }

        [TestCase]
        public void ThreeWayTieForSecond()
        {

        }

        [TestCase]
        public void FourWayTieForSecond()
        {

        }

        [TestCase]
        public void TwoWayTieForThird()
        {

        }

        [TestCase]
        public void ThreeWayTieForThird()
        {

        }

        [TestCase]
        public void FourWayTieForThird()
        {

        }

        [TestCase]
        public void SameFirstPerfSameHeat()
        {

        }

        [TestCase]
        public void SameSecondPerfSameHeat()
        {

        }

        [TestCase]
        public void SameThirdPerfSameHeat()
        {

        }

        [TestCase]
        public void NoPerformances()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            //perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 17.9m));

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 0)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 0 - It equals " + eventToTest.team1Total);
            }
            if (eventToTest.team2Total != 0)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 0 - It equals " + eventToTest.team2Total);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
    }
}
