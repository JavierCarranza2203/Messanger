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
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(157, 15);
            label1.TabIndex = 2;
            label1.Text = "¿Que rol desea desempeñar?";
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
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(170, 110);
            Controls.Add(btnAceptar);
            Controls.Add(label1);
            Controls.Add(radCliente);
            Controls.Add(radServer);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Inicio";
            Text = "Inicio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radServer;
        private RadioButton radCliente;
        private Label label1;
        private Button btnAceptar;
    }
}