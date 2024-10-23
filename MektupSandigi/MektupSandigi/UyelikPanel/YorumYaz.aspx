<%@ Page Title="" Language="C#" MasterPageFile="~/UyelikPanel/UyeEkran.Master" AutoEventWireup="true" CodeBehind="YorumYaz.aspx.cs" Inherits="MektupSandigi.UyelikPanel.YorumYaz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Yorum Ekle</h1>
    <asp:TextBox ID="txtYorumIcerik" runat="server" TextMode="MultiLine" Rows="5" Columns="50" placeholder="Yorumunuzu buraya yazın..."></asp:TextBox>
    <br />
    <asp:Button ID="btnYorumEkle" runat="server" Text="Yorum Ekle" OnClick="btnYorumEkle_Click" />
    <asp:Label ID="lblSonuc" runat="server" ForeColor="Red"></asp:Label>
    <asp:Label ID="lblSonucc" runat="server" ForeColor="Green"></asp:Label>
</asp:Content>
