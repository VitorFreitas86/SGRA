using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication10.DAL;
using WebApplication10.PROP;

namespace WebApplication10.BAL
{
    public class BAL_cartao
    {
        public List<PROP_cartao> get_cartao_renovacao_by_id(int id)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.get_cartao_renovacao_by_ID(id);
        }
        public List<PROP_cartao> get_cartao_admin_by_id(int id)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.get_cartao_admin_by_id(id);
        }
        public List<PROP_cartao> get_cartao_by_entidade(int identidade)
        {
            DAL_cartao cartao = new DAL_cartao();
           return cartao.get_cartao_by_entidade(identidade);
        }
        public List<PROP_cartao> filtro_cartao_by_nome_entidade(string nome_pesq, int id_ent)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.filtro_cartao_by_nome_entidade(("%" + nome_pesq + "%").ToString(), id_ent);
        }

        public List<PROP_cartao> filtro_cartao_by_nome(string nome_pesq)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.filtro_cartao_by_nome(("%" + nome_pesq + "%").ToString());
        }
        public List<PROP_cartao> get_cartao_all()
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.get_cartao_all();
        }

        public List<PROP_cartao> get_cartao_all_parecer_psp()
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.get_cartao_all_parecer_psp();
        }

        public List<PROP_cartao> get_cartao_all_parecer_sef()
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.get_cartao_all_parecer_sef();
        }

        public string email_by_id(int id)
        {
        DAL_cartao cartao = new DAL_cartao();
         return cartao.email_by_idcartao(id);
        }

        //public string email_based_idcartao(int id)
        //{
        //    DAL_cartao cartao = new DAL_cartao();
        //    return cartao.email_based_idpedido(id);
        //}

        
        public int numero_cartao()
        {
            DAL_cartao numero = new DAL_cartao();
            return Convert.ToInt32(numero.numero_cartao());
           }

        public int Create_cartao(string nome, string morada, string localidade, string codigopostal,
         string telefone, string telemovel, string tele_serv,
        string nacionalidade, string cc, string validade_cc, string data_nascimento, string email,
        string entidade_patronal, string categ_profissional, string tipo_de_pedido, string area_trabalho, string validade_acesso,
           string funcao, string horario, string areas, string cartao_pontual_visitante, string autorizacao_portas, string inquerito,
           string formacao, string fotocopia_bi, string fotocopia_vinculo_laboral, string fotografia, string path_doc_final, string registo_criminal, string fotocopia_cartao_acompanhante,
           string estado, int entidade_identidade, string data_reg, string pessoa_requerente, string numero, string nome_acompanhante, string user_req)
        {
            DAL_cartao cartao = new DAL_cartao();
         return   cartao.Create_cartao(nome, morada, localidade, codigopostal, telefone, telemovel, tele_serv, nacionalidade, cc, validade_cc, data_nascimento,
                email,entidade_patronal, categ_profissional, tipo_de_pedido, area_trabalho, validade_acesso, funcao, horario, areas, cartao_pontual_visitante,
                autorizacao_portas, inquerito, formacao, fotocopia_bi, fotocopia_vinculo_laboral, fotografia, path_doc_final, registo_criminal, fotocopia_cartao_acompanhante,
                estado, entidade_identidade, data_reg, pessoa_requerente, numero, nome_acompanhante, user_req);
        }
        public int update_admin_cartao(int idin, string estado, string conferido, string cor, string parecer_psp, string parecer_psp_data, string perecer_sef, string parecer_sef_data
            , string parecer_outros, string parecer_outros_data, string num_cartao, string tipo_de_pedido, string areas, string validade_acesso, string pagamento, string autorizacao_portas, string req_sef, string req_psp)
        {
            DAL_cartao cartao = new DAL_cartao();
          return  cartao.update_admin_cartao(idin, estado, conferido, cor, parecer_psp, parecer_psp_data, perecer_sef, parecer_sef_data, parecer_outros, parecer_outros_data, num_cartao, tipo_de_pedido, areas, validade_acesso, pagamento,autorizacao_portas,req_sef,req_psp);
        }
        public int insert_renovacao_cartao(string nome, string morada, string localidade, string codigopostal,
       string telefone, string telemovel, string tele_serv,
      string nacionalidade, string cc, string validade_cc, string data_nascimento, string email,
      string entidade_patronal, string categ_profissional, string tipo_de_pedido, string area_trabalho, string validade_acesso,
         string funcao, string horario, string areas, string cartao_pontual_visitante, string autorizacao_portas, string inquerito,
         string formacao, string fotocopia_bi, string fotocopia_vinculo_laboral, string fotografia, string registo_criminal, string fotocopia_cartao_acompanhante,
         string estado, int entidade_identidade, string data_reg, string pessoa_requerente, string numero, string nome_acompanhante, string doc_path_renovacao_cartao, string fotocopia_cartao_identificacao, int id)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.insert_renovacao_cartao(nome, morada, localidade, codigopostal, telefone, telemovel, tele_serv, nacionalidade, cc, validade_cc, data_nascimento, email, entidade_patronal, categ_profissional, tipo_de_pedido, area_trabalho, validade_acesso, funcao, horario, areas, cartao_pontual_visitante, autorizacao_portas, inquerito, formacao, fotocopia_bi, fotocopia_vinculo_laboral, fotografia, registo_criminal, fotocopia_cartao_acompanhante, estado, entidade_identidade, data_reg, pessoa_requerente, numero, nome_acompanhante, doc_path_renovacao_cartao, fotocopia_cartao_identificacao, id);
        }
        public int insert_segunda_via_cartao(string nome, string morada, string localidade, string codigopostal,
       string telefone, string telemovel, string tele_serv,
      string nacionalidade, string cc, string validade_cc, string data_nascimento, string email,
      string entidade_patronal, string categ_profissional, string tipo_de_pedido, string area_trabalho, string validade_acesso,
         string funcao, string horario, string areas, string cartao_pontual_visitante, string autorizacao_portas, string inquerito,
         string formacao, string fotocopia_bi, string fotocopia_vinculo_laboral, string fotografia,  string registo_criminal, string fotocopia_cartao_acompanhante,
         string estado, int entidade_identidade, string data_reg, string pessoa_requerente, string numero, string nome_acompanhante, string doc_path_segunda_via_cartao, int id)
        {
            DAL_cartao cartao = new DAL_cartao();
           return cartao.insert_segunda_via_cartao(nome, morada, localidade, codigopostal, telefone, telemovel, tele_serv, nacionalidade, cc, validade_cc, data_nascimento, email, entidade_patronal, categ_profissional, tipo_de_pedido, area_trabalho, validade_acesso, funcao, horario, areas, cartao_pontual_visitante, autorizacao_portas, inquerito, formacao, fotocopia_bi, fotocopia_vinculo_laboral, fotografia, registo_criminal, fotocopia_cartao_acompanhante, estado, entidade_identidade, data_reg, pessoa_requerente, numero, nome_acompanhante, doc_path_segunda_via_cartao, id);
        }
        public string numero_renovacao_cartao(int idpedido)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.numero_renovacao_cartao(idpedido);
        }

        public string numero_segunda_via_cartao(int idpedido)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.numero_segunda_via_cartao(idpedido);
        }
        public List<PROP_cartao> select_segunda_via_cartao_by_idcartao(int idpedido)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.select_segunda_via_cartao_byid(idpedido);
        }

        public List<PROP_cartao> select_renovacao_cartao_by_idcartao(int idpedido)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.select_renovacao_cartao_byid(idpedido);
        }
        public string estado_renovacao_cartao(int id_renovacao)
        {
            DAL_cartao cartao = new DAL_cartao();
    return        cartao.estado_renovacao_cartao(id_renovacao);
        }
        public string estado_segunda_via_cartao(int id_segunda_via)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.estado_via_cartao(id_segunda_via);
        }
        public int update_parecer_psp(int idin, string parecer_psp, string parecer_psp_data, string msg_psp, string req_psp)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.update_parecer_psp(idin, parecer_psp, parecer_psp_data, msg_psp, req_psp);
        }

        public int update_parecer_sef(int idin, string parecer_sef, string parecer_sef_data, string msg_sef, string req_sef)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.update_parecer_sef(idin, parecer_sef, parecer_sef_data, msg_sef, req_sef);
        }
        public int update_admin_cartao_renovacao(int idin, string estado, string conferido, string cor, string parecer_psp, string parecer_psp_data, string perecer_sef, string parecer_sef_data
          , string parecer_outros, string parecer_outros_data, string num_cartao, string tipo_de_pedido, string areas, string validade_acesso, string pagamento, int idrenovacao,string autorizacao_portas)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.update_admin_cartao_renovacao(idin, estado, conferido, cor, parecer_psp, parecer_psp_data, perecer_sef, parecer_sef_data, parecer_outros, parecer_outros_data, num_cartao, tipo_de_pedido, areas, validade_acesso, pagamento, idrenovacao, autorizacao_portas);
        }
        public int update_admin_cartao_segunda_via(int idin, string estado, string conferido, string cor, string parecer_psp, string parecer_psp_data, string perecer_sef, string parecer_sef_data
        , string parecer_outros, string parecer_outros_data, string num_cartao, string tipo_de_pedido, string areas, string validade_acesso, string pagamento, int idrenovacao)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.update_admin_cartao_segunda_via(idin, estado, conferido, cor, parecer_psp, parecer_psp_data, perecer_sef, parecer_sef_data, parecer_outros, parecer_outros_data, num_cartao, tipo_de_pedido, areas, validade_acesso, pagamento, idrenovacao);
        }
        public string doc_path_renovacao_cartao(int idrenovacao)
        {
            DAL_cartao cartao = new DAL_cartao();
           return cartao.doc_path_renovacao_cartao(idrenovacao);
        }
        public string doc_path_segunda_via_cartao(int idrenovacao)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.doc_path_segunda_via_cartao(idrenovacao);
        }
        public List<PROP_cartao> select_cartao_by_identidade_pendente(string identidade)
        {
            DAL_cartao cartao = new DAL_cartao();
            if (identidade == null)
            {
                return cartao.select_cartao_by_pendente_admin();
            }
            else
            {
                return cartao.select_cartao_by_identidade_pendente(Convert.ToInt32(identidade));
            }
        }


        public List<PROP_cartao> valida_n_cartao(string num_cartao_new, int cartao_escolhido)
        {

            DAL_cartao cartao = new DAL_cartao();
            return cartao.valida_n_cartao(num_cartao_new, cartao_escolhido);
        }


        public int update_estado_inativo_cartao(int idin)
        {
            DAL_cartao cartao = new DAL_cartao();
            return cartao.update_estado_inativo_cartao(idin);
        }
        //public List<PROP_cartao> select_cartao_by_identidade_pendente(int identidade)
        //{
        //    DAL_cartao cartao = new DAL_cartao();
        //    return cartao.select_cartao_by_identidade_pendente(identidade);
        //}
        //public List<PROP_cartao> select_cartao_by_pendente_admin()
        //{
        //    DAL_cartao cartao = new DAL_cartao();
        //    return cartao.select_cartao_by_pendente_admin();
        //}
    }
}