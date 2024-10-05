using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi
{
    public partial class AnaSayfaYorumlar : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        Uyeler u=new Uyeler();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            u = (Uyeler)Session["uye"];

            
            if (u == null)
            {
                
                txtYorumIcerik.Visible = false;
                btnYorumEkle.Visible = false;

                
                lblSonuc.Text = "Üye girişi yapmanız gerekmektedir.";
                lblSonuc.ForeColor = System.Drawing.Color.Red; 
                lblSonuc.Visible = true;
            }
            else
            {
               
                txtYorumIcerik.Visible = true;
                btnYorumEkle.Visible = true;
            }

        }

        protected void btnYorumEkle_Click(object sender, EventArgs e)
        {

            
            if (string.IsNullOrWhiteSpace(txtYorumIcerik.Text))
            {
                lblSonuc.Text = "Lütfen yorumunuzu girin.";
                lblSonuc.ForeColor = System.Drawing.Color.Red; 
                lblSonuc.Visible = true; 
                return; 
            }

            Yorumlar yeniYorum = new Yorumlar
            {
                MektupID = 1,
                KullaniciID = u.KullaniciID, 
                YorumIcerik = txtYorumIcerik.Text,
                OlusturmaTarihi = DateTime.Now,
                Durum = true, 
                Onay = false 
            };

            if (vm.YorumEkle(yeniYorum))
            {
                lblSonuc.Text = "Yorum başarıyla eklendi!";
                lblSonuc.ForeColor = System.Drawing.Color.Green; 
                lblSonuc.Visible = true;
                txtYorumIcerik.Text = string.Empty; 
            }
            else
            {
                lblSonuc.Text = "Yorum eklenirken bir hata oluştu.";
                lblSonuc.ForeColor = System.Drawing.Color.Red; 
                lblSonuc.Visible = true;
            }
        }
    }
}