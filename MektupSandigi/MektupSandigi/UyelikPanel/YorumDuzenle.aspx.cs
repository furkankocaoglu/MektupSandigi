using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MektupSandigi.UyelikPanel
{
    public partial class YorumDuzenle : System.Web.UI.Page
    {
        VeriModeli vm= new VeriModeli();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string yorumIdStr = Request.QueryString["id"];
                if (string.IsNullOrEmpty(yorumIdStr))
                {
                    lblSonuc.Text = "Yorum ID'si sağlanmadı.";
                    lblSonuc.ForeColor = System.Drawing.Color.Red;
                    lblSonuc.Visible = true;
                    return;
                }

                int yorumID;
                if (int.TryParse(yorumIdStr, out yorumID))
                {
                    Yorumlar yorum = vm.YorumGetir(yorumID);
                    if (yorum != null)
                    {
                        txtYorumIcerik.Text = yorum.YorumIcerik;
                    }
                    else
                    {
                        lblSonuc.Text = "Yorum bulunamadı.";
                        lblSonuc.ForeColor = System.Drawing.Color.Red; 
                        lblSonuc.Visible = true;
                    }
                }
                else
                {
                    lblSonuc.Text = "Geçersiz yorum ID: " + yorumIdStr;
                    lblSonuc.ForeColor = System.Drawing.Color.Red; 
                    lblSonuc.Visible = true;
                }
            }
        }

        protected void btnYorumDuzenle_Click(object sender, EventArgs e)
        {
            int yorumID;
            if (int.TryParse(Request.QueryString["id"], out yorumID))
            {
                string yorumIcerik = txtYorumIcerik.Text.Trim();

                if (!string.IsNullOrEmpty(yorumIcerik))
                {
                    try
                    {
                        Yorumlar guncelYorum = new Yorumlar
                        {
                            YorumID = yorumID,
                            YorumIcerik = yorumIcerik,
                        };

                        bool sonuc = vm.YorumGuncelle(guncelYorum);
                        if (sonuc)
                        {
                            lblSonuc.Text = "Yorum başarıyla güncellendi!";
                            lblSonuc.ForeColor = System.Drawing.Color.Green; 
                        }
                        else
                        {
                            lblSonuc.Text = "Güncelleme işlemi başarısız oldu.";
                            lblSonuc.ForeColor = System.Drawing.Color.Red; 
                        }
                        lblSonuc.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        lblSonuc.Text = "Bir hata oluştu: " + ex.Message;
                        lblSonuc.ForeColor = System.Drawing.Color.Red; 
                        lblSonuc.Visible = true;
                    }
                }
                else
                {
                    lblSonuc.Text = "Lütfen bir yorum girin.";
                    lblSonuc.ForeColor = System.Drawing.Color.Red; 
                    lblSonuc.Visible = true;
                }
            }

        }
    }
}