using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain
{
    public class Meet
    {
        public DateTime dateOfMeet { get; set; }
        public string location { get; set; }
        public string weatherConditions { get; set; }
        public Teams schoolNames { get; set; }
        //The Dictionary key Tuple is <Event Name, Heat # of that Event>
        public Dictionary<Tuple<string, int>, List<Performance>> performances { get; set; }

        //Default Constructor
        public Meet() { }

        //Constructor used for a new meet
        public Meet(DateTime dateOfMeet, string location, string weatherConditions, Teams schoolNames)
        {
            this.dateOfMeet = dateOfMeet;
            this.location = location;
            this.weatherConditions = weatherConditions;
            this.schoolNames = schoolNames;
        }

        //Constructor used for an existing meet
        public Meet(DateTime dateOfMeet, string location, string weatherConditions, Teams schoolNames, Dictionary<Tuple<string, int>, List<Performance>> performances)
        {
            this.dateOfMeet = dateOfMeet;
            this.location = location;
            this.weatherConditions = weatherConditions;
            this.schoolNames = schoolNames;
            this.performances = performances;
        }

        public bool validate()
        {
            if (dateOfMeet == DateTime.MinValue) return false; //Invalid Date
            else if (string.IsNullOrWhiteSpace(location)) return false; //No location given
            else if (string.IsNullOrWhiteSpace(weatherConditions)) return false; //No Weather conditions given
            else if (schoolNames == null) return false; //No school names
            else if (!schoolNames.validate()) return false; //Invalid school names

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
                foreach (KeyValuePair<Tuple<string, int>, List<Performance>> i in performances)
                {
                    //If the key is not a valid event
                    if (!validEvents.Any(i.Key.Item1.Contains)) return false;
                }

                //foreach(Event i in events)
                foreach (KeyValuePair<Tuple<string, int>, List<Performance>> i in performances)
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
            str.Append(Environment.NewLine + schoolNames.ToString());
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
            foreach (KeyValuePair<Tuple<string, int>, List<Performance>> i in performances)
            {
                str.Append(Environment.NewLine + "Event: " + i.Key.Item1.ToString());
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
            else if (!myMeet.schoolNames.Equals(schoolNames)) return false;
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
                hash = hash * 23 + dateOfMeet.GetHashCode();
                hash = hash * 23 + location.GetHashCode();
                hash = hash * 23 + weatherConditions.GetHashCode();
                hash = hash * 23 + schoolNames.GetHashCode();
                hash = hash * 23 + performances.GetHashCode();
                return hash;
            }
        }

        public bool AddPerformance(string eventName, int heatNumber, List<Performance> pta)
        {
            string name = "";
            int heat = 0;
            foreach (KeyValuePair<Tuple<string, int>, List<Performance>> p in performances) //Goes through every event/heat combo
            {
                if(p.Key.Item1 == eventName) //Checks for event
                {
                    name = p.Key.Item1;
                    if (p.Key.Item2 == heatNumber) //Check if heat # exists
                    {                        
                        heat = p.Key.Item2;
                        break;
                    }
                }
            }
            if(!string.IsNullOrWhiteSpace(name)) //Event already exists
            {
                if(heat != 0) //Heat already exists
                {
                    performances[Tuple.Create(name, heat)] = pta; 
                }
                else //New heat
                {
                    performances[Tuple.Create(name, heatNumber)] = pta;
                }
            }
            else //Event is new
            {
                performances[Tuple.Create(eventName, heatNumber)] = pta;
            }
            return true;
        }
    }
}