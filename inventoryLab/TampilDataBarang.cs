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
            ConnDB.OleAdapter = new OleDbDataAdapter("Select * from barang", ConnDB.conn);
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
        void setGrid()
        {
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;

            dataGridView1.Columns[0].HeaderText = "KODE";
            dataGridView1.Columns[1].HeaderText = "NAMA BARANG";
            dataGridView1.Columns[2].HeaderText = "STOK";
            dataGridView1.Columns[3].HeaderText = "STATUS";
            dataGridView1.Columns[4].HeaderText = "RAK";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
