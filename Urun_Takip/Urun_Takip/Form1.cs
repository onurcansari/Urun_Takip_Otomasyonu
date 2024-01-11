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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RR6G2VG;Initial Catalog=DbUrun;Integrated Security=True");

        private void btnList_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From TblKategori", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into TblKategori (Ad) Values (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtKategoriAd.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategoriniz başarılı bir şekilde eklendi");

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("delete from TblKategori where id =@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", txtId.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategoriniz başarılı bir şekilde silindi");

        }

        private void txtKategoriAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update TblKategori set Ad = @p2 where id =@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", txtId.Text);
            komut4.Parameters.AddWithValue("@p2", txtKategoriAd.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategoriniz başarılı bir şekilde güncellendi");
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From TblKategori where Ad = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKategoriAd.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
