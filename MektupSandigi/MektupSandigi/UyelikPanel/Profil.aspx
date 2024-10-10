<%@ Page Title="" Language="C#" MasterPageFile="~/UyelikPanel/UyeEkran.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="MektupSandigi.UyelikPanel.Profil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>ÜYE PANELİNE HOŞGELDİN </h1>
    <div>
        <h2>Üye Bilgileri</h2>
        <asp:Label ID="lblKullaniciAdi" runat="server" Text="Kullanıcı Adı: "></asp:Label>
        <asp:Label ID="lblKullaniciAdiValue" runat="server" Text=""></asp:Label><br />

        <asp:Label ID="lblMail" runat="server" Text="Mail: "></asp:Label>
        <asp:Label ID="lblMailValue" runat="server" Text=""></asp:Label><br />

        <asp:Label ID="lblSifre" runat="server" Text="Şifre: "></asp:Label>
        <asp:Label ID="lblSifreValue" runat="server" Text=""></asp:Label><br />

        <asp:Label ID="lblOlusturmaTarihi" runat="server" Text="Oluşturma Tarihi: "></asp:Label>
        <asp:Label ID="lblOlusturmaTarihiValue" runat="server" Text=""></asp:Label><br />

        <asp:Label ID="lblDurum" runat="server" Text="Durum: "></asp:Label>
        <asp:Label ID="lblDurumValue" runat="server" Text=""></asp:Label><br />

        <asp:Label ID="lblSilinmis" runat="server" Text="Silinmiş: "></asp:Label>
        <asp:Label ID="lblSilinmisValue" runat="server" Text=""></asp:Label><br />
    </div>
</asp:Content>
