<%@ Page Title="" Language="C#" MasterPageFile="~/acessos.Master" AutoEventWireup="true" CodeBehind="entidade.aspx.cs" Inherits="WebApplication10.Admin.entidade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%= Page.ResolveUrl("~/Layout/Menu.css")%>" type="text/css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="div_background_withe">
                <asp:Panel ID="Panel_header" runat="server" Width="100%" Style="padding-top: 15px;">
                    <asp:Label ID="Label7" runat="server" Text="Gestão de Pessoas Requerentes" CssClass="header_letras2"></asp:Label>
                    <div style="float: right; position: relative; margin-left: 87%; margin-top: -32px;">
                        <asp:ImageButton ID="LinkButton1" runat="server" ImageUrl="~/Layout/img/add_empresa.png" Width="28px" ToolTip="Adicionar Nova Entidade" />
                    </div>
                </asp:Panel>
                <div class="roundCorner" id="GridView_div">
                    <asp:GridView ID="GridView_entidade" runat="server" ShowFooter="true" GridLines="None" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                        OnRowCancelingEdit="GridView1_RowCancelingEdit" AutoGenerateColumns="false" DataKeyNames="identidade" Width="100%" OnRowCreated="GridView_entidade_RowCreated" EmptyDataText="Não existem dados a apresentar">
                        <EditRowStyle BackColor="#0d4365" />
                        <RowStyle BackColor="#e8e8e8" BorderWidth="0" Font-Names="Ubuntu" ForeColor="#0d4465" Font-Size="12px" />
                        <Columns>
                            <asp:CommandField ShowEditButton="True" UpdateText="Atualizar" EditText="Acesso" CancelText="Cancelar" CausesValidation="false"
                                ButtonType="Image" EditImageUrl="../Layout/img/edit_e.png" HeaderStyle-CssClass="titleGrid" CancelImageUrl="../Layout/img/cancel_edit.png" UpdateImageUrl="../Layout/img/confirm_edit.png" FooterStyle-CssClass="footerGridRoundEsq" />
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" HeaderText="Nome" ShowHeader="true" HeaderStyle-CssClass="titleGrid" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:Label ID="nome" runat="server" Text='<%# Bind("Nome")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_nome" runat="server" Text='<%# Eval("Nome") %>' MaxLength="20"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" HeaderText="Rua" ShowHeader="true" HeaderStyle-CssClass="titleGrid" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:Label ID="rua" runat="server" Text='<%# Bind("rua")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_rua" runat="server" Text='<%# Eval("rua") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" HeaderText="C. Postal" ShowHeader="true" HeaderStyle-CssClass="titleGrid" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:Label ID="codigopostal" runat="server" Text='<%# Bind("codigopostal")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_codigopostal" runat="server" Width="60px" Text='<%# Eval("codigopostal") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" HeaderText="Cidade" ShowHeader="true" HeaderStyle-CssClass="titleGrid" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:Label ID="cidade" runat="server" Text='<%# Bind("cidade")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_cidade" runat="server" Text='<%# Eval("cidade") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" HeaderText="País" ShowHeader="true" HeaderStyle-CssClass="titleGrid" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:Label ID="pais" runat="server" Text='<%# Bind("pais")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_pais" runat="server" Text='<%# Eval("pais") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" HeaderText="Código" ShowHeader="true" HeaderStyle-CssClass="titleGridRoundDir" FooterStyle-CssClass="footerGridRoundDir">
                                <ItemTemplate>
                                    <asp:Label ID="codigo" runat="server" Text='<%# Bind("codigo")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_codigo" runat="server" Text='<%# Eval("codigo") %>' Width="25px"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle />
                    </asp:GridView>
                       <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" BackColor="#FEDAD8" ValidationGroup="MyValidationGroup" Style="margin-bottom: 15px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="99.8%" />
                 
                </div>
                <asp:Panel ID="Panel1" runat="server" CssClass="modalPanelEntidade" Style="display: none">
                    <asp:Panel ID="Panel2" runat="server" cssclass="header_popup_desing">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Nova Entidade" cssclass="header_popup_letras"></asp:Label>
                                </td>
                                <td>
                                    <div class="header_popup_btn_close">
                                        <asp:ImageButton ID="Cancel" runat="server" ImageUrl="~/Layout/img/Close.png" Width="22px" Height="22px" />
                                    </div>

                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <div>
                        <table id="tableNewEntidade" class="table_Entidade_nova">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Entidade" CssClass="tableNewEntidade"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="nome_entidade" runat="server" MaxLength="20" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="nome_entidade"
                                        ErrorMessage="É Obrigatório o preenchimento."
                                        EnableClientScript="true"
                                        SetFocusOnError="true" Style="color: red;"
                                        Text="*" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Rua" CssClass="tableNewEntidade"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="rua" runat="server" MaxLength="45" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Código Postal" CssClass="tableNewEntidade"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="codigopostal" runat="server" MaxLength="45" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Cidade" CssClass="tableNewEntidade"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="cidade" runat="server" MaxLength="45" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="País" CssClass="tableNewEntidade"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="pais" runat="server" MaxLength="45" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Código" CssClass="tableNewEntidade"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="codigo" runat="server" MaxLength="4" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <div class="popup_btn_insert">
                                        <asp:ImageButton ID="insert_entidade" runat="server" OnClick="ins_entidade_Click" ImageUrl="~/Layout/img/confirmar.png" ToolTip="Gravar Dados Entidade" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:ValidationSummary ID="ValidationSummary4" runat="server" ForeColor="Red" BackColor="#FEDAD8" ValidationGroup="MyValidationGroup" Style="margin-left: 23px; margin-bottom: 15px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="90%" />
                        <div class="clear"></div>
                    </div>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender BackgroundCssClass="modalBg" DropShadow="true" ID="ModalPopupExtender1" PopupControlID="Panel1" runat="server"
                    TargetControlID="LinkButton1" PopupDragHandleControlID="Panel2" CancelControlID="Cancel">
                </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
