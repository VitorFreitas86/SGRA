<%@ Page Title="" Language="C#" MasterPageFile="~/acessos.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApplication10.Users.home" %>
<%@ MasterType VirtualPath="~/acessos.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="outer">
                <div class="middle">
                    <div class="inner_home">

                        <div>
                            <div class="roundCorner" id="GridView_div">

                                <table class="home_master_table">
                                    <tr>
                                        <td>
                                            <table class="home_child_table">
                                                <tr>
                                                    <td colspan="2" style="text-align: center; background-color: #0d4465;">
                                                        <asp:Label ID="Label11" runat="server" Text="Cartão Identificação/Acesso" CssClass="label_child_table"></asp:Label>
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
