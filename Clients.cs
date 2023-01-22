using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblèmeA3_GrG
{
    public class Clients:Personne
    {
       
        public Clients(string nom, string prenom, DateTime dt, string adressepostale, string adressemail,string telephone,string numSS):base(nom,prenom,dt,adressepostale,adressemail,telephone,numSS)
        {
            
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
