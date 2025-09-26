using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Security;

namespace WebApplication10.BAL
{
    public class send_email
    {
        public void registo_utilizador(string entidade,string nome,string user, string questao,string email,string path,string path_2)
        {

            string htmlBody = "<html><body><img src=\"cid:Pic1\"><br><div>Registo de Novo Utilizador</div><br><div> O seu utilizador foi registado com sucesso. A sua ativação poderá levar algum tempo.<br>Após ativado poderá utilizar a aplicação para requisitar os pedidos de acesso.<br></div>" + "<br><div><b>Entidade Requisitante: </b>" + entidade + "<br> <b>Nome Próprio:</b>" + nome + "<br><b>Username:</b>" + user + "<br> <b>Pergunta Secreta:</b>" + questao + "<br></div>" + "<br><img src=\"cid:Pic2\"><br></body></html>";
            AlternateView avHtml = AlternateView.CreateAlternateViewFromString
            (htmlBody, null, MediaTypeNames.Text.Html);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic1 = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
            pic1.ContentId = "Pic1";
            avHtml.LinkedResources.Add(pic1);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic2 = new LinkedResource(path_2, MediaTypeNames.Image.Jpeg);
            pic2.ContentId = "Pic2";
            avHtml.LinkedResources.Add(pic2);
            // Add the alternate views instead of using MailMessage.Body
            MailMessage m = new MailMessage();
            m.AlternateViews.Add(avHtml);

            // Address and send the message
            m.From = new MailAddress("aerogarelajes@gmail.com", "Aerogare Civil das Lajes");
            m.CC.Add(new MailAddress("vitor.hr.freitas@azores.gov.pt"));//Coordenacao e informatica
            m.To.Add(new MailAddress(email));
            m.Subject = "Registo de novo utilizador do SGRA";
            SmtpClient client = new SmtpClient();
            client.Send(m);
        }

        public void registo_conducao(string dados,string numero, string data, string nome, string entidade_patronal, string pessoa_requerente,string entidade, string email,string path, string path_2)
        {

            string htmlBody = "<html><body><div><img src=\"cid:Pic1\"><div><br>" + dados + "<br>Proderá também consultar o estado do mesmo, bastando para isso aceder ao SGRA.<br>"
                 + "<br><b>Número: </b>" + numero + "<br> <b>Data Registo:</b>" + data + "<br><b>Destinatário:</b>" + nome + "<br> <b>Entidade Patronal:</b>" + entidade_patronal + "<br><b>Pessoa Requerente:</b>" + pessoa_requerente + "<br><b>Entidade:</b>" + entidade + "<br><br></div><div> <div><img src=\"cid:Pic2\">  </div> <br></body></html>";

            AlternateView avHtml = AlternateView.CreateAlternateViewFromString
            (htmlBody, null, MediaTypeNames.Text.Html);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic1 = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
            pic1.ContentId = "Pic1";
            avHtml.LinkedResources.Add(pic1);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic2 = new LinkedResource(path_2, MediaTypeNames.Image.Jpeg);
            pic2.ContentId = "Pic2";
            avHtml.LinkedResources.Add(pic2);
            // Add the alternate views instead of using MailMessage.Body
            MailMessage m = new MailMessage();
            m.AlternateViews.Add(avHtml);

            // Address and send the message
            m.From = new MailAddress("aerogarelajes@gmail.com", "Aerogare Civil das Lajes");
            m.CC.Add(new MailAddress("vitor.hr.freitas@azores.gov.pt"));//COORDENACAO
            m.To.Add(new MailAddress(email));
            m.Subject = dados;
            SmtpClient client = new SmtpClient();
            client.Send(m);
        }
        public void registo_viatura(string dados, string numero, string data, string matricula, string marca,string modelo, string pessoa_requerente, string entidade, string email, string path, string path_2)
        {

            string htmlBody = "<html><body><div><img src=\"cid:Pic1\"></div><br><div>" + dados + "<br>Proderá também consultar o estado do mesmo, bastando para isso aceder ao SGRA.<br>"
                            + "<br><b>Número: </b>" + numero + "<br> <b>Data Registo:</b>" + data + "<br><b>Matricula:</b>" + matricula + "<br> <b>Marca:</b>" + marca + "<br><b>Pessoa Requerente:</b>" + pessoa_requerente + "<br><b>Entidade:</b>" + entidade + "<br><br></div><div> <div><img src=\"cid:Pic2\"> </div> <br></body></html>";


            AlternateView avHtml = AlternateView.CreateAlternateViewFromString
            (htmlBody, null, MediaTypeNames.Text.Html);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic1 = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
            pic1.ContentId = "Pic1";
            avHtml.LinkedResources.Add(pic1);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic2 = new LinkedResource(path_2, MediaTypeNames.Image.Jpeg);
            pic2.ContentId = "Pic2";
            avHtml.LinkedResources.Add(pic2);
            // Add the alternate views instead of using MailMessage.Body
            MailMessage m = new MailMessage();
            m.AlternateViews.Add(avHtml);

            // Address and send the message
            m.From = new MailAddress("aerogarelajes@gmail.com", "Aerogare Civil das Lajes");
            m.CC.Add(new MailAddress("vitor.hr.freitas@azores.gov.pt"));//COORDENACAO
            m.To.Add(new MailAddress(email));
            m.Subject = dados;
            SmtpClient client = new SmtpClient();
            client.Send(m);
        }

        public void registo_cartao(string dados, string numero, string data, string nome, string entidade_patronal, string pessoa_requerente, string entidade, string email, string path, string path_2)
        {
            string htmlBody = "<html><body><div><img src=\"cid:Pic1\"></div><div><br>" + dados + "<br>Proderá também consultar o estado do mesmo, bastando para isso aceder ao SGRA.<br>"
                  + "<br><b>Número: </b>" + numero + "<br> <b>Data Registo:</b>" + data + "<br><b>Destinatário:</b>" + nome + "<br> <b>Entidade Patronal:</b>" + entidade_patronal + "<br><b>Pessoa Requerente:</b>" + pessoa_requerente + "<br><b>Entidade:</b>" + entidade + "<br></div><br><div><img src=\"cid:Pic2\"> </div> <br></body></html>";

         
            AlternateView avHtml = AlternateView.CreateAlternateViewFromString
            (htmlBody, null, MediaTypeNames.Text.Html);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic1 = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
            pic1.ContentId = "Pic1";
            avHtml.LinkedResources.Add(pic1);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic2 = new LinkedResource(path_2, MediaTypeNames.Image.Jpeg);
            pic2.ContentId = "Pic2";
            avHtml.LinkedResources.Add(pic2);
            // Add the alternate views instead of using MailMessage.Body
            MailMessage m = new MailMessage();
            m.AlternateViews.Add(avHtml);

            // Address and send the message
            m.From = new MailAddress("aerogarelajes@gmail.com", "Aerogare Civil das Lajes");
            m.CC.Add(new MailAddress("vitor.hr.freitas@azores.gov.pt"));//COORDENACAO
            m.To.Add(new MailAddress(email));
            m.Subject = dados;
            SmtpClient client = new SmtpClient();
            client.Send(m);
        }
 
        public void admin_cartao_parecer( string email, string path, string path_2,string [] destinatarios)
        {
      
            string htmlBody = "<html><body><div><img src=\"cid:Pic1\"></div><div>" + "<br>Vem- se por este meio solicitar parecer sobre a emissão de cartão de identificação/acesso.<br></div><div><br> Deverá aceder à sua área reservada para o efeito.<br></div><div><br>Obrigado.</div>"
                            + "</div><br><div><img src=\"cid:Pic2\"> </div> <br></body></html>";

            AlternateView avHtml = AlternateView.CreateAlternateViewFromString
            (htmlBody, null, MediaTypeNames.Text.Html);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic1 = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
            pic1.ContentId = "Pic1";
            avHtml.LinkedResources.Add(pic1);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic2 = new LinkedResource(path_2, MediaTypeNames.Image.Jpeg);
            pic2.ContentId = "Pic2";
            avHtml.LinkedResources.Add(pic2);
            // Add the alternate views instead of using MailMessage.Body
            MailMessage m = new MailMessage();
            m.AlternateViews.Add(avHtml);

            // Address and send the message
            m.From = new MailAddress("aerogarelajes@gmail.com", "Aerogare Civil das Lajes");

            for (int i = 0; i < destinatarios.Length; i++)
            {
                m.To.Add(new MailAddress(destinatarios[i]));
            } 
            m.Subject = "Parecer sobre a emissão do cartão de identificação/ acesso";
            SmtpClient client = new SmtpClient();
            client.Send(m);
        }

        public void email_suporte(string email_destino, string nome, string email_origem, string telemovel, string assunto, Attachment anexo, string path, string path_2, string corpo)
        {
            string htmlBody = "       <html><body><div><img src=\"cid:Pic1\"></div></br><div>"+assunto+"</div>" + "</br><b>Nome: </b>" + nome + "<br> <b>Email:</b>" + email_origem + "<br><b>Contato:</b>" + telemovel + "<br> <b>Mensagem:</b>" + corpo + "<br></div></br><div><br><img src=\"cid:Pic2\"> </div> <br></body></html>";
            AlternateView avHtml = AlternateView.CreateAlternateViewFromString
            (htmlBody, null, MediaTypeNames.Text.Html);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic1 = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
            pic1.ContentId = "Pic1";
            avHtml.LinkedResources.Add(pic1);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic2 = new LinkedResource(path_2, MediaTypeNames.Image.Jpeg);
            pic2.ContentId = "Pic2";
            avHtml.LinkedResources.Add(pic2);
            // Add the alternate views instead of using MailMessage.Body
            MailMessage m = new MailMessage();
            m.AlternateViews.Add(avHtml);

            // Address and send the message
            m.From = new MailAddress("aerogarelajes@gmail.com", "Aerogare Civil das Lajes");
            m.CC.Add(new MailAddress(email_origem));
            m.To.Add(new MailAddress("vitor.hr.freitas@azores.gov.pt"));//informatica
            m.Subject = assunto;
            SmtpClient client = new SmtpClient();
            client.Send(m);
        }

        public void email_parecer_entidade(string path, string path_2,string emissor, string data, string mensagem)
        {
            string htmlBody = "<html><body><div><img src=\"cid:Pic1\"></div></br><div><b></b>Emissão de parecer efetuado com êxito. </div>"
                 + "<br> <b>Emissor:</b>" + emissor + "<br><b>Data:</b>" + data + "<br> <b>Parecer:</b>" + mensagem + "<br></div></br><div><img src=\"cid:Pic2\"></div> <br></body></html>";
          
            AlternateView avHtml = AlternateView.CreateAlternateViewFromString
            (htmlBody, null, MediaTypeNames.Text.Html);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic1 = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
            pic1.ContentId = "Pic1";
            avHtml.LinkedResources.Add(pic1);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic2 = new LinkedResource(path_2, MediaTypeNames.Image.Jpeg);
            pic2.ContentId = "Pic2";
            avHtml.LinkedResources.Add(pic2);
            // Add the alternate views instead of using MailMessage.Body
            MailMessage m = new MailMessage();
            m.AlternateViews.Add(avHtml);

            // Address and send the message
            m.From = new MailAddress("aerogarelajes@gmail.com", "Aerogare Civil das Lajes");
     
            m.To.Add(new MailAddress("vitor.hr.freitas@azores.gov.pt"));//DEPARTAMENTO DE COORDENACAO    
            m.Subject = "Resposta a pedido de parecer";
            SmtpClient client = new SmtpClient();
            client.Send(m);
        }


        public void email_admin_to_requerente(string email_destino, string assunto, string[] anexo, string path, string path_2, string corpo)
        {
           
            string htmlBody = "<html><body><div><img src=\"cid:Pic1\"></div></br><div>" + assunto + "</div>"
                  + "<br> <b>Mensagem:</b>" + corpo + "<br></div></br><div><br><img src=\"cid:Pic2\"> </div> <br></body></html>";

            //string htmlBody = "       <html><body><div><img src=\"cid:Pic1\"></div></br><div>" + assunto + "</div>" + "</br><b>Nome: </b>" + nome + "<br> <b>Email:</b>" + email_origem + "<br><b>Contato:</b>" + telemovel + "<br> <b>Mensagem:</b>" + corpo + "<br></div></br><div><br><img src=\"cid:Pic2\"> </div> <br></body></html>";
            AlternateView avHtml = AlternateView.CreateAlternateViewFromString
            (htmlBody, null, MediaTypeNames.Text.Html);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic1 = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
            pic1.ContentId = "Pic1";
            avHtml.LinkedResources.Add(pic1);

            // Create a LinkedResource object for each embedded image
            LinkedResource pic2 = new LinkedResource(path_2, MediaTypeNames.Image.Jpeg);
            pic2.ContentId = "Pic2";
            avHtml.LinkedResources.Add(pic2);
            // Add the alternate views instead of using MailMessage.Body
            MailMessage m = new MailMessage();
            m.AlternateViews.Add(avHtml);
            for (int i = 0; i <= anexo.Length - 1; i++)
            {

                var attachment = new Attachment(anexo[i]);
                m.Attachments.Add(attachment);
            }
            // Address and send the message
            m.From = new MailAddress("aerogarelajes@gmail.com", "Aerogare Civil das Lajes");
            m.CC.Add(new MailAddress("vitor.hr.freitas@azores.gov.pt"));//COORDENACAO
            m.To.Add(new MailAddress(email_destino));
            m.Subject = assunto;
            SmtpClient client = new SmtpClient();
            client.Send(m);
        }
    }
}