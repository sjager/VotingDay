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
    public partial class Borda : Form
    {
        public Borda(DataTable input, List<string> movieTitles)
        {
            InitializeComponent();
            var bordaCount = new Dictionary<int, int>();
            for (var i = 0; i < input.Columns.Count - 1; i++)
            {
                bordaCount.Add(i, 0);
            }
            //determine 0 indexing or 1 indexing
            var oneIndexing = Enumerable.Range(1, input.Columns.Count-1).All(x => input.Rows[0].ItemArray.Contains(x));
            var zeroIndexing = Enumerable.Range(0, input.Columns.Count-1).All(x => input.Rows[0].ItemArray.Contains(x));

            if (oneIndexing ^ zeroIndexing)
            {
                foreach (DataRow team in input.Rows)
                {
                    for(var i=0; i<input.Columns.Count-1; i++)
                    {
                        bordaCount[i] += oneIndexing ? Convert.ToInt32(team.ItemArray[i+1]) - 1 : Convert.ToInt32(team.ItemArray[i+1]);
                    }
                }

                var orderedList = bordaCount.ToList().OrderByDescending(x => x.Value).ThenBy(x => movieTitles[x.Key]);
                var dataSource = new DataTable("Borda Results");
                dataSource.Columns.Add("id", typeof(int));
                dataSource.Columns.Add("name", typeof (string));
                dataSource.Columns.Add("result", typeof (int));
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

            }
            else
            {
                //TODO error
            }
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
