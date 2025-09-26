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
    public class DAL_users
    {
        public List<PROP_users> pesquisar_users(string nome_entrada)
        {
            List<PROP_users> user_list = new List<PROP_users>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@nome_entrada", nome_entrada));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "pesq_nome_user");


            PROP_users user;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                user = new PROP_users(Convert.ToInt32(drow["userId"]), drow["name"].ToString(), drow["CreationDate"].ToString(), drow["nome"].ToString(), drow["entidade_identidade"].ToString(), drow["IsApproved"].ToString());
                user_list.Add(user);
            }

            return user_list;
        }

        public List<PROP_users> getAll_users()
        {
            List<PROP_users> user_list = new List<PROP_users>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "ver_dados_users");


            PROP_users user;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                user = new PROP_users(Convert.ToInt32(drow["userId"]), drow["name"].ToString(), drow["CreationDate"].ToString(), drow["nome"].ToString(), drow["entidade_identidade"].ToString(), drow["IsApproved"].ToString());
                user_list.Add(user);
            }

            return user_list;
        }

        public List<PROP_users> get_contatos_user(int iduser)
        {
            List<PROP_users> user_list = new List<PROP_users>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@IDin", iduser));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "contatos_user");


            PROP_users user;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                user = new PROP_users(drow["num_acl"].ToString(), drow["cargo"].ToString(), drow["telefone"].ToString(), drow["fax"].ToString(), drow["email"].ToString());
                user_list.Add(user);
            }

            return user_list;
        }

        public List<PROP_users> get_login_user(int iduser)
        {
            List<PROP_users> user_list = new List<PROP_users>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@IDin", iduser));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "login_user");


            PROP_users user;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                user = new PROP_users(drow["LastLoginDate"].ToString(),drow["Password"].ToString(),drow["passwordQuestion"].ToString(), drow["PasswordAnswer"].ToString(), drow["LastPasswordChangedDate"].ToString(), drow["FailedPasswordAttemptCount"].ToString(), drow["FailedPasswordAttemptWindowStart"].ToString(), drow["FailedPasswordAnswerAttemptCount"].ToString(), drow["FailedPasswordAnswerAttemptWindowStart"].ToString(), drow["IsLockedOut"].ToString(), drow["LastLockedOutDate"].ToString());
                user_list.Add(user);
            }

            return user_list;
        }

        public List<PROP_users> edit_user_by_id(int iduser)
        {
            List<PROP_users> user_list = new List<PROP_users>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@IDin", iduser));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_edit_user");


            PROP_users user;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                user = new PROP_users(drow["nome"].ToString(), drow["num_acl"].ToString(), drow["telefone"].ToString(), drow["fax"].ToString(), drow["cargo"].ToString(), drow["name"].ToString(), drow["Password"].ToString(), drow["Email"].ToString());
                user_list.Add(user);
            }

            return user_list;
        }

        public void delete_user_by_id(int iduser)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();

            lstParameter.Add(new MySqlParameter("@IDin", iduser));
            sqlHelper.executenonquery(lstParameter, "apagar_user");


            //MySqlCommand cmd = new MySqlCommand();
            //Object returnValue;

            //cmd.CommandText = "pesq_id_entidade";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("identrada", Convert.ToInt32(Label1.Text) );

            //cmd.Connection = con;

            //con.Open();

            //returnValue = cmd.ExecuteScalar();

            //con.Close();
        }

        public void update_user_approved(int iduser,int aprovado)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();

            lstParameter.Add(new MySqlParameter("@IDin", iduser));
            lstParameter.Add(new MySqlParameter("@approved", aprovado));
            sqlHelper.executenonquery(lstParameter, "update_IsApproved");
        }

        public void update_user_islockedout(int iduser, int locked, DateTime? datal)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();

            lstParameter.Add(new MySqlParameter("@IDin", iduser));
            lstParameter.Add(new MySqlParameter("@locked", locked));
            lstParameter.Add(new MySqlParameter("@datal", datal));
            sqlHelper.executenonquery(lstParameter, "update_IsLockedOut");
        }

        public void update_user_edit(int iduser, string username, string password,string email,string nome,string num_acl,string telefone,string fax,string cargo)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();

            lstParameter.Add(new MySqlParameter("@IDin", iduser));
            lstParameter.Add(new MySqlParameter("@username", username));
            lstParameter.Add(new MySqlParameter("@password", password));
            lstParameter.Add(new MySqlParameter("@email", email));
            lstParameter.Add(new MySqlParameter("@nome", nome));
            lstParameter.Add(new MySqlParameter("@num_acl", num_acl));
            lstParameter.Add(new MySqlParameter("@telefone", telefone));
            lstParameter.Add(new MySqlParameter("@fax", fax));
            lstParameter.Add(new MySqlParameter("@cargo", cargo));
            sqlHelper.executenonquery(lstParameter, "update_edit_user");
        }

        public List<PROP_users> select_user_by_nome(string nome)
        {
            List<PROP_users> user_list = new List<PROP_users>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@nome_in", nome));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_user_by_name");


            PROP_users user;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                user = new PROP_users(Convert.ToInt32(drow["UserId"]), drow["nome"].ToString());
                user_list.Add(user);
            }

            return user_list;

        }

        public List<PROP_users> select_user_nomepessoal_by_id(int id)
        {
            List<PROP_users> user_list = new List<PROP_users>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@id", id));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_user_nomepessoal_by_ID");


            PROP_users user;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                user = new PROP_users(drow["nome"].ToString());
                user_list.Add(user);
            }

            return user_list;

        }

        public void update_FailedPasswordAttemptCount(int iduser, DateTime? datal)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();

            lstParameter.Add(new MySqlParameter("@IDin", iduser));
            lstParameter.Add(new MySqlParameter("@datal", datal));
            sqlHelper.executenonquery(lstParameter, "update_FailedPasswordAttemptCount");
        }

        public List<PROP_users> validarlogin(string username,string password)
        {
            List<PROP_users> user_list = new List<PROP_users>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@user", username));
            parameters.Add(new MySqlParameter("@passw", password));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "validar_login");


            PROP_users user;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                user = new PROP_users(drow["name"].ToString(), drow["Password"].ToString());
                user_list.Add(user);
            }

            return user_list;

        }

        public string numero_roles()
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            return sqlHelper.executeScaler(lstParameter, "numero_roles");
        }

       

        public void insert_roles()
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            sqlHelper.executenonquery(lstParameter, "insert_roles");
           
        }

        public string numero_users()
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            return sqlHelper.executeScaler(lstParameter, "numero_users");

        }

        public void insert_first_u(int idin)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("@IDin", idin));
            sqlHelper.executeScaler(lstParameter, "insert_first");

        }

        public void insert_usersinroles(int IDin, int roleID)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("IDin", IDin));
            lstParameter.Add(new MySqlParameter("roleId", roleID));
            sqlHelper.executeScaler(lstParameter, "insert_userinrole");
        }
        public void update_privilegio(int IDin, int roleID)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("iduser", IDin));
            lstParameter.Add(new MySqlParameter("rolevalue", roleID));
            sqlHelper.executeScaler(lstParameter, "update_privilegio_user");
        }

        public string privilegio_user(int iduser)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("iduser", iduser));
            return sqlHelper.executeScaler(lstParameter, "select_privilegio user");
        }
    }
}