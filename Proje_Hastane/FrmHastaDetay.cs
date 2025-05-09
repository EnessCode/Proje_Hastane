﻿using System;
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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        public string kimlikno;

        sqlbağlantısı bgl=new sqlbağlantısı();

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = kimlikno;
            //Ad Soyad çekme
            SqlCommand komut=new SqlCommand("Select HastaAd,HastaSoyad from Tbl_Hastalar where HastaTC=@p1",bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while(dr.Read())
            {
                lblAdSoyad.Text = dr[0] +" "+ dr[1];
            }
            bgl.baglantı().Close();

            //Randevu geçmiş
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where HastaTC=" + kimlikno, bgl.baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Branş çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd from Tbl_Branslar", bgl.baglantı());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                cmbBranş.Items.Add(dr2[0]);
            }
            bgl.baglantı().Close();
        }

        private void cmbBranş_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();

            SqlCommand komut3 = new SqlCommand("Select DoktorAd, DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglantı());
            komut3.Parameters.AddWithValue("@p1", cmbBranş.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read()) 
            {
                cmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            bgl.baglantı() .Close();
        }
        
        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where RandevuBrans='" + cmbBranş.Text + "'" + " and RandevuDoktor='" + cmbDoktor.Text + "'and RandevuDurum=0", bgl.baglantı());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void lnkBilgiDüzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDüzenle fr=new FrmBilgiDüzenle();
            fr.TCno = lblTC.Text;
            fr.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Randevular set RandevuDurum=1,HastaTC=@p1,HastaSikayet=@p2 where Randevuid=@p3", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1",lblTC.Text);
            komut.Parameters.AddWithValue("@p2",rtbŞikayet.Text);
            komut.Parameters.AddWithValue("@p3",txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Randevu Alındı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
