<%@ Page Title="" Language="C#" MasterPageFile="~/UyelikPanel/UyeEkran.Master" AutoEventWireup="true" CodeBehind="YorumYaz.aspx.cs" Inherits="MektupSandigi.UyelikPanel.YorumYaz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Yorum Ekle</h3>
        </div>
        <asp:Label ID="lblSonuc" runat="server" CssClass="girisKontrol" Visible="false"></asp:Label>
        <div class="formIcerik">
            <div class="satir">
                <label>Yorum İçeriği</label><br />
                <asp:TextBox ID="tb_yorumIcerik" runat="server" TextMode="MultiLine" CssClass="metinKutu" Rows="5"></asp:TextBox>
            </div>
            <div class="satir">
                <asp:Button ID="btnYorumEkle" runat="server" Text="Yorumu Ekle" OnClick="btnYorumEkle_Click1" CssClass="islemButton" />
            </div>
        </div>
    </div>

</asp:Content>
