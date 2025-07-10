using System.Collections.Generic;
using bookingruangan.Models;

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
            return RuanganModel.GetTersedia();
        }

        public bool PinjamRuangan(string kelas, string tanggal, string ruang, string mulai, string selesai)
        {
            return UserDashboardModel.Pinjam(_namaUser, kelas, tanggal, ruang, mulai, selesai);
        }
    }
}
