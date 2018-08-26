namespace GameOnPi
{
    partial class SettingsScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsScreen));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.resolutionList = new System.Windows.Forms.ListBox();
            this.widthField = new System.Windows.Forms.TextBox();
            this.heightField = new System.Windows.Forms.TextBox();
            this.bitrate = new System.Windows.Forms.TextBox();
            this.packetsize = new System.Windows.Forms.TextBox();
            this.codecList = new System.Windows.Forms.ListBox();
            this.remote = new System.Windows.Forms.CheckBox();
            this.nosops = new System.Windows.Forms.CheckBox();
            this.localAudio = new System.Windows.Forms.CheckBox();
            this.sorround = new System.Windows.Forms.CheckBox();
            this.unsupported = new System.Windows.Forms.CheckBox();
            this.windowed = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.fpsBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.platformList = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.gamePics = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(69, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Shrani";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SteelBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(230, 406);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 26);
            this.button2.TabIndex = 1;
            this.button2.Text = "Prekliči";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // resolutionList
            // 
            this.resolutionList.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.resolutionList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resolutionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resolutionList.FormattingEnabled = true;
            this.resolutionList.ItemHeight = 18;
            this.resolutionList.Items.AddRange(new object[] {
            "720p (1280 x 720)",
            "1080p (1920 x 1080)",
            "4K (3840 x 2160)"});
            this.resolutionList.Location = new System.Drawing.Point(12, 64);
            this.resolutionList.Name = "resolutionList";
            this.resolutionList.Size = new System.Drawing.Size(160, 54);
            this.resolutionList.TabIndex = 2;
            // 
            // widthField
            // 
            this.widthField.Location = new System.Drawing.Point(15, 217);
            this.widthField.MaxLength = 5;
            this.widthField.Name = "widthField";
            this.widthField.Size = new System.Drawing.Size(56, 20);
            this.widthField.TabIndex = 3;
            // 
            // heightField
            // 
            this.heightField.Location = new System.Drawing.Point(78, 217);
            this.heightField.MaxLength = 5;
            this.heightField.Name = "heightField";
            this.heightField.Size = new System.Drawing.Size(60, 20);
            this.heightField.TabIndex = 4;
            // 
            // bitrate
            // 
            this.bitrate.Location = new System.Drawing.Point(105, 249);
            this.bitrate.MaxLength = 10;
            this.bitrate.Name = "bitrate";
            this.bitrate.Size = new System.Drawing.Size(56, 20);
            this.bitrate.TabIndex = 5;
            // 
            // packetsize
            // 
            this.packetsize.Location = new System.Drawing.Point(148, 276);
            this.packetsize.MaxLength = 10;
            this.packetsize.Name = "packetsize";
            this.packetsize.Size = new System.Drawing.Size(56, 20);
            this.packetsize.TabIndex = 6;
            // 
            // codecList
            // 
            this.codecList.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.codecList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codecList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.codecList.FormattingEnabled = true;
            this.codecList.ItemHeight = 18;
            this.codecList.Items.AddRange(new object[] {
            "auto",
            "h264",
            "h265"});
            this.codecList.Location = new System.Drawing.Point(16, 319);
            this.codecList.Name = "codecList";
            this.codecList.Size = new System.Drawing.Size(100, 54);
            this.codecList.TabIndex = 7;
            // 
            // remote
            // 
            this.remote.AutoSize = true;
            this.remote.BackColor = System.Drawing.Color.Transparent;
            this.remote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.remote.ForeColor = System.Drawing.Color.White;
            this.remote.Location = new System.Drawing.Point(250, 169);
            this.remote.Name = "remote";
            this.remote.Size = new System.Drawing.Size(141, 19);
            this.remote.TabIndex = 8;
            this.remote.Text = "Optimizacija naprave";
            this.remote.UseVisualStyleBackColor = false;
            // 
            // nosops
            // 
            this.nosops.AutoSize = true;
            this.nosops.BackColor = System.Drawing.Color.Transparent;
            this.nosops.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nosops.ForeColor = System.Drawing.Color.White;
            this.nosops.Location = new System.Drawing.Point(250, 144);
            this.nosops.Name = "nosops";
            this.nosops.Size = new System.Drawing.Size(222, 19);
            this.nosops.TabIndex = 9;
            this.nosops.Text = "GPE lahko spreminja nastavitve igre";
            this.nosops.UseVisualStyleBackColor = false;
            // 
            // localAudio
            // 
            this.localAudio.AutoSize = true;
            this.localAudio.BackColor = System.Drawing.Color.Transparent;
            this.localAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.localAudio.ForeColor = System.Drawing.Color.White;
            this.localAudio.Location = new System.Drawing.Point(250, 39);
            this.localAudio.Name = "localAudio";
            this.localAudio.Size = new System.Drawing.Size(147, 19);
            this.localAudio.TabIndex = 10;
            this.localAudio.Text = "Predvajaj zvok lokalno";
            this.localAudio.UseVisualStyleBackColor = false;
            // 
            // sorround
            // 
            this.sorround.AutoSize = true;
            this.sorround.BackColor = System.Drawing.Color.Transparent;
            this.sorround.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sorround.ForeColor = System.Drawing.Color.White;
            this.sorround.Location = new System.Drawing.Point(250, 64);
            this.sorround.Name = "sorround";
            this.sorround.Size = new System.Drawing.Size(174, 19);
            this.sorround.TabIndex = 11;
            this.sorround.Text = "Pretakaj 5.1 prostorski zvok";
            this.sorround.UseVisualStyleBackColor = false;
            // 
            // unsupported
            // 
            this.unsupported.AutoSize = true;
            this.unsupported.BackColor = System.Drawing.Color.Transparent;
            this.unsupported.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.unsupported.ForeColor = System.Drawing.Color.White;
            this.unsupported.Location = new System.Drawing.Point(250, 192);
            this.unsupported.Name = "unsupported";
            this.unsupported.Size = new System.Drawing.Size(189, 19);
            this.unsupported.TabIndex = 12;
            this.unsupported.Text = "Pretakanje brez GPE podpore";
            this.unsupported.UseVisualStyleBackColor = false;
            // 
            // windowed
            // 
            this.windowed.AutoSize = true;
            this.windowed.BackColor = System.Drawing.Color.Transparent;
            this.windowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.windowed.ForeColor = System.Drawing.Color.White;
            this.windowed.Location = new System.Drawing.Point(15, 169);
            this.windowed.Name = "windowed";
            this.windowed.Size = new System.Drawing.Size(101, 19);
            this.windowed.TabIndex = 13;
            this.windowed.Text = "Prikaži v oknu";
            this.windowed.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(247, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nastavitve zvoka";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nastavitve slike";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(247, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Nastavitve sistema";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Bitrate v Kbps:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Velikost paketa v bajtih:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(13, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Širina in višina videa:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "Ločljivost pretakanja:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(13, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 15);
            this.label8.TabIndex = 21;
            this.label8.Text = "Kodek za video:";
            // 
            // fpsBox
            // 
            this.fpsBox.Location = new System.Drawing.Point(50, 142);
            this.fpsBox.MaxLength = 10;
            this.fpsBox.Name = "fpsBox";
            this.fpsBox.Size = new System.Drawing.Size(35, 20);
            this.fpsBox.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(13, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "FPS:";
            // 
            // platformList
            // 
            this.platformList.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.platformList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.platformList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.platformList.FormattingEnabled = true;
            this.platformList.ItemHeight = 18;
            this.platformList.Items.AddRange(new object[] {
            "auto",
            "pi",
            "imx",
            "aml",
            "x11",
            "x11_vdpau",
            "sdl",
            "fake"});
            this.platformList.Location = new System.Drawing.Point(318, 229);
            this.platformList.Name = "platformList";
            this.platformList.Size = new System.Drawing.Size(91, 144);
            this.platformList.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(247, 276);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 30);
            this.label10.TabIndex = 25;
            this.label10.Text = "Sistem za \r\npretakanje:";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SteelBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(148, 364);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 26);
            this.button3.TabIndex = 26;
            this.button3.Text = "Ponastavi";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // gamePics
            // 
            this.gamePics.AutoSize = true;
            this.gamePics.BackColor = System.Drawing.Color.Transparent;
            this.gamePics.Checked = true;
            this.gamePics.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gamePics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gamePics.ForeColor = System.Drawing.Color.White;
            this.gamePics.Location = new System.Drawing.Point(249, 119);
            this.gamePics.Name = "gamePics";
            this.gamePics.Size = new System.Drawing.Size(209, 19);
            this.gamePics.TabIndex = 27;
            this.gamePics.Text = "Naloži naslovnice iger iz interneta";
            this.gamePics.UseVisualStyleBackColor = false;
            // 
            // SettingsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::GameOnPi.Properties.Resources.settings_backgroud;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(483, 444);
            this.Controls.Add(this.gamePics);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.platformList);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fpsBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.windowed);
            this.Controls.Add(this.unsupported);
            this.Controls.Add(this.sorround);
            this.Controls.Add(this.localAudio);
            this.Controls.Add(this.nosops);
            this.Controls.Add(this.remote);
            this.Controls.Add(this.codecList);
            this.Controls.Add(this.packetsize);
            this.Controls.Add(this.bitrate);
            this.Controls.Add(this.heightField);
            this.Controls.Add(this.widthField);
            this.Controls.Add(this.resolutionList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nastavitve";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox resolutionList;
        private System.Windows.Forms.TextBox widthField;
        private System.Windows.Forms.TextBox heightField;
        private System.Windows.Forms.TextBox bitrate;
        private System.Windows.Forms.TextBox packetsize;
        private System.Windows.Forms.ListBox codecList;
        private System.Windows.Forms.CheckBox remote;
        private System.Windows.Forms.CheckBox nosops;
        private System.Windows.Forms.CheckBox localAudio;
        private System.Windows.Forms.CheckBox sorround;
        private System.Windows.Forms.CheckBox unsupported;
        private System.Windows.Forms.CheckBox windowed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox fpsBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox platformList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox gamePics;
    }
}