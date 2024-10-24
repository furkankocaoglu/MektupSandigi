using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

            if (string.IsNullOrEmpty(tb_kullanici.Text) || string.IsNullOrEmpty(tb_mail.Text) || string.IsNullOrEmpty(tb_sifre.Text))
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Kullanıcı adı, E-mail ve Şifre alanları boş bırakılamaz.";
                pnl_basarili.Visible = false;
                return;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(tb_mail.Text, emailPattern))
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Geçersiz e-posta adresi formatı.";
                pnl_basarili.Visible = false;
                return;
            }

            
            string[] gecerliUzantilar = { ".com", ".net", ".org" };
            bool uzantiGeçerli = false;

            foreach (string uzanti in gecerliUzantilar)
            {
                if (tb_mail.Text.EndsWith(uzanti))
                {
                    uzantiGeçerli = true;
                    break;
                }
            }

            if (!uzantiGeçerli)
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "E-posta adresinin .com, .net veya .org ile bitmesi gerekmektedir.";
                pnl_basarili.Visible = false;
                return;
            }

            Uyeler yeniUye = new Uyeler
            {
                KullaniciAdi = tb_kullanici.Text,
                Mail = tb_mail.Text,
                Sifre = tb_sifre.Text,
                OlusturmaTarihi = DateTime.Now,
                Durum = true,
                Silinmis = false
            };

            bool sonuc = vm.UyeOl(yeniUye);
            if (sonuc)
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Üyelik oluşturulurken bir hata oluştu. Lütfen tekrar deneyin.";
                pnl_basarili.Visible = false;
            }

        }
    }
    
}