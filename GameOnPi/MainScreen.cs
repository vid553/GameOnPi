/*
 * Game On Pi Application
 * 
 * Copyright (C) 2018 vid553 <vid.majster@gmail.com>
 * 
 * Icon made by Freepik from www.flaticon.com
 * Background Images from www.pexels.com
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Renci.SshNet;

namespace GameOnPi
{
    public partial class MainScreen : Form
    {
        // Parametri za ssh povezavo
        public static string deviceIp;
        public static string deviceUsername;
        public static SecureString devicePassword;

        //Parametri za nastavitve
        // obvezni
        public static string resolution;  // 720, 1080, 4k
        public static int fps;               // 30 ali 60 ali druga številka

        // neobvezni
        public static int widthRes;
        public static int heightRes;
        public static int bitrate;
        public static int packetsize;

        public static string codec;
        public static bool remote;
        public static bool nosops;
        public static bool localAudio;
        public static bool sorround;

        public static string platform;
        public static bool unsupported;
        public static bool windowed;

        // Parametri za delovanje GUI-ja
        public static bool gamePics;        // dovoli prenos slik iz interneta

        // Privatne info spremenljivke
        private string igdbKey = "2e22a53106fef00128b609202cfcc516";    // ključ za dostop do API-ja od IGDB
        private SshClient sshClient; // objekt za SSH
        private bool isPaired = false;  // če je ta PC seznanjen s napravo
        private static SshCommand streamCommand;
        private BackgroundWorker streamWorker;
        private static int formHeight;
        private static int formWidth;

        public MainScreen()
        {
            InitializeComponent();
            KeyPreview = true;
            infoLabel.Visible = false;
            formHeight = Height;
            formWidth = Width;

            if (File.Exists("settings.config"))
            {
                LoadSettingsFile();
            }
            else
            {
                LoadDefaultParameters();
            }
            OpenConnectScreen();
        }

        public static void LoadDefaultParameters()    // nastavimo privzete parametre
        {
            deviceIp = "";
            deviceUsername = "";

            resolution = "1080";
            fps = 60;
            widthRes = 0;
            heightRes = 0;
            bitrate = 0;
            packetsize = 0;

            codec = "auto";
            remote = false;
            nosops = true;
            localAudio = false;
            sorround = false;

            platform = "auto";
            unsupported = false;
            windowed = false;

            gamePics = true;
        }

        private void button1_Click(object sender, EventArgs e)  // klik na gumb Poveži oz. Prekini povezavo
        {
            if (sshClient != null && sshClient.IsConnected)
            {
                sshClient.Disconnect();
                button1.Text = "Poveži se z napravo";
                flowLayoutPanel1.Visible = false;
                flowLayoutPanel1.Controls.Clear();
                infoLabel.Text = "Povezava prekinjena :(";
                infoLabel.Visible = true;
            }
            else
            {
                devicePassword.Clear();
                OpenConnectScreen();
            }
        }

        private void OpenConnectScreen()    // odpremo okno za vzpostavitev povezave
        {
            ConnectScreen connect = new ConnectScreen();
            connect.FormClosed += (o, form) =>
            {
                if (devicePassword != null)
                {
                    if (devicePassword.Length != 0)
                    {
                        infoLabel.Visible = false;
                        ConnectWithPi();
                    }
                }
                else
                {
                    infoLabel.Text = "Ni povezave :(";
                    infoLabel.Visible = true;
                }
            };
            connect.ShowDialog();
        }

        private void ConnectWithPi()    // vzpostavimo povezavo z napravo
        {
            try
            {
                if (deviceIp != null && deviceUsername != null && devicePassword != null)
                {
                    ConnectionInfo connectionInfo = new ConnectionInfo(deviceIp, deviceUsername, 
                        new PasswordAuthenticationMethod(deviceUsername, new NetworkCredential("", devicePassword).Password));
                    sshClient = new SshClient(connectionInfo);
                    sshClient.Connect();
                    if (sshClient.IsConnected == true)
                    {
                        button1.Text = "Prekini povezavo";
                        UpdateGameList(sshClient);
                    }
                    else
                    {
                        infoLabel.Text = "Napaka! Preverite povezavo z napravo...";
                        infoLabel.Visible = true;
                        button1.Text = "Poveži se z napravo";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Napaka pri vzpostavitvi povezave z napravo.");
                infoLabel.Text = "Ni povezave :(";
                button1.Text = "Poveži se z napravo";
                infoLabel.Visible = true;
                sshClient.Dispose();
                sshClient = null;
            }
        }

        private void UpdateGameList(SshClient client)   // posodobimo seznam iger, ki so na voljo
        {
            List<String> gameList = GetGameList(client);
            flowLayoutPanel1.Visible = true;
            infoLabel.Visible = false;
            if (gamePics == true)
            {
                if (Directory.Exists("game_covers/") == false)
                {
                    Directory.CreateDirectory("game_covers/");
                }
                List<String> loadedGamePics = 
                    Directory.GetFiles("game_covers/").Select(Path.GetFileNameWithoutExtension).ToList();
                int numOfPics = loadedGamePics.Count;
                int numOfNew = gameList.Count;
                int picsToLoad = numOfNew - numOfPics;
                if (picsToLoad > 0)
                {
                    for (int i = 0; i < gameList.Count; i++)
                    {
                        bool existsLocally = false;
                        for (int j = 0; j < loadedGamePics.Count; j++)
                        {
                            if (gameList[i] == loadedGamePics[j])
                            {
                                existsLocally = true;
                            }
                        }
                        if (existsLocally == false)
                        {
                            DownloadGamePic(gameList[i]);
                        }
                    }
                }
                List<String> allGamePicsNames = 
                    Directory.GetFiles("game_covers/").Select(Path.GetFileNameWithoutExtension).ToList();
                for (int i = 0; i < allGamePicsNames.Count; i++)
                {
                    Image gameImage = Image.FromFile("game_covers/" + allGamePicsNames[i] + ".jpg");
                    string picName = allGamePicsNames[i].Replace("+", ":");
                    int maxWidth = gameImage.Width;
                    int maxHeight = gameImage.Height;
                    Button button = new Button();
                    button.Name = picName;
                    button.MouseDown += delegate
                    {
                        StartStream(client, picName);
                    };
                    button.BackgroundImage = gameImage;
                    button.MinimumSize = new Size(maxWidth, maxHeight);
                    ToolTip toolTip = new ToolTip();
                    toolTip.SetToolTip(button, allGamePicsNames[i]);
                    flowLayoutPanel1.Controls.Add(button);
                }
            }
            else // Če je pridobivanje slik videoiger izklopljeno
            {
                for (int i = 0; i < gameList.Count(); i++)
                {
                    Button button = new Button();
                    button.Name = gameList[i];
                    button.Text = gameList[i];
                    button.MouseDown += delegate
                    {
                        StartStream(client, gameList[i]);
                    };
                    button.MinimumSize = new Size(200, 200);
                    button.Font = new Font("Stencil", 20f, FontStyle.Bold);
                    button.BackColor = Color.SteelBlue;
                    button.FlatStyle = FlatStyle.Flat;
                    flowLayoutPanel1.Controls.Add(button);
                }
            }
            
        }

        private void DownloadGamePic(string searchGame) // prenesemo slike od novih iger iz igdb.com
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest
                .Create("https://api-endpoint.igdb.com/games/?search=" + searchGame.Replace(" ", "%20"));
            webRequest.Method = "GET";
            webRequest.Accept = "application/json";
            webRequest.Headers["user-key"] = igdbKey;

            string jsonResponse = "";
            using (Stream s = webRequest.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    jsonResponse = sr.ReadToEnd();
                }
            }
            int startPos = jsonResponse.IndexOf(':') + 1;
            int length = jsonResponse.IndexOf('}') - startPos;
            string id = jsonResponse.Substring(startPos, length);

            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest
                .Create("https://api-endpoint.igdb.com/games/" +  id);
            webRequest2.Method = "GET";
            webRequest2.Accept = "application/json";
            webRequest2.Headers["user-key"] = igdbKey;

            string jsonResponse2 = "";
            using (Stream s = webRequest2.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    jsonResponse2 = sr.ReadToEnd();
                }
            }
            jsonResponse2 = jsonResponse2.Substring(1, jsonResponse2.Length-2);
            JObject game = JObject.Parse(jsonResponse2);
            try
            {
                string coverUrl = (string)game["cover"]["url"];
                string picUrl = coverUrl.Replace("t_thumb", "t_cover_big");
                picUrl = picUrl.Substring(2);

                WebClient webClient = new WebClient();
                DirectoryInfo di = Directory.CreateDirectory("game_covers/");
                searchGame = searchGame.Replace(":", "+");
                webClient.DownloadFile("http://" + picUrl, "game_covers/" + searchGame + ".jpg");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private List<String> GetGameList(SshClient client)  // pridobimo seznam vseh možnih iger
        {
            SshCommand listCommand = client.CreateCommand("moonlight list");
            listCommand.Execute();
            string resultCommand = listCommand.Result;
            string[] result = resultCommand.Split('\n');
            List<String> allGames = new List<string>();
            if (result[1].Contains("Connect to"))
            {
                for (int i = 2; i < result.Length; i++)
                {
                    if (result[i].Contains(i - 1 + "."))
                    {
                        string game = result[i].Substring(result[i].IndexOf('.') + 2);
                        allGames.Add(game);
                    }
                }
            }
            if (allGames.Count == 0)
            {
                MessageBox.Show("Ni najdenih kompatibilnih iger :(");
                return null;
            }
            return allGames;
        }

        private void button3_Click(object sender, EventArgs e)  // klik na gumb Seznani ta pc
        {
            if (isPaired != true)
            {
                PairWithComputer(sshClient);
            }
            else
            {
                UnpairWithComputer(sshClient);
            }
        }

        private void PairWithComputer(SshClient client) // seznanimo pc s pi-jem
        {
            if (client != null || client.IsConnected == true)
            {
                IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName())
                    .Where(address => address.AddressFamily == AddressFamily.InterNetwork).First();
                SshCommand listCommand = client.CreateCommand("moonlight pair " + ip.ToString());
                string result = listCommand.Execute();
                if (result.Contains("error"))
                {
                    MessageBox.Show("Napaka pri seznanjanju.");
                }
                else if (result.Contains("already"))
                {
                    MessageBox.Show("Računalnik je že bil seznanjen s napravo.");
                    isPaired = true;
                    button3.Text = "Prekini seznanitev";
                }
                else if (result.Contains("PIN"))
                {
                    int pin = Convert.ToInt32(result.Substring(result.IndexOf(':') + 2, 4));
                    MessageBox.Show("Koda PIN: " + pin);
                    button3.Text = "Prekini seznanitev";
                }
                else
                {
                    MessageBox.Show("Računalnik uspešno seznanjen s napravo.");
                    isPaired = true;
                    button3.Text = "Prekini seznanitev";
                }
            }
            else
            {
                MessageBox.Show("Ni vzpostavljene povezave z napravo.");
            }
        }

        private void UnpairWithComputer(SshClient client)   // prekinemo seznanitev pc-ja in pi-a
        {
            if (client != null)
            {
                IPAddress ip = Dns.GetHostAddresses(Dns.GetHostName())
                    .Where(address => address.AddressFamily == AddressFamily.InterNetwork).First();
                SshCommand listCommand = client.CreateCommand("moonlight unpair " + ip.ToString());
                string result = listCommand.Execute();
                if (result.Contains("error"))
                {
                    MessageBox.Show("Napaka pri odstranjevanju povezave.");
                }
                else if (result.Contains("never"))
                {
                    MessageBox.Show("Računalnik ni bil seznanjen s napravo.");
                    isPaired = false;
                    button3.Text = "Seznani ta PC";
                }
                else
                {
                    MessageBox.Show("Računalnik in naprava nista več seznanjena.");
                    isPaired = false;
                    button3.Text = "Seznani ta PC";
                }
            }
            else
            {
                MessageBox.Show("Ni vzpostavljene povezave z napravo.");
            }
        }

        private void StartStream(SshClient client, string game) // zaženemo stream z izbrano igro
        {
            if (game.Contains(" ")) { game = "'" + game + "'"; }
            flowLayoutPanel1.Visible = false;
            infoLabel.Text = "Zagon igre...\n" +
                "Za izhod iz pretakanja pritisnite: \n\n" +
                "Na PC-ju: ALT in F12 \n" +
                "Na Pi-ju: CTRL, ALT, SHIFT in Q";
            infoLabel.Visible = true;

            string optionalArgs = "";
            if (widthRes > 0) { optionalArgs += "-width " + widthRes + " "; }
            if (heightRes > 0) { optionalArgs += "-height " + heightRes + " "; }
            if (bitrate > 0) { optionalArgs += "-bitrate " + bitrate + " "; }
            if (packetsize > 0) { optionalArgs += "-packetsize " + packetsize + " "; }
            if (codec != "auto") { optionalArgs += "-codec " + codec + " "; }
            if (remote == true) { optionalArgs += "-remote "; }
            if (nosops == false) { optionalArgs += "-nosops "; }
            if (localAudio == true) { optionalArgs += "-localaudio "; }
            if (sorround == true) { optionalArgs += "-sorround "; }
            if (platform != "auto") { optionalArgs += "-platform " + platform + " "; }

            streamCommand = client.CreateCommand
                ("moonlight stream -" + resolution + " -fps " + fps +" -app " + game + " " + optionalArgs);

            streamWorker = new BackgroundWorker();
            streamWorker.DoWork += BeginStream;
            streamWorker.RunWorkerCompleted += UpdateGUI;
            streamWorker.RunWorkerAsync();
        }

        private void BeginStream(object sender, System.ComponentModel.DoWorkEventArgs e)    //zagon pretakanja v ozadju
        {
            string streamOutput = streamCommand.Execute();
            streamOutput = streamOutput.Replace("\n", "\r\n");
        }

        private void UpdateGUI(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)    // konec pretakanja v ozadju
        {
            infoLabel.Visible = false;
            flowLayoutPanel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)  // klik gumba Nastavitve
        {
            SettingsScreen settings = new SettingsScreen();
            settings.ShowDialog();
        }

        public static void SaveSettingsFile()   // shranimo nastavitve v datoteko
        {
            try
            {
                List<string> settingVariables = new List<string>();

                settingVariables.Add(resolution);
                settingVariables.Add(fps.ToString());
                settingVariables.Add(widthRes.ToString());
                settingVariables.Add(heightRes.ToString());
                settingVariables.Add(bitrate.ToString());
                settingVariables.Add(packetsize.ToString());

                settingVariables.Add(codec);
                settingVariables.Add(remote.ToString());
                settingVariables.Add(nosops.ToString());
                settingVariables.Add(localAudio.ToString());
                settingVariables.Add(sorround.ToString());

                settingVariables.Add(platform);
                settingVariables.Add(unsupported.ToString());
                settingVariables.Add(windowed.ToString());

                settingVariables.Add(gamePics.ToString());
                settingVariables.Add(formHeight.ToString());
                settingVariables.Add(formWidth.ToString());

                settingVariables.Add(deviceIp);
                settingVariables.Add(deviceUsername);
            
                File.WriteAllLines("settings.config", settingVariables);
            }
            catch (Exception) {}
        }

        private void LoadSettingsFile() // naložimo nastavitve iz datoteke
        {
            try
            {
                List<string> settingVariables = new List<string>();
                settingVariables = File.ReadAllLines("settings.config").ToList();

                resolution = settingVariables[0];
                fps = Convert.ToInt32(settingVariables[1]);
                widthRes = Convert.ToInt32(settingVariables[2]);
                heightRes = Convert.ToInt32(settingVariables[3]);
                bitrate = Convert.ToInt32(settingVariables[4]);
                packetsize = Convert.ToInt32(settingVariables[5]);

                codec = settingVariables[6];
                remote = Convert.ToBoolean(settingVariables[7]);
                nosops = Convert.ToBoolean(settingVariables[8]);
                localAudio = Convert.ToBoolean(settingVariables[9]);
                sorround = Convert.ToBoolean(settingVariables[10]);

                platform = settingVariables[11];
                unsupported = Convert.ToBoolean(settingVariables[12]);
                windowed = Convert.ToBoolean(settingVariables[13]);

                gamePics = Convert.ToBoolean(settingVariables[14]);
                formHeight = Convert.ToInt32(settingVariables[15]);
                formWidth = Convert.ToInt32(settingVariables[16]);

                if (settingVariables.Count > 17)
                {
                    deviceIp = settingVariables[17];
                    deviceUsername = settingVariables[18];
                }

                Width = formWidth;
                Height = formHeight;
            }
            catch (Exception)
            {
                MessageBox.Show("Napaka pri branju datoteke z nastavitvami. Uporaba privzetih nastavitev...");
                LoadDefaultParameters();
            }
           
        }

        private void ExitStream(SshClient client)   // stop stream aplikacije oz. izhod iz programa
        {
            if (sshClient.IsConnected)
            {
                SshCommand listCommand = client.CreateCommand("moonlight quit");
                listCommand.Execute();
            }
            infoLabel.Visible = false;
            flowLayoutPanel1.Visible = true;
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)  // sprostimo vire ko se aplikacija zapre
        {
            formHeight = Height;
            formWidth = Width;
            SaveSettingsFile();
            if (devicePassword != null)
            {
                devicePassword.Dispose();
            }
            if (streamWorker != null)
            {
                streamWorker.Dispose();
            }
            if (sshClient != null)
            {
                if (sshClient.IsConnected == true)
                {
                    ExitStream(sshClient);
                }
                sshClient.Dispose();
                Dispose();
            }
        }

        private void MainScreen_KeyDown(object sender, KeyEventArgs e)  // stop stream ko uporabnik pritisne Alt + F12
        {
            if (e.KeyCode == Keys.F12 && (e.Alt))
            {
                if (sshClient != null && streamWorker != null)
                {
                    ExitStream(sshClient);
                    streamWorker.Dispose();
                }
            }
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
