using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication10.Users
{
    public partial class inserir_conducao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                ////PASSAR VALOR PARA O ASCX 0-->INSERSAO////////////
                conducao_form.acao = "0";
            }
        }
    }
}