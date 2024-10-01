using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class VeriModeli
    {
        SqlConnection baglanti; SqlCommand komut;

        public VeriModeli()
        {
            baglanti = new SqlConnection(BaglantiYollari.baglantiYolu);
            komut = baglanti.CreateCommand();
        }

        #region yönetici metodu
        public Yonetici YoneticiGiris(string mail, string sifre)
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM YoneticilerTable WHERE Mail = @mail AND Sifre = @sifre";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@mail", mail);
                komut.Parameters.AddWithValue("@sifre", sifre);
                baglanti.Open();

                int sayi = Convert.ToInt32(komut.ExecuteScalar());
                if (sayi == 1)
                {
                    komut.CommandText = @"SELECT Y.YoneticiID, Y.Isim, Y.Soyisim, Y.KullaniciAdi, Y.Mail, Y.Sifre, Y.Durum, Y.Silinmis 
                                  FROM YoneticilerTable AS Y 
                                  WHERE Y.Mail = @mail AND Y.Sifre = @sifre";
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@mail", mail);
                    komut.Parameters.AddWithValue("@sifre", sifre);
                    SqlDataReader okuyucu = komut.ExecuteReader();
                    Yonetici y = new Yonetici();
                    while (okuyucu.Read())
                    {
                        y.YoneticiID = okuyucu.GetInt32(0);
                        y.Isim = okuyucu.GetString(1);
                        y.Soyisim = okuyucu.GetString(2);
                        y.KullaniciAdi = okuyucu.GetString(3);
                        y.Mail = okuyucu.GetString(4);
                        y.Sifre = okuyucu.GetString(5);
                        y.Durum = okuyucu.GetBoolean(6);
                        y.Silinmis = okuyucu.GetBoolean(7);
                    }
                    return y;
                }
                else
                {
                    return null; 
                }
            }
            catch
            {
                return null; 
            }
            finally
            {
                baglanti.Close(); 
            }
        }
        #endregion

        #region kategori metodu
        public bool KategoriEkle(Kategori kat)
        {
            try
            {
                komut.CommandText = "INSERT INTO KategorilerTable(KategoriIsim) VALUES(@isim)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", kat.KategoriIsim);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public List<Kategori> KategoriListele()
        {
            List<Kategori> kategoriler = new List<Kategori>();

            try
            {
                komut.CommandText = "SELECT ID, Isim FROM KategorilerTable ";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kat = new Kategori();
                    kat.KategoriID = reader.GetInt32(0);
                    kat.KategoriIsim = reader.GetString(1);
                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void KategoriSilHardDelete(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM KategorilerTable WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }


        #endregion
    }
}
