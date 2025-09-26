using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.BAL;
using WebApplication10.PROP;

namespace WebApplication10.Users
{
    public partial class segunda_via_viatura : System.Web.UI.Page
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

        //PAGINAMENTO//
          private void ApplyPaging()
        {
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

        //CARREGAR GRIDVIEW//
        protected void carrega_grid()
        {
            BAL_viatura viatura = new BAL_viatura();
            GridView_viatura.DataSource = viatura.get_viatura_by_entidade(Convert.ToInt32(Session["identidade"]));
            GridView_viatura.DataBind();
        }
        //PAGINAMENTO//
        protected void GridView_viatura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_viatura.PageIndex = e.NewPageIndex;
            carrega_grid();
        }

        protected void GridView_viatura_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "2via")//RENOVACAO
            {
                GridViewRow linha = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int DemoId = Convert.ToInt32(linha.RowIndex.ToString());
                int ID = Convert.ToInt32(GridView_viatura.DataKeys[linha.RowIndex].Value.ToString());
                viatura_form.acao = "1";
                viatura_form.Visible = true;
                this.ModalPopupExtender1.Show();
                viatura_form.distico = true;
                viatura_form.ID_viatura = ID;
                carregar_tb(ID);
            }
            if (e.CommandName.ToString() == "renovacao")//VIATURA
            {
                GridViewRow linha = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int DemoId = Convert.ToInt32(linha.RowIndex.ToString());
                int ID = Convert.ToInt32(GridView_viatura.DataKeys[linha.RowIndex].Value.ToString());
                viatura_form.Visible = true;
                carregar_tb(ID);
                viatura_form.acao = "2";
                viatura_form.fileupload_cartao_viatura = true;
                viatura_form.distico = true;
                viatura_form.ID_viatura = ID;
                this.ModalPopupExtender1.Show();
            }
        }
        //CARREGAR TEXTBOX//
        public void carregar_tb(int ID)
        {
            BAL_entidades entidade = new BAL_entidades();
             BAL_viatura viatura = new BAL_viatura();
            List<PROP_viatura> lista_viatura = new List<PROP_viatura>();
            lista_viatura = viatura.get_viatura_renovacao_by_ID(ID);
            viatura_form.numero = lista_viatura[0].numero;
            viatura_form.n_identificacao = lista_viatura[0].n_identificacao;
            viatura_form.marca = lista_viatura[0].marca;
            viatura_form.modelo = lista_viatura[0].modelo;
            viatura_form.cor = lista_viatura[0].cor;
            viatura_form.matricula = lista_viatura[0].matricula;
            viatura_form.proprietario = lista_viatura[0].proprietario;
            viatura_form.apolice = lista_viatura[0].apolice;
            viatura_form.companhia_seguros = lista_viatura[0].companhia_seguro;
            viatura_form.d_seguro = lista_viatura[0].validade_seguro;
            int id_entidade = Convert.ToInt32(lista_viatura[0].entidade_identidade);
            viatura_form.nome_entidade = entidade.get_entidade_by_id(id_entidade);
            viatura_form.servico = lista_viatura[0].servico;
            viatura_form.rb_checked_by_BD(lista_viatura[0].tipo_de_pedido.ToString());
            //viatura_form.validade_acesso = lista_viatura[0].validade_acesso;
            viatura_form.r_distico = lista_viatura[0].distico;
            viatura_form.ipo = lista_viatura[0].ipo;
            viatura_form.validade_ipo = lista_viatura[0].ipo_validade;
             viatura_form.id_pedido_viatura = ID;
     
        }

        protected void GridView_viatura_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                 e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");
                 e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }
        protected void Cancel_Click(object sender, ImageClickEventArgs e)
        {
            //ESCODER MODAL POPUPEXTENDER//
            this.ModalPopupExtender1.Hide();
   
        }
        //RADIOBUTTOM FILTROS//
        protected void RB_filtro_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (RB_filtro.SelectedIndex == 0)
            {
                tb_pesq_num.Visible = true;
                ddl_estado.Visible = false;
                tb_matricula.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = true;
            }
            if (RB_filtro.SelectedIndex == 1)
            {
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = false;
                tb_matricula.Visible = false;
                ib_data.Visible = true;
                tb_data.Visible = true;
                ib_pesq.Visible = true;
            }
            if (RB_filtro.SelectedIndex == 3)
            {
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = true;
                tb_matricula.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = true;
            }
            if (RB_filtro.SelectedIndex == 2)
            {
                tb_matricula.Visible = true;
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = true;
            }
        }
        //IMAGEBUTTOM FILTROS//
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
        //EVENTO DE PESQUISAR NOS FILTOS//
        protected void ib_pesq_Click(object sender, ImageClickEventArgs e)
        {
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
        }
        //PAAGINAMENTO 
        protected void GridView_viatura_DataBound(object sender, EventArgs e)
        {
            ApplyPaging();
            GridViewRow PagerRow = GridView_viatura.BottomPagerRow;
            try
            {
                Label b = (Label)PagerRow.FindControl("Label_pager_status");
                b.Text = "Página " + (GridView_viatura.PageIndex + 1) + " de " + GridView_viatura.PageCount; ;
            }
            catch { }
        }
    }
}