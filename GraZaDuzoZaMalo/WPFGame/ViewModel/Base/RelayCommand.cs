using System;
using System.Windows.Input;

namespace WPFGame
{
    public class RelayCommand : ICommand
    {
        private Action action;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action action)
        {
            this.action = action;
        }

        /// <summary>
        /// Commands can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}