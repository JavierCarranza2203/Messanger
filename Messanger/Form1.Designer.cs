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
            SuspendLayout();
            // 
            // listMessages
            // 
            listMessages.FormattingEnabled = true;
            listMessages.ItemHeight = 15;
            listMessages.Location = new Point(1, 0);
            listMessages.Name = "listMessages";
            listMessages.Size = new Size(443, 454);
            listMessages.TabIndex = 0;
            // 
            // btnStartServer
            // 
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
            // Servidor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
