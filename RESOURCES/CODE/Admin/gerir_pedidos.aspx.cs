using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.BAL;
using iTextSharp;
using WebApplication10.DAL;
using WebApplication10.PROP;




namespace WebApplication10.Admin
{
    public partial class gerir_pedidos : System.Web.UI.Page
    {
        public bool display_edit { get; set; }
        //int row_grid_principal;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (GridView_conducao.AllowPaging == true)
                ApplyPaging();
            }
            else
            {
                carrega_grid_conducao();
            }
        }

        ////////////////////////////PAGINAMENTO/////////////////////////////
        private void ApplyPaging()
        {
            try
            {
                GridViewRow row = GridView_conducao.BottomPagerRow;
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
                if (GridView_conducao.PageIndex == 0)
                {
                    lnkFirstPage.Enabled = false;
                    lnkPrevPage.Enabled = false;
                }
                for (int i = 1; i <= GridView_conducao.PageCount; i++)
                {
                    lnkPaging = new LinkButton();
                    lnkPaging.Width = Unit.Pixel(22);
                    lnkPaging.Height = Unit.Pixel(22);
                    lnkPaging.CssClass = "LinkPaging";
                    lnkPaging.Text = i.ToString();
                    lnkPaging.ToolTip = "Página " + i;
                    lnkPaging.CommandName = "Page";
                    lnkPaging.CommandArgument = i.ToString();
                    if (i == GridView_conducao.PageIndex + 1)
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
                if (GridView_conducao.PageIndex == GridView_conducao.PageCount - 1)
                {
                    lnkNextPage.Enabled = false;
                    lnkLastPage.Enabled = false;
                }
            }
            catch { }
        }

        protected void carrega_grid_conducao()
        {
            ////////////////////////////CARREGAR GRIDVIEW CONDUCAO/////////////////////////////
            BAL_conducao conducao = new BAL_conducao();
            GridView_conducao.DataSource = conducao.get_all_conducao();
            GridView_conducao.DataBind();
        }

        protected void carrega_grid_conducao_via(int idpedido, GridView GridView_segunda_via)
        {
            ////////////////////////////SEGUNDA VIA CONDUCAO/////////////////////////////
            BAL_conducao conducao = new BAL_conducao();
            GridView_segunda_via.DataSource = conducao.get_conducao_segunda_via(idpedido);
            GridView_segunda_via.DataBind();
        }

        protected void carrega_grid_renovacao(int idpedido, GridView GridView_renovacao)
        {
            ////////////////////////////RENOVACAO CONDUCAO/////////////////////////////
            BAL_conducao conducao = new BAL_conducao();
            GridView_renovacao.DataSource = conducao.get_renovacao(idpedido);
            GridView_renovacao.DataBind();
        }
        protected void GridView_conducao_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                ////////////////////////////ALTERAR COR DAS GRIDVIEWS/////////////////////////////
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }

            if (e.Row.RowType == DataControlRowType.DataRow && GridView_conducao.EditIndex == e.Row.RowIndex)
            {
                Label estado = e.Row.FindControl("lbl_estado") as Label;
                DropDownList ddl_estado = (DropDownList)e.Row.FindControl("ddl_estado");
                ddl_estado.Items.Insert(0, "Pendente");
                ddl_estado.Items.Insert(1, "Activo");
                ddl_estado.Items.Insert(2, "Diferido");
                ddl_estado.Items.Insert(3, "Inactivo");
                ddl_estado.Items.FindByValue((e.Row.FindControl("lbl_estado") as Label).Text).Selected = true;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Label1 = ((Label)e.Row.FindControl("entidade_identidade"));
                BAL_entidades entidade = new BAL_entidades();
                string convert = entidade.get_entidade_by_id(Convert.ToInt32(Label1.Text));
                Label1.Text = convert;
                int ID = Convert.ToInt32(GridView_conducao.DataKeys[e.Row.RowIndex].Values[0].ToString());
                BAL_conducao conducao = new BAL_conducao();
                LinkButton segunda_via = (LinkButton)e.Row.FindControl("segunda_via");
                segunda_via.Text = conducao.numero_segunda_via_conducao(ID).ToString();
                LinkButton renovacao = (LinkButton)e.Row.FindControl("renovacao");
                renovacao.Text = conducao.numero_renovacao_conducao(ID).ToString();
                GridView GridView_segunda_via = (GridView)e.Row.Cells[15].FindControl("GridView_segunda_via") as GridView;
                GridView GridView_renovacao = (GridView)e.Row.Cells[16].FindControl("GridView_renovacao") as GridView;
                ImageButton ImageButton_hide = (ImageButton)e.Row.FindControl("ImageButton_hide");
                ImageButton_hide.Visible = false;
                
                Label lb_cartao_acl = (Label)e.Row.FindControl("lb_cartao_acl");
                Label lb_carta_conducao = (Label)e.Row.FindControl("lb_carta_conducao");
                ////////////////////////////VERIFICA SE AS LABELS TEM VALOR E SE TIVEREM POE O BOTAO DA GRIDVIEW VISIVEL/////////////////////////////
                if (lb_cartao_acl.Text != "")
                {
                    ImageButton cartao_acl = (ImageButton)e.Row.FindControl("cartao_acl");
                    cartao_acl.Visible = true;
                }
                if (lb_carta_conducao.Text != "")
                {
                    ImageButton carta_conducao = (ImageButton)e.Row.FindControl("carta_conducao");
                    carta_conducao.Visible = true;
                }
                GridView_renovacao.DataSource = conducao.get_renovacao(ID); ;
                GridView_renovacao.DataBind();
                GridView_segunda_via.DataSource = conducao.get_conducao_segunda_via(ID);
                GridView_segunda_via.DataBind();
                if (GridView_segunda_via.Rows.Count > 0)
                {

                    ImageButton path_doc_final = (ImageButton)e.Row.FindControl("doc_final");
                    path_doc_final.Visible = false;

                }
                if (GridView_renovacao.Rows.Count > 0)
                {

                    ImageButton path_doc_final = (ImageButton)e.Row.FindControl("doc_final");
                    path_doc_final.Visible = false;

                }
               
            }
        }

        protected void GridView_conducao_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ////////////////////////////ADMINISTRACAO DA CONDUCAO ROW EDITING/////////////////////////////
            GridView_conducao.EditIndex = e.NewEditIndex;
            carrega_grid_conducao();
            GridView_conducao.Rows[e.NewEditIndex].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            GridView_conducao.SelectedIndex = e.NewEditIndex;
            GridView_conducao.SelectedRow.Attributes.Remove("onmouseover");   
        }

        protected void GridView_conducao_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ////////////////////////////CANCELAR EDICAO/////////////////////////////
            GridView_conducao.EditIndex = -1;
            carrega_grid_conducao();
        }
        protected void GridView_conducao_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ////////////////////////////ACTUALIZAR CONDUCAO/////////////////////////////
            string estado = (GridView_conducao.Rows[e.RowIndex].FindControl("ddl_estado") as DropDownList).SelectedValue;
            int id = Convert.ToInt32(GridView_conducao.DataKeys[e.RowIndex].Value.ToString());
            string soa = (GridView_conducao.Rows[e.RowIndex].FindControl("TextBox_soa") as TextBox).Text;
            string soa_nome = (GridView_conducao.Rows[e.RowIndex].FindControl("TextBox_soa_nome") as TextBox).Text;
            Label path_doc = (Label)GridView_conducao.Rows[e.RowIndex].FindControl("doc");
            string fileName = path_doc.Text;
            BAL_conducao conducao = new BAL_conducao();

            ////////////////////////////COLOCAR MARCA DE AGUA NO PDF JA EXISTENTE/////////////////////////////

            PdfReader reader = new PdfReader(fileName);
            using (var ms = new MemoryStream())
            {
                using (PdfStamper stamper = new PdfStamper(reader, ms))
                {

                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    Font f2 = new Font(bf, 8, Font.NORMAL, BaseColor.DARK_GRAY);
                    PdfContentByte canvas = stamper.GetOverContent(1);
                    //canvas.SetColorFill(iTextSharp.text.BaseColor.WHITE);
                    ColumnText.ShowTextAligned(
                      canvas,
                      Element.ALIGN_LEFT,
                      new Phrase(soa_nome.Trim(), f2),
                      370, 107, 0);
                    ColumnText.ShowTextAligned(
                      canvas,
                      Element.ALIGN_LEFT,
                      new Phrase(soa.Trim(), f2),
                      400, 127, 0);
                    stamper.Close();
                }
                byte[] data = ms.ToArray();
                reader.Close();
                Response.ClearHeaders();
                Response.Clear();
                save.SaveFile(data, fileName);
            }
            if (estado == "Inactivo")
            {
                ////////////////////////////AO COLOCAR O PEDIDO PRINCIPAL EM INACTIVO COLOCAR AS CHILDGRIDS/////////////////////////////
                conducao.update_estado_inativo_conducao(id);
            }
            conducao.update_estado_pedido_conducao(id, estado, soa, soa_nome);
            GridView_conducao.EditIndex = -1;
            carrega_grid_conducao();
        }

        protected void GridView_conducao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
         
            if (e.CommandName.ToString() == "send_email")
            {
                acessos MyMasterPage = (acessos)Page.Master; 
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(GridView_conducao.DataKeys[rowIndex].Value);
                BAL_conducao conducao = new BAL_conducao();
                conducao.email_based_idpedido(id);
            
                    ///////////////////////ACEDER MASTER PAGE/////////////////////////////////
                MyMasterPage.painel_email = conducao.email_based_idpedido(id).ToString();
                Label path_cartao_acl = (Label)GridView_conducao.Rows[rowIndex].FindControl("lb_cartao_acl");
                Label path_carta_conducao = (Label)GridView_conducao.Rows[rowIndex].FindControl("lb_carta_conducao");
                Label doc_final = (Label)GridView_conducao.Rows[rowIndex].FindControl("doc");
                string[] docs_upload = { path_cartao_acl.Text, path_carta_conducao.Text, doc_final.Text };
                MyMasterPage.documentos_conducao = docs_upload;         
            }

            if (e.CommandName.ToString() == "hide")
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Panel Panel_segunda_via = gvr.FindControl("Panel_segunda_via") as Panel;
                Panel Panel_renovacao = gvr.FindControl("Panel_renovacao") as Panel;
                Panel_segunda_via.Visible = false;
                Panel_renovacao.Visible = false;
                display_edit = true;
                int rowIndex = gvr.RowIndex;
                this.GridView_conducao.Columns[16].Visible = true;
                ImageButton ImageButton_hide = (ImageButton)GridView_conducao.Rows[rowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = false;
                GridView_conducao.SelectedIndex = -1;
                int DemoId = Convert.ToInt32(gvr.RowIndex.ToString());
                GridView_conducao.Rows[DemoId].BackColor = System.Drawing.ColorTranslator.FromHtml("#e8e8e8");
                GridView_conducao.Rows[DemoId].ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d4465");
                GridView_conducao.Rows[DemoId].Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");
            }

            if (e.CommandName.ToString() == "renovacao")
            {
                ////////////////////////////RENOVACAO DE CONDUCAO/////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(GridView_conducao.DataKeys[rowIndex].Value);
                ViewState["id_pedido"] = id;
                Panel Panel_segunda_via = gvr.FindControl("Panel_segunda_via") as Panel;
                Panel Panel_renovacao = gvr.FindControl("Panel_renovacao") as Panel;
                Panel_segunda_via.Visible = false;
                Panel_renovacao.Visible = true;
                GridView_conducao.SelectedIndex = rowIndex;
                this.GridView_conducao.Columns[16].Visible = false;
                ImageButton ImageButton_hide = (ImageButton)GridView_conducao.Rows[rowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = true;
                GridView_conducao.SelectedIndex = rowIndex;
                GridView_conducao.Rows[rowIndex].BackColor = System.Drawing.ColorTranslator.FromHtml("#0d4365");
                GridView_conducao.Rows[rowIndex].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                GridView_conducao.SelectedRow.Attributes.Remove("onmouseover");
            }

            if (e.CommandName.ToString() == "segunda_via")
            {
                ////////////////////////////SEGUNDA VIA DE CONDUCAO/////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(GridView_conducao.DataKeys[rowIndex].Value);
                ViewState["id_pedido"] = id;
                Panel Panel_segunda_via = gvr.FindControl("Panel_segunda_via") as Panel;
                Panel Panel_renovacao = gvr.FindControl("Panel_renovacao") as Panel;
                Panel_segunda_via.Visible = true;
                Panel_renovacao.Visible = false;
                GridView_conducao.SelectedIndex = rowIndex;
                this.GridView_conducao.Columns[16].Visible = false;
                ImageButton ImageButton_hide = (ImageButton)GridView_conducao.Rows[rowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = true;
                GridView_conducao.SelectedIndex = rowIndex;
                GridView_conducao.Rows[rowIndex].BackColor = System.Drawing.ColorTranslator.FromHtml("#0d4365");
                GridView_conducao.Rows[rowIndex].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                GridView_conducao.SelectedRow.Attributes.Remove("onmouseover");
            }

            if (e.CommandName.ToString() == "cartao_acl")
            {
                ////////////////////////////DOWNLOAD CARTAO /////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path_cartao_acl = (Label)GridView_conducao.Rows[rowIndex].FindControl("lb_cartao_acl");       
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path_cartao_acl.Text.Split(separator); 
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path_cartao_acl.Text);
            }

            if (e.CommandName.ToString() == "cartao_conducao")
            {
                ////////////////////////////DOWNLOAD CARTA CONDUCAO/////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path_carta_conducao = (Label)GridView_conducao.Rows[rowIndex].FindControl("lb_carta_conducao");  
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path_carta_conducao.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path_carta_conducao.Text);
            }
            if (e.CommandName.ToString() == "doc")
            {
                ////////////////////////////DOWNLOAD DOCUMENTO/////////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path_carta_conducao = (Label)GridView_conducao.Rows[rowIndex].FindControl("doc");
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path_carta_conducao.Text.Split(separator);
             Response.Redirect( "ReportDownload.aspx?FileName=" + strSplitArr[5].ToString() + "&FilePath=" + path_carta_conducao.Text);
            }

        }
    
        /////////////////////////////////2ºvia/////////////////////////////
        protected void GridView_segunda_via_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView GridView_segunda_via = (GridView)GridView_conducao.SelectedRow.Cells[15].FindControl("GridView_segunda_via") as GridView;
            GridView_segunda_via.EditIndex = e.NewEditIndex;
            carrega_grid_conducao_via(Convert.ToInt32(ViewState["id_pedido"].ToString()), GridView_segunda_via);
        }
        ////////////////////////////ATUALIZACAO DA INFORMACAO DA SEGUNDA VIA/////////////////////////////
        protected void GridView_segunda_via_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridView GridView_segunda_via = (GridView)GridView_conducao.SelectedRow.Cells[15].FindControl("GridView_segunda_via") as GridView;
            string estado = (GridView_segunda_via.Rows[e.RowIndex].FindControl("ddl_estado_via") as DropDownList).SelectedValue;
            int id = Convert.ToInt32(GridView_segunda_via.DataKeys[e.RowIndex].Value.ToString());
            BAL_conducao conducao = new BAL_conducao();
            conducao.update_estado_via_conducao(id, estado);
            GridView_segunda_via.EditIndex = -1;
            carrega_grid_conducao_via(Convert.ToInt32(ViewState["id_pedido"].ToString()), GridView_segunda_via);
        }
        ////////////////////////////CANCELAR EDICAO DA SEGUNDA VIA/////////////////////////////
        protected void GridView_segunda_via_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView GridView_segunda_via = (GridView)GridView_conducao.SelectedRow.Cells[15].FindControl("GridView_segunda_via") as GridView;
            GridView_segunda_via.EditIndex = -1;
            carrega_grid_conducao_via(Convert.ToInt32(ViewState["id_pedido"].ToString()), GridView_segunda_via);
        }

        protected void GridView_segunda_via_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "doc_via")
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                GridView GridView_segunda_via = (GridView)GridView_conducao.SelectedRow.Cells[16].FindControl("GridView_segunda_via") as GridView;
                Label path_doc = (Label)GridView_segunda_via.Rows[rowIndex].FindControl("path_doc_segunda_via_conducao");
                ////////////////////////////DOWNLOAD DOCUMENTO DA SEGUNDA VIA/////////////////////////////
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path_doc.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[6].ToString() + "&FilePath=" + path_doc.Text);
            }
        }

        protected void GridView_segunda_via_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (GridView_conducao.SelectedRow != null)
                {
                    GridView GridView_segunda_via = (GridView)GridView_conducao.SelectedRow.FindControl("GridView_segunda_via") as GridView;
                    if (e.Row.RowType == DataControlRowType.DataRow && GridView_segunda_via.EditIndex == e.Row.RowIndex)
                    {
                        DropDownList ddl_estado_via = (DropDownList)e.Row.FindControl("ddl_estado_via");
                        ddl_estado_via.Items.Insert(0, "Pendente");
                        ddl_estado_via.Items.Insert(1, "Activo");
                        ddl_estado_via.Items.Insert(2, "Diferido");
                        ddl_estado_via.Items.Insert(3, "Inactivo");
                        ddl_estado_via.Items.FindByValue("Inactivo").Enabled = false;
                        ddl_estado_via.Items.FindByValue((e.Row.FindControl("lbl_estado_via") as Label).Text).Selected = true;
                    }
                }
            }
            catch { }
        }
        /////////////////////////////////renovacao/////////////////////////////
        protected void GridView_renovacao_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (GridView_conducao.SelectedRow != null)
                {
                    GridView GridView_renovacao = (GridView)GridView_conducao.SelectedRow.FindControl("GridView_renovacao") as GridView;
                    if (e.Row.RowType == DataControlRowType.DataRow && GridView_renovacao.EditIndex == e.Row.RowIndex)
                    {
                        DropDownList ddl_estado_renovacao = (DropDownList)e.Row.FindControl("ddl_estado_renovacao");
                        ddl_estado_renovacao.Items.Insert(0, "Pendente");
                        ddl_estado_renovacao.Items.Insert(1, "Activo");
                        ddl_estado_renovacao.Items.Insert(2, "Diferido");
                        ddl_estado_renovacao.Items.Insert(3, "Inactivo");
                        ddl_estado_renovacao.Items.FindByValue("Inactivo").Enabled = false;
                        ddl_estado_renovacao.Items.FindByValue((e.Row.FindControl("lbl_estado_renovacao") as Label).Text).Selected = true;

                    }
                }
            }
            catch { }
        }
        ////////////////////////////CANCELAR EDICAO DA RENOVACAO/////////////////////////////
        protected void GridView_renovacao_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView GridView_renovacao = (GridView)GridView_conducao.SelectedRow.FindControl("GridView_renovacao") as GridView;
            GridView_renovacao.EditIndex = -1;
            carrega_grid_renovacao(Convert.ToInt32(ViewState["id_pedido"].ToString()), GridView_renovacao);
        }
        ////////////////////////////EDICAO RENOVACAO/////////////////////////////
        protected void GridView_renovacao_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView GridView_renovacao = (GridView)GridView_conducao.SelectedRow.FindControl("GridView_renovacao") as GridView;
            GridView_renovacao.EditIndex = e.NewEditIndex;
            carrega_grid_renovacao(Convert.ToInt32(ViewState["id_pedido"].ToString()), GridView_renovacao);
        }
        ////////////////////////////ATUALIZACAO DA INFORMACAO DE RENOVACAO/////////////////////////////
        protected void GridView_renovacao_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridView GridView_renovacao = (GridView)GridView_conducao.SelectedRow.FindControl("GridView_renovacao") as GridView;
            string estado = (GridView_renovacao.Rows[e.RowIndex].FindControl("ddl_estado_renovacao") as DropDownList).SelectedValue;
            int id = Convert.ToInt32(GridView_renovacao.DataKeys[e.RowIndex].Value.ToString());
            BAL_conducao conducao = new BAL_conducao();
            conducao.update_estado_renovacao_conducao(id, estado);
            GridView_renovacao.EditIndex = -1;
            carrega_grid_renovacao(Convert.ToInt32(ViewState["id_pedido"].ToString()), GridView_renovacao);
        }

      
        protected void GridView_renovacao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "doc_renovacao")
            {
                ////////////////////////////DOWNLOAD DOCUMENTO FINAL RENOVACAO/////////////////////////////
                GridView GridView_renovacao = (GridView)GridView_conducao.SelectedRow.FindControl("GridView_renovacao") as GridView;
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                Label path_doc = (Label)GridView_renovacao.Rows[rowIndex].FindControl("path_doc_renovacao_conducao");
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path_doc.Text.Split(separator);
                Response.Redirect("ReportDownload.aspx?FileName=" + strSplitArr[6].ToString() + "&FilePath=" + path_doc.Text);
            }
        }

        protected void GridView_conducao_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ////////////////////////////PAGINAMENTO/////////////////////////////
            GridView_conducao.PageIndex = e.NewPageIndex;
            carrega_grid_conducao();
        }
        protected void GridView_child_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");
            // when mouse leaves the row, change the bg color to its original value  
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
        protected void ImageButton_filtros_Click(object sender, ImageClickEventArgs e)
        {
            ////////////////////////////FILTROS/////////////////////////////
            if (Panel_filtros.Visible == true)
            {
                Panel_filtros.Visible = false;
                GridView_conducao.AllowPaging = true;
                carrega_grid_conducao();
            }
            else
            {
                Panel_filtros.Visible = true;
                GridView_conducao.AllowPaging = false;
                carrega_grid_conducao();
            }
        }

        protected void RB_filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////////////////////////////RADIOBUTTON ALTERACAO DE INDEX/////////////////////////////
            if (RB_filtro.SelectedIndex == 0)
            {
                tb_pesq_num.Visible = true;
                ddl_estado.Visible = false;
                tb_nome.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = false;
                ddl_entidade.Visible = false;
                ImageButton1.Visible = false;
                ImageButton2.Visible = false;
                ImageButton4.Visible = false;
                ImageButton3.Visible = true;
            }
            if (RB_filtro.SelectedIndex == 1)
            {
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = false;
                tb_nome.Visible = false;
                ib_data.Visible = true;
                tb_data.Visible = true;
                ib_pesq.Visible = false;
                ddl_entidade.Visible = false;
                ImageButton1.Visible = false;
                ImageButton2.Visible = false;
                ImageButton4.Visible = true;
                ImageButton3.Visible = false;

            }
            if (RB_filtro.SelectedIndex == 3)
            {
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = true;
                tb_nome.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = false;
                ddl_entidade.Visible = false;
                ImageButton1.Visible = true;
                ImageButton2.Visible = false;
                ImageButton4.Visible = false;
                ImageButton3.Visible = false;

            }
            if (RB_filtro.SelectedIndex == 2)
            {
                tb_nome.Visible = true;
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = false;
                ddl_entidade.Visible = false;
                ImageButton1.Visible = false;
                ImageButton2.Visible = true;
                ImageButton4.Visible = false;
                ImageButton3.Visible = false;

            }
            if (RB_filtro.SelectedIndex == 4)
            {
                tb_nome.Visible = false;
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = true;
                ddl_entidade.Visible = true;
                ImageButton1.Visible = false;
                ImageButton2.Visible = false;
                ImageButton4.Visible = false;
                ImageButton3.Visible = false;
                carrega_entidade();
            }
        }

        protected void ib_pesq_Click(object sender, ImageClickEventArgs e)
        {
            ////////////////////////////PESQUISAR IMAGEM/////////////////////////////
            int i = 0;
            if (RB_filtro.SelectedIndex == 0)
            {
                while (i < GridView_conducao.Rows.Count)
                {
                    Label num = GridView_conducao.Rows[i].FindControl("lbnum") as Label;
                    if (num.Text == tb_pesq_num.Text)
                        GridView_conducao.Rows[i].Visible = true;
                    else
                        GridView_conducao.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 1)
            {
                while (i < GridView_conducao.Rows.Count)
                {
                    Label lbdatareg = GridView_conducao.Rows[i].FindControl("lbdatareg") as Label;
                    if (lbdatareg.Text == tb_data.Text)
                        GridView_conducao.Rows[i].Visible = true;
                    else
                        GridView_conducao.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 3)
            {
                while (i < GridView_conducao.Rows.Count)
                {
                    Label lbl_estado = GridView_conducao.Rows[i].FindControl("lbl_estado") as Label;
                    if (lbl_estado.Text == ddl_estado.SelectedValue.ToString())
                        GridView_conducao.Rows[i].Visible = true;
                    else
                        GridView_conducao.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 2)
            {
                BAL_conducao conducao = new BAL_conducao();
                GridView_conducao.DataSource = conducao.filtro_conducao_by_nome(tb_nome.Text);
                GridView_conducao.DataBind();
            }
            if (RB_filtro.SelectedIndex == 4)
            {
                while (i < GridView_conducao.Rows.Count)
                {
                    Label entidade_identidade = GridView_conducao.Rows[i].FindControl("entidade_identidade") as Label;
                    if (entidade_identidade.Text == ddl_entidade.SelectedValue.ToString())
                        GridView_conducao.Rows[i].Visible = true;
                    else
                        GridView_conducao.Rows[i].Visible = false;
                    i++;
                }
            }
        }
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

        protected void GridView_conducao_DataBound(object sender, EventArgs e)
        {
            ApplyPaging();
            try
            {
                GridViewRow PagerRow = GridView_conducao.BottomPagerRow;
                Label b = (Label)PagerRow.FindControl("Label_pager_status");
                b.Text = "Página " + (GridView_conducao.PageIndex + 1) + " de " + GridView_conducao.PageCount; ;
            }
            catch { }
        }

      
    }
}