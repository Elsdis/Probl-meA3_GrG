using System;

namespace ProblèmeA3_GrG
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Transconnect app = new Transconnect("test.csv","truc");
            app.AfficherArbre();
            app.EnregistrerSalaries("test.csv");
        }
    }
}
