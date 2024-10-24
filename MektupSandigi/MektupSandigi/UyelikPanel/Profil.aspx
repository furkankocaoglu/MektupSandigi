<%@ Page Title="" Language="C#" MasterPageFile="~/UyelikPanel/UyeEkran.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="MektupSandigi.UyelikPanel.Profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Profil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="welcome-header">ÜYE PANELİNE HOŞGELDİN</h1>
    <div class="user-info">
        <h2 class="info-header">Üye Bilgileri</h2>
        <label class="info-label">Kullanıcı Adı:</label>
        <asp:Label ID="lblKullaniciAdiValue" runat="server" CssClass="info-value" Text=""></asp:Label><br />

        <label class="info-label">Mail:</label>
        <asp:Label ID="lblMailValue" runat="server" CssClass="info-value" Text=""></asp:Label><br />

        <label class="info-label">Şifre:</label>
        <asp:Label ID="lblSifreValue" runat="server" CssClass="info-value" Text=""></asp:Label><br />

        <label class="info-label">Oluşturma Tarihi:</label>
        <asp:Label ID="lblOlusturmaTarihiValue" runat="server" CssClass="info-value" Text=""></asp:Label><br />

        <label class="info-label">Durum:</label>
        <asp:Label ID="lblDurumValue" runat="server" CssClass="info-value" Text=""></asp:Label><br />

        <label class="info-label"> Üyelik Silinmiş Mi?:</label>
        <asp:Label ID="lblSilinmisValue" runat="server" CssClass="info-value" Text=""></asp:Label><br />
    </div>
</asp:Content>
