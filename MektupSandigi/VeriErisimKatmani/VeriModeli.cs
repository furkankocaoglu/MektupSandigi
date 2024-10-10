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


        public void KategoriSilHardDelete(int id)
        {
            try
            {

                komut.CommandText = "DELETE FROM KategorilerTable WHERE KategoriID = @id";
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

        #region üyeler metodu
        public List<Uyeler> TumUyeleriGetir()
        {
            List<Uyeler> uyeler = new List<Uyeler>();
            try
            {
                komut.CommandText = "SELECT KullaniciID, KullaniciAdi, Mail, Sifre, OlusturmaTarihi, Durum FROM KullanicilarTable";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Uyeler u = new Uyeler();
                    u.KullaniciID = okuyucu.GetInt32(0);
                    u.KullaniciAdi = okuyucu.GetString(1);
                    u.Mail = okuyucu.GetString(2);
                    u.Sifre = okuyucu.GetString(3);
                    u.OlusturmaTarihi = okuyucu.GetDateTime(4);
                    u.Durum = okuyucu.GetBoolean(5);
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

        #endregion

        #region yorum metodu

        public bool YorumEkle(Yorumlar yorum)
        {
            try
            {
                komut.CommandText = "INSERT INTO YorumlarTable (MektupID, KullaniciID, YorumIcerik, OlusturmaTarihi, Durum, Onay) VALUES (@mektupID, @kullaniciID, @yorumIcerik, @olusturmaTarihi, @durum, @onay)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@mektupID", yorum.MektupID);
                komut.Parameters.AddWithValue("@kullaniciID", yorum.KullaniciID);
                komut.Parameters.AddWithValue("@yorumIcerik", yorum.YorumIcerik);
                komut.Parameters.AddWithValue("@olusturmaTarihi", yorum.OlusturmaTarihi);
                komut.Parameters.AddWithValue("@durum", yorum.Durum);
                komut.Parameters.AddWithValue("@onay", yorum.Onay);
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
        public List<Yorumlar> TumYorumlariGetir()
        {
            List<Yorumlar> yorumlar = new List<Yorumlar>();

            try
            {
                komut.CommandText = "SELECT YorumID, MektupID, KullaniciID, YorumIcerik, OlusturmaTarihi, Onay, Durum FROM YorumlarTable";
                komut.Parameters.Clear();
                baglanti.Open();

                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Yorumlar yorum = new Yorumlar
                    {
                        YorumID = okuyucu.GetInt32(0),
                        MektupID = okuyucu.GetInt32(1),
                        KullaniciID = okuyucu.GetInt32(2),
                        YorumIcerik = okuyucu.GetString(3),
                        OlusturmaTarihi = okuyucu.GetDateTime(4),
                        Onay = !okuyucu.IsDBNull(5) && okuyucu.GetBoolean(5),
                        Durum = !okuyucu.IsDBNull(6) && okuyucu.GetBoolean(6)
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
        public void YorumSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM YorumlarTable WHERE ID=@id";
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
        public void YorumDurumDegistir(int id)
        {
            try
            {
                komut.CommandText = "SELECT Durum FROM YorumlarTable WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                bool durum = Convert.ToBoolean(komut.ExecuteScalar());

                komut.CommandText = "UPDATE YorumlarTable SET Durum=@durum WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                komut.Parameters.AddWithValue("@durum", !durum);
                komut.ExecuteNonQuery();
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

                komut.CommandText = "INSERT INTO MektuplarTable (KullaniciID, KategoriID, Baslik, Icerik, AliciMail, GonderimTarihi, AcilisTarihi, TeslimEdildiMi, OlusturmaTarihi)  VALUES (@kullaniciID, @kategoriID, @baslik, @icerik, @aliciMail, @gonderimTarihi, @acilisTarihi, @teslimEdildiMi, @olusturmaTarihi)";

                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kullaniciID", mektup.KullaniciID);
                komut.Parameters.AddWithValue("@kategoriID", mektup.KategoriID);
                komut.Parameters.AddWithValue("@baslik", mektup.Baslik);
                komut.Parameters.AddWithValue("@icerik", mektup.Icerik);
                komut.Parameters.AddWithValue("@aliciMail", mektup.AliciMail);
                komut.Parameters.AddWithValue("@gonderimTarihi", mektup.GonderimTarihi);
                komut.Parameters.AddWithValue("@acilisTarihi", mektup.AcilisTarihi);
                komut.Parameters.AddWithValue("@teslimEdildiMi", mektup.TeslimEdildiMi);
                komut.Parameters.AddWithValue("@olusturmaTarihi", mektup.OlusturmaTarihi);
                baglanti.Open();
                komut.ExecuteNonQuery();

               MailGonder(mektup.AliciMail.ToString(), mektup.Baslik.ToString(), mektup.Icerik.ToString());


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
        public List<Mektup> GetMektuplar()
        {
            List<Mektup> mektuplar = new List<Mektup>();

            try
            {
                komut = new SqlCommand("SELECT MektupID, KullaniciID, KategoriID, Baslik, Icerik, AliciMail, GonderimTarihi, AcilisTarihi, TeslimEdildiMi, OlusturmaTarihi FROM MektuplarTable", baglanti);
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
                        GonderimTarihi = okuyucu.GetDateTime(6),
                        AcilisTarihi = okuyucu.GetDateTime(7),
                        TeslimEdildiMi = okuyucu.GetBoolean(8),
                        OlusturmaTarihi = okuyucu.GetDateTime(9)
                    };
                    mektuplar.Add(mktp);
                }
                return mektuplar;
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
        public void MailGonder(string aliciMail, string baslik, string icerik)
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

                
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(gondericiMail), 
                    Subject = baslik, 
                    Body = icerik, 
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

        #endregion
    }
}
