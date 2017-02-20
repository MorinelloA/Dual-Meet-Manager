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
    public partial class MeetHub : Form
    {
        public MeetHub()
        {
            InitializeComponent();
        }

        Meet activeMeet;

        public MeetHub(Meet activeMeet) : this()
        {
            this.activeMeet = activeMeet;
        }


        private void MeetHub_Load(object sender, EventArgs e)
        {
            MessageBox.Show(activeMeet.location);
        }
    }
}
