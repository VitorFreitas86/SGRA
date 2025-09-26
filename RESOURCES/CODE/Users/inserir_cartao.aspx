<%@ Page Title="" Language="C#" MasterPageFile="~/acessos.Master" AutoEventWireup="true" CodeBehind="inserir_cartao.aspx.cs" Inherits="WebApplication10.Users.inserir_cartao" %>
<%@ Register Src="~/controls/cartao_form.ascx" TagPrefix="uc4" TagName="cartao_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="div_background_withe_70_cartao">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ValidateRequestMode="Disabled">
            <ContentTemplate>
                <div style="height: 15px;"></div>
                <div class="panel_headar_insert">
                    <asp:Label ID="Label1" runat="server" Text="Novo Requerimento de Cartão de Identificação/Acesso" class="header_letras3"></asp:Label>
                </div>
                <div class="roundCorner_insert">
                    <uc4:cartao_form runat="server" ID="cartao_form" Visible="true" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
