using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROP
{
    public class PROPAcessos
    {
        public int idlogin { get; set; }
        public string username { get; set; }

        public PROPAcessos()
        {

        }

        public PROPAcessos(int idlogin, string username)
        {
            this.idlogin = idlogin;
            this.username = username;
        }

       

        //public List<PROPAcessos> getCoutry(string searchCountry)
        //{
        //    DALCountry dalCountry = new DALCountry();

        //    if (string.IsNullOrEmpty(searchCountry))
        //    {
        //        return dalCountry.getAllCountry();
        //    }
        //    else
        //    {
        //        return dalCountry.getCountry(searchCountry);
        //    }
        //}
    }
}
