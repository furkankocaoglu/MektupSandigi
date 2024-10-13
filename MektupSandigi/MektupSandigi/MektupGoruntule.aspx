<%@ Page Title="" Language="C#" MasterPageFile="~/AnaEkran.Master" AutoEventWireup="true" CodeBehind="MektupGoruntule.aspx.cs" Inherits="MektupSandigi.MektupGoruntule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
            <h2>Mektup Detayları</h2>
            <asp:Label ID="lblUyari" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <asp:Label ID="lblBaslik" runat="server" Font-Bold="true"></asp:Label><br />
            <asp:Label ID="lblIcerik" runat="server" TextMode="MultiLine" Width="600px" Height="400px" BackColor="#f9f9f9" BorderColor="#ccc" BorderStyle="Solid" BorderWidth="1px"></asp:Label><br />
            <asp:Panel ID="pnlMektup" runat="server" Visible="false">
                <h3>Mektup İçeriği:</h3>
                <asp:Label ID="lblMektupIcerigi" runat="server"></asp:Label>
            </asp:Panel>
        </div>
</asp:Content>
