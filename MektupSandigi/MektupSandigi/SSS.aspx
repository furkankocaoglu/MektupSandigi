<%@ Page Title="" Language="C#" MasterPageFile="~/AnaEkran.Master" AutoEventWireup="true" CodeBehind="SSS.aspx.cs" Inherits="MektupSandigi.SSS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Sıkça Sorulan Sorular</h1>
        <ul>
            <li><strong>Mektup Sandığı nedir?</strong><br />
                Mektup Sandığı, kullanıcıların kendilerine veya başkalarına gelecekte gönderilecek mektuplar yazabilmelerini sağlayan bir platformdur. Mektuplar, belirlenen tarihte otomatik olarak açılır ve kullanıcıya teslim edilir.</li>

            <li><strong>Nasıl mektup yazabilirim?</strong><br />
                Kullanıcılar, platformda bulunan "Mektup Yaz" bölümüne giderek metin alanına istedikleri mesajı yazabilir, tarih belirleyebilir ve isteğe bağlı olarak fotoğraf veya video ekleyebilirler.</li>

            <li><strong>Mektubun açılma tarihini nasıl belirleyebilirim?</strong><br />
                Mektup yazarken,  takvim arayüzü üzerinden açılmasını istediğiniz tarihi seçebilirsiniz. Tarih, mektubu açma zamanını belirleyecektir.</li>

            <li><strong>Mektubum açıldığında ne olacak?</strong><br />
                Mektubunuzun açılma tarihi geldiğinde, kullanıcıya mail içerisinde iletilen link üzerinden görüntüleme yaptığında üyelik ekranınızdan okunup okunmadığını görebileceksiniz. </li>

            <li><strong>Platforma nasıl kayıt olabilirim?</strong><br />
                Kayıt olmak için ana sayfada bulunan "Üye Ol" butonuna tıklayarak gerekli bilgileri doldurabilir ve hesap oluşturabilirsiniz.</li>

            <li><strong>Gizlilik ve güvenlik nasıl sağlanıyor?</strong><br />
                Kullanıcı bilgileriniz gizli tutulur ve güvenli bir şekilde saklanır. Platform, kişisel verilerinizi korumak için gerekli tüm önlemleri alır.</li>

            <li><strong>Destek almak istersem ne yapmalıyım?</strong><br />
                Herhangi bir sorunla karşılaşırsanız veya destek almak isterseniz, "Geliştirmemize yardımcı olun" bölümünden bize ulaşabilirsiniz. Ekibimiz, sorularınızı değerlendirmekten memnuniyet duyacaktır.</li>
        </ul>
    </div>
</asp:Content>
