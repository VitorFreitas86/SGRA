using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.BAL;
using System.Collections;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;


namespace WebApplication10.Admin
{
    public partial class entidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carrega_grid();
            }
        }

        protected void ins_entidade_Click(object sender, EventArgs e)
        {
            int vazio=0;
            //////////////////INSERIR ENTIDADE//////////////////
            BAL_entidades entidade = new BAL_entidades();
            if (entidade.existe_entidade(nome_entidade.Text, vazio) == "0")
            {
                if (entidade.valida_n_entidade(codigo.Text, vazio) == "" || codigo.Text=="")
                {
                    entidade.Create_entidade(nome_entidade.Text.ToUpper(), rua.Text, codigopostal.Text, cidade.Text, pais.Text, codigo.Text);
                    carrega_grid();
                }
                else
                { AddErrorToValidationSummary("Já Existe uma Entidade com o o código inserido!!"); ModalPopupExtender1.Show(); ValidationSummary1.Visible = false; }
            }
            else
            { AddErrorToValidationSummary("Já Existe uma Entidade com o nome inserido!!"); ModalPopupExtender1.Show(); ValidationSummary1.Visible = false; }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //////////////////EDITAR DADOS DA ENTIDADE//////////////////
            GridView_entidade.EditIndex = e.NewEditIndex;
            carrega_grid();
            GridView_entidade.SelectedIndex = e.NewEditIndex;
            GridView_entidade.SelectedRow.Attributes.Remove("onmouseover");
        }

        protected void carrega_grid()
        {
            //////////////////CARREGAR DADOS NA GRIDVIEW//////////////////
            BAL_entidades entidade = new BAL_entidades();
            GridView_entidade.DataSource = entidade.get_entidade(null);
            GridView_entidade.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ////////////////// PROCURAR O VALOR DAS TEXTBOX E ACTUALIZAR OS DADOS//////////////////
            string nome = (GridView_entidade.Rows[e.RowIndex].FindControl("txt_nome") as TextBox).Text;
            string rua = (GridView_entidade.Rows[e.RowIndex].FindControl("txt_rua") as TextBox).Text;
            string codigopostal = (GridView_entidade.Rows[e.RowIndex].FindControl("txt_codigopostal") as TextBox).Text;
            string cidade = (GridView_entidade.Rows[e.RowIndex].FindControl("txt_cidade") as TextBox).Text;
            string pais = (GridView_entidade.Rows[e.RowIndex].FindControl("txt_pais") as TextBox).Text;
            string codigo = (GridView_entidade.Rows[e.RowIndex].FindControl("txt_codigo") as TextBox).Text;
            int ID = Convert.ToInt32(GridView_entidade.DataKeys[e.RowIndex].Value);
            BAL_entidades entidade =new BAL_entidades();
            if (entidade.existe_entidade(nome, ID) == "0")
            {
                if (entidade.valida_n_entidade(codigo, ID) == ""|| codigo=="")
                {
                    entidade.update_entidade(ID, nome.ToUpper(), rua, codigopostal, cidade, pais, codigo);
                    GridView_entidade.EditIndex = -1;
                    carrega_grid();
                }
                else
                {
                    AddErrorToValidationSummary("Já Existe uma Entidade com o o código inserido!!");
                    ValidationSummary1.Visible = true;
                }
            }
            else
            {
                AddErrorToValidationSummary("Já Existe uma Entidade com o o nome inserido!!");
                ValidationSummary1.Visible = true;
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //////////////////CANCELAR EDICAO//////////////////
            GridView_entidade.EditIndex = -1;
            carrega_grid();
        }

       
        protected void ImageButtonclose_Click(object sender, ImageClickEventArgs e)
        {
            //////////////////FECHAR MODALPOPUPEXTENDER//////////////////
            ModalPopupExtender1.Show();
        }

        protected void GridView_entidade_RowCreated(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                //////////////////ATRIBUIR COR NO MOUSEOVER E VOLTAR A COR ANTIGA NO MOUSEOUT//////////////////
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");


            }
        }

        ////////////////////////////ADICIONAR MENSAGEM DE ERRO A VALIDATAION SUMMARY ATRAVES DE UM CUSTOM VALIDATOR/////////////////////////////
        protected void AddErrorToValidationSummary(string errorMessage)
        {
            CustomValidator custVal = new CustomValidator();
            custVal.IsValid = false;
            custVal.ErrorMessage = errorMessage;
            custVal.EnableClientScript = false;
            custVal.Display = ValidatorDisplay.None;
            custVal.ValidationGroup = "MyValidationGroup";
            this.Page.Form.Controls.Add(custVal);
        }
    }
}