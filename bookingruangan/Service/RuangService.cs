using System;
using System.Collections.Generic;
using bookingruangan.Helpers;
using bookingruangan.Models;
using MySql.Data.MySqlClient;

namespace bookingruangan.Service
{
    public class RuangService
    {
        public static int TambahRuang(RuangModel ruang)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO mnjruang (nama, jenis, kapasitas, status) VALUES (@nama, @jenis, @kapasitas, @status)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", ruang.Nama);
                    cmd.Parameters.AddWithValue("@jenis", ruang.Jenis);
                    cmd.Parameters.AddWithValue("@kapasitas", ruang.Kapasitas);
                    cmd.Parameters.AddWithValue("@status", ruang.Status);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static void UpdateRuang(RuangModel ruang)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE mnjruang SET nama=@nama, jenis=@jenis, kapasitas=@kapasitas, status=@status WHERE id=@id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", ruang.Nama);
                    cmd.Parameters.AddWithValue("@jenis", ruang.Jenis);
                    cmd.Parameters.AddWithValue("@kapasitas", ruang.Kapasitas);
                    cmd.Parameters.AddWithValue("@status", ruang.Status);
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

        public static List<RuangModel> GetAllRuangan()
        {
            var list = new List<RuangModel>();

            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT id, nama, jenis, kapasitas, status FROM mnjruang";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RuangModel
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nama = reader["nama"].ToString(),
                            Jenis = reader["jenis"].ToString(),
                            Kapasitas = Convert.ToInt32(reader["kapasitas"]),
                            Status = reader["status"].ToString()
                        });
                    }
                }
            }

            return list;
        }
    }
}
