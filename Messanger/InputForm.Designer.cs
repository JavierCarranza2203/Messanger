namespace Messanger
{
    partial class InputForm
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
            label1 = new Label();
            txtServerIP = new TextBox();
            btnConnect = new Button();
            label2 = new Label();
            txtDbUser = new TextBox();
            label3 = new Label();
            txtDbPassword = new TextBox();
            label4 = new Label();
            txtDbPort = new TextBox();
            label5 = new Label();
            txtDbName = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(36, 19);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(165, 32);
            label1.TabIndex = 8;
            label1.Text = "IP del servidor";
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(36, 58);
            txtServerIP.Margin = new Padding(6);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(259, 39);
            txtServerIP.TabIndex = 7;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(343, 348);
            btnConnect.Margin = new Padding(6);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(280, 49);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "Guardar";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(36, 122);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(191, 32);
            label2.TabIndex = 10;
            label2.Text = "Usuario de la BD";
            // 
            // txtDbUser
            // 
            txtDbUser.Location = new Point(36, 161);
            txtDbUser.Margin = new Padding(6);
            txtDbUser.Name = "txtDbUser";
            txtDbUser.Size = new Size(259, 39);
            txtDbUser.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(329, 122);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(231, 32);
            label3.TabIndex = 12;
            label3.Text = "Contraseña de la BD";
            // 
            // txtDbPassword
            // 
            txtDbPassword.Location = new Point(343, 161);
            txtDbPassword.Margin = new Padding(6);
            txtDbPassword.Name = "txtDbPassword";
            txtDbPassword.Size = new Size(280, 39);
            txtDbPassword.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(343, 19);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(181, 32);
            label4.TabIndex = 14;
            label4.Text = "Puerto de la BD";
            // 
            // txtDbPort
            // 
            txtDbPort.Location = new Point(343, 58);
            txtDbPort.Margin = new Padding(6);
            txtDbPort.Name = "txtDbPort";
            txtDbPort.Size = new Size(280, 39);
            txtDbPort.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(36, 223);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(199, 32);
            label5.TabIndex = 16;
            label5.Text = "Nombre de la BD";
            // 
            // txtDbName
            // 
            txtDbName.Location = new Point(36, 262);
            txtDbName.Margin = new Padding(6);
            txtDbName.Name = "txtDbName";
            txtDbName.Size = new Size(587, 39);
            txtDbName.TabIndex = 15;
            // 
            // button1
            // 
            button1.Location = new Point(36, 348);
            button1.Margin = new Padding(6);
            button1.Name = "button1";
            button1.Size = new Size(280, 49);
            button1.TabIndex = 17;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            // 
            // InputForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(669, 421);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(txtDbName);
            Controls.Add(label4);
            Controls.Add(txtDbPort);
            Controls.Add(label3);
            Controls.Add(txtDbPassword);
            Controls.Add(label2);
            Controls.Add(txtDbUser);
            Controls.Add(label1);
            Controls.Add(txtServerIP);
            Controls.Add(btnConnect);
            Margin = new Padding(6);
            Name = "InputForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InputForm";
            Load += InputForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtServerIP;
        private Button btnConnect;
        private Label label2;
        private TextBox txtDbUser;
        private Label label3;
        private TextBox txtDbPassword;
        private Label label4;
        private TextBox txtDbPort;
        private Label label5;
        private TextBox txtDbName;
        private Button button1;
    }
}