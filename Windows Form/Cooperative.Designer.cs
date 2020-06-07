namespace SpaceInvaders
{
    partial class Cooperative
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.scoreLabel1 = new System.Windows.Forms.Label();
            this.numberOfLivesLabel1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.missleAmmoLabel1 = new System.Windows.Forms.Label();
            this.laserAmmoLabel1 = new System.Windows.Forms.Label();
            this.missleAmmoLabel2 = new System.Windows.Forms.Label();
            this.laserAmmoLabel2 = new System.Windows.Forms.Label();
            this.nuke2 = new System.Windows.Forms.PictureBox();
            this.nuke1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nuke2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuke1)).BeginInit();
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(1653, 302);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.scoreLabel.Size = new System.Drawing.Size(169, 64);
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
            this.numberOfLivesLabel.Location = new System.Drawing.Point(1653, 89);
            this.numberOfLivesLabel.Name = "numberOfLivesLabel";
            this.numberOfLivesLabel.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.numberOfLivesLabel.Size = new System.Drawing.Size(291, 64);
            this.numberOfLivesLabel.TabIndex = 2;
            this.numberOfLivesLabel.Text = "Number of lives = 0";
            this.numberOfLivesLabel.Click += new System.EventHandler(this.numberOfLivesLabel_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // scoreLabel1
            // 
            this.scoreLabel1.AutoSize = true;
            this.scoreLabel1.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel1.ForeColor = System.Drawing.Color.White;
            this.scoreLabel1.Location = new System.Drawing.Point(-2, 298);
            this.scoreLabel1.Name = "scoreLabel1";
            this.scoreLabel1.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.scoreLabel1.Size = new System.Drawing.Size(169, 64);
            this.scoreLabel1.TabIndex = 4;
            this.scoreLabel1.Text = "Score = 0";
            this.scoreLabel1.Click += new System.EventHandler(this.scoreLabel_Click);
            // 
            // numberOfLivesLabel1
            // 
            this.numberOfLivesLabel1.AutoSize = true;
            this.numberOfLivesLabel1.BackColor = System.Drawing.Color.Transparent;
            this.numberOfLivesLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.numberOfLivesLabel1.ForeColor = System.Drawing.Color.White;
            this.numberOfLivesLabel1.Location = new System.Drawing.Point(-2, 89);
            this.numberOfLivesLabel1.Name = "numberOfLivesLabel1";
            this.numberOfLivesLabel1.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.numberOfLivesLabel1.Size = new System.Drawing.Size(291, 64);
            this.numberOfLivesLabel1.TabIndex = 5;
            this.numberOfLivesLabel1.Text = "Number of lives = 0";
            this.numberOfLivesLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.numberOfLivesLabel1.Click += new System.EventHandler(this.numberOfLivesLabel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-2, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.label2.Size = new System.Drawing.Size(153, 64);
            this.label2.TabIndex = 6;
            this.label2.Text = "Player 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(1676, 40);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.label3.Size = new System.Drawing.Size(153, 64);
            this.label3.TabIndex = 7;
            this.label3.Text = "Player 1";
            // 
            // missleAmmoLabel1
            // 
            this.missleAmmoLabel1.AutoSize = true;
            this.missleAmmoLabel1.BackColor = System.Drawing.Color.Transparent;
            this.missleAmmoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missleAmmoLabel1.ForeColor = System.Drawing.Color.White;
            this.missleAmmoLabel1.Location = new System.Drawing.Point(1653, 165);
            this.missleAmmoLabel1.Name = "missleAmmoLabel1";
            this.missleAmmoLabel1.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.missleAmmoLabel1.Size = new System.Drawing.Size(311, 64);
            this.missleAmmoLabel1.TabIndex = 2;
            this.missleAmmoLabel1.Text = "Number of ammo = 0";
            this.missleAmmoLabel1.Click += new System.EventHandler(this.missleAmmorLabel1_Click);
            // 
            // laserAmmoLabel1
            // 
            this.laserAmmoLabel1.AutoSize = true;
            this.laserAmmoLabel1.BackColor = System.Drawing.Color.Transparent;
            this.laserAmmoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laserAmmoLabel1.ForeColor = System.Drawing.Color.White;
            this.laserAmmoLabel1.Location = new System.Drawing.Point(1653, 234);
            this.laserAmmoLabel1.Name = "laserAmmoLabel1";
            this.laserAmmoLabel1.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.laserAmmoLabel1.Size = new System.Drawing.Size(311, 64);
            this.laserAmmoLabel1.TabIndex = 2;
            this.laserAmmoLabel1.Text = "Number of ammo = 0";
            this.laserAmmoLabel1.Click += new System.EventHandler(this.missleAmmorLabel1_Click);
            // 
            // missleAmmoLabel2
            // 
            this.missleAmmoLabel2.AutoSize = true;
            this.missleAmmoLabel2.BackColor = System.Drawing.Color.Transparent;
            this.missleAmmoLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missleAmmoLabel2.ForeColor = System.Drawing.Color.White;
            this.missleAmmoLabel2.Location = new System.Drawing.Point(-2, 165);
            this.missleAmmoLabel2.Name = "missleAmmoLabel2";
            this.missleAmmoLabel2.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.missleAmmoLabel2.Size = new System.Drawing.Size(311, 64);
            this.missleAmmoLabel2.TabIndex = 2;
            this.missleAmmoLabel2.Text = "Number of ammo = 0";
            this.missleAmmoLabel2.Click += new System.EventHandler(this.missleAmmorLabel2_Click);
            // 
            // laserAmmoLabel2
            // 
            this.laserAmmoLabel2.AutoSize = true;
            this.laserAmmoLabel2.BackColor = System.Drawing.Color.Transparent;
            this.laserAmmoLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laserAmmoLabel2.ForeColor = System.Drawing.Color.White;
            this.laserAmmoLabel2.Location = new System.Drawing.Point(-2, 234);
            this.laserAmmoLabel2.Name = "laserAmmoLabel2";
            this.laserAmmoLabel2.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.laserAmmoLabel2.Size = new System.Drawing.Size(311, 64);
            this.laserAmmoLabel2.TabIndex = 2;
            this.laserAmmoLabel2.Text = "Number of ammo = 0";
            this.laserAmmoLabel2.Click += new System.EventHandler(this.missleAmmorLabel2_Click);
            // 
            // nuke2
            // 
            this.nuke2.Image = global::SpaceInvaders.Properties.Resources.nuke;
            this.nuke2.Location = new System.Drawing.Point(31, 574);
            this.nuke2.Name = "nuke2";
            this.nuke2.Size = new System.Drawing.Size(75, 75);
            this.nuke2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nuke2.TabIndex = 8;
            this.nuke2.TabStop = false;
            this.nuke2.Visible = false;
            // 
            // nuke1
            // 
            this.nuke1.Image = global::SpaceInvaders.Properties.Resources.nuke;
            this.nuke1.Location = new System.Drawing.Point(1671, 552);
            this.nuke1.Name = "nuke1";
            this.nuke1.Size = new System.Drawing.Size(75, 75);
            this.nuke1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nuke1.TabIndex = 9;
            this.nuke1.TabStop = false;
            this.nuke1.Visible = false;
            // 
            // Cooperative
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1942, 672);
            this.Controls.Add(this.nuke1);
            this.Controls.Add(this.nuke2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberOfLivesLabel1);
            this.Controls.Add(this.scoreLabel1);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.numberOfLivesLabel);
            this.Controls.Add(this.missleAmmoLabel1);
            this.Controls.Add(this.laserAmmoLabel1);
            this.Controls.Add(this.missleAmmoLabel2);
            this.Controls.Add(this.laserAmmoLabel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Cooperative";
            this.ShowIcon = false;
            this.Text = "Space Invaders";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Client_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.nuke2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuke1)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label missleAmmoLabel1;
        private System.Windows.Forms.Label laserAmmoLabel1;
        private System.Windows.Forms.Label missleAmmoLabel2;
        private System.Windows.Forms.Label laserAmmoLabel2;
        private System.Windows.Forms.PictureBox nuke2;
        private System.Windows.Forms.PictureBox nuke1;
    }
}

