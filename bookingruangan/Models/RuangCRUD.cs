using System;
using MySql.Data.MySqlClient;

namespace bookingruangan.Models
{
    public class RuangCRUD
    {
        public static int TambahRuang(Ruang ruang)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO mnjruang (nama, jenis, kapasitas) VALUES (@nama, @jenis, @kapasitas)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", ruang.Nama);
                    cmd.Parameters.AddWithValue("@jenis", ruang.Jenis);
                    cmd.Parameters.AddWithValue("@kapasitas", ruang.Kapasitas);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static void UpdateRuang(Ruang ruang)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE mnjruang SET nama=@nama, jenis=@jenis, kapasitas=@kapasitas WHERE id=@id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", ruang.Nama);
                    cmd.Parameters.AddWithValue("@jenis", ruang.Jenis);
                    cmd.Parameters.AddWithValue("@kapasitas", ruang.Kapasitas);
                    cmd.Parameters.AddWithValue("@id", ruang.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void HapusRuang(int id)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM mnjruang WHERE id=@id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
