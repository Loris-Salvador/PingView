using Infrastructure;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ViewModel.Wrappers
{
    public class JoueurWrapper : WrapperBase
    {
        private Joueur _joueur => (Joueur)Content;
        public JoueurWrapper(object content) : base(content)
        {
        }

        public string Nom
        {
            get => _joueur.Nom;
            set
            {
                if (value == _joueur.Nom)
                    return;
                _joueur.Nom = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NomComplet));
            }
        }

        public string Prenom
        {
            get => _joueur.Prenom;
            set
            {
                if (value == _joueur.Prenom)
                    return;
                _joueur.Prenom = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NomComplet));
            }
        }

        public string Club
        {
            get => _joueur.Club;
            set
            {
                if (value == _joueur.Club)
                    return;
                _joueur.Club = value;
                OnPropertyChanged();
            }
        }

        public int NbVictoires
        {
            get => _joueur.NbVictoires;
            set
            {
                if (value == _joueur.NbVictoires)
                    return;
                _joueur.NbVictoires = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Ratio));
                OnPropertyChanged(nameof(PourcentageVictoire));
                OnPropertyChanged(nameof(PourcentageDefaite));
            }
        }

        public int NbDefaites
        {
            get => _joueur.NbDefaites;
            set
            {
                if (value == _joueur.NbDefaites)
                    return;
                _joueur.NbDefaites = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Ratio));
                OnPropertyChanged(nameof(PourcentageVictoire));
                OnPropertyChanged(nameof(PourcentageDefaite));
            }
        }

        public string Classement
        {
            get => _joueur.Classement;
            set
            {
                if (value == _joueur.Classement)
                    return;
                _joueur.Classement = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FuturClassement));

            }
        }

        public int Position
        {
            get => _joueur.Position;
            set
            {
                if (value == _joueur.Position)
                    return;
                _joueur.Position = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FuturClassement));
            }
        }

        public int Points
        {
            get => _joueur.Points;
            set
            {
                if (value == _joueur.Points)
                    return;
                _joueur.Points = value;
                OnPropertyChanged();
            }
        }

        public string NomComplet => $"{char.ToUpper(Nom[0])}{Nom.Substring(1).ToLower()} {char.ToUpper(Prenom[0])}{Prenom.Substring(1).ToLower()}";

        public string FuturClassement
        {
            get
            {
                if (Points > 1575)
                {
                    if (Position <= 75)
                    {
                        return "B0";
                    }
                    else if (Position <= 225)
                    {
                        return "B2";
                    }
                    else if (Position <= 500)
                    {
                        return "B4";
                    }
                    else if (Position <= 1000)
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
