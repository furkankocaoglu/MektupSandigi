using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi.UyelikPanel
{
    public partial class Gonderiler : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Session'dan uyeler nesnesini al
                Uyeler uye = Session["uye"] as Uyeler;

                // Eğer uyeler nesnesi null değilse, KullaniciID'yi al
                if (uye != null)
                {
                    int kullaniciID = uye.KullaniciID; // Kullanıcı ID'sini al
                    List<Mektup> mektuplar = vm.KullaniciMektuplariniGetir(kullaniciID);
                    gvMektuplar.DataSource = mektuplar;
                    gvMektuplar.DataBind();
                }
                else
                {
                    // Kullanıcı oturumu açmamışsa yapılacak işlemler
                    // Örneğin, bir hata mesajı gösterebilirsiniz
                }
            }

        }
    }
}