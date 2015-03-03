﻿using System;
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
    public partial class Approval : Form
    {

        public string exportFilePath;

        public Approval(DataTable input)
        {
            InitializeComponent();

            var candidateList = new List<Candidate>();

            foreach (DataRow dr in input.Rows)
            {
                Candidate rowCandidate = new Candidate()
                {
                    Name = dr[1].ToString(),
                    Votes = Int16.Parse(dr[2].ToString())
                };

                candidateList.Add(rowCandidate);
            }

            var results = new VotingResults(candidateList);

            approvalAnalysisDataGrid.ReadOnly = true;

            var nameCol = new DataGridViewTextBoxColumn();
            var votesCol = new DataGridViewTextBoxColumn();
            var rankCol = new DataGridViewTextBoxColumn();

            nameCol.HeaderText = "Name";
            votesCol.HeaderText = "Votes";
            rankCol.HeaderText = "Rank";

            approvalAnalysisDataGrid.Columns.AddRange(new DataGridViewColumn[] { rankCol, nameCol, votesCol });

            approvalAnalysisDataGrid.Rows.Add("Rank", "Name", "Votes");

            int rank = 1;
            foreach (Candidate c in results.Candidates)
            {
                AddRow(c, rank);
                rank++;
            }
        }

        public void AddRow(Candidate candidate, int rank)
        {
            approvalAnalysisDataGrid.Rows.Add(rank, candidate.Name, candidate.Votes);
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {

            Exporter exporter = new Exporter(approvalAnalysisDataGrid);
            exportFilePath = exporter.ExportToExcel("Round3_Amirite.xls");
            
        }

        private void sendEmailButton_Click(object sender, EventArgs e)
        {
            EmailForm emailForm = new EmailForm(exportFilePath);
            emailForm.Show();
        }
    }
}
