<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/MasterPage.Master" AutoEventWireup="true" CodeBehind="MakaleEkle.aspx.cs" Inherits="OyuncakKovasiWebApp.YoneticiPanel.MakaleEkle" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="assets\ckeditor\ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Makale Ekle</h3>
        </div>
        <div class="formIcerik">
            <asp:Panel ID="pnl_basarili" runat="server" class="basariliPanel" Visible="false">
                <label>Makale ekleme işlemi <b>başarıyla </b>gerçekleşti </label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false">
                <asp:Label ID="lbl_hataMesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="solKolon">
                <div class="satir">
                    <label class="etiket">Kategori</label><br />
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" DataValueField="ID" DataTextField="Isim" CssClass="dropdown"></asp:DropDownList>
                </div>
                <div class="satir">
                    <label class="etiket">Başlık</label><br />
                    <asp:TextBox ID="tb_baslik" runat="server" CssClass="metinKutu"></asp:TextBox>
                </div>
                <div class="satir">
                    <label class="etiket">Makale Resmi</label><br />
                    <asp:FileUpload ID="fu_resim" runat="server" CssClass="metinKutu" />
                </div>
                <div class="satir">
                    <asp:CheckBox ID="cb_AktifMi" runat="server" CssClass="secimKutu" Text="Makaleyi Yayınla"></asp:CheckBox>
                </div>
                <div class="satir">
                    <asp:Button ID="btn_makaleEkle" runat="server" Text="Makale Kaydet" CssClass="buton" OnClick="btn_makaleEkle_Click" />
                </div>
            </div>
            <div class="sagKolon">
                <div class="satir">
                    <label class="etiket">Özet</label><br />
                    <asp:TextBox ID="tb_ozet" runat="server" CssClass="metinKutu fullwith" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="satir">
                    <label class="etiket">İçerik</label><br />
                    <asp:TextBox ID="tb_icerik" runat="server" CssClass="metinKutu fullwith" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div style="clear: both"></div>
        </div>
    </div>
    <script>
        CKEDITOR.replace('ContentPlaceHolder1_tb_icerik');
    </script>
</asp:Content>
