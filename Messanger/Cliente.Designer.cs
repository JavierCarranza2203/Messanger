namespace Messanger
{
    partial class Cliente
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
            btnConnect = new Button();
            txtServerIP = new TextBox();
            label1 = new Label();
            listMessages = new ListBox();
            btnSendFile = new Button();
            txtMessage = new TextBox();
            btnSend = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(775, 66);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(100, 23);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Conectar";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(775, 37);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(100, 23);
            txtServerIP.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(775, 19);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 5;
            label1.Text = "IP del servidor";
            // 
            // listMessages
            // 
            listMessages.BackColor = SystemColors.ActiveCaptionText;
            listMessages.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listMessages.ForeColor = Color.White;
            listMessages.FormattingEnabled = true;
            listMessages.Location = new Point(12, 73);
            listMessages.Name = "listMessages";
            listMessages.Size = new Size(724, 436);
            listMessages.TabIndex = 7;
            // 
            // btnSendFile
            // 
            btnSendFile.BackColor = Color.White;
            btnSendFile.BackgroundImage = Properties.Resources._1388902;
            btnSendFile.BackgroundImageLayout = ImageLayout.Zoom;
            btnSendFile.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSendFile.Location = new Point(862, 629);
            btnSendFile.Name = "btnSendFile";
            btnSendFile.Padding = new Padding(50);
            btnSendFile.Size = new Size(50, 50);
            btnSendFile.TabIndex = 10;
            btnSendFile.UseVisualStyleBackColor = false;
            btnSendFile.Click += btnSendFile_Click;
            // 
            // txtMessage
            // 
            txtMessage.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMessage.Location = new Point(12, 515);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(844, 166);
            txtMessage.TabIndex = 9;
            // 
            // btnSend
            // 
            btnSend.BackgroundImage = Properties.Resources.send_icon_md;
            btnSend.BackgroundImageLayout = ImageLayout.Stretch;
            btnSend.Font = new Font("Microsoft Sans Serif", 9F);
            btnSend.Location = new Point(862, 573);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(50, 50);
            btnSend.TabIndex = 8;
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Black;
            label2.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 19);
            label2.Name = "label2";
            label2.Size = new Size(167, 29);
            label2.TabIndex = 11;
            label2.Text = "WAZAGRAM™";
            // 
            // Cliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(920, 693);
            Controls.Add(label2);
            Controls.Add(btnSendFile);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            Controls.Add(listMessages);
            Controls.Add(label1);
            Controls.Add(txtServerIP);
            Controls.Add(btnConnect);
            Name = "Cliente";
            Text = "Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConnect;
        private TextBox txtServerIP;
        private Label label1;
        private ListBox listMessages;
        private Button btnSendFile;
        private TextBox txtMessage;
        private Button btnSend;
        private Label label2;
    }
}