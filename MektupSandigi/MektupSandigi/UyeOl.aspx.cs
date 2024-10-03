using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi
{
    public partial class UyeOl : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void btn_tikla_Click1(object sender, EventArgs e)
        {
            Uyeler u = new Uyeler();
            u.KullaniciAdi = tb_kullanici.Text;
            u.Mail = tb_mail.Text;
            u.Sifre = tb_sifre.Text;
            u.Durum = cb_durum.Checked;
            u.OlusturmaTarihi = DateTime.Now;

            if (string.IsNullOrEmpty(tb_mail.Text))
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Lütfen e-posta adresinizi girin";
                return;
            }

            if (!tb_mail.Text.Contains("@") || !tb_mail.Text.EndsWith(".com"))
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Geçersiz e-posta adresi";
                return;
            }

            if (
                string.IsNullOrEmpty(tb_kullanici.Text) ||
                string.IsNullOrEmpty(tb_sifre.Text))
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Boş alan bırakılamaz ";
                return;
            }

            if (vm.UyeOl(u))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Üye eklenirken bir hata oluştu";
            }

        }
    }
    
}