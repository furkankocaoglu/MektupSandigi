<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/AnaEkran.Master" AutoEventWireup="true" CodeBehind="UyeOl.aspx.cs" Inherits="MektupSandigi.UyeOl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Üye Ol</title>
    <link href="CSS/UyeOl.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tasiyici">
        <div class="GirisKutu">
            <div class="baslik">
                <h2>Mektup Sandığı</h2>
                <h3>Kayıt Ol</h3>
            </div>
            <div class="UyeFormIcerik">
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarilipanel" Visible="false">
                    <label>Üyelik başarıyla oluşturulmuştur</label>
                </asp:Panel>
                <div class="satir ">
                    <label class="UyeFormetiket">Kullanıcı Adı</label>
                    <asp:TextBox ID="tb_kullanici" runat="server" CssClass="metinkutu" placeholder="Kullanıcı Adınız"></asp:TextBox>
                </div>
                <div class="satir ">
                    <label class="UyeFormetiket">E-mail</label>
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="metinkutu" placeholder="E-mail"></asp:TextBox>
                    <asp:RegularExpressionValidator
                        ID="rev_mail"
                        runat="server"
                        ControlToValidate="tb_mail"
                        ErrorMessage="Geçersiz e-posta adresi!"
                        CssClass="validatorMessage"
                        ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                        ForeColor="Red"
                        Display="Dynamic">
    </asp:RegularExpressionValidator>
                </div>
                <div class="satir ">
                    <label class="UyeFormetiket">Şifre</label>
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinkutu" placeholder="Şifreniz" TextMode="Password"></asp:TextBox>
                </div>
                <asp:Button ID="btn_tikla" runat="server" Text="Üyelik Oluştur" CssClass="tiklabutton" OnClick="btn_tikla_Click1" />
            </div>
        </div>
    </div>
</asp:Content>
