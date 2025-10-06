<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/MasterPage.Master" AutoEventWireup="true" CodeBehind="KategoriDuzenle.aspx.cs" Inherits="OyuncakKovasiWebApp.YoneticiPanel.KategoriDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
    <div class="formBaslik">
        <h3>Kategori Düzenle</h3>
    </div>
    <div class="formIcerik">
        <asp:Panel ID="pnl_basarili" runat="server" class="basariliPanel" Visible="false">
            <label>Kategori düzenleme işlemi <b> başarıyla </b> gerçekleşti </label>
        </asp:Panel>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false">
            <asp:Label ID="lbl_hataMesaj" runat="server"></asp:Label>
        </asp:Panel>
        <div class="satir">
            <label class="etiket">Kategori Adı</label><br />
            <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu" placeholder="lütfen Boş Bırakmayınız" MaxLength="25"></asp:TextBox>
        </div>
        <div class="satir">
            <asp:CheckBox ID="cb_durum" runat="server" Text="Aktif Kategori" CssClass="secimKutu" />
        </div>
        <div class="satir">
            <asp:Button ID="btn_kategoriDuzenle" runat="server" Text="Kategori Düzenle" CssClass="buton" OnClick="btn_kategoriDuzenle_Click" />
        </div>
    </div>
</div>
</asp:Content>
