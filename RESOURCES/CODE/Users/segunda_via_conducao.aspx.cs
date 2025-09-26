﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.BAL;
using WebApplication10.PROP;

namespace WebApplication10.Users
{
    public partial class segunda_via_conducao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (GridView1.AllowPaging == true)
                ApplyPaging();
            }
            else
            { 

                carrega_grid_conducao();
            }
        }

        //PAGINAMENTO//
        private void ApplyPaging()
        {
            try
            {
                GridViewRow row = GridView1.BottomPagerRow;
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
                if (GridView1.PageIndex == 0)
                {
                    lnkFirstPage.Enabled = false;
                    lnkPrevPage.Enabled = false;
                }
                for (int i = 1; i <= GridView1.PageCount; i++)
                {
                    lnkPaging = new LinkButton();
                    lnkPaging.Width = Unit.Pixel(22);
                    lnkPaging.Height = Unit.Pixel(22);
                    lnkPaging.CssClass = "LinkPaging";
                    lnkPaging.Text = i.ToString();
                    lnkPaging.ToolTip = "Página " + i;
                    lnkPaging.CommandName = "Page";
                    lnkPaging.CommandArgument = i.ToString();
                    if (i == GridView1.PageIndex + 1)
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
                if (GridView1.PageIndex == GridView1.PageCount - 1)
                {
                    lnkNextPage.Enabled = false;
                    lnkLastPage.Enabled = false;
                }
            }
            catch { }
        }

        //CARREGAR GRIDCONDUCAO//
        protected void carrega_grid_conducao()
        {
            BAL_conducao conducao = new BAL_conducao();
            GridView1.DataSource = conducao.get_conducao_by_entidade(Convert.ToInt32(Session["identidade"]));
            GridView1.DataBind();
           
        }

        //PESQUISAR FILTROS//
        protected void ib_pesq_Click(object sender, ImageClickEventArgs e)
        {
            int i = 0;
            if (RB_filtro.SelectedIndex == 0)
            {
                while (i < GridView1.Rows.Count)
                {
                    if (GridView1.Rows[i].Cells[0].Text == tb_pesq_num.Text)
                        GridView1.Rows[i].Visible = true;
                    else
                        GridView1.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 1)
            {
                while (i < GridView1.Rows.Count)
                {
                    if (GridView1.Rows[i].Cells[1].Text == tb_data.Text)
                        GridView1.Rows[i].Visible = true;
                    else
                        GridView1.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 3)
            {
                while (i < GridView1.Rows.Count)
                {
                    if (GridView1.Rows[i].Cells[3].Text == ddl_estado.SelectedValue.ToString())
                        GridView1.Rows[i].Visible = true;
                    else
                        GridView1.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 2)
            {
                BAL_conducao conducao = new BAL_conducao();
                GridView1.DataSource = conducao.filtro_conducao_by_nome_identidade(tb_nome.Text, Convert.ToInt32(Session["identidade"]));
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "2via")//SEGUNDA VIA
            {
               GridViewRow linha = (GridViewRow)((Control)e.CommandSource).NamingContainer;
               int DemoId = Convert.ToInt32(linha.RowIndex.ToString());
               int ID = Convert.ToInt32(GridView1.DataKeys[linha.RowIndex].Value.ToString());
               conducao_form.Visible = true;
               carregar_tb(ID);
               conducao_form.acao = "1";
               this.ModalPopupExtender1.Show();
            }
            if (e.CommandName.ToString() == "renovacao")//RENOVACAO
            {
                GridViewRow linha = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int DemoId = Convert.ToInt32(linha.RowIndex.ToString());
                int ID = Convert.ToInt32(GridView1.DataKeys[linha.RowIndex].Value.ToString());
                conducao_form.Visible = true;
                carregar_tb(ID);
                conducao_form.acao = "2";
                this.ModalPopupExtender1.Show();
            }
        }

        //CARREGAR TEXTBOX//
        public void carregar_tb(int ID) 
        {
            BAL_entidades entidade = new BAL_entidades();
            BAL_conducao conducao = new BAL_conducao();     
            List<PROP_conducao> lista_conducao = new List<PROP_conducao>();
            lista_conducao = conducao.get_conducao_by_numero_and_entidade(ID);
            conducao_form.numero = lista_conducao[0].numero;
            conducao_form.nome = lista_conducao[0].nome;
            conducao_form.e_patronal = lista_conducao[0].entidade_patronal;
            conducao_form.funcao = lista_conducao[0].funcao;
            conducao_form.num_acesso = lista_conducao[0].n_cartao_acesso;
            conducao_form.carta_conducao = lista_conducao[0].n_carta_conducao;
            conducao_form.categoria = lista_conducao[0].categorias;
            conducao_form.d_emissao = lista_conducao[0].data_emissao;
            conducao_form.l_emissao = lista_conducao[0].local_emissao;
            conducao_form.validade = lista_conducao[0].validade;
            int id_entidade = Convert.ToInt32(lista_conducao[0].entidade_identidade);
            conducao_form.nome_entidade = entidade.get_entidade_by_id(id_entidade);
            conducao_form.categoria_viatura = lista_conducao[0].categoria_viaturas;
            conducao_form.cb_checked_by_BD(lista_conducao[0].areas_circulacao.ToString());
            conducao_form.id_pedido_conducao = ID;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //PAGINAMETNO//
            GridView1.PageIndex = e.NewPageIndex;
            carrega_grid_conducao();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }
        protected void Cancel_Click(object sender, ImageClickEventArgs e)
        {
            //ESCONDER MODAL POPUPEXTENDER//
            this.ModalPopupExtender1.Hide();
        }

        //RADIOBUTTOM FILTROS//
        protected void RB_filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RB_filtro.SelectedIndex == 0)
            {
                tb_pesq_num.Visible = true;
                ddl_estado.Visible = false;
                tb_nome.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = true;
            }
            if (RB_filtro.SelectedIndex == 1)
            {
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = false;
                tb_nome.Visible = false;
                ib_data.Visible = true;
                tb_data.Visible=true;
                ib_pesq.Visible = true;
            }
            if (RB_filtro.SelectedIndex == 3)
            {
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = true;
                tb_nome.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = true;
            }
            if (RB_filtro.SelectedIndex == 2)
            {
                tb_nome.Visible = true;
                tb_pesq_num.Visible = false;
                ddl_estado.Visible = false;
                ib_data.Visible = false;
                tb_data.Visible = false;
                ib_pesq.Visible = true;
            }
        }

        //IMAGEBUTTOM FITLROS//
        protected void ImageButton_filtros_Click(object sender, ImageClickEventArgs e)
        {
            if (Panel_filtros.Visible == true)
            {
                Panel_filtros.Visible = false;
                GridView1.AllowPaging = true;
                carrega_grid_conducao();
            }
            else
            {
                Panel_filtros.Visible = true;
                GridView1.AllowPaging = false;
                carrega_grid_conducao();
            }
        }
        //PAGINAMENTO
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            try
            {
                ApplyPaging();
                GridViewRow PagerRow = GridView1.BottomPagerRow;
                Label b = (Label)PagerRow.FindControl("Label_pager_status");
                b.Text = "Página " + (GridView1.PageIndex + 1) + " de " + GridView1.PageCount; ;
            }
            catch { }
        }
    }
}