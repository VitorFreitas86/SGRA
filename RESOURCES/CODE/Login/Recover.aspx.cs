using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using WebApplication10.BAL;
using WebApplication10.PROP;

namespace SGRA.Login
{
    public partial class Recover : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
        {
            PasswordRecovery1.SuccessText = "Email enviado com sucesso, Por favor verifique o seu email.";
        }

        protected void PasswordRecovery1_SendMailError(object sender, SendMailErrorEventArgs e)
        {

        }
        protected void PasswordRecovery1_VerifyingAnswer(object sender, LoginCancelEventArgs e)
        {
            ///////////////////////////RECUPERAR PALAVRA CHAVE//////////////////////////////////////
            if (ViewState["LoginErrors"] == null)
                ViewState["LoginErrors"] = 0;
            int ErrorCount = (int)ViewState["LoginErrors"] + 1;
            ViewState["LoginErrors"] = ErrorCount;
            Panel panelLogin = (Panel)PasswordRecovery1.Controls[1].Controls[15];
            panelLogin.Visible = true;
            if (ErrorCount > 3)
            {
                BAL_users user = new BAL_users();
                List<PROP_users> users = new List<PROP_users>();
                users = user.select_user_by_nome(PasswordRecovery1.UserName.ToUpper());
                if (users.Count != 0)
                {
                    int IDout = users[0].userId;
                    user.update_user_islockedout(IDout, 1, DateTime.Now);
                }
            }
        }
        protected void PasswordRecovery1_VerifyingUser(object sender, LoginCancelEventArgs e)
        {
            ////////////////INCREMENTAR Nº TENTATIVAS DE ERRO/////////////////////////////
            if (ViewState["LoginErrors"] == null)
                ViewState["LoginErrors"] = 0;
            Panel panelLogin = (Panel)PasswordRecovery1.Controls[0].Controls[11];
            panelLogin.Visible = true;
            int ErrorCount = (int)ViewState["LoginErrors"] + 1;
            ViewState["LoginErrors"] = ErrorCount;
        }

        protected void ContinueButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}

