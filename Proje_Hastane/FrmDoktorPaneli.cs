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
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }
        sqlbağlantısı bgl=new sqlbağlantısı();
        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Tbl_Doktorlar", bgl.baglantı());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //Branşları comboboxa çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd from Tbl_Branslar", bgl.baglantı());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBranş.Items.Add(dr2[0].ToString());
            }
            bgl.baglantı().Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komutekle = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglantı());
            komutekle.Parameters.AddWithValue("@p1", txtAd.Text);
            komutekle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komutekle.Parameters.AddWithValue("@p3", cmbBranş.Text);
            komutekle.Parameters.AddWithValue("@p4", mskTC.Text);
            komutekle.Parameters.AddWithValue("@p5", txtSifre.Text);
            komutekle.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Doktor Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbBranş.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Doktorlar where DoktorTC=@p1",bgl.baglantı());
            komutsil.Parameters.AddWithValue("@p1",mskTC.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Kayıt Silindi!","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutgüncelle = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p5 where DoktorTC=@p4", bgl.baglantı());
            komutgüncelle.Parameters.AddWithValue("@p1", txtAd.Text);
            komutgüncelle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komutgüncelle.Parameters.AddWithValue("@p3", cmbBranş.Text);
            komutgüncelle.Parameters.AddWithValue("@p4", mskTC.Text);
            komutgüncelle.Parameters.AddWithValue("@p5", txtSifre.Text);
            komutgüncelle.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Doktor Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
