using DualMeetManager.Domain;
using DualMeetManager.Domain.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Service.Scoring
{
    public interface IScoringSvc
    {
        /*Calculate Running Event
	    Calculate Field Event
	    Calculate Relay Event
	    Calculate Total*/
        IndEvent CalculateRunningEvent(List<Performance> perf);
        IndEvent CalculateFieldEvent(List<Performance> perf);
        RelayEvent CalculateRelayEvent(List<Performance> perf);
        OverallScore CalculateTotal(OverallScore scores, string Gender);

        OverallScore AddIndEvent(IndEvent eventToAdd);
        OverallScore AddRelayEvent(RelayEvent eventToAdd);
    }
}
