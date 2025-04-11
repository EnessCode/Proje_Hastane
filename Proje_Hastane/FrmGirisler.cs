using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmGirisler : Form
    {
        public FrmGirisler()
        {
            InitializeComponent();
        }

        private void btnHasta_Click(object sender, EventArgs e)
        {
            FrmHastaGiriş fr = new FrmHastaGiriş();
            fr.Show();
            this.Hide();
        }

        private void btnDoktorGirişi_Click(object sender, EventArgs e)
        {
            FrmDoktorGiriş fr = new FrmDoktorGiriş();
            fr.Show();
            this.Hide();
        }

        private void btnSekreterGirişi_Click(object sender, EventArgs e)
        {
            FrmSekreterGiriş fr=new FrmSekreterGiriş();
            fr.Show();
            this.Hide();
        }
    }
}
