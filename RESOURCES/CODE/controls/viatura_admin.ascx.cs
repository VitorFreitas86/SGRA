using AjaxControlToolkit;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.BAL;
using WebApplication10.PROP;

namespace WebApplication10.controls
{
    public partial class viatura_admin : System.Web.UI.UserControl
    {
        /// <summary>
        /// CARREGAR TEXTBOX E RADIBUTTOM E CHECKBOX COM VALORES DA BASE DE DADOS////////////////////
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
                if (Label_estado.Text == "Inactivo" && acao != "0")
                {
                    ddl_estado.Visible = false;
                    LabelEstado.Visible = false;
                }
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
        public int id_viatura
        {
            get
            {
                if (ViewState["id_viatura"] == null)
                    ViewState["id_viatura"] = string.Empty;
                return Convert.ToInt32(ViewState["id_viatura"].ToString());
            }
            set
            {
                ViewState["id_viatura"] = value;
            }
        }
        public int id_renovacao
        {
            get
            {
                if (ViewState["id_renovacao"] == null)
                    ViewState["id_renovacao"] = string.Empty;
                return Convert.ToInt32(ViewState["id_renovacao"].ToString());
            }
            set
            {
                ViewState["id_renovacao"] = value;
            }
        }
        public bool enable_tb_n_identificacao
    {
        set { tb_n_identificacao.Enabled = value; tb_n_distico.Enabled = value; }
            }
        public string distico
        {
            get { return tb_n_distico.Text.ToString(); }
            set { tb_n_distico.Text = value; }
        }    
        public string n_identificao
        {
            get { return tb_n_identificacao.Text.ToString(); }
            set { tb_n_identificacao.Text = value;}
        }
        public string outros
        {
            get { return tb_outros.Text.ToString(); }
            set { tb_outros.Text = value; }
        }
        public string portao
        {
            get { return tb_portao.Text.ToString(); }
            set { tb_portao.Text = value; }
        }
        public void rb_checked_by_BD(string entrada)
        {
            if (entrada == "Circulação Permanente")
            {
                rb_tipo_circulação.SelectedIndex = 0;
            }
            else
                if (entrada == "Circulação Temporária")
                { rb_tipo_circulação.SelectedIndex = 1;
                Label_validade.Visible = true;
                tb_validade.Visible = true;
                ib_validade.Visible = true;
                }
                
        }
        public string validade
        {
            get { return tb_validade.Text.ToString(); }
            set { tb_validade.Text = value; }
        }
        public string conferido
        {
            get { return tb_conferido.Text.ToString(); }
            set { tb_conferido.Text = value; }
        }
        public string estado
        {
            get { return Label_estado.Text.ToString(); }
            set { 
                Label_estado.Text = value;
            ddl_estado.SelectedValue = null;
            ddl_estado.Items.FindByValue(Label_estado.Text).Selected = true; 
            }
        }
        /// </summary>
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
            }
        }

        ///////////// VALIDAR RADIOBUTTON COM TIPO DE CARTAO E HACK PARA MANTER O POPUP VISIVEL//////////////
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            validar_cartao();
            var popup = Parent.FindControl("ModalPopupExtender1") as ModalPopupExtender;
            if(popup!=null)
            popup.Show(); 
        }

        ///////////// VALIDAR CARTAO ATRAVES DE RADIOBUTTOM//////////////
        protected string validar_cartao()
        {       
            if (rb_tipo_circulação.SelectedIndex == 1)
            {       
                Label_validade.Visible = true;
                tb_validade.Visible = true;
                ib_validade.Visible = true;  
                var popup = Parent.FindControl("ModalPopupExtender1") as ModalPopupExtender;
            popup.Show( ); 
                return "Circulação Temporária";  
     
            }
            else
                if (rb_tipo_circulação.SelectedIndex == 0)
                {          
                    Label_validade.Visible = false;
                    tb_validade.Visible = false;
                    ib_validade.Visible = false;                 
                    var popup = Parent.FindControl("ModalPopupExtender1") as ModalPopupExtender;
                    popup.Show();  
                    return "Circulação Permanente";
                }
                  else return null;
        }

        ///////////// EVENTO DO BOTAO GRAVAR //////////////
        protected void ib_save_Click(object sender, ImageClickEventArgs e)
        {
            string newFile;
            string mergedFile;
    
          
            BAL_viatura viatura = new BAL_viatura();

            if (acao == "0")
            {
                //if (ddl_estado.SelectedValue == "Inactivo")
                //{
                //    //////////////SE FOR INACTIVO PASSA A RENOVACOA E SEGUNDA VIA PARA INATIVO TB///////////////
                //    viatura.update_estado_inativo_viatura(id_viatura);
                //}
                  if (ddl_estado.SelectedValue == "Inactivo")
                {
                    //////////////////////////ATUALIZAR INATIVO PARA TODAS AS CHILDGRIS SE A PRINCIPAL FOR INACTIVA/////////////////////////////
                    if (tb_n_distico.Text != "")
                    {
                        AddErrorToValidationSummary("Atenção para colocar o pedido no estado Inactivo deverá remover o Nº de Distico!");
                        return;

                    }
                    if (tb_n_distico.Text == "")
                    {
                     viatura.update_estado_inativo_viatura(id_viatura);
                    }
                }
                //////////////////VERIFICAR SE O CARTAO ESTA INDEFERIDO//////////////////////
                if (ddl_estado.SelectedValue == "Indeferido")
                {
                    ////////////////////////////ATUALIZAR INATIVO PARA TODAS AS CHILDGRIS SE A PRINCIPAL FOR INACTIVA/////////////////////////////
                    if (tb_n_distico.Text != "")
                    {
                        AddErrorToValidationSummary("Atenção para colocar o pedido no estado Indeferido deverá remover o Nº de Distico!");
                        return;
                    }

                }

                if (viatura.valida_distico(tb_n_distico.Text, id_viatura) == "0" || tb_n_distico.Text=="")
                {
                    if (viatura.valida_n_identificacao(tb_n_identificacao.Text, id_viatura).Count == 0)
                    {
                        //////ATUALIZAR INFOMRCAO E POR MARCA DE AGUA NO DOCUMENTO//////////////

                        viatura.update_admin_viatura(tb_n_identificacao.Text, tb_outros.Text, ddl_estado.SelectedValue, tb_portao.Text, tb_n_distico.Text, tb_conferido.Text, tb_validade.Text, validar_cartao(), id_viatura);
                        List<PROP_viatura> lista_viatura = new List<PROP_viatura>();

                        lista_viatura = viatura.get_viatura_renovacao_by_ID(id_viatura);

                        string path_doc_final = lista_viatura[0].path_doc_final_viaturas.ToString();

                        char[] separator = new char[] { '\\' };
                        string[] strSplitArr = path_doc_final.Split(separator);
                        //////////CONCATENACAO DOS VALORES DO PATH PARA CRIACAO DOS DOCUMENTOS TEMPORARIOS//////////////
                        newFile = strSplitArr[0] + "\\" + strSplitArr[1] + "\\" + strSplitArr[2] + "\\" + strSplitArr[3] + "\\" + strSplitArr[4] + "\\" + "admin.pdf";
                        mergedFile = strSplitArr[0] + "\\" + strSplitArr[1] + "\\" + strSplitArr[2] + "\\" + strSplitArr[3] + "\\" + strSplitArr[4] + "\\" + "Merged.pdf";
                        //////////CRIAR PDF DE RELATORIO/////////////
                        pdf_admin(newFile, mergedFile, path_doc_final);
                        //////////REENCAMINHAR PAGINA DE ADMINISTRACAO////////////
                        Response.Redirect("~/Admin/gerir_viatura.aspx");
                    }
                    else
                    {
                        //ERROS DO Nº DE IDENTIFICACAO///                    
                        AddErrorToValidationSummary("Atenção o nº de identificação já está em utilização, por favor reveja o nº de identificação");
                    }

                }
                else
                {
                    //ERROS DO Nº DISTICO///
                    AddErrorToValidationSummary("Atenção o nº Dístico já está em utilização, por favor reveja o nº de Dístico");
                }
            }

          

            if (acao == "1")
            { /*2via*/

                viatura.update_admin_via_viatura(tb_n_identificacao.Text, tb_outros.Text, ddl_estado.SelectedValue, tb_portao.Text, tb_n_distico.Text, tb_conferido.Text, tb_validade.Text, validar_cartao(), id_viatura, id_renovacao);
                string path_doc_final = viatura.select_path_doc_via_viatura(id_renovacao);
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path_doc_final.Split(separator);
                //////////CONCATENACAO DOS VALORES DO PATH PARA CRIACAO DOS DOCUMENTOS TEMPORARIOS//////////////
                newFile = strSplitArr[0] + "\\" + strSplitArr[1] + "\\" + strSplitArr[2] + "\\" + strSplitArr[3] + "\\" + strSplitArr[4] + "\\" + "Segunda_via" + "\\" + "admin.pdf";
                mergedFile = strSplitArr[0] + "\\" + strSplitArr[1] + "\\" + strSplitArr[2] + "\\" + strSplitArr[3] + "\\" + strSplitArr[4] + "\\" + "Segunda_via" + "\\" + "Merged.pdf";
                //////////CRIAR PDF DE RELATORIO/////////////
                pdf_admin(newFile, mergedFile, path_doc_final);
                //////////REENCAMINHAR PAGINA DE ADMINISTRACAO////////////
                Response.Redirect("~/Admin/gerir_viatura.aspx");
            }
            if (acao == "2")
            { /*renovacao*/
                viatura.update_admin_renovacao_viatura(tb_n_identificacao.Text, tb_outros.Text, ddl_estado.SelectedValue, tb_portao.Text, tb_n_distico.Text, tb_conferido.Text, tb_validade.Text, validar_cartao(), id_viatura, id_renovacao);
                string path_doc_final = viatura.select_path_doc_renovacao_viatura(id_renovacao);
                char[] separator = new char[] { '\\' };
                string[] strSplitArr = path_doc_final.Split(separator);
                //////////CONCATENACAO DOS VALORES DO PATH PARA CRIACAO DOS DOCUMENTOS TEMPORARIOS//////////////
                newFile = strSplitArr[0] + "\\" + strSplitArr[1] + "\\" + strSplitArr[2] + "\\" + strSplitArr[3] + "\\" + strSplitArr[4] + "\\" + "Renovacao" + "\\" + "admin.pdf";
                mergedFile = strSplitArr[0] + "\\" + strSplitArr[1] + "\\" + strSplitArr[2] + "\\" + strSplitArr[3] + "\\" + strSplitArr[4] + "\\" + "Renovacao" + "\\" + "Merged.pdf";
                //////////CRIAR PDF DE RELATORIO/////////////
                pdf_admin(newFile, mergedFile, path_doc_final);
                //////////REENCAMINHAR PAGINA DE ADMINISTRACAO////////////
                Response.Redirect("~/Admin/gerir_viatura.aspx");
            }
         
            //this.Page.GetType().InvokeMember("updatepanel", System.Reflection.BindingFlags.InvokeMethod, null, this.Page, new object[] {});
        }

///////////////////////////////CRIAR PDF COM REPORT DE DOCUMETNO FINAL///////////////////////////////
        protected void pdf_admin(string newFile, string mergedFile, string doc_principal)
        {
            string oldFile = Server.MapPath("~\\Templates\\viatura.pdf");
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
                    string text = this.tb_n_distico.Text.Trim();
                    // put the alignment and coordinates here
                    cb.ShowTextAligned(1, text, 192, 715, 0);
                    cb.EndText();
                    //cb.BeginText();
                    //text = tb_conferido.Text;
                    //// put the alignment and coordinates here
                    //cb.ShowTextAligned(2, text, 160, 310, 0);
                    //cb.EndText();

                    cb.BeginText();
                    text = tb_n_identificacao.Text.Trim();
                    cb.ShowTextAligned(3, text, 230, 701, 0);
                    cb.EndText();

                    cb.BeginText();
                    text = this.tb_outros.Text.Trim();
                    cb.ShowTextAligned(3, text, 320, 720, 0);
                    cb.EndText();
                    ////////////
                    cb.BeginText();
                    text = this.tb_portao.Text.Trim();
                    cb.ShowTextAligned(3, text, 130, 555, 0);
                    cb.EndText();

              cb.BeginText();
              text = validar_cartao();
              cb.ShowTextAligned(3, text, 120, 450, 0);
                    cb.EndText();
            //////
             cb.BeginText();
             text = this.tb_validade.Text.Trim();
             cb.ShowTextAligned(3, text, 145, 432, 0);
                    cb.EndText();
            ///////
             cb.BeginText();
                    text = this.tb_conferido.Text.Trim();
                    cb.ShowTextAligned(3, text, 235, 436, 0);
                    cb.EndText();



                    // create the new page and add it to the pdf
                    //PdfImportedPage page = writer.GetImportedPage(reader, 1);
                    //cb.AddTemplate(page, 0, 0);

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
        /////////////////////////ADICIONAR MENSAGEM DE ERRO NO VALIDATION SUMMARY ////////////////
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
    }

}
