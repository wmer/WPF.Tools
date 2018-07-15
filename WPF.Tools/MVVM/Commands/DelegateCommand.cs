using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.Tools.MVVM.Commands {
    public class DelegateCommand<T> : ICommand where T : class {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public event EventHandler CanExecuteChanged;


        public DelegateCommand(Action<T> execute)
            : this(execute, null) {
        }

        public DelegateCommand(Action<T> execute, Predicate<T> canExecute) {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public void Execute(object parameter) =>
                            _execute((T)parameter);

        public void RaiseCanExecuteChanged() =>
                        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public class DelegateCommand : ICommand {
        public event EventHandler CanExecuteChanged;
        private readonly Action _execute;

        public DelegateCommand(Action execute) {
            _execute = execute;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _execute();

        public void RaiseCanExecuteChanged() =>
                        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
