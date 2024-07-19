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
    public partial class urun_ekle : Form
    {
        public urun_ekle()
        {
            InitializeComponent();
        }
        islemler islem = new islemler();
        private void button1_Click(object sender, EventArgs e)
        {
            string marka = "";
            if (comboBox1.SelectedIndex == 0)
            {
                marka = "DOĞUŞ ÇAY";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                marka = "LİPTON";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                marka = "ÇAYKUR";
            }
            else { }

            islem.urun_ekle(textBox1.Text, textBox2.Text, marka , textBox3.Text);

            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cay cay = new cay();
            cay.Show();
            this.Hide();
        }
    }
}
