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
            List<Mektup> mektuplar = vm.GetMektuplar(); 
            gvMektuplar.DataSource = mektuplar; 
            gvMektuplar.DataBind();
        }
    }
}
