using System.Drawing;
using System.Windows.Forms;

namespace bookingruangan
{
    partial class sewa
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            listView1 = new ListView();

            SuspendLayout();

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 19);
            label1.Name = "label1";
            label1.Size = new Size(179, 25);
            label1.TabIndex = 0;
            label1.Text = "Manajemen Ruangan";

            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 81);
            label2.Name = "label2";
            label2.Size = new Size(134, 25);
            label2.TabIndex = 1;
            label2.Text = "Nama Ruangan";

            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 139);
            label3.Name = "label3";
            label3.Size = new Size(49, 25);
            label3.TabIndex = 2;
            label3.Text = "Jenis";

            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 188);
            label4.Name = "label4";
            label4.Size = new Size(86, 25);
            label4.TabIndex = 3;
            label4.Text = "Kapasitas";

            // 
            // textBox1
            // 
            textBox1.Location = new Point(180, 78);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 5;

            // 
            // textBox2
            // 
            textBox2.Location = new Point(180, 136);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 31);
            textBox2.TabIndex = 6;

            // 
            // textBox3
            // 
            textBox3.Location = new Point(180, 187);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 31);
            textBox3.TabIndex = 7;

            // 
            // button1 (Tambah)
            // 
            button1.Location = new Point(106, 252);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 9;
            button1.Text = "Tambah";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;

            // 
            // button2 (Edit)
            // 
            button2.Location = new Point(303, 252);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 10;
            button2.Text = "Edit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;

            // 
            // button3 (Hapus)
            // 
            button3.Location = new Point(528, 252);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 11;
            button3.Text = "Hapus";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;

            // 
            // listView1
            // 
            listView1.Location = new Point(0, 306);
            listView1.Name = "listView1";
            listView1.Size = new Size(800, 146);
            listView1.TabIndex = 12;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;

            // 
            // sewa
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "sewa";
            Text = "Sewa Ruangan";
            Load += sewa_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
        private Button button3;
        private ListView listView1;
    }
}
