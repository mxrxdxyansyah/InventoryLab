using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventoryLab
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void buttonpgn_Click(object sender, EventArgs e)
        {
            TampilDataPengguna tpn = new TampilDataPengguna();
            tpn.TopLevel = false; tpn.TopMost = true;
            panelTampil.Controls.Add(tpn);
            tpn.BringToFront();
            tpn.Show();
        }

        private void buttonaslab_Click(object sender, EventArgs e)
        {
            TampilDataAslab tpl = new TampilDataAslab();
            tpl.TopLevel = false; tpl.TopMost = true;
            panelTampil.Controls.Add(tpl);
            tpl.BringToFront();
            tpl.Show();
        }

        private void buttonbrg_Click(object sender, EventArgs e)
        {
            TampilDataBarang tpb = new TampilDataBarang();
            tpb.TopLevel = false; tpb.TopMost = true;
            panelTampil.Controls.Add(tpb);
            tpb.BringToFront();
            tpb.Show();
        }
    }
}
