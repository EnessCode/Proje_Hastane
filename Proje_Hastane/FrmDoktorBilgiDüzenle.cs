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

namespace Proje_Hastane
{
    public partial class FrmDoktorBilgiDüzenle : Form
    {
        public FrmDoktorBilgiDüzenle()
        {
            InitializeComponent();
        }
        sqlbağlantısı bgl=new sqlbağlantısı();
        public string TCno;
        private void FrmDoktorBilgiDüzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text=TCno;

            SqlCommand komut = new SqlCommand("Select * from Tbl_Doktorlar where DoktorTC=@p1", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1",mskTC.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while(dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                cmbBranş.Text = dr[3].ToString();
                txtSifre.Text = dr[5].ToString(); 
            }
            bgl.baglantı().Close();
        }

        private void buttonBilgiGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutgüncelle = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTC=@p5", bgl.baglantı());
            komutgüncelle.Parameters.AddWithValue("@p1",txtAd.Text);
            komutgüncelle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komutgüncelle.Parameters.AddWithValue("@p3",cmbBranş.Text);
            komutgüncelle.Parameters.AddWithValue("@p4",txtSifre.Text);
            komutgüncelle.Parameters.AddWithValue("@p5",mskTC.Text);
            komutgüncelle.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Kayıt Güncellendi");
        }
    }
}
