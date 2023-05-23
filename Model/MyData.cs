using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MyData
    {
        public ObservableCollection<Note> Notes { get; set; }

        private string _index;

        private Joueur _MainJoueur = new Joueur();

        public Joueur MainJoueur
        {
            get { return _MainJoueur; }
            set { _MainJoueur = value; }
        }


        public string Index
        {
            get { return _index; }
            set { _index = value; }
        }

        private MyData()
        {

        }

        private static MyData Instance = new MyData();

        public static MyData getInstance()
        {
            return Instance;
        }


    }
}
