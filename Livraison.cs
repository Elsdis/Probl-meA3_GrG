using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblèmeA3_GrG
{
    internal class Livraison
    {
        //attributs

        private string france;
        private string lieudepart;
        private string lieuarrivee;

        //

        public string Lieudepart
        {
            get { return lieudepart; }
            
        }

        public string Lieuarrivee
        {
            get { return lieuarrivee; }
            
        }
        public string France
        {
            get { return france; }
            set {france= value; }
        }

        public Livraison(string france, string lieudepart,string lieuarrivee)
        {
            this.france = france;
            this.lieudepart = lieudepart;
            this.lieuarrivee = lieuarrivee; 
            
        }

        public int Distance()
        {
            return 0;
        }
        public void AfficherDistance(string lieudepart,string lieuarrivee)
        {
            //ouverture et lecture du fichier distance


        }


    }
}
