using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace WPF.Tools.MVVM.Commands {
    public class EventToCommand : TriggerAction<DependencyObject> {
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
            "CommandParameter", typeof(object), typeof(EventToCommand), null);

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", typeof(ICommand), typeof(EventToCommand), new UIPropertyMetadata(null));

        public static readonly DependencyProperty InvokeParameterProperty = DependencyProperty.Register(
            "EventArgs", typeof(object), typeof(EventToCommand), null);

        private string commandName;

        public object EventArgs {
            get => GetValue(InvokeParameterProperty);
            set {
                this.SetValue(InvokeParameterProperty, value);
            }
        }


        public ICommand Command {
            get => (ICommand)this.GetValue(CommandProperty);
            set {
                this.SetValue(CommandProperty, value);
            }
        }

        public string CommandName {
            get => commandName;
            set {
                if (this.CommandName != value) {
                    this.commandName = value;
                }
            }
        }

        public object CommandParameter {
            get => GetValue(CommandParameterProperty);
            set {
                this.SetValue(CommandParameterProperty, value);
            }
        }

        public object Sender { get; set; }

        protected override void Invoke(object parameter) {
            this.EventArgs = parameter;
            if (this.AssociatedObject != null) {
                ICommand command = this.Command;
                if ((command != null) && command.CanExecute(this.CommandParameter)) {
                    command.Execute(this.CommandParameter);
                }
            }
        }
    }
}
