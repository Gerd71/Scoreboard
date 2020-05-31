namespace Scoreboard
{
    public partial class Scoreboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scoreboard));
            this.lbScoreGuest = new System.Windows.Forms.Label();
            this.lbScoreHome = new System.Windows.Forms.Label();
            this.lbTextHome = new System.Windows.Forms.Label();
            this.lbTextGuest = new System.Windows.Forms.Label();
            this.lbTimeScoreboard = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbQuarter = new System.Windows.Forms.Label();
            this.lbTextQuarter = new System.Windows.Forms.Label();
            this.lbDown = new System.Windows.Forms.Label();
            this.lbTextDown = new System.Windows.Forms.Label();
            this.pBHome = new System.Windows.Forms.PictureBox();
            this.pBGuest = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pBPlayer = new System.Windows.Forms.PictureBox();
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.pBHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBGuest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lbScoreGuest
            // 
            this.lbScoreGuest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbScoreGuest.BackColor = System.Drawing.Color.Black;
            this.lbScoreGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 120F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScoreGuest.ForeColor = System.Drawing.Color.Crimson;
            this.lbScoreGuest.Location = new System.Drawing.Point(993, 448);
            this.lbScoreGuest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbScoreGuest.Name = "lbScoreGuest";
            this.lbScoreGuest.Size = new System.Drawing.Size(288, 165);
            this.lbScoreGuest.TabIndex = 1;
            this.lbScoreGuest.Text = "0";
            // 
            // lbScoreHome
            // 
            this.lbScoreHome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbScoreHome.BackColor = System.Drawing.Color.Black;
            this.lbScoreHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 120F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScoreHome.ForeColor = System.Drawing.Color.Crimson;
            this.lbScoreHome.Location = new System.Drawing.Point(-56, 448);
            this.lbScoreHome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbScoreHome.Name = "lbScoreHome";
            this.lbScoreHome.Size = new System.Drawing.Size(288, 165);
            this.lbScoreHome.TabIndex = 2;
            this.lbScoreHome.Text = "0";
            // 
            // lbTextHome
            // 
            this.lbTextHome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTextHome.AutoSize = true;
            this.lbTextHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTextHome.Location = new System.Drawing.Point(-78, 354);
            this.lbTextHome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTextHome.Name = "lbTextHome";
            this.lbTextHome.Size = new System.Drawing.Size(283, 91);
            this.lbTextHome.TabIndex = 3;
            this.lbTextHome.Text = "HOME";
            // 
            // lbTextGuest
            // 
            this.lbTextGuest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTextGuest.AutoSize = true;
            this.lbTextGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTextGuest.Location = new System.Drawing.Point(984, 351);
            this.lbTextGuest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTextGuest.Name = "lbTextGuest";
            this.lbTextGuest.Size = new System.Drawing.Size(319, 91);
            this.lbTextGuest.TabIndex = 4;
            this.lbTextGuest.Text = "GUEST";
            // 
            // lbTimeScoreboard
            // 
            this.lbTimeScoreboard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTimeScoreboard.BackColor = System.Drawing.Color.Black;
            this.lbTimeScoreboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTimeScoreboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeScoreboard.ForeColor = System.Drawing.Color.Crimson;
            this.lbTimeScoreboard.Location = new System.Drawing.Point(318, 132);
            this.lbTimeScoreboard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTimeScoreboard.Name = "lbTimeScoreboard";
            this.lbTimeScoreboard.Size = new System.Drawing.Size(629, 210);
            this.lbTimeScoreboard.TabIndex = 5;
            this.lbTimeScoreboard.Text = "12:00";
            // 
            // lbTime
            // 
            this.lbTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.Location = new System.Drawing.Point(509, 36);
            this.lbTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(230, 91);
            this.lbTime.TabIndex = 6;
            this.lbTime.Text = "TIME";
            // 
            // lbQuarter
            // 
            this.lbQuarter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbQuarter.BackColor = System.Drawing.Color.Black;
            this.lbQuarter.Font = new System.Drawing.Font("Microsoft Sans Serif", 100.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuarter.ForeColor = System.Drawing.Color.Crimson;
            this.lbQuarter.Location = new System.Drawing.Point(383, 464);
            this.lbQuarter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbQuarter.Name = "lbQuarter";
            this.lbQuarter.Size = new System.Drawing.Size(108, 133);
            this.lbQuarter.TabIndex = 7;
            this.lbQuarter.Text = "1";
            // 
            // lbTextQuarter
            // 
            this.lbTextQuarter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTextQuarter.AutoSize = true;
            this.lbTextQuarter.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTextQuarter.Location = new System.Drawing.Point(338, 366);
            this.lbTextQuarter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTextQuarter.Name = "lbTextQuarter";
            this.lbTextQuarter.Size = new System.Drawing.Size(266, 76);
            this.lbTextQuarter.TabIndex = 8;
            this.lbTextQuarter.Text = "Quarter";
            // 
            // lbDown
            // 
            this.lbDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDown.BackColor = System.Drawing.Color.Black;
            this.lbDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 100.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDown.ForeColor = System.Drawing.Color.Crimson;
            this.lbDown.Location = new System.Drawing.Point(690, 464);
            this.lbDown.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDown.Name = "lbDown";
            this.lbDown.Size = new System.Drawing.Size(108, 133);
            this.lbDown.TabIndex = 9;
            this.lbDown.Text = "1";
            // 
            // lbTextDown
            // 
            this.lbTextDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTextDown.AutoSize = true;
            this.lbTextDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTextDown.Location = new System.Drawing.Point(648, 368);
            this.lbTextDown.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTextDown.Name = "lbTextDown";
            this.lbTextDown.Size = new System.Drawing.Size(207, 76);
            this.lbTextDown.TabIndex = 10;
            this.lbTextDown.Text = "Down";
            // 
            // pBHome
            // 
            this.pBHome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pBHome.Image = ((System.Drawing.Image)(resources.GetObject("pBHome.Image")));
            this.pBHome.Location = new System.Drawing.Point(-62, 60);
            this.pBHome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pBHome.Name = "pBHome";
            this.pBHome.Size = new System.Drawing.Size(256, 256);
            this.pBHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBHome.TabIndex = 11;
            this.pBHome.TabStop = false;
            // 
            // pBGuest
            // 
            this.pBGuest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pBGuest.Image = ((System.Drawing.Image)(resources.GetObject("pBGuest.Image")));
            this.pBGuest.Location = new System.Drawing.Point(1007, 60);
            this.pBGuest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pBGuest.Name = "pBGuest";
            this.pBGuest.Size = new System.Drawing.Size(256, 256);
            this.pBGuest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBGuest.TabIndex = 13;
            this.pBGuest.TabStop = false;
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Tai Le", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(216, -62);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(867, 85);
            this.lbTitle.TabIndex = 14;
            this.lbTitle.Text = "Salzburg Ducks Homefield";
            // 
            // pBPlayer
            // 
            this.pBPlayer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pBPlayer.BackColor = System.Drawing.SystemColors.Desktop;
            this.pBPlayer.Location = new System.Drawing.Point(-100, 26);
            this.pBPlayer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pBPlayer.Name = "pBPlayer";
            this.pBPlayer.Size = new System.Drawing.Size(1402, 683);
            this.pBPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBPlayer.TabIndex = 15;
            this.pBPlayer.TabStop = false;
            this.pBPlayer.Visible = false;
            // 
            // MediaPlayer
            // 
            this.MediaPlayer.Enabled = true;
            this.MediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.MediaPlayer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MediaPlayer.Name = "MediaPlayer";
            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
            this.MediaPlayer.Size = new System.Drawing.Size(1491, 754);
            this.MediaPlayer.TabIndex = 16;
            this.MediaPlayer.Visible = false;
            // 
            // Scoreboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1232, 638);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.pBGuest);
            this.Controls.Add(this.pBHome);
            this.Controls.Add(this.lbTextDown);
            this.Controls.Add(this.lbDown);
            this.Controls.Add(this.lbTextQuarter);
            this.Controls.Add(this.lbQuarter);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbTimeScoreboard);
            this.Controls.Add(this.lbTextGuest);
            this.Controls.Add(this.lbTextHome);
            this.Controls.Add(this.lbScoreHome);
            this.Controls.Add(this.lbScoreGuest);
            this.Controls.Add(this.pBPlayer);
            this.Controls.Add(this.MediaPlayer);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Scoreboard";
            this.Text = "Scoreboard";
            ((System.ComponentModel.ISupportInitialize)(this.pBHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBGuest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbScoreGuest;
        public System.Windows.Forms.Label lbScoreHome;
        public System.Windows.Forms.Label lbTextHome;
        public System.Windows.Forms.Label lbTextGuest;
        public System.Windows.Forms.Label lbTimeScoreboard;
        public System.Windows.Forms.Label lbTime;
        public System.Windows.Forms.Label lbQuarter;
        public System.Windows.Forms.Label lbTextQuarter;
        public System.Windows.Forms.Label lbDown;
        public System.Windows.Forms.Label lbTextDown;
        public System.Windows.Forms.PictureBox pBHome;
        public System.Windows.Forms.PictureBox pBGuest;
        public System.Windows.Forms.Label lbTitle;
        public System.Windows.Forms.PictureBox pBPlayer;
        public AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
    }
}