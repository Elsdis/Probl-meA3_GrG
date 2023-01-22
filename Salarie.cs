using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblèmeA3_GrG
{
    public class Salarie:Personne
    {
        //attributs

        
        private DateTime dateentreesociete;
        private string poste;
        private double salaire;
        private List<Salarie> employes;

        //Propriétés



        public DateTime Dateentreesociete
        {
            get { return dateentreesociete; }
            set { dateentreesociete = value; }
        }

        public string Poste
        {
            get { return poste; }
            
        }

        public double Salaire
        {
            get { return salaire; }
              
        }
        public List<Salarie> Employes
        {
            get { return employes; }
        }
        

        public string ToShortString()
        {
            return $"{nom} {prenom} / {poste}";
        }
        //Constructeur

        public Salarie(List<Salarie> employes, string nom,string prenom, DateTime dt, string adressepostale, string adressemail, string telephone, string numSS, DateTime dtES, string poste, double salaire):base(nom,prenom,dt,adressepostale,adressemail,telephone,numSS)
        {
            this.dateentreesociete = dtES;
            this.poste = poste;
            this.salaire = salaire;
            this.employes = employes;
        }
        public Salarie( string nom, string prenom, DateTime dt, string adressepostale, string adressemail, string telephone, string numSS, DateTime dtES, string poste, double salaire) : base(nom, prenom, dt, adressepostale, adressemail, telephone, numSS)
        {
            this.dateentreesociete = dtES;
            this.poste = poste;
            this.salaire = salaire;
            this.employes = new List<Salarie>();
        }

        public override string ToString()
        {
            return base.ToString() + $"\nDate entrée société: {dateentreesociete.ToShortDateString()} \nPoste: {poste} \nSalaire: {salaire}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Salarie)
            {
                Salarie s = (Salarie)obj;
                return s.Nom == this.Nom && s.Prenom == this.Prenom;
            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(Salarie s1, Salarie s2)
        {
            return s1.Nom == s2.Nom && s1.Prenom == s2.Prenom;
        }
        public static bool operator !=(Salarie s1, Salarie s2)
        {
            return s1.Nom != s2.Nom || s1.Prenom != s2.Prenom;
        }
    }
}
