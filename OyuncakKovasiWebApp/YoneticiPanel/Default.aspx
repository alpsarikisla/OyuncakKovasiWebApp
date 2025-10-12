<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OyuncakKovasiWebApp.YoneticiPanel.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="counts">
        <div class="countBox">
            <h3>
                <asp:Label ID="lbl_categoryCount" runat="server">0</asp:Label></h3>
            adet kategori
        </div>
        <div class="countBox">
            <h3>
                <asp:Label ID="lbl_arthicleCount" runat="server">0</asp:Label></h3>
            adet makale
        </div>
        <div class="countBox">
            <h3>
                <asp:Label ID="lbl_memberCount" runat="server">0</asp:Label></h3>
            adet üye
        </div>
        <div class="countBox">
            <h3>
                <asp:Label ID="lbl_commentCount" runat="server">0</asp:Label></h3>
            adet yorum
        </div>
        <div style="clear:both"></div>
    </div>
</asp:Content>
