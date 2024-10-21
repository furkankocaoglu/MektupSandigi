using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi
{
    public partial class KullaniciYorumlari : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UyeYorumListele();
            }

        }
        private void UyeYorumListele()
        {
            
            gv_onayli_yorumlar.DataSource = vm.UyeYorumListele(true); 
            gv_onayli_yorumlar.DataBind();
        }
    }
}