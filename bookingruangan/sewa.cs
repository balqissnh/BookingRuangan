using System;
using System.Windows.Forms;
using bookingruangan.Controllers;
using bookingruangan.Models;

namespace bookingruangan
{
    public partial class sewa : Form
    {
        private SewaController _controller;

        public sewa()
        {
            InitializeComponent();
            _controller = new SewaController(this);
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
        }

        private void sewa_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Clear();
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Nama Ruangan", 200);
            listView1.Columns.Add("Jenis", 150);
            listView1.Columns.Add("Kapasitas", 100);
            listView1.Columns.Add("Status", 100); // Tambahkan kolom status

            _controller.LoadDataRuangan(listView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text.Trim();
            string jenis = textBox2.Text.Trim();
            string kapasitas = textBox3.Text.Trim();

            if (!string.IsNullOrWhiteSpace(nama) &&
                !string.IsNullOrWhiteSpace(jenis) &&
                !string.IsNullOrWhiteSpace(kapasitas))
            {
                try
                {
                    _controller.TambahRuang(nama, jenis, kapasitas, listView1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Semua kolom harus diisi.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin diedit.");
                return;
            }

            try
            {
                string status = listView1.SelectedItems[0].SubItems[4].Text; // Ambil status dari listView
                _controller.UpdateRuang(listView1.SelectedItems[0], textBox1.Text, textBox2.Text, textBox3.Text, status);
                MessageBox.Show("Data berhasil diperbarui.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin dihapus.");
                return;
            }

            try
            {
                _controller.HapusRuang(listView1.SelectedItems[0], listView1);
                MessageBox.Show("Data berhasil dihapus.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var item = listView1.SelectedItems[0];
                textBox1.Text = item.SubItems[1].Text;
                textBox2.Text = item.SubItems[2].Text;
                textBox3.Text = item.SubItems[3].Text;
                // textBox4.Text = item.SubItems[4].Text; // Tambahkan jika ingin edit status manual
            }
        }
    }
}
