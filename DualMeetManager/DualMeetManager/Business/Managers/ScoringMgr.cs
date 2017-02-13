using DualMeetManager.Domain;
using DualMeetManager.Domain.Scoring;
using DualMeetManager.Service.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Business.Managers
{
    public class ScoringMgr : Manager
    {
        public OverallScore CalculateTotal(OverallScore scores, string gender)
        {
            try
            {
                IScoringSvc scoringSvc = (IScoringSvc)GetService(typeof(IScoringSvc).Name);
                OverallScore os = scoringSvc.CalculateTotal(scores, gender);
                return os;
            }
            catch (Exception e) //Implement more specific Exceptions later
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
                return null;
            }
        }

        public OverallScore AddEvent(OverallScore scores, string eventName, IndEvent eventToAdd)
        {
            try
            {
                IScoringSvc scoringSvc = (IScoringSvc)GetService(typeof(IScoringSvc).Name);
                OverallScore os = scoringSvc.AddEvent(scores, eventName, eventToAdd);
                return os;
            }
            catch (Exception e) //Implement more specific Exceptions later
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
                return null;
            }
        }

        public OverallScore AddEvent(OverallScore scores, string eventName, RelayEvent eventToAdd)
        {
            try
            {
                IScoringSvc scoringSvc = (IScoringSvc)GetService(typeof(IScoringSvc).Name);
                OverallScore os = scoringSvc.AddEvent(scores, eventName, eventToAdd);
                return os;
            }
            catch (Exception e) //Implement more specific Exceptions later
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
                return null;
            }
        }
    }
}
