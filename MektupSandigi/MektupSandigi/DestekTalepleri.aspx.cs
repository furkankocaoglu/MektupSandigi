using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi
{
    public partial class DestekTalepleri : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        Uyeler u = new Uyeler();
        protected void Page_Load(object sender, EventArgs e)
        {
            u = (Uyeler)Session["uye"];
            if (u == null)
            {
                lblSonuc.Text = "Üye girişi yapmanız gerekmektedir.";
                lblSonuc.ForeColor = System.Drawing.Color.Red;
                lblSonuc.Visible = true;
                linkGiris.Visible = true;
                
                return;
            }
            else
            {
                linkGiris.Visible = false;
            }


        }

        protected void btnTalepEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKonuIcerik.Text) || string.IsNullOrWhiteSpace(txtYorumIcerik.Text))
            {
                lblSonuc.Text = "Lütfen tüm alanları doldurun.";
                lblSonuc.ForeColor = System.Drawing.Color.Red;
                lblSonuc.Visible = true;
                return;
            }

            if (u == null)
            {
                lblSonuc.Text = "Üye girişi yapmanız gerekmektedir.";
                lblSonuc.ForeColor = System.Drawing.Color.Red;
                lblSonuc.Visible = true;
                return;
            }

            DestekTalep yeniTalep = new DestekTalep
            {
                KullaniciID = u.KullaniciID,
                Baslik = txtKonuIcerik.Text,
                Icerik = txtYorumIcerik.Text,
            };

            
            if (vm.TalepEkle(yeniTalep))
            {
                lblSonuc.Text = "Talebiniz başarıyla gönderildi.";
                lblSonuc.ForeColor = System.Drawing.Color.Green;
                lblSonuc.Visible = true;
                txtKonuIcerik.Text = string.Empty;
                txtYorumIcerik.Text = string.Empty;
            }
            else
            {
                lblSonuc.Text = "Talebiniz eklenirken bir hata oluştu.";
                lblSonuc.ForeColor = System.Drawing.Color.Red;
                lblSonuc.Visible = true;
            }
        }
    }
}