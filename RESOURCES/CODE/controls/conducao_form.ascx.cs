using AjaxControlToolkit;
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
    public partial class conducao_form : System.Web.UI.UserControl
    {
        /// <summary>
        /// CARREGAR CAMPOS COM VALORES DA BD PARA O PROCESSO DE RENOVACAO E SEGUNDA VIA
        public string path;
        public int id_pedido_conducao
        {
            get
            {
                if (ViewState["id_pedido_conducao"] == null)
                    ViewState["id_pedido_conducao"] = string.Empty;
                return Convert.ToInt32(ViewState["id_pedido_conducao"].ToString());
            }
            set
            {
                ViewState["id_pedido_conducao"] = value;
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
        public string e_patronal
        {
            get { return tb_patronal.Text.ToString(); }
            set { tb_patronal.Text = value; }

        }
        public string funcao
        {
            get { return tb_funcao.Text.ToString(); }
            set { tb_funcao.Text = value; }

        }
        public string num_acesso
        {
            get { return tb_num_acesso.Text.ToString(); }
            set { tb_num_acesso.Text = value; }

        }
        public string carta_conducao
        {
            get { return tb_carta_conducao.Text.ToString(); }
            set { tb_carta_conducao.Text = value; }

        }
        public string categoria
        {
            get { return tb_categoria.Text.ToUpper().ToString(); }
            set { tb_categoria.Text = value; }

        }
        public string d_emissao
        {
            get { return tb_d_emissao.Text.ToString(); }
            set { tb_d_emissao.Text = value; }

        }
        public string l_emissao
        {
            get { return tb_l_emissao.Text.ToString(); }
            set { tb_l_emissao.Text = value; }

        }
        public string validade
        {
            get { return tb_validade.Text.ToString(); }
            set { tb_validade.Text = value; }

        }
        public string nome_entidade
        {
            get { return tb_nome_entidade.Text.ToString(); }
            set { tb_nome_entidade.Text = value; }

        }
        public string categoria_viatura
        {
            get { return tb_categoria_viatura.Text.ToUpper().ToString(); }
            set { tb_categoria_viatura.Text = value; }

        }
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
              /// ////////////////////CAMINHO PARA CARREGAR DOCUMETNOS//////////////
            path = @"D:\conducao\pedidos\" + tb_nome_entidade.Text + "\\" + tb_num.Text;
            CalendarExtender1.EndDate = DateTime.Now;
            if (!IsPostBack)
            {
                Session["fotocopia_cartao_acl"] = "";
                Session["fotocopia_carta"] = "";
                Session["flag_upload"] = 0;
                if (acao == "0")
                {
                    BAL_entidades entidades = new BAL_entidades();
                    BAL_conducao conducao = new BAL_conducao();
                    int num_conducao = Convert.ToInt32(conducao.numero_conducao());
                    num_conducao = num_conducao + 1;
                    tb_num.Text = num_conducao.ToString();
                    tb_nome_entidade.Text = entidades.get_entidade_by_id(Convert.ToInt32(Session["identidade"]));
                }
            }
        }

        ///////////////////////DAR VALOR AS AREAS DE ACESSO//////////////////
        public void cb_checked_by_BD(string entrada)
        {
            if (entrada == "Plataforma de estacionamento de aeronaves e Terminal de cargas e bagagens")
            {
                terminal.Checked = true; plataforma.Checked = true;
            }
            else
                if (entrada == "Plataforma de estacionamento de aeronaves")
                { plataforma.Checked = true; }
                else
                    if (entrada == "Terminal de cargas e bagagens")
                    { terminal.Checked = true; }
        }

     ///////////////////////LIMPAR VALORES DE FILEUPLOAD///////////////////
        protected void limpar_fileupload()
        {
            Session["flag_upload"] = 0;
            Session["fotocopia_cartao_acl"] = "";
            Session["fotocopia_carta"] = "";
            AFileUpload_carta_conducao.ClearFileFromPersistedStore();
            AFileUpload_cartao_acesso.ClearFileFromPersistedStore();
        }

        ///////////////////EVENTO DE FINALIZAR O PROCESSO////////////////////////////////
        protected void Conducao_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            /////////DECLARACAO VARIAVEIS/////////////////////////////
            string data_alterada = DateTime.Now.ToString("dd-mm-yyyy_HH-mm-ss");
            string datareg = DateTime.Now.ToShortDateString();
            string header = Server.MapPath("~\\Templates\\email_header.png");
            string footer = Server.MapPath("~\\Templates\\email_footer.png");
            string areas = validar_areas();
            MembershipUser u = Membership.GetUser(Session["UserID"].ToString());
            string s_email = u.Email;
            send_email email = new send_email();
            BAL_users user = new BAL_users();
            BAL_entidades entidades = new BAL_entidades();
            BAL_conducao conducao = new BAL_conducao();
            if (acao == "0")//INSERCAO
            {
                if (Convert.ToInt32(Session["flag_upload"]) >= 2 && Session["fotocopia_cartao_acl"].ToString() != "" & Session["fotocopia_carta"].ToString() != "")
                {
                    string newFile = Path.Combine(path) + "\\" + tb_nome.Text + ".pdf";
                    ///////////////INSERIR A BASE DE DADOS///////////////
                    conducao.Create_conducao(tb_nome.Text, tb_patronal.Text, tb_funcao.Text,
                     tb_num_acesso.Text, tb_carta_conducao.Text,
                     tb_categoria.Text.ToUpper(), tb_d_emissao.Text, tb_l_emissao.Text, tb_validade.Text, areas,
                 tb_categoria_viatura.Text.ToUpper(), null,
               Session["fotocopia_cartao_acl"].ToString(), Session["fotocopia_carta"].ToString(), Convert.ToInt32(Session["identidade"]), "Pendente",
                 Session["user"].ToString(), tb_num.Text, datareg, newFile, Session["UserID"].ToString().ToUpper());
                    ///////////////////CRIRAR PDF DOCUMENTO FINAL/////////////////////////
                    report(path, areas, Session["user"].ToString(), newFile, "Original");
                    ////////////////DADOS PARA O EMAIL///////////
                    string dados = "Novo Registo de Pedido de condução - Pedido Nº " + tb_num.Text;
                    ////////////ENVIAR EMAIL////////////////
                    email.registo_conducao(dados, tb_num.Text, DateTime.Now.ToString(), tb_nome.Text, tb_patronal.Text,
                        Session["user"].ToString(), tb_nome_entidade.Text, s_email, header, footer);
                    ////////////LIMPAR OS FILEUPLOADS E IR PARA A PAGINA SUCESSO////////////////
                    limpar_fileupload();
                    Response.Redirect("~/Users/homesucess.aspx");
                }
                else
                {
                    /////////ERRO//////////////////
                    AddErrorToValidationSummary("Por favor reveja os documentos a carregar.");
                    limpar_fileupload();
                }
            }

            if (acao == "1")//SEGUNDA VIA
            {
                if (Convert.ToInt32(Session["flag_upload"]) >= 2 && Session["fotocopia_cartao_acl"].ToString() != "" & Session["fotocopia_carta"].ToString() != "")
                {
                    /////////DECLARACAO VARIAVEIS/////////////////////////////
                    string doc_segunda_via = path + "\\" + "segunda_via" + "\\";
                    string newFile = Path.Combine(doc_segunda_via) + "segunda_via_" + tb_nome.Text + "_" + data_alterada + ".pdf";
                    string watermark = Server.MapPath("~\\Templates\\segunda_via.png");
                    ///////APAGAR DOCUMENTOS ANTIGOS E COLOCAR A MARCA DE AGUA NO DOCUEMTNO PRINCIPAL///////////
                    delete_old_docs(id_pedido_conducao, watermark);
                    ///////////////INSERIR A BASE DE DADOS///////////////
                    conducao.inserir_segunda_via_conducao(tb_nome.Text, tb_funcao.Text, tb_num_acesso.Text, tb_carta_conducao.Text, tb_categoria.Text.ToUpper(),
                            tb_d_emissao.Text, tb_l_emissao.Text, tb_validade.Text, areas, tb_categoria_viatura.Text.ToUpper(), Session["fotocopia_cartao_acl"].ToString(), Session["fotocopia_carta"].ToString(),
                            "Pendente", Session["user"].ToString(), datareg, newFile, id_pedido_conducao);
                    ///////////////////CRIRAR PDF DOCUMENTO FINAL/////////////////////////
                    report(doc_segunda_via, areas, Session["user"].ToString(), newFile, "Segunda Via");
                    ////////////////DADOS PARA O EMAIL///////////
                    string dados = "Nova Requisição de segunda via do Pedido de condução - Pedido Nº " + tb_num.Text;
                    ////////////ENVIAR EMAIL////////////////
                    email.registo_conducao(dados, tb_num.Text, DateTime.Now.ToString(), tb_nome.Text, tb_patronal.Text,
                           Session["user"].ToString(), tb_nome_entidade.Text, s_email, header, footer);
                    ////////////LIMPAR OS FILEUPLOADS E IR PARA A PAGINA SUCESSO////////////////
                    limpar_fileupload();
                    Response.Redirect("~/Users/homesucess.aspx");
                }
                else
                {
                    //////////////////////////ERRO////////////////////////
                    AddErrorToValidationSummary("Por favor reveja os documentos a carregar.");
                    limpar_fileupload();
                }
            }

            if (acao == "2")//RENOVACAO
            {
                if (Convert.ToInt32(Session["flag_upload"]) >= 2 && Session["fotocopia_cartao_acl"].ToString() != "" & Session["fotocopia_carta"].ToString() != "")
                {
                    /////////DECLARACAO VARIAVEIS/////////////////////////////
                    string doc_renovacao = path + "\\" + "renovacao" + "\\";
                    string newFile = Path.Combine(doc_renovacao) + "renovacao_" + tb_nome.Text + "_" + data_alterada + ".pdf";
                    string watermark = Server.MapPath("~\\Templates\\renovado.png");
                    ///////APAGAR DOCUMENTOS ANTIGOS E COLOCAR A MARCA DE AGUA NO DOCUEMTNO PRINCIPAL///////////
                    delete_old_docs(id_pedido_conducao, watermark);
                    ///////////////INSERIR A BASE DE DADOS///////////////
                    conducao.inserir_renovacao_conducao(tb_nome.Text, tb_funcao.Text, tb_num_acesso.Text, tb_carta_conducao.Text, tb_categoria.Text.ToUpper(),
                        tb_d_emissao.Text, tb_l_emissao.Text, tb_validade.Text, areas, tb_categoria_viatura.Text.ToUpper(), Session["fotocopia_cartao_acl"].ToString(), Session["fotocopia_carta"].ToString(),
                        "Pendente", Session["user"].ToString(), datareg, newFile, id_pedido_conducao);
                    ///////////////////CRIRAR PDF DOCUMENTO FINAL/////////////////////////
                    report(doc_renovacao, areas, Session["user"].ToString(), newFile, "Renovação");
                    ////////////////DADOS PARA O EMAIL///////////
                    string dados = "Nova Requisição de Renovação do Pedido de condução - Pedido Nº " + tb_num.Text;
                    ////////////ENVIAR EMAIL////////////////
                    email.registo_conducao(dados, tb_num.Text, DateTime.Now.ToString(), tb_nome.Text, tb_patronal.Text,
                           Session["user"].ToString(), tb_nome_entidade.Text, s_email, header, footer);
                    ////////////LIMPAR OS FILEUPLOADS E IR PARA A PAGINA SUCESSO////////////////
                    limpar_fileupload();
                    Response.Redirect("~/Users/homesucess.aspx");
                }
                else
                {
                    //////////////////////ERRO////////////////////////////
                    AddErrorToValidationSummary("Por favor reveja os documentos a carregar.");
                    limpar_fileupload();
                }
            }
        }

       
       ////////////ADICIONAR ERROS AO VALIDATION SUMMARY////////////////////////
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

        ///////////////////VALIDAR AREAS/////////////////
        protected string validar_areas()
        {
            string areas = "";
            if (plataforma.Checked && terminal.Checked)
                areas = "Plataforma de estacionamento de aeronaves e Terminal de cargas e bagagens";
            else
                if (plataforma.Checked)
                    areas = "Plataforma de estacionamento de aeronaves";
                else
                    if (terminal.Checked)
                        areas = "Terminal de cargas e bagagens";

            return areas;
        }


        ////////////APAGAR DPCUMENTOS////////////////
        public void delete_old_docs(int id, string watermark)
        {
            BAL_conducao conducao = new BAL_conducao();
            List<PROP_conducao> lista_conducao = new List<PROP_conducao>();
            lista_conducao = conducao.get_conducao_by_numero_and_entidade(id);
            string old_carta = lista_conducao[0].fotocopia_carta_conducao;
            string old_cartao = lista_conducao[0].fotocopia_cartao_acl;
            StampDocument.PutImageWaterMark(lista_conducao[0].path_doc_final, watermark);
            if (File.Exists(old_carta) && File.Exists(old_cartao) && old_carta != Session["fotocopia_carta"].ToString() && old_cartao != Session["fotocopia_cartao_acl"].ToString())
            {
                File.Delete(old_carta);
                File.Delete(old_cartao);
            }
        }


        ////////////FORMULAR DOCUMENTO FINAL////////////////
        protected void report(string path, string areas, string nome_requerente, string newFile, string tipo)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string oldFile = Server.MapPath("~\\Templates\\conducao.pdf");


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
            cb.ShowTextAligned(1, text, 520, 737, 0);
            cb.EndText();
            cb.BeginText();
            text = DateTime.Now.ToString();
            // put the alignment and coordinates here
            cb.ShowTextAligned(2, text, 240, 700, 0);
            cb.EndText();


            cb.BeginText();
            text = nome_requerente.Trim();
            cb.ShowTextAligned(3, text, 320, 700, 0);
            cb.EndText();



            cb.BeginText();
            text = this.tb_nome.Text.Trim();
            cb.ShowTextAligned(4, text, 155, 650, 0);
            cb.EndText();


            cb.BeginText();
            text = this.tb_patronal.Text.Trim();
            cb.ShowTextAligned(5, text, 165, 635, 0);
            cb.EndText();


            cb.BeginText();
            text = this.tb_funcao.Text.Trim();
            cb.ShowTextAligned(5, text, 360, 635, 0);
            cb.EndText();


            cb.BeginText();
            text = this.tb_num_acesso.Text.Trim();
            cb.ShowTextAligned(6, text, 175, 618, 0);
            cb.EndText();


            cb.BeginText();
            text = this.tb_carta_conducao.Text.Trim();
            cb.ShowTextAligned(7, text, 335, 618, 0);
            cb.EndText();


            cb.BeginText();
            text = this.tb_categoria.Text.ToUpper().Trim();
            cb.ShowTextAligned(8, text, 490, 618, 0);
            cb.EndText();



            cb.BeginText();
            text = this.tb_d_emissao.Text.Trim();
            cb.ShowTextAligned(9, text, 175, 600, 0);
            cb.EndText();


            cb.BeginText();
            text = this.tb_l_emissao.Text.Trim();
            cb.ShowTextAligned(10, text, 345, 600, 0);
            cb.EndText();


            cb.BeginText();
            text = this.tb_validade.Text.Trim();
            cb.ShowTextAligned(11, text, 480, 600, 0);
            cb.EndText();

            cb.BeginText();
            text = this.tb_nome_entidade.Text.Trim();
            cb.ShowTextAligned(12, text, 200, 540, 0);
            cb.EndText();


            cb.BeginText();
            text = areas.Trim();
            cb.ShowTextAligned(13, text, 200, 522, 0);
            cb.EndText();


            cb.BeginText();
            text = this.tb_categoria_viatura.Text.ToUpper().Trim();
            cb.ShowTextAligned(14, text, 270, 504, 0);
            cb.EndText();

            cb.BeginText();
            text = tipo.Trim();
            cb.ShowTextAligned(14, text, 520, 800, 0);
            cb.EndText();

            // create the new page and add it to the pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            cb.AddTemplate(page, 0, 0);

            // close the streams and voilá the file should be changed :)
            document.Close();
            fs.Close();
            writer.Close();
            reader.Close();

        }

        ////////////CARREGAR CARTAO DE SUCESSO////////////////
        protected void AFileUpload_cartao_acesso_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AFileUpload_cartao_acesso.HasFile)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Session["flag_upload"] = Convert.ToInt32(Session["flag_upload"]) + 1;
                Session["fotocopia_cartao_acl"] = path + "\\" + "cartao_acesso_" + AFileUpload_cartao_acesso.FileName;
                AFileUpload_cartao_acesso.SaveAs(Session["fotocopia_cartao_acl"].ToString());
            }

        }


        ////////////CARREGAR CARTAO CONDUCAO////////////////
        protected void AFileUpload_carta_conducao_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AFileUpload_carta_conducao.HasFile)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Session["flag_upload"] = Convert.ToInt32(Session["flag_upload"]) + 1;
                Session["fotocopia_carta"] = path + "\\" + "carta_conducao_" + AFileUpload_carta_conducao.FileName;
                AFileUpload_carta_conducao.SaveAs(Session["fotocopia_carta"].ToString());
            }

        }

        protected void ib_calendar_d_emissao_Click(object sender, ImageClickEventArgs e)
        {
            if (tb_d_emissao.Text != "")
                CalendarExtender2.StartDate = Convert.ToDateTime(tb_d_emissao.Text);
        }


        ////////////BOTOES LATERAIS PARA NAVEGACAO N WIZARD STEP////////////////
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


        ///////////// VALIDAR QUE AS CHECKBOX ESTAO SELECIONADAS//////////////
        protected void SelectValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (plataforma.Checked == true || terminal.Checked == true)
                args.IsValid = true;
            else
                args.IsValid = false;
        }

        ///////////// VALIDAR QUE AS CHECKBOX ESTAO SELECIONADAS//////////////
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = cb_validate.Checked;
        }

        ///////////// BOTAO SEGUINTE VALIDAR//////////////
        protected void Conducao_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (!Page.IsValid)
            {
                e.Cancel = true;
            }
        }

     

 
    }
}