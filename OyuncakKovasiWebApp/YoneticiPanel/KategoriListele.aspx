<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/MasterPage.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="OyuncakKovasiWebApp.YoneticiPanel.KategoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Kategoriler</h3>
        </div>
        <div class="formIcerik">
            <asp:ListView ID="lv_kategoriler" runat="server" OnItemCommand="lv_kategoriler_ItemCommand">
                <LayoutTemplate>
                    <table class="liste" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Kategori No</th>
                                <th>Kategori Adı</th>
                                <th>Durum</th>
                                <th>Seçenekler</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("ID") %>
                        </td>
                        <td>
                            <%# Eval("Isim") %>
                        </td>
                        <td>
                            <%# Eval("DurumStr") %>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbtn_durumDegistir" runat="server" CssClass="listeButon durum" CommandArgument='<%# Eval("ID") %>'>Durum Değiştir</asp:LinkButton>
                            <a href='KategoriDuzenle.aspx?kategoriID=<%# Eval("ID") %>' class="listeButon duzenle">Düzenle</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
