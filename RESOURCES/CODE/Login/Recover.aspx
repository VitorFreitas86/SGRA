<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recover.aspx.cs" Inherits="SGRA.Login.Recover" %>

<%@ Register Src="~/controls/footer.ascx" TagPrefix="uc11" TagName="footer" %>
<%@ Register Src="~/controls/bar_GRA.ascx" TagPrefix="uc10" TagName="bar_GRA" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta charset="UTF-8">
    <link href="../Layout/Style.css" rel="stylesheet" type="text/css" />
    <link href="../Layout/StyleBarra.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" type="image/ico" href="../Layout/img/favicon.ico">
       <script src="../JS/Script.js"></script>
    <title>SGRA-Sistema de Gestão e Requisição de Acessos</title>
    <style type="text/css">
        .auto-style1 {
            width: 82px;
        }
    </style>
</head>
<!--[if IE lte 9 ]>
        <body class="ie">
        <![endif]-->
<!--[if !IE 9]>-->
<body onresize="Resize()">
    <!--<![endif]-->
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="pnlContent" style="min-width: 800px;">
                    <uc10:bar_GRA runat="server" ID="bar_GRA" Visible="true" />
                </div>
                <div class="outer">
                    <div class="middle">
                        <div class="inner_rec">


                            <div class="divRecoverExterior">
                                <div class="loginBoxBehind2">
                                    <div class="titleRecover">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Layout/img/chave.png" AlternateText="Recuperação Palavra-Chave" />
                                        &nbsp;  Esqueceu-se da sua Palavra-chave?
                                    </div>

                                    <div>
                                        <div>
                                            <div class="loginBoxBehindTransp2"></div>
                                            <div class="loginContent">
                                                <asp:PasswordRecovery runat="server" ID="PasswordRecovery1" Style="width: 100%;"
                                                    OnSendingMail="PasswordRecovery1_SendingMail"
                                                    OnSendMailError="PasswordRecovery1_SendMailError"
                                                    OnVerifyingAnswer="PasswordRecovery1_VerifyingAnswer"
                                                    OnVerifyingUser="PasswordRecovery1_VerifyingUser" AnswerRequiredErrorMessage="Preenchimento da resposta secreta é obrigatório para recuperar a palavra-chave." GeneralFailureText="A sua tentativa de recuperar a sua palavra-chave não foi bem sucedida. Por favor, tente novamente." QuestionFailureText="Não foi possivel verificar a sua resposta chave . Por favor, tente novamente." QuestionInstructionText="Responda à seguinte pergunta secreta para receber sua senha." QuestionLabelText="Pergunta secreta" QuestionTitleText="Confirmação de utilizador" SuccessText="A sua palavra chave foi enviada para o seu e-mail." UserNameFailureText="Não foi possivel confirmar a &nbsp;sua informação Por favor, tente novamente." UserNameInstructionText="Por favor introduza o seu nome de utilizador para receber a sua Palavra-chave" UserNameLabelText="Utilizador" UserNameRequiredErrorMessage="Preenchimento do username é obrigatório para recupar a sua palavra chave." UserNameTitleText="" RenderOuterTable="False">
                                                    <MailDefinition From="aerogarelajes@gmail.com" Subject="Recuperação da Palavra-Chave" BodyFileName="~/Templates/email_recover.html" IsBodyHtml="True" Priority="High">
                                                    </MailDefinition>
                                                    <QuestionTemplate>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <table style="border-collapse: collapse; width: 100%; margin-left: 20px; margin-top: 5px;">
                            <tr>
                                <td>
                                    <table class="tableRecoverv2">
                                        <tr>
                                            <td colspan="2">Responda à pergunta para receber a sua palavra-chave.</td>
                                        </tr>
                                        <tr>
                                            <td>Utilizador</td>
                                            <td>
                                                <asp:Literal ID="UserName" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Pergunta secreta</td>
                                            <td>
                                                <asp:Literal ID="Question" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Resposta</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Answer" runat="server" Width="252px" MaxLength="255"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="Answer"
                                                    ErrorMessage="Preenchimento da resposta secreta é obrigatório para recuperar a palavra-chave"
                                                    EnableClientScript="true"
                                                    ValidationGroup="PasswordRecovery1"
                                                    SetFocusOnError="true" Style="color: red;"
                                                    Text="*" />
                                                <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="PasswordRecovery1" runat="server" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="false" />

                                            </td>
                                        </tr>
                                        <tr style="text-align: center;">
                                            <td colspan="2" style="padding-right: 10%;">
                                                <asp:ImageButton ID="SubmitButton" runat="server" CommandName="Submit" Style="margin-top:8px;"  ValidationGroup="PasswordRecovery1" ImageUrl="~/Layout/img/confirmar.png" />
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                        </table>
                                                        <asp:Panel CssClass="messageError_recover2" ID="messageError_recover" runat="server" Visible="false">
                                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                        </asp:Panel>
                                                    </QuestionTemplate>
                                                    <SuccessTemplate>
                                                        <table style="border-collapse: collapse;">
                                                            <tr>
                                                                <td>
                                                                    <table class="tableRecover_sucess">
                                                                        <tr>
                                                                            <td style="text-align: center;">

                                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Layout/img/success.png" Style="width: 48px; margin-top: 10px;" ImageAlign="Middle" /><br />
                                                                            </td>

                                                                            <td>&nbsp;&nbsp; A sua nova palavra chave foi enviada para o seu e-mail.</td>
                                                                        </tr>
                                                                        <tr style="text-align: center;">
                                                                            <td colspan="2">
                                                                                <asp:ImageButton ID="ContinueButton" runat="server" CausesValidation="False" ImageUrl="~/Layout/img/continuar.png" OnClick="ContinueButton_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </SuccessTemplate>
                                                    <UserNameTemplate>
                                                        <table style="border-collapse: collapse; min-height: 232px; margin-bottom: 2%;" id="tableRecoverDiv">
                                                            <tr>
                                                                <td>
                                                                    <table id="tableRecover">
                                                                        <tr>
                                                                            <td>
                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">Introduza o seu nome de utilizador para receber a sua Palavra-chave</td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="auto-style1">
                                                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Utilizador</asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="UserName" runat="server" Width="200px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="UserName"
                                                                                    ErrorMessage="Preenchimento do nome de utilizador obrigatório para recuperar a sua palavra chave."
                                                                                    EnableClientScript="true"
                                                                                    ValidationGroup="PasswordRecovery1"
                                                                                    SetFocusOnError="true" Style="color: red;"
                                                                                    Text="*" />
                                                                                <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="PasswordRecovery1" runat="server" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="false" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="text-align: center;">
                                                                            <td colspan="2">
                                                                                <asp:ImageButton ID="SubmitButton" runat="server" CommandName="Submit"  ValidationGroup="PasswordRecovery1" ImageUrl="~/Layout/img/confirmar.png" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:Panel CssClass="messageError_recover" ID="messageError_recover" runat="server" Visible="false">
                                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                        </asp:Panel>
                                                    </UserNameTemplate>
                                                </asp:PasswordRecovery>
                                            </div>
                                        </div>
                                    </div>
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
    </form>
</body>
</html>
