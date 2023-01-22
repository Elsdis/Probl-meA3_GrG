
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
