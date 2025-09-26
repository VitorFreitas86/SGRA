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
    public class DAL_cartao
    {
        public string numero_cartao()
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            return sqlHelper.executeScaler(lstParameter, "numero_cartao");
        }

        public List<PROP_cartao> filtro_cartao_by_nome_entidade(string nome,int id)
        {
            List<PROP_cartao> cartaolist = new List<PROP_cartao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("nome_pesq", nome));
            parameters.Add(new MySqlParameter("id_ent", id));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "pesq_cartao_by_nome_entidade");

            PROP_cartao cartao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                cartao = new PROP_cartao(Convert.ToInt32(drow["idcartao"]), drow["numero"].ToString(), drow["data_reg"].ToString(), drow["nome"].ToString(), drow["pessoa_requerente"].ToString(), drow["estado"].ToString(), drow["tipo_de_pedido"].ToString());
                cartaolist.Add(cartao);
            }

            return cartaolist;
        }

        public List<PROP_cartao> filtro_cartao_by_nome(string nome)
        {
            List<PROP_cartao> cartaolist = new List<PROP_cartao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("nome_pesq", nome));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "pesq_cartao_by_nome");

            PROP_cartao cartao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                cartao = new PROP_cartao(Convert.ToInt32(drow["idcartao"]), drow["numero"].ToString(), drow["data_reg"].ToString(), drow["nome"].ToString(), drow["tipo_de_pedido"].ToString(), drow["estado"].ToString(), drow["fotocopia_bi"].ToString(), drow["fotocopia_vinculo_laboral"].ToString(), drow["fotografia"].ToString(), drow["registo_criminal"].ToString(), drow["fotocopia_cartao_acompanhante"].ToString(), drow["path_doc_final"].ToString(), Convert.ToInt32(drow["entidade_identidade"]), drow["validade_acesso"].ToString());
                cartaolist.Add(cartao);
            }

            return cartaolist;
        }

        public string email_by_idcartao(int id) {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("id_pedido", id));
            return sqlHelper.executeScaler(lstParameter, "select_email_based_idcartao");
        }

        //public string email_based_idpedido(int id)
        //{
        //    SQLHelper sqlHelper = new SQLHelper();
        //    List<MySqlParameter> lstParameter = new List<MySqlParameter>();
        //    lstParameter.Add(new MySqlParameter("id_pedido", id));

        //    return sqlHelper.executeScaler(lstParameter, "select_email_based_idcartao");
        //}

        public string numero_segunda_via_cartao(int idpedido)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("idpedido", idpedido));
            return sqlHelper.executeScaler(lstParameter, "numero_segunda_via_cartao");
        }

        public string numero_renovacao_cartao(int idpedido)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("idpedido", idpedido));
            return sqlHelper.executeScaler(lstParameter, "numero_renovacao_cartao");
        }

        public List<PROP_cartao> get_cartao_admin_by_id(int id)
        {
            List<PROP_cartao> cartaolist = new List<PROP_cartao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("idin", id));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_cartao_admin_by_id");

            PROP_cartao cartao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                cartao = new PROP_cartao(Convert.ToInt32(drow["idcartao"]), drow["fotocopia_bi"].ToString(), drow["fotocopia_vinculo_laboral"].ToString(), drow["fotografia"].ToString(), drow["path_doc_final"].ToString(), drow["registo_criminal"].ToString(), drow["fotocopia_cartao_acompanhante"].ToString(),
                    drow["estado"].ToString(), drow["conferido"].ToString(), drow["cor"].ToString(), drow["parecer_psp"].ToString(), drow["parecer_psp_data"].ToString(), drow["perecer_sef"].ToString()
                    , drow["parecer_sef_data"].ToString(), drow["parecer_outros"].ToString(), drow["parecer_outros_data"].ToString(), drow["num_cartao"].ToString(), drow["tipo_de_pedido"].ToString(), drow["areas"].ToString(), drow["validade_acesso"].ToString(), drow["pagamento"].ToString(), drow["autorizacao_portas"].ToString(), drow["msg_psp"].ToString(), drow["msg_sef"].ToString());
                cartaolist.Add(cartao);
            }

            return cartaolist;
        }

        public List<PROP_cartao> get_cartao_renovacao_by_ID(int id)
        {
            List<PROP_cartao> cartaolist = new List<PROP_cartao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("idin", id));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "get_cartao_by_ID");

            PROP_cartao cartao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                cartao = new PROP_cartao(Convert.ToInt32(drow["idcartao"]), drow["nome"].ToString(), drow["morada"].ToString(), drow["localidade"].ToString(), drow["codigopostal"].ToString(), drow["telefone"].ToString(), drow["telemovel"].ToString(), drow["tele_serv"].ToString(), drow["nacionalidade"].ToString(), drow["cc"].ToString(), drow["validade_cc"].ToString(), drow["data_nascimento"].ToString(), drow["email"].ToString(), drow["categ_profissional"].ToString(), drow["tipo_de_pedido"].ToString(), drow["area_trabalho"].ToString(),
                    drow["validade_acesso"].ToString(), drow["funcao"].ToString(), drow["horario"].ToString(),
                    drow["areas"].ToString(), drow["cartao_pontual_visitante"].ToString(), drow["autorizacao_portas"].ToString(), 
                    drow["inquerito"].ToString(), drow["formacao"].ToString(), drow["path_doc_final"].ToString(), 
                    drow["numero"].ToString(), drow["num_cartao"].ToString(), Convert.ToInt32(drow["entidade_identidade"].ToString()),
                    drow["entidade_patronal"].ToString(), drow["nome_acompanhante"].ToString(), drow["fotocopia_bi"].ToString()
                    , drow["fotocopia_vinculo_laboral"].ToString(), drow["fotografia"].ToString(), drow["registo_criminal"].ToString()
                    , drow["fotocopia_cartao_acompanhante"].ToString());
                cartaolist.Add(cartao);
            }

            return cartaolist;
        }


        public List<PROP_cartao> get_cartao_by_entidade(int id)
        {
            List<PROP_cartao> cartaolist = new List<PROP_cartao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("identidade", id));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_cartao_by_identidade");

            PROP_cartao cartao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                cartao = new PROP_cartao(Convert.ToInt32(drow["idcartao"]), drow["numero"].ToString(), drow["data_reg"].ToString(), drow["nome"].ToString(), drow["pessoa_requerente"].ToString(), drow["estado"].ToString(), drow["tipo_de_pedido"].ToString());
                cartaolist.Add(cartao);
            }

            return cartaolist;
        }

        public List<PROP_cartao> get_cartao_all_parecer_psp()
        {
            List<PROP_cartao> cartaolist = new List<PROP_cartao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_cartao_parecer_psp");

            PROP_cartao cartao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            //{,"","","",""
               
            {
                cartao = new PROP_cartao(Convert.ToInt32(drow["idcartao"]),drow["data_reg"].ToString(), drow["nome"].ToString(), drow["tipo_de_pedido"].ToString(), drow["fotografia"].ToString(), Convert.ToInt32(drow["entidade_identidade"]));
                cartaolist.Add(cartao);
            }

            return cartaolist;
        }
        public List<PROP_cartao> get_cartao_all_parecer_sef()
        {
            List<PROP_cartao> cartaolist = new List<PROP_cartao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_cartao_parecer_sef");

            PROP_cartao cartao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            //{,"","","",""
            {
                cartao = new PROP_cartao(Convert.ToInt32(drow["idcartao"]), drow["data_reg"].ToString(), drow["nome"].ToString(), drow["tipo_de_pedido"].ToString(), drow["fotografia"].ToString(), Convert.ToInt32(drow["entidade_identidade"]));
                cartaolist.Add(cartao);
            }

            return cartaolist;
        }
        public List<PROP_cartao> get_cartao_all()
        {
            List<PROP_cartao> cartaolist = new List<PROP_cartao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_cartao");

            PROP_cartao cartao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                cartao = new PROP_cartao(Convert.ToInt32(drow["idcartao"]), drow["numero"].ToString(), drow["data_reg"].ToString(), drow["nome"].ToString(), drow["tipo_de_pedido"].ToString(), drow["estado"].ToString(), drow["fotocopia_bi"].ToString(), drow["fotocopia_vinculo_laboral"].ToString(), drow["fotografia"].ToString(), drow["registo_criminal"].ToString(), drow["fotocopia_cartao_acompanhante"].ToString(), drow["path_doc_final"].ToString(), Convert.ToInt32(drow["entidade_identidade"]), drow["validade_acesso"].ToString());
                cartaolist.Add(cartao);
            }

            return cartaolist;
        }
        public int Create_cartao(string nome, string morada, string localidade, string codigopostal,
          string telefone, string telemovel, string tele_serv,
         string nacionalidade, string cc, string validade_cc, string data_nascimento, string email,
         string entidade_patronal, string categ_profissional, string tipo_de_pedido, string area_trabalho,string validade_acesso,
            string funcao, string horario, string areas, string cartao_pontual_visitante,string autorizacao_portas, string inquerito,
            string formacao,string fotocopia_bi,string fotocopia_vinculo_laboral,string fotografia,string path_doc_final,string registo_criminal,string fotocopia_cartao_acompanhante,
            string estado, int entidade_identidade, string data_reg, string pessoa_requerente, string numero, string nome_acompanhante,string user_req)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("nome", nome));
            parameters.Add(new MySqlParameter("morada", morada));
            parameters.Add(new MySqlParameter("localidade", localidade));
            parameters.Add(new MySqlParameter("codigopostal", codigopostal));
            parameters.Add(new MySqlParameter("telefone", telefone));
            parameters.Add(new MySqlParameter("telemovel", telemovel));
            parameters.Add(new MySqlParameter("tele_serv", tele_serv));
            parameters.Add(new MySqlParameter("nacionalidade", nacionalidade));
            parameters.Add(new MySqlParameter("cc", cc));
            parameters.Add(new MySqlParameter("validade_cc", validade_cc));
            parameters.Add(new MySqlParameter("data_nascimento", data_nascimento));
            parameters.Add(new MySqlParameter("email", email));
            parameters.Add(new MySqlParameter("entidade_patronal", entidade_patronal));
            parameters.Add(new MySqlParameter("categ_profissional", categ_profissional));
            parameters.Add(new MySqlParameter("tipo_de_pedido", tipo_de_pedido));
            parameters.Add(new MySqlParameter("area_trabalho", area_trabalho));
            parameters.Add(new MySqlParameter("validade_acesso", validade_acesso));
            parameters.Add(new MySqlParameter("funcao", funcao));
            parameters.Add(new MySqlParameter("horario", horario));
            parameters.Add(new MySqlParameter("areas", areas));
            parameters.Add(new MySqlParameter("cartao_pontual_visitante", cartao_pontual_visitante));
            parameters.Add(new MySqlParameter("autorizacao_portas", autorizacao_portas));
            parameters.Add(new MySqlParameter("inquerito", inquerito));
            parameters.Add(new MySqlParameter("formacao", formacao));
            parameters.Add(new MySqlParameter("fotocopia_bi", fotocopia_bi));
            parameters.Add(new MySqlParameter("fotocopia_vinculo_laboral", fotocopia_vinculo_laboral));
            parameters.Add(new MySqlParameter("fotografia", fotografia));
            parameters.Add(new MySqlParameter("path_doc_final", path_doc_final));
            parameters.Add(new MySqlParameter("registo_criminal", registo_criminal));
            parameters.Add(new MySqlParameter("fotocopia_cartao_acompanhante", fotocopia_cartao_acompanhante));
            parameters.Add(new MySqlParameter("estado", estado));
            parameters.Add(new MySqlParameter("entidade_identidade", entidade_identidade));
            parameters.Add(new MySqlParameter("data_reg", data_reg));
            parameters.Add(new MySqlParameter("pessoa_requerente", pessoa_requerente));
            parameters.Add(new MySqlParameter("numero", numero));
            parameters.Add(new MySqlParameter("nome_acompanhante", nome_acompanhante));
            parameters.Add(new MySqlParameter("user_req", user_req));
            return sqlHelper.executeSP<int>(parameters, "insert_cartao");
        }


        public int update_admin_cartao(int idin, string estado, string conferido, string cor, string parecer_psp, string parecer_psp_data, string perecer_sef, string parecer_sef_data
            , string parecer_outros, string parecer_outros_data, string num_cartao, string tipo_de_pedido, string areas, string validade_acesso, string pagamento, string autorizacao_portas, string req_sef, string req_psp)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("idin", idin));
            parameters.Add(new MySqlParameter("estado", estado));
            parameters.Add(new MySqlParameter("conferido", conferido));
            parameters.Add(new MySqlParameter("cor", cor));
            parameters.Add(new MySqlParameter("parecer_psp", parecer_psp));
            parameters.Add(new MySqlParameter("parecer_psp_data", parecer_psp_data));
            parameters.Add(new MySqlParameter("perecer_sef", perecer_sef));
            parameters.Add(new MySqlParameter("parecer_sef_data", parecer_sef_data));
            parameters.Add(new MySqlParameter("parecer_outros", parecer_outros));
            parameters.Add(new MySqlParameter("parecer_outros_data", parecer_outros_data));
            parameters.Add(new MySqlParameter("num_cartao", num_cartao));
            parameters.Add(new MySqlParameter("tipo_de_pedido", tipo_de_pedido));
            parameters.Add(new MySqlParameter("areas", areas));
            parameters.Add(new MySqlParameter("validade_acesso", validade_acesso));
            parameters.Add(new MySqlParameter("pagamento", pagamento));
            parameters.Add(new MySqlParameter("autorizacao_portas", autorizacao_portas));
            parameters.Add(new MySqlParameter("req_sef", req_sef));
            parameters.Add(new MySqlParameter("req_psp", req_psp));
            return sqlHelper.executeSP<int>(parameters, "update_cartao_admin_by_id");
        }

        public int insert_renovacao_cartao(string nome, string morada, string localidade, string codigopostal,
         string telefone, string telemovel, string tele_serv,
        string nacionalidade, string cc, string validade_cc, string data_nascimento, string email,
        string entidade_patronal, string categ_profissional, string tipo_de_pedido, string area_trabalho, string validade_acesso,
           string funcao, string horario, string areas, string cartao_pontual_visitante, string autorizacao_portas, string inquerito,
           string formacao, string fotocopia_bi, string fotocopia_vinculo_laboral, string fotografia, string registo_criminal, string fotocopia_cartao_acompanhante,
           string estado, int entidade_identidade, string data_reg, string pessoa_requerente, string numero, string nome_acompanhante, string doc_path_renovacao_cartao, string fotocopia_cartao_identificacao,int id)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("nome", nome));
            parameters.Add(new MySqlParameter("morada", morada));
            parameters.Add(new MySqlParameter("localidade", localidade));
            parameters.Add(new MySqlParameter("codigopostal", codigopostal));
            parameters.Add(new MySqlParameter("telefone", telefone));
            parameters.Add(new MySqlParameter("telemovel", telemovel));
            parameters.Add(new MySqlParameter("tele_serv", tele_serv));
            parameters.Add(new MySqlParameter("nacionalidade", nacionalidade));
            parameters.Add(new MySqlParameter("cc", cc));
            parameters.Add(new MySqlParameter("validade_cc", validade_cc));
            parameters.Add(new MySqlParameter("data_nascimento", data_nascimento));
            parameters.Add(new MySqlParameter("email", email));
            parameters.Add(new MySqlParameter("entidade_patronal", entidade_patronal));
            parameters.Add(new MySqlParameter("categ_profissional", categ_profissional));
            parameters.Add(new MySqlParameter("tipo_de_pedido", tipo_de_pedido));
            parameters.Add(new MySqlParameter("area_trabalho", area_trabalho));
            parameters.Add(new MySqlParameter("validade_acesso", validade_acesso));
            parameters.Add(new MySqlParameter("funcao", funcao));
            parameters.Add(new MySqlParameter("horario", horario));
            parameters.Add(new MySqlParameter("areas", areas));
            parameters.Add(new MySqlParameter("cartao_pontual_visitante", cartao_pontual_visitante));
            parameters.Add(new MySqlParameter("autorizacao_portas", autorizacao_portas));
            parameters.Add(new MySqlParameter("inquerito", inquerito));
            parameters.Add(new MySqlParameter("formacao", formacao));
            parameters.Add(new MySqlParameter("fotocopia_bi", fotocopia_bi));
            parameters.Add(new MySqlParameter("fotocopia_vinculo_laboral", fotocopia_vinculo_laboral));
            parameters.Add(new MySqlParameter("fotografia", fotografia));
            //parameters.Add(new MySqlParameter("path_doc_final", path_doc_final));
            parameters.Add(new MySqlParameter("registo_criminal", registo_criminal));
            parameters.Add(new MySqlParameter("fotocopia_cartao_acompanhante", fotocopia_cartao_acompanhante));
            parameters.Add(new MySqlParameter("data_reg", data_reg));
            parameters.Add(new MySqlParameter("pessoa_requerente", pessoa_requerente));
            parameters.Add(new MySqlParameter("doc_path_renovacao_cartao", doc_path_renovacao_cartao));
            parameters.Add(new MySqlParameter("fotocopia_cartao_identificacao", fotocopia_cartao_identificacao));
            parameters.Add(new MySqlParameter("estado", estado));
            parameters.Add(new MySqlParameter("nome_acompanhante", nome_acompanhante));
            parameters.Add(new MySqlParameter("idin", id));
            return sqlHelper.executeSP<int>(parameters, "insert_renovacao_cartao");
        }

        public int insert_segunda_via_cartao(string nome, string morada, string localidade, string codigopostal,
        string telefone, string telemovel, string tele_serv,
       string nacionalidade, string cc, string validade_cc, string data_nascimento, string email,
       string entidade_patronal, string categ_profissional, string tipo_de_pedido, string area_trabalho, string validade_acesso,
          string funcao, string horario, string areas, string cartao_pontual_visitante, string autorizacao_portas, string inquerito,
          string formacao, string fotocopia_bi, string fotocopia_vinculo_laboral, string fotografia, string registo_criminal, string fotocopia_cartao_acompanhante,
          string estado, int entidade_identidade, string data_reg, string pessoa_requerente, string numero, string nome_acompanhante, string doc_path_segunda_via_cartao, int id)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("nome", nome));
            parameters.Add(new MySqlParameter("morada", morada));
            parameters.Add(new MySqlParameter("localidade", localidade));
            parameters.Add(new MySqlParameter("codigopostal", codigopostal));
            parameters.Add(new MySqlParameter("telefone", telefone));
            parameters.Add(new MySqlParameter("telemovel", telemovel));
            parameters.Add(new MySqlParameter("tele_serv", tele_serv));
            parameters.Add(new MySqlParameter("nacionalidade", nacionalidade));
            parameters.Add(new MySqlParameter("cc", cc));
            parameters.Add(new MySqlParameter("validade_cc", validade_cc));
            parameters.Add(new MySqlParameter("data_nascimento", data_nascimento));
            parameters.Add(new MySqlParameter("email", email));
            parameters.Add(new MySqlParameter("entidade_patronal", entidade_patronal));
            parameters.Add(new MySqlParameter("categ_profissional", categ_profissional));
            parameters.Add(new MySqlParameter("tipo_de_pedido", tipo_de_pedido));
            parameters.Add(new MySqlParameter("area_trabalho", area_trabalho));
            parameters.Add(new MySqlParameter("validade_acesso", validade_acesso));
            parameters.Add(new MySqlParameter("funcao", funcao));
            parameters.Add(new MySqlParameter("horario", horario));
            parameters.Add(new MySqlParameter("areas", areas));
            parameters.Add(new MySqlParameter("cartao_pontual_visitante", cartao_pontual_visitante));
            parameters.Add(new MySqlParameter("autorizacao_portas", autorizacao_portas));
            parameters.Add(new MySqlParameter("inquerito", inquerito));
            parameters.Add(new MySqlParameter("formacao", formacao));
            parameters.Add(new MySqlParameter("fotocopia_bi", fotocopia_bi));
            parameters.Add(new MySqlParameter("fotocopia_vinculo_laboral", fotocopia_vinculo_laboral));
            parameters.Add(new MySqlParameter("fotografia", fotografia));

            parameters.Add(new MySqlParameter("registo_criminal", registo_criminal));
            parameters.Add(new MySqlParameter("fotocopia_cartao_acompanhante", fotocopia_cartao_acompanhante));
            parameters.Add(new MySqlParameter("data_reg", data_reg));
            parameters.Add(new MySqlParameter("pessoa_requerente", pessoa_requerente));
            parameters.Add(new MySqlParameter("doc_path_segunda_via_cartao", doc_path_segunda_via_cartao));
           
            parameters.Add(new MySqlParameter("estado", estado));
            parameters.Add(new MySqlParameter("nome_acompanhante", nome_acompanhante));
            parameters.Add(new MySqlParameter("idin", id));
            return sqlHelper.executeSP<int>(parameters, "insert_segunda_via_cartao");
        }

        public List<PROP_cartao> select_renovacao_cartao_byid(int id)
        {
            List<PROP_cartao> cartaolist = new List<PROP_cartao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("idin", id));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_renovacao_cartao");

            PROP_cartao cartao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                cartao = new PROP_cartao(Convert.ToInt32(drow["idcartao_renovacao"]), drow["data_reg"].ToString(), drow["pessoa_requerente"].ToString(), drow["doc_path_renovacao_cartao"].ToString(), drow["fotocopia_cartao_identificacao"].ToString(), drow["estado"].ToString());
                cartaolist.Add(cartao);
            }

            return cartaolist;
        }
        public List<PROP_cartao> select_segunda_via_cartao_byid(int id)
        {
            List<PROP_cartao> cartaolist = new List<PROP_cartao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("idin", id));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_segunda_via_cartao");

            PROP_cartao cartao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                cartao = new PROP_cartao(Convert.ToInt32(drow["idcartao_segunda_via"]), drow["data_reg"].ToString(), drow["pessoa_requerente"].ToString(), drow["doc_path_segunda_via_cartao"].ToString(),  drow["estado"].ToString());
                cartaolist.Add(cartao);
            }

            return cartaolist;
        }
        public string estado_via_cartao(int idvia)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("id_segunda_via", idvia));
            return sqlHelper.executeScaler(lstParameter, "estado_segunda_via_cartao");
        }

        public string estado_renovacao_cartao(int idrenovacao)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("id_renovacao", idrenovacao));
            return sqlHelper.executeScaler(lstParameter, "estado_renovacao_cartao");
        }

        public int update_parecer_psp(int idin,  string parecer_psp, string parecer_psp_data, string msg_psp, string req_psp)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("idin", idin));
            parameters.Add(new MySqlParameter("parecer_psp", parecer_psp));
            parameters.Add(new MySqlParameter("parecer_psp_data", parecer_psp_data));
            parameters.Add(new MySqlParameter("msg_psp", msg_psp));
            parameters.Add(new MySqlParameter("req_psp", req_psp));
            return sqlHelper.executeSP<int>(parameters, "update_parecer_psp");
        }
        public int update_parecer_sef(int idin, string parecer_sef, string parecer_sef_data, string msg_sef, string req_sef)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("idin", idin));
            parameters.Add(new MySqlParameter("perecer_sef", parecer_sef));
            parameters.Add(new MySqlParameter("parecer_sef_data", parecer_sef_data));
            parameters.Add(new MySqlParameter("msg_sef", msg_sef));
            parameters.Add(new MySqlParameter("req_sef", req_sef));
            return sqlHelper.executeSP<int>(parameters, "update_parecer_sef");
        }

        public int update_admin_cartao_renovacao(int idin, string estado, string conferido, string cor, string parecer_psp, string parecer_psp_data, string perecer_sef, string parecer_sef_data
         , string parecer_outros, string parecer_outros_data, string num_cartao, string tipo_de_pedido, string areas, string validade_acesso, string pagamento, int idrenovacao, string autorizacao_portas)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("idin", idin));
            parameters.Add(new MySqlParameter("estado", estado));
            parameters.Add(new MySqlParameter("conferido", conferido));
            parameters.Add(new MySqlParameter("cor", cor));
            parameters.Add(new MySqlParameter("parecer_psp", parecer_psp));
            parameters.Add(new MySqlParameter("parecer_psp_data", parecer_psp_data));
            parameters.Add(new MySqlParameter("perecer_sef", perecer_sef));
            parameters.Add(new MySqlParameter("parecer_sef_data", parecer_sef_data));
            parameters.Add(new MySqlParameter("parecer_outros", parecer_outros));
            parameters.Add(new MySqlParameter("parecer_outros_data", parecer_outros_data));
            parameters.Add(new MySqlParameter("num_cartao", num_cartao));
            parameters.Add(new MySqlParameter("tipo_de_pedido", tipo_de_pedido));
            parameters.Add(new MySqlParameter("areas", areas));
            parameters.Add(new MySqlParameter("validade_acesso", validade_acesso));
            parameters.Add(new MySqlParameter("pagamento", pagamento));
            parameters.Add(new MySqlParameter("idrenovacao", idrenovacao));
            parameters.Add(new MySqlParameter("autorizacao_portas", autorizacao_portas));
            return sqlHelper.executeSP<int>(parameters, "update_renovacao_cartao_admin_by_id");
        }
        public int update_admin_cartao_segunda_via(int idin, string estado, string conferido, string cor, string parecer_psp, string parecer_psp_data, string perecer_sef, string parecer_sef_data
        , string parecer_outros, string parecer_outros_data, string num_cartao, string tipo_de_pedido, string areas, string validade_acesso, string pagamento, int idrenovacao)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("idin", idin));
            parameters.Add(new MySqlParameter("estado", estado));
            parameters.Add(new MySqlParameter("conferido", conferido));
            parameters.Add(new MySqlParameter("cor", cor));
            parameters.Add(new MySqlParameter("parecer_psp", parecer_psp));
            parameters.Add(new MySqlParameter("parecer_psp_data", parecer_psp_data));
            parameters.Add(new MySqlParameter("perecer_sef", perecer_sef));
            parameters.Add(new MySqlParameter("parecer_sef_data", parecer_sef_data));
            parameters.Add(new MySqlParameter("parecer_outros", parecer_outros));
            parameters.Add(new MySqlParameter("parecer_outros_data", parecer_outros_data));
            parameters.Add(new MySqlParameter("num_cartao", num_cartao));
            parameters.Add(new MySqlParameter("tipo_de_pedido", tipo_de_pedido));
            parameters.Add(new MySqlParameter("areas", areas));
            parameters.Add(new MySqlParameter("validade_acesso", validade_acesso));
            parameters.Add(new MySqlParameter("pagamento", pagamento));
            parameters.Add(new MySqlParameter("idrenovacao", idrenovacao));
            return sqlHelper.executeSP<int>(parameters, "update_segunda_via_cartao_admin_by_id");
        }

        public string doc_path_renovacao_cartao(int idrenovacao)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("idin", idrenovacao));
            return sqlHelper.executeScaler(lstParameter, "select_doc_path_renovacao_cartao");
        }
        public string doc_path_segunda_via_cartao(int idrenovacao)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("idin", idrenovacao));
            return sqlHelper.executeScaler(lstParameter, "select_doc_path_segunda_via_cartao");
        }
        public List<PROP_cartao> select_cartao_by_identidade_pendente(int identidade)
        {
            List<PROP_cartao> cartaolist = new List<PROP_cartao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("identidade", identidade));
            //parameters.Add(new MySqlParameter("num", num));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_cartao_by_identidade_pendente");

            PROP_cartao cartao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                cartao = new PROP_cartao(drow["Pedido"].ToString(), drow["numero"].ToString(), drow["data_reg"].ToString(), drow["nome"].ToString(), drow["pessoa_requerente"].ToString(), drow["estado"].ToString());
                cartaolist.Add(cartao);
            }

            return cartaolist;
        }
        public List<PROP_cartao> select_cartao_by_pendente_admin()
        {
            List<PROP_cartao> cartaolist = new List<PROP_cartao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
        
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_cartao_by_pendente_admin");

            PROP_cartao cartao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                cartao = new PROP_cartao(drow["Pedido"].ToString(), drow["numero"].ToString(), drow["data_reg"].ToString(), drow["nome"].ToString(), drow["pessoa_requerente"].ToString(), drow["estado"].ToString(), Convert.ToInt32(drow["entidade_identidade"].ToString()));
                cartaolist.Add(cartao);
            }

            return cartaolist;
        }

        public List<PROP_cartao> valida_n_cartao(string num_cartao_new, int cartao_escolhido)
        {
            List<PROP_cartao> cartao_list = new List<PROP_cartao>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("num_cartao_new", num_cartao_new));
            parameters.Add(new MySqlParameter("cartao_escolhido", cartao_escolhido));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "valida_n_cartao");

            PROP_cartao cartao;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                cartao = new PROP_cartao(drow["num_cartao"].ToString());
                cartao_list.Add(cartao);
            }

            return cartao_list;
        }

        public int update_estado_inativo_cartao(int idin)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            parameters.Add(new MySqlParameter("idin", idin));
            return sqlHelper.executeSP<int>(parameters, "update_estado_inativo_cartao");
        }
    }


    
}