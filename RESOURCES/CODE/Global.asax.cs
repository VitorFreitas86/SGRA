using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication10
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["identidade"] = "";
            Session["UserID"] = "";
            Session["user"] = "";
            Session["flag_upload_c"] = 0;
            Session["AFileUpload_bi"] = "";
            Session["AFileUpload_vinculo"] = "";
            Session["AFileUpload_foto"] = "";
            Session["AFileUpload_r_criminal"] = "";
            Session["AFileUpload_cartao_acompanhante"] = "";
            Session["AFileUpload_cartao_renovacao"] = "";
            Session["fotocopia_cartao_acl"] = "";
            Session["fotocopia_carta"] = "";
            Session["flag_upload"] = 0;
            Session["flag_upload_v"] = 0;
            Session["AFileUpload_livrete"] = "";
            Session["AFileUpload_r_propriedade"] = "";
            Session["AFileUpload_cobertura_seguradora"] = "";
            Session["AFileUpload_cartao_circulacao"] = "";
            Session["AFileUpload_c_verde"] = "";
            Session["AFileUpload_ipo"] = "";
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {    
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Session["identidade"] = "";
            Session["UserID"] = "";
            Session["user"] = "";
            Session["flag_upload_c"] = 0;
            Session["AFileUpload_bi"] = "";
            Session["AFileUpload_vinculo"] = "";
            Session["AFileUpload_foto"] = "";
            Session["AFileUpload_r_criminal"] = "";
            Session["AFileUpload_cartao_acompanhante"] = "";
            Session["AFileUpload_cartao_renovacao"] = "";
            Session["fotocopia_cartao_acl"] = "";
            Session["fotocopia_carta"] = "";
            Session["flag_upload"] = 0;
            Session["flag_upload_v"] = 0;
            Session["AFileUpload_livrete"] = "";
            Session["AFileUpload_r_propriedade"] = "";
            Session["AFileUpload_cobertura_seguradora"] = "";
            Session["AFileUpload_cartao_circulacao"] = "";
            Session["AFileUpload_c_verde"] = "";
            Session["AFileUpload_ipo"] = "";
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session["identidade"] = "";
            Session["UserID"] = "";
            Session["user"] = "";
            Session["flag_upload_c"] = 0;
            Session["AFileUpload_bi"] = "";
            Session["AFileUpload_vinculo"] = "";
            Session["AFileUpload_foto"] = "";
            Session["AFileUpload_r_criminal"] = "";
            Session["AFileUpload_cartao_acompanhante"] = "";
            Session["AFileUpload_cartao_renovacao"] = "";
            Session["fotocopia_cartao_acl"] = "";
            Session["fotocopia_carta"] = "";
            Session["flag_upload"] = 0;
            Session["flag_upload_v"] = 0;
            Session["AFileUpload_livrete"] = "";
            Session["AFileUpload_r_propriedade"] = "";
            Session["AFileUpload_cobertura_seguradora"] = "";
            Session["AFileUpload_cartao_circulacao"] = "";
            Session["AFileUpload_c_verde"] = "";
            Session["AFileUpload_ipo"] = "";
     
          
        }

        protected void Application_End(object sender, EventArgs e)
        {           
                

        }
    }
}