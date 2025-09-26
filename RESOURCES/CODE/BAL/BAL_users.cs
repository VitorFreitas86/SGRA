using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication10.DAL;
using WebApplication10.PROP;

namespace WebApplication10.BAL
{
    public class BAL_users
    {
        public List<PROP_users> pesquisar_user(string nome_entrada)
        {
            DAL_users users = new DAL_users();
            return users.pesquisar_users("%" + nome_entrada + "%");
        }
        public List<PROP_users> get_user()
        {
            DAL_users users = new DAL_users();         
                return users.getAll_users();
        }
        public List<PROP_users> get_contatos_user(int iduser)
        {
            DAL_users users = new DAL_users();

            //if (string.IsNullOrEmpty())
            //{
            return users.get_contatos_user(iduser);
            //return dalCountry.getAllCountry();
            //}
            //else
            //{
            //    return user.get_entidade(user);
            //}
        }
        public List<PROP_users> get_login_user(int iduser)
        {
            DAL_users users = new DAL_users();

            //if (string.IsNullOrEmpty())
            //{
            return users.get_login_user(iduser);
            //return dalCountry.getAllCountry();
            //}
            //else
            //{
            //    return user.get_entidade(user);
            //}
        }
        public List<PROP_users> edit_user_by_id(int iduser)
        {
            DAL_users users = new DAL_users();

            //if (string.IsNullOrEmpty())
            //{
            return users.edit_user_by_id(iduser);
            //return dalCountry.getAllCountry();
            //}
            //else
            //{
            //    return user.get_entidade(user);
            //}
        }
        public void delete_user_by_id(int iduser)
        {
            DAL_users users = new DAL_users();
            users.delete_user_by_id(iduser);
        }

        public void update_user_approved(int iduser,int aprovado)
        {
            DAL_users users = new DAL_users();
            users.update_user_approved(iduser,aprovado);
        }

        public void update_user_islockedout(int iduser, int locked, DateTime? datal)
        {
            DAL_users users = new DAL_users();
            users.update_user_islockedout(iduser, locked, datal);
        }
        public void update_user_edit(int iduser, string username, string password, string email, string nome, string num_acl, string telefone, string fax, string cargo)
        {
            DAL_users users = new DAL_users();
            users.update_user_edit(iduser, username, password, email, nome, num_acl, telefone, fax, cargo);
        }
        public List<PROP_users> select_user_by_nome(string nome)
        {
            DAL_users users = new DAL_users();
            return users.select_user_by_nome(nome);
        }
        public List<PROP_users> select_user_nomepessoal_by_id(int id)
        {
            DAL_users users = new DAL_users();
            return users.select_user_nomepessoal_by_id(id);
        }

        public void update_FailedPasswordAttemptCount(int iduser, DateTime? datal)
        {
            DAL_users users = new DAL_users();
            users.update_FailedPasswordAttemptCount(iduser, datal);
        }


        
        public List<PROP_users> validarlogin(string nome,string password)
        {
            DAL_users users = new DAL_users();
            return users.validarlogin(nome,password);
        }

        public int numero_roles()
        {
            DAL_users roles = new DAL_users();
            return Convert.ToInt32(roles.numero_roles());

        }
        public void insert_roles()
        {
            DAL_users roles = new DAL_users();
            roles.insert_roles();

        }

        public int numero_users()
        {
            DAL_users user = new DAL_users();
             return Convert.ToInt32(user.numero_users());
        }


        public void insert_first_u(int idin)
        {
            DAL_users user = new DAL_users();
            user.insert_first_u(idin);
        }

        public void insert_usersinroles(int IDin, int roleId)
        {
            DAL_users role = new DAL_users();
            role.insert_usersinroles(IDin,roleId);
        }


        public void update_privilegio(int IDin, int roleId)
        {
            DAL_users role = new DAL_users();
            role.update_privilegio(IDin, roleId);
        }
        public int privilegio_user(int idin)
        {
            DAL_users roles = new DAL_users();
            return Convert.ToInt32(roles.privilegio_user(idin));

        }
        
    }
}