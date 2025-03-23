namespace Messanger
{
    partial class frmIniciarSesion
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
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            btnCrearCuenta = new Button();
            btnIniciarSesion = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(63, 131);
            label1.Name = "label1";
            label1.Size = new Size(126, 41);
            label1.TabIndex = 0;
            label1.Text = "Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(200, 36);
            label3.Name = "label3";
            label3.Size = new Size(412, 45);
            label3.TabIndex = 2;
            label3.Text = "👻👻 WAZAGRAM 👻👻";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 11F);
            textBox1.Location = new Point(64, 190);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(690, 47);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 11F);
            textBox2.Location = new Point(64, 330);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(690, 47);
            textBox2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(63, 280);
            label2.Name = "label2";
            label2.Size = new Size(175, 41);
            label2.TabIndex = 4;
            label2.Text = "Contraseña:";
            // 
            // btnCrearCuenta
            // 
            btnCrearCuenta.Location = new Point(63, 442);
            btnCrearCuenta.Name = "btnCrearCuenta";
            btnCrearCuenta.Size = new Size(331, 46);
            btnCrearCuenta.TabIndex = 6;
            btnCrearCuenta.Text = "Crear cuenta";
            btnCrearCuenta.UseVisualStyleBackColor = true;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(423, 442);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(331, 46);
            btnIniciarSesion.TabIndex = 7;
            btnIniciarSesion.Text = "Iniciar sesión";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // frmIniciarSesion
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 537);
            Controls.Add(btnIniciarSesion);
            Controls.Add(btnCrearCuenta);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "frmIniciarSesion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar Sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Button btnCrearCuenta;
        private Button btnIniciarSesion;
    }
}