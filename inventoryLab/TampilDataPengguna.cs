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
    public partial class TampilDataPengguna : Form
    {
        public TampilDataPengguna()
        {
            InitializeComponent();
        }
        KoneksiDB ConnDB = new KoneksiDB();


        private void TampilDataPengguna_Load(object sender, EventArgs e)
        {
            BindxSoucre();
            setGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTambahDataPengguna frm3 = new FormTambahDataPengguna(this);
            frm3.UpdateEventHandler += F2_UpdateEventHandler1;
            frm3.ShowDialog();
        }
        //inisiasi penampilan data
        public void BindxSoucre()
        {

            // membuka koneksi db || pilih query
            ConnDB.Koneksi();
            ConnDB.OleAdapter = new OleDbDataAdapter("Select * from pengguna", ConnDB.conn);
            DataSet ds = new DataSet();
            ConnDB.OleAdapter.Fill(ds);

            //menampilkan kedalam table
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.ReadOnly = true;

            //menutup koneksi db
            ConnDB.conn.Close();

        }

        //penghubung antar form
        private void F2_UpdateEventHandler1(object sender, FormTambahDataPengguna.UpdateEventArgs args)
        {
            BindxSoucre();
        }

        void setGrid()
        {
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Width = 150;

            dataGridView1.Columns[0].HeaderText = "KODE";
            dataGridView1.Columns[1].HeaderText = "NAMA PENGGUNA";
            dataGridView1.Columns[3].HeaderText = "LEVEL USER";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


    }
}
