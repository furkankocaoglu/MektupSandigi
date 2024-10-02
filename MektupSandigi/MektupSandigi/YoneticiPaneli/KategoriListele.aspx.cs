using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi.YoneticiPaneli
{
    public partial class KategoriListele : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KategorileriListele(); 
            }

        }
        private void KategorileriListele()
        {
            gv_Kategoriler.DataSource = vm.KategorileriListele(); 
            gv_Kategoriler.DataBind(); 
        }

        protected void gv_Kategoriler_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int kategoriId = Convert.ToInt32(e.CommandArgument);
                vm.KategoriSilHardDelete(kategoriId); 
                KategorileriListele(); 
            }
        }
    }

}

