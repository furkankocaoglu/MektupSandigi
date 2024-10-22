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
                BindData();
            }

        }
        private void BindData()
        {
            var uyeler = vm.UyeListele(false); 
            if (uyeler != null && uyeler.Count > 0)
            {
                gv_Uyeler.DataSource = uyeler;
                gv_Uyeler.DataBind();
            }
            else
            {
                gv_Uyeler.DataSource = null;
                gv_Uyeler.DataBind(); 
            }
        }

        protected void gv_Uyeler_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null && e.CommandArgument is string)
            {
                int id;
                if (int.TryParse(e.CommandArgument.ToString(), out id))
                {
                    if (e.CommandName == "Sil")
                    {
                        vm.UyeSil(id);
                    }
                    else if (e.CommandName == "Durum")
                    {
                        vm.UyeDurumDegistir(id);
                    }
                    BindData();
                }
            }
        }
    }
    
}