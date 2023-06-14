using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using AccesDB;
using FonctionUtil;

namespace TestUtilitaire
{
    public class Program
    {
        static void Main(string[] args)
        {

            Joueur j = new Joueur();

            j = GetJoueur.getJoueurWithIndex("150121");


            Console.WriteLine(j);
            Console.WriteLine("Futur Classement : "  + j.FuturClassement);

            Console.ReadKey();
        }
    }
}
