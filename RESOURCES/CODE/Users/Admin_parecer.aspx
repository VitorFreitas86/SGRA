<%@ Page Title="" Language="C#" MasterPageFile="~/acessos.Master" AutoEventWireup="true" CodeBehind="Admin_parecer.aspx.cs" Inherits="WebApplication10.Users.Admin_parecer" %>
<%@ Register Src="~/controls/emitir_parecer.ascx" TagPrefix="uc9" TagName="cartao_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div class="outer">
                <div class="middle">
                    <div class="inner_home">

                        <div style="background-color: #fff; width: 90%; margin-left: 5%; padding-left: 1%; padding-bottom: 1%; margin-right: 5%; padding-right: 1%; box-shadow: 0px 0px 2px 2px rgb(145, 144, 144); -moz-border-radius: 5px; border-radius: 5px; min-width: 800px;">
                            <div class="roundCorner" id="GridView_div" style="padding-top: 15px;">
                                <asp:GridView ID="GridView_cartao" runat="server" Width="100%" ShowFooter="true"
                                    AutoGenerateColumns="false" DataKeyNames="idcartao" AllowPaging="false" OnRowCommand="GridView_cartao_RowCommand" GridLines="None" EmptyDataText="Não existem dados a apresentar" OnRowDataBound="GridView_cartao_RowDataBound">
                                    <RowStyle BackColor="#e8e8e8" BorderWidth="0" Font-Names="Ubuntu" Font-Size="12px" ForeColor="#0d4465" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton_foto" runat="server" Width="75" Height="90" CommandName="fotografia" ImageAlign="Middle" ToolTip="Download Fotografia" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="points" Visible="false">
                                            <HeaderTemplate>fotografia</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lb_fotografia" runat="server" Text='<%# Bind("fotografia") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGridRoundEsq">
                                            <HeaderTemplate>Registo</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbdatareg" runat="server" Text='<%# Bind("data_reg") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                            <HeaderTemplate>Tipo</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lb_tipo_cartao" runat="server" Text='<%# Bind("tipo_de_pedido") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                            <HeaderTemplate>Nome</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="n_identificacao" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                            <HeaderTemplate>Entidade</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="entidade_identidade" runat="server" Text='<%# Bind("entidade_identidade") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="points" Visible="false">
                                            <HeaderTemplate>path_doc_final</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lb_path_doc_final" runat="server" Text='<%# Bind("path_doc_final") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="parecer" runat="server" CommandName="ver_cartao"
                                                    ImageUrl="~/Layout/img/parecer.png" Width="32" Height="32" ToolTip="Ver mais" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" CssClass="modalPanel" Style="display: none">
                        <asp:Panel ID="Panel2" runat="server" class="header_popup_desing">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Emitir parecer sobre o cartão de identificação/acesso" class="header_popup_letras"></asp:Label>
                                    </td>
                                    <td>
                                        <div class="header_popup_btn_close">
                                            <asp:ImageButton ID="Cancel" runat="server" ImageUrl="~/Layout/img/Close.png" Width="22px" Height="22px" ValidateRequestMode="Disabled" ValidationGroup="none" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <div>
                            <uc9:cartao_form runat="server" ID="cartao_form" Visible="true" />
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none;" />
            <ajaxToolkit:ModalPopupExtender BackgroundCssClass="modalBg" DropShadow="true" ID="ModalPopupExtender1" PopupControlID="Panel1" runat="server"
                TargetControlID="Button1" PopupDragHandleControlID="Panel2" CancelControlID="Cancel">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
