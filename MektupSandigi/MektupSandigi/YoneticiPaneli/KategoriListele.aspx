<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="MektupSandigi.YoneticiPaneli.KategoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/KategoriListele.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sayfaBaslik">
        <h3>KATEGORİLER</h3>
    </div>
    <div class="tabloTasiyici">
        <div>
            <asp:GridView ID="gv_Kategoriler" runat="server" CssClass="gv-style" AutoGenerateColumns="False" OnRowCommand="gv_Kategoriler_RowCommand">
                <Columns>
                    <asp:BoundField DataField="KategoriID" HeaderText="Kategori No " />
                    <asp:BoundField DataField="KategoriIsim" HeaderText="Kategori İsim" />
                    <asp:ButtonField CommandName="Sil" Text="Sil" ButtonType="Button" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

