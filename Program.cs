using System;

namespace ProblèmeA3_GrG
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            Transconnect app = new Transconnect("test.csv","truc");
            app.Boss = new Salarie("Jeff", "Bezos", new DateTime(10, 10, 10), "AAA", "aaa", "aaa", "numss", new DateTime(10, 10, 10), "op", 10.1);
            app.AfficherArbre();
            app.EnregistrerSalaries("test.csv");
        }
    }
}
