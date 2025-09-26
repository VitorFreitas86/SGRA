using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.BAL;

namespace WebApplication10.Users
{
    public partial class consultar_viatura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (IsPostBack)
                {
      if(GridView_viatura.AllowPaging==true)
                    ApplyPaging();
                }
                else

            {
                carrega_grid();
            }

        }

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
            }catch{}
        }


        protected void carrega_grid()
        {
            BAL_viatura viatura = new BAL_viatura();
            GridView_viatura.DataSource = viatura.get_viatura_by_entidade(Convert.ToInt32(Session["identidade"]));
            GridView_viatura.DataBind();
        }

        protected void GridView_viatura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_viatura.PageIndex = e.NewPageIndex;
            carrega_grid();
        }

        protected void GridView_viatura_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "hide")
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Panel Panel_segunda_via = gvr.FindControl("Panel_segunda_via") as Panel;
                Panel Panel_renovacao = gvr.FindControl("Panel_renovacao") as Panel;
                Panel_segunda_via.Visible = false;
                Panel_renovacao.Visible = false;
                ImageButton ImageButton_hide = (ImageButton)GridView_viatura.Rows[gvr.RowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = false;
                GridView_viatura.SelectedIndex = -1;
                int DemoId = Convert.ToInt32(gvr.RowIndex.ToString());
                GridView_viatura.Rows[DemoId].BackColor = System.Drawing.ColorTranslator.FromHtml("#e8e8e8");
                GridView_viatura.Rows[DemoId].ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d4465");
                GridView_viatura.Rows[DemoId].Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");
            }
            if (e.CommandName.ToString() == "renovacao")
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(GridView_viatura.DataKeys[rowIndex].Value);
                ViewState["id_pedido"] = id;
                Panel Panel_segunda_via = gvr.FindControl("Panel_segunda_via") as Panel;
                Panel_segunda_via.Visible = false;
                Panel Panel_renovacao = gvr.FindControl("Panel_renovacao") as Panel;           
                Panel_renovacao.Visible = true;
                ImageButton ImageButton_hide = (ImageButton)GridView_viatura.Rows[gvr.RowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = true;
                GridView_viatura.SelectedIndex = rowIndex;
                GridView_viatura.Rows[rowIndex].BackColor = System.Drawing.ColorTranslator.FromHtml("#0d4365");
                GridView_viatura.Rows[rowIndex].ForeColor = Color.White;
               GridView_viatura.SelectedRow.Attributes.Remove("onmouseover");
            }
            if (e.CommandName.ToString() == "segunda_via")
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(GridView_viatura.DataKeys[rowIndex].Value);
                ViewState["id_pedido"] = id;
                Panel Panel_segunda_via = gvr.FindControl("Panel_segunda_via") as Panel;
                Panel_segunda_via.Visible = true;
                Panel Panel_renovacao = gvr.FindControl("Panel_renovacao") as Panel;
                Panel_renovacao.Visible = false;
                ImageButton ImageButton_hide = (ImageButton)GridView_viatura.Rows[gvr.RowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = true;
                GridView_viatura.SelectedIndex = rowIndex;
                GridView_viatura.Rows[rowIndex].BackColor = System.Drawing.ColorTranslator.FromHtml("#0d4365");
                GridView_viatura.Rows[rowIndex].ForeColor = Color.White;
                GridView_viatura.SelectedRow.Attributes.Remove("onmouseover");
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
                GridView GridView_segunda_via = (GridView)e.Row.Cells[12].FindControl("GridView_segunda_via") as GridView;
                GridView GridView_renovacao = (GridView)e.Row.Cells[13].FindControl("GridView_renovacao") as GridView;
                GridView_renovacao.DataSource = viatura.get_viatura_renovacao(ID);
                GridView_renovacao.DataBind();     
                GridView_segunda_via.DataSource = viatura.get_viatura_segunda_via(ID);
                GridView_segunda_via.DataBind();
                ImageButton ImageButton_hide = (ImageButton)e.Row.FindControl("ImageButton_hide");
                ImageButton_hide.Visible = false;
            }
        }

        protected void GridView_child_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
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
    }
}