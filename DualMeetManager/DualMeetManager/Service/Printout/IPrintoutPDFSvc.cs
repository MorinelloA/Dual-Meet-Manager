﻿using DualMeetManager.Domain;
using DualMeetManager.Domain.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Service.Printout
{
    public interface IPrintoutPDFSvc : IService
    {
        /// <summary>
        /// Interface for creating a PDF of individual event performances
        /// </summary>
        /// <param name="eventName">Name of the event for this printout</param>
        /// <param name="performances">List of performances for this printout</param>
        /// <returns>boolean that shows whether or not the PDF was created successfully or not</returns>
        bool CreateIndEventPDF(string eventName, List<Performance> performances);

        /// <summary>
        /// Interface for creating a PDF of all performances for one specific teams
        /// </summary>
        /// <param name="teamAbbr">Team to be printed</param>
        /// <param name="meetToPrint">Meet that the performances are being gathered from</param>
        /// <returns>boolean that shows whether or not the PDF was created successfully or not</returns>
        bool CreateTeamPerfPDF(string teamAbbr, Meet meetToPrint);

        /// <summary>
        /// Interface for creating a PDF for all scoring information for a Meet
        /// </summary>
        /// <param name="scoreToPrint">OverallScore information of the meet to be printed</param>
        /// <returns>boolean that shows whether or not the PDF was created successfully or not</returns>
        bool CreateMeetResultsPDF(OverallScore scoreToPrint);
    }
}
