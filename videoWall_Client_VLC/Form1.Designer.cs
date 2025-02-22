namespace videoWall_Client
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lstFilesVideo = new System.Windows.Forms.ListBox();
            this.lstFilesImage = new System.Windows.Forms.ListBox();
            this.butTazele = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.butYukleAcil = new System.Windows.Forms.Button();
            this.butKlasorSec = new System.Windows.Forms.Button();
            this.treeViewFolders = new System.Windows.Forms.TreeView();
            this.butTazeleResimler = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(1181, 556);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(145, 21);
            this.txtMessage.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(1274, 638);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(52, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "button1";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lstFilesVideo
            // 
            this.lstFilesVideo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lstFilesVideo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstFilesVideo.FormattingEnabled = true;
            this.lstFilesVideo.ItemHeight = 16;
            this.lstFilesVideo.Location = new System.Drawing.Point(12, 45);
            this.lstFilesVideo.Name = "lstFilesVideo";
            this.lstFilesVideo.Size = new System.Drawing.Size(288, 596);
            this.lstFilesVideo.TabIndex = 3;
            // 
            // lstFilesImage
            // 
            this.lstFilesImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lstFilesImage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstFilesImage.FormattingEnabled = true;
            this.lstFilesImage.ItemHeight = 16;
            this.lstFilesImage.Location = new System.Drawing.Point(315, 45);
            this.lstFilesImage.Name = "lstFilesImage";
            this.lstFilesImage.Size = new System.Drawing.Size(288, 564);
            this.lstFilesImage.TabIndex = 4;
            this.lstFilesImage.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstFilesImage_DrawItem);
            this.lstFilesImage.SelectedIndexChanged += new System.EventHandler(this.lstFilesImage_SelectedIndexChanged);
            // 
            // butTazele
            // 
            this.butTazele.Location = new System.Drawing.Point(809, 45);
            this.butTazele.Name = "butTazele";
            this.butTazele.Size = new System.Drawing.Size(82, 26);
            this.butTazele.TabIndex = 5;
            this.butTazele.Text = "Tazele";
            this.butTazele.UseVisualStyleBackColor = true;
            this.butTazele.Click += new System.EventHandler(this.butTazele_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Video";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(312, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Resimler";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(12, 648);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 27);
            this.button1.TabIndex = 8;
            this.button1.Text = "Yükle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(315, 648);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 27);
            this.button2.TabIndex = 9;
            this.button2.Text = "Yükle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.Location = new System.Drawing.Point(110, 648);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 27);
            this.button3.TabIndex = 10;
            this.button3.Text = "Video Ekrana Ver";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.Location = new System.Drawing.Point(423, 647);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(152, 28);
            this.button4.TabIndex = 11;
            this.button4.Text = "Resim Ekrana Ver";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.Location = new System.Drawing.Point(609, 261);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(702, 348);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(315, 620);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(285, 23);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // butYukleAcil
            // 
            this.butYukleAcil.BackColor = System.Drawing.Color.Red;
            this.butYukleAcil.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butYukleAcil.Location = new System.Drawing.Point(187, 13);
            this.butYukleAcil.Name = "butYukleAcil";
            this.butYukleAcil.Size = new System.Drawing.Size(113, 27);
            this.butYukleAcil.TabIndex = 14;
            this.butYukleAcil.Text = "Acil Yükle";
            this.butYukleAcil.UseVisualStyleBackColor = false;
            this.butYukleAcil.Visible = false;
            this.butYukleAcil.Click += new System.EventHandler(this.butYukleAcil_Click);

            // 
            // treeViewFolders
            // 
            this.treeViewFolders.Location = new System.Drawing.Point(609, 45);
            this.treeViewFolders.Name = "treeViewFolders";
            this.treeViewFolders.Size = new System.Drawing.Size(194, 210);
            this.treeViewFolders.TabIndex = 16;
            this.treeViewFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFolders_AfterSelect);
            // 
            // butTazeleResimler
            // 
            this.butTazeleResimler.Location = new System.Drawing.Point(521, 12);
            this.butTazeleResimler.Name = "butTazeleResimler";
            this.butTazeleResimler.Size = new System.Drawing.Size(82, 26);
            this.butTazeleResimler.TabIndex = 17;
            this.butTazeleResimler.Text = "Tazele";
            this.butTazeleResimler.UseVisualStyleBackColor = true;
            this.butTazeleResimler.Click += new System.EventHandler(this.butTazeleResimler_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 684);
            this.Controls.Add(this.butTazeleResimler);
            this.Controls.Add(this.treeViewFolders);
            this.Controls.Add(this.butKlasorSec);
            this.Controls.Add(this.butYukleAcil);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butTazele);
            this.Controls.Add(this.lstFilesImage);
            this.Controls.Add(this.lstFilesVideo);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Video Wall";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox lstFilesVideo;
        private System.Windows.Forms.ListBox lstFilesImage;
        private System.Windows.Forms.Button butTazele;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button butYukleAcil;
        private System.Windows.Forms.Button butKlasorSec;
        private System.Windows.Forms.TreeView treeViewFolders;
        private System.Windows.Forms.Button butTazeleResimler;
    }
}

