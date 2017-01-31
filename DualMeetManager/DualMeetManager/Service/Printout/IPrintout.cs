using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Service.Printout
{
    interface IPrintout
    {
        //Methods need Parameters
        void CreateIndEventPDF();
        void CreateTeamPerfPDF();
        void CreateMeetResultsPDF();

        void CreateIndEventDoc();
        void CreateTeamPerfDoc();
        void CreateMeetResultsDoc();
    }
}