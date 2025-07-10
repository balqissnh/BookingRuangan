using System.Security.Cryptography;
using System.Text;
using bookingruangan.Models;
using bookingruangan.Helpers;
using MySql.Data.MySqlClient;

namespace bookingruangan.Services
{
    public class RegisterService
    {
        public static bool Register(RegisterModel user)
        {
            string hashedPassword = HashPassword(user.Password);

            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO anggota (nama_lengkap, npm, username, password)
                                 VALUES (@nama, @npm, @username, @password)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", user.NamaLengkap);
                    cmd.Parameters.AddWithValue("@npm", user.NPM);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (MySqlException)
                    {
                        return false;
                    }
                }
            }
        }

        private static string HashPassword(string password)
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
