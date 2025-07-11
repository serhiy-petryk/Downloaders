
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
            this.btnParseUAKinoFilmy = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
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
            // btnParseUAKinoFilmy
            // 
            this.btnParseUAKinoFilmy.Location = new System.Drawing.Point(21, 65);
            this.btnParseUAKinoFilmy.Name = "btnParseUAKinoFilmy";
            this.btnParseUAKinoFilmy.Size = new System.Drawing.Size(220, 32);
            this.btnParseUAKinoFilmy.TabIndex = 1;
            this.btnParseUAKinoFilmy.Text = "Parse uakino.best/filmy/.. files";
            this.btnParseUAKinoFilmy.UseVisualStyleBackColor = true;
            this.btnParseUAKinoFilmy.Click += new System.EventHandler(this.btnParseUAKinoFilmy_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(118, 17);
            this.statusLabel.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnParseUAKinoFilmy);
            this.Controls.Add(this.btnDownloadUAKinoFilmy);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownloadUAKinoFilmy;
        private System.Windows.Forms.Button btnParseUAKinoFilmy;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}

