using DualMeetManager.Service.DataEntry;
using DualMeetManager.Service.Printout;
using DualMeetManager.Service.Saving;
using DualMeetManager.Service.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Service
{
    public class Factory
    {
        public IDataEntrySvc GetDataEntrySvc()
        {
            return new DataEntrySvcImpl();
        }

        public IPrintoutDocSvc GetPrintoutDocSvc()
        {
            return new PrintoutDocXSvcImpl();
        }

        public IPrintoutPDFSvc GetPrintoutPDFSvc()
        {
            return new PrintoutPDFSharpSvcImpl();
        }

        public ISavingSvc GetSavingSvc()
        {
            return new SavingJsonSvcImpl();
        }

        public IScoringSvc GetScoringSvc()
        {
            return new ScoringSvcImpl();
        }

    }
}
