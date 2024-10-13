using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi.UyelikPanel
{
    public partial class YorumYaz : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
       

        protected void btnYorumEkle_Click1(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                try
                {
                    Uyeler u = (Uyeler)Session["uye"];
                    int kullaniciID = u.KullaniciID;

                    string yorumIcerik = tb_yorumIcerik.Text.Trim();
                    DateTime olusturmaTarihi = DateTime.Now;

                    if (!string.IsNullOrEmpty(yorumIcerik))
                    {
                        using (SqlConnection baglanti = new SqlConnection("YourConnectionStringHere"))
                        {
                            using (SqlCommand komut = new SqlCommand())
                            {
                                komut.Connection = baglanti;
                                komut.CommandText = "INSERT INTO YorumlarTable (KullaniciID, YorumIcerik, OlusturmaTarihi) VALUES (@kullaniciID, @yorumIcerik, @olusturmaTarihi)";

                                komut.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                                komut.Parameters.AddWithValue("@yorumIcerik", yorumIcerik);
                                komut.Parameters.AddWithValue("@olusturmaTarihi", olusturmaTarihi);

                                baglanti.Open();
                                komut.ExecuteNonQuery();
                            }
                        }

                        lblSonuc.Text = "Yorum başarıyla eklendi!";
                        lblSonuc.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblSonuc.Text = "Yorum içeriği boş olamaz.";
                        lblSonuc.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblSonuc.Text = "Bir hata oluştu: " + ex.ToString();
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblSonuc.Text = "Öncelikle giriş yapmalısınız.";
                lblSonuc.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    

    
    

}
    
    
