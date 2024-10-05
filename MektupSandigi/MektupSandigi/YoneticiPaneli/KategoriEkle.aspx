<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="MektupSandigi.YoneticiPaneli.KategoriEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/KategoriEkleme.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
    <div class="formBaslik">
        <h3>Yeni Kategori Ekle </h3>
    </div>
    <div class="formIcerik">
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliPanel" Visible="false">
            <strong>Başarılı!</strong> Mektup için kategori eklendi
        </asp:Panel>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false">
            <strong>Başarısız!</strong>
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <div class="satir">
            <label>Kategori Adı</label><br />
            <br />
            <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu"></asp:TextBox>
        </div>
        <div class="satir">
            <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="islemButton" OnClick="lbtn_ekle_Click">Ekle</asp:LinkButton>
        </div>
    </div>
</div>
</asp:Content>

