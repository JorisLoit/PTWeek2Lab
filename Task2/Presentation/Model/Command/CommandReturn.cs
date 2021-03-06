using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Presentation.ViewModel;

namespace Task2.Presentation.Model.Command
{
    internal class CommandReturn : CommandBase
    {
        private readonly MainWindowViewModel _mvw;
        private readonly MyLibrary _lib;

        public CommandReturn(MainWindowViewModel vwm, ref MyLibrary lib)
        {
            _mvw = vwm;
            _lib = lib;
        }
        public override void Execute(object parameter)
        {

            if (_mvw.SelectedCatalog != null && _mvw.SelectedUser != null)
            {
                _lib.Return(_mvw.SelectedCatalog.Title, _mvw.SelectedCatalog.Author, _mvw.SelectedUser);
                new CommandIsAvailible(this._mvw, _lib).Execute(this);
            }
        }
    }
}
