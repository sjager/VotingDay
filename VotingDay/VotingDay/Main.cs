using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VotingDay
{
    public partial class Main : Form
    {
        private DataTable voteCounts = new DataTable();
        private DataTable preferenceOrders = new DataTable();
        private Mode mode;
        private Form _analyzeForm;
        public List<string> MovieTitleList = new List<string>();

        public enum Mode
        {
            Plurality,
            Cumulative,
            Approval,
            Borda,
            PluralityElimination,
            PairwiseElimination
        }

        public Main()
        {
            InitializeComponent();
            VoteCounts.DataSource = voteCounts;
        }

        public void RestoreDefaults()
        {
            ItemCount.Enabled = false;
            TeamCount.Enabled = false;
            CustomLabel.Visible = false;
            CustomInput.Visible = false;
            CustomButton.Visible = false;
            RemoveClickEvent(CustomButton);
            RemoveClickEvent(AnalyzeButton);
        }

        private void ItemCount_TextChanged(object sender, EventArgs e)
        {
            int temp;
            if (Int32.TryParse(ItemCount.Text, out temp))
            {
                if (voteCounts.Rows.Count < temp)
                {
                    for (var i = voteCounts.Rows.Count; i < temp; i++)
                    {
                        voteCounts.Rows.Add(i, MovieTitleList.Count() > i ? MovieTitleList[i] : "", 0);
                    }
                }
                else
                {
                    for (var i = voteCounts.Rows.Count-1; i >= temp; i--)
                    {
                        voteCounts.Rows.Remove(voteCounts.Rows[i]);
                    }
                }
            }
        }

        private void TeamCount_TextChanged(object sender, EventArgs e)
        {
            int temp;
            if (Int32.TryParse(TeamCount.Text, out temp))
            {
                if (preferenceOrders.Rows.Count < temp)
                {
                    for (var i = preferenceOrders.Rows.Count; i < temp; i++)
                    {
                        preferenceOrders.Rows.Add("Team " + i);
                    }
                }
                else
                {
                    for (var i = preferenceOrders.Rows.Count - 1; i >= temp; i--)
                    {
                        preferenceOrders.Rows.Remove(preferenceOrders.Rows[i]);
                    }
                }
            }
        }

        private void SetupPlurality_Click(object sender, EventArgs e)
        {
            mode = Mode.Plurality;
            voteCounts = new DataTable();
            voteCounts.Columns.Add("id", typeof(int));
            voteCounts.Columns.Add("name", typeof(string));
            voteCounts.Columns.Add("count", typeof(int));
            VoteCounts.DataSource = voteCounts;
            VoteCounts.AutoResizeColumns();
            RestoreDefaults();
            ItemCount.Enabled = true;
            AnalyzeButton.Click += AnalyzePlurality;
        }

        private void SetupCumulative_Click(object sender, EventArgs e)
        {
            mode = Mode.Cumulative;
            voteCounts = new DataTable();
            voteCounts.Columns.Add("id", typeof(int));
            voteCounts.Columns.Add("name", typeof(string));
            voteCounts.Columns.Add("count", typeof(int));
            VoteCounts.DataSource = voteCounts;
            VoteCounts.AutoResizeColumns();
            RestoreDefaults();
            CustomLabel.Text = "Vote Number(k)";
            ItemCount.Enabled = true;
            CustomLabel.Visible = true;
            CustomInput.Visible = true;
            AnalyzeButton.Click += AnalyzeCumulative;
        }

        private void SetupApproval_Click(object sender, EventArgs e)
        {
            mode = Mode.Approval;
            voteCounts = new DataTable();
            voteCounts.Columns.Add("id", typeof(int));
            voteCounts.Columns.Add("name", typeof(string));
            voteCounts.Columns.Add("count", typeof(int));
            VoteCounts.DataSource = voteCounts;
            VoteCounts.AutoResizeColumns();
            RestoreDefaults();
            AnalyzeButton.Click += AnalyzeApproval;
            ItemCount.Enabled = true;
        }

        private void SetupBorda_Click(object sender, EventArgs e)
        {
            mode = Mode.Borda;
            preferenceOrders = new DataTable();
            int temp;
            if (Int32.TryParse(ItemCount.Text, out temp))
            {
                RestoreDefaults();
                TeamCount.Enabled = true;
                ItemCount.Enabled = false;
                preferenceOrders.Columns.Add("Team Name");
                for (var i = 0; i < temp; i++)
                {
                    preferenceOrders.Columns.Add(i.ToString(), typeof (int));
                }

                AnalyzeButton.Click += AnalyzeBorda;

                VoteCounts.DataSource = preferenceOrders;
                VoteCounts.AutoResizeColumns();
            }
            else
            {
                //TODO display error of some sort ("ItemCount must be an int before Borda Voting").
            }
        }

        private void SetupPluralityElimination_Click(object sender, EventArgs e)
        {
            mode = Mode.PluralityElimination;
            voteCounts = new DataTable();
            int temp;
            if (Int32.TryParse(ItemCount.Text, out temp))
            {
                RestoreDefaults();
                ItemCount.Enabled = false;
                voteCounts.Columns.Add("Item Number");
                for (var i = 0; i < temp; i++)
                {
                    voteCounts.Columns.Add("Round " + i.ToString(), typeof(int));
                }

                for (var i = 0; i < temp; i++)
                {
                    voteCounts.Rows.Add(MovieTitleList[i]);
                }

                CustomLabel.Text = "Round:";
                CustomInput.Text = 1.ToString();
                CustomButton.Text = "Advance Round";
                CustomLabel.Visible = true;
                CustomInput.Visible = true;
                CustomButton.Visible = true;
                CustomButton.Click += AdvanceRound;

                AnalyzeButton.Click += AnalyzePluralityWithElimination;

                VoteCounts.DataSource = voteCounts;
                VoteCounts.AutoResizeColumns();
            }
            else
            {
                //TODO display error of some sort ("ItemCount must be an int before Borda Voting").
            }
        }

        private void AdvanceRound(object sender, EventArgs e)
        {
            int tempRound, tempItemCount;
            if (Int32.TryParse(CustomInput.Text, out tempRound) && Int32.TryParse(ItemCount.Text, out tempItemCount))
            {
                //get row with minimum value
                int minIndex = 0, minValue = Int32.MaxValue, temp1; 
                for (var i = 0; i < tempItemCount; i++)
                {
                    if (VoteCounts.Rows[i].Cells[tempRound].Style.BackColor != Color.Red && Int32.TryParse(voteCounts.Rows[i][tempRound].ToString(), out temp1) && temp1 <= minValue)
                    {
                        if (temp1 < minValue)
                        {
                            minIndex = i;
                        } else if (temp1 == minValue && MovieTitleList[i].CompareTo(MovieTitleList[minIndex]) > 0)
                        {
                            minIndex = i;
                        }
                        minValue = temp1;
                    }
                }

                for (var i = tempRound; i <= tempItemCount; i++)
                {
                    for (var j = 0; j < VoteCounts.RowCount; j++)
                    {
                        if (j == minIndex)
                        {
                            VoteCounts.Rows[j].Cells[i].Style.BackColor = Color.Red;
                            VoteCounts.Rows[minIndex].Cells[i].ReadOnly = true;
                        }
                        VoteCounts.Rows[j].Cells[i].Value = Convert.ToInt32(voteCounts.Rows[j][tempRound]);
                    }
                }
                CustomInput.Text = (++tempRound).ToString();
            }
            else
            {
                //TODO display error of some sort (Round number must be an int you dummy!).
            }
        }

        private void SetupPairwise_Click(object sender, EventArgs e)
        {
            mode = Mode.PairwiseElimination;
            RestoreDefaults();
            AnalyzeButton.Click += AnalyzePairwise;

            //Use table from borda voting
            VoteCounts.DataSource = preferenceOrders;
            VoteCounts.AutoResizeColumns();
        }

        private void RemoveClickEvent(Button b)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick",
                BindingFlags.Static | BindingFlags.NonPublic);
            object obj = f1.GetValue(b);
            PropertyInfo pi = b.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
            list.RemoveHandler(obj, list[obj]);
        }

        private void AnalyzePlurality(object sender, EventArgs e)
        {
            _analyzeForm = new Plurality(voteCounts, MovieTitleList);
            _analyzeForm.Show();
        }

        private void AnalyzeCumulative(object sender, EventArgs e)
        {
            _analyzeForm = new Cumulative(voteCounts);
            _analyzeForm.Show();
        }

        private void AnalyzeApproval(object sender, EventArgs e)
        {
            _analyzeForm = new Approval(voteCounts);
            _analyzeForm.Show();
        }

        private void AnalyzeBorda(object sender, EventArgs e)
        {
            _analyzeForm = new Borda(voteCounts, MovieTitleList);
            _analyzeForm.Show();
        }

        private void AnalyzePluralityWithElimination(object sender, EventArgs e)
        {
            _analyzeForm = new PluralityWithElimination(voteCounts, MovieTitleList);
            _analyzeForm.Show();
        }

        private void AnalyzePairwise(object sender, EventArgs e)
        {
            _analyzeForm = new PairwiseElimination(preferenceOrders, MovieTitleList);
            _analyzeForm.Show();
        }

        private void ImportItemNamesButton_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var filename = dlg.FileName;

                string sFileContents = "";

                using (StreamReader oStreamReader = new StreamReader(File.OpenRead(filename)))
                {
                    sFileContents = oStreamReader.ReadToEnd();
                }

                string[] sFileLines = sFileContents.Split(Environment.NewLine.ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (string sFileLine in sFileLines)
                {
                    MovieTitleList.Add(sFileLine.Contains(",") ? sFileLine.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).First() : sFileLine);
                }
                ImportItemNamesButton.Text = MovieTitleList.Count() + " items imported";
            }
        }

        private void VoteCounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var clipboard = Clipboard.GetText();
            string[] clipboardRows = clipboard.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var row = e.RowIndex;
            for (var i = 0; i < clipboardRows.Length; i++, row++)
            {
                var clipboardCols = clipboardRows[i].Split(",".ToCharArray());
                var col = e.ColumnIndex;
                for (var j = 0; j < clipboardCols.Length; j++, col++)
                {
                    try
                    {
                        voteCounts.Rows[row][col] = clipboardCols[j];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        
                    }
                }
            }
        } 
    }
}
