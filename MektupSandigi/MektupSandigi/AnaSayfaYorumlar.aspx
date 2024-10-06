<%@ Page Title="" Language="C#" MasterPageFile="~/AnaEkran.Master" AutoEventWireup="true" CodeBehind="AnaSayfaYorumlar.aspx.cs" Inherits="MektupSandigi.AnaSayfaYorumlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/AnSayfaYorumlar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="formTasiyici">
            <div class="formBaslik">
                <h3>Yorum Yaz</h3>
            </div>
         <div>
             <h5>Bu sayfada üyemiz olarak yeni yorum yazabilirsiniz.</h5>
         </div>
            <asp:TextBox ID="txtYorumIcerik" runat="server" TextMode="MultiLine" Rows="4" Width="400px" Height="200px" Placeholder="Gönderdiğiniz mektuplar ile ilgili düşüncelerinizi buraya yazın..."></asp:TextBox>
         <div class="button-container">
            <asp:Button ID="btnYorumEkle" runat="server" Text="Yorum Ekle" OnClick="btnYorumEkle_Click" />
             <div />
            <asp:Label ID="lblSonuc" runat="server" ForeColor="Green" Visible="false"></asp:Label>
        </div>
         </div>
</asp:Content>
