namespace SpaceInvaders
{
    partial class VersusPVP
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.numberOfLivesLabel = new System.Windows.Forms.Label();
            this.numberOfLivesLabel1 = new System.Windows.Forms.Label();
            this.p2laserImg = new System.Windows.Forms.PictureBox();
            this.p2NukeImg = new System.Windows.Forms.PictureBox();
            this.p1NukeImg = new System.Windows.Forms.PictureBox();
            this.p1LaserImg = new System.Windows.Forms.PictureBox();
            this.p1missleImg = new System.Windows.Forms.PictureBox();
            this.p1LiveImg = new System.Windows.Forms.PictureBox();
            this.p2missleImg = new System.Windows.Forms.PictureBox();
            this.p2LiveImg = new System.Windows.Forms.PictureBox();
            this.p1Label = new System.Windows.Forms.Label();
            this.p2Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.p2laserImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2NukeImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1NukeImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1LaserImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1missleImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1LiveImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2missleImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2LiveImg)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // numberOfLivesLabel
            // 
            this.numberOfLivesLabel.AutoSize = true;
            this.numberOfLivesLabel.BackColor = System.Drawing.Color.Transparent;
            this.numberOfLivesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfLivesLabel.ForeColor = System.Drawing.Color.White;
            this.numberOfLivesLabel.Location = new System.Drawing.Point(720, 40);
            this.numberOfLivesLabel.Name = "numberOfLivesLabel";
            this.numberOfLivesLabel.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.numberOfLivesLabel.Size = new System.Drawing.Size(86, 64);
            this.numberOfLivesLabel.TabIndex = 0;
            this.numberOfLivesLabel.Text = "x 3";
            // 
            // numberOfLivesLabel1
            // 
            this.numberOfLivesLabel1.AutoSize = true;
            this.numberOfLivesLabel1.BackColor = System.Drawing.Color.Transparent;
            this.numberOfLivesLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfLivesLabel1.ForeColor = System.Drawing.Color.White;
            this.numberOfLivesLabel1.Location = new System.Drawing.Point(720, 530);
            this.numberOfLivesLabel1.Name = "numberOfLivesLabel1";
            this.numberOfLivesLabel1.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.numberOfLivesLabel1.Size = new System.Drawing.Size(86, 64);
            this.numberOfLivesLabel1.TabIndex = 1;
            this.numberOfLivesLabel1.Text = "x 3";
            // 
            // p2laserImg
            // 
            this.p2laserImg.BackColor = System.Drawing.Color.Transparent;
            this.p2laserImg.Image = global::SpaceInvaders.Properties.Resources.laser;
            this.p2laserImg.Location = new System.Drawing.Point(986, 40);
            this.p2laserImg.Name = "p2laserImg";
            this.p2laserImg.Size = new System.Drawing.Size(75, 75);
            this.p2laserImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.p2laserImg.TabIndex = 2;
            this.p2laserImg.TabStop = false;
            // 
            // p2NukeImg
            // 
            this.p2NukeImg.BackColor = System.Drawing.Color.Transparent;
            this.p2NukeImg.Image = global::SpaceInvaders.Properties.Resources.nuke;
            this.p2NukeImg.Location = new System.Drawing.Point(1118, 40);
            this.p2NukeImg.Name = "p2NukeImg";
            this.p2NukeImg.Size = new System.Drawing.Size(75, 75);
            this.p2NukeImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2NukeImg.TabIndex = 3;
            this.p2NukeImg.TabStop = false;
            this.p2NukeImg.Visible = false;
            // 
            // p1NukeImg
            // 
            this.p1NukeImg.BackColor = System.Drawing.Color.Transparent;
            this.p1NukeImg.Image = global::SpaceInvaders.Properties.Resources.nuke;
            this.p1NukeImg.Location = new System.Drawing.Point(1103, 519);
            this.p1NukeImg.Name = "p1NukeImg";
            this.p1NukeImg.Size = new System.Drawing.Size(75, 75);
            this.p1NukeImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1NukeImg.TabIndex = 4;
            this.p1NukeImg.TabStop = false;
            this.p1NukeImg.Visible = false;
            // 
            // p1LaserImg
            // 
            this.p1LaserImg.BackColor = System.Drawing.Color.Transparent;
            this.p1LaserImg.Image = global::SpaceInvaders.Properties.Resources.laser;
            this.p1LaserImg.Location = new System.Drawing.Point(986, 519);
            this.p1LaserImg.Name = "p1LaserImg";
            this.p1LaserImg.Size = new System.Drawing.Size(75, 75);
            this.p1LaserImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.p1LaserImg.TabIndex = 5;
            this.p1LaserImg.TabStop = false;
            // 
            // p1missleImg
            // 
            this.p1missleImg.BackColor = System.Drawing.Color.Transparent;
            this.p1missleImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.p1missleImg.Image = global::SpaceInvaders.Properties.Resources.missle;
            this.p1missleImg.Location = new System.Drawing.Point(858, 519);
            this.p1missleImg.Name = "p1missleImg";
            this.p1missleImg.Size = new System.Drawing.Size(75, 75);
            this.p1missleImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1missleImg.TabIndex = 6;
            this.p1missleImg.TabStop = false;
            // 
            // p1LiveImg
            // 
            this.p1LiveImg.BackColor = System.Drawing.Color.Transparent;
            this.p1LiveImg.Image = global::SpaceInvaders.Properties.Resources.live;
            this.p1LiveImg.Location = new System.Drawing.Point(625, 519);
            this.p1LiveImg.Name = "p1LiveImg";
            this.p1LiveImg.Size = new System.Drawing.Size(75, 75);
            this.p1LiveImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1LiveImg.TabIndex = 7;
            this.p1LiveImg.TabStop = false;
            // 
            // p2missleImg
            // 
            this.p2missleImg.BackColor = System.Drawing.Color.Transparent;
            this.p2missleImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.p2missleImg.Image = global::SpaceInvaders.Properties.Resources.missle;
            this.p2missleImg.Location = new System.Drawing.Point(858, 40);
            this.p2missleImg.Name = "p2missleImg";
            this.p2missleImg.Size = new System.Drawing.Size(75, 75);
            this.p2missleImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2missleImg.TabIndex = 8;
            this.p2missleImg.TabStop = false;
            // 
            // p2LiveImg
            // 
            this.p2LiveImg.BackColor = System.Drawing.Color.Transparent;
            this.p2LiveImg.Image = global::SpaceInvaders.Properties.Resources.live;
            this.p2LiveImg.Location = new System.Drawing.Point(625, 40);
            this.p2LiveImg.Name = "p2LiveImg";
            this.p2LiveImg.Size = new System.Drawing.Size(75, 75);
            this.p2LiveImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2LiveImg.TabIndex = 9;
            this.p2LiveImg.TabStop = false;
            // 
            // p1Label
            // 
            this.p1Label.AutoSize = true;
            this.p1Label.BackColor = System.Drawing.Color.Transparent;
            this.p1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1Label.ForeColor = System.Drawing.Color.White;
            this.p1Label.Location = new System.Drawing.Point(438, 530);
            this.p1Label.Name = "p1Label";
            this.p1Label.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.p1Label.Size = new System.Drawing.Size(153, 64);
            this.p1Label.TabIndex = 10;
            this.p1Label.Text = "Player 1";
            // 
            // p2Label
            // 
            this.p2Label.AutoSize = true;
            this.p2Label.BackColor = System.Drawing.Color.Transparent;
            this.p2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2Label.ForeColor = System.Drawing.Color.White;
            this.p2Label.Location = new System.Drawing.Point(438, 40);
            this.p2Label.Name = "p2Label";
            this.p2Label.Padding = new System.Windows.Forms.Padding(17, 16, 17, 16);
            this.p2Label.Size = new System.Drawing.Size(153, 64);
            this.p2Label.TabIndex = 11;
            this.p2Label.Text = "Player 2";
            // 
            // VersusPVP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::SpaceInvaders.Properties.Resources.giphy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1942, 672);
            this.Controls.Add(this.p2Label);
            this.Controls.Add(this.p1Label);
            this.Controls.Add(this.p2LiveImg);
            this.Controls.Add(this.p2missleImg);
            this.Controls.Add(this.p1LiveImg);
            this.Controls.Add(this.p1missleImg);
            this.Controls.Add(this.p1LaserImg);
            this.Controls.Add(this.p1NukeImg);
            this.Controls.Add(this.p2NukeImg);
            this.Controls.Add(this.p2laserImg);
            this.Controls.Add(this.numberOfLivesLabel1);
            this.Controls.Add(this.numberOfLivesLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VersusPVP";
            this.Text = "VersusPVP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VersusPVP_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.p2laserImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2NukeImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1NukeImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1LaserImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1missleImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1LiveImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2missleImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2LiveImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label numberOfLivesLabel;
        private System.Windows.Forms.Label numberOfLivesLabel1;
        private System.Windows.Forms.PictureBox p2laserImg;
        private System.Windows.Forms.PictureBox p2NukeImg;
        private System.Windows.Forms.PictureBox p1NukeImg;
        private System.Windows.Forms.PictureBox p1LaserImg;
        private System.Windows.Forms.PictureBox p1missleImg;
        private System.Windows.Forms.PictureBox p1LiveImg;
        private System.Windows.Forms.PictureBox p2missleImg;
        private System.Windows.Forms.PictureBox p2LiveImg;
        private System.Windows.Forms.Label p1Label;
        private System.Windows.Forms.Label p2Label;
    }
}