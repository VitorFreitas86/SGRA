using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication10.BAL;
namespace WebApplication10.controls
{
    public partial class footer : System.Web.UI.UserControl
    {
        public string visibildade_painel
        {
            set
            {
                Panel_close.Visible = true;
                Panel_suporte.Visible = false;
                Panel_gestao_doc.Visible = true;
                TextBox_email.Text = value;
                Label_header.Text = "Contactar Requerente";

            }
        }
        public string[] carrega_docs
        {
            set
            {
                string[] documentos = value;

                if (Cb_docs.Items.Count > 0)
                { Cb_docs.Items.Clear(); }

                    for (int i = 0; i <= documentos.Length - 1; i++)
                    {
                        CheckBoxField item = new CheckBoxField();
                        string fileName = documentos.GetValue(i).ToString();
                        char[] separator = new char[] { '\\' };
                        string[] strSplitArr = fileName.Split(separator);

                        if (fileName != "")
                        {
                            Cb_docs.Items.Add(new ListItem(strSplitArr[5].ToString(), fileName));
                        }
                    }
             
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
         
          
        }

        protected void ImageButton_s_email_Click(object sender, ImageClickEventArgs e)
        {  
            string header = Server.MapPath("~\\Templates\\email_header.png");
            string footer = Server.MapPath("~\\Templates\\email_footer.png");
            send_email s = new send_email();
            if (Panel_suporte.Visible == true)
            {
                    s.email_suporte("vitor.hr.freitas@azores.gov.pt", TextBox_nome.Text, TextBox_email.Text, TextBox_contato.Text, TextBox_assunto.Text, null, header, footer, TextBox_corpo.Text);
            }      
            if (Panel_gestao_doc.Visible == true)
            {     
                string[] path = { };
                foreach (ListItem listItem in Cb_docs.Items)
                {
                    
                    if (listItem.Selected == true)
                    {
                      Array.Resize<string>(ref path, path.Length + 1);
                        int p = path.Length - 1;
                        path[p] = listItem.Value;                     
                    }              
                }
              s.email_admin_to_requerente(TextBox_email.Text, TextBox_assunto.Text, path, header, footer, TextBox_corpo.Text);

            }
            Panel_email.Visible = false;
            Panel_sucess.Visible = true;
        }


        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Label_header.Text = "Suporte Técnico";
            Panel_email.Visible = true;
            Panel_sucess.Visible = false;
            Panel_close.Visible = true;
         }

        protected void ImageButton_close_Click(object sender, ImageClickEventArgs e)
        {
            Panel_close.Visible = false;
        }

     
    }
}