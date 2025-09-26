using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.BAL;
using WebApplication10.PROP;

namespace WebApplication10.Admin
{
    public partial class gerir_viatura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                if (GridView_viatura.AllowPaging == true)
                ApplyPaging();
            }
            else
            {              
                carrega_grid();
            }
        }

        private void ApplyPaging()
        {
            ////////////////////////////PAGINAMENTO/////////////////////////////
            try
            {
                GridViewRow row = GridView_viatura.BottomPagerRow;
                PlaceHolder ph;
                LinkButton lnkPaging;
                LinkButton lnkFirstPage;
                LinkButton lnkPrevPage;
                LinkButton lnkNextPage;
                LinkButton lnkLastPage;


                lnkFirstPage = new LinkButton();
                lnkFirstPage.Text = Server.HtmlEncode(".");
                lnkFirstPage.Width = Unit.Pixel(32);
                lnkFirstPage.Height = Unit.Pixel(32);
                lnkFirstPage.CssClass = "LinkPaging_first";
                lnkFirstPage.CommandName = "Page";
                lnkFirstPage.CommandArgument = "first";
                lnkPrevPage = new LinkButton();
                lnkPrevPage.CssClass = "LinkPaging_anterior";
                lnkPrevPage.Text = Server.HtmlEncode(".");
                lnkPrevPage.Width = Unit.Pixel(32);
                lnkPrevPage.Height = Unit.Pixel(32);
                lnkPrevPage.CommandName = "Page";
                lnkPrevPage.CommandArgument = "prev";
                ph = (PlaceHolder)row.FindControl("ph");
                ph.Controls.Add(lnkFirstPage);
                ph.Controls.Add(lnkPrevPage);
                if (GridView_viatura.PageIndex == 0)
                {
                    lnkFirstPage.Enabled = false;
                    lnkPrevPage.Enabled = false;
                }
                for (int i = 1; i <= GridView_viatura.PageCount; i++)
                {
                    lnkPaging = new LinkButton();
                    lnkPaging.Width = Unit.Pixel(22);
                    lnkPaging.Height = Unit.Pixel(22);
                    lnkPaging.CssClass = "LinkPaging";
                    lnkPaging.Text = i.ToString();
                    lnkPaging.ToolTip = "Página " + i;
                    lnkPaging.CommandName = "Page";
                    lnkPaging.CommandArgument = i.ToString();
                    if (i == GridView_viatura.PageIndex + 1)
                        lnkPaging.CssClass = "LinkPaging_selected";

                    ph = (PlaceHolder)row.FindControl("ph");
                    ph.Controls.Add(lnkPaging);
                }
                lnkNextPage = new LinkButton();
                lnkNextPage.Text = Server.HtmlEncode(" . ");
                lnkNextPage.Width = Unit.Pixel(32);
                lnkNextPage.Height = Unit.Pixel(32);
                lnkNextPage.CssClass = "LinkPaging_proximo";
                lnkNextPage.CommandName = "Page";
                lnkNextPage.CommandArgument = "next";
                lnkLastPage = new LinkButton();
                lnkLastPage.Text = Server.HtmlEncode(".");
                lnkLastPage.CssClass = "LinkPaging_last";
                lnkLastPage.Width = Unit.Pixel(32);
                lnkLastPage.Height = Unit.Pixel(32);
                lnkLastPage.CommandName = "Page";
                lnkLastPage.CommandArgument = "last";
                lnkFirstPage.ToolTip = "Primeira Página";
                lnkPrevPage.ToolTip = "Página Anterior";
                lnkNextPage.ToolTip = "Página Seguinte";
                lnkLastPage.ToolTip = "Última Página";
                ph = (PlaceHolder)row.FindControl("ph");
                ph.Controls.Add(lnkNextPage);
                ph = (PlaceHolder)row.FindControl("ph");
                ph.Controls.Add(lnkLastPage);

                if (GridView_viatura.PageIndex == GridView_viatura.PageCount - 1)
                {
                    lnkNextPage.Enabled = false;
                    lnkLastPage.Enabled = false;
                }
            }
            catch { }
        }

        protected void carrega_grid()
        {
            ////////////////////////////CARREGAR GRIDVIEW/////////////////////////////
            BAL_viatura viatura = new BAL_viatura();
            GridView_viatura.DataSource = viatura.get_viatura_all() ;
            GridView_viatura.DataBind();
        }

        protected void GridView_viatura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ////////////////////////////PAGINAMENTO/////////////////////////////
            GridView_viatura.PageIndex = e.NewPageIndex;
            carrega_grid();
        }

        protected void GridView_viatura_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            foradeprazo();
            if (e.CommandName.ToString() == "send_email")
            {
                ////////////////////////////ENVIAR EMAIL COM ARRAY DE ANEXOS/////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(GridView_viatura.DataKeys[rowIndex].Value);
                BAL_viatura email = new BAL_viatura();
                 Label path = (Label)GridView_viatura.Rows[rowIndex].FindControl("fotocopia_livrete");
                 Label path1 = (Label)GridView_viatura.Rows[rowIndex].FindControl("fotocopia_registop");
                 Label path2 = (Label)GridView_viatura.Rows[rowIndex].FindControl("fotocopia_cartaverde");
                 Label path3 = (Label)GridView_viatura.Rows[rowIndex].FindControl("fotocopia_declaracao_segurador");
                 Label path4 = (Label)GridView_viatura.Rows[rowIndex].FindControl("fotocopia_ipo");
                 Label path5 = (Label)GridView_viatura.Rows[rowIndex].FindControl("doc");
                 acessos MyMasterPage = (acessos)Page.Master;
                 MyMasterPage.painel_email = email.email_based_idviatura(id);
                 string[] docs_upload = { path.Text, path1.Text, path2.Text, path3.Text, path4.Text, path5.Text };
                 MyMasterPage.documentos_conducao = docs_upload;
            }

            if (e.CommandName.ToString() == "hide")
            {
                //////////////////////////ESCONDER CHILD PANELS///////////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Panel Panel_segunda_via = gvr.FindControl("Panel_segunda_via") as Panel;
                Panel Panel_renovacao = gvr.FindControl("Panel_renovacao") as Panel;
                Panel_segunda_via.Visible = false;
                Panel_renovacao.Visible = false;
                ImageButton ImageButton_hide = (ImageButton)GridView_viatura.Rows[rowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = false;
                GridView_viatura.SelectedIndex = -1;
                int DemoId = Convert.ToInt32(gvr.RowIndex.ToString());
                GridView_viatura.Rows[DemoId].BackColor = System.Drawing.ColorTranslator.FromHtml("#e8e8e8");
                foradeprazo();
             
                GridView_viatura.Rows[DemoId].ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d4465");
                GridView_viatura.Rows[DemoId].Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");

            }

            if (e.CommandName.ToString() == "renovacao")
            {
                //////////////////////////// RENOVACAO/////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(GridView_viatura.DataKeys[rowIndex].Value);
                ViewState["id_pedido"] = id;
                //carrega_grid_viatura_renovacao(id);
                Panel Panel_segunda_via = gvr.FindControl("Panel_segunda_via") as Panel;
                Panel Panel_renovacao = gvr.FindControl("Panel_renovacao") as Panel;
                Panel_segunda_via.Visible = false;
                Panel_renovacao.Visible = true;
                GridView_viatura.SelectedIndex = rowIndex;
                Label estado_inactivo = (Label)GridView_viatura.Rows[rowIndex].FindControl("lbl_estado");
                ImageButton ImageButton_hide = (ImageButton)GridView_viatura.Rows[rowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = true;
                if (estado_inactivo.Text == "Inactivo")
                {
                    GridView GridView_renovacao = (GridView)GridView_viatura.Rows[rowIndex].Cells[22].FindControl("GridView_renovacao") as GridView;

                    GridView_renovacao.Columns[7].Visible = false;

                }
                GridView_viatura.SelectedIndex = rowIndex;
                GridView_viatura.Rows[rowIndex].BackColor = System.Drawing.ColorTranslator.FromHtml("#0d4365");
                GridView_viatura.Rows[rowIndex].ForeColor = Color.White;
                GridView_viatura.SelectedRow.Attributes.Remove("onmouseover");
           
            }

            if (e.CommandName.ToString() == "segunda_via")
            {
                ////////////////////////////SEGUNDA VIA/////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(GridView_viatura.DataKeys[rowIndex].Value);
                ViewState["id_pedido"] = id;
                Panel Panel_segunda_via = gvr.FindControl("Panel_segunda_via") as Panel;
                Panel Panel_renovacao = gvr.FindControl("Panel_renovacao") as Panel;
                Panel_segunda_via.Visible = true;
                Panel_renovacao.Visible = false;
                GridView_viatura.SelectedIndex = rowIndex;
                Label estado_inactivo = (Label)GridView_viatura.Rows[rowIndex].FindControl("lbl_estado");
                ImageButton ImageButton_hide = (ImageButton)GridView_viatura.Rows[rowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = true;
                if (estado_inactivo.Text == "Inactivo")
                {
                    ////////////////////////////ESCONDER ADMINISTRACAO SE FOR INCTIVO/////////////////////////////
                    GridView GridView_segunda_via = (GridView)GridView_viatura.Rows[rowIndex].Cells[21].FindControl("GridView_viatura") as GridView;
                    GridView_viatura.Columns[6].Visible = false;
                }
                GridView_viatura.SelectedIndex = rowIndex;
                GridView_viatura.Rows[rowIndex].BackColor = System.Drawing.ColorTranslator.FromHtml("#0d4365");
                GridView_viatura.Rows[rowIndex].ForeColor = Color.White;
                GridView_viatura.SelectedRow.Attributes.Remove("onmouseover");   
            }
            
            
            if (e.CommandName.ToString() == "livrete")
            {
                ////////////////////////////DOWNLOAD LIVRETE/////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path = (Label)GridView_viatura.Rows[rowIndex].FindControl("fotocopia_livrete");
                //string fileName = path.Text;
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path.Text);
            }
            if (e.CommandName.ToString() == "r_prop")
            {
                ////////////////////////////DOWNLOAD REGISTO PROPRIEDADE/////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path = (Label)GridView_viatura.Rows[rowIndex].FindControl("fotocopia_registop");
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path.Text);
            }
            if (e.CommandName.ToString() == "carta_verde")
            {
                ////////////////////////////DOWNLOAD CARTA VERDE/////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path = (Label)GridView_viatura.Rows[rowIndex].FindControl("fotocopia_cartaverde");
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path.Text);

            }
            if (e.CommandName.ToString() == "d_segurador")
            {
                ////////////////////////////DOWNLOAD SEGURADORA/////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path = (Label)GridView_viatura.Rows[rowIndex].FindControl("fotocopia_declaracao_segurador");
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path.Text);
 
            }
            if (e.CommandName.ToString() == "ipo")
            {
                ////////////////////////////DOWNLOAD IPO/////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path = (Label)GridView_viatura.Rows[rowIndex].FindControl("fotocopia_ipo");   
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path.Text);
 
            }
            if (e.CommandName.ToString() == "doc_final")
            {
                ////////////////////////////DOWNLOAD DOCUMENTO FINAL/////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path = (Label)GridView_viatura.Rows[rowIndex].FindControl("doc");
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path.Text);
               
            }

            if (e.CommandName.ToString() == "admin")
            {
                ////////////////////////////ADMINISTRACAO/////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(GridView_viatura.DataKeys[rowIndex].Value);
                ViewState["id_pedido"] = id;
                BAL_viatura viatura = new BAL_viatura();        
                List<PROP_viatura> lista_conducao = new List<PROP_viatura>();
                lista_conducao = viatura.get_viatura_idviatura(id);
                viatura_admin.id_viatura = lista_conducao[0].idviatura;
                viatura_admin.distico = lista_conducao[0].distico;
                viatura_admin.n_identificao = lista_conducao[0].n_identificacao;
                viatura_admin.outros = lista_conducao[0].outros_servicos;
                viatura_admin.portao = lista_conducao[0].portao_acesso;
                viatura_admin.validade = lista_conducao[0].validade_acesso;
                viatura_admin.rb_checked_by_BD(lista_conducao[0].tipo_de_pedido);
                viatura_admin.estado = lista_conducao[0].estado;
                viatura_admin.acao = "0";
                viatura_admin.enable_tb_n_identificacao = true;
                viatura_admin.conferido = lista_conducao[0].conferido;
                this.ModalPopupExtender1.Show();
            }
        }

        protected void GridView_viatura_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int ID = Convert.ToInt32(GridView_viatura.DataKeys[e.Row.RowIndex].Values[0].ToString());
                    BAL_viatura viatura = new BAL_viatura();
                    LinkButton segunda_via = (LinkButton)e.Row.FindControl("segunda_via");
                    segunda_via.Text = viatura.numero_segunda_via_viatura(ID).ToString();
                    LinkButton renovacao = (LinkButton)e.Row.FindControl("renovacao");
                    renovacao.Text = viatura.numero_renovacao_viatura(ID).ToString();
                    Label Label1 = ((Label)e.Row.FindControl("entidade_identidade"));
                    BAL_entidades entidade = new BAL_entidades();
                    string convert = entidade.get_entidade_by_id(Convert.ToInt32(Label1.Text));
                    Label1.Text = convert;
                    GridView GridView_segunda_via = (GridView)e.Row.Cells[21].FindControl("GridView_segunda_via") as GridView;
                    GridView GridView_renovacao = (GridView)e.Row.Cells[22].FindControl("GridView_renovacao") as GridView;
                    GridView_segunda_via.DataSource = viatura.get_viatura_segunda_via(ID);
                    GridView_segunda_via.DataBind();
                    GridView_renovacao.DataSource = viatura.get_viatura_renovacao(ID);
                    GridView_renovacao.DataBind();
           
                    ImageButton ImageButton_hide = (ImageButton)e.Row.FindControl("ImageButton_hide");
                    ImageButton_hide.Visible = false;
                    Label fotocopia_livrete = (Label)e.Row.FindControl("fotocopia_livrete");
                    Label fotocopia_registop = (Label)e.Row.FindControl("fotocopia_registop");
                    Label fotocopia_cartaverde = (Label)e.Row.FindControl("fotocopia_cartaverde");
                    Label fotocopia_declaracao_segurador = (Label)e.Row.FindControl("fotocopia_declaracao_segurador");
                    Label doc = (Label)e.Row.FindControl("doc");
                    var scriptManager = ScriptManager.GetCurrent(this.Page);
                    ImageButton admin = (ImageButton)e.Row.FindControl("admin");
                    ////////////////////////////REGISTAR POSTBACK DO BOTAO ADMINSITRACAO/////////////////////////////
                    scriptManager.RegisterPostBackControl(admin);

                    ////////////////////////////VERIFICACAO DO VALOR DAS LABELS PARA POR O BOTAO VISIBLE/////////////////////////////
                  
                    if (fotocopia_livrete.Text != "")
                    {
                        ImageButton livrete = (ImageButton)e.Row.FindControl("livrete");
                        livrete.Visible = true;
                    }
                    if (fotocopia_registop.Text != "")
                    {
                        ImageButton registop = (ImageButton)e.Row.FindControl("r_prop");
                        registop.Visible = true;
                    }
                    if (fotocopia_cartaverde.Text != "")
                    {
                        ImageButton cartaverde = (ImageButton)e.Row.FindControl("carta_verde");
                        cartaverde.Visible = true;
                    }
                    if (fotocopia_declaracao_segurador.Text != "")
                    {
                        ImageButton declaracao_segurador = (ImageButton)e.Row.FindControl("d_segurador");
                        declaracao_segurador.Visible = true;
                    }
                    if (doc.Text != "")
                    {
                        ImageButton doc_final = (ImageButton)e.Row.FindControl("doc_final");
                        doc_final.Visible = true;
                    }
                    Label Label_ipo = ((Label)e.Row.FindControl("fotocopia_ipo"));
                    if (Label_ipo.Text != "")
                    {
                        ImageButton ib_ipo = (ImageButton)e.Row.FindControl("ipo");
                        ib_ipo.Visible = true;
                    }
                    Label Label_validade = ((Label)e.Row.FindControl("validade_acesso"));
                    if (Label_validade.Text != "" && Label_validade.Text!="NULL")
                    {
                        if (Convert.ToDateTime(Label_validade.Text) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                        {
                            e.Row.BackColor = System.Drawing.Color.FromName("#fedad9");
                        }
                    }
                    ///////////////////////////////////////ESCONDER O BOTAO DE ADMINISTRACAO EM TDS AS ROWS DA CHILD GRID MENOS A ROW 0 E QD//////////////////
                    ////////////////////////////////////// SE EXISTIR RENOVACAO OU 2º VIA ESCONDER O BOTAO DO DOCUMENTO ORIGINAL////////////////////////
                    if (GridView_segunda_via.Rows.Count > 0)
                    {
                        ImageButton admin_segunda = GridView_segunda_via.Rows[0].FindControl("admin") as ImageButton;
                        admin_segunda.Visible = true;
                        ImageButton doc_final = (ImageButton)e.Row.FindControl("doc_final");
                        doc_final.Visible = false;
                    }
                    if (GridView_renovacao.Rows.Count > 0)
                    {
                        ImageButton admin_renovacao = GridView_renovacao.Rows[0].FindControl("admin") as ImageButton;
                        admin_renovacao.Visible = true;
                        ImageButton doc_final = (ImageButton)e.Row.FindControl("doc_final");
                        doc_final.Visible = false;
                    }
                }
            }
        

        protected void GridView_segunda_via_RowCommand(object sender, GridViewCommandEventArgs e)
        {        
            if (e.CommandName.ToString() == "doc_via")
            {
                ////////////////////////////DOWNLOAD DOCUMENTO FINAL SEGUNDA VIA/////////////////////////////
                GridView GridView_segunda_via = (GridView)GridView_viatura.SelectedRow.Cells[21].FindControl("GridView_segunda_via") as GridView;
                GridView GridView_renovacao = (GridView)GridView_viatura.SelectedRow.Cells[22].FindControl("GridView_renovacao") as GridView;
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path_doc = (Label)GridView_segunda_via.Rows[rowIndex].FindControl("path_doc_segunda_via_viatura");
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path_doc.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[6].ToString() + "&FilePath=" + path_doc.Text);

            }
            if (e.CommandName.ToString() == "admin_via")
            {
                ////////////////////////////ADMINISTAR SEGUNDA VIA/////////////////////////////
                GridView GridView_segunda_via = (GridView)GridView_viatura.SelectedRow.Cells[21].FindControl("GridView_segunda_via") as GridView;
                GridView GridView_renovacao = (GridView)GridView_viatura.SelectedRow.Cells[22].FindControl("GridView_renovacao") as GridView;               
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(GridView_segunda_via.DataKeys[rowIndex].Value);
                int id_viatura = Convert.ToInt32(ViewState["id_pedido"].ToString());
                viatura_admin.Visible = true;                
                BAL_viatura viatura = new BAL_viatura();
                viatura_admin.estado = viatura.estado_via(id);
                List<PROP_viatura> lista_conducao = new List<PROP_viatura>();             
                lista_conducao = viatura.get_viatura_idviatura(id_viatura);
                viatura_admin.id_viatura = lista_conducao[0].idviatura;
                viatura_admin.distico = lista_conducao[0].distico;
                viatura_admin.n_identificao = lista_conducao[0].n_identificacao;
                viatura_admin.outros = lista_conducao[0].outros_servicos;
                viatura_admin.portao = lista_conducao[0].portao_acesso;
                viatura_admin.validade = lista_conducao[0].validade_acesso;
                viatura_admin.rb_checked_by_BD(lista_conducao[0].tipo_de_pedido);
                viatura_admin.acao = "1";
                viatura_admin.id_renovacao = id;
                viatura_admin.enable_tb_n_identificacao = false;
                viatura_admin.conferido = lista_conducao[0].conferido;
                this.ModalPopupExtender1.Show();
            }
        }



        protected void GridView_renovacao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "doc_renovacao")
            {
                ////////////////////////////DOWNLOAD DOCUMENTO DE RENOVACAO/////////////////////////////
                GridView GridView_segunda_via = (GridView)GridView_viatura.SelectedRow.Cells[21].FindControl("GridView_segunda_via") as GridView;
                GridView GridView_renovacao = (GridView)GridView_viatura.SelectedRow.Cells[22].FindControl("GridView_renovacao") as GridView;
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path_doc = (Label)GridView_renovacao.Rows[rowIndex].FindControl("path_doc_renovacao_viatura");
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path_doc.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[6].ToString() + "&FilePath=" + path_doc.Text);

            }
           
            if (e.CommandName.ToString() == "fotocopia_cartao")
            {
                GridView GridView_segunda_via = (GridView)GridView_viatura.SelectedRow.Cells[21].FindControl("GridView_segunda_via") as GridView;
                GridView GridView_renovacao = (GridView)GridView_viatura.SelectedRow.Cells[21].FindControl("GridView_renovacao") as GridView;               
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path_doc = (Label)GridView_renovacao.Rows[rowIndex].FindControl("path_fotocopia_cartao_circulacao");
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path_doc.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path_doc.Text);
    

            }

            if (e.CommandName.ToString() == "admin_renovacao")
            {
                ////////////////////////////ADMINISTRAR RENOVACAO/////////////////////////////
                GridView GridView_segunda_via = (GridView)GridView_viatura.SelectedRow.Cells[21].FindControl("GridView_segunda_via") as GridView;
                GridView GridView_renovacao = (GridView)GridView_viatura.SelectedRow.Cells[22].FindControl("GridView_renovacao") as GridView;               
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex; 
           
                int id = Convert.ToInt32(GridView_renovacao.DataKeys[rowIndex].Value);
                int id_viatura = Convert.ToInt32(ViewState["id_pedido"].ToString());
                viatura_admin.Visible = true;
                BAL_viatura viatura = new BAL_viatura();
                viatura_admin.estado = viatura.estado_renovacao(id);
                List<PROP_viatura> lista_conducao = new List<PROP_viatura>();
                lista_conducao = viatura.get_viatura_idviatura(id_viatura);
                viatura_admin.id_viatura = lista_conducao[0].idviatura;
                viatura_admin.distico = lista_conducao[0].distico;
                viatura_admin.n_identificao = lista_conducao[0].n_identificacao;
                viatura_admin.outros = lista_conducao[0].outros_servicos;
                viatura_admin.portao = lista_conducao[0].portao_acesso;
                viatura_admin.validade = lista_conducao[0].validade_acesso;
                viatura_admin.rb_checked_by_BD(lista_conducao[0].tipo_de_pedido);
                viatura_admin.acao = "2";
                viatura_admin.id_renovacao = id;
                viatura_admin.enable_tb_n_identificacao = false;
                viatura_admin.conferido = lista_conducao[0].conferido;
                ////////////////////////////MOSTRAR MODALPOPUPEXTENDER/////////////////////////////
                this.ModalPopupExtender1.Show();

            }
       
        }

       

        protected void GridView_child_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
       
        
        }
     
             protected void RB_filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////////////////////////////FILTROS/////////////////////////////
            foradeprazo();
            if (RB_filtro.SelectedIndex == 0)
            {
                tb_pesq_num.Visible = true;
                ddl_estado.Visible = false;
                tb_matricula.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = false;
                ddl_entidade.Visible = false; 
                ImageButton4.Visible = false; 
                ImageButton3.Visible = true;
                ImageButton1.Visible = false; 
                ImageButton2.Visible = false;
            }
            if (RB_filtro.SelectedIndex == 1)
            {
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = false;
                tb_matricula.Visible = false;
                ib_data.Visible = true;
                tb_data.Visible = true;
                ib_pesq.Visible = false;
                ddl_entidade.Visible = false;
                ImageButton3.Visible = false; 
                ImageButton4.Visible = true; 
                ImageButton1.Visible = false;
                ImageButton2.Visible = false;
            }
            if (RB_filtro.SelectedIndex == 3)
            {
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = true;
                tb_matricula.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = false;
                ddl_entidade.Visible = false; 
                ImageButton2.Visible = false;
                ImageButton1.Visible = true; 
                ImageButton3.Visible = false; 
                ImageButton4.Visible = false;

            }
            if (RB_filtro.SelectedIndex == 2)
            {
                tb_matricula.Visible = true;
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = false;
                ddl_entidade.Visible = false;
                ImageButton3.Visible = false;
                ImageButton4.Visible = false;
                ImageButton1.Visible = false;
                ImageButton2.Visible = true;
            }
            if (RB_filtro.SelectedIndex == 4)
            {
                tb_matricula.Visible = false;
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = true;
                ddl_entidade.Visible = true;
                ImageButton4.Visible = false;
                ImageButton3.Visible = false;
                ImageButton2.Visible = false; 
                ImageButton1.Visible = false;
                carrega_entidade();
            }
        }

        protected void ImageButton_filtros_Click(object sender, ImageClickEventArgs e)
        {
            if (Panel_filtros.Visible == true)
            {
                Panel_filtros.Visible = false;
                GridView_viatura.AllowPaging = true;
                carrega_grid();
            }
            else
            {
                Panel_filtros.Visible = true;
                GridView_viatura.AllowPaging = false;
                carrega_grid();
            }
        }

        protected void ib_pesq_Click(object sender, ImageClickEventArgs e)
        {
            ////////////////////////////BOTAO DE FILTRAR/////////////////////////////
            int i = 0;
            if (RB_filtro.SelectedIndex == 0)
            {
                while (i < GridView_viatura.Rows.Count)
                {
                    Label num = GridView_viatura.Rows[i].FindControl("lbnum") as Label;
                    if (num.Text == tb_pesq_num.Text)
                        GridView_viatura.Rows[i].Visible = true;
                    else
                        GridView_viatura.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 1)
            {
                while (i < GridView_viatura.Rows.Count)
                {
                    Label lbdatareg = GridView_viatura.Rows[i].FindControl("lbdatareg") as Label;
                    if (lbdatareg.Text == tb_data.Text)
                        GridView_viatura.Rows[i].Visible = true;
                    else
                        GridView_viatura.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 3)
            {
                while (i < GridView_viatura.Rows.Count)
                {
                    Label lbl_estado = GridView_viatura.Rows[i].FindControl("lbl_estado") as Label;
                    if (lbl_estado.Text == ddl_estado.SelectedValue.ToString())
                        GridView_viatura.Rows[i].Visible = true;
                    else
                        GridView_viatura.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 2)
            {

                while (i < GridView_viatura.Rows.Count)
                {
                    Label matricula = GridView_viatura.Rows[i].FindControl("lbmatricula") as Label;
                    if (matricula.Text == tb_matricula.Text.ToUpper())
                        GridView_viatura.Rows[i].Visible = true;
                    else
                        GridView_viatura.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 4)
            {
                while (i < GridView_viatura.Rows.Count)
                {
                    Label entidade_identidade = GridView_viatura.Rows[i].FindControl("entidade_identidade") as Label;
                    if (entidade_identidade.Text == ddl_entidade.SelectedValue.ToString())
                        GridView_viatura.Rows[i].Visible = true;
                    else
                        GridView_viatura.Rows[i].Visible = false;
                    i++;
                }
            }
        }
        ////////////////////////////CARREGAR DDL ENTIDADE/////////////////////////////
        public void carrega_entidade()
        {

            BAL_entidades entidade = new BAL_entidades();
            List<PROP_entidade> entidades = new List<PROP_entidade>();
            entidades = entidade.get_entidade(null);
            ddl_entidade.DataSource = entidades;
            ddl_entidade.DataTextField = "nome";
            ddl_entidade.DataBind();
            ddl_entidade.Items.Insert(0, "Selecione");
        }

        ////////////////////////////MANTER A COR NOS FORA DE PRAZO/////////////////////////////
        protected void foradeprazo()
        {
            foreach (GridViewRow row in GridView_viatura.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (row.FindControl("validade_acesso")!=null)
                    {
                    Label Label_validade = ((Label)row.FindControl("validade_acesso"));
                    if (Label_validade.Text != "" && Label_validade.Text!="NULL")
                    {
                        if (Convert.ToDateTime(Label_validade.Text) < Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                        {
                            row.BackColor =  System.Drawing.ColorTranslator.FromHtml("#fedad9");
                        }
                    }
                    }
                }
            }
        }

        protected void GridView_viatura_DataBound(object sender, EventArgs e)
        {
            ApplyPaging();
            try
            {
                GridViewRow PagerRow = GridView_viatura.BottomPagerRow;
                Label b = (Label)PagerRow.FindControl("Label_pager_status");
                b.Text = "Página " + (GridView_viatura.PageIndex + 1) + " de " + GridView_viatura.PageCount; ;
            }
            catch { }
        }

        protected void GridView_segunda_via_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }
      

    }
}