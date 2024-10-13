using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi.UyelikPanel
{
    public partial class YorumYaz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnYorumEkle_Click(object sender, EventArgs e)
        {

           
            if (Session["KullaniciID"] != null)
            {
                lblSonuc.Text = "Önce giriş yapmalısınız.";
                lblSonuc.ForeColor = System.Drawing.Color.Red;
                lblSonuc.Visible = true;
                return; 
            }

            
            int kullaniciID = Convert.ToInt32(Session["KullaniciID"]);
            string yorumIcerik = txtYorumIcerik.Text.Trim();

            
            if (string.IsNullOrEmpty(yorumIcerik))
            {
                lblSonuc.Text = "Yorum içeriği boş olamaz.";
                lblSonuc.ForeColor = System.Drawing.Color.Red;
                lblSonuc.Visible = true;
                return;
            }

            
            VeriModeli vm = new VeriModeli();
            bool sonuc = vm.UyeYorumEkle(kullaniciID, yorumIcerik);

            
            if (sonuc)
            {
                lblSonuc.Text = "Yorumunuz başarıyla eklendi.";
                lblSonuc.ForeColor = System.Drawing.Color.Green;
                txtYorumIcerik.Text = ""; 
            }
            else
            {
                lblSonuc.Text = "Yorum eklenirken bir hata oluştu.";
                lblSonuc.ForeColor = System.Drawing.Color.Red;
            }
            lblSonuc.Visible = true; 
        }
    }
    
}