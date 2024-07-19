using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cay
{
    internal class islemler
    {
        MySqlConnection bag= new MySqlConnection(veritabni_baglanti.bag);
        MySqlCommand komut= new MySqlCommand();
        MySqlDataReader oku;
        MySqlDataAdapter adapter;
        public DataTable tablo;


        public int giris_kontrol = 0;
        public void giris(string kullanici_adi,string sifre)
        {
            bag.Open();
            komut.CommandText="SELECT * FROM adminler WHERE kullanici_adi='"+kullanici_adi+"'";
            komut.Connection = bag;
            oku = komut.ExecuteReader();
            if(oku.Read()==true )
            {
                if (oku["sifre"].ToString() == sifre)
                {
                    giris_kontrol = 1;
                }
                else
                {
                    MessageBox.Show("Şifreniz hatalı");
                }

            }
            else
            {
                MessageBox.Show("Admin kaydı bulunamadı");
            }
            bag.Close();    
        }
        public void urunler_tablo()
        {

            bag.Open();
            adapter = new MySqlDataAdapter("select * from urunler ", bag);
            tablo = new DataTable("veriler");
            adapter.Fill(tablo);
            bag.Close();


        }

        public void urun_guncelle(string id,string ad,string stok,string marka,string fiyat)
        {
            if (id.Length == 0 || ad.Length == 0 || stok.Length == 0 || marka.Length == 0 || fiyat.Length == 0)
            {
                MessageBox.Show("Tüm alanalrı doldurunuz lütfen");
            }
            else
            {


                bag.Open();
                komut.Connection = bag;
                komut.CommandText = "UPDATE urunler SET ad='" + ad + "',marka='" + marka + "',stok=" + stok + ",fiyat=" + fiyat + " WHERE id=" + id;
                komut.ExecuteNonQuery();
                bag.Close();

            }
        }
        public void urun_ekle(string ad, string stok, string marka, string fiyat)
        {
            if (ad.Length == 0 || stok.Length == 0 || marka.Length == 0 || fiyat.Length == 0)
            {
                MessageBox.Show("Tüm alanalrı doldurunuz lütfen");
            }
            else
            {


                bag.Open();
                komut.Connection = bag;
                komut.CommandText = "INSERT INTO urunler VALUES(null,'" + ad + "'," + stok + ",'" + marka + "'," + fiyat + ")";
                int kontrol=komut.ExecuteNonQuery();
                if (kontrol > 0)
                {
                    MessageBox.Show("Ürün kaydı başarılı");
                }
                bag.Close();

            }
        }

        public void siparisler_tablo()
        {
            bag.Open();
            adapter = new MySqlDataAdapter("SELECT siparisler.musteri_id AS 'SİPARİŞ ID',\r\n       uyeler.ad AS 'MÜŞTERİ AD',\r\n       uyeler.soyad AS 'MÜŞTERİ SOYAD',\r\n       uyeler.adres AS 'MÜŞTERİ ADRES',\r\n       uyeler.telefon AS 'MÜŞTERİ TELEFON',\r\n       GROUP_CONCAT(CONCAT(urunler.marka, ' ', urunler.ad, '(', siparisler.adet, ' adet)') SEPARATOR '\\n') AS siparisler\r\nFROM uyeler\r\nJOIN siparisler ON uyeler.id = siparisler.musteri_id\r\nJOIN urunler ON urunler.id = siparisler.urun_id\r\nWHERE siparisler.durum = 'aktif'\r\nGROUP BY uyeler.ad, uyeler.soyad, uyeler.adres;\r\n", bag);
            tablo = new DataTable("veriler");
            adapter.Fill(tablo);
            bag.Close();
        }
        public void siparis(string veri,string id)
        {
            if (id.Length > 0)
            {
                bag.Open();
                komut.Connection = bag;
                komut.CommandText = "UPDATE siparisler SET durum='" + veri + "' WHERE musteri_id=" + id;
                int kontrol = komut.ExecuteNonQuery();
                if (kontrol > 0)
                {
                    MessageBox.Show("İşlem başarılı");
                }
                bag.Close();
            }
            else
            {
                MessageBox.Show("ID bilgisi giriniz lütfen");
            }
        }
        public string hakkimizda, tel;
        public void sayfa_bilgiler()
        {
            bag.Open() ;
            komut.Connection= bag;
            komut.CommandText = "SELECT * FROM icerik where id=1";
            oku = komut.ExecuteReader();
            if(oku.Read()==true)
            {
                hakkimizda = oku["hakkimizda"].ToString();
                tel = oku["iletisim"].ToString();
            }
            bag.Close();
        }

        public void sayfa_bilgi_guncelle(string hakkimizda,string tel)
        {
            bag.Open();
            komut.Connection = bag;
            komut.CommandText = "UPDATE icerik SET hakkimizda='"+hakkimizda+"',iletisim='"+tel+"' WHERE id=1";
            int kontrol=komut.ExecuteNonQuery();
            if(kontrol > 0)
            
            {
                MessageBox.Show("Güncelleme Başarılı");
            }
            bag.Close();
        }

        public List<string> sepet = new List<string>();
        public List<string> sepet_id = new List<string>();
        public List<int> sepet_adet = new List<int>();
        public double toplam_fiyat = 0;
        string fiyat = "0";
        public void sepete_ekle(string id, int adet)
        {
            giris_kontrol = 0;
            bag.Open();
            komut.CommandText = "SELECT * FROM urunler WHERE id=" + id;
            komut.Connection = bag;
            oku = komut.ExecuteReader();
            if (oku.Read() == true)
            {
                fiyat = oku["fiyat"].ToString();
                for (int i = 0; i < sepet.Count; i++)
                {
                    if (sepet[i] == oku["marka"].ToString() + " " + oku["ad"].ToString())
                    {
                        sepet_adet[i] += adet;
                        toplam_fiyat = toplam_fiyat + (adet * Convert.ToDouble(fiyat));
                        giris_kontrol = 1;
                    }
                }
                if (giris_kontrol != 1)
                {
                    sepet.Add(oku["marka"].ToString()+" "+ oku["ad"].ToString());
                    sepet_adet.Add(adet);
                    sepet_id.Add(id);
                    toplam_fiyat = toplam_fiyat + (adet * Convert.ToDouble(fiyat));
                }

            }
            bag.Close();
        }

        public void sepetten_cikar(string id, int adet)
        {
            bag.Open();
            komut.CommandText = "SELECT * FROM urunler WHERE id=" + id;
            komut.Connection = bag;
            oku = komut.ExecuteReader();
            if (oku.Read() == true)
            {
                for (int i = 0; i < sepet.Count; i++)
                {
                    if (sepet[i] == oku["marka"].ToString() + " " + oku["ad"].ToString())
                    {
                        fiyat = oku["fiyat"].ToString();
                        sepet_adet[i] -= adet;

                        if (sepet_adet[i] <= 0)
                        {
                            sepet[i] = "boş";
                            sepet_adet[i] = 0;
                        }
                        toplam_fiyat = toplam_fiyat - (adet * Convert.ToDouble(fiyat));
                    }
                }
            }
            bag.Close();
        }

        public void satis_onay(List<string> id, List<string> urunler, List<int> adet)
        {
            bag.Open();
            for (int i = 0; i < sepet.Count; i++)
            {
                if (urunler[i] != "boş")
                {
                    komut.CommandText = "UPDATE urunler SET stok = stok -" + adet[i] + " WHERE id = \"" + id[i] + "\"";
                    komut.Connection = bag;
                    komut.ExecuteNonQuery();
                }
            }
            bag.Close();
            sepet.Clear();
            sepet_adet.Clear();
            sepet_id.Clear();
            toplam_fiyat = 0;
        }


    }
}
