using System;
using System.Windows.Forms;
using bookingruangan.Controllers;

namespace bookingruangan
{
    public partial class FormRegister : Form
    {
        private RegisterController _controller;

        public FormRegister()
        {
            InitializeComponent();
            _controller = new RegisterController(this);
        }

        // Dipanggil saat tombol Register ditekan
        private void btnRegister_Click(object sender, EventArgs e)
        {
            _controller.HandleRegister();
        }

        // Jika user klik link "Login"
        private void lblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        // Getter untuk Controller
        public string GetNama() => txtNama.Text.Trim();
        public string GetNpm() => txtNpm.Text.Trim();
        public string GetUsername() => txtUsername.Text.Trim();
        public string GetPassword() => txtPassword.Text.Trim();

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void RedirectToLogin()
        {
            this.Hide();
            new login().Show();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            // Bisa dikosongkan
        }
    }
}
