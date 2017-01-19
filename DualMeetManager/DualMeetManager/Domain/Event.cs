using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain
{
    class Event
    {
        public string name { get; set; }
        public List<Performance> preformances { get; set; }
    }
}
