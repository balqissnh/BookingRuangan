namespace bookingruangan
{
    partial class FormRiwayatPeminjaman
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.Button btnKembalikan;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            listView1 = new ListView();
            btnKembali = new Button();
            btnKembalikan = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(61, 13);
            label1.Name = "label1";
            label1.Size = new Size(500, 40);
            label1.TabIndex = 1;
            label1.Text = "Riwayat Peminjaman";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(30, 70);
            listView1.Name = "listView1";
            listView1.Size = new Size(566, 250);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // btnKembali
            // 
            btnKembali.Location = new Point(41, 343);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(100, 35);
            btnKembali.TabIndex = 3;
            btnKembali.Text = "Kembali";
            btnKembali.Click += btnKembali_Click;
            // 
            // btnKembalikan
            // 
            btnKembalikan.Location = new Point(441, 343);
            btnKembalikan.Name = "btnKembalikan";
            btnKembalikan.Size = new Size(126, 35);
            btnKembalikan.TabIndex = 0;
            btnKembalikan.Text = "Kembalikan";
            btnKembalikan.Click += btnKembalikan_Click;
            // 
            // FormRiwayatPeminjaman
            // 
            ClientSize = new Size(648, 400);
            Controls.Add(btnKembalikan);
            Controls.Add(label1);
            Controls.Add(listView1);
            Controls.Add(btnKembali);
            Name = "FormRiwayatPeminjaman";
            Text = "Riwayat Peminjaman";
            Load += FormRiwayatPeminjaman_Load;
            ResumeLayout(false);
        }
    }
}
