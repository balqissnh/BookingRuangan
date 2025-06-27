using System;
using System.Windows.Forms;
using bookingruangan.Controllers;
using Microsoft.Win32;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            // Boleh dikosongkan
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string result = _controller.HandleLogin(username, password);

            if (result == "admin")
            {
                MessageBox.Show("Login Admin Berhasil");
                this.Hide();
                new sewa().Show();
            }
            else if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Login User Berhasil");
                this.Hide();
                new FormUserDashboard(result).Show();
            }
            else
            {
                MessageBox.Show("Login Gagal, cek username atau password");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Tidak digunakan
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new FormRegister().Show(); // Ganti dengan nama form register milikmu
        }
    }
}
