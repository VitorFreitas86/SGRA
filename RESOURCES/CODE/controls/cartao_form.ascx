<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cartao_form.ascx.cs" Inherits="WebApplication10.controls.cartao_form" %>
<div>
    <asp:Label ID="Label_status" runat="server" Text="" Visible="false"></asp:Label>
</div>
<asp:Wizard ID="cartao" runat="server" ActiveStepIndex="0" OnFinishButtonClick="cartao_FinishButtonClick" BackColor="#F8F8F8" Style="color: red;" FinishCompleteButtonImageUrl="~/Layout/img/save.png" FinishCompleteButtonType="Image" FinishPreviousButtonImageUrl="~/Layout/img/anterior.png" FinishPreviousButtonText="" FinishPreviousButtonType="Image" StartNextButtonImageUrl="~/Layout/img/next.png" StartNextButtonType="Image" StepNextButtonImageUrl="~/Layout/img/next.png" StepNextButtonType="Image" StepPreviousButtonImageUrl="~/Layout/img/anterior.png" StepPreviousButtonType="Image" OnNextButtonClick="cartao_NextButtonClick">
    <StartNavigationTemplate>
        <asp:ImageButton ID="StartNextButton" ToolTip="Seguinte" CausesValidation="true" Style="margin-bottom: 5px; margin-top: 5px; margin-right: 5px;" runat="server" AlternateText="Next" CommandName="MoveNext" ImageUrl="~/Layout/img/next.png" />
    </StartNavigationTemplate>
    <StepNavigationTemplate>
        <asp:ImageButton ID="StepPreviousButton" runat="server" ToolTip="Anterior" Style="margin-bottom: 5px; margin-top: 5px;" AlternateText="Previous" CausesValidation="False" CommandName="MovePrevious" ImageUrl="~/Layout/img/anterior.png" />
        <asp:ImageButton ID="StepNextButton" CausesValidation="true" runat="server" ToolTip="Seguinte" Style="margin-bottom: 5px; margin-top: 5px; margin-right: 5px;" AlternateText="Next" CommandName="MoveNext" ImageUrl="~/Layout/img/next.png" />
    </StepNavigationTemplate>
    <WizardSteps>
        <asp:WizardStep ID="dados_pessoais" runat="server" Title="Dados Pessoais">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div style="margin-bottom: 10px; margin-left: 79.7%; margin-top: 10px;">
                        <asp:Label ID="Label34" runat="server" Text="Nº Processo" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;"></asp:Label>
                        <asp:TextBox ID="tb_num" runat="server" Enabled="False" Width="54px" Style="margin-left: 10px;"></asp:TextBox>
                    </div>
                    <fieldset style="width: 690px; margin-left: 10px; color: #0d4465; margin-right: 10px;">
                        <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px; color: #0d4465;">Informação Pessoal</legend>
                        <table style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 5px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="Label7" runat="server" Text="Nome"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_nome" runat="server" MaxLength="90" ValidationGroup="cartap" Enabled="true" Width="574px" Style="margin-left: 0px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="tb_nome" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do nome completo." SetFocusOnError="true" Text="*" Style="color: red;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="Label2" runat="server" Text="Morada"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_morada" runat="server" MaxLength="53" ValidationGroup="cartao" Width="280px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tb_morada" EnableClientScript="true" ErrorMessage="É necessário o preenchimento da morada do destinatário do cartão." SetFocusOnError="true" Text="*" Style="color: red;" />
                                    <asp:Label ID="Label4" runat="server" Text="Código postal" Style="margin-left: 39px;"></asp:Label>
                                    <asp:TextBox ID="tb_codigo_postal" runat="server" MaxLength="45" ValidationGroup="cartao" Style="margin-left: 10px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_codigo_postal" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do código postal." SetFocusOnError="true" Text="*" Style="color: red;" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="tb_codigo_postal" EnableClientScript="true" ErrorMessage="Deve inserir o codigo postal no formato 0000-000." SetFocusOnError="true" Text="*" Style="color: red;" ValidationExpression="^[0-9]{4,4}-[0-9]{3,3}$" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="Label3" runat="server" Text="Localidade"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_localidade" runat="server" MaxLength="35" ValidationGroup="cartao" Width="244px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tb_localidade" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do localidade." SetFocusOnError="true" Text="*" Style="color: red;" />
                                    <asp:Label ID="Label5" runat="server" Text="Telefone" Style="margin-left: 102px;"></asp:Label>
                                    <asp:TextBox ID="tb_telefone" MaxLength="14" runat="server" ValidationGroup="cartao" Style="margin-left: 10px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_telefone" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do telefone." SetFocusOnError="true" Text="*" Style="color: red;" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="tb_telefone" EnableClientScript="true" ErrorMessage="Apenas pode introduzir numeros no campo telemóvel." SetFocusOnError="true" Text="*" ValidationExpression="^[0-9]*$" Style="color: red;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="Label6" runat="server" Text="Telemóvel"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_tlm" MaxLength="14" runat="server" ValidationGroup="cartao" Style="margin-left: -1px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_tlm" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do telemóvel." SetFocusOnError="true" Text="*" Style="color: red;" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="tb_tlm" EnableClientScript="true" ErrorMessage="Apenas pode introduzir numeros no campo telemóvel." SetFocusOnError="true" Text="*" ValidationExpression="^[0-9]*$" Style="color: red;" />
                                    <asp:Label ID="Label1" runat="server" Text="Telefone Serviço" Style="margin-left: 144px;"></asp:Label>
                                    <asp:TextBox ID="tb_tlf_serv" runat="server" MaxLength="14" ValidationGroup="cartao" Style="margin-left: 10px;"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="tb_tlf_serv" EnableClientScript="true" ErrorMessage="Apenas pode introduzir números no campo telefone de serviço." SetFocusOnError="true" Text="*" ValidationExpression="^[0-9]*$" Style="color: red;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">Email</td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server" MaxLength="56" Width="310px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="Email" EnableClientScript="true" ErrorMessage="É necessário a inserção do Email" SetFocusOnError="true" Text="*" ValidationGroup="cartao" Style="color: red;" />
                                    <asp:RegularExpressionValidator ID="rexemail" runat="server" ControlToValidate="Email" EnableClientScript="true" ErrorMessage="Introduza um e-mail válido." SetFocusOnError="true" Text="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Style="color: red;" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset style="width: 690px; margin-left: 10px; margin-top: 10px; color: #0d4465;">
                        <legend style="font-family: Ubuntu; font-size: 14px; font-weight: bold; color: #0d4465;">Informação BI/CC/Passaporte</legend>
                        <table style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 5px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                            <tr>
                                <td class="auto-style3">
                                    <asp:Label ID="Label8" runat="server" Text="CC/BI/Passaporte nº"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_bi" runat="server" MaxLength="17" ValidationGroup="cartao" Width="170px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tb_bi" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do CC/BI/Passaporte." SetFocusOnError="true" Text="*" Style="color: red;" />
                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="tb_bi" EnableClientScript="true" ErrorMessage="Apenas pode introduzir numeros CC/BI/Passaporte." SetFocusOnError="true" Text="*" Style="color: red;" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>--%>
                                    <asp:Label ID="Label9" runat="server" Text="Validade" Style="margin-left: 92px;"></asp:Label>
                                    <asp:TextBox ID="tb_validade_bi" runat="server" MaxLength="45" ValidationGroup="calendar" Style="margin-left: 10px;"></asp:TextBox>
                                    <asp:ImageButton ID="ib_v_bi" runat="Server" ImageUrl="~/Layout/img/calendar.png" ValidationGroup="calendar" Width="25px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tb_validade_bi" EnableClientScript="true" ErrorMessage="É necessário o preenchimento da data de validade do documento de identificação." SetFocusOnError="true" Text="*" Style="color: red;" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="tb_validade_bi" Display="Dynamic" ErrorMessage="A data deve estar no formato: dd/mm/yyyy" SetFocusOnError="True" Text="*" Style="color: red;" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /](0[1-9]|1[012])[- /](19|20)[0-9]{2}"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    <asp:Label ID="Label19" runat="server" Text="Nacionalidade"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_nacionalidade" runat="server" MaxLength="21" ValidationGroup="cartao" Width="169px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="tb_nacionalidade" EnableClientScript="true" ErrorMessage="É necessário o preenchimento da nacionalidade." SetFocusOnError="true" Text="*" Style="color: red;" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="tb_nacionalidade" EnableClientScript="true" ErrorMessage="Apenas pode introduzir letras no campo da nacionalidade." SetFocusOnError="true" Text="*" ValidationExpression="^[a-zA-ZáàÁÀéÉíÍìÌóòÒÓÃãõÕèÈúÚùÙêÊçÇ ]*$" Style="color: red;" />
                                    <asp:Label ID="Label10" runat="server" Text="Data de Nascimento" Style="margin-left: 15px;"></asp:Label>
                                    <asp:TextBox ID="tb_d_nascimento" runat="server" MaxLength="45" ValidationGroup="calendar" Style="margin-left: 10px;"></asp:TextBox>
                                    <asp:ImageButton ID="ib_d_nascimento" runat="Server" Height="25px" ImageUrl="~/Layout/img/calendar.png" ValidationGroup="calendar" Width="25px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tb_d_nascimento" EnableClientScript="true" ErrorMessage="É necessário o preenchimento da data de nascimento." SetFocusOnError="true" Text="*" Style="color: red;" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_d_nascimento" Display="Dynamic" ErrorMessage="A data deve estar no formato: dd/mm/yyyy" SetFocusOnError="True" Text="*" Style="color: red;" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /](0[1-9]|1[012])[- /](19|20)[0-9]{2}"></asp:RegularExpressionValidator>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" DefaultView="Years" PopupButtonID="ib_v_bi" TargetControlID="tb_validade_bi" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" DefaultView="Years" PopupButtonID="ib_d_nascimento" TargetControlID="tb_d_nascimento" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset style="width: 690px; margin-left: 10px; margin-top: 10px; color: #0d4465;">
                        <legend style="font-family: Ubuntu; font-size: 14px; font-weight: bold; color: #0d4465;">Informação Contratual</legend>
                        <table style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 5px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label13" runat="server" Text="Entidade Patronal"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_patronal" runat="server" MaxLength="29" ValidationGroup="cartao" Width="418px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator132" runat="server" ControlToValidate="tb_patronal" ErrorMessage="É necessário o preenchimento do campo entidade patronal." EnableClientScript="true" SetFocusOnError="true" Text="*" Style="color: red;" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label16" runat="server" Text="Cat. Profissional"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_cat_prof" runat="server" MaxLength="42" ValidationGroup="cartao" Width="418px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="tb_cat_prof" ErrorMessage="É necessário o preenchimento do campo categoria profissional." SetFocusOnError="true" Text="*" Style="color: red;" EnableClientScript="true" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="tb_cat_prof" EnableClientScript="true" ErrorMessage="Apenas pode introduzir letras no campo da categoria profissional." SetFocusOnError="true" Text="*" ValidationExpression="^[a-zA-ZáàÁÀéÉíÍìÌóòÒÓÃãõÕèÈúÚùÙêÊçÇ ]*$" Style="color: red;" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" BackColor="#FEDAD8" Style="margin-left: 10px; margin-top: 10px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="715px" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:WizardStep>
        <asp:WizardStep ID="entidade" runat="server" Title="Entidade Requisitante">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <fieldset style="width: 690px; margin-left: 10px; margin-top: 25px; margin-right: 10px;">
                        <legend style="font-family: Ubuntu; font-size: 14px; color: #0d4465; font-weight: bold;">Informação Entidade Requisitante</legend>
                        <table style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 7px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                            <tr>
                                <td class="auto-style7">
                                    <asp:Label ID="Label11" runat="server" Text="Nome ou denominação"></asp:Label>
                                </td>
                                <td class="auto-style10">
                                    <asp:TextBox ID="tb_nome_entidade" runat="server" Enabled="false" ValidationGroup="cartao" Width="398px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">
                                    <asp:Label ID="Label12" runat="server" Text="Tipo de cartão"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:RadioButtonList ID="rb_tipo_cartao" runat="server" AutoPostBack="True" Style="font-size: 12px; color: #0d4465; font-family: ubuntu;" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                        <asp:ListItem Value="Permanente">Cartão Permanente</asp:ListItem>
                                        <asp:ListItem Value="Temporaria">Cartão Temporária</asp:ListItem>
                                        <asp:ListItem Value="Acompanhado">Cartão Pontual de Visitante</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator
                                        ID="ReqiredFieldValidator1"
                                        runat="server"
                                        ControlToValidate="rb_tipo_cartao"
                                        ErrorMessage="É necessário escolher o tipo de cartão."
                                        EnableClientScript="true"
                                        Text="*" Style="color: red;">  </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Panel ID="Panel_validade_acesso" runat="server" Visible="false">
                                        <asp:Label ID="Label_n_meses" runat="server" Text="Validade do Acesso Nº" Visible="true"></asp:Label>
                                        <asp:TextBox ID="tb_validade_acesso" runat="server" MaxLength="2" Visible="true" Width="45px" Style="margin-left: 78px;"></asp:TextBox>
                                        <asp:Label ID="Label_meses" runat="server" Text="(Meses)" Visible="true"></asp:Label>
                                        <asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1122"
                                            runat="server"
                                            ControlToValidate="tb_validade_acesso"
                                            ErrorMessage="É necessário inserir o número de meses."
                                            EnableClientScript="true"
                                            Text="*" Style="color: red;">  </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator69"
                                            ControlToValidate="tb_validade_acesso" ValidationExpression="^[0-9]*$"
                                            ErrorMessage="Deve introduzir números de meses."
                                            EnableClientScript="true"
                                            SetFocusOnError="true"
                                            Text="*" Style="color: red;" />
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Panel ID="Panel_num_cartao" runat="server" Visible="false">
                                        <asp:Label ID="lb_cartao" runat="server" Text="Renovação cartão Nº" Visible="true"></asp:Label>
                                        <asp:TextBox ID="tb_r_cartao" runat="server" Visible="true" Enabled="false" Style="margin-left: 85px;"></asp:TextBox>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Panel ID="Panel_acompanhante" runat="server" Visible="false">
                                        <asp:Label ID="Label26" runat="server" Text="Acompanhado por" Visible="true"></asp:Label>
                                        <asp:TextBox ID="tb_acompanhante" runat="server" MaxLength="31" ValidationGroup="cartao" Visible="true" Style="margin-left: 100px;" Width="305px"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator20" ControlToValidate="tb_acompanhante"
                                            ErrorMessage="É necessário o preenchimento do nome do acompanhante."
                                            EnableClientScript="true"
                                            SetFocusOnError="true"
                                            Text="*" Style="color: red;" />
                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator166" ControlToValidate="tb_acompanhante" ValidationExpression="^[a-zA-ZáàÁÀéÉíÍìÌóòÒÓÃãõÕèÈúÚùÙêÊçÇ ]*$" ErrorMessage="Apenas pode introduzir letras no nome do acompanhante."
                                            EnableClientScript="true"
                                            SetFocusOnError="true"
                                            Text="*" Style="color: red;" />
                                        <asp:Label ID="Label27" runat="server" Text="Com o cartão" Visible="true" Style="margin-left: 0px;"></asp:Label>
                                        <asp:TextBox ID="tb_cartao_acompanhante" runat="server" MaxLength="5" Style="margin-left: 5px;" ValidationGroup="cartao" Width="51px" Visible="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator21" ControlToValidate="tb_cartao_acompanhante"
                                            ErrorMessage="É necessário o preenchimento do nº do cartão de acesso do acompanhante."
                                            EnableClientScript="true"
                                            SetFocusOnError="true"
                                            Text="*" Style="color: red;" />
                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator17" ControlToValidate="tb_cartao_acompanhante" ValidationExpression="^[0-9]*$" ErrorMessage="Apenas pode introduzir números no campo Nº cartão do acompanhante."
                                            EnableClientScript="true"
                                            SetFocusOnError="true"
                                            Text="*" Style="color: red;" />
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">
                                    <asp:Label ID="Label20" runat="server" Text="Área predominante de trabalho"></asp:Label>
                                </td>
                                <td class="auto-style10">
                                    <asp:TextBox ID="tb_areas_trabalho" runat="server" MaxLength="30" ValidationGroup="cartao" Width="439px" Visible="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style8">
                                    <asp:Label ID="Label21" runat="server" Text="Função"></asp:Label>
                                </td>
                                <td class="auto-style11">
                                    <asp:TextBox ID="tb_funcao" runat="server" MaxLength="45" ValidationGroup="cartao" Width="400px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="tb_funcao" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do campo função." SetFocusOnError="true" Style="color: red;" Text="*" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="tb_funcao" EnableClientScript="true" ErrorMessage="Apenas pode introduzir letras no campo função." SetFocusOnError="true" Text="*" Style="color: red;" ValidationExpression="^[a-zA-ZáàÁÀéÉíÍìÌóòÒÓÃãõÕèÈúÚùÙêÊçÇ ]*$" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style7">
                                    <asp:Label ID="Label25" runat="server" Text="Horário de Acesso"></asp:Label>
                                </td>
                                <td class="auto-style10">
                                    <asp:TextBox ID="tb_horario" runat="server" MaxLength="31" ValidationGroup="cartao" Width="274px"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="tb_horario" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do campo horário de acesso." SetFocusOnError="true" Text="*" Style="color: red;" />--%>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" BackColor="#FEDAD8" Style="margin-left: 10px; margin-top: 10px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="715px" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep1" runat="server" Title="Acesso a áreas restritas">
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                    <fieldset style="width: 690px; margin-left: 10px; margin-top: 25px; margin-right: 10px;">
                        <legend style="font-family: Ubuntu; font-size: 14px; color: #0d4465; font-weight: bold;">Áreas onde o funcionário exerce funções</legend>
                        <div style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 7px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                            <asp:CheckBoxList ID="cb_areas_funcoes" runat="server" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;">
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
                    <asp:ValidationSummary ID="ValidationSummary6" runat="server" ForeColor="Red" BackColor="#FEDAD8" Style="margin-left: 10px; margin-top: 10px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="715px" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep_areas_restritas" runat="server" Title="Condições de Acesso">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <fieldset style="width: 690px; margin-left: 10px; margin-top: 25px; margin-right: 10px;">
                        <legend style="font-family: Ubuntu; font-size: 14px; color: #0d4465; font-weight: bold;">Autorizacao de aberturas de portas automatizadas</legend>
                        <div style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 7px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                            <asp:CheckBox ID="portas" Text="Portas Embarque/Desembarque" Style="font-size: 12px; color: #0d4465; font-family: ubuntu;" runat="server" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="outras" Style="font-size: 12px; font-family: ubuntu; color: #0d4465;" Text="Outras" runat="server" AutoPostBack="true" OnCheckedChanged="cb_portas_SelectedIndexChanged" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                
                    <asp:TextBox ID="tb_outras" runat="server" Visible="false" MaxLength="75" Width="300px"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator3" runat="server"
                                ErrorMessage="Deve referir quais as outras áreas"
                                EnableClientScript="true"
                                Text="*" Style="color: red;" OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator>
                        </div>
                    </fieldset>
                    <fieldset style="width: 690px; margin-left: 10px; margin-top: 10px; color: #0d4465; margin-right: 10px;">
                        <legend style="font-family: Ubuntu; font-size: 14px; font-weight: bold; color: #0d4465;">Condições complementares para acesso a áreas restritas</legend>
                        <div style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 7px;">
                            <asp:Label ID="Label30" runat="server" Style="font-size: 12px; font-family: ubuntu; color: #0d4465;">
                   1.Foi efectuado o inquérito pessoal dos últimos 5 anos, de acordo com o disposto no nº11 do Reg. (EU) Nº 185/2010 da Comissão de 4 de Maio de 2010?&nbsp; 
             
                     O Certificado de Registo Criminal passado para acesso a áreas restritas de um aeroporto deve ser anexado ao processo.              
                            </asp:Label>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator4"
                                runat="server"
                                EnableClientScript="true"
                                ControlToValidate="RadioButtonList_inquerito"
                                ErrorMessage="É necessário responder á pergunta relativa ao inquérito!"
                                Text="*" Style="color: red;">  </asp:RequiredFieldValidator>
                            <asp:RadioButtonList ID="RadioButtonList_inquerito" Style="font-size: 12px; font-family: ubuntu; color: #0d4465;" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Sim">Sim</asp:ListItem>
                                <asp:ListItem Value="Não">Não</asp:ListItem>
                            </asp:RadioButtonList>

                            <asp:Label ID="Label32" runat="server" Style="font-size: 12px; font-family: ubuntu; color: #0d4465;">
                        2.Foi ministrada formação de segurança na aviação civil de acordo com os requisitos estabelecidos no nº11 do Reg. (EU) Nº 185/2010 da Comissão de 4 de Maio de 10? 
                            </asp:Label><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator9"
                                runat="server"
                                EnableClientScript="true"
                                ControlToValidate="RadioButtonList_formacao"
                                ErrorMessage="É necessário responder á pergunta relativa á formação."
                                Text="*" Style="color: red;">  </asp:RequiredFieldValidator>
                            <asp:RadioButtonList ID="RadioButtonList_formacao" Style="font-size: 12px; font-family: ubuntu; color: #0d4465;" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Sim">Sim</asp:ListItem>
                                <asp:ListItem Value="Não">Não</asp:ListItem>
                            </asp:RadioButtonList>

                        </div>
                    </fieldset>
                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ForeColor="Red" BackColor="#FEDAD8" Style="margin-left: 10px; margin-top: 10px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="715px" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:WizardStep>
        <asp:WizardStep ID="declaracao_entidade" runat="server" Title="Declaração da Entidade">
            <fieldset style="width: 690px; margin-left: 10px; color: #0d4465; margin-top: 25px; margin-right: 10px;">
                <legend style="font-family: Ubuntu; font-size: 14px; color: #0d4465; font-weight: bold;">Declaração Entidade Requisitante</legend>
                <div style="margin-left: 10px; margin-top: 10px; width: 664px; line-height: 25px; text-align: justify; padding-right: 10px; padding-bottom: 10px;">
                    <asp:Label ID="Label15" runat="server" Style="font-family: Ubuntu; font-size: 13px; color: #0d4465;">
                Para os devidos efeitos e relacionado com o exercício da actividade que motiva a emissão da competente autorização de acesso às áreas reservadas e restritas da Aerogare Civil das Lajes, declara-se que a Entidade requisitante se reconhece responsável, sem averiguação prévia da respectiva causa, mas sem prejuízo de confirmação por averiguações posteriores, por quaisquer danos que o funcionário acima mencionado causar a quaisquer entidades, seja a que título for ou por que modalidade.
                <br />Para o efeito de emissão de um cartão de identificação e de acesso à Aerogare Civil das Lajes, a favor do referido funcionário, declara-se que toda a informação indicada e anexada está correcta e é verdadeira. As áreas de acesso indicadas correspondem apenas às áreas onde o funcionário exerce funções.
                <br />Reconhece-se que o cartão de acesso a ser emitido pela Aerogare Civil das Lajes será sempre propriedade desta, pelo que será devolvido sempre e logo que cesse a sua validade ou as condições que levaram à sua emissão, ou quando a Aerogare Civil das Lajes assim o determinar. Sendo cumprido o descrito nos pontos 1. e 2., será guardado um registo de prova efectuando-se a devida comprovação sempre que solicitado pela Aerogare Civil das Lajes ou por uma Autoridade Adequada. 
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    </asp:Label>
                    <br />
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:CheckBox ID="cb_validate" runat="server" Style="font-family: Ubuntu; font-size: 13px; color: #0d4465;" Text="Tomei conhecimento e aceito as condições de utilização" />
                            <asp:CustomValidator ID="CustomValidator1" runat="server"
                                ErrorMessage="É necessário aceitar os termos de utilização." EnableClientScript="true"
                                Text="*" Style="color: red;" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>                  
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </fieldset>
            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ForeColor="Red" BackColor="#FEDAD8" Style="margin-left: 10px; margin-top: 10px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="715px" />
        </asp:WizardStep>
        <asp:WizardStep ID="documentos" runat="server" Title="Documentos a anexar">
            <div style="margin-left: 10px; margin-top: 10px;">          
            </div>
            <fieldset style="width: 690px; margin-left: 10px; margin-right: 10px; margin-top: 15px; color: #0d4465; margin-bottom: 10px; color: #0d4465;">
                <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px; color: #0d4465;">Carregar Fotocópia legivel do CC/BI/Passaporte</legend>
                <div style="margin-bottom: 10px; margin-top: 10px; margin-left: 10px; margin-right: 10px;">
                    <ajaxToolkit:AsyncFileUpload ID="AFileUpload_bi" runat="server" ThrobberID="Throbber1" OnClientUploadStarted="checkExtension" OnClientUploadError="uploadError" OnClientUploadComplete="uploadcomplete" Width="100%" ErrorBackColor="#FC362A" CompleteBackColor="#2AFC60" OnUploadedComplete="AFileUpload_bi_UploadedComplete" />
                    <asp:Label ID="Throbber1" runat="server" Style="display: none">
                        <img src="../Layout/img/Loading.gif"  alt="Validando" class="loading_fileupload"/>
                    </asp:Label>
                </div>
            </fieldset>
            <fieldset style="width: 690px; margin-left: 10px; margin-right: 10px; margin-top: 10px; color: #0d4465; margin-bottom: 10px;">
                <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px; color: #0d4465;">Carregar Declaração de vinculo laboral</legend>
                <div style="margin-bottom: 10px; margin-top: 10px; margin-left: 10px; margin-right: 10px;">
                    <ajaxToolkit:AsyncFileUpload ID="AFileUpload_vinculo" runat="server" ThrobberID="Throbber2" OnClientUploadStarted="checkExtension" OnClientUploadError="uploadError" OnClientUploadComplete="uploadcomplete" Width="100%" ErrorBackColor="#FC362A" CompleteBackColor="#2AFC60" OnUploadedComplete="AFileUpload_vinculo_UploadedComplete" />
                    <asp:Label ID="Throbber2" runat="server" Style="display: none">
                            <img src="../Layout/img/Loading.gif"  alt="Validando" class="loading_fileupload"/>
                    </asp:Label>
                </div>
            </fieldset>
            <fieldset style="width: 690px; margin-left: 10px; margin-right: 10px; margin-top: 10px; color: #0d4465; margin-bottom: 10px;">
                <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px; color: #0d4465;">Carregar Fotografia tipo passe recente</legend>
                <div style="margin-bottom: 10px; margin-top: 10px; margin-left: 10px; margin-right: 10px;">
                    <ajaxToolkit:AsyncFileUpload ID="AFileUpload_foto" runat="server" ThrobberID="Throbber3" OnClientUploadStarted="checkExtension_foto" OnClientUploadError="uploadError" OnClientUploadComplete="uploadcomplete" OnUploadedComplete="AFileUpload_foto_UploadedComplete" Width="100%" ErrorBackColor="#FC362A" CompleteBackColor="#2AFC60" />
                    <asp:Label ID="Throbber3" runat="server" Style="display: none">
                            <img src="../Layout/img/Loading.gif"  alt="Validando"  class="loading_fileupload" />
                    </asp:Label>
                </div>
            </fieldset>
            <fieldset style="width: 690px; margin-left: 10px; margin-right: 10px; margin-top: 10px; color: #0d4465; margin-bottom: 10px;">
                <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px; color: #0d4465; color: #0d4465;">Carregar Prova da existência de Registo Criminal (Se aplicável)</legend>
                <div style="margin-bottom: 10px; margin-top: 10px; margin-left: 10px; margin-right: 10px;">
                    <ajaxToolkit:AsyncFileUpload ID="AFileUpload_r_criminal" runat="server" ThrobberID="Throbber4" OnClientUploadStarted="checkExtension" OnClientUploadError="uploadError" OnClientUploadComplete="uploadcomplete" Width="100%" ErrorBackColor="#FC362A" CompleteBackColor="#2AFC60" OnUploadedComplete="AFileUpload_r_criminal_UploadedComplete" />
                    <asp:Label ID="Throbber4" runat="server" Style="display: none;">
                            <img src="../Layout/img/Loading.gif"  alt="Validando" class="loading_fileupload"/>
                    </asp:Label>
                </div>
            </fieldset>
            <asp:Panel ID="Panel_cartao_acaompanhante_upload" runat="server" Visible="false">
                <fieldset style="width: 690px; margin-left: 10px; margin-right: 10px; margin-top: 10px; color: #0d4465; margin-bottom: 10px;">
                    <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px;  color: #0d4465;">Cartão de Identificação e acesso do acompanhante</legend>
                    <div style="margin-bottom: 10px; margin-top: 10px; margin-left: 10px; margin-right: 10px;">
                        <ajaxToolkit:AsyncFileUpload ID="AFileUpload_cartao_acompanhante" ThrobberID="Throbber5" runat="server" OnClientUploadStarted="checkExtension" OnClientUploadError="uploadError" OnClientUploadComplete="uploadcomplete" OnUploadedComplete="AFileUpload_cartao_acompanhante_UploadedComplete" Width="100%" ErrorBackColor="#FC362A" CompleteBackColor="#2AFC60" />
                        <asp:Label ID="Throbber5" runat="server" Style="display: none;">
                                <img src="../Layout/img/Loading.gif"  alt="Validando" class="loading_fileupload" />
                        </asp:Label>
                    </div>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel_renovacao" runat="server" Visible="false">
                <fieldset style="width: 690px; margin-left: 10px; margin-right: 10px; margin-top: 10px; color: #0d4465; margin-bottom: 10px;">
                    <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px;  color: #0d4465;">Carregar Fotocópia legivel do Cartão de identificação e acesso (Renovação)</legend>
                    <div style="margin-bottom: 10px; margin-top: 10px; margin-left: 10px; margin-right: 10px;">
                        <ajaxToolkit:AsyncFileUpload ID="AFileUpload_cartao_renovacao" runat="server" ThrobberID="Throbber6" OnClientUploadStarted="checkExtension" OnClientUploadError="uploadError" OnClientUploadComplete="uploadcomplete" OnUploadedComplete="AFileUpload_cartao_renovacao_UploadedComplete" Width="100%" ErrorBackColor="#FC362A" CompleteBackColor="#2AFC60" />
                        <asp:Label ID="Throbber6" runat="server" Style="display: none">
                            <img src="../Layout/img/Loading.gif"  alt="Validando" class="loading_fileupload"/>
                        </asp:Label>
                    </div>
                </fieldset>
            </asp:Panel>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <asp:ValidationSummary ID="ValidationSummary5" runat="server" ForeColor="Red" BackColor="#FEDAD8" ValidationGroup="MyValidationGroup" Style="margin-left: 10px; margin-top: 10px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="713px" />
                    <div id="ContentPlaceHolder1_conducao_form_Conducao_StatusLabel" style="display: none; background-color: #FEDAD8; color: red; font-size: 12px; margin-left: 10px; margin-top: 10px; text-align: justify; float: left; width: 97.5%; border: 2px solid red; display: none; margin-bottom: 10px;">
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:WizardStep>
    </WizardSteps>
    <FinishNavigationTemplate>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:ImageButton ID="FinishPreviousButton" runat="server" ToolTip="Anterior" Style="margin-bottom: 5px; margin-top: 5px;" CommandName="MovePrevious" ImageUrl="~/Layout/img/anterior.png" />
                <asp:ImageButton ID="FinishButton" ToolTip="Submeter Pedido" Style="margin-bottom: 5px; margin-top: 5px; margin-right: 5px;" runat="server" AlternateText="Finish" CommandName="MoveComplete" ImageUrl="~/Layout/img/save.png" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="prgLoadingStatus" runat="server" DynamicLayout="true">
            <ProgressTemplate>
                <div id="overlay">
                    <div id="modalprogress">
                        <div id="theprogress">
                            <asp:Image ID="imgWaitIcon" runat="server" ImageAlign="AbsMiddle" ImageUrl="../Layout/img/sending.gif" Width="300px" Height="300px" />
                        </div>
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </FinishNavigationTemplate>
    <SideBarStyle BackColor="#CCCCCC" Width="250px" />
    <SideBarTemplate>
        <asp:DataList runat="server" ID="SideBarList" OnItemDataBound="SideBarList_ItemDataBound" CellPadding="5">
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="SideBarButton" Font-Bold="true" Width="200"
                    cssclass="sidebar_btn" />
            </ItemTemplate>
        </asp:DataList>
    </SideBarTemplate>
</asp:Wizard>

<%------------------------------------------------------JAVASCRIPT----------------------------------------------------------%>
<script src="../JS/Script.js"></script>
<%--------------------------------------------------------STYLES-------------------------------------------------------------%>
<style>
    .auto-style3 {
        width: 136px;
    }

    .auto-style4 {
        width: 165px;
    }

    .auto-style5 {
        width: 74px;
    }

    .auto-style7 {
        width: 198px;
    }

    .auto-style8 {
        width: 198px;
        height: 26px;
    }

    .auto-style9 {
        height: 26px;
    }

    .auto-style10 {
        width: 469px;
    }

    .auto-style11 {
        height: 26px;
        width: 469px;
    }
</style>
