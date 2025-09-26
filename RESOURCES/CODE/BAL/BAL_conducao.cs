using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication10.DAL;
using WebApplication10.PROP;

namespace WebApplication10.BAL
{
    public class BAL_conducao
    {
        public int numero_conducao()
        {
            DAL_conducao numero = new DAL_conducao();
            return Convert.ToInt32(numero.numero_conducao());
     

        }
        public int numero_segunda_via_conducao(int idpedido)
        {
            DAL_conducao numero = new DAL_conducao();
            return Convert.ToInt32(numero.numero_segunda_via_conducao(idpedido));
;

        }
        public string email_based_idpedido(int idpedido)
        {
            DAL_conducao email_conducao = new DAL_conducao();
            return email_conducao.email_based_idpedido(idpedido);
        }

        public int numero_renovacao_conducao(int idpedido)
        {
            DAL_conducao numero = new DAL_conducao();
            return Convert.ToInt32(numero.numero_renovacao_conducao(idpedido));
        }
       
        public int Create_conducao(string nome,string entidade_patronal,  string funcao,string n_cartao_acl, 
            string n_carta_conducao,string categorias,string data_emissao,string local_emissao,string validade, 
            string areas_circulacao,string categorias_viaturas,string soa, string fotocopia_cartao_acl, string fotocopia_carta_conducao,
            int entidade_identidade, string estado, string pessoa_requerente, string numero, string datareg, string path_doc_final, string user_req)
        {
            DAL_conducao insert = new DAL_conducao();
          return  insert.Create_conducao(nome, entidade_patronal, funcao, n_cartao_acl,
              n_carta_conducao, categorias, data_emissao, local_emissao, validade,
              areas_circulacao, categorias_viaturas, soa, fotocopia_cartao_acl,
              fotocopia_carta_conducao, entidade_identidade, estado, pessoa_requerente, numero, datareg, path_doc_final, user_req);
        }

        public int inserir_segunda_via_conducao(string nome, string funcao,
            string n_cartao_acl, string n_carta_conducao, string categorias,
            string data_emissao, string local_emissao,
               string validade, string areas_circulacao, string categorias_viaturas, string fotocopia_cartao_acl,
            string fotocopia_carta_conducao, string estado, string pessoa_requerente,
            string data_reg_2, string path_doc_conducao_2, int id_pedido_conducao)
        {
            DAL_conducao via = new DAL_conducao();
            return via.inserir_segunda_via_conducao(nome, funcao, n_cartao_acl, n_carta_conducao, categorias, data_emissao, local_emissao,
            validade, areas_circulacao, categorias_viaturas, fotocopia_cartao_acl, fotocopia_carta_conducao, estado, pessoa_requerente,
    data_reg_2, path_doc_conducao_2, id_pedido_conducao);
        }

        public int inserir_renovacao_conducao(string nome, string funcao,
         string n_cartao_acl, string n_carta_conducao, string categorias,
         string data_emissao, string local_emissao,
            string validade, string areas_circulacao, string categorias_viaturas, string fotocopia_cartao_acl,
         string fotocopia_carta_conducao, string estado, string pessoa_requerente,
         string data_reg_2, string path_doc_conducao_2, int id_pedido_conducao)
        {
            DAL_conducao via = new DAL_conducao();
            return via.inserir_renovacao_conducao(nome, funcao, n_cartao_acl, n_carta_conducao, categorias, data_emissao, local_emissao,
            validade, areas_circulacao, categorias_viaturas, fotocopia_cartao_acl, fotocopia_carta_conducao, estado, pessoa_requerente,
    data_reg_2, path_doc_conducao_2, id_pedido_conducao);
        }
        public List<PROP_conducao> filtro_conducao_by_nome(string nome)
        {
            DAL_conducao conducao = new DAL_conducao();
            return conducao.filtro_conducao_by_nome(("%" + nome + "%").ToString());
        }
        public List<PROP_conducao> filtro_conducao_by_nome_identidade(string nome, int id_ent)
        {
            DAL_conducao conducao = new DAL_conducao();
            return conducao.filtro_conducao_by_nome_identidade(("%" + nome + "%").ToString(), id_ent);
        }
        public List<PROP_conducao> get_conducao_by_entidade(int identidade)
        {
            DAL_conducao conducao = new DAL_conducao();
           return   conducao.get_conducao_by_entidade(identidade);
        }

        public List<PROP_conducao> get_conducao_by_pendente(string identidade)
        { 
            DAL_conducao conducao = new DAL_conducao();
            if (identidade == null)
            {
                return conducao.get_conducao_pendente_admin();
            }
            else
            {
                return conducao.get_conducao_by_identidade_pendente(Convert.ToInt32(identidade));
            }
        }

        public List<PROP_conducao> get_all_conducao()
        {
            DAL_conducao conducao = new DAL_conducao();
            return conducao.get_all_conducao();
        }

        public List<PROP_conducao> get_conducao_by_numero_and_entidade(int idconducao)
        {
            DAL_conducao conducao = new DAL_conducao();
            return conducao.get_conducao_by_numero_and_entidade(idconducao);
        }
        public List<PROP_conducao> get_conducao_segunda_via(int idpedido)
        {
            DAL_conducao conducao = new DAL_conducao();
            return conducao.get_conducao_segunda_via(idpedido);
        }

        public List<PROP_conducao> get_renovacao(int idpedido)
        {
            DAL_conducao conducao = new DAL_conducao();
            return conducao.get_conducao_renovacao(idpedido);
        }

        public bool update_estado_pedido_conducao(int identrada, string estado,string soa,string soa_nome)
        {
            DAL_conducao conducao = new DAL_conducao();
            conducao.Update_estado_pedido_conducao(identrada, estado,soa,soa_nome);
            return true;
        }

        public bool update_estado_via_conducao(int identrada, string estado)
        {
            DAL_conducao conducao = new DAL_conducao();
            conducao.Update_estado_via_conducao(identrada, estado);
            return true;
        }

        public bool update_estado_renovacao_conducao(int identrada, string estado)
        {
            DAL_conducao conducao = new DAL_conducao();
            conducao.Update_estado_renovacao_conducao(identrada, estado);
            return true;
        }

        public int update_estado_inativo_conducao(int idin)
        {
            DAL_conducao conducao = new DAL_conducao();
            return    conducao.update_estado_inativo_conducao(idin);
         
        }

        //public List<PROP_conducao> get_conducao_by_pendente_admin()
        //{
        //    DAL_conducao conducao = new DAL_conducao();
        //    return conducao.get_conducao_pendente_admin();

        //}
    }
}