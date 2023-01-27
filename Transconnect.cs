using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Linq;

namespace ProblèmeA3_GrG
{
    internal class Transconnect
    {
        public Graph graphVilles;
        public List<Clients> clients;
        public Salarie boss;
        public List<Commande> commandes;
        public List<Vehicule> vehicules;
        public Salarie Boss
        {
            get { return boss; }
            set { boss = value; }
        }



        public Transconnect(Salarie boss, string fichierClient)
        {
            this.boss = boss;
            this.clients = new List<Clients>();
            if (File.Exists(fichierClient))
            {
                LireFichierClient(fichierClient);
            }
        }
        public Transconnect(string fichierSalarie, string fichierClient)
        {
            this.clients = new List<Clients>();
            if (File.Exists(fichierClient))
            {
                LireFichierClient(fichierClient);
            }
            if (File.Exists(fichierSalarie))
            {
                LireFichierSalarie(fichierSalarie);
            }
        }
        public int GetTreeLength()
        {
            return GetTreeLengthHelper(boss);
        }
        public static int GetTreeLengthHelper(Salarie chef)
        {
            int l = 1;
            foreach (Salarie e in chef.Employes)
            {
                int test = GetTreeLengthHelper(e);
                if (test >= l)
                    l = 1 + test;
            }
            return l;
        }
        public void AfficherArbre()
        {
            if (this.boss == null)
            {
                Console.WriteLine("Il n'y a pas de CEO, veuillez en ajouter un.");
                return;
            }
            int size = GetTreeLength();
            bool[] flag = new bool[size];
            for (int i = 0; i < size; i++)
            {
                flag[i] = true;
            }
            AfficherArbreHelper(this.boss, 0, flag);
        }
        public static void AfficherArbreHelper(Salarie chef, int niveau, bool[] flag, bool isLast = false)
        {
            for (int i = 1; i < niveau; i++)
            {
                Console.Write("    ");
                if (flag[i])
                    Console.Write("|");
                else
                    Console.Write(" ");
            }

            if (niveau > 0)
                Console.Write("    +----");
            Console.WriteLine(chef.ToShortString());
            if (isLast)
                flag[niveau] = false;


            if (chef.Employes.Count > 0)
            {
                for (int i = 0; i < chef.Employes.Count - 1; i++)
                {
                    AfficherArbreHelper(chef.Employes[i], niveau + 1, flag);
                }
                AfficherArbreHelper(chef.Employes[chef.Employes.Count - 1], niveau + 1, flag, true);
            }
            flag[niveau] = true;
        }
        public void AjouterSalarie(Salarie aAjouter, string nom, string prenom)
        {
            if (this.boss == null)
            {
                this.boss = aAjouter;
                return;
            }
            Salarie s = ChercherSalarie(nom, prenom);
            if (s == null)
                Console.WriteLine("Le salarie n'existe pas");
            else if (s.Employes.Contains(aAjouter))
                Console.WriteLine($"{aAjouter.Nom} {aAjouter.Prenom} est déjà un employé de {nom} {prenom}");
            else
                s.Employes.Add(aAjouter);
        }
        public void SupprimerSalarie(string nom, string prenom)
        {
            bool supressed = SupprimerSalarieHelper(boss, nom, prenom);
            if (supressed)
            {
                Console.WriteLine($"{nom} {prenom} a été supprimé");
            }
            else
                Console.WriteLine($"{nom} {prenom} n'existe pas");
        }
        public static bool SupprimerSalarieHelper(Salarie chef, string nom, string prenom)
        {
            bool val = false;
            if (chef.Employes.Count > 0)
            {
                foreach (Salarie e in chef.Employes)
                {
                    if (e.Nom == nom && e.Prenom == prenom)
                    {
                        chef.Employes.Remove(e);
                        return true;
                    }
                    else
                    {
                        val |= SupprimerSalarieHelper(e, nom, prenom);
                    }
                }
            }
            return val;

        }
        public Salarie ChercherSalarie(string nom, string prenom)
        {
            return ChercherSalarieHelper(boss, nom, prenom);
        }
        public static Salarie ChercherSalarieHelper(Salarie chef, string nom, string prenom)
        {
            if (chef.Nom == nom && chef.Prenom == prenom)
                return chef;
            foreach (Salarie e in chef.Employes)
            {
                Salarie test = ChercherSalarieHelper(e, nom, prenom);
                if (test != null)
                    return test;
            }
            return null;
        }
        public void LireFichierClient(string fichier)
        {
            //TODO
            string[] lines = File.ReadAllLines(fichier);
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                string nom = words[0];
                string prenom = words[1];
                DateTime dt = DateTime.Parse(words[2]);
                string adressepostale = words[3];
                string adressemail = words[4];
                string telephone = words[5];
                string numSS = words[6];
                Clients client = new Clients(nom, prenom, dt, adressepostale, adressemail, telephone, numSS);
                clients.Add(client);
            }

        }
        public void EnregistrerClient(string fichier)
        {
            List<string> lines = new List<string>();
            foreach (Clients client in clients)
            {
                string line = $"{client.Nom};{client.Prenom};{client.Datedenaissance.ToShortDateString()};{client.Adressepostale};{client.Adressemail};{client.Telephone};{client.NumSS}";
                lines.Add(line);
            }

            File.WriteAllLines(fichier, lines);
        }
        public static List<Salarie> GetAllSalarie(Salarie chef, List<Salarie> salarie = null)
        {
            if (salarie == null)
                salarie = new List<Salarie>();
            salarie.Add(chef);
            foreach (Salarie e in chef.Employes)
            {
                GetAllSalarie(e, salarie);
            }
            return salarie;
        }
        public void EnregistrerSalaries(string fichier)
        {
            List<string> lines = new List<string>();
            foreach (Salarie salarie in GetAllSalarie(boss))
            {
                string line = $"{salarie.Nom};{salarie.Prenom};{salarie.Datedenaissance.ToShortDateString()};{salarie.Adressepostale};{salarie.Adressemail};{salarie.Telephone};{salarie.NumSS};{salarie.TarifHoraire};{salarie.Dateentreesociete.ToShortDateString()};{salarie.Poste};";
                line += String.Join(',', salarie.Employes.Select(e => e.Nom + " " + e.Prenom));
                lines.Add(line);
            }

            File.WriteAllLines(fichier, lines);
        }

        public void LireFichierSalarie(string fichier)
        {
            string[] lines = File.ReadAllLines(fichier);
            List<Salarie> ToutLesSalaries = new List<Salarie>();
            List<string[]> ToutLesEmployes = new List<string[]>();
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                string nom = words[0];
                string prenom = words[1];
                DateTime dt = DateTime.Parse(words[2]);
                string adressepostale = words[3];
                string adressemail = words[4];
                string telephone = words[5];
                string numSS = words[6];
                double tarifhoraire = double.Parse(words[7]);
                DateTime dateentreesociete = DateTime.Parse(words[8]);
                string poste = words[9];
                string[] employes = words[10].Split(',');
                Salarie salarie = new Salarie(nom, prenom, dt, adressepostale, adressemail, telephone, numSS, dateentreesociete, poste, tarifhoraire);
                ToutLesEmployes.Add(employes);
                ToutLesSalaries.Add(salarie);
            }
            for (int i = 0; i < ToutLesSalaries.Count; i++)
            {
                foreach (string employe in ToutLesEmployes[i])
                {
                    if (employe.Length > 0)
                    {
                        string[] words = employe.Split(' ');
                        string nom = words[0];
                        string prenom = words[1];
                        Salarie s = ToutLesSalaries.Find(e => e.Nom == nom && e.Prenom == prenom);
                        if (s != null)
                            ToutLesSalaries[i].Employes.Add(s);
                        else
                        {
                            Console.WriteLine($"Le salarie : {employe} n'existe pas");
                        }
                    }
                }
            }
            this.boss = ToutLesSalaries[0];
        }
        public Salarie ChauffeurDisponible()
        {
            return ChauffeurDisponibleHelper(boss);
        }
        public Salarie ChauffeurDisponibleHelper(Salarie chef)
        {
            bool chauffeurDejaAssigne = commandes.Any(c => c.Chauffeur == chef && !c.Livré);
            if (chef.Poste == "Chauffeur" && !chauffeurDejaAssigne)
                return chef;
            foreach (Salarie e in chef.Employes)
            {
                Salarie test = ChauffeurDisponibleHelper(e);
                if (test != null)
                    return test;
            }
            return null;
        }

        public void AjouterCommande(Clients client, Ville depart, Ville arrivee, double prix, Vehicule vehicule, DateTime datedeliv, string produit)
        {

            //Check si le client existe
            if (!clients.Contains(client))
            {
                clients.Add(client);
            }

            //Check si le chauffeur est disponible
            Salarie chauffeur = ChauffeurDisponible();
            if (chauffeur is null)
            {
                Console.WriteLine("Aucun chauffeur disponible");
                return;
            }
            DateTime Maintenant = DateTime.Now;
            string numero = $"{client.Nom[0]}{client.Prenom[0]}{Maintenant.Year}{Maintenant.Month}{Maintenant.Day}{Maintenant.Hour}{Maintenant.Minute}{Maintenant.Second}";
            Commande c = new Commande(chauffeur, client, depart, arrivee, prix, vehicule, datedeliv, produit, numero, graphVilles);
            commandes.Add(c);
        }
        public void LireFichierCommande(string fichier)
        {
            string[] lines = File.ReadAllLines(fichier);
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                string nomchauffeur = words[0];

                string prenomchauffeur = words[1];
                string nomclient = words[2];
                string prenomclient = words[3];
                string villedepart = words[4];
                string villearrivee = words[5];
                double prix = double.Parse(words[6]);
                string nomvehicule = words[7];
                DateTime datedeliv = DateTime.Parse(words[8]);
                string produit = words[9];
                string numero = words[10];
                Salarie chauffeur = ChercherSalarie(nomchauffeur, prenomchauffeur);
                Clients client = clients.Find(c => c.Nom == nomclient && c.Prenom == prenomclient);
                Ville Vdepart = graphVilles.ChercherVille(villedepart);
                Ville Varrivee = graphVilles.ChercherVille(villearrivee);
                Vehicule vehicule = vehicules.Find(v => v.Nom == nomvehicule);
                Commande c = new Commande(chauffeur, client, Vdepart, Varrivee, prix, vehicule, datedeliv, produit, numero, graphVilles);
                commandes.Add(c);
            }
        }
        public void EnregistrerCommande(string fichier)
        {
            List<string> lines = new List<string>();
            foreach (Commande c in commandes)
            {
                string str = $"{c.Chauffeur.Nom};{c.Chauffeur.Prenom};{c.Client.Nom};{c.Client.Prenom};{c.Depart.Nom};{c.Arrivee.Nom};{c.Prix};{c.Vehicule.Nom};{c.Datedeliv.ToShortDateString()};{c.Produit};{c.Numero};{c.Livré};{c.Payé}";
                lines.Add(str);
            }
            File.WriteAllLines(fichier, lines);
        }
        public void ModifierCommande(string numerocommande)
        {
            Commande c = commandes.Find(com => com.Numero == numerocommande);
            if (c is null)
            {
                Console.WriteLine("Commande introuvable");
                return;
            }
            Console.WriteLine("Que voulez vous faire?");
            Console.WriteLine("1. Modifier le client");
            Console.WriteLine("2. Modifier l'état de la commande");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    Console.WriteLine("Entrez le nom du client");
                    string nom = Console.ReadLine();
                    Console.WriteLine("Entrez le prénom du client");
                    string prenom = Console.ReadLine();
                    Clients client = clients.Find(c => c.Nom == nom && c.Prenom == prenom);
                    if (client is null)
                    {
                        Console.WriteLine("Client introuvable");
                        return;
                    }
                    c.Client = client;
                    break;
                case "2":
                    Console.WriteLine("Entrez le nouvel état de la commande(1. Livré, 2. Payé, 3. Livré et payé)");
                    string etat = Console.ReadLine();
                    switch (etat)
                    {
                        case "1":
                            c.Livré = true;
                            break;
                        case "2":
                            c.Payé = true;
                            break;
                        case "3":
                            c.Payé = true;
                            c.Livré = true;
                            break; 
                        default:
                            Console.WriteLine("Etat inconnu");
                            break;
                         
                    }
                    break;

            }

        }
        public int NombreLivraisons(Salarie chauffeur)
        {
            int compteur = commandes.Where(c => c.Chauffeur.Equals(chauffeur)).Count();
            return compteur;
        }
        public void AfficherStatChauffeurs()
        {
            AfficherStatChauffeurHelper(boss);
        }
        public void AfficherprixCommande(string numero)
        {

            Commande c = commandes.Find(com => com.Numero == numero);
            if (c is null)
            {
                Console.WriteLine("Commande introuvable");
                return;
            }
            double prixcommande = c.TarifCommande(c.Chauffeur);
            {
                Console.WriteLine($"Le prix de la commande est de {prixcommande}");
            }
            

        }
        public void AfficherCheminCommande(string numero)
        {

            Commande c = commandes.Find(com => com.Numero == numero);
            if (c is null)
            {
                Console.WriteLine("Commande introuvable");
                return;
            }
            Dijkstra chemin = new Dijkstra(graphVilles, c.Depart);
            chemin.AfficherCheminPlusCourt(c.Arrivee);
        }
            public void AfficherStatChauffeurHelper(Salarie chef)
        {

            if (chef.Poste == "Chauffeur")
                Console.WriteLine($"{chef.Nom} {chef.Prenom}: {NombreLivraisons(chef)}");
            foreach (Salarie s in chef.Employes)
                AfficherStatChauffeurHelper(s);

        }
        public void AfficherStatCommande(int mois)
        {
            List<Commande> commandesdumois = commandes.Where(c => c.Datedeliv.Month == mois).ToList();
            foreach (Commande c in commandesdumois)
                Console.WriteLine(c.ToString());
        }
        public void AffichermoyennePrix()
        {
            List<Commande> commandesfinies = commandes.Where(c => c.Payé).ToList();
            double sommetotale = 0;
            foreach (Commande c in commandesfinies)
                sommetotale += c.Prix;

            double moyenne = commandesfinies.Count() > 0 ? sommetotale / commandesfinies.Count() : 0;
            Console.WriteLine($"Voici la moyenne des prix des commandes: {moyenne}");
        }
        public void AfficherStatCompteClients()
        {
            double moyenne = 0;
            foreach (Clients c in clients)
            {
                double sumcclient = commandes.Where(co => co.Client == c).Sum(co => co.Prix);
                moyenne += sumcclient;
            }
            moyenne = clients.Count() > 0 ? moyenne / clients.Count() : 0;
            Console.WriteLine($"Les clients ont passé en moyenne {moyenne} euros de commande");

        }
        public void AfficherCommandesClient(Clients c)
        {
            List<Commande> commandesclient = commandes.Where(co => co.Client == c).ToList();
            Console.WriteLine($"{c.Nom} {c.Prenom}:\n{commandesclient.Select(cl => cl.ToString() + "\n")}");
        }
       
         
        
    }
}
