/*
 * Game On Pi Application
 * 
 * Copyright (C) 2018 vid553 <vid.majster@gmail.com>
 * 
 * Icon made by Freepik from www.flaticon.com
 * Background Images from www.pexels.com
 */

using System;
using System.Net;
using System.Windows.Forms;

namespace GameOnPi
{
    public partial class ConnectScreen : Form
    {
        private static string deviceIp;
        private static string deviceUsername;
        private static string devicePassword;

        public ConnectScreen()
        {
            InitializeComponent();
            KeyPreview = true;
            LoadValues();
            label5.Visible = false;
        }

        private void LoadValues()   // naloži parametre v GUI
        {
            textBox1.Text = MainScreen.deviceIp;
            textBox3.Text = MainScreen.deviceUsername;
            textBox4.Text = "";
        }

        private void Connect()  // prenesi podatke v glavno okno in se poveži z napravo
        {
            deviceIp = textBox1.Text;
            deviceUsername = textBox3.Text;
            devicePassword = textBox4.Text;
            if (deviceIp == "" || deviceUsername == "" || devicePassword == "")
            {
                MessageBox.Show("Vnesite vse potrebne podatke!");
            }
            else
            {
                MainScreen.deviceIp = deviceIp;
                MainScreen.deviceUsername = deviceUsername;
                MainScreen.devicePassword = new NetworkCredential("", devicePassword).SecurePassword;
                MainScreen.SaveSettingsFile();
                label5.Visible = true;
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)  // klik na gumb vzpostavi povezavo
        {
            Connect();
        }

        private void ConnectScreen_KeyDown(object sender, KeyEventArgs e)   // če uporabnik pritisne enter
        {
            if(e.KeyCode == Keys.Enter)
            {
                Connect();
            }
        }

        private void ConnectScreen_FormClosing(object sender, FormClosingEventArgs e)   // ko se to okno zapira
        {
            if (e.CloseReason != CloseReason.UserClosing)
            {
                if (deviceIp == null || deviceIp == "" || deviceUsername == "" || devicePassword == "")
                {
                    MessageBox.Show("Vnesite vse potrebne podatke!");
                    e.Cancel = true;
                }
            }
        }
    }
}
