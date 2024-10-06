<%@ Page Title="" Language="C#" MasterPageFile="~/AnaEkran.Master" AutoEventWireup="true" CodeBehind="MektupYaz.aspx.cs" Inherits="MektupSandigi.MektupYaz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/MektupEkle.css" rel="stylesheet" />
    <script src="ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Mektup Yaz</h3>
        </div>
        <asp:Label ID="lblSonuc" runat="server" Visible="false"></asp:Label>
        <div class="formIcerik">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliPanel" Visible="false">
                <strong>Başarılı!</strong> Mektup Başarıyla Eklenmiştir
           
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false">
                <strong>Başarısız!</strong>
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="satir">
                <label>Başlık</label><br />
                <asp:TextBox ID="tb_baslik" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Kategori</label><br />
                <asp:TextBox ID="tb_kategoriID" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Alıcı Mail Adresi</label><br />
                <asp:TextBox ID="tb_aliciMail" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Mektup İçerik</label><br />
                <asp:TextBox ID="tb_icerik" runat="server" TextMode="MultiLine" CssClass="metinKutu"></asp:TextBox>
                <script>

                    CKEDITOR.replace('ContentPlaceHolder1_tb_icerik');
                </script>
            </div>
            <div class="satir">
                <label>Gönderim Tarihi</label><br />
                <asp:TextBox ID="tb_gonderimTarihi" runat="server" CssClass="metinKutu" ReadOnly="true"></asp:TextBox>
                <asp:Calendar ID="calendarGonderimTarihi" runat="server" OnSelectionChanged="calendarGonderimTarihi_SelectionChanged" Visible="false"></asp:Calendar>
                <br />
                <br />
                <br />
                <asp:Button ID="btnTarihSec" runat="server" Text="Tarihi Seç" OnClick="btnTarihSec_Click1" />
            </div>
            <div class="satir">
                <asp:LinkButton ID="lbtn_mektupEkle" runat="server" CssClass="islemButton" OnClick="lbtn_mektupEkle_Click">Mektup Gönder</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
