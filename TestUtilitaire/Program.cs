using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using AccesDB;

namespace TestUtilitaire
{
    public class Program
    {
        static void Main(string[] args)
        {

            Joueur j = new Joueur();

            j = AccesJoueur.getMainJoueur("150121");


            Console.WriteLine(j);

            Console.ReadKey();
        }
    }
}
