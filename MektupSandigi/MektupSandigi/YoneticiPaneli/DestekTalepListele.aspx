<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="DestekTalepListele.aspx.cs" Inherits="MektupSandigi.YoneticiPaneli.DestekTalepListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/DestekTalepListele.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sayfaBaslik">
        <h3>DESTEK TALEPLERİ</h3>
    </div>
    <div class="tabloTasiyici">
        <div>
            <asp:GridView ID="gv_DestekTalepleri" runat="server" AutoGenerateColumns="False" CssClass="destek-talep">
                <Columns>
                    <asp:BoundField DataField="DestekID" HeaderText="Destek ID" />
                    <asp:BoundField DataField="KullaniciID" HeaderText="Kullanıcı ID" />
                    <asp:BoundField DataField="Baslik" HeaderText="Başlık" />
                    <asp:BoundField DataField="Icerik" HeaderText="İçerik" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
