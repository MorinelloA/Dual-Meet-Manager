using DualMeetManager.Domain;
using DualMeetManager.Domain.Scoring;
using DualMeetManager.Service.Printout;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Tests.Service.Printout
{
    [TestFixture]
    public class PrintoutDocXImplTest
    {
        [Test]
        public void TestCreateIndEventDocRunning()
        {
            Performance myPerformance1 = new Performance("A", "AA", 1, 59.1m);
            Performance myPerformance2 = new Performance("B", "BB", 1, 59.9m);
            Performance myPerformance3 = new Performance("C", "CC", 1, 65m);
            Performance myPerformance4 = new Performance("D", "AA", 1, 65.9m);
            Performance myPerformance5 = new Performance("E", "BB", 2, 71.2m);
            Performance myPerformance6 = new Performance("F", "CC", 2, 83.42m);

            List<Performance> myPerformancesA = new List<Performance>();
            myPerformancesA.Add(myPerformance1);
            myPerformancesA.Add(myPerformance2);
            myPerformancesA.Add(myPerformance3);
            myPerformancesA.Add(myPerformance4);
            myPerformancesA.Add(myPerformance5);
            myPerformancesA.Add(myPerformance6);

            PrintoutDocXSvcImpl pdxi = new PrintoutDocXSvcImpl();
            pdxi.CreateIndEventDoc("Boy's 100", myPerformancesA);
        }

        [Test]
        public void TestCreateIndEventDocField()
        {
            Performance myPerformance1 = new Performance("A", "AA", 59.1m);
            Performance myPerformance2 = new Performance("B", "BB", 59.9m);
            Performance myPerformance3 = new Performance("C", "CC", 65m);
            Performance myPerformance4 = new Performance("D", "AA", 65.9m);
            Performance myPerformance5 = new Performance("E", "BB", 71.2m);
            Performance myPerformance6 = new Performance("F", "CC", 83.42m);

            List<Performance> myPerformancesA = new List<Performance>();
            myPerformancesA.Add(myPerformance1);
            myPerformancesA.Add(myPerformance2);
            myPerformancesA.Add(myPerformance3);
            myPerformancesA.Add(myPerformance4);
            myPerformancesA.Add(myPerformance5);
            myPerformancesA.Add(myPerformance6);

            PrintoutDocXSvcImpl pdxi = new PrintoutDocXSvcImpl();
            pdxi.CreateIndEventDoc("Boy's LJ", myPerformancesA);
        }

        [Test]
        public void TestCreateTeamPerfDoc()
        {
            Performance boys100Performance1 = new Performance("A", "BLN", 1, 11.1m);
            Performance boys100Performance2 = new Performance("B", "TJ", 1, 12.2m);
            Performance boys100Performance3 = new Performance("C", "TJ", 1, 13.3m);
            Performance boys100Performance4 = new Performance("D", "WHS", 1, 14.1m);
            Performance boys100Performance5 = new Performance("AA", "BLN", 2, 11.01m);
            Performance boys100Performance6 = new Performance("BB", "TJ", 2, 12.12m);
            Performance boys100Performance7 = new Performance("CC", "TJ", 2, 13.13m);
            Performance boys100Performance8 = new Performance("DD", "WHS", 2, 14.41m);

            List<Performance> boys100Performances = new List<Performance>();
            boys100Performances.Add(boys100Performance1);
            boys100Performances.Add(boys100Performance2);
            boys100Performances.Add(boys100Performance3);
            boys100Performances.Add(boys100Performance4);
            boys100Performances.Add(boys100Performance5);
            boys100Performances.Add(boys100Performance6);
            boys100Performances.Add(boys100Performance7);
            boys100Performances.Add(boys100Performance8);

            Performance girls100Performance1 = new Performance("A", "BLN", 1, 11.1m);
            Performance girls100Performance2 = new Performance("B", "TJ", 1, 12.2m);
            Performance girls100Performance3 = new Performance("C", "TJ", 1, 13.3m);
            Performance girls100Performance4 = new Performance("D", "WHS", 1, 14.1m);
            Performance girls100Performance5 = new Performance("AA", "BLN", 2, 11.01m);
            Performance girls100Performance6 = new Performance("BB", "TJ", 2, 12.12m);
            Performance girls100Performance7 = new Performance("CC", "TJ", 2, 13.13m);
            Performance girls100Performance8 = new Performance("DD", "WHS", 2, 14.41m);

            List<Performance> girls100Performances = new List<Performance>();
            girls100Performances.Add(girls100Performance1);
            girls100Performances.Add(girls100Performance2);
            girls100Performances.Add(girls100Performance3);
            girls100Performances.Add(girls100Performance4);
            girls100Performances.Add(girls100Performance5);
            girls100Performances.Add(girls100Performance6);
            girls100Performances.Add(girls100Performance7);
            girls100Performances.Add(girls100Performance8);

            Performance boys200Performance1 = new Performance("A", "BLN", 1, 11.1m);
            Performance boys200Performance2 = new Performance("B", "TJ", 1, 12.2m);
            Performance boys200Performance3 = new Performance("C", "TJ", 1, 13.3m);
            Performance boys200Performance4 = new Performance("D", "WHS", 1, 14.1m);
            Performance boys200Performance5 = new Performance("AA", "BLN", 2, 11.01m);
            Performance boys200Performance6 = new Performance("BB", "TJ", 2, 12.12m);
            Performance boys200Performance7 = new Performance("CC", "TJ", 2, 13.13m);
            Performance boys200Performance8 = new Performance("DD", "WHS", 2, 14.41m);

            List<Performance> boys200Performances = new List<Performance>();
            boys200Performances.Add(boys200Performance1);
            boys200Performances.Add(boys200Performance2);
            boys200Performances.Add(boys200Performance3);
            boys200Performances.Add(boys200Performance4);
            boys200Performances.Add(boys200Performance5);
            boys200Performances.Add(boys200Performance6);
            boys200Performances.Add(boys200Performance7);
            boys200Performances.Add(boys200Performance8);

            Performance girls200Performance1 = new Performance("AAA", "BLN", 1, 11.1m);
            Performance girls200Performance2 = new Performance("BBB", "TJ", 1, 12.2m);
            Performance girls200Performance3 = new Performance("CCC", "TJ", 1, 13.3m);
            Performance girls200Performance4 = new Performance("DDD", "WHS", 1, 14.1m);
            Performance girls200Performance5 = new Performance("AAAA", "BLN", 2, 11.01m);
            Performance girls200Performance6 = new Performance("BBBB", "TJ", 2, 12.12m);
            Performance girls200Performance7 = new Performance("CCCC", "TJ", 2, 13.13m);
            Performance girls200Performance8 = new Performance("DDDD", "WHS", 2, 14.41m);

            List<Performance> girls200Performances = new List<Performance>();
            girls200Performances.Add(girls200Performance1);
            girls200Performances.Add(girls200Performance2);
            girls200Performances.Add(girls200Performance3);
            girls200Performances.Add(girls200Performance4);
            girls200Performances.Add(girls200Performance5);
            girls200Performances.Add(girls200Performance6);
            girls200Performances.Add(girls200Performance7);
            girls200Performances.Add(girls200Performance8);

            Performance girlsLJPerformance1 = new Performance("AAA", "BLN", 36m);
            Performance girlsLJPerformance2 = new Performance("BBB", "BLN", 36.2m);
            Performance girlsLJPerformance3 = new Performance("CCC", "BLN", 83.3m);
            Performance girlsLJPerformance4 = new Performance("DDD", "BLN", 79.1m);
            Performance girlsLJPerformance5 = new Performance("AAAA", "BLN", 91.01m);
            Performance girlsLJPerformance6 = new Performance("BBBB", "BLN", 92.12m);
            Performance girlsLJPerformance7 = new Performance("CCCC", "BLN", 93.13m);
            Performance girlsLJPerformance8 = new Performance("DDDD", "PLM", 114.41m);

            List<Performance> girlsLJPerformances = new List<Performance>();
            girlsLJPerformances.Add(girlsLJPerformance1);
            girlsLJPerformances.Add(girlsLJPerformance2);
            girlsLJPerformances.Add(girlsLJPerformance3);
            girlsLJPerformances.Add(girlsLJPerformance4);
            girlsLJPerformances.Add(girlsLJPerformance5);
            girlsLJPerformances.Add(girlsLJPerformance6);
            girlsLJPerformances.Add(girlsLJPerformance7);
            girlsLJPerformances.Add(girlsLJPerformance8);

            Dictionary<string, List<Performance>> myEventsA = new Dictionary<string, List<Performance>>();
            myEventsA.Add("Boy's 100", boys100Performances);
            myEventsA.Add("Boy's 200", boys200Performances);
            myEventsA.Add("Girl's 100", girls100Performances);
            myEventsA.Add("Girl's 200", girls200Performances);
            myEventsA.Add("Girl's LJ", girlsLJPerformances);

            Dictionary<string, string> boysNamesA = new Dictionary<string, string>();
            boysNamesA.Add("BLN", "Baldwin");
            boysNamesA.Add("TJ", "Thomas Jefferson");
            boysNamesA.Add("WHS", "Washington HS");

            Dictionary<string, string> girlsNamesA = new Dictionary<string, string>();
            girlsNamesA.Add("BLN", "Baldwin");
            girlsNamesA.Add("GWY", "Gateway");
            girlsNamesA.Add("KCH", "Knoch");

            Teams teams = new Teams(boysNamesA, girlsNamesA);

            Meet myMeet = new Meet(new DateTime(2017, 04, 13), "Baldwin HS", "Windy", teams, myEventsA);

            PrintoutDocXSvcImpl pdxi = new PrintoutDocXSvcImpl();
            pdxi.CreateTeamPerfDoc("BLN", "Girl's", myMeet);
        }
        //CreateMeetResultsDoc
        [Test]
        public void TestCreateMeetResultsDoc()
        {
            IndEvent indEvent1 = new IndEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), 8.0m, 1.0m);
            IndEvent indEvent2 = new IndEvent("PLM", "GWY", new EventPoints(0.0m, 5.0m, "P5", "PLM", "11.2"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), 3.0m, 6.0m);
            Dictionary<string, IndEvent> indEvents = new Dictionary<string, IndEvent>();
            indEvents.Add("Boy's 100", indEvent1);
            indEvents.Add("Boy's 200", indEvent2);

            RelayEvent relayEvent1 = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "A", "PLM", "11.3"), new EventPoints(0.0m, 0.0m, "A", "GWY", "11.4"), 5.0m, 0.0m);
            RelayEvent relayEvent2 = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "A", "PLM", "400"), new EventPoints(0.0m, 0.0m, "A", "GWY", "500"), 5.0m, 0.0m);
            Dictionary<string, RelayEvent> relayEvents = new Dictionary<string, RelayEvent>();
            relayEvents.Add("Boy's 4x100", relayEvent1);
            relayEvents.Add("Boy's 4x400", relayEvent2);

            OverallScore myOverallScore = new OverallScore(Tuple.Create("PLM", "Plum"), Tuple.Create("GWY", "Gateway"), indEvents, relayEvents);

            PrintoutDocXSvcImpl pdxi = new PrintoutDocXSvcImpl();
            pdxi.CreateMeetResultsDoc("Boy's", myOverallScore);
        }
    }
}
