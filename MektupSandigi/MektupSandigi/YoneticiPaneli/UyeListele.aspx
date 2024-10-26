<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="UyeListele.aspx.cs" Inherits="MektupSandigi.YoneticiPaneli.UyeListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/UyeListele.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="sayfaBaslik">
        <h3>ÜYELER</h3>
    </div>
    <div class="tabloTasiyici">
        <div>
            <asp:GridView ID="gv_Uyeler" runat="server" CssClass="gv-style" AutoGenerateColumns="False" OnRowCommand="gv_Uyeler_RowCommand">
                <Columns>
                    <asp:BoundField DataField="KullaniciID" HeaderText="Kullanıcı No" />
                    <asp:BoundField DataField="KullaniciAdi" HeaderText="Kullanıcı İsim" />
                    <asp:BoundField DataField="Mail" HeaderText="Mail" />
                    <asp:BoundField DataField="OlusturmaTarihi" HeaderText="Oluşturma Tarihi" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:TemplateField HeaderText="Durum">
                        <ItemTemplate>
                            <%# (Convert.ToBoolean(Eval("Durum")) ? "Aktif" : "Pasif") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="İşlemler">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnSil" runat="server" CommandName="Sil" CommandArgument='<%# Eval("KullaniciID") %>' Text="Sil" />
                            <asp:LinkButton ID="btnDurum" runat="server" CommandName="Durum" CommandArgument='<%# Eval("KullaniciID") %>' Text="Değiştir" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle CssClass="alternate" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
