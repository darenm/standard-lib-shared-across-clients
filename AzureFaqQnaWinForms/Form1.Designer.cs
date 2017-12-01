namespace AzureFaqQnaWinForms
{
    partial class Form1
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
            this.SearchQuery = new System.Windows.Forms.TextBox();
            this.AskQuestion = new System.Windows.Forms.Button();
            this.AskQuestionProgress = new System.Windows.Forms.ProgressBar();
            this.ResponseList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SearchQuery
            // 
            this.SearchQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchQuery.Location = new System.Drawing.Point(12, 12);
            this.SearchQuery.Name = "SearchQuery";
            this.SearchQuery.Size = new System.Drawing.Size(748, 26);
            this.SearchQuery.TabIndex = 0;
            // 
            // AskQuestion
            // 
            this.AskQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AskQuestion.Location = new System.Drawing.Point(766, 12);
            this.AskQuestion.Name = "AskQuestion";
            this.AskQuestion.Size = new System.Drawing.Size(120, 26);
            this.AskQuestion.TabIndex = 1;
            this.AskQuestion.Text = "Ask Question";
            this.AskQuestion.UseVisualStyleBackColor = true;
            this.AskQuestion.Click += new System.EventHandler(this.AskQuestion_Click);
            // 
            // AskQuestionProgress
            // 
            this.AskQuestionProgress.Location = new System.Drawing.Point(766, 12);
            this.AskQuestionProgress.Name = "AskQuestionProgress";
            this.AskQuestionProgress.Size = new System.Drawing.Size(120, 26);
            this.AskQuestionProgress.TabIndex = 2;
            this.AskQuestionProgress.Visible = false;
            // 
            // ResponseList
            // 
            this.ResponseList.Location = new System.Drawing.Point(12, 85);
            this.ResponseList.Multiline = true;
            this.ResponseList.Name = "ResponseList";
            this.ResponseList.ReadOnly = true;
            this.ResponseList.Size = new System.Drawing.Size(874, 581);
            this.ResponseList.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 678);
            this.Controls.Add(this.ResponseList);
            this.Controls.Add(this.AskQuestionProgress);
            this.Controls.Add(this.AskQuestion);
            this.Controls.Add(this.SearchQuery);
            this.Name = "Form1";
            this.Text = "Azure FAQ QnA Bot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchQuery;
        private System.Windows.Forms.Button AskQuestion;
        private System.Windows.Forms.ProgressBar AskQuestionProgress;
        private System.Windows.Forms.TextBox ResponseList;
    }
}

