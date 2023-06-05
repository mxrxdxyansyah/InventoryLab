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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace inventoryLab
{
    public partial class FormTambahRak : Form
    {
        public FormTambahRak()
        {
            InitializeComponent();
        }
        KoneksiDB ConnDB = new KoneksiDB();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Silahkan Legkapi Data");
            }
            //jika inputan terisi maka data akan masuk
            else
            {
                ConnDB.Koneksi();
                string QueryTambah = "INSERT INTO rak (kode_rak,lokasi) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')";
                ConnDB.cmd = new OleDbCommand(QueryTambah, ConnDB.conn);
                ConnDB.cmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Ditambah");
                nootomatis();
                ConnDB.conn.Close();

                this.Close();
            }

        }
        public void nootomatis()
        {
            long hitung;
            string urut;

            ConnDB.Koneksi();
            // Perintah untuk mendapatkan nilai terbesar dari field nomor
            ConnDB.cmd = new OleDbCommand("select kode_rak from rak where kode_rak in(select max(kode_rak) from rak) order by kode_rak desc", ConnDB.conn);
            ConnDB.OleReader = ConnDB.cmd.ExecuteReader();
            ConnDB.OleReader.Read();
            // Jika data ditemukan
            if (ConnDB.OleReader.HasRows)
            {
                // Menambahkan data dari field nomor 
                hitung = Convert.ToInt64(ConnDB.OleReader[0].ToString().Substring(ConnDB.OleReader["kode_rak"].ToString().Length - 2, 2)) + 1;
                string joinstr = "00" + hitung;
                // Mengambil 4 karakter kanan terakhir dari string joinstr lalu di tambahkan dengan string
                urut = "RK" + joinstr.Substring(joinstr.Length - 2, 2);
            }
            else
            {
                // Jika tidak ditemukan maka mengisi variable urut dengan BRG0001
                urut = "RK01";
            }
            ConnDB.OleReader.Close();
            textBox1.Text = urut;
            textBox1.Enabled = false;
            ConnDB.conn.Close();
        }
        public void BindxSoucre()
        {

            // membuka koneksi db || pilih query
            ConnDB.Koneksi();
            ConnDB.OleAdapter = new OleDbDataAdapter("Select * from rak", ConnDB.conn);
            DataSet ds = new DataSet();
            ConnDB.OleAdapter.Fill(ds);

            //menampilkan kedalam table
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.ReadOnly = true;

            //menutup koneksi db
            ConnDB.conn.Close();

        }

        private void FormTambahRak_Load(object sender, EventArgs e)
        {
            BindxSoucre();
            nootomatis();
            setGrid();
        }
        void setGrid()
        {
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
     

            dataGridView1.Columns[0].HeaderText = "KODE";
            dataGridView1.Columns[1].HeaderText = "LOKASI";
  

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
