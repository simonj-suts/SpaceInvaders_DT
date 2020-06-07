namespace SpaceInvaders
{
    partial class Client
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
            this.components = new System.ComponentModel.Container();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.numberOfLivesLabel = new System.Windows.Forms.Label();
            this.missleAmmoLabel = new System.Windows.Forms.Label();
            this.laserAmmoLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(9, 168);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.scoreLabel.Size = new System.Drawing.Size(150, 61);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "Score = 0";
            this.scoreLabel.Click += new System.EventHandler(this.scoreLabel_Click);
            // 
            // numberOfLivesLabel
            // 
            this.numberOfLivesLabel.AutoSize = true;
            this.numberOfLivesLabel.BackColor = System.Drawing.Color.Transparent;
            this.numberOfLivesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfLivesLabel.ForeColor = System.Drawing.Color.White;
            this.numberOfLivesLabel.Location = new System.Drawing.Point(9, 6);
            this.numberOfLivesLabel.Name = "numberOfLivesLabel";
            this.numberOfLivesLabel.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.numberOfLivesLabel.Size = new System.Drawing.Size(254, 61);
            this.numberOfLivesLabel.TabIndex = 2;
            this.numberOfLivesLabel.Text = "Number of lives = 0";
            this.numberOfLivesLabel.Click += new System.EventHandler(this.numberOfLivesLabel_Click);
            // 
            // missleAmmoLabel
            // 
            this.missleAmmoLabel.AutoSize = true;
            this.missleAmmoLabel.BackColor = System.Drawing.Color.Transparent;
            this.missleAmmoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missleAmmoLabel.ForeColor = System.Drawing.Color.White;
            this.missleAmmoLabel.Location = new System.Drawing.Point(9, 122);
            this.missleAmmoLabel.Name = "missleAmmoLabel";
            this.missleAmmoLabel.Padding = new System.Windows.Forms.Padding(15, 13, 15, 13);
            this.missleAmmoLabel.Size = new System.Drawing.Size(268, 55);
            this.missleAmmoLabel.TabIndex = 2;
            this.missleAmmoLabel.Text = "Number of ammo = 0";
            this.missleAmmoLabel.Click += new System.EventHandler(this.missleAmmorLabel_Click);
            // 
            // laserAmmoLabel
            // 
            this.laserAmmoLabel.AutoSize = true;
            this.laserAmmoLabel.BackColor = System.Drawing.Color.Transparent;
            this.laserAmmoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laserAmmoLabel.ForeColor = System.Drawing.Color.White;
            this.laserAmmoLabel.Location = new System.Drawing.Point(9, 67);
            this.laserAmmoLabel.Name = "laserAmmoLabel";
            this.laserAmmoLabel.Padding = new System.Windows.Forms.Padding(15, 13, 15, 13);
            this.laserAmmoLabel.Size = new System.Drawing.Size(268, 55);
            this.laserAmmoLabel.TabIndex = 2;
            this.laserAmmoLabel.Text = "Number of ammo = 0";
            this.laserAmmoLabel.Click += new System.EventHandler(this.missleAmmorLabel_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1196, 512);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.numberOfLivesLabel);
            this.Controls.Add(this.missleAmmoLabel);
            this.Controls.Add(this.laserAmmoLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Client";
            this.ShowIcon = false;
            this.Text = "Space Invaders";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Client_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label numberOfLivesLabel;
        private System.Windows.Forms.Label missleAmmoLabel;
        private System.Windows.Forms.Label laserAmmoLabel;
        private System.Windows.Forms.Timer timer;
    }
}

