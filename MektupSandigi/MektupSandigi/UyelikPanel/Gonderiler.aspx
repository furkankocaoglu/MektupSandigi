<%@ Page Title="" Language="C#" MasterPageFile="~/UyelikPanel/UyeEkran.Master" AutoEventWireup="true" CodeBehind="Gonderiler.aspx.cs" Inherits="MektupSandigi.UyelikPanel.Gonderiler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gönderdiğim Mektuplar</h1>
<asp:GridView ID="gvMektuplar" runat="server" AutoGenerateColumns="False" CssClass="table">
    <Columns>
        <asp:BoundField DataField="Baslik" HeaderText="Başlık" />
        <asp:BoundField DataField="Icerik" HeaderText="İçerik" />
        <asp:BoundField DataField="AliciMail" HeaderText="Alıcı Mail" />
        <asp:BoundField DataField="AcilisTarihi" HeaderText="Açılış Tarihi" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
        <asp:BoundField DataField="OlusturmaTarihi" HeaderText="Oluşturma Tarihi" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
    </Columns>
</asp:GridView>
</asp:Content>
