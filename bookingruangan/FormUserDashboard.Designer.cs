namespace bookingruangan
{
    partial class FormUserDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnPinjam;
        private System.Windows.Forms.DateTimePicker dtpMulai;
        private System.Windows.Forms.DateTimePicker dtpSelesai;
        private System.Windows.Forms.Label lblMulai;
        private System.Windows.Forms.Label lblSelesai;
        private System.Windows.Forms.TextBox txtKelas;
        private System.Windows.Forms.Label lblKelas;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.Label lblTanggal;
        private System.Windows.Forms.Button btnRiwayat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            btnLogout = new Button();
            listView1 = new ListView();
            btnPinjam = new Button();
            dtpMulai = new DateTimePicker();
            dtpSelesai = new DateTimePicker();
            lblMulai = new Label();
            lblSelesai = new Label();
            txtKelas = new TextBox();
            lblKelas = new Label();
            dtpTanggal = new DateTimePicker();
            lblTanggal = new Label();
            btnRiwayat = new Button();
            SuspendLayout();

            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(91, 17);
            label1.Size = new Size(520, 40);
            label1.Text = "Daftar Ruangan Tersedia";
            label1.TextAlign = ContentAlignment.MiddleCenter;

            btnLogout.Location = new Point(266, 553);
            btnLogout.Size = new Size(120, 35);
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;

            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(31, 70);
            listView1.Size = new Size(637, 250);
            listView1.View = View.Details;

            btnPinjam.Location = new Point(57, 553);
            btnPinjam.Size = new Size(120, 35);
            btnPinjam.Text = "Pinjam";
            btnPinjam.Click += btnPinjam_Click;

            dtpMulai.Format = DateTimePickerFormat.Time;
            dtpMulai.Location = new Point(161, 448);
            dtpMulai.ShowUpDown = true;
            dtpMulai.Size = new Size(180, 31);

            dtpSelesai.Format = DateTimePickerFormat.Time;
            dtpSelesai.Location = new Point(500, 451);
            dtpSelesai.ShowUpDown = true;
            dtpSelesai.Size = new Size(168, 31);

            lblMulai.Location = new Point(33, 451);
            lblMulai.Size = new Size(100, 25);
            lblMulai.Text = "Jam Mulai";

            lblSelesai.Location = new Point(371, 454);
            lblSelesai.Size = new Size(113, 28);
            lblSelesai.Text = "Jam Selesai";

            txtKelas.Location = new Point(161, 338);
            txtKelas.Size = new Size(180, 31);

            lblKelas.Location = new Point(31, 341);
            lblKelas.Size = new Size(120, 25);
            lblKelas.Text = "Kelas Peminjam:";

            dtpTanggal.Format = DateTimePickerFormat.Short;
            dtpTanggal.Location = new Point(161, 396);
            dtpTanggal.Size = new Size(180, 31);

            lblTanggal.Location = new Point(31, 399);
            lblTanggal.Size = new Size(120, 25);
            lblTanggal.Text = "Tanggal Pinjam:";

            btnRiwayat.Location = new Point(490, 553);
            btnRiwayat.Size = new Size(153, 35);
            btnRiwayat.Text = "Lihat Riwayat";
            btnRiwayat.Click += btnRiwayat_Click;

            ClientSize = new Size(708, 644);
            Controls.Add(btnRiwayat);
            Controls.Add(label1);
            Controls.Add(listView1);
            Controls.Add(lblKelas);
            Controls.Add(txtKelas);
            Controls.Add(lblTanggal);
            Controls.Add(dtpTanggal);
            Controls.Add(lblMulai);
            Controls.Add(dtpMulai);
            Controls.Add(lblSelesai);
            Controls.Add(dtpSelesai);
            Controls.Add(btnPinjam);
            Controls.Add(btnLogout);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard User - Booking Ruangan";
            Load += FormUserDashboard_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
