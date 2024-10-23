using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi
{
    public partial class UyeGiris : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_mail.Text))
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "E-posta boş bırakılamaz";
                return; 
            }

            if (string.IsNullOrEmpty(tb_sifre.Text))
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Şifre boş bırakılamaz";
                return; 
            }

            if (!tb_mail.Text.Contains("@") || !tb_mail.Text.Contains("."))
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Geçersiz e-posta adresi";
                return; 
            }

            Uyeler u = vm.UyeGiris(tb_mail.Text, tb_sifre.Text);
            if (u == null)
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Hata oluştu";
                return; 
            }

            if (u.KullaniciID == 0)
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Kullanıcı bulunamadı";
                return; 
            }

            if (!u.Durum)
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Hesap aktif değildir";
                return; 
            }

           
            Session["uye"] = u;
            Response.Redirect("~/UyelikPanel/Default.aspx");

        }
    }
}