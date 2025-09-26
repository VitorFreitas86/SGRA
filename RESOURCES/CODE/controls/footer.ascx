<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="footer.ascx.cs" Inherits="WebApplication10.controls.footer" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Panel ID="Panel_close" runat="server" Visible="false" BackColor="#0d4465" Style="padding-left: 5px;">
            <table style="width: 100%; color: #d6ecff; font-family: Ubuntu; font-size: 14px; margin-top: 0%; font-weight: bold;">
                <tr>
                    <td>
                        <asp:Label ID="Label_header" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:ImageButton ID="ImageButton_close" runat="server" OnClick="ImageButton_close_Click" ImageUrl="~/Layout/img/Close.png" Width="20" Style="text-align: right; float: right;" />
                    </td>
                </tr>
            </table>
            <asp:Panel ID="Panel_email" runat="server" Visible="true" BackColor="#0d4465">
                <table class="popup_contato">
                    <tr>
                        <td style="width: 33.3%;">
                            <div style="margin-top: 0px; height: 150px;">
                                <asp:Label ID="Label1" runat="server" Text="Insira o seu email"></asp:Label><br />
                                <asp:TextBox ID="TextBox_email" runat="server" Width="233px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Style="color: red;" runat="server" ControlToValidate="TextBox_email" EnableClientScript="true" ErrorMessage="É necessário a inserção do Email" SetFocusOnError="true" Text="*" ValidationGroup="suporte" />
                                <asp:RegularExpressionValidator ID="rexemail" Style="color: red;" runat="server" ControlToValidate="TextBox_email" EnableClientScript="true" ErrorMessage="Introduza um e-mail válido." SetFocusOnError="true" Text="*" ValidationGroup="suporte" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                <br />
                                <asp:Label ID="Label3" runat="server" Text="Assunto"></asp:Label><br />
                                <asp:TextBox ID="TextBox_assunto" runat="server" Width="232px" MaxLength="80"></asp:TextBox>
                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" BackColor="#FEDAD8" ValidationGroup="suporte" Style="margin-top: 10px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="98%" />
                            </div>
                        </td>
                        <td style="width: 33.3%;">
                            <div style="margin-top: 0px; height: 150px;">
                                <asp:Label ID="Label4" runat="server" Text="Mensagem a enviar"></asp:Label><br />
                                <asp:TextBox ID="TextBox_corpo" runat="server" Height="135px" TextMode="MultiLine" MaxLength="500" Width="400px" Style="resize: none"></asp:TextBox>
                            </div>
                        </td>
                        <td style="width: 33.3%;">
                            <asp:Panel ID="Panel_suporte" runat="server" Height="150px" BackColor="#0d4465">
                                <table class="popup_contato_suporte">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label_nome" runat="server" Text="Insira o seu nome:"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox_nome" runat="server" Width="233px" MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Insira o seu contato"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox_contato" runat="server" Width="232px" MaxLength="12"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Panel_gestao_doc" runat="server" Visible="false" Height="150px" Width="100%" ScrollBars="auto">
                                <asp:Label ID="Label6" runat="server" Text="Documentos:" cssclass="docs_email_suporte"></asp:Label>
                                <asp:CheckBoxList ID="Cb_docs" runat="server" cssclass="docs_email_suporte"></asp:CheckBoxList>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center; margin-top: 0px;">
                    <div>
                        <asp:ImageButton ID="ImageButton_s_email" runat="server" OnClick="ImageButton_s_email_Click" ImageUrl="~/Layout/img/suporte.png" ValidationGroup="suporte" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel_sucess" runat="server" Visible="false" cssclass="popup_contato_success">
                <br />
                <div style="text-align: center;">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Layout/img/success.png" Width="64px" /><br />
                    <asp:Label ID="Label5" runat="server" Text="O seu email foi enviado com sucesso" Style="color: #a9cf3a; font-weight: bold; font-size: 16px; margin-left: 15px; text-align: center;" Width="281px"></asp:Label><br />
                </div>
                <br />
            </asp:Panel>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<table style="width: 100%; border-top-width: 1px; border-top-style: solid; border-top-color: #0d4465; min-width: 800px; background-color: #e9eaed;">
    <tr>
        <td style="font-family: Ubuntu; color: #0d4465; font-size: 13px; display: block;">Copyright © <a href="http://aerogarelajes.azores.gov.pt/" target="_blank" style="text-decoration: none; color: #0d4465; cursor: pointer;">Aerogare Civil das Lajes - 2014</a>
        </td>
        <td>
            <asp:ImageButton ID="ImageButton3" runat="server" Style="float: right; text-align: right;" ImageUrl="~/Layout/img/ayuda.png" OnClick="ImageButton3_Click" ToolTip="Pedido de Suporte Técnico" Width="36" Height="36" AlternateText="Suporte Técnico" />
        </td>
    </tr>
</table>

<%----------------------------------------------------------JAVSCRIP----------------------------------------------------------%>
<script src="../JS/Script.js"></script>
