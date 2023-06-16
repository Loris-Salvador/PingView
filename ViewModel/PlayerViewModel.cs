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

        private Rencontre _rencontreSelectionne;

        public Rencontre RencontreSelectionne
        {
            get { return _rencontreSelectionne; }
            set
            {
                _rencontreSelectionne = value;
                _rencontreSelectionne = GetRencontre.GetDetailsRencontre(_rencontreSelectionne);
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

        private ObservableCollection<WrapperNote> _notes = new ObservableCollection<WrapperNote>();

        public ObservableCollection<WrapperNote> notes
        {
            get { return _notes; }
            set { _notes =  value; }    
        }

        private ObservableCollection<Rencontre> _rencontres = new ObservableCollection<Rencontre>();

        public ObservableCollection<Rencontre> Rencontres
        {
            get { return _rencontres; }
            set { _rencontres = value; }
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
        public ICommand ParametreCommand { get; }

        public PlayerViewModel(NavigationStore navigationStore)
        {

            _data.Load("FichierTest.json");

            foreach (Note note in _data.Notes)
            {
                WrapperNote n = new WrapperNote(new Note());
                n.Nom = note.Nom;
                n.Description = note.Description;
                n.Created = note.Created;
                notes.Add(n);
            }
            _data.Notes.Clear();


            MainJoueur = GetJoueur.getJoueurWithIndex(_data.Index);


            _rencontres = new ObservableCollection<Rencontre>();
            _rencontres = GetRencontre.GetRencontresJoueur(MainJoueur);//F
            


            AjouterNoteCommand = new AjouterNoteCommand(this);
            NoteCommand = new NoteCommand(this);
            RechercherCommand = new RechercherCommand(navigationStore);
            SupprimerNoteCommand = new SupprimerNoteCommand(this);
            ParametreCommand = new ParametreCommand(navigationStore);
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

            _data.Save("FichierTest.json");

            base.Dispose();
        }

    }
}
