using DAL;
using MySql.Data.MySqlClient;
using PROP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication10.PROP;

namespace WebApplication10.DAL
{
    public class DAL_entidade
    {
        public int Create_entidade(string nome, string rua, string codigopostal, string cidade, string pais,string codigo)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            //parameters.Add(new MySqlParameter("_CountryName", countryName));
        parameters.Add(new MySqlParameter("nome", nome));
              parameters.Add(new MySqlParameter("rua", rua));
              parameters.Add(new MySqlParameter("codigopostal", codigopostal));
              parameters.Add(new MySqlParameter("cidade", cidade));
              parameters.Add(new MySqlParameter("pais", pais));
              parameters.Add(new MySqlParameter("codigo", codigo));
            return sqlHelper.executeSP<int>(parameters, "inserir_entidade");
        }

        public List<PROP_entidade> get_entidade(string entidade_entrada)
        {
            List<PROP_entidade> entidadelist = new List<PROP_entidade>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("identrada", Convert.ToInt32(entidade_entrada)));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "ver_entidade");

            PROP_entidade entidade;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                entidade = new PROP_entidade(Convert.ToInt32(drow["identidade"]), drow["nome"].ToString(), drow["rua"].ToString(), drow["codigopostal"].ToString(), drow["cidade"].ToString(), drow["pais"].ToString(), drow["codigo"].ToString());
                entidadelist.Add(entidade);
            }

            return entidadelist;
        }

        public List<PROP_entidade> getAll_entidade()
        {
            List<PROP_entidade> entidade_list = new List<PROP_entidade>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "ver_entidade");


            PROP_entidade entidade;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                entidade = new PROP_entidade(Convert.ToInt32(drow["identidade"]), drow["nome"].ToString(), drow["rua"].ToString(), drow["codigopostal"].ToString(), drow["cidade"].ToString(), drow["pais"].ToString(), drow["codigo"].ToString());
                entidade_list.Add(entidade);
            }

            return entidade_list;
        }


        public void Update_entidade(int identrada, string nome, string rua, string codigopostal, string cidade,  string pais,string codigo)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("idin", identrada));
            lstParameter.Add(new MySqlParameter("nomentrada", nome));
            lstParameter.Add(new MySqlParameter("rua", rua));
            lstParameter.Add(new MySqlParameter("codigopostal", codigopostal));
            lstParameter.Add(new MySqlParameter("cidade", cidade));
            lstParameter.Add(new MySqlParameter("pais", pais));
            lstParameter.Add(new MySqlParameter("codigo", codigo));
            sqlHelper.executenonquery(lstParameter, "update_entidade");
        }

        public string get_entidade_by_id(int identidade)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("identrada", identidade));
            return sqlHelper.executeScaler(lstParameter, "pesq_id_entidade");
        }
        public string get_codigo_entidade_by_id(int identidade)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("identrada", identidade));
            return sqlHelper.executeScaler(lstParameter, "pesq_codigo_entidade");
        }
            public string get_entidade_by_nome(string nome)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("nomentrada", nome));
            return sqlHelper.executeScaler(lstParameter, "pesq_nome_entidade");
        }



            public string numero_entidade()
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                return sqlHelper.executeScaler(lstParameter, "numero_entidade");

            }
            public void insert_entidade1()
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                sqlHelper.executeScaler(lstParameter, "insert_entidade");

            }

            public string get_entidade_by_user(int iduser)
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("user", iduser));
                return sqlHelper.executeScaler(lstParameter, "select_entidade_by_user");
            }

            public string existe_entidade(string nome_entidade, int id_entidadein)
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("nome_entidade", nome_entidade));
                lstParameter.Add(new MySqlParameter("id_entidadein", id_entidadein));
                return sqlHelper.executeScaler(lstParameter, "valida_nome_entidade");
            }

            public string valida_n_entidade(string n_cartao_in, int pk_entidade)
            {
                SQLHelper sqlHelper = new SQLHelper();
                List<MySqlParameter> lstParameter = new List<MySqlParameter>();
                lstParameter.Add(new MySqlParameter("n_cartao_in", n_cartao_in));
                lstParameter.Add(new MySqlParameter("pk_entidade", pk_entidade));
                return sqlHelper.executeScaler(lstParameter, "valida_n_entiadade");
            }
    }
}