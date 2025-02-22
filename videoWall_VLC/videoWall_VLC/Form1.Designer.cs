using System.IO;

namespace videoWall_VLC
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.vlcCont1 = new Vlc.DotNet.Forms.VlcControl();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.vlcCont2 = new Vlc.DotNet.Forms.VlcControl();
            ((System.ComponentModel.ISupportInitialize)(this.vlcCont1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcCont2)).BeginInit();
            this.SuspendLayout();
            // 
            // vlcCont1
            // 
            this.vlcCont1.BackColor = System.Drawing.Color.Black;
            this.vlcCont1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vlcCont1.Location = new System.Drawing.Point(12, 12);
            this.vlcCont1.Name = "vlcCont1";
            this.vlcCont1.Size = new System.Drawing.Size(274, 209);
            this.vlcCont1.Spu = -1;
            this.vlcCont1.TabIndex = 0;
            this.vlcCont1.Text = "vlcControl3";
            this.vlcCont1.VlcLibDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("vlcCont1.VlcLibDirectory")));
            this.vlcCont1.VlcMediaplayerOptions = new string[] {
        "--no-osd",
        "--no-video-title-show",
        ":input-repeat=65535"};
            this.vlcCont1.Playing += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs>(this.vlcCont1_Playing);
            this.vlcCont1.TimeChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs>(this.vlcCont1_TimeChanged);
            // 
            // lstMessages
            // 
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.ItemHeight = 27;
            this.lstMessages.Location = new System.Drawing.Point(573, 31);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(383, 355);
            this.lstMessages.TabIndex = 5;
            // 
            // vlcCont2
            // 
            this.vlcCont2.BackColor = System.Drawing.Color.Black;
            this.vlcCont2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vlcCont2.Location = new System.Drawing.Point(12, 242);
            this.vlcCont2.Name = "vlcCont2";
            this.vlcCont2.Size = new System.Drawing.Size(274, 209);
            this.vlcCont2.Spu = -1;
            this.vlcCont2.TabIndex = 6;
            this.vlcCont2.Text = "vlcControl3";
            this.vlcCont2.VlcLibDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("vlcCont2.VlcLibDirectory")));
            this.vlcCont2.VlcMediaplayerOptions = new string[] {
        "--no-osd",
        "--no-video-title-show",
        ":input-repeat=65535"};
            this.vlcCont2.Playing += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs>(this.vlcCont2_Playing);
            this.vlcCont2.TimeChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs>(this.vlcCont2_TimeChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 558);
            this.ControlBox = false;
            this.Controls.Add(this.vlcCont2);
            this.Controls.Add(this.lstMessages);
            this.Controls.Add(this.vlcCont1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.vlcCont1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcCont2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Vlc.DotNet.Forms.VlcControl vlcCont1;
        private System.Windows.Forms.ListBox lstMessages;
        private Vlc.DotNet.Forms.VlcControl vlcCont2;
    }
}

