using DualMeetManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Service.DataEntry
{
    public class DataEntryImpl : IDataEntry
    {
        public string ConvertToTimedData(decimal perf)
        {
            if (perf == 0m) return "";
            decimal TS, TM;
            TS = Math.Round(perf, 3);
            TM = 0;
            while (TS >= 60)
            {
                TM += 1;
                TS -= 60;
            }
            if (TM >= 1)
            {
                if (TS >= 10)
                {
                    return(TM + ":" + TS.ToString("0.###"));
                }
                else
                {
                    return(TM + ":0" + TS.ToString("0.###"));
                }
            }
            else
            {
                return (TS.ToString());
            }
        }

        /// <summary>
        /// Converts minutes and seconds (Ex: 2:15) in raw seconds (135)
        /// </summary>
        /// <param name="perf">String as minutes:seconds</param>
        /// <returns>raw data as total seconds</returns>
        /// <remarks>Needs further error handling for null or invalid strings</remarks>
        public decimal ConvertFromTimedData(string perf)
        {
            int divider = 0;
            for (int x = 0; x < perf.Length; x++)
            {
                if (perf[x] == ':')
                    divider = x;
            }
            if (divider != 0)
            {
                if (perf.Length > divider + 1)
                {
                    return (Math.Round(Convert.ToDecimal(perf.Substring(0, divider)) * 60 + Convert.ToDecimal(perf.Substring((divider + 1), ((perf.Length) - (divider + 1)))), 3));
                }
                else
                {
                    return (Math.Round(Convert.ToDecimal(perf.Substring(0, perf.Length - 1)) * 60, 3));
                }
            }
            else
                return(Math.Round(Convert.ToDecimal(perf.Substring(divider, perf.Length)), 3));
        }

        public string ConvertToLengthData(decimal perf)
        {
            if (perf == 0m) return "";
            decimal TS, TM;
            TS = Math.Round(perf, 3);
            TM = 0;
            while (TS >= 12)
            {
                TM += 1;
                TS -= 12;
            }
            if (TM >= 1)
            {
                if (TS >= 10)
                {
                    return (TM + "-" + TS.ToString("0.###"));
                }
                else
                {
                    return (TM + "-0" + TS.ToString("0.###"));
                }
            }
            else
            {
                return (TS.ToString());
            }
        }

        /// <summary>
        /// Converts feet and inches (Ex: 18-2.5) in raw inches (218.5)
        /// </summary>
        /// <param name="perf">String as feet-inches</param>
        /// <returns>raw data as total inches</returns>
        /// <remarks>Needs further error handling for null or invalid strings</remarks>
        public decimal ConvertFromLengthData(string perf)
        {
            int divider = 0;
            for (int x = 0; x < perf.Length; x++)
            {
                if (perf[x] == '-')
                    divider = x;
            }
            if (divider != 0)
            {
                if (perf.Length > divider + 1)
                {
                    return (Math.Round(Convert.ToDecimal(perf.Substring(0, divider)) * 12 + Convert.ToDecimal(perf.Substring((divider + 1), ((perf.Length) - (divider + 1)))), 3));
                }
                else
                {
                    return (Math.Round(Convert.ToDecimal(perf.Substring(0, perf.Length - 1)) * 12, 3));
                }
            }
            else
                return (Math.Round(Convert.ToDecimal(perf.Substring(divider, perf.Length)), 3));
        }

        public IDictionary<string, List<Performance>> AddPerformanceToEvent(IDictionary<string, List<Performance>> perfList, string eventName, Performance perfToAdd)
        {
            List<Performance> newPerfList = new List<Performance>();
            //This method is for adding a single performance, not a List

            if (perfList.ContainsKey(eventName))
            {
                //myDictionary[myKey] = myNewValue;
                //This is what I want to do, but the snytax is not correct
                //perfList.eventName.perflist.Add(perfToAdd);

                newPerfList = perfList[eventName];
                newPerfList.Add(perfToAdd);
                perfList[eventName] = newPerfList;
            }
            else
            {
                newPerfList.Add(perfToAdd);
                perfList.Add(eventName, newPerfList);
            }

            return perfList;
        }

        public IDictionary<string, List<Performance>> AddPerformanceToEvent(IDictionary<string, List<Performance>> perfList, string eventName, List<Performance> perfsToAdd)
        {
            perfList[eventName] = perfsToAdd;
            return perfList;
        }
    }
}
