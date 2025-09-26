using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.BAL;
using WebApplication10.DAL;
using WebApplication10.PROP;

namespace WebApplication10.Admin
{
    public partial class consultar_dados_user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["IDblock"] = null;
                ViewState["IDedit"] = null;
                ViewState["privilegio"] = null;
                carrega_grid();
            }
        }

        protected void carrega_grid()
        {
            DAL_users user = new DAL_users();
            GridView1.DataSource = user.getAll_users();
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                ////////////// when mouse is over the row, save original color to new attribute, and change it to highlight color
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E1EFFD'");
                ////////////7 when mouse leaves the row, change the bg color to its original value////////////  
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ////////////////PROCURAR OS OBJECTOS NA CHILDGRID////////////////////////
                string ID = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
                Panel Panel_contatos = e.Row.FindControl("Panel_contatos") as Panel;
                Panel Panel_edit_user = e.Row.FindControl("Panel_contatos") as Panel;
                Panel Panel_login = e.Row.FindControl("Panel_contatos") as Panel;
                Panel_contatos.Visible = false;
                Panel_edit_user.Visible = false;
                Panel_login.Visible = false;
                BAL_users user = new BAL_users();
                List<PROP_users> contatos = new List<PROP_users>();
                contatos = user.get_contatos_user(Convert.ToInt32(ID));
                ImageButton Button_update_user = (ImageButton)Panel_edit_user.FindControl("Button_update_user");
                Button_update_user.OnClientClick = "Button_update_user_Click";
                Button_update_user.ValidationGroup = "edit_user";
                Label lb_cartao = Panel_contatos.FindControl("lb_cartao") as Label;
                Label lb_cargo = Panel_contatos.FindControl("lb_cargo") as Label;
                Label label_telefone = Panel_contatos.FindControl("label_telefone") as Label;
                Label label_fax = Panel_contatos.FindControl("label_fax") as Label;
                Label label_email = Panel_contatos.FindControl("label_email") as Label;
                lb_cartao.Text = contatos[0].num_acl;
                lb_cargo.Text = contatos[0].cargo;
                label_telefone.Text = contatos[0].telefone;
                label_fax.Text = contatos[0].fax;
                label_email.Text = contatos[0].email;
                List<PROP_users> login = new List<PROP_users>();
                login = user.get_login_user(Convert.ToInt32(ID));
                Label LastLoginDate = Panel_login.FindControl("LastLoginDate") as Label;
                Label login_pwd = Panel_login.FindControl("login_pwd") as Label;
                Label login_question = Panel_login.FindControl("login_question") as Label;
                Label login_answer = Panel_login.FindControl("login_answer") as Label;
                Label login_lastpasschangedate = Panel_login.FindControl("login_lastpasschangedate") as Label;
                Label login_failedpasscount = Panel_login.FindControl("login_failedpasscount") as Label;
                Label login_FailedPasswordAttemptWindowStart = Panel_login.FindControl("login_FailedPasswordAttemptWindowStart") as Label;
                Label login_respostachave = Panel_login.FindControl("login_respostachave") as Label;
                Label login_respostachave_data = Panel_login.FindControl("login_respostachave_data") as Label;
                Label login_block_acesso = Panel_login.FindControl("login_block_acesso") as Label;
                Label login_block_acesso_data = Panel_login.FindControl("login_block_acesso_data") as Label;
                ////////ATRIBUIÇÃO DE VALORES AS TEXTBOX DOS CHILD PANELS//////////////////////
                LastLoginDate.Text = login[0].LastLoginDate;
                login_pwd.Text = login[0].Password;
                login_question.Text = login[0].passwordQuestion;
                login_answer.Text = login[0].PasswordAnswer;
                login_lastpasschangedate.Text = login[0].LastPasswordChangedDate;
                login_failedpasscount.Text = login[0].FailedPasswordAttemptCount;
                login_FailedPasswordAttemptWindowStart.Text = login[0].FailedPasswordAttemptWindowStart;
                login_respostachave.Text = login[0].FailedPasswordAnswerAttemptCount;
                login_respostachave_data.Text = login[0].FailedPasswordAnswerAttemptWindowStart;
                login_block_acesso.Text = login[0].IsLockedOut;
                login_block_acesso_data.Text = login[0].LastLockedOutDate;
                ////////RADIOBUTTOM PARA BLOQUEIO DE LOGIN E MOSTRAR CONFIRMACAO EM JAVASCRIPT//////////////////////

                RadioButtonList RadioButtonList_block = Panel_login.FindControl("RadioButtonList_block") as RadioButtonList;
                RadioButtonList_block.Attributes.Add("onclick", "return showconfirm();");

                ////////DDL DE PRIVILEGIO E MOSTRAR CONFIRMACAO EM JAVASCRIPT//////////////////////
                DropDownList ddl_privilegio = Panel_login.FindControl("ddl_privilegio") as DropDownList;
                ddl_privilegio.Attributes.Add("onChange", "confirmfunction();"); 
                ddl_privilegio.AutoPostBack = false;
                Label Label_privilegio = Panel_login.FindControl("Label_privilegio") as Label;
                Label_privilegio.Text = user.privilegio_user(Convert.ToInt32(ID)).ToString();
                ImageButton ImageButton_hide = (ImageButton)e.Row.FindControl("ImageButton_hide");
                ImageButton_hide.Visible = false;
                ////////DDL DE PRIVILEGIO SELECIONAR INDEX CONSOANTE VALOR DA BD//////////////////////
                if (Label_privilegio.Text == "1")
                {
                    ddl_privilegio.SelectedIndex = 0;
                }
                else
                {
                    ddl_privilegio.SelectedIndex = 1;
                }

                if (login_block_acesso.Text == "True")
                {
                    RadioButtonList_block.SelectedValue = "1";


                }
                else
                    if (login_block_acesso.Text == "False")
                    {

                        RadioButtonList_block.SelectedValue = "0";
                    }
                ////////EDITAR DADOS PESSOAIS DO UTILIZADOR //////////////////////
                List<PROP_users> editar = new List<PROP_users>();
                editar = user.edit_user_by_id(Convert.ToInt32(ID));
                TextBox nome_edit = Panel_edit_user.FindControl("nome") as TextBox;
                TextBox num_acl_edit = Panel_edit_user.FindControl("num_acl") as TextBox;
                TextBox telefone_edit = Panel_edit_user.FindControl("telefone") as TextBox;
                TextBox Fax_edit = Panel_edit_user.FindControl("Fax") as TextBox;
                TextBox cargo_edit = Panel_edit_user.FindControl("cargo") as TextBox;
                TextBox UserName_edit = Panel_edit_user.FindControl("UserName") as TextBox;
                TextBox Password_edit = Panel_edit_user.FindControl("Password") as TextBox;
                TextBox Email_edit = Panel_edit_user.FindControl("Email") as TextBox;
                nome_edit.Text = editar[0].nome;
                num_acl_edit.Text = editar[0].num_acl;
                telefone_edit.Text = editar[0].telefone;
                Fax_edit.Text = editar[0].fax;
                cargo_edit.Text = editar[0].cargo;
                UserName_edit.Text = editar[0].name;
                Password_edit.Text = editar[0].Password;
                Email_edit.Text = editar[0].email;
                Label Label1 = ((Label)e.Row.FindControl("Label1"));
                DAL_entidade entidade = new DAL_entidade();
                string convert = entidade.get_entidade_by_id(Convert.ToInt32(Label1.Text));
                Label1.Text = convert;
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)//row comand grid users
        {
            if (e.CommandName.ToString() == "hide")
            {
                /////////ESCONDER AS CHILD GRIDS////////////////////////7
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Panel Panel_contatos = gvr.FindControl("Panel_contatos") as Panel;
                Panel Panel_edit_user = gvr.FindControl("Panel_edit_user") as Panel;
                Panel Panel_login = gvr.FindControl("Panel_login") as Panel;
                Panel_contatos.Visible = false;
                Panel_edit_user.Visible = false;
                Panel_login.Visible = false;
                ImageButton ImageButton_hide = (ImageButton)GridView1.Rows[gvr.RowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = false;
                int DemoId = Convert.ToInt32(gvr.RowIndex.ToString());
                GridView1.Rows[DemoId].BackColor = System.Drawing.ColorTranslator.FromHtml("#e8e8e8");
                GridView1.Rows[DemoId].ForeColor = System.Drawing.ColorTranslator.FromHtml("#0d4365");
            }

            if (e.CommandName.ToString() == "contatos")
            {
                //////////////////CONTATOS UTILIZADORES////////////////////////
                GridViewRow linha = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int DemoId = Convert.ToInt32(linha.RowIndex.ToString());
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Panel Panel_contatos = gvr.FindControl("Panel_contatos") as Panel;
                Panel_contatos.Visible = true;
                Panel Panel_edit_user = gvr.FindControl("Panel_edit_user") as Panel;
                Panel Panel_login = gvr.FindControl("Panel_login") as Panel;
                Panel_edit_user.Visible = false;
                Panel_login.Visible = false;
                ImageButton ImageButton_hide = (ImageButton)GridView1.Rows[gvr.RowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = true;
                GridView1.SelectedIndex = DemoId;
                GridView1.Rows[DemoId].BackColor = System.Drawing.ColorTranslator.FromHtml("#0d4365");
                GridView1.Rows[DemoId].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                 GridView1.SelectedRow.Attributes.Remove("onmouseover");
                ViewState["IDedit"] = ID;


            }
            if (e.CommandName.ToString() == "login")
            {
                //////////////////////////DADOS DE LOGIN DO USER////////////////////////
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int DemoId = Convert.ToInt32(gvr.RowIndex.ToString());
                int ID = Convert.ToInt32(GridView1.DataKeys[gvr.RowIndex].Value.ToString());
                ImageButton ImageButton_hide = (ImageButton)GridView1.Rows[gvr.RowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = true;
                Panel Panel_contatos = gvr.FindControl("Panel_contatos") as Panel;
                Panel Panel_edit_user = gvr.FindControl("Panel_edit_user") as Panel;
                Panel Panel_login = gvr.FindControl("Panel_login") as Panel;
                Panel_contatos.Visible = false;
                Panel_edit_user.Visible = false;
                Panel_login.Visible = true;
                GridView1.SelectedIndex = DemoId;
                GridView1.Rows[DemoId].BackColor = System.Drawing.ColorTranslator.FromHtml("#0d4365");
                GridView1.Rows[DemoId].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                GridView1.SelectedRow.Attributes.Remove("onmouseover");
                ViewState["privilegio"] = ID;
                ViewState["IDblock"] = ID;

            }

            if (e.CommandName.ToString() == "editar")
            {
                ////////EVENTO DO BOTADO DE EDITAR OS DADOS E ALTERACAO DE CORES  E RETIRAR MOUSEOVER COR//////////////////////
                GridViewRow linha = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int DemoId = Convert.ToInt32(linha.RowIndex.ToString());
                int ID = Convert.ToInt32(GridView1.DataKeys[linha.RowIndex].Value.ToString());
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Panel Panel_contatos = gvr.FindControl("Panel_contatos") as Panel;
                Panel Panel_edit_user = gvr.FindControl("Panel_edit_user") as Panel;
                Panel Panel_login = gvr.FindControl("Panel_login") as Panel;
                Panel_contatos.Visible = false;
                Panel_edit_user.Visible = true;
                Panel_login.Visible = false;
                GridView1.SelectedIndex = DemoId;
                ViewState["IDedit"] = ID;
                GridView1.Rows[DemoId].BackColor = System.Drawing.ColorTranslator.FromHtml("#0d4365");
                GridView1.Rows[DemoId].ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                GridView1.SelectedRow.Attributes.Remove("onmouseover");
                ImageButton ImageButton_hide = (ImageButton)GridView1.Rows[gvr.RowIndex].FindControl("ImageButton_hide");
                ImageButton_hide.Visible = true;

            }


            if (e.CommandName.ToString() == "apagar")
            {
                GridViewRow linha = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int DemoId = Convert.ToInt32(linha.RowIndex.ToString());
                int ID = Convert.ToInt32(GridView1.DataKeys[linha.RowIndex].Value.ToString());
                BAL_users users = new BAL_users();
                users.delete_user_by_id(ID);
                carrega_grid();

            }

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ////////EDICAO DA PERMISSAO DE ACESSO DO UTILIZADOR À APLICACAO//////////////////////
            GridView1.EditIndex = e.NewEditIndex;
            carrega_grid();
            (GridView1.Rows[GridView1.EditIndex].FindControl("chkStatus") as CheckBox).Enabled = true;
            GridView1.SelectedIndex = e.NewEditIndex;
            GridView1.SelectedRow.Attributes.Remove("onmouseover");
            GridView1.SelectedRow.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            GridView1.Rows[e.NewEditIndex].Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#315f7b");
            GridView1.Rows[e.NewEditIndex].Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#315f7b");
       
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ////////CANCELAR EDICAO//////////////////////
            GridView1.EditIndex = -1;
            carrega_grid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ///////////////PERMTIR O ACESSO AO UTILIZADOR//////////////////
            bool status = (GridView1.Rows[e.RowIndex].FindControl("chkStatus") as CheckBox).Checked;
            string customerId = GridView1.DataKeys[e.RowIndex].Value.ToString();
            int ID = Convert.ToInt32(customerId);
            int aprovado = Convert.ToInt32(status);
            BAL_users users = new BAL_users();
            users.update_user_approved(ID, aprovado);
            GridView1.EditIndex = -1;
            carrega_grid();
        }

        protected void RadioButtonList_block_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////////////////////////ALTERAR BLOQUEIO DO UTLIZADOR BASEADO NAS TENTATIVAS ERRADAS//////////////
            Panel Panel_login = GridView1.SelectedRow.FindControl("Panel_login") as Panel;
            RadioButtonList RadioButtonList_block = Panel_login.FindControl("RadioButtonList_block") as RadioButtonList;
            if (RadioButtonList_block.SelectedIndex == 0)
            {
                if (ViewState["IDblock"] != null)//NAO BLOQUEADO
                {
                    BAL_users users = new BAL_users();
                    users.update_user_islockedout(Convert.ToInt32(ViewState["IDblock"]), 0, null);
                    ViewState["IDblock"] = null;
                }
            }
            else
                if (RadioButtonList_block.SelectedIndex == 1)//BLOQUEADO
                {
                    if (ViewState["IDblock"] != null)
                    {
                        BAL_users users = new BAL_users();
                        users.update_user_islockedout(Convert.ToInt32(ViewState["IDblock"]), 1, DateTime.Now);
                        ViewState["IDblock"] = null;
                    }
                }
        }

        protected void Button_update_user_Click(object sender, EventArgs e)
        {
            /////////////////////////ATUALIZAR DADOS DO UTILIZADOR/////////////////////////////////
            Panel Panel_edit_user = GridView1.SelectedRow.FindControl("Panel_contatos") as Panel;
            Panel_edit_user.Visible = true;
            TextBox nome = Panel_edit_user.FindControl("nome") as TextBox;
            TextBox num_acl = Panel_edit_user.FindControl("num_acl") as TextBox;
            TextBox telefone = Panel_edit_user.FindControl("telefone") as TextBox;
            TextBox Fax = Panel_edit_user.FindControl("Fax") as TextBox;
            TextBox cargo = Panel_edit_user.FindControl("cargo") as TextBox;
            TextBox UserName = Panel_edit_user.FindControl("UserName") as TextBox;
            TextBox Password = Panel_edit_user.FindControl("Password") as TextBox;
            TextBox Email = Panel_edit_user.FindControl("Email") as TextBox;
            if (ViewState["IDedit"] != null && Email.Text != "" && Password.Text != "" && UserName.Text != "" && telefone.Text != "" && nome.Text != "")
            {
                BAL_users users = new BAL_users();
                users.update_user_edit(Convert.ToInt32(ViewState["IDedit"]), UserName.Text, Password.Text, Email.Text, nome.Text, num_acl.Text, telefone.Text, Fax.Text, cargo.Text);
                carrega_grid();
                ViewState["IDedit"] = null;
            }
            else
            {
                Literal ErrorMessage = Panel_edit_user.FindControl("ErrorMessage") as Literal;
                ErrorMessage.Text = "Existem erros na alteração dos dados do utilizador.";
            }
        }

        protected void ddl_privilegio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///////////////////////ALTERAR PRIVILEGIOS DE ACESSO DO UTILIZADOR //////////////////////////////////
            Panel Panel_login = GridView1.SelectedRow.FindControl("Panel_login") as Panel;
            DropDownList ddl_privilegio = Panel_login.FindControl("ddl_privilegio") as DropDownList;
            BAL_users user = new BAL_users();
            if (ddl_privilegio.SelectedIndex == 0)
            {
                user.update_privilegio(Convert.ToInt32(ViewState["privilegio"]), 1);
            }
            else
            {
                user.update_privilegio(Convert.ToInt32(ViewState["privilegio"]), 2);
            }
        }

    
       /////////////////////////////////// FUNCOES DE FILTROS///////////////////////////////////////////////////
    
        protected void ImageButton_filtros_Click(object sender, ImageClickEventArgs e)
        {
            if (Panel_filtros.Visible == true)
            {
                Panel_filtros.Visible = false;        
            }
            else
            {
                Panel_filtros.Visible = true;
            }
        }
        protected void ib_pesq_Click(object sender, ImageClickEventArgs e)
        {
            //////////////////BOTAO DE FILTAR//////////////////////////////
            BAL_users user = new BAL_users();
            GridView1.DataSource = user.pesquisar_user(tb_nome.Text);
            GridView1.DataBind();
        }
    }
}