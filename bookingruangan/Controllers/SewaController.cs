using System;
using System.Windows.Forms;
using bookingruangan.Models;

namespace bookingruangan.Controllers
{
    public class SewaController
    {
        private sewa _view;

        public SewaController(sewa view)
        {
            _view = view;
        }

        public void LoadDataRuangan(ListView listView)
        {
            listView.Items.Clear();
            string connectionString = "server=localhost;database=bookingruang;user=root;password=;";

            try
            {
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, nama, jenis, kapasitas FROM mnjruang";
                    using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new ListViewItem(reader["id"].ToString());
                            item.SubItems.Add(reader["nama"].ToString());
                            item.SubItems.Add(reader["jenis"].ToString());
                            item.SubItems.Add(reader["kapasitas"].ToString());
                            listView.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        public void TambahRuang(string nama, string jenis, string kapasitas, ListView listView)
        {
            var ruang = new Ruang
            {
                Nama = nama,
                Jenis = jenis,
                Kapasitas = int.Parse(kapasitas)
            };

            int id = RuangCRUD.TambahRuang(ruang);
            var item = new ListViewItem(id.ToString());
            item.SubItems.Add(nama);
            item.SubItems.Add(jenis);
            item.SubItems.Add(kapasitas);
            listView.Items.Add(item);
        }

        public void UpdateRuang(ListViewItem selectedItem, string nama, string jenis, string kapasitas)
        {
            int id = int.Parse(selectedItem.SubItems[0].Text);

            var ruang = new Ruang
            {
                Id = id,
                Nama = nama,
                Jenis = jenis,
                Kapasitas = int.Parse(kapasitas)
            };

            RuangCRUD.UpdateRuang(ruang);

            selectedItem.SubItems[1].Text = nama;
            selectedItem.SubItems[2].Text = jenis;
            selectedItem.SubItems[3].Text = kapasitas;
        }

        public void HapusRuang(ListViewItem selectedItem, ListView listView)
        {
            int id = int.Parse(selectedItem.SubItems[0].Text);
            RuangCRUD.HapusRuang(id);
            listView.Items.Remove(selectedItem);
        }
    }
}
