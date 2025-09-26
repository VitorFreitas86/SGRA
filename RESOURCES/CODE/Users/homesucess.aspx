<%@ Page Title="" Language="C#" MasterPageFile="~/acessos.Master" AutoEventWireup="true" CodeBehind="homesucess.aspx.cs" Inherits="WebApplication10.Users.WebForm1" %>

<%@ MasterType VirtualPath="~/acessos.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="outer_success">
                <div class="middle">
                    <div class="inner_home">
                        <div>
                            <div class="roundCorner" id="GridView_div">
                                <asp:Panel ID="Panel_sucess" runat="server" Visible="true"
                                    Style="Padding: 3px 24px 3px 25px; height: 35px; font-weight: bold; 
                                    font-family: Ubuntu; border-top-left-radius: 25px; -moz-border-radius-topleft: 25px; border-bottom-left-radius: 25px; -moz-bottom-radius-topleft: 25px; border-top-right-radius: 25px; -moz-border-radius-topright: 25px; border-bottom-right-radius: 25px; -moz-bottom-radius-topright: 25px; text-shadow: 0 -1px 0 rgba(0,0,0,0.4); /* margin-top: -150px; */
                                    width: 50%; 
                                    margin-left:17%; margin-bottom: 100px; margin-top: 100px; background-color: #ccc; box-shadow: 2px 2px 8px #0d4465; text-align: center; min-width: 800px;">
                                    <div class="home_sucesso">
                                        <asp:Label ID="Label10" runat="server" Style="font-family: ubuntu; font-size: 18px; color: #0d4465; padding-left: 16px; padding-right: 16px; display: block; text-align: center;"> O seu pedido foi registado com sucesso. </asp:Label>
                                    </div>
                                </asp:Panel>
                                <table class="home_master_table">
                                    <tr>
                                        <td>
                                            <table class="home_child_table">
                                                <tr>
                                                    <td colspan="2" style="text-align: center; background-color: #0d4465;">
                                                        <asp:Label ID="Label11" runat="server" Text="Cartão de Identificação/Acesso" CssClass="label_child_table"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px;">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="/Layout/img/cartao_acl.png" Width="100px" Style="padding-left: 10px;" /></td>
                                                    <td>
                                                        <div style="margin-left: 10px;">
                                                            <a href="inserir_cartao.aspx" class="link_menu">&#8226;       
                                                    <asp:Label ID="Label4" runat="server" Text="Novo" CssClass="link_menu"></asp:Label></a><br />
                                                            <a href="segunda_via_cartao.aspx" class="link_menu">&#8226;       
                                                    <asp:Label ID="Label5" runat="server" Text="Renovações" CssClass="link_menu"></asp:Label></a><br />
                                                            <a href="consultar_cartao.aspx" class="link_menu">&#8226;     
                                                    <asp:Label ID="Label6" runat="server" Text="Histórico" CssClass="link_menu"></asp:Label></a><br />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table class="home_child_table">
                                                <tr>
                                                    <td colspan="2" style="text-align: center; background-color: #0d4465;">
                                                        <asp:Label ID="Label12" runat="server" Text="Circulação de Viaturas" CssClass="label_child_table"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px;">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Layout/img/Truck.png" Width="100px" Style="padding-left: 10px;" /></td>
                                                    <td>
                                                        <div style="margin-left: 10px;">
                                                            <a href="inserir_viatura.aspx" class="link_menu">&#8226;        
                                                    <asp:Label ID="Label7" runat="server" Text="Novo" CssClass="link_menu"></asp:Label></a><br />
                                                            <a href="segunda_via_viatura.aspx" class="link_menu">&#8226;         
                                                    <asp:Label ID="Label8" runat="server" Text="Renovações" CssClass="link_menu"></asp:Label></a><br />
                                                            <a href="consultar_viatura.aspx" class="link_menu">&#8226;         
                                                    <asp:Label ID="Label9" runat="server" Text="Histórico" CssClass="link_menu"></asp:Label></a><br />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table class="home_child_table">
                                                <tr>
                                                    <td colspan="2" style="text-align: center; background-color: #0d4465;">
                                                        <asp:Label ID="Label13" runat="server" Text="Autorização de Condução" CssClass="label_child_table"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px;">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Layout/img/volante.png" Width="100px" Style="padding-left: 10px;" /></td>
                                                    <td>
                                                        <div style="margin-left: 10px;">
                                                            <a href="inserir_conducao.aspx" class="link_menu">&#8226;   
                                                    <asp:Label ID="Label1" runat="server" Text="Novo" CssClass="link_menu"></asp:Label></a><br />
                                                            <a href="segunda_via_conducao.aspx" class="link_menu">&#8226; 
                                                    <asp:Label ID="Label2" runat="server" Text="Renovações" CssClass="link_menu"></asp:Label></a><br />
                                                            <a href="consultar_conducao.aspx" class="link_menu">&#8226;  
                                                    <asp:Label ID="Label3" runat="server" Text="Histórico" CssClass="link_menu"></asp:Label></a><br />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
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
</asp:Content>

