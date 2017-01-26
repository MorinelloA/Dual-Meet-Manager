using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Update namespace
namespace DualMeetManager.Domain
{
    public class Performance
    {
        public string athleteName { get; set; }
        public string schoolName { get; set; }
        public int heatNum { get; set; }
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

        //Constructor with heatNum
        public Performance(string athleteName, string schoolName, int heatNum, decimal performance) {
            this.athleteName = athleteName;
            this.schoolName = schoolName;
            this.heatNum = heatNum;
            this.performance = performance;
        }

        public bool validate()
        {
            if (string.IsNullOrWhiteSpace(athleteName)) return false; //Must have a name
            else if (string.IsNullOrWhiteSpace(schoolName)) return false; //Must have a school
            else if (performance <= 0) return false; //Valid time or distance is positive
            return true;
        }

        public override string ToString()
        {
            //This performance will be returned as raw data (seconds and inches)

            if (heatNum == 0)
                return "Name: " + athleteName + ", " + schoolName + " - " + performance;
            else
                return "Name: " + athleteName + ", " + schoolName + " - Heat " + heatNum + " - " + performance;
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
                hash = hash * 23 + heatNum.GetHashCode();
                hash = hash * 23 + performance.GetHashCode();
                return hash;
            }
        }
    }
}
