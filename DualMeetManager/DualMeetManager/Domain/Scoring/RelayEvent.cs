using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain.Scoring
{
    class RelayEvent
    {
        Tuple<string, string> team1 { get; set; }
        Tuple<string, string> team2 { get; set; }
        Tuple<int, int> points { get; set; }
    }
}
