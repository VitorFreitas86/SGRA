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
    public partial class viatura_form : System.Web.UI.UserControl
    {
        /// <summary>
        /// CARREGAR TEXTBOX CHECKBOX E RADIOBUTTON COM VALORES VINDOS DA BASE DE DADOS/////////

        public int ID_viatura
        {
            get { return Convert.ToInt32(ViewState["id_viatura"]); }
            set { ViewState["id_viatura"] = value; }
        }


        public bool fileupload_cartao_viatura
        {
            set
            {
                Panel_renovaca_circulacao.Visible = value;
            }
        }
        public bool distico
        {
            set
            {
                tb_r_distico.Visible = value;
                lb_distico.Visible = value;
            }
        }
        public string numero
        {
            get { return tb_num.Text.ToString(); }
            set { tb_num.Text = value; }
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
        public string n_identificacao
        {
            get { return tb_n_identificao.Text.ToString(); }
            set { tb_n_identificao.Text = value; }
        }
        public string marca
        {
            get { return tb_marca.Text.ToString(); }
            set { tb_marca.Text = value; }
        }
        public string modelo
        {
            get { return tb_modelo.Text.ToString(); }
            set { tb_modelo.Text = value; }
        }
        public string cor
        {
            get { return tb_cor.Text.ToString(); }
            set { tb_cor.Text = value; }
        }
        public string matricula
        {
            get { return tb_matricula.Text.ToString(); }
            set { tb_matricula.Text = value; }
        }
        public string proprietario
        {
            get { return tb_proprietario.Text.ToString(); }
            set { tb_proprietario.Text = value; }
        }
        public string apolice
        {
            get { return tb_apolice.Text.ToString(); }
            set { tb_apolice.Text = value; }
        }
        public string companhia_seguros
        {
            get { return tb_companhia_seguros.Text.ToString(); }
            set { tb_companhia_seguros.Text = value; }
        }
        public string d_seguro
        {
            get { return tb_d_seguro.Text.ToString(); }
            set { tb_d_seguro.Text = value; }
        }
        public string ipo
        {
            get { return tb_ipo.Text.ToString(); }
            set { tb_ipo.Text = value; }
        }
        public string validade_ipo
        {
            get { return tb_validade_ipo.Text.ToString(); }
            set { tb_validade_ipo.Text = value; }
        }
        public string nome_entidade
        {
            get { return tb_nome_entidade.Text.ToString(); }
            set { tb_nome_entidade.Text = value; }
        }
        public string servico
        {
            get { return tb_servico.Text.ToString(); }
            set { tb_servico.Text = value; }
        }
        public string validade_acesso
        {
            get { return tb_validade_acesso.Text.ToString(); }
            set { tb_validade_acesso.Text = value; }
        }
        public string r_distico
        {
            get { return tb_r_distico.Text.ToString(); }
            set { tb_r_distico.Text = value; }
        }
        public void rb_checked_by_BD(string entrada)
        {
            if (entrada == "Circulação Permanente")
            {
                rb_tipo_circulação.SelectedIndex = 0;

            }
            else
                if (entrada == "Circulação Temporária")
                {
                    rb_tipo_circulação.SelectedIndex = 1;
                    Panel_validade_acesso.Visible = true;

                }

        }
        public int id_pedido_viatura
        {
            get
            {
                if (ViewState["id_pedido_viatura"] == null)
                    ViewState["id_pedido_viatura"] = string.Empty;
                return Convert.ToInt32(ViewState["id_pedido_viatura"].ToString());
            }
            set
            {
                ViewState["id_pedido_viatura"] = value;
            }
        }
        /// </summary>

        public string path;

        protected void Page_Load(object sender, EventArgs e)
        {
            //////////////CAMINHO PARA CARREGAR DOCUMENTOS//////////////
           path= @"D:\\viaturas\" + tb_nome_entidade.Text + "\\" + tb_num.Text;
            if (!IsPostBack)
            {
                CalendarExtender1.StartDate = DateTime.Now;
                CalendarExtender3.EndDate = DateTime.Now;
                CalendarExtender2.StartDate = DateTime.Now;
             Session["flag_upload_v"] = 0;
                Session["AFileUpload_livrete"] = "";
                Session["AFileUpload_r_propriedade"] = "";
                Session["AFileUpload_cobertura_seguradora"] = "";
                Session["AFileUpload_cartao_circulacao"]= "";
                Session["AFileUpload_c_verde"] = "";
                Session["AFileUpload_ipo"] = "";
                
                if (acao == "0")
                {
                    BAL_entidades entidades = new BAL_entidades();
                    BAL_viatura viatura = new BAL_viatura();
                    int num_viatura = Convert.ToInt32(viatura.numero_viatura());
                    num_viatura = num_viatura + 1;
                    tb_num.Text = num_viatura.ToString();
                    tb_nome_entidade.Text = entidades.get_entidade_by_id(Convert.ToInt32(Session["identidade"]));
                    tb_n_identificao.Text = entidades.get_codigo_entidade_by_id(Convert.ToInt32(Session["identidade"])) + "-" + viatura.get_viatura_entidade_by_id(Convert.ToInt32(Session["identidade"]));
                }
            }
        }

        ///// LIMNPAR DADOS DE CARREGAMENTO DE DOCUMETOS//////
        protected void limpar_fileupload()
        {
         Session["flag_upload_v"] = 0;
            Session["AFileUpload_livrete"] = "";
            Session["AFileUpload_r_propriedade"] = "";
            Session["AFileUpload_cobertura_seguradora"] = "";
            Session["AFileUpload_cartao_circulacao"] = "";
            Session["AFileUpload_c_verde"] = "";
            Session["AFileUpload_ipo"] = "";
            AFileUpload_livrete.ClearFileFromPersistedStore();
            AFileUpload_r_propriedade.ClearFileFromPersistedStore();
            AFileUpload_cobertura_seguradora.ClearFileFromPersistedStore();
            AFileUpload_cartao_circulacao.ClearFileFromPersistedStore();
            AFileUpload_c_verde.ClearFileFromPersistedStore();
            AFileUpload_ipo.ClearFileFromPersistedStore();
    
        }

        //////////////EVENTO DE CARREGAMENTO DE BOTAO ///////////
        protected void viatura_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            /////////DECLARACAO VARIAVEIS/////////////////////////////
            string datareg = DateTime.Now.ToShortDateString();
            string data_alterada = DateTime.Now.ToString("dd-mm-yyyy_HH-mm-ss");
            string header = Server.MapPath("~\\Templates\\email_header.png");
            string footer = Server.MapPath("~\\Templates\\email_footer.png");
            string tipo_cartao = validar_cartao();
            MembershipUser u = Membership.GetUser(Session["UserID"].ToString());
            string s_email = u.Email;
            send_email email = new send_email();
            BAL_users user = new BAL_users();
            BAL_entidades entidades = new BAL_entidades();
            BAL_viatura viatura = new BAL_viatura();
            /////////////////////////ADICIONAR MESES/////////////////
            string data_validade = "";
            if (tb_validade_acesso.Text != "")
            {
                data_validade = meses_contagem(Convert.ToInt32(tb_validade_acesso.Text));
            }

            if (acao == "0")//INSERCAO
            {
                if (Convert.ToInt32(Session["flag_upload_v"]) >= 4)
                {
                    /////////DECLARACAO VARIAVEIS/////////////////////////////
                    //string newFile = Path.Combine(path) + "\\" + tb_matricula.Text + ".pdf";
                    string newFile = Path.Combine(path) + "\\" + tb_matricula.Text + "_" + data_alterada + ".pdf";
                 
                    ///////////////INSERIR A BASE DE DADOS///////////////
           

                    viatura.Create(tb_marca.Text, tb_modelo.Text, tb_cor.Text, tb_matricula.Text.ToUpper(), tb_apolice.Text, tb_companhia_seguros.Text
                        , tb_d_seguro.Text, tb_ipo.Text, tb_validade_ipo.Text, tipo_cartao, tb_servico.Text, Session["AFileUpload_livrete"].ToString(),
                        Session["AFileUpload_r_propriedade"].ToString(), Session["AFileUpload_c_verde"].ToString(),
                      Session["AFileUpload_ipo"].ToString(), Session["AFileUpload_cobertura_seguradora"].ToString(), Convert.ToInt32(Session["identidade"]), "Pendente",
                         Session["user"].ToString(), tb_num.Text, tb_proprietario.Text, data_validade, datareg, newFile, tb_n_identificao.Text, "",Session["UserID"].ToString().ToUpper());
                    ///////////////////CRIRAR PDF DOCUMENTO FINAL/////////////////////////
                    report(path, tipo_cartao, Session["user"].ToString(), newFile, "Original");
                    ////////////////DADOS PARA O EMAIL///////////
                    string dados = "Novo Registo de Pedido de Acesso de viatura - Pedido Nº " + tb_num.Text;
                    ///////////ENVIAR EMAIL////////////////
                    email.registo_viatura(dados, tb_num.Text, datareg, tb_matricula.Text, tb_marca.Text, tb_modelo.Text, Session["user"].ToString(), tb_nome_entidade.Text, s_email, header, footer);
                    ////////////LIMPAR OS FILEUPLOADS E IR PARA A PAGINA SUCESSO////////////////
                    limpar_fileupload();
                    Response.Redirect("~/Users/homesucess.aspx");
                }
                else
                {
                    //////ERROS///////
                    AddErrorToValidationSummary("Por favor reveja os documentos a carregar.");
                    limpar_fileupload();
                }
            }

            if (acao == "1")//SEGUNDA VIA
            {            
                if (Convert.ToInt32(Session["flag_upload_v"]) >= 4)
                {
                  
                    /////////DECLARACAO VARIAVEIS/////////////////////////////
                    string watermark = Server.MapPath("~\\Templates\\segunda_via.png");
                    string doc_segunda_via = path + "\\" + "segunda_via" + "\\";
                    string newFile = Path.Combine(doc_segunda_via) + "segunda_via_" + tb_matricula.Text + "_" + data_alterada + ".pdf";
                    /////APAGAR DOCUMENTOS ANTIGOS E COLOCAR A MARCA DE AGUA NO DOCUEMTNO PRINCIPAL///////////
                    delete_old_docs(id_pedido_viatura, watermark);
                    ///////////////INSERIR A BASE DE DADOS///////////////
                    viatura.insert_segunda_via_viatura(id_pedido_viatura, apolice, companhia_seguros, d_seguro, ipo, validade_ipo, servico, tipo_cartao, data_validade, Session["AFileUpload_livrete"].ToString(), Session["AFileUpload_r_propriedade"].ToString(), Session["AFileUpload_c_verde"].ToString(), Session["AFileUpload_cobertura_seguradora"].ToString(), Session["AFileUpload_ipo"].ToString(), datareg, Session["user"].ToString(), newFile);
                    ///////////////////CRIRAR PDF DOCUMENTO FINAL/////////////////////////
                    report(doc_segunda_via, tipo_cartao, Session["user"].ToString(), newFile, "Segunda Via");
                    ////////////////DADOS PARA O EMAIL///////////
                    string dados = "Registo de Segunda Via do Pedido de Acesso da viatura - Pedido Nº " + tb_num.Text;
                    ////////////ENVIAR EMAIL////////////////
                    email.registo_viatura(dados, tb_num.Text, datareg, tb_matricula.Text, tb_marca.Text, tb_modelo.Text, Session["user"].ToString(), tb_nome_entidade.Text, s_email, header, footer);
                    ////////////LIMPAR OS FILEUPLOADS E IR PARA A PAGINA SUCESSO////////////////
                    limpar_fileupload();
                    Response.Redirect("~/Users/homesucess.aspx");
                }
                else
                {
                    ////ERROS/////
                    AddErrorToValidationSummary("Por favor reveja os documentos a carregar.");
                    limpar_fileupload();
                }
            }
            if (acao == "2")//RENOVACAO
            {
                if (Convert.ToInt32(Session["flag_upload_v"]) >= 5)
                {
                   
                    /////////DECLARACAO VARIAVEIS/////////////////////////////
                    string doc_renovacao = path + "\\" + "renovacao" + "\\";
                    string newFile = Path.Combine(doc_renovacao) + "renovacao_" + tb_matricula.Text + "_" + data_alterada + ".pdf";
                    string watermark = Server.MapPath("~\\Templates\\renovado.png");
                    ///////APAGAR DOCUMENTOS ANTIGOS E COLOCAR A MARCA DE AGUA NO DOCUEMTNO PRINCIPAL///////////
                    delete_old_docs(id_pedido_viatura, watermark);
                    ///////////////INSERIR A BASE DE DADOS///////////////
                    viatura.insert_renovacao_viatura(id_pedido_viatura, apolice, companhia_seguros, d_seguro, ipo, validade_ipo, servico, tipo_cartao, data_validade, Session["AFileUpload_livrete"].ToString(),
                    Session["AFileUpload_r_propriedade"].ToString(), Session["AFileUpload_c_verde"].ToString(), Session["AFileUpload_cobertura_seguradora"].ToString(), Session["AFileUpload_ipo"].ToString(), datareg, Session["user"].ToString(), newFile, Session["AFileUpload_cartao_circulacao"].ToString());
                    ///////////////////CRIRAR PDF DOCUMENTO FINAL/////////////////////////
                    report(doc_renovacao, tipo_cartao, Session["user"].ToString(), newFile, "Renovação");
                    ////////////////DADOS PARA O EMAIL///////////
                    string dados = "Registo do Pedido de Renovação do Acesso da viatura - Pedido Nº " + tb_num.Text;
                    ////////////ENVIAR EMAIL////////////////
                    email.registo_viatura(dados, tb_num.Text, datareg, tb_matricula.Text, tb_marca.Text, tb_modelo.Text, Session["user"].ToString(), tb_nome_entidade.Text, s_email, header, footer);
                    ////////////LIMPAR OS FILEUPLOADS E IR PARA A PAGINA SUCESSO////////////////
                    limpar_fileupload();
                    Response.Redirect("~/Users/homesucess.aspx");
                }
                else
                {
                    ///ERROS///
                    AddErrorToValidationSummary("Por favor reveja os documentos a carregar.");
                    limpar_fileupload();
                }
            }
        }

        ///////////APAGAR DOCUMENTOS/////////////
        public void delete_old_docs(int id, string watermark)
        {
            BAL_viatura viatura = new BAL_viatura();
            List<PROP_viatura> lista_viatura = new List<PROP_viatura>();
            lista_viatura = viatura.get_viatura_renovacao_by_ID(id);
            string[] old_doc = new string[5];
            old_doc[0] = lista_viatura[0].fotocopia_cartaverde;
            old_doc[1] = lista_viatura[0].fotocopia_declaracao_segurador;
            old_doc[2] = lista_viatura[0].fotocopia_ipo;
            old_doc[3] = lista_viatura[0].fotocopia_livrete;
            old_doc[4] = lista_viatura[0].fotocopia_registop;
            StampDocument.PutImageWaterMark(lista_viatura[0].path_doc_final_viaturas, watermark);
            for (int i = 0; i <= 4; i++)
            {
                if (old_doc[i] != Session["AFileUpload_livrete"].ToString() && old_doc[i] != Session["AFileUpload_r_propriedade"].ToString() && old_doc[i] != Session["AFileUpload_c_verde"].ToString() && old_doc[i] != Session["AFileUpload_cobertura_seguradora"].ToString() && old_doc[i] != Session["AFileUpload_ipo"].ToString() && old_doc[i] != Session["AFileUpload_cartao_circulacao"].ToString())
                {
                    if (File.Exists(old_doc[i]))
                    {
                        File.Delete(old_doc[i]);
                    }
                }
            }
        }

        /////////////VALIDAR CARTAO////////////////
        protected string validar_cartao()
        {
          
            if (rb_tipo_circulação.SelectedIndex == 1)
            {
                Panel_validade_acesso.Visible = true;
                return "Circulação Temporária";
            }
            else
                if (rb_tipo_circulação.SelectedIndex == 0)
                {
                    Panel_validade_acesso.Visible = false;
                    return "Circulação Permanente";

                }
                else return "";
        }

        ////////////FAZER O PDF PARA O DOCUMENTO FINAL////////////////
        protected void report(string path, string tipo_cartao, string nome_requerente, string newFile, string tipo)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string oldFile = Server.MapPath("~\\Templates\\viatura.pdf");


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
            cb.ShowTextAligned(1, text, 520, 739, 0);
            cb.EndText();
            cb.BeginText();
            text = DateTime.Now.ToString();
            // put the alignment and coordinates here
            cb.ShowTextAligned(2, text, 240, 700, 0);
            cb.EndText();

            cb.BeginText();
            text = nome_requerente.Trim();
            cb.ShowTextAligned(3, text, 313, 700, 0);
            cb.EndText();

            cb.BeginText();
            text = this.tb_marca.Text.Trim();
            cb.ShowTextAligned(3, text, 120, 617, 0);
            cb.EndText();

            cb.BeginText();
            text = this.tb_modelo.Text.Trim();
            cb.ShowTextAligned(4, text, 240, 617, 0);
            cb.EndText();

            cb.BeginText();
            text = this.tb_cor.Text.Trim();
            cb.ShowTextAligned(5, text, 340, 617, 0);
            cb.EndText();

            cb.BeginText();
            text = this.tb_matricula.Text.ToUpper().Trim();
            cb.ShowTextAligned(6, text, 460, 617, 0);
            cb.EndText();
            /////////////////////////////////

            cb.BeginText();
            text = tb_proprietario.Text.Trim();
            cb.ShowTextAligned(7, text, 145, 600, 0);
            cb.EndText();

            cb.BeginText();
            text = tb_n_identificao.Text;
            cb.ShowTextAligned(8, text, 470, 600, 0);
            cb.EndText();
            //////////////////////////////////

            cb.BeginText();
            text = tb_apolice.Text.Trim();
            cb.ShowTextAligned(8, text, 135, 585, 0);
            cb.EndText();

            cb.BeginText();
            text = tb_companhia_seguros.Text.Trim();
            cb.ShowTextAligned(8, text, 300, 585, 0);
            cb.EndText();


            cb.BeginText();
            text = tb_d_seguro.Text.Trim();
            cb.ShowTextAligned(8, text, 450, 585, 0);
            cb.EndText();
            //////////////////////////////////

            cb.BeginText();
            text = tb_ipo.Text.Trim();
            cb.ShowTextAligned(8, text, 200, 568, 0);
            cb.EndText();

            cb.BeginText();
            text = tb_validade_ipo.Text.Trim();
            cb.ShowTextAligned(8, text, 370, 568, 0);
            cb.EndText();
            ///////////////////////////////////

            cb.BeginText();
            text = this.tb_nome_entidade.Text.Trim();
            cb.ShowTextAligned(12, text, 182, 485, 0);
            cb.EndText();

            cb.BeginText();
            text = tipo_cartao.Trim();
            cb.ShowTextAligned(13, text, 210, 470, 0);
            cb.EndText();
            ///////////////////////////////////////////

            cb.BeginText();
            text = tb_validade_acesso.Text;
            cb.ShowTextAligned(13, text, 240, 450, 0);
            cb.EndText();

            cb.BeginText();
            text = tb_r_distico.Text;
            cb.ShowTextAligned(13, text, 460, 450, 0);
            cb.EndText();

            ///////////////////////////////////////////

            cb.BeginText();
            text = tb_servico.Text;
            cb.ShowTextAligned(13, text, 210, 435, 0);
            cb.EndText();

            ////////////////////////////////////////
            cb.BeginText();
            text = tb_servico.Text;
            cb.ShowTextAligned(13, text, 210, 435, 0);
            cb.EndText();


            cb.BeginText();
            text = tipo.Trim();
            cb.ShowTextAligned(14, text, 520, 800, 0);
            cb.EndText();

            // create the new page and add it to the pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            cb.AddTemplate(page, 0, 0);

            //document.NewPage();
            //PdfImportedPage page2 = writer.GetImportedPage(reader, 2);
            //cb.AddTemplate(page2, 0, 0);
            // close the streams and voilá the file should be changed :)
            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();

        }

        protected string meses_contagem(int meses)
        {
            DateTime data=DateTime.Now.AddMonths(meses);
           string data2 = data.ToShortDateString();
            return data2;
        }

        ///////////VALIDAR TIPO DE CARTAO QUANDO O INDEX DO RADIOBUTTON MUDAR////////////////
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            validar_cartao();
        }

        ////////////NABEGACAO MENU VERTICAL SIDEBAR DO WIZARDSTEP////////////////
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
                    //linkButton.Style.Add(HtmlTextWriterStyle.TextDecoration, "none");
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
        ////////////CARREGAR LIVRETE////////////////
        protected void AFileUpload_livrete_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AFileUpload_livrete.HasFile)
            { 
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                 Session["flag_upload_v"] = Convert.ToInt32(Session["flag_upload_v"]) + 1;
                    Session["AFileUpload_livrete"] = path + "\\" + "livrete_" + AFileUpload_livrete.FileName;
                    AFileUpload_livrete.SaveAs(Session["AFileUpload_livrete"].ToString());
            }
        
        }

        ////////////CARREGAR SEGURADORA////////////////
        protected void AFileUpload_cobertura_seguradora_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AFileUpload_cobertura_seguradora.HasFile)
            {        
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                 Session["flag_upload_v"] = Convert.ToInt32(Session["flag_upload_v"]) + 1;
                    Session["AFileUpload_cobertura_seguradora"] = path + "\\" + "segurador_" + AFileUpload_cobertura_seguradora.FileName;
                    AFileUpload_cobertura_seguradora.SaveAs(Session["AFileUpload_cobertura_seguradora"].ToString());
             
            }
         
        }

        ////////////CARREGAR CARTAO DE CIRCULACAO////////////////
        protected void AFileUpload_cartao_circulacao_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AFileUpload_cartao_circulacao.HasFile)
            {     
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                 Session["flag_upload_v"] = Convert.ToInt32(Session["flag_upload_v"]) + 1;
                    Session["AFileUpload_cartao_circulacao"] = path + "\\" + "ccirculacao_" + AFileUpload_cartao_circulacao.FileName;
                    AFileUpload_cartao_circulacao.SaveAs(Session["AFileUpload_cartao_circulacao"].ToString());
             }  
        }

        ////////////CARREGAR REGSITGO DE PROPRIEDADE////////////////
        protected void AFileUpload_r_propriedade_UploadedComplete1(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AFileUpload_r_propriedade.HasFile)
            {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                 //Session["flag_upload_v"] = Convert.ToInt32(Session["flag_upload_v"]) + 1;
                    Session["AFileUpload_r_propriedade"] = path + "\\" + "rpropriedade_" + AFileUpload_r_propriedade.FileName;
                    AFileUpload_r_propriedade.SaveAs(Session["AFileUpload_r_propriedade"].ToString());
            }
          
        }

        ////////////CARREGAR CARATA VERDE////////////////
        protected void AFileUpload_c_verde_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AFileUpload_c_verde.HasFile)
            {          
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                 Session["flag_upload_v"] = Convert.ToInt32(Session["flag_upload_v"]) + 1;
                    Session["AFileUpload_c_verde"] = path + "\\" + "cartaverde_" + AFileUpload_c_verde.FileName;
                    AFileUpload_c_verde.SaveAs(Session["AFileUpload_c_verde"].ToString());    
            }
         
        }

        ////////////CARREGAR COPIA IPO////////////////
        protected void AFileUpload_ipo_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AFileUpload_ipo.HasFile)
            {            
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                 Session["flag_upload_v"] = Convert.ToInt32(Session["flag_upload_v"]) + 1;
                    Session["AFileUpload_ipo"] = path + "\\" + "ipo_" + AFileUpload_ipo.FileName;
                    AFileUpload_ipo.SaveAs(Session["AFileUpload_ipo"].ToString());
            }
         }

        ////////////VERIFICAR QUE A CHECKBOX ESTA SELECIONADA////////////////
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = cb_validate.Checked;
        }

        ////////////ADICONAR ERRO NO VALIDATE SUMMARY////////////////
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

        ////////////VALIDAR NO EVENTO DO BOTAO SEGUINTE////////////////
        protected void viatura_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (!Page.IsValid)
            {
                e.Cancel = true;
            }
        }

        protected void tb_matricula_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
        /////////////VALIDAR SE A MATRICULA JA EXISTE SE ESTA FOR DIFERENTE DE VAZIO////////////////
            if (tb_matricula.Text != "")
            {
                BAL_viatura viatura = new BAL_viatura();
                if (viatura.valida_matricula(tb_matricula.Text, ID_viatura) != "")
                { args.IsValid = false;}
            }
        }

    }
}