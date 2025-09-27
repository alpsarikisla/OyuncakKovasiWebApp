<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YoneticiGiris.aspx.cs" Inherits="OyuncakKovasiWebApp.YoneticiPanel.YoneticiGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yönetici Giriş</title>
    <link href="Assets/css/GirisStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="anaTasiyici golge">
            <div class="sol">
                <%--<img src="assets\resimler\GirisPanelBanner.jpg" />--%>
                <h1 style="margin:20px">Welcome</h1>
            </div>
            <div class="sag">
                <div class="baslik">
                    <h2>Yönetici Giriş</h2>
                    <p>Giriş Yapmak İçin Lütfen bilgilerinizi Giriniz</p>
                </div>
                <div class="satir">
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="metinKutu" placeholder="mail adresiniz" Text="developer@developer.com"></asp:TextBox>
                </div>
                <div class="satir">
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinKutu" placeholder="Şifreniz" Text="1234"></asp:TextBox>
                </div>
                <div class="satir">
                    <asp:Button ID="btn_giris" runat="server" Text="Giriş Yap" CssClass="buton" OnClick="btn_giris_Click" />
                </div>
                <div class="satir" style="text-align: center">
                    <a href="#" class="sifremiUnuttum">Şifremi Unuttum</a>
                </div>
                <asp:Panel ID="pnl_mesaj" runat="server" CssClass="mesaj" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </asp:Panel>
            </div>
            <div style="clear: both"></div>
        </div>
    </form>
</body>
</html>
