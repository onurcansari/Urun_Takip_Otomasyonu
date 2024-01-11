using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip
{
    public partial class FrmSatislar : Form
    {
        public FrmSatislar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RR6G2VG;Initial Catalog=DbUrun;Integrated Security=True");
        DataSet1TableAdapters.TblSatıslarTableAdapter ds = new DataSet1TableAdapters.TblSatıslarTableAdapter();


        private void FrmSatislar_Load(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Select * from TblUrunler", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            comboBox1.ValueMember = "UrunId";
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "UrunAd";

            dataGridView1.DataSource = ds.SatisListesi();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Execute satislistesi", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            ds.SatisEkle(int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(txtMusteri.Text), byte.Parse(TxtAdet1.Text), decimal.Parse(txtFiyat1.Text), decimal.Parse(txtToplam1.Text), DateTime.Parse(mskTarih.Text));
            MessageBox.Show("Satış Başarıyla Gerçekleşti", "Satış İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            double adet, fiyat, toplam;
            adet = Convert.ToDouble(TxtAdet1.Text);
            fiyat = Convert.ToDouble(txtFiyat1.Text);
            toplam = adet * fiyat;
            txtToplam1.Text = toplam.ToString(); 
        }
    }
}
