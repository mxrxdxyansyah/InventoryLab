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
    public partial class FormTambahDataBarang : Form
    {
        public FormTambahDataBarang(TampilDataBarang fx)
        {
            InitializeComponent();
            TampilDataBarang dx;
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
        void tampilrak()
        {
            ConnDB.Koneksi();
            ConnDB.cmd = new OleDbCommand("SELECT * from rak'", ConnDB.conn);
            ConnDB.OleReader = ConnDB.cmd.ExecuteReader();

            while (ConnDB.OleReader.Read())
            {
                comboBox1.Items.Add(ConnDB.OleReader["kode_rak"]);

            }
            ConnDB.conn.Close();
        }
        private void FormTambahDataBarang_Load(object sender, EventArgs e)
        {
            nootomatis();
            tampilrak();
            
        }
        public void nootomatis()
        {
            long hitung;
            string urut;

            ConnDB.Koneksi();
            // Perintah untuk mendapatkan nilai terbesar dari field nomor
            ConnDB.cmd = new OleDbCommand("select kode_barang from barang where kode_barang in(select max(kode_barang) from barang) order by kode_barang desc", ConnDB.conn);
            ConnDB.OleReader = ConnDB.cmd.ExecuteReader();
            ConnDB.OleReader.Read();
            // Jika data ditemukan
            if (ConnDB.OleReader.HasRows)
            {
                // Menambahkan data dari field nomor 
                hitung = Convert.ToInt64(ConnDB.OleReader[0].ToString().Substring(ConnDB.OleReader["kode_barang"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                // Mengambil 4 karakter kanan terakhir dari string joinstr lalu di tambahkan dengan string
                urut = "BL" + joinstr.Substring(joinstr.Length - 3, 3);
            }
            else
            {
                // Jika tidak ditemukan maka mengisi variable urut dengan BRG0001
                urut = "BL001";
            }
            ConnDB.OleReader.Close();
            textBox1.Text = urut;
            textBox1.Enabled = false;
            ConnDB.conn.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnDB.Koneksi();
            //comboBox1.Items.Clear();
            ConnDB.cmd = new OleDbCommand("SELECT * from rak where kode_rak='" + comboBox1.Text + "'", ConnDB.conn);
            ConnDB.OleReader = ConnDB.cmd.ExecuteReader();

            while (ConnDB.OleReader.Read())
            {
                string locat = ConnDB.OleReader["lokasi"].ToString();
                textBox4.Text = locat;
               
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // jika inputan kosong maka tidak akan terisi
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Silahkan Legkapi Data");
            }
            //jika inputan terisi maka data akan masuk
            else
            {
                ConnDB.Koneksi();
                string QueryTambah = "INSERT INTO barang (kode_barang,nama_barang,stok,status,kode_rak) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + comboBox1.Text+ "')";
                ConnDB.cmd = new OleDbCommand(QueryTambah, ConnDB.conn);
                ConnDB.cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Ditambah");
                nootomatis();
                ConnDB.conn.Close();

                this.Close();
            }
            raiseUpdate();
        }
    }
}
