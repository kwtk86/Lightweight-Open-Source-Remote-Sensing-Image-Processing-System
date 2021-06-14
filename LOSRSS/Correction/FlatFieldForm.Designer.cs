namespace LOSRSS
{
    partial class FlatFieldForm
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
            this.flatFieldButton = new System.Windows.Forms.Button();
            this.mainPicBox = new System.Windows.Forms.PictureBox();
            this.transparentPicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transparentPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // flatFieldButton
            // 
            this.flatFieldButton.Location = new System.Drawing.Point(627, 561);
            this.flatFieldButton.Name = "flatFieldButton";
            this.flatFieldButton.Size = new System.Drawing.Size(156, 51);
            this.flatFieldButton.TabIndex = 3;
            this.flatFieldButton.Text = "确定范围";
            this.flatFieldButton.UseVisualStyleBackColor = true;
            this.flatFieldButton.Click += new System.EventHandler(this.flatFieldButton_Click);
            // 
            // mainPicBox
            // 
            this.mainPicBox.BackColor = System.Drawing.Color.Transparent;
            this.mainPicBox.Location = new System.Drawing.Point(12, 12);
            this.mainPicBox.Name = "mainPicBox";
            this.mainPicBox.Size = new System.Drawing.Size(600, 600);
            this.mainPicBox.TabIndex = 22;
            this.mainPicBox.TabStop = false;
            // 
            // transparentPicBox
            // 
            this.transparentPicBox.BackColor = System.Drawing.Color.Transparent;
            this.transparentPicBox.Location = new System.Drawing.Point(12, 12);
            this.transparentPicBox.Name = "transparentPicBox";
            this.transparentPicBox.Size = new System.Drawing.Size(600, 600);
            this.transparentPicBox.TabIndex = 23;
            this.transparentPicBox.TabStop = false;
            this.transparentPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.transparentPicBox_MouseDown);
            this.transparentPicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.transparentPicBox_MouseMove);
            this.transparentPicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.transparentPicBox_MouseUp);
            // 
            // FlatFieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 663);
            this.Controls.Add(this.transparentPicBox);
            this.Controls.Add(this.mainPicBox);
            this.Controls.Add(this.flatFieldButton);
            this.Name = "FlatFieldForm";
            this.Text = "确定校正范围";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FlatFieldForm_FormClosing);
            this.Load += new System.EventHandler(this.PicForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.transparentPicBox_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.mainPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transparentPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button flatFieldButton;
        private System.Windows.Forms.PictureBox mainPicBox;
        private System.Windows.Forms.PictureBox transparentPicBox;
    }
}