using DualMeetManager.Business.Exceptions;
using DualMeetManager.Domain;
using DualMeetManager.Domain.Scoring;
using DualMeetManager.Service.Printout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DualMeetManager.Business.Managers
{
    public class PrintoutMgr : Manager
    {
        public void CreateIndEventPDF(string eventName, List<Performance> performances)
        {
            try
            {
                IPrintoutPDFSvc printoutSvc = (IPrintoutPDFSvc)GetService(typeof(IPrintoutPDFSvc).Name);
                bool didPrint = printoutSvc.CreateIndEventPDF(eventName, performances);
                if (!didPrint)
                    MessageBox.Show("Printout Failed!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception in PrintoutMgr: CreateIndEventPDF: " + e);
                MessageBox.Show("Printout Failed!");
            }
        }

        public void CreateTeamPerfPDF(string teamAbbr, Meet meetToPrint)
        {
            try
            {
                IPrintoutPDFSvc printoutSvc = (IPrintoutPDFSvc)GetService(typeof(IPrintoutPDFSvc).Name);
                bool didPrint = printoutSvc.CreateTeamPerfPDF(teamAbbr, meetToPrint);
                if (!didPrint)
                    MessageBox.Show("Printout Failed!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in PrintoutMgr: CreateTeamPerfPDF: " + e);
                MessageBox.Show("Printout Failed!");
            }
        }

        public void CreateMeetResultsPDF(OverallScore scoreToPrint)
        {
            try
            {
                IPrintoutPDFSvc printoutSvc = (IPrintoutPDFSvc)GetService(typeof(IPrintoutPDFSvc).Name);
                bool didPrint = printoutSvc.CreateMeetResultsPDF(scoreToPrint);
                if (!didPrint)
                    MessageBox.Show("Printout Failed!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in PrintoutMgr: CreateMeetResultsPDF: " + e);
                MessageBox.Show("Printout Failed!");
            }
        }

        public void CreateIndEventDoc(string eventName, List<Performance> performances)
        {
            try
            {
                IPrintoutDocSvc printoutSvc = (IPrintoutDocSvc)GetService(typeof(IPrintoutDocSvc).Name);
                bool didPrint = printoutSvc.CreateIndEventDoc(eventName, performances);
                if (!didPrint)
                    MessageBox.Show("Printout Failed!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in PrintoutMgr: CreateIndEventDoc: " + e);
                MessageBox.Show("Printout Failed!");
            }
        }

        public void CreateTeamPerfDoc(string teamAbbr, string gender, Meet meetToPrint)
        {
            try
            {
                IPrintoutDocSvc printoutSvc = (IPrintoutDocSvc)GetService(typeof(IPrintoutDocSvc).Name);
                bool didPrint = printoutSvc.CreateTeamPerfDoc(teamAbbr, gender, meetToPrint);
                if (!didPrint)
                    MessageBox.Show("Printout Failed!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in PrintoutMgr: CreateTeamPerfDoc: " + e);
                MessageBox.Show("Printout Failed!");
            }
        }

        public void CreateMeetResultsDoc(string gender, DateTime dt, string location, OverallScore scoreToPrint)
        {
            try
            {
                IPrintoutDocSvc printoutSvc = (IPrintoutDocSvc)GetService(typeof(IPrintoutDocSvc).Name);
                bool didPrint = printoutSvc.CreateMeetResultsDoc(gender, dt, location, scoreToPrint);
                if (!didPrint)
                    MessageBox.Show("Printout Failed!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in PrintoutMgr: CreateMeetResultsDoc: " + e);
                MessageBox.Show("Printout Failed!");
            }
        }
    }
}
