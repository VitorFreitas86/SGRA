<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="viatura_form.ascx.cs" Inherits="WebApplication10.controls.viatura_form" %>
<div>
    <asp:Label ID="Label_status" runat="server" Text="" Visible="false"></asp:Label>
</div>
<asp:Wizard ID="viatura" runat="server" ActiveStepIndex="0" OnFinishButtonClick="viatura_FinishButtonClick" BackColor="#F8F8F8" FinishCompleteButtonImageUrl="~/Layout/img/save.png" FinishCompleteButtonType="Image" FinishPreviousButtonImageUrl="~/Layout/img/anterior.png" FinishPreviousButtonText="" FinishPreviousButtonType="Image" StartNextButtonImageUrl="~/Layout/img/next.png" StartNextButtonType="Image" StepNextButtonImageUrl="~/Layout/img/next.png" StepNextButtonType="Image" StepPreviousButtonImageUrl="~/Layout/img/anterior.png" StepPreviousButtonType="Image" OnNextButtonClick="viatura_NextButtonClick">
    <StartNavigationTemplate>
        <asp:ImageButton ID="StartNextButton" ToolTip="Seguinte" Style="margin-bottom: 5px; margin-top: 5px; margin-right: 5px;" runat="server" AlternateText="Next" CommandName="MoveNext" ImageUrl="~/Layout/img/next.png" />
    </StartNavigationTemplate>
    <StepNavigationTemplate>
        <asp:ImageButton ID="StepPreviousButton" runat="server" ToolTip="Anterior" Style="margin-bottom: 5px; margin-top: 5px;" AlternateText="Previous" CausesValidation="False" CommandName="MovePrevious" ImageUrl="~/Layout/img/anterior.png" />
        <asp:ImageButton ID="StepNextButton" runat="server" ToolTip="Seguinte" Style="margin-bottom: 5px; margin-top: 5px; margin-right: 5px;" AlternateText="Next" CommandName="MoveNext" ImageUrl="~/Layout/img/next.png" />
    </StepNavigationTemplate>
    <WizardSteps>
        <asp:WizardStep ID="dados_viatura" runat="server" Title="Dados Viatura">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <div style="margin-bottom: 10px; margin-top: 10px; float: left;">
                                        <asp:Label ID="Label7" runat="server" Text="Número de identificação" Style="margin-left: 10px; color: #0d4465; font-family: Ubuntu; font-size: 12px;"></asp:Label>
                                        <asp:TextBox ID="tb_n_identificao" runat="server" MaxLength="45" ValidationGroup="viatura" Enabled="false" Visible="true" Style="margin-left: 10px;"></asp:TextBox>
                                    </div>
                                </td>
                                <td>
                                    <div style="margin-bottom: 10px; margin-top: 10px; float: right; margin-right: 3px; margin-right: 10px;">
                                        <asp:Label ID="Label14" runat="server" Text="Nº Processo" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;"></asp:Label>
                                        <asp:TextBox ID="tb_num" runat="server" Width="54px" Enabled="false" Style="margin-left: 10px;"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <fieldset style="width: 676px; margin-left: 10px; margin-right: 10px; margin-top: 10px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                        <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px; color: #0d4465;">Informação da Viatura</legend>
                        <table style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 5px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                            <tr>
                                <td class="auto-style3">
                                    <asp:Label ID="Label2" runat="server" Text="Marca"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_marca" runat="server" MaxLength="18" ValidationGroup="viatura"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tb_marca" EnableClientScript="true" ErrorMessage="É necessário o preenchimento da marca da viatura" SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="rexenome" runat="server" ControlToValidate="tb_marca" EnableClientScript="true" ErrorMessage="Apenas pode introduzir letras no campo marca da viatura" SetFocusOnError="True" Text="*" ValidationExpression="^[a-zA-ZáàÁÀéÉíÍìÌóòÒÓÃãõÕèÈúÚùÙêÊçÇ ]*$" Style="color: red;"> </asp:RegularExpressionValidator>
                                    <asp:Label ID="Label3" runat="server" Text="Modelo"></asp:Label>
                                    <asp:TextBox ID="tb_modelo" runat="server" MaxLength="17" ValidationGroup="viatura" Style="margin-left: 10px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tb_modelo" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do modelo da viatura." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                    <asp:Label ID="Label4" runat="server" Text="Cor"></asp:Label>
                                    <asp:TextBox ID="tb_cor" runat="server" MaxLength="13" ValidationGroup="viatura" Style="margin-left: 3px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_cor" EnableClientScript="true" ErrorMessage="É necessário o preenchimento da cor da viatura" SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="tb_cor" EnableClientScript="true" ErrorMessage="Apenas pode introduzir letras no campo cor da viatura." SetFocusOnError="True" Text="*" ValidationExpression="^[a-zA-ZáàÁÀéÉíÍìÌóòÒÓÃãõÕèÈúÚùÙêÊçÇ ]*$" Style="color: red;"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    <asp:Label ID="Label5" runat="server" Text="Matricula"></asp:Label>
                                </td>
                                <td><%--AutoPostBack="True" OnTextChanged="tb_matricula_TextChanged"--%>
                                    <asp:TextBox ID="tb_matricula" runat="server" MaxLength="8" Style="text-transform: uppercase" ValidationGroup="viatura" ></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_matricula" EnableClientScript="true" ErrorMessage="É necessário o preenchimento da matricula da viatura" SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>--%>
                                    <asp:CustomValidator ID="CustomValidator2" runat="server" EnableClientScript="true"
                    ErrorMessage="Por favor reveja a matricula da viatura, porque a matricula inserida já se encontra associada a outra viatura."
                    Text="*"  Style="color: red;" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
     
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="tb_matricula" EnableClientScript="true" ErrorMessage="A matricula da viatura deve ser inserida no formato HH-HH-HH" SetFocusOnError="True" Text="*" ValidationExpression="[0-9A-Za-z]{2,2}[-][0-9A-Za-z]{2,2}[-][0-9A-Za-z]{2,2}" Style="color: red;"></asp:RegularExpressionValidator>
                                    <asp:Label ID="Label6" runat="server" Text="Proprietáro"></asp:Label>
                                    <asp:TextBox ID="tb_proprietario" runat="server" MaxLength="48" ValidationGroup="viatura" Width="320px" Style="margin-left: 10px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_proprietario" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do proprietário da viatura." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="tb_proprietario" EnableClientScript="true" ErrorMessage="Apenas pode introduzir letras no proprietário." SetFocusOnError="True" Text="*" ValidationExpression="^[a-zA-ZáàÁÀéÉíÍìÌóòÒÓÃãõÕèÈúÚùÙêÊçÇ ]*$" Style="color: red;"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>

                    </fieldset>
                    <fieldset style="width: 676px; margin-left: 10px; margin-top: 10px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                        <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px; color: #0d4465;">Informação da Seguradora</legend>
                        <table style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 5px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label19" runat="server" Text="Companhia de Seguros"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_companhia_seguros" runat="server" MaxLength="22" ValidationGroup="viatura" Width="490px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="tb_companhia_seguros" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do nome da companhia de seguros." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="tb_companhia_seguros" EnableClientScript="true" ErrorMessage="Apenas pode introduzir letras no campo da companhia de seguros." SetFocusOnError="True" Text="*" ValidationExpression="^[a-zA-ZáàÁÀéÉíÍìÌóòÒÓÃãõÕèÈúÚùÙêÊçÇ ]*$" Style="color: red;"></asp:RegularExpressionValidator>
                                </td>

                            </tr>
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label1" runat="server" Text="Nº apolice"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_apolice" runat="server" MaxLength="14" ValidationGroup="viatura" Width="183px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tb_apolice" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do Nº de Apolice." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="tb_apolice" EnableClientScript="true" ErrorMessage="Apenas pode introduzir números no campo Nº da Apólice." SetFocusOnError="True" Text="*" ValidationExpression="^[0-9]*$" Style="color: red;"></asp:RegularExpressionValidator>--%>
                                    <asp:Label ID="Label8" runat="server" Text="Validade Seguro" Style="margin-left: 9px;"></asp:Label>
                                    <asp:TextBox ID="tb_d_seguro" runat="server" MaxLength="45" TextMode="DateTime" ValidationGroup="calendar" Style="margin-left: 10px;"></asp:TextBox>
                                    <asp:ImageButton ID="ib_calendar_d_seguro" runat="server" ImageUrl="~/Layout/img/calendar.png" ValidationGroup="calendar" Width="25px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tb_d_seguro" EnableClientScript="true" ErrorMessage="É necessário o preenchimento da data de seguro." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="REcreationdate" runat="server" ControlToValidate="tb_d_seguro" Display="Dynamic" ErrorMessage="A data deve estar no formato: dd/mm/yyyy" SetFocusOnError="True" Text="*" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /](0[1-9]|1[012])[- /](19|20)[0-9]{2}" Style="color: red;"></asp:RegularExpressionValidator>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"
                                        TargetControlID="tb_d_seguro" PopupButtonID="ib_calendar_d_seguro" DefaultView="Years" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset style="width: 670px; margin-left: 10px; margin-top: 10px;">
                        <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px; color: #0d4465;">Informação da IPO</legend>
                        <table style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 5px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                            <tr>
                                <td class="auto-style2">
                                    <asp:Label ID="Label9" runat="server" Text="Data de inspeção (IPO)"></asp:Label>
                                </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="tb_ipo" runat="server" MaxLength="45" ValidationGroup="calendar" Width="135px"></asp:TextBox>
                                    <asp:ImageButton runat="Server" ID="ib_ipo" ImageUrl="~/Layout/img/calendar.png" Width="25px" ValidationGroup="calendar" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" OnClientDateSelectionChanged="OnClientDateSelectionChanged"
                                        TargetControlID="tb_ipo" PopupButtonID="ib_ipo" DefaultView="Years" />
                                    <script type="text/javascript">
                                        function OnClientDateSelectionChanged(sender, args) {
                                            $find("<%=CalendarExtender2.ClientID %>").set_startDate(sender._selectedDate);
                                        }
                                    </script>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="tb_ipo" Display="Dynamic" ErrorMessage="A data deve estar no formato: dd/mm/yyyy" SetFocusOnError="True" Text="*" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /](0[1-9]|1[012])[- /](19|20)[0-9]{2}" Style="color: red;"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tb_ipo" EnableClientScript="true" ErrorMessage="É necessário o preenchimento da data de inspeção." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Validade da inspeção"></asp:Label>
                                    <asp:TextBox ID="tb_validade_ipo" runat="server" MaxLength="45" ValidationGroup="calendar" Style="margin-left: 10px;" Width="135px"></asp:TextBox>
                                    <asp:ImageButton ID="ib_validade" runat="server" ImageUrl="~/Layout/img/calendar.png" ValidationGroup="calendar" Width="25px" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tb_validade_ipo" EnableClientScript="true" ErrorMessage="É necessário o preenchimento da validade da IPO." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_validade_ipo" Display="Dynamic" ErrorMessage="A data deve estar no formato: dd/mm/yyyy" SetFocusOnError="True" Text="*" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /](0[1-9]|1[012])[- /](19|20)[0-9]{2}" Style="color: red;"></asp:RegularExpressionValidator>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server"
                                        TargetControlID="tb_validade_ipo" PopupButtonID="ib_validade" DefaultView="Years" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" BackColor="#FEDAD8" Style="margin-left: 10px; margin-top: 10px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="694px" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:WizardStep>
        <asp:WizardStep ID="entidade" runat="server" Title="Entidade Requisitante">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <fieldset style="width: 676px; margin-left: 10px; margin-top: 25px; margin-right: 10px;">
                        <legend style="font-family: Ubuntu; font-weight: bold; color: #0d4465; font-size: 14px;">Informação Entidade Requisitante</legend>
                        <table style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 5px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="Label11" runat="server" Text="Nome ou designação"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_nome_entidade" runat="server" Enabled="false" ValidationGroup="viatura"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="Label13" runat="server" Text="Serviço/Obra"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_servico" runat="server" MaxLength="75" ValidationGroup="viatura" Width="491px"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tb_servico" EnableClientScript="true" ErrorMessage="É necessário inserir serviço/obra." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>--%>
                                </td>

                            </tr>
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="Label12" runat="server" Text="Tipo de circulação"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:RadioButtonList ID="rb_tipo_circulação" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Style="font-size: 12px; font-family: ubuntu; color: #0d4465;">
                                        <asp:ListItem Value="permanente">Circulação Permanente</asp:ListItem>
                                        <asp:ListItem Value="temporaria">Circulação Temporária</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="rb_tipo_circulação" EnableClientScript="true" ErrorMessage="É necessário escolher o tipo de cartão!" SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                    &nbsp; &nbsp;  &nbsp; &nbsp; 
                                    <asp:Panel ID="Panel_validade_acesso" runat="server" Visible="False">
                                        <asp:Label ID="Label_n_meses" runat="server" Text="Validade do Acesso"></asp:Label>
                                        &nbsp; &nbsp;
                            <asp:TextBox ID="tb_validade_acesso" runat="server" MaxLength="2" Width="45px"></asp:TextBox>
                                        <asp:Label ID="Label_meses" runat="server" Text="(Meses)" Visible="true"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="tb_validade_acesso" EnableClientScript="true" ErrorMessage="É necessário inserir o número de meses de duração." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="tb_validade_acesso" EnableClientScript="true" ErrorMessage="Deve introduzir números de meses." SetFocusOnError="True" Text="*" ValidationExpression="^[0-9]*$" Style="color: red;"></asp:RegularExpressionValidator>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">
                                    <asp:Label ID="lb_distico" runat="server" Text="Renovação Dístico Nº" Visible="false"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="tb_r_distico" runat="server" Visible="false" Enabled="false" MaxLength="45"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ForeColor="Red" BackColor="#FEDAD8" Style="margin-left: 10px; margin-top: 10px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="700px" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:WizardStep>
        <asp:WizardStep ID="declaracao_entidade" runat="server" Title="Declaração da Entidade">
            <fieldset style="width: 676px; margin-left: 10px; margin-top: 25px; margin-right: 18px;">
                <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px; color: #0d4465;">Declaração Entidade Requisitante</legend>
                <div style="margin-left: 10px; margin-top: 10px; width: 664px; line-height: 25px; color: #0d4465; text-align: justify; padding-right: 10px; padding-bottom: 10px;">
                    <asp:Label ID="Label15" runat="server" Style="font-family: Ubuntu; font-size: 13px;">
                 Para o devido efeito de autorização de acesso e circulação nas áreas restritas da Aerogare Civil das Lajes (ACL), declara¬-se que toda a informação, indicada está correta e é verdadeira. As áreas e locais de acesso indicados correspondem apenas às áreas por onde a viatura necessita de aceder e circular. 
<br />A autorização de acesso da viatura será exibida prontamente em todos os postos de verificação e de controlo de acessos de modo a permitir uma fácil visualização e identificação desta, e de forma contínua sempre que circular nas áreas restritas da ACL. A autorização a emitir não será emprestada ou utilizada por qualquer outra viatura, e será devidamente conservada e guardada, sendo a ACL informada de imediato por escrito, de qualquer tipo de extravio ou furto que lhe ocorra. 
<br />Reconhece-se que a autorização de acesso da viatura a ser emitida pela Aerogare Civil das Lajes será sempre propriedade desta, pelo que será devolvida sempre e logo que cesse a sua validade ou as condições que levaram à sua emissão, ou quando a Aerogare Civil das Lajes assim o determinar 
                    </asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cb_validate" runat="server" Style="font-family: Ubuntu; font-size: 13px; color: #0d4465;" Text="Tomei conhecimento e aceito as condições de utilização" />
                    &nbsp; 
                <asp:CustomValidator ID="CustomValidator1" runat="server" EnableClientScript="true"
                    ErrorMessage="É necessário aceitar os termos de utilização."
                    Text="*" OnServerValidate="CustomValidator1_ServerValidate" Style="color: red;"></asp:CustomValidator>
                </div>
            </fieldset>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" BackColor="#FEDAD8" Style="margin-left: 10px; margin-top: 10px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="708px" />
        </asp:WizardStep>
        <asp:WizardStep ID="documentos" runat="server" Title="Documentos a anexar">
            <div style="margin-left: 10px; margin-top: 10px;">
            </div>
            <fieldset style="width: 676px; margin-left: 10px; margin-right: 10px; margin-top: 15px; margin-bottom: 10px; color: #0d4465;">
                <legend style="font-family: Ubuntu; font-weight: bold; color: #0d4465; font-size: 14px;">Carregar Fotocópia do Livrete da viatura</legend>
                <div style="margin-bottom: 10px; margin-top: 10px; margin-left: 10px; margin-right: 10px;">
                    <ajaxToolkit:AsyncFileUpload ID="AFileUpload_livrete" runat="server" ThrobberID="Label17" OnClientUploadStarted="checkExtension" OnClientUploadError="uploadError" OnClientUploadComplete="uploadcomplete" OnUploadedComplete="AFileUpload_livrete_UploadedComplete" Width="100%" ErrorBackColor="#FC362A" CompleteBackColor="#2AFC60" />
                    <asp:Label ID="Label17" runat="server" Style="display: none">
                        <img src="../Layout/img/Loading.gif"  alt="Validando" class="loading_fileupload"/>
                    </asp:Label>
                </div>
            </fieldset>
            <fieldset style="width: 676px; margin-left: 10px; margin-right: 10px; margin-top: 15px; margin-bottom: 10px; color: #0d4465;">
                <legend style="font-family: Ubuntu; font-weight: bold; color: #0d4465; font-size: 14px;">Carregar Registo de Propriedade</legend>
                <div style="margin-bottom: 10px; margin-top: 10px; margin-left: 10px; margin-right: 10px;">
                    <ajaxToolkit:AsyncFileUpload ID="AFileUpload_r_propriedade" runat="server" ThrobberID="Throbber" OnClientUploadStarted="checkExtension" OnClientUploadError="uploadError" OnClientUploadComplete="uploadcomplete" OnUploadedComplete="AFileUpload_r_propriedade_UploadedComplete1" ErrorBackColor="#FC362A" Width="100%" CompleteBackColor="#2AFC60" />
                    <asp:Label ID="Throbber" runat="server" Style="display: none">
                        <img src="../Layout/img/Loading.gif"  alt="Validando" class="loading_fileupload"/>
                    </asp:Label>
                </div>
            </fieldset>
            <fieldset style="width: 676px; margin-left: 10px; margin-right: 10px; margin-top: 15px; margin-bottom: 10px; color: #0d4465;">
                <legend style="font-family: Ubuntu; font-weight: bold; color: #0d4465; font-size: 14px;">Carregar Fotocópia da carta verde</legend>
                <div style="margin-bottom: 10px; margin-top: 10px; margin-left: 10px; margin-right: 10px;">
                    <ajaxToolkit:AsyncFileUpload ID="AFileUpload_c_verde" runat="server" ThrobberID="Throbber1" OnClientUploadStarted="checkExtension" OnClientUploadError="uploadError" OnClientUploadComplete="uploadcomplete" OnUploadedComplete="AFileUpload_c_verde_UploadedComplete" ErrorBackColor="#FC362A" Width="100%" CompleteBackColor="#2AFC60" />
                    <asp:Label ID="Throbber1" runat="server" Style="display: none">
                        <img src="../Layout/img/Loading.gif"  alt="Validando"  class="loading_fileupload"/>
                    </asp:Label>
                </div>
            </fieldset>
            <fieldset style="width: 676px; margin-left: 10px; margin-right: 10px; margin-top: 15px; margin-bottom: 10px; color: #0d4465;">
                <legend style="font-family: Ubuntu; font-weight: bold; color: #0d4465; font-size: 14px;">Declaração da Seguradora de cobertura do veículo quando em circulação na ACL</legend>
                <div style="margin-bottom: 10px; margin-top: 10px; margin-left: 10px; margin-right: 10px;">
                    <ajaxToolkit:AsyncFileUpload ID="AFileUpload_cobertura_seguradora" runat="server" ThrobberID="Throbber2" OnClientUploadStarted="checkExtension" OnClientUploadError="uploadError" OnClientUploadComplete="uploadcomplete" OnUploadedComplete="AFileUpload_cobertura_seguradora_UploadedComplete" Width="100%" ErrorBackColor="#FC362A" CompleteBackColor="#2AFC60" />
                    <asp:Label ID="Throbber2" runat="server" Style="display: none">
                        <img src="../Layout/img/Loading.gif"  alt="Validando"  class="loading_fileupload"/>
                    </asp:Label>
                </div>
            </fieldset>
            <fieldset style="width: 676px; margin-left: 10px; margin-right: 10px; margin-top: 15px; margin-bottom: 10px; color: #0d4465;">
                <legend style="font-family: Ubuntu; font-weight: bold; color: #0d4465; font-size: 14px;">Relatório de Inspeção Técnica Periódica - (IPO)</legend>
                <div style="margin-bottom: 10px; margin-top: 10px; margin-left: 10px; margin-right: 10px;">
                    <ajaxToolkit:AsyncFileUpload ID="AFileUpload_ipo" runat="server" ThrobberID="Throbber3" OnClientUploadStarted="checkExtension" OnClientUploadError="uploadError" OnClientUploadComplete="uploadcomplete" OnUploadedComplete="AFileUpload_ipo_UploadedComplete" Width="100%" ErrorBackColor="#FC362A" CompleteBackColor="#2AFC60" />
                    <asp:Label ID="Throbber3" runat="server" Style="display: none">
                    <img src="../Layout/img/Loading.gif"  alt="Validando" class="loading_fileupload"/>
                    </asp:Label>
                </div>
            </fieldset>
            <asp:Panel ID="Panel_renovaca_circulacao" runat="server" Visible="false">
                <fieldset style="width: 676px; margin-left: 10px; color: #0d4465; margin-right: 10px; margin-top: 15px; color: #0d4465; margin-bottom: 10px;">
                    <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px; color: #0d4465;">Cartão de Circulação da Viatura</legend>
                    <div style="margin-bottom: 10px; margin-top: 10px; margin-left: 10px; margin-right: 10px;">
                        <ajaxToolkit:AsyncFileUpload ID="AFileUpload_cartao_circulacao" ThrobberID="Throbber4" runat="server" OnClientUploadStarted="checkExtension" OnClientUploadError="uploadError" OnClientUploadComplete="uploadcomplete" OnUploadedComplete="AFileUpload_cartao_circulacao_UploadedComplete" Width="100%" ErrorBackColor="#FC362A" CompleteBackColor="#2AFC60" />
                        <asp:Label ID="Throbber4" runat="server" Style="display: none">
                            <img src="../Layout/img/Loading.gif"  alt="Validando"  class="loading_fileupload"/>
                        </asp:Label>
                    </div>
                </fieldset>
            </asp:Panel>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ForeColor="Red" BackColor="#FEDAD8" ValidationGroup="MyValidationGroup" Style="margin-left: 10px; margin-top: 10px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="700px" />
                    <div id="ContentPlaceHolder1_conducao_form_Conducao_StatusLabel" style="background-color: #FEDAD8; color: red; font-size: 12px; margin-left: 10px; margin-top: 10px; text-align: justify; float: left; width: 96.5%; border: 2px solid red; display: none; margin-bottom: 10px;">
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:WizardStep>
    </WizardSteps>
    <FinishNavigationTemplate>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:ImageButton ID="FinishPreviousButton" ToolTip="Anterior" Style="margin-bottom: 5px; margin-top: 5px;" runat="server" CausesValidation="False" CommandName="MovePrevious" ImageUrl="~/Layout/img/anterior.png" />
                <asp:ImageButton ID="FinishButton" runat="server" ToolTip="Submeter Pedido" Style="margin-bottom: 5px; margin-top: 5px; margin-right: 5px;" AlternateText="Finish" CommandName="MoveComplete" ImageUrl="~/Layout/img/save.png" />
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


<%-------------------------------------------------------JAVASCRIPT-----------------------------------------------------------%>
<script src="../JS/Script.js"></script>
<%--------------------------------------------------STYLE-----------------------------------------------------------------%>
<style>
    .auto-style2 {
        width: 149px;
    }

    .auto-style3 {
        width: 67px;
    }

    .auto-style4 {
        width: 191px;
    }

    .auto-style5 {
        width: 161px;
    }
</style>
