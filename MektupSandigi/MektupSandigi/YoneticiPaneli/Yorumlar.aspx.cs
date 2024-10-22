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
                YorumListele();
            }
        }
        private void YorumListele()
        {
            gv_yorumlar.DataSource = vm.YorumListele();
            gv_yorumlar.DataBind();
        }
        protected void gv_yorumlar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int yorumID = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "onayla")
            {
                Onayla(yorumID);
            }
            else if (e.CommandName == "sil")
            {
                Sil(yorumID);
            }
            else if (e.CommandName == "durum")
            {
                DurumDegistir(yorumID);
            }

            YorumListele(); 

        }
        private void Onayla(int yorumID)
        {
            var yorum = vm.YorumGetir(yorumID);
            if (yorum != null)
            {
                yorum.Onay = true; 
                bool guncelleSonuc = vm.YorumGuncelleme(yorum);

                if (!guncelleSonuc)
                {
                    
                }
            }
        }
        private void Sil(int yorumID)
        {
            vm.YorumSilHardDelete(yorumID); 
        }
        private void DurumDegistir(int yorumID)
        {
            vm.YorumDurumDegistir(yorumID); 
        }
    }
}


