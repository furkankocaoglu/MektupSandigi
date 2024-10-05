using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi.YoneticiPaneli
{
    public partial class Yorumlar : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TumYorumlariGetir();
            }
        }

        private void TumYorumlariGetir()
        {
            gv_yorumlar.DataSource = vm.TumYorumlariGetir();
            gv_yorumlar.DataBind();
        }

        protected void gv_yorumlar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int yorumID = Convert.ToInt32(e.CommandArgument);
                vm.YorumSil(yorumID); 
                TumYorumlariGetir();
            }
            if (e.CommandName == "durum")
            {
                int yorumID = Convert.ToInt32(e.CommandArgument);
                vm.YorumDurumDegistir(yorumID); 
                TumYorumlariGetir();
            }
        }





    }
}
