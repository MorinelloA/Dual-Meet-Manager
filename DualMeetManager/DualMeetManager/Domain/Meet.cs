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

        //Default Constructor
        public Meet() { }

        //Constructor used for a new meet
        public Meet(DateTime dateOfMeet, string location, string weatherConditions, List<string> boySchoolNames,
            List<string> girlSchoolNames, List<string> boySchoolAbbr, List<string> girlSchoolAbbr)
        {
            this.dateOfMeet = dateOfMeet;
            this.location = location;
            this.weatherConditions = weatherConditions;
            this.boySchoolNames = boySchoolNames;
            this.girlSchoolNames = girlSchoolNames;
            this.boySchoolAbbr = boySchoolAbbr;
            this.girlSchoolAbbr = girlSchoolAbbr;
        }

        //Constructor used for an existing meet
        public Meet(DateTime dateOfMeet, string location, string weatherConditions, List<string> boySchoolNames,
            List<string> girlSchoolNames, List<string> boySchoolAbbr, List<string> girlSchoolAbbr, List<Event> events)
        {
            this.dateOfMeet = dateOfMeet;
            this.location = location;
            this.weatherConditions = weatherConditions;
            this.boySchoolNames = boySchoolNames;
            this.girlSchoolNames = girlSchoolNames;
            this.boySchoolAbbr = boySchoolAbbr;
            this.girlSchoolAbbr = girlSchoolAbbr;
            this.events = events;
        }
    }
}
