using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private Mode mode;

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
                    for (var i = voteCounts.Rows.Count+1; i <= temp; i++)
                    {
                        voteCounts.Rows.Add(i, "", 0);
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
                if (voteCounts.Rows.Count < temp)
                {
                    for (var i = voteCounts.Rows.Count + 1; i <= temp; i++)
                    {
                        voteCounts.Rows.Add("Team " + i);
                    }
                }
                else
                {
                    for (var i = voteCounts.Rows.Count - 1; i >= temp; i--)
                    {
                        voteCounts.Rows.Remove(voteCounts.Rows[i]);
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
            ItemCount.Enabled = true;
        }

        private void SetupBorda_Click(object sender, EventArgs e)
        {
            mode = Mode.Borda;
            voteCounts = new DataTable();
            int temp;
            if (Int32.TryParse(ItemCount.Text, out temp))
            {
                RestoreDefaults();
                TeamCount.Enabled = true;
                ItemCount.Enabled = false;
                voteCounts.Columns.Add("Team Name");
                for (var i = 1; i <= temp; i++)
                {
                    voteCounts.Columns.Add(i.ToString(), typeof (int));
                }
                
                VoteCounts.DataSource = voteCounts;
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
                for (var i = 1; i <= temp; i++)
                {
                    voteCounts.Columns.Add("Round " + i.ToString(), typeof(int));
                }

                for (var i = 1; i <= temp; i++)
                {
                    voteCounts.Rows.Add(i.ToString());
                }

                CustomLabel.Text = "Round:";
                CustomInput.Text = 1.ToString();
                CustomButton.Text = "Advance Round";
                CustomLabel.Visible = true;
                CustomInput.Visible = true;
                CustomButton.Visible = true;
                CustomButton.Click += AdvanceRound;

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
                    if (Int32.TryParse(voteCounts.Rows[i][tempRound].ToString(), out temp1) && temp1 < minValue)
                    {
                        minIndex = i;
                        minValue = temp1;
                    }
                }

                for (var i = tempRound; i <= tempItemCount; i++)
                {
                    VoteCounts.Rows[minIndex].Cells[i].Style.BackColor = Color.Red;
                    VoteCounts.Rows[minIndex].Cells[i].ReadOnly = true;
                }

                CustomInput.Text = (tempRound + 1).ToString();
            }
            else
            {
                //TODO display error of some sort (Round number must be an int you dummy!).
            }
        }

        private void SetupPairwise_Click(object sender, EventArgs e)
        {
            mode = Mode.PairwiseElimination;
            //TODO figure out what goes here
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

        //TODO write analysis handlers
    }
}
