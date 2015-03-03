namespace VotingDay
{
    partial class Plurality
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
            this.DisplayPreferences = new System.Windows.Forms.DataGridView();
            this.exportButton = new System.Windows.Forms.Button();
            this.sendEmailButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayPreferences)).BeginInit();
            this.SuspendLayout();
            // 
            // DismissButton
            // 
            this.DismissButton.Location = new System.Drawing.Point(26, 190);
            this.DismissButton.Name = "DismissButton";
            this.DismissButton.Size = new System.Drawing.Size(70, 28);
            this.DismissButton.TabIndex = 0;
            this.DismissButton.Text = "Ok";
            this.DismissButton.UseVisualStyleBackColor = true;
            this.DismissButton.Click += new System.EventHandler(this.DismissButton_Click);
            // 
            // DisplayPreferences
            // 
            this.DisplayPreferences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DisplayPreferences.Location = new System.Drawing.Point(0, 0);
            this.DisplayPreferences.Name = "DisplayPreferences";
            this.DisplayPreferences.Size = new System.Drawing.Size(240, 150);
            this.DisplayPreferences.TabIndex = 1;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(116, 190);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // sendEmailButton
            // 
            this.sendEmailButton.Location = new System.Drawing.Point(197, 190);
            this.sendEmailButton.Name = "sendEmailButton";
            this.sendEmailButton.Size = new System.Drawing.Size(75, 23);
            this.sendEmailButton.TabIndex = 3;
            this.sendEmailButton.Text = "Send Email";
            this.sendEmailButton.UseVisualStyleBackColor = true;
            this.sendEmailButton.Click += new System.EventHandler(this.sendEmailButton_Click);
            // 
            // Plurality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.sendEmailButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.DisplayPreferences);
            this.Controls.Add(this.DismissButton);
            this.Name = "Plurality";
            this.Text = "Plurality";
            ((System.ComponentModel.ISupportInitialize)(this.DisplayPreferences)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DismissButton;
        private System.Windows.Forms.DataGridView DisplayPreferences;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button sendEmailButton;
    }
}