using System.Windows.Input;

namespace Calculator.ViewsModels
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> action;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<T> action)
        {
            this.action = action;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            action((T)parameter);
        }
    }
}