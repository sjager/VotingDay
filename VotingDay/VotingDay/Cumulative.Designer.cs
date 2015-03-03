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
            ((System.ComponentModel.ISupportInitialize)(this.cumulativeAnalysisDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DismissButton
            // 
            this.DismissButton.Location = new System.Drawing.Point(165, 228);
            this.DismissButton.Name = "DismissButton";
            this.DismissButton.Size = new System.Drawing.Size(70, 28);
            this.DismissButton.TabIndex = 1;
            this.DismissButton.Text = "Ok";
            this.DismissButton.UseVisualStyleBackColor = true;
            // 
            // cumulativeAnalysisDataGrid
            // 
            this.cumulativeAnalysisDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cumulativeAnalysisDataGrid.Location = new System.Drawing.Point(21, 21);
            this.cumulativeAnalysisDataGrid.Name = "cumulativeAnalysisDataGrid";
            this.cumulativeAnalysisDataGrid.Size = new System.Drawing.Size(357, 150);
            this.cumulativeAnalysisDataGrid.TabIndex = 2;
            // 
            // Cumulative
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 317);
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
    }
}