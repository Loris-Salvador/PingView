using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Joueur
    {
        private string _nom;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        private string _prenom;

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value;}
        }

        private string _club;

        public string Club
        {
            get { return _club; }
            set { _club = value;}
        }

        private int _nbVictoires;

        public int NbVictoires
        {
            get { return _nbVictoires;}
            set { _nbVictoires = value;}
        }

        private int _nbDefaites;

        public int NbDefaites
        {
            get { return _nbDefaites; }
            set { _nbDefaites = value;}
        }

        private string _classement;

        public string Classement
        {
            get { return _classement; }
            set { _classement = value;}
        }

        private int _position;

        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }

        private int _points;

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        private string _pdp;

        public string Pdp
        {
            get { return _pdp; }
            set { _pdp = value;}
        }

        public Joueur(string nom, string prenom, string club, int nbVictoires, int nbDefaites, string classement, int position, int points, string pdp)
        {
            Nom = nom;
            Prenom = prenom;
            Club = club;
            NbDefaites = nbDefaites;
            NbVictoires = nbVictoires;
            Classement = classement;
            Position = position;
            Points = points;
            Pdp = pdp;
        }

        public Joueur() : this("pas de nom", "pas de prenom", "pas de club", -1, -1, "pas de classement", -1, -1, "")
        {

        }


        public override string ToString()
        {
            return "Nom : " + Nom + "\n" + "Prenom : " + Prenom + "\n" + "Classement : " + Classement + "\n" + "Club : " + Club + "\n" + "Position : " + Position + "\n" + "Points : " + Points;
        }
    }
}
