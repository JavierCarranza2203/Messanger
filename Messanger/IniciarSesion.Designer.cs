namespace Messanger
{
    partial class IniciarSesion
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
            label2 = new Label();
            txtUsuario = new TextBox();
            txtContrasenia = new TextBox();
            label3 = new Label();
            btnIniciarSesion = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Black;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 28);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(339, 55);
            label1.TabIndex = 3;
            label1.Text = "WAZAGRAM™";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(45, 106);
            label2.Name = "label2";
            label2.Size = new Size(135, 45);
            label2.TabIndex = 4;
            label2.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 12F);
            txtUsuario.Location = new Point(45, 154);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(633, 50);
            txtUsuario.TabIndex = 5;
            // 
            // txtContrasenia
            // 
            txtContrasenia.Font = new Font("Segoe UI", 12F);
            txtContrasenia.Location = new Point(45, 274);
            txtContrasenia.Name = "txtContrasenia";
            txtContrasenia.Size = new Size(633, 50);
            txtContrasenia.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(45, 226);
            label3.Name = "label3";
            label3.Size = new Size(187, 45);
            label3.TabIndex = 6;
            label3.Text = "Contraseña:";
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.BackColor = Color.White;
            btnIniciarSesion.FlatStyle = FlatStyle.Flat;
            btnIniciarSesion.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnIniciarSesion.ForeColor = SystemColors.ControlText;
            btnIniciarSesion.Location = new Point(45, 470);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(633, 85);
            btnIniciarSesion.TabIndex = 8;
            btnIniciarSesion.Text = "Iniciar sesión";
            btnIniciarSesion.UseVisualStyleBackColor = false;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Cursor = Cursors.Hand;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Underline);
            label4.Location = new Point(45, 339);
            label4.Name = "label4";
            label4.Size = new Size(580, 37);
            label4.TabIndex = 9;
            label4.Text = "¿No tiene una cuenta u olvidó sus credenciales?";
            // 
            // IniciarSesion
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(733, 585);
            Controls.Add(label4);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtContrasenia);
            Controls.Add(label3);
            Controls.Add(txtUsuario);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlLightLight;
            Name = "IniciarSesion";
            Text = "IniciarSesion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsuario;
        private TextBox txtContrasenia;
        private Label label3;
        private Button btnIniciarSesion;
        private Label label4;
    }
}