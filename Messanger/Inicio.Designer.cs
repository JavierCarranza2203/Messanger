namespace Messanger
{
    partial class Inicio
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
            radServer = new RadioButton();
            radCliente = new RadioButton();
            label1 = new Label();
            btn_servidor = new Button();
            btn_cliente = new Button();
            panel1 = new Panel();
            pnl_servidor = new Panel();
            pnl_cliente = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // radServer
            // 
            radServer.AutoSize = true;
            radServer.Location = new Point(22, 107);
            radServer.Margin = new Padding(6);
            radServer.Name = "radServer";
            radServer.Size = new Size(133, 36);
            radServer.TabIndex = 0;
            radServer.TabStop = true;
            radServer.Text = "Servidor";
            radServer.UseVisualStyleBackColor = true;
            // 
            // radCliente
            // 
            radCliente.AutoSize = true;
            radCliente.Location = new Point(22, 179);
            radCliente.Margin = new Padding(6);
            radCliente.Name = "radCliente";
            radCliente.Size = new Size(120, 36);
            radCliente.TabIndex = 1;
            radCliente.TabStop = true;
            radCliente.Text = "Cliente";
            radCliente.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(24, 55);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(339, 55);
            label1.TabIndex = 2;
            label1.Text = "WAZAGRAM™";
            // 
            // btn_servidor
            // 
            btn_servidor.BackColor = Color.White;
            btn_servidor.Location = new Point(24, 166);
            btn_servidor.Margin = new Padding(6);
            btn_servidor.Name = "btn_servidor";
            btn_servidor.Size = new Size(565, 764);
            btn_servidor.TabIndex = 4;
            btn_servidor.Text = "SERVIDOR";
            btn_servidor.UseVisualStyleBackColor = false;
            btn_servidor.Click += btn_servidor_Click;
            // 
            // btn_cliente
            // 
            btn_cliente.BackColor = Color.White;
            btn_cliente.Location = new Point(594, 164);
            btn_cliente.Margin = new Padding(6);
            btn_cliente.Name = "btn_cliente";
            btn_cliente.Size = new Size(550, 764);
            btn_cliente.TabIndex = 5;
            btn_cliente.Text = "CLIENTE";
            btn_cliente.UseVisualStyleBackColor = false;
            btn_cliente.Click += btn_cliente_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Desktop;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btn_cliente);
            panel1.Controls.Add(pnl_servidor);
            panel1.Controls.Add(btn_servidor);
            panel1.Location = new Point(-2, -17);
            panel1.Margin = new Padding(6);
            panel1.Name = "panel1";
            panel1.Size = new Size(1168, 962);
            panel1.TabIndex = 6;
            // 
            // pnl_servidor
            // 
            pnl_servidor.BackColor = SystemColors.ControlLightLight;
            pnl_servidor.BackgroundImage = Properties.Resources.Server_Transparent_Images_Clip_Art;
            pnl_servidor.BackgroundImageLayout = ImageLayout.Zoom;
            pnl_servidor.Location = new Point(91, 279);
            pnl_servidor.Margin = new Padding(6);
            pnl_servidor.Name = "pnl_servidor";
            pnl_servidor.Size = new Size(412, 523);
            pnl_servidor.TabIndex = 8;
            pnl_servidor.Click += pnl_servidor_Click;
            // 
            // pnl_cliente
            // 
            pnl_cliente.BackColor = SystemColors.ControlLightLight;
            pnl_cliente.BackgroundImage = Properties.Resources.client_7;
            pnl_cliente.BackgroundImageLayout = ImageLayout.Zoom;
            pnl_cliente.Location = new Point(657, 262);
            pnl_cliente.Margin = new Padding(6);
            pnl_cliente.Name = "pnl_cliente";
            pnl_cliente.Size = new Size(435, 523);
            pnl_cliente.TabIndex = 7;
            pnl_cliente.Click += pnl_cliente_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1166, 939);
            ControlBox = false;
            Controls.Add(pnl_cliente);
            Controls.Add(panel1);
            Controls.Add(radServer);
            Controls.Add(radCliente);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Margin = new Padding(6);
            Name = "Inicio";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radServer;
        private RadioButton radCliente;
        private Label label1;
        private Button btn_servidor;
        private Button btn_cliente;
        private Panel panel1;
        private Panel pnl_cliente;
        private Panel pnl_servidor;
    }
}