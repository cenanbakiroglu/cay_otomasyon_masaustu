using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cay
{
    public partial class cay : Form
    {
        public cay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           urun_guncelleme guncelle = new urun_guncelleme();
            guncelle.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            urun_ekle ekle = new urun_ekle();
            ekle.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            siparisler siparis = new siparisler();
            siparis.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sayfa_ici_duzenleme sayfa = new sayfa_ici_duzenleme();
            sayfa.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            satis sat = new satis();
            sat.Show();
            this.Hide();
        }
    }
}
