using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager.Domain
{
    public class Teams
    {
        public Dictionary<string, string> boySchoolNames { get; set; }
        public Dictionary<string, string> girlSchoolNames { get; set; }

        public Teams() { }

        public Teams(Dictionary<string, string> boySchoolNames, Dictionary<string, string> girlSchoolNames)
        {
            this.boySchoolNames = boySchoolNames;
            this.girlSchoolNames = girlSchoolNames;
        }

        public bool validate()
        {
            if (boySchoolNames == null && girlSchoolNames == null) return false; //Must have either a boy or girl team
            else if (boySchoolNames.Keys.Count() != boySchoolNames.Keys.Distinct().Count()) return false; //Duplicates Exist
            else if (boySchoolNames.Values.Count() != boySchoolNames.Values.Distinct().Count()) return false; //Duplicates Exist
            else if (girlSchoolNames.Keys.Count() != girlSchoolNames.Keys.Distinct().Count()) return false; //Duplicates Exist
            else if (girlSchoolNames.Values.Count() != girlSchoolNames.Values.Distinct().Count()) return false; //Duplicates Exist

            foreach (KeyValuePair<string, string> i in boySchoolNames)
            {
                if (string.IsNullOrWhiteSpace(i.Key)) return false;
                else if (string.IsNullOrWhiteSpace(i.Value)) return false;
                else if (i.Key.Length > 3) return false;
            }

            foreach (KeyValuePair<string, string> i in girlSchoolNames)
            {
                if (string.IsNullOrWhiteSpace(i.Key)) return false;
                else if (string.IsNullOrWhiteSpace(i.Value)) return false;
                else if (i.Key.Length > 3) return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Teams:");
            sb.Append(Environment.NewLine + "Boys:");
            foreach (KeyValuePair<string, string> i in boySchoolNames)
            {
                sb.Append(Environment.NewLine + i.Value + " - " + i.Key);
            }

            sb.Append(Environment.NewLine + "Girls:");
            foreach (KeyValuePair<string, string> i in girlSchoolNames)
            {
                sb.Append(Environment.NewLine + i.Value + " - " + i.Key);
            }

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            Teams myTeams = obj as Teams;
            if (myTeams.boySchoolNames == null && boySchoolNames != null) return false;
            else if (myTeams.boySchoolNames != null && boySchoolNames == null) return false;
            else if (myTeams.girlSchoolNames == null && girlSchoolNames != null) return false;
            else if (myTeams.girlSchoolNames != null && girlSchoolNames == null) return false;
            else if (myTeams.boySchoolNames == null && boySchoolNames == null && myTeams.girlSchoolNames == null && girlSchoolNames == null) return true;
            else if (!myTeams.boySchoolNames.OrderBy(r => r.Key).SequenceEqual(boySchoolNames.OrderBy(r => r.Key))) return false;
            else if (!myTeams.girlSchoolNames.OrderBy(r => r.Key).SequenceEqual(girlSchoolNames.OrderBy(r => r.Key))) return false;
            return true;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + boySchoolNames.GetHashCode();
                hash = hash * 23 + girlSchoolNames.GetHashCode();
                return hash;
            }
        }
    }
}
