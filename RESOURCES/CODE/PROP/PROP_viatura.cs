using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.PROP
{
    public class PROP_viatura
    {
        //private string p;

        //private int p1;
        //private string p2;
        //private string p3;
        //private string p4;
        //private string p5;
        //private string p6;
        //private string p7;
        //private string p8;
        //private string p9;
        //private string p10;
        //private int p11;

      
        public string Pedido { get; set; }
        public string path_doc_segunda_via_viatura { get; set; }
        public int idviatura_via { get; set; }
        public string path_doc_renovacao_viatura { get; set; }
        public int idviatura{ get; set; }
        public string pessoa_requerente { get; set; }
        public string proprietario { get; set; }
        public string servico { get; set; }
        public string ipo_validade { get; set; }
        public string ipo { get; set; }
        public string companhia_seguro { get; set; }
        public string validade_seguro { get; set; }
        public string apolice { get; set; }
        public string cor { get; set; }
        public string numero { get; set; }
        public string data_reg { get; set; }
        public string matricula { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string estado { get; set; }
        public string n_identificacao { get; set; }
        public int entidade_identidade { get; set; }
        public string fotocopia_livrete { get; set; }
        public string fotocopia_registop { get; set; }
        public string fotocopia_cartaverde { get; set; }
        public string fotocopia_declaracao_segurador { get; set; }
        public string fotocopia_ipo { get; set; }
        public string path_doc_final_viaturas { get; set; }
        public string outros_servicos { get; set; }
        public string portao_acesso { get; set; }
        public string distico { get; set; }
        public string conferido { get; set; }
        public string validade_acesso { get; set; }
        public string tipo_de_pedido { get; set; }
        public string path_fotocopia_cartao_circulacao { get; set; }
        public int idviatura_renovacao { get; set; }

        public PROP_viatura(int idviatura, string numero, string n_identificacao, string data_reg, string matricula, string marca, string modelo, string estado, int entidade_identidade,string tipo_de_pedido,
          string fotocopia_livrete, string fotocopia_registop, string fotocopia_cartaverde, string fotocopia_declaracao_segurador, string fotocopia_ipo, string path_doc_final_viaturas,string validade_acesso)
        {
            // TODO: Complete member initialization
            this.idviatura = idviatura;
            this.numero = numero;
            this.data_reg = data_reg;
            this.matricula = matricula;
            this.marca = marca;
            this.modelo = modelo;
            this.estado = estado;
            this.n_identificacao = n_identificacao;
            this.entidade_identidade = entidade_identidade;
            this.fotocopia_livrete = fotocopia_livrete;
            this.fotocopia_registop = fotocopia_registop;
            this.fotocopia_cartaverde = fotocopia_cartaverde;
            this.fotocopia_declaracao_segurador = fotocopia_declaracao_segurador;
            this.fotocopia_ipo = fotocopia_ipo;
            this.path_doc_final_viaturas = path_doc_final_viaturas;
            this.tipo_de_pedido = tipo_de_pedido;
            this.validade_acesso = validade_acesso;
        }

        public PROP_viatura(int idviatura, string numero, string n_identificacao, string data_reg, string matricula, string marca, string modelo, string estado)
        {
            // TODO: Complete member initialization
            this.idviatura = idviatura;
            this.numero = numero;
            this.n_identificacao = n_identificacao;
            this.data_reg = data_reg;
            this.matricula = matricula;
            this.marca = marca;
            this.modelo = modelo;
            this.estado = estado;
        }

        public PROP_viatura(int idviatura, string n_identificacao, string outros_servicos, string estado,string portao_acesso, string distico, string conferido,  string validade_acesso, string tipo_de_pedido)
        {
            // TODO: Complete member initialization
            this.idviatura = idviatura;
            this.n_identificacao = n_identificacao;
            this.outros_servicos = outros_servicos;
            this.estado = estado;
                 this.portao_acesso = portao_acesso;  
            this.distico = distico;
            this.conferido = conferido;
            this.validade_acesso = validade_acesso;
            this.tipo_de_pedido = tipo_de_pedido;
     
        }

        public PROP_viatura(int idviatura, string marca, string modelo, string cor, string matricula, string n_identificacao, string apolice, string companhia_seguro, string validade_seguro, string ipo, string ipo_validade, string tipo_de_pedido, string servico, string fotocopia_livrete, string fotocopia_registop, string fotocopia_cartaverde, string fotocopia_declaracao_segurador, string fotocopia_ipo, int entidade_identidade, string estado, string proprietario, string distico, string portao_acesso, string outros_servicos, string data_reg, string numero, string conferido, string pessoa_requerente, string validade_acesso, string path_doc_final_viaturas)
        {
            // TODO: Complete member initialization
            this.idviatura = idviatura;
            this.marca = marca;
            this.modelo = modelo;
            this.cor = cor;
            this.matricula = matricula;
            this.n_identificacao = n_identificacao;
            this.apolice = apolice;
            this.companhia_seguro = companhia_seguro;
            this.validade_seguro = validade_seguro;
            this.ipo = ipo;
            this.ipo_validade = ipo_validade;
            this.tipo_de_pedido = tipo_de_pedido;
            this.servico = servico;
            this.fotocopia_livrete = fotocopia_livrete;
            this.fotocopia_registop = fotocopia_registop;
            this.fotocopia_cartaverde = fotocopia_cartaverde;
            this.fotocopia_declaracao_segurador = fotocopia_declaracao_segurador;
            this.fotocopia_ipo = fotocopia_ipo;
            this.entidade_identidade = entidade_identidade;
            this.estado = estado;
            this.proprietario = proprietario;
            this.distico = distico;
            this.portao_acesso = portao_acesso;
            this.outros_servicos = outros_servicos;
            this.data_reg = data_reg;
            this.numero = numero;
            this.conferido = conferido;
            this.pessoa_requerente = pessoa_requerente;
            this.validade_acesso = validade_acesso;
            this.path_doc_final_viaturas = path_doc_final_viaturas;
        }

        public PROP_viatura(int idviatura_via, string data_reg, string pessoa_requerente, string path_doc_segunda_via_viatura, string estado)
        {
            // TODO: Complete member initialization
            this.idviatura_via = idviatura_via;
            this.data_reg = data_reg;
            this.pessoa_requerente = pessoa_requerente;
            this.path_doc_segunda_via_viatura = path_doc_segunda_via_viatura;
            this.estado = estado;
        }

        public PROP_viatura(int idviatura_renovacao, string data_reg, string pessoa_requerente, string path_doc_renovacao_viatura, string path_fotocopia_cartao_circulacao, string estado)
        {
            // TODO: Complete member initialization
            this.idviatura_renovacao = idviatura_renovacao;
            this.data_reg = data_reg;
            this.pessoa_requerente = pessoa_requerente;
            this.path_doc_renovacao_viatura = path_doc_renovacao_viatura;
            this.path_fotocopia_cartao_circulacao = path_fotocopia_cartao_circulacao;
            this.estado = estado;
        }

        public PROP_viatura(string Pedido, string numero, string data_reg, string matricula, string marca, string modelo, string pessoa_requerente, string estado, int entidade_identidade)
        {
            // TODO: Complete member initialization
            this.Pedido = Pedido;
            this.numero = numero;
            this.data_reg = data_reg;
            this.matricula = matricula;
            this.marca = marca;
            this.modelo = modelo;
            this.pessoa_requerente = pessoa_requerente;
            this.estado = estado;
            this.entidade_identidade = entidade_identidade;

        }

        public PROP_viatura(int idviatura, string numero, string tipo_de_pedido, string pessoa_requerente, string n_identificacao, string data_reg, string matricula, string marca, string modelo, string estado)
        {
            // TODO: Complete member initialization
            this.idviatura = idviatura;
            this.numero = numero;
            this.tipo_de_pedido = tipo_de_pedido;
            this.pessoa_requerente = pessoa_requerente;
            this.n_identificacao = n_identificacao;
            this.data_reg = data_reg;
            this.matricula = matricula;
            this.marca = marca;
            this.modelo = modelo;
            this.estado = estado;
        }

        //public PROP_viatura(string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, int p11)
        //{
        //    // TODO: Complete member initialization
        //    this.p2 = p2;
        //    this.p3 = p3;
        //    this.p4 = p4;
        //    this.p5 = p5;
        //    this.p6 = p6;
        //    this.p7 = p7;
        //    this.p8 = p8;
        //    this.p9 = p9;
        //    this.p11 = p11;
        //}

        public PROP_viatura(string Pedido, string numero, string data_reg, string matricula, string marca, string modelo, string pessoa_requerente, string estado)
        {
            // TODO: Complete member initialization
            this.Pedido = Pedido;
            this.numero = numero;
            this.data_reg = data_reg;
            this.matricula = matricula;
            this.marca = marca;
            this.modelo = modelo;
            this.pessoa_requerente = pessoa_requerente;
            this.estado = estado;

        }

        public PROP_viatura(string n_identificacao)
        {
            // TODO: Complete member initialization
            this.n_identificacao = n_identificacao;
        }
    }
}