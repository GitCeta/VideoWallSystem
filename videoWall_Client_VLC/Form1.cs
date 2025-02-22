using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Reflection.Emit;
using System.Threading;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace videoWall_Client
{
    public partial class Form1 : Form
    {

        private string[] allImagesFiles;

        string videoPath = Properties.Settings.Default.videoPath;
        string imagePath = Properties.Settings.Default.imagePath;

        string map_videoPath = Properties.Settings.Default.map_videoPath;
        string map_imagePath = Properties.Settings.Default.map_imagePath;

        private int port = 1669;
        private string ipAddress = Properties.Settings.Default.serverIP;

        int secilenSatir = -1;
        string secilenDosyaAdi;

        string save_ImagePath;

        FileItem secilen;

        public Form1()
        {
            InitializeComponent();

            save_ImagePath = map_imagePath;

            // Daha sonra debug için kullanabilirim. O yüzden visible false yaptım. Form'dan silmedim...
            txtMessage.Visible = false;
            btnSend.Visible = false;

            Assembly assemblyStillStore = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assemblyStillStore.Location);
            this.Text = this.Text + " v" + fileVersionInfo.FileVersion;

            PopulateTreeView(map_imagePath);
        }

        private void PopulateTreeView(string rootFolder)
        {
            treeViewFolders.Nodes.Clear();

            TreeNode rootNode = new TreeNode(rootFolder)
            {
                Tag = rootFolder,
                Text = Path.GetFileName(rootFolder),
            };

            treeViewFolders.Nodes.Add(rootNode);
            LoadDirectories(rootFolder, rootNode);
        }

        private void LoadDirectories(string dir, TreeNode node)
        {
            try
            {
                string[] subDirectories = Directory.GetDirectories(dir);
                foreach (string subDir in subDirectories)
                {
                    TreeNode subNode = new TreeNode(Path.GetFileName(subDir))
                    {
                        Tag = subDir // Tam yolu `Tag` içine kaydet
                    };
                    node.Nodes.Add(subNode);
                    LoadDirectories(subDir, subNode);
                }
            }
            catch
            {
                // Hata yönetimi
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button3.Enabled = true;

            butKlasorSec.Visible = false;

            lstFilesImage.DrawMode = DrawMode.OwnerDrawFixed;

            LoadFilesToListBox_Video(map_videoPath);
            LoadFilesToListBox_Image(map_imagePath);

            SaveImagelItems();
        }

        private void LoadFilesToListBox_Video(string directoryPath)
        {
            lstFilesVideo.Items.Clear();
            if (Directory.Exists(directoryPath))
            {
                // Desteklenen dosya uzantıları
                string[] videoExtensions = { "*.mov", "*.avi", "*.mp4", "*.mpeg", "*.mpg", "*.mkv", "*.m4v", "*.m2v", "*.mxf", "*.ts" };

                List<string> files = new List<string>();

                foreach (string extension in videoExtensions)
                {
                    files.AddRange(Directory.GetFiles(directoryPath, extension));
                }

                foreach (string filePath in files)
                {
                    lstFilesVideo.Items.Add(Path.GetFileName(filePath));
                }
            }
        }

        private void LoadFilesToListBox_Image(string directoryPath)
        {
            lstFilesImage.Items.Clear();

            if (Directory.Exists(directoryPath))
            {
                // Desteklenen resim uzantıları
                string[] imageExtensions = { "*.png", "*.jpg" };

                List<string> files = new List<string>();

                foreach (string extension in imageExtensions)
                {
                    files.AddRange(Directory.GetFiles(directoryPath, extension));
                }

                foreach (string filePath in files)
                {
                    // Dosya adını göster, tam yolu sakla
                    lstFilesImage.Items.Add(new FileItem
                    {
                        FileName = Path.GetFileName(filePath),
                        FullPath = filePath
                    });
                }
            }
        }

        public class FileItem
        {
            public string FileName { get; set; }
            public string FullPath { get; set; }

            public override string ToString()
            {
                return FileName;
            }
        }



        private void SendUdpMessage(string message)
        {
            try
            {
                using (UdpClient udpClient = new UdpClient())
                {
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);

                    byte[] data = Encoding.UTF8.GetBytes(message);

                    udpClient.Send(data, data.Length, endPoint);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;

            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            SendUdpMessage(message);
        }

        private void butTazele_Click(object sender, EventArgs e)
        {
            PopulateTreeView(save_ImagePath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gonderVideo();

            Thread.Sleep(3000);
        }
        private void gonderImage()
        {
            string fName;

            try
            {
                if (lstFilesImage.SelectedItem != null)
                {
                    string selectedFile = lstFilesImage.SelectedItem.ToString();

                    secilenSatir = lstFilesImage.SelectedIndex;
                    secilenDosyaAdi = lstFilesImage.Text;

                    secilen = lstFilesImage.SelectedItem as FileItem;

                    lstFilesImage.Refresh();

                    if (string.IsNullOrEmpty(selectedFile))
                    {
                        MessageBox.Show("Geçerli bir dosya seçmediniz.", "Hata");
                    }
                    else
                    {
                        string ayikla = map_imagePath;

                        fName = secilen.FullPath.Replace(ayikla, "").Trim('\\');
                        SendUdpMessage("IMAGE " + StringToHex(imagePath + "\\" + fName));
                    }
                }
                else
                {
                    MessageBox.Show("Dosya seçilmedi.", "Hata");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gonderVideo()
        {
            try
            {
                if (lstFilesVideo.SelectedItem != null)
                {
                    string selectedFile = lstFilesVideo.SelectedItem.ToString();

                    if (string.IsNullOrEmpty(selectedFile))
                    {
                        MessageBox.Show("Geçerli bir dosya seçmediniz.", "Hata");
                    }
                    else
                    {
                        SendUdpMessage("VIDEO " + StringToHex(videoPath + "\\" + selectedFile));
                    }
                }
                else
                {
                    MessageBox.Show("Dosya seçilmedi.", "Hata");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            gonderImage();

            Thread.Sleep(3000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            SendUdpMessage("ACTIVE1");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;

            SendUdpMessage("ACTIVE2");
        }

        private void resimBas(string dosya)
        {
            try
            {
                if (File.Exists(dosya))
                {
                    pictureBox1.Image = Image.FromFile(dosya);
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

        private void lstFilesImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFilesImage.SelectedItem != null)
            {
                if (lstFilesImage.SelectedItem is FileItem selectedItem)
                {
                    string fullPath = selectedItem.FullPath;

                    resimBas(fullPath);
                }

            }
        }

        private void lstFilesImage_DrawItem(object sender, DrawItemEventArgs e)
        {
            FileItem cursorKont = lstFilesImage.Items[e.Index] as FileItem;

            e.DrawBackground();

            string itemText = lstFilesImage.Items[e.Index].ToString();

            if (e.Index == secilenSatir)
            {
                if (secilenSatir == -1)
                {
                    itemText += "";
                }
                else
                {
                    if (textBox1.Text == "" && secilen.FileName == itemText && cursorKont.FullPath == secilen.FullPath)
                    {
                        itemText = ">>> " + itemText + " <<<";
                    }
                    else
                    {
                        itemText += "";
                    }
                }
            }

            e.Graphics.DrawString(itemText, e.Font, Brushes.Black, e.Bounds);

            e.DrawFocusRectangle();
        }

        private void SaveImagelItems()
        {
            allImagesFiles = lstFilesImage.Items
                                          .Cast<FileItem>()
                                          .Select(item => item.FullPath)
                                          .ToArray();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = textBox1.Text.ToLower();

            string selectedPath = "";

            if (treeViewFolders.SelectedNode != null && treeViewFolders.SelectedNode.Tag != null)
            {
                selectedPath = treeViewFolders.SelectedNode.Tag.ToString();
            }
            else
            {
                selectedPath = "";
            }

            if (selectedPath == "")
            {
                selectedPath = map_imagePath.ToString();
            }

            string ayikla = selectedPath;

            var filteredItems = allImagesFiles
                .Where(item => item.ToLower().Contains(filter))
                .Select(item => new FileItem
                {
                    FullPath = item,
                    FileName = item.Replace(ayikla, "").Trim('\\')
                })
                .ToArray();

            lstFilesImage.Items.Clear();
            lstFilesImage.Items.AddRange(filteredItems.Cast<object>().ToArray());
        }

        private void butYukleAcil_Click(object sender, EventArgs e)
        {
            gonderVideo();
            Thread.Sleep(1000);
            SendUdpMessage("ACTIVE1");
        }

        private void treeViewFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedPath = "";

            textBox1.Text = "";

            selectedPath = treeViewFolders.SelectedNode.Tag.ToString();

            LoadFilesToListBox_Image(selectedPath);

            SaveImagelItems();
        }

        private void butTazeleResimler_Click(object sender, EventArgs e)
        {
            string selectedPath = "";
            if (treeViewFolders.SelectedNode != null)
            {
                selectedPath = treeViewFolders.SelectedNode.Tag.ToString();

                LoadFilesToListBox_Video(map_videoPath);
                LoadFilesToListBox_Image(selectedPath);

                SaveImagelItems();
            }
        }
    }
}