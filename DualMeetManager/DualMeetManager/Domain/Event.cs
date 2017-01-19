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
    }
}
