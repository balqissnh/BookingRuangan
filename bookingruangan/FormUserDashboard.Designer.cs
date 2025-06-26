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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnPinjam = new System.Windows.Forms.Button();
            this.dtpMulai = new System.Windows.Forms.DateTimePicker();
            this.dtpSelesai = new System.Windows.Forms.DateTimePicker();
            this.lblMulai = new System.Windows.Forms.Label();
            this.lblSelesai = new System.Windows.Forms.Label();
            this.txtKelas = new System.Windows.Forms.TextBox();
            this.lblKelas = new System.Windows.Forms.Label();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.lblTanggal = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // label1
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Daftar Ruangan Tersedia";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // listView1
            this.listView1.Location = new System.Drawing.Point(30, 70);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(450, 180);
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Columns.Add("ID", 40);
            this.listView1.Columns.Add("Nama Ruangan", 150);
            this.listView1.Columns.Add("Jenis", 120);
            this.listView1.Columns.Add("Kapasitas", 100);

            // lblKelas
            this.lblKelas.Text = "Kelas Peminjam:";
            this.lblKelas.Location = new System.Drawing.Point(30, 260);
            this.lblKelas.Size = new System.Drawing.Size(120, 25);

            // txtKelas
            this.txtKelas.Location = new System.Drawing.Point(160, 257);
            this.txtKelas.Size = new System.Drawing.Size(150, 31);

            // lblTanggal
            this.lblTanggal.Text = "Tanggal Pinjam:";
            this.lblTanggal.Location = new System.Drawing.Point(30, 295);
            this.lblTanggal.Size = new System.Drawing.Size(120, 25);

            // dtpTanggal
            this.dtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTanggal.Location = new System.Drawing.Point(160, 292);
            this.dtpTanggal.Size = new System.Drawing.Size(150, 31);

            // lblMulai
            this.lblMulai.Text = "Jam Mulai:";
            this.lblMulai.Location = new System.Drawing.Point(30, 330);
            this.lblMulai.Size = new System.Drawing.Size(100, 25);

            // dtpMulai
            this.dtpMulai.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpMulai.ShowUpDown = true;
            this.dtpMulai.Location = new System.Drawing.Point(130, 327);
            this.dtpMulai.Size = new System.Drawing.Size(100, 31);

            // lblSelesai
            this.lblSelesai.Text = "Jam Selesai:";
            this.lblSelesai.Location = new System.Drawing.Point(250, 330);
            this.lblSelesai.Size = new System.Drawing.Size(100, 25);

            // dtpSelesai
            this.dtpSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSelesai.ShowUpDown = true;
            this.dtpSelesai.Location = new System.Drawing.Point(350, 327);
            this.dtpSelesai.Size = new System.Drawing.Size(100, 31);

            // btnPinjam
            this.btnPinjam.Text = "Pinjam";
            this.btnPinjam.Location = new System.Drawing.Point(110, 370);
            this.btnPinjam.Size = new System.Drawing.Size(120, 35);
            this.btnPinjam.Click += new System.EventHandler(this.btnPinjam_Click);

            // btnLogout
            this.btnLogout.Text = "Logout";
            this.btnLogout.Location = new System.Drawing.Point(270, 370);
            this.btnLogout.Size = new System.Drawing.Size(120, 35);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // FormUserDashboard
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 430);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lblKelas);
            this.Controls.Add(this.txtKelas);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.lblMulai);
            this.Controls.Add(this.dtpMulai);
            this.Controls.Add(this.lblSelesai);
            this.Controls.Add(this.dtpSelesai);
            this.Controls.Add(this.btnPinjam);
            this.Controls.Add(this.btnLogout);
            this.Name = "FormUserDashboard";
            this.Text = "Dashboard User - Booking Ruangan";
            this.Load += new System.EventHandler(this.FormUserDashboard_Load);
            this.ResumeLayout(false);
        }
    }
}
