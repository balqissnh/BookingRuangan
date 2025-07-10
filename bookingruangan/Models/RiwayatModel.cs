using System;

namespace bookingruangan.Models
{
    public class RiwayatModel
    {
        public DateTime Tanggal { get; set; }
        public string Kelas { get; set; }
        public string Ruangan { get; set; }
        public string JamMulai { get; set; }
        public string JamSelesai { get; set; }
        public string Status { get; set; }
    }
}
