using System;
using System.Windows.Forms;
using bookingruangan.Controllers;
using bookingruangan.Models;

namespace bookingruangan
{
    public partial class FormRiwayatPeminjaman : Form
    {
        private readonly string _namaUser;
        private readonly FormRiwayatPeminjamanController _controller;

        public FormRiwayatPeminjaman(string namaUser)
        {
            InitializeComponent();
            _namaUser = namaUser;
            _controller = new FormRiwayatPeminjamanController(_namaUser);
        }

        private void FormRiwayatPeminjaman_Load(object sender, EventArgs e)
        {
            label1.Text = "Riwayat Peminjaman - " + _namaUser;

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
            var riwayatList = _controller.GetRiwayat();

            foreach (var data in riwayatList)
            {
                var item = new ListViewItem(data.Tanggal.ToString("yyyy-MM-dd"));
                item.SubItems.Add(data.Kelas);
                item.SubItems.Add(data.Ruangan);
                item.SubItems.Add(data.JamMulai);
                item.SubItems.Add(data.JamSelesai);
                item.SubItems.Add(data.Status);
                listView1.Items.Add(item);
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
            if (confirm == DialogResult.No) return;

            bool berhasil = _controller.Kembalikan(tanggal, ruang, jamMulai);

            if (berhasil)
            {
                MessageBox.Show("Ruangan berhasil dikembalikan.");
                LoadRiwayat();
            }
            else
            {
                MessageBox.Show("Data tidak ditemukan atau sudah dikembalikan.");
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
