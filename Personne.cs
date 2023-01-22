using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblèmeA3_GrG
{

    class Personne
    {

        //attributs

        protected string nom;
        protected string numSS;
        protected string prenom;
        protected DateTime datedenaissance;
        protected string adressepostale;
        protected string adressemail;
        protected string telephone;
        //proprietes


        public string Nom
        {
            get { return nom; }
            set { nom = value; }

        }

        public string Prenom
        {
            get { return prenom; }
        }
        public DateTime Datedenaissance
        {
            get { return datedenaissance; }
        }

        public string Adressepostale
        {
            get { return adressepostale; }
            set { adressepostale = value; }
        }

        public string Adressemail
        {
            get { return adressemail; }
            set { adressemail = value; }
        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }

        }
        public string NumSS
        {
            get { return numSS; }
        }


        //Constructeur

        public Personne(string nom, string prenom, DateTime dt, string adressepostale, string adressemail, string telephone, string numSS)
        {

            this.nom = nom;
            this.prenom = prenom;
            this.datedenaissance = dt;
            this.adressepostale = adressepostale;
            this.adressemail = adressemail;
            this.telephone = telephone;
            this.numSS = numSS;
        }

        public override string ToString()
        {
            return $"Nom : {nom}\n" +
                $"Prenom : {prenom}\n" +
                $"Date de naissance : {datedenaissance.ToShortDateString()}\n" +
                $"Adresse postale : {adressepostale}\n" +
                $"Adresse mail : {adressemail}\n" +
                $"Telephone : {telephone}\n" +
                $"Numéro de sécurité sociale : {numSS}";
        }
    }
}


