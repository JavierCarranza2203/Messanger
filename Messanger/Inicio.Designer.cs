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
            btnAceptar = new Button();
            btn_servidor = new Button();
            btn_cliente = new Button();
            panel1 = new Panel();
            pnl_servidor = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // radServer
            // 
            radServer.AutoSize = true;
            radServer.Location = new Point(12, 50);
            radServer.Name = "radServer";
            radServer.Size = new Size(68, 19);
            radServer.TabIndex = 0;
            radServer.TabStop = true;
            radServer.Text = "Servidor";
            radServer.UseVisualStyleBackColor = true;
            // 
            // radCliente
            // 
            radCliente.AutoSize = true;
            radCliente.Location = new Point(12, 84);
            radCliente.Name = "radCliente";
            radCliente.Size = new Size(62, 19);
            radCliente.TabIndex = 1;
            radCliente.TabStop = true;
            radCliente.Text = "Cliente";
            radCliente.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Futura Hv BT", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(13, 26);
            label1.Name = "label1";
            label1.Size = new Size(178, 29);
            label1.TabIndex = 2;
            label1.Text = "WAZAGRAM™";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(106, 61);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(52, 26);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "-->";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btn_servidor
            // 
            btn_servidor.BackColor = Color.White;
            btn_servidor.Location = new Point(13, 78);
            btn_servidor.Name = "btn_servidor";
            btn_servidor.Size = new Size(304, 358);
            btn_servidor.TabIndex = 4;
            btn_servidor.Text = "SERVIDOR";
            btn_servidor.UseVisualStyleBackColor = false;
            btn_servidor.Click += btn_servidor_Click;
            // 
            // btn_cliente
            // 
            btn_cliente.BackColor = Color.White;
            btn_cliente.Location = new Point(320, 77);
            btn_cliente.Name = "btn_cliente";
            btn_cliente.Size = new Size(296, 358);
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
            panel1.Location = new Point(-1, -8);
            panel1.Name = "panel1";
            panel1.Size = new Size(630, 452);
            panel1.TabIndex = 6;
            // 
            // pnl_servidor
            // 
            pnl_servidor.BackColor = SystemColors.ControlLightLight;
            pnl_servidor.BackgroundImage = Properties.Resources.Server_Transparent_Images_Clip_Art;
            pnl_servidor.BackgroundImageLayout = ImageLayout.Zoom;
            pnl_servidor.Location = new Point(49, 131);
            pnl_servidor.Name = "pnl_servidor";
            pnl_servidor.Size = new Size(222, 245);
            pnl_servidor.TabIndex = 8;
            pnl_servidor.Click += pnl_servidor_Click;
            pnl_servidor.Paint += pnl_servidor_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.BackgroundImage = Properties.Resources.client_7;
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.Location = new Point(354, 123);
            panel2.Name = "panel2";
            panel2.Size = new Size(234, 245);
            panel2.TabIndex = 7;
            panel2.Click += panel2_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(628, 440);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnAceptar);
            Controls.Add(radServer);
            Controls.Add(radCliente);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
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
        private Button btnAceptar;
        private Button btn_servidor;
        private Button btn_cliente;
        private Panel panel1;
        private Panel panel2;
        private Panel pnl_servidor;
    }
}