using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi.YoneticiPaneli
{

    public partial class UyeListele : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TumUyeleriGetir();
            }

        }
        private void TumUyeleriGetir()
        {
            gv_Uyeler.DataSource = vm.TumUyeleriGetir();
            gv_Uyeler.DataBind();
        }
        protected void gv_Uyeler_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

    }
}