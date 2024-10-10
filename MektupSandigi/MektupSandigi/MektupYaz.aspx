<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/AnaEkran.Master" AutoEventWireup="true" CodeBehind="MektupYaz.aspx.cs" Inherits="MektupSandigi.MektupYaz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/MektupEkle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="linkUyeGirisi" runat="server" class="link">
        <a href="UyeGiris.aspx">&nbsp;&nbsp;&nbsp;&nbsp;Üye Girişi yap</a>
    </div>
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Mektup Yaz</h3>
        </div>
        <asp:Label ID="lblSonuc" runat="server" CssClass="girisKontrol" Visible="false"></asp:Label>
        <div class="formIcerik">
            <div class="satir">
                <label>Başlık</label><br />
                <br />
                <asp:TextBox ID="tb_baslik" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Kategori</label><br />
                <br />
                <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="metinKutu"></asp:DropDownList>
            </div>
            <div class="satir">
                <label>Alıcı Mail Adresi</label><br />
                <br />
                <asp:TextBox ID="tb_aliciMail" runat="server" CssClass="metinKutu"></asp:TextBox>
                <asp:RegularExpressionValidator
                    ID="rev_aliciMail"
                    runat="server"
                    ControlToValidate="tb_aliciMail"
                    ErrorMessage="Geçersiz e-posta adresi!"
                    CssClass="validatorMessage"
                    ValidationExpression="^[\w\.\-]+@[\w\-]+\.[a-zA-Z]{2,4}$"
                    ForeColor="Red">
                </asp:RegularExpressionValidator>
            </div>
            <div class="satir">
                <label>Mektup İçerik</label><br />
                <br />
                <asp:TextBox ID="tb_icerik" runat="server" TextMode="MultiLine" CssClass="metinKutu" Rows="20"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Gönderim Tarihi</label><br />
                <br />
                <asp:TextBox ID="tb_gonderimTarihi" runat="server" CssClass="tarihKutu" ReadOnly="true"></asp:TextBox>
                <br />
                <br />
                <asp:Calendar ID="calendarGonderimTarihi" runat="server" OnSelectionChanged="calendarGonderimTarihi_SelectionChanged" Visible="false"></asp:Calendar>
                <asp:Button ID="btnTarihSec" runat="server" Text="Gönderim Tarihi Seç" OnClick="btnTarihSec_Click" />
            </div>
            <div class="satir">
                <asp:LinkButton ID="lbtn_mektupEkle" runat="server" CssClass="islemButton" OnClick="lbtn_mektupEkle_Click1">Mektup Gönder</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
