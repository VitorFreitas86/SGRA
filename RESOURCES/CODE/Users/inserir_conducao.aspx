<%@ Page Title="" Language="C#" MasterPageFile="~/acessos.Master" AutoEventWireup="true" CodeBehind="inserir_conducao.aspx.cs" Inherits="WebApplication10.Users.inserir_conducao" %>
<%@ Register Src="~/controls/conducao_form.ascx" TagPrefix="uc1" TagName="conducao_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="div_background_withe_70">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ValidateRequestMode="Disabled">
            <ContentTemplate>
                <div style="height: 15px;"></div>
                <div class="panel_headar_insert">
                    <asp:Label ID="Label7" runat="server" Text="Novo Requerimento de Condução" class="header_letras3"></asp:Label>
                </div>
                <div class="roundCorner_insert">
                    <uc1:conducao_form runat="server" ID="conducao_form" Visible="true" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
