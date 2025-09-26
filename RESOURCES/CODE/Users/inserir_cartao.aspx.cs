using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication10.Users
{
    public partial class inserir_cartao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////PASSAR VALOR PARA O ASCX 0-->INSERSAO////////////
            cartao_form.acao = "0";
        }
    }
}