using System;
using System.Windows.Input;

namespace Emulator.Chip8.Gui.ViewModels
{
    public class UiCommand : ICommand
    {
        private Action action;

        public UiCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }

        public event EventHandler CanExecuteChanged;
    }
}