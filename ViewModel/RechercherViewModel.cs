using Infrastructure;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Command;
using ViewModel.Navigation;
using ViewModel.Wrappers;
using AccesDB;

namespace ViewModel
{
    public class RechercherViewModel : ViewModelBase
    {
        private Joueur _joueurSelectionne;

        public Joueur JoueurSelectionne
        {
            get { return _joueurSelectionne; }
            set
            {
                _joueurSelectionne = value;
                _joueurSelectionne = GetJoueur.getJoueurWithIndex(_joueurSelectionne.Index);
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Joueur> _listeJoueur = new ObservableCollection<Joueur>();

        public ObservableCollection<Joueur> ListeJoueur
        {
            get { return _listeJoueur; }
            set
            {
                _listeJoueur = value;
                OnPropertyChanged();
            }
        }



        private string _nom = "";
        public string Nom
        {
            get { return _nom; }

            set
            {
                if (value == _nom ) return;
                _nom = value;
                OnPropertyChanged();
                if(_nom.Length > 4)
                {
                    ListeJoueur = GetJoueur.getListJoueurWithNom(Nom);
                }
            }
        }

        private string _classement;
        public string Classement
        {
            get { return _classement; }

            set
            {
                if (value == _classement) return;
                _classement = value;
                OnPropertyChanged();
            }
        }

        private string _club = "";
        public string Club
        {
            get { return _club; }

            set
            {
                if (value == _club) return;
                _club = value;
                OnPropertyChanged();
            }
        }

/*        private void RechercheNom()
        {
            ListeJoueur = GetJoueur.getListJoueurWithNom(Nom);
            Console.WriteLine(ListeJoueur[0]);
        }*/


        public ICommand HomeCommand { get; }
        public RechercherViewModel(NavigationStore navigationStore)
        {
           HomeCommand = new HomeCommand(navigationStore);
        }
    }
}
