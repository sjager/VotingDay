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
        public PairwiseElimination(DataTable input)
        {
            InitializeComponent();
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
