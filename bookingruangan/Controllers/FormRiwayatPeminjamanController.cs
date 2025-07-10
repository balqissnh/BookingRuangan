using System.Collections.Generic;
using bookingruangan.Models;

namespace bookingruangan.Controllers
{
    public class FormRiwayatPeminjamanController
    {
        private readonly string _namaUser;

        public FormRiwayatPeminjamanController(string namaUser)
        {
            _namaUser = namaUser;
        }

        public List<RiwayatPeminjamanModel> GetRiwayat()
        {
            return RiwayatPeminjamanModel.AmbilRiwayat(_namaUser);
        }

        public bool Kembalikan(string tanggal, string ruang, string jamMulai)
        {
            return RiwayatPeminjamanModel.KembalikanRuangan(_namaUser, tanggal, ruang, jamMulai);
        }
    }
}
