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
            Performance myPerformance1 = new Performance("A", "AA", 1.1m);
            Performance myPerformance2 = new Performance("B", "BB", 2.2m);
            Performance myPerformance3 = new Performance("C", "CC", 3.3m);
            Performance myPerformance4 = new Performance("D", "AA", 4.1m);
            Performance myPerformance5 = new Performance("E", "BB", 5.2m);
            Performance myPerformance6 = new Performance("F", "CC", 6.3m);

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
