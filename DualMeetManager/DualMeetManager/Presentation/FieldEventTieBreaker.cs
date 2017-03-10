using DualMeetManager.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DualMeetManager.Presentation
{
    public partial class FieldEventTieBreaker : Form
    {
        string team1, team2;
        List<Performance> perf = new List<Performance>();

        public FieldEventTieBreaker()
        {
            InitializeComponent();
        }

        public FieldEventTieBreaker(string t1, string t2, List<Performance> perf) : this()
        {
            team1 = t1;
            team2 = t2;
            this.perf = perf;
        }

        private void cboPlace1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPlace2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPlace3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPlace4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPlace5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPlace6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPlace7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPlace8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grpHeats1_Enter(object sender, EventArgs e)
        {

        }

        private void cboPlace9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
