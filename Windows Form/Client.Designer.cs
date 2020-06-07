﻿namespace SpaceInvaders
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
            this.nukeImg = new System.Windows.Forms.PictureBox();
            this.energy = new System.Windows.Forms.Label();
            this.missleImg = new System.Windows.Forms.PictureBox();
            this.laserImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nukeImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.missleImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laserImg)).BeginInit();
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(28, 80);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Padding = new System.Windows.Forms.Padding(19, 20, 19, 20);
            this.scoreLabel.Size = new System.Drawing.Size(173, 72);
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
            this.numberOfLivesLabel.Location = new System.Drawing.Point(10, 8);
            this.numberOfLivesLabel.Name = "numberOfLivesLabel";
            this.numberOfLivesLabel.Padding = new System.Windows.Forms.Padding(19, 20, 19, 20);
            this.numberOfLivesLabel.Size = new System.Drawing.Size(295, 72);
            this.numberOfLivesLabel.TabIndex = 2;
            this.numberOfLivesLabel.Text = "Number of lives = 0";
            this.numberOfLivesLabel.Click += new System.EventHandler(this.numberOfLivesLabel_Click);
            // 
            // missleAmmoLabel
            // 
            this.missleAmmoLabel.AutoSize = true;
            this.missleAmmoLabel.BackColor = System.Drawing.Color.Transparent;
            this.missleAmmoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missleAmmoLabel.ForeColor = System.Drawing.Color.White;
            this.missleAmmoLabel.Location = new System.Drawing.Point(1297, 599);
            this.missleAmmoLabel.Name = "missleAmmoLabel";
            this.missleAmmoLabel.Size = new System.Drawing.Size(26, 29);
            this.missleAmmoLabel.TabIndex = 2;
            this.missleAmmoLabel.Text = "0";
            this.missleAmmoLabel.Click += new System.EventHandler(this.missleAmmorLabel_Click);
            // 
            // laserAmmoLabel
            // 
            this.laserAmmoLabel.AutoSize = true;
            this.laserAmmoLabel.BackColor = System.Drawing.Color.Black;
            this.laserAmmoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laserAmmoLabel.ForeColor = System.Drawing.Color.White;
            this.laserAmmoLabel.Location = new System.Drawing.Point(1184, 599);
            this.laserAmmoLabel.Name = "laserAmmoLabel";
            this.laserAmmoLabel.Size = new System.Drawing.Size(26, 29);
            this.laserAmmoLabel.TabIndex = 2;
            this.laserAmmoLabel.Text = "0";
            this.laserAmmoLabel.Click += new System.EventHandler(this.missleAmmorLabel_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // nukeImg
            // 
            this.nukeImg.Image = global::SpaceInvaders.Properties.Resources.nuke;
            this.nukeImg.Location = new System.Drawing.Point(1014, 553);
            this.nukeImg.Name = "nukeImg";
            this.nukeImg.Size = new System.Drawing.Size(75, 75);
            this.nukeImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nukeImg.TabIndex = 4;
            this.nukeImg.TabStop = false;
            this.nukeImg.Visible = false;
            // 
            // energy
            // 
            this.energy.AutoSize = true;
            this.energy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.energy.ForeColor = System.Drawing.Color.Transparent;
            this.energy.Location = new System.Drawing.Point(28, 168);
            this.energy.Name = "energy";
            this.energy.Padding = new System.Windows.Forms.Padding(19, 20, 19, 20);
            this.energy.Size = new System.Drawing.Size(189, 72);
            this.energy.TabIndex = 5;
            this.energy.Text = "Energy = 0";
            // 
            // missleImg
            // 
            this.missleImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.missleImg.Image = global::SpaceInvaders.Properties.Resources.missle;
            this.missleImg.Location = new System.Drawing.Point(1248, 553);
            this.missleImg.Name = "missleImg";
            this.missleImg.Size = new System.Drawing.Size(75, 75);
            this.missleImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.missleImg.TabIndex = 6;
            this.missleImg.TabStop = false;
            // 
            // laserImg
            // 
            this.laserImg.Image = global::SpaceInvaders.Properties.Resources.laser;
            this.laserImg.Location = new System.Drawing.Point(1135, 553);
            this.laserImg.Name = "laserImg";
            this.laserImg.Size = new System.Drawing.Size(75, 75);
            this.laserImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.laserImg.TabIndex = 7;
            this.laserImg.TabStop = false;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1346, 640);
            this.Controls.Add(this.laserAmmoLabel);
            this.Controls.Add(this.missleAmmoLabel);
            this.Controls.Add(this.laserImg);
            this.Controls.Add(this.missleImg);
            this.Controls.Add(this.energy);
            this.Controls.Add(this.nukeImg);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.numberOfLivesLabel);
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
            ((System.ComponentModel.ISupportInitialize)(this.nukeImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.missleImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laserImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label numberOfLivesLabel;
        private System.Windows.Forms.Label missleAmmoLabel;
        private System.Windows.Forms.Label laserAmmoLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox nukeImg;
        private System.Windows.Forms.Label energy;
        private System.Windows.Forms.PictureBox missleImg;
        private System.Windows.Forms.PictureBox laserImg;
    }
}

