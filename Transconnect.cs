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
        private Graph graphVilles;
        private List<Clients> clients;
        private Salarie CEO;
        
        
        public Transconnect(Salarie CEO, string fichier)
        {
            this.CEO = CEO;
            this.clients = new List<Clients>();
            if (File.Exists(fichier))
            {
                LireFicher(fichier);
            }
        }
        public Transconnect(string fichierSalarie, string fichierClient)
        {
            this.clients = new List<Clients>();
            if (File.Exists(fichierClient))
            {
                LireFicher(fichierClient);
            }
            if (File.Exists(fichierSalarie))
            {
                LireFichierSalarie(fichierSalarie);
            }
        }
        public int GetTreeLength()
        {
            return GetTreeLengthHelper(CEO);
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
            int size = GetTreeLength();
            bool[] flag = new bool[size];
            for (int i = 0; i < size; i++)
            {
                flag[i] = true;
            }
            AfficherArbreHelper(this.CEO, 0, flag);
        }
        public static void AfficherArbreHelper(Salarie chef, int niveau, bool[] flag, bool isLast = false)
        {
            if (flag == null)
            {
                
            }
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
                AfficherArbreHelper(chef.Employes[chef.Employes.Count-1], niveau + 1, flag, true);
            }
            flag[niveau] = true;
        }
        public void AjouterSalarie(Salarie aAjouter,string nom,string prenom)
        {
            Salarie s = ChercherSalarie(nom, prenom);
            if (s == null)
                Console.WriteLine("Le salarie n'existe pas");
            else if(s.Employes.Contains(aAjouter))
                Console.WriteLine($"{aAjouter.Nom} {aAjouter.Prenom} est déjà un employé de {nom} {prenom}");
            else
                s.Employes.Add(aAjouter);
        }
        public void SupprimerSalarie(string nom,string prenom)
        {
            bool supressed = SupprimerSalarieHelper(CEO, nom, prenom);
            if(supressed)
            {
                Console.WriteLine($"{nom} {prenom} a été supprimé");
            }
            else
                Console.WriteLine($"{nom} {prenom} n'existe pas");
        }
        public static bool SupprimerSalarieHelper(Salarie chef,string nom, string prenom)
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
            return ChercherSalarieHelper(CEO, nom, prenom);
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
        public void LireFicher(string fichier)
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
        public static HashSet<Salarie> GetAllSalarie(Salarie chef, HashSet<Salarie> salarie = null)
        {
            if (salarie == null)
                salarie = new HashSet<Salarie>();
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
            foreach (Salarie salarie in GetAllSalarie(CEO))
            {
                string line = $"{salarie.Nom};{salarie.Prenom};{salarie.Datedenaissance.ToShortDateString()};{salarie.Adressepostale};{salarie.Adressemail};{salarie.Telephone};{salarie.NumSS};{salarie.Salaire};{salarie.Dateentreesociete.ToShortDateString()};{salarie.Poste};";
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
                double salaire = double.Parse(words[7]);
                DateTime dateentreesociete = DateTime.Parse(words[8]);
                string poste = words[9];
                string[] employes = words[10].Split(',');
                Salarie salarie = new Salarie(nom, prenom, dt, adressepostale, adressemail, telephone, numSS, dateentreesociete, poste, salaire );
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
                        if(s!=null)
                        ToutLesSalaries[i].Employes.Add(s);
                        else
                        {
                            Console.WriteLine($"Le salarie : {employe} n'existe pas");
                        }
                    }
                }
            }
            this.CEO = ToutLesSalaries[0];
        }
    }
}
