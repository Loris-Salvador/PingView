using Infrastructure;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Wrappers;

namespace ViewModel.Command
{
    public class SupprimerNoteCommand : CommandBase
    {
        private readonly PlayerViewModel _playerViewModel;

        public SupprimerNoteCommand(PlayerViewModel playerViewModel)
        {
            _playerViewModel = playerViewModel;
        }
        public override void Execute(object parameter)
        {
            Console.WriteLine("Supprimer Note Pressed");

            if(_playerViewModel.SelectedNote != -1)
                _playerViewModel.notes.RemoveAt(_playerViewModel.SelectedNote);
        }
    }
}
