using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.BAL;
using WebApplication10.PROP;

namespace WebApplication10.Login
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregar_ddl();
                BAL_entidades entidade = new BAL_entidades();
                int num_entidade = entidade.numero_entidade();
                if (num_entidade == 0)
                {
                    entidade.insert_entidade1();
                    BAL_users role = new BAL_users();
                    int num_role = role.numero_roles();
                    if (num_role == 0)
                    {
                        role.insert_roles();
                        carrega_entidade();
                    }
                }
                else
                    if (num_entidade > 0)
                    {
                        carrega_entidade();
                        ///////////////////////preenxer ddl ano/////////////////
                      
                    }


            }
        }



        protected void carregar_ddl() {
            ddl_ano.Items.Insert(0, "Ano");
            int index = 1;
            for (int Year = 1950; Year <= DateTime.Now.Year; Year++)
            {
                ListItem li = new ListItem(Year.ToString(), Year.ToString());
                ddl_ano.Items.Insert(index, li);
                index++;
            }
            /////////////////////////preenxer ddl dia/////////////////////
            ddl_dia.Items.Insert(0, "Dia");
            for (int day = 1; day < 32; day++)
            {
                if (day < 10)
                {
                    ListItem li = new ListItem();
                    string aux = "0";
                    li.Text = aux + day.ToString();
                    li.Value = aux + day.ToString();
                    ddl_dia.Items.Add(li);
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = day.ToString();
                    li.Value = day.ToString();
                    ddl_dia.Items.Add(li);
                }
            }
            /////////////////////////preenxer ddl mes/////////////////////
            ddl_mes.Items.Insert(0, "Mês");
            for (int m = 1; m <= 12; m++)
            {
                ListItem li = new ListItem();
                li.Text = m.ToString();
                li.Value = m.ToString();
                ddl_mes.Items.Add(li);
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

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            TextBox UserNameTextBox = (TextBox)CreateUserWizardStep2.ContentTemplateContainer.FindControl("UserName");
            SqlDataSource DataSource = (SqlDataSource)CreateUserWizardStep2.ContentTemplateContainer.FindControl("InsertExtraInfo");
            DropDownList ddl_entidade = (DropDownList)CreateUserWizardStep2.FindControl("ddl_entidade");
            MembershipUser User = Membership.GetUser(UserNameTextBox.Text.ToUpper());
            object UserGUID = User.ProviderUserKey;
            Object returnValue;
            BAL_entidades entidades = new BAL_entidades();
            returnValue = entidades.get_entidade_by_nome(ddl_entidade.SelectedValue.ToString());
            /////////////////////////////inserir com Pk entidade
            DataSource.InsertParameters.Add("UserId", UserGUID.ToString());
            DataSource.InsertParameters.Add("entidade_identidade", returnValue.ToString());
            DataSource.Insert();
            //////////////////adicionar utilizador na roles
            BAL_users role = new BAL_users();
            int num_user = role.numero_users();
            if (num_user == 1)
            {
                role.insert_usersinroles(Convert.ToInt32(UserGUID.ToString()), 1);
                BAL_users users = new BAL_users();
                users.insert_first_u(Convert.ToInt32(UserGUID.ToString()));
            }
            else
            {
                role.insert_usersinroles(Convert.ToInt32(UserGUID.ToString()), 2);
            }
            ///////////////////////////////////////enviar emails//////////////////////////////
            TextBox email_address = (TextBox)CreateUserWizardStep2.ContentTemplateContainer.FindControl("EMAIL");
            TextBox user = (TextBox)CreateUserWizardStep2.ContentTemplateContainer.FindControl("UserName");
            TextBox nome = (TextBox)CreateUserWizardStep0.FindControl("nome");
            DropDownList question = (DropDownList)CreateUserWizardStep2.ContentTemplateContainer.FindControl("Question");
            string header = Server.MapPath("~\\Templates\\email_header.png");
            string footer = Server.MapPath("~\\Templates\\email_footer.png");
            send_email email = new send_email();
            email.registo_utilizador(ddl_entidade.SelectedValue.ToString(), nome.Text, user.Text, question.Text, email_address.Text, header, footer);
        }

        protected void CreateUserWizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            string nomec = nome.Text.Substring(0, 1);
            string apelidoc = apelido.Text.Substring(0, 1);
            ((TextBox)CreateUserWizardStep0.FindControl("nome")).Text = nome.Text + " " + apelido.Text;
            string userc = nomec.ToUpper() + apelidoc.ToUpper() + ddl_ano.SelectedValue + ddl_dia.SelectedValue;
            ((TextBox)CreateUserWizardStep2.ContentTemplateContainer.FindControl("UserName")).Text = userc.ToString();
        }
        public string GetErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Nome de utilizador já existe. Por favor insira um nome de utilizador diferente.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "O endereço de e-mail já existe. Por favor insira um endereço de e-mail diferente.";

                case MembershipCreateStatus.InvalidPassword:
                    return "A palavra-chave deve possuir no minimo 7 caracteres sendo um deles 1 caracter não alfanumérico";

                case MembershipCreateStatus.InvalidEmail:
                    return "O endereço de e-mail fornecido é inválido. Por favor, verifique o valor e tente novamente.";

                case MembershipCreateStatus.InvalidUserName:
                    return "O nome de usuário fornecido é inválido. Por favor, verifique o valor e tente novamente.";

                case MembershipCreateStatus.ProviderError:
                    return "O provedor de autenticação retornou um erro. Verifique os valores de entrada e tente novamente. Se o problema persistir, por favor, contate o administrador do sistema.";

                case MembershipCreateStatus.UserRejected:
                    return "O pedido de criação de utilizador foi cancelada. Verifique os valores de entrada e tente novamente. Se o problema persistir, por favor, contate o administrador do sistema.";

                default:
                    return "Ocorreu um erro desconhecido. Verifique os valores de entrada e tente novamente. Se o problema persistir, por favor, contate o administrador do sistema.";
            }
        }

        protected void CreateUserWizard1_CreateUserError(object sender, CreateUserErrorEventArgs e)
        {
            MembershipCreateStatus status = e.CreateUserError;
            ((Label)CreateUserWizardStep2.ContentTemplateContainer.FindControl("Label_erro")).Text = GetErrorMessage(status).ToString();
        }
    }
}