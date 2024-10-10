using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi.UyelikPanel
{
    public partial class Profil : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["uye"] != null)
                {
                   
                    Uyeler uye = (Uyeler)Session["uye"];
                    UyeBilgileriniGoster(uye.KullaniciID);
                }
                else
                {
                    Response.Redirect("UyeGiris.aspx");
                }
            }
        }
        private void UyeBilgileriniGoster(int kullaniciID)
        {
            Uyeler uye = vm.UyeBilgisiGetir(kullaniciID);

            if (uye != null)
            {
                lblKullaniciAdiValue.Text = uye.KullaniciAdi;
                lblMailValue.Text = uye.Mail;
                lblSifreValue.Text = uye.Sifre; 
                lblOlusturmaTarihiValue.Text = uye.OlusturmaTarihi.ToString("dd/MM/yyyy");
                lblDurumValue.Text = uye.Durum ? "Aktif" : "Pasif";
                lblSilinmisValue.Text = uye.Silinmis ? "Evet" : "Hayır"; 
            }
            else
            {
                lblKullaniciAdiValue.Text = "Kullanıcı bilgileri alınamadı.";
                lblMailValue.Text = "Kullanıcı bilgileri alınamadı.";
                lblSifreValue.Text = "Kullanıcı bilgileri alınamadı.";
                lblOlusturmaTarihiValue.Text = "Kullanıcı bilgileri alınamadı.";
                lblDurumValue.Text = "Kullanıcı bilgileri alınamadı.";
                lblSilinmisValue.Text = "Kullanıcı bilgileri alınamadı.";
            }
        }
    }
}
    
    
    


