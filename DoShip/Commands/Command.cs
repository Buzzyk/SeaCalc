using System;
using System.Windows.Input;

namespace DoShip.Commands
{
    internal abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        protected void OnCanExecuteChange()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }




}
