<%@ Page Title="" Language="C#" MasterPageFile="~/Arayuz.Master" AutoEventWireup="true" CodeBehind="MakaleDetay.aspx.cs" Inherits="OyuncakKovasiWebApp.MakaleDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <article class="makale">
        <div>
            <asp:Image ID="img_resim" runat="server" Style="width: 100%; border-bottom: 10px solid #0bc172" />

            <%-- <h3 class="resimUstu">
            <label><%# Eval("Baslik") %></label>
        </h3>--%>
        </div>
        <div style="margin-top: 30px; margin-bottom: 10px">
            <h1>
                <asp:Label ID="lbl_baslik" runat="server"></asp:Label>
            </h1>
        </div>
        <div class="kategoriYazar">

            <label>
                Kategori :
                <asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal>
                | 
            Yazar :
                <asp:Literal ID="ltrl_yazar" runat="server"></asp:Literal>
            </label>
            <span>Ekleme Tarihi :<asp:Literal ID="ltrl_eklemeTarihi" runat="server"></asp:Literal>
                |
            Görüntüleme :
                <asp:Literal ID="ltrl_gorntulemeSayi" runat="server"></asp:Literal></span>
            <div style="clear: both"></div>
        </div>
        <div style="margin-top: 10px; text-align: justify">
            <asp:Literal ID="lbl_icerik" runat="server"></asp:Literal>
        </div>
    </article>
    <div class="yorumTasiyici">
        <div class="yorumbaslik">
            <h3>Yorumlar</h3>
        </div>
        <div class="yorumIcerik">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliPanel" Visible="false">
                <label>Yorum Başarıyla Eklenmiştir. Admin onayından sonra yayınlanacaktır</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnl_girisVar" runat="server" Visible="false">
                <div class="yorumsatir">
                    <label>Yorum Yazınız</label><br />
                    <asp:TextBox ID="tb_yorum" runat="server" TextMode="MultiLine" CssClass="yorumMetinKutu"></asp:TextBox>
                </div>
                <div class="yorumsatir">
                    <asp:Button ID="btn_yorumyap" runat="server" OnClick="btn_yorumyap_Click" CssClass="buton" Text="Yorum Yap" />
                </div>
            </asp:Panel>
            <asp:Panel ID="pnl_GirisYok" runat="server">
                Yorum yapabilmek için lütfen <a href="GirisYap.aspx" class="girisyaplink">Giriş Yapınız </a>
            </asp:Panel>
        </div>

    </div>
    <div class="yorumlar">
        <asp:Repeater ID="rp_yorumlar" runat="server">
            <ItemTemplate>
                <label><%# Eval("Uye") %></label> | <label><%# Eval("TarihStr") %></label><br />
                <%# Eval("Icerik") %>
                <hr style="margin:10px 0;" />
            </ItemTemplate>
        </asp:Repeater>
        <asp:Panel ID="pnl_yorumYok" runat="server">
            <h4>Bu makaleye henüz yorum yapılmamış</h4>
        </asp:Panel>
    </div>
</asp:Content>
