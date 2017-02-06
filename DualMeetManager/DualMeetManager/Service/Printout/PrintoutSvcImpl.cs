using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DualMeetManager.Domain;
using DualMeetManager.Domain.Scoring;

namespace DualMeetManager.Service.Printout
{
    public class PrintoutSvcImpl : IPrintoutSvc
    {
        public bool CreateIndEventDoc(string eventName, List<Performance> performances)
        {
            throw new NotImplementedException();
        }

        public bool CreateIndEventPDF(string eventName, List<Performance> performances)
        {
            throw new NotImplementedException();
        }

        public bool CreateMeetResultsDoc(OverallScore scoreToPrint)
        {
            throw new NotImplementedException();
        }

        public bool CreateMeetResultsPDF(OverallScore scoreToPrint)
        {
            throw new NotImplementedException();
        }

        public bool CreateTeamPerfDoc(string teamAbbr, Meet meetToPrint)
        {
            throw new NotImplementedException();
        }

        public bool CreateTeamPerfPDF(string teamAbbr, Meet meetToPrint)
        {
            throw new NotImplementedException();
        }
    }
}
