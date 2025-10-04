<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/MasterPage.Master" AutoEventWireup="true" CodeBehind="KategoriListeleGridView.aspx.cs" Inherits="OyuncakKovasiWebApp.YoneticiPanel.KategoriListeleGridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Kategoriler</h3>
        </div>
        <div class="formIcerik">
            <asp:GridView ID="gv_kategoriler" runat="server" CssClass="liste" Visible="false"></asp:GridView>
            <asp:GridView ID="gv_kategoriSinirliKolon" runat="server" AutoGenerateColumns="false" CssClass="liste">
               <%-- <HeaderStyle CssClass="listeBaslik" />--%>
                <AlternatingRowStyle BackColor="Azure"/>
                <Columns>
                    <asp:BoundField HeaderText="Kategori No" DataField="ID"/>
                    <asp:BoundField HeaderText="Kategori Adı" DataField="Isim" />
                    <asp:BoundField HeaderText="Durum" DataField="DurumStr" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
