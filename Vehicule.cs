using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblèmeA3_GrG
{
    public abstract class Vehicule
    {
        //attributs

        protected int roues;
        protected double fuel;
        protected string immatriculation;
        protected string nom;
        protected double tarifKilometrique;

        //propriétés

        public int Roues
        {
            get { return roues; }   
        }

        public double Fuel
        {
            get { return fuel; }
        }

        public string Immatriculation
        {
                get { return immatriculation; }
        }
        public string Nom
        {
            get { return nom; }
        }

        public double TarifKilometrique
        {
            get { return tarifKilometrique; }
        }

        //Constructeur

        public Vehicule(int roues, double fuel, string imma)
        {
            this.roues = roues;
            this.fuel = fuel;
            this.immatriculation = imma;
        }

        public override string ToString()
        {
            return roues + "" + fuel + " " + immatriculation;
        }
    }
}
