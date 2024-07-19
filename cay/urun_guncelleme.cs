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
    public partial class urun_guncelleme : Form
    {
        public urun_guncelleme()
        {
            InitializeComponent();
        }
        islemler islem = new islemler();
        private void urun_guncelleme_Load(object sender, EventArgs e)
        {
            
            islem.urunler_tablo();
            dataGridView1.DataSource = islem.tablo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string marka = "";
            if(comboBox1.SelectedIndex == 0)
            {
                marka = "DOĞUŞ ÇAY";
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                marka = "LİPTON";
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                marka = "ÇAYKUR";
            }
            else { }

            islem.urun_guncelle(textBox1.Text, textBox2.Text, textBox3.Text, marka, textBox4.Text);

            urun_guncelleme_Load(sender, e);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cay cay = new cay();
            cay.Show();
            this.Hide();
        }
    }
}
