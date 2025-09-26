using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.BAL;

namespace WebApplication10.controls
{
    public partial class emitir_parecer : System.Web.UI.UserControl
    {

      
        public int id_cartao
        {
            get
            {
                if (ViewState["id_cartao"] == null)
                    ViewState["id_cartao"] = string.Empty;
                return Convert.ToInt32(ViewState["id_cartao"].ToString());
            }
            set
            {
                ViewState["id_cartao"] = value;
            }
        }
        public string acao
        {
            get
            {
                if (ViewState["acao"] == null)
                    ViewState["acao"] = string.Empty;

                return ViewState["acao"].ToString();
            }
            set
            {
                ViewState["acao"] = value;
            }
        }
  
        public string nome
        {
            get { return tb_nome.Text.ToString(); }
            set { tb_nome.Text = value; }
        }
        public string morada
        {
            get { return tb_morada.Text.ToString(); }
            set { tb_morada.Text = value; }
        }
        public string localidade
        {
            get { return tb_localidade.Text.ToString(); }
            set { tb_localidade.Text = value; }
        }
        public string codigo_postal
        {
            get { return tb_codigo_postal.Text.ToString(); }
            set { tb_codigo_postal.Text = value; }
        }
        public string telefone
        {
            get { return tb_telefone.Text.ToString(); }
            set { tb_telefone.Text = value; }
        }
        public string telemovel
        {
            get { return tb_tlm.Text.ToString(); }
            set { tb_tlm.Text = value; }
        }
        public string tlf_serv
        {
            get { return tb_tlf_serv.Text.ToString(); }
            set { tb_tlf_serv.Text = value; }
        }
        public string nacionalidade
        {
            get { return tb_nacionalidade.Text.ToString(); }
            set { tb_nacionalidade.Text = value; }
        }
        public string bi
        {
            get { return tb_bi.Text.ToString(); }
            set { tb_bi.Text = value; }
        }
        public string validade_bi
        {
            get { return tb_validade_bi.Text.ToString(); }
            set { tb_validade_bi.Text = value; }
        }
        public string data_nascimento
        {
            get { return tb_d_nascimento.Text.ToString(); }
            set { tb_d_nascimento.Text = value; }
        }
        public string email
        {
            get { return Email.Text.ToString(); }
            set { Email.Text = value; }
        }
        public string patronal
        {
            get { return tb_patronal.Text.ToString(); }
            set { tb_patronal.Text = value; }
        }
        public string cat_prof
        {
            get { return tb_cat_prof.Text.ToString(); }
            set { tb_cat_prof.Text = value; }
        }
        /// </summary>
        string nome_entidade = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FinishButton_Click(object sender, ImageClickEventArgs e)
        {
            if (tb_parecer.Text != "")
            {
                BAL_cartao cartao = new BAL_cartao();
                string data = DateTime.Now.ToShortDateString();
                BAL_entidades entidade = new BAL_entidades();
                nome_entidade = entidade.get_entidade_by_id(Convert.ToInt32(Session["identidade"]));
                if (nome_entidade == "PSP")
                {
                    cartao.update_parecer_psp(id_cartao, Session["user"].ToString(), data, tb_parecer.Text, "0");
                }

                if (nome_entidade == "SEF")
                {
                    cartao.update_parecer_sef(id_cartao, Session["user"].ToString(), data, tb_parecer.Text, "0");
                }
                send_email email = new send_email();
                string header = Server.MapPath("~\\Templates\\email_header.png");
                string footer = Server.MapPath("~\\Templates\\email_footer.png");
                email.email_parecer_entidade(header, footer, Session["user"].ToString(), data, tb_parecer.Text);
                Response.Redirect("~\\Users\\Admin_parecer.aspx");
            }
                else
            {         AddErrorToValidationSummary("Deve inserir alguma mensagem de parecer");
 
            }
        }
        /////////////////////////ADICIONAR MENSAGEM DE ERRO NO VALIDATION SUMMARY ////////////////
        protected void AddErrorToValidationSummary(string errorMessage)
        {
            CustomValidator custVal = new CustomValidator();
            custVal.IsValid = false;
            custVal.ErrorMessage = errorMessage;
            custVal.EnableClientScript = true;
            custVal.Display = ValidatorDisplay.None;
            custVal.ValidationGroup = "MyValidationGroup";
            this.Page.Form.Controls.Add(custVal);
            Response.Redirect("../Users/admin_parecer.aspx");
        }
       
    }
        
}