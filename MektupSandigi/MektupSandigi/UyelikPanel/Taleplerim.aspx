<%@ Page Title="" Language="C#" MasterPageFile="~/UyelikPanel/UyeEkran.Master" AutoEventWireup="true" CodeBehind="Taleplerim.aspx.cs" Inherits="MektupSandigi.UyelikPanel.Taleplerim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="formTasiyici">
    <div class="formBaslik">
        <h3>Tavsiye ve düşüncelerinizi belirtebilirsiniz..</h3>
    </div>
    <asp:TextBox ID="txtKonuIcerik" runat="server" TextMode="MultiLine" Rows="2" Width="400px" Placeholder="Konuyu girin..."></asp:TextBox>
         <br />
             <br />
    <asp:TextBox ID="txtYorumIcerik" runat="server" TextMode="MultiLine" Rows="5" Width="400px" Placeholder="Düşüncelerinizi buraya yazın..."></asp:TextBox>
    <div class="button-container">
        <asp:Button ID="btnTalepEkle" runat="server" Text="Talep İlet" OnClick="btnTalepEkle_Click"/>
    </div>
         <br />
    <asp:Label ID="lblSonuc" runat="server" ForeColor="Green" Visible="false"></asp:Label>
         
</div>
</asp:Content>
