using DualMeetManager.Domain;
using DualMeetManager.Domain.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Service.Printout
{
    public interface IPrintoutSvc
    {
        //Methods need Parameters
        bool CreateIndEventPDF(string eventName, List<Performance> performances);
        bool CreateTeamPerfPDF(string teamAbbr, Meet meetToPrint);
        bool CreateMeetResultsPDF(OverallScore scoreToPrint);

        bool CreateIndEventDoc(string eventName, List<Performance> performances);
        bool CreateTeamPerfDoc(string teamAbbr, Meet meetToPrint);
        bool CreateMeetResultsDoc(OverallScore scoreToPrint);
    }
}