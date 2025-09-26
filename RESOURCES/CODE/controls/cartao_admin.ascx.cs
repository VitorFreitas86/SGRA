using AjaxControlToolkit;
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
using WebApplication10.PROP;

namespace WebApplication10.controls
{
    public partial class cartao_admin : System.Web.UI.UserControl
    {

        /// <summary>
        /// CARREGAR VALORES NAS TEXTBOX NOS RADIOBUTTONS E NAS CHECKBOX PARA O PROCESSO DE RENOVACAO E SEGUNDA VIA////////////
       
        public string path_doc_final
        {
            get
            {
                if (ViewState["path_doc_final"] == null)
                    ViewState["path_doc_final"] = string.Empty;
                return ViewState["path_doc_final"].ToString();
            }
            set
            {
                ViewState["path_doc_final"] = value;
            }
        }
        public string fotocopia_bi
        {
            get
            {
                if (ViewState["fotocopia_bi"] == null)
                    ViewState["fotocopia_bi"] = string.Empty;
                return ViewState["fotocopia_bi"].ToString();
            }
            set
            {
                ViewState["fotocopia_bi"] = value;
            }
        }
        public string fotografia
        {
            get
            {
                if (ViewState["fotografia"] == null)
                    ViewState["fotografia"] = string.Empty;
                return ViewState["fotografia"].ToString();
            }
            set
            {
                ViewState["fotografia"] = value;
            }
        }
        public string registo_criminal
        {
            get
            {
                if (ViewState["registo_criminal"] == null)
                    ViewState["registo_criminal"] = string.Empty;
                return ViewState["registo_criminal"].ToString();
            }
            set
            {
                ViewState["registo_criminal"] = value;
            }
        }
        public string fotocopia_cartao_acompanhante
        {
            get
            {
                if (ViewState["fotocopia_cartao_acompanhante"] == null)
                    ViewState["fotocopia_cartao_acompanhante"] = string.Empty;
                return ViewState["fotocopia_cartao_acompanhante"].ToString();
            }
            set
            {
                ViewState["fotocopia_cartao_acompanhante"] = value;
            }
        }
        public string fotocopia_vinculo_laboral
        {
            get
            {
                if (ViewState["fotocopia_vinculo_laboral"] == null)
                    ViewState["fotocopia_vinculo_laboral"] = string.Empty;
                return ViewState["fotocopia_vinculo_laboral"].ToString();
            }
            set
            {
                ViewState["fotocopia_vinculo_laboral"] = value;
            }
        }
        public int id_cartao_renovacao
        {
            get
            {
                if (ViewState["id_cartao_renovacao"] == null)
                    ViewState["id_cartao_renovacao"] = string.Empty;
                return Convert.ToInt32(ViewState["id_cartao_renovacao"].ToString());
            }
            set
            {
                ViewState["id_cartao_renovacao"] = value;
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
                if (acao == "0")
                {
                    ddl_estado.Items.FindByValue("Inactivo").Enabled = true;
                }
                else
                {
                    ddl_estado.Items.FindByValue("Inactivo").Enabled = false;
                }
            }
        }
        public string psp
        {
            get { return tb_psp.Text.ToString(); }
            set { tb_psp.Text = value; }
        }
        public string d_psp
        {
            get { return tb_d_psp.Text.ToString(); }
            set { tb_d_psp.Text = value; }
        }
        public string sef
        {
            get { return tb_sef.Text.ToString(); }
            set { tb_sef.Text = value; }
        }
        public string d_sef
        {
            get { return tb_d_sef.Text.ToString(); }
            set { tb_d_sef.Text = value; }
        }
        public string outros_servicos
        {
            get { return tb_o_servicos.Text.ToString(); }
            set { tb_o_servicos.Text = value; }
        }
        public string d_outros_servicos
        {
            get { return tb_d_servico.Text.ToString(); }
            set { tb_d_servico.Text = value; }
        }
        public bool enable_num_cartao {
            set { tb_n_cartao.Enabled = value; }
        }
        public string num_cartao
        {
            get { return tb_n_cartao.Text.ToString(); }
            set { tb_n_cartao.Text = value; }
        }
        public bool num_cartao_color
        {
            ////////////////////ALTERAR A COR DA TEXTBOX DO CARTAO CONSOANTE FOR A SOLICITAR NO CASO DE EXISTIR VALOR E A COR NORMAL///////////
            set {
                if (value == true)
                {
                    tb_n_cartao.BackColor = System.Drawing.Color.Orange;
                }
                else
                {
                    tb_n_cartao.BackColor = System.Drawing.Color.White;
                }
            }
        }
        public string validade_cartao
        {
            get { return tb_validade_cartao.Text.ToString(); }
            set { tb_validade_cartao.Text = value; }
        }
        public string estado
        {
            get { return Label_estado.Text.ToString(); }
            set
            {
                Label_estado.Text = value;
                ddl_estado.SelectedValue = null;
                ddl_estado.Items.FindByValue(Label_estado.Text).Selected = true;
            }
        }
        public string cor
        {
            get { return lb_cor.Text.ToString(); }
            set
            {
                lb_cor.Text = value;            
                    ddl_cor.SelectedValue = null;          
                    if (lb_cor.Text != "")
                    {
                    ddl_cor.Items.FindByValue(lb_cor.Text).Selected = true;
                }
            }
        }
        public string tipo_de_cartao
        {
            get { return lb_tipo_cartao.Text.ToString(); }
            set
            {
                lb_tipo_cartao.Text = value;
                ddl_tipo_cartao.SelectedValue = null;
                ddl_tipo_cartao.Items.FindByValue(lb_tipo_cartao.Text).Selected = true; 
            }
        }
        public string conferido
        {
            get { return tb_conferido.Text.ToString(); }
            set { tb_conferido.Text = value;
         
            }
        }
        public string areas
        {
            get { return lb_areas.Text.ToString(); }
            set {
                cb_areas_funcoes.ClearSelection();
                lb_areas.Text = value;
            string areas_string = lb_areas.Text;
            char[] separator = new char[] { ' ' };
            string[] strSplitArr = areas_string.Split(separator);
            for (int i = 0; i < strSplitArr.Length;i++)
            {
       
            foreach (System.Web.UI.WebControls.ListItem item in cb_areas_funcoes.Items)
            {
                if (strSplitArr[i].ToString()== item.Value)
                {
                    item.Selected=true;
                }
            }

            }   
            }
        }
        public string pagamento
        {
            get { return tb_pagamento.Text.ToString(); }
            set { tb_pagamento.Text = value; }
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


        public string tb_msg_psp
        {
            get { return msg_psp.Text.ToString(); }
            set { msg_psp.Text = value; }
        }
        public string tb_msg_sef
        {
            get { return msg_sef.Text.ToString(); }
            set { msg_sef.Text = value; }
        }
        /// </summary>


        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /////////////////////////////////////////////////MANTER O MODALPOPUP EXTENDER VISIVEL NO POSTBACK//////////////////////////// 
      
        protected void cb_psp_CheckedChanged(object sender, EventArgs e)
        {


            if (cb_psp.Checked == true)
            {
                Panel_psp.Visible = true;
                var popup = Parent.FindControl("ModalPopupExtender1") as ModalPopupExtender;
                popup.Show();
            }
            else
            {
                Panel_psp.Visible = false;
                var popup = Parent.FindControl("ModalPopupExtender1") as ModalPopupExtender;
                popup.Show();  
            }
        }

        protected void cb_sef_CheckedChanged(object sender, EventArgs e)
        {

            if (cb_sef.Checked == true)
            {
                Panel_sef.Visible = true;
                var popup = Parent.FindControl("ModalPopupExtender1") as ModalPopupExtender;
                popup.Show();
            }
            else
            {
                Panel_sef.Visible = false;
                var popup = Parent.FindControl("ModalPopupExtender1") as ModalPopupExtender;
                popup.Show();  
            }
        }

        protected void cb_o_servicos_CheckedChanged(object sender, EventArgs e)
        {

            if (cb_o_servicos.Checked == true)
            {
                Panel_o_serv.Visible = true;
                var popup = Parent.FindControl("ModalPopupExtender1") as ModalPopupExtender;
                popup.Show();
            }
            else
            {
                Panel_o_serv.Visible = false;
                var popup = Parent.FindControl("ModalPopupExtender1") as ModalPopupExtender;
                popup.Show();  
            }
        }

        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void ib_save_admin_Click(object sender, ImageClickEventArgs e)
        {
            ////////////////////////////ANEXOS  NO ENVIO DO EMAIL COM ARRAY DINAMICO/////////////////////////////
            BAL_cartao cartao = new BAL_cartao();
            send_email email = new send_email();
                string header = Server.MapPath("~\\Templates\\email_header.png");
            string footer = Server.MapPath("~\\Templates\\email_footer.png");           
            string newFile;
            string mergedFile;  
            string[] destinatarios = { };
           
            /////////////////////VARIAVEIS PARA PEDIR VER SE É PARA PEDIR PARECER SE É PARA INSERIR NA BD//////////////

            int parecer_inserir = 0;// 0--> INSERIR ADMIN   1-->PEDIR PARECER

            string req_sef = "0";
            string req_psp = "0";

            if (cb_psp.Checked == true)
            {
                Array.Resize<string>(ref destinatarios, destinatarios.Length + 1);
                int p = destinatarios.Length - 1;
                req_psp = "1";
                destinatarios[p] = tb_psp.Text;
                parecer_inserir = 1;
            }
            if (cb_sef.Checked == true)
            {
                Array.Resize<string>(ref destinatarios, destinatarios.Length + 1);
                int p = destinatarios.Length - 1;
                req_sef = "1";
                destinatarios[p] = tb_sef.Text;
                parecer_inserir = 1;
            }
            if (cb_o_servicos.Checked == true)
            {

                Array.Resize<string>(ref destinatarios, destinatarios.Length + 1);
                int p = destinatarios.Length - 1;
                destinatarios[p] = tb_o_servicos.Text;
                parecer_inserir = 1;
            }

      

            if (acao == "0")
            {
                //////////////////VERIFICAR SE O CARTAO ESTA INACTIVO//////////////////////
                if (ddl_estado.SelectedValue == "Inactivo")
                {
                    //////////////////////////ATUALIZAR INATIVO PARA TODAS AS CHILDGRIS SE A PRINCIPAL FOR INACTIVA/////////////////////////////
                    if (tb_n_cartao.Text != "")
                    {
                        AddErrorToValidationSummary("Atenção para colocar o pedido no estado Inactivo deverá remover o Nº de cartão !");
                        return;

                    }
                    if (tb_n_cartao.Text == "")
                    {
                        cartao.update_estado_inativo_cartao(id_cartao);
                    }
                }
                //////////////////VERIFICAR SE O CARTAO ESTA INDEFERIDO//////////////////////
                if (ddl_estado.SelectedValue == "Indeferido")
                {
                    ////////////////////////////ATUALIZAR INATIVO PARA TODAS AS CHILDGRIS SE A PRINCIPAL FOR INACTIVA/////////////////////////////
                    if (tb_n_cartao.Text != "")
                    {
                        AddErrorToValidationSummary("Atenção para colocar o pedido no estado Indeferido deverá remover o Nº de cartão!");
                        return;
                    }

                }
                if (cartao.valida_n_cartao(tb_n_cartao.Text, id_cartao).Count == 0 || tb_n_cartao.Text=="" )
                {
                    ///////////////PARA PEDIR PARECER
                    if (parecer_inserir == 1)
                    {
                        cartao.update_admin_cartao(id_cartao,
                        ddl_estado.SelectedValue, conferido, ddl_cor.SelectedValue, psp, d_psp, sef, d_sef, outros_servicos, d_outros_servicos, tb_n_cartao.Text, tipo_de_cartao, validar_areas_funcoes(), tb_validade_cartao.Text, pagamento, validar_portas(), req_sef, req_psp);

                        email.admin_cartao_parecer(tb_o_servicos.Text.Trim(), header, footer, destinatarios);

                        Response.Redirect("~\\Admin\\gerir_cartao.aspx");
                    }

                    if (parecer_inserir == 0)
                    {
                        cartao.update_admin_cartao(id_cartao,
                        ddl_estado.SelectedValue, conferido, ddl_cor.SelectedValue, psp, d_psp, sef, d_sef, outros_servicos, d_outros_servicos, num_cartao, tipo_de_cartao, validar_areas_funcoes(), tb_validade_cartao.Text, pagamento, validar_portas(), req_sef, req_psp);
                        //////////SEPARAR O PATH DO DOCUMENTO FINAL PARA DESCOBRIR QUAL A PASTA PARA CRIAR OS FIXEIROS TEMPORARIOS//////////////////////
                        char[] separator = new char[] { '\\' };
                        string[] strSplitArr = path_doc_final.Split(separator);
                        //////////CONCATENACAO DOS VALORES DO PATH PARA CRIACAO DOS DOCUMENTOS TEMPORARIOS//////////////
                        newFile = strSplitArr[0] + "\\" + strSplitArr[1] + "\\" + strSplitArr[2] + "\\" + strSplitArr[3] + "\\" + strSplitArr[4] + "\\" + "admin.pdf";
                        mergedFile = strSplitArr[0] + "\\" + strSplitArr[1] + "\\" + strSplitArr[2] + "\\" + strSplitArr[3] + "\\" + strSplitArr[4] + "\\" + "Merged.pdf";
                        ///////////CRIAR PDF TEMPORARIOS/////////////
                        pdf_admin(newFile, mergedFile, path_doc_final);
                        Response.Redirect("~\\Admin\\gerir_cartao.aspx");
                    }

                  
                }
                else
                {
                    ////////////////////////////NAO PERMITE CARTOES COM NUMEROS IGUAIS/////////////////////////////
                    AddErrorToValidationSummary("Atenção o número de cartão já está a ser utilizador por algum pedido em vigor.");
        
                }
            }

            ////////////////////////////RENOVACAO/////////////////////////////
            if (acao == "2")
            {//RENOVACAO
                if (parecer_inserir == 0)
                {
                    cartao.update_admin_cartao_renovacao(id_cartao,
                    ddl_estado.SelectedValue, conferido, ddl_cor.SelectedValue, psp, d_psp, sef, d_sef, outros_servicos, d_outros_servicos, num_cartao, tipo_de_cartao, validar_areas_funcoes(), tb_validade_cartao.Text, pagamento, id_cartao_renovacao, validar_portas());
                    //////////SEPARAR O PATH DO DOCUMENTO FINAL PARA DESCOBRIR QUAL A PASTA PARA CRIAR OS FIXEIROS TEMPORARIOS//////////////////////
                    char[] separator = new char[] { '\\' };
                    string[] strSplitArr = path_doc_final.Split(separator);
                    //////////CONCATENACAO DOS VALORES DO PATH PARA CRIACAO DOS DOCUMENTOS TEMPORARIOS//////////////
                    newFile = strSplitArr[0] + "\\" + strSplitArr[1] + "\\" + strSplitArr[2] + "\\" + strSplitArr[3] + "\\" + strSplitArr[4] + "\\" + "Renovacao" + "\\" + "admin.pdf";
                    mergedFile = strSplitArr[0] + "\\" + strSplitArr[1] + "\\" + strSplitArr[2] + "\\" + strSplitArr[3] + "\\" + strSplitArr[4] + "\\" + "Renovacao" + "\\" + "Merged.pdf";
                    pdf_admin(newFile, mergedFile, cartao.doc_path_renovacao_cartao(id_cartao_renovacao));
                }
                if (parecer_inserir == 1)
                {
                    email.admin_cartao_parecer(tb_o_servicos.Text.Trim(), header, footer, destinatarios);
                    cartao.update_admin_cartao_renovacao(id_cartao,
                    ddl_estado.SelectedValue, conferido, ddl_cor.SelectedValue, psp, d_psp, sef, d_sef, outros_servicos, d_outros_servicos, num_cartao, tipo_de_cartao, validar_areas_funcoes(), tb_validade_cartao.Text, pagamento, id_cartao_renovacao, validar_portas());          
                }
                Response.Redirect("~\\Admin\\gerir_cartao.aspx");
            }
            ////////////////////////////SEGUNDA VIA/////////////////////////////
            if (acao == "1")
            {//SEGUNDAVIA
                if (parecer_inserir == 0)
                {
                    char[] separator = new char[] { '\\' };
                    string[] strSplitArr = path_doc_final.Split(separator);
                    //////////CONCATENACAO DOS VALORES DO PATH PARA CRIACAO DOS DOCUMENTOS TEMPORARIOS//////////////
                    newFile = strSplitArr[0] + "\\" + strSplitArr[1] + "\\" + strSplitArr[2] + "\\" + strSplitArr[3] + "\\" + strSplitArr[4] + "\\" + "Segunda_via" + "\\" + "admin.pdf";
                    mergedFile = strSplitArr[0] + "\\" + strSplitArr[1] + "\\" + strSplitArr[2] + "\\" + strSplitArr[3] + "\\" + strSplitArr[4] + "\\" + "Segunda_via" + "\\" + "Merged.pdf";
                    cartao.update_admin_cartao_segunda_via(id_cartao,
                    ddl_estado.SelectedValue, conferido, ddl_cor.SelectedValue, psp, d_psp, sef, d_sef, outros_servicos, d_outros_servicos, num_cartao, tipo_de_cartao, validar_areas_funcoes(), tb_validade_cartao.Text, pagamento, id_cartao_renovacao);
                    pdf_admin(newFile, mergedFile, cartao.doc_path_segunda_via_cartao(id_cartao_renovacao));
                }

                if (parecer_inserir == 1)
                {
                    cartao.update_admin_cartao_segunda_via(id_cartao,
                   ddl_estado.SelectedValue, conferido, ddl_cor.SelectedValue, psp, d_psp, sef, d_sef, outros_servicos, d_outros_servicos, num_cartao, tipo_de_cartao, validar_areas_funcoes(), tb_validade_cartao.Text, pagamento, id_cartao_renovacao);
                    email.admin_cartao_parecer(tb_o_servicos.Text.Trim(), header, footer, destinatarios);
                }
                Response.Redirect("~\\Admin\\gerir_cartao.aspx");
                    }
        
        }

        protected string validar_areas_funcoes()
        {
            ////////////////////////////VALIDAR FUNCOES ATRAVES DE LABEL QUE CARREGA O VALOR DA CHECKBOXLIST/////////////////////////////
            Label lbl_areas_funcoes = new Label();
            foreach (System.Web.UI.WebControls.ListItem item in cb_areas_funcoes.Items)
            {
                if (item.Selected)
                    lbl_areas_funcoes.Text += item.Value + " ";
            }
            return lbl_areas_funcoes.Text;
        }

        /// //////REMOVER PAGINAS DE PDF PARA NAO FICAR COM O HISTORICO DA ADMINISTRACAO////////////////
        public void removePagesFromPdf(String sourceFile, String destinationFile, params int[] pagesToKeep)
        {
           
            PdfReader r = new PdfReader(sourceFile);
            //Create our destination file
            
            using (FileStream fs = new FileStream(destinationFile, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Delete))
            {
                using (Document doc = new Document())
                {
                    using (PdfWriter w = PdfWriter.GetInstance(doc, fs))
                    {
                        //Open the desitination for writing
                        doc.Open();
                        //Loop through each page that we want to keep
                        foreach (int page in pagesToKeep)
                        {
                            //Add a new blank page to destination document
                            doc.NewPage();
                            //Extract the given page from our reader and add it directly to the destination PDF
                            w.DirectContent.AddTemplate(w.GetImportedPage(r, page), 0, 0);
                        }
                        //Close our document
                        doc.Close();
                    }
                }
            }
            r.Close();
        }



        protected void pdf_admin(string newFile, string mergedFile, string doc_principal)
        {
          
            //char[] separator = new char[] { '\\' };
            //string[] strSplitArr = fileName.Split(separator);
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
                    string text = this.tb_n_cartao.Text.Trim();
                    // put the alignment and coordinates here
                    cb.ShowTextAligned(1, text, 175, 330, 0);
                    cb.EndText();

            //////
                    cb.BeginText();
                    text = this.msg_psp.Text.Trim();
                    cb.ShowTextAligned(3, text, 75, 415, 0);
                    cb.EndText();

                    cb.BeginText();
                    text = this.tb_d_psp.Text.Trim();
                    cb.ShowTextAligned(3, text, 110, 388, 0);
                    cb.EndText();
            //////

                    cb.BeginText();
                    text = this.msg_sef.Text.Trim();
                    cb.ShowTextAligned(3, text, 325, 415, 0);
                    cb.EndText();

                    cb.BeginText();
                    text = this.tb_d_sef.Text.Trim();
                    cb.ShowTextAligned(3, text, 360, 388, 0);
                    cb.EndText();
           
 ///////
                    cb.BeginText();
                    text = tb_conferido.Text;
                    // put the alignment and coordinates here
                    cb.ShowTextAligned(2, text, 160, 310, 0);
                    cb.EndText();

                    cb.BeginText();
                    text = ddl_tipo_cartao.SelectedValue.Trim();
                    cb.ShowTextAligned(3, text, 80,177, 0);
                    cb.EndText();

                    cb.BeginText();
                    text = this.tb_validade_cartao.Text.Trim();
                    cb.ShowTextAligned(3, text, 100, 145, 0);
                    cb.EndText();
                    ////////////
                    cb.BeginText();
                    text = this.tb_validade_cartao.Text.Trim();
                    cb.ShowTextAligned(3, text, 100, 145, 0);
                    cb.EndText();

              cb.BeginText();
                    text = this.ddl_cor.SelectedValue.Trim();
                    cb.ShowTextAligned(3, text, 200, 215, 0);
                    cb.EndText();
            //////
             cb.BeginText();
                    text = this.validar_areas_funcoes().Trim();
                    cb.ShowTextAligned(3, text, 195, 174, 0);
                    cb.EndText();
            ///////
             cb.BeginText();
                    text = this.tb_conferido.Text.Trim();
                    cb.ShowTextAligned(3, text, 200, 145, 0);
                    cb.EndText();


             cb.BeginText();
                    text = this.tb_pagamento.Text.Trim();
                    cb.ShowTextAligned(3, text, 330, 225, 0);
                    cb.EndText();

              cb.BeginText();
                    text = validar_portas();
                    cb.ShowTextAligned(3, text,  80, 92, 0);
                    cb.EndText();
                   

                    //document.NewPage();
                    PdfImportedPage page2 = writer.GetImportedPage(reader, 2);
                    cb.AddTemplate(page2, 0, 0);
                    // close the streams and voilá the file should be changed :)
                    document.Close();
                    fs.Close();
                    writer.Close();
                    reader.Close();
                    string[] array_concatenar = { doc_principal, newFile };
            PdfMerge.MergeFiles(mergedFile, array_concatenar);
            File.Delete(newFile);

            PdfReader pdfReader = new PdfReader(mergedFile);
            int numberOfPages = pdfReader.NumberOfPages;
            pdfReader.Close();
            if (numberOfPages >2)
            {
                File.Delete(doc_principal);
                removePagesFromPdf(mergedFile, doc_principal, 1, 3);
                File.Delete(mergedFile);
            }
            else
            {
                File.Delete(doc_principal);
                File.Move(mergedFile, @doc_principal);
            }

          
        }
        ////////////////////////////ADICIONAR MENSAGEM DE ERRO A VALIDATAION SUMMARY ATRAVES DE UM CUSTOM VALIDATOR/////////////////////////////
        protected void AddErrorToValidationSummary(string errorMessage)
        {
            CustomValidator custVal = new CustomValidator();
            custVal.IsValid = false;
            custVal.ErrorMessage = errorMessage;
            custVal.EnableClientScript = true;
            custVal.Display = ValidatorDisplay.Dynamic;
            custVal.ValidationGroup = "MyValidationGroup";
            this.Page.Form.Controls.Add(custVal);
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
        ////////////////////ALTERACAO DOS INDEX DE SELECAO DAS PORTAS /////////////////////// 
        protected void cb_portas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (outras.Checked)
                tb_outras.Visible = true;
            else
                if (outras.Checked == false)
                    tb_outras.Visible = false;
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
    }
}