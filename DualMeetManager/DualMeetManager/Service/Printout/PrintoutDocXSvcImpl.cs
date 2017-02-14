using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DualMeetManager.Domain;
using DualMeetManager.Domain.Scoring;
using Novacode;
using System.Drawing;
using DualMeetManager.Business.Managers;

namespace DualMeetManager.Service.Printout
{
    /// <summary>
    /// Implementation that uses the DocX library to generate Microsoft Word documents for Meet information
    /// </summary>
    public class PrintoutDocXSvcImpl : IPrintoutDocSvc
    {
        /// <summary>
        /// Implementation for creating a doc of individual event performances
        /// </summary>
        /// <param name="eventName">Name of the event for this printout</param>
        /// <param name="performances">List of performances for this printout</param>
        /// <returns>boolean that shows whether or not the doc was created successfully or not</returns>
        public bool CreateIndEventDoc(string eventName, List<Performance> performances)
        {
            //Make sure we get a valid filename
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < eventName.Length; i++)
            {
                //if (!perf.All(c => char.IsDigit(c) || c == ':' || c == '.'))
                if (char.IsLetterOrDigit(eventName[i]))
                {
                    sb.Append(eventName[i]);
                }
            }
            string fileName = sb.ToString() + ".docx";
            using (DocX document = DocX.Create(fileName))
            {
                document.MarginLeft = 36; //.5 Margin
                document.MarginRight = 36;
                document.MarginTop = 36;
                document.MarginBottom = 36;
                // Add a new Paragraph to the document.
                Paragraph p = document.InsertParagraph();

                // Append some text.
                p.Append(eventName + "\n\n").Font(new FontFamily("Arial Black"));

                if (performances != null)
                {
                    EventMgr eMgr = new EventMgr();
                    if (performances[0].heatNum != 0) //Running Event
                    {
                        // Add a Table to this document. (Rows, Columns)
                        Table t = document.AddTable(performances.Count + 1, 5);
                        // Specify some properties for this Table.
                        t.Alignment = Alignment.center;
                        t.Design = TableDesign.TableNormal;

                        //t.Rows[0].Cells[0].FillColor = Color.Azure;
                        //t.Rows[0].Cells[0].Paragraphs.First().Append("#").Font(new FontFamily("Arial Black"));
                        t.Rows[0].Cells[0].Paragraphs.First().Append("#").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                        t.Rows[0].Cells[1].Paragraphs.First().Append("Athlete").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                        t.Rows[0].Cells[2].Paragraphs.First().Append("School").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                        t.Rows[0].Cells[3].Paragraphs.First().Append("Performance").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                        t.Rows[0].Cells[4].Paragraphs.First().Append("Heat").Bold().UnderlineStyle(UnderlineStyle.singleLine);

                        for (int i = 0; i < performances.Count; i++)
                        {
                            t.Rows[i+1].Cells[0].Paragraphs.First().Append((i+1).ToString());
                            t.Rows[i+1].Cells[1].Paragraphs.First().Append(performances[i].athleteName);
                            t.Rows[i+1].Cells[2].Paragraphs.First().Append(performances[i].schoolName);
                            t.Rows[i+1].Cells[3].Paragraphs.First().Append(eMgr.ConvertToTimedData(performances[i].performance));
                            t.Rows[i+1].Cells[4].Paragraphs.First().Append(performances[i].heatNum.ToString());
                        }

                        document.InsertTable(t);
                    }
                    else //Field Event
                    {
                        // Add a Table to this document. (Rows, Columns)
                        Table t = document.AddTable(performances.Count + 1, 4);
                        // Specify some properties for this Table.
                        t.Alignment = Alignment.center;
                        t.Design = TableDesign.TableNormal;

                        t.Rows[0].Cells[0].Paragraphs.First().Append("#").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                        t.Rows[0].Cells[1].Paragraphs.First().Append("Athlete").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                        t.Rows[0].Cells[2].Paragraphs.First().Append("School").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                        t.Rows[0].Cells[3].Paragraphs.First().Append("Performance").Bold().UnderlineStyle(UnderlineStyle.singleLine);

                        for (int i = 0; i < performances.Count; i++)
                        {
                            t.Rows[i + 1].Cells[0].Paragraphs.First().Append((i + 1).ToString());
                            t.Rows[i + 1].Cells[1].Paragraphs.First().Append(performances[i].athleteName);
                            t.Rows[i + 1].Cells[2].Paragraphs.First().Append(performances[i].schoolName);
                            t.Rows[i + 1].Cells[3].Paragraphs.First().Append(eMgr.ConvertToLengthData(performances[i].performance));
                        }

                        document.InsertTable(t);
                    }
                    Paragraph pp = document.InsertParagraph();
                    pp.Append("\n\n\nNOTE: Ties are not calculated on this sheet. #'s are only for reference").Font(new FontFamily("Arial"));
                }
                else //No performances
                {
                    p.Append("No performances for this event").Font(new FontFamily("Arial"));
                }

                // Save the document.
                document.Save();
                System.Diagnostics.Process.Start(fileName);
            }

            return true;
        }

        /// <summary>
        /// Implementation for creating a doc for all scoring information for a Meet
        /// </summary>
        /// <param name="scoreToPrint">OverallScore information of the meet to be printed</param>
        /// <returns>boolean that shows whether or not the doc was created successfully or not</returns>
        public bool CreateMeetResultsDoc(OverallScore scoreToPrint)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implementation for creating a doc of all performances for one specific team
        /// </summary>
        /// <param name="teamAbbr">Team to be printed</param>
        /// <param name="meetToPrint">Meet that the performances are being gathered from</param>
        /// <returns>boolean that shows whether or not the doc was created successfully or not</returns>
        public bool CreateTeamPerfDoc(string teamAbbr, string gender, Meet meetToPrint)
        {
            Dictionary<string, List<Performance>> performances = new Dictionary<string, List<Performance>>();
            //go thru each event in meetToPrint
            foreach(string evt in meetToPrint.performances.Keys)
            {
                //go thru and add performances with the teamAbbr to the temp list
                List<Performance> tempPerfs = new List<Performance>();
                foreach(Performance p in meetToPrint.performances[evt])
                {
                    if(p.schoolName == teamAbbr)
                    {
                        tempPerfs.Add(p);
                    }
                }

                //Add tempList to performances
                if(tempPerfs != null) //Cannot add a null value to a dictionary key
                    performances.Add(evt, tempPerfs);
            } //The above SHOULD be complete. Still untested

            string fileName = teamAbbr + meetToPrint.dateOfMeet.Month + "-" + meetToPrint.dateOfMeet.Day + "Performances.docx";
            using (DocX document = DocX.Create(fileName))
            {
                document.MarginLeft = 36; //.5 Margin
                document.MarginRight = 36;
                document.MarginTop = 36;
                document.MarginBottom = 36;

                Paragraph pp = document.InsertParagraph();

                // Append some text.
                pp.Append(teamAbbr + " Performances\n\n").Font(new FontFamily("Arial Black"));

                Paragraph[] p = new Paragraph[18];
                Paragraph[] noPerf = new Paragraph[18];
                Table[] perfs = new Table[18];


                if (performances != null)
                {
                    string[] validEvents = {gender + " 100", gender + " 200", gender + " 400",
                    gender + " 800", gender + " 1600", gender + " 3200", gender + " 4x100",
                    gender + " 4x400", gender + " 4x800", gender + " LJ", gender + " TJ", gender + " HJ",
                    gender + " PV", gender + " ShotPut", gender + " Discus", gender + " Javelin"};

                    //foreach (string evt in validEvents)
                    for(int i = 0; i < validEvents.Length; i++)
                    {
                        //Print event name
                        p[i] = document.InsertParagraph();
                        p[i].Append(validEvents[i] + ":\n");

                        //Print table of performances
                        if(!performances.ContainsKey(validEvents[i])) //If key does not exist, the team did not compete in this event
                        {
                            noPerf[i] = document.InsertParagraph();
                            noPerf[i].Append("Event not competed in by this team:\n");
                        }
                        //Check if running or field event
                        //Space for next 

                    }

                    EventMgr eMgr = new EventMgr();
                    if (performances[0].heatNum != 0) //Running Event
                    {
                        // Add a Table to this document. (Rows, Columns)
                        Table t = document.AddTable(performances.Count + 1, 5);
                        // Specify some properties for this Table.
                        t.Alignment = Alignment.center;
                        t.Design = TableDesign.TableNormal;

                        //t.Rows[0].Cells[0].FillColor = Color.Azure;
                        //t.Rows[0].Cells[0].Paragraphs.First().Append("#").Font(new FontFamily("Arial Black"));
                        t.Rows[0].Cells[0].Paragraphs.First().Append("#").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                        t.Rows[0].Cells[1].Paragraphs.First().Append("Athlete").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                        t.Rows[0].Cells[2].Paragraphs.First().Append("School").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                        t.Rows[0].Cells[3].Paragraphs.First().Append("Performance").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                        t.Rows[0].Cells[4].Paragraphs.First().Append("Heat").Bold().UnderlineStyle(UnderlineStyle.singleLine);

                        for (int i = 0; i < performances.Count; i++)
                        {
                            t.Rows[i + 1].Cells[0].Paragraphs.First().Append((i + 1).ToString());
                            t.Rows[i + 1].Cells[1].Paragraphs.First().Append(performances[i].athleteName);
                            t.Rows[i + 1].Cells[2].Paragraphs.First().Append(performances[i].schoolName);
                            t.Rows[i + 1].Cells[3].Paragraphs.First().Append(eMgr.ConvertToTimedData(performances[i].performance));
                            t.Rows[i + 1].Cells[4].Paragraphs.First().Append(performances[i].heatNum.ToString());
                        }

                        document.InsertTable(t);
                    }
                    else //Field Event
                    {
                        // Add a Table to this document. (Rows, Columns)
                        Table t = document.AddTable(performances.Count + 1, 4);
                        // Specify some properties for this Table.
                        t.Alignment = Alignment.center;
                        t.Design = TableDesign.TableNormal;

                        t.Rows[0].Cells[0].Paragraphs.First().Append("#").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                        t.Rows[0].Cells[1].Paragraphs.First().Append("Athlete").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                        t.Rows[0].Cells[2].Paragraphs.First().Append("School").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                        t.Rows[0].Cells[3].Paragraphs.First().Append("Performance").Bold().UnderlineStyle(UnderlineStyle.singleLine);

                        for (int i = 0; i < performances.Count; i++)
                        {
                            t.Rows[i + 1].Cells[0].Paragraphs.First().Append((i + 1).ToString());
                            t.Rows[i + 1].Cells[1].Paragraphs.First().Append(performances[i].athleteName);
                            t.Rows[i + 1].Cells[2].Paragraphs.First().Append(performances[i].schoolName);
                            t.Rows[i + 1].Cells[3].Paragraphs.First().Append(eMgr.ConvertToLengthData(performances[i].performance));
                        }

                        document.InsertTable(t);
                    }
                    Paragraph pp = document.InsertParagraph();
                    pp.Append("\n\n\nNOTE: Ties are not calculated on this sheet. #'s are only for reference").Font(new FontFamily("Arial"));
                }
                else //No performances
                {
                    p.Append("No performances for this event").Font(new FontFamily("Arial"));
                }

                // Save the document.
                document.Save();
                System.Diagnostics.Process.Start(fileName);
            }

            return true;

        }
    }
}
