namespace VotingDay
{
    partial class Approval
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
            this.approvalAnalysisDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.approvalAnalysisDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DismissButton
            // 
            this.DismissButton.Location = new System.Drawing.Point(181, 383);
            this.DismissButton.Name = "DismissButton";
            this.DismissButton.Size = new System.Drawing.Size(70, 28);
            this.DismissButton.TabIndex = 1;
            this.DismissButton.Text = "Ok";
            this.DismissButton.UseVisualStyleBackColor = true;
            // 
            // approvalAnalysisDataGrid
            // 
            this.approvalAnalysisDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.approvalAnalysisDataGrid.Location = new System.Drawing.Point(12, 12);
            this.approvalAnalysisDataGrid.Name = "approvalAnalysisDataGrid";
            this.approvalAnalysisDataGrid.Size = new System.Drawing.Size(410, 232);
            this.approvalAnalysisDataGrid.TabIndex = 2;
            // 
            // Approval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 423);
            this.Controls.Add(this.approvalAnalysisDataGrid);
            this.Controls.Add(this.DismissButton);
            this.Name = "Approval";
            this.Text = "Approval";
            ((System.ComponentModel.ISupportInitialize)(this.approvalAnalysisDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DismissButton;
        private System.Windows.Forms.DataGridView approvalAnalysisDataGrid;
    }
}