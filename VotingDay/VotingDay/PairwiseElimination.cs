using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private DataTable data;
        private List<string> movies; 

        public PairwiseElimination(DataTable input, List<string> movieTitles)
        {
            InitializeComponent();
            data = input;
            movies = movieTitles;
            var numberOfContestants = input.Columns.Count - 1;
            var numberOfRounds = Math.Log(numberOfContestants, 2);
            if (numberOfRounds - Math.Floor(numberOfRounds) == 0.0)
            {
                numberOfRounds = (int)numberOfRounds;
                var dataTable = new DataTable("");
                dataTable.Columns.Add("MovieTitle", typeof (string));
                for (var i = 1; i <= numberOfRounds; i++)
                {
                    dataTable.Columns.Add("Round " + i, typeof(int));
                }
                for (var i = 0; i < numberOfContestants; i++)
                {
                    var rowData = new object[(int)numberOfRounds + 1];
                    rowData[0] = movies[i];
                    dataTable.Rows.Add(rowData);
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
                            if (i == 1 || Convert.ToInt32(dataTable.Rows[j + k][i - 1]) == 1)
                            {
                                contestants.Add(j + k);
                            }
                            else
                            {
                                dataTable.Rows[j + k][i] = 0;
                            }
                        }

                        //evaluate the winner of the bracket
                        var winner = EvaluateWinner(contestants[0], contestants[1]);
                        dataTable.Rows[winner][i] = 1;
                        dataTable.Rows[contestants[0] + contestants[1] - winner][i] = 0;
                    }
                }
                dataGridView1.DataSource = dataTable;
            }
        }

        private int EvaluateWinner(int contestant1, int contestant2)
        {
            var comparison =0;
            for (var i = 0; i < data.Rows.Count; i++)
            {
                comparison += (Convert.ToInt32(data.Rows[i].ItemArray[contestant1+1]) > Convert.ToInt32(data.Rows[i].ItemArray[contestant2+1]) ? 1 : -1);
            }

            return comparison > 0
                ? contestant1
                : comparison < 0
                    ? contestant2
                    : movies[contestant1].CompareTo(movies[contestant2]) < 0 ? contestant1 : contestant2;
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {

            Exporter exporter = new Exporter(dataGridView1);
            exportFilePath = exporter.ExportToExcel("Round6_Amirite.xls");

        }

        private void sendEmailButton_Click(object sender, EventArgs e)
        {
            EmailForm emailForm = new EmailForm(exportFilePath);
            emailForm.Show();
        }
    }
}
