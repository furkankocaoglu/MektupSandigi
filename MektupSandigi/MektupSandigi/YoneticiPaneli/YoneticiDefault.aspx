<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="YoneticiDefault.aspx.cs" Inherits="MektupSandigi.YoneticiPaneli.YoneticiDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Defaultcs.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
         <div><h1>Yönetici Paneline Hoşgeldiniz</h1></div>
             <div class="panel">
             <div class="panel">
            <h2>İstatistikler</h2>
            <p>Aktif Kullanıcı Sayısı: <asp:Label ID="lblKullaniciSayisi" runat="server" Text="0"></asp:Label></p>
            <p>Gönderilen Mektup Sayısı: <asp:Label ID="lblMektupSayisi" runat="server" Text="0"></asp:Label></p>
            <p>Yorum Sayısı: <asp:Label ID="lblYorumSayisi" runat="server" Text="0"></asp:Label></p>
            <p>Destek Talep Sayısı: <asp:Label ID="lblDestekTalepSayisi" runat="server" Text="0"></asp:Label></p>
            <p>Okunan Mektup Sayısı: <asp:Label ID="lblOkunanMektupSayisi" runat="server" Text="0"></asp:Label></p>
            <p>Okunmayan Mektup Sayısı: <asp:Label ID="lblOkunmayanMektupSayisi" runat="server" Text="0"></asp:Label></p>
            <p>Onay Bekleyen Yorum Sayısı: <asp:Label ID="lblOnayBekleyenYorumSayisi" runat="server" Text="0"></asp:Label></p>
            <p>Silinmiş Kullanıcı Sayısı: <asp:Label ID="lblSilinmisKullaniciSayisi" runat="server" Text="0"></asp:Label></p>
        </div>
        </div>
        </div>
</asp:Content>
