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
            SuspendLayout();
            // 
            // listMessages
            // 
            listMessages.BackColor = SystemColors.ActiveCaptionText;
            listMessages.ForeColor = Color.White;
            listMessages.FormattingEnabled = true;
            listMessages.ItemHeight = 15;
            listMessages.Location = new Point(1, 0);
            listMessages.Name = "listMessages";
            listMessages.Size = new Size(443, 454);
            listMessages.TabIndex = 0;
            // 
            // btnStartServer
            // 
            btnStartServer.Font = new Font("Futura Hv BT", 9F);
            btnStartServer.Location = new Point(450, 12);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(338, 34);
            btnStartServer.TabIndex = 1;
            btnStartServer.Text = "Iniciar";
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Click += btnStartServer_Click;
            // 
            // btnSend
            // 
            btnSend.Font = new Font("Futura Hv BT", 9F);
            btnSend.Location = new Point(450, 323);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(338, 23);
            btnSend.TabIndex = 2;
            btnSend.Text = "Mandar";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(450, 228);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(338, 89);
            txtMessage.TabIndex = 3;
            // 
            // btnSendFile
            // 
            btnSendFile.BackColor = Color.White;
            btnSendFile.Font = new Font("Futura Hv BT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSendFile.Location = new Point(450, 143);
            btnSendFile.Name = "btnSendFile";
            btnSendFile.Size = new Size(127, 45);
            btnSendFile.TabIndex = 4;
            btnSendFile.Text = "Enviar archivo";
            btnSendFile.UseVisualStyleBackColor = false;
            btnSendFile.Click += btnSendFile_Click;
            // 
            // Servidor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
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
    }
}
