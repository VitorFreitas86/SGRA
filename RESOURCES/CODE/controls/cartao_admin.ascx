<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cartao_admin.ascx.cs" Inherits="WebApplication10.controls.cartao_admin" %>

<style type="text/css">
    .auto-style1 {
        width: 401px;
    }
</style>

<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ib_save_admin" EventName="Click" />
    </Triggers>
    <ContentTemplate>
        <div>
        </div>
        <table style="color: #0d4465; font-family: Ubuntu; font-size: 12px; padding-bottom: 10px; padding-left: 10px; padding-right: 10px; padding-top: 10px;">
            <tr>
                <td class="auto-style1">
                    <fieldset style="width: auto; margin-left: 10px; margin-top: 10px;">
                        <legend style="font-family: Ubuntu; font-size: 14px; color: #0d4465; font-weight: bold;">Dados Cartão</legend>
                        <table style="color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Atribuido o Cartão Nº" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px; padding-top: 10px;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_n_cartao" runat="server" Text="" MaxLength="4"></asp:TextBox>
                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator9"
                                        ControlToValidate="tb_n_cartao" ValidationExpression="^[0-9]*$"
                                        ErrorMessage="Apenas pode introduzir numeros no campo do número do cartão."
                                        EnableClientScript="true"
                                        SetFocusOnError="true"
                                        Text="*" Style="color: red;" />
                            
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Tipo de Cartão"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lb_tipo_cartao" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddl_tipo_cartao" runat="server">
                                        <asp:ListItem Text="Permantente" Value="Permanente"></asp:ListItem>
                                        <asp:ListItem Text="Temporario" Value="Temporario"></asp:ListItem>
                                        <asp:ListItem Text="Acompanhado" Value="Acompanhado"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Validade"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_validade_cartao" runat="server" MaxLength="45" ValidationGroup="calendar"></asp:TextBox>
                                    <asp:ImageButton runat="Server" ID="ib_v_cartao" ImageUrl="~/Layout/img/calendar.png" Width="25px" ValidationGroup="calendar" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server"
                                        TargetControlID="tb_validade_cartao" PopupButtonID="ib_v_cartao" DefaultView="Years" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="tb_validade_cartao"
                                        Display="Dynamic" ErrorMessage="A data deve estar no formato: dd/mm/yyyy" SetFocusOnError="True" Text="*" Style="color: red;"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /](0[1-9]|1[012])[- /](19|20)[0-9]{2}"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Cor"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lb_cor" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddl_cor" runat="server">
                                        <asp:ListItem Text=" " Value=" "></asp:ListItem>
                                        <asp:ListItem Text="Branco" Value="Branco"></asp:ListItem>
                                        <asp:ListItem Text="Amarelo" Value="Amarelo"></asp:ListItem>
                                        <asp:ListItem Text="Vermelho" Value="Vermelho"></asp:ListItem>
                                        <asp:ListItem Text="Azul" Value="Azul"></asp:ListItem>
                                        <asp:ListItem Text="Verde" Value="Verde"></asp:ListItem>
                                        <asp:ListItem Text="Castanho" Value="Castanho"></asp:ListItem>
                                    </asp:DropDownList>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Conferido"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_conferido" runat="server" MaxLength="45" ValidationGroup="calendar"></asp:TextBox>
                                    <asp:ImageButton runat="Server" ID="ib_conferido" ImageUrl="~/Layout/img/calendar.png" Width="25px" ValidationGroup="calendar" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"
                                        TargetControlID="tb_conferido" PopupButtonID="ib_conferido" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_conferido"
                                        Display="Dynamic" ErrorMessage="A data deve estar no formato: dd/mm/yyyy" SetFocusOnError="True" Text="*" EnableClientScript="false" Style="color: red;"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /](0[1-9]|1[012])[- /](19|20)[0-9]{2}"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text="Pagamento"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_pagamento" runat="server" MaxLength="10"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LabelEstado" runat="server" Text="Estado"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label_estado" runat="server" Text="" Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddl_estado" runat="server" >
                                        <asp:ListItem Text="Pendente" Value="Pendente"></asp:ListItem>
                                        <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
                                        <asp:ListItem Text="Indeferido" Value="Indeferido"></asp:ListItem>
                                        <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
                                    </asp:DropDownList>
                               
                                    <%--<asp:Label ID="Label_erro" runat="server" Text="" Style=" color:red;"></asp:Label>--%>
                                          </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset style="width: auto; margin-left: 10px; margin-top: 10px;">
                        <legend style="font-family: Ubuntu; font-size: 14px; color: #0d4465; font-weight: bold;">Autorizacao de aberturas de portas automatizadas</legend>
                        <div>
                            <asp:CheckBox ID="portas" Text="Portas Embarque/Desembarque" Style="font-size: 12px; color: #0d4465; font-family: ubuntu;" runat="server" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="outras" Style="font-size: 12px; font-family: ubuntu; color: #0d4465;" Text="Outras" runat="server" AutoPostBack="true" OnCheckedChanged="cb_portas_SelectedIndexChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                
                    <asp:TextBox ID="tb_outras" runat="server" Visible="false" MaxLength="70" Width="305px"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator3" runat="server"
                                ErrorMessage="Deve referir quais as outras áreas"
                                EnableClientScript="true"
                                Text="*" Style="color: red;" OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator>
                        </div>
                    </fieldset>
                </td>
                <td>
                    <fieldset style="width: auto; margin-left: 10px; margin-top: 8px; height: 292px;">
                        <legend style="font-family: Ubuntu; font-size: 14px; color: #0d4465; font-weight: bold;">Áreas de Acesso</legend>
                        <div style="color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                            <asp:CheckBoxList ID="cb_areas_funcoes" runat="server" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;" Width="415px">
                                <asp:ListItem Value="A" Text="Áreas de acesso público do Aeroporto (condicionados)."> </asp:ListItem>
                                <asp:ListItem Value="B" Text="Sala de Recolha de Bagagem."> </asp:ListItem>
                                <asp:ListItem Value="C" Text="Hangares de Carga."> </asp:ListItem>
                                <asp:ListItem Value="D" Text="Área de Operações."> </asp:ListItem>
                                <asp:ListItem Value="E" Text="Salas de Embarque Schengen."> </asp:ListItem>
                                <asp:ListItem Value="I" Text="Sala de Embarque internacional (após SEF)."> </asp:ListItem>
                                <asp:ListItem Value="L" Text="Lojas."> </asp:ListItem>
                                <asp:ListItem Value="M" Text="Hangares de Manutenção de Aeronaves."> </asp:ListItem>
                                <asp:ListItem Value="O" Text="Áreas Operacionais (pista, Taxi-way, Caminhos periféricos)."> </asp:ListItem>
                                <asp:ListItem Value="P" Text="Plataformas de Estacionamento de Aeronaves."> </asp:ListItem>
                                <asp:ListItem Value="T" Text="Terminais de Tratamento de Bagagem de Porão."> </asp:ListItem>
                            </asp:CheckBoxList>
                            <asp:Label ID="lb_areas" runat="server" Text="Label" Visible="false"></asp:Label>
                        </div>
                    </fieldset>
                </td>
            </tr>
        </table>
        <fieldset style="width: auto; width: auto; margin-left: 23px; margin-right: 15px; margin-bottom: 10px;">
            <legend style="font-family: Ubuntu; font-size: 14px; color: #0d4465; font-weight: bold;">Pedir Parecer das Entidades 
            </legend>
            <asp:Panel ID="Panel1" runat="server">
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:CheckBox ID="cb_psp" runat="server" Text="PSP" OnCheckedChanged="cb_psp_CheckedChanged" AutoPostBack="true" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;" />
                            </td>
                            <td>
                                <asp:Panel ID="Panel_psp" runat="server" Visible="false">
                                    <asp:Label ID="Label10" runat="server" Text="Email:" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;"></asp:Label>&nbsp;
                                    <asp:TextBox ID="tb_psp" runat="server" Width="230px" MaxLength="120"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="tb_psp"
                                        ErrorMessage="É necessário a inserção do Email" ValidationGroup="psp" Style="color: red;"
                                        EnableClientScript="false"
                                        SetFocusOnError="true"
                                        Text="*" />
                                    <asp:RegularExpressionValidator runat="server" ID="rexemail" ControlToValidate="tb_psp" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Introduza um e-mail válido."
                                        SetFocusOnError="true" Style="color: red;"
                                        Text="*" />
                    &nbsp;                       
                                </asp:Panel>
                            </td>
                            <td>
                                <asp:Label ID="Data" runat="server" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;" Text="Data:"></asp:Label>
                                <asp:TextBox ID="tb_d_psp" runat="server" Enabled="false" MaxLength="45" Width="100px"></asp:TextBox>
                                <asp:TextBox ID="msg_psp" runat="server" MaxLength="50" Enabled="false" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>

                </div>
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:CheckBox ID="cb_sef" runat="server" Text="SEF" OnCheckedChanged="cb_sef_CheckedChanged" AutoPostBack="true" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;" />
                            </td>
                            <td>
                                <asp:Panel ID="Panel_sef" runat="server" Visible="false">                                
                                    <asp:Label ID="Label2" runat="server" Text="Email:" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;"></asp:Label>&nbsp;
                                    <asp:TextBox ID="tb_sef" runat="server" Width="230px" MaxLength="120"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="tb_sef"
                                        ErrorMessage="É necessário a inserção do Email" ValidationGroup="sef"
                                        EnableClientScript="false" Style="color: red;"
                                        SetFocusOnError="true"
                                        Text="*" />
                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator7" ControlToValidate="tb_sef" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Introduza um e-mail válido."
                                        SetFocusOnError="true" Style="color: red;"
                                        Text="*" />
                    &nbsp;                     
                                </asp:Panel>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;" Text="Data:"></asp:Label>
                                <asp:TextBox ID="tb_d_sef" runat="server" Enabled="false" MaxLength="45" Width="100px"></asp:TextBox>
                                <asp:TextBox ID="msg_sef" runat="server" MaxLength="50" Enabled="false" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:CheckBox ID="cb_o_servicos" runat="server" AutoPostBack="true" Text="Outros Serviços/Entidades" OnCheckedChanged="cb_o_servicos_CheckedChanged" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;" />
                            </td>
                            <td>
                                <asp:Panel ID="Panel_o_serv" runat="server" Visible="false">
                                    <asp:Label ID="Label11" runat="server" Text="Email:" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;"></asp:Label>&nbsp;
                                    <asp:TextBox ID="tb_o_servicos" runat="server" Text="" Width="230px" MaxLength="120"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="tb_o_servicos"
                                        ErrorMessage="É necessário a inserção do Email" ValidationGroup="o_serv"
                                        EnableClientScript="false" Style="color: red;"
                                        SetFocusOnError="true"
                                        Text="*" />
                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator8" ControlToValidate="tb_o_servicos" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Introduza um e-mail válido."
                                        EnableClientScript="false"
                                        SetFocusOnError="true" Style="color: red;"
                                        Text="*" />
                                    <asp:Label ID="Label4" runat="server" Text="Data:" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;"></asp:Label>&nbsp;
                                    <asp:TextBox ID="tb_d_servico" runat="server" MaxLength="45" Enabled="false"></asp:TextBox>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </fieldset>
        <div style="text-align: center; padding-bottom: 10px;">
            <asp:ImageButton ID="ib_save_admin" runat="server" CausesValidation="true" OnClick="ib_save_admin_Click" ImageUrl="~/Layout/img/confirmar.png"  />
        </div>
        <asp:ValidationSummary ID="ValidationSummary4" runat="server" ForeColor="Red"  BackColor="#FEDAD8" ValidationGroup="MyValidationGroup" Style="margin-left: 23px; margin-bottom: 15px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="95%" />

         </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="prgLoadingStatus" runat="server" DynamicLayout="true">
    <ProgressTemplate>
        <div id="overlay">
            <div id="modalprogress">
                <div id="theprogress_2">
                    <asp:Image ID="imgWaitIcon" runat="server" ImageAlign="AbsMiddle" ImageUrl="../Layout/img/sending.gif" Width="300px" Height="300px" />
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<%--------------------------------------------------STYLE-----------------------------------------------------------------%>
 