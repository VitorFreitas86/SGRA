using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebApplication10.BAL;

namespace WebApplication10.Users
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "resizeMyPage", "window.onresize=function(){ Resize();}", true);
            if (!IsPostBack)
            {
                
            }

            //if (!IsPostBack)
            //{
            //    ///////////////DIFERENTE DE ADMNISTRADOR ESCONDE O SUBMENU//////////////////////////
            //    if (!HttpContext.Current.User.IsInRole("admin"))
            //    {
            //        //Master.hide_menu_sucesso();

            //    }
            //}

            //    if (GridView_cartao.Rows.Count == 0)
            //    { 
            //    Label_cartao.Visible=false;
            //        GridView_cartao.Visible=false;
            //    }
            //    if (GridView_viatura.Rows.Count == 0)
            //    {
            //        Label_viatura.Visible = false;
            //        GridView_viatura.Visible = false;
            //    }
            //    if (GridView_conducao.Rows.Count == 0)
            //    {
            //        Label_conducao.Visible = false;
            //        GridView_conducao.Visible = false;
            //    }
            //    if (GridView_conducao.Rows.Count == 0 && GridView_viatura.Rows.Count == 0 && GridView_cartao.Rows.Count == 0)
            //    {
            //        Panel_pendente.CssClass = "home_pendentes_sem";
            //        Label_pendente.Visible = true;
            //        Label_pendente.Text = "Não existem pedidos pendentes.";
            //    }
            //    else
            //    { Panel_pendente.CssClass = "home_pendentes"; }
            //}

        }


        //public void sucesso_visibilidade() { 
        //Panel_sucess.Visible=true;
        //}


        //private void hideMenuItems()
        //{
        //    if (!HttpContext.Current.User.IsInRole("admin"))
        //    {
        //        Menu menu=(Menu)Master.FindControl("Menu1");
        //        MenuItemCollection menuItems = menu.Items[3].ChildItems;

        //        for (int i = 0; i < menuItems.Count; i++)
        //        {
        //            menuItems.RemoveAt(i);
        //        }
               
        //    }
        //}

        //protected void carrega_grid_conducao(string id)
        //{
        //    BAL_conducao conducao = new BAL_conducao();
        //    GridView_conducao.DataSource = conducao.get_conducao_by_pendente(id);
        //    GridView_conducao.DataBind();
        //}

        //protected void carrega_grid_viatura(string id)
        //{
        //    BAL_viatura viatura = new BAL_viatura();
        //    GridView_viatura.DataSource = viatura.select_viatura_by_identidade_pendente(id);
        //    GridView_viatura.DataBind();
        //}

        //protected void carrega_grid_cartao(string id)
        //{
        //    BAL_cartao cartao = new BAL_cartao();
        //    GridView_cartao.DataSource = cartao.select_cartao_by_identidade_pendente(id);
        //    GridView_cartao.DataBind();
        //}

        //protected void GridView_cartao_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (HttpContext.Current.User.IsInRole("admin"))
        //        {
        //            GridView_cartao.Columns[6].Visible = true;
        //            Label Label1 = ((Label)e.Row.FindControl("entidade_identidade_cartao"));
        //            BAL_entidades entidade = new BAL_entidades();
        //            string convert = entidade.get_entidade_by_id(Convert.ToInt32(Label1.Text));
        //            Label1.Text = convert;
        //        }
        //        else
        //        { GridView_cartao.Columns[6].Visible = false; }
        //    }
        //}

        //protected void GridView_conducao_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (HttpContext.Current.User.IsInRole("admin"))
        //        {
        //            GridView_conducao.Columns[6].Visible = true;
        //            Label Label1 = ((Label)e.Row.FindControl("entidade_identidade_conducao"));
        //            BAL_entidades entidade = new BAL_entidades();
        //            string convert = entidade.get_entidade_by_id(Convert.ToInt32(Label1.Text));
        //            Label1.Text = convert;
        //        }
        //        else
        //        { GridView_conducao.Columns[6].Visible = false; }
        //    }
        //}
        //protected void GridView_viatura_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (HttpContext.Current.User.IsInRole("admin"))
        //        {
        //            GridView_viatura.Columns[8].Visible = true;
        //            Label Label1 = ((Label)e.Row.FindControl("entidade_identidade_viatura"));
        //            BAL_entidades entidade = new BAL_entidades();
        //            string convert = entidade.get_entidade_by_id(Convert.ToInt32(Label1.Text));
        //            Label1.Text = convert;
        //        }
        //        else
        //        { GridView_viatura.Columns[8].Visible = false; }
        //    }
        //}
    }
}