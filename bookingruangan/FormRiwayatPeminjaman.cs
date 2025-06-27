using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bookingruangan
{
    public partial class FormRiwayatPeminjaman : Form
    {
        private readonly string _namaUser;

        public FormRiwayatPeminjaman(string namaUser)
        {
            InitializeComponent();
            _namaUser = namaUser;
        }

        private void FormRiwayatPeminjaman_Load(object sender, EventArgs e)
        {
            label1.Text = "Riwayat Peminjaman - " + _namaUser;

            // ✅ Tambahkan kolom untuk listView
            listView1.Columns.Clear();
            listView1.Columns.Add("Tanggal", 100);
            listView1.Columns.Add("Kelas", 100);
            listView1.Columns.Add("Ruangan", 120);
            listView1.Columns.Add("Jam Mulai", 100);
            listView1.Columns.Add("Jam Selesai", 100);
            listView1.Columns.Add("Status", 100);

            LoadRiwayat();
        }

        private void LoadRiwayat()
        {
            listView1.Items.Clear();
            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT tanggal, kelas_peminjam, nama_ruang, jam_mulai, jam_selesai, status 
                    FROM peminjaman 
                    WHERE nama_peminjam = @nama 
                    ORDER BY tanggal DESC";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", _namaUser);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new ListViewItem(Convert.ToDateTime(reader["tanggal"]).ToString("yyyy-MM-dd"));
                            item.SubItems.Add(reader["kelas_peminjam"].ToString());
                            item.SubItems.Add(reader["nama_ruang"].ToString());
                            item.SubItems.Add(reader["jam_mulai"].ToString());
                            item.SubItems.Add(reader["jam_selesai"].ToString());
                            item.SubItems.Add(reader["status"].ToString());
                            listView1.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void btnKembalikan_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih data peminjaman yang ingin dikembalikan.");
                return;
            }

            string tanggal = listView1.SelectedItems[0].SubItems[0].Text;
            string ruang = listView1.SelectedItems[0].SubItems[2].Text;
            string jamMulai = listView1.SelectedItems[0].SubItems[3].Text;
            string status = listView1.SelectedItems[0].SubItems[5].Text;

            if (status == "dikembalikan")
            {
                MessageBox.Show("Ruangan ini sudah dikembalikan sebelumnya.");
                return;
            }

            var confirm = MessageBox.Show("Apakah Anda yakin ingin mengembalikan ruangan ini?",
                            "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No)
                return;

            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                string queryUpdate = @"UPDATE peminjaman 
                                       SET status='dikembalikan' 
                                       WHERE nama_peminjam=@nama 
                                       AND nama_ruang=@ruang 
                                       AND tanggal=@tanggal 
                                       AND jam_mulai=@jam";

                using (var cmd = new MySqlCommand(queryUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", _namaUser);
                    cmd.Parameters.AddWithValue("@ruang", ruang);
                    cmd.Parameters.AddWithValue("@tanggal", tanggal);
                    cmd.Parameters.AddWithValue("@jam", jamMulai);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        string updateRuang = "UPDATE mnjruang SET status='tersedia' WHERE nama = @ruang";
                        using (var cmdRuang = new MySqlCommand(updateRuang, conn))
                        {
                            cmdRuang.Parameters.AddWithValue("@ruang", ruang);
                            cmdRuang.ExecuteNonQuery();
                        }

                        MessageBox.Show("Ruangan berhasil dikembalikan.");
                        LoadRiwayat();
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan atau sudah dikembalikan.");
                    }
                }
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormUserDashboard(_namaUser).Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tidak digunakan
        }
    }
}
