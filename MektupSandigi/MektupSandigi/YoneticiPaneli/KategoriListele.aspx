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
            <asp:GridView ID="gv_Kategoriler" runat="server" CssClass="gv-style" AutoGenerateColumns="True" OnRowCommand="gv_Kategoriler_RowCommand1">
                <Columns>
                    <asp:BoundField DataField="KategoriID" HeaderText="Kategori No" />
                    <asp:BoundField DataField="KategoriIsim" HeaderText="Kategori İsim" />
                    <asp:TemplateField HeaderText="Durum">
                        <ItemTemplate>
                            <%# (Convert.ToBoolean(Eval("Durum")) ? "Aktif" : "Pasif") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="İşlemler">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnSil" runat="server" CommandName="Sil" CommandArgument='<%# Eval("KategoriID") %>' Text="Sil" />
                            <asp:LinkButton ID="btnDurum" runat="server" CommandName="Durum" CommandArgument='<%# Eval("KategoriID") %>' Text="Değiştir" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle CssClass="alternate" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

