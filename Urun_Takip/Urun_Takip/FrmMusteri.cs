using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Urun_Takip
{
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TblMusteriTableAdapter tb = new DataSet1TableAdapters.TblMusteriTableAdapter();

        private void txtAlisFiyat_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.TblMusteriTableAdapter tb= new DataSet1TableAdapters.TblMusteriTableAdapter();
            dataGridView1.DataSource = tb.MusteriListesi();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            tb.MusteriEkle(txtAd.Text,txtSoyad.Text,txtSehir.Text,decimal.Parse(txtBakiye.Text));
            MessageBox.Show("Müşteri Sisteme Kaydedildi","Kayıt İşlemi Gerçekleşti",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            tb.MusteriSil(int.Parse(txtMusterId.Text));
            MessageBox.Show("Müşteri Sistemden Silindi", "Silme İşlemi Gerçekleşti", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMusterId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtBakiye.Text= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnGüncel_Click(object sender, EventArgs e)
        {
            tb.MusteriGuncelle(txtAd.Text, txtSoyad.Text,txtSehir.Text,decimal.Parse(txtBakiye.Text),int.Parse(txtMusterId.Text));
            MessageBox.Show("Müşteri Sistemde Güncellendi", "Güncelleme İşlemi Gerçekleşti", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if(rdbAd.Checked) {
                dataGridView1.DataSource = tb.AdaGoreListele(txtAranacakKelime.Text);
            }
            if(rdbSoyad.Checked)
            {
                dataGridView1.DataSource = tb.SoyadaGoreListele(txtAranacakKelime.Text);
            }
            if (rdbSehir.Checked)
            {
                dataGridView1.DataSource = tb.SehireGoreListele(txtAranacakKelime.Text);

            }
        }
    }
}
