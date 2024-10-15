<%@ Page Title="" Language="C#" MasterPageFile="~/AnaEkran.Master" AutoEventWireup="true" CodeBehind="MektupGoruntule.aspx.cs" Inherits="MektupSandigi.MektupGoruntule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="mektupContainer" runat="server" style=text-align:center>
        <h2>Mektup Başlığı: <asp:Label ID="lblBaslik" runat="server"></asp:Label></h2>
        <p><strong>İçerik:</strong></p>
        <p><asp:Label ID="lblIcerik" runat="server"></asp:Label></p>
    </div>
</asp:Content>
