using DualMeetManager.Service;
using DualMeetManager.Service.DataEntry;
using DualMeetManager.Service.Printout;
using DualMeetManager.Service.Saving;
using DualMeetManager.Service.Scoring;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Tests.Service
{
    [TestFixture]
    class FactoryTest
    {
        [Test]
        public void TestFactoryDataEntrySvc()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            Factory myFactory = new Factory();

            IDataEntrySvc dataEntryService = myFactory.GetDataEntrySvc();
            Console.WriteLine("dataEntryService type: " + dataEntryService.GetType());
            Assert.IsInstanceOf<DataEntrySvcImpl>(dataEntryService, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestFactoryPrintoutDocSvc()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            Factory myFactory = new Factory();

            IPrintoutDocSvc printoutDocService = myFactory.GetPrintoutDocSvc();
            Console.WriteLine("printoutDocServce type: " + printoutDocService.GetType());
            Assert.IsInstanceOf<PrintoutDocXSvcImpl>(printoutDocService, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestFactoryPrintoutPDFSvc()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            Factory myFactory = new Factory();

            IPrintoutPDFSvc printoutPDFService = myFactory.GetPrintoutPDFSvc();
            Console.WriteLine("printoutPDFServce type: " + printoutPDFService.GetType());
            Assert.IsInstanceOf<PrintoutPDFSharpSvcImpl>(printoutPDFService, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestFactorySavingSvc()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            Factory myFactory = new Factory();

            ISavingSvc savingService = myFactory.GetSavingSvc();
            Console.WriteLine(savingService.GetType());
            Assert.IsInstanceOf<SavingJsonSvcImpl>(savingService, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestFactoryScoringSvc()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            Factory myFactory = new Factory();

            IScoringSvc scoringService = myFactory.GetScoringSvc();
            Console.WriteLine(scoringService.GetType());
            Assert.IsInstanceOf<ScoringSvcImpl>(scoringService, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }


    }
}
