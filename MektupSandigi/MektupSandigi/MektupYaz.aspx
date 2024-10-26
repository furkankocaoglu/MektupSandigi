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
            <div class="formContainer">
                <div class="solTablo">
                    <table class="formTable">
                        <tr>
                            <td>
                                <label>Başlık</label></td>
                            <td>
                                <asp:TextBox ID="tb_baslik" runat="server" CssClass="metinKutu"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <label>Kategori</label></td>
                            <td>
                                <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="metinKutu"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>
                                <label>Alıcı Mail Adresi&nbsp;&nbsp;</label></td>
                            <td>
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
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="sagTablo">
                    <table class="formTable">
                        <tr>
                            <td>
                                <label>Mektup İçerik</label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="tb_icerik" runat="server" TextMode="MultiLine" CssClass="metinKutu" Rows="15" Width=650px Placeholder="Mektubunuzun gönderimi alıcı kişinin mail adresine yapılacağı için geri alınamayan bir işlem olduğunu ve içerik gönderildikten sonrasında düzenleme yapılamadığını belirtmek isteriz.."></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Açılış Tarihi</label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="tb_gonderimTarihi" runat="server" CssClass="tarihKutu" ReadOnly="true"></asp:TextBox>
                                <asp:Calendar ID="calendarGonderimTarihi" runat="server" OnSelectionChanged="calendarGonderimTarihi_SelectionChanged" Visible="false"></asp:Calendar>
                                <asp:Button ID="btnTarihSec" runat="server" Text="Açılış Tarihi Seç" OnClick="btnTarihSec_Click" />
                           </td>
                        </tr>
                    </table>
                </div>
           
        </div>

        <div class="satir">
            <asp:LinkButton ID="lbtn_mektupEkle" runat="server" CssClass="islemButton" OnClick="lbtn_mektupEkle_Click1">Mektup Gönder</asp:LinkButton>
        </div>
        </div>
    </div>
</asp:Content>
