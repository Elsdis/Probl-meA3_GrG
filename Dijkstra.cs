using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProblèmeA3_GrG
{
    public class Dijkstra
    {
        private Graph graph;
        private Ville source;
        private int[] distance;
        private int[] temps;
        private Ville[] precedant;
        private bool[] visite;

        public Dijkstra(Graph graph, Ville source)
        {
            this.graph = graph;
            this.source = source;
            distance = new int[graph.Adjacents.Count];
            temps = new int[graph.Adjacents.Count]; 
            precedant = new Ville[graph.Adjacents.Count];
            visite = new bool[graph.Adjacents.Count];
            foreach (Ville v in graph.Adjacents.Keys)
            {
                distance[v.Index] = int.MaxValue;
                temps[v.Index] = int.MaxValue;
                precedant[v.Index] = null;
                visite[v.Index] = false;
            }
            distance[source.Index] = 0;
            temps[source.Index] = 0;
            precedant[source.Index] = source;
        }

        public void CheminPlusCourt()
        {
            Ville u = source;
            while (u != null)
            {
                visite[u.Index] = true;

                foreach (Tuple<Ville, int,int> v in graph.Adjacents[u])
                {
                    if (!visite[v.Item1.Index])
                    {
                        if (distance[v.Item1.Index] > distance[u.Index] + v.Item2)
                        {
                            distance[v.Item1.Index] = distance[u.Index] + v.Item2;
                            temps[v.Item1.Index] = temps[u.Index] + v.Item3;
                            precedant[v.Item1.Index] = u;
                        }
                    }
                }
                u = null;
                int min = int.MaxValue;
                foreach (Ville v in graph.Adjacents.Keys)
                {
                    if (!visite[v.Index] && distance[v.Index] < min)
                    {
                        min = distance[v.Index];
                        u = v;
                    }
                }
            }
        }
        public int[] obtenirtempsdistance(Ville destination)
        {
            return new int[2] { temps[destination.Index], distance[destination.Index] };
        }

        public void AfficherCheminPlusCourt(Ville destination)
        {
            if (precedant[destination.Index] != null)
            {
                Console.WriteLine("Le chemin le plus court entre " + source.Nom + " et " + destination.Nom + " est de " + distance[destination.Index] + " km.");
                Stack<Ville> chemin = new Stack<Ville>();
                Ville courrant = destination;
                while (courrant != source)
                {
                    chemin.Push(courrant);
                    courrant = precedant[courrant.Index];
                }
                string resultat = "Cette distance est obtenue en passant par : " + chemin.Pop().Nom;
                while (chemin.Count > 0)
                    resultat += " => " + chemin.Pop().Nom;
                Console.WriteLine(resultat);
            }
            else
            {
                Console.WriteLine("Il n'y a pas de chemin entre " + source.Nom + " et " + destination.Nom + ".");
            }
        }
    }
}
