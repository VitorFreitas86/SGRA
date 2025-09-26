<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="emitir_parecer.ascx.cs" Inherits="WebApplication10.controls.emitir_parecer" %>

<asp:Panel ID="Panel1" runat="server" Style="margin-top: 5px; margin-right: 5px;">
    <fieldset style="width: 690px; margin-left: 10px; color: #0d4465;">
        <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px;">Informação Pessoal</legend>
        <table style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 5px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label7" runat="server" Text="Nome"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_nome" Enabled="false" runat="server" MaxLength="450" Width="574px" Style="margin-left: 0px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label2" runat="server" Text="Morada"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_morada" runat="server" MaxLength="450" Enabled="false" Width="280px"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Text="Código postal" Style="margin-left: 39px;"></asp:Label>
                    <asp:TextBox ID="tb_codigo_postal" runat="server" MaxLength="45" Enabled="false" Style="margin-left: 10px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label3" runat="server" Text="Localidade"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_localidade" runat="server" MaxLength="45" Enabled="false" Width="244px"></asp:TextBox>
                    <asp:Label ID="Label5" runat="server" Text="Telefone" Style="margin-left: 102px;"></asp:Label>
                    <asp:TextBox ID="tb_telefone" MaxLength="45" runat="server" Enabled="false" Style="margin-left: 10px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label6" runat="server" Text="Telemóvel"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_tlm" MaxLength="45" runat="server" Enabled="false" Style="margin-left: -1px;"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="Telefone Serviço" Style="margin-left: 153px;"></asp:Label>
                    <asp:TextBox ID="tb_tlf_serv" runat="server" MaxLength="45" Enabled="false" Style="margin-left: 10px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5">Email</td>
                <td>
                    <asp:TextBox ID="Email" runat="server" MaxLength="128" Width="310px" Enabled="false" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset style="width: 690px; margin-left: 10px; margin-top: 10px; color: #0d4465;">
        <legend style="font-family: Ubuntu; font-size: 14px; font-weight: bold;">Informação BI/CC/Passaporte</legend>
        <table style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 5px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label8" runat="server" Text="CC/BI/Passaporte nº"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_bi" runat="server" MaxLength="45" Enabled="false" Width="170px"></asp:TextBox>
                    <asp:Label ID="Label9" runat="server" Text="Validade" Style="margin-left: 92px;"></asp:Label>
                    <asp:TextBox ID="tb_validade_bi" runat="server" MaxLength="45" Enabled="false" Style="margin-left: 10px;"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label19" runat="server" Text="Nacionalidade"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_nacionalidade" runat="server" MaxLength="45" Enabled="false" Width="169px"></asp:TextBox>
                    <asp:Label ID="Label10" runat="server" Text="Data de Nascimento" Style="margin-left: 24px;"></asp:Label>
                    <asp:TextBox ID="tb_d_nascimento" runat="server" MaxLength="45" Enabled="false" Style="margin-left: 10px;"></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset style="width: 690px; margin-left: 10px; margin-top: 10px; color: #0d4465;">
        <legend style="font-family: Ubuntu; font-size: 14px; font-weight: bold;">Informação Contratual</legend>
        <table style="width: 100%; margin-left: 5px; margin-bottom: 5px; margin-right: 5px; margin-top: 5px; color: #0d4465; font-family: Ubuntu; font-size: 12px;">
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label13" runat="server" Text="Entidade Patronal"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_patronal" runat="server" MaxLength="450" Enabled="false" Width="418px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label16" runat="server" Text="Cat. Profissional"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tb_cat_prof" runat="server" MaxLength="45" Enabled="false" Width="418px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset style="width: 690px; margin-left: 10px; color: #0d4465; background-color: #F8F8F8;">
        <legend style="font-family: Ubuntu; font-weight: bold; font-size: 14px;">Emitir parecer sobre Cartão</legend>
        <asp:TextBox ID="tb_parecer" runat="server" Height="35px" Width="686px" MaxLength="50"></asp:TextBox><br />
           
  
    </fieldset>
  
      <asp:ImageButton ID="FinishButton" ToolTip="Submeter Pedido" runat="server" AlternateText="Submeter" ImageUrl="~/Layout/img/confirmar.png" OnClick="FinishButton_Click" Style="margin-left: 288px;" />
  <asp:ValidationSummary ID="ValidationSummary4" runat="server" ForeColor="Red" BackColor="#FEDAD8" ValidationGroup="MyValidationGroup" Style="margin-bottom: 5px; font-size: 12px;" HeaderText="Existem os seguintes erros de preenchimento" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" BorderColor="Red" BorderWidth="2" BorderStyle="Double" EnableClientScript="false" Width="80%" />

</asp:Panel>
