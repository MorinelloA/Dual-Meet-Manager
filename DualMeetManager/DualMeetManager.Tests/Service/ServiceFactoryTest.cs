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
    public class ServiceFactoryTest
    {
        [Test, Order(1)]
        public void TestServiceFactoryDataEntrySvc()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            ServiceFactory myServiceFactory = ServiceFactory.GetInstance();
            IDataEntrySvc dataEntryService = (IDataEntrySvc)myServiceFactory.GetService(typeof(IDataEntrySvc).Name);
            Console.WriteLine("dataEntryService type: " + dataEntryService.GetType());

            Assert.IsInstanceOf<DataEntrySvcImpl>(dataEntryService, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestServiceFactoryPrintoutDocSvc()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            ServiceFactory myServiceFactory = ServiceFactory.GetInstance();
            IPrintoutDocSvc printoutDocService = (IPrintoutDocSvc)myServiceFactory.GetService(typeof(IPrintoutDocSvc).Name);
            Console.WriteLine("printoutDocServce type: " + printoutDocService.GetType());

            Assert.IsInstanceOf<PrintoutDocXSvcImpl>(printoutDocService, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestServiceFactoryPrintoutPDFSvc()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            ServiceFactory myServiceFactory = ServiceFactory.GetInstance();
            IPrintoutPDFSvc printoutPDFService = (IPrintoutPDFSvc)myServiceFactory.GetService(typeof(IPrintoutPDFSvc).Name);
            Console.WriteLine("printoutPDFService type: " + printoutPDFService.GetType());

            Assert.IsInstanceOf<PrintoutPDFSharpSvcImpl>(printoutPDFService, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestServiceFactorySavingSvc()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            ServiceFactory myServiceFactory = ServiceFactory.GetInstance();
            ISavingSvc savingService = (ISavingSvc)myServiceFactory.GetService(typeof(ISavingSvc).Name);
            Console.WriteLine("savingService type: " + savingService.GetType());

            Assert.IsInstanceOf<SavingJsonSvcImpl>(savingService, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }

        [Test]
        public void TestServiceFactoryScoringSvc()
        {
            Console.WriteLine("Inside " + GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            ServiceFactory myServiceFactory = ServiceFactory.GetInstance();
            IScoringSvc scoringService = (IScoringSvc)myServiceFactory.GetService(typeof(IScoringSvc).Name);
            Console.WriteLine(scoringService.GetType());

            Assert.IsInstanceOf<ScoringSvcImpl>(scoringService, GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Failed");
            Console.WriteLine(GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Passed");
        }
    }
}
