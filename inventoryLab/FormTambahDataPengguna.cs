using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventoryLab
{
    public partial class FormTambahDataPengguna : Form
    {
        public FormTambahDataPengguna(TampilDataPengguna f2)
        {
            InitializeComponent();
            TampilDataPengguna d2;
        }
        KoneksiDB ConnDB = new KoneksiDB();
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        //integrasi form tampildata
        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }

        protected void raiseUpdate()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler?.Invoke(this, args);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // jika inputan kosong maka tidak akan terisi
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Silahkan Legkapi Data");
            }
            //jika inputan terisi maka data akan masuk
            else
            {
                ConnDB.Koneksi();
                string QueryTambah = "INSERT INTO pengguna (kode_pengguna,nama_pengguna,pswrd,level_user) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "')";
                ConnDB.cmd = new OleDbCommand(QueryTambah, ConnDB.conn);
                ConnDB.cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Ditambah");
                nootomatis();
                ConnDB.conn.Close();

                this.Close();
            }
            raiseUpdate();
        }

        private void FormTambahDataPengguna_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Admin");
            comboBox1.Items.Add("Petugas");

            nootomatis();
        }
        void nootomatis()
        {
            long hitung;
            string urut;



            ConnDB.Koneksi();
            // Perintah untuk mendapatkan nilai terbesar dari field nomor
            ConnDB.cmd = new OleDbCommand("select kode_pengguna from pengguna where kode_pengguna in(select max(kode_pengguna) from pengguna) order by kode_pengguna desc", ConnDB.conn);
            ConnDB.OleReader = ConnDB.cmd.ExecuteReader();
            ConnDB.OleReader.Read();
            // Jika data ditemukan
            if (ConnDB.OleReader.HasRows)
            {
                // Menambahkan data dari field nomor 
                hitung = Convert.ToInt64(ConnDB.OleReader[0].ToString().Substring(ConnDB.OleReader["kode_pengguna"].ToString().Length - 2, 2)) + 1;
                string joinstr = "00" + hitung;
                // Mengambil 4 karakter kanan terakhir dari string joinstr lalu di tambahkan dengan string
                urut = "PG" + joinstr.Substring(joinstr.Length - 2, 2);
            }
            else
            {
                // Jika tidak ditemukan maka mengisi variable urut dengan BRG0001
                urut = "PG01";
            }
            ConnDB.OleReader.Close();
            textBox1.Text = urut;
            textBox1.Enabled = false;
            ConnDB.conn.Close();
        }

    }
}
