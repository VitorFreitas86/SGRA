using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.PROP
{
    public class PROP_entidade
    {
        private string existe_entidade;

        //public int idlogin { get; set; }
        public int identidade { get; set; }
        public string nome { get; set; }
      
        public string rua { get; set; }
        public string codigopostal { get; set; }
        public string cidade { get; set; }
        public string pais { get; set; }
        public string codigo { get; set; }
        public PROP_entidade()
        {

        }

        public PROP_entidade(int identidade, string nome, string rua, string codigopostal, string cidade, string pais,string codigo)
        {
            this.identidade = identidade;
            this.nome = nome;
        
            this.rua = rua; 
            this.codigopostal = codigopostal;
            this.cidade = cidade;
            this.pais = pais;
            this.codigo = codigo;
        }

        public PROP_entidade(string existe_entidade)
        {
            // TODO: Complete member initialization
            this.existe_entidade = existe_entidade;
        }
    }
}