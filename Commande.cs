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
        private string produit;
        private string numero;
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
        public string Produit
        {
            get { return produit; }
        }
        public string Numero
        {
            get { return numero; }
        }
        public Vehicule Vehicule
        {
            get { return vehicule; }
        }


        public Ville Arrivee
        {
            get { return arrivee; }
        }

        public Clients Client
        {
            get { return client; }
            set { client = value; }
        }
        public Commande(Salarie chauffeur, Clients client, Ville depart, Ville arrivee, double prix, Vehicule vehicule, DateTime datedeliv, string produit, string numero, Graph graphVilles)
        {
            this.chauffeur = chauffeur;
            this.client = client;
            this.depart = depart;
            this.arrivee = arrivee;
            this.prix = prix;
            this.vehicule = vehicule;
            this.datedeliv = datedeliv;
            this.produit = produit;
            this.numero = numero;
            this.chemin = new Dijkstra(graphVilles, depart);
            chemin.CheminPlusCourt();
        }


        public double TarifCommande(Salarie ch)
        {
            int[] tempsDistance = chemin.obtenirtempsdistance(arrivee);
            int temps = tempsDistance[0];
            int distance = tempsDistance[1];
            double tarif = ch.CalculTarifhoraire() * temps / 60.0 + distance * vehicule.TarifKilometrique;
            return tarif;
        }
        public override string ToString()
        {
            return "Commande n°" + numero + " de " + client.Nom + " " + client.Prenom + " pour " + produit + " de " + depart.Nom + " à " + arrivee.Nom + " le " + datedeliv + " par " + chauffeur.Nom + " " + chauffeur.Prenom + " pour " + prix + "€";
        }
    }
}
