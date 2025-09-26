<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SGRA.Login.Signin" %>
<%@ Register TagPrefix="mp" TagName="MyMP" Src="~/acessos.Master" %>
<%@ Register Src="~/controls/bar_GRA.ascx" TagPrefix="uc10" TagName="bar_GRA" %>
<%@ Register Src="~/controls/footer.ascx" TagPrefix="uc11" TagName="footer" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>SGRA-Sistema de Gestão e Requisição de Acessos</title>
    <meta charset="UTF-8">
    <link rel="shortcut icon" type="image/ico" href="../Layout/img/favicon.ico">
    <%--<link href='http://fonts.googleapis.com/css?family=Ubuntu' rel='stylesheet' type='text/css'>--%>
    <script src="../JS/Script.js"></script>
    <link href="../Layout/StyleBarra.css" rel="stylesheet" type="text/css" />
    <link href="../Layout/Style.css" rel="stylesheet" type="text/css" />
    <link href="../Layout/Menu.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var $buoop = {};
        $buoop.ol = window.onload;
        window.onload = function () {
            try { if ($buoop.ol) $buoop.ol(); } catch (e) { }
            var e = document.createElement("script");
            e.setAttribute("type", "text/javascript");
            e.setAttribute("src", "//browser-update.org/update.js");
            document.body.appendChild(e);
        }
</script> 
	
    <style type="text/css">
        .auto-style1 {
            width: 328px;
        }
    </style>
</head>
<!--[if lt IE 9 ]>
<body class="ie">
<![endif]-->
<!--[if IE 9 ]>
<body class="ie">
<![endif]-->
<!--[if !IE ]>-->
<body onresize="Resize()">
    <!--<![endif]-->
    <form id="form1" action="#" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <uc10:bar_GRA runat="server" ID="bar_GRA" Visible="true" />
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="outer_reg">
                    <div class="middle">
                        <div class="inner">
                            <div class="divExteriorLogin">
                                <div>
                                    <asp:Label ID="Label3" runat="server" Height="16px" Text="Sistema de Gestão e Requisição de Acessos" CssClass="title"></asp:Label>
                                </div>
                                <div>
                                    <div id="divExterior">
                                        <div class="loginBoxBehindTransp"></div>
                                        <div class="loginContent">
                                            <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Users/home.aspx" OnAuthenticate="Login1_Authenticate"
                                                OnLoginError="Login1_LoginError" PasswordRecoveryText="Recuperar Password" PasswordRecoveryUrl="~/Login/Recover.aspx" CreateUserUrl="Register.aspx" CreateUserText="Novo Utilizador" PasswordRequiredErrorMessage="É necessário a introdução da Password." RememberMeText="Manter sessão iniciada" FailureText="Ocorreu um erro. Tente novamente." TitleText="Iniciar Sessão" UserNameRequiredErrorMessage="É necessário a introdução do Username." OnLoggedIn="Login1_LoggedIn" RenderOuterTable="False">
                                                <LayoutTemplate>
                                                    <table class="tableContentLogin">
                                                        <tr>
                                                            <td>
                                                                <table class="textLabels" style="margin-top: 1%;">
                                                                    <tr>
                                                                        <td class="tdCenter">Utilizador
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="UserName" runat="server" CssClass="inputColor" ValidationGroup="Login1" MaxLength="256"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ValidationGroup="Login1" ControlToValidate="UserName" Text="*" Style="color: red;"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Palavra-Chave</td>
                                                                        <td>
                                                                            <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="inputColor" ValidationGroup="Login1" MaxLength="128"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" Text="*" ValidationGroup="Login1" Style="color: red;"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center; -webkit-padding-start: 10px;">
                                                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" CssClass="buttonLogin" OnClick="Login1_Authenticate" ValidationGroup="ctl00$Login2" BorderStyle="None" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:Panel CssClass="messageError_1" ID="messageError" runat="server" Visible="false">
                                                        <asp:Literal ID="FailureText" runat="server"></asp:Literal></div>    
                                                    </asp:Panel>
                                                </LayoutTemplate>
                                            </asp:Login>
                                        </div>
                                    </div>
                                    <table class="tableButtons">
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="ImageButton1" runat="server" ValidationGroup="new" ImageUrl="~/Layout/img/new_user.png" OnClick="ImageButton1_Click" AlternateText="Novo utilizador" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageButton3" runat="server" ValidationGroup="recover" ImageUrl="~/Layout/img/recuperar_pwd.png" CssClass="imgRecPwd" OnClick="ImageButton3_Click" AlternateText="Recuperar Password" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="prgLoadingStatus" runat="server" DynamicLayout="true">
            <ProgressTemplate>
                <div id="overlay">
                    <div id="modalprogress">
                        <div id="theprogress_2">
                            <asp:Image ID="imgWaitIcon" runat="server" ImageUrl="../Layout/img/sending.gif" AlternateText="Sending" CssClass="sending" />
                        </div>
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div id="rodape">
            <footer>
                <uc11:footer runat="server" ID="footer" Visible="true" />
            </footer>
        </div>
    </form>
</body>
</html>
