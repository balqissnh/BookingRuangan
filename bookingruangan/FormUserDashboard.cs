using System;
using System.Windows.Forms;
using bookingruangan.Controllers;
using bookingruangan.Models;

namespace bookingruangan
{
    public partial class FormUserDashboard : Form
    {
        private readonly string _namaUser;
        private readonly FormUserDashboardController _controller;

        public FormUserDashboard(string namaUser)
        {
            InitializeComponent();
            _namaUser = namaUser;
            _controller = new FormUserDashboardController(_namaUser);

            this.Width = 700;
            this.Height = 700;
        }

        private void FormUserDashboard_Load(object sender, EventArgs e)
        {
            label1.Text = "Selamat datang, " + _namaUser + "!";

            listView1.Columns.Clear();
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Nama Ruang", 150);
            listView1.Columns.Add("Jenis", 150);
            listView1.Columns.Add("Kapasitas", 100);

            LoadDataRuangan();
        }

        private void LoadDataRuangan()
        {
            listView1.Items.Clear();
            var dataRuangan = _controller.GetRuanganTersedia();

            foreach (var ruang in dataRuangan)
            {
                var item = new ListViewItem(ruang.Id.ToString());
                item.SubItems.Add(ruang.Nama);
                item.SubItems.Add(ruang.Jenis);
                item.SubItems.Add(ruang.Kapasitas.ToString());
                listView1.Items.Add(item);
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

            bool berhasil = _controller.PinjamRuangan(kelasPeminjam, tanggalPinjam, namaRuangan, jamMulai, jamSelesai);

            if (berhasil)
            {
                MessageBox.Show("Peminjaman berhasil!");
                LoadDataRuangan();
            }
            else
            {
                MessageBox.Show("Gagal meminjam ruangan.");
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
