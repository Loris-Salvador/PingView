using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Joueur
    {
        #region Declarations
        private string _index;

        public string Index
        {
            get { return _index; }
            set { _index = value; }
        }

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

        #endregion

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
            return Nom + " " + Prenom + " " + Classement;
            //return "Nom : " + Nom + "\n" + "Prenom : " + Prenom + "\n" + "Classement : " + Classement + "\n" + "Club : " + Club + "\n" + "Position : " + Position + "\n" + "Points : " + Points + "\n" + "NbVictoires : " + NbVictoires + "\n" + "NbDefaites : " + NbDefaites;
        }

        public string NomComplet => $"{char.ToUpper(Nom[0])}{Nom.Substring(1).ToLower()} {char.ToUpper(Prenom[0])}{Prenom.Substring(1).ToLower()}";

        public string FuturClassement
        {
            get
            {
                if(Points > 1575)
                {
                    if (Position <= 75)
                    {
                        return "B0";
                    }
                    else if(Position <= 225)
                    {
                        return "B2";
                    }
                    else if(Position <= 500)
                    {
                        return "B4";
                    }
                    else if(Position <=1000)
                    {
                        return "B6";
                    }
                    else
                    {
                        return "C0";
                    }
                }
                return "";
            }
        }

        public string Ratio
        {
            get
            {
                return NbVictoires + " V - " + NbDefaites + " D";
            }
        }

        public string PourcentageVictoireWidth
        {
            get
            {
                string ratio =  (double)NbVictoires / (double)(NbVictoires + NbDefaites) + "*";
                return ratio.Replace(",", ".");
            }
        }

        public string PourcentageDefaiteWidth
        {
            get
            {
                string ratio = (double)NbDefaites / (double)(NbVictoires + NbDefaites) + "*";
                return ratio.Replace(",", ".");
            }
        }

        public string PourcentageVictoire
        {
            get
            {
                double ratio = (double)NbVictoires / (double)(NbVictoires + NbDefaites) * 100;
                int approximation = (int)Math.Round(ratio);
                return approximation + "%";
            }
        }

        public string PourcentageDefaite
        {
            get
            {
                double ratio = (double)NbDefaites / (double)(NbVictoires + NbDefaites) * 100;
                int approximation = (int)Math.Round(ratio);
                return approximation + "%";
            }
        }

    }
}
