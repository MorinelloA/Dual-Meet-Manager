using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain.Scoring
{
    class OverallScore
    {
        Dictionary<string, List<IndEvent>> individualEvents;
        Dictionary<string, List<IndEvent>> relayEvents;
    }
}
