using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain
{
    class Meet
    {
        public DateTime dateOfMeet { get; set; }
        public string location { get; set; }
        public string weatherConditions { get; set; }
        public List<string> boySchoolNames { get; set; }
        public List<string> girlSchoolNames { get; set; }
        public List<string> boySchoolAbbr { get; set; }
        public List<string> girlSchoolAbbr { get; set; }
        public List<Event> events { get; set; }
    }
}
