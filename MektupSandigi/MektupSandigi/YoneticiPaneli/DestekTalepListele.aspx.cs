using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi.YoneticiPaneli
{
    public partial class DestekTalepListele : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var talepler = vm.TumTalepleriGetir();
                gv_DestekTalepleri.DataSource = talepler;
                gv_DestekTalepleri.DataBind();
            }

        }
        
    }
}