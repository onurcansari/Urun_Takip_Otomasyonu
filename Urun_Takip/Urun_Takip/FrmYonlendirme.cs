using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip
{
    public partial class FrmYonlendirme : Form
    {
        public FrmYonlendirme()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            FrmUrun frmUrun = new FrmUrun();
            frmUrun.Show();
        }

        private void pnlKategori_Click(object sender, EventArgs e)
        {
            FrmKategori frmKategori = new FrmKategori();
            frmKategori.Show();
        }

        private void pnlIstatistik_Click(object sender, EventArgs e)
        {
            FrmIstatistik frmIstatistik = new FrmIstatistik();
            frmIstatistik.Show();
        }

        private void pnlGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frmGrafikler = new FrmGrafikler();
            frmGrafikler.Show();
        }

        private void pnlLogin_Click(object sender, EventArgs e)
        {
            FrmAdmin frmAdmin = new FrmAdmin();
            frmAdmin.Show();
            this.Hide();
        }
    }
}
