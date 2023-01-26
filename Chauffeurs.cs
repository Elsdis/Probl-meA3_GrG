using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblèmeA3_GrG
{
    public class Chauffeurs:Salarie
    {
        private bool estLibre;
        public Chauffeurs(string nom, string prenom, DateTime dt, string adressepostale, string adressemail, string telephone, string numSecu, DateTime dtES, string poste, double salaire,Vehicule vehiculeconduit, double tarifhoraire) : base(nom, prenom, dt, adressepostale, adressemail, telephone, numSecu, dtES, poste, salaire)
        {
            this.vehiculeconduit = vehiculeconduit;
            this.tarifhoraire = tarifhoraire;
        }
        public Vehicule Vehiculeconduit
        {
            get { return vehiculeconduit; }
        }
        
        public double Tarifhoraire
        {
            get { return tarifhoraire; }
        }

        

    }
}
