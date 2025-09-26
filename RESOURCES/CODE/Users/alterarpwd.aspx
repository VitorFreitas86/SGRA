<%@ Page Title="" Language="C#" MasterPageFile="~/acessos.Master" AutoEventWireup="true" CodeBehind="alterarpwd.aspx.cs" Inherits="WebApplication10.Login.alterarpwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="outer">
        <div class="middle">
            <div class="inner_alt">
                <div class="loginBoxBehind3">
                    <div class="titleRecover">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Layout/img/chave.png" />
                        &nbsp;  Alterar Palavra-Chave
                    </div>
                    <div>
                        <div>
                            <div class="loginBoxBehindTransp3"></div>
                            <div class="loginContent">
                                <asp:ChangePassword ID="ChangePassword1" runat="server" DisplayUserName="True" Style="width: 100%;" ChangePasswordButtonText="Alterar Palavra-chave" ChangePasswordFailureText="Palavra-chave incorreta ou inválida. Tamanho mínimo: 7. Caracteres não alfanuméricos necessários:1" ChangePasswordTitleText="Alterar a sua palavra-chave" ConfirmNewPasswordLabelText="Confirmar nova palavra-chave" ConfirmPasswordCompareErrorMessage="A confirmação da palavra-chave tem de ser igual á nova palavra-chave." ConfirmPasswordRequiredErrorMessage="Confirmação de nova palavra-chave é obrigatório." ContinueButtonText="continuar" NewPasswordLabelText="Nova Palavra-chave:" NewPasswordRegularExpressionErrorMessage="Por favor insira uma palavra-chave diferente." NewPasswordRequiredErrorMessage="Preenchimento de nova palavra-chave é obrigatório." PasswordLabelText="Palavra-chave :" PasswordRequiredErrorMessage="Preenchimento da Palavra-chave é obrigatório." SuccessText="A sua palavra-chave foi alterada com sucesso." SuccessTitleText="Alteração de palavra-chave concluída." UserNameLabelText="Username:" UserNameRequiredErrorMessage="Preenchimento de username é obrigatório.">
                                    <ChangePasswordTemplate>
                                        <table style="border-collapse: collapse; width: 100%;">
                                            <tr>
                                                <td>
                                                    <table id="tableChangePwd" style="width: 100%;">

                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Utilizador</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="UserName" runat="server" Enabled="false" CssClass="widthInput" Width="250px" ValidationGroup="ChangePassword1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Preenchimento de username é obrigatório." ToolTip="Preenchimento de username é obrigatório." ValidationGroup="ChangePassword1" Style="color: red;" EnableClientScript="true" Text="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Palavra-chave</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" Width="250px" ValidationGroup="ChangePassword1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" ErrorMessage="Preenchimento da Palavra-chave é obrigatório." ToolTip="Preenchimento da Palavra-chave é obrigatório." ValidationGroup="ChangePassword1" Style="color: red;" EnableClientScript="true" Text="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">Nova Palavra-chave</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" Width="250px" ValidationGroup="ChangePassword1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" ErrorMessage="Preenchimento de nova palavra-chave é obrigatório." ToolTip="Preenchimento de nova palavra-chave é obrigatório." ValidationGroup="ChangePassword1" Style="color: red;" EnableClientScript="true" Text="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirmar nova palavra-chave</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" Width="250px" ValidationGroup="ChangePassword1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" ErrorMessage="Confirmação de nova palavra-chave é obrigatório." ToolTip="Confirmação de nova palavra-chave é obrigatório." ValidationGroup="ChangePassword1" Style="color: red;" EnableClientScript="true" Text="*"></asp:RequiredFieldValidator>
                                                                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="A confirmação da palavra-chave tem de ser igual á nova palavra-chave." Style="color: red;" EnableClientScript="true" Text="*"></asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <asp:ImageButton ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" ValidationGroup="ChangePassword1" ImageUrl="~/Layout/img/confirmar.png" Style="margin-top: 5px; margin-left: 200px; margin-bottom: 20px;" />
                                                    <div  style="margin-top:5px; font-family:Ubuntu; color:red; text-align:center; font-size:12px;">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                    </div>

                                                </td>
                                            </tr>
                                        </table>
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="false" ValidationGroup="ChangePassword1" />
                                    </ChangePasswordTemplate>
                                    <SuccessTemplate>
                                        <table style="margin-top: 9%; margin-left:10%;">
                                            <tr>
                                                <td style="text-align: center;">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Layout/img/success.png" Style="width: 48px; margin-top: 10px; margin-bottom: 10px;"
                                                        ImageAlign="Middle" /><br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="Label1" runat="server" Style="font-family: ubuntu; font-size: 15px; color: #D6ECFF; padding-left: 16px; padding-right: 16px; display: block; text-align: center;"> A alteração da sua palavra-chave foi concluída com êxito.</asp:Label>
                                                    <br />
                                                </td>
                                                <tr>
                                                    <td style="text-align: center; padding-top: 24px;">
                                                        <asp:ImageButton ID="ContinueButton" runat="server" CausesValidation="False" ImageUrl="~/Layout/img/continuar.png" ToolTip="Continuar" ValidationGroup="CreateUserWizard1" OnClick="ContinueButton_Click" />
                                                    </td>
                                                </tr>
                                            <tr>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </SuccessTemplate>
                                </asp:ChangePassword>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
