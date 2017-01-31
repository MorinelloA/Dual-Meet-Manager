using DualMeetManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Service.DataEntry
{
    public interface IDataEntry
    {
        string ConvertToTimedData(decimal perf);
        decimal ConvertFromTimedData(string perf);

        string ConvertToLengthData(decimal perf);
        decimal ConvertFromLengthData(string perf);

        //IDictionary<string, List<Performance>> is the same as Meet.performances
        //Ex: <MEET NAME>.performances = AddPerformanceToEvent(NEW DICTIONARY) 
        IDictionary<string, List<Performance>> AddPerformanceToEvent(IDictionary<string, List<Performance>> perfList, string eventName, Performance perfToAdd);
        IDictionary<string, List<Performance>> DeleteEvent(string Event);
    }
}
