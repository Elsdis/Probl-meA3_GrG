using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblèmeA3_GrG
{
    public class Chauffeurs:Salarie
    {
        private Vehicule vehiculeconduit;
        private double tarifhoraire;
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

        public int CalculTarifhoraire()
        {
          
            int anciennete = DateTime.Now.Year - this.dateentreesociete.Year;
            if (anciennete > 5 && anciennete <10)
            {
                return 10;
            }
            if(anciennete >10 && anciennete < 20)
            {
                return 12;
            }
            if(anciennete>20 && anciennete <30)
            {
                return 13;
            }
            if (anciennete > 30)
            {
                return 15;
            }
            return 8;
        }
        

    }
}
