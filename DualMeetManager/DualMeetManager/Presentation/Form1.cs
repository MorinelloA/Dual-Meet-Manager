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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmdCreateMeet_Click(object sender, EventArgs e)
        {
            if (txtLocation.Text == "")
            {
                MessageBox.Show("Please enter a location", "Invalid Data");
            }
            else if (cboWeather.Text == "")
            {
                MessageBox.Show("Please enter weather conditions", "Invalid Data");
            }
            else if(string.IsNullOrWhiteSpace(txtBoysTeam1Name.Text) || string.IsNullOrWhiteSpace(txtBoysTeam1Abbr.Text))
            {
                MessageBox.Show("Please enter team name information for boy's team #1", "Invalid Data");
            }
            else if ((string.IsNullOrWhiteSpace(txtBoysTeam2Name.Text) && !string.IsNullOrWhiteSpace(txtBoysTeam2Abbr.Text)) || (!string.IsNullOrWhiteSpace(txtBoysTeam2Name.Text) && string.IsNullOrWhiteSpace(txtBoysTeam2Abbr.Text)))
            {
                MessageBox.Show("Invalid name information for boy's team #2", "Invalid Data");
            }
            else if ((string.IsNullOrWhiteSpace(txtBoysTeam3Name.Text) && !string.IsNullOrWhiteSpace(txtBoysTeam3Abbr.Text)) || (!string.IsNullOrWhiteSpace(txtBoysTeam3Name.Text) && string.IsNullOrWhiteSpace(txtBoysTeam3Abbr.Text)))
            {
                MessageBox.Show("Invalid name information for boy's team #3", "Invalid Data");
            }
            else if ((string.IsNullOrWhiteSpace(txtBoysTeam4Name.Text) && !string.IsNullOrWhiteSpace(txtBoysTeam4Abbr.Text)) || (!string.IsNullOrWhiteSpace(txtBoysTeam4Name.Text) && string.IsNullOrWhiteSpace(txtBoysTeam4Abbr.Text)))
            {
                MessageBox.Show("Invalid name information for boy's team #4", "Invalid Data");
            }
            else if ((string.IsNullOrWhiteSpace(txtBoysTeam5Name.Text) && !string.IsNullOrWhiteSpace(txtBoysTeam5Abbr.Text)) || (!string.IsNullOrWhiteSpace(txtBoysTeam5Name.Text) && string.IsNullOrWhiteSpace(txtBoysTeam5Abbr.Text)))
            {
                MessageBox.Show("Invalid name information for boy's team #5", "Invalid Data");
            }
            else if ((string.IsNullOrWhiteSpace(txtBoysTeam6Name.Text) && !string.IsNullOrWhiteSpace(txtBoysTeam6Abbr.Text)) || (!string.IsNullOrWhiteSpace(txtBoysTeam6Name.Text) && string.IsNullOrWhiteSpace(txtBoysTeam6Abbr.Text)))
            {
                MessageBox.Show("Invalid name information for boy's team #6", "Invalid Data");
            }
            else if (string.IsNullOrWhiteSpace(txtGirlsTeam1Name.Text) || string.IsNullOrWhiteSpace(txtGirlsTeam1Abbr.Text))
            {
                MessageBox.Show("Please enter team name information for girl's team #1", "Invalid Data");
            }
            else if ((string.IsNullOrWhiteSpace(txtGirlsTeam2Name.Text) && !string.IsNullOrWhiteSpace(txtGirlsTeam2Abbr.Text)) || (!string.IsNullOrWhiteSpace(txtGirlsTeam2Name.Text) && string.IsNullOrWhiteSpace(txtGirlsTeam2Abbr.Text)))
            {
                MessageBox.Show("Invalid name information for girl's team #2", "Invalid Data");
            }
            else if ((string.IsNullOrWhiteSpace(txtGirlsTeam3Name.Text) && !string.IsNullOrWhiteSpace(txtGirlsTeam3Abbr.Text)) || (!string.IsNullOrWhiteSpace(txtGirlsTeam3Name.Text) && string.IsNullOrWhiteSpace(txtGirlsTeam3Abbr.Text)))
            {
                MessageBox.Show("Invalid name information for girl's team #3", "Invalid Data");
            }
            else if ((string.IsNullOrWhiteSpace(txtGirlsTeam4Name.Text) && !string.IsNullOrWhiteSpace(txtGirlsTeam4Abbr.Text)) || (!string.IsNullOrWhiteSpace(txtGirlsTeam4Name.Text) && string.IsNullOrWhiteSpace(txtGirlsTeam4Abbr.Text)))
            {
                MessageBox.Show("Invalid name information for girl's team #4", "Invalid Data");
            }
            else if ((string.IsNullOrWhiteSpace(txtGirlsTeam5Name.Text) && !string.IsNullOrWhiteSpace(txtGirlsTeam5Abbr.Text)) || (!string.IsNullOrWhiteSpace(txtGirlsTeam5Name.Text) && string.IsNullOrWhiteSpace(txtGirlsTeam5Abbr.Text)))
            {
                MessageBox.Show("Invalid name information for girl's team #5", "Invalid Data");
            }
            else if ((string.IsNullOrWhiteSpace(txtGirlsTeam6Name.Text) && !string.IsNullOrWhiteSpace(txtGirlsTeam6Abbr.Text)) || (!string.IsNullOrWhiteSpace(txtGirlsTeam6Name.Text) && string.IsNullOrWhiteSpace(txtGirlsTeam6Abbr.Text)))
            {
                MessageBox.Show("Invalid name information for girl's team #6", "Invalid Data");
            }
            else
            {

                string meetLocation = txtLocation.Text;
                DateTime meetDateTime = dtpMeetDate.Value;
                string meetWeather = cboWeather.Text;
                string boysTeam1Abbr = txtBoysTeam1Abbr.Text.Trim();
                string boysTeam1Name = txtBoysTeam1Name.Text.Trim();
                string boysTeam2Abbr = txtBoysTeam2Abbr.Text.Trim();
                string boysTeam2Name = txtBoysTeam2Name.Text.Trim();
                string boysTeam3Abbr = txtBoysTeam3Abbr.Text.Trim();
                string boysTeam3Name = txtBoysTeam3Name.Text.Trim();
                string boysTeam4Abbr = txtBoysTeam4Abbr.Text.Trim();
                string boysTeam4Name = txtBoysTeam4Name.Text.Trim();
                string boysTeam5Abbr = txtBoysTeam5Abbr.Text.Trim();
                string boysTeam5Name = txtBoysTeam5Name.Text.Trim();
                string boysTeam6Abbr = txtBoysTeam6Abbr.Text.Trim();
                string boysTeam6Name = txtBoysTeam6Name.Text.Trim();
                string girlsTeam1Abbr = txtGirlsTeam1Abbr.Text.Trim();
                string girlsTeam1Name = txtGirlsTeam1Name.Text.Trim();
                string girlsTeam2Abbr = txtGirlsTeam2Abbr.Text.Trim();
                string girlsTeam2Name = txtGirlsTeam2Name.Text.Trim();
                string girlsTeam3Abbr = txtGirlsTeam3Abbr.Text.Trim();
                string girlsTeam3Name = txtGirlsTeam3Name.Text.Trim();
                string girlsTeam4Abbr = txtGirlsTeam4Abbr.Text.Trim();
                string girlsTeam4Name = txtGirlsTeam4Name.Text.Trim();
                string girlsTeam5Abbr = txtGirlsTeam5Abbr.Text.Trim();
                string girlsTeam5Name = txtGirlsTeam5Name.Text.Trim();
                string girlsTeam6Abbr = txtGirlsTeam6Abbr.Text.Trim();
                string girlsTeam6Name = txtGirlsTeam6Name.Text.Trim();

                List<string> boysNames = new List<string>();
                if(!string.IsNullOrWhiteSpace(boysTeam1Name))
                    boysNames.Add(boysTeam1Name);
                if (!string.IsNullOrWhiteSpace(boysTeam2Name))
                    boysNames.Add(boysTeam2Name);
                if (!string.IsNullOrWhiteSpace(boysTeam3Name))
                    boysNames.Add(boysTeam3Name);
                if (!string.IsNullOrWhiteSpace(boysTeam4Name))
                    boysNames.Add(boysTeam4Name);
                if (!string.IsNullOrWhiteSpace(boysTeam5Name))
                    boysNames.Add(boysTeam5Name);
                if (!string.IsNullOrWhiteSpace(boysTeam6Name))
                    boysNames.Add(boysTeam6Name);

                List<string> boysAbbrs = new List<string>();
                if (!string.IsNullOrWhiteSpace(boysTeam1Abbr))
                    boysAbbrs.Add(boysTeam1Abbr);
                if (!string.IsNullOrWhiteSpace(boysTeam2Abbr))
                    boysAbbrs.Add(boysTeam2Abbr);
                if (!string.IsNullOrWhiteSpace(boysTeam3Abbr))
                    boysAbbrs.Add(boysTeam3Abbr);
                if (!string.IsNullOrWhiteSpace(boysTeam4Abbr))
                    boysAbbrs.Add(boysTeam4Abbr);
                if (!string.IsNullOrWhiteSpace(boysTeam5Abbr))
                    boysAbbrs.Add(boysTeam5Abbr);
                if (!string.IsNullOrWhiteSpace(boysTeam6Abbr))
                    boysAbbrs.Add(boysTeam6Abbr);

                List<string> girlsNames = new List<string>();
                if (!string.IsNullOrWhiteSpace(girlsTeam1Name))
                    girlsNames.Add(girlsTeam1Name);
                if (!string.IsNullOrWhiteSpace(girlsTeam2Name))
                    girlsNames.Add(girlsTeam2Name);
                if (!string.IsNullOrWhiteSpace(girlsTeam3Name))
                    girlsNames.Add(girlsTeam3Name);
                if (!string.IsNullOrWhiteSpace(girlsTeam4Name))
                    girlsNames.Add(girlsTeam4Name);
                if (!string.IsNullOrWhiteSpace(girlsTeam5Name))
                    girlsNames.Add(girlsTeam5Name);
                if (!string.IsNullOrWhiteSpace(girlsTeam6Name))
                    girlsNames.Add(girlsTeam6Name);

                List<string> girlsAbbrs = new List<string>();
                if (!string.IsNullOrWhiteSpace(girlsTeam1Abbr))
                    girlsAbbrs.Add(girlsTeam1Abbr);
                if (!string.IsNullOrWhiteSpace(girlsTeam2Abbr))
                    girlsAbbrs.Add(girlsTeam2Abbr);
                if (!string.IsNullOrWhiteSpace(girlsTeam3Abbr))
                    girlsAbbrs.Add(girlsTeam3Abbr);
                if (!string.IsNullOrWhiteSpace(girlsTeam4Abbr))
                    girlsAbbrs.Add(girlsTeam4Abbr);
                if (!string.IsNullOrWhiteSpace(girlsTeam5Abbr))
                    girlsAbbrs.Add(girlsTeam5Abbr);
                if (!string.IsNullOrWhiteSpace(girlsTeam6Abbr))
                    girlsAbbrs.Add(girlsTeam6Abbr);

                if (boysNames.Distinct().Count() != boysNames.Count())
                    MessageBox.Show("All Boy's names must be unique", "Invalid Data");
                else if (boysAbbrs.Distinct().Count() != boysAbbrs.Count())
                    MessageBox.Show("All Boy's abbrs must be unique", "Invalid Data");
                else if (girlsNames.Distinct().Count() != girlsNames.Count())
                    MessageBox.Show("All Girl's names must be unique", "Invalid Data");
                else if (girlsAbbrs.Distinct().Count() != girlsAbbrs.Count())
                    MessageBox.Show("All Girl's abbrs must be unique", "Invalid Data");
                else
                {
                    Dictionary<string, string> boysTeams = new Dictionary<string, string>();
                    boysTeams.Add(boysTeam1Abbr, boysTeam1Name);
                    if (!string.IsNullOrWhiteSpace(boysTeam2Abbr))
                        boysTeams.Add(boysTeam2Abbr, boysTeam2Name);
                    if (!string.IsNullOrWhiteSpace(boysTeam3Abbr))
                        boysTeams.Add(boysTeam3Abbr, boysTeam3Name);
                    if (!string.IsNullOrWhiteSpace(boysTeam4Abbr))
                        boysTeams.Add(boysTeam4Abbr, boysTeam4Name);
                    if (!string.IsNullOrWhiteSpace(boysTeam5Abbr))
                        boysTeams.Add(boysTeam5Abbr, boysTeam5Name);
                    if (!string.IsNullOrWhiteSpace(boysTeam6Abbr))
                        boysTeams.Add(boysTeam6Abbr, boysTeam6Name);

                    Dictionary<string, string> girlsTeams = new Dictionary<string, string>();
                    girlsTeams.Add(girlsTeam1Abbr, girlsTeam1Name);
                    if (!string.IsNullOrWhiteSpace(girlsTeam2Abbr))
                        girlsTeams.Add(girlsTeam2Abbr, girlsTeam2Name);
                    if (!string.IsNullOrWhiteSpace(girlsTeam3Abbr))
                        girlsTeams.Add(girlsTeam3Abbr, girlsTeam3Name);
                    if (!string.IsNullOrWhiteSpace(girlsTeam4Abbr))
                        girlsTeams.Add(girlsTeam4Abbr, girlsTeam4Name);
                    if (!string.IsNullOrWhiteSpace(girlsTeam5Abbr))
                        girlsTeams.Add(girlsTeam5Abbr, girlsTeam5Name);
                    if (!string.IsNullOrWhiteSpace(girlsTeam6Abbr))
                        girlsTeams.Add(girlsTeam6Abbr, girlsTeam6Name);

                    Teams newTeams = new Teams(boysTeams, girlsTeams);

                    Meet newMeet = new Meet(meetDateTime, meetLocation, meetWeather, newTeams);

                    if (newMeet.validate())
                    {
                        MessageBox.Show("Meet created successfully");
                        //Switch forms
                    }
                    else
                    {
                        MessageBox.Show("Unknown problem creating this meet. Data was invaalid.");
                    }
                }
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            //MessageBox to check if the user wants to reset the entered data
            DialogResult result = MessageBox.Show("Are you sure you want to clear the meet data?",
                "Clear data?", MessageBoxButtons.YesNo);

            //Check that the user wants to reset the entered data
            if (result == DialogResult.Yes)
            {
                //Clear all text properties
                txtLocation.Text = "";
                txtBoysTeam1Abbr.Text = "";
                txtBoysTeam1Name.Text = "";
                txtBoysTeam2Abbr.Text = "";
                txtBoysTeam2Name.Text = "";
                txtBoysTeam3Abbr.Text = "";
                txtBoysTeam3Name.Text = "";
                txtBoysTeam4Abbr.Text = "";
                txtBoysTeam4Name.Text = "";
                txtBoysTeam5Abbr.Text = "";
                txtBoysTeam5Name.Text = "";
                txtBoysTeam6Abbr.Text = "";
                txtBoysTeam6Name.Text = "";
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            //Exit the application
            Application.Exit();
        }
    }
}
