<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication10.Login.Register" %>
<%@ Register Src="~/controls/footer.ascx" TagPrefix="uc11" TagName="footer" %>
<%@ Register Src="~/controls/bar_GRA.ascx" TagPrefix="uc10" TagName="bar_GRA" %>
<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>SGRA-Sistema de Gestão e Requisição de Acessos</title>
       <meta charset="UTF-8">
            <link rel="shortcut icon" type="image/ico" href="../Layout/img/favicon.ico">
     <%--<link href='http://fonts.googleapis.com/css?family=Ubuntu' rel='stylesheet' type='text/css'>--%>
      <link href="../Layout/Style.css" rel="stylesheet" type="text/css" />
    <link href="../Layout/Menu.css" rel="stylesheet" type="text/css" />
      <link href="../Layout/StyleBarra.css" rel="stylesheet" type="text/css" />
       <script src="../JS/Script.js"></script>
</head>
  
<!--[if IE  lte 9 ]>
<body class="ie">
<![endif]-->
<!--[if !IE 9]>-->
<body onresize="Resize_reg()">
    <!--<![endif]-->
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     
            <div id="pnlContent">
                <uc10:bar_GRA runat="server" ID="bar_GRA" Visible="true" />
            </div>
           <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                <ContentTemplate>
         <div class="outer_reg">
            <div class="middle">
                <div class="inner_reg">
   <div class="divRegister">
         
                    <div class="boxRegister">
                        <asp:CreateUserWizard runat="server" DisableCreatedUser="True" Width="99.5%" Height="99.5%" ID="CreateUserWizard1" OnCreatedUser="CreateUserWizard1_CreatedUser" ContinueDestinationPageUrl="~/Default.aspx" OnNextButtonClick="CreateUserWizard1_NextButtonClick" OnCreateUserError="CreateUserWizard1_CreateUserError" CompleteSuccessText="A sua conta foi criada com sucesso, irá receber um e-mail com os dados de acesso." ContinueButtonText="Continuar" CreateUserButtonImageUrl="~/Layout/img/save_gray.png" CreateUserButtonType="Image" DuplicateEmailErrorMessage="O email que inseriu já existe, por favor reveja o campo email." DuplicateUserNameErrorMessage="Insira um nome de utilizador diferente." FinishPreviousButtonImageUrl="~/Layout/img/back.png" FinishPreviousButtonType="Image" StartNextButtonImageUrl="~/Layout/img/foward.png" StartNextButtonType="Image" StepNextButtonImageUrl="~/Layout/img/foward.png" StepNextButtonType="Image" StepPreviousButtonImageUrl="~/Layout/img/back.png" StepPreviousButtonType="Image" UnknownErrorMessage="Não foi possivel criar a sua conta, por favor tente novamente." BorderStyle="None" InvalidEmailErrorMessage="Introduza um email válido">
                            <WizardSteps>
                                <asp:WizardStep ID="CreateUserWizardStep0" runat="server">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Layout/img/user.png" Height="32px" Style="margin-left: 4%; margin-top: 1%;" AlternateText="user" />
                                    <asp:Label ID="Label1" runat="server" Text="Informação do Utilizador" CssClass="label_header_reg"></asp:Label>
                                    <br />
                                    <fieldset class="fieldset_reg">
                                        <legend class="fieldset_legend">Informação Pessoal</legend>
                                        <table class="tableRegister">

                                            <tr>
                                                <td>Nome Utilizador</td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="nome" MaxLength="40" Width="275px" ValidationGroup="CreateUserWizard1" />

                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" ControlToValidate="nome"
                                                        ErrorMessage="É necessário o preenchimento do Nome de utilizador."
                                                        EnableClientScript="true"
                                                        SetFocusOnError="true" Style="color: red;"
                                                        Text="*" />
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator4"
                                                        ControlToValidate="nome" ValidationExpression="^[a-zA-ZáàÁÀéÉíÍìÌóòÒÓÃãõÕèÈúÚùÙêÊçÇ ]*$"
                                                        ErrorMessage="Apenas pode introduzir letras no nome de utilizador."
                                                        EnableClientScript="true"
                                                        SetFocusOnError="true" Style="color: red;"
                                                        Text="*" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Apelido Utilizador</td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="apelido" MaxLength="17" Width="175px" ValidationGroup="CreateUserWizard1" />

                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="apelido"
                                                        ErrorMessage="É necessário o preenchimento do Apelido de utilizador."
                                                        EnableClientScript="true"
                                                        SetFocusOnError="true" Style="color: red;"
                                                        Text="*" />
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1"
                                                        ControlToValidate="apelido" ValidationExpression="^[a-zA-ZáàÁÀéÉíÍìÌóòÒÓÃãõÕèÈúÚùÙêÊçÇ ]*$"
                                                        ErrorMessage="Apenas pode introduzir letras no apelido do utilizador."
                                                        EnableClientScript="true"
                                                        SetFocusOnError="true" Style="color: red;"
                                                        Text="*" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Data Nascimento</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_ano" runat="server"></asp:DropDownList>
                                                    <asp:DropDownList ID="ddl_mes" runat="server"></asp:DropDownList>
                                                    <asp:DropDownList ID="ddl_dia" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server"
                                                        ErrorMessage="Necessário introduzir o dia de nascimento." ControlToValidate="ddl_dia" InitialValue="Dia"
                                                        EnableClientScript="true"
                                                        SetFocusOnError="true" Style="color: red;"
                                                        Text="*"></asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Necessário introduzir o Ano de nascimento." ControlToValidate="ddl_ano" InitialValue="Ano"
                                                        EnableClientScript="true"
                                                        SetFocusOnError="true" Style="color: red;"
                                                        Text="*"></asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Necessário introduzir o mês de nascimento." ControlToValidate="ddl_mes" InitialValue="Mês" EnableClientScript="true"
                                                        SetFocusOnError="true" Style="color: red;"
                                                        Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                        </table>
                                    </fieldset>
                                    <fieldset class="fieldset_reg">
                                        <legend class="fieldset_legend">Informação Contratual</legend>
                                        <table class="tableRegister">
                                            <tr>
                                                <td>Entidade</td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_entidade" runat="server" CssClass="dropDown" Width="234px" ValidationGroup="CreateUserWizard1"></asp:DropDownList>

                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="ddl_entidade"
                                                        ErrorMessage="É necessário o preenchimento do Nome/Denominação da Entidade." InitialValue="Selecione"
                                                        EnableClientScript="true"
                                                        SetFocusOnError="true" Style="color: red;"
                                                        Text="*" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Cargo/Função</td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="cargo" MaxLength="40" Width="230px" ValidationGroup="CreateUserWizard1" />

                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="cargo"
                                                        ErrorMessage="Necessário introduzir o cargo e/ou função."
                                                        EnableClientScript="true"
                                                        SetFocusOnError="true" Style="color: red;"
                                                        Text="*" />
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator5"
                                                        ControlToValidate="cargo" ValidationExpression="^[a-zA-ZáàÁÀéÉíÍìÌóòÒÓÃãõÕèÈúÚùÙêÊçÇ ]*$"
                                                        ErrorMessage="Apenas pode introduzir letras no campo função."
                                                        EnableClientScript="true"
                                                        SetFocusOnError="true" Style="color: red;"
                                                        Text="*" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Nº Cartão ACL</td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="num_acl" MaxLength="3" ValidationGroup="CreateUserWizard1" />

                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="num_acl"
                                                        ErrorMessage="É necessário o preenchimento do campo do número de cartão da ACL"
                                                        EnableClientScript="true"
                                                        SetFocusOnError="true" Style="color: red;"
                                                        Text="*" />
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator6"
                                                        ControlToValidate="num_acl" ValidationExpression="^[0-9]*$"
                                                        ErrorMessage="Apenas pode introduzir números no cartão da ACL."
                                                        EnableClientScript="true"
                                                        SetFocusOnError="true" Style="color: red;"
                                                        Text="*" />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <fieldset class="fieldset_reg">
                                        <legend class="fieldset_legend">Contatos</legend>
                                        <table class="tableRegister">
                                            <tr>
                                                <td>Telefone</td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="telefone" MaxLength="12" ValidationGroup="CreateUserWizard1" />

                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="telefone"
                                                        ErrorMessage="É necessário o preenchimento do campo telefone"
                                                        EnableClientScript="true"
                                                        SetFocusOnError="true" Style="color: red;"
                                                        Text="*" />
                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2"
                                                        ControlToValidate="telefone" ValidationExpression="^[0-9]*$"
                                                        ErrorMessage="Apenas pode introduzir números no campo telefone."
                                                        EnableClientScript="true"
                                                        SetFocusOnError="true" Style="color: red;"
                                                        Text="*" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Fax</td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="Fax" MaxLength="12" />

                                                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3"
                                                        ControlToValidate="Fax" ValidationExpression="^[0-9]*$"
                                                        ErrorMessage="Apenas pode introduzir números no campo fax."
                                                        EnableClientScript="true"
                                                        SetFocusOnError="true" Style="color: red;"
                                                        Text="*" />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </asp:WizardStep>
                                <asp:CreateUserWizardStep ID="CreateUserWizardStep2" runat="server">
                                    <ContentTemplate>
                                        <br />

                                        <fieldset class="fieldset_reg_log">
                                            <legend class="fieldset_legend">Informação de autenticação</legend>
                                            <table class="tableRegister">

                                                <tr>
                                                    <td>Utilizador</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="UserName" MaxLength="256" Width="200px"  Enabled="false"/>
                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="UserName"
                                                            ErrorMessage="É necessário a inserção do Username." ValidationGroup="CreateUserWizard1"
                                                            EnableClientScript="true"
                                                            SetFocusOnError="true" Style="color: red;"
                                                            Text="*" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Palavra-Chave</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="Password" TextMode="Password" MaxLength="128" Width="200px" />
                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ControlToValidate="Password"
                                                            ErrorMessage="É necessário a inserção da Password." ValidationGroup="CreateUserWizard1"
                                                            EnableClientScript="true"
                                                            SetFocusOnError="true" Style="color: red;"
                                                            Text="*" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Confirmar Palavra-Chave</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password"  MaxLength="128" Width="200px" />
                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator13" ControlToValidate="ConfirmPassword"
                                                            ErrorMessage="É necessário a confirmação da Password." ValidationGroup="CreateUserWizard1"
                                                            EnableClientScript="true"
                                                            SetFocusOnError="true" Style="color: red;"
                                                            Text="*" />
                                                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic" EnableClientScript="true" ErrorMessage="A password e a password de confirmação não são iguais, deve inserir a mesma password nos dois campos." SetFocusOnError="true" Style="color: red;" Text="*" ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Email</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="Email" MaxLength="128" CssClass="inputRegister" Width="280px" />
                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="Email"
                                                            ErrorMessage="É necessário a inserção do Email" ValidationGroup="CreateUserWizard1"
                                                            EnableClientScript="true"
                                                            SetFocusOnError="true" Style="color: red;"
                                                            Text="*" />
                                                        <asp:RegularExpressionValidator runat="server" ID="rexemail" ValidationGroup="CreateUserWizard1" ControlToValidate="Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Introduza um e-mail válido."
                                                            EnableClientScript="true"
                                                            SetFocusOnError="true" Style="color: red;"
                                                            Text="*" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Pergunta Secreta</td>
                                                    <td>
                                                        <asp:DropDownList ID="Question" runat="server" CssClass="inputRegister">
                                                            <asp:ListItem Text="Seleccione" />
                                                            <asp:ListItem Text="Qual é o nome do seu amigo de infância?" />
                                                            <asp:ListItem Text="Qual o mês e ano de nascimento do seu irmão mais velho/novo?" />
                                                            <asp:ListItem Text="Qual é o nome do meio do seu filho mais velho/novo?" />
                                                            <asp:ListItem Text="Qual é o nome do meio do seu irmão mais velho/novo?" />
                                                            <asp:ListItem Text="Qual a escola que frequentou o ensino primário?" />
                                                            <asp:ListItem Text="Qual a escola que frequentou o ensino secundário?" />
                                                            <asp:ListItem Text="Qual o primeiro e último nome do seu primo mais velho?" />
                                                            <asp:ListItem Text="Qual era o nome do seu primeiro animal de estimação?" />
                                                            <asp:ListItem Text="Qual o nome da universidade que frequentou?" />
                                                            <asp:ListItem Text="Qual foi o seu primeiro trabalho?" />
                                                            <asp:ListItem Text="Qual a cidade onde gostava de morar?" />
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ValidationGroup="CreateUserWizard1" ErrorMessage="Necessário introduzir o dia de nascimento." ControlToValidate="Question" InitialValue="Seleccione"
                                                            EnableClientScript="true"
                                                            SetFocusOnError="true" Style="color: red;"
                                                            Text="*"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Resposta Secreta</td>
                                                    <td>
                                                        <asp:TextBox ID="Answer" runat="server" MaxLength="255" CssClass="inputRegister" Width="300px" />
                                                        <asp:RequiredFieldValidator ID="PasswordAnswerRequiredValidator" runat="server"
                                                            ControlToValidate="Answer" ForeColor="red"
                                                            Display="Static" ErrorMessage="É necessário inserir uma resposta secreta." ValidationGroup="CreateUserWizard1"
                                                            EnableClientScript="true"
                                                            SetFocusOnError="true" Style="color: red;"
                                                            Text="*" /></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label_erro" runat="server" Text="" Style="color: red;"></asp:Label>
                                                    </td>
                                                </tr>
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Existem os seguintes erros de preenchimento" ValidationGroup="CreateUserWizard1" ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="false" />
                                            </table>
                                            <asp:SqlDataSource ID="InsertExtraInfo" runat="server" ConnectionString="<%$ConnectionStrings:LocalMySqlServer %>"
                                                InsertCommand="inserir_user"
                                                InsertCommandType="StoredProcedure"
                                                ProviderName="<%$ ConnectionStrings:LocalMySqlServer.providerName%>">
                                                <InsertParameters>
                                                    <asp:ControlParameter Name="nome" Type="String" ControlID="nome" PropertyName="Text" />
                                                    <asp:ControlParameter Name="telefone" Type="String" ControlID="telefone" PropertyName="Text" />
                                                    <asp:ControlParameter Name="fax" Type="String" ControlID="fax" PropertyName="Text" />
                                                    <asp:ControlParameter Name="cargo" Type="String" ControlID="cargo" PropertyName="Text" />
                                                    <asp:ControlParameter Name="num_acl" Type="String" ControlID="num_acl" PropertyName="Text" />
                                                </InsertParameters>
                                            </asp:SqlDataSource>
                                    </ContentTemplate>
                                </asp:CreateUserWizardStep>
                                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                                    <ContentTemplate>
                                        <br />
                                        <table>
                                            <tr>
                                                <td style="text-align:center;">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Layout/img/success.png" Width="64px" ImageAlign="Middle" /><br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Style="font-family: ubuntu; font-size: 15px; color: #D6ECFF; padding-left: 16px; padding-right: 16px; display: block; text-align: center;"> A sua conta foi criada com sucesso, irá receber um e-mail com os dados de acesso. O processo de analise da informação poderá demorar alguns dias até ter acesso permitido.</asp:Label>
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                           
                                                 <td style="text-align:center;">
                                                    <asp:ImageButton ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"  ValidationGroup="CreateUserWizard1" ImageUrl="~/Layout/img/continuar.png" ToolTip="Continuar" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:CompleteWizardStep>
                            </WizardSteps>
                            <FinishNavigationTemplate>
                                <asp:ImageButton ID="FinishPreviousButton" runat="server" AlternateText="Previous" CausesValidation="False" CommandName="MovePrevious" ImageUrl="~/Layout/img/back.png" ToolTip="Anterior" />
                                <asp:Button ID="FinishButton" runat="server" CommandName="MoveComplete" ToolTip="Submeter"  />
                            </FinishNavigationTemplate>
                            <StartNavigationTemplate>
                                <asp:ImageButton ID="StartNextButton" runat="server" AlternateText="Next" CommandName="MoveNext" ImageUrl="~/Layout/img/foward.png" tooltip="Seguinte"/>
                            </StartNavigationTemplate>
                        </asp:CreateUserWizard>
                    </div>
              
           
        </div>
                    </div>
                </div>
         </div>
        <div id="rodape">
                     <footer>
            <uc11:footer runat="server" ID="footer" Visible="true" />
        </footer>
            </div>
                      </ContentTemplate>
         </asp:UpdatePanel>
            <asp:UpdateProgress ID="prgLoadingStatus" runat="server" DynamicLayout="true">
                <ProgressTemplate>
                    <div id="overlay">
                        <div id="modalprogress">
                            <div id="theprogress_2">
                                <asp:Image ID="imgWaitIcon" runat="server"  ImageUrl="../Layout/img/sending.gif" AlternateText="Sending" CssClass="sending" />
                            </div>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
    </form>
</body>
</html>
