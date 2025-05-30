using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace bookingruangan
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string namaLengkap = txtNama.Text.Trim();
            string npm = txtNpm.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (namaLengkap == "" || npm == "" || username == "" || password == "")
            {
                MessageBox.Show("Semua kolom harus diisi!");
                return;
            }

            string hashedPassword = HashPassword(password);

            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO anggota (nama_lengkap, npm, username, password) VALUES (@nama, @npm, @username, @password)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", namaLengkap);
                    cmd.Parameters.AddWithValue("@npm", npm);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registrasi berhasil. Silakan login.");
                        this.Hide();
                        new login().Show();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Registrasi gagal: " + ex.Message);
                    }
                }
            }
        }

        private void lblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
