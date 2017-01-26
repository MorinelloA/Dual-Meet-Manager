using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain
{
    public class Event
    {

        //public Dictionary<Tuple<string, int>, List<Performance>> performances { get; set; }
        public string eventName { get; set; }
        public int heatNumber { get; set; }
        public List<Performance> performances { get; set; }

        //Default Constructor
        public Event() { }

        //Parameterized Constructor
        public Event(string eventName, int heatNumber, List<Performance> performances)
        {
            this.eventName = eventName;
            this.heatNumber = heatNumber;
            this.performances = performances;
        }

        //Meet with no performances
        public Event(string eventName, int heatNumber)
        {
            this.eventName = eventName;
            this.heatNumber = heatNumber;
        }

        public bool validate()
        {
            string[] validEvents = {"Boy's 100", "Boy's 200", "Boy's 400",
                    "Boy's 800", "Boy's 1600", "Boy's 3200", "Boy's 4x100",
                    "Boy's 4x400", "Boy's 4x800", "Boy's LJ", "Boy's TJ", "Boy's HJ",
                    "Boy's PV", "Boy's ShotPut", "Boy's Discus", "Boy's Javelin",
                    "Girl's 100", "Girl's 200", "Girl's 400",
                    "Girl's 800", "Girl's 1600", "Girl's 3200", "Girl's 4x100",
                    "Girl's 4x400", "Girl's 4x800", "Girl's LJ", "Girl's TJ", "Girl's HJ",
                    "Girl's PV", "Girl's ShotPut", "Girl's Discus", "Girl's Javelin"};

            //Check if the eventName is in validEvents
            if (!validEvents.Contains(eventName)) return false;
            else if (heatNumber <= 0) return false; //Must have a heat
            else if (performances != null) //This is allowed
            {
                foreach (Performance p in performances)
                    if (!p.validate()) return false;
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Event: " + eventName);
            foreach (Performance j in performances)
            {
                str.Append(Environment.NewLine + j.ToString());
            }
            return str.ToString();
        }

        public override bool Equals(object obj)
        {
            Event myEvent = obj as Event;
            if (myEvent == null) return false;
            else if (myEvent.eventName != eventName) return false;
            else if (myEvent.heatNumber != heatNumber) return false;
            else if (!myEvent.performances.SequenceEqual(performances)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + eventName.GetHashCode();
                hash = hash * 23 + heatNumber.GetHashCode();
                hash = hash * 23 + performances.GetHashCode();
                return hash;
            }
        }
    }
}
