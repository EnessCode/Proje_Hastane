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
    public partial class FrmHastaGiriş : Form
    {
        public FrmHastaGiriş()
        {
            InitializeComponent();
        }

        sqlbağlantısı bgl=new sqlbağlantısı();
        private void FrmHastaGiriş_Load(object sender, EventArgs e)
        {

        }

        private void lnkÜyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayıt fr=new FrmHastaKayıt();
            fr.Show();
            this.Hide();
        }

        private void btnGirişYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                FrmHastaDetay fr=new FrmHastaDetay();
                fr.kimlikno=mskTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC & şifre!");
            }
            bgl.baglantı().Close();
        }
    }
}
