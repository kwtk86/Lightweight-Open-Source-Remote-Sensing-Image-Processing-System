﻿namespace LOSRSS.files
{
    partial class BandSelectForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnSaveByBand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.MultiColumn = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(397, 184);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnSaveByBand
            // 
            this.btnSaveByBand.Location = new System.Drawing.Point(297, 202);
            this.btnSaveByBand.Name = "btnSaveByBand";
            this.btnSaveByBand.Size = new System.Drawing.Size(112, 44);
            this.btnSaveByBand.TabIndex = 1;
            this.btnSaveByBand.Text = "保存";
            this.btnSaveByBand.UseVisualStyleBackColor = true;
            this.btnSaveByBand.Click += new System.EventHandler(this.btnSaveByBand_Click);
            // 
            // BandSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 249);
            this.Controls.Add(this.btnSaveByBand);
            this.Controls.Add(this.listBox1);
            this.Name = "BandSelectForm";
            this.Text = "波段选择";
            this.Load += new System.EventHandler(this.BandSelectForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSaveByBand;
    }
}