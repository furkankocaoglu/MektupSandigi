using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi.YoneticiPaneli
{
    public partial class YoneticiDefault : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                vm = new VeriModeli(); 
                bildirimler();
            }
        }
        private void bildirimler()
        {
            
            int kullaniciSayisi = vm.KullaniciSayisiniGetir();
            lblKullaniciSayisi.Text = kullaniciSayisi.ToString();

            
            int mektupSayisi = vm.MektupSayisiniGetir();
            lblMektupSayisi.Text = mektupSayisi.ToString();

            
            int yorumSayisi = vm.YorumSayisiniGetir();
            lblYorumSayisi.Text = yorumSayisi.ToString();

           
            int destekTalepSayisi = vm.DestekTalepSayisiniGetir();
            lblDestekTalepSayisi.Text = destekTalepSayisi.ToString();


            int okunanMektupSayisi = vm.OkunanMektupSayisiniGetir();
            lblOkunanMektupSayisi.Text = okunanMektupSayisi.ToString();

            
            int okunmayanMektupSayisi = vm.OkunmayanMektupSayisiniGetir();
            lblOkunmayanMektupSayisi.Text = okunmayanMektupSayisi.ToString();

            
            int onayBekleyenYorumSayisi = vm.OnayBekleyenYorumSayisiniGetir();
            lblOnayBekleyenYorumSayisi.Text = onayBekleyenYorumSayisi.ToString();

            
            int silinmisKullaniciSayisi = vm.SilinmisKullaniciSayisiniGetir();
            lblSilinmisKullaniciSayisi.Text = silinmisKullaniciSayisi.ToString();
        }

    }
        
    
}