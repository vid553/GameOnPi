/*
 * Game On Pi Application
 * 
 * Copyright (C) 2018 Vid Rajtmajer <vid.rajtmajer@gmail.com>
 * 
 * Icon made by Freepik from www.flaticon.com
 * Background Images from www.pexels.com
 */

using System;
using System.Windows.Forms;

namespace GameOnPi
{
    public partial class SettingsScreen : Form
    {
        public SettingsScreen()
        {
            InitializeComponent();
            LoadSettings(); 
        }

        private void LoadSettings()  // naloži parametre v GUI
        {
            switch (MainScreen.resolution)
            {
                case "720": resolutionList.SelectedIndex = 0;
                    break;
                case "1080": resolutionList.SelectedIndex = 1;
                    break;
                case "4k":  resolutionList.SelectedIndex = 2;
                    break;
                default:    resolutionList.SelectedIndex = 0;
                    break;
            }
            fpsBox.Text = MainScreen.fps.ToString();
            if (MainScreen.widthRes != 0) { widthField.Text = MainScreen.widthRes.ToString(); }
            if (MainScreen.heightRes != 0) { heightField.Text = MainScreen.heightRes.ToString(); }
            if (MainScreen.bitrate != 0) { bitrate.Text = MainScreen.bitrate.ToString(); }
            if (MainScreen.packetsize != 0) { packetsize.Text = MainScreen.packetsize.ToString(); }
            codecList.SelectedItem = MainScreen.codec;
            remote.Checked = MainScreen.remote;
            nosops.Checked = MainScreen.nosops;
            localAudio.Checked = MainScreen.localAudio;
            sorround.Checked = MainScreen.sorround;
            platformList.SelectedItem = MainScreen.platform;
            unsupported.Checked = MainScreen.unsupported;
            windowed.Checked = MainScreen.windowed;
            gamePics.Checked = MainScreen.gamePics;
        }

        private void button1_Click(object sender, EventArgs e)  // klik na gumb Shrani
        {
            switch(resolutionList.SelectedIndex)
            {
                case 0: MainScreen.resolution = "720";
                    break;
                case 1: MainScreen.resolution = "1080";
                    break;
                case 2: MainScreen.resolution = "4k";
                    break;
                default: MainScreen.resolution = "720";
                    break;
            }
            if (fpsBox.Text != "")
            {
               try { MainScreen.fps = Convert.ToInt32(fpsBox.Text); }
               catch { MessageBox.Show("Napaka pri vnosu FPS parametra. Vnesite primerno številko."); }
            }
            if (widthField.Text != "")
            {
                try {  MainScreen.widthRes = Convert.ToInt32(widthField.Text); }
                catch { MessageBox.Show("Napaka pri vnosu Širina videa parametra. Vnesite primerno številko."); }
            }
            if (heightField.Text != "")
            {
                try { MainScreen.heightRes = Convert.ToInt32(heightField.Text); }
                catch { MessageBox.Show("Napaka pri vnosu Višina videa parametra. Vnesite primerno številko."); }
            }
            if (bitrate.Text != "")
            {
                try { MainScreen.bitrate = Convert.ToInt32(bitrate.Text); }
                catch { MessageBox.Show("Napaka pri vnosu bitrate parametra. Vnesite primerno številko."); }
            }
            if (packetsize.Text != "")
            {
                try { MainScreen.packetsize = Convert.ToInt32(packetsize.Text); }
                catch { MessageBox.Show("Napaka pri vnosu packetsize parametra. Vnesite primerno številko."); }
            }
            MainScreen.codec = codecList.SelectedItem.ToString();
            MainScreen.localAudio = localAudio.Checked;
            MainScreen.sorround = sorround.Checked;
            MainScreen.nosops = nosops.Checked;
            MainScreen.remote = remote.Checked;
            MainScreen.unsupported = unsupported.Checked;
            MainScreen.platform = platformList.SelectedItem.ToString();
            MainScreen.windowed = windowed.Checked;
            MainScreen.gamePics = gamePics.Checked;

            MainScreen.SaveSettingsFile();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)  // klik na gumb Prekliči
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)  // klik na gumb Ponastavi
        {
            MainScreen.LoadDefaultParameters();
            LoadSettings();
        }
    }
}
