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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        islemler islem = new islemler();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                islem.giris(textBox1.Text, textBox2.Text);

                if (islem.giris_kontrol == 1)
                {
                    cay cay = new cay();
                    cay.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Boş alan bırakmayınız");
            }
        }
    }
}
