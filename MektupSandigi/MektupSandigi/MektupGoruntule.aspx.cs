using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                    
                    MektupGoster(mektupID);
                }
                else
                {
                    
                    Response.Write("Geçersiz mektup ID.");
                }
            }

        }
        private void MektupGoster(int mektupID)
        {
            string connectionString = "your_connection_string_here"; 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Baslik, Icerik, GonderimTarihi FROM MektuplarTable WHERE MektupID = @MektupID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MektupID", mektupID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string baslik = reader["Baslik"].ToString();
                    string icerik = reader["Icerik"].ToString();
                    DateTime gonderimTarihi = Convert.ToDateTime(reader["GonderimTarihi"]);

                    
                    if (DateTime.Now < gonderimTarihi)
                    {
                        lblUyari.Text = "Bu mektup henüz açılmadı. Mektubun açılma tarihi: " + gonderimTarihi.ToString("dd MMMM yyyy HH:mm");
                        lblUyari.Visible = true;
                    }
                    else
                    {
                        
                        lblBaslik.Text = baslik;
                        lblIcerik.Text = icerik;
                        pnlMektup.Visible = true;
                    }
                }
                else
                {
                    lblUyari.Text = "Mektup bulunamadı.";
                    lblUyari.Visible = true;
                }

                reader.Close();
            }
        }
    }
}

