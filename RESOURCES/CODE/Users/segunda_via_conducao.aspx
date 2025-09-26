<%@ Page Title="" Language="C#" MasterPageFile="~/acessos.Master" AutoEventWireup="true" CodeBehind="segunda_via_conducao.aspx.cs" Inherits="WebApplication10.Users.segunda_via_conducao" %>

<%@ Register Src="~/controls/conducao_form.ascx" TagPrefix="uc9" TagName="conducao_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel_filtros" runat="server" Visible="false" BackColor="#e1effd" BorderColor="#0E3E5B" BorderWidth="1px" CssClass="popup_pesquisa">
                <asp:RadioButtonList ID="RB_filtro" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="RB_filtro_SelectedIndexChanged" cssclass="rb_filtro">
                    <asp:ListItem Text="Nº Processo"></asp:ListItem>
                    <asp:ListItem Text="Data de Registo"></asp:ListItem>
                    <asp:ListItem Text="Nome Destinatário"></asp:ListItem>
                    <asp:ListItem Text="Estado do Pedido"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:TextBox ID="tb_data" runat="server" TextMode="DateTime" MaxLength="45" ValidationGroup="calendar" Visible="false" CssClass="tb_data_filtro"></asp:TextBox>
                <asp:ImageButton runat="Server" ID="ib_data" ImageUrl="~/Layout/img/calendar.png" Visible="false" Width="25px" ValidationGroup="calendar" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"
                    TargetControlID="tb_data" PopupButtonID="ib_data" DefaultView="Years" />
                <asp:TextBox ID="tb_pesq_num" runat="server" Visible="false" CssClass="tb_pesq_num_filtro"></asp:TextBox>
                <asp:TextBox ID="tb_nome" runat="server" Visible="false" CssClass="tb_nome_filtro"></asp:TextBox>
                <asp:DropDownList ID="ddl_estado" runat="server" Visible="false" CssClass="ddl_estado_filtro">
                    <asp:ListItem Text="Pendente" Value="Pendente"></asp:ListItem>
                    <asp:ListItem Text="Indeferido" Value="Indeferido"></asp:ListItem>
                    <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
                    <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
                </asp:DropDownList>
                <asp:ImageButton ID="ib_pesq" runat="server" OnClick="ib_pesq_Click" CssClass="ib_pesq_filtro" Visible="false" ImageUrl="~/Layout/img/search.png" Width="32" Height="32" />
            </asp:Panel>
            <div class="div_background_withe">
                <asp:Panel ID="Panel_header" runat="server" Width="100%" Style="padding-top: 15px;">
                    <asp:Label ID="Label7" runat="server" Text="Operações sobre Pedidos de Condução" CssClass="header_letras2"></asp:Label>
                    <div class="btns_headers_2">
                        <asp:ImageButton ID="ImageButton_filtros" ToolTip="Filtrar" runat="server" OnClick="ImageButton_filtros_Click" ImageUrl="~/Layout/img/filtros.png" Width="28px" Style="margin-right: 5px;" />
                    </div>
                </asp:Panel>
                <div>
                    <asp:GridView ID="GridView1" runat="server" Width="100%" ShowFooter="true"
                        AutoGenerateColumns="false" DataKeyNames="idconducao" OnRowCommand="GridView1_RowCommand" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging" GridLines="None" OnRowCreated="GridView1_RowCreated" OnDataBound="GridView1_DataBound">
                        <RowStyle BackColor="#e8e8e8" BorderWidth="0" Font-Names="Ubuntu" Font-Size="12px" ForeColor="#0d4465" />
                        <EmptyDataTemplate>
                            <div style="background-color: #e8e8e8; font-family: Ubuntu; font-size: 14px; color: #0d4465; padding: 5px 5px 5px 5px;">Não existem dados a apresentar.</div>
                        </EmptyDataTemplate>
                        <PagerTemplate> 
                            <table style="width: 100%; margin-top: 5px; border-collapse: collapse; border-spacing: 0;" >
                                <tr style="text-align: center;">
                                    <td>
                                        <asp:PlaceHolder ID="ph" runat="server"></asp:PlaceHolder>
                                    </td>
                                </tr>
                                <tr style="text-align: center;">
                                    <td>
                                        <asp:Label ID="Label_pager_status" runat="server" Text="" Style="font-family: ubuntu; font-size: 10px"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <Columns>
                            <asp:BoundField DataField="numero" HeaderText="Nº" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGridRoundEsq" />
                            <asp:BoundField DataField="datareg" HeaderText="Registo" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid" />
                            <asp:BoundField DataField="nome" HeaderText="Destinatário" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid" />
                            <asp:BoundField DataField="estado" HeaderText="Estado" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid" />
                            <asp:TemplateField HeaderText="2º Via" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="segunda_via" runat="server" CommandName="2via"
                                        ImageUrl="~/Layout/img/doc_segunda.png" Width="30px" Height="30" ToolTip="Segunda Via" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Renovação" HeaderStyle-CssClass="titleGridRoundDir" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGridRoundDir">
                                <ItemTemplate>
                                    <asp:ImageButton ID="renovacao" runat="server" CommandName="renovacao"
                                        ImageUrl="~/Layout/img/doc_renovacao.png" Width="30px" Height="30" ToolTip="Renovações" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPanel" Style="display: none">
        <asp:Panel ID="Panel2" runat="server" cssclass="header_popup_desing">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Inserir Pedido de Renovação/2º Via" cssclass="header_popup_letras"></asp:Label>
                    </td>
                    <td>
                        <div class="header_popup_btn_close">
                            <asp:ImageButton ID="Cancel" runat="server" ImageUrl="~/Layout/img/Close.png" Width="22px" Height="22px" OnClick="Cancel_Click" ValidateRequestMode="Disabled" ValidationGroup="none" />
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel_operacoes_conducao" runat="server" ValidateRequestMode="Disabled">
            <ContentTemplate>
                <div>
                    <uc9:conducao_form runat="server" ID="conducao_form" Visible="false" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none;" />
    <ajaxToolkit:ModalPopupExtender BackgroundCssClass="modalBg" DropShadow="true" ID="ModalPopupExtender1" PopupControlID="Panel1" runat="server"
        TargetControlID="Button1" PopupDragHandleControlID="Panel2" CancelControlID="Cancel">
    </ajaxToolkit:ModalPopupExtender>
</asp:Content>



