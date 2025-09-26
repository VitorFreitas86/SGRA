<%@ Page Title="" Language="C#" MasterPageFile="~/acessos.Master" AutoEventWireup="true" CodeBehind="consultar_cartao.aspx.cs" Inherits="WebApplication10.Users.segunda_via_cartao" %>

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
                    <asp:Label ID="Label7" runat="server" Text="Histórico de Pedidos de Cartões de Identificação/Acesso" CssClass="header_letras2"></asp:Label>
                    <div class="btns_headers_3">
                        <asp:ImageButton ID="ImageButton_print" runat="server" ToolTip="Imprimir" ImageUrl="~/Layout/img/imprimirgrid.png" OnClientClick="PrintGridData()" Width="28px" Style="margin-right: 5px;" />
                        <asp:ImageButton ID="ImageButton_filtros" ToolTip="Filtrar" runat="server" OnClick="ImageButton_filtros_Click" ImageUrl="~/Layout/img/filtros.png" Width="28px" Style="margin-right: 5px;" />
                    </div>
                </asp:Panel>
                <div class="roundCorner" id="GridView_div">
                    <asp:GridView ID="GridView_cartao" runat="server" Width="100%" GridLines="None" ShowFooter="true"
                        AutoGenerateColumns="false" DataKeyNames="idcartao" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView_cartao_PageIndexChanging" OnRowCommand="GridView_cartao_RowCommand" OnRowDataBound="GridView_cartao_RowDataBound" OnDataBound="GridView_cartao_DataBound">
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
                                    <asp:Label ID="lbtipo_pedido" runat="server" Text='<%# Bind("tipo_de_pedido") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <HeaderTemplate>Destinatário</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="n_identificacao" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <HeaderTemplate>Requerente</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lb_p_requerente" runat="server" Text='<%# Bind("pessoa_requerente") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_estado" runat="server" Text='<%# Eval("estado")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="2º Via" HeaderStyle-CssClass="titleGrid_2via" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <div class="div_btn_operacoes">
                                        <asp:LinkButton runat="server" Text="_" ID="segunda_via" CommandName="segunda_via" CssClass="btn_operacoes_pedidos" ToolTip="2º Via"></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Renovação" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <div class="div_btn_operacoes">
                                        <asp:LinkButton runat="server" Text="_" ID="renovacao" CommandName="renovacao" CssClass="btn_operacoes_pedidos" ToolTip="Renovações"></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton_hide" runat="server" ImageUrl="~/Layout/img/minus.png" CommandName="hide" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleGridRoundDir" FooterStyle-CssClass="footerGridRoundDir">
                                <ItemTemplate>
                                    <tr>
                                        <td colspan="10">
                                            <asp:Panel ID="Panel_segunda_via" runat="server" Visible="false" CssClass="chil_grid_panel_cartao_via">
                                                <asp:GridView ID="GridView_segunda_via" runat="server" Width="100.1%" GridLines="Horizontal" BorderWidth="0" OnRowCreated="GridView_renovacao_RowCreated"
                                                    AutoGenerateColumns="false" DataKeyNames="idcartao_segunda_via" EmptyDataText="Não existem pedidos de 2º Via">
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
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <tr>
                                        <td colspan="10">
                                            <asp:Panel ID="Panel_renovacao" runat="server" Visible="false" CssClass="chil_grid_panel_cartao_renovacao">
                                                <asp:GridView ID="GridView_renovacao" runat="server" Width="100.1%" GridLines="Horizontal" BorderWidth="0" OnRowCreated="GridView_renovacao_RowCreated"
                                                    AutoGenerateColumns="false" DataKeyNames="idcartao_renovacao" EmptyDataText="Não existem pedidos de Renovações">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
