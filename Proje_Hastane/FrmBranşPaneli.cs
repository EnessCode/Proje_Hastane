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
    public partial class FrmBranşPaneli : Form
    {
        public FrmBranşPaneli()
        {
            InitializeComponent();
        }

        sqlbağlantısı bgl=new sqlbağlantısı();
        private void FrmBranşPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt=new DataTable();
            SqlDataAdapter da=new SqlDataAdapter("Select * from Tbl_Branslar",bgl.baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komutekle= new SqlCommand("insert into Tbl_Branslar (BransAd) values (@p1)",bgl.baglantı());
            komutekle.Parameters.AddWithValue("@p1",txtBranş.Text);
            komutekle.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Branş Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtBranşid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBranş.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Branslar where BransAd=@p1", bgl.baglantı());
            komutsil.Parameters.AddWithValue("@p1", txtBranş.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Branş Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutgüncelle = new SqlCommand("Update Tbl_Branslar set Bransad=@p1 where Bransid=@p2", bgl.baglantı());
            komutgüncelle.Parameters.AddWithValue("@p1", txtBranş.Text);
            komutgüncelle.Parameters.AddWithValue("@p2", txtBranşid.Text);
            komutgüncelle.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Branş Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
