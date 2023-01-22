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
        List<Vehicule> vehicule;
        private Chauffeurs chauffeur;
        private DateTime datedeliv;
        Ville depart;
        Ville arrivee;
        private Dijkstra chemin;
        public double Prix
        {
            get { return prix; }
        }

        public Chauffeurs Chauffeur
        {
            get { return chauffeur; }
        }
        public DateTime Datedeliv
        {
            get { return datedeliv; }
        }

        public Ville Depart
        {
            get { return depart; }

        }

        public Ville Arrivee
        {
            get { return arrivee; }
        }

        public Clients Client
        {
            get { return client; }
        }
        public Commande(Clients client, Ville depart, Ville arrivee, double prix, List<Vehicule> vehicule, Chauffeurs chauffeur, DateTime datedeliv,Graph graphVilles)
        {
            this.client = client;
            this.depart = depart;
            this.arrivee = arrivee;
            this.prix = prix;
            this.vehicule = vehicule;
            this.chauffeur = chauffeur;
            this.datedeliv = datedeliv;
            this.chemin = new Dijkstra(graphVilles, depart);
            chemin.CheminPlusCourt();
        }

        public double TarifCommande(Chauffeurs ch)
        {
            int[] tempsDistance = chemin.obtenirtempsdistance(arrivee);
            int temps = tempsDistance[0];
            int distance = tempsDistance[1];
            double tarif = ch.CalculTarifhoraire(ch) + distance * ch.Vehiculeconduit.TarifKilometrique; //manque tarif au kilometrage;   *
            return tarif;



        }
        public void AjouterCommande(Commande c1)
        {
        }
    }
}
