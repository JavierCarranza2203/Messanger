namespace Messanger
{
    partial class Servidor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listMessages = new ListBox();
            btnStartServer = new Button();
            btnSend = new Button();
            txtMessage = new TextBox();
            btnSendFile = new Button();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // listMessages
            // 
            listMessages.BackColor = SystemColors.ActiveCaptionText;
            listMessages.Font = new Font("Futura Hv BT", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listMessages.ForeColor = Color.White;
            listMessages.FormattingEnabled = true;
            listMessages.Location = new Point(12, 68);
            listMessages.Name = "listMessages";
            listMessages.Size = new Size(810, 388);
            listMessages.TabIndex = 0;
            // 
            // btnStartServer
            // 
            btnStartServer.BackgroundImage = Properties.Resources._1841400_200;
            btnStartServer.BackgroundImageLayout = ImageLayout.Zoom;
            btnStartServer.Font = new Font("Futura Hv BT", 9F);
            btnStartServer.Location = new Point(862, 470);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(50, 50);
            btnStartServer.TabIndex = 1;
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Click += btnStartServer_Click;
            // 
            // btnSend
            // 
            btnSend.BackgroundImage = Properties.Resources.send_icon_md;
            btnSend.BackgroundImageLayout = ImageLayout.Stretch;
            btnSend.Font = new Font("Futura Hv BT", 9F);
            btnSend.Location = new Point(862, 528);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(50, 50);
            btnSend.TabIndex = 2;
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtMessage
            // 
            txtMessage.Font = new Font("Futura Hv BT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMessage.Location = new Point(12, 470);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(844, 166);
            txtMessage.TabIndex = 3;
            // 
            // btnSendFile
            // 
            btnSendFile.BackColor = Color.White;
            btnSendFile.BackgroundImage = Properties.Resources._1388902;
            btnSendFile.BackgroundImageLayout = ImageLayout.Zoom;
            btnSendFile.Font = new Font("Futura Hv BT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSendFile.Location = new Point(862, 584);
            btnSendFile.Name = "btnSendFile";
            btnSendFile.Padding = new Padding(50);
            btnSendFile.Size = new Size(50, 50);
            btnSendFile.TabIndex = 4;
            btnSendFile.UseVisualStyleBackColor = false;
            btnSendFile.Click += btnSendFile_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Futura Hv BT", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(178, 29);
            label1.TabIndex = 5;
            label1.Text = "WAZAGRAM™";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BackgroundImage = Properties.Resources.user;
            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.Location = new Point(832, 379);
            panel1.Name = "panel1";
            panel1.Size = new Size(80, 77);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BackgroundImage = Properties.Resources.user;
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.Location = new Point(832, 68);
            panel2.Name = "panel2";
            panel2.Size = new Size(80, 77);
            panel2.TabIndex = 7;
            // 
            // Servidor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(920, 651);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(btnSendFile);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            Controls.Add(btnStartServer);
            Controls.Add(listMessages);
            Name = "Servidor";
            Text = "Servidor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listMessages;
        private Button btnStartServer;
        private Button btnSend;
        private TextBox txtMessage;
        private Button btnSendFile;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
    }
}
