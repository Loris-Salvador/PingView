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
using ViewModel.Wrappers;

namespace ViewModel
{
    public class PlayerViewModel : ViewModelBase
    {
        private readonly MyData _data = MyData.getInstance();

        private JoueurWrapper _mainJoueur;

        public JoueurWrapper MainJoueur
        {
            get { return _mainJoueur; }
            set
            {
                if (_mainJoueur == value) return;
                _mainJoueur = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<WrapperNote> _notes = new ObservableCollection<WrapperNote>();

        public ObservableCollection<WrapperNote> notes
        {
            get { return _notes; }
            set { _notes =  value; }    
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

        private int _selectedNote;

        public int SelectedNote
        {
            get { return _selectedNote; }
            set
            {
                if (value == _selectedNote) return;
                _selectedNote = value;
                OnPropertyChanged();
            }
        }


        public ICommand NoteCommand { get; }
        public ICommand RechercherCommand { get; }
        public ICommand CalculateurCommand { get; }
        public ICommand AjouterNoteCommand { get; }
        public ICommand SupprimerNoteCommand { get; }

        public PlayerViewModel(NavigationStore navigationStore)
        {
            MainJoueur = new JoueurWrapper(new Joueur());
            AjouterNoteCommand = new AjouterNoteCommand(this);
            NoteCommand = new NoteCommand(this);
            RechercherCommand = new RechercherCommand(navigationStore);
            SupprimerNoteCommand = new SupprimerNoteCommand(this);
            Console.WriteLine(_mainJoueur.Club);
        }

        public override void Dispose()
        {
            foreach (WrapperNote wrapperNote in _notes)
            {
                Note n = new Note();
                n.Nom = wrapperNote.Nom;
                n.Description = wrapperNote.Description;
                n.Created = wrapperNote.Created;
                _data.Notes.Add(n);
            }
            base.Dispose();
        }

    }
}
