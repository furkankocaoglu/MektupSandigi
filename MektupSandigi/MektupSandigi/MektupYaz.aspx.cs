using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi
{
    public partial class MektupYaz : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        Uyeler u = new Uyeler();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KategorileriListele(); 
            }

            u = (Uyeler)Session["uye"];
            if (u == null)
            {
                lblSonuc.Text = "Üye girişi yapmanız gerekmektedir.";
                lblSonuc.ForeColor = System.Drawing.Color.Red;
                lblSonuc.Visible = true;
                return;
            }
        }

        private void KategorileriListele()
        {
            vm.KategorileriListele();
            
        }

        protected void lbtn_mektupEkle_Click(object sender, EventArgs e)
        {
            //var sanitizer = new HtmlSanitizer();
            //string sanitizedInput = sanitizer.Sanitize(tb_icerik.Text);

            //Mektup yeniMektup = new Mektup
            //{
            //    KullaniciID = u.ID, // Kullanıcı ID'sini oturumdan al
            //    KategoriID = Convert.ToInt32(ddl_kategoriler.SelectedValue), // Kategori seçimini al
            //    Baslik = tb_baslik.Text,
            //    Icerik = sanitizedInput,
            //    AliciMail = tb_aliciMail.Text,
            //    GonderimTarihi = DateTime.Parse(tb_gonderimTarihi.Text), // Tarih TextBox'tan al
            //    AcilisTarihi = DateTime.Now, // Örnek: şu anki tarih
            //    TeslimEdildiMi = false,
            //    OlusturmaTarihi = DateTime.Now
            //};

            //// Mektubu eklemek için gerekli metodu çağırın
            //bool isAdded = vm.MektupEkle(yeniMektup);
            //if (isAdded)
            //{
            //    lblSonuc.Text = "Mektup başarıyla eklendi!";
            //    lblSonuc.ForeColor = System.Drawing.Color.Green;
            //    lblSonuc.Visible = true;
            //}
            //else
            //{
            //    lblSonuc.Text = "Mektup ekleme sırasında bir hata oluştu.";
            //    lblSonuc.ForeColor = System.Drawing.Color.Red;
            //    lblSonuc.Visible = true;
            //}
        }

        protected void btnTarihSec_Click1(object sender, EventArgs e)
        {
            calendarGonderimTarihi.Visible = !calendarGonderimTarihi.Visible;
        }

        protected void calendarGonderimTarihi_SelectionChanged(object sender, EventArgs e)
        {
            tb_gonderimTarihi.Text = calendarGonderimTarihi.SelectedDate.ToString("yyyy-MM-dd");
            calendarGonderimTarihi.Visible = false; // Takvimi gizle
        }


    }
}