<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/MasterPage.Master" AutoEventWireup="true" CodeBehind="MakaleListele.aspx.cs" Inherits="OyuncakKovasiWebApp.YoneticiPanel.MakaleListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Makaleler</h3>
        </div>
        <div class="formIcerik">
            <asp:ListView ID="lv_makaleler" runat="server">
                <LayoutTemplate>
                    <table class="liste" cellpadding="0">
                        <thead>
                            <tr>
                                <th>Resim</th>
                                <th>No</th>
                                <th>Başlık</th>
                                <th>Kategori</th>
                                <th>Yazar</th>
                                <th>Görüntüleme Sayı</th>
                                <th>Ekeleme Tarihi</th>
                                <th>Durum</th>
                                <th>Seçenekler</th>
                            </tr>
                        </thead>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center">
                            <img src='../MakaleResimleri/<%# Eval("KapakResim") %>' width="80" />
                        </td>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Baslik") %></td>
                        <td><%# Eval("KategoriAdi") %></td>
                        <td><%# Eval("Yazar") %></td>
                        <td><%# Eval("GoruntulemeSayi") %></td>
                        <td><%# Eval("EklemeTarihi") %></td>
                        <td><%# Eval("AktifMiStr") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_durumDegistir" runat="server" CssClass="listeButon durum" CommandArgument='<%# Eval("ID") %>'>Durum Değiştir</asp:LinkButton>
                            <a href='MakaleDuzenle.aspx?MakaleID=<%# Eval("ID") %>' class="listeButon duzenle">Düzenle</a>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="listeButon sil">Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>

