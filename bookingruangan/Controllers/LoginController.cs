using System;
using System.Windows.Forms;
using bookingruangan.Models;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using bookingruangan.Helpers;

namespace bookingruangan.Controllers
{
    public class LoginController
    {
        private login _view;

        public LoginController(login view)
        {
            _view = view;
        }

        public string HandleLogin(string username, string password)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                // === 1. Cek admin (tidak pakai hash) ===
                string queryAdmin = "SELECT COUNT(*) FROM users WHERE username=@username AND password=@password";
                using (var cmd = new MySqlCommand(queryAdmin, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                        return "admin";  // Tetap return string "admin"
                }

                // === 2. Cek user (dengan hash SHA256) ===
                string hashedPassword = HashPassword(password);
                string queryUser = "SELECT nama_lengkap FROM anggota WHERE username=@username AND password=@password";
                using (var cmd = new MySqlCommand(queryUser, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string namaUser = result.ToString();
                        return namaUser; // ⬅️ Kembalikan nama lengkap user!
                    }
                }

                return null; // Login gagal
            }
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
    }
}
