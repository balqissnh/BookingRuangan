using System;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace bookingruangan
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                MessageBox.Show("Login Berhasil");
                this.Hide();
                sewa form1 = new sewa(); // Ganti dengan 'sewa' kalau form sewa
                form1.Show();
            }
            else
            {
                MessageBox.Show("Login Gagal");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
