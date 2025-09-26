<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="conducao_form.ascx.cs" Inherits="WebApplication10.controls.conducao_form" %>
<%@ Register TagPrefix="mp" TagName="MyMP" Src="~/acessos.master" %>
<div>
    <asp:Label ID="Label_status" runat="server" Text="" Visible="false"></asp:Label>
</div>
<div>
    <asp:Wizard ID="Conducao" runat="server" ActiveStepIndex="0" OnFinishButtonClick="Conducao_FinishButtonClick" BackColor="#F8F8F8" FinishCompleteButtonImageUrl="~/Layout/img/save.png" FinishCompleteButtonType="Image" FinishPreviousButtonImageUrl="~/Layout/img/anterior.png" FinishPreviousButtonText="" FinishPreviousButtonType="Image" StartNextButtonImageUrl="~/Layout/img/next.png" StartNextButtonType="Image" StepNextButtonImageUrl="~/Layout/img/next.png" StepNextButtonType="Image" StepPreviousButtonImageUrl="~/Layout/img/anterior.png" StepPreviousButtonType="Image" OnNextButtonClick="Conducao_NextButtonClick">
        <StartNavigationTemplate>
            <asp:ImageButton ID="StartNextButton" ToolTip="Seguinte" Style="margin-bottom: 5px; margin-top: 5px; margin-right: 5px;" runat="server" AlternateText="Next" CommandName="MoveNext" ImageUrl="~/Layout/img/next.png" />
        </StartNavigationTemplate>
        <StepNavigationTemplate>
            <asp:ImageButton ID="StepPreviousButton" runat="server" ToolTip="Anterior" Style="margin-bottom: 5px; margin-top: 5px;" AlternateText="Previous" CausesValidation="False" CommandName="MovePrevious" ImageUrl="~/Layout/img/anterior.png" />
            <asp:ImageButton ID="StepNextButton" runat="server" ToolTip="Seguinte" Style="margin-bottom: 5px; margin-top: 5px; margin-right: 5px;" AlternateText="Next" CommandName="MoveNext" ImageUrl="~/Layout/img/next.png" />
        </StepNavigationTemplate>
        <WizardSteps>
            <asp:WizardStep ID="dados_pessoais" runat="server" Title="Dados Pessoais">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div style="margin-left: 79.5%; margin-bottom: 10px; margin-top: 2px;">
                            <asp:Label ID="Label14" runat="server" Text="Nº Processo" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px"></asp:Label>
                            <asp:TextBox ID="tb_num" runat="server" Enabled="False" Width="54px" Style="margin-left: 10px;"></asp:TextBox>
                        </div>
                        <fieldset style="width: 690px; margin-left: 10px; color: #0d4465; margin-right: 10px; margin-top: 10px;">
                            <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px; color: #0d4465;">Informação Pessoal/Contratual</legend>
                            <table style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 5px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                                <tr>
                                    <td class="auto-style6">
                                        <asp:Label ID="Label2" runat="server" Text="Nome completo"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="tb_nome" runat="server" MaxLength="90" ValidationGroup="Conducao" Width="524px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tb_nome" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do Nome completo." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="rexenome" runat="server" ControlToValidate="tb_nome" EnableClientScript="true" ErrorMessage="Apenas pode introduzir letras no campo nome." SetFocusOnError="True" Text="*" ValidationExpression="^[a-zA-ZáàÁÀéÉíÍìÌóòÒÓÃãõÕèÈúÚùÙêÊçÇ ]*$" Style="color: red;"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6">
                                        <asp:Label ID="Label3" runat="server" Text="Entidade Patronal"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="tb_patronal" runat="server" MaxLength="34" ValidationGroup="Conducao" Width="200px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="tb_patronal" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do Nome completo." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tb_patronal" EnableClientScript="true" ErrorMessage="Apenas pode introduzir letras no campo da entidade patronal." SetFocusOnError="True" Text="*" ValidationExpression="^[a-zA-ZáàÁÀéÉíÍìÌóòÒÓÃãõÕèÈúÚùÙêÊçÇ ]*$" Style="color: red;"></asp:RegularExpressionValidator>
                                        <asp:Label ID="Label4" runat="server" Text="Função" Style="margin-left: 46px;"></asp:Label>
                                        <asp:TextBox ID="tb_funcao" runat="server" MaxLength="45" ValidationGroup="Conducao" Width="200px" Style="margin-left: 10px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_funcao" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do campo função." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="tb_funcao" EnableClientScript="true" ErrorMessage="Apenas pode introduzir letras no campo função." SetFocusOnError="True" Text="*" ValidationExpression="^[a-zA-ZáàÁÀéÉíÍìÌóòÒÓÃãõÕèÈúÚùÙêÊçÇ ]*$" Style="color: red;"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6">
                                        <asp:Label ID="Label5" runat="server" Text="Nº Cartão Acesso"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="tb_num_acesso" runat="server" MaxLength="8" ValidationGroup="Conducao" Style="margin-left: 0px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_num_acesso" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do número de cartão de acesso." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="tb_num_acesso" EnableClientScript="true" ErrorMessage="Apenas pode introduzir números no campo do cartão da ACL." SetFocusOnError="True" Text="*" ValidationExpression="^[0-9]*$" Style="color: red;"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <fieldset style="width: 690px; margin-left: 10px; margin-top: 10px; color: #0d4465;">
                            <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px; color: #0d4465;">Carta Condução</legend>
                            <table style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 5px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                                <tr>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label6" runat="server" Text="Nº Carta Condução"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="tb_carta_conducao" runat="server" MaxLength="18" ValidationGroup="Conducao" Width="200px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_carta_conducao" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do número da carta de condução." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                        <asp:Label ID="Label7" runat="server" Text="Categoria(s)" Style="margin-left: 63px;"></asp:Label>
                                        <asp:TextBox ID="tb_categoria" runat="server" MaxLength="13" Style="text-transform: uppercase; margin-left: 10px;" ValidationGroup="Conducao"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tb_categoria" EnableClientScript="true" ErrorMessage="É necessário o preenchimento da categoria da carta de condução." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label8" runat="server" Text="Data de emissão"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="tb_d_emissao" runat="server" TextMode="DateTime" MaxLength="45" ValidationGroup="calendar" Style="margin-left: -1px;"></asp:TextBox>
                                        <asp:ImageButton runat="Server" ID="ib_calendar_d_emissao" ImageUrl="~/Layout/img/calendar.png" Width="25px" ValidationGroup="calendar" />
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" OnClientDateSelectionChanged="OnClientDateSelectionChanged"
                                            TargetControlID="tb_d_emissao" PopupButtonID="ib_calendar_d_emissao" DefaultView="Years" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tb_d_emissao" EnableClientScript="true" ErrorMessage="É necessário o preenchimento da data de emissão da carta de condução." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="REcreationdate" runat="server" ControlToValidate="tb_d_emissao" Display="Dynamic" ErrorMessage="A data deve estar no formato: dd/mm/yyyy" SetFocusOnError="True" Text="*" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /](0[1-9]|1[012])[- /](19|20)[0-9]{2}" Style="color: red;"></asp:RegularExpressionValidator>
                                        <asp:Label ID="Label10" runat="server" Text="Validade" Style="margin-left: 106px;"></asp:Label>
                                        <asp:TextBox ID="tb_validade" runat="server" MaxLength="45" ValidationGroup="calendar" Style="margin-left: 10px;"></asp:TextBox>
                                        <asp:ImageButton ID="ib_validade" runat="server" ImageUrl="~/Layout/img/calendar.png" ValidationGroup="calendar" Width="25px" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tb_validade" EnableClientScript="true" ErrorMessage="É necessário o preenchimento da validade da carta de condução." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tb_validade" Display="Dynamic" ErrorMessage="A data deve estar no formato: dd/mm/yyyy" SetFocusOnError="True" Text="*" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /](0[1-9]|1[012])[- /](19|20)[0-9]{2}" Style="color: red;"></asp:RegularExpressionValidator>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server"
                                            TargetControlID="tb_validade" PopupButtonID="ib_validade" DefaultView="Years" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label9" runat="server" Text="Local de emissão"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="tb_l_emissao" runat="server" MaxLength="19" ValidationGroup="Conducao" Width="200px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tb_l_emissao" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do local de emissão da carta de condução." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="tb_l_emissao" EnableClientScript="true" ErrorMessage="Apenas pode introduzir letras no campo local de emissão." SetFocusOnError="True" Text="*" ValidationExpression="^[a-zA-ZáàÁÀéÉíÍìÌóòÒÓÃãõÕèÈúÚùÙêÊçÇ ]*$" Style="color: red;"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" BackColor="#FEDAD8" Style="margin-left: 10px; padding-bottom: 5px; margin-top: 10px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="715px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:WizardStep>
            <asp:WizardStep ID="entidade" runat="server" Title="Entidade Requisitante">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <fieldset style="width: 690px; margin-left: 10px; margin-top: 25px; color: #0d4465; margin-right: 10px;">
                            <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px; color: #0d4465;">Informação Entidade Requisitante</legend>
                            <table style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 5px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server" Text="Nome ou designação"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tb_nome_entidade" runat="server" Enabled="false" Width="320px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" Text="Áreas de circulação"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="plataforma" Text="Plataforma de estacionamento de aeronaves" runat="server" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;" /><br />
                                        <asp:CheckBox ID="terminal" Text="Terminal de cargas e bagagens" runat="server" Style="color: #0d4465; font-family: Ubuntu; font-size: 12px;" />
                                        <asp:CustomValidator ID="SelectValidator" runat="server" EnableClientScript="true"
                                            ErrorMessage="É necessário selecionar pelo menos um área de circulação."
                                            Text="*" OnServerValidate="SelectValidator_ServerValidate" Style="color: red;"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" Text="Categorias de viaturas a serem conduzidas"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tb_categoria_viatura" runat="server" Style='text-transform: uppercase' MaxLength="45"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tb_categoria_viatura" EnableClientScript="true" ErrorMessage="É necessário inserir a categoria de viaturas a serem conduzidas." SetFocusOnError="True" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ForeColor="Red" BackColor="#FEDAD8" Style="margin-left: 10px; margin-top: 10px; padding-bottom: 5px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="715px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:WizardStep>
            <asp:WizardStep ID="declaracao_entidade" runat="server" Title="Declaração da Entidade">
                <fieldset style="width: 690px; margin-top: 25px; margin-left: 10px; color: #0d4465; margin-right: 10px;">
                    <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px; color: #0d4465;">Declaração Entidade Requisitante</legend>
                    <div style="margin-left: 10px; margin-top: 10px; width: 664px; line-height: 25px; text-align: justify; padding-right: 10px; padding-bottom: 10px;">
                        <asp:Label ID="Label15" runat="server" Style="font-family: Ubuntu; font-size: 13px; color: #0d4465;">
                  Para o devido efeito de autorização de circulação nas áreas restritas da Aerogare Civil das Lajes 
                 (ACL), declara-se que toda a informação indicada está correcta e é verdadeira. 
                 <br/>
                  Reconhece-se que a autorização de condução a ser emitido pela Aerogare Civil das Lajes será 
                  sempre propriedade desta, pelo que será devolvido sempre e logo que cesse a Sua validade ou as 
                  condições que levaram à sua emissão, ou quando o Aeroporto assim o determinar. 
                        </asp:Label>
                        <br />
                        <br>

                        <asp:CheckBox ID="cb_validate" runat="server" Style="font-family: Ubuntu; font-size: 13px; color: #0d4465;" Text="Tomei conhecimento e aceito as condições de utilização" />

                        <asp:CustomValidator ID="CustomValidator1" runat="server"
                            ErrorMessage="É necessário aceitar os termos de utilização." EnableClientScript="true"
                            Text="*" OnServerValidate="CustomValidator1_ServerValidate" Style="color: red;"></asp:CustomValidator>
                    </div>
                </fieldset>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" BackColor="#FEDAD8" Style="margin-left: 10px; margin-top: 10px; font-size: 12px; padding-bottom: 5px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="715px" />
            </asp:WizardStep>
            <asp:WizardStep ID="documentos" runat="server" Title="Documentos a anexar">
                <asp:UpdatePanel ID="UpdatePanel_conducao" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div style="margin-left: 10px; margin-top: 25px;">
                            <%--<asp:Label ID="Label1" runat="server" Style="font-family: Ubuntu; font-size: 14px; color: #0d4465;">Os documentos a carregar deverão ter tamanho o temanho máximo de 1Mb.<br /> Só serão permitidos apenas ficheiros num dos seguintes formatos: .PDF .PNG .JPG .TIFF</asp:Label>--%>
                        </div>
                        <fieldset style="width: 690px; margin-left: 10px; margin-right: 10px; margin-top: 15px; color: #0d4465; margin-bottom: 10px;">
                            <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px;  color: #0d4465;">Carregar Cartão de Acesso ACL</legend>


                            <div style="margin-bottom: 10px; margin-top: 10px; margin-left: 10px; margin-right: 10px;">
                                <ajaxToolkit:AsyncFileUpload ID="AFileUpload_cartao_acesso" runat="server" ThrobberID="Throbber4" OnClientUploadStarted="checkExtension" OnClientUploadError="uploadError" OnUploadedComplete="AFileUpload_cartao_acesso_UploadedComplete" OnClientUploadComplete="uploadcomplete" Width="100%" ErrorBackColor="#FC362A" CompleteBackColor="#2AFC60" />
                                <asp:Label ID="Throbber4" runat="server" Style="display: none">
                            <img src="../Layout/img/Loading.gif"  alt="Validando" class="loading_fileupload"/>
                                </asp:Label>
                            </div>
                        </fieldset>
                        <fieldset style="width: 690px; margin-left: 10px; margin-right: 10px; margin-top: 10px; color: #0d4465; margin-bottom: 10px;">
                            <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px;  color: #0d4465;">Carregar Carta de condução</legend>
                            <div style="margin-bottom: 10px; margin-top: 10px; margin-left: 10px; margin-right: 10px;">
                                <ajaxToolkit:AsyncFileUpload ID="AFileUpload_carta_conducao" runat="server" ThrobberID="Throbber5" OnClientUploadStarted="checkExtension" OnClientUploadError="uploadError" OnUploadedComplete="AFileUpload_carta_conducao_UploadedComplete" OnClientUploadComplete="uploadcomplete" ErrorBackColor="#FC362A" Width="100%" CompleteBackColor="#2AFC60" />
                                <asp:Label ID="Throbber5" runat="server" Style="display: none">
                            <img src="../Layout/img/Loading.gif"  alt="Validando" class="loading_fileupload" />
                                </asp:Label>
                            </div>
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:ValidationSummary ID="ValidationSummary4" runat="server" ForeColor="Red" BackColor="#FEDAD8" ValidationGroup="MyValidationGroup" Style="margin-left: 10px; margin-top: 10px; padding-bottom: 5px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="715px" />
                        <div id="ContentPlaceHolder1_conducao_form_Conducao_StatusLabel" style="background-color: #FEDAD8; color: red; font-size: 12px; margin-left: 10px; margin-top: 10px; text-align: justify; float: left; width: 96.5%; border: 2px solid red; display: none; margin-bottom: 10px;">
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:WizardStep>
        </WizardSteps>
        <FinishNavigationTemplate>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:ImageButton ID="FinishPreviousButton" runat="server" CommandName="MovePrevious" ImageUrl="~/Layout/img/anterior.png" ToolTip="Anterior" Style="margin-bottom: 5px; margin-top: 5px;" />
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

</div>
<%------------------------------------------------------JAVASCRIPT---------------------------------------------------------------%>

<script type="text/javascript">
    function OnClientDateSelectionChanged(sender, args) {
        $find("<%=CalendarExtender2.ClientID %>").set_startDate(sender._selectedDate);
    }
</script>
<script src="../JS/Script.js"></script>



<%------------------------------------------------------STYLES---------------------------------------------------------------%>


<style>
    .auto-style2 {
        width: 547px;
    }

    .auto-style5 {
        width: 126px;
    }

    .auto-style6 {
        width: 128px;
    }
</style>






