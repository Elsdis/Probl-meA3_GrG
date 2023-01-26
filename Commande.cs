using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProblèmeA3_GrG
{
    public class Commande
    {
        Clients client;
        private double prix;
        Vehicule vehicule;
        private Salarie chauffeur;
        private DateTime datedeliv;
        private bool livré;
        private bool payé;
        Ville depart;
        Ville arrivee;
        private Dijkstra chemin;
        public double Prix
        {
            get { return prix; }
        }

        public Salarie Chauffeur
        {
            get { return chauffeur; }
            set { chauffeur = value; }
        }
        public DateTime Datedeliv
        {
            get { return datedeliv; }
        }

        public Ville Depart
        {
            get { return depart; }

        }
        public bool Livré
        {
            get { return livré; }
            set { livré = value; }
        }
        public bool Payé
        {
            get { return payé; }
            set { payé = value; }
        }



        public Ville Arrivee
        {
            get { return arrivee; }
        }

        public Clients Client
        {
            get { return client; }
        }
        public Commande(Clients client, Ville depart, Ville arrivee, double prix, Vehicule vehicule, DateTime datedeliv,Graph graphVilles)
        {
            this.client = client;
            this.depart = depart;
            this.arrivee = arrivee;
            this.prix = prix;
            this.vehicule = vehicule;
            this.datedeliv = datedeliv;
            this.chemin = new Dijkstra(graphVilles, depart);
            chemin.CheminPlusCourt();
        }

        public double TarifCommande(Chauffeurs ch)
        {
            int[] tempsDistance = chemin.obtenirtempsdistance(arrivee);
            int temps = tempsDistance[0];
            int distance = tempsDistance[1];
            double tarif = ch.CalculTarifhoraire()*temps + distance * ch.Vehiculeconduit.TarifKilometrique; 
            return tarif;
        }
    }
}
