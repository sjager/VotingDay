using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VotingDay
{
    public partial class PairwiseElimination : Form
    {
        public string exportFilePath;
        private DataTable indata;
        private List<string> movies; 
        private DataTable outTable;

        public PairwiseElimination(DataTable input, List<string> movieTitles)
        {
            InitializeComponent();
            indata = input;
            movies = movieTitles;
            var numberOfContestants = input.Columns.Count - 1;
            var numberOfRounds = Math.Log(numberOfContestants, 2);
            if (numberOfRounds - Math.Floor(numberOfRounds) == 0.0)
            {
                numberOfRounds = (int)numberOfRounds;
                outTable = new DataTable("");
                outTable.Columns.Add("MovieTitle", typeof(string));
                for (var i = 1; i <= numberOfRounds; i++)
                {
                    outTable.Columns.Add("Round " + i, typeof(int));
                }
                for (var i = 0; i < numberOfContestants; i++)
                {
                    var rowData = new object[(int)numberOfRounds + 1];
                    rowData[0] = movies[i];
                    outTable.Rows.Add(rowData);
                }
                for (var i = 1; i <= numberOfRounds; i++)
                {
                    // for each bracket
                    for (var j = 0; j < numberOfContestants; j = j + (int)Math.Pow(2, i))
                    {
                        var contestants = new List<int>();
                        // foreach contestant in the bracket, find the two contestants
                        for (var k = 0; k < Math.Pow(2, i); k++)
                        {
                            if (i == 1 || Convert.ToInt32(outTable.Rows[j + k][i - 1]) == 1)
                            {
                                contestants.Add(j + k);
                            }
                            else
                            {
                                outTable.Rows[j + k][i] = 0;
                            }
                        }

                        //evaluate the winner of the bracket
                        var winner = EvaluateWinner(contestants[0], contestants[1]);
                        outTable.Rows[winner][i] = 1;
                        outTable.Rows[contestants[0] + contestants[1] - winner][i] = 0;
                    }
                }
                dataGridView1.DataSource = outTable;

                var paretoDominated = new List<int>();
                var paretoDominates = new List<int>();
                for (var i = 0; i < indata.Columns.Count-1; i++)
                {
                    for (var j = 0; j < indata.Columns.Count-1; j++)
                    {
                        if (IsParetoDominated(i, j))
                        {
                            paretoDominates.Add(i);
                            paretoDominated.Add(j);
                        }
                    }
                }

                
                if (!paretoDominated.Any())
                {
                    Debug.WriteLine("No Pareto Domination exists");
                }
                else
                {
                    for (var i = 0; i < paretoDominated.Count; i++)
                    {
                        int underdog;
                        if (GetPlace(paretoDominated[i]) > GetPlace(paretoDominates[i]))
                        {
                            Debug.WriteLine(movies[paretoDominated[i]] + " was dominated by " + movies[paretoDominates[i]] +
                                          " but finished higher");
                            break;
                        }
                    }
                    for(var i = 0; i < paretoDominated.Count; i++)
                    {
                        int temp1 = -1, temp2 = -2;
                        for (var j = 0; j < indata.Columns.Count-1; j++)
                        {
                            if (paretoDominates[i] != j && EvaluateWinner(paretoDominates[i], j) == j)
                            {
                                temp1 = j;
                            }
                        }
                        for (var j = 0; j < indata.Columns.Count-1; j++)
                        {
                            if (paretoDominated[i] != j && EvaluateWinner(paretoDominated[i], j) == paretoDominated[i])
                            {
                                temp2 = j;
                            }
                        }
                        if (temp1 >= 0 && temp2 >= 0)
                        {
                            // condition for underdog winning has been found.
                            Debug.WriteLine("\"Pareto dominated\" " + movies[paretoDominated[i]] + " beats " + movies[temp2] + " and \"pareto dominating\" " +
                            movies[paretoDominates[i]] + " is beaten by " + movies[temp1]);
                            break;
                        }
                    }
                }
            }
        }

        private int EvaluateWinner(int contestant1, int contestant2)
        {
            var comparison =0;
            for (var i = 0; i < indata.Rows.Count; i++)
            {
                comparison += (Convert.ToInt32(indata.Rows[i].ItemArray[contestant1 + 1]) > Convert.ToInt32(indata.Rows[i].ItemArray[contestant2 + 1]) ? 1 : -1);
            }

            return comparison > 0
                ? contestant1
                : comparison < 0
                    ? contestant2
                    : movies[contestant1].CompareTo(movies[contestant2]) < 0 ? contestant1 : contestant2;
        }

        private bool IsParetoDominated(int dominator, int dominated)
        {
            var comparison = 0;
            for (var i = 0; i < indata.Rows.Count; i++)
            {
                comparison += (Convert.ToInt32(indata.Rows[i].ItemArray[dominator + 1]) > Convert.ToInt32(indata.Rows[i].ItemArray[dominated + 1]) ? 1 : -1);
            }
            return comparison == indata.Rows.Count;
        }

        private int GetPlace(int contestant)
        {
            var i = 1;
            while (i < outTable.Columns.Count && Convert.ToInt32(outTable.Rows[contestant][i]) == 1)
            {
                i++;
            }
            return i;
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            var rowToHighlight = 1;
            for (var i = 0; i < outTable.Rows.Count; i++)
            {
                if (Convert.ToInt32(outTable.Rows[i][outTable.Columns.Count - 1]) == 1)
                {
                    rowToHighlight = i+1;
                }
            }

            Exporter exporter = new Exporter(dataGridView1);
            exportFilePath = exporter.ExportToExcel("Round6_Amirite.xls",rowToHighlight);

        }

        private void sendEmailButton_Click(object sender, EventArgs e)
        {
            EmailForm emailForm = new EmailForm(exportFilePath, 6);
            emailForm.Show();
        }
    }
}
