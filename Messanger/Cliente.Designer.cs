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
            listMessages = new ListBox();
            btnSend = new Button();
            txtServerIP = new TextBox();
            txtMessage = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(416, 56);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(100, 23);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Conectar";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // listMessages
            // 
            listMessages.FormattingEnabled = true;
            listMessages.ItemHeight = 15;
            listMessages.Location = new Point(-3, -2);
            listMessages.Name = "listMessages";
            listMessages.Size = new Size(413, 454);
            listMessages.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(416, 297);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(372, 23);
            btnSend.TabIndex = 2;
            btnSend.Text = "Enviar";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(416, 27);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(100, 23);
            txtServerIP.TabIndex = 3;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(416, 180);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(372, 111);
            txtMessage.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(416, 9);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 5;
            label1.Text = "IP del servidor";
            // 
            // Cliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(txtMessage);
            Controls.Add(txtServerIP);
            Controls.Add(btnSend);
            Controls.Add(listMessages);
            Controls.Add(btnConnect);
            Name = "Cliente";
            Text = "Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConnect;
        private ListBox listMessages;
        private Button btnSend;
        private TextBox txtServerIP;
        private TextBox txtMessage;
        private Label label1;
    }
}