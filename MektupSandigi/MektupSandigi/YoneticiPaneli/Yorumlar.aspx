<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="Yorumlar.aspx.cs" Inherits="MektupSandigi.YoneticiPaneli.Yorumlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Yorumlar.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>YORUMLAR</h3>
        </div>
        <asp:GridView ID="gv_yorumlar" runat="server" CssClass="gv-style" AutoGenerateColumns="False" OnRowCommand="gv_yorumlar_RowCommand">
            <Columns>
                <asp:BoundField DataField="YorumID" HeaderText="Yorum ID" />
                <asp:BoundField DataField="KullaniciID" HeaderText="Kullanıcı ID" />
                <asp:BoundField DataField="YorumIcerik" HeaderText="Yorum İçeriği" />
                <asp:BoundField DataField="OlusturmaTarihi" HeaderText="Oluşturma Tarihi" />
                <asp:BoundField DataField="Onay" HeaderText="Onay" />
                <asp:BoundField DataField="Durum" HeaderText="Durum" />
                <asp:BoundField DataField="Silinmis" HeaderText="Silinmis" />
                <asp:TemplateField HeaderText="İşlemler">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtn_onayla" runat="server" CommandArgument='<%# Eval("YorumID") %>' CommandName="onayla">Onayla</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_durum" runat="server" CommandArgument='<%# Eval("YorumID") %>' CommandName="durum">DurumGüncelle</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CommandArgument='<%# Eval("YorumID") %>' CommandName="sil">Sil</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_sill" runat="server" CommandArgument='<%# Eval("YorumID") %>' CommandName="sill">Hard Delete</asp:LinkButton>
                        
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
