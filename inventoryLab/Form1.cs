using System.Data;
using System.Data.OleDb;
namespace inventoryLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        KoneksiDB ConnDB = new KoneksiDB();
        FormMenu Frmenu = new FormMenu();
        private void button1_Click(object sender, EventArgs e)
        {
            ConnDB.Koneksi();
            ConnDB.cmd = new OleDbCommand("SELECT * FROM pengguna where kode_pengguna='" + textBox1.Text + "' AND pswrd='" + textBox2.Text + "'", ConnDB.conn);
            ConnDB.OleReader = ConnDB.cmd.ExecuteReader();
            ConnDB.OleReader.Read();
            if (!ConnDB.OleReader.HasRows)
            {
                MessageBox.Show("Gagal Login.... Periksa Kembali");
                textBox1.Text = "";
                textBox2.Clear();
                textBox1.Focus();
            }
            else
            {
                this.Visible = false;
                Frmenu.ShowDialog();
            }

            //FormMenu frmn = new FormMenu();
            //frmn.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToUpper();
        }
    }
}