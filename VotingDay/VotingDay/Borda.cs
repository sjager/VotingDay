using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace VotingDay
{
    public partial class Borda : Form
    {
        private DataTable data;
        private List<string> movies;

        public string exportFilePath;
        public Borda(DataTable input, List<string> movieTitles)
        {
            InitializeComponent();
            data = input;
            movies = movieTitles;
            var bordaCount = new Dictionary<int, int>();
            for (var i = 0; i < input.Columns.Count - 1; i++)
            {
                bordaCount.Add(i, 0);
            }
            //determine 0 indexing or 1 indexing
            var oneIndexing = Enumerable.Range(1, input.Columns.Count - 1).All(x => input.Rows[0].ItemArray.Contains(x));
            var zeroIndexing = Enumerable.Range(0, input.Columns.Count - 1).All(x => input.Rows[0].ItemArray.Contains(x));

            if (oneIndexing ^ zeroIndexing)
            {
                foreach (DataRow team in input.Rows)
                {
                    for (var i = 0; i < input.Columns.Count - 1; i++)
                    {
                        bordaCount[i] += oneIndexing ? Convert.ToInt32(team.ItemArray[i + 1]) - 1 : Convert.ToInt32(team.ItemArray[i + 1]);
                    }
                }

                var orderedList = bordaCount.ToList().OrderByDescending(x => x.Value).ThenBy(x => movieTitles[x.Key]);
                var dataSource = new DataTable("Borda Results");
                dataSource.Columns.Add("id", typeof(int));
                dataSource.Columns.Add("name", typeof(string));
                dataSource.Columns.Add("result", typeof(int));
                foreach (var item in orderedList)
                {
                    DataRow newRow = dataSource.Rows.Add();
                    object[] rowArray = new object[3];
                    rowArray[0] = item.Key;
                    rowArray[1] = movieTitles[item.Key];
                    rowArray[2] = item.Value;
                    newRow.ItemArray = rowArray;
                }

                dataGridView1.DataSource = dataSource;
                dataGridView1.AutoResizeColumns();

                var BordaWinner = orderedList.First().Key;
                //var condorcetWinner = false;
                var condorcetSpoilers = orderedList.Skip(1).Where(i => EvaluateWinner(BordaWinner, i.Key) != BordaWinner).Select(x => movies[x.Key]).ToList();


                if (condorcetSpoilers.Any())
                {
                    Debug.WriteLine("The condorcet condition is RUINED by these movies: " + condorcetSpoilers.Aggregate((x, y) => x + " " + y));
                }
                else
                {
                    Debug.WriteLine("The condorcet condition is satisfied");
                }

                //remove each column
                //skip first column of names
                for (var j = 0; j < input.Columns.Count - 1; j++)
                {

                    var bordaCountTemp = new Dictionary<int, int>();
                    for (var i = 0; i < input.Columns.Count - 1; i++)
                    {
                        bordaCountTemp.Add(i, 0);
                    }

                    if (j == orderedList.First().Key)
                    {
                        //dont test removing winner
                        continue;
                    }

                    var removedValue = 0;
                    foreach (DataRow team in input.Rows)
                    {
                        for (var i = 0; i < input.Columns.Count - 1; i++)
                        {
                            if (i == j)
                            {
                                bordaCountTemp[i] = 0;
                                removedValue = oneIndexing ? Convert.ToInt32(team.ItemArray[i + 1]) - 1 : Convert.ToInt32(team.ItemArray[i + 1]);
                                break;
                            }
                        }
                        for (var i = 0; i < input.Columns.Count - 1; i++)
                        {
                            var value = oneIndexing ? Convert.ToInt32(team.ItemArray[i + 1]) - 1 : Convert.ToInt32(team.ItemArray[i + 1]);
                            if (value > removedValue)
                            {
                                value--;
                            }
                            bordaCountTemp[i] += value;

                        }
                    }

                    var orderedListTemp = bordaCountTemp.ToList().OrderByDescending(x => x.Value).ThenBy(x => movieTitles[x.Key]);


                    int[] orderArray = new int[input.Columns.Count - 2];
                    int[] tempArray = new int[input.Columns.Count - 2];
                    int k = 0;
                    foreach (var item in orderedList)
                    {
                        if (item.Key != j)
                        {
                            orderArray[k] = item.Key;
                            k++;
                        }
                    }
                    k = 0;
                    foreach (var item in orderedListTemp)
                    {
                        if (item.Key != j)
                        {
                            tempArray[k] = item.Key;
                            k++;
                        }



                        if (!orderArray.SequenceEqual(tempArray))
                        {
                            if (orderArray[0] != tempArray[0])
                            {
                                Debug.WriteLine("winner spoiler: ");
                            }
                            Debug.WriteLine(movieTitles[j]);
                        }
                    }

                }

            }
            else
            {
                //TODO error
            }
        }

        private int EvaluateWinner(int contestant1, int contestant2)
        {
            var comparison = 0;
            for (var i = 0; i < data.Rows.Count; i++)
            {
                comparison += (Convert.ToInt32(data.Rows[i].ItemArray[contestant1 + 1]) > Convert.ToInt32(data.Rows[i].ItemArray[contestant2 + 1]) ? 1 : -1);
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
            exportFilePath = exporter.ExportToExcel("Round4_Amirite.xls", 1);

        }

        private void sendEmailButton_Click(object sender, EventArgs e)
        {
            EmailForm emailForm = new EmailForm(exportFilePath, 4);
            emailForm.Show();
        }
    }
}
