using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bookingruangan
{
    public partial class FormUserDashboard : Form
    {
        private string _namaUser;

        public FormUserDashboard(string namaUser)
        {
            InitializeComponent();
            _namaUser = namaUser;

            // Atur ukuran form
            this.Width = 600;
            this.Height = 500;
        }

        private void FormUserDashboard_Load(object sender, EventArgs e)
        {
            label1.Text = "Selamat datang, " + _namaUser + "!";
            LoadDataRuangan();
        }

        private void LoadDataRuangan()
        {
            listView1.Items.Clear();
            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                // Menampilkan ruangan yang belum dipinjam (berdasarkan data di tabel peminjaman)
                string query = @"
                    SELECT id, nama, jenis, kapasitas 
                    FROM mnjruang 
                    WHERE nama NOT IN (
                        SELECT nama_ruang 
                        FROM peminjaman 
                        WHERE status = 'dipinjam'
                    )";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader["id"].ToString());
                        item.SubItems.Add(reader["nama"].ToString());
                        item.SubItems.Add(reader["jenis"].ToString());
                        item.SubItems.Add(reader["kapasitas"].ToString());
                        listView1.Items.Add(item);
                    }
                }
            }
        }

        private void btnPinjam_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih ruangan yang ingin dipinjam.");
                return;
            }

            string namaRuangan = listView1.SelectedItems[0].SubItems[1].Text;
            string jamMulai = dtpMulai.Value.ToString("HH:mm");
            string jamSelesai = dtpSelesai.Value.ToString("HH:mm");
            string kelasPeminjam = txtKelas.Text.Trim();
            string tanggalPinjam = dtpTanggal.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrWhiteSpace(kelasPeminjam))
            {
                MessageBox.Show("Isi nama kelas peminjam terlebih dahulu.");
                return;
            }

            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                // Simpan peminjaman ke tabel, dengan status 'dipinjam'
                string query = @"INSERT INTO peminjaman 
                                (nama_peminjam, kelas_peminjam, tanggal, nama_ruang, jam_mulai, jam_selesai, status) 
                                VALUES 
                                (@nama, @kelas, @tanggal, @ruang, @mulai, @selesai, 'dipinjam')";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", _namaUser);
                    cmd.Parameters.AddWithValue("@kelas", kelasPeminjam);
                    cmd.Parameters.AddWithValue("@tanggal", tanggalPinjam);
                    cmd.Parameters.AddWithValue("@ruang", namaRuangan);
                    cmd.Parameters.AddWithValue("@mulai", jamMulai);
                    cmd.Parameters.AddWithValue("@selesai", jamSelesai);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Gagal menyimpan peminjaman: " + ex.Message);
                        return;
                    }
                }

                MessageBox.Show("Peminjaman berhasil!");
                LoadDataRuangan(); // Refresh agar ruangan yang dipinjam tidak muncul lagi
            }
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormRiwayatPeminjaman(_namaUser).Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }
    }
}
