using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DualMeetManager.Domain;
using DualMeetManager.Domain.Scoring;

namespace DualMeetManager.Service.Printout
{
    /// <summary>
    /// Implementation that uses the DocX library to generate Microsoft Word documents for Meet information
    /// </summary>
    public class PrintoutDocXSvcImpl : IPrintoutDocSvc
    {
        /// <summary>
        /// Implementation for creating a doc of individual event performances
        /// </summary>
        /// <param name="eventName">Name of the event for this printout</param>
        /// <param name="performances">List of performances for this printout</param>
        /// <returns>boolean that shows whether or not the doc was created successfully or not</returns>
        public bool CreateIndEventDoc(string eventName, List<Performance> performances)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implementation for creating a doc for all scoring information for a Meet
        /// </summary>
        /// <param name="scoreToPrint">OverallScore information of the meet to be printed</param>
        /// <returns>boolean that shows whether or not the doc was created successfully or not</returns>
        public bool CreateMeetResultsDoc(OverallScore scoreToPrint)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implementation for creating a doc of all performances for one specific teams
        /// </summary>
        /// <param name="teamAbbr">Team to be printed</param>
        /// <param name="meetToPrint">Meet that the performances are being gathered from</param>
        /// <returns>boolean that shows whether or not the doc was created successfully or not</returns>
        public bool CreateTeamPerfDoc(string teamAbbr, Meet meetToPrint)
        {
            throw new NotImplementedException();
        }
    }
}
