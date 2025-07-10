using bookingruangan.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;

namespace bookingruangan.Services
{
    public class LoginService
    {
        public static string HashPassword(string password)
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

        public static string CekLogin(string username, string password)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                // Cek Admin (tanpa hash)
                string queryAdmin = "SELECT COUNT(*) FROM users WHERE username=@username AND password=@password";
                using (var cmd = new MySqlCommand(queryAdmin, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        return "admin";
                }

                // Cek User (dengan hash)
                string hashed = HashPassword(password);
                string queryUser = "SELECT nama_lengkap FROM anggota WHERE username=@username AND password=@password";
                using (var cmd = new MySqlCommand(queryUser, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashed);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        return result.ToString(); // nama lengkap user
                }

                return null;
            }
        }
    }
}
