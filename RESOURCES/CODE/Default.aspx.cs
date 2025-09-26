using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.BAL;
using WebApplication10.PROP;

namespace SGRA.Login
{
    public partial class Signin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
          
           
            ////////////////////////COLOCAR VARIAVEL DE CONTROLO DE TENTATIVAS DE ERRO A ZERO///////////////////
            if (!this.IsPostBack)
                
            //page.ClientScript.RegisterStartupScript(typeof(Page), "Test", "<script type='text/javascript'>checkSizeWindow();</script>");
 
                ViewState["LoginErrors"] = 0;
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            MembershipUser user = Membership.GetUser(Login1.UserName.ToUpper().ToString());
            if (YourValidationFunction(Login1.UserName.ToUpper(), Login1.Password) && !user.IsLockedOut && user.IsApproved)
            {
                e.Authenticated = true;
                Login1.Visible = false;     
                List<PROP_users> users = new List<PROP_users>();
                BAL_conducao rconducao = new BAL_conducao();
                BAL_users nome = new BAL_users();
                BAL_entidades entidades = new BAL_entidades();
                users = nome.select_user_by_nome(Login1.UserName);
                Session["identidade"] = entidades.get_entidade_by_user(users[0].userId);
                Session["UserID"] = Login1.UserName.ToString();
                Session["user"] = users[0].nome;

            }
            else
            {
                e.Authenticated = false;
            }
        }

        protected void Login1_LoginError(object sender, EventArgs e)
        {
            ///////////METODO PARA VERIFICAR OS ERROS DE LOGIN E INCREMENTAR A VARIAVEL DE ERRO PARA BLOQUEIO DO UTILIZADOR///////////
            if (ViewState["LoginErrors"] == null)
                ViewState["LoginErrors"] = 0;
            int ErrorCount = (int)ViewState["LoginErrors"] + 1;
            ViewState["LoginErrors"] = ErrorCount;
            string ID = "";
            Panel panelLogin = (Panel)Login1.FindControl("messageError");
            panelLogin.Visible = true;
            BAL_users user = new BAL_users();
            List<PROP_users> users = new List<PROP_users>();
            users = user.select_user_by_nome(Login1.UserName);
            /////////VERIFICAR SE EXISTE UTILIZADOR E VER QUAL E O USER////////////////
            if (users.Count != 0)
            {
                ID = users[0].userId.ToString();
            }
            //////////////////////INCREMENTAR TENTATIVAS DE ERRO COM DATA////////////
            if (ID != "")
            {
                int IDout = int.Parse(ID);
                user.update_FailedPasswordAttemptCount(IDout, DateTime.Now);
            }
            /////////////////////SE O NUMERO DE TENTATIVAS DE ACEDER FOR 3 ENCAMINHA PARA A RECUPERACAO DE PASSWORD ////////////////
            if ((ErrorCount >= 3) && (Login1.PasswordRecoveryUrl != string.Empty))
                Response.Redirect(Login1.PasswordRecoveryUrl);
        }
        //////////////////METODO DE VALIDACAO//////////////////
        private bool YourValidationFunction(string UserName, string Password)
        {
            bool boolReturnValue = false;
            BAL_users user = new BAL_users();
            List<PROP_users> users = new List<PROP_users>();
            users = user.validarlogin(UserName, Password);
            if (users.Count != 0)
            {
                if ((UserName == users[0].name) & (Password == users[0].Password))
                {
                    return boolReturnValue = true;
                }
            }
            return boolReturnValue;
        }
      
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ///////////////////IR PARA O REGISTO DE UTILIZADOR/////////////////////////
            Response.Redirect("/Login/Register.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            ////////////////////IR PARA A RECUPERACAO DA PALAVRA CHAVE/////////////////
            Response.Redirect("/Login/Recover.aspx");
        }

        

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            ///////////// SE O UTILIZADOR EST
            Response.Redirect("/Users/home.aspx");
        }

        protected void Login1_Authenticate(object sender, EventArgs e)
        {
    AuthenticateEventArgs auth = new AuthenticateEventArgs();
            auth.Authenticated = false;
            Login1_Authenticate(this, auth);
        }

    
    }
}



