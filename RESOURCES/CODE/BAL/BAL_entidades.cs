using DAL;
using PROP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication10.DAL;
using WebApplication10.PROP;

namespace WebApplication10.BAL
{
    public class BAL_entidades
    {

        public int Create_entidade(string nome, string rua, string codigopostal, string cidade, string pais,string codigo)
        {
          
                DAL_entidade entidade = new DAL_entidade();
             
                return entidade.Create_entidade(nome, rua, codigopostal, cidade, pais,codigo);
            
        }

        public List<PROP_entidade> get_entidade(string entidade_entrada)
        {
            DAL_entidade entidade = new DAL_entidade();

            if (string.IsNullOrEmpty(entidade_entrada))
            {
                return entidade.getAll_entidade();
                
            }
            else
            {
                return entidade.get_entidade(entidade_entrada);
            }
        }


        public bool update_entidade( int identrada, string nome, string rua, string codigopostal, string cidade, string pais,string codigo)
        {
            
                DAL_entidade entidade = new DAL_entidade();
                entidade.Update_entidade(identrada, nome, rua, codigopostal, cidade, pais,codigo);
                return true;
            
        }
        public string get_codigo_entidade_by_id(int entidade_entrada)
        {
            DAL_entidade entidade = new DAL_entidade();
            return entidade.get_codigo_entidade_by_id(entidade_entrada).ToString();
        }
        public string get_entidade_by_id(int entidade_entrada)
        {
            DAL_entidade entidade = new DAL_entidade();
            return entidade.get_entidade_by_id(entidade_entrada).ToString();
        }
        public string get_entidade_by_nome(string nome)
        {
            DAL_entidade entidade = new DAL_entidade();
            return entidade.get_entidade_by_nome(nome).ToString();
        }

        public int numero_entidade()
        {
            DAL_entidade entidade = new DAL_entidade();
            return Convert.ToInt32(entidade.numero_entidade().ToString());
        }

        public void insert_entidade1()
        {
            DAL_entidade entidade = new DAL_entidade();
            entidade.insert_entidade1();
        }

        public int get_entidade_by_user(int userid)
        {
            DAL_entidade entidade = new DAL_entidade();
            return Convert.ToInt32(entidade.get_entidade_by_user(userid).ToString());          
        }


        public string existe_entidade(string nome_entidade, int id_entidadein )
        {
            DAL_entidade entidade = new DAL_entidade();
            return entidade.existe_entidade(nome_entidade, id_entidadein);
        }

        public string valida_n_entidade(string n_cartao_in, int pk_entidade)
        {

            DAL_entidade entidade = new DAL_entidade();
            return entidade.valida_n_entidade(n_cartao_in, pk_entidade);
        }
    }
}