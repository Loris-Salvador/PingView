using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ViewModel.Command
{
    public class NoteCommand : CommandBase
    {
        private readonly PlayerViewModel _playerViewModel;

        public NoteCommand(PlayerViewModel playerViewModel)
        {
            _playerViewModel = playerViewModel;
        }
        public override void Execute(object parameter)
        {
            Console.WriteLine("Note Pressed");
            if (_playerViewModel.SpanJoueur == 1)
                _playerViewModel.SpanJoueur = 3;
            else
                _playerViewModel.SpanJoueur = 1;
            _playerViewModel.IsGridNotesVisible = !_playerViewModel.IsGridNotesVisible;
            _playerViewModel.IsGridMatchesVisible = !_playerViewModel.IsGridMatchesVisible;
        }
    }
}
