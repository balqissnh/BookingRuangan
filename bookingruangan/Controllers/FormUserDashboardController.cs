using System.Collections.Generic;
using bookingruangan.Helpers;
using bookingruangan.Models;
using MySql.Data.MySqlClient;

namespace bookingruangan.Controllers
{
    public class FormUserDashboardController
    {
        private readonly string _namaUser;

        public FormUserDashboardController(string namaUser)
        {
            _namaUser = namaUser;
        }

        public List<RuanganModel> GetRuanganTersedia()
        {
            var list = new List<RuanganModel>();
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT id, nama, jenis, kapasitas FROM mnjruang WHERE status = 'tersedia'";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RuanganModel
                        {
                            Id = reader.GetInt32("id"),
                            Nama = reader.GetString("nama"),
                            Jenis = reader.GetString("jenis"),
                            Kapasitas = reader.GetInt32("kapasitas")
                        });
                    }
                }
            }
            return list;
        }

        public bool PinjamRuangan(string kelas, string tanggal, string ruang, string mulai, string selesai)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                var trx = conn.BeginTransaction();

                try
                {
                    string insert = @"INSERT INTO peminjaman 
                                      (nama_peminjam, kelas_peminjam, tanggal, nama_ruang, jam_mulai, jam_selesai, status) 
                                      VALUES 
                                      (@nama, @kelas, @tanggal, @ruang, @mulai, @selesai, 'dipinjam')";

                    using (var cmd = new MySqlCommand(insert, conn, trx))
                    {
                        cmd.Parameters.AddWithValue("@nama", _namaUser);
                        cmd.Parameters.AddWithValue("@kelas", kelas);
                        cmd.Parameters.AddWithValue("@tanggal", tanggal);
                        cmd.Parameters.AddWithValue("@ruang", ruang);
                        cmd.Parameters.AddWithValue("@mulai", mulai);
                        cmd.Parameters.AddWithValue("@selesai", selesai);
                        cmd.ExecuteNonQuery();
                    }

                    string update = "UPDATE mnjruang SET status = 'dipinjam' WHERE nama = @ruang";
                    using (var cmdUpdate = new MySqlCommand(update, conn, trx))
                    {
                        cmdUpdate.Parameters.AddWithValue("@ruang", ruang);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    trx.Commit();
                    return true;
                }
                catch
                {
                    trx.Rollback();
                    return false;
                }
            }
        }
    }
}
