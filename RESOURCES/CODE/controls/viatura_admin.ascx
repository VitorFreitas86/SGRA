<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="viatura_admin.ascx.cs" Inherits="WebApplication10.controls.viatura_admin" %>
<div style="width: 500px; padding-left: 10px; padding-top: 10px;">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ib_save" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <div>
                <table style="color: #0d4465; font-family: Ubuntu; font-size: 12px; width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="LabelEstado" runat="server" Text="Estado"></asp:Label></td>
                        <td>
                            <asp:Label ID="Label_estado" runat="server" Text="" Visible="false"></asp:Label>
                            <asp:DropDownList ID="ddl_estado" runat="server">
                                <asp:ListItem Text="Pendente" Value="Pendente"></asp:ListItem>
                                <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
                                <asp:ListItem Text="Indeferido" Value="Indeferido"></asp:ListItem>
                                <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Atribuido o Dístico Nº"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tb_n_distico" runat="server" Enabled="true" MaxLength="5" ValidationGroup="teste"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="teste" ControlToValidate="tb_n_distico" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do nº dístico" SetFocusOnError="true" Text="*" Style="color: red;" />--%>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ValidationGroup="teste" ControlToValidate="tb_n_distico" EnableClientScript="true" ErrorMessage="Apenas pode introduzir numeros no campo nº dístico." SetFocusOnError="true" Text="*" ValidationExpression="^[0-9]*$" Style="color: red;" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Atribuido o Nº de identificação"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tb_n_identificacao" runat="server" MaxLength="8"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="teste" ControlToValidate="tb_n_identificacao" EnableClientScript="true" ErrorMessage="É necessário o preenchimento do nº de identificação" SetFocusOnError="true" Text="*" Style="color: red;" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Outros Serviços/Entidades"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tb_outros" runat="server" MaxLength="45"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table style="color: #0d4465; font-family: Ubuntu; font-size: 12px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Portão de Acesso"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tb_portao" runat="server" Width="225px" Style="margin-right: 0px;" MaxLength="45"> </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Tipo de cartão"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rb_tipo_circulação" runat="server" Style="font-size: 12px; font-family: ubuntu;" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                <asp:ListItem Value="permanente">Circulação Permanente</asp:ListItem>
                                <asp:ListItem Value="temporaria">Circulação Temporária</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:CustomValidator ID="SelectValidator" runat="server"
                                ClientValidationFunction="onButtonClick();"
                                ErrorMessage="É necessário escolher o tipo de cartão.">*</asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label_validade" runat="server" Text="Validade:" Visible="false"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tb_validade" runat="server" MaxLength="45" Visible="false"></asp:TextBox>
                            <asp:ImageButton runat="Server" ID="ib_validade" ImageUrl="~/Layout/img/calendar.png" Width="25px" Visible="false" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server"
                                TargetControlID="tb_validade" PopupButtonID="ib_validade" DefaultView="Years" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="teste" ControlToValidate="tb_validade" Display="Dynamic" ErrorMessage="A data deve estar no formato: dd/mm/yyyy" SetFocusOnError="True" Text="*" Style="color: red;" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /](0[1-9]|1[012])[- /](19|20)[0-9]{2}"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Conferido:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tb_conferido" runat="server" MaxLength="45"></asp:TextBox>
                            <asp:ImageButton runat="Server" ID="ib_conferido" ImageUrl="~/Layout/img/calendar.png" Width="25px" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server"
                                TargetControlID="tb_conferido" PopupButtonID="ib_conferido" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="teste" ControlToValidate="tb_conferido" EnableClientScript="true" ErrorMessage="É necessário o preenchimento da data de conferir" SetFocusOnError="true" Text="*" Style="color: red;" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="teste" ControlToValidate="tb_conferido" Display="Dynamic" ErrorMessage="A data deve estar no formato: dd/mm/yyyy" SetFocusOnError="True" Text="*" Style="color: red;" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /](0[1-9]|1[012])[- /](19|20)[0-9]{2}"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="text-align: center; padding-bottom: 10px;">
                <asp:ImageButton ID="ib_save" runat="server" OnClick="ib_save_Click" CausesValidation="true" ImageUrl="~/Layout/img/confirmar.png" ValidationGroup="teste" />
            </div>
            <asp:ValidationSummary ID="ValidationSummary4" runat="server" ForeColor="Red" BackColor="#FEDAD8" ValidationGroup="MyValidationGroup" Style="margin-bottom: 5px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="true" Width="98%" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
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

<%-------------------------------------------------------SCRIPT---------------------------------------------------%>
<script type="text/javascript">
    function onButtonClick(args) {
        return validateRadioButtonList('<%= rb_tipo_circulação.ClientID %>');
    }
    function validateRadioButtonList(radioButtonListId, args) {
        var listItemArray = document.getElementsByName(radioButtonListId);
        for (var i = 0; i < listItemArray.length; i++) {
            var listItem = listItemArray[i];
            if (listItem.checked) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
        }
    }
</script>
