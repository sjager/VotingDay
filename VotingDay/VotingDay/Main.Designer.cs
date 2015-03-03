namespace VotingDay
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VoteCounts = new System.Windows.Forms.DataGridView();
            this.ItemNumberInputLabel = new System.Windows.Forms.Label();
            this.ItemCount = new System.Windows.Forms.TextBox();
            this.TeamCountLabel = new System.Windows.Forms.Label();
            this.TeamCount = new System.Windows.Forms.TextBox();
            this.SetupPlurality = new System.Windows.Forms.Button();
            this.SetupCumulative = new System.Windows.Forms.Button();
            this.SetupApproval = new System.Windows.Forms.Button();
            this.SetupBorda = new System.Windows.Forms.Button();
            this.SetupPluralityElimination = new System.Windows.Forms.Button();
            this.SetupPairwise = new System.Windows.Forms.Button();
            this.CustomLabel = new System.Windows.Forms.Label();
            this.CustomInput = new System.Windows.Forms.TextBox();
            this.AnalyzeButton = new System.Windows.Forms.Button();
            this.CustomButton = new System.Windows.Forms.Button();
            this.ImportItemNamesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VoteCounts)).BeginInit();
            this.SuspendLayout();
            // 
            // VoteCounts
            // 
            this.VoteCounts.AllowUserToAddRows = false;
            this.VoteCounts.AllowUserToDeleteRows = false;
            this.VoteCounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VoteCounts.Location = new System.Drawing.Point(12, 73);
            this.VoteCounts.Name = "VoteCounts";
            this.VoteCounts.RowHeadersWidth = 10;
            this.VoteCounts.Size = new System.Drawing.Size(361, 209);
            this.VoteCounts.TabIndex = 0;
            this.VoteCounts.Tag = "VoteCounts";
            this.VoteCounts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VoteCounts_CellDoubleClick);
            // 
            // ItemNumberInputLabel
            // 
            this.ItemNumberInputLabel.AutoSize = true;
            this.ItemNumberInputLabel.Location = new System.Drawing.Point(9, 9);
            this.ItemNumberInputLabel.Name = "ItemNumberInputLabel";
            this.ItemNumberInputLabel.Size = new System.Drawing.Size(70, 13);
            this.ItemNumberInputLabel.TabIndex = 1;
            this.ItemNumberInputLabel.Text = "Item Number:";
            // 
            // ItemCount
            // 
            this.ItemCount.Enabled = false;
            this.ItemCount.Location = new System.Drawing.Point(98, 6);
            this.ItemCount.Name = "ItemCount";
            this.ItemCount.Size = new System.Drawing.Size(33, 20);
            this.ItemCount.TabIndex = 2;
            this.ItemCount.TextChanged += new System.EventHandler(this.ItemCount_TextChanged);
            // 
            // TeamCountLabel
            // 
            this.TeamCountLabel.AutoSize = true;
            this.TeamCountLabel.Location = new System.Drawing.Point(9, 37);
            this.TeamCountLabel.Name = "TeamCountLabel";
            this.TeamCountLabel.Size = new System.Drawing.Size(77, 13);
            this.TeamCountLabel.TabIndex = 3;
            this.TeamCountLabel.Text = "Team Number:";
            // 
            // TeamCount
            // 
            this.TeamCount.Enabled = false;
            this.TeamCount.Location = new System.Drawing.Point(98, 34);
            this.TeamCount.Name = "TeamCount";
            this.TeamCount.Size = new System.Drawing.Size(33, 20);
            this.TeamCount.TabIndex = 4;
            this.TeamCount.TextChanged += new System.EventHandler(this.TeamCount_TextChanged);
            // 
            // SetupPlurality
            // 
            this.SetupPlurality.Location = new System.Drawing.Point(393, 43);
            this.SetupPlurality.Name = "SetupPlurality";
            this.SetupPlurality.Size = new System.Drawing.Size(154, 33);
            this.SetupPlurality.TabIndex = 5;
            this.SetupPlurality.Text = "Set Up Plurality Vote";
            this.SetupPlurality.UseVisualStyleBackColor = true;
            this.SetupPlurality.Click += new System.EventHandler(this.SetupPlurality_Click);
            // 
            // SetupCumulative
            // 
            this.SetupCumulative.Location = new System.Drawing.Point(393, 82);
            this.SetupCumulative.Name = "SetupCumulative";
            this.SetupCumulative.Size = new System.Drawing.Size(154, 33);
            this.SetupCumulative.TabIndex = 6;
            this.SetupCumulative.Text = "Set Up Cumulative Vote";
            this.SetupCumulative.UseVisualStyleBackColor = true;
            this.SetupCumulative.Click += new System.EventHandler(this.SetupCumulative_Click);
            // 
            // SetupApproval
            // 
            this.SetupApproval.Location = new System.Drawing.Point(393, 121);
            this.SetupApproval.Name = "SetupApproval";
            this.SetupApproval.Size = new System.Drawing.Size(154, 33);
            this.SetupApproval.TabIndex = 7;
            this.SetupApproval.Text = "Set Up Approval Vote";
            this.SetupApproval.UseVisualStyleBackColor = true;
            this.SetupApproval.Click += new System.EventHandler(this.SetupApproval_Click);
            // 
            // SetupBorda
            // 
            this.SetupBorda.Location = new System.Drawing.Point(393, 160);
            this.SetupBorda.Name = "SetupBorda";
            this.SetupBorda.Size = new System.Drawing.Size(154, 33);
            this.SetupBorda.TabIndex = 8;
            this.SetupBorda.Text = "Set Up Borda Vote";
            this.SetupBorda.UseVisualStyleBackColor = true;
            this.SetupBorda.Click += new System.EventHandler(this.SetupBorda_Click);
            // 
            // SetupPluralityElimination
            // 
            this.SetupPluralityElimination.Location = new System.Drawing.Point(393, 199);
            this.SetupPluralityElimination.Name = "SetupPluralityElimination";
            this.SetupPluralityElimination.Size = new System.Drawing.Size(154, 33);
            this.SetupPluralityElimination.TabIndex = 9;
            this.SetupPluralityElimination.Text = "Set Up Plurality with Elim.";
            this.SetupPluralityElimination.UseVisualStyleBackColor = true;
            this.SetupPluralityElimination.Click += new System.EventHandler(this.SetupPluralityElimination_Click);
            // 
            // SetupPairwise
            // 
            this.SetupPairwise.Location = new System.Drawing.Point(393, 238);
            this.SetupPairwise.Name = "SetupPairwise";
            this.SetupPairwise.Size = new System.Drawing.Size(154, 33);
            this.SetupPairwise.TabIndex = 10;
            this.SetupPairwise.Text = "Set Up Pairwise Elimination";
            this.SetupPairwise.UseVisualStyleBackColor = true;
            this.SetupPairwise.Click += new System.EventHandler(this.SetupPairwise_Click);
            // 
            // CustomLabel
            // 
            this.CustomLabel.AutoSize = true;
            this.CustomLabel.Location = new System.Drawing.Point(173, 12);
            this.CustomLabel.Name = "CustomLabel";
            this.CustomLabel.Size = new System.Drawing.Size(68, 13);
            this.CustomLabel.TabIndex = 11;
            this.CustomLabel.Text = "CustomLabel";
            this.CustomLabel.Visible = false;
            // 
            // CustomInput
            // 
            this.CustomInput.Location = new System.Drawing.Point(272, 9);
            this.CustomInput.Name = "CustomInput";
            this.CustomInput.Size = new System.Drawing.Size(38, 20);
            this.CustomInput.TabIndex = 12;
            this.CustomInput.Visible = false;
            // 
            // AnalyzeButton
            // 
            this.AnalyzeButton.Location = new System.Drawing.Point(393, 279);
            this.AnalyzeButton.Name = "AnalyzeButton";
            this.AnalyzeButton.Size = new System.Drawing.Size(154, 46);
            this.AnalyzeButton.TabIndex = 13;
            this.AnalyzeButton.Text = "Analyze!";
            this.AnalyzeButton.UseVisualStyleBackColor = true;
            // 
            // CustomButton
            // 
            this.CustomButton.Location = new System.Drawing.Point(194, 34);
            this.CustomButton.Name = "CustomButton";
            this.CustomButton.Size = new System.Drawing.Size(92, 23);
            this.CustomButton.TabIndex = 14;
            this.CustomButton.Text = "CustomButton";
            this.CustomButton.UseVisualStyleBackColor = true;
            this.CustomButton.Visible = false;
            // 
            // ImportItemNamesButton
            // 
            this.ImportItemNamesButton.Location = new System.Drawing.Point(392, 4);
            this.ImportItemNamesButton.Name = "ImportItemNamesButton";
            this.ImportItemNamesButton.Size = new System.Drawing.Size(154, 33);
            this.ImportItemNamesButton.TabIndex = 15;
            this.ImportItemNamesButton.Text = "Import Item Names";
            this.ImportItemNamesButton.UseVisualStyleBackColor = true;
            this.ImportItemNamesButton.Click += new System.EventHandler(this.ImportItemNamesButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 341);
            this.Controls.Add(this.ImportItemNamesButton);
            this.Controls.Add(this.CustomButton);
            this.Controls.Add(this.AnalyzeButton);
            this.Controls.Add(this.CustomInput);
            this.Controls.Add(this.CustomLabel);
            this.Controls.Add(this.SetupPairwise);
            this.Controls.Add(this.SetupPluralityElimination);
            this.Controls.Add(this.SetupBorda);
            this.Controls.Add(this.SetupApproval);
            this.Controls.Add(this.SetupCumulative);
            this.Controls.Add(this.SetupPlurality);
            this.Controls.Add(this.TeamCount);
            this.Controls.Add(this.TeamCountLabel);
            this.Controls.Add(this.ItemCount);
            this.Controls.Add(this.ItemNumberInputLabel);
            this.Controls.Add(this.VoteCounts);
            this.KeyPreview = true;
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.VoteCounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView VoteCounts;
        private System.Windows.Forms.Label ItemNumberInputLabel;
        private System.Windows.Forms.TextBox ItemCount;
        private System.Windows.Forms.Label TeamCountLabel;
        private System.Windows.Forms.TextBox TeamCount;
        private System.Windows.Forms.Button SetupPlurality;
        private System.Windows.Forms.Button SetupCumulative;
        private System.Windows.Forms.Button SetupApproval;
        private System.Windows.Forms.Button SetupBorda;
        private System.Windows.Forms.Button SetupPluralityElimination;
        private System.Windows.Forms.Button SetupPairwise;
        private System.Windows.Forms.Label CustomLabel;
        private System.Windows.Forms.TextBox CustomInput;
        private System.Windows.Forms.Button AnalyzeButton;
        private System.Windows.Forms.Button CustomButton;
        private System.Windows.Forms.Button ImportItemNamesButton;
    }
}

