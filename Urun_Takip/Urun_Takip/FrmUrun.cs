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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RR6G2VG;Initial Catalog=DbUrun;Integrated Security=True");

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Select UrunId,UrunAd,Stok,AlisFiyat,SatisFiyat,Ad,Kategori from TblUrunler Inner join TblKategori On TblUrunler.Kategori = TblKategori.id", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Kategori"].Visible = false;
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Select * From TblKategori", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            comboBox1.DisplayMember = "Ad";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = dt2;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("insert into TblUrunler (UrunAd,Stok,alisfiyat,satisFiyat,Kategori) Values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut3.Parameters.AddWithValue("@p1", txtAd.Text); 
            komut3.Parameters.AddWithValue("@p2", numericUpDown1.Value);
            komut3.Parameters.AddWithValue("@p3", txtAlisFiyat.Text);
            komut3.Parameters.AddWithValue("@p4", txtSatisFiyat.Text);
            komut3.Parameters.AddWithValue("@p5", comboBox1.SelectedValue);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürününüz başarılı bir şekilde eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("delete from TblUrunler where UrunId =@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", txtId.Text);
            komut4.ExecuteNonQuery(); 
            baglanti.Close();
            MessageBox.Show("Ürününüz başarılı bir şekilde silindi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            numericUpDown1.Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            txtAlisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSatisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

        }

        private void btnGüncel_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("update TblUrunler set UrunAd=@p1,Stok=@p2,alisfiyat=@p3,satisFiyat=@p4,Kategori=@p5 where UrunId = @p6", baglanti);
            komut5.Parameters.AddWithValue("@p1", txtAd.Text);
            komut5.Parameters.AddWithValue("@p2", numericUpDown1.Value);
            komut5.Parameters.AddWithValue("@p3", decimal.Parse(txtAlisFiyat.Text));
            komut5.Parameters.AddWithValue("@p4", decimal.Parse(txtSatisFiyat.Text));
            komut5.Parameters.AddWithValue("@p5", comboBox1.SelectedValue);
            komut5.Parameters.AddWithValue("@p6", txtId.Text);
            komut5.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürününüz başarılı bir şekilde güncellendi","Güncelleme",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
    }
}
