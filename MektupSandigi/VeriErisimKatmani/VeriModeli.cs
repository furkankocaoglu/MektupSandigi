using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
                komut.CommandText = @"SELECT Y.YoneticiID, Y.Isim, Y.Soyisim, Y.KullaniciAdi, Y.Mail, Y.Sifre, Y.Durum, Y.Silinmis FROM YoneticilerTable AS Y WHERE Y.Mail = @mail AND Y.Sifre = @sifre";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@mail", mail);
                komut.Parameters.AddWithValue("@sifre", sifre);
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read())
                {
                    Yonetici y = new Yonetici
                    {
                        YoneticiID = okuyucu.GetInt32(0),
                        Isim = okuyucu.GetString(1),
                        Soyisim = okuyucu.GetString(2),
                        KullaniciAdi = okuyucu.GetString(3),
                        Mail = okuyucu.GetString(4),
                        Sifre = okuyucu.GetString(5),
                        Durum = okuyucu.GetBoolean(6),
                        Silinmis = okuyucu.GetBoolean(7)
                    };
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
                komut.CommandText = "INSERT INTO KategorilerTable(KategoriIsim,Durum,Silinmis) VALUES(@isim,@durum,@silinmis)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", kat.KategoriIsim);
                komut.Parameters.AddWithValue("@durum", kat.Durum);
                komut.Parameters.AddWithValue("@silinmis", kat.Silinmis);
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
        public List<Kategori> KategorileriListele()
        {
            List<Kategori> kategoriler = new List<Kategori>();

            try
            {
                komut.CommandText = "SELECT KategoriID, KategoriIsim FROM KategorilerTable WHERE Silinmis = 0";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kat = new Kategori
                    {
                        KategoriID = reader.GetInt32(0),
                        KategoriIsim = reader.GetString(1)
                    };
                    kategoriler.Add(kat);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }

            return kategoriler;
        }


        public List<Kategori> KategoriListele(bool silinmis)
        {
            List<Kategori> kategoriler = new List<Kategori>();

            try
            {
                komut.CommandText = "SELECT KategoriID, KategoriIsim, Durum, Silinmis FROM KategorilerTable WHERE Silinmis=@silinmis";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@silinmis", silinmis);
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kat = new Kategori();
                    kat.KategoriID = reader.GetInt32(0);
                    kat.KategoriIsim = reader.GetString(1);
                    kat.Durum = reader.GetBoolean(2);
                    kat.Silinmis = reader.GetBoolean(3);
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
        public List<Kategori> KategoriListele(bool silinmis, bool durum)
        {
            List<Kategori> kategoriler = new List<Kategori>();

            try
            {
                komut.CommandText = "SELECT KategoriID, KategoriIsim, Durum, Silinmis FROM KategorilerTable WHERE Silinmis=@silinmis AND Durum =@durum";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@silinmis", silinmis);
                komut.Parameters.AddWithValue("@durum", durum);
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kat = new Kategori();
                    kat.KategoriID = reader.GetInt32(0);
                    kat.KategoriIsim = reader.GetString(1);
                    kat.Durum = reader.GetBoolean(2);
                    kat.Silinmis = reader.GetBoolean(3);
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
                komut.CommandText = "DELETE FROM KategorilerTable WHERE KategoriID=@id";
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

        public void KategoriSil(int id)
        {
            try
            {
                komut.CommandText = "UPDATE KategorilerTable SET Silinmis = 1 WHERE KategoriID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");

            }
            finally
            {
                baglanti.Close();
            }
        }

        public void KategoriDurumDegistir(int id)
        {
            try
            {
                komut.CommandText = "SELECT Durum FROM KategorilerTable WHERE KategoriID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                bool durum = Convert.ToBoolean(komut.ExecuteScalar());
                komut.CommandText = "UPDATE KategorilerTable SET Durum=@durum WHERE KategoriID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@durum", !durum);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }

        public Kategori KategoriGetir(int id)
        {
            try
            {
                komut.CommandText = "SELECT KategoriID, KategoriIsim, Durum, Silinmis FROM KategorilerTable WHERE KategoriID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                Kategori kat = new Kategori();

                while (okuyucu.Read())
                {
                    kat.KategoriID = okuyucu.GetInt32(0);
                    kat.KategoriIsim = okuyucu.GetString(1);
                    kat.Durum = okuyucu.GetBoolean(2);
                    kat.Silinmis = okuyucu.GetBoolean(3);
                }
                return kat;
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

        public bool KategoriGuncelle(Kategori k)
        {
            try
            {
                komut.CommandText = "UPDATE KategorilerTable SET KategoriIsim=@isim, Durum=@durum WHERE KategoriID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", k.KategoriID);
                komut.Parameters.AddWithValue("@isim", k.KategoriIsim);
                komut.Parameters.AddWithValue("@durum", k.Durum);
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


        #endregion

        #region üyeler metodu
        public List<Uyeler> UyeListele()
        {
            List<Uyeler> uyeler = new List<Uyeler>();

            try
            {
                komut.CommandText = "SELECT KullaniciID, KullaniciAdi, Mail, Sifre, OlusturmaTarihi, Durum, Silinmis FROM KullanicilarTable ";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    Uyeler u = new Uyeler();
                    u.KullaniciID = reader.GetInt32(0);
                    u.KullaniciAdi = reader.GetString(1);
                    u.Mail = reader.GetString(2);
                    u.Sifre = reader.GetString(3);
                    u.OlusturmaTarihi = reader.GetDateTime(4);
                    u.Durum = reader.GetBoolean(5);
                    u.Silinmis = reader.GetBoolean(6);
                    uyeler.Add(u);
                }
                return uyeler;
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
        public bool UyeOl(Uyeler u)
        {
            try
            {
                komut.CommandText = "INSERT INTO KullanicilarTable(KullaniciAdi, Mail, Sifre, OlusturmaTarihi, Durum) VALUES(@kullaniciAdi, @mail, @sifre, @olusturmatarihi, @durum)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kullaniciadi", u.KullaniciAdi);
                komut.Parameters.AddWithValue("@mail", u.Mail);
                komut.Parameters.AddWithValue("@sifre", u.Sifre);
                komut.Parameters.AddWithValue("@olusturmatarihi", u.OlusturmaTarihi);
                komut.Parameters.AddWithValue("@durum", u.Durum);
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
        public Uyeler UyeGiris(string mail, string sifre)
        {
            try
            {
                Uyeler u = new Uyeler();
                komut.CommandText = "SELECT * FROM KullanicilarTable WHERE Mail = @e AND Sifre = @s";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@e", mail);
                komut.Parameters.AddWithValue("@s", sifre);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    u.KullaniciID = okuyucu.GetInt32(0);
                    u.KullaniciAdi = okuyucu.GetString(1);
                    u.Mail = okuyucu.GetString(2);
                    u.Sifre = okuyucu.GetString(3);
                    u.OlusturmaTarihi = okuyucu.GetDateTime(4);
                    u.Durum = okuyucu.GetBoolean(5);
                }
                return u;
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
        public List<Uyeler> UyeListele(bool silinmis)
        {
            List<Uyeler> Kullanicilar = new List<Uyeler>();

            try
            {
                komut.CommandText = "SELECT KullaniciID, KullaniciAdi, Mail, Sifre, OlusturmaTarihi, Durum, Silinmis FROM KullanicilarTable WHERE Silinmis=@silinmis";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@silinmis", silinmis);
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    Uyeler uye = new Uyeler();
                    uye.KullaniciID = reader.GetInt32(0);
                    uye.KullaniciAdi = reader.GetString(1);
                    uye.Mail = reader.GetString(2);
                    uye.Sifre = reader.GetString(3);
                    uye.OlusturmaTarihi = reader.GetDateTime(4);
                    uye.Durum = reader.GetBoolean(5);
                    uye.Silinmis = reader.GetBoolean(6);
                    Kullanicilar.Add(uye);
                }
                return Kullanicilar;
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
        public List<Uyeler> UyeListele(bool silinmis, bool durum)
        {
            List<Uyeler> Kullanicilar = new List<Uyeler>();

            try
            {
                komut.CommandText = "SELECT KullaniciID, KullaniciAdi, Mail, Sifre, OlusturmaTarihi, Durum, Silinmis FROM KullanicilarTable WHERE Silinmis=@silinmis AND Durum =@durum";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@silinmis", silinmis);
                komut.Parameters.AddWithValue("@durum", durum);
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    Uyeler uye = new Uyeler();
                    uye.KullaniciID = reader.GetInt32(0);
                    uye.KullaniciAdi = reader.GetString(1);
                    uye.Mail = reader.GetString(2);
                    uye.Sifre = reader.GetString(3);
                    uye.OlusturmaTarihi = reader.GetDateTime(4);
                    uye.Durum = reader.GetBoolean(5);
                    uye.Silinmis = reader.GetBoolean(6);
                    Kullanicilar.Add(uye);
                }
                return Kullanicilar;
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

        public void UyeSilHardDelete(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM KullanicilarTable WHERE KullaniciID=@id";
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

        public void UyeSil(int id)
        {
            try
            {
                komut.CommandText = "UPDATE KullanicilarTable SET Silinmis = 1 WHERE KullaniciID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");

            }
            finally
            {
                baglanti.Close();
            }
        }

        public void UyeDurumDegistir(int id)
        {
            try
            {
                komut.CommandText = "SELECT Durum FROM KullanicilarTable WHERE KullaniciID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                bool durum = Convert.ToBoolean(komut.ExecuteScalar());
                komut.CommandText = "UPDATE KullanicilarTable SET Durum=@durum WHERE KullaniciID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@durum", !durum);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }

        public Uyeler UyeGetir(int id)
        {
            try
            {
                komut.CommandText = "SELECT KullaniciID, KullaniciAdi, Durum, Silinmis FROM KullanicilarTable WHERE KullaniciID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                Uyeler uye = new Uyeler();

                while (okuyucu.Read())
                {
                    uye.KullaniciID = okuyucu.GetInt32(0);
                    uye.KullaniciAdi = okuyucu.GetString(1);
                    uye.Durum = okuyucu.GetBoolean(2);
                    uye.Silinmis = okuyucu.GetBoolean(3);
                }
                return uye;
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

        public bool UyeGuncelle(Uyeler u)
        {
            try
            {
                komut.CommandText = "UPDATE KullanicilarTable SET KullaniciAdi=@isim, Durum=@durum WHERE KullaniciID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", u.KullaniciID);
                komut.Parameters.AddWithValue("@isim", u.KullaniciAdi);
                komut.Parameters.AddWithValue("@durum", u.Durum);
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

        #endregion

        #region yorum metodu


        public bool YorumEkle(Yorumlar yorum)
        {
            try
            {
                komut.CommandText = "INSERT INTO YorumlarTable (KullaniciID, YorumIcerik, OlusturmaTarihi, Durum, Onay, Silinmis) VALUES (@kullaniciID, @yorumIcerik, @olusturmaTarihi, @durum, @onay, @silinmis)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kullaniciID", yorum.KullaniciID);
                komut.Parameters.AddWithValue("@yorumIcerik", yorum.YorumIcerik);
                komut.Parameters.AddWithValue("@olusturmaTarihi", yorum.OlusturmaTarihi);
                komut.Parameters.AddWithValue("@durum", yorum.Durum);
                komut.Parameters.AddWithValue("@onay", yorum.Onay);
                komut.Parameters.AddWithValue("@silinmis", yorum.Silinmis);
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
        public List<Yorumlar> YorumListele()
        {
            List<Yorumlar> yorumlar = new List<Yorumlar>();

            try
            {
                komut.CommandText = "SELECT YorumID, KullaniciID, YorumIcerik, OlusturmaTarihi, Onay, Durum,Silinmis FROM YorumlarTable";
                komut.Parameters.Clear();
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Yorumlar yorum = new Yorumlar
                    {
                        YorumID = okuyucu.GetInt32(0),
                        KullaniciID = okuyucu.GetInt32(1),
                        YorumIcerik = okuyucu.GetString(2),
                        OlusturmaTarihi = okuyucu.GetDateTime(3),
                        Onay = !okuyucu.IsDBNull(5) && okuyucu.GetBoolean(4),
                        Durum = !okuyucu.IsDBNull(6) && okuyucu.GetBoolean(5),
                        Silinmis = !okuyucu.IsDBNull(6) && okuyucu.GetBoolean(6)
                    };
                    yorumlar.Add(yorum);
                }
                return yorumlar;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public List<Yorumlar> YorumListele(bool silinmis)
        {
            List<Yorumlar> yorumlar = new List<Yorumlar>();

            try
            {
                komut.CommandText = "SELECT YorumID, KullaniciID, YorumIcerik, OlusturmaTarihi, Onay, Durum,Silinmis FROM YorumlarTable WHERE Silinmis=@silinmis";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@silinmis", silinmis);
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    Yorumlar yorum = new Yorumlar();
                    yorum.YorumID = reader.GetInt32(0);
                    yorum.KullaniciID = reader.GetInt32(1);
                    yorum.YorumIcerik = reader.GetString(2);
                    yorum.OlusturmaTarihi = reader.GetDateTime(3);
                    yorum.Onay = reader.GetBoolean(4);
                    yorum.Durum = reader.GetBoolean(4);
                    yorum.Silinmis = reader.GetBoolean(4);
                    yorumlar.Add(yorum);
                }
                return yorumlar;
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
        public List<Yorumlar> YorumListele(bool silinmis, bool durum)
        {
            List<Yorumlar> yorumlar = new List<Yorumlar>();

            try
            {
                komut.CommandText = "SELECT YorumID, KullaniciID, YorumIcerik, OlusturmaTarihi, Onay, Durum,Silinmis FROM YorumlarTable WHERE Silinmis=@silinmis AND Durum =@durum";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@silinmis", silinmis);
                komut.Parameters.AddWithValue("@durum", durum);
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    Yorumlar yorum = new Yorumlar();
                    yorum.YorumID = reader.GetInt32(0);
                    yorum.KullaniciID = reader.GetInt32(1);
                    yorum.YorumIcerik = reader.GetString(2);
                    yorum.OlusturmaTarihi = reader.GetDateTime(3);
                    yorum.Onay = reader.GetBoolean(4);
                    yorum.Durum = reader.GetBoolean(5);
                    yorum.Silinmis = reader.GetBoolean(6);
                    yorumlar.Add(yorum);
                }
                return yorumlar;
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

        public void YorumSilHardDelete(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM YorumlarTable WHERE YorumID=@id";
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

        public void YorumSil(int id)
        {
            try
            {
                komut.CommandText = "UPDATE YorumlarTable SET Silinmis = 1 WHERE YorumID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);


                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                komut.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                baglanti.Close();
            }
        }

        public void YorumDurumDegistir(int id)
        {
            try
            {
                komut.CommandText = "SELECT Durum FROM YorumlarTable WHERE YorumID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();

                object result = komut.ExecuteScalar();
                if (result != null && result is bool)
                {
                    bool durum = (bool)result;
                    komut.CommandText = "UPDATE YorumlarTable SET Durum=@durum WHERE YorumID = @id";
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@durum", !durum);
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                }
                else
                {

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                baglanti.Close();
            }
        }

        public Yorumlar YorumGetir(int id)
        {
            Yorumlar yorum = null;

            string sorgu = "SELECT * FROM YorumlarTable WHERE YorumID = @id AND Silinmis = 0";
            using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
            {
                komut.Parameters.AddWithValue("@id", id);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                using (SqlDataReader reader = komut.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        yorum = new Yorumlar
                        {
                            YorumID = Convert.ToInt32(reader["YorumID"]),
                            YorumIcerik = reader["YorumIcerik"].ToString(),

                        };
                    }
                }
            }

            return yorum;
        }

        public bool YorumGuncelle(Yorumlar yorum)
        {
            try
            {
                komut.CommandText = "UPDATE YorumlarTable SET YorumIcerik = @yorumIcerik WHERE YorumID = @id AND Silinmis = 0";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", yorum.YorumID);
                komut.Parameters.AddWithValue("@yorumIcerik", yorum.YorumIcerik);

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                return komut.ExecuteNonQuery() > 0;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public bool YorumGuncelleme(Yorumlar yorum)
        {
            try
            {
                komut.CommandText = "UPDATE YorumlarTable SET Onay = @onay WHERE YorumID = @id AND Silinmis = 0";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", yorum.YorumID);
                komut.Parameters.AddWithValue("@onay", yorum.Onay);

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                int result = komut.ExecuteNonQuery();
                return result > 0;
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
        public void YorumOnayla(int id)
        {
            try
            {
                komut.CommandText = "UPDATE YorumlarTable SET Onay = 1 WHERE YorumID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                komut.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                baglanti.Close();
            }
        }
        public List<Yorumlar> UyeYorumListele(bool sadeceOnayli)
        {
            List<Yorumlar> yorumlar = new List<Yorumlar>();

            string sorgu = "SELECT YorumID, KullaniciID, YorumIcerik, OlusturmaTarihi, Onay, Durum, Silinmis FROM YorumlarTable";
            if (sadeceOnayli)
            {
                sorgu += " WHERE Onay = 1 AND Silinmis = 0";
            }

            try
            {
                komut.CommandText = sorgu;
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    Yorumlar yorum = new Yorumlar
                    {
                        YorumID = reader.GetInt32(0),
                        KullaniciID = reader.GetInt32(1),
                        YorumIcerik = reader.GetString(2),
                        OlusturmaTarihi = reader.GetDateTime(3),
                        Onay = reader.GetBoolean(4),
                        Durum = reader.GetBoolean(5),
                        Silinmis = reader.GetBoolean(6)
                    };
                    yorumlar.Add(yorum);
                }
                return yorumlar;
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

        #region destek talep metodu
        public bool TalepEkle(DestekTalep talep)
        {
            try
            {
                komut.CommandText = "INSERT INTO DesteklerTable (KullaniciID, Baslik, Icerik) VALUES (@kullaniciID, @baslik, @icerik)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kullaniciID", talep.KullaniciID);
                komut.Parameters.AddWithValue("@baslik", talep.Baslik);
                komut.Parameters.AddWithValue("@icerik", talep.Icerik);
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
        public List<DestekTalep> TumTalepleriGetir()
        {
            List<DestekTalep> talepler = new List<DestekTalep>();

            try
            {
                komut.CommandText = "SELECT DestekID, KullaniciID, Baslik, Icerik FROM DesteklerTable";
                komut.Parameters.Clear();
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    DestekTalep talep = new DestekTalep
                    {
                        DestekID = okuyucu.GetInt32(0),
                        KullaniciID = okuyucu.GetInt32(1),
                        Baslik = okuyucu.GetString(2),
                        Icerik = okuyucu.GetString(3)

                    };
                    talepler.Add(talep);
                }
                return talepler;
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

        #region mektup metodu

        public bool MektupEkle(Mektup mektup)
        {
            try
            {
                
                DateTime today = DateTime.Today;

                
                if (string.IsNullOrWhiteSpace(mektup.AliciMail))
                {
                    Console.WriteLine("Alici mail adresi boş olamaz.");
                    return false;
                }

                
                if (mektup.AcilisTarihi < today)
                {
                    Console.WriteLine("Hata: Açılış tarihi geçmiş bir tarih olamaz.");
                    return false;
                }

               
                komut.CommandText = @"
            INSERT INTO MektuplarTable (KullaniciID, KategoriID, Baslik, Icerik, AliciMail, AcilisTarihi, TeslimEdildiMi, OlusturmaTarihi) 
            OUTPUT INSERTED.MektupID 
            VALUES (@kullaniciID, @kategoriID, @baslik, @icerik, @aliciMail, @acilisTarihi, 0, @olusturmaTarihi)";

                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kullaniciID", mektup.KullaniciID);
                komut.Parameters.AddWithValue("@kategoriID", mektup.KategoriID);
                komut.Parameters.AddWithValue("@baslik", mektup.Baslik);
                komut.Parameters.AddWithValue("@icerik", mektup.Icerik); 
                komut.Parameters.AddWithValue("@aliciMail", mektup.AliciMail);
                komut.Parameters.AddWithValue("@acilisTarihi", mektup.AcilisTarihi);
                komut.Parameters.AddWithValue("@olusturmaTarihi", DateTime.Now);

                baglanti.Open();
                int mektupID = (int)komut.ExecuteScalar();

                
                string mailIcerik = mektup.AcilisTarihi.Date == today
                    ? " " +
                      $"<a href='https://localhost:44396/MektupGoruntule.aspx?mektupID={mektupID}'>Link</a>"
                    : mektup.Icerik;

                
                MailGonder(mektup.AliciMail, mektup.Baslik, mailIcerik, mektupID, mektup.AcilisTarihi);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mektup eklenirken bir hata oluştu: " + ex.Message);
                return false;
            }
            finally
            {
                baglanti.Close();
            }
        }


        public List<Mektup> GetMektuplar()
        {
            List<Mektup> mektuplar = new List<Mektup>();

            try
            {
                komut = new SqlCommand("SELECT MektupID, KullaniciID, KategoriID, Baslik, Icerik, AliciMail, AcilisTarihi, TeslimEdildiMi, OlusturmaTarihi FROM MektuplarTable", baglanti);
                komut.Parameters.Clear();
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Mektup mktp = new Mektup
                    {
                        MektupID = okuyucu.GetInt32(0),
                        KullaniciID = okuyucu.GetInt32(1),
                        KategoriID = okuyucu.GetInt32(2),
                        Baslik = okuyucu.GetString(3),
                        Icerik = okuyucu.GetString(4),
                        AliciMail = okuyucu.GetString(5),
                        AcilisTarihi = okuyucu.GetDateTime(6),
                        TeslimEdildiMi = okuyucu.GetBoolean(7),
                        OlusturmaTarihi = okuyucu.GetDateTime(8)
                    };
                    mektuplar.Add(mktp);
                }
                return mektuplar;
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
        public void MailGonder(string aliciMail, string baslik, string icerik, int mektupID, DateTime acilisTarihi)
        {
            try
            {

                string gondericiMail = "mektupsandigi@stafftrackportal.com";
                string gondericiSifre = "T_2lH@vK==47rM7h";


                SmtpClient smtpClient = new SmtpClient("mail.stafftrackportal.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(gondericiMail, gondericiSifre),
                    EnableSsl = false
                };
                string link = $"https://localhost:44396/MektupGoruntule.aspx?mektupID={mektupID}";
                string htmlIcerik;
                if (acilisTarihi.Date == DateTime.Today)
                {
                    
                    htmlIcerik = $"<html><body><h2>{baslik}</h2><p><a href='{link}'>Mektubu görüntülemek için buraya tıklayın</a></p></body></html>";

                }
                else
                {
                    
                    htmlIcerik = $"<html><body><h2>{baslik}</h2><p>{icerik}</p><p><a href='{link}'>Mektubu görüntülemek için buraya tıklayın</a></p></body></html>";
                }
                if (acilisTarihi > DateTime.Now)
                {
                    htmlIcerik = $"<html><body><h2>{baslik}</h2><p>Mektup {acilisTarihi.ToString("dd/MM/yyyy HH:mm")} tarihinde açılacaktır.</p><p><a href='{link}'>Mektubu görüntülemek için buraya tıklayın</a></p></body></html>";
                }
                else
                {
                    htmlIcerik = $"<html><body><h2>{baslik}</h2><p>{icerik}</p><p><a href='{link}'>Mektubu görüntülemek için buraya tıklayın</a></p></body></html>";
                }

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(gondericiMail),
                    Subject = baslik,
                    Body = htmlIcerik,
                    IsBodyHtml = true
                };
                mail.To.Add(aliciMail);
                smtpClient.Send(mail);
                Console.WriteLine("Mail başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mail gönderimi sırasında hata oluştu: " + ex.Message);
            }

        }
        public void UpdateTeslimEdildi(int mektupID)
        {
            try
            {
                komut.CommandText = "UPDATE MektuplarTable SET TeslimEdildiMi = 1 WHERE MektupID = @mektupID";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@mektupID", mektupID);

                baglanti.Open();
                int rowsAffected = komut.ExecuteNonQuery(); 

                if (rowsAffected == 0)
                {
                    Console.WriteLine("Güncellenen kayıt yok."); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Güncelleme sırasında hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
        public Mektup GetMektupByID(int mektupID)
        {
            Mektup mektup = null;

            try
            {
                komut.CommandText = "SELECT MektupID, KullaniciID, KategoriID, Baslik, Icerik, AliciMail, AcilisTarihi, TeslimEdildiMi, OlusturmaTarihi FROM MektuplarTable WHERE MektupID = @mektupID";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@mektupID", mektupID);

                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read())
                {
                    mektup = new Mektup
                    {
                        MektupID = okuyucu.GetInt32(0),
                        KullaniciID = okuyucu.GetInt32(1),
                        KategoriID = okuyucu.GetInt32(2),
                        Baslik = okuyucu.GetString(3),
                        Icerik = okuyucu.GetString(4),
                        AliciMail = okuyucu.GetString(5),
                        AcilisTarihi = okuyucu.GetDateTime(6),
                        TeslimEdildiMi = okuyucu.GetBoolean(7),
                        OlusturmaTarihi = okuyucu.GetDateTime(8)
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mektup bilgileri alınırken hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }

            return mektup;
        }
        public List<Mektup> GetOkunanMektuplar(int kullaniciID)
        {
            List<Mektup> mektuplar = new List<Mektup>();

            try
            {
                komut = new SqlCommand("SELECT * FROM MektuplarTable WHERE KullaniciID = @kullaniciID AND TeslimEdildiMi = 1", baglanti);
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Mektup mktp = new Mektup
                    {
                        MektupID = okuyucu.GetInt32(0),
                        KullaniciID = okuyucu.GetInt32(1),
                        KategoriID = okuyucu.GetInt32(2),
                        Baslik = okuyucu.GetString(3),
                        Icerik = okuyucu.GetString(4),
                        AliciMail = okuyucu.GetString(5),
                        AcilisTarihi = okuyucu.GetDateTime(6),
                        TeslimEdildiMi = okuyucu.GetBoolean(7),
                        OlusturmaTarihi = okuyucu.GetDateTime(8)
                    };
                    mektuplar.Add(mktp);
                }
                return mektuplar;
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

        #region üyelik paneli metodu
        public Uyeler UyeBilgisiGetir(int kullaniciID)
        {
            try
            {
                komut.CommandText = "SELECT KullaniciID, KullaniciAdi, Mail, Sifre, OlusturmaTarihi, Durum, Silinmis FROM KullanicilarTable WHERE KullaniciID = @kullaniciID";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kullaniciID", kullaniciID);

                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                Uyeler uye = null;

                if (okuyucu.Read())
                {
                    uye = new Uyeler
                    {
                        KullaniciID = okuyucu.GetInt32(0),
                        KullaniciAdi = okuyucu.GetString(1),
                        Mail = okuyucu.GetString(2),
                        Sifre = okuyucu.GetString(3),
                        OlusturmaTarihi = okuyucu.GetDateTime(4),
                        Durum = okuyucu.GetBoolean(5),
                        Silinmis = okuyucu.IsDBNull(6) ? false : okuyucu.GetBoolean(6)
                    };
                }
                return uye;
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
        public List<Yorumlar> KullaniciYorumlariniGetir(int kullaniciID)
        {
            List<Yorumlar> yorumlar = new List<Yorumlar>();

            string sorgu = "SELECT * FROM YorumlarTable WHERE KullaniciID = @kullaniciID AND Silinmis = 0";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@kullaniciID", kullaniciID);

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            SqlDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                Yorumlar yorum = new Yorumlar
                {
                    YorumID = Convert.ToInt32(reader["YorumID"]),
                    KullaniciID = Convert.ToInt32(reader["KullaniciID"]),
                    YorumIcerik = reader["YorumIcerik"].ToString(),
                    OlusturmaTarihi = Convert.ToDateTime(reader["OlusturmaTarihi"]),
                    Durum = Convert.ToBoolean(reader["Durum"]),
                    Silinmis = Convert.ToBoolean(reader["Silinmis"])
                };
                yorumlar.Add(yorum);
            }

            return yorumlar;
        }
        public List<Mektup> KullaniciMektuplariniGetir(int kullaniciID)
        {
            List<Mektup> mektuplar = new List<Mektup>();

            try
            {
                komut.CommandText = "SELECT MektupID, KategoriID, Baslik, Icerik, AliciMail,  AcilisTarihi, TeslimEdildiMi, OlusturmaTarihi FROM MektuplarTable WHERE KullaniciID = @kullaniciID";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kullaniciID", kullaniciID);

                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Mektup mektup = new Mektup
                    {
                        MektupID = okuyucu.GetInt32(0),
                        KategoriID = okuyucu.GetInt32(1),
                        Baslik = okuyucu.GetString(2),
                        Icerik = okuyucu.GetString(3),
                        AliciMail = okuyucu.GetString(4),
                        AcilisTarihi = okuyucu.GetDateTime(5),
                        TeslimEdildiMi = okuyucu.GetBoolean(6),
                        OlusturmaTarihi = okuyucu.GetDateTime(7)
                    };
                    mektuplar.Add(mektup);
                }
                return mektuplar;
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
        public void YorumEkle(int kullaniciID, int mektupID, string yorumIcerik)
        {
            try
            {
                komut.CommandText = "INSERT INTO YorumlarTable (KullaniciID, MektupID, YorumIcerik, OlusturmaTarihi) VALUES (@kullaniciID, @mektupID, @yorumIcerik, @olusturmaTarihi)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                komut.Parameters.AddWithValue("@mektupID", mektupID);
                komut.Parameters.AddWithValue("@yorumIcerik", yorumIcerik);
                komut.Parameters.AddWithValue("@olusturmaTarihi", DateTime.Now);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                System.IO.File.AppendAllText("C:\\path_to_log\\HataLog.txt",
                    DateTime.Now + ": " + ex.Message + Environment.NewLine);
                throw;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void YorumSilme(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM YorumlarTable WHERE YorumID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                System.IO.File.AppendAllText("C:\\path_to_log\\HataLog.txt",
                    DateTime.Now + ": " + ex.Message + Environment.NewLine);
                throw;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public void YorumDuzenle(int id, string yeniIcerik)
        {
            try
            {
                komut.CommandText = "UPDATE YorumlarTable SET YorumIcerik = @yeniIcerik WHERE YorumID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@yeniIcerik", yeniIcerik);
                komut.Parameters.AddWithValue("@id", id);

                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                System.IO.File.AppendAllText("C:\\path_to_log\\HataLog.txt",
                    DateTime.Now + ": " + ex.Message + Environment.NewLine);
                throw;
            }
            finally
            {
                baglanti.Close();
            }
        }




        #endregion
    }
}
