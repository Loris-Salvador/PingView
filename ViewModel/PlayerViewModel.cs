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
using ViewModel.Wrappers;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class PlayerViewModel : ViewModelBase//
    {
        private readonly Joueur mainJoueur;
        public ObservableCollection<WrapperNote> notes { get ; private set; }

        public string Club => mainJoueur.Club;

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
                _isGridMatchesVisible = value;
                OnPropertyChanged();
            }
        }

        private bool _isGridNotesVisible = false;

        public bool IsGridNotesVisible
        {
            get { return _isGridNotesVisible; }

            set
            {
                if (value == _isGridNotesVisible) return;
                _isGridNotesVisible = value;
                OnPropertyChanged();
            }
        }
        public ICommand NoteCommand { get; }
        public ICommand RechercherCommand { get; }
        public ICommand CalculateurCommand { get; }

        public PlayerViewModel(NavigationStore navigationStore)
        {
            mainJoueur = new Joueur();
            mainJoueur = AccesJoueur.getMainJoueur("150121");
            notes = new ObservableCollection<WrapperNote>();
            notes.Add(new WrapperNote(new Note()));
            NoteCommand = new NoteCommand(this);
            RechercherCommand = new RechercherCommand(navigationStore);
        }

    }
}
