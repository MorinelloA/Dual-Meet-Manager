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
        public void TestTeam1Sweep()
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

            //Log performances
            Console.WriteLine("Performances:");
            foreach(Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if(eventToTest.team1Total != 9)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 9 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 0)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 0 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        /// <summary>
        /// Tests if scoring for Team 2 sweeping 1 2 and 3 is accurate
        /// </summary>
        [TestCase]
        public void TestTeam2Sweep()
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

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 0)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 0 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 9)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 9 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }


        [TestCase]
        public void TestFirstPlaceOnly()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.5m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 5)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 5 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 0)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 0 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestFirstAndSecondOnly()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.7m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 5)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 5 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 3)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 3 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestFiveToFour()
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

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 5)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 5 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 4)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 4 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestEightToOne()
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

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 1)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 1 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 8)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 8 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestTwoWayTieForFirst5To4()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.82m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 1, 10.3m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.4m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 2, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 2, 10.1m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 5)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 5 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 4)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 4 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestTwoWayTieForFirst1To8()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.2m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.1m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 1, 10.3m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.4m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 2, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 2, 10.1m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 1)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 1 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 8)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 8 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestTwoWayTieForFirst4To5()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.62m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 1, 10.3m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.24m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 2, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 2, 10.1m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 4)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 4 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 5)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 5 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestThreeWayTieForFirst()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.2m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 2, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.4m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 3, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 3, 10.1m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 6)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 6 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 3)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 3 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestFourWayTieForFirst()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.2m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 2, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.4m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 3, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 3, 10.1m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 4, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 4, 10.15m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != (9.0m / 4.0m) * 3)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal " + ((9.0m / 4.0m) * 3) + " - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != (9.0m / 4.0m))
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal " + (9.0m / 4.0m) + " - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestTwoWayTieForSecond()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.8m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 2, 10.8m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.2m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 3, 10.2m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 3, 10.51m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 7)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 7 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 2)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 2 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            if(!test)
            {
                Console.WriteLine("Complete EventTest for Error Logging:");
                Console.WriteLine(eventToTest.ToString());
            }
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestThreeWayTieForSecond()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.4m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 2, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.8m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 3, 10.7m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 3, 10.5m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 4.0m / 3 * 2)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal " + 4.0m / 3 * 2 + " - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 5 + (4.0m / 3))
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal " + 5 + (4.0m / 3) + " - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            if (!test)
            {
                Console.WriteLine("Complete EventTest for Error Logging:");
                Console.WriteLine(eventToTest.ToString());
            }
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestFourWayTieForSecond()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.4m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 2, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.8m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 3, 10.7m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 3, 10.5m));
            perfs.Add(new Performance("Plum Athlete #4", "PLM", 4, 10.7m));
            perfs.Add(new Performance("Gateway Athlete #4", "GWY", 4, 10.5m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 4.0m / 4 * 2)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal " + 4.0m / 4 * 2 + " - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 5 + (4.0m / 4 * 2))
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal " + 5 + (4.0m / 4 * 2) + " - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            if (!test)
            {
                Console.WriteLine("Complete EventTest for Error Logging:");
                Console.WriteLine(eventToTest.ToString());
            }
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestTwoWayTieForThird()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.2m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 2, 10.3m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.52m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 3, 10.53m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 3, 10.3m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 5.5m)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 5.5 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 3.5m)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 3.5 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            if (!test)
            {
                Console.WriteLine("Complete EventTest for Error Logging:");
                Console.WriteLine(eventToTest.ToString());
            }
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestThreeWayTieForThird()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.4m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 2, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.2m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 3, 10.7m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 3, 10.5m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 1.0m / 3 * 2)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal " + 1.0m / 3 * 2 + " - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 8 + (1.0m / 3))
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal " + 8 + (1.0m / 3) + " - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            if (!test)
            {
                Console.WriteLine("Complete EventTest for Error Logging:");
                Console.WriteLine(eventToTest.ToString());
            }
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestFourWayTieForThird()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.4m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 2, 10.5m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.2m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 3, 10.7m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 3, 10.5m));
            perfs.Add(new Performance("Plum Athlete #4", "PLM", 4, 10.97m));
            perfs.Add(new Performance("Gateway Athlete #4", "GWY", 4, 10.5m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 1.0m / 4 * 2)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal " + 1.0m / 4 * 2 + " - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 8 + (1.0m / 4 * 2))
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal " + 8 + (1.0m / 4 * 2) + " - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            if (!test)
            {
                Console.WriteLine("Complete EventTest for Error Logging:");
                Console.WriteLine(eventToTest.ToString());
            }
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestSameFirstPerfSameHeat()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.1m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 2, 10.3m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.2m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 3, 10.53m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 3, 10.33m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 5m)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 5 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 4m)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 4 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            if (!test)
            {
                Console.WriteLine("Complete EventTest for Error Logging:");
                Console.WriteLine(eventToTest.ToString());
            }
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestSameSecondPerfSameHeat()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.2m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 1, 10.2m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.3m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 2, 10.53m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 2, 10.33m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 6m)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 6 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 3m)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 3 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            if (!test)
            {
                Console.WriteLine("Complete EventTest for Error Logging:");
                Console.WriteLine(eventToTest.ToString());
            }
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestSameThirdPerfSameHeat()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.8m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 2, 10.2m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.9m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 3, 10.3m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 3, 10.3m));
            

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 8m)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 8 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 1m)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 1 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            if (!test)
            {
                Console.WriteLine("Complete EventTest for Error Logging:");
                Console.WriteLine(eventToTest.ToString());
            }
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestThreeSameFirstPerfTwoHeats()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.1m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 2, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.2m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 3, 10.53m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 3, 10.33m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 8m)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 8 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 1m)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 1 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            if (!test)
            {
                Console.WriteLine("Complete EventTest for Error Logging:");
                Console.WriteLine(eventToTest.ToString());
            }
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestFourSameFirstPerfTwoHeats()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.1m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 1, 10.1m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 2, 10.1m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 8m)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 8 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 1m)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 1 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            if (!test)
            {
                Console.WriteLine("Complete EventTest for Error Logging:");
                Console.WriteLine(eventToTest.ToString());
            }
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestFourSameFirstPerfTwoHeats2()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.1m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 1, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.1m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 2, 10.1m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 9m)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 9 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 0m)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 0 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            if (!test)
            {
                Console.WriteLine("Complete EventTest for Error Logging:");
                Console.WriteLine(eventToTest.ToString());
            }
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestThreeSameSecondPerfTwoHeats()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            //public IndEvent CalculateRunningEvent(string team1Abbr, string team2Abbr, List<Performance> perf)
            string team1 = "PLM";
            string team2 = "GWY";
            List<Performance> perfs = new List<Performance>();

            //public Performance(string athleteName, string schoolName, decimal performance)
            perfs.Add(new Performance("Plum Athlete #1", "PLM", 1, 10.1m));
            perfs.Add(new Performance("Gateway Athlete #1", "GWY", 1, 10.2m));
            perfs.Add(new Performance("Plum Athlete #2", "PLM", 1, 10.2m));
            perfs.Add(new Performance("Gateway Athlete #2", "GWY", 2, 10.2m));
            perfs.Add(new Performance("Plum Athlete #3", "PLM", 2, 10.53m));
            perfs.Add(new Performance("Gateway Athlete #3", "GWY", 2, 10.33m));

            //Log performances
            Console.WriteLine("Performances:");
            foreach (Performance i in perfs)
            {
                Console.WriteLine(i.ToString());
            }

            ScoringSvcImpl SSI = new ScoringSvcImpl();

            IndEvent eventToTest = new IndEvent();
            eventToTest = SSI.CalculateRunningEvent(team1, team2, perfs);

            bool test = true;

            if (eventToTest.team1Total != 5m)
            {
                test = false;
                Console.WriteLine("Team 1 Total does not equal 5 - It equals " + eventToTest.team1Total);
                Console.WriteLine("Team 1 First Place Points - " + eventToTest.points[0].team1Pts);
                Console.WriteLine("Team 1 Second Place Points - " + eventToTest.points[1].team1Pts);
                Console.WriteLine("Team 1 Third Place Points - " + eventToTest.points[2].team1Pts);
            }
            if (eventToTest.team2Total != 4m)
            {
                test = false;
                Console.WriteLine("Team 2 Total does not equal 4 - It equals " + eventToTest.team2Total);
                Console.WriteLine("Team 2 First Place Points - " + eventToTest.points[0].team2Pts);
                Console.WriteLine("Team 2 Second Place Points - " + eventToTest.points[1].team2Pts);
                Console.WriteLine("Team 2 Third Place Points - " + eventToTest.points[2].team2Pts);
            }

            if (!test)
            {
                Console.WriteLine("Complete EventTest for Error Logging:");
                Console.WriteLine(eventToTest.ToString());
            }
            Assert.True(test, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [TestCase]
        public void TestNoPerformances()
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
