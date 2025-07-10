using System;
using System.Windows.Forms;
using bookingruangan.Models;
using bookingruangan.Service;

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

            var ruangList = RuangService.GetAllRuangan();
            foreach (var ruang in ruangList)
            {
                var item = new ListViewItem(ruang.Id.ToString());
                item.SubItems.Add(ruang.Nama);
                item.SubItems.Add(ruang.Jenis);
                item.SubItems.Add(ruang.Kapasitas.ToString());
                item.SubItems.Add(ruang.Status); // Tambahkan status
                listView.Items.Add(item);
            }
        }

        public void TambahRuang(string nama, string jenis, string kapasitas, ListView listView)
        {
            var ruang = new RuangModel
            {
                Nama = nama,
                Jenis = jenis,
                Kapasitas = int.Parse(kapasitas),
                Status = "tersedia" // Default status saat ditambahkan
            };

            int id = RuangService.TambahRuang(ruang);

            var item = new ListViewItem(id.ToString());
            item.SubItems.Add(ruang.Nama);
            item.SubItems.Add(ruang.Jenis);
            item.SubItems.Add(ruang.Kapasitas.ToString());
            item.SubItems.Add(ruang.Status);
            listView.Items.Add(item);
        }

        public void UpdateRuang(ListViewItem selectedItem, string nama, string jenis, string kapasitas, string status)
        {
            int id = int.Parse(selectedItem.SubItems[0].Text);

            var ruang = new RuangModel
            {
                Id = id,
                Nama = nama,
                Jenis = jenis,
                Kapasitas = int.Parse(kapasitas),
                Status = status
            };

            RuangService.UpdateRuang(ruang);

            selectedItem.SubItems[1].Text = nama;
            selectedItem.SubItems[2].Text = jenis;
            selectedItem.SubItems[3].Text = kapasitas;
            selectedItem.SubItems[4].Text = status; // Tambahkan update status ke tampilan
        }

        public void HapusRuang(ListViewItem selectedItem, ListView listView)
        {
            int id = int.Parse(selectedItem.SubItems[0].Text);
            RuangService.HapusRuang(id);
            listView.Items.Remove(selectedItem);
        }
    }
}
