using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.PROP
{
    public class PROP_cartao
    {
//private   int p1;
//private   string p2;
//private   string p3;
//private   string p4;
//private   string p5;
//private   int p6;

        //private int p1;
        //private string p2;
        //private string p3;
        //private string p4;
        //private string p5;
        //private int p6;
        //private string p7;
        //private string p8;
        //private string p9;
        //private string p10;

        //private string p;

        //private string p1;
        //private string p2;
        //private string p3;
        //private string p4;
        //private string p5;
        //private string p6;

        //private string Pedido;
        //private string numero;
        //private string data_reg;
        //private string nome;
        //private string pessoa_requerente;
        //private string estado;

        //private int idcartao_segunda_via;
        //private string data_reg;
        //private string pessoa_requerente;
        //private string doc_path_segunda_via_cartao;
        //private string estado;

        //private int idcartao_renovacao;
        //private string data_reg;
        //private string pessoa_requerente;
        //private string doc_path_renovacao_cartao;
        //private string fotocopia_cartao_identificao;
        //private string estado;

        //private int idcartao;
        //private string morada;
        //private string localidade;
        //private string codigopostal;
        //private string telefone;
        //private string telemovel;
        //private string tele_serv;
        //private string nacionalidade;
        //private string cc;
        //private string validade_cc;
        //private string data_nascimento;
        //private string email;
        //private string categ_profissional;
        //private string tipo_de_pedido;
        //private string area_trabalho;
        //private string validade_acesso;
        //private string funcao;
        //private string horario;
        //private string areas;
        //private string cartao_pontual_visitante;
        //private string autorizacao_portas;
        //private string inquerito;
        //private string formacao;
        //private string path_doc_final;
        //private string morada5;

        //private int idcartao;
        //private string fotocopia_bi;
        //private string fotocopia_vinculo_laboral;
        //private string fotografia;
        //private string path_doc_final;
        //private string registo_criminal;
        //private string fotocopia_cartao_acompanhante;
        //private string estado;
        //private string conferido;
        //private string cor;
        //private string parecer_psp;
        //private string parecer_psp_data;
        //private string perecer_sef;
        //private string parecer_sef_data;
        //private string parecer_outros;
        //private string parecer_outros_data;
        //private string num_cartao;
        //private string tipo_de_pedido;
        //private string areas;
        //private string validade_acesso;
        //private string pagamento;

        public int idcartao_renovacao { get; set; }
        public int entidade_identidade { get; set; }
        public int idcartao { get; set; }
        public string numero { get; set; }

        public string msg_sef { get; set; }
        public string msg_psp { get; set; }
        public string data_reg { get; set; }
        public string nome { get; set; }
        public string pessoa_requerente { get; set; }
        public string estado { get; set; }
        public string fotocopia_bi { get; set; }
        public string fotocopia_vinculo_laboral { get; set; }
        public string fotografia { get; set; }
        public string registo_criminal { get; set; }
        public string fotocopia_cartao_acompanhante { get; set; }
        public string path_doc_final { get; set; }
        public string tipo_de_pedido { get; set; }
         public string conferido { get; set; }
              public string cor { get; set; }
      public string parecer_psp { get; set; }
       public string parecer_psp_data { get; set; }
           public string perecer_sef { get; set; }
               public string parecer_sef_data { get; set; }
              public string parecer_outros { get; set; }
               public string parecer_outros_data { get; set; }
               public string num_cartao { get; set; }
             
                 public string areas { get; set; }
                   public string validade_acesso { get; set; }
               public string pagamento { get; set; }
               public string morada { get; set; }
               public string localidade { get; set; }
               public string codigopostal { get; set; }
               public string telefone { get; set; }
               public string telemovel { get; set; }
               public string tele_serv { get; set; }
               public string nacionalidade { get; set; }
               public string validade_cc { get; set; }
               public string data_nascimento { get; set; }
               public string email { get; set; }
               public string categ_profissional { get; set; }
               public string bi { get; set; }
               public string area_trabalho { get; set; }
               public string funcao { get; set; }
               public string horario { get; set; }
               public string cartao_pontual_visitante { get; set; }
               public string autorizacao_portas { get; set; }
               public string inquerito { get; set; }
               public string formacao { get; set; }
               public string entidade_patronal { get; set; }
               public string nome_acompanhante { get; set; }
               public string doc_path_renovacao_cartao { get; set; }
               public string fotocopia_cartao_identificao { get; set; }
               public int idcartao_segunda_via { get; set; }
               public string doc_path_segunda_via_cartao { get; set; }
               public string Pedido { get; set; }

        public PROP_cartao(int idcartao, string numero, string data_reg, string nome, string pessoa_requerente, string estado,string tipo_de_pedido)
        {
            // TODO: Complete member initialization
            this.idcartao = idcartao;
            this.numero = numero;
            this.data_reg = data_reg;
            this.nome = nome;
            this.pessoa_requerente = pessoa_requerente;
            this.estado = estado;
            this.tipo_de_pedido = tipo_de_pedido;
        }

        public PROP_cartao(int idcartao, string numero, string data_reg, string nome, string tipo_de_pedido, string estado, string fotocopia_bi, string fotocopia_vinculo_laboral, string fotografia, string registo_criminal, string fotocopia_cartao_acompanhante, string path_doc_final, int entidade_identidade,string validade_acesso)
        {
            // TODO: Complete member initialization
            this.idcartao = idcartao;
            this.numero = numero;
            this.data_reg = data_reg;
            this.nome = nome;
            this.tipo_de_pedido = tipo_de_pedido;
            this.estado = estado;
            this.fotocopia_bi = fotocopia_bi;
            this.fotocopia_vinculo_laboral = fotocopia_vinculo_laboral;
            this.fotografia = fotografia;
            this.registo_criminal = registo_criminal;
            this.fotocopia_cartao_acompanhante = fotocopia_cartao_acompanhante;
            this.path_doc_final = path_doc_final;
            this.entidade_identidade = entidade_identidade;
            this.validade_acesso = validade_acesso;
        }

        public PROP_cartao(int idcartao, string fotocopia_bi, string fotocopia_vinculo_laboral, string fotografia, string path_doc_final, string registo_criminal, string fotocopia_cartao_acompanhante,
            string estado, string conferido, string cor, string parecer_psp, string parecer_psp_data, 
            string perecer_sef, string parecer_sef_data, string parecer_outros, string parecer_outros_data, 
            string num_cartao, string tipo_de_pedido, string areas, string validade_acesso, string pagamento,
            string autorizacao_portas,string msg_psp,string msg_sef)
        {
            // TODO: Complete member initialization
            this.idcartao = idcartao;
            this.fotocopia_bi = fotocopia_bi;
            this.fotocopia_vinculo_laboral = fotocopia_vinculo_laboral;
            this.fotografia = fotografia;
            this.path_doc_final = path_doc_final;
            this.registo_criminal = registo_criminal;
            this.fotocopia_cartao_acompanhante = fotocopia_cartao_acompanhante;
            this.estado = estado;
            this.conferido = conferido;
            this.cor = cor;
            this.parecer_psp = parecer_psp;
            this.parecer_psp_data = parecer_psp_data;
            this.perecer_sef = perecer_sef;
            this.parecer_sef_data = parecer_sef_data;
            this.parecer_outros = parecer_outros;
            this.parecer_outros_data = parecer_outros_data;
            this.num_cartao = num_cartao;
            this.tipo_de_pedido = tipo_de_pedido;
            this.areas = areas;
            this.validade_acesso = validade_acesso;
            this.pagamento = pagamento;
            this.autorizacao_portas = autorizacao_portas;
            this.msg_psp = msg_psp;
            this.msg_sef = msg_sef;
        }

        public PROP_cartao(int idcartao, string nome, string morada, string localidade, string codigopostal, string telefone, string telemovel, string tele_serv, string nacionalidade, string cc, string validade_cc, string data_nascimento, string email, string categ_profissional, string tipo_de_pedido, string area_trabalho, string validade_acesso, string funcao, string horario, string areas, string cartao_pontual_visitante, 
            string autorizacao_portas, string inquerito, string formacao, string path_doc_final, string numero,
            string num_cartao, int entidade_identidade, string entidade_patronal, string nome_acompanhante,
            string fotocopia_bi, string fotocopia_vinculo_laboral, string fotografia, string registo_criminal, string fotocopia_cartao_acompanhante)
        {
            // TODO: Complete member initialization
            this.fotocopia_bi = fotocopia_bi;
            this.fotocopia_vinculo_laboral = fotocopia_vinculo_laboral;
            this.fotografia = fotografia;
            this.registo_criminal=registo_criminal;
            this.fotocopia_cartao_acompanhante = fotocopia_cartao_acompanhante;
            this.idcartao = idcartao;
            this.morada = morada;
            this.localidade = localidade;
            this.codigopostal = codigopostal;
            this.telefone = telefone;
            this.telemovel = telemovel;
            this.tele_serv = tele_serv;
            this.nacionalidade = nacionalidade;
            this.bi = cc;
            this.validade_cc = validade_cc;
            this.data_nascimento = data_nascimento;
            this.email = email;
            this.categ_profissional = categ_profissional;
            this.tipo_de_pedido = tipo_de_pedido;
            this.area_trabalho = area_trabalho;
            this.validade_acesso = validade_acesso;
            this.funcao = funcao;
            this.horario = horario;
            this.areas = areas;
            this.cartao_pontual_visitante = cartao_pontual_visitante;
            this.autorizacao_portas = autorizacao_portas;
            this.inquerito = inquerito;
            this.formacao = formacao;
            this.path_doc_final = path_doc_final;
            this.nome = nome;
            this.numero = numero;
            this.num_cartao = num_cartao;
            this.entidade_identidade = entidade_identidade;
            this.entidade_patronal = entidade_patronal;
            this.nome_acompanhante = nome_acompanhante;
        }

        public PROP_cartao(int idcartao_renovacao, string data_reg, string pessoa_requerente, string doc_path_renovacao_cartao, string fotocopia_cartao_identificao, string estado)
        {
            // TODO: Complete member initialization
            this.idcartao_renovacao = idcartao_renovacao;
            this.data_reg = data_reg;
            this.pessoa_requerente = pessoa_requerente;
            this.doc_path_renovacao_cartao = doc_path_renovacao_cartao;
            this.fotocopia_cartao_identificao = fotocopia_cartao_identificao;
            this.estado = estado;
        }

        public PROP_cartao(int idcartao_segunda_via, string data_reg, string pessoa_requerente, string doc_path_segunda_via_cartao, string estado)
        {
            // TODO: Complete member initialization
            this.idcartao_segunda_via = idcartao_segunda_via;
            this.data_reg = data_reg;
            this.pessoa_requerente = pessoa_requerente;
            this.doc_path_segunda_via_cartao = doc_path_segunda_via_cartao;
            this.estado = estado;
        }

        public PROP_cartao(string Pedido, string numero, string data_reg, string nome, string pessoa_requerente, string estado, int entidade_identidade)
        {
            // TODO: Complete member initialization
            this.Pedido = Pedido;
            this.numero = numero;
            this.data_reg = data_reg;
            this.nome = nome;
            this.pessoa_requerente = pessoa_requerente;
            this.estado = estado;
            this.entidade_identidade = entidade_identidade;
        }

        public PROP_cartao(string Pedido, string numero, string data_reg, string nome, string pessoa_requerente, string estado)
        {
            // TODO: Complete member initialization
            this.Pedido = Pedido;
            this.numero = numero;
            this.data_reg = data_reg;
            this.nome = nome;
            this.pessoa_requerente = pessoa_requerente;
            this.estado = estado;
        }

        public PROP_cartao(string num_cartao)
        {
            // TODO: Complete member initialization
            this.num_cartao = num_cartao;
        }
 //string p7, string p8, string p9, string p10
        public PROP_cartao(int idcartao, string data_reg, string nome, string tipo_de_pedido, string fotografia, int entidade_identidade)
        {
            // TODO: Complete member initialization
            this.idcartao = idcartao;
           
            this.data_reg = data_reg;
            this.nome = nome;
            this.tipo_de_pedido = tipo_de_pedido;
            this.fotografia = fotografia;
            this.entidade_identidade = entidade_identidade;
            //this.p8 = p8;
            //this.p9 = p9;
            //this.p10 = p10;
        }

    }
     
}
