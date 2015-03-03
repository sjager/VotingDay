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
            this.exportButton = new System.Windows.Forms.Button();
            this.sendEmailButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.approvalAnalysisDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DismissButton
            // 
            this.DismissButton.Location = new System.Drawing.Point(111, 307);
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
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(221, 307);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 3;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // sendEmailButton
            // 
            this.sendEmailButton.Location = new System.Drawing.Point(324, 347);
            this.sendEmailButton.Name = "sendEmailButton";
            this.sendEmailButton.Size = new System.Drawing.Size(75, 23);
            this.sendEmailButton.TabIndex = 4;
            this.sendEmailButton.Text = "Send Email";
            this.sendEmailButton.UseVisualStyleBackColor = true;
            this.sendEmailButton.Click += new System.EventHandler(this.sendEmailButton_Click);
            // 
            // Approval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 423);
            this.Controls.Add(this.sendEmailButton);
            this.Controls.Add(this.exportButton);
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
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button sendEmailButton;
    }
}