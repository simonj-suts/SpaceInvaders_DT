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
            this.missleAmmoLabel = new System.Windows.Forms.Label();
            this.laserAmmoLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.numberOfLivesLabel = new System.Windows.Forms.Label();
            this.liveImg = new System.Windows.Forms.PictureBox();
            this.laserImg = new System.Windows.Forms.PictureBox();
            this.missleImg = new System.Windows.Forms.PictureBox();
            this.nukeImg = new System.Windows.Forms.PictureBox();
            this.numberOfLivesLabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.liveImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laserImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.missleImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nukeImg)).BeginInit();
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(1022, 19);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.scoreLabel.Size = new System.Drawing.Size(150, 61);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "Score = 0";
            this.scoreLabel.Click += new System.EventHandler(this.scoreLabel_Click);
            // 
            // missleAmmoLabel
            // 
            this.missleAmmoLabel.AutoSize = true;
            this.missleAmmoLabel.BackColor = System.Drawing.Color.Transparent;
            this.missleAmmoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missleAmmoLabel.ForeColor = System.Drawing.Color.White;
            this.missleAmmoLabel.Location = new System.Drawing.Point(1153, 479);
            this.missleAmmoLabel.Name = "missleAmmoLabel";
            this.missleAmmoLabel.Size = new System.Drawing.Size(23, 25);
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
            this.laserAmmoLabel.Location = new System.Drawing.Point(1052, 479);
            this.laserAmmoLabel.Name = "laserAmmoLabel";
            this.laserAmmoLabel.Size = new System.Drawing.Size(23, 25);
            this.laserAmmoLabel.TabIndex = 2;
            this.laserAmmoLabel.Text = "0";
            this.laserAmmoLabel.Click += new System.EventHandler(this.missleAmmorLabel_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // numberOfLivesLabel
            // 
            this.numberOfLivesLabel.AutoSize = true;
            this.numberOfLivesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfLivesLabel.ForeColor = System.Drawing.Color.White;
            this.numberOfLivesLabel.Location = new System.Drawing.Point(784, 460);
            this.numberOfLivesLabel.Name = "numberOfLivesLabel";
            this.numberOfLivesLabel.Size = new System.Drawing.Size(43, 29);
            this.numberOfLivesLabel.TabIndex = 8;
            this.numberOfLivesLabel.Text = "x 3";
            // 
            // liveImg
            // 
            this.liveImg.BackColor = System.Drawing.Color.Transparent;
            this.liveImg.Image = global::SpaceInvaders.Properties.Resources.live;
            this.liveImg.Location = new System.Drawing.Point(702, 442);
            this.liveImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.liveImg.Name = "liveImg";
            this.liveImg.Size = new System.Drawing.Size(67, 60);
            this.liveImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.liveImg.TabIndex = 9;
            this.liveImg.TabStop = false;
            // 
            // laserImg
            // 
            this.laserImg.BackColor = System.Drawing.Color.Transparent;
            this.laserImg.Image = global::SpaceInvaders.Properties.Resources.laser;
            this.laserImg.Location = new System.Drawing.Point(1009, 442);
            this.laserImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.laserImg.Name = "laserImg";
            this.laserImg.Size = new System.Drawing.Size(67, 60);
            this.laserImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.laserImg.TabIndex = 7;
            this.laserImg.TabStop = false;
            // 
            // missleImg
            // 
            this.missleImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.missleImg.Image = global::SpaceInvaders.Properties.Resources.missle;
            this.missleImg.Location = new System.Drawing.Point(1109, 442);
            this.missleImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.missleImg.Name = "missleImg";
            this.missleImg.Size = new System.Drawing.Size(67, 61);
            this.missleImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.missleImg.TabIndex = 6;
            this.missleImg.TabStop = false;
            // 
            // nukeImg
            // 
            this.nukeImg.Image = global::SpaceInvaders.Properties.Resources.nuke;
            this.nukeImg.Location = new System.Drawing.Point(901, 442);
            this.nukeImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nukeImg.Name = "nukeImg";
            this.nukeImg.Size = new System.Drawing.Size(67, 60);
            this.nukeImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nukeImg.TabIndex = 4;
            this.nukeImg.TabStop = false;
            this.nukeImg.Visible = false;
            // 
            // numberOfLivesLabel2
            // 
            this.numberOfLivesLabel2.AutoSize = true;
            this.numberOfLivesLabel2.BackColor = System.Drawing.Color.Transparent;
            this.numberOfLivesLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfLivesLabel2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.numberOfLivesLabel2.Location = new System.Drawing.Point(532, 199);
            this.numberOfLivesLabel2.Name = "numberOfLivesLabel2";
            this.numberOfLivesLabel2.Size = new System.Drawing.Size(0, 39);
            this.numberOfLivesLabel2.TabIndex = 10;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::SpaceInvaders.Properties.Resources.giphy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1196, 512);
            this.Controls.Add(this.numberOfLivesLabel2);
            this.Controls.Add(this.liveImg);
            this.Controls.Add(this.numberOfLivesLabel);
            this.Controls.Add(this.laserAmmoLabel);
            this.Controls.Add(this.missleAmmoLabel);
            this.Controls.Add(this.laserImg);
            this.Controls.Add(this.missleImg);
            this.Controls.Add(this.nukeImg);
            this.Controls.Add(this.scoreLabel);
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
            ((System.ComponentModel.ISupportInitialize)(this.liveImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laserImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.missleImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nukeImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label missleAmmoLabel;
        private System.Windows.Forms.Label laserAmmoLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox nukeImg;
        private System.Windows.Forms.PictureBox missleImg;
        private System.Windows.Forms.PictureBox laserImg;
        private System.Windows.Forms.Label numberOfLivesLabel;
        private System.Windows.Forms.PictureBox liveImg;
        private System.Windows.Forms.Label numberOfLivesLabel2;
    }
}

