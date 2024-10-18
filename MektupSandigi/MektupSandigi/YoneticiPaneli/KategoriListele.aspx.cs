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
                BindData();
            }

        }
        private void BindData()
        {
            gv_Kategoriler.DataSource = vm.KategoriListele(false);
            gv_Kategoriler.DataBind();
        }
        protected void gv_Kategoriler_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null && e.CommandArgument is string)
            {
                int id;
                if (int.TryParse(e.CommandArgument.ToString(), out id))
                {
                    if (e.CommandName == "Sil")
                    {
                        vm.KategoriSil(id);
                    }
                    else if (e.CommandName == "Durum")
                    {
                        vm.KategoriDurumDegistir(id);
                    }

                    
                    BindData(); 
                }
            }
        }
        
    }
    

}

