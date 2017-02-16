﻿using DualMeetManager.Business.Exceptions;
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
            IPrintoutPDFSvc printoutSvc = (IPrintoutPDFSvc)GetService(typeof(IPrintoutPDFSvc).Name);
            bool didPrint = printoutSvc.CreateIndEventPDF(eventName, performances);
            if (!didPrint)
                MessageBox.Show("Printout Failed!");
        }

        public void CreateTeamPerfPDF(string teamAbbr, Meet meetToPrint)
        {
            IPrintoutPDFSvc printoutSvc = (IPrintoutPDFSvc)GetService(typeof(IPrintoutPDFSvc).Name);
            bool didPrint = printoutSvc.CreateTeamPerfPDF(teamAbbr, meetToPrint);
            if (!didPrint)
                MessageBox.Show("Printout Failed!");
        }

        public void CreateMeetResultsPDF(OverallScore scoreToPrint)
        {
            IPrintoutPDFSvc printoutSvc = (IPrintoutPDFSvc)GetService(typeof(IPrintoutPDFSvc).Name);
            bool didPrint = printoutSvc.CreateMeetResultsPDF(scoreToPrint);
            if (!didPrint)
                MessageBox.Show("Printout Failed!");
        }

        public void CreateIndEventDoc(string eventName, List<Performance> performances)
        {
            IPrintoutDocSvc printoutSvc = (IPrintoutDocSvc)GetService(typeof(IPrintoutDocSvc).Name);
            bool didPrint = printoutSvc.CreateIndEventDoc(eventName, performances);
            if (!didPrint)
                MessageBox.Show("Printout Failed!");
        }

        public void CreateTeamPerfDoc(string teamAbbr, string gender, Meet meetToPrint)
        {
            IPrintoutDocSvc printoutSvc = (IPrintoutDocSvc)GetService(typeof(IPrintoutDocSvc).Name);
            bool didPrint = printoutSvc.CreateTeamPerfDoc(teamAbbr, gender, meetToPrint);
            if (!didPrint)
                MessageBox.Show("Printout Failed!");
        }

        public void CreateMeetResultsDoc(OverallScore scoreToPrint)
        {
            IPrintoutDocSvc printoutSvc = (IPrintoutDocSvc)GetService(typeof(IPrintoutDocSvc).Name);
            bool didPrint = printoutSvc.CreateMeetResultsDoc(scoreToPrint);
            if (!didPrint)
                MessageBox.Show("Printout Failed!");
        }
    }
}
