using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi.UyelikPanel
{
    public partial class UyeYorumlari : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["uye"] != null)
                {
                    int kullaniciID = ((Uyeler)Session["uye"]).KullaniciID;
                    YorumlariGoster(kullaniciID);
                }
                else
                {
                    Response.Redirect("UyeGiris.aspx");
                }
            }

        }
        private void YorumlariGoster(int kullaniciID)
        {
            List<Yorumlar> yorumlar = vm.KullaniciYorumlariniGetir(kullaniciID);

            if (yorumlar != null && yorumlar.Count > 0)
            {
                gvYorumlar.DataSource = yorumlar;
                gvYorumlar.DataBind();
            }
            else
            {
                gvYorumlar.DataSource = null;
                gvYorumlar.DataBind();
            }
        }

        protected void gvYorumlar_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                int yorumID = Convert.ToInt32(e.CommandArgument);

                try
                {
                    vm.YorumSil(yorumID);
                    lblHataMesaji.Text = "Yorum başarıyla silindi.";

                    
                    int kullaniciID = ((Uyeler)Session["uye"]).KullaniciID;
                    YorumlariGoster(kullaniciID);
                }
                catch (Exception ex)
                {
                    lblHataMesaji.Text = "Yorum silme işlemi sırasında bir hata oluştu: " + ex.Message;
                }

            }
        }
    }
    
    
}
