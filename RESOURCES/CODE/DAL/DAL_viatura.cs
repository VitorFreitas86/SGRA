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
    public class DAL_viatura
    {
        public string numero_viatura()
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            return sqlHelper.executeScaler(lstParameter, "numero_viatura");
        }
        public int Create_viatura(string marca, string modelo, string cor, string matricula,
           string apolice, string companhia_seguro, string validade_seguro,
          string ipo, string ipo_validade, string tipo_de_pedido, string servico, string fotocopia_livrete,
          string fotocopia_registop, string fotocopia_cartaverde, string fotocopia_ipo, string fotocopia_declaracao_segurador,
            int entidade_identidade, string estado, string pessoa_requerente, string numero,string proprietario,string validade_acesso,
          string datareg, string path_doc_final_viaturas, string n_identificacao, string distico, string user_req)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("marca", marca));
            parameters.Add(new MySqlParameter("modelo", modelo));
            parameters.Add(new MySqlParameter("cor", cor));
            parameters.Add(new MySqlParameter("matricula", matricula));
            parameters.Add(new MySqlParameter("path_doc_final_viaturas", path_doc_final_viaturas));
            parameters.Add(new MySqlParameter("apolice", apolice));
            parameters.Add(new MySqlParameter("companhia_seguro", companhia_seguro));
            parameters.Add(new MySqlParameter("validade_seguro", validade_seguro));
            parameters.Add(new MySqlParameter("ipo", ipo));
            parameters.Add(new MySqlParameter("ipo_validade", ipo_validade));
            parameters.Add(new MySqlParameter("tipo_de_pedidos", tipo_de_pedido));
            parameters.Add(new MySqlParameter("servico", servico));
            parameters.Add(new MySqlParameter("fotocopia_livrete", fotocopia_livrete));
            parameters.Add(new MySqlParameter("fotocopia_registop", fotocopia_registop));
            parameters.Add(new MySqlParameter("fotocopia_cartaverde", fotocopia_cartaverde));
            parameters.Add(new MySqlParameter("fotocopia_declaracao_segurador", fotocopia_declaracao_segurador));
            parameters.Add(new MySqlParameter("fotocopia_ipo", fotocopia_ipo));
            parameters.Add(new MySqlParameter("proprietario", proprietario));
            parameters.Add(new MySqlParameter("validade_acesso", validade_acesso));
            parameters.Add(new MySqlParameter("entidade_identidade", entidade_identidade));
            parameters.Add(new MySqlParameter("estado", estado));
            parameters.Add(new MySqlParameter("pessoa_requerente", pessoa_requerente));
            parameters.Add(new MySqlParameter("numero", numero));
            parameters.Add(new MySqlParameter("data_reg", datareg));
            parameters.Add(new MySqlParameter("n_identificacao", n_identificacao));
            parameters.Add(new MySqlParameter("distico", distico));
            parameters.Add(new MySqlParameter("user_req", user_req));
            return sqlHelper.executeSP<int>(parameters, "insert_viatura");
        }
        public int update_admin_viatura(string n_identificacao, string outros_servicos, string estado, string portao_acesso,
            string distico, string conferido, string validade_acesso, string tipo_de_acesso, int idin)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("n_identificacao", n_identificacao));
            parameters.Add(new MySqlParameter("outros_servicos", outros_servicos));
            parameters.Add(new MySqlParameter("estado", estado));
            parameters.Add(new MySqlParameter("portao_acesso", portao_acesso));
            parameters.Add(new MySqlParameter("distico", distico));
            parameters.Add(new MySqlParameter("conferido", conferido));
            parameters.Add(new MySqlParameter("validade_acesso", validade_acesso));
            parameters.Add(new MySqlParameter("tipo_de_pedido", tipo_de_acesso));
            parameters.Add(new MySqlParameter("idin", idin));
            return sqlHelper.executeSP<int>(parameters, "update_admin_viatura");
        }

        public string email_based_idpedido(int id)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("@id_pedido", id));
            return sqlHelper.executeScaler(lstParameter, "select_email_based_idviatura");
        }

        public List<PROP_viatura> get_viatura_by_entidade(int id)
        {
            List<PROP_viatura> viatura_list = new List<PROP_viatura>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("identidade", id));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_viatura_by_identidade");

            PROP_viatura viatura;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                viatura = new PROP_viatura(Convert.ToInt32(drow["idviatura"]), drow["numero"].ToString(), drow["tipo_de_pedido"].ToString(), drow["pessoa_requerente"].ToString(), drow["n_identificacao"].ToString(), drow["data_reg"].ToString(), drow["matricula"].ToString(), drow["marca"].ToString(), drow["modelo"].ToString(), drow["estado"].ToString());
                viatura_list.Add(viatura);
            }

            return viatura_list;
        }

        public List<PROP_viatura> get_viatura_all()
        {
            List<PROP_viatura> viatura_list = new List<PROP_viatura>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_viatura");

            PROP_viatura viatura;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                viatura = new PROP_viatura(Convert.ToInt32(drow["idviatura"]), drow["numero"].ToString(), drow["n_identificacao"].ToString(), drow["data_reg"].ToString(), drow["matricula"].ToString(), drow["marca"].ToString(), drow["modelo"].ToString(), drow["estado"].ToString(),
                 Convert.ToInt32(drow["entidade_identidade"]), drow["tipo_de_pedido"].ToString(), drow["fotocopia_livrete"].ToString(), drow["fotocopia_registop"].ToString(), drow["fotocopia_cartaverde"].ToString(), drow["fotocopia_declaracao_segurador"].ToString(), drow["fotocopia_ipo"].ToString(), drow["path_doc_final_viaturas"].ToString(), drow["validade_acesso"].ToString());
                viatura_list.Add(viatura);
            }

            return viatura_list;
        }
        public string get_viatura_entidade_by_id(int identidade)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("idin", identidade));
            return sqlHelper.executeScaler(lstParameter, "numero_viaturas_entidade_by_id");
        }
        public List<PROP_viatura> get_viatura_by_idviatura(int id)
        {
            List<PROP_viatura> viatura_list = new List<PROP_viatura>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("idin", id));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_admin_viatura");

            PROP_viatura viatura;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                viatura = new PROP_viatura(Convert.ToInt32(drow["idviatura"]), drow["n_identificacao"].ToString(), drow["outros_servicos"].ToString(), drow["estado"].ToString(), drow["portao_acesso"].ToString(), drow["distico"].ToString(), drow["conferido"].ToString(), drow["validade_acesso"].ToString(), drow["tipo_de_pedido"].ToString());
                viatura_list.Add(viatura);
            }

            return viatura_list;
        }
        public List<PROP_viatura> get_viatura_renovacao_by_ID(int idviatura)
        {
            List<PROP_viatura> viaturalist = new List<PROP_viatura>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_viatura", idviatura));
            //parameters.Add(new MySqlParameter("num", num));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_viatura_byID");

            PROP_viatura viatura;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                //conducao = new PROP_conducao(Convert.ToInt32(drow["idconducao"]), drow["numero"].ToString(), drow["datareg"].ToString(), drow["nome"].ToString(), drow["pessoa_requerente"].ToString(), drow["estado"].ToString(), drow["soa"].ToString(), drow["soa_nome"].ToString(), drow["path_doc_final"].ToString());
                viatura = new PROP_viatura(Convert.ToInt32(drow["idviatura"]), drow["marca"].ToString(), drow["modelo"].ToString(), drow["cor"].ToString(), drow["matricula"].ToString(), drow["n_identificacao"].ToString(), drow["apolice"].ToString(), drow["companhia_seguro"].ToString(), drow["validade_seguro"].ToString(), drow["ipo"].ToString(), drow["ipo_validade"].ToString(), drow["tipo_de_pedido"].ToString(), drow["servico"].ToString(), drow["fotocopia_livrete"].ToString(), drow["fotocopia_registop"].ToString(), drow["fotocopia_cartaverde"].ToString(), drow["fotocopia_declaracao_segurador"].ToString(), drow["fotocopia_ipo"].ToString(), Convert.ToInt32(drow["entidade_identidade"]), drow["estado"].ToString(), drow["proprietario"].ToString(), drow["distico"].ToString(), drow["portao_acesso"].ToString(), drow["outros_servicos"].ToString(), drow["data_reg"].ToString(), drow["numero"].ToString(), drow["conferido"].ToString(), drow["pessoa_requerente"].ToString(), drow["validade_acesso"].ToString(), drow["path_doc_final_viaturas"].ToString());
                viaturalist.Add(viatura);
            }

            return viaturalist;
        }

        public int insert_segunda_via_viatura(int idin, string apolice, string companhia_seguro, string validade_seguro,
            string ipo, string ipo_validade, string servico, string tipo_de_pedido, string validade_acesso, string fotocopia_livrete,
            string fotocopia_registop, string fotocopia_cartaverde, string fotocopia_declaracao_segurador, string fotocopia_ipo, 
            string data_reg, string pessoa_requerente, string path_doc_segunda_via_viatura)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("idin", idin));
            parameters.Add(new MySqlParameter("apolice", apolice));
            parameters.Add(new MySqlParameter("companhia_seguro", companhia_seguro));
            parameters.Add(new MySqlParameter("validade_seguro", validade_seguro));
            parameters.Add(new MySqlParameter("ipo", ipo));
            parameters.Add(new MySqlParameter("ipo_validade", ipo_validade));
            parameters.Add(new MySqlParameter("servico", servico));
            parameters.Add(new MySqlParameter("tipo_de_pedido", tipo_de_pedido));
            parameters.Add(new MySqlParameter("validade_acesso", validade_acesso));
            parameters.Add(new MySqlParameter("fotocopia_livrete", fotocopia_livrete));
            parameters.Add(new MySqlParameter("fotocopia_registop", fotocopia_registop));
            parameters.Add(new MySqlParameter("fotocopia_cartaverde", fotocopia_cartaverde));
            parameters.Add(new MySqlParameter("fotocopia_declaracao_segurador", fotocopia_declaracao_segurador));
            parameters.Add(new MySqlParameter("fotocopia_ipo", fotocopia_ipo));
            parameters.Add(new MySqlParameter("data_reg", data_reg));
            parameters.Add(new MySqlParameter("pessoa_requerente", pessoa_requerente));
            parameters.Add(new MySqlParameter("path_doc_segunda_via_viatura", path_doc_segunda_via_viatura));
            parameters.Add(new MySqlParameter("estado", "Pendente"));
            return sqlHelper.executeSP<int>(parameters, "insert_segunda_via_viatura");
        }
        public int insert_renovacao_viatura(int idin, string apolice, string companhia_seguro, string validade_seguro,
            string ipo, string ipo_validade, string servico, string tipo_de_pedido, string validade_acesso, string fotocopia_livrete,
            string fotocopia_registop, string fotocopia_cartaverde, string fotocopia_declaracao_segurador, string fotocopia_ipo,
            string data_reg, string pessoa_requerente, string path_doc_renovacao_viatura, string path_fotocopia_cartao_circulacao)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("idin", idin));
            parameters.Add(new MySqlParameter("apolice", apolice));
            parameters.Add(new MySqlParameter("companhia_seguro", companhia_seguro));
            parameters.Add(new MySqlParameter("validade_seguro", validade_seguro));
            parameters.Add(new MySqlParameter("ipo", ipo));
            parameters.Add(new MySqlParameter("ipo_validade", ipo_validade));
            parameters.Add(new MySqlParameter("servico", servico));
            parameters.Add(new MySqlParameter("tipo_de_pedido", tipo_de_pedido));
            parameters.Add(new MySqlParameter("validade_acesso", validade_acesso));
            parameters.Add(new MySqlParameter("fotocopia_livrete", fotocopia_livrete));
            parameters.Add(new MySqlParameter("fotocopia_registop", fotocopia_registop));
            parameters.Add(new MySqlParameter("fotocopia_cartaverde", fotocopia_cartaverde));
            parameters.Add(new MySqlParameter("fotocopia_declaracao_segurador", fotocopia_declaracao_segurador));
            parameters.Add(new MySqlParameter("fotocopia_ipo", fotocopia_ipo));
            parameters.Add(new MySqlParameter("data_reg", data_reg));
            parameters.Add(new MySqlParameter("pessoa_requerente", pessoa_requerente));
            parameters.Add(new MySqlParameter("path_doc_renovacao_viatura", path_doc_renovacao_viatura));
            parameters.Add(new MySqlParameter("path_fotocopia_cartao_circulacao", path_fotocopia_cartao_circulacao));
            parameters.Add(new MySqlParameter("estado", "Pendente"));
            return sqlHelper.executeSP<int>(parameters, "insert_renovacao_viatura");
        }

               public string numero_segunda_via_viatura(int idpedido)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("idpedido", idpedido));
            return sqlHelper.executeScaler(lstParameter, "numero_segunda_via_viatura");
        }
            
            public string numero_renovacao_viatura(int idpedido)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("idpedido", idpedido));
            return sqlHelper.executeScaler(lstParameter, "numero_renovacao_viatura");
        }
            public List<PROP_viatura> get_viatura_segunda_via(int idpedido)
            {
                List<PROP_viatura> viaturalist = new List<PROP_viatura>();
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                parameters.Add(new MySqlParameter("idpedido", idpedido));
                var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_viatura_via_by_ID");

                PROP_viatura viatura;
                foreach (DataRow drow in resultSet.Tables[0].Rows)
                {
                    viatura = new PROP_viatura(Convert.ToInt32(drow["idviatura_via"]), drow["data_reg"].ToString(), drow["pessoa_requerente"].ToString(), drow["path_doc_segunda_via_viatura"].ToString(), drow["estado"].ToString());
                    viaturalist.Add(viatura);
                }

                return viaturalist;
            }
            public List<PROP_viatura> get_viatura_renovacao(int idpedido)
            {
                List<PROP_viatura> viaturalist = new List<PROP_viatura>();
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                parameters.Add(new MySqlParameter("idpedido", idpedido));
                var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_viatura_renovacao_by_ID");

                PROP_viatura viatura;
                foreach (DataRow drow in resultSet.Tables[0].Rows)
                {
                    viatura = new PROP_viatura(Convert.ToInt32(drow["idviatura_renovacao"]), drow["data_reg"].ToString(), drow["pessoa_requerente"].ToString(), drow["path_doc_renovacao_viatura"].ToString(), drow["path_fotocopia_cartao_circulacao"].ToString(), drow["estado"].ToString());
                    viaturalist.Add(viatura);
                }

                return viaturalist;
            }
            public string estado_via_viatura(int idvia)
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("idvia", idvia));
                return sqlHelper.executeScaler(lstParameter, "select_estado_via_viatura");
            }
         public string estado_renovacao_viatura(int idrenovacao)
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("idrenovacao", idrenovacao));
                return sqlHelper.executeScaler(lstParameter, "select_estado_renovacao_viatura");
            }
       
        public int update_admin_via_viatura(string n_identificacao, string outros_servicos, string estado, string portao_acesso,
             string distico, string conferido, string validade_acesso, string tipo_de_acesso, int idin, int idrenovacao)
         {
             SQLHelper sqlHelper = new SQLHelper();
             List<MySqlParameter> parameters = new List<MySqlParameter>();
             parameters.Add(new MySqlParameter("n_identificacao", n_identificacao));
             parameters.Add(new MySqlParameter("outros_servicos", outros_servicos));
             parameters.Add(new MySqlParameter("estado", estado));
             parameters.Add(new MySqlParameter("portao_acesso", portao_acesso));
             parameters.Add(new MySqlParameter("distico", distico));
             parameters.Add(new MySqlParameter("conferido", conferido));
             parameters.Add(new MySqlParameter("validade_acesso", validade_acesso));
             parameters.Add(new MySqlParameter("tipo_de_pedido", tipo_de_acesso));
             parameters.Add(new MySqlParameter("idin", idin));
             parameters.Add(new MySqlParameter("id_renovacao", idrenovacao));
             return sqlHelper.executeSP<int>(parameters, "update_admin_via_viatura");
         }

        public int update_admin_renovacao_viatura(string n_identificacao, string outros_servicos, string estado, string portao_acesso,
           string distico, string conferido, string validade_acesso, string tipo_de_acesso, int idin, int idrenovacao)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("n_identificacao", n_identificacao));
            parameters.Add(new MySqlParameter("outros_servicos", outros_servicos));
            parameters.Add(new MySqlParameter("estado", estado));
            parameters.Add(new MySqlParameter("portao_acesso", portao_acesso));
            parameters.Add(new MySqlParameter("distico", distico));
            parameters.Add(new MySqlParameter("conferido", conferido));
            parameters.Add(new MySqlParameter("validade_acesso", validade_acesso));
            parameters.Add(new MySqlParameter("tipo_de_pedido", tipo_de_acesso));
            parameters.Add(new MySqlParameter("idin", idin));
            parameters.Add(new MySqlParameter("id_renovacao", idrenovacao));
            return sqlHelper.executeSP<int>(parameters, "update_admin_renovacao_viatura");
        }
        public string select_path_doc_renovacao_viatura(int idrenovacao)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
          
            parameters.Add(new MySqlParameter("idrenovacao", idrenovacao));
            return sqlHelper.executeScaler(parameters, "select_path_doc_renovacao_viatura");
        }
        public string select_path_doc_via_viatura(int idvia)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("idvia", idvia));
            return sqlHelper.executeScaler(parameters, "select_path_doc_via_viatura");
        }

        public List<PROP_viatura> select_viatura_by_identidade_pendente(int identidade)
        {
            List<PROP_viatura> viaturalist = new List<PROP_viatura>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("identidade", identidade));
            //parameters.Add(new MySqlParameter("num", num));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_viatura_by_identidade_pendente");

            PROP_viatura viatura;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                //conducao = new PROP_conducao(Convert.ToInt32(drow["idconducao"]), drow["numero"].ToString(), drow["datareg"].ToString(), drow["nome"].ToString(), drow["pessoa_requerente"].ToString(), drow["estado"].ToString(), drow["soa"].ToString(), drow["soa_nome"].ToString(), drow["path_doc_final"].ToString());
                viatura = new PROP_viatura(drow["Pedido"].ToString(), drow["numero"].ToString(), drow["data_reg"].ToString(), drow["matricula"].ToString(), drow["marca"].ToString(), drow["modelo"].ToString(), drow["pessoa_requerente"].ToString(), drow["estado"].ToString());
                viaturalist.Add(viatura);
            }

            return viaturalist;
        }

        public List<PROP_viatura> select_viatura_by_pendente_admin()
        {
            List<PROP_viatura> viaturalist = new List<PROP_viatura>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            //parameters.Add(new MySqlParameter("num", num));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_viatura_by_pendente_admin");

            PROP_viatura viatura;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                //conducao = new PROP_conducao(Convert.ToInt32(drow["idconducao"]), drow["numero"].ToString(), drow["datareg"].ToString(), drow["nome"].ToString(), drow["pessoa_requerente"].ToString(), drow["estado"].ToString(), drow["soa"].ToString(), drow["soa_nome"].ToString(), drow["path_doc_final"].ToString());
                viatura = new PROP_viatura(drow["Pedido"].ToString(), drow["numero"].ToString(), drow["data_reg"].ToString(), drow["matricula"].ToString(), drow["marca"].ToString(), drow["modelo"].ToString(), drow["pessoa_requerente"].ToString(), drow["estado"].ToString(), Convert.ToInt32(drow["entidade_identidade"].ToString()));
                viaturalist.Add(viatura);
            }

            return viaturalist;
        }

        public List<PROP_viatura> valida_n_identificacao(string n_identificacao_new, int cartao_escolhido)
        {
            List<PROP_viatura> viatura_list = new List<PROP_viatura>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("n_identificacao_new", n_identificacao_new));
            parameters.Add(new MySqlParameter("cartao_escolhido", cartao_escolhido));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "valida_n_identificacao_viatura");

            PROP_viatura viatura;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                viatura = new PROP_viatura( drow["n_identificacao"].ToString());
                viatura_list.Add(viatura);
            }

            return viatura_list;
        }

        public int update_estado_inativo_viatura(int idin)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
 
            parameters.Add(new MySqlParameter("idin", idin));
            return sqlHelper.executeSP<int>(parameters, "update_estado_inativo_viatura");
        }

      

        public string valida_distico(string n_distico, int id_viatura)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("n_distico", n_distico));
            lstParameter.Add(new MySqlParameter("id_viaturain", id_viatura));
            return sqlHelper.executeScaler(lstParameter, "valida_n_distico");
        }

        public string valida_matricula(string matricula_in, int idviatura_in)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("matricula_in", matricula_in));
            lstParameter.Add(new MySqlParameter("idviatura_in", idviatura_in));
            return sqlHelper.executeScaler(lstParameter, "valida_matricula");
        }

      
    }
}