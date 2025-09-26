using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.PROP
{
    public class PROP_conducao
    {

//private int p7;
//private string p8;
//private string p9;
//private string p10;
//private string p11;
//private string p12;
//private string p13;
//private string p1;
//private string p2;
//private string p3;
//private string p4;
//private string p5;
//private string p6;
        
        public int idconducao_renovacao { get; set; }
        public int idconducao { get; set; }
        public int idsegunda_via_conducao { get; set; }
        public string data_reg { get; set; }
        public string path_doc_segunda_via_conducao { get; set; }
        public string path_doc_renovacao_conducao { get; set; }
        public string numero { get; set; }
        public string datareg { get; set; }
        public string nome { get; set; }
        public string pessoa_requerente { get; set; }
        public string estado { get; set; }
        public string fotocopia_cartao_acl { get; set; }
        public string fotocopia_carta_conducao { get; set; }
        public string soa { get; set; }
        public string soa_nome { get; set; }
        public string path_doc_final { get; set; }
        public string entidade_identidade { get; set; }
        public string entidade_patronal { get; set; }
        public string funcao { get; set; }
        public string n_cartao_acesso { get; set; }
        public string n_carta_conducao { get; set; }
        public string categorias { get; set; }
        public string data_emissao { get; set; }
        public string local_emissao { get; set; }
        public string validade { get; set; }
        public string areas_circulacao { get; set; }
        public string categoria_viaturas { get; set; }
        public string pedido { get; set; }




        public PROP_conducao()
        {

        }
        public PROP_conducao(int idconducao, string numero, string datareg, string nome, string entidade_identidade,
            string estado, string fotocopia_cartao_acl, string fotocopia_carta_conducao, string soa, string soa_nome, string path_doc_final,string validade)
        {
            // TODO: Complete member initialization
            this.idconducao = idconducao;
            this.numero = numero;
            this.datareg = datareg;
            this.nome = nome;
            this.entidade_identidade = entidade_identidade;
            this.estado = estado;
            this.fotocopia_cartao_acl = fotocopia_cartao_acl;
            this.fotocopia_carta_conducao = fotocopia_carta_conducao;
            this.soa = soa;
            this.soa_nome = soa_nome;
            this.path_doc_final = path_doc_final;
            this.validade = validade;
        }
    
        public PROP_conducao(int idconducao, string nome, string entidade_patronal, string funcao, string n_cartao_acesso,
            string n_carta_conducao, string categorias, string data_emissao, string local_emissao, string validade, string areas_circulacao,
            string categoria_viaturas, string soa, string entidade_identidade, string estado, string pessoa_requerente, string numero,
            string datareg, string soa_nome, string path_doc_final)
        {
            // TODO: Complete member initialization
            this.idconducao = idconducao;
            this.nome = nome;
            this.entidade_patronal = entidade_patronal;
            this.funcao = funcao;
            this.n_cartao_acesso = n_cartao_acesso;
            this.n_carta_conducao = n_carta_conducao;
            this.categorias = categorias;
            this.data_emissao = data_emissao;
            this.local_emissao = local_emissao;
            this.validade = validade;
            this.areas_circulacao = areas_circulacao;
            this.categoria_viaturas = categoria_viaturas;
            this.soa = soa;
            this.entidade_identidade = entidade_identidade;
            this.estado = estado;
            this.pessoa_requerente = pessoa_requerente;
            this.numero = numero;
            this.datareg = datareg;
            this.soa_nome = soa_nome;
            this.path_doc_final = path_doc_final;
        }

     
        public PROP_conducao(int idconducao, string numero, string datareg, string nome, string pessoa_requerente, string estado, string soa, string soa_nome, string path_doc_final)
        {
            // TODO: Complete member initialization
            this.idconducao = idconducao;
            this.numero = numero;
            this.datareg = datareg;
            this.nome = nome;
            this.pessoa_requerente = pessoa_requerente;
            this.estado = estado;
            this.soa = soa;
            this.soa_nome = soa_nome;
            this.path_doc_final = path_doc_final;
        }

        public PROP_conducao(int idconducao, string nome, string entidade_patronal, string funcao, string n_cartao_acesso, string n_carta_conducao, string categorias, string data_emissao, string local_emissao, string validade, string areas_circulacao, string categoria_viaturas, string soa, string entidade_identidade, string estado, string pessoa_requerente, string numero, string datareg, string soa_nome, string path_doc_final,  string fotocopia_carta_conducao, string fotocopia_cartao_acl)
        {
            // TODO: Complete member initialization
            this.idconducao = idconducao;
            this.nome = nome;
            this.entidade_patronal = entidade_patronal;
            this.funcao = funcao;
            this.n_cartao_acesso = n_cartao_acesso;
            this.n_carta_conducao = n_carta_conducao;
            this.categorias = categorias;
            this.data_emissao = data_emissao;
            this.local_emissao = local_emissao;
            this.validade = validade;
            this.areas_circulacao = areas_circulacao;
            this.categoria_viaturas = categoria_viaturas;
            this.soa = soa;
            this.entidade_identidade = entidade_identidade;
            this.estado = estado;
            this.pessoa_requerente = pessoa_requerente;
            this.numero = numero;
            this.datareg = datareg;
            this.soa_nome = soa_nome;
            this.path_doc_final = path_doc_final;
            this.fotocopia_carta_conducao = fotocopia_carta_conducao;
            this.fotocopia_cartao_acl = fotocopia_cartao_acl;
            
        }

        public PROP_conducao(int idsegunda_via_conducao, string data_reg, string pessoa_requerente, string path_doc_segunda_via_conducao, string estado)
        {
            // TODO: Complete member initialization
            this.idsegunda_via_conducao = idsegunda_via_conducao;
            this.data_reg = data_reg;
            this.pessoa_requerente = pessoa_requerente;
            this.path_doc_segunda_via_conducao = path_doc_segunda_via_conducao;
            this.estado = estado;

            this.idconducao_renovacao = idsegunda_via_conducao;
            this.path_doc_renovacao_conducao = path_doc_segunda_via_conducao;
        }

        public    PROP_conducao(string pedido,string numero,string datareg,string nome,string pessoa_requerente,string estado,int entidade_identidade)
          {
        // TODO: Complete member initialization
            this.pedido = pedido;
            this.numero = numero;
            this.datareg = datareg;
            this.nome = nome;
            this.pessoa_requerente = pessoa_requerente;
            this.estado = estado;
            this.entidade_identidade = entidade_identidade.ToString();
    }

        //public PROP_conducao(int p7, string p8, string p9, string p10, string p11, string p12, string p13)
        //{
        //    // TODO: Complete member initialization
        //    this.p7 = p7;
        //    this.p8 = p8;
        //    this.p9 = p9;
        //    this.p10 = p10;
        //    this.p11 = p11;
        //    this.p12 = p12;
        //    this.p13 = p13;
        //}



        public PROP_conducao(string pedido, string numero, string datareg, string nome, string pessoa_requerente, string estado)
        {
            // TODO: Complete member initialization
            this.pedido = pedido;
            this.numero = numero;
            this.datareg = datareg;
            this.nome = nome;
            this.pessoa_requerente = pessoa_requerente;
            this.estado = estado;
        }

        //public PROP_conducao(int idconducao_renovacao, string data_reg, string pessoa_requerente, string path_doc_renovacao_conducao, string estado)
        //{
        //    // TODO: Complete member initialization
        //    this.idconducao_renovacao = idconducao_renovacao;
        //    this.data_reg = data_reg;
        //    this.pessoa_requerente = pessoa_requerente;
        //    this.path_doc_renovacao_conducao = path_doc_renovacao_conducao;
        //    this.estado = estado;
        //}
        
    }
}