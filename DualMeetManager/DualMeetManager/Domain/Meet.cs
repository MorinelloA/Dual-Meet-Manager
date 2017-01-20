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

        public override string ToString()
        {
            string str = "Date: " + String.Format("{0:MM/dd/yyyy}", dateOfMeet);
            str += Environment.NewLine + "Location: " + location;
            str += Environment.NewLine + "Weather Conditions: " + weatherConditions;
            str += Environment.NewLine + "Teams:";
            str += Environment.NewLine + "Boys:";

            for (int i = 0; i < boySchoolNames.Count; i++)
            {
                str += Environment.NewLine + boySchoolNames[i] + " - " + boySchoolAbbr[i];
            }

            for (int i = 0; i < girlSchoolNames.Count; i++)
            {
                str += Environment.NewLine + girlSchoolNames[i] + " - " + girlSchoolAbbr[i];
            }

            foreach (Event i in events)
            {
                str += Environment.NewLine + i.ToString();
            }

            return str;
        }

        public override bool Equals(object obj)
        {
            Meet myMeet = obj as Meet;
            if (myMeet == null) return false;
            else if (myMeet.location != location) return false;
            else if (myMeet.weatherConditions != weatherConditions) return false;
            else if (myMeet.boySchoolNames.SequenceEqual(boySchoolNames)) return false;
            else if (myMeet.girlSchoolNames.SequenceEqual(girlSchoolNames)) return false;
            else if (myMeet.boySchoolAbbr.SequenceEqual(boySchoolAbbr)) return false;
            else if (myMeet.girlSchoolAbbr.SequenceEqual(girlSchoolAbbr)) return false;
            else if (myMeet.events.SequenceEqual(events)) return false;

            else return true;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + location.GetHashCode();
                hash = hash * 23 + weatherConditions.GetHashCode();
                hash = hash * 23 + boySchoolNames.GetHashCode();
                hash = hash * 23 + girlSchoolNames.GetHashCode();
                hash = hash * 23 + boySchoolAbbr.GetHashCode();
                hash = hash * 23 + girlSchoolAbbr.GetHashCode();
                hash = hash * 23 + events.GetHashCode();
                return hash;
            }
        }
    }
}
