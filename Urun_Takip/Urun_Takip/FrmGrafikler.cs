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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RR6G2VG;Initial Catalog=DbUrun;Integrated Security=True");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select ad,count(*) from TblUrunler inner join TblKategori on TblUrunler.Kategori=TblKategori.id group by ad",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Kategori"].Points.AddXY(dr[0], dr[1]);
            }
            baglanti.Close();
        }
    }
}
