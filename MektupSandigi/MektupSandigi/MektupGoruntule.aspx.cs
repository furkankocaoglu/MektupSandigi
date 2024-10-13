using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi
{
    public partial class MektupGoruntule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int mektupID;
                if (int.TryParse(Request.QueryString["mektupID"], out mektupID))
                {
                    Mektup mektup = GetMektupByID(mektupID); // Mektubu veritabanından al

                    if (mektup != null)
                    {
                        if (mektup.AcilisTarihi <= DateTime.Now) // Açılış tarihi geçmişse
                        {
                            lblBaslik.Text = mektup.Baslik;
                            lblIcerik.Text = mektup.Icerik;
                        }
                        else
                        {
                            lblBaslik.Text = "Bu mektup henüz açılamaz.";
                            lblIcerik.Text = $"Açılış tarihi: {mektup.AcilisTarihi.ToString("g")}";
                        }
                    }
                    else
                    {
                        lblBaslik.Text = "Mektup bulunamadı.";
                    }
                }
            }

        }
        private Mektup GetMektupByID(int mektupID)
        {
            // Veritabanından mektubu alacak kod burada olacak
            // Örneğin:
            using (SqlConnection baglanti = new SqlConnection("YourConnectionStringHere"))
            {
                SqlCommand komut = new SqlCommand("SELECT * FROM MektuplarTable WHERE MektupID = @mektupID", baglanti);
                komut.Parameters.AddWithValue("@mektupID", mektupID);

                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    return new Mektup
                    {
                        MektupID = (int)reader["MektupID"],
                        KullaniciID = (int)reader["KullaniciID"],
                        KategoriID = (int)reader["KategoriID"],
                        Baslik = reader["Baslik"].ToString(),
                        Icerik = reader["Icerik"].ToString(),
                        AliciMail = reader["AliciMail"].ToString(),
                        AcilisTarihi = (DateTime)reader["AcilisTarihi"],
                        OlusturmaTarihi = (DateTime)reader["OlusturmaTarihi"],
                        TeslimEdildiMi = (bool)reader["TeslimEdildiMi"]
                    };
                }
            }
            return null;
        }
    }
    
}

