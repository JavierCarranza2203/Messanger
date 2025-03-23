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
            listMessages = new ListBox();
            btnSendFile = new Button();
            txtMessage = new TextBox();
            btnSend = new Button();
            label2 = new Label();
            txtServerIP = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // listMessages
            // 
            listMessages.BackColor = SystemColors.ActiveCaptionText;
            listMessages.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listMessages.ForeColor = Color.White;
            listMessages.FormattingEnabled = true;
            listMessages.ItemHeight = 30;
            listMessages.Location = new Point(22, 156);
            listMessages.Margin = new Padding(6, 6, 6, 6);
            listMessages.Name = "listMessages";
            listMessages.Size = new Size(1341, 904);
            listMessages.TabIndex = 7;
            // 
            // btnSendFile
            // 
            btnSendFile.BackColor = Color.White;
            btnSendFile.BackgroundImage = Properties.Resources._1388902;
            btnSendFile.BackgroundImageLayout = ImageLayout.Zoom;
            btnSendFile.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSendFile.Location = new Point(1601, 1342);
            btnSendFile.Margin = new Padding(6, 6, 6, 6);
            btnSendFile.Name = "btnSendFile";
            btnSendFile.Padding = new Padding(93, 107, 93, 107);
            btnSendFile.Size = new Size(93, 107);
            btnSendFile.TabIndex = 10;
            btnSendFile.UseVisualStyleBackColor = false;
            btnSendFile.Click += btnSendFile_Click;
            // 
            // txtMessage
            // 
            txtMessage.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMessage.Location = new Point(22, 1099);
            txtMessage.Margin = new Padding(6, 6, 6, 6);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(1564, 350);
            txtMessage.TabIndex = 9;
            // 
            // btnSend
            // 
            btnSend.BackgroundImage = Properties.Resources.send_icon_md;
            btnSend.BackgroundImageLayout = ImageLayout.Stretch;
            btnSend.Font = new Font("Microsoft Sans Serif", 9F);
            btnSend.Location = new Point(1601, 1222);
            btnSend.Margin = new Padding(6, 6, 6, 6);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(93, 107);
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
            label2.Location = new Point(22, 41);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(339, 55);
            label2.TabIndex = 11;
            label2.Text = "WAZAGRAM™";
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(1439, 79);
            txtServerIP.Margin = new Padding(6, 6, 6, 6);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.ReadOnly = true;
            txtServerIP.Size = new Size(182, 39);
            txtServerIP.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(1439, 41);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(165, 32);
            label1.TabIndex = 5;
            label1.Text = "IP del servidor";
            // 
            // Cliente
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1709, 1478);
            Controls.Add(label2);
            Controls.Add(btnSendFile);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            Controls.Add(listMessages);
            Controls.Add(label1);
            Controls.Add(txtServerIP);
            Margin = new Padding(6, 6, 6, 6);
            Name = "Cliente";
            Text = "Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listMessages;
        private Button btnSendFile;
        private TextBox txtMessage;
        private Button btnSend;
        private Label label2;
        private TextBox txtServerIP;
        private Label label1;
    }
}