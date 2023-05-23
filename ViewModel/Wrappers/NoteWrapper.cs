using Infrastructure;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Wrappers
{
    public class WrapperNote : WrapperBase
    {
        private readonly Note _note;

        public string Nom
        {
            get => _note.Nom;
            set
            {
                if (value == _note.Nom)
                    return;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _note.Description;
            set
            {
                if (value == _note.Description)
                    return;
                OnPropertyChanged();
            }
        }

        public DateTime Created
        {
            get => _note.Created;
            set
            {
                if (value == _note.Created)
                    return;
                OnPropertyChanged();
            }
        }

        public WrapperNote(object content) : base(content)
        {
            _note = (Note)content;
        }
    }
}
