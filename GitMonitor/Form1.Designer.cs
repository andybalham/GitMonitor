
namespace GitMonitor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reposTextBox = new System.Windows.Forms.TextBox();
            this.checkButton = new System.Windows.Forms.Button();
            this.reportTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // reposTextBox
            // 
            this.reposTextBox.Location = new System.Drawing.Point(10, 9);
            this.reposTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reposTextBox.Multiline = true;
            this.reposTextBox.Name = "reposTextBox";
            this.reposTextBox.Size = new System.Drawing.Size(814, 97);
            this.reposTextBox.TabIndex = 1;
            this.reposTextBox.Text = "origin/211026-test-client-list-functionality -> origin/main > 5 @ D:\\Users\\andyb\\" +
    "Documents\\github\\sls-testing-toolkit";
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(742, 379);
            this.checkButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(82, 22);
            this.checkButton.TabIndex = 0;
            this.checkButton.Text = "&Check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // reportTextBox
            // 
            this.reportTextBox.Location = new System.Drawing.Point(9, 110);
            this.reportTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reportTextBox.Multiline = true;
            this.reportTextBox.Name = "reportTextBox";
            this.reportTextBox.ReadOnly = true;
            this.reportTextBox.Size = new System.Drawing.Size(814, 265);
            this.reportTextBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 412);
            this.Controls.Add(this.reportTextBox);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.reposTextBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox reposTextBox;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.TextBox reportTextBox;
    }
}

