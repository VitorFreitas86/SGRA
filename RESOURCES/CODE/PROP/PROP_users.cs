using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.PROP
{
    public class PROP_users
    {
        //private string p1;
        //private string p2;
        //private string p3;
        //private string p4;
        //private string p5;
        //private string p6;
        //private string p7;
        //private string p8;
        //private string p9;
        //private string p10;
        //private string p11;
        //private object p;

        public int userId { get; set; }
        public string name { get; set; }

        public string CreationDate { get; set; }
        public string nome { get; set; }
        public string entidade_identidade { get; set; }
        public string IsApproved { get; set; }

        public string num_acl { get; set; }

        public string cargo { get; set; }

        public string telefone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        //public string IsApproved { get; set; }
        //public string IsApproved { get; set; }
        public string LastLoginDate { get; set; }
        public string Password { get; set; }
        public string passwordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public string LastPasswordChangedDate { get; set; }
        public string FailedPasswordAttemptCount { get; set; }
        public string FailedPasswordAttemptWindowStart { get; set; }
        public string FailedPasswordAnswerAttemptCount { get; set; }
        public string FailedPasswordAnswerAttemptWindowStart { get; set; }
        public string IsLockedOut { get; set; }
        public string LastLockedOutDate { get; set; }

        public PROP_users()
        {

        }

        public PROP_users(int userId, string name, string CreationDate, string nome, string entidade_identidade, string IsApproved)
        {
            this.userId = userId;
            this.name = name;

            this.CreationDate = CreationDate;
            this.nome = nome;
            this.entidade_identidade = entidade_identidade;
            this.IsApproved = IsApproved;
        }

        public PROP_users(string num_acl, string cargo, string telefone, string fax, string email)
        {
            this.num_acl = num_acl;
            this.cargo = cargo;

            this.telefone = telefone;
            this.fax = fax;
            this.email = email;
            //this.IsApproved = IsApproved;
        }

        public PROP_users(string LastLoginDate, string Password, string passwordQuestion,
            string PasswordAnswer, string LastPasswordChangedDate, string FailedPasswordAttemptCount,
            string FailedPasswordAttemptWindowStart, string FailedPasswordAnswerAttemptCount, string FailedPasswordAnswerAttemptWindowStart,
            string IsLockedOut, string LastLockedOutDate)
        {
            // TODO: Complete member initialization
            this.LastLoginDate = LastLoginDate;
            this.Password = Password;
            this.passwordQuestion = passwordQuestion;
            this.PasswordAnswer = PasswordAnswer;
            this.LastPasswordChangedDate = LastPasswordChangedDate;
            this.FailedPasswordAttemptCount = FailedPasswordAttemptCount;
            this.FailedPasswordAttemptWindowStart = FailedPasswordAttemptWindowStart;
            this.FailedPasswordAnswerAttemptCount = FailedPasswordAnswerAttemptCount;
            this.FailedPasswordAnswerAttemptWindowStart = FailedPasswordAnswerAttemptWindowStart;
            this.IsLockedOut = IsLockedOut;
            this.LastLockedOutDate = LastLockedOutDate;
        }

        public PROP_users(string nome, string num_acl, string telefone, string fax,
            string cargo, string name, string Password, string email)
        {
            // TODO: Complete member initialization
            this.nome = nome;
            this.num_acl = num_acl;
            this.telefone = telefone;
            this.fax = fax;
            this.cargo = cargo;
            this.name = name;
            this.Password = Password;
            this.email = email;
        }

        public PROP_users(int userId, string nome)
        {
            // TODO: Complete member initialization
            this.userId = userId;
            this.nome = nome;
        }

        public PROP_users(string nome)
        {
            // TODO: Complete member initialization
            this.nome = nome;
        }
        public PROP_users(string name, string Password)
        {
            // TODO: Complete member initialization
            this.name = name;
            this.Password = Password;
        }




    }
}