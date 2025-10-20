<%@ Page Title="" Language="C#" MasterPageFile="~/Arayuz.Master" AutoEventWireup="true" CodeBehind="GirisYap.aspx.cs" Inherits="OyuncakKovasiWebApp.GirisYap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="girisTasiyici golge">
        <div style="text-align:center;">
            <img src="Assets/SayfaResimleri/tZhgVchaxs.gif" style="width:70%"/>
        </div>
        <div class="satir">
            <label>Mail Adresiniz</label><br />
            <asp:TextBox ID="tb_mail" runat="server" CssClass="metinKutu" placeholder="ornek@ornek.com"></asp:TextBox>
        </div>
        <div class="satir">
            <label>Şifreniz</label><br />
            <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinKutu" TextMode="Password" placeholder="********"></asp:TextBox>
        </div>
        <div class="satir" style="text-align:center">
            <a href="#">Şifremi Unuttum</a>
        </div>
        <div class="satir">
            <asp:Button ID="lbtn_giris" runat="server" CssClass="buton" Text="Giriş Yap" OnClick="lbtn_giris_Click"/>
        </div>
    </div>
</asp:Content>
