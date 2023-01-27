using System;

namespace ProblèmeA3_GrG
{
    class Program
    {
        static void AffichageFinal(Transconnect app)
        {
            Console.WriteLine("Bonjour, bienvenue sur l'application Transconnect");
            Console.WriteLine("Que voulez vous faire?");
            Console.WriteLine("1. Module Client");
            Console.WriteLine("2. Module Salarie");
            Console.WriteLine("3. Module Commande");
            Console.WriteLine("4. Module Satistique");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Que voulez vous faire?");
                    Console.WriteLine("1. Ajouter un client");
                    Console.WriteLine("2. Afficher les clients");
                    Console.WriteLine("3. Afficher les commandes d'un client");
                    Console.WriteLine("4. Retour");
                    string inputclient = Console.ReadLine();
                    switch (inputclient)
                    {
                        case "1":
                            Console.WriteLine("Entrez le nom du client");
                            string nom = Console.ReadLine();
                            Console.WriteLine("Entrez le prénom du client");
                            string prenom = Console.ReadLine();
                            Console.WriteLine("Entrez l'adresse postale du client");
                            string adresse = Console.ReadLine();
                            Console.WriteLine("Entrez l'adresse mail du client");
                            string mail = Console.ReadLine();
                            Console.WriteLine("Entrez le numéro de téléphone du client");
                            string telephone = Console.ReadLine();
                            Console.WriteLine("Entrez le numéro de sécurité social du client");
                            string nss = Console.ReadLine();
                            Clients nClient = new Clients(nom, prenom, DateTime.Now, adresse, mail, telephone, nss);
                            Console.WriteLine("Tapez une touche pour retourner:");
                            Console.ReadKey();
                            AffichageFinal(app);
                            break;
                        case "2":
                            foreach (Clients clients in app.clients)
                            {
                                Console.WriteLine(clients.ToString());
                            }
                            break;
                        case "3":
                            Console.WriteLine("Entrez le nom du client");
                            string nomclient = Console.ReadLine();
                            Console.WriteLine("Entrez le prénom du client");
                            string prenomclient = Console.ReadLine();
                            Clients client = app.clients.Find(c => c.Nom == nomclient && c.Prenom == prenomclient);
                            if (client is null)
                            {
                                Console.WriteLine("Client introuvable");
                                Console.WriteLine("Tapez une touche pour retourner:");
                                Console.ReadKey();
                                AffichageFinal(app);
                                return;
                            }
                            app.AfficherCommandesClient(client);
                            Console.WriteLine("Tapez une touche pour retourner:");
                            Console.ReadKey();
                            AffichageFinal(app);
                            break;
                        case "4":
                            AffichageFinal(app);
                            Console.WriteLine("Tapez une touche pour retourner:");
                            Console.ReadKey();
                            AffichageFinal(app);
                            break;
                        default:
                            Console.WriteLine("Commande inconnue");
                            Console.WriteLine("Tapez une touche pour retourner:");
                            Console.ReadKey();
                            AffichageFinal(app);
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("Que voulez vous faire?");
                    Console.WriteLine("1. Ajouter un salarié");
                    Console.WriteLine("2. Supprimer un salariés");
                    Console.WriteLine("3. Afficher les salariés");
                    Console.WriteLine("3. Retour");
                    string inputsalarie = Console.ReadLine();
                    switch (inputsalarie)
                    {
                        case "1":
                            Console.WriteLine("Entrez le nom du client");
                            string nom = Console.ReadLine();
                            Console.WriteLine("Entrez le prénom du client");
                            string prenom = Console.ReadLine();
                            Console.WriteLine("Entrez l'adresse postale du client");
                            string adresse = Console.ReadLine();
                            Console.WriteLine("Entrez l'adresse mail du client");
                            string mail = Console.ReadLine();
                            Console.WriteLine("Entrez le numéro de téléphone du client");
                            string telephone = Console.ReadLine();
                            Console.WriteLine("Entrez le numéro de sécurité social du client");
                            string nss = Console.ReadLine();
                            Console.WriteLine("Quel est le poste du nouveau salarié?");
                            Console.WriteLine("1. Chauffeur");
                            Console.WriteLine("2. Autre");
                            Console.WriteLine("3. Retour");
                            string poste = new string("");
                            string inputposte = Console.ReadLine();
                            switch (inputposte)
                            {
                                case "1":
                                    poste = "Chauffeur";
                                    
                                    break;
                                case "2":
                                    Console.WriteLine("Entrez le poste du nouveau salarié");
                                    poste = Console.ReadLine();
                                    ;
                                    break;
                                case "3":
                                    AffichageFinal(app);
                                    
                                    break;
                            }
                            Console.WriteLine("Entrez le salaire du nouveau salarié");
                            string salaire = Console.ReadLine();
                            double tarifHoraire;
                            bool success = double.TryParse(salaire, out tarifHoraire);
                            Salarie nSalarie = new Salarie(nom, prenom, DateTime.Now, adresse, mail, telephone, nss, DateTime.Now, poste, tarifHoraire);
                            Console.WriteLine("A qui ce salarié est-il afilié?");
                            Console.WriteLine("Nom?");
                            string bossp = Console.ReadLine();
                            Console.WriteLine("Prénom?");
                            string bossn = Console.ReadLine();
                            app.AjouterSalarie(nSalarie, bossp, bossn);
                            Console.WriteLine("Tapez une touche pour retourner:");
                            Console.ReadKey();
                            AffichageFinal(app);
                            break;
                        case "2":
                            Console.WriteLine("Entrez le nom du salarié");
                            string nomsalarie = Console.ReadLine();
                            Console.WriteLine("Entrez le prénom du salarié");
                            string prenomsalarie = Console.ReadLine();
                            app.SupprimerSalarie(nomsalarie, prenomsalarie);
                            Console.WriteLine("Tapez une touche pour retourner:");
                            Console.ReadKey();
                            AffichageFinal(app);
                            break;
                        case "3":
                            app.AfficherArbre();
                            Console.WriteLine("Tapez une touche pour retourner:");
                            Console.ReadKey();
                            AffichageFinal(app);
                            break;
                        case "4":
                            AffichageFinal(app);
                            Console.WriteLine("Tapez une touche pour retourner:");
                            Console.ReadKey();
                            AffichageFinal(app);
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine("Que voulez vous faire?");
                    Console.WriteLine("1. Calculer le prix d'une commande");
                    Console.WriteLine("2. Donner le chemin d'une commande");
                    string inputcomm = Console.ReadLine();
                    switch (inputcomm)
                    {
                        case "1":
                            Console.WriteLine("Entrez le numero de la commande");
                            string num = Console.ReadLine();
                            app.AfficherprixCommande(num);
                            Console.WriteLine("Tapez une touche pour retourner:");
                            Console.ReadKey();
                            AffichageFinal(app);
                            break;
                        case "2":
                            Console.WriteLine("Entrez le numero de la commande");
                            string num2 = Console.ReadLine();
                            app.AfficherCheminCommande(num2);
                            Console.WriteLine("Tapez une touche pour retourner:");
                            Console.ReadKey();
                            AffichageFinal(app);
                            break;

                    }
                    break;
                case "4":
                    Console.WriteLine("Voici les statistiques de l'entreprise:");
                    Console.WriteLine("Nombre de commandes livrées:");
                    app.AfficherStatCommande(DateTime.Now.Month);
                    Console.WriteLine("Nombre de commandes payées:");
                    app.AfficherStatCommande(DateTime.Now.Month);
                    Console.WriteLine("Nombre de commandes en cours:");
                    app.AfficherStatCommande(DateTime.Now.Month);
                    Console.WriteLine("Nombre de commandes par chauffeur:");
                    app.AfficherStatChauffeurs();
                    Console.WriteLine("Moyenne des prix des commandes:");
                    app.AffichermoyennePrix();
                    Console.WriteLine("Moyenne des prix des commandes par client:");
                    app.AfficherStatCompteClients();
                    Console.WriteLine("Nombre de commandes par client:");
                    foreach (Clients c in app.clients)
                        app.AfficherCommandesClient(c);
                    Console.WriteLine("Tapez une touche pour retourner:");
                    Console.ReadKey();
                    AffichageFinal(app);
                    break;
            }
        }
    
            static void Main(string[] args)
        {


            Transconnect app = new Transconnect("test.csv","truc");
            
            app.Boss = new Salarie("Jeff", "Bezos", new DateTime(10, 10, 10), "AAA", "aaa", "aaa", "numss", new DateTime(10, 10, 10), "op", 10.1);
                AffichageFinal(app);
                app.EnregistrerSalaries("test.csv");
                app.EnregistrerClient("truc.csv");
        }
    }
}
