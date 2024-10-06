<%@ Page Title="" Language="C#" MasterPageFile="~/AnaEkran.Master" AutoEventWireup="true" CodeBehind="DestekTalepleri.aspx.cs" Inherits="MektupSandigi.DestekTalepleri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/DestekTalepleri.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="formTasiyici">
    <div class="formBaslik">
        <h3>Öneri, düşünce, destek..</h3>
    </div>
    <asp:TextBox ID="txtKonuIcerik" runat="server" TextMode="MultiLine" Rows="2" Width="400px" Placeholder="Konuyu girin..."></asp:TextBox>
         <br />
    <asp:TextBox ID="txtYorumIcerik" runat="server" TextMode="MultiLine" Rows="5" Width="400px" Placeholder="Düşüncelerinizi buraya yazın..."></asp:TextBox>
    <div class="button-container">
        <asp:Button ID="btnTalepEkle" runat="server" Text="Talep İlet" OnClick="btnTalepEkle_Click"/>
    </div>
    <asp:Label ID="lblSonuc" runat="server" ForeColor="Green" Visible="false"></asp:Label>
</div>
</asp:Content>
