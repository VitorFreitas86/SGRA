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
    public partial class segunda_via_cartao1 : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
          if (IsPostBack)
            {
                if (GridView_cartao.AllowPaging == true)
                ApplyPaging();
            }
            else{

                carrega_cartao();
            }
        }

    //PAGINAMENTPO//
  private void ApplyPaging()
        {
            try
            {
                GridViewRow row = GridView_cartao.BottomPagerRow;
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
                if (GridView_cartao.PageIndex == 0)
                {
                    lnkFirstPage.Enabled = false;
                    lnkPrevPage.Enabled = false;
                }
                for (int i = 1; i <= GridView_cartao.PageCount; i++)
                {
                    lnkPaging = new LinkButton();
                    lnkPaging.Width = Unit.Pixel(22);
                    lnkPaging.Height = Unit.Pixel(22);
                    lnkPaging.CssClass = "LinkPaging";
                    lnkPaging.Text = i.ToString();
                    lnkPaging.ToolTip = "Página " + i;
                    lnkPaging.CommandName = "Page";
                    lnkPaging.CommandArgument = i.ToString();
                    if (i == GridView_cartao.PageIndex + 1)
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
                if (GridView_cartao.PageIndex == GridView_cartao.PageCount - 1)
                {
                    lnkNextPage.Enabled = false;
                    lnkLastPage.Enabled = false;
                }
            }
            catch { }
        }
        //CARREGAR CARTAO//
        protected void carrega_cartao()
        {
            BAL_cartao cartao = new BAL_cartao();
            GridView_cartao.DataSource = cartao.get_cartao_by_entidade(Convert.ToInt32(Session["identidade"]));
            GridView_cartao.DataBind();
        }
        protected void GridView_cartao_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //PAGINAMENTO//
            GridView_cartao.PageIndex = e.NewPageIndex;
            carrega_cartao();
        }

        public void carregar_tb(int ID)//CARREGAR TEXTBOX
        {
            BAL_entidades entidade = new BAL_entidades();
            BAL_cartao cartao = new BAL_cartao();
            List<PROP_cartao> lista_cartao = new List<PROP_cartao>();
            lista_cartao = cartao.get_cartao_renovacao_by_id(ID);
            cartao_form.numero = lista_cartao[0].numero;
            cartao_form.nome = lista_cartao[0].nome;
            cartao_form.id_cartao = ID;
            cartao_form.morada = lista_cartao[0].morada;
            cartao_form.localidade = lista_cartao[0].localidade;
            cartao_form.codigo_postal = lista_cartao[0].codigopostal;
            cartao_form.telefone = lista_cartao[0].telefone;
            cartao_form.telemovel = lista_cartao[0].telemovel;
            cartao_form.tlf_serv = lista_cartao[0].tele_serv;
            cartao_form.nacionalidade = lista_cartao[0].nacionalidade;
            cartao_form.bi = lista_cartao[0].bi;
            cartao_form.validade_bi = lista_cartao[0].validade_cc;
            cartao_form.data_nascimento = lista_cartao[0].data_nascimento;
            cartao_form.email = lista_cartao[0].email;
            cartao_form.patronal = lista_cartao[0].entidade_patronal;
            cartao_form.cat_prof = lista_cartao[0].categ_profissional;
            cartao_form.nacionalidade = lista_cartao[0].nacionalidade;
            cartao_form.nacionalidade = lista_cartao[0].nacionalidade;
            int id_entidade = Convert.ToInt32(lista_cartao[0].entidade_identidade);
            cartao_form.nome_entidade = entidade.get_entidade_by_id(id_entidade);
            cartao_form.rb_checked_by_BD(lista_cartao[0].tipo_de_pedido.ToString());
            cartao_form.renovacao_n_cartao = lista_cartao[0].num_cartao;
            cartao_form.areas_trabalho = lista_cartao[0].area_trabalho;
            cartao_form.funcao = lista_cartao[0].funcao;
            cartao_form.horario = lista_cartao[0].horario;
            cartao_form.acompanhante = lista_cartao[0].nome_acompanhante;
            cartao_form.areas = lista_cartao[0].areas;
            cartao_form.cb_portas_by_bd(lista_cartao[0].autorizacao_portas);
            cartao_form.rb_inquerido_by_BD(lista_cartao[0].inquerito);
            cartao_form.rb_formacao_by_BD(lista_cartao[0].formacao);
        }

        protected void GridView_cartao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
             if (e.CommandName.ToString() == "2via")//INSERIR SEGUNDA VIA
            {
               GridViewRow linha = (GridViewRow)((Control)e.CommandSource).NamingContainer;
               int DemoId = Convert.ToInt32(linha.RowIndex.ToString());
               int ID = Convert.ToInt32(GridView_cartao.DataKeys[linha.RowIndex].Value.ToString());
               cartao_form.Visible = true;
               carregar_tb(ID);
               cartao_form.acao = "1";
               GridView_cartao.SelectedIndex = DemoId;
               this.ModalPopupExtender1.Show();
            }
            if (e.CommandName.ToString() == "renovacao")//INSERIR RENVOACAO
            {
                GridViewRow linha = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int DemoId = Convert.ToInt32(linha.RowIndex.ToString());
                int ID = Convert.ToInt32(GridView_cartao.DataKeys[linha.RowIndex].Value.ToString());
                cartao_form.Visible = true;
                carregar_tb(ID);
                cartao_form.acao = "2";
                cartao_form.renovacao = true;
                cartao_form.num_cartao_visible = true;
                GridView_cartao.SelectedIndex = DemoId;
                this.ModalPopupExtender1.Show();       
            }
        }

        protected void GridView_cartao_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
        }

        protected void GridView_cartao_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridView_cartao.SelectedIndex = -1;
        }
        // /////////////////ESCONDER MODAL POPUPEXTENDER/////////////////////
        protected void Cancel_Click(object sender, ImageClickEventArgs e)
        {
            this.ModalPopupExtender1.Hide();
        }
        ////////////////////FILTROS/////////////////////////
        protected void ImageButton_filtros_Click(object sender, ImageClickEventArgs e)
        {
            if (Panel_filtros.Visible == true)
            {
                Panel_filtros.Visible = false;
                GridView_cartao.AllowPaging = true;
                carrega_cartao();
            }
            else
            {
                Panel_filtros.Visible = true;
                GridView_cartao.AllowPaging = false;
                carrega_cartao();
            }
        }
        // ////////////////////RADIO BUTTOM FILTROS/////////////////////////
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
                tb_data.Visible = true;
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
        // ////////////////////FILTROS/////////////////////////
        protected void ib_pesq_Click(object sender, ImageClickEventArgs e)
        {
            int i = 0;
            if (RB_filtro.SelectedIndex == 0)
            {
                while (i < GridView_cartao.Rows.Count)
                {
                    Label num = GridView_cartao.Rows[i].FindControl("lbnum") as Label;
                    if (num.Text == tb_pesq_num.Text)
                        GridView_cartao.Rows[i].Visible = true;
                    else
                        GridView_cartao.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 1)
            {
                while (i < GridView_cartao.Rows.Count)
                {
                    Label lbdatareg = GridView_cartao.Rows[i].FindControl("lbdatareg") as Label;
                    if (lbdatareg.Text == tb_data.Text)
                        GridView_cartao.Rows[i].Visible = true;
                    else
                        GridView_cartao.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 3)
            {
                while (i < GridView_cartao.Rows.Count)
                {
                    Label lbl_estado = GridView_cartao.Rows[i].FindControl("lbl_estado") as Label;
                    if (lbl_estado.Text == ddl_estado.SelectedValue.ToString())
                        GridView_cartao.Rows[i].Visible = true;
                    else
                        GridView_cartao.Rows[i].Visible = false;
                    i++;
                }
            }
            if (RB_filtro.SelectedIndex == 2)
            {
                BAL_cartao cartao = new BAL_cartao();
                GridView_cartao.DataSource = cartao.filtro_cartao_by_nome_entidade(tb_nome.Text, Convert.ToInt32(Session["identidade"]));
                GridView_cartao.DataBind();
            }
        }

        protected void GridView_cartao_DataBound(object sender, EventArgs e)
        {
            ApplyPaging();
            try
            {
                GridViewRow PagerRow = GridView_cartao.BottomPagerRow;
                Label b = (Label)PagerRow.FindControl("Label_pager_status");
                b.Text = "Página " + (GridView_cartao.PageIndex + 1) + " de " + GridView_cartao.PageCount; ;
            }
            catch { }
        }

    }
}