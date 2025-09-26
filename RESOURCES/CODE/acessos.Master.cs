using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.BAL;
using WebApplication10.PROP;
using AjaxControlToolkit;
using System.Text;

namespace WebApplication10
{
    public partial class acessos : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {    
            if (!IsPostBack)
            {
                try
                {
                    LabelValue = Session["user"].ToString();
                    BAL_entidades entidade = new BAL_entidades();
                    ///////////VERIFICAR SE A ENTIDADE E SEF OU PSP PARA DAR POR O BOTAO DE DAR PARECER SOBRE CARTOES///////////
                    //if (Session["identidade"] != "")
                    //{
                    ///////////////DIFERENTE DE ADMNISTRADOR ESCONDE O SUBMENU//////////////////////////
                    if (!HttpContext.Current.User.IsInRole("admin"))
                    {
                        hide_menu();
                    }
                        string nome_entidade = entidade.get_entidade_by_id(Convert.ToInt32(Session["identidade"]));
                        if (nome_entidade == "PSP" || nome_entidade == "SEF")
                        {
                            adicionar_btn_parecer();
                        }
                    //}
                }
                catch {
                    Response.Redirect("~/Default.aspx");
                }


               
            }
        }

        public void hide_menu()
        {
            MenuItemCollection menuItems = Menu1.Items[3].ChildItems;
            MenuItem newItem = new MenuItem();
            newItem.Text = "Alterar Palavra-Chave";
            newItem.NavigateUrl = "~/users/alterarpwd.aspx";
            menuItems.Clear();
            menuItems.Add(newItem);
        }

        public void adicionar_btn_parecer()
        {
            MenuItemCollection menuItems = Menu1.Items[3].ChildItems;
            MenuItem newItem = new MenuItem();
            newItem.Text = "Alterar Palavra-Chave";
            newItem.NavigateUrl = "~/users/alterarpwd.aspx";
            menuItems.Clear();
            menuItems.Add(newItem);

            MenuItem newItem2 = new MenuItem();
            newItem2.Text = "Emissão Parecer";
            newItem2.NavigateUrl = "~/users/Admin_parecer.aspx";
    
            menuItems.Add(newItem2);
        }

        
        public string LabelValue
        {
            get { return this.lb_sessao.Text; }
            set { this.lb_sessao.Text = value; }
        }
        public string painel_email
        {
            set { fotter_end.visibildade_painel = value; }
        }
        public string[] documentos_conducao
        {
            set { fotter_end.carrega_docs = value; }
        }

        protected void btnLogout_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
            Session["identidade"] = "";
            Session["UserID"] = "";
            Session["user"] = "";
        }
    }
}