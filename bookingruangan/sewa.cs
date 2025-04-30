using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bookingruangan
{
    public partial class sewa : Form
    {
        public sewa()
        {
            InitializeComponent();
            // Tambahkan handler ListView jika belum di-designer
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
        }

        private void sewa_Load(object sender, EventArgs e)
        {
            // Inisialisasi tampilan dan kolom ListView
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Clear(); // Bersihkan dulu jika ada kolom sebelumnya
            listView1.Columns.Add("ID", 50);   // Tambahkan kolom ID
            listView1.Columns.Add("Nama Ruangan", 200);
            listView1.Columns.Add("Jenis", 150);
            listView1.Columns.Add("Kapasitas", 150);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Tambah data ke ListView
            string namaRuangan = textBox1.Text.Trim();
            string jenis = textBox2.Text.Trim();
            string kapasitas = textBox3.Text.Trim();

            if (!string.IsNullOrWhiteSpace(namaRuangan) &&
                !string.IsNullOrWhiteSpace(jenis) &&
                !string.IsNullOrWhiteSpace(kapasitas))
            {
                try
                {
                    string connectionString = "server=localhost;database=bookingruang;user=root;password=;";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO mnjruang (nama, jenis, kapasitas) VALUES (@nama, @jenis, @kapasitas)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nama", namaRuangan);
                            cmd.Parameters.AddWithValue("@jenis", jenis);
                            cmd.Parameters.AddWithValue("@kapasitas", int.Parse(kapasitas));
                            cmd.ExecuteNonQuery();
                        }

                        // Ambil ID yang di-generate otomatis oleh MySQL
                        string getIdQuery = "SELECT LAST_INSERT_ID()";
                        using (MySqlCommand cmdId = new MySqlCommand(getIdQuery, conn))
                        {
                            int id = Convert.ToInt32(cmdId.ExecuteScalar());

                            // Tambah item ke ListView dengan ID
                            var item = new ListViewItem(id.ToString());
                            item.SubItems.Add(namaRuangan);
                            item.SubItems.Add(jenis);
                            item.SubItems.Add(kapasitas);
                            listView1.Items.Add(item);
                        }
                    }
                    ClearTextBoxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Semua kolom harus diisi.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Edit data yang dipilih
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin diedit.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = listView1.SelectedItems[0];

            int idRuangan = int.Parse(selectedItem.SubItems[0].Text); // ID tidak diubah
            string namaBaru = textBox1.Text.Trim();
            string jenisBaru = textBox2.Text.Trim();
            string kapasitasBaru = textBox3.Text.Trim();

            try
            {
                string connectionString = "server=localhost;database=bookingruang;user=root;password=;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE mnjruang SET nama = @nama, jenis = @jenis, kapasitas = @kapasitas WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", namaBaru);
                        cmd.Parameters.AddWithValue("@jenis", jenisBaru);
                        cmd.Parameters.AddWithValue("@kapasitas", int.Parse(kapasitasBaru));
                        cmd.Parameters.AddWithValue("@id", idRuangan);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Perbarui tampilan ListView tanpa mengubah ID
                selectedItem.SubItems[1].Text = namaBaru;
                selectedItem.SubItems[2].Text = jenisBaru;
                selectedItem.SubItems[3].Text = kapasitasBaru;

                ClearTextBoxes();
                MessageBox.Show("Data berhasil diperbarui.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Hapus data yang dipilih dari database dan ListView
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih data yang ingin dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = listView1.SelectedItems[0];
            int idRuangan = int.Parse(selectedItem.SubItems[0].Text); // Ambil id untuk dihapus

            try
            {
                string connectionString = "server=localhost;database=bookingruang;user=root;password=;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    // Query untuk menghapus data dari database berdasarkan id
                    string query = "DELETE FROM mnjruang WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idRuangan);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Hapus item dari ListView setelah data dihapus dari database
                listView1.Items.Remove(selectedItem);
                ClearTextBoxes();
                MessageBox.Show("Data berhasil dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tampilkan data ke textbox saat item dipilih
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                textBox1.Text = selectedItem.SubItems[1].Text;  // Nama
                textBox2.Text = selectedItem.SubItems[2].Text;  // Jenis
                textBox3.Text = selectedItem.SubItems[3].Text;  // Kapasitas
            }
        }


        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }
    }
}
