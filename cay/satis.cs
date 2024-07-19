using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace cay
{
    public partial class satis : Form
    {
        public satis()
        {
            InitializeComponent();
        }
        islemler islem = new islemler();
        private void button1_Click(object sender, EventArgs e)
        {
            islem.sepete_ekle(textBox1.Text, Convert.ToInt32(textBox2.Text));
            listBox1.Items.Clear();
            for (int i = 0; i < islem.sepet.Count; i++)
            {
                if (islem.sepet[i] != "boş")
                {
                    listBox1.Items.Add(islem.sepet[i] + "x" + islem.sepet_adet[i]);
                }
            }
            textBox3.Text = islem.toplam_fiyat.ToString();
        }

        private void satis_Load(object sender, EventArgs e)
        {
            textBox2.Text = "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            islem.sepetten_cikar(textBox1.Text, Convert.ToInt32(textBox2.Text));

            listBox1.Items.Clear();
            for (int i = 0; i < islem.sepet.Count; i++)
            {
                if (islem.sepet[i] != "boş")
                {
                    listBox1.Items.Add(islem.sepet[i] + " x " + islem.sepet_adet[i]);
                }
            }
            textBox3.Text = islem.toplam_fiyat.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            islem.satis_onay(islem.sepet_id, islem.sepet ,islem.sepet_adet);
            listBox1.Items.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox2.Text = "1";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cay cay = new cay();
            cay.Show();
            this.Hide();
        }
    }
}
