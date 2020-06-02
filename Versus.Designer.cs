namespace SpaceInvaders
{
    partial class Versus
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
        private void InitializeComponents()
        {
            this.components = new System.ComponentModel.Container();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.numberOfLivesLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.scoreLabel1 = new System.Windows.Forms.Label();
            this.numberOfLivesLabel1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // numberOfLivesLabel
            // 
            this.numberOfLivesLabel.AutoSize = true;
            this.numberOfLivesLabel.BackColor = System.Drawing.Color.Transparent;
            this.numberOfLivesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfLivesLabel.ForeColor = System.Drawing.Color.White;
            this.numberOfLivesLabel.Location = new System.Drawing.Point(1648, 0);
            this.numberOfLivesLabel.Name = "numberOfLivesLabel";
            this.numberOfLivesLabel.Padding = new System.Windows.Forms.Padding(20);
            this.numberOfLivesLabel.Size = new System.Drawing.Size(297, 72);
            this.numberOfLivesLabel.TabIndex = 2;
            this.numberOfLivesLabel.Text = "Number of lives = 0";
            this.numberOfLivesLabel.Click += new System.EventHandler(this.numberOfLivesLabel_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);       
            // 
            // numberOfLivesLabel1
            // 
            this.numberOfLivesLabel1.AutoSize = true;
            this.numberOfLivesLabel1.BackColor = System.Drawing.Color.Transparent;
            this.numberOfLivesLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.numberOfLivesLabel1.ForeColor = System.Drawing.Color.White;
            this.numberOfLivesLabel1.Location = new System.Drawing.Point(-2, 0);
            this.numberOfLivesLabel1.Name = "numberOfLivesLabel1";
            this.numberOfLivesLabel1.Padding = new System.Windows.Forms.Padding(20);
            this.numberOfLivesLabel1.Size = new System.Drawing.Size(297, 72);
            this.numberOfLivesLabel1.TabIndex = 5;
            this.numberOfLivesLabel1.Text = "Number of lives = 0";
            this.numberOfLivesLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.numberOfLivesLabel1.Click += new System.EventHandler(this.numberOfLivesLabel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1946, 672);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberOfLivesLabel1);
            this.Controls.Add(this.scoreLabel1);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.numberOfLivesLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Menu";
            this.ShowIcon = false;
            this.Text = "Space Invaders";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Versus_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label numberOfLivesLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label scoreLabel1;
        private System.Windows.Forms.Label numberOfLivesLabel1;
        private System.Windows.Forms.Label label1;
    }
}

