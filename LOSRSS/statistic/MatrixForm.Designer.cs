namespace LOSRSS.statistic
{
    partial class MatrixForm
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
            this.MatrixText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // MatrixText
            // 
            this.MatrixText.Location = new System.Drawing.Point(13, 14);
            this.MatrixText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MatrixText.Name = "MatrixText";
            this.MatrixText.Size = new System.Drawing.Size(836, 517);
            this.MatrixText.TabIndex = 1;
            this.MatrixText.Text = "";
            this.MatrixText.WordWrap = false;
            // 
            // MatrixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 542);
            this.Controls.Add(this.MatrixText);
            this.Name = "MatrixForm";
            this.Text = "MatrixForm";
            this.Load += new System.EventHandler(this.MatrixForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox MatrixText;
    }
}