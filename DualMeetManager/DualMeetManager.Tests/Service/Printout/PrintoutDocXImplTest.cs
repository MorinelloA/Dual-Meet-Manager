using DualMeetManager.Domain;
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
        public void TestAAA()
        {
            Performance myPerformance1 = new Performance("A", "AA", 1, 59.1m);
            Performance myPerformance2 = new Performance("B", "BB", 1, 59.9m);
            Performance myPerformance3 = new Performance("C", "CC", 1, 65m);
            Performance myPerformance4 = new Performance("D", "AA", 1, 65.9m);
            Performance myPerformance5 = new Performance("E", "BB", 2, 71.2m);
            Performance myPerformance6 = new Performance("F", "CC", 2, 83.42m);

            /*Performance myPerformance1 = new Performance("A", "AA", 59.1m);
            Performance myPerformance2 = new Performance("B", "BB", 59.9m);
            Performance myPerformance3 = new Performance("C", "CC", 65m);
            Performance myPerformance4 = new Performance("D", "AA", 65.9m);
            Performance myPerformance5 = new Performance("E", "BB", 71.2m);
            Performance myPerformance6 = new Performance("F", "CC", 83.42m);*/

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
    }
}
