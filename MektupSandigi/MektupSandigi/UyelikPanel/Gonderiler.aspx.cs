using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi.UyelikPanel
{
    public partial class Gonderiler : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                Uyeler uye = Session["uye"] as Uyeler;

                
                if (uye != null)
                {
                    int kullaniciID = uye.KullaniciID; 
                    List<Mektup> mektuplar = vm.KullaniciMektuplariniGetir(kullaniciID);
                    gvMektuplar.DataSource = mektuplar;
                    gvMektuplar.DataBind();
                }
                else
                {
                    
                }
            }

        }
    }
}