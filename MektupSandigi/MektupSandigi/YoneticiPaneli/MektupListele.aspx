<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="MektupListele.aspx.cs" Inherits="MektupSandigi.YoneticiPaneli.MektupListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/MektupListele.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="sayfaBaslik" style="text-align:center">
            <h2>MEKTUPLAR</h2>
        </div>
        <asp:GridView ID="gv_Mektuplar" runat="server" CssClass="gv-style" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MektupID" HeaderText="MektupID" />
                <asp:BoundField DataField="KullaniciID" HeaderText="KullanıcıID" />
                <asp:BoundField DataField="KategoriID" HeaderText="KategoriID" />
                <asp:BoundField DataField="Baslik" HeaderText="Başlık" />
                <asp:BoundField DataField="Icerik" HeaderText="İçerik" />
                <asp:BoundField DataField="AliciMail" HeaderText="Alıcı Mail" />
                <asp:BoundField DataField="AcilisTarihi" HeaderText="Açılış Tarihi" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="TeslimEdildiMi" HeaderText="Teslim Edildi Mi?" DataFormatString="{0}" />
                <asp:BoundField DataField="OlusturmaTarihi" HeaderText="Oluşturma Tarihi" DataFormatString="{0:yyyy-MM-dd}" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
