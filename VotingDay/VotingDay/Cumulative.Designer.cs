namespace VotingDay
{
    partial class Cumulative
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
            this.DismissButton = new System.Windows.Forms.Button();
            this.cumulativeAnalysisDataGrid = new System.Windows.Forms.DataGridView();
            this.exportButton = new System.Windows.Forms.Button();
            this.sendEmailButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cumulativeAnalysisDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DismissButton
            // 
            this.DismissButton.Location = new System.Drawing.Point(89, 225);
            this.DismissButton.Name = "DismissButton";
            this.DismissButton.Size = new System.Drawing.Size(70, 28);
            this.DismissButton.TabIndex = 1;
            this.DismissButton.Text = "Ok";
            this.DismissButton.UseVisualStyleBackColor = true;
            // 
            // cumulativeAnalysisDataGrid
            // 
            this.cumulativeAnalysisDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cumulativeAnalysisDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cumulativeAnalysisDataGrid.Location = new System.Drawing.Point(21, 21);
            this.cumulativeAnalysisDataGrid.Name = "cumulativeAnalysisDataGrid";
            this.cumulativeAnalysisDataGrid.Size = new System.Drawing.Size(357, 150);
            this.cumulativeAnalysisDataGrid.TabIndex = 2;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(176, 228);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 3;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // sendEmailButton
            // 
            this.sendEmailButton.Location = new System.Drawing.Point(270, 228);
            this.sendEmailButton.Name = "sendEmailButton";
            this.sendEmailButton.Size = new System.Drawing.Size(75, 23);
            this.sendEmailButton.TabIndex = 4;
            this.sendEmailButton.Text = "Send Email";
            this.sendEmailButton.UseVisualStyleBackColor = true;
            this.sendEmailButton.Click += new System.EventHandler(this.sendEmailButton_Click);
            // 
            // Cumulative
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 317);
            this.Controls.Add(this.sendEmailButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.cumulativeAnalysisDataGrid);
            this.Controls.Add(this.DismissButton);
            this.Name = "Cumulative";
            this.Text = "Cumulative";
            ((System.ComponentModel.ISupportInitialize)(this.cumulativeAnalysisDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DismissButton;
        private System.Windows.Forms.DataGridView cumulativeAnalysisDataGrid;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button sendEmailButton;
    }
}