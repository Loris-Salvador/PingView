using Infrastructure;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Wrappers
{
    public class JoueurWrapper : WrapperBase
    {
        private Joueur _note => (Joueur)Content;

        public string Club
        {
            get => _note.Club;
            set
            {
                if (value == _note.Club)
                    return;
                _note.Club = value;
                OnPropertyChanged();
            }
        }



        public JoueurWrapper(object content) : base(content)
        {

        }
    }
}
