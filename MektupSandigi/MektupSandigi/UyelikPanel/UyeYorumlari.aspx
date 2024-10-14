<%@ Page Title="" Language="C#" MasterPageFile="~/UyelikPanel/UyeEkran.Master" AutoEventWireup="true" CodeBehind="UyeYorumlari.aspx.cs" Inherits="MektupSandigi.UyelikPanel.UyeYorumlari" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h1>Yorumlarım</h1>
    <asp:GridView ID="gvYorumlar" runat="server" AutoGenerateColumns="False" CssClass="table" OnRowCommand="gvYorumlar_RowCommand">
        <Columns>
            <asp:BoundField DataField="YorumIcerik" HeaderText="Yorum İçeriği" />
            <asp:BoundField DataField="OlusturmaTarihi" HeaderText="Oluşturma Tarihi" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
            <asp:TemplateField HeaderText="İşlemler">
                <ItemTemplate>
                    <asp:Button ID="btnSil" runat="server" Text="Sil" CommandName="Sil" CommandArgument='<%# Eval("YorumID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblHataMesaji" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
