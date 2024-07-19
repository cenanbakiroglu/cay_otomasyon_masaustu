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
    public partial class siparisler : Form
    {
        public siparisler()
        {
            InitializeComponent();
        }
        islemler islem = new islemler();
        private void siparisler_Load(object sender, EventArgs e)
        {
            islem.siparisler_tablo();
            
            foreach (DataRow row in islem.tablo.Rows)
            {
                string siparisler = row["siparisler"].ToString();
                string duzenlenmisSiparisler = siparisler.Replace("\n", Environment.NewLine);
                row["siparisler"] = duzenlenmisSiparisler;
            }
            dataGridView1.DataSource = islem.tablo;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
           
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            islem.siparis("teslim", textBox1.Text);
            siparisler_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            islem.siparis("iptal", textBox1.Text);
            siparisler_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cay cay = new cay();
            cay.Show();
            this.Hide();
        }
    }

}
