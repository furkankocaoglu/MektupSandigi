﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi.UyelikPanel
{
    public partial class YorumYaz : System.Web.UI.Page
    {
        VeriModeli vm = new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uye"] == null)
            {
                Response.Redirect("UyeGiris.aspx");
            }

        }
       

        protected void btnYorumEkle_Click(object sender, EventArgs e)
        {
            int kullaniciID = ((Uyeler)Session["uye"]).KullaniciID;

            string yorumIcerik = txtYorumIcerik.Text.Trim();

            if (!string.IsNullOrEmpty(yorumIcerik))
            {
                try
                {
                    
                    Yorumlar yeniYorum = new Yorumlar
                    {
                        KullaniciID = kullaniciID,
                        YorumIcerik = yorumIcerik,
                        OlusturmaTarihi = DateTime.Now, 
                        Durum = true, 
                        Onay = false, 
                        Silinmis = false 
                    };

                    vm.YorumEkle(yeniYorum);
                    lblSonucc.Text = "Yorum başarıyla eklendi!";
                    lblSonucc.ForeColor = System.Drawing.Color.Green; 
                    lblSonucc.Visible = true; 
                    lblSonuc.Visible = false; 
                    txtYorumIcerik.Text = "";
                }
                catch
                {
                    lblSonuc.Text = "Yorum ekleme işlemi başarısız oldu.";
                    lblSonuc.Visible = true; 
                    lblSonucc.Visible = false; 
                }
            }
            else
            {
                lblSonuc.Text = "Lütfen bir yorum girin.";
                lblSonuc.Visible = true; 
                lblSonucc.Visible = false; 
            }
        }

    }
    
    

    
    

}
    
    
