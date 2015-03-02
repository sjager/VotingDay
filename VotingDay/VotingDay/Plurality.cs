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
    public partial class Plurality : Form
    {
        public Plurality(DataTable input)
        {

            InitializeComponent();
            //DisplayPreferences.DataSource = displayPreferences;

            Dictionary<int, int> dictionary =
	            new Dictionary<int, int>();

	        


            for (int i = 0; i <input.Rows.Count; i++){
                dictionary.Add( Convert.ToInt32(input.Rows[i][0]), Convert.ToInt32(input.Rows[i][2]));
            }

            //sort dictionary
            List<KeyValuePair<int, int>> myList = dictionary.ToList();


            myList.Sort(
                delegate(KeyValuePair<int, int> firstPair,
                KeyValuePair<int, int> nextPair)
                {
                    return nextPair.Value.CompareTo(firstPair.Value);
                }
            );

            IDictionary<int, int> sortedDictionary =
                myList.ToDictionary(pair => pair.Key, pair => pair.Value);

            DataTable table = new DataTable("Order");
            //for (int i = 0; i < 2; i++)
            //{
            //    table.Columns.Add();
            //}

            table.Columns.Add("id", typeof(int));
            table.Columns.Add("count", typeof(int));
            foreach (int id in sortedDictionary.Keys)
            {
                DataRow newRow = table.Rows.Add();
                object[] rowArray = new object[2];
                rowArray[0] = id;
                rowArray[1] = sortedDictionary[id];
                newRow.ItemArray = rowArray;
            }

            DisplayPreferences.DataSource = table;
            DisplayPreferences.AutoResizeColumns();
        }

     

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
