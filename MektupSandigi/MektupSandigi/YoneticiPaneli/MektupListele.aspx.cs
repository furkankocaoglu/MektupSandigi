using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi.YoneticiPaneli
{
    public partial class MektupListele : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }

        }
        private void BindGridView()
        {
            List<Mektup> mektuplar = vm.GetMektuplar();
            if (mektuplar != null && mektuplar.Count > 0)
            {
                gv_Mektuplar.DataSource = mektuplar;
                gv_Mektuplar.DataBind();
            }
        }


    }
}