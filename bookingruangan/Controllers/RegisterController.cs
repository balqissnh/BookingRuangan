using bookingruangan.Helpers;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace bookingruangan.Controllers
{
    public class RegisterController
    {
        private FormRegister _form;

        public RegisterController(FormRegister form)
        {
            _form = form;
        }

        public void HandleRegister()
        {
            string namaLengkap = _form.GetNama();
            string npm = _form.GetNpm();
            string username = _form.GetUsername();
            string password = _form.GetPassword();

            if (string.IsNullOrWhiteSpace(namaLengkap) ||
                string.IsNullOrWhiteSpace(npm) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                _form.ShowMessage("Semua kolom harus diisi!");
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
                        _form.ShowMessage("Registrasi berhasil. Silakan login.");
                        _form.RedirectToLogin();
                    }
                    catch (MySqlException ex)
                    {
                        _form.ShowMessage("Registrasi gagal: " + ex.Message);
                    }
                }
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
