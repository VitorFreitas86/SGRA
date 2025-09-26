<%@ Page Title="" Language="C#" MasterPageFile="~/acessos.Master" AutoEventWireup="true" CodeBehind="gerir_viatura.aspx.cs" Inherits="WebApplication10.Admin.gerir_viatura" %>

<%@ Register Src="~/controls/viatura_admin.ascx" TagPrefix="uc3" TagName="viatura_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('<%=GridView_viatura.ClientID %>');
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
    <br>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
            <asp:Panel ID="Panel_filtros" runat="server" Visible="false" BackColor="#e1effd" BorderColor="#0E3E5B" BorderWidth="1px" CssClass="popup_pesquisa">
                <asp:RadioButtonList ID="RB_filtro" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="RB_filtro_SelectedIndexChanged" cssclass="rb_filtro">
                    <asp:ListItem Text="Nº Processo"></asp:ListItem>
                    <asp:ListItem Text="Data de Registo"></asp:ListItem>
                    <asp:ListItem Text="Matricula"></asp:ListItem>
                    <asp:ListItem Text="Estado do Pedido"></asp:ListItem>
                    <asp:ListItem Text="Entidade"></asp:ListItem>
                </asp:RadioButtonList>
              <div>
                  <asp:TextBox ID="tb_data" runat="server" TextMode="DateTime" MaxLength="45" ValidationGroup="calendar" Visible="false" CssClass="tb_data_filtro_admin_viatura"></asp:TextBox>
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
                   <asp:TextBox ID="tb_matricula" runat="server" Visible="false" CssClass="tb_matricula_filtro_admin_viatura" Style="text-transform: uppercase"></asp:TextBox>
               <asp:ImageButton ID="ImageButton2" runat="server" OnClick="ib_pesq_Click" CssClass="ib_pesq_filtro" Visible="false" ImageUrl="~/Layout/img/search.png" Width="32" Height="32" />
            </div>
                 <div>
                  <asp:DropDownList ID="ddl_estado" runat="server" Visible="false" CssClass="ddl_estado_filtro_viatura">
                    <asp:ListItem Text="Pendente" Value="Pendente"></asp:ListItem>
                    <asp:ListItem Text="Indeferido" Value="Indeferido"></asp:ListItem>
                    <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
                    <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
                </asp:DropDownList>
                  <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ib_pesq_Click" CssClass="ib_pesq_filtro" Visible="false" ImageUrl="~/Layout/img/search.png" Width="32" Height="32" />
            </div>
                <div style="margin-top: -5px;margin-bottom: 5px;width: auto;margin-left: 24%;text-align: right;padding-left: 22%;">
                            <asp:DropDownList ID="ddl_entidade" Visible="false" runat="server"></asp:DropDownList>
                <asp:ImageButton ID="ib_pesq" runat="server" OnClick="ib_pesq_Click" CssClass="ib_pesq_filtro" Visible="false" ImageUrl="~/Layout/img/search.png" Width="32" Height="32" />
            </div>
                    </asp:Panel>
           
             <div class="div_background_withe">
                <asp:Panel ID="Panel_header" runat="server" Width="100%" Style="padding-top: 15px;">
                    <asp:Label ID="Label7" runat="server" Text="Gestão de Pedidos de Viaturas" CssClass="header_letras2"></asp:Label>
                    <div class="btns_headers_3">
                        <asp:ImageButton ID="ImageButton_print" runat="server" ToolTip="Imprimir" ImageUrl="~/Layout/img/imprimirgrid.png" OnClientClick="PrintGridData()" Width="28px" Style="margin-right: 5px;" />
                        <asp:ImageButton ID="ImageButton_filtros" ToolTip="Filtrar" runat="server" OnClick="ImageButton_filtros_Click" ImageUrl="~/Layout/img/filtros.png" Width="28px" Style="margin-right: 5px;" />
                    </div>
                </asp:Panel>

                <div class="roundCorner" id="GridView_div">
                    <asp:GridView ID="GridView_viatura" runat="server" Width="100%" ShowFooter="true"
                        AutoGenerateColumns="false" DataKeyNames="idviatura" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView_viatura_PageIndexChanging" OnRowCommand="GridView_viatura_RowCommand" OnRowDataBound="GridView_viatura_RowDataBound" GridLines="None" OnDataBound="GridView_viatura_DataBound" EmptyDataText="Não existem dados a apresentar">
                        <RowStyle BackColor="#e8e8e8" BorderWidth="0" Font-Names="Ubuntu" Font-Size="12px" ForeColor="#0d4465" />
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
                                    <asp:Label ID="lb_tipo_cartao" runat="server" Text='<%# Bind("tipo_de_pedido") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <HeaderTemplate>Identificação</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="n_identificacao" runat="server" Text='<%# Bind("n_identificacao") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <HeaderTemplate>Matricula</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbmatricula" runat="server" Text='<%# Bind("matricula") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <HeaderTemplate>Marca</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbmarca" runat="server" Text='<%# Bind("marca") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <HeaderTemplate>Modelo</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbmodelo" runat="server" Text='<%# Bind("modelo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <HeaderTemplate>Entidade</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="entidade_identidade" runat="server" Text='<%# Bind("entidade_identidade") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false">
                                <HeaderTemplate>Livrete</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="fotocopia_livrete" runat="server" Text='<%# Bind("fotocopia_livrete") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false">
                                <HeaderTemplate>Registo Propriedade</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="fotocopia_registop" runat="server" Text='<%# Bind("fotocopia_registop") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false">
                                <HeaderTemplate>carta verde</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="fotocopia_cartaverde" runat="server" Text='<%# Bind("fotocopia_cartaverde") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false">
                                <HeaderTemplate>declaracao segurador</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="fotocopia_declaracao_segurador" runat="server" Text='<%# Bind("fotocopia_declaracao_segurador") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false">
                                <HeaderTemplate>ipo</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="fotocopia_ipo" runat="server" Text='<%# Bind("fotocopia_ipo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false">
                                <HeaderTemplate>doc</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="doc" runat="server" Text='<%# Bind("path_doc_final_viaturas") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_estado" runat="server" Text='<%# Eval("estado")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="2ºvia" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleGrid" FooterStyle-CssClass="footerGrid">
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
                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="titleBTN" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="doc_final" runat="server" CommandName="doc_final" Visible="false"
                                        ImageUrl="~/Layout/img/doc.png" Width="32px" ToolTip="Documento Pedido Viatura" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="titleBTN" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="livrete" runat="server" CommandName="livrete"
                                        ImageUrl="~/Layout/img/livrete.png" Width="32px" ToolTip="Livrete" Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="titleBTN" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="r_prop" runat="server" CommandName="r_prop" Visible="false"
                                        ImageUrl="~/Layout/img/r_propriedade.png" Width="32px" ToolTip="Registo Propriedade" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="titleBTN" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="carta_verde" runat="server" CommandName="carta_verde" Visible="false"
                                        ImageUrl="~/Layout/img/green.png" Width="32px" ToolTip="Carta Verde" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="titleBTN" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="d_segurador" runat="server" CommandName="d_segurador" Visible="false"
                                        ImageUrl="~/Layout/img/seguradora.png" Width="32px" ToolTip="Declaração Seguradora" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="titleBTN" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ipo" runat="server" CommandName="ipo" Visible="false"
                                        ImageUrl="~/Layout/img/ipo.png" Width="32px" ToolTip="IPO" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="titleBTN" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="admin" runat="server" CommandName="admin"
                                        ImageUrl="~/Layout/img/admin.png" Width="32" ToolTip="Administrar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="titleBTN" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton_s_email" OnClientClick="toBottom()" runat="server" ImageUrl="~/Layout/img/email.png" Width="32px" CommandName="send_email" ToolTip="Enviar email ao Requerente" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="titleBTN" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
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
                                            <asp:Panel ID="Panel_segunda_via" runat="server" Visible="false" CssClass="chil_grid_panel">
                                                <asp:GridView ID="GridView_segunda_via" OnRowCreated="GridView_child_RowCreated" runat="server" Width="71.5%" GridLines="Horizontal" BorderWidth="0"
                                                    AutoGenerateColumns="false" DataKeyNames="idviatura_via" OnRowCommand="GridView_segunda_via_RowCommand" OnRowDataBound="GridView_segunda_via_RowDataBound">
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
                                                        <asp:TemplateField SortExpression="points" Visible="false">
                                                            <HeaderTemplate>doc</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="path_doc_segunda_via_viatura" runat="server" Text='<%# Bind("path_doc_segunda_via_viatura") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_estado_via" runat="server" Text='<%# Eval("estado")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="doc_final_via" runat="server" CommandName="doc_via"
                                                                    ImageUrl="~/Layout/img/doc.png" Width="32" ToolTip="Documento 2º via" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="child_grid_header ">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="admin" runat="server" CommandName="admin_via" Visible="false"
                                                                    ImageUrl="~/Layout/img/admin.png" Width="32px" ToolTip="Administrar 2º via" />
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
                                            <asp:Panel ID="Panel_renovacao" runat="server" Visible="false" CssClass="chil_grid_panel_panel_renovacao">
                                                <asp:GridView ID="GridView_renovacao" OnRowCreated="GridView_child_RowCreated" OnRowDataBound="GridView_segunda_via_RowDataBound" runat="server" Width="71.5%" GridLines="Horizontal" BorderWidth="0"
                                                    AutoGenerateColumns="false" DataKeyNames="idviatura_renovacao" OnRowCommand="GridView_renovacao_RowCommand">
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
                                                        <asp:TemplateField SortExpression="points" Visible="false">
                                                            <HeaderTemplate>doc</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="path_doc_renovacao_viatura" runat="server" Text='<%# Bind("path_doc_renovacao_viatura") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="points" Visible="false">
                                                            <HeaderTemplate>doc</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="path_fotocopia_cartao_circulacao" runat="server" Text='<%# Bind("path_fotocopia_cartao_circulacao") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_estado_renovacao" runat="server" Text='<%# Eval("estado")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="fotocopia_cartao" runat="server" CommandName="fotocopia_cartao"
                                                                    ImageUrl="~/Layout/img/cartao_acl.png" Width="32px" ToolTip="Fotocópia Cartão ACL" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="doc_renovacao" runat="server" CommandName="doc_renovacao"
                                                                    ImageUrl="~/Layout/img/doc.png" Width="32px" ToolTip="Documento Renovação" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="admin" runat="server" CommandName="admin_renovacao" Visible="false"
                                                                    ImageUrl="~/Layout/img/admin.png" Width="32" ToolTip="Administrar Renovação" />
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
                                        <asp:Label ID="Label8" runat="server" Text="Administrar Pedidos de Viaturas" cssclass="header_popup_letras"></asp:Label>
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
                            <uc3:viatura_admin runat="server" ID="viatura_admin" Visible="true" />
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
