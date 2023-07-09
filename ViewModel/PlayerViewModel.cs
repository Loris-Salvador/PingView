using Infrastructure;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Command;
using ViewModel.Navigation;
using AccesDB;
using System.Collections.ObjectModel;
using FonctionUtil;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ViewModel
{
    public class PlayerViewModel : ViewModelBase
    {
        private readonly MyData _data = MyData.getInstance();

        private Rencontre _rencontreSelectionne;

        public Rencontre RencontreSelectionne
        {
            get { return _rencontreSelectionne; }
            set
            {
                _rencontreSelectionne = value;
                _rencontreSelectionne = GetRencontre.GetDetailsRencontre(_rencontreSelectionne);
                Console.WriteLine(RencontreSelectionne.Score + RencontreSelectionne.ScoreHome);
                OnPropertyChanged();
            }
        }


        private Joueur _mainJoueur;
        public Joueur MainJoueur
        {
            get { return _mainJoueur; }
            set
            {
                if (_mainJoueur == value) return;
                _mainJoueur = value;
               
            }
        }


        public ObservableCollection<Rencontre> Rencontres
        {
            get { return _data.Rencontres; }
            set { _data.Rencontres = value; }
        }

        private int _spanJoueur = 1;
        public int SpanJoueur
        {
            get { return _spanJoueur; }

            set
            {
                if (value == _spanJoueur) return;
                _spanJoueur = value;
                OnPropertyChanged();
            }
        }

        private bool _isGridMatchesVisible = true;

        public bool IsGridMatchesVisible
        {
            get { return _isGridMatchesVisible; }

            set
            {
                if (value == _isGridMatchesVisible) return;
                if (value == true)
                    SpanJoueur = 1;
                else
                {
                    SpanJoueur = 3;
                }
                _isGridMatchesVisible = value;
                OnPropertyChanged();
            }
        }



        public ICommand RechercherCommand { get; }
        public ICommand ParametreCommand { get; }

        public PlayerViewModel(NavigationStore navigationStore)
        {
            _rencontreSelectionne = new Rencontre();

            _data.Load("Data.json");


            MainJoueur = GetJoueur.getJoueurWithIndex(_data.Index);

            Console.WriteLine(MainJoueur);


            if(_data.Reload == true)
                Rencontres = GetRencontre.GetRencontresJoueur(MainJoueur);//charger dans un cas precis
            _data.Reload = false;


            RechercherCommand = new RechercherCommand(navigationStore);
            ParametreCommand = new ParametreCommand(navigationStore);
        }

        public override void Dispose()
        {
            _data.Save("Data.json");

            base.Dispose();
        }

    }
}
