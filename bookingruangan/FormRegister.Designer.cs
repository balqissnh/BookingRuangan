namespace bookingruangan
{
    partial class FormRegister
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label lblNpm;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtNpm;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.LinkLabel lblLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblNama = new Label();
            lblNpm = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            txtNama = new TextBox();
            txtNpm = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnRegister = new Button();
            lblLogin = new LinkLabel();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Location = new Point(41, 139);
            lblNama.Margin = new Padding(4, 0, 4, 0);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(135, 25);
            lblNama.TabIndex = 0;
            lblNama.Text = "Nama Lengkap:";
            // 
            // lblNpm
            // 
            lblNpm.AutoSize = true;
            lblNpm.Location = new Point(41, 206);
            lblNpm.Margin = new Padding(4, 0, 4, 0);
            lblNpm.Name = "lblNpm";
            lblNpm.Size = new Size(55, 25);
            lblNpm.TabIndex = 2;
            lblNpm.Text = "NPM:";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(41, 272);
            lblUsername.Margin = new Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(95, 25);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(41, 339);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(91, 25);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password:";
            // 
            // txtNama
            // 
            txtNama.Location = new Point(212, 134);
            txtNama.Margin = new Padding(4, 5, 4, 5);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(284, 31);
            txtNama.TabIndex = 1;
            // 
            // txtNpm
            // 
            txtNpm.Location = new Point(212, 201);
            txtNpm.Margin = new Padding(4, 5, 4, 5);
            txtNpm.Name = "txtNpm";
            txtNpm.Size = new Size(284, 31);
            txtNpm.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(212, 267);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(284, 31);
            txtUsername.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(212, 334);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(284, 31);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(212, 485);
            btnRegister.Margin = new Padding(4, 5, 4, 5);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(286, 50);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(245, 556);
            lblLogin.Margin = new Padding(4, 0, 4, 0);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(216, 25);
            lblLogin.TabIndex = 9;
            lblLogin.TabStop = true;
            lblLogin.Text = "Sudah punya akun? Login";
            lblLogin.LinkClicked += lblLogin_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(281, 44);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(75, 25);
            label1.TabIndex = 10;
            label1.Text = "Register";
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(708, 644);
            Controls.Add(label1);
            Controls.Add(lblNama);
            Controls.Add(txtNama);
            Controls.Add(lblNpm);
            Controls.Add(txtNpm);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnRegister);
            Controls.Add(lblLogin);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form Registrasi";
            Load += FormRegister_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
    }
}
