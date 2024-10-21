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
                    Mektup mektup = GetMektupByID(mektupID); 

                    if (mektup != null)
                    {
                       
                        if (mektup.AcilisTarihi > DateTime.Now)
                        {
                            lblBaslik.Text = "Mektup henüz açılmadı.";
                            lblIcerik.Text = $"Size teslim edilmesi istenen özel mektubunuz {mektup.AcilisTarihi.ToString("dd/MM/yyyy HH:mm")} tarihinde açılacaktır. İlgili tarihe kadar beklemenizi rica ederiz.";
                        }
                        else
                        {
                           
                            lblBaslik.Text = mektup.Baslik;
                            lblIcerik.Text = mektup.Icerik;
                        }
                    }
                    else
                    {
                        lblBaslik.Text = "Mektup bulunamadı.";
                        lblIcerik.Text = string.Empty;
                    }
                }
                else
                {
                    lblBaslik.Text = "Geçersiz mektup ID.";
                    lblIcerik.Text = string.Empty;
                }
            }

        }
        private Mektup GetMektupByID(int mektupID)
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=MektupSandigi_DB;Integrated Security=True;";
            

            using (SqlConnection baglanti = new SqlConnection(connectionString))
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

