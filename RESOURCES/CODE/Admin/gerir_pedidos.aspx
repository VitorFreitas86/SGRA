<%@ Page Title="" Language="C#" MasterPageFile="~/acessos.Master" AutoEventWireup="true" CodeBehind="gerir_pedidos.aspx.cs" Inherits="WebApplication10.Admin.gerir_pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintGridData() {

            var prtGrid = document.getElementById('<%=GridView_conducao.ClientID %>');
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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

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
                <asp:DropDownList ID="ddl_entidade" runat="server" Visible="false"></asp:DropDownList>
                <asp:ImageButton ID="ib_pesq" runat="server" OnClick="ib_pesq_Click" CssClass="ib_pesq_filtro" Visible="false" ImageUrl="~/Layout/img/search.png" Width="32" Height="32" />
          </div>
                  </asp:Panel>
            <div class="div_background_withe">
                <asp:Panel ID="Panel_header" runat="server" Width="100%" Style="padding-top: 15px;">
                    <asp:Label ID="Label7" runat="server" Text="Gestão de Pedidos de Condução" CssClass="header_letras2"></asp:Label>
                    <div class="btns_headers_3">
                        <asp:ImageButton ID="ImageButton_print" runat="server" ToolTip="Imprimir" ImageUrl="~/Layout/img/imprimirgrid.png" OnClientClick="PrintGridData()" Width="28px" Style="margin-right: 5px;" />
                        <asp:ImageButton ID="ImageButton_filtros" ToolTip="Filtrar" runat="server" OnClick="ImageButton_filtros_Click" ImageUrl="~/Layout/img/filtros.png" Width="28px" Style="margin-right: 5px;" />
                    </div>
                </asp:Panel>
                <div class="roundCorner" id="GridView_div">
                    <asp:GridView ID="GridView_conducao" runat="server" OnRowEditing="GridView_conducao_RowEditing"
                        OnRowUpdating="GridView_conducao_RowUpdating" ShowFooter="true"
                        OnRowCancelingEdit="GridView_conducao_RowCancelingEdit"
                        OnRowDataBound="GridView_conducao_RowDataBound" Width="100%"
                        AutoGenerateColumns="false" DataKeyNames="idconducao" OnRowCommand="GridView_conducao_RowCommand" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView_conducao_PageIndexChanging" GridLines="None" OnDataBound="GridView_conducao_DataBound" EmptyDataText="Não existem dados a apresentar">
                        <EditRowStyle BackColor="#0d4365" />
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
                                    <asp:Label ID="lbdatareg" runat="server" Text='<%# Bind("datareg") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <HeaderTemplate>Destinatário</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbnome" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <HeaderTemplate>Entidade</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="entidade_identidade" runat="server" Text='<%# Bind("entidade_identidade") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false">
                                <HeaderTemplate>fotocopia_cartao_acl</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lb_cartao_acl" runat="server" Text='<%# Bind("fotocopia_cartao_acl") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false">
                                <HeaderTemplate>fotocopia_cartao_conducao</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lb_carta_conducao" runat="server" Text='<%# Bind("fotocopia_carta_conducao") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_estado" runat="server" Text='<%# Eval("estado")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbl_estado" runat="server" Text='<%# Eval("estado")%>' Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddl_estado" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Briefing" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <EditItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="TextBox_soa" runat="server" Text='<%# Bind("soa") %>' Width="70px" MaxLength="45"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton runat="Server" ID="ib_soa" ImageUrl="~/Layout/img/calendar.png" Width="25px" />
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server"
                                                    TargetControlID="TextBox_soa" PopupButtonID="ib_soa" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox_soa"
                                                    Display="Dynamic" ErrorMessage="A data deve estar no formato: dd/mm/yyyy" SetFocusOnError="True" Text="*" Style="color: red;"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /](0[1-9]|1[012])[- /](19|20)[0-9]{2}"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label_soa" runat="server" Text='<%# Bind("soa") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="R.Briefing" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox_soa_nome" runat="server" Text='<%# Bind("soa_nome") %>' MaxLength="40" Width="110px"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="TextBox_soa_nome"
                                        ErrorMessage="É necessário o preenchimento o nome do responsável pelo Briefing."
                                        EnableClientScript="true"
                                        SetFocusOnError="true" Style="color: red;"
                                        Text="*" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label_soa_nome" runat="server" Text='<%# Bind("soa_nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField SortExpression="points" Visible="false">
                                <HeaderTemplate>Documento</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="doc" runat="server" Text='<%# Bind("path_doc_final") %>'></asp:Label>
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
                                    <asp:ImageButton ID="doc_final" runat="server" CommandName="doc"
                                        ImageUrl="~/Layout/img/doc.png" Width="32px" ToolTip="Documento Final" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="titleBTN" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="cartao_acl" runat="server" CommandName="cartao_acl" Visible="false"
                                        ImageUrl="~/Layout/img/cartao_acl.png" Width="32px" ToolTip="Cartão ACL" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="titleBTN" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="carta_conducao" runat="server" CommandName="cartao_conducao" Visible="false"
                                        ImageUrl="~/Layout/img/carta_c.png" Width="32px" Height="30" ToolTip="Carta Condução" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" ButtonType="Image" EditImageUrl="../Layout/img/admin.png" CancelImageUrl="../Layout/img/cancel_edit.png" UpdateImageUrl="../Layout/img/confirm_edit.png" HeaderStyle-CssClass="titleBTN" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid" />
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton_s_email" OnClientClick="toBottom()" runat="server" CommandName="send_email" Width="32" ToolTip="Enviar email ao Requerente" ImageUrl="~/Layout/img/email.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="titleBTN" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton_hide" runat="server" ImageUrl="~/Layout/img/minus.png" CommandName="hide" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleGridRoundDir" FooterStyle-CssClass="footerGridRoundDir">
                                <ItemTemplate>
                                    <tr>
                                        <td colspan="100%">
                                            <asp:Panel ID="Panel_segunda_via" runat="server" Visible="false" CssClass="chil_grid_panel_gerir_conducao_via">
                                                <asp:GridView ID="GridView_segunda_via" OnRowCreated="GridView_child_RowCreated" runat="server" Width="82%" GridLines="Horizontal" BorderWidth="0"
                                                    AutoGenerateColumns="false" DataKeyNames="idsegunda_via_conducao" OnRowCancelingEdit="GridView_segunda_via_RowCancelingEdit" OnRowCommand="GridView_segunda_via_RowCommand" OnRowEditing="GridView_segunda_via_RowEditing" OnRowUpdating="GridView_segunda_via_RowUpdating" OnRowDataBound="GridView_segunda_via_RowDataBound">
                                                    <RowStyle BackColor="#FFFFFF" BorderWidth="0" Font-Names="Ubuntu" Font-Size="12px" ForeColor="#0d4465" />
                                                    <Columns>
                                                        <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>Registo</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="d_registo_via" runat="server" Text='<%# Bind("data_reg") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>Requerente</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lb_p_requerente_via" runat="server" Text='<%# Bind("pessoa_requerente") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField SortExpression="points" Visible="false" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <HeaderTemplate>doc</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="path_doc_segunda_via_conducao" runat="server" Text='<%# Bind("path_doc_segunda_via_conducao") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_estado_via" runat="server" Text='<%# Eval("estado")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lbl_estado_via" runat="server" Text='<%# Eval("estado")%>' Visible="false"></asp:Label>
                                                                <asp:DropDownList ID="ddl_estado_via" runat="server">
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="doc_final_via" runat="server" CommandName="doc_via"
                                                                    ImageUrl="~/Layout/img/doc.png" Width="32px" ToolTip="Documento Final 2º Via" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField ShowEditButton="True" ButtonType="Image" EditImageUrl="../Layout/img/admin.png" CancelImageUrl="../Layout/img/cancel_edit.png" UpdateImageUrl="../Layout/img/confirm_edit.png" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center" />
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <tr><%--OnRowCreated="GridView_child_RowCreated"--%>
                                        <td colspan="100%">
                                            <asp:Panel ID="Panel_renovacao"  runat="server" Visible="false" CssClass="chil_grid_panel">
                                                <asp:GridView ID="GridView_renovacao" runat="server" Width="84%" GridLines="Horizontal" BorderWidth="0"
                                                    AutoGenerateColumns="false" DataKeyNames="idconducao_renovacao" OnRowDataBound="GridView_renovacao_RowDataBound" OnRowCancelingEdit="GridView_renovacao_RowCancelingEdit" OnRowCommand="GridView_renovacao_RowCommand" OnRowEditing="GridView_renovacao_RowEditing" OnRowUpdating="GridView_renovacao_RowUpdating">
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
                                                                <asp:Label ID="path_doc_renovacao_conducao" runat="server" Text='<%# Bind("path_doc_renovacao_conducao") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_estado_renovacao" runat="server" Text='<%# Eval("estado")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lbl_estado_renovacao" runat="server" Text='<%# Eval("estado")%>' Visible="false"></asp:Label>
                                                                <asp:DropDownList ID="ddl_estado_renovacao" runat="server">
                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="doc_renovacao" runat="server" CommandName="doc_renovacao"
                                                                    ImageUrl="~/Layout/img/doc.png" Width="32px" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField ShowEditButton="True" HeaderStyle-CssClass="child_grid_header " ItemStyle-HorizontalAlign="Center" ButtonType="Image" EditImageUrl="../Layout/img/admin.png" CancelImageUrl="../Layout/img/cancel_edit.png" UpdateImageUrl="../Layout/img/confirm_edit.png" />
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
