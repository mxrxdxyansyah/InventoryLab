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
    public partial class TampilDataBarang : Form
    {
        public TampilDataBarang()
        {
            InitializeComponent();
        }

        KoneksiDB ConnDB = new KoneksiDB();
        void showData() // berfungsi untuk memanggil atau menampilkan data
        {
            // membuka koneksi db || pilih query
            ConnDB.Koneksi();
            ConnDB.OleAdapter = new OleDbDataAdapter("SELECT barang.kode_barang,barang.nama_barang,barang.stok,rak.lokasi,barang.status FROM barang INNER JOIN rak ON barang.kode_rak = rak.kode_rak ", ConnDB.conn);
            DataSet ds = new DataSet();
            ConnDB.OleAdapter.Fill(ds);

            //menampilkan kedalam table
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.ReadOnly = true;

            //menutup koneksi db
            ConnDB.conn.Close();
        }
        private void TampilDataBarang_Load(object sender, EventArgs e)
        {
            showData();
            setGrid();
        }
        //penghubung antar form
        private void F2_UpdateEventHandler1(object sender, FormTambahDataBarang.UpdateEventArgs args)
        {
            showData();
        }
        void setGrid()
        {
            dataGridView1.Columns["kode_barang"].Width = 150;
            dataGridView1.Columns["nama_barang"].Width = 150;
            dataGridView1.Columns["stok"].Width = 150;
            dataGridView1.Columns["lokasi"].Width = 150;
            dataGridView1.Columns["status"].Width = 150;

            dataGridView1.Columns["kode_barang"].HeaderText = "KODE";
            dataGridView1.Columns["nama_barang"].HeaderText = "NAMA BARANG";
            dataGridView1.Columns["stok"].HeaderText = "STOK";
            dataGridView1.Columns["lokasi"].HeaderText = "RAK";
            dataGridView1.Columns["status"].HeaderText = "STATUS";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTambahDataBarang frm3 = new FormTambahDataBarang(this);
            frm3.UpdateEventHandler += F2_UpdateEventHandler1;
            frm3.ShowDialog();
        }
    }
}
