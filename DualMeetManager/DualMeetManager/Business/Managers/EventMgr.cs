using DualMeetManager.Business.Exceptions;
using DualMeetManager.Service.DataEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Business.Managers
{
    public class EventMgr : Manager
    {
        public string ConvertToTimedData(decimal perf)
        {
            try
            {
                IDataEntrySvc dataEntrySvc = (IDataEntrySvc)GetService(typeof(IDataEntrySvc).Name);
                string timedData = dataEntrySvc.ConvertToTimedData(perf);
                return timedData;
            }
            catch (InvalidPerformanceException ipe)
            {
                Console.WriteLine("Error converting " + perf + " to timed data");
                Console.WriteLine(ipe.ToString());
                Console.Write(ipe.StackTrace);
                return "";
            }
        }

        public decimal ConvertFromTimedData(string perf)
        {
            try
            {
                IDataEntrySvc dataEntrySvc = (IDataEntrySvc)GetService(typeof(IDataEntrySvc).Name);
                decimal rawData = dataEntrySvc.ConvertFromTimedData(perf);
                return rawData;
            }
            catch (InvalidPerformanceException ipe)
            {
                Console.WriteLine("Error converting " + perf + " to raw data");
                Console.WriteLine(ipe.ToString());
                Console.Write(ipe.StackTrace);
                return 0m;
            }
        }

        public string ConvertToLengthData(decimal perf)
        {
            try
            {
                IDataEntrySvc dataEntrySvc = (IDataEntrySvc)GetService(typeof(IDataEntrySvc).Name);
                string lengthData = dataEntrySvc.ConvertToLengthData(perf);
                return lengthData;
            }
            catch (InvalidPerformanceException ipe)
            {
                Console.WriteLine("Error converting " + perf + " to length data");
                Console.WriteLine(ipe.ToString());
                Console.Write(ipe.StackTrace);
                return "";
            }
        }

        public decimal ConvertFromLengthData(string perf)
        {
            try
            {
                IDataEntrySvc dataEntrySvc = (IDataEntrySvc)GetService(typeof(IDataEntrySvc).Name);
                decimal rawData = dataEntrySvc.ConvertFromLengthData(perf);
                return rawData;
            }
            catch (InvalidPerformanceException ipe)
            {
                Console.WriteLine("Error converting " + perf + " to raw data");
                Console.WriteLine(ipe.ToString());
                Console.Write(ipe.StackTrace);
                return 0m;
            }
        }
    }
}
