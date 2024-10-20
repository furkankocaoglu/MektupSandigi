<%@ Page Title="" Language="C#" MasterPageFile="~/UyelikPanel/UyeEkran.Master" AutoEventWireup="true" CodeBehind="YorumDuzenle.aspx.cs" Inherits="MektupSandigi.UyelikPanel.YorumDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Yorum Düzenle</h1>
    <asp:TextBox ID="txtYorumIcerik" runat="server" TextMode="MultiLine" Rows="4" Columns="50"></asp:TextBox>
    <br />
    <asp:Button ID="btnYorumDuzenle" runat="server" Text="Yorumu Güncelle" OnClick="btnYorumDuzenle_Click" />
    <br />
    <asp:Label ID="lblSonuc" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
