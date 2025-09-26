using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.BAL;
using WebApplication10.PROP;

namespace WebApplication10.controls
{
    public partial class cartao_form : System.Web.UI.UserControl
    {
        /// <summary>
        /// CARREGAR VALORES NAS TEXTBOX NOS RADIOBUTTONS E NAS CHECKBOX PARA O PROCESSO DE RENOVACAO E SEGUNDA VIA////////////
        public bool renovacao
        {
            set
            {
                Panel_renovacao.Visible = value;
            }
        }
        public bool num_cartao_visible
        {
            set
            {
                Panel_num_cartao.Visible = value;
            }
        }
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
        public string numero
        {
            get { return tb_num.Text.ToString(); }
            set { tb_num.Text = value; }
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
        public string nome_entidade
        {
            get { return tb_nome_entidade.Text.ToString(); }
            set { tb_nome_entidade.Text = value; }
        }
        public void rb_checked_by_BD(string entrada)
        {
            if (entrada == "Permanente")
            {
                rb_tipo_cartao.SelectedIndex = 0;
               
            }
            else
                if (entrada == "Temporario")
                {
                    rb_tipo_cartao.SelectedIndex = 1;
                    Panel_validade_acesso.Visible = true;
                }
                else
                    if (entrada == "Acompanhado")
                    {
                        rb_tipo_cartao.SelectedIndex = 2;
                        Panel_acompanhante.Visible = true;
                        Panel_cartao_acaompanhante_upload.Visible = true;
                    }

        }
        public string renovacao_n_cartao
        {
            get { return tb_r_cartao.Text.ToString(); }
            set { tb_r_cartao.Text = value; }
        }
        public string areas_trabalho
        {
            get { return tb_areas_trabalho.Text.ToString(); }
            set { tb_areas_trabalho.Text = value; }
        }
        public string funcao
        {
            get { return tb_funcao.Text.ToString(); }
            set { tb_funcao.Text = value; }
        }
        public string horario
        {
            get { return tb_horario.Text.ToString(); }
            set { tb_horario.Text = value; }
        }
        public string acompanhante
        {
            get { return tb_acompanhante.Text.ToString(); }
            set { tb_acompanhante.Text = value; }
        }
        public string areas
        {
            get { return lb_areas.Text.ToString(); }
            set
            {
                cb_areas_funcoes.ClearSelection();
                lb_areas.Text = value;
                string areas_string = lb_areas.Text;
                char[] separator = new char[] { ' ' };
                string[] strSplitArr = areas_string.Split(separator);
                for (int i = 0; i < strSplitArr.Length; i++)
                {
                    foreach (System.Web.UI.WebControls.ListItem item in cb_areas_funcoes.Items)
                    {
                        if (strSplitArr[i].ToString() == item.Value)
                        {
                            item.Selected = true;
                        }
                    }
                }

            }
        }
        public void cb_portas_by_bd(string entrada)
        {
            portas.Checked = false;
            outras.Checked = false;
            tb_outras.Visible = false;
            string portas_string = entrada;
            char[] separator = new char[] { '&' };
            string[] strSplitArr = portas_string.Split(separator);
            for (int i = 0; i < strSplitArr.Length; i++)
            {

                bool startsWith = strSplitArr[i].StartsWith("Portas de embarque/desembarque");

                if (startsWith == true)
                {
                    portas.Checked = true;
                }
                if (strSplitArr[i] != "Portas de embarque/desembarque" && strSplitArr[i] != " " && strSplitArr[i] != "")
                {
                    outras.Checked = true;
                    tb_outras.Visible = true;
                    tb_outras.Text = strSplitArr[i];
                }
            }
        }
        public void rb_inquerido_by_BD(string entrada)
        {
            if (entrada == "Sim")
            {
                RadioButtonList_inquerito.SelectedIndex = 0;
            }
            else
                if (entrada == "Não")
                {
                    RadioButtonList_inquerito.SelectedIndex = 1;
                }
        }
        public void rb_formacao_by_BD(string entrada)
        {
            if (entrada == "Sim")
            {
                RadioButtonList_formacao.SelectedIndex = 0;
            }
            else
                if (entrada == "Não")
                {
                    RadioButtonList_formacao.SelectedIndex = 1;
                }
        }
        /// </summary>

       
        public string path;
        protected void Page_Load(object sender, EventArgs e)
        {
            /////DECLARACAO DAS PATHS PARA OS DOCUMETNOS E PARA OS THUMBNAILS DAS FOTOGRAFIAS DOS CARTOES///////////////
            path = @"D:\\cartoes\" + tb_nome_entidade.Text + "\\" + tb_num.Text;
             ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            CalendarExtender2.EndDate = DateTime.Now;
            if (!IsPostBack)
            {
                /////////////////////////////////LIMPAR VARIAVEIS DE SESSAO DO CARREGAMENTO DE DOCUMETNOS///////////////////////////////
                Session["flag_upload_c"] = 0;
                Session["AFileUpload_bi"] = "";
                Session["AFileUpload_vinculo"] = "";
                Session["AFileUpload_foto"] = "";
                Session["AFileUpload_r_criminal"] = "";
                Session["AFileUpload_cartao_acompanhante"] = "";
                Session["AFileUpload_cartao_renovacao"] = "";
                ///////////////////////INICCIAR A DATA DOS EXTENDER COMO A DATA ACTUAL PARA COMECAR////////////////////////////////////
                CalendarExtender3.StartDate = DateTime.Now;
                if (acao == "0")
                {
                    ////////////////////////////////////////////////SE FOR A PRIMEIRA INSERCAO VAI VERIFICAR E INCREMENTAR O NUMERO DO CARTAO E VAI CARREGAR A ENTIDADE PELO UTILIZADOR/////////////
                    BAL_entidades entidades = new BAL_entidades();
                    BAL_cartao numero = new BAL_cartao();
                    int num_cartao = Convert.ToInt32(numero.numero_cartao());
                    num_cartao = num_cartao + 1;
                    tb_num.Text = num_cartao.ToString();
                    tb_nome_entidade.Text = entidades.get_entidade_by_id(Convert.ToInt32(Session["identidade"]));

                }
            }
        }
    
        //////////////////////////LIMPAR OS FILEUPLOADS/////////////////////////////////////////////////////
        protected void limpar_fileupload()
        {
            Session["flag_upload_c"] = 0;
            Session["AFileUpload_bi"] = "";
            Session["AFileUpload_vinculo"] = "";
            Session["AFileUpload_foto"] = "";
            Session["AFileUpload_r_criminal"] = "";
            Session["AFileUpload_cartao_acompanhante"] = "";
            Session["AFileUpload_cartao_renovacao"] = "";
            AFileUpload_bi.ClearFileFromPersistedStore();
            AFileUpload_vinculo.ClearFileFromPersistedStore();
            AFileUpload_foto.ClearFileFromPersistedStore();
            AFileUpload_r_criminal.ClearFileFromPersistedStore();
            AFileUpload_cartao_acompanhante.ClearFileFromPersistedStore();
            AFileUpload_cartao_renovacao.ClearFileFromPersistedStore();

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            validar_cartao();
        }
   
        /// /////////////////////////////VALIDAR CARTAO E ATRIBUIR VALOR AOS MESMOS////////////////////////////////
   
        protected string validar_cartao()
        {
            if (rb_tipo_cartao.SelectedIndex == 1)
            {
                Panel_validade_acesso.Visible = true;
                Panel_acompanhante.Visible = false;
                Panel_cartao_acaompanhante_upload.Visible = false;
                return "Temporario";
            }

            else

                if (rb_tipo_cartao.SelectedIndex == 0)
                {
                    Panel_validade_acesso.Visible = false;
                    Panel_acompanhante.Visible = false;
                    Panel_cartao_acaompanhante_upload.Visible = false;
                    return "Permanente";
                }
                else
                    if (rb_tipo_cartao.SelectedIndex == 2)
                    {
                        Panel_validade_acesso.Visible = false;
                        Panel_acompanhante.Visible = true;
                        Panel_cartao_acaompanhante_upload.Visible = true;
                        return "Acompanhado";
                    }
                    else
                        return null;
        }
       // ///////////////////////////////BOTAO PARA FINALIZAR E IRA ATRIBUIR A INSERCAO=0/SEGUNDAVIA=1/RENOVACAO=2////////////////////
        protected void cartao_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        { /////////DECLARACAO VARIAVEIS  E CARREGAR VALORES/////////////////////////////
            string portas = validar_portas();
            string data_alterada = DateTime.Now.ToString("dd-mm-yyyy_HH-mm-ss");
            string header = Server.MapPath("~\\Templates\\email_header.png");
            string footer = Server.MapPath("~\\Templates\\email_footer.png");
            string areas_funcoes = validar_areas_funcoes();
            MembershipUser u = Membership.GetUser(Session["UserID"].ToString());
            string s_email = u.Email;
            send_email email = new send_email();
            BAL_users user = new BAL_users();
            BAL_entidades entidades = new BAL_entidades();
            BAL_cartao cartao = new BAL_cartao();
            /////////////////////////ADICIONAR MESES/////////////////
            string data_validade = "";
            if (tb_validade_acesso.Text != "")
            {
                data_validade = meses_contagem(Convert.ToInt32(tb_validade_acesso.Text));
            }

            if (acao == "0")///INSERCAO
            {
                string newFile = Path.Combine(path) + "\\" + tb_nome.Text + ".pdf";
                if (Convert.ToInt32(Session["flag_upload_c"]) >= 2)
                {
                    /////////////////////////INSERIR BASE DE DADOS/////////////////////////////
                    cartao.Create_cartao(tb_nome.Text, tb_morada.Text, tb_localidade.Text, tb_codigo_postal.Text, tb_telefone.Text, tb_telefone.Text, tb_tlf_serv.Text, tb_nacionalidade.Text, tb_bi.Text, tb_validade_bi.Text, tb_d_nascimento.Text,
                        Email.Text, tb_patronal.Text, tb_cat_prof.Text, validar_cartao(), tb_areas_trabalho.Text, data_validade, tb_funcao.Text, tb_horario.Text,
                       areas_funcoes, tb_cartao_acompanhante.Text, portas, RadioButtonList_inquerito.SelectedValue, RadioButtonList_formacao.SelectedValue, Session["AFileUpload_bi"].ToString(), Session["AFileUpload_vinculo"].ToString(), Session["AFileUpload_foto"].ToString(), newFile, Session["AFileUpload_r_criminal"].ToString(), Session["AFileUpload_cartao_acompanhante"].ToString(), "Pendente", Convert.ToInt32(Session["identidade"]),
                        DateTime.Now.ToShortDateString(), Session["user"].ToString(), tb_num.Text, tb_acompanhante.Text, Session["UserID"].ToString().ToUpper());
                    ////////////////CRIAR DOCUMETNO FINAL////////////////////////////////////
                    report(path, areas_funcoes, Session["user"].ToString(), newFile, "Original");
                    ////////////////STRING PARA O EMAIL////////////////////////////////////
                    string dados = "Novo Registo de Pedido de Cartão de Identificação/Acesso - Pedido Nº " + tb_num.Text;
                    ////////////////ENVIAR EMAIL////////////////////////////////////
                    email.registo_cartao(dados, tb_num.Text, DateTime.Now.ToString(), tb_nome.Text, tb_patronal.Text,
                        Session["user"].ToString(), tb_nome_entidade.Text, s_email, header, footer);
                    ////////////////LIMPAR FILEUPLOAD E ENCAMINHAR PARA A PAGINA SUCESSO////////////////////////////////////
                    limpar_fileupload();
                    Response.Redirect("~/Users/homesucess.aspx");
                }
                else
                {
                   ////////////////////////PAGINA DE ERRO//////////////////////////
                    AddErrorToValidationSummary("Por favor reveja os documentos a carregar.");
                    limpar_fileupload();
                }
            }
            if (acao == "1")///SEGUNDAVIA
            {
                if (Convert.ToInt32(Session["flag_upload_c"]) >= 2)
                {
                    /////////DECLARACAO VARIAVEIS/////////////////////////////
                    string watermark = Server.MapPath("~\\Templates\\segunda_via.png");
                    string doc_segunda_via = path + "\\" + "segunda_via" + "\\";
                    string newFile = Path.Combine(doc_segunda_via) + "segunda_via_" + tb_nome.Text + "_" + data_alterada + ".pdf";
                    ///////APAGAR DOCUMENTOS ANTIGOS E COLOCAR A MARCA DE AGUA NO DOCUEMTNO PRINCIPAL///////////
                    delete_old_docs(id_cartao, watermark);
                    ///////////////INSERIR A BASE DE DADOS///////////////
                    cartao.insert_segunda_via_cartao(tb_nome.Text, tb_morada.Text, tb_localidade.Text, tb_codigo_postal.Text, tb_telefone.Text, tb_telefone.Text, tb_tlf_serv.Text, tb_nacionalidade.Text, tb_bi.Text, tb_validade_bi.Text, tb_d_nascimento.Text,
                            Email.Text, tb_patronal.Text, tb_cat_prof.Text, validar_cartao(), tb_areas_trabalho.Text, data_validade, tb_funcao.Text, tb_horario.Text,
                           areas_funcoes, tb_cartao_acompanhante.Text, portas, RadioButtonList_inquerito.SelectedValue, RadioButtonList_formacao.SelectedValue, Session["AFileUpload_bi"].ToString(), Session["AFileUpload_vinculo"].ToString(), Session["AFileUpload_foto"].ToString(), Session["AFileUpload_r_criminal"].ToString(), Session["AFileUpload_cartao_acompanhante"].ToString(), "Pendente", Convert.ToInt32(Session["identidade"]),
                            DateTime.Now.ToShortDateString(), Session["user"].ToString(), tb_num.Text, tb_acompanhante.Text, newFile, id_cartao);
                    ////////////////////CRIAR PDF DOCUMENTO FINAL///////////////
                    report(doc_segunda_via, areas_funcoes, Session["user"].ToString(), newFile, "Segunda Via");
                    ////////////////DADOS PARA O EMAIL///////////
                    string dados = "Nova Requisição de segunda via do Pedido de Cartão de Identificação/Acesso - Pedido Nº " + tb_num.Text;
                   ////////////ENVIAR EMAIL////////////////
                    email.registo_cartao(dados, tb_num.Text, DateTime.Now.ToString(), tb_nome.Text, tb_patronal.Text,
                        Session["user"].ToString(), tb_nome_entidade.Text, s_email, header, footer);
                    //////////////LIMPAR OS FILEUPLOADS E IR PARA A PAGINA SUCESSO///////////////////
                    limpar_fileupload();
                    Response.Redirect("~/Users/homesucess.aspx");
                }
                else
                {///////////////////////ERRRO////////////////////////
                    AddErrorToValidationSummary("Por favor reveja os documentos a carregar.");
                    limpar_fileupload();
                }
            }
            if (acao == "2")////RENOVACAO
            {
                if (Convert.ToInt32(Session["flag_upload_c"]) >= 3)
                {
                    /////////DECLARACAO VARIAVEIS/////////////////////////////
                    string doc_renovacao = path + "\\" + "renovacao" + "\\";
                    string newFile = Path.Combine(doc_renovacao) + "renovacao_" + tb_nome.Text + "_" + data_alterada + ".pdf";
                    string watermark = Server.MapPath("~\\Templates\\renovado.png");
                    ///////APAGAR DOCUMENTOS ANTIGOS E COLOCAR A MARCA DE AGUA NO DOCUEMTNO PRINCIPAL///////////
                    delete_old_docs(id_cartao, watermark);
                    ///////////////INSERIR A BASE DE DADOS///////////////
                    cartao.insert_renovacao_cartao(tb_nome.Text, tb_morada.Text, tb_localidade.Text, tb_codigo_postal.Text, tb_telefone.Text, tb_telefone.Text, tb_tlf_serv.Text, tb_nacionalidade.Text, tb_bi.Text, tb_validade_bi.Text, tb_d_nascimento.Text,
                            Email.Text, tb_patronal.Text, tb_cat_prof.Text, validar_cartao(), tb_areas_trabalho.Text, data_validade, tb_funcao.Text, tb_horario.Text,
                           areas_funcoes, tb_cartao_acompanhante.Text, portas, RadioButtonList_inquerito.SelectedValue, RadioButtonList_formacao.SelectedValue, Session["AFileUpload_bi"].ToString(), Session["AFileUpload_vinculo"].ToString(), Session["AFileUpload_foto"].ToString(), Session["AFileUpload_r_criminal"].ToString(), Session["AFileUpload_cartao_acompanhante"].ToString(), "Pendente", Convert.ToInt32(Session["identidade"]),
                            DateTime.Now.ToShortDateString(), Session["user"].ToString(), tb_num.Text, tb_acompanhante.Text, newFile, Session["AFileUpload_cartao_renovacao"].ToString(), id_cartao);
                  ///////////////////CRIRAR PDF DOCUMENTO FINAL/////////////////////////
                    report(doc_renovacao, areas_funcoes, Session["user"].ToString(), newFile, "Renovação");
                    ////////////////DADOS PARA O EMAIL///////////
                    string dados = "Nova Requisição de Renovação Pedido de Cartão de Identificação/Acesso - Pedido Nº " + tb_num.Text;
                    ////////////ENVIAR EMAIL////////////////
                    email.registo_cartao(dados, tb_num.Text, DateTime.Now.ToString(), tb_nome.Text, tb_patronal.Text,
                        Session["user"].ToString(), tb_nome_entidade.Text, s_email, header, footer);
                    ////////////LIMPAR OS FILEUPLOADS E IR PARA A PAGINA SUCESSO////////////////
                    limpar_fileupload();
                    Response.Redirect("~/Users/homesucess.aspx");
                }
                else
                {
                    ///////////////ERRO////////////////
                    AddErrorToValidationSummary("Por favor reveja os documentos a carregar.");
                    limpar_fileupload();
                }
            }
        }
        /// //////ADICIONAR MESES////////////////
        protected string meses_contagem(int meses)
        {
            DateTime data = DateTime.Now.AddMonths(meses);
            string data2 = data.ToShortDateString();
            return data2;
        }
        ////////////////////ALTERACAO DOS INDEX DE SELECAO DAS PORTAS /////////////////////// 
        protected void cb_portas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (outras.Checked)
                tb_outras.Visible = true;
            else
                if (outras.Checked == false)
                    tb_outras.Visible = false;
        }
    
        /// //////////////APAGAR DOCUMENTOS ANTIGOS E POR WATERMARK///////////////////////
        public void delete_old_docs(int id, string watermark)
        {
            BAL_cartao cartao = new BAL_cartao();
            List<PROP_cartao> lista_cartao = new List<PROP_cartao>();
            lista_cartao = cartao.get_cartao_renovacao_by_id(id);
            string old_fotocopia_bi = lista_cartao[0].fotocopia_bi;
            string old_fotocopia_vinculo_laboral = lista_cartao[0].fotocopia_vinculo_laboral;
            string old_fotografia = lista_cartao[0].fotografia;
            string old_registo_criminal = lista_cartao[0].registo_criminal;
            string old_fotocopia_cartao_acompanhante = lista_cartao[0].cartao_pontual_visitante;
            string old_fotocopia_cartao_identificacao = "";//FALTA FAZER O STORED PRA VER O CAMINHO DA FOTOCOPIA DO CARTAO
            StampDocument.PutImageWaterMark(lista_cartao[0].path_doc_final, watermark);
            if (File.Exists(old_fotocopia_bi) && old_fotocopia_bi != Session["AFileUpload_bi"].ToString())
            {
                File.Delete(old_fotocopia_bi);
            }

            if (File.Exists(old_fotocopia_vinculo_laboral) && old_fotocopia_vinculo_laboral != Session["AFileUpload_vinculo"].ToString())
            {
                File.Delete(old_fotocopia_vinculo_laboral);
            }
            if (File.Exists(old_fotografia) && old_fotografia != Session["AFileUpload_foto"].ToString())
            {
                File.Delete(old_fotografia);
            }
            if (File.Exists(old_registo_criminal) && old_registo_criminal != Session["AFileUpload_r_criminal"].ToString())
            {
                File.Delete(old_registo_criminal);
            }
            if (File.Exists(old_fotocopia_cartao_acompanhante) && old_fotocopia_cartao_acompanhante != Session["AFileUpload_cartao_acompanhante"].ToString())
            {
                File.Delete(old_fotocopia_cartao_acompanhante);
            }
            if (acao == "2")
            {
                if (File.Exists(old_fotocopia_cartao_identificacao) && old_fotocopia_cartao_identificacao != Session["AFileUpload_cartao_renovacao"].ToString())
                {
                    File.Delete(old_fotocopia_cartao_identificacao);
                }
            }
        }

        protected string validar_areas_funcoes()
        {
            Label lbl_areas_funcoes = new Label();
            foreach (System.Web.UI.WebControls.ListItem item in cb_areas_funcoes.Items)
            {
                if (item.Selected)
                    lbl_areas_funcoes.Text += item.Value + " ";
            }
            return lbl_areas_funcoes.Text;
        }
        /// /////////////////////////////// ATRIBUIR VALOR AS PORTAS//////////////////////
        protected string validar_portas()
        {

            if (portas.Checked && outras.Checked)
            {
                return "Portas de embarque/desembarque" + " & " + tb_outras.Text;
            }
            else
                if (portas.Checked)
                {

                    return "Portas de embarque/desembarque";
                }
                else

                    if (outras.Checked)
                    {

                        return tb_outras.Text;

                    }
            return " ";
        }

        /// /////////////////////////CRIAR PDF COM DOCUMETNO FINAL//////////////////////////////////////////////
        protected void report(string path, string tipo_cartao, string nome_requerente, string newFile, string tipo)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string oldFile = Server.MapPath("~\\Templates\\cartao.pdf");


            // open the reader
            PdfReader reader = new PdfReader(oldFile);
            Rectangle size = reader.GetPageSizeWithRotation(1);
            Document document = new Document(size);

            // open the writer
            FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            // the pdf content
            PdfContentByte cb = writer.DirectContent;

            // select the font properties
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.DARK_GRAY);
            cb.SetFontAndSize(bf, 8);

            // write the text in the pdf content
            cb.BeginText();
            string text = this.tb_num.Text.Trim();
            // put the alignment and coordinates here
            cb.ShowTextAligned(1, text, 520, 760, 0);
            cb.EndText();
            cb.BeginText();
            text = DateTime.Now.ToString();
            // put the alignment and coordinates here
            cb.ShowTextAligned(2, text, 225, 733, 0);
            cb.EndText();

            cb.BeginText();
            text = nome_requerente.Trim();
            cb.ShowTextAligned(3, text, 310, 733, 0);
            cb.EndText();

            cb.BeginText();
            text = this.tb_nome.Text.Trim();
            cb.ShowTextAligned(3, text, 150, 678, 0);
            cb.EndText();
            ////////////
            cb.BeginText();
            text = this.tb_morada.Text.Trim();
            cb.ShowTextAligned(3, text, 115, 658, 0);
            cb.EndText();

            ////////////
            cb.BeginText();
            text = this.tb_localidade.Text.Trim();
            cb.ShowTextAligned(3, text, 410, 658, 0);
            cb.EndText();
            //////////////////////////////////
            cb.BeginText();
            text = this.tb_codigo_postal.Text.Trim();
            cb.ShowTextAligned(3, text, 145, 638, 0);
            cb.EndText();

            cb.BeginText();
            text = this.tb_telefone.Text.Trim();
            cb.ShowTextAligned(3, text, 240, 638, 0);
            cb.EndText();

            cb.BeginText();
            text = this.tb_tlm.Text.Trim();
            cb.ShowTextAligned(3, text, 338, 638, 0);
            cb.EndText();

            cb.BeginText();
            text = this.tb_tlf_serv.Text.Trim();
            cb.ShowTextAligned(3, text, 468, 638, 0);
            cb.EndText();
            ////////////////////////
            cb.BeginText();
            text = this.tb_nacionalidade.Text.Trim();
            cb.ShowTextAligned(3, text, 143, 619, 0);
            cb.EndText();

            cb.BeginText();
            text = this.tb_bi.Text.Trim();
            cb.ShowTextAligned(3, text, 338, 619, 0);
            cb.EndText();

            cb.BeginText();
            text = this.tb_validade_bi.Text.Trim();
            cb.ShowTextAligned(3, text, 465, 619, 0);
            cb.EndText();
            //////////////

            cb.BeginText();
            text = this.tb_d_nascimento.Text.Trim();
            cb.ShowTextAligned(3, text, 165, 600, 0);
            cb.EndText();

            cb.BeginText();
            text = this.Email.Text.Trim();
            cb.ShowTextAligned(3, text, 305, 600, 0);
            cb.EndText();
            ////////////////////////

            cb.BeginText();
            text = this.tb_patronal.Text.Trim();
            cb.ShowTextAligned(3, text, 157, 582, 0);
            cb.EndText();

            cb.BeginText();
            text = this.tb_cat_prof.Text.Trim();
            cb.ShowTextAligned(3, text, 370, 582, 0);
            cb.EndText();
            /////////////////////
            cb.BeginText();
            text = this.tb_nome_entidade.Text.Trim();
            cb.ShowTextAligned(3, text, 180, 520, 0);
            cb.EndText();
            ////////////////////
            cb.BeginText();
            text = validar_cartao();
            cb.ShowTextAligned(3, text, 180, 500, 0);
            cb.EndText();

            cb.BeginText();
            text = tb_r_cartao.Text.Trim();
            cb.ShowTextAligned(3, text, 535, 500, 0);
            cb.EndText();

            //////////////////////
            cb.BeginText();

            text = tb_areas_trabalho.Text.Trim();
            cb.ShowTextAligned(3, text, 225, 476, 0);
            cb.EndText();

            cb.BeginText();
            text = this.tb_validade_acesso.Text.Trim();
            cb.ShowTextAligned(3, text, 460, 476, 0);
            cb.EndText();
            //////////////////////

            cb.BeginText();
            text = this.tb_funcao.Text.Trim();
            cb.ShowTextAligned(3, text, 112, 458, 0);
            cb.EndText();

            cb.BeginText();
            text = this.tb_horario.Text.Trim();
            cb.ShowTextAligned(3, text, 425, 458, 0);
            cb.EndText();
            /////////////////
            cb.BeginText();
            text = this.tb_funcao.Text.Trim();
            cb.ShowTextAligned(3, text, 112, 458, 0);
            cb.EndText();

            /////////////
            cb.BeginText();
            text = validar_areas_funcoes();
            cb.ShowTextAligned(3, text, 280, 438, 0);
            cb.EndText();

            if (rb_tipo_cartao.SelectedValue == "Acompanhado")
            {
                cb.BeginText();
                text = "X";
                cb.ShowTextAligned(3, text, 75, 418, 0);
                cb.EndText();
                ////////////////

                cb.BeginText();
                text = this.tb_acompanhante.Text;
                cb.ShowTextAligned(3, text, 300, 418, 0);
                cb.EndText();

                ////////////////
                cb.BeginText();
                text = this.tb_cartao_acompanhante.Text;
                cb.ShowTextAligned(3, text, 530, 418, 0);
                cb.EndText();

            }

            //////////////////////
            cb.BeginText();
            text = validar_portas();
            cb.ShowTextAligned(3, text, 90, 380, 0);
            cb.EndText();
            /////////////////

            cb.BeginText();
            text = RadioButtonList_inquerito.SelectedValue;
            cb.ShowTextAligned(3, text, 233, 339, 0);
            cb.EndText();
            //////////////

            cb.BeginText();
            text = RadioButtonList_formacao.SelectedValue;
            cb.ShowTextAligned(3, text, 300, 290, 0);
            cb.EndText();
            //////////////
            cb.BeginText();
            text = tipo.Trim();
            cb.ShowTextAligned(14, text, 520, 830, 0);
            cb.EndText();

            // create the new page and add it to the pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            cb.AddTemplate(page, 0, 0);
            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();

        }

   
        ////////////////////// SIDEBEBAR DOS WIZARDSTPS/////////////////////

        protected void SideBarList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            WizardStep dataItem = e.Item.DataItem as WizardStep;
            LinkButton linkButton = e.Item.FindControl("SideBarButton") as LinkButton;
            if (dataItem != null)
            {
                //If active step index less than item index lets disable the link
                if (dataItem.Wizard.ActiveStepIndex < e.Item.ItemIndex)
                {
                    linkButton.Enabled = false;
                    linkButton.CssClass = "disabledbtn";
                }
                //If active step index equals to item index lets remove underline
                if (dataItem.Wizard.ActiveStepIndex == e.Item.ItemIndex)
                {
                    linkButton.Enabled = true;
                    linkButton.CssClass = "enabledbtn";
                }
                if (dataItem.Wizard.ActiveStepIndex > e.Item.ItemIndex)
                {
                    linkButton.Style.Add(HtmlTextWriterStyle.TextDecoration, "none");
                    linkButton.Style.Add(HtmlTextWriterStyle.BackgroundImage, "url('../Layout/img/btn_side.png')");
                    linkButton.Style.Add(HtmlTextWriterStyle.Color, "#0E4564");
                    linkButton.Enabled = true;
                }
            }
        }
       
        /// ///////////////////CARREGAR BI//////////////////////////////////
        protected void AFileUpload_bi_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AFileUpload_bi.HasFile)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Session["flag_upload_c"] = Convert.ToInt32(Session["flag_upload_c"]) + 1;
                Session["AFileUpload_bi"] = path + "\\" + "bi_" + AFileUpload_bi.FileName;
                AFileUpload_bi.SaveAs(Session["AFileUpload_bi"].ToString());
            }
        }

        /// ///////////////////CARREGAR CARTAO DE ACOMPANHANTE//////////////////////////////////
        protected void AFileUpload_cartao_acompanhante_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AFileUpload_cartao_acompanhante.HasFile)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //Session["flag_upload_c"] = Convert.ToInt32(Session["flag_upload_c"]) + 1;
                Session["AFileUpload_cartao_acompanhante"] = path + "\\" + "ccirculacao_" + AFileUpload_cartao_acompanhante.FileName;
                AFileUpload_cartao_acompanhante.SaveAs(Session["AFileUpload_cartao_acompanhante"].ToString());
            }
        }

        /// ///////////////////CARREGAR CARTAO PARA O PROCESSO DE RENOVACAO//////////////////////////////////
        protected void AFileUpload_cartao_renovacao_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AFileUpload_cartao_renovacao.HasFile)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Session["flag_upload_c"] = Convert.ToInt32(Session["flag_upload_c"]) + 1;
                Session["AFileUpload_cartao_renovacao"] = path + "\\" + "renovacao_" + AFileUpload_cartao_renovacao.FileName;
                AFileUpload_cartao_renovacao.SaveAs(Session["AFileUpload_cartao_renovacao"].ToString());
            }
        }

        /// ///////////////////CARREGAR FOTOGRAFIA//////////////////////////////////
        protected void AFileUpload_foto_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AFileUpload_foto.HasFile)
            {
                var r = new Random();
                int random = (r.Next(100));

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Session["flag_upload_c"] = Convert.ToInt32(Session["flag_upload_c"]) + 1;
                Session["AFileUpload_foto"] = path + "\\" + "foto_" + random.ToString() + AFileUpload_foto.FileName;
                AFileUpload_foto.SaveAs(Session["AFileUpload_foto"].ToString());

                string fileName = "foto_" + random.ToString() + AFileUpload_foto.FileName;
                string sourcePath = @path;
                string targetPath = @"D:\\fotos\" + tb_nome_entidade.Text + "\\" + tb_num.Text+ "\\" ;

                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);

                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                System.IO.File.Copy(sourceFile, destFile, true);

            }
        }

        /// ///////////////////CARREGAR REGISTO CRIMINAL//////////////////////////////////
        protected void AFileUpload_r_criminal_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AFileUpload_r_criminal.HasFile)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //Session["flag_upload_c"] = Convert.ToInt32(Session["flag_upload_c"]) + 1;
                Session["AFileUpload_r_criminal"] = path + "\\" + "rcriminal_" + AFileUpload_r_criminal.FileName;
                AFileUpload_r_criminal.SaveAs(Session["AFileUpload_r_criminal"].ToString());
            }
        }

        /// ///////////////////CARREGAR VINCULO//////////////////////////////////
        protected void AFileUpload_vinculo_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AFileUpload_vinculo.HasFile)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //Session["flag_upload_c"] = Convert.ToInt32(Session["flag_upload_c"]) + 1;
                Session["AFileUpload_vinculo"] = path + "\\" + "vinculo_" + AFileUpload_vinculo.FileName;
                AFileUpload_vinculo.SaveAs(Session["AFileUpload_vinculo"].ToString());
            }
        }
        /// ///////////////////VALIDAR SE OUTRAS ESTAO MARCADAS TEM DE TER TEXTO//////////////////////////////////
        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (outras.Checked == true && tb_outras.Text == "")
            {
                args.IsValid = false;
               
            }
            else
                args.IsValid = true;
        }
        /// ///////////////////VALIDAR QUE A CHECKBOX ESTA SELECIONADA//////////////////////////////////
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = cb_validate.Checked;
  
        }
        /// ///////////////////ADICIONAR MENSAGEM DE ERRO AO VALIDATOR SUMMARY//////////////////////////////////
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

        /// ///////////////////NO ENVENTO DO BOTAO SEGUINTE PARA VALIDAR//////////////////////////////////
        protected void cartao_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (!Page.IsValid)
            {
                e.Cancel = true;
            }
        }
    }

}