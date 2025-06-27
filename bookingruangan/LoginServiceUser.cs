using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

namespace bookingruangan.Models
{
    public class LoginServiceUser
    {
        public static bool Authenticate(string username, string password)
        {
            string hashedPassword = HashPassword(password);

            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM anggota WHERE username=@username AND password=@password";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
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