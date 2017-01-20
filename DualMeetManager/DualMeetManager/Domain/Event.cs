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
        public List<Performance> performances { get; set; }

        //Default Constructor
        public Event() { }

        //Parameterized Constructor
        public Event(string name, List<Performance> performances)
        {
            this.name = name;
            this.performances = performances;
        }

        public override string ToString()
        {
            string str = "Event: " + name;

            foreach(Performance i in performances)
            {
                str += Environment.NewLine + i.ToString();
            }
            
            return str;
        }

        public override bool Equals(object obj)
        {
            Event myEvent = obj as Event;
            if (myEvent == null) return false;
            else if (myEvent.name != name) return false;
            else if (myEvent.performances.SequenceEqual(performances)) return false;
            else return true;
        }

        //Setup found at this link:
        //http://www.loganfranken.com/blog/692/overriding-equals-in-c-part-2/
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + name.GetHashCode();
                hash = hash * 23 + performances.GetHashCode();
                return hash;
            }
        }
    }
}
