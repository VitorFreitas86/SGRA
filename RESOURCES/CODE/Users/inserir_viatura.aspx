<%@ Page Title="" Language="C#" MasterPageFile="~/acessos.Master" AutoEventWireup="true" CodeBehind="inserir_viatura.aspx.cs" Inherits="WebApplication10.Users.inserir_viatura" %>
<%@ Register Src="~/controls/viatura_form.ascx" TagPrefix="uc2" TagName="viatura_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="div_background_withe_70">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ValidateRequestMode="Disabled">
            <ContentTemplate>
                <div style="height: 15px;"></div>
                <div class="panel_headar_insert">
                    <asp:Label ID="Label1" runat="server" Text="Novo Requerimento de Circulação de Viatura" class="header_letras3"></asp:Label>
                </div>
                <div class="roundCorner_insert">
                    <uc2:viatura_form runat="server" ID="viatura_form" Visible="true" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
