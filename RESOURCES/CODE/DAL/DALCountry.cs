using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PROP;
using System.Data;
using System;

namespace DAL
{
    public class DALCountry
    {
        public int CreateCountry(string countryName)
        {            
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("_CountryName", countryName));

            return sqlHelper.executeSP<int>(parameters, "InsertCountry");
        }

        public List<PROPAcessos> getAllCountry()
        {
            List<PROPAcessos> countryList = new List<PROPAcessos>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "ver_login");


            PROPAcessos country;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                country = new PROPAcessos(Convert.ToInt32(drow[0].ToString()), drow[1].ToString());
                countryList.Add(country);
            }

            return countryList;
        }

        public List<PROPAcessos> getCountry(string searchCountry)
        {
            List<PROPAcessos> countryList = new List<PROPAcessos>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("identrada", Convert.ToInt32(searchCountry)));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "pesq_id_entidade");
            
            PROPAcessos country;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                country = new PROPAcessos(0,drow["nome"].ToString());
                countryList.Add(country);
            }

            return countryList;
        }

        public int DeleteCountry(int countryID)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_CountryID", countryID));
            return sqlHelper.executeSP<int>(lstParameter, "DeleteCountry");                
        }

        public string GetCountryById(int countryID)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_CountryID", countryID));
            return sqlHelper.executeScaler(lstParameter, "SelectCountryByID");                
        }

        public void UpdateCountry(PROPAcessos country)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> lstParameter = new List<MySqlParameter>();
            lstParameter.Add(new MySqlParameter("_CountryID", country.idlogin));
            lstParameter.Add(new MySqlParameter("_CountryName", country.username));
            sqlHelper.executenonquery(lstParameter, "UpdateCountryName");
        }

        public void validar_login(string user, string pwd)
        {
            SQLHelper sqlHelper = new SQLHelper();
            //string connStr = "Datasource=localhost;Database=acessos;uid=root;pwd=root;";
            //MySqlConnection conn = new MySqlConnection(connStr);
         
                
            //    conn.Open();

            //    string rtn = "validar_login";
            //    MySqlCommand cmd = new MySqlCommand(rtn, conn);
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    cmd.Parameters.AddWithValue("@user", "user");
            //    cmd.Parameters.AddWithValue("@passw", "pwd");
            //    MySqlDataReader rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        Console.WriteLine(rdr[0] + " --- " + rdr[1]);
            //    }
            //    rdr.Close();
            }
        
        }
    }

