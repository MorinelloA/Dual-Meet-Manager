using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain
{
    class Performance
    {
        public string athleteName { get; set; }
        public string schoolName { get; set; }
        public decimal performance { get; set; }

        //Default Constructor
        public Performance(){ }

        //Parameterized Constructor
        public Performance(string athleteName, string schoolName, decimal performance)
        {
            this.athleteName = athleteName;
            this.schoolName = schoolName;
            this.performance = performance;
        }

        public override string ToString()
        {
            //This performance will be returned as raw data (seconds and inches)
            string str = "Name: " + athleteName + ", " + schoolName + " - " + performance;
            return str;
        }

        public override bool Equals(object obj)
        {
            Performance myPerf = obj as Performance;
            if (myPerf == null) return false;
            else if (myPerf.athleteName != athleteName) return false;
            else if (myPerf.schoolName != schoolName) return false;
            else if (myPerf.performance != performance) return false;
            else return true;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + athleteName.GetHashCode();
                hash = hash * 23 + schoolName.GetHashCode();
                hash = hash * 23 + performance.GetHashCode();
                return hash;
            }
        }
    }
}
