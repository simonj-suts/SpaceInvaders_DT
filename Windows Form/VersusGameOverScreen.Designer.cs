namespace SpaceInvaders
{
    partial class VersusGameOverScreen
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
            this.gameoverlabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.winnerlabel = new System.Windows.Forms.Label();
            //this.loserlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameoverlabel
            // 
            this.gameoverlabel.AutoSize = true;
            this.gameoverlabel.Font = new System.Drawing.Font("Palatino Linotype", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameoverlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gameoverlabel.Location = new System.Drawing.Point(this.Width / 2 + 200, this.Height / 2 - 100);
            this.gameoverlabel.Name = "gameoverlabel";
            this.gameoverlabel.Size = new System.Drawing.Size(598, 107);
            this.gameoverlabel.TabIndex = 0;
            this.gameoverlabel.Text = "Game Over";
            //
            // winnerlabel
            //
            this.winnerlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.winnerlabel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winnerlabel.Name = "winnerlabel";
            this.winnerlabel.Text = "Winner";
            this.winnerlabel.Size = new System.Drawing.Size(400, 100);
            this.winnerlabel.Location = new System.Drawing.Point(this.Width / 2 - 100, 200);
            /*
            // loserlabel
            //
            this.loserlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loserlabel.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loserlabel.Name = "winnerlabel";
            this.loserlabel.Text = "Winner";
            this.loserlabel.Size = new System.Drawing.Size(300, 100);
            */
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Location = new System.Drawing.Point(550, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(319, 53);
            this.button1.TabIndex = 2;
            this.button1.Text = "Back to Main Menu";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button2.Location = new System.Drawing.Point(550, 409);
            this.button2.Name = "button1";
            this.button2.Size = new System.Drawing.Size(319, 53);
            this.button2.TabIndex = 2;
            this.button2.Text = "Restart";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // GameOver
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1178, 465);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gameoverlabel);
            this.Controls.Add(this.winnerlabel);
            //this.Controls.Add(this.loserlabel);
            this.Name = "GameOver";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GameOver_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gameoverlabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label winnerlabel;
        //private System.Windows.Forms.Label loserlabel;
    }
}