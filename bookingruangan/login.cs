using System;
using System.Windows.Forms;
using bookingruangan.Controllers;

namespace bookingruangan
{
    public partial class login : Form
    {
        private LoginController _controller;

        public login()
        {
            InitializeComponent();
            _controller = new LoginController(this);
        }

        // Optional, tidak wajib diisi
        private void Form1_Load(object sender, EventArgs e)
        {
            // Boleh dikosongkan
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string result = _controller.HandleLogin(username, password); // Bisa "admin", atau nama user, atau null

            if (result == "admin")
            {
                MessageBox.Show("Login Admin Berhasil");
                this.Hide();
                new sewa().Show(); // Form Admin
            }
            else if (!string.IsNullOrEmpty(result)) // berarti user berhasil login
            {
                MessageBox.Show("Login User Berhasil");
                this.Hide();
                new FormUserDashboard(result).Show(); // Kirim nama user
            }
            else
            {
                MessageBox.Show("Login Gagal, cek username atau password");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Dikosongkan saja kalau tidak digunakan
        }
    }
}
