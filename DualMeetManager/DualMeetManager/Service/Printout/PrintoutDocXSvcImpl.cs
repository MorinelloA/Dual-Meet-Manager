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
using System.Text.RegularExpressions;

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
            EventMgr eMgr = new EventMgr();
            string fileName = "FullMeetTest.docx";
            using (DocX document = DocX.Create(fileName))
            {
                document.MarginLeft = 36; //.5 Margin
                document.MarginRight = 36;
                document.MarginTop = 36;
                document.MarginBottom = 36;
                Table t = document.AddTable(53, 12);
                // Specify some properties for this Table.
                t.Alignment = Alignment.center;
                t.Design = TableDesign.TableNormal;
                Border b = new Border(BorderStyle.Tcbs_single, BorderSize.one, 0, Color.Black);
                t.SetBorder(TableBorderType.Bottom, b);
                t.SetBorder(TableBorderType.Top, b);
                t.SetBorder(TableBorderType.Left, b);
                t.SetBorder(TableBorderType.Right, b);
                t.SetBorder(TableBorderType.InsideH, b);
                t.SetBorder(TableBorderType.InsideV, b);

                //Align all cells to center
                for(int aa = 0; aa < 53; aa++)
                {
                    for(int bb = 0; bb < 12; bb++)
                    {
                        t.Rows[aa].Cells[bb].Paragraphs.First().Alignment = Alignment.center;
                    }
                }
                
                //Shade appropriate cell grey
                for (int bb = 0; bb <= 5; bb++)
                {
                    for (int aa = 1; aa <= 5; aa++)
                    {
                        t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                    }
                    for (int aa = 13; aa <= 17; aa++)
                    {
                        t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                    }
                    for (int aa = 25; aa <= 28; aa++)
                    {
                        t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                    }
                    for (int aa = 36; aa <= 40; aa++)
                    {
                        t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                    }
                    for (int aa = 48; aa <= 52; aa++)
                    {
                        t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                    }
                }
                for (int bb = 6; bb <= 11; bb++)
                {
                    for (int aa = 7; aa <= 11; aa++)
                    {
                        t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                    }
                    for (int aa = 19; aa <= 23; aa++)
                    {
                        t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                    }
                    for (int aa = 30; aa <= 34; aa++)
                    {
                        t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                    }
                    for (int aa = 42; aa <= 46; aa++)
                    {
                        t.Rows[aa].Cells[bb].Shading = Color.LightGray;
                    }
                }

                    // Merge the cells 100 & 200 Title Cells into one new cell.
                    t.Rows[0].MergeCells(0, 5);
                t.Rows[0].MergeCells(1, 6);
                t.Rows[0].Cells[0].RemoveParagraphAt(0);
                t.Rows[0].Cells[0].RemoveParagraphAt(0);
                t.Rows[0].Cells[0].RemoveParagraphAt(0);
                t.Rows[0].Cells[0].RemoveParagraphAt(0);
                t.Rows[0].Cells[0].RemoveParagraphAt(0);
                t.Rows[0].Cells[1].RemoveParagraphAt(0);
                t.Rows[0].Cells[1].RemoveParagraphAt(0);
                t.Rows[0].Cells[1].RemoveParagraphAt(0);
                t.Rows[0].Cells[1].RemoveParagraphAt(0);
                t.Rows[0].Cells[1].RemoveParagraphAt(0);
                t.Rows[0].Cells[0].Paragraphs.First().Append("100 Meter Dash");
                t.Rows[0].Cells[1].Paragraphs.First().Append("200 Meter Dash");
                t.Rows[0].Cells[0].Shading = Color.Black;
                t.Rows[0].Cells[1].Shading = Color.Black;
                t.Rows[1].Cells[0].Paragraphs.First().Append("#");
                t.Rows[1].Cells[1].Paragraphs.First().Append("Athlete");
                t.Rows[1].Cells[2].Paragraphs.First().Append("School");
                t.Rows[1].Cells[3].Paragraphs.First().Append("Time");
                t.Rows[1].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[1].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                t.Rows[1].Cells[6].Paragraphs.First().Append("#");
                t.Rows[1].Cells[7].Paragraphs.First().Append("Athlete");
                t.Rows[1].Cells[8].Paragraphs.First().Append("School");
                t.Rows[1].Cells[9].Paragraphs.First().Append("Time");
                t.Rows[1].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[1].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                t.Rows[2].Cells[0].Paragraphs.First().Append("1");
                t.Rows[3].Cells[0].Paragraphs.First().Append("2");
                t.Rows[4].Cells[0].Paragraphs.First().Append("3");
                t.Rows[5].MergeCells(0, 3);
                t.Rows[5].Cells[0].RemoveParagraphAt(0);
                t.Rows[5].Cells[0].RemoveParagraphAt(0);
                t.Rows[5].Cells[0].RemoveParagraphAt(0);
                t.Rows[5].Cells[0].Paragraphs.First().Append("Total");
                t.Rows[5].Cells[0].Paragraphs.First().Alignment = Alignment.left;
                if (scoreToPrint.indEvents.ContainsKey("Boy's 400"))
                {
                    t.Rows[2].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].points[0].athleteName);
                    t.Rows[2].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].points[0].schoolName);
                    t.Rows[2].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].points[0].performance);
                    t.Rows[2].Cells[4].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].points[0].team1Pts.ToString());
                    t.Rows[2].Cells[5].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].points[0].team2Pts.ToString());
                    t.Rows[3].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].points[1].athleteName);
                    t.Rows[3].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].points[1].schoolName);
                    t.Rows[3].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].points[1].performance);
                    t.Rows[3].Cells[4].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].points[1].team1Pts.ToString());
                    t.Rows[3].Cells[5].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].points[1].team2Pts.ToString());
                    t.Rows[4].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].points[2].athleteName);
                    t.Rows[4].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].points[2].schoolName);
                    t.Rows[4].Cells[3].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].points[2].performance);
                    t.Rows[4].Cells[4].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].points[2].team1Pts.ToString());
                    t.Rows[4].Cells[5].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].points[2].team2Pts.ToString());
                    t.Rows[5].Cells[1].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].team1Total.ToString());
                    t.Rows[5].Cells[2].Paragraphs.First().Append(scoreToPrint.indEvents["Boy's 100"].team2Total.ToString());
                }
                else
                {
                    t.Rows[2].Cells[4].Paragraphs.First().Append("0");
                    t.Rows[2].Cells[5].Paragraphs.First().Append("0");
                    t.Rows[3].Cells[4].Paragraphs.First().Append("0");
                    t.Rows[3].Cells[5].Paragraphs.First().Append("0");
                    t.Rows[4].Cells[4].Paragraphs.First().Append("0");
                    t.Rows[4].Cells[5].Paragraphs.First().Append("0");
                    t.Rows[5].Cells[1].Paragraphs.First().Append("0");
                    t.Rows[5].Cells[2].Paragraphs.First().Append("0");
                }

                // Merge the cells 400 & 800 Title Cells into one new cell.
                t.Rows[6].MergeCells(0, 5);
                t.Rows[6].MergeCells(1, 6);
                t.Rows[6].Cells[0].RemoveParagraphAt(0);
                t.Rows[6].Cells[0].RemoveParagraphAt(0);
                t.Rows[6].Cells[0].RemoveParagraphAt(0);
                t.Rows[6].Cells[0].RemoveParagraphAt(0);
                t.Rows[6].Cells[0].RemoveParagraphAt(0);
                t.Rows[6].Cells[1].RemoveParagraphAt(0);
                t.Rows[6].Cells[1].RemoveParagraphAt(0);
                t.Rows[6].Cells[1].RemoveParagraphAt(0);
                t.Rows[6].Cells[1].RemoveParagraphAt(0);
                t.Rows[6].Cells[1].RemoveParagraphAt(0);
                t.Rows[6].Cells[0].Paragraphs.First().Append("400 Meter Dash");
                t.Rows[6].Cells[1].Paragraphs.First().Append("800 Meter Dash");
                t.Rows[6].Cells[0].Shading = Color.Black;
                t.Rows[6].Cells[1].Shading = Color.Black;
                t.Rows[7].Cells[0].Paragraphs.First().Append("#");
                t.Rows[7].Cells[1].Paragraphs.First().Append("Athlete");
                t.Rows[7].Cells[2].Paragraphs.First().Append("School");
                t.Rows[7].Cells[3].Paragraphs.First().Append("Time");
                t.Rows[7].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[7].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                t.Rows[7].Cells[6].Paragraphs.First().Append("#");
                t.Rows[7].Cells[7].Paragraphs.First().Append("Athlete");
                t.Rows[7].Cells[8].Paragraphs.First().Append("School");
                t.Rows[7].Cells[9].Paragraphs.First().Append("Time");
                t.Rows[7].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[7].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);

                // Merge the cells 1600 & 3200 Title Cells into one new cell.
                t.Rows[12].MergeCells(0, 5);
                t.Rows[12].MergeCells(1, 6);
                t.Rows[12].Cells[0].RemoveParagraphAt(0);
                t.Rows[12].Cells[0].RemoveParagraphAt(0);
                t.Rows[12].Cells[0].RemoveParagraphAt(0);
                t.Rows[12].Cells[0].RemoveParagraphAt(0);
                t.Rows[12].Cells[0].RemoveParagraphAt(0);
                t.Rows[12].Cells[1].RemoveParagraphAt(0);
                t.Rows[12].Cells[1].RemoveParagraphAt(0);
                t.Rows[12].Cells[1].RemoveParagraphAt(0);
                t.Rows[12].Cells[1].RemoveParagraphAt(0);
                t.Rows[12].Cells[1].RemoveParagraphAt(0);
                t.Rows[12].Cells[0].Paragraphs.First().Append("1600 Meter Dash");
                t.Rows[12].Cells[1].Paragraphs.First().Append("3200 Meter Dash");
                t.Rows[12].Cells[0].Shading = Color.Black;
                t.Rows[12].Cells[1].Shading = Color.Black;
                t.Rows[13].Cells[0].Paragraphs.First().Append("#");
                t.Rows[13].Cells[1].Paragraphs.First().Append("Athlete");
                t.Rows[13].Cells[2].Paragraphs.First().Append("School");
                t.Rows[13].Cells[3].Paragraphs.First().Append("Time");
                t.Rows[13].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[13].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                t.Rows[13].Cells[6].Paragraphs.First().Append("#");
                t.Rows[13].Cells[7].Paragraphs.First().Append("Athlete");
                t.Rows[13].Cells[8].Paragraphs.First().Append("School");
                t.Rows[13].Cells[9].Paragraphs.First().Append("Time");
                t.Rows[13].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[13].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);

                // Merge the cells High Hurdle & 300H Title Cells into one new cell.
                t.Rows[18].MergeCells(0, 5);
                t.Rows[18].MergeCells(1, 6);
                t.Rows[18].Cells[0].RemoveParagraphAt(0);
                t.Rows[18].Cells[0].RemoveParagraphAt(0);
                t.Rows[18].Cells[0].RemoveParagraphAt(0);
                t.Rows[18].Cells[0].RemoveParagraphAt(0);
                t.Rows[18].Cells[0].RemoveParagraphAt(0);
                t.Rows[18].Cells[1].RemoveParagraphAt(0);
                t.Rows[18].Cells[1].RemoveParagraphAt(0);
                t.Rows[18].Cells[1].RemoveParagraphAt(0);
                t.Rows[18].Cells[1].RemoveParagraphAt(0);
                t.Rows[18].Cells[1].RemoveParagraphAt(0);
                t.Rows[18].Cells[0].Paragraphs.First().Append("High Hurdles");
                t.Rows[18].Cells[1].Paragraphs.First().Append("300 Meter Hurdles");
                t.Rows[18].Cells[0].Shading = Color.Black;
                t.Rows[18].Cells[1].Shading = Color.Black;
                t.Rows[19].Cells[0].Paragraphs.First().Append("#");
                t.Rows[19].Cells[1].Paragraphs.First().Append("Athlete");
                t.Rows[19].Cells[2].Paragraphs.First().Append("School");
                t.Rows[19].Cells[3].Paragraphs.First().Append("Time");
                t.Rows[19].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[19].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                t.Rows[19].Cells[6].Paragraphs.First().Append("#");
                t.Rows[19].Cells[7].Paragraphs.First().Append("Athlete");
                t.Rows[19].Cells[8].Paragraphs.First().Append("School");
                t.Rows[19].Cells[9].Paragraphs.First().Append("Time");
                t.Rows[19].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[19].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);

                // Merge the cells 4x100 & 4x400 Title Cells into one new cell.
                t.Rows[24].MergeCells(0, 5);
                t.Rows[24].MergeCells(1, 6);
                t.Rows[24].Cells[0].RemoveParagraphAt(0);
                t.Rows[24].Cells[0].RemoveParagraphAt(0);
                t.Rows[24].Cells[0].RemoveParagraphAt(0);
                t.Rows[24].Cells[0].RemoveParagraphAt(0);
                t.Rows[24].Cells[0].RemoveParagraphAt(0);
                t.Rows[24].Cells[1].RemoveParagraphAt(0);
                t.Rows[24].Cells[1].RemoveParagraphAt(0);
                t.Rows[24].Cells[1].RemoveParagraphAt(0);
                t.Rows[24].Cells[1].RemoveParagraphAt(0);
                t.Rows[24].Cells[1].RemoveParagraphAt(0);
                t.Rows[24].Cells[0].Paragraphs.First().Append("4x100 Meter Relay");
                t.Rows[24].Cells[1].Paragraphs.First().Append("4x400 Meter Relay");
                t.Rows[24].Cells[0].Shading = Color.Black;
                t.Rows[24].Cells[1].Shading = Color.Black;
                t.Rows[25].Cells[0].Paragraphs.First().Append("#");
                t.Rows[25].Cells[1].Paragraphs.First().Append("Athlete");
                t.Rows[25].Cells[2].Paragraphs.First().Append("School");
                t.Rows[25].Cells[3].Paragraphs.First().Append("Time");
                t.Rows[25].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[25].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                t.Rows[25].Cells[6].Paragraphs.First().Append("#");
                t.Rows[25].Cells[7].Paragraphs.First().Append("Athlete");
                t.Rows[25].Cells[8].Paragraphs.First().Append("School");
                t.Rows[25].Cells[9].Paragraphs.First().Append("Time");
                t.Rows[25].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[25].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);

                // Merge the cells 4x800 & Shotput Title Cells into one new cell.
                t.Rows[29].MergeCells(0, 5);
                t.Rows[29].MergeCells(1, 6);
                t.Rows[29].Cells[0].RemoveParagraphAt(0);
                t.Rows[29].Cells[0].RemoveParagraphAt(0);
                t.Rows[29].Cells[0].RemoveParagraphAt(0);
                t.Rows[29].Cells[0].RemoveParagraphAt(0);
                t.Rows[29].Cells[0].RemoveParagraphAt(0);
                t.Rows[29].Cells[1].RemoveParagraphAt(0);
                t.Rows[29].Cells[1].RemoveParagraphAt(0);
                t.Rows[29].Cells[1].RemoveParagraphAt(0);
                t.Rows[29].Cells[1].RemoveParagraphAt(0);
                t.Rows[29].Cells[1].RemoveParagraphAt(0);
                t.Rows[29].Cells[0].Paragraphs.First().Append("4x800 Meter Relay");
                t.Rows[29].Cells[1].Paragraphs.First().Append("Shotput");
                t.Rows[29].Cells[0].Shading = Color.Black;
                t.Rows[29].Cells[1].Shading = Color.Black;
                t.Rows[30].Cells[0].Paragraphs.First().Append("#");
                t.Rows[30].Cells[1].Paragraphs.First().Append("Athlete");
                t.Rows[30].Cells[2].Paragraphs.First().Append("School");
                t.Rows[30].Cells[3].Paragraphs.First().Append("Time");
                t.Rows[30].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[30].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                t.Rows[30].Cells[6].Paragraphs.First().Append("#");
                t.Rows[30].Cells[7].Paragraphs.First().Append("Athlete");
                t.Rows[30].Cells[8].Paragraphs.First().Append("School");
                t.Rows[30].Cells[9].Paragraphs.First().Append("Time");
                t.Rows[30].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[30].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);

                // Merge the cells Discus & Javelin Title Cells into one new cell.
                t.Rows[35].MergeCells(0, 5);
                t.Rows[35].MergeCells(1, 6);
                t.Rows[35].Cells[0].RemoveParagraphAt(0);
                t.Rows[35].Cells[0].RemoveParagraphAt(0);
                t.Rows[35].Cells[0].RemoveParagraphAt(0);
                t.Rows[35].Cells[0].RemoveParagraphAt(0);
                t.Rows[35].Cells[0].RemoveParagraphAt(0);
                t.Rows[35].Cells[1].RemoveParagraphAt(0);
                t.Rows[35].Cells[1].RemoveParagraphAt(0);
                t.Rows[35].Cells[1].RemoveParagraphAt(0);
                t.Rows[35].Cells[1].RemoveParagraphAt(0);
                t.Rows[35].Cells[1].RemoveParagraphAt(0);
                t.Rows[35].Cells[0].Paragraphs.First().Append("Discus");
                t.Rows[35].Cells[1].Paragraphs.First().Append("Javelin");
                t.Rows[35].Cells[0].Shading = Color.Black;
                t.Rows[35].Cells[1].Shading = Color.Black;
                t.Rows[36].Cells[0].Paragraphs.First().Append("#");
                t.Rows[36].Cells[1].Paragraphs.First().Append("Athlete");
                t.Rows[36].Cells[2].Paragraphs.First().Append("School");
                t.Rows[36].Cells[3].Paragraphs.First().Append("Time");
                t.Rows[36].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[36].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                t.Rows[36].Cells[6].Paragraphs.First().Append("#");
                t.Rows[36].Cells[7].Paragraphs.First().Append("Athlete");
                t.Rows[36].Cells[8].Paragraphs.First().Append("School");
                t.Rows[36].Cells[9].Paragraphs.First().Append("Time");
                t.Rows[36].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[36].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);

                // Merge the cells LJ & TJ Title Cells into one new cell.
                t.Rows[41].MergeCells(0, 5);
                t.Rows[41].MergeCells(1, 6);
                t.Rows[41].Cells[0].RemoveParagraphAt(0);
                t.Rows[41].Cells[0].RemoveParagraphAt(0);
                t.Rows[41].Cells[0].RemoveParagraphAt(0);
                t.Rows[41].Cells[0].RemoveParagraphAt(0);
                t.Rows[41].Cells[0].RemoveParagraphAt(0);
                t.Rows[41].Cells[1].RemoveParagraphAt(0);
                t.Rows[41].Cells[1].RemoveParagraphAt(0);
                t.Rows[41].Cells[1].RemoveParagraphAt(0);
                t.Rows[41].Cells[1].RemoveParagraphAt(0);
                t.Rows[41].Cells[1].RemoveParagraphAt(0);
                t.Rows[41].Cells[0].Paragraphs.First().Append("Long Jump");
                t.Rows[41].Cells[1].Paragraphs.First().Append("Triple Jump");
                t.Rows[41].Cells[0].Shading = Color.Black;
                t.Rows[41].Cells[1].Shading = Color.Black;
                t.Rows[42].Cells[0].Paragraphs.First().Append("#");
                t.Rows[42].Cells[1].Paragraphs.First().Append("Athlete");
                t.Rows[42].Cells[2].Paragraphs.First().Append("School");
                t.Rows[42].Cells[3].Paragraphs.First().Append("Time");
                t.Rows[42].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[42].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                t.Rows[42].Cells[6].Paragraphs.First().Append("#");
                t.Rows[42].Cells[7].Paragraphs.First().Append("Athlete");
                t.Rows[42].Cells[8].Paragraphs.First().Append("School");
                t.Rows[42].Cells[9].Paragraphs.First().Append("Time");
                t.Rows[42].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[42].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);

                // Merge the cells High Jump & Pole Vault Title Cells into one new cell.
                t.Rows[47].MergeCells(0, 5);
                t.Rows[47].MergeCells(1, 6);
                t.Rows[47].Cells[0].RemoveParagraphAt(0);
                t.Rows[47].Cells[0].RemoveParagraphAt(0);
                t.Rows[47].Cells[0].RemoveParagraphAt(0);
                t.Rows[47].Cells[0].RemoveParagraphAt(0);
                t.Rows[47].Cells[0].RemoveParagraphAt(0);
                t.Rows[47].Cells[1].RemoveParagraphAt(0);
                t.Rows[47].Cells[1].RemoveParagraphAt(0);
                t.Rows[47].Cells[1].RemoveParagraphAt(0);
                t.Rows[47].Cells[1].RemoveParagraphAt(0);
                t.Rows[47].Cells[1].RemoveParagraphAt(0);
                t.Rows[47].Cells[0].Paragraphs.First().Append("High Jump");
                t.Rows[47].Cells[1].Paragraphs.First().Append("Pole Vault");
                t.Rows[47].Cells[0].Shading = Color.Black;
                t.Rows[47].Cells[1].Shading = Color.Black;
                t.Rows[48].Cells[0].Paragraphs.First().Append("#");
                t.Rows[48].Cells[1].Paragraphs.First().Append("Athlete");
                t.Rows[48].Cells[2].Paragraphs.First().Append("School");
                t.Rows[48].Cells[3].Paragraphs.First().Append("Time");
                t.Rows[48].Cells[4].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[48].Cells[5].Paragraphs.First().Append(scoreToPrint.team2.Item1);
                t.Rows[48].Cells[6].Paragraphs.First().Append("#");
                t.Rows[48].Cells[7].Paragraphs.First().Append("Athlete");
                t.Rows[48].Cells[8].Paragraphs.First().Append("School");
                t.Rows[48].Cells[9].Paragraphs.First().Append("Time");
                t.Rows[48].Cells[10].Paragraphs.First().Append(scoreToPrint.team1.Item1);
                t.Rows[48].Cells[11].Paragraphs.First().Append(scoreToPrint.team2.Item1);

                document.InsertTable(t);
                document.Save();
                System.Diagnostics.Process.Start(fileName);
            }
            return true;
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
                    EventMgr eMgr = new EventMgr();

                    string[] validEvents = {gender + " 100", gender + " 200", gender + " 400",
                    gender + " 800", gender + " 1600", gender + " 3200", gender + " 4x100",
                    gender + " 4x400", gender + " 4x800", gender + " LJ", gender + " TJ", gender + " HJ",
                    gender + " PV", gender + " ShotPut", gender + " Discus", gender + " Javelin"};

                    //foreach (string evt in validEvents)
                    for (int i = 0; i < validEvents.Length; i++)
                    {
                        //Print event name
                        p[i] = document.InsertParagraph();
                        p[i].Append("\n\n" + validEvents[i] + ":\n").Bold();

                        //Print table of performances
                        if (!performances.ContainsKey(validEvents[i])) //If key does not exist, the team did not compete in this event
                        {
                            noPerf[i] = document.InsertParagraph();
                            noPerf[i].Append("Event not competed in by this team");
                        }
                        //Check if running or field event
                        else
                        {
                            List<Performance> tempEventList = performances[validEvents[i]]; //new List<Performance>();
                            if (tempEventList[0].heatNum != 0) //running event
                            {
                                tempEventList = tempEventList.OrderBy(o => o.performance).ToList(); //Order list by best-worst performance
                                perfs[i] = document.AddTable(tempEventList.Count + 1, 4);
                                // Specify some properties for this Table.
                                perfs[i].Alignment = Alignment.center;
                                perfs[i].Design = TableDesign.TableNormal;

                                //t.Rows[0].Cells[0].FillColor = Color.Azure;
                                //t.Rows[0].Cells[0].Paragraphs.First().Append("#").Font(new FontFamily("Arial Black"));
                                perfs[i].Rows[0].Cells[0].Paragraphs.First().Append("#").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                                perfs[i].Rows[0].Cells[1].Paragraphs.First().Append("Athlete").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                                perfs[i].Rows[0].Cells[2].Paragraphs.First().Append("Performance").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                                perfs[i].Rows[0].Cells[3].Paragraphs.First().Append("Heat").Bold().UnderlineStyle(UnderlineStyle.singleLine);

                                for (int j = 0; j < tempEventList.Count; j++)
                                {
                                    perfs[i].Rows[j + 1].Cells[0].Paragraphs.First().Append((j + 1).ToString());
                                    perfs[i].Rows[j + 1].Cells[1].Paragraphs.First().Append(tempEventList[j].athleteName);
                                    perfs[i].Rows[j + 1].Cells[2].Paragraphs.First().Append(eMgr.ConvertToLengthData(tempEventList[j].performance));
                                    perfs[i].Rows[j + 1].Cells[3].Paragraphs.First().Append(tempEventList[j].heatNum.ToString());
                                }

                                document.InsertTable(perfs[i]);
                            }
                            else // field event
                            {
                                tempEventList = tempEventList.OrderByDescending(o => o.performance).ToList(); //Order list by best-worst performance
                                perfs[i] = document.AddTable(tempEventList.Count + 1, 3);
                                // Specify some properties for this Table.
                                perfs[i].Alignment = Alignment.center;
                                perfs[i].Design = TableDesign.TableNormal;

                                //t.Rows[0].Cells[0].FillColor = Color.Azure;
                                //t.Rows[0].Cells[0].Paragraphs.First().Append("#").Font(new FontFamily("Arial Black"));
                                perfs[i].Rows[0].Cells[0].Paragraphs.First().Append("#").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                                perfs[i].Rows[0].Cells[1].Paragraphs.First().Append("Athlete").Bold().UnderlineStyle(UnderlineStyle.singleLine);
                                perfs[i].Rows[0].Cells[2].Paragraphs.First().Append("Performance").Bold().UnderlineStyle(UnderlineStyle.singleLine);

                                for (int j = 0; j < tempEventList.Count; j++)
                                {
                                    perfs[i].Rows[j + 1].Cells[0].Paragraphs.First().Append((j + 1).ToString());
                                    perfs[i].Rows[j + 1].Cells[1].Paragraphs.First().Append(tempEventList[j].athleteName);
                                    perfs[i].Rows[j + 1].Cells[2].Paragraphs.First().Append(eMgr.ConvertToLengthData(tempEventList[j].performance));
                                }

                                document.InsertTable(perfs[i]);
                            }
                        }
                        //Enter some blank Space for next event
                        //Might not be needed
                        
                    }
                    // Save the document.
                    document.Save();
                    System.Diagnostics.Process.Start(fileName);
                }
            }
            return true;
        }
    }
}
