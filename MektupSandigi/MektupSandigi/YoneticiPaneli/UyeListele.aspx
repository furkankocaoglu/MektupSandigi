<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="UyeListele.aspx.cs" Inherits="MektupSandigi.YoneticiPaneli.UyeListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/UyeListele.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sayfaBaslik">
        <h3>ÜYELER</h3>
    </div>
    <asp:GridView ID="gv_Uyeler" runat="server" CssClass="gv-style" AutoGenerateColumns="False" OnRowCommand="gv_Uyeler_RowCommand">
        <Columns>
            <asp:BoundField DataField="KullaniciID" HeaderText="Kullanıcı No" />
            <asp:BoundField DataField="KullaniciAdi" HeaderText="Kullanıcı Adı" />
            <asp:BoundField DataField="Mail" HeaderText="E-posta" />
            <asp:BoundField DataField="OlusturmaTarihi" HeaderText="Üyelik Tarihi" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Durum" HeaderText="Durum" />
            <asp:ButtonField CommandName="Sil" Text="Sil" ButtonType="Button" />
        </Columns>
    </asp:GridView>
</asp:Content>
