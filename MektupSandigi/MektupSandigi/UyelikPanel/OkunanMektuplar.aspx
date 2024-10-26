<%@ Page Title="" Language="C#" MasterPageFile="~/UyelikPanel/UyeEkran.Master" AutoEventWireup="true" CodeBehind="OkunanMektuplar.aspx.cs" Inherits="MektupSandigi.UyelikPanel.OkunanMektuplar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Okunan Mektuplarım</h2>
        <p>Bu sayfada mektubunuzu gönderdiğiniz kişinin mektup yazan linke giriş yapıp yapmadığını görebilirsiniz. Giriş yapıldıysa "okundu" statüsüne çekilecektir.</p>
        <asp:GridView ID="gvMektuplar" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Baslik" HeaderText="Başlık" />
                <asp:TemplateField HeaderText="Durum">
                    <ItemTemplate>
                        <%# Convert.ToBoolean(Eval("TeslimEdildiMi")) ? "Okundu" : "Okunmadı" %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
