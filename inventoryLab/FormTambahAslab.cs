using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace inventoryLab
{
    public partial class FormTambahAslab : Form
    {
        public FormTambahAslab(TampilDataAslab f2)
        {
            InitializeComponent();
            TampilDataAslab d2;
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

        //menyimpan data 
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
                string QueryTambah = "INSERT INTO aslab (kode_aslab,nama_aslab,nim) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                ConnDB.cmd = new OleDbCommand(QueryTambah, ConnDB.conn);
                ConnDB.cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Ditambah");
                nootomatis();
                ConnDB.conn.Close();

                this.Close();
            }
            raiseUpdate();

        }
        void nootomatis()
        {
            long hitung;
            string urut;
            
            

            ConnDB.Koneksi();
            // Perintah untuk mendapatkan nilai terbesar dari field nomor
            ConnDB.cmd = new OleDbCommand("select kode_aslab from aslab where kode_aslab in(select max(kode_aslab) from aslab) order by kode_aslab desc", ConnDB.conn);
            ConnDB.OleReader = ConnDB.cmd.ExecuteReader();
            ConnDB.OleReader.Read();
            // Jika data ditemukan
            if (ConnDB.OleReader.HasRows)
            {
                // Menambahkan data dari field nomor 
                hitung = Convert.ToInt64(ConnDB.OleReader[0].ToString().Substring(ConnDB.OleReader["kode_aslab"].ToString().Length - 2, 2)) + 1;
                string joinstr = "00" + hitung;
                // Mengambil 4 karakter kanan terakhir dari string joinstr lalu di tambahkan dengan string
                urut = "AS" + joinstr.Substring(joinstr.Length - 2, 2);
            }
            else
            {
                // Jika tidak ditemukan maka mengisi variable urut dengan BRG0001
                urut = "AS01";
            }
            ConnDB.OleReader.Close();
            textBox1.Text = urut;
            textBox1.Enabled = false;
            ConnDB.conn.Close();
        }

        private void FormTambahAslab_Load(object sender, EventArgs e)
        {
            nootomatis();
        }
    }
}
