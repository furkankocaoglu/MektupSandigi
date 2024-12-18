﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi.UyelikPanel
{
    public partial class mektupYaz : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        Uyeler u = new Uyeler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_kategoriler.DataSource = vm.KategorileriListele();
                ddl_kategoriler.DataTextField = "KategoriIsim";
                ddl_kategoriler.DataValueField = "KategoriID";
                ddl_kategoriler.DataBind();
            }
        }

        protected void lbtn_mektupEkle_Click(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                try
                {
                    Uyeler u = (Uyeler)Session["uye"]; 
                    if (!string.IsNullOrEmpty(tb_baslik.Text) &&
                        !string.IsNullOrEmpty(tb_icerik.Text) &&
                        ddl_kategoriler.SelectedIndex != -1) 
                    {
                        string[] gecerliUzantilar = { ".com", ".net", ".org" };
                        bool uzantiGecerli = false;

                        foreach (string uzanti in gecerliUzantilar)
                        {
                            if (tb_aliciMail.Text.EndsWith(uzanti))
                            {
                                uzantiGecerli = true;
                                break;
                            }
                        }

                        if (!uzantiGecerli)
                        {
                            lblSonuc.Text = "Alıcı e-posta adresinin .com, .net veya .org ile bitmesi gerekmektedir.";
                            lblSonuc.ForeColor = System.Drawing.Color.Red;
                            lblSonuc.Visible = true;
                            return;
                        }
                        DateTime acilisTarihi;
                        
                        if (DateTime.TryParse(tb_gonderimTarihi.Text, out acilisTarihi))
                        {
                            Mektup mek = new Mektup
                            {
                                Baslik = tb_baslik.Text.Trim(),
                                KategoriID = Convert.ToInt32(ddl_kategoriler.SelectedValue),
                                KullaniciID = u.KullaniciID, 
                                AliciMail = tb_aliciMail.Text.Trim(),
                                Icerik = tb_icerik.Text.Trim(),
                                OlusturmaTarihi = DateTime.Now,
                                AcilisTarihi = acilisTarihi,
                                TeslimEdildiMi = false
                            };

                            
                            if (vm.MektupEkle(mek))
                            {
                                lblSonuc.Text = "Mektup başarıyla gönderildi!";
                                lblSonuc.ForeColor = System.Drawing.Color.Green;
                                lblSonuc.Visible = true;
                            }
                            else
                            {
                                lblSonuc.Text = "Mektup eklenirken bir hata oluştu.";
                                lblSonuc.ForeColor = System.Drawing.Color.Red;
                                lblSonuc.Visible = true;
                            }
                        }
                        else
                        {
                            lblSonuc.Text = "Geçersiz açılış tarihi.";
                            lblSonuc.ForeColor = System.Drawing.Color.Red;
                            lblSonuc.Visible = true;
                        }
                    }
                    else
                    {
                        lblSonuc.Text = "Başlık, içerik ve kategori boş olamaz.";
                        lblSonuc.ForeColor = System.Drawing.Color.Red;
                        lblSonuc.Visible = true;
                    }
                }
                catch 
                {
                    return;
                }
                
            }
            else
            {
                lblSonuc.Text = "Öncelikle giriş yapmalısınız.";
                lblSonuc.ForeColor = System.Drawing.Color.Red;
                lblSonuc.Visible = true;
            }

        }
        
        protected void btnTarihSec_Click(object sender, EventArgs e)
        {
            calendarGonderimTarihi.Visible = !calendarGonderimTarihi.Visible;

        }
        protected void calendarGonderimTarihi_SelectionChanged(object sender, EventArgs e)
        {
            tb_gonderimTarihi.Text = calendarGonderimTarihi.SelectedDate.ToString("yyyy-MM-dd");
            calendarGonderimTarihi.Visible = false;
        }
    }
}