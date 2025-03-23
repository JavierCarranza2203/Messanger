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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 8;
            label1.Text = "IP del servidor";
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(12, 27);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(100, 23);
            txtServerIP.TabIndex = 7;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(12, 56);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(100, 23);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "Conectar";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // InputForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(142, 153);
            Controls.Add(label1);
            Controls.Add(txtServerIP);
            Controls.Add(btnConnect);
            Name = "InputForm";
            Text = "InputForm";
            Load += InputForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtServerIP;
        private Button btnConnect;
    }
}