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
            if (Session["uye"] == null)
            {
                Response.Redirect("UyeGiris.aspx");
            }

        }
       

        protected void btnYorumEkle_Click(object sender, EventArgs e)
        {
            int kullaniciID = ((Uyeler)Session["uye"]).KullaniciID;
            int mektupID = 1; 

            string yorumIcerik = txtYorumIcerik.Text.Trim();

            if (!string.IsNullOrEmpty(yorumIcerik))
            {
                try
                {
                    vm.YorumEkle(kullaniciID, mektupID, yorumIcerik);
                    lblSonuc.Text = "Yorum başarıyla eklendi!";
                    txtYorumIcerik.Text = ""; 
                }
                catch
                {
                    lblSonuc.Text = "Yorum ekleme işlemi başarısız oldu.";
                }
            }
            else
            {
                lblSonuc.Text = "Lütfen bir yorum girin.";
            }
        }

    }
    
    

    
    

}
    
    
