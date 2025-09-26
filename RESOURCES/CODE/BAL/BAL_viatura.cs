using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication10.DAL;
using WebApplication10.PROP;

namespace WebApplication10.BAL
{
    public class BAL_viatura
    {
        public int numero_viatura()
        {
            DAL_viatura numero = new DAL_viatura();
            return Convert.ToInt32(numero.numero_viatura());
        }

        public string email_based_idviatura(int id)
        {
            DAL_viatura viatura = new DAL_viatura();
           return viatura.email_based_idpedido(id);
        }

        public int update_admin_viatura(string n_identificacao, string outros_servicos, string estado, string portao_acesso, string distico, string conferido, string validade_acesso, string tipo_de_acesso, int idin)
        {
            DAL_viatura viatura = new DAL_viatura();
        return viatura.update_admin_viatura(n_identificacao, outros_servicos, estado, portao_acesso, distico, conferido, validade_acesso, tipo_de_acesso, idin);
        
        }
        public int Create(string marca, string modelo, string cor, string matricula,
         string apolice, string companhia_seguro, string validade_seguro,
        string ipo, string ipo_validade, string tipo_de_pedido, string servico, string fotocopia_livrete,
        string fotocopia_registop, string fotocopia_cartaverde, string fotocopia_ipo, string fotocopia_declaracao_segurador,
          int entidade_identidade, string estado, string pessoa_requerente, string numero, string proprietario, string validade_acesso,
        string datareg, string path_doc_final_viaturas,string n_identificacao,string distico, string user_req)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.Create_viatura(marca, modelo, cor, matricula,
                apolice, companhia_seguro, validade_seguro, ipo, ipo_validade,
                tipo_de_pedido, servico, fotocopia_livrete, fotocopia_registop,
                fotocopia_cartaverde, fotocopia_ipo, fotocopia_declaracao_segurador, entidade_identidade, estado, pessoa_requerente, numero, proprietario, validade_acesso, datareg, path_doc_final_viaturas, n_identificacao, distico, user_req);
        }

        public List<PROP_viatura> get_viatura_by_entidade(int identidade)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.get_viatura_by_entidade(identidade);
        }

        public string get_viatura_entidade_by_id(int entidade_entrada)
        {
            DAL_viatura viatura = new DAL_viatura();
            int n_viaturas=Convert.ToInt32(viatura.get_viatura_entidade_by_id(entidade_entrada));
            n_viaturas = n_viaturas+1;
            //return viatura.get_viatura_entidade_by_id(entidade_entrada).ToString();
            if (n_viaturas < 10)
            {
                string aux = "0";
                return aux + n_viaturas.ToString();
            }
            else 
                return n_viaturas.ToString();
        }
        public List<PROP_viatura> get_viatura_all()
        {
            DAL_viatura viatura = new DAL_viatura();
          return  viatura.get_viatura_all();
        }
        public List<PROP_viatura> get_viatura_idviatura(int idin)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.get_viatura_by_idviatura(idin);
        }
      
        public List<PROP_viatura> get_viatura_renovacao_by_ID(int idin)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.get_viatura_renovacao_by_ID(idin);
        }
        public int insert_segunda_via_viatura(int idin, string apolice, string companhia_seguro, string validade_seguro,
            string ipo, string ipo_validade, string servico, string tipo_de_pedido, string validade_acesso, string fotocopia_livrete,
            string fotocopia_registop, string fotocopia_cartaverde, string fotocopia_declaracao_segurador, string fotocopia_ipo, 
            string data_reg, string pessoa_requerente, string path_doc_segunda_via_viatura)
        {
            DAL_viatura viatura = new DAL_viatura();
           return viatura.insert_segunda_via_viatura(idin, apolice, companhia_seguro, validade_seguro, ipo, ipo_validade, servico, tipo_de_pedido, validade_acesso, fotocopia_livrete, fotocopia_registop, fotocopia_cartaverde, fotocopia_declaracao_segurador, fotocopia_ipo, 
               data_reg, pessoa_requerente, path_doc_segunda_via_viatura);
        }

        public int insert_renovacao_viatura(int idin, string apolice, string companhia_seguro, string validade_seguro,
           string ipo, string ipo_validade, string servico, string tipo_de_pedido, string validade_acesso, string fotocopia_livrete,
           string fotocopia_registop, string fotocopia_cartaverde, string fotocopia_declaracao_segurador, string fotocopia_ipo,
           string data_reg, string pessoa_requerente, string path_doc_renovacao_viatura, string path_fotocopia_cartao_circulacao)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.insert_renovacao_viatura(idin, apolice, companhia_seguro, validade_seguro, ipo, ipo_validade, servico, tipo_de_pedido, validade_acesso, fotocopia_livrete, fotocopia_registop, fotocopia_cartaverde, fotocopia_declaracao_segurador, fotocopia_ipo,
                data_reg, pessoa_requerente, path_doc_renovacao_viatura, path_fotocopia_cartao_circulacao);
        }

        public string numero_renovacao_viatura(int idpedido)
        {
            DAL_viatura viatura = new DAL_viatura();
             return    viatura.numero_renovacao_viatura(idpedido);
        }

        public string numero_segunda_via_viatura(int idpedido)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.numero_segunda_via_viatura(idpedido);
        }
        public List<PROP_viatura> get_viatura_segunda_via(int idpedido)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.get_viatura_segunda_via(idpedido);
        }

        public List<PROP_viatura> get_viatura_renovacao(int idpedido)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.get_viatura_renovacao(idpedido);
        }
        public string estado_via(int idvia)
        {
            DAL_viatura viatura = new DAL_viatura();
           return viatura.estado_via_viatura(idvia);
        }

        public string estado_renovacao(int idrenovacao)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.estado_renovacao_viatura(idrenovacao);
        }
        public int update_admin_via_viatura(string n_identificacao, string outros_servicos, string estado, string portao_acesso, string distico, string conferido, string validade_acesso, string tipo_de_acesso, int idin, int idrenovacao)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.update_admin_via_viatura(n_identificacao, outros_servicos, estado, portao_acesso, distico, conferido, validade_acesso, tipo_de_acesso, idin, idrenovacao);

        }
        public int update_admin_renovacao_viatura(string n_identificacao, string outros_servicos, string estado, string portao_acesso, string distico, string conferido, string validade_acesso, string tipo_de_acesso, int idin, int idrenovacao)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.update_admin_renovacao_viatura(n_identificacao, outros_servicos, estado, portao_acesso, distico, conferido, validade_acesso, tipo_de_acesso, idin, idrenovacao);

        }
        public string select_path_doc_renovacao_viatura(int idrenovacao)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.select_path_doc_renovacao_viatura(idrenovacao);
        }

        public string select_path_doc_via_viatura(int idvia)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.select_path_doc_via_viatura(idvia);
        }

        public List<PROP_viatura> select_viatura_by_identidade_pendente(string identidade)
        {
            DAL_viatura viatura = new DAL_viatura();
            if (identidade == null)
            {
                return viatura.select_viatura_by_pendente_admin();
            }
            else
            {
                return viatura.select_viatura_by_identidade_pendente(Convert.ToInt32(identidade));
            }
        }
        public List<PROP_viatura> valida_n_identificacao(string n_identificacao_new, int cartao_escolhido)
        {
       
            DAL_viatura viatura = new DAL_viatura();
            return viatura.valida_n_identificacao(n_identificacao_new, cartao_escolhido);
        }

        public int update_estado_inativo_viatura(int idin)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.update_estado_inativo_viatura(idin);
        }


        public string valida_distico(string n_distico, int id_viatura)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.valida_distico(n_distico,id_viatura);
        }

        public string valida_matricula(string matricula_in, int idviatura_in)
        {
            DAL_viatura viatura = new DAL_viatura();
            return viatura.valida_matricula(matricula_in, idviatura_in);
        }

        
    }
}