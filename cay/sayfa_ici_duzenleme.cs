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
    public partial class sayfa_ici_duzenleme : Form
    {
        public sayfa_ici_duzenleme()
        {
            InitializeComponent();
        }
        islemler islem = new islemler();
        private void sayfa_ici_duzenleme_Load(object sender, EventArgs e)
        {
            islem.sayfa_bilgiler();
            textBox1.Text = islem.hakkimizda;
            textBox2.Text = islem.tel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            islem.sayfa_bilgi_guncelle(textBox1.Text, textBox2.Text);
            sayfa_ici_duzenleme_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cay cay = new cay();
            cay.Show();
            this.Hide();
        }
    }
}
