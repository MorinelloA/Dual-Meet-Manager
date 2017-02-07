using DualMeetManager.Domain;
using DualMeetManager.Domain.Scoring;
using System.Collections.Generic;

namespace DualMeetManager.Service.Printout
{
    public interface IPrintoutSvc
    {
        
        bool CreateIndEventPDF(string eventName, List<Performance> performances);
        bool CreateTeamPerfPDF(string teamAbbr, Meet meetToPrint);
        bool CreateMeetResultsPDF(OverallScore scoreToPrint);

        bool CreateIndEventDoc(string eventName, List<Performance> performances);
        bool CreateTeamPerfDoc(string teamAbbr, Meet meetToPrint);
        bool CreateMeetResultsDoc(OverallScore scoreToPrint);
    }
}