<%@ Page Title="" Language="C#" MasterPageFile="~/UyelikPanel/UyeEkran.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MektupSandigi.UyelikPanel.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Hoş Geldin <asp:Label ID="lblKullaniciAdi" runat="server" CssClass="kullanici-adi"></asp:Label>!</h2>
        
        <p>Profil bilgilerinizi görüntülemek ve mektup göndermek için yukarıdaki menüyü kullanabilirsiniz.</p>
        
        <h3>Yardımcı İpuçları:</h3>
        <ul>
            <li>Yeni bir mektup göndermek için "Yeni Mektup" butonuna tıklayın.</li>
            <li>Yorumlarınızı kontrol edin ve geri bildirimlerinizi paylaşın.</li>
            <li>Üyelik bilgilerinizi kontrol edebilirsiniz!</li>
        </ul>

        <h3>Topluluk Olayları:</h3>
        <p>Gelecek etkinlikler:</p>
        <ul>
            <li>Mektup Yarışması: 15 Ekim</li>
            <li>Yorum Yazma Haftası: 1-7 Kasım</li>
        </ul>
    </div>
</asp:Content>
