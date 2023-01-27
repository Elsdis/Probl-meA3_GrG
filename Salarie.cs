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

        
        protected DateTime dateentreesociete;
        protected string poste;
        protected double tarifHoraire;
        protected List<Salarie> employes;

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

        public double TarifHoraire
        {
            get { return tarifHoraire; }
              
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

        public Salarie(List<Salarie> employes, string nom,string prenom, DateTime dt, string adressepostale, string adressemail, string telephone, string numSS, DateTime dtES, string poste, double tarifHoraire):base(nom,prenom,dt,adressepostale,adressemail,telephone,numSS)
        {
            this.dateentreesociete = dtES;
            this.poste = poste;
            this.tarifHoraire = tarifHoraire;
            this.employes = employes;
        }
        public Salarie( string nom, string prenom, DateTime dt, string adressepostale, string adressemail, string telephone, string numSS, DateTime dtES, string poste, double tarifHoraire) : base(nom, prenom, dt, adressepostale, adressemail, telephone, numSS)
        {
            this.dateentreesociete = dtES;
            this.poste = poste;
            this.tarifHoraire = tarifHoraire;
            this.employes = new List<Salarie>();
        }

        public override string ToString()
        {
            return base.ToString() + $"\nDate entrée société: {dateentreesociete.ToShortDateString()} \nPoste: {poste} \nTarif horaire: {tarifHoraire}";
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
            if (s1 is null)
            {
                return s2 is null;
            }
            if (s2 is null)
            {
                return s1 is null;
            }
            return s1.Nom == s2.Nom && s1.Prenom == s2.Prenom;
        }
        public static bool operator !=(Salarie s1, Salarie s2)
        {
            if (s1 is null)
            {
                return !(s2 is null); 
            }
            if (s2 is null)
            {
                return !(s1 is null);
            }
            return s1.Nom != s2.Nom || s1.Prenom != s2.Prenom;
        }
        public int CalculTarifhoraire()
        {
          
            int anciennete = DateTime.Now.Year - this.dateentreesociete.Year;
            if (anciennete > 5 && anciennete <10)
            {
                return 10;
            }
            if(anciennete > 10 && anciennete < 20)
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
