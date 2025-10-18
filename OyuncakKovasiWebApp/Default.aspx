<%@ Page Title="" Language="C#" MasterPageFile="~/Arayuz.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OyuncakKovasiWebApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rp_makaleler" runat="server">
        <ItemTemplate>
            <article class="makale">
                <div>
                    <img src="MakaleResimleri/<%# Eval("KapakResim") %>" style="width: 100%; border-bottom:10px solid #0bc172" />
                    <h3 class="resimUstu">
                        <label><%# Eval("Baslik") %></label>
                    </h3>
                </div>
                <div style="margin-top:30px; margin-bottom:10px">
                    <h1><%# Eval("Baslik") %></h1>
                </div>
                <div class="kategoriYazar">
                    <label>Kategori : <%# Eval ("KategoriAdi") %> | Yazar : <%#Eval ("Yazar") %> </label>
                    <span>Ekleme Tarihi : <%# Eval("EklemeTarihiStr") %> | Görüntüleme : <%# Eval("GoruntulemeSayi") %></span>
                    <div style="clear: both"></div>
                </div>
                <div style="margin-top:10px;">
                    <%# Eval("Ozet") %>
                    <br />
                    <a href="#" class="yazidevam">Yazının Devamı ...</a>
                </div>
            </article>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
