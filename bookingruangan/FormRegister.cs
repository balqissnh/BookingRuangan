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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            _controller.HandleRegister();
        }

        // Metode tambahan untuk diakses controller
        public string GetNama() => txtNama.Text.Trim();
        public string GetNpm() => txtNpm.Text.Trim();
        public string GetUsername() => txtUsername.Text.Trim();
        public string GetPassword() => txtPassword.Text;

        public void ShowMessage(string msg) => MessageBox.Show(msg);

        public void RedirectToLogin()
        {
            this.Hide();
            new login().Show();
        }

        private void lblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            // Bisa kosong jika tidak ada proses saat form load
        }

    }
}
