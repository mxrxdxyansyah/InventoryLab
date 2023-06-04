using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.DataFormats;

namespace inventoryLab
{
    public partial class TampilDataAslab : Form
    {
        public TampilDataAslab()
        {
            InitializeComponent();
        }
        KoneksiDB ConnDB = new KoneksiDB();

        //menampilkan data
        private void TampilDataAslab_Load(object sender, EventArgs e)
        {
            BindxSoucre();
            setGrid();
        }
        //inisiasi penampilan data
        public void BindxSoucre()
        {
        
            // membuka koneksi db || pilih query
            ConnDB.Koneksi();
            ConnDB.OleAdapter = new OleDbDataAdapter("Select * from aslab", ConnDB.conn);
            DataSet ds = new DataSet();
            ConnDB.OleAdapter.Fill(ds);

            //menampilkan kedalam table
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.ReadOnly = true;

            //menutup koneksi db
            ConnDB.conn.Close();

        }

        //penghubung antar form
        private void F2_UpdateEventHandler1(object sender, FormTambahAslab.UpdateEventArgs args)
        {
            BindxSoucre();
        }
        void setGrid()
        {
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;

            dataGridView1.Columns[0].HeaderText = "KODE";
            dataGridView1.Columns[1].HeaderText = "NAMA ASISTEN LAB";
            dataGridView1.Columns[2].HeaderText = "NIM";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormTambahAslab frm3 = new FormTambahAslab(this);
            frm3.UpdateEventHandler += F2_UpdateEventHandler1;
            frm3.ShowDialog(); 

        }
    }
}

