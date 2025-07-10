using System;
using System.Collections.Generic;
using bookingruangan.Helpers;
using MySql.Data.MySqlClient;

namespace bookingruangan.Models
{
    public class RiwayatPeminjamanModel
    {
        public DateTime Tanggal { get; set; }
        public string Kelas { get; set; }
        public string Ruangan { get; set; }
        public string JamMulai { get; set; }
        public string JamSelesai { get; set; }
        public string Status { get; set; }

        public static List<RiwayatPeminjamanModel> AmbilRiwayat(string namaUser)
        {
            var riwayat = new List<RiwayatPeminjamanModel>();
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT tanggal, kelas_peminjam, nama_ruang, jam_mulai, jam_selesai, status 
                                 FROM peminjaman WHERE nama_peminjam = @nama ORDER BY tanggal DESC";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", namaUser);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            riwayat.Add(new RiwayatPeminjamanModel
                            {
                                Tanggal = Convert.ToDateTime(reader["tanggal"]),
                                Kelas = reader["kelas_peminjam"].ToString(),
                                Ruangan = reader["nama_ruang"].ToString(),
                                JamMulai = reader["jam_mulai"].ToString(),
                                JamSelesai = reader["jam_selesai"].ToString(),
                                Status = reader["status"].ToString()
                            });
                        }
                    }
                }
            }
            return riwayat;
        }

        public static bool KembalikanRuangan(string namaUser, string tanggal, string ruang, string jamMulai)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string queryUpdate = @"UPDATE peminjaman SET status='dikembalikan' 
                                       WHERE nama_peminjam=@nama AND nama_ruang=@ruang 
                                       AND tanggal=@tanggal AND jam_mulai=@jam";

                using (var cmd = new MySqlCommand(queryUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", namaUser);
                    cmd.Parameters.AddWithValue("@ruang", ruang);
                    cmd.Parameters.AddWithValue("@tanggal", tanggal);
                    cmd.Parameters.AddWithValue("@jam", jamMulai);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        // Kembalikan status ruangan
                        string updateRuang = "UPDATE mnjruang SET status='tersedia' WHERE nama = @ruang";
                        using (var cmdRuang = new MySqlCommand(updateRuang, conn))
                        {
                            cmdRuang.Parameters.AddWithValue("@ruang", ruang);
                            cmdRuang.ExecuteNonQuery();
                        }

                        return true;
                    }
                }
            }
            return false;
        }
    }
}
