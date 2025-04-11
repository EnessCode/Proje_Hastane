using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class FrmBilgiDüzenle : Form
    {
        public FrmBilgiDüzenle()
        {
            InitializeComponent();
        }
        public string TCno;
        sqlbağlantısı bgl=new sqlbağlantısı();
        private void FrmBilgiDüzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = TCno;
            SqlCommand komut = new SqlCommand("Select * from Tbl_Hastalar where HastaTC=@p1", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            SqlDataReader dr= komut.ExecuteReader();
            while (dr.Read()) 
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                mskTelno.Text = dr[4].ToString(); 
                txtSifre.Text = dr[5].ToString();
                cmbCinsiyet.Text = dr[6].ToString();
            }
            bgl.baglantı().Close();
        }

        private void buttonBilgiGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutgüncelle = new SqlCommand("Update Tbl_Hastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTC=@p6", bgl.baglantı());
            komutgüncelle.Parameters.AddWithValue("@p1",txtAd.Text);   
            komutgüncelle.Parameters.AddWithValue("@p2",txtSoyad.Text);
            komutgüncelle.Parameters.AddWithValue("@p3", mskTelno.Text);
            komutgüncelle.Parameters.AddWithValue("@p4", txtSifre.Text);
            komutgüncelle.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
            komutgüncelle.Parameters.AddWithValue("@p6", mskTC.Text);
            komutgüncelle .ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
    }
}
