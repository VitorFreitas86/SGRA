<%@ Page Title="" Language="C#" MasterPageFile="~/acessos.Master" AutoEventWireup="true" CodeBehind="gerir_cartao.aspx.cs" Inherits="WebApplication10.Admin.gerir_cartao" %>

<%@ Register Src="~/controls/cartao_admin.ascx" TagPrefix="uc7" TagName="cartao_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintGridData() {

            var prtGrid = document.getElementById('<%=GridView_cartao.ClientID %>');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>
    <script type="text/javascript">
        function toBottom() {
            window.scrollTo(0, document.body.scrollHeight);
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
            <asp:Panel ID="Panel_filtros" runat="server" Visible="false" BackColor="#e1effd" BorderColor="#0E3E5B" BorderWidth="1px" CssClass="popup_pesquisa">
                <asp:RadioButtonList ID="RB_filtro" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="RB_filtro_SelectedIndexChanged" cssclass="rb_filtro">
                    <asp:ListItem Text="Nº Processo"></asp:ListItem>
                    <asp:ListItem Text="Data de Registo"></asp:ListItem>
                    <asp:ListItem Text="Nome Destinatário"></asp:ListItem>
                    <asp:ListItem Text="Estado do Pedido"></asp:ListItem>
                    <asp:ListItem Text="Entidade"></asp:ListItem>
                </asp:RadioButtonList>
                <div>
                <asp:TextBox ID="tb_data" runat="server" TextMode="DateTime" MaxLength="45" ValidationGroup="calendar" Visible="false" CssClass="tb_data_filtro_admin"></asp:TextBox>
                <asp:ImageButton runat="Server" ID="ib_data" ImageUrl="~/Layout/img/calendar.png" Visible="false" Width="25px" ValidationGroup="calendar" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"
                    TargetControlID="tb_data" PopupButtonID="ib_data" DefaultView="Years" />
                      <asp:ImageButton ID="ImageButton4" runat="server" OnClick="ib_pesq_Click" CssClass="ib_pesq_filtro" Visible="false" ImageUrl="~/Layout/img/search.png" Width="32" Height="32" />
         
           </div>
                     <div>
                    <asp:TextBox ID="tb_pesq_num" runat="server" Visible="false" CssClass="tb_pesq_num_filtro"></asp:TextBox>
            <asp:ImageButton ID="ImageButton3" runat="server" OnClick="ib_pesq_Click" CssClass="ib_pesq_filtro" Visible="false" ImageUrl="~/Layout/img/search.png" Width="32" Height="32" />
         
                     </div>
                <div>
                  <asp:TextBox ID="tb_nome" runat="server" Visible="false" CssClass="tb_nome_filtro_admin"></asp:TextBox>
            <asp:ImageButton ID="ImageButton2" runat="server" OnClick="ib_pesq_Click" CssClass="ib_pesq_filtro" Visible="false" ImageUrl="~/Layout/img/search.png" Width="32" Height="32" />
         
                       </div>
                       <div>
                 <asp:DropDownList ID="ddl_estado" runat="server" Visible="false" CssClass="ddl_estado_filtro_admin">
                    <asp:ListItem Text="Pendente" Value="Pendente"></asp:ListItem>
                    <asp:ListItem Text="Indeferido" Value="Indeferido"></asp:ListItem>
                    <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
                    <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
                </asp:DropDownList>
                      <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ib_pesq_Click" CssClass="ib_pesq_filtro" Visible="false" ImageUrl="~/Layout/img/search.png" Width="32" Height="32" />
         
                   </div>
                <div style="margin-top: -5px;margin-bottom: 5px;width: auto;margin-left: 24%;text-align: right;padding-left: 22%;">
                <asp:DropDownList ID="ddl_entidade" runat="server"  Visible="false"></asp:DropDownList>
                <asp:ImageButton ID="ib_pesq" runat="server" OnClick="ib_pesq_Click" CssClass="ib_pesq_filtro" Visible="false" ImageUrl="~/Layout/img/search.png" Width="32" Height="32" />
           </div>
                     </asp:Panel>
            <div class="div_background_withe">
                <asp:Panel ID="Panel_header" runat="server" Width="100%" Style="padding-top: 15px;">
                    <asp:Label ID="Label7" runat="server" Text="Gestão de Pedidos de Cartões de Identificação/Acesso" CssClass="header_letras2"></asp:Label>
                    <div class="btns_headers_3">
                        <asp:ImageButton ID="ImageButton_print" runat="server" ToolTip="Imprimir" ImageUrl="~/Layout/img/imprimirgrid.png" OnClientClick="PrintGridData()" Width="28px" Style="margin-right: 5px;" />
                        <asp:ImageButton ID="ImageButton_filtros" ToolTip="Filtrar" runat="server" OnClick="ImageButton_filtros_Click" ImageUrl="~/Layout/img/filtros.png" Width="28px" Style="margin-right: 5px;" />
                    </div>
                </asp:Panel>
                <div class="roundCorner" id="GridView_div">
                    <asp:GridView ID="GridView_cartao" runat="server" Width="100%" ShowFooter="true"
                        AutoGenerateColumns="false" DataKeyNames="idcartao" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView_cartao_PageIndexChanging" OnRowCommand="GridView_cartao_RowCommand" OnRowDataBound="GridView_cartao_RowDataBound" GridLines="None" OnDataBound="GridView_cartao_DataBound" EmptyDataText="Não existem dados a apresentar">
                        <RowStyle BackColor="#e8e8e8" BorderWidth="0" Font-Names="Ubuntu" Font-Size="12px" ForeColor="#0d4465" />
                        <PagerTemplate> 
                            <table style="width: 100%; margin-top: 5px; border-collapse: collapse; border-spacing: 0; " >
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
                            <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGridRoundEsq">
                                <HeaderTemplate>Nº</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbnum" runat="server" Text='<%# Bind("numero") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
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
                            <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_estado" runat="server" Text='<%# Eval("estado")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false" HeaderStyle-CssClass="titleBTN" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <HeaderTemplate>fotocopia_bi</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lb_fotocopia_bi" runat="server" Text='<%# Bind("fotocopia_bi") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false">
                                <HeaderTemplate>fotocopia_vinculo_laboral</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lb_fotocopia_vinculo_laboral" runat="server" Text='<%# Bind("fotocopia_vinculo_laboral") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false">
                                <HeaderTemplate>fotografia</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lb_fotografia" runat="server" Text='<%# Bind("fotografia") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false">
                                <HeaderTemplate>registo_criminal</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lb_registo_criminal" runat="server" Text='<%# Bind("registo_criminal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false">
                                <HeaderTemplate>fotocopia_cartao_acompanhante</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lb_fotocopia_cartao_acompanhante" runat="server" Text='<%# Bind("fotocopia_cartao_acompanhante") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false">
                                <HeaderTemplate>path_doc_final</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lb_path_doc_final" runat="server" Text='<%# Bind("path_doc_final") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="2ºvia" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleGrid_2via" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <div class="div_btn_operacoes_admin">
                                        <asp:LinkButton runat="server" Text="_" ID="segunda_via" CommandName="segunda_via" ToolTip="2º Via" CssClass="btn_operacoes_pedidos_admin"></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Renovação" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleGrid" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <div class="div_btn_operacoes_admin">
                                        <asp:LinkButton runat="server" Text="_" ID="renovacao" CommandName="renovacao" ToolTip="Renovações" CssClass="btn_operacoes_pedidos_admin"></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton_foto" runat="server" Width="75" Height="90" CommandName="fotografia" ImageAlign="Middle" ToolTip="Download Fotografia" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="path_doc_final" runat="server" CommandName="path_doc_final"
                                        ImageUrl="~/Layout/img/doc.png" ToolTip="Documento Final" Visible="false" Width="32px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="fotocopia_bi" runat="server" CommandName="fotocopia_bi"
                                        ImageUrl="~/Layout/img/bi_card.png" Width="32" Height="32" ToolTip="BI/CC/Passapote" Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="fotocopia_vinculo_laboral" runat="server" CommandName="fotocopia_vinculo_laboral"
                                        ImageUrl="~/Layout/img/contrat.png" Width="32" Height="32" ToolTip="Vinculo Laboral" Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="registo_criminal" Visible="false" runat="server" CommandName="registo_criminal"
                                        ImageUrl="~/Layout/img/r_criminal.png" Width="32" ToolTip="Registo Criminal" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="fotocopia_cartao_acompanhante" Visible="false" runat="server" CommandName="fotocopia_cartao_acompanhante"
                                        ImageUrl="~/Layout/img/c_acompanhante.png" Width="32px" ToolTip="Cartão de Acompanhante" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="admin" runat="server" CommandName="admin"
                                        ImageUrl="~/Layout/img/admin.png" Width="32" Height="32" ToolTip="Administrar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton_s_email" OnClientClick="toBottom()" runat="server" CommandName="send_email" Height="32" ImageUrl="~/Layout/img/email.png" ToolTip="Enviar email ao Requerente" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton_hide" runat="server" ImageUrl="~/Layout/img/minus.png" CommandName="hide" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false">
                                <HeaderTemplate>validade</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="validade_acesso" runat="server" Text='<%# Bind("validade_acesso") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleGridRoundDir" FooterStyle-CssClass="footerGridRoundDir">
                                <ItemTemplate>
                                    <tr>
                                        <td colspan="100%">
                                            <asp:Panel ID="Panel_segunda_via" runat="server" Visible="false" CssClass="chil_grid_panel_admin_cartoes_via">
                                                <asp:GridView ID="GridView_segunda_via" OnRowCreated="GridView_child_RowCreated" runat="server" Width="73%" GridLines="Horizontal" BorderWidth="0"
                                                    AutoGenerateColumns="false" DataKeyNames="idcartao_segunda_via" OnRowCommand="GridView_segunda_via_RowCommand">
                                                    <RowStyle BackColor="#FFFFFF" BorderWidth="0" Font-Names="Ubuntu" Font-Size="12px" ForeColor="#0d4465" />
                                                    <Columns>
                                                        <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>Registo</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbdatareg" runat="server" Text='<%# Bind("data_reg") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>Requerente</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lb_p_requerente_via" runat="server" Text='<%# Bind("pessoa_requerente") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_estado_via" runat="server" Text='<%# Eval("estado")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="aaaaa" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lb_path_doc_final_via" runat="server" Text='<%# Eval("doc_path_segunda_via_cartao")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="child_grid_header ">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="doc_final" runat="server" CommandName="doc_final_via"
                                                                    ImageUrl="~/Layout/img/doc.png" Width="30px" Height="30" ToolTip="Documento Final 2º via" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="admin" runat="server" CommandName="admin_via"
                                                                    ImageUrl="~/Layout/img/admin.png" Width="32px" Height="32" ToolTip="Administrar 2º-via" Visible="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <tr>
                                        <td colspan="100%">
                                            <asp:Panel ID="Panel_renovacao" runat="server" Visible="false" CssClass="chil_grid_panel_admin_cartoes_renovacao">
                                                <asp:GridView ID="GridView_renovacao" OnRowCreated="GridView_child_RowCreated" runat="server" Width="69.5%" GridLines="Horizontal" BorderWidth="0"
                                                    AutoGenerateColumns="false" DataKeyNames="idcartao_renovacao" OnRowCommand="GridView_renovacao_RowCommand">
                                                    <RowStyle BackColor="#FFFFFF" BorderWidth="0" Font-Names="Ubuntu" Font-Size="12px" ForeColor="#0d4465" />
                                                    <Columns>
                                                        <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>Registo</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="d_registo_renovacao" runat="server" Text='<%# Bind("data_reg") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>Requerente</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lb_p_requerente_renovacao" runat="server" Text='<%# Bind("pessoa_requerente") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_estado_renovacao" runat="server" Text='<%# Eval("estado")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="fotocopia_cartao_identificacao" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lb_fotocopia_cartao_identificacao" runat="server" Text='<%# Eval("fotocopia_cartao_identificao")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="doc_final" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lb_doc_path_renovacao_cartao" runat="server" Text='<%# Eval("doc_path_renovacao_cartao")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="fotocopia_cartao_identificao" runat="server" CommandName="fotocopia_cartao"
                                                                    ImageUrl="~/Layout/img/cartao_acl.png" Width="32" Height="32" ToolTip="Cartão de Identificação/Acesso" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="doc_final_renovacao" runat="server" CommandName="doc_final_renovacao"
                                                                    ImageUrl="~/Layout/img/doc.png" Width="32px" Height="32" ToolTip="Documento Final da Renovação" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="admin" runat="server" CommandName="admin_renovacao" Visible="false"
                                                                    ImageUrl="~/Layout/img/admin.png" Width="32px" Height="32" ToolTip="Administrar Renovação" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" CssClass="modalPanel" Style="display: none">
                        <asp:Panel ID="Panel2" runat="server" cssclass="header_popup_desing">
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="Administrar Pedidos de Cartões de Identificação / Acesso" cssclass="header_popup_letras"></asp:Label>
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
                            <uc7:cartao_admin runat="server" ID="cartao_admin" Visible="false" />
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
