﻿using DualMeetManager.Domain.Scoring;
using DualMeetManager.Service.DataEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConvertToTimedData(30.1111m));
            Console.WriteLine(ConvertToTimedData(59.1111m));
            Console.WriteLine(ConvertToTimedData(60.1111m));
            Console.WriteLine(ConvertToTimedData(61.1111m));
            Console.WriteLine(ConvertToTimedData(70.1111m));

            Console.WriteLine(ConvertFromTimedData("10"));
            Console.WriteLine(ConvertFromTimedData("2:10"));
            Console.WriteLine(ConvertFromTimedData("0"));
            Console.WriteLine(ConvertFromTimedData("1:00"));
            Console.WriteLine(ConvertFromTimedData("1:01"));
        }

        public static string ConvertToTimedData(decimal perf)
        {
            if (perf == 0m) return "";
            decimal TS, TM;
            TS = Math.Round(perf, 3);
            TM = 0;
            while (TS >= 60)
            {
                TM = TM + 1;
                TS = Math.Round(TS - 60, 3);
            }
            if (TM >= 1)
            {
                if (TS >= 10)
                {
                    return (TM + ":" + TS);
                }
                else
                {
                    return (TM + ":0" + TS);
                }
            }
            else
            {
                return (TS.ToString());
            }
        }

        public static decimal ConvertFromTimedData(string perf)
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
                return (Math.Round(Convert.ToDecimal(perf.Substring(divider, perf.Length)), 3));
        }
    }
}
