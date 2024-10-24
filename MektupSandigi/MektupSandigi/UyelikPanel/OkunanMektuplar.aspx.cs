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
    public partial class OkunanMektuplar : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindGrid();
            }

        }
        private void BindGrid()
        {

            if (Session["uye"] != null)
            {
                
                Uyeler mevcutUye = (Uyeler)Session["uye"];
                int kullaniciId = mevcutUye.KullaniciID;

                
                List<Mektup> mektuplar = vm.KullaniciMektuplariniGetir(kullaniciId);

               
                if (mektuplar != null && mektuplar.Count > 0)
                {
                    gvMektuplar.DataSource = mektuplar;
                    gvMektuplar.DataBind();
                }
                else
                {
                    
                }
            }
            else
            {
                
                Response.Redirect("UyeGiris.aspx");
            }
        }
    }
}
