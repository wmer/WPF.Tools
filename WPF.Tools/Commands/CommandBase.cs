using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.Tools.Commands {
    public abstract class CommandBase<T> where T : class {
        private DelegateCommand<T> _command;

        public CommandBase() {
            _command = new DelegateCommand<T>(Execute, CanExecute);
        }

        public DelegateCommand<T> Command {
            get { return _command; }
        }

        public virtual bool CanExecute(object parameter) => true;

        public abstract void Execute(object parameter);

        public void RaiseCanExecuteChanged() =>
                            Command.RaiseCanExecuteChanged();
    }


    public abstract class CommandBase : ICommand {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) => true;
        public abstract void Execute(object parameter);

        public void RaiseCanExecuteChanged() {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
