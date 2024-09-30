<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="MektupSandigi.YoneticiPaneli.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yönetici Ekranı</title>
    <link href="CSS/YöneticiEkrani.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="tasiyici">
            <div style="border-bottom: 1px solid silver; padding-bottom: 10px; margin: 10px 0;">
                <h3>Giriş Yapın</h3>
            </div>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="panelBasarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server">Kullanıcı Bulunamadı</asp:Label>
            </asp:Panel>
            <div class="satir">
                <label>Mail</label><br />
                <asp:TextBox ID="tb_mail" runat="server" CssClass="metinKutu" placeholder="ornek@example.com"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Şifre</label><br />
                <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinKutu" placeholder="*****" TextMode="Password"></asp:TextBox>
            </div>
            <div class="satir">
                <asp:Button ID="btn_girisYap" runat="server" OnClick="btn_girisYap_Click" Text="Giriş Yap" CssClass="girisButton" />
            </div>
        </div>
    </form>
</body>
</html>
