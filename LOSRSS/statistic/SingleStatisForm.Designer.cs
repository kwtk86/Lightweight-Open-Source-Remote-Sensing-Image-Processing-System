namespace LOSRSS
{
    partial class SingleStatisForm
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
            this.StatisList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // StatisList
            // 
            this.StatisList.GridLines = true;
            this.StatisList.HideSelection = false;
            this.StatisList.Location = new System.Drawing.Point(12, 12);
            this.StatisList.Name = "StatisList";
            this.StatisList.Size = new System.Drawing.Size(580, 279);
            this.StatisList.TabIndex = 0;
            this.StatisList.UseCompatibleStateImageBehavior = false;
            this.StatisList.View = System.Windows.Forms.View.Details;
            // 
            // SingleStatisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 307);
            this.Controls.Add(this.StatisList);
            this.Name = "SingleStatisForm";
            this.Text = "单波段统计";
            this.Load += new System.EventHandler(this.StatisForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView StatisList;
    }
}