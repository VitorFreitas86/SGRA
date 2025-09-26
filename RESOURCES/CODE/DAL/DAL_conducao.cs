using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication10.PROP;

namespace WebApplication10.DAL
{
    public class DAL_conducao
    {

        public string numero_conducao()
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            return sqlHelper.executeScaler(lstParameter, "numero_conducao");
        }
        public string email_based_idpedido(int idconducao)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("@id_pedido", idconducao));
            return sqlHelper.executeScaler(lstParameter, "select_email_based_idconducao");
        }

        public string numero_segunda_via_conducao(int idpedido)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("idpedido", idpedido));
            return sqlHelper.executeScaler(lstParameter, "numero_segunda_via_conducao");
        }

        public string numero_renovacao_conducao(int idpedido)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("idpedido", idpedido));
            return sqlHelper.executeScaler(lstParameter, "numero_renovacao_conducao");
        }

        public List<PROP_conducao> get_conducao_by_entidade(int id)
        {
            List<PROP_conducao> conducaolist = new List<PROP_conducao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("identidade", id));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_conducao_by_identidade");

            PROP_conducao conducao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                conducao = new PROP_conducao(Convert.ToInt32(drow["idconducao"]), drow["numero"].ToString(), drow["datareg"].ToString(), drow["nome"].ToString(), drow["pessoa_requerente"].ToString(), drow["estado"].ToString(), drow["soa"].ToString(), drow["soa_nome"].ToString(), drow["path_doc_final"].ToString());
                conducaolist.Add(conducao);
            }

            return conducaolist;
        }

             public List<PROP_conducao> filtro_conducao_by_nome(string nome)
        {
            List<PROP_conducao> conducaolist = new List<PROP_conducao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("nome_pesq", nome));
            //parameters.Add(new MySqlParameter("id_ent", id_ent));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "pesq_conducao_nome");

            PROP_conducao conducao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                conducao = new PROP_conducao(Convert.ToInt32(drow["idconducao"]), drow["numero"].ToString(), drow["datareg"].ToString(), drow["nome"].ToString(), drow["entidade_identidade"].ToString(), drow["estado"].ToString(), drow["fotocopia_cartao_acl"].ToString(), drow["fotocopia_carta_conducao"].ToString(), drow["soa"].ToString(), drow["soa_nome"].ToString(), drow["path_doc_final"].ToString(), drow["validade"].ToString());
                conducaolist.Add(conducao);
            }

            return conducaolist;
        }

        public List<PROP_conducao> filtro_conducao_by_nome_identidade(string nome, int id_ent)
        {
            List<PROP_conducao> conducaolist = new List<PROP_conducao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("nome_pesq", nome));
            parameters.Add(new MySqlParameter("id_ent", id_ent));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "pesq_conducao_by_nome_and_entidade");

            PROP_conducao conducao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                conducao = new PROP_conducao(Convert.ToInt32(drow["idconducao"]), drow["numero"].ToString(), drow["datareg"].ToString(), drow["nome"].ToString(), drow["entidade_identidade"].ToString(), drow["estado"].ToString(), drow["fotocopia_cartao_acl"].ToString(), drow["fotocopia_carta_conducao"].ToString(), drow["soa"].ToString(), drow["soa_nome"].ToString(), drow["path_doc_final"].ToString(), drow["validade"].ToString());
                conducaolist.Add(conducao);
            }

            return conducaolist;
        }


        public List<PROP_conducao> get_conducao_segunda_via(int idpedido)
        {
            List<PROP_conducao> conducaolist = new List<PROP_conducao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("idpedido", idpedido));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_segunda_via_by_id");

            PROP_conducao conducao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                conducao = new PROP_conducao(Convert.ToInt32(drow["idsegunda_via_conducao"]), drow["data_reg"].ToString(), drow["pessoa_requerente"].ToString(), drow["path_doc_segunda_via_conducao"].ToString(), drow["estado"].ToString());
                conducaolist.Add(conducao);
            }

            return conducaolist;
        }

        public List<PROP_conducao> get_all_conducao()
        {
            List<PROP_conducao> conducaolist = new List<PROP_conducao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
      
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_all_conducao");

            PROP_conducao conducao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                conducao = new PROP_conducao(Convert.ToInt32(drow["idconducao"]), drow["numero"].ToString(), drow["datareg"].ToString(), drow["nome"].ToString(), drow["entidade_identidade"].ToString(), drow["estado"].ToString(), drow["fotocopia_cartao_acl"].ToString(), drow["fotocopia_carta_conducao"].ToString(), drow["soa"].ToString(), drow["soa_nome"].ToString(), drow["path_doc_final"].ToString(), drow["validade"].ToString());
                conducaolist.Add(conducao);
            }

            return conducaolist;
        }
        
        
        public List<PROP_conducao> get_conducao_renovacao(int idpedido)
        {
            List<PROP_conducao> conducaolist = new List<PROP_conducao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("idpedido", idpedido));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_renovacao_by_id");

            PROP_conducao conducao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                conducao = new PROP_conducao(Convert.ToInt32(drow["idconducao_renovacao"]), drow["data_reg"].ToString(), drow["pessoa_requerente"].ToString(), drow["path_doc_renovacao_conducao"].ToString(), drow["estado"].ToString());
                conducaolist.Add(conducao);
            }

            return conducaolist;
        }

        public List<PROP_conducao> get_conducao_by_identidade_pendente(int id)
        {
            List<PROP_conducao> conducaolist = new List<PROP_conducao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("identidade", id));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_conducao_by_identidade_pendente");

            PROP_conducao conducao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                conducao = new PROP_conducao( drow["Pedido"].ToString(), drow["numero"].ToString(), drow["datareg"].ToString(), drow["nome"].ToString(), drow["pessoa_requerente"].ToString(), drow["estado"].ToString());
                conducaolist.Add(conducao);
            }

            return conducaolist;
        }

        public List<PROP_conducao> get_conducao_pendente_admin()
        {
            List<PROP_conducao> conducaolist = new List<PROP_conducao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_conducao_by_pendente_admin");

            PROP_conducao conducao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                conducao = new PROP_conducao(drow["Pedido"].ToString(), drow["numero"].ToString(), drow["datareg"].ToString(), drow["nome"].ToString(), drow["pessoa_requerente"].ToString(), drow["estado"].ToString(), Convert.ToInt32(drow["entidade_identidade"].ToString()));
                conducaolist.Add(conducao);
            }

            return conducaolist;
        }
        public List<PROP_conducao> get_conducao_by_numero_and_entidade(int idconducao)
        {
            List<PROP_conducao> conducaolist = new List<PROP_conducao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_conducao", idconducao));
            //parameters.Add(new MySqlParameter("num", num));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_conducao_by_numero_and_identidade");

            PROP_conducao conducao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                //conducao = new PROP_conducao(Convert.ToInt32(drow["idconducao"]), drow["numero"].ToString(), drow["datareg"].ToString(), drow["nome"].ToString(), drow["pessoa_requerente"].ToString(), drow["estado"].ToString(), drow["soa"].ToString(), drow["soa_nome"].ToString(), drow["path_doc_final"].ToString());
                conducao = new PROP_conducao(Convert.ToInt32(drow["idconducao"]), drow["nome"].ToString(), drow["entidade_patronal"].ToString(), drow["funcao"].ToString(), drow["n_cartao_acesso"].ToString(), drow["n_carta_conducao"].ToString(), drow["categorias"].ToString(), drow["data_emissao"].ToString(), drow["local_emissao"].ToString(), drow["validade"].ToString(), drow["areas_circulacao"].ToString(), drow["categoria_viaturas"].ToString(), drow["soa"].ToString(), drow["entidade_identidade"].ToString(), drow["estado"].ToString(), drow["pessoa_requerente"].ToString(), drow["numero"].ToString(), drow["datareg"].ToString(), drow["soa_nome"].ToString(), drow["path_doc_final"].ToString(), drow["fotocopia_carta_conducao"].ToString(), drow["fotocopia_cartao_acl"].ToString());
                conducaolist.Add(conducao);
            }

            return conducaolist;
        }

        public void Update_estado_via_conducao(int idpedido, string estado)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("id", idpedido));
            lstParameter.Add(new MySqlParameter("estado", estado));
            sqlHelper.executenonquery(lstParameter, "update_estado_via_conducao");
        }

        public void Update_estado_renovacao_conducao(int idpedido, string estado)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("id", idpedido));
            lstParameter.Add(new MySqlParameter("estado", estado));
            sqlHelper.executenonquery(lstParameter, "update_estado_renovacao_conducao");
        }
        public void Update_estado_pedido_conducao(int idpedido, string estado,string soa,string soa_nome)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("id", idpedido));
            lstParameter.Add(new MySqlParameter("estado", estado));
            lstParameter.Add(new MySqlParameter("soa", soa));
            lstParameter.Add(new MySqlParameter("soa_nome", soa_nome));
            sqlHelper.executenonquery(lstParameter, "update_estado_pedido_conducao");
        }

        public int Create_conducao(string nome, string entidade_patronal, string funcao, string n_cartao_acl,
            string n_carta_conducao, string categorias, string data_emissao, string local_emissao,
            string validade, string areas_circulacao, string categorias_viaturas, string soa, string fotocopia_cartao_acl,
            string fotocopia_carta_conducao, int entidade_identidade, string estado, string pessoa_requerente, string numero,
            string datareg, string path_doc_final, string user_req)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("nome", nome));
            parameters.Add(new MySqlParameter("entidade_patronal", entidade_patronal));
            parameters.Add(new MySqlParameter("funcao", funcao));
            parameters.Add(new MySqlParameter("n_cartao_acl", n_cartao_acl));
            parameters.Add(new MySqlParameter("n_carta_conducao", n_carta_conducao));
            parameters.Add(new MySqlParameter("categorias", categorias));
            parameters.Add(new MySqlParameter("data_emissao", data_emissao));
            parameters.Add(new MySqlParameter("local_emissao", local_emissao));
            parameters.Add(new MySqlParameter("validade", validade));
            parameters.Add(new MySqlParameter("areas_circulacao", areas_circulacao));
            parameters.Add(new MySqlParameter("categorias_viaturas", categorias_viaturas));
            parameters.Add(new MySqlParameter("soa", soa));
            parameters.Add(new MySqlParameter("fotocopia_cartao_acl", fotocopia_cartao_acl));
            parameters.Add(new MySqlParameter("fotocopia_carta_conducao", fotocopia_carta_conducao));
            parameters.Add(new MySqlParameter("entidade_identidade", entidade_identidade));
            parameters.Add(new MySqlParameter("estado", estado));
            parameters.Add(new MySqlParameter("pessoa_requerente", pessoa_requerente));
            parameters.Add(new MySqlParameter("numero", numero));
            parameters.Add(new MySqlParameter("datareg", datareg));
            parameters.Add(new MySqlParameter("path_doc_final", path_doc_final));
            parameters.Add(new MySqlParameter("user_req", user_req));
            return sqlHelper.executeSP<int>(parameters, "insert_conducao");
        }

        public int inserir_segunda_via_conducao(string nome, string funcao, 
            string n_cartao_acl, string n_carta_conducao, string categorias,
            string data_emissao, string local_emissao,
               string validade, string areas_circulacao, string categorias_viaturas, string fotocopia_cartao_acl,
            string fotocopia_carta_conducao, string estado, string pessoa_requerente,
            string data_reg_2, string path_doc_conducao_2, int id_pedido_conducao)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("data_reg_2", data_reg_2));
            parameters.Add(new MySqlParameter("id_pedido_conducao", id_pedido_conducao));
            parameters.Add(new MySqlParameter("path_doc_conducao_2", path_doc_conducao_2));
            parameters.Add(new MySqlParameter("estado", estado));
            parameters.Add(new MySqlParameter("pessoa_requerente_2", pessoa_requerente));

            parameters.Add(new MySqlParameter("nome", nome));
            parameters.Add(new MySqlParameter("funcao", funcao));
            parameters.Add(new MySqlParameter("n_cartao_acl", n_cartao_acl));
            parameters.Add(new MySqlParameter("n_carta_conducao", n_carta_conducao));
            parameters.Add(new MySqlParameter("categorias", categorias));
            parameters.Add(new MySqlParameter("data_emissao", data_emissao));
            parameters.Add(new MySqlParameter("local_emissao", local_emissao));
            parameters.Add(new MySqlParameter("validade", validade));
            parameters.Add(new MySqlParameter("areas_circulacao", areas_circulacao));
            parameters.Add(new MySqlParameter("categorias_viaturas", categorias_viaturas));
            parameters.Add(new MySqlParameter("fotocopia_cartao_acl", fotocopia_cartao_acl));
            parameters.Add(new MySqlParameter("fotocopia_carta_conducao", fotocopia_carta_conducao));
            return sqlHelper.executeSP<int>(parameters, "insert_segunda_via_conducao");
        }

        public int inserir_renovacao_conducao(string nome, string funcao,
               string n_cartao_acl, string n_carta_conducao, string categorias,
               string data_emissao, string local_emissao,
                  string validade, string areas_circulacao, string categorias_viaturas, string fotocopia_cartao_acl,
               string fotocopia_carta_conducao, string estado, string pessoa_requerente,
               string data_reg_2, string path_doc_conducao_2, int id_pedido_conducao)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("data_reg_2", data_reg_2));
            parameters.Add(new MySqlParameter("id_pedido_conducao", id_pedido_conducao));
            parameters.Add(new MySqlParameter("path_doc_conducao_2", path_doc_conducao_2));
            parameters.Add(new MySqlParameter("estado", estado));
            parameters.Add(new MySqlParameter("pessoa_requerente_2", pessoa_requerente));

            parameters.Add(new MySqlParameter("nome", nome));
            parameters.Add(new MySqlParameter("funcao", funcao));
            parameters.Add(new MySqlParameter("n_cartao_acl", n_cartao_acl));
            parameters.Add(new MySqlParameter("n_carta_conducao", n_carta_conducao));
            parameters.Add(new MySqlParameter("categorias", categorias));
            parameters.Add(new MySqlParameter("data_emissao", data_emissao));
            parameters.Add(new MySqlParameter("local_emissao", local_emissao));
            parameters.Add(new MySqlParameter("validade", validade));
            parameters.Add(new MySqlParameter("areas_circulacao", areas_circulacao));
            parameters.Add(new MySqlParameter("categorias_viaturas", categorias_viaturas));
            parameters.Add(new MySqlParameter("fotocopia_cartao_acl", fotocopia_cartao_acl));
            parameters.Add(new MySqlParameter("fotocopia_carta_conducao", fotocopia_carta_conducao));
            return sqlHelper.executeSP<int>(parameters, "insert_renovacao_conducao");
        }

        public int update_estado_inativo_conducao(int idin)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("idin", idin));
            return sqlHelper.executeSP<int>(parameters, "update_estado_inativo_conducao");
        }
    
    }
}