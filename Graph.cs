
using System;
using System.Collections.Generic;
using System.Text;

namespace ProblèmeA3_GrG
{
    public class Graph
    {
        private Dictionary<Ville, List<Tuple<Ville, int,int>>> adjacents;

        public Dictionary<Ville, List<Tuple<Ville, int,int>>> Adjacents
        {
            get { return adjacents; }
            set { adjacents = value; }
        }

        public Graph()
        {
            adjacents = new Dictionary<Ville, List<Tuple<Ville, int,int>>>();
        }
        public Ville ChercherVille(string nom)
        {
            foreach (Ville v in adjacents.Keys)
            {
                if (v.Nom == nom)
                {
                    return v;
                }
            }
            return null;
        }
        public void LireFichierVille(string fichier)
        {
            string[] lignes = System.IO.File.ReadAllLines(fichier);
            int index = 0;
            foreach (string ligne in lignes)
            {
                string[] mots = ligne.Split(';');
                string nomville = mots[0];
                string nomdestination = mots[1];
                Ville depart = ChercherVille(nomville);
                if (depart == null)
                {
                    depart = new Ville(nomville, index);
                    index++;
                    adjacents.Add(depart, new List<Tuple<Ville, int, int>>());
                }
                else
                {
                    Ville destination = ChercherVille(nomdestination);
                    if (destination == null)
                    {
                        destination = new Ville(nomdestination, index);
                        index++;
                        adjacents.Add(destination, new List<Tuple<Ville, int, int>>());
                    }
                    int distance = int.Parse(mots[2]);
                    string[] temps = mots[3].Split('h');
                    int minutes = temps.Length == 2 ? int.Parse(temps[0]) * 60 + int.Parse(temps[1]) : int.Parse(temps[0].Split('m')[0]); ;
                    adjacents[depart].Add(new Tuple<Ville, int, int>(destination, distance, minutes));

                }

            }
        }

        public void AjouterVille(Ville vertex1, Ville vertex2, int distance,int temps)
        {
            if (!adjacents.ContainsKey(vertex1))
            {
                adjacents.Add(vertex1, new List<Tuple<Ville, int,int>>());
            }
            if (!adjacents.ContainsKey(vertex2))
            {
                adjacents.Add(vertex2, new List<Tuple<Ville, int,int>>());
            }
            adjacents[vertex1].Add(new Tuple<Ville, int,int>(vertex2, distance,temps));
            adjacents[vertex2].Add(new Tuple<Ville, int,int>(vertex1, distance,temps));
        }
    }
}
