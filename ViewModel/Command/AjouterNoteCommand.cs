using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Wrappers;
using Model;

namespace ViewModel.Command
{
    public class AjouterNoteCommand : CommandBase
    {
        private readonly PlayerViewModel _playerViewModel;

        public AjouterNoteCommand(PlayerViewModel playerViewModel)
        {
            _playerViewModel = playerViewModel;
        }
        public override void Execute(object parameter)
        {
            Console.WriteLine("Ajouter Note Pressed");

            _playerViewModel.notes.Add(new WrapperNote(new Note()));
        }
    }
}
