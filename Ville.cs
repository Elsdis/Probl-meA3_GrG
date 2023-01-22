using System;
using System.Collections.Generic;
using System.Text;

namespace ProblèmeA3_GrG
{
    public class Ville
    {
        private string nom;
        private int index;
        

        public string Nom
        {
            get
            {
                return this.nom;
            }
            set
            {
                this.nom = value;
            }
        }
        public int Index
        {
            get
            {

                return this.index;
            }
            set
            {
                this.index = value;
            }
        }

        public Ville(string name, int index)
        {
            this.nom = name;
            this.index = index;
        }
    }
}