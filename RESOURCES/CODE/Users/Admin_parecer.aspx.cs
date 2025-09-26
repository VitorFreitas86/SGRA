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
    public partial class Admin_parecer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carrega_cartao();
            }
        }

        protected void carrega_cartao()
        {
            //////////////////CARREGAR GRIDVIEW CARTAO PRINCIPAL//////////////////
            BAL_cartao cartao = new BAL_cartao();
            BAL_entidades entidade = new BAL_entidades();
            string nome_entidade = entidade.get_entidade_by_id(Convert.ToInt32(Session["identidade"]));
            ///////////SE PSP
            if (nome_entidade == "PSP")
            {
                GridView_cartao.DataSource = cartao.get_cartao_all_parecer_psp();
                GridView_cartao.DataBind();
            }
            ///////////SE SEF
            if (nome_entidade == "SEF")
            {
                GridView_cartao.DataSource = cartao.get_cartao_all_parecer_sef();
                GridView_cartao.DataBind();
            }
        }
        protected void GridView_cartao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "ver_cartao")
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = gvr.RowIndex;
                int id = Convert.ToInt32(GridView_cartao.DataKeys[rowIndex].Value);
                carregar_tb(id);
            }
        }

        public void carregar_tb(int ID)//CARREGAR TEXTBOX
        {
            BAL_entidades entidade = new BAL_entidades();
            BAL_cartao cartao = new BAL_cartao();
            List<PROP_cartao> lista_cartao = new List<PROP_cartao>();
            lista_cartao = cartao.get_cartao_renovacao_by_id(ID);
            //cartao_form.numero = lista_cartao[0].numero;
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
        
            cartao_form.Visible = true;
            ModalPopupExtender1.Show();

        }

 
        protected void GridView_cartao_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label label_foto = ((Label)e.Row.FindControl("lb_fotografia"));
                if (label_foto.Text != "")
                {
                    string fileName = label_foto.Text;
                    char[] separator = new char[] { '\\' };
                    string[] strSplitArr = fileName.Split(separator);
                    string caminho_foto;
                    string nome_foto;
                    caminho_foto = strSplitArr[0].ToString() + "\\" + strSplitArr[1].ToString() + "\\" + strSplitArr[2].ToString() + "\\" + strSplitArr[3].ToString() + "\\" + strSplitArr[4].ToString() + "\\";
                    nome_foto = "~/fotos" + "/" + strSplitArr[3].ToString() + "/" + strSplitArr[4].ToString() + "/" + strSplitArr[5].ToString();
                    ////////////////////////////THUMBNAILS PARA A FOTOGRAFIA NO ROOTAPP/////////////////////////////
                    ImageButton ImageButton_foto = ((ImageButton)e.Row.FindControl("ImageButton_foto"));

                    ImageButton_foto.ImageUrl = nome_foto;

                }
                Label Label1 = ((Label)e.Row.FindControl("entidade_identidade"));
                BAL_entidades entidade = new BAL_entidades();
                string convert = entidade.get_entidade_by_id(Convert.ToInt32(Label1.Text));
                Label1.Text = convert;
            }

        }
    }
}