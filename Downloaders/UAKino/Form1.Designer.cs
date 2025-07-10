
namespace UAKino
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
            this.btnDownloadUAKinoFilmy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDownloadUAKinoFilmy
            // 
            this.btnDownloadUAKinoFilmy.Location = new System.Drawing.Point(21, 12);
            this.btnDownloadUAKinoFilmy.Name = "btnDownloadUAKinoFilmy";
            this.btnDownloadUAKinoFilmy.Size = new System.Drawing.Size(220, 32);
            this.btnDownloadUAKinoFilmy.TabIndex = 0;
            this.btnDownloadUAKinoFilmy.Text = "Download uakino.best/filmy/..";
            this.btnDownloadUAKinoFilmy.UseVisualStyleBackColor = true;
            this.btnDownloadUAKinoFilmy.Click += new System.EventHandler(this.btnDownloadUAKinoFilmy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDownloadUAKinoFilmy);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDownloadUAKinoFilmy;
    }
}

