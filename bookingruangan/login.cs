using System;
using System.Windows.Forms;
using bookingruangan.Controllers;

namespace bookingruangan.Views
{
    public partial class login : Form
    {
        private LoginController _controller;

        public login()
        {
            InitializeComponent();
            _controller = new LoginController(this); // Controller terhubung dengan View
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Delegasi ke controller
            _controller.HandleLogin(username, password);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
