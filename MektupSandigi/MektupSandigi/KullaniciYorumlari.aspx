<%@ Page Title="" Language="C#" MasterPageFile="~/AnaEkran.Master" AutoEventWireup="true" CodeBehind="KullaniciYorumlari.aspx.cs" Inherits="MektupSandigi.KullaniciYorumlari" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>ÜYELERDEN GELEN YORUMLAR</h3>
        </div>
        <asp:GridView ID="gv_onayli_yorumlar" runat="server" CssClass="gv-style" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="YorumIcerik" HeaderText="Yorum İçeriği" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
