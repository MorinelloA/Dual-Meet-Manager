using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.src.com.dualmeetmanager.model.domain
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
        public Dictionary<string, List<Performance>> performances { get; set; }

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
            List<string> girlSchoolNames, List<string> boySchoolAbbr, List<string> girlSchoolAbbr, Dictionary<string, List<Performance>> performances)
        {
            this.dateOfMeet = dateOfMeet;
            this.location = location;
            this.weatherConditions = weatherConditions;
            this.boySchoolNames = boySchoolNames;
            this.girlSchoolNames = girlSchoolNames;
            this.boySchoolAbbr = boySchoolAbbr;
            this.girlSchoolAbbr = girlSchoolAbbr;
            this.performances = performances;
        }

        public bool validate()
        {
            if (dateOfMeet == DateTime.MinValue) return false; //Invalid Date
            else if (string.IsNullOrWhiteSpace(location)) return false; //No location given
            else if (string.IsNullOrWhiteSpace(weatherConditions)) return false; //No Weather conditions given
            else if (boySchoolNames == null && girlSchoolNames == null) return false; //No school names
            else if (boySchoolAbbr == null && girlSchoolAbbr == null) return false; //No school abbr
            else if (boySchoolNames.Count != boySchoolNames.Distinct().Count()) return false; //Duplicates Exist
            else if (girlSchoolNames.Count != girlSchoolNames.Distinct().Count()) return false; //Duplicates Exist
            else if (boySchoolAbbr.Count != boySchoolAbbr.Distinct().Count()) return false; //Duplicates Exist
            else if (girlSchoolAbbr.Count != girlSchoolAbbr.Distinct().Count()) return false; //Duplicates Exist
            else if (boySchoolNames.Count != boySchoolAbbr.Count) return false; //Names and Abbr aren't equal
            else if (girlSchoolNames.Count != girlSchoolAbbr.Count) return false; //Names and Abbr aren't equal

            foreach (string i in boySchoolNames)
            {
                if (string.IsNullOrWhiteSpace(i)) return false; //Empty name
            }

            foreach (string i in girlSchoolNames)
            {
                if (string.IsNullOrWhiteSpace(i)) return false; //Empty name
            }

            foreach (string i in boySchoolAbbr)
            {
                if (i.Length > 3) return false; //Abbreviations need to be limited to 3 characters
                if (string.IsNullOrWhiteSpace(i)) return false; //Empty abbr
            }

            foreach (string i in girlSchoolAbbr)
            {
                if (i.Length > 3) return false; //Abbreviations need to be limited to 3 characters
                if (string.IsNullOrWhiteSpace(i)) return false; //Empty abbr
            }

            if (performances != null) //This is allowed
            {
                //Check for incorrect event name
                //Array with valid event names
                string[] validEvents = {"Boy's 100", "Boy's 200", "Boy's 400",
                    "Boy's 800", "Boy's 1600", "Boy's 3200", "Boy's 4x100",
                    "Boy's 4x400", "Boy's 4x800", "Boy's LJ", "Boy's TJ", "Boy's HJ",
                    "Boy's PV", "Boy's ShotPut", "Boy's Discus", "Boy's Javelin",
                    "Girl's 100", "Girl's 200", "Girl's 400",
                    "Girl's 800", "Girl's 1600", "Girl's 3200", "Girl's 4x100",
                    "Girl's 4x400", "Girl's 4x800", "Girl's LJ", "Girl's TJ", "Girl's HJ",
                    "Girl's PV", "Girl's ShotPut", "Girl's Discus", "Girl's Javelin"};
                foreach (KeyValuePair<string, List<Performance>> i in performances)
                {
                    //If the key is not a valid event
                    if (!validEvents.Any(i.Key.Contains)) return false;
                }

                //foreach(Event i in events)
                foreach (KeyValuePair<string, List<Performance>> i in performances)
                {
                    foreach(Performance j in i.Value)
                        if (!j.validate()) return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Date: " + String.Format("{0:MM/dd/yyyy}", dateOfMeet));
            str.Append(Environment.NewLine + "Location: " + location);
            str.Append(Environment.NewLine + "Weather Conditions: " + weatherConditions);

            //Replace the code below with Teams.ToString() method
            /*
            str.Append(Environment.NewLine + "Teams:");
            
            str.Append(Environment.NewLine + "Boys:");

            for (int i = 0; i < boySchoolNames.Count; i++)
            {
                str.Append(Environment.NewLine + boySchoolNames[i] + " - " + boySchoolAbbr[i]);
            }

            str.Append(Environment.NewLine + "Girls:");
            for (int i = 0; i < girlSchoolNames.Count; i++)
            {
                str.Append(Environment.NewLine + girlSchoolNames[i] + " - " + girlSchoolAbbr[i]);
            }*/

            //foreach (Performance i in performances)
            foreach (KeyValuePair<string, List<Performance>> i in performances)
            {
                str.Append(Environment.NewLine + "Event: " + i.Key.ToString());
                foreach (Performance j in i.Value)
                {
                    str.Append(Environment.NewLine + j.ToString());
                }
            }

            return str.ToString();
        }

        public override bool Equals(object obj)
        {
            Meet myMeet = obj as Meet;
            if (myMeet == null) return false;
            else if (!myMeet.dateOfMeet.Equals(dateOfMeet)) return false;
            else if (myMeet.location != location) return false;
            else if (myMeet.weatherConditions != weatherConditions) return false;
            else if (!myMeet.boySchoolNames.SequenceEqual(boySchoolNames)) return false;
            else if (!myMeet.girlSchoolNames.SequenceEqual(girlSchoolNames)) return false;
            else if (!myMeet.boySchoolAbbr.SequenceEqual(boySchoolAbbr)) return false;
            else if (!myMeet.girlSchoolAbbr.SequenceEqual(girlSchoolAbbr)) return false;
            else if (myMeet.performances == null && performances == null) return true; //events could be null
            else if (myMeet.performances == null && performances != null) return false;
            else if (myMeet.performances != null && performances == null) return false;
            else if (!myMeet.performances.OrderBy(r => r.Key).SequenceEqual(performances.OrderBy(r => r.Key))) return false;
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
                hash = hash * 23 + performances.GetHashCode();
                return hash;
            }
        }
    }
}