using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Urun_Takip
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RR6G2VG;Initial Catalog=DbUrun;Integrated Security=True");

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            // Toplam Kategori Sayısı
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select count(*) from TblKategori", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblToplamKategori.Text = dr[0].ToString();
            }
            baglanti.Close();

            // Toplam Ürün Sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select count(*) from TblUrunler", baglanti);
            SqlDataReader dr2 = komut1.ExecuteReader();
            while (dr2.Read())
            {
                lblUrunSayisi.Text = dr2[0].ToString();
            }
            baglanti.Close();

            // Beyaz Eşya Sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select count(*) from TblUrunler where Kategori=(Select id from TblKategori where Ad = 'Beyaz Eşya')", baglanti);
            SqlDataReader dr3 = komut2.ExecuteReader();
            while (dr3.Read())
            {
                lblBeyazEsyaSayisi.Text = dr3[0].ToString();
            }
            baglanti.Close();

            // Küçük Ev Aletleri Sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select count(*) from TblUrunler where Kategori=(Select id from TblKategori where Ad = 'Küçük Ev Aletleri')", baglanti);
            SqlDataReader dr4 = komut3.ExecuteReader();
            while (dr4.Read())
            {
                lblKucukEvAletleriSayisi.Text = dr4[0].ToString();
            }
            baglanti.Close();

            // En Yüksek Stoklu Ürün
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select * from TblUrunler where Stok = (Select MAX(stok) from TblUrunler)", baglanti);
            SqlDataReader dr5 = komut4.ExecuteReader();
            while (dr5.Read())
            {
                lblEnYuksekStok.Text = dr5["UrunAd"].ToString();
            }
            baglanti.Close();

            // En Düşük Stoklu Ürün
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select * from TblUrunler where Stok = (Select MIN(stok) from TblUrunler)", baglanti);
            SqlDataReader dr6 = komut5.ExecuteReader();
            while (dr6.Read())
            {
                lblEnDusukStok.Text = dr6["UrunAd"].ToString();
            }
            baglanti.Close();

            // Laptop Toplam Karı
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select stok*(satisfiyat-alisFiyat) from TblUrunler where UrunAd = 'Oyuncu Bilgisayarı'", baglanti);
            SqlDataReader dr7 = komut6.ExecuteReader();
            while (dr7.Read())
            {
               lblLaptopToplamKari.Text = dr7[0].ToString() + "₺";
            }
            baglanti.Close();

            // Beyaz Eşya Toplam Karı
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("Select Sum(Stok*(Satisfiyat-AlisFiyat)) from TblUrunler where KAtegori =(Select id from TblKategori where Ad = 'Beyaz Eşya')", baglanti);
            SqlDataReader dr8 = komut7.ExecuteReader();
            while (dr8.Read())
            {
                lblBeyazEsyaToplamKari.Text = dr8[0].ToString() + "₺";
            }
            baglanti.Close();
        }
    }
}
