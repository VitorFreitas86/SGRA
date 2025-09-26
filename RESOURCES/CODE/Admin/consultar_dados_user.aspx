<%@ Page Title="" Language="C#" MasterPageFile="~/acessos.Master" AutoEventWireup="true" CodeBehind="consultar_dados_user.aspx.cs" Inherits="WebApplication10.Admin.consultar_dados_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
          <script type="text/javascript">
              function PrintGridData() {

                  var prtGrid = document.getElementById('<%=GridView1.ClientID %>');
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
         //CONFIRMAR BOX DOS RADIOBUTTONS DE BLOQUEIO, E CANCELAR POSTBACK
         function 
showconfirm() {

             //if (confirm('Tem a certeza que pretente alterar o estado de bloqueio do utilizador?')) {

             //    //aspnetForm.submit()
             //    //return true;
             //}
             //else {

             //    return false;

             //}
             return confirm('Tem a certeza que pretente alterar o estado de bloqueio do utilizador?');
         }
    </script>
    <script type="text/javascript">
        function confirmfunction() {
            if (confirm("Tem a certeza que pretente alterar os privilégios de acesso do utilizador?")) {
                __doPostBack('ctl00$ContentPlaceHolder1$GridView1$ctl02$ddl_privilegio', '');
            }
            else {
                window.location = '<%= ResolveUrl("~/Admin/consultar_dados_user.aspx") %>';
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" ><ContentTemplate>
    <div class="div_background_withe">
        <asp:Panel ID="Panel_filtros" runat="server" Visible="false" BackColor="#e1effd" BorderColor="#0E3E5B" BorderWidth="1px" Style="width: 292px; padding-left: 10px; position: absolute; margin-left: 0%; height: 28px; margin-top: 6px;">
            <asp:Label ID="Label15" runat="server" Text="Nome Próprio" Style="font-family: Ubuntu; font-size: 12px; color: #0d4465; font-weight: bold;"></asp:Label>
            <asp:TextBox ID="tb_nome" runat="server" Visible="true" Style="margin-left: 10px;"></asp:TextBox>
            <asp:ImageButton ID="ib_pesq" runat="server" OnClick="ib_pesq_Click" CssClass="ib_pesq_filtro" Visible="true" ImageUrl="~/Layout/img/search.png" Width="28" Height="28" />
        </asp:Panel>
        <asp:Panel ID="Panel_header" runat="server" Width="100%" Style="padding-top: 15px;">
            <asp:Label ID="Label7" runat="server" Text="Gestão de Pessoas Requerentes" CssClass="header_letras2"></asp:Label>
            <div class="btns_headers_3">
                <asp:ImageButton ID="ImageButton_print" runat="server" ToolTip="Imprimir" ImageUrl="~/Layout/img/imprimirgrid.png" OnClientClick="PrintGridData()" Width="28px" Style=" margin-right: 5px;" />
                <asp:ImageButton ID="ImageButton_filtros" ToolTip="Filtrar" runat="server" OnClick="ImageButton_filtros_Click" ImageUrl="~/Layout/img/filtros.png" Width="28px" Style=" margin-right: 5px;" />
            </div>
        </asp:Panel>
      
        <div class="roundCorner" id="GridView_div">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="userId" Width="100%" ShowFooter="true"
                OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand"
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                OnRowCancelingEdit="GridView1_RowCancelingEdit" GridLines="None" EmptyDataText="Não existem dados a apresentar">
                <EditRowStyle BackColor="#0d4365" />
                <RowStyle BackColor="#e8e8e8" BorderWidth="0" Font-Names="Ubuntu" Font-Size="12px" ForeColor="#0d4465" />
                <Columns>
                    <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGridRoundEsq">
                        <HeaderTemplate>Data Criação</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbCreationDate" runat="server" Text='<%# Bind("CreationDate") %>'></asp:Label>
                        </ItemTemplate>
                          <HeaderStyle CssClass="titleGrid"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                        <HeaderTemplate>Username</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbUsername" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="titleGrid"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                        <HeaderTemplate>Nome Próprio</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbnome" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="titleGrid"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="entidade_identidade" HeaderText="Entidade" Visible="false" />
                    <asp:TemplateField SortExpression="points" HeaderStyle-CssClass="titleGrid" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                        <HeaderTemplate>Entidade</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("entidade_identidade") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="titleGrid"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Acesso" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleGrid" FooterStyle-CssClass="footerGrid">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkStatus" runat="server"
                                AutoPostBack="true"
                                Checked='<%# Convert.ToBoolean(Eval("IsApproved")) %>'
                                Enabled="False" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="titleGrid"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" UpdateText="Atualizar" EditText="Acesso" CancelText="Cancelar" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN"
                        ButtonType="Image" EditImageUrl="../Layout/img/admin.png" CancelImageUrl="../Layout/img/cancel_edit.png" UpdateImageUrl="../Layout/img/confirm_edit.png">
                        <HeaderStyle CssClass="titleBTN"></HeaderStyle>
                        <FooterStyle CssClass="footerGrid"></FooterStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                        <ItemTemplate>
                            <asp:ImageButton ID="contatos" runat="server" CommandName="contatos"
                                ImageUrl="~/Layout/img/phone.png" Width="30px" Height="30" ToolTip="Contatos Utilizador" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="titleBTN"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                        <ItemTemplate>
                            <asp:ImageButton ID="login" runat="server" CommandName="login"
                                ImageUrl="~/Layout/img/login.png" Width="30px" Height="30" ToolTip="Dados de Login" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="titleBTN"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                       <ItemTemplate>  <%-- OnClientClick="showConfirm(this); return false;"--%> 
                            <asp:ImageButton ID="editar" runat="server" CommandName="editar"
                                ImageUrl="~/Layout/img/edit_user.png" Width="30px" Height="30" ToolTip="Editar dados Utilizador" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="titleBTN"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="titleBTN" FooterStyle-CssClass="footerGrid">
                        <ItemTemplate>
                            <asp:ImageButton ID="apagar" runat="server" CommandName="apagar"
                                ImageUrl="~/Layout/img/delete.png" Width="30px" Height="30" ToolTip="Apagar Utilizador" />
                            <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server"
                                TargetControlID="apagar"
                                ConfirmText="Tem a certeza que pretende eliminar o utilizador definitivamente?" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="titleBTN"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGrid">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton_hide" runat="server" ImageUrl="~/Layout/img/minus.png" CommandName="hide" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="titleBTN"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" FooterStyle-CssClass="footerGridRoundDir">
                        <ItemTemplate>
                            <tr>
                                <td colspan="100%">
                                    <asp:Panel ID="Panel_contatos" Visible="false" runat="server" cssclass="panel_contatos">
                                        <table class="tabela_contatos">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server" Text="Nº Cartão ACL:" Font-Bold="true"></asp:Label>
                                                    <asp:Label ID="lb_cartao" runat="server" Text="" Style="margin-left: 10px;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" Text="Cargo:" Font-Bold="true"></asp:Label>
                                                    <asp:Label ID="lb_cargo" runat="server" Text="" Style="margin-left: 10px;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Telefone:" Font-Bold="true"></asp:Label>
                                                    <asp:Label ID="label_telefone" runat="server" Style="margin-left: 10px;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Fax:" Font-Bold="true"></asp:Label>
                                                    <asp:Label ID="label_fax" runat="server" Text="" Style="margin-left: 10px;"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Email:" Font-Bold="true"></asp:Label>
                                                    <asp:Label ID="label_email" runat="server" Text="" Style="margin-left: 10px;"> </asp:Label>
                                                </td>
                                            </tr>
                                        </table>

                                    </asp:Panel>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <HeaderStyle CssClass="titleGridRoundDir_BTN"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <tr>
                                <td colspan="100%">
                                    <asp:Panel ID="Panel_login" runat="server" Visible="false" Style="visibility:visible;" cssclass="panel_login">
                                        <table style="font-family: Ubuntu; font-size: 12px; color: #0d4465;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Data último acesso:" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="LastLoginDate" runat="server" Text="" Style="margin-left: 10px;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Password:" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="login_pwd" runat="server" Text="" Style="margin-left: 10px;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Pergunta Secreta:" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="login_question" runat="server" Text="" Style="margin-left: 10px;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" Text="Resposta Secreta:" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="login_answer" runat="server" Text="" Style="margin-left: 10px;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Labelwww" runat="server" Text="Data alteração da Password:" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="login_lastpasschangedate" runat="server" Text="" Style="margin-left: 10px;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Tentativas" runat="server" Text="Tentativas de Acesso Falhadas:" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="login_failedpasscount" runat="server" Text="" Style="margin-left: 10px;"></asp:Label>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:Label ID="Data" runat="server" Text="Data de falhanço no login:" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="login_FailedPasswordAttemptWindowStart" runat="server" Text="" Style="margin-left: 10px;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="respchave" runat="server" Text="Resposta Secreta Errada:" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="login_respostachave" runat="server" Text="" Style="margin-left: 10px;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Data Resposta Secreta Errada:" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="login_respostachave_data" runat="server" Text="" Style="margin-left: 10px;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text="Bloqueio de acesso:" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="login_block_acesso" runat="server" Text="" Visible="false"></asp:Label>
                                                    <asp:RadioButtonList ID="RadioButtonList_block" runat="server" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList_block_SelectedIndexChanged" Width="271px" Height="17px" >
                                                        <asp:ListItem Text="Não Bloqueado" Value="0" />
                                                        <asp:ListItem Text="Bloqueado" Value="1" />
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Text="Data Bloqueio de acesso:" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="login_block_acesso_data" runat="server" Text="" Style="margin-left: 10px;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" Text="Privilégio de acesso:" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label_privilegio" runat="server" Text="" Visible="false"></asp:Label>
                                                    <asp:DropDownList ID="ddl_privilegio" runat="server" OnSelectedIndexChanged="ddl_privilegio_SelectedIndexChanged" AutoPostBack="True">
                                                        <asp:ListItem Text="Administrador" Value="1" />
                                                        <asp:ListItem Text="Utilizador" Value="2" />
                                                    </asp:DropDownList>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <tr>
                                <td colspan="100%">
                                    <asp:Panel ID="Panel_edit_user" runat="server" Visible="false" CssClass="panel_edit">
                                        <table style="width: 100%; font-family: Ubuntu; font-size: 12px; color: #0d4465;">
                                            <tr>
                                                <td>
                                                    <table style="width: 100%; font-family: Ubuntu; font-size: 12px; color: #0d4465;">
                                                        <tr>
                                                            <td colspan="2">
                                                                <b>Informação do Utilizador</b></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Nome Utilizador</td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="nome" MaxLength="80" />
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="nome"
                                                                    ErrorMessage="É necessário a inserção no nome pessoal."
                                                                    ValidationGroup="edit_user"
                                                                    Text="*" Style="color: red;"
                                                                   
                                                                    SetFocusOnError="true" />
                                                            </td><%-- EnabledClientScript="false"--%>
                                                        </tr>
                                                        <tr>
                                                            <td>Nº Cartão ACL</td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="num_acl" MaxLength="5" />
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="num_acl"
                                                                    ErrorMessage="É necessário o preenchimento do campo do número de cartão da ACL"
                                                                    ValidationGroup="edit_user"
                                                                    SetFocusOnError="true"
                                                                    Text="*" Style="color: red;"
                                                                    />
                                                            </td><%-- EnabledClientScript="false"--%>
                                                        </tr>
                                                        <tr>
                                                            <td>Telefone</td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="telefone" MaxLength="15" />
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="telefone"
                                                                    ErrorMessage="É necessário o preenchimento do campo telefone"
                                                                    ValidationGroup="edit_user"
                                                                    SetFocusOnError="true"
                                                                    Text="*" Style="color: red;"
                                                                     />
                                                            </td><%--EnabledClientScript="false"--%>
                                                        </tr>
                                                        <tr>
                                                            <td>Fax</td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="Fax" MaxLength="15" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Cargo/Função</td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="cargo" MaxLength="100" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table style="width: 100%; font-family: Ubuntu; font-size: 12px; color: #0d4465;">
                                                        <tr>
                                                            <td colspan="2">
                                                                <b>Informação do Utilizador </b></td>
                                                        </tr>
                                                        <tr>
                                                            <td>Username</td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="UserName"  MaxLength="256" />
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="UserName"
                                                                    ErrorMessage="É necessário a inserção do Username."
                                                                    ValidationGroup="edit_user"
                                                                    Text="*" Style="color: red;"
                                                                   
                                                                    SetFocusOnError="true" />
                                                            </td><%-- EnabledClientScript="false"--%>
                                                        </tr>
                                                        <tr>
                                                            <td>Palavra-Chave</td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="Password"  MaxLength="128" />
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ControlToValidate="Password"
                                                                    ErrorMessage="É necessário a inserção da Password."
                                                                    ValidationGroup="edit_user"
                                                                    Text="*" Style="color: red;"
                                                                  
                                                                    SetFocusOnError="true" />
                                                            </td><%--  EnabledClientScript="false"--%>
                                                        </tr>
                                                        <tr>
                                                            <td>Confirmar Palavra-Chave</td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="ConfirmPassword" MaxLength="128" />
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator13" ControlToValidate="ConfirmPassword"
                                                                    ErrorMessage="É necessário a confirmação da Password."
                                                                    ValidationGroup="edit_user"
                                                                    Text="*" Style="color: red;"
                                                                 
                                                                    SetFocusOnError="true" />
                                                            </td><%--   EnabledClientScript="false"--%>
                                                        </tr>
                                                        <tr>
                                                            <td>Email</td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="Email" MaxLength="128" />
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="Email"
                                                                    ErrorMessage="É necessário a inserção do Email"
                                                                    ValidationGroup="edit_user"
                                                                    Text="*" Style="color: red;"
                                                                
                                                                    SetFocusOnError="true" /><%--    EnabledClientScript="false"--%>
                                                                <asp:RegularExpressionValidator runat="server" ID="rexemail" ControlToValidate="Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Introduza um e-mail válido."
                                                                    ValidationGroup="edit_user"
                                                                    Text="*" Style="color: red;"
                                                                   
                                                                    SetFocusOnError="true" /><%-- EnabledClientScript="false"--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:ImageButton ID="Button_update_user" runat="server" OnClick="Button_update_user_Click" ValidationGroup="edit_user" CausesValidation="true" ImageUrl="~/Layout/img/confirmar.png" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" BackColor="#FEDAD8" Style="margin-left: 10px; margin-top: 10px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="False" Width="100%" />
                                        <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="A password e a password de confirmação tem de ser iguais."></asp:CompareValidator>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <ControlStyle BorderStyle="None" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
       </ContentTemplate></asp:UpdatePanel>
    <%-----------------------------------------------------------JAVASCRIPT--------------------------------------------------------------%>
   
</asp:Content>

