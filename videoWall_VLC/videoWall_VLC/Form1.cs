using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Vlc.DotNet.Forms;

namespace videoWall_VLC
{
    public partial class Form1 : Form
    {
        private bool actionDone1 = false;
        private bool actionDone2 = false;

        private bool isPlayingVlcCont1 = false;
        private bool isPlayingVlcCont2 = false;

        private Image image;

        int buffNo = 1;
        bool genResCheck = false;

        int ekrandaki = 1;

        private UdpClient udpClient;
        private int port = 1669; // Dinlemek istediğiniz UDP portu
        private bool isListening = false;
        public Form1()
        {
            InitializeComponent();

            /*
            foreach (var process in Process.GetProcessesByName("mpc-hc64"))
            {
                try
                {
                    process.Kill();
                    process.WaitForExit(); // Kapatılmasını bekle
                }
                catch (Exception ex)
                {
                }
            }
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint, true);
            this.UpdateStyles();

            this.DoubleBuffered = true;

            this.Location = new Point(0, 0);
            this.Size = new Size(7680, 4320);

            this.KeyPreview = true;

            vlcCont1.Dock = DockStyle.Fill;
            vlcCont2.Dock = DockStyle.Fill;

            Application.DoEvents();

            Thread.Sleep(1000);

            dinlemeyeBasla();

            Cursor.Hide();

            lstMessages.Visible = true;

            vlcCont1.Visible = true;
            vlcCont2.Visible = true;

            vlcCont1.BringToFront();

            vlcCont1.VlcMediaPlayer.Video.FullScreen = true;
            vlcCont2.VlcMediaPlayer.Video.FullScreen = true;
            vlcCont1.VlcMediaPlayer.Video.AspectRatio = $"{this.ClientSize.Width}:{this.ClientSize.Height}";
            vlcCont2.VlcMediaPlayer.Video.AspectRatio = $"{this.ClientSize.Width}:{this.ClientSize.Height}";
        }

        private void ClearScreen()
        {
            using (Graphics g = this.CreateGraphics())
            {
                g.Clear(this.BackColor); // Formun arka plan rengini temizler
            }
        }

        private async void dinlemeyeBasla()
        {
            if (!isListening)
            {
                isListening = true;
                lstMessages.Items.Add($"Port {port} üzerinden UDP mesajları dinleniyor...");

                udpClient = new UdpClient(port);

                await ListenForMessagesAsync();
            }
            else
            {
                isListening = false;
                udpClient?.Close();
                lstMessages.Items.Add("Dinleme durduruldu.");
            }
        }
        private async Task ListenForMessagesAsync()
        {
            string cevir;
            string[] gelenKomut;

            bool check;

            lstMessages.Items.Add("----");

            try
            {
                while (isListening)
                {
                    UdpReceiveResult receiveResult = await udpClient.ReceiveAsync();

                    byte[] data = receiveResult.Buffer;

                    string message = Encoding.UTF8.GetString(data);

                    gelenKomut = message.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (gelenKomut.Length > 0)
                    {
                        if (gelenKomut[0] == "VIDEO")
                        {
                           Launch(gelenKomut[1]);
                        }

                        if (gelenKomut[0] == "IMAGE")
                        {
                            string resimDosyaYolu = gelenKomut[1];

                            Launch(gelenKomut[1]);
                            //resimBas6(resimDosyaYolu);
                        }

                        if (gelenKomut[0] == "ACTIVE1")
                        {
                            Application.DoEvents();

                            //pictureBox1.BringToFront();
                            //lstMessages.BringToFront();
                        }

                        if (gelenKomut[0] == "ACTIVE2")
                        {
                            Application.DoEvents();

                            //pictureBox1.BringToFront();
                            //lstMessages.BringToFront();
                        }
                    }

                    //cevir = HexToString(message);
                    //lstMessages.Items.Add($"Gelen mesaj: {message}");
                    lstMessages.Items.Add(HexToString(gelenKomut[1]));
                }
            }
            catch (ObjectDisposedException)
            {
                lstMessages.Items.Add("hata");
                // UDP kapatıldığında oluşacak hatayı yok say
            }
            catch (Exception ex)
            {
                lstMessages.Items.Add($"Hata oluştu: {ex.Message}");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                Application.Exit();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            udpClient?.Close();
            udpClient = null;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor.Show();
        }

        private void Launch(string dosya)
        {
            string filePath;

            dosya = HexToString(dosya);

            filePath = dosya;

            try
            {
                if (File.Exists(dosya))
                {
                    string[] options = new string[]
                    {
                        "--no-osd", // Ekran üzerindeki OSD'yi devre dışı bırak
                        "--no-video-title-show", // Başlık gösterimini devre dışı bırak
                        ":network-caching=10000",
                        ":file-caching=10000",
                        ":input-repeat=65535"    // Sonsuz tekrar
                    };

                    if (buffNo == 1)
                    {
                        vlcCont2.SetMedia(new Uri(filePath), options);
                    }

                    if (buffNo == 2)
                    {
                        vlcCont1.SetMedia(new Uri(filePath), options);
                    }

                    if (buffNo == 1)
                    {
                        vlcCont2.Play();
                    }

                    if (buffNo == 2)
                    {
                        vlcCont1.Play();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        static string StringToHex(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            StringBuilder sb = new StringBuilder();

            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

        static string HexToString(string hexInput)
        {
            int numberOfChars = hexInput.Length / 2;
            byte[] bytes = new byte[numberOfChars];

            for (int i = 0; i < numberOfChars; i++)
            {
                bytes[i] = Convert.ToByte(hexInput.Substring(i * 2, 2), 16);
            }

            return Encoding.UTF8.GetString(bytes);
        }

        private void vlcCont1_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
        {
            isPlayingVlcCont1 = true;

            actionDone1 = false;
        }

        private void vlcCont2_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
        {
            isPlayingVlcCont2 = true;

            actionDone2 = false;
        }

        private void vlcCont1_TimeChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs e)
        {
            if (!actionDone1 && e.NewTime >= 1000)
            {
                actionDone1 = true;
                buffNo = 1;

                if (vlcCont1.InvokeRequired)
                {
                    vlcCont1.Invoke(new Action(() => vlcCont1.BringToFront()));

                    stop2();
                }
                else
                {
                    vlcCont1.BringToFront();

                    stop2();
                }
            }
        }

        private void stop1()
        {
            if (vlcCont1.InvokeRequired)
            {
                vlcCont1.Invoke(new Action(() => vlcCont1.Stop()));
            }
            else
            {
                vlcCont1.Stop();
            }
        }

        private void stop2()
        {
            if (vlcCont2.InvokeRequired)
            {
                vlcCont2.Invoke(new Action(() => vlcCont2.Stop()));
            }
            else
            {
                vlcCont2.Stop();
            }
        }

        private void vlcCont2_TimeChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs e)
        {
            if (!actionDone2 && e.NewTime >= 1000)
            {
                actionDone2 = true;
                buffNo = 2;

                if (vlcCont2.InvokeRequired)
                {
                    vlcCont2.Invoke(new Action(() => vlcCont2.BringToFront()));

                    stop1();
                }
                else
                {
                    vlcCont2.BringToFront();

                    stop1();
                }
            }
        }
    }
}
